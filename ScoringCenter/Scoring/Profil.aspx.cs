using ScoringCenter.ScorManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ScoringCenter.Scoring
{
    public partial class Profil : System.Web.UI.Page
    {
        Scoringws service = new Scoringws();
        StringBuilder sblogo = new StringBuilder();
        StringBuilder sb = new StringBuilder();
        private System.Globalization.CultureInfo frCult = System.Globalization.CultureInfo.CreateSpecificCulture("fr-FR");
        protected void Page_Load(object sender, EventArgs e)
        {
            ControllerPage();
            AfficheLogoBank();
        }
        public void AfficheLogoBank()
        {
            if (Session["code_banque"] != null)
            {
                var code_banque = Session["code_banque"];
                var bankInfo = service.AfficheLogoBank(ScorCryptage.Decrypt(code_banque.ToString().Trim()));
                foreach (var banque in bankInfo)
                {

                    if (banque.IMG_BANQUE != "" && banque.IMG_BANQUE != null)
                    {
                        sb.AppendLine(string.Format("<img src=\"../Images/Logo/{0}\"style=\"width: 100% ;height:100%\" />", banque.IMG_BANQUE.ToString().Trim()));
                    }
                }
                idimgLogoBanque.InnerHtml = sb.ToString();
            }
        }
        public void ControllerPage()
        {
            ////Debut_Controle///////////////////////////////////////////////////
            if (Session["login"] == null) Response.Redirect("~/Scoring/Connexion.aspx");
            else
            {
                var idprofil = Session["id_profil"].ToString();
                var elements = service.VHABILITATION(idprofil);
                AD.Visible = false;
                TB.Visible = false;
                GP.Visible = false;
                GU.Visible = false;
                PARAM.Visible = false;
                GPA.Visible = false;
                Pay.Visible = false;
                //Con.Visible = false;

                var test = 0;

                foreach (var element in elements)
                {
                    if (element.ID_DROIT.ToString().Trim() == "AD")
                    {
                        if (element.ID_TYPE_DROIT.ToString().Trim() != "0") AD.Visible = true;
                    }

                    if (element.ID_DROIT.ToString().Trim() == "TB")
                    {
                        if (element.ID_TYPE_DROIT.ToString().Trim() != "0") TB.Visible = true;
                    }

                    if (element.ID_DROIT.ToString().Trim() == "GP")
                    {
                        if (element.ID_TYPE_DROIT.ToString().Trim() != "0") GP.Visible = true;
                    }
                    if (element.ID_DROIT.ToString().Trim() == "PARAM")
                    {
                        if (element.ID_TYPE_DROIT.ToString().Trim() != "0") PARAM.Visible = true;
                    }
                    if (element.ID_DROIT.ToString().Trim() == "GU")
                    {
                        if (element.ID_TYPE_DROIT.ToString().Trim() != "0") GU.Visible = true;
                    }
                    if (element.ID_DROIT.ToString().Trim() == "GPA")
                    {
                        if (element.ID_TYPE_DROIT.ToString().Trim() != "0") GPA.Visible = true;
                    }

                    if (element.ID_DROIT.ToString().Trim() == "Cen")
                    {
                       // if (element.ID_TYPE_DROIT.ToString().Trim() != "0") //Cen.Visible = true;
                    }
                    if (element.ID_DROIT.ToString().Trim() == "CC")
                    {
                        //if (element.ID_TYPE_DROIT.ToString().Trim() != "0") //CC.Visible = true;
                    }
                    if (element.ID_DROIT.ToString().Trim() == "Pay")
                    {
                        if (element.ID_TYPE_DROIT.ToString().Trim() != "0") Pay.Visible = true;
                    }
                    
                    //et pour les actions sur la page
                    if (element.ID_DROIT.ToString().Trim() == "GP")
                    {
                        // if (element.ID_TYPE_DROIT.ToString().Trim() != "0") AD.Visible = true;

                        
                        switch (element.ID_TYPE_DROIT.ToString().Trim())
                        {
                            case "1": test = 1;
                                Scriptos.InnerHtml = "<script>$(':input').removeAttr('disabled');</script>";
                                break;
                            case "2": if (test != 1)
                                {
                                    Scriptos.InnerHtml = "<script>$(':input').attr('disabled','disabled');</script>";
                                }
                                break;
                            default:
                                break;
                        }
                    }



                }
            }
            //getInfoClient(); EBF.Visible = false; ////Fin_Controle////////////////////////////////////////////////////
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            ListeBanque();
            RemplirGrille();
            InitCouleur();
            InitZone();
            EtatProfil.Checked = true;
        }

        public void InitZone()
        {
            TbNLibelleP.Text = "";
            TbNPlafond.Value = "";
            TbICodePro.Text = "";
            TbIdProfil.Text = "";
        }

        public void ListeBanque()
        {
            if (Session["code_banque"] == null) Response.Redirect("~/Scoring/Connexion.aspx");

            string param = Session["code_banque"].ToString();
            foreach (var element in service.ListeBanque(ScorCryptage.Decrypt(param)))
            {
                DdlBanque.Items.Add(new ListItem(element.SIGLE_BANQUE.ToString(), element.CODE_BANQUE));
            }
            LoadPlafonds();
        }
        
        public void RemplirGrille()
        {
            StringBuilder sb = new StringBuilder();
            string param = Session["code_banque"].ToString();
            var banques = service.ListeBanque(ScorCryptage.Decrypt(param));
            List<PS_VSCOR_PROFILResult> liste_profil = new List<PS_VSCOR_PROFILResult>();
            foreach(var banque in banques) {
                List<PS_VSCOR_PROFILResult> temp_list_profil = service.ListeProfil(0, "", banque.CODE_BANQUE, "", "", Convert.ToDecimal("0"), true);
                foreach(PS_VSCOR_PROFILResult profil in temp_list_profil) {
                    liste_profil.Add(profil);
                }
            }

            foreach (var v in liste_profil)
            {
                if (v.LIBELLE_PROFIL != "scoradm")
                {
                    var xcd = "Mettre à Jours"; var ID = "";
                    sb.AppendLine("<tr onclick=\"chargerchamptxt($(this))\" class='tr_backgr' title='Sélectionner cette ligne'>");
                    sb.AppendLine(string.Format("<td class='text-left'>{0}</td>", v.CODE_PROFIL.ToUpper()));
                    sb.AppendLine(string.Format("<td class='text-left' Data='{1}'>{0}</td>", service.InfosBanqueByCode(v.CODE_BANQUE).SIGLE_BANQUE.ToUpper(), v.CODE_BANQUE));
                    sb.AppendLine(string.Format("<td class='text-left'>{0}</td>", v.LIBELLE_PROFIL));

                    if (v.PLAFOND_PROFIL.ToString() != "0")
                    {
                        if (Int32.MaxValue > v.PLAFOND_PROFIL)
                        {
                            var inin = DataManager.Ps_scor_leseuil(Convert.ToInt32(v.PLAFOND_PROFIL));
                            if (inin.Count != 0)
                            {
                                xcd = "";
                                var MAXSEUIL = inin.FirstOrDefault().MAX_SCOR_SEUIL_DELEGUATION;
                                var MINSEUIL = inin.FirstOrDefault().MIN_SCOR_SEUIL_DELEGUATION;
                                ID = inin.FirstOrDefault().ID_SCOR_SEUIL_DELEGUATION.ToString();
                                if (MAXSEUIL.ToString() == Int64.MaxValue + "")
                                    xcd += "illimité";
                                else
                                    xcd += MAXSEUIL;
                            }
                        }
                    }
                    else
                    {
                        xcd = "0";
                        ID = "0";
                    }
                       
                        
                    sb.AppendLine(string.Format("<td class='text-right' Data='{1}'>{0}</td>", xcd, ID));
                    //sb.AppendLine(string.Format("<td class='text-right'>{0}</td>", Convert.ToString(string.Format(frCult, "{0:#,##0}", v.PLAFOND_PROFIL))));
                    if (v.ETAT_PROFIL == true)
                        sb.AppendLine("<td class='text-center'><div class='circle_green'></div></td>");
                    //Activé
                    else
                        sb.AppendLine("<td class='text-center'><div class='circle_red'></div></td>");
                    //Désactivé
                    sb.AppendLine(string.Format("<td class='display'>{0}</td>", v.ID_PROFIL));

                    sb.AppendLine("</tr>");
                }
                
            }
            ListProfil.InnerHtml = sb.ToString();
        }

        protected void btnNouveau_ServerClick(object sender, EventArgs e)
        {
            InitZone();
        }

        void OpenShowPasvalideConsult(string titre, string msg)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPasvalideConsult();", true);
            this.lblPasValidemessageConsult.Text = msg;
            this.lblPasValideTitreConsult.Text = titre;
        }

        void OpenShowvalideConsult(string titre, string msg)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowvalideConsult();", true);
            this.lblValidemessageConsult.Text = msg;
            this.lblValideTitreConsult.Text = titre;
        }

        protected void btnValider_ServerClick(object sender, EventArgs e)
        {
            // ajuster les valeurs des boîtes de sélection
            DdlBanque.SelectedValue = TbCodeBanqueRemote.Text.Trim();
            LoadPlafonds();
            TbNPlafond.Value = TbPlafondRemote.Text.Trim();

            // enregistrement
            if (TbCodeProilRemote.Text.Trim() == "" || TbNLibelleP.Text == "" || TbPlafondRemote.Text.Trim() == "")
            {
                OpenShowPasvalideConsult("Erreur...", "Veuillez remplir les champs !!!");
            }
            else
            {
                var list_profil = service.ListeProfil(5, "", TbCodeBanqueRemote.Text.Trim(), TbCodeProilRemote.Text.Trim(), "", Convert.ToDecimal("0"), true);
                if (list_profil.Count == 0)
                {
                        int incrProfil = 0;
                        foreach (var incr in service.ListeProfil(4, "", "", "", "", Convert.ToDecimal("0"), true))
                        {
                            incrProfil = Convert.ToInt32(incr.ID_PROFIL);
                            incrProfil++;
                        }
                        service.PS_SCOR_SPY(Session["id_user"].ToString().Trim(), "Profil", connmou007.Value.ToString(), "I");
                        service.traiterProfil(1, incrProfil.ToString(), TbCodeBanqueRemote.Text.Trim(), TbCodeProilRemote.Text.Trim(), TbNLibelleP.Text,
                                Convert.ToDecimal(TbPlafondRemote.Text.Trim().Replace(",", "").Replace(" ", "").Replace("&nbsp;", "")), EtatProfil.Checked);
                    
                    OpenShowPasvalideConsult("Enregistrement", "Enregistrement effectuée avec succès !!!");
                }
                else
                {
                    try
                    {
                        service.traiterProfil(2, TbIdProfil.Text.Trim(), TbCodeBanqueRemote.Text.Trim(), TbCodeProilRemote.Text.Trim(), TbNLibelleP.Text,
                           Convert.ToDecimal(TbPlafondRemote.Text.Trim().Replace(",", "").Replace(" ", "").Replace("&nbsp;", "")), EtatProfil.Checked);
                    }
                    catch (Exception ex)
                    {
                        ex.ToString();
                    }
                    service.PS_SCOR_SPY(Session["id_user"].ToString().Trim(), "Profil", connmou007.Value.ToString(), "M");
                    OpenShowPasvalideConsult("Modification", "Modification effectuée avec succès !!!");
                }
                RemplirGrille();
                InitZone();
            }
        }

        public void InitCouleur()
        {

        }

        protected void ShowvalideOpenConsult_ServerClick(object sender, EventArgs e)
        {
            try
            {
                service.traiterProfil(3, TbIdProfil.Text, "", "", "", Convert.ToDecimal("0"), true);
                RemplirGrille();
                InitZone();
                OpenShowPasvalideConsult("Suppression...", "Suppression effectuée avec succès !!!");
            }
            catch (Exception ex)
            {
                OpenShowPasvalideConsult("Attention...", "Impossible de supprimer ce profil");
                ex.ToString();
            }
            service.PS_SCOR_SPY(Session["id_user"].ToString().Trim(), "Profil", connmou007.Value.ToString(), "S");

        }

        protected void TIMINGOpenConsult_ServerClick(object sender, EventArgs e)
        {
            try
            {
                
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            service.PS_SCOR_SPY(Session["id_user"].ToString().Trim(), "Profil", connmou007.Value.ToString(), "I");
            OpenShowPasvalideConsult("Enregistrement...", "Enregistrement effectué avec succès !!!");
        }

        protected void OnBanqueChangeLoadPlafonds(object sender, EventArgs e)
        {
            LoadPlafonds();
        }

        public void LoadPlafonds()
        {
            if (Session["code_banque"] == null) Response.Redirect("~/Scoring/Connexion.aspx");

            // filtrer la liste des plafond en fonction de la banque sélectionnée
            TbNPlafond.Items.Clear();
            if (DdlBanque.SelectedValue != string.Empty)
            {
                var liste_plafonds = DataManager.ListeSeuil(DdlBanque.SelectedValue);
                if (liste_plafonds.Any())
                {
                    foreach (var element in liste_plafonds)
                    {
                        TbNPlafond.Items.Add(new ListItem(element.MAX_SCOR_SEUIL_DELEGUATION == Int64.MaxValue ? "illimité" : element.MAX_SCOR_SEUIL_DELEGUATION.ToString(), element.ID_SCOR_SEUIL_DELEGUATION.ToString()));
                    }
                }
            }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static object LoadPlafondSelectOptionsHtml(string code_banque)
        {
            return new { _plafonds = LoadPlafondOptionsHtml(code_banque)};
        }

        public static string LoadPlafondOptionsHtml(string code_banque)
        {
            string content = "";

            if (code_banque != string.Empty)
            {
                var elements = DataManager.ListeSeuil(code_banque);
                foreach (var element in elements) content += String.Format("<option value='{0}'>{1}</option>", element.ID_SCOR_SEUIL_DELEGUATION.ToString().Trim(),
                    element.MAX_SCOR_SEUIL_DELEGUATION == Int64.MaxValue ? "illimité" : element.MAX_SCOR_SEUIL_DELEGUATION.ToString());
            }

            return content;
        }
    }
}