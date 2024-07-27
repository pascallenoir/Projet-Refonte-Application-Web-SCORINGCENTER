using iTextSharp.text.pdf;
using ScoringCenter.Scoring;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ScoringCenter
{
    public partial class Connexion : System.Web.UI.Page
    {
        Scoringws service = new Scoringws();
        StringBuilder sb = new StringBuilder();

        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (!IsPostBack)
            {
                Session.Abandon();

                string eventTarget = Request["__EVENTTARGET"];
                string eventArgument = Request["__EVENTARGUMENT"];

                if (eventTarget == ClientID && eventArgument == "Alert_dismissible")
                {
                    Alert_dismissible();
                }
            }
        }
        protected void Page_Init(object sender, EventArgs e)
        {
           
        }

        protected void Connexion_Click(object sender, EventArgs e)
        {
            var code_banque = "";
            var id_user = ""; 
            var id_profil = "";
            var nom_user = "";
            if (Password1.Value.Trim() != "" && Password2.Value.Trim() != "")
            {
                try
                {
                    service.traiterUser(9, "", "", "", "", "", "", InputUserName.Value, Password1.Value, DateTime.Now, true,
                        "", "","");

                    foreach (var Info in service.InfoUtilisateur(InputUserName.Value, Password1.Value))
                    {
                        NEWCOMPTE.Visible = false;
                        if (Info.PCHNG == "XOX1649H")
                        {
                            NEWCOMPTE.Visible = true;
                            af.Visible = false;

                        }
                        else
                        {
                            nom_user = Info.PRENOM_USER + "  " + Info.NOM_USER;
                            id_user = Info.ID_USER;
                            id_profil = Info.ID_PROFIL;
                            foreach (var banque in service.InfoBanque(Info.CODE_AGENCE))
                            {
                                code_banque = banque.CODE_BANQUE;
                            }
                        }

                    }
                    Session.Add("code_banque", ScorCryptage.Encrypt(code_banque));
                    Session.Add("login", ScorCryptage.Encrypt("1"));
                    Session.Add("id_user", id_user);
                    Session.Add("id_profil", id_profil);
                    Session.Add("nom_user", nom_user);
                    service.PS_SCOR_SPY(Session["id_user"].ToString().Trim(), "Connexion", connmou007.Value.ToString(), "C");

                    Response.Redirect("~/Scoring/AutreDossier.aspx");
                }
                catch (Exception ex)
                {
                    ex.ToString();
                }
            }

            else
            {
                if (service.Authentification(InputUserName.Value, InputPassword.Value))
                {


                    foreach (var Info in service.InfoUtilisateur(InputUserName.Value, InputPassword.Value))
                    {
                        if (Info.PCHNG == "XOX1649H")
                        {
                            NEWCOMPTE.Visible = true;
                            af.Visible = false;
                        }
                        else
                        {
                            nom_user = Info.PRENOM_USER + "  " + Info.NOM_USER;
                            id_user = Info.ID_USER;
                            id_profil = Info.ID_PROFIL;
                            foreach (var banque in service.InfoBanque(Info.CODE_AGENCE))
                            {
                                code_banque = banque.CODE_BANQUE;
                            }
                        }

                    }
                    if (NEWCOMPTE.Visible == false)
                    {
                        Session.Add("code_banque", ScorCryptage.Encrypt(code_banque));
                        Session.Add("login", ScorCryptage.Encrypt("1"));
                        Session.Add("id_user", id_user);
                        Session.Add("id_profil", id_profil);
                        Session.Add("nom_user", nom_user);
                        service.PS_SCOR_SPY(Session["id_user"].ToString().Trim(), "Connexion", connmou007.Value.ToString(), "C");

                        Response.Redirect("~/Scoring/AutreDossier.aspx");
                    }
                    
                }
                else
                {
                    getMessage.Visible = true;
                    //sb.AppendLine("<div class='alert alert-soft-primary alert-dismissible fade in' role='alert'>");
                    //sb.AppendLine(" <button type='button' class='close' data-dismiss='alert' aria-label='Close' style='margin-top: -0.4%;'><span aria-hidden='true'>&times;</span></button>");
                    //sb.AppendLine("<strong>Nom d'utilisateur ou Mot de passe incorrecte</strong> <br> Veuillez réessayer !");
                    //sb.AppendLine("</div>");
                    //getMessage.InnerHtml = sb.ToString();
                }
            }
        }
        protected void Alert_dismissible()
        {
            getMessage.Visible = false;
        }
    }
}