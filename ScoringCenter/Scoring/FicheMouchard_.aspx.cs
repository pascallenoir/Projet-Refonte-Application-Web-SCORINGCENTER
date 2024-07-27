using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ScoringCenter.Scoring
{
    public partial class FicheMouchard : System.Web.UI.Page
    {
        StringBuilder sc = new StringBuilder();
        Scoringws service = new Scoringws();
        protected void Page_Load(object sender, EventArgs e)
        {
            ControllerPages();
            afficherFiche();
        }

        private void afficherFiche()
        {
            var listes = service.AfficheMouche007(ScorCryptage.Decrypt(Request.QueryString["id"]));
            if (listes.Count != 0)
            {
                foreach (var v in listes)
                {
                    NomUser.Text = v.NOM_USER.ToString();
                    PrenomUser.Text = v.PRENOM_USER.ToString();
                    EmailUser.Text = v.EMAIL_USER.ToString();
                    ProfilUser.Text = v.LIBELLE_PROFIL.ToString();
                    NomAgence.Text = v.NOM_AGENCE.ToString();
                    EcranAction.Text = v.ECRAN.ToString();
                    if (ScorCryptage.Decrypt(v.EVENEMENT.ToString()).Length < 30)
                    {
                        EvenementAction.Text = ScorCryptage.Decrypt(v.EVENEMENT.ToString()).Substring(0, ScorCryptage.Decrypt(v.EVENEMENT.ToString()).Length);
                    }
                    else
                    {
                        EvenementAction.Text = ScorCryptage.Decrypt(v.EVENEMENT.ToString()).Substring(0, 35);
                    }
                    ObjetAction.Text = v.OBJET.ToString();
                    DateAction.Text = v.DATE_ACTION.ToString();
                    TextDescription.Text=Description(ScorCryptage.Decrypt(v.EVENEMENT.ToString()), v.ACTIONS);
                }
            }
        }
        private String Description(String eve, String act)
        {
            String interpretation ="";
            var BoutEve = eve.Split('@');
            if(act.Trim()=="C"){
                interpretation = interpretation + " l'utilisateur c'est connecter" + " le " + BoutEve[0]+", ";
                for (int i = 1; i < BoutEve.Length;i++ )
                {
                    String valeurCase = BoutEve[i].ToString();
                    int longueur = valeurCase.Length;                           
                    String Identifiant = "";
                    Identifiant = valeurCase.Substring(5, longueur-5);
                    if (valeurCase.Substring(3, 1) == "T")
                        interpretation = interpretation + " en saisissant l'identifiant " + Identifiant + ", ";
                    if (valeurCase.Substring(3, 1) == "B")
                    interpretation = interpretation + " en cliquant le boutton de connexion";
                }
            }
            if (act.Trim() == "R")
            {
                interpretation = interpretation + " l'utilisateur a effectué une recherche" + " le " + BoutEve[0] + ", ";
                for (int i = 1; i < BoutEve.Length; i++)
                {
                    String valeurCase = BoutEve[i].ToString();
                    int longueur = valeurCase.Length;
                    String Identifiant = "";
                    Identifiant = valeurCase.Substring(5, longueur - 5);
                    if (valeurCase.Substring(3, 1) == "C")
                        interpretation = interpretation + " en en selectionnant " + Identifiant + " dans la liste déroulante, ";
                    if (valeurCase.Substring(3, 1) == "T")
                        interpretation = interpretation + " en saisissant le text suivant " + Identifiant + ", ";
                    if (valeurCase.Substring(3, 1) == "B")
                        interpretation = interpretation + " en cliquant le boutton de Rechecher";
                }
            }
            return interpretation;
        }
        public void ControllerPages()
        {
            ////Debut_Controle///////////////////////////////////////////////////
            if (Session["login"] == null) Response.Redirect("~/Scoring/Connexion.aspx");
            else
            {
                var idprofil = Session["id_profil"].ToString();
                var elements = service.VHABILITATION(idprofil);
                AD.Visible = false;
                var test = 0;
                foreach (var element in elements)
                {
                    if (element.ID_DROIT.ToString().Trim() == "AD")
                    {
                        if (element.ID_TYPE_DROIT.ToString().Trim() != "0") AD.Visible = true;
                    }
                }
            }
        }
    }
}