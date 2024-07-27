using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ScoringCenter.Scoring
{
    public partial class Profil : System.Web.UI.Page
    {
        Scoringws service = new Scoringws();
        string code_banque = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            ControllerPage();
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
            ////Fin_Controle////////////////////////////////////////////////////
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            
            RemplirGrille();
            InitCouleur();
            InitZone();
            EtatProfil.Checked = true;
        }

        public void InitZone()
        {
            TbNLibelleP.Text = "";
            TbNPlafond.Text = "";
            TbICodePro.Text = "";
        }

        public void RemplirGrille()
        {
            if (Session["code_banque"] == null) Response.Redirect("~/Scoring/Connexion.aspx"); 

            StringBuilder sb = new StringBuilder();
            code_banque = ScorCryptage.Decrypt(Session["code_banque"].ToString());
            var list_profil = service.ListeProfil(0, "", code_banque, "", "", decimal.Parse("0"), true);
            foreach (var v in list_profil)
            {
              
                if (code_banque==v.CODE_BANQUE)
                {
                sb.AppendLine("<tr onclick=\"chargerchamptxt($(this))\" title='Sélectionner cette ligne'>");
                sb.AppendLine(string.Format("<td class='text-left'>{0}</td>", v.CODE_PROFIL.ToUpper()));
                sb.AppendLine(string.Format("<td class='text-left'>{0}</td>", v.LIBELLE_PROFIL));
                sb.AppendLine(string.Format("<td class='text-right'>{0}</td>", Convert.ToString(string.Format("{0:#,##0}", v.PLAFOND_PROFIL))));
                if(v.ETAT_PROFIL == true)
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
            if (TbICodePro.Text == "" && TbNLibelleP.Text == "")
            {
                OpenShowPasvalideConsult("Erreur...", "Veuillez remplir les champs !!!");
            }
            else
            {
                var list_profil = service.ListeProfil(5, "", code_banque, TbICodePro.Text, "", decimal.Parse("0"), true);
                if (list_profil.Count == 0)
                {
                    try
                    {
                        int incrProfil = 0;
                        foreach (var incr in service.ListeProfil(4, "", "", "", "", decimal.Parse("0"), true))
                        {
                            incrProfil = Int16.Parse(incr.ID_PROFIL);
                            incrProfil++;
                        }
                        service.PS_SCOR_SPY(Session["id_user"].ToString().Trim(), "Profil", connmou007.Value.ToString(), "I");
                        service.traiterProfil(1, incrProfil.ToString(), code_banque, TbICodePro.Text, TbNLibelleP.Text,
                                decimal.Parse(TbNPlafond.Text), EtatProfil.Checked);
                    }
                    catch (Exception ex)
                    {
                        ex.ToString();
                    }

                    OpenShowPasvalideConsult("Enregistrement", "Enregistrement effectuée avec succès !!!");
                }
                else
                {
                    try
                    {
                        service.traiterProfil(2, TbIdProfil.Text, code_banque, TbICodePro.Text, TbNLibelleP.Text,
                            decimal.Parse(TbNPlafond.Text), EtatProfil.Checked);
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

        protected void btnSupprimer_ServerClick(object sender, EventArgs e)
        {
            if (TbICodePro.Text == "" && TbNLibelleP.Text == "")
            {
                OpenShowPasvalideConsult("Erreur...", "Veuillez remplir les champs !!!");
            }
            else
            {
                OpenShowvalideConsult("Suppression ...", " Voulez-vous vraiment Supprimer cette ligne du Document!?...");
            }
        }

        public void InitCouleur()
        {

        }

        protected void ShowvalideOpenConsult_ServerClick(object sender, EventArgs e)
        {
            try
            {
                service.traiterProfil(3, TbIdProfil.Text, "", "", "", decimal.Parse("0"), true);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            if (Session["id_user"] == null) Response.Redirect("~/Scoring/Connexion.aspx"); 

            service.PS_SCOR_SPY(Session["id_user"].ToString().Trim(), "Profil", connmou007.Value.ToString(), "S");
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
            if (Session["id_user"] == null) Response.Redirect("~/Scoring/Connexion.aspx"); 

            service.PS_SCOR_SPY(Session["id_user"].ToString().Trim(), "Profil", connmou007.Value.ToString(), "I");
            OpenShowPasvalideConsult("Enregistrement...", "Enregistrement effectué avec succès !!!");
        }
    }
}