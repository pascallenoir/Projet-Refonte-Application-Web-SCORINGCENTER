using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ScoringCenter.Scoring
{
    public partial class Mouchard : System.Web.UI.Page
    {
        StringBuilder sb = new StringBuilder();
        StringBuilder sc = new StringBuilder();
        Scoringws service = new Scoringws();

        protected void Page_Load(object sender, EventArgs e)
        {
            ControllerPages();
            afficherTableau();
        }
        public void afficherTableau() {
            var listes = service.ListeMouch007();
            if (listes.Count != 0)
            {


                foreach (var v in listes)
                {
                    sc.AppendLine(string.Format("<tr id='{0}' onclick='ligneclick(this.id)'>", ScorCryptage.Encrypt(v.ID_ACTION.ToString())));
                    if (v.DATE_ACTION != null) sc.AppendLine(string.Format("<td >{0}</td>", v.DATE_ACTION.ToString()));
                    else sc.AppendLine(string.Format("<td >-</td>"));
                    if (v.UTILISATEUR != null && v.UTILISATEUR.Trim() != "") sc.AppendLine(string.Format("<td >{0}</td>", v.UTILISATEUR.ToString()));
                    else sc.AppendLine(string.Format("<td >-</td>"));
                    if (v.ECRAN != null && v.ECRAN.Trim() != "") sc.AppendLine(string.Format("<td >{0}</td>", v.ECRAN.ToString()));
                    else sc.AppendLine(string.Format("<td >-</td>"));
                    if (ScorCryptage.Decrypt(v.EVENEMENT.ToString()).Length < 30)
                    {
                        if (v.EVENEMENT != null && v.EVENEMENT.Trim() != "") sc.AppendLine(string.Format("<td  title='{0}'>{1}</td>", ScorCryptage.Decrypt(v.EVENEMENT.ToString()), ScorCryptage.Decrypt(v.EVENEMENT.ToString()).Substring(0, ScorCryptage.Decrypt(v.EVENEMENT.ToString()).Length)));
                        else sc.AppendLine(string.Format("<td >-</td>"));
                    }
                    else
                    {
                        if (v.EVENEMENT != null && v.EVENEMENT.Trim() != "") sc.AppendLine(string.Format("<td  title='{0}'>{1}</td>", ScorCryptage.Decrypt(v.EVENEMENT.ToString()), ScorCryptage.Decrypt(v.EVENEMENT.ToString()).Substring(0, 30)));
                        else sc.AppendLine(string.Format("<td >-</td>"));
                    }
                    if (v.ACTIONS != null && v.ACTIONS.Trim() != "") sc.AppendLine(string.Format("<td >{0}</td>", v.ACTIONS.ToString()));
                    else sc.AppendLine(string.Format("<td >-</td>"));
                    if (v.OBJET != null && v.OBJET.Trim() != "") sc.AppendLine(string.Format("<td >{0}</td>", v.OBJET.ToString()));
                    else sc.AppendLine(string.Format("<td >-</td>"));
                    sc.AppendLine("</tr>");
                }
            }
            ListDocTableauBord.InnerHtml = sc.ToString();
        }
        public void ControllerPages()
        {
            ////Debut_Controle///////////////////////////////////////////////////
            if (Session["login"] == null) Response.Redirect("~/Scoring/Connexion.aspx");
            else{
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