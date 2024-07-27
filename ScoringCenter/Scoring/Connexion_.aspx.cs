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
            Session.Add("login", null);
            if (!IsPostBack)
            {
                Session.Abandon();
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
            if (service.Authentification(InputUserName.Value, InputPassword.Value)) 
            {
              
                foreach (var Info in service.InfoUtilisateur(InputUserName.Value, InputPassword.Value))
                {
                    nom_user = Info.PRENOM_USER + "  " + Info.NOM_USER;
                    id_user = Info.ID_USER;
                    id_profil=Info.ID_PROFIL;
                   foreach(var banque in service.InfoBanque(Info.CODE_AGENCE))
                   {
                       code_banque = banque.CODE_BANQUE;
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
            else
            {
                sb.AppendLine("<div class='alert alert-danger fade in'>");
                sb.AppendLine("<a href='#' class='close' data-dismiss='alert' style='margin-top: -0.4%;'>&times;</a>");
                sb.AppendLine("<strong>Nom d'utilisateur ou Mot de passe incorrecte, <br>Veuillez réessayer !!!</strong>");
                sb.AppendLine("</div>");
                getMessage.InnerHtml = sb.ToString();
            }
        }
    }
}