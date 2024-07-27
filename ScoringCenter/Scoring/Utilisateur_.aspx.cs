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
    public partial class Utilisateur : System.Web.UI.Page
    {
        Scoringws service = new Scoringws();
        StringBuilder sblogo = new StringBuilder();
        StringBuilder sb = new StringBuilder();
        static string code_banque = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            AfficheLogoBank();
            ControllerPage();
        }
        public void AfficheLogoBank()
        {
            if (Session["code_banque"] != null)
            {
                var code_banque = Session["code_banque"].ToString();
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

                //Cen.Visible = false;
                //CC.Visible = false;
                Pay.Visible = false;
                // Con.Visible = false;

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
                        //if (element.ID_TYPE_DROIT.ToString().Trim() != "0") //Cen.Visible = true;
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
                    if (element.ID_DROIT.ToString().Trim() == "GU")
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
        public void InitZone()
        {
            //TbAgence.Attributes.Add("readonly", "readonly");
            DdlAgence.Value = "";
            DdlProfil.SelectedIndex = 0;
            TbNom.Text = "";
            TbPrenom.Text = "";
            TbLoginUser.Text = "";
            TbPassword.Text = "";
            TbEmail.Text = "";
            TbConfirm.Text = "";
            ChkStatUser.Checked = true;
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            if (Session["code_banque"] == null) Response.Redirect("~/Scoring/Connexion.aspx");
            code_banque = ScorCryptage.Decrypt(Session["code_banque"].ToString());
            RemplirGrille();
            ListeProfil();
            ListeTableParam();
            InitZone();
        }

        public void RemplirGrille()
        {
            StringBuilder sbData = new StringBuilder();
            var list_user = service.ListeUser(0, "", "", "", "", "", "", "", "", DateTime.Now, true, code_banque, "");
            suphierarchique.Items.Clear();
            suphierarchique.Items.Add("");
            foreach (var v in list_user)
            {
                if (code_banque == v.CODE_BANQUE)
                {
                    if (Session["id_user"] == null) Response.Redirect("~/Scoring/Connexion.aspx");
                    //if (v.ID_USER.Trim() != Session["id_user"].ToString().Trim())
                    //{
                        ListItem l = new ListItem();
                        l.Value = v.ID_USER;
                        l.Text = (string.IsNullOrEmpty(v.NOM_USER) ? "" : v.NOM_USER.ToUpper()) + " " + (string.IsNullOrEmpty(v.PRENOM_USER) ? "" : v.PRENOM_USER.ToString());
                        suphierarchique.Items.Add(l);
                    //}
                    sbData.AppendLine("<tr onclick=\"chargerchamptxt($(this))\" data-pers='" + (v.ID_USER.Trim() == Session["id_user"].ToString().Trim() ? "1" : "0") + "' title='Sélectionner cette ligne'>");
                    //sbData.AppendLine("<tr onclick=\"chargerchamptxt($(this))\"  title='Sélectionner cette ligne'>");
                    sbData.AppendLine(string.Format("<td class='text-left'>{0} {1}</td>", v.NOM_USER.ToUpper(), v.PRENOM_USER));
                    sbData.AppendLine(string.Format("<td class='text-left'>{0}</td>", v.LOGIN_USER));
                    sbData.AppendLine(string.Format("<td class='text-left'>{0}</td>", v.LIBELLE_PROFIL));
                    sbData.AppendLine(string.Format("<td class='text-left'>{0}</td>", v.NOM_AGENCE));

                    if (v.STATUT_USER == true)
                        sbData.AppendLine("<td><div class='circle_green'></div></td>");
                    //Activé
                    else
                        sbData.AppendLine("<td><div class='circle_red'></div></td>");
                    //Désactivé
                    sbData.AppendLine(string.Format("<td class='display'>{0}</td>", v.NOM_USER));
                    sbData.AppendLine(string.Format("<td class='display'>{0}</td>", v.PRENOM_USER));
                    sbData.AppendLine(string.Format("<td class='display'>{0}</td>", v.EMAIL_USER));
                    sbData.AppendLine(string.Format("<td class='display'>{0}</td>", v.PASSWORD_USER));
                    sbData.AppendLine(string.Format("<td class='display'>{0}</td>", v.ID_USER));
                    sbData.AppendLine(string.Format("<td class='display'>{0}</td>", v.ID_PROFIL));
                    sbData.AppendLine(string.Format("<td class='display'>{0}</td>", v.PARENT_SUPP));
                    sbData.AppendLine("</tr>");
                }
            }
            ListUtilisateur.InnerHtml = sbData.ToString();
        }

        public void ListeProfil()
        {
            var i_typeEvaluation = service.ListeUser(2, "", "", "", "", "", "", "", "", DateTime.Now, true, code_banque, "");
            DdlProfil.Items.Clear();
            DdlProfil.Items.Add("");
            foreach (var v in i_typeEvaluation)
            {
                if (v.LIBELLE_PROFIL != "scoradm")
                {
                    ListItem l = new ListItem();
                    l.Value = v.ID_PROFIL;
                    l.Text = v.LIBELLE_PROFIL;
                    DdlProfil.Items.Add(l);
                }
            }
        }

        protected void btnSupprimer_ServerClick(object sender, EventArgs e)
        {

            if (DdlAgence.Value == "" && DdlProfil.Value == "")
            {
                OpenShowPasvalideConsult("Erreur...", "Veuillez remplir les champs !!!");
            }
            else
            {
                service.PS_SCOR_SPY(Session["id_user"].ToString().Trim(), "Utilisateur", connmou007.Value.ToString(), "S");
                OpenShowvalideConsult("Suppression ...", " Voulez-vous vraiment Supprimer cette ligne du Document ?...");
            }
        }

        protected void btnValider_ServerClick(object sender, EventArgs e)
        {
            if (DdlAgence.Value == "" || DdlProfil.Value == "" || TbEmail.Text == "" || TbConfirm.Text == "" || TbPassword.Text == "" || TbLoginUser.Text == "" || TbNom.Text == "" || TbPrenom.Text == "")
            {
                OpenShowPasvalideConsult("Erreur...", "Veuillez remplir les champs !!!");
            }
            else
            {
                if (IsValidEmailAddress(TbEmail.Text) == false)
                    OpenShowPasvalideConsult("Information ...", "L'adresse mail est incorrecte !!!");
                else
                {
                    if (TbPassword.Text != TbConfirm.Text)
                        OpenShowPasvalideConsult("Erreur...", "Confirmation de mot de passe incorrecte !!!");
                    else
                    {
                        var list_user = service.ListeUser(7, "", "", "", "", "", "", TbLoginUser.Text, "", DateTime.Now, true,
                            code_banque, "");
                        var Listecode_agence = service.ListeUser(8, "", "", "", "", "", "", "", "", DateTime.Now, true,
                                    "", DdlAgence.Value).ToList();
                        var code_agence = "";
                        foreach (var xagent in Listecode_agence)
                        {
                            code_agence = xagent.CODE_AGENCE.ToString();
                        }
                        if (list_user.Count == 0)
                        {
                            try
                            {
                                int incrUser = 0;
                                foreach (var incr in service.ListeUser(3, "", "", "", "", "", "", "", "", DateTime.Now,
                                    true, "", ""))
                                {
                                    incrUser = Int16.Parse(incr.ID_USER);
                                    incrUser++;
                                }

                                service.traiterUser(4, incrUser.ToString(), DdlProfil.Value, DdlAgence.Value.Trim(), TbNom.Text,
                                    TbPrenom.Text, TbEmail.Text, TbLoginUser.Text, TbPassword.Text, DateTime.Now, ChkStatUser.Checked,
                                    "", "",suphierarchique.Value);
                            }
                            catch (Exception ex)
                            {
                                ex.ToString();
                            }
                            service.PS_SCOR_SPY(Session["id_user"].ToString().Trim(), "Utilisateur", connmou007.Value.ToString(), "I");
                            OpenShowPasvalideConsult("Enregistrement", "Enregistrement effectuée avec succès !!!");
                        }
                        else
                        {
                            try
                            {
                                service.traiterUser(5, TbIdUtilisateur.Text, DdlProfil.Value, DdlAgence.Value.Trim(), TbNom.Text,
                                    TbPrenom.Text, TbEmail.Text, TbLoginUser.Text, TbPassword.Text, DateTime.Now, ChkStatUser.Checked,
                                    "", "",suphierarchique.Value);
                            }
                            catch (Exception ex)
                            {
                                ex.ToString();
                            }
                            service.PS_SCOR_SPY(Session["id_user"].ToString().Trim(), "Utilisateur", connmou007.Value.ToString(), "M");
                            OpenShowPasvalideConsult("Modification", "Modification effectuée avec succès !!!");
                        }

                        RemplirGrille();
                        InitZone();
                    }
                }
            }
        }
        public void ListeTableParam()
        {
            if (Session["code_banque"] == null) Response.Redirect("~/Scoring/Connexion.aspx");

            if (Session["code_banque"] != null)
            {
                if (Session["code_banque"] == null) Response.Redirect("~/Scoring/Connexion.aspx");

                var param = Session["code_banque"].ToString();

                foreach (var v in service.ListeAgenceBanque(ScorCryptage.Decrypt(param)))
                {
                    DdlAgence.Items.Add(new ListItem(v.GUICHET_AGENCE.ToString() + " - " + v.NOM_AGENCE.ToString(), v.CODE_AGENCE));
                }
            }
            else
            {
                //sb.AppendLine("<div class='alert alert-danger fade in'>");
                //sb.AppendLine("<a href='#' class='close' data-dismiss='alert' style='margin-top: -0.4%;'>&times;</a>");
                //sb.AppendLine("<strong>Veuillez vous connecter pour evoluer !!!<br/></strong>");
                //sb.AppendLine("</div>");
                //getMessage.InnerHtml = sb.ToString();
                Response.Redirect("~/Scoring/Connexion.aspx");
            }

        }
        protected void btnNouveau_ServerClick(object sender, EventArgs e)
        {
            InitZone();
        }

        public bool IsValidEmailAddress(string email)
        {
            try
            {
                var emailChecked = new System.Net.Mail.MailAddress(email);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void InitCouleur()
        {

        }

        protected void ShowvalideOpenConsult_ServerClick(object sender, EventArgs e)
        {
            try
            {
                service.traiterUser(6, TbIdUtilisateur.Text, "", "", "", "", "", "", "", DateTime.Now, true, "", "", "");
            }
            catch (Exception ex)
            {
                ex.ToString();
            }

            RemplirGrille();
            InitZone();
            OpenShowPasvalideConsult("Suppression...", "Suppression effectuée avec succès !!!");
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

            OpenShowPasvalideConsult("Enregistrement...", "Enregistrement effectué avec succès !!!");
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

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static string[] searchAgence(string text)
        {
            string[] res = new string[1];
            StringBuilder sbS = new StringBuilder();

            List<PS_VSCOR_UTILISATEURResult> get_agence;
            Scoringws service = new Scoringws();

            get_agence = service.ListeUser(1, "", "", "", "", "", "", "", "", DateTime.Now, true, code_banque, text);

            if (get_agence.Count != 0)
            {
                foreach (var v in get_agence)
                {
                    sbS.AppendLine(string.Format("<option class='' id='{0}' value='{1}'>{1}</option>",
                        v.CODE_AGENCE, v.NOM_AGENCE));
                }
            }
            else
            {
                sbS.AppendLine("<option class='' id='' value=''>Aucune donnée ne correspond aux termes de recherche spécifiés</option>");
            }

            res[0] = sbS.ToString();
            return res;
        }
    }
}