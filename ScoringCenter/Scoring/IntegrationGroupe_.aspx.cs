using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ScoringCenter.Scoring
{
    public partial class IntegrationGroupe : System.Web.UI.Page
    {
        StringBuilder sb = new StringBuilder();
        Scoringws service = new Scoringws();

        protected void Page_Load(object sender, EventArgs e)
        {
            ////Debut_Controle///////////////////////////////////////////////////
            if (Session["login"] == null) Response.Redirect("~/Scoring/Connexion.aspx");
            ////Fin_Controle////////////////////////////////////////////////////
            if (!IsPostBack)
            {

            }
        }

        public void getInfoClient()
        {
            if (string.IsNullOrEmpty(Request.QueryString["id"]))
            {
                if (string.IsNullOrEmpty(Session["id_scoring"].ToString()))
                    Response.Redirect("~/Scoring/AutreDossier.aspx");
                else
                {
                    var id_scoring = Session["id_scoring"].ToString();
                    Session.Add("id_scoring", id_scoring);
                    var code_banque = Session["code_banque"].ToString();
                    var info = service.DetailsDossierContrepartie(code_banque, id_scoring);
                    string id_dossier = "";
                    foreach (var v in info)
                    {
                        NClient.Text = v.ETCIV_NOMREDUIT;
                        Idprincip.Text = v.ID_SCORING;
                        CodeAPE.Text = v.RCCM;
                        AEntreprise.Text = v.SECTEUR_D_ACTIVITE;
                        Siren.Text = v.ACTIVITE_BCEAO;
                        Devise.Text = v.DEVISE;
                        ChiffreAffaire.Text = Convert.ToString(string.Format("{0:#,##0}", v.CA));
                        id_dossier = v.ID_DOSSIER;
                        if (v.GROUPE_DOSSIER != "") { }
                        else { Integ_Group.Visible = false; Response.Redirect("~/Scoring/AutreDossier.aspx"); }
                    }
                    Session.Add("id_dossier", id_dossier);
                }
            }
            else
            {
                var id_scoring = ScorCryptage.Decrypt(Request.QueryString["id"]);
                Session.Add("id_scoring", id_scoring);
                var code_banque = Session["code_banque"].ToString();
                var info = service.DetailsDossierContrepartie(code_banque, id_scoring);
                string id_dossier = "";
                foreach (var v in info)
                {
                    NClient.Text = v.ETCIV_NOMREDUIT;
                    Idprincip.Text = v.ID_SCORING;
                    CodeAPE.Text = v.RCCM;
                    AEntreprise.Text = v.SECTEUR_D_ACTIVITE;
                    Siren.Text = v.ACTIVITE_BCEAO;
                    Devise.Text = v.DEVISE;
                    ChiffreAffaire.Text = Convert.ToString(string.Format("{0:#,##0}", v.CA));
                    id_dossier = v.ID_DOSSIER;
                    if (v.GROUPE_DOSSIER != "") { }
                    else { Integ_Group.Visible = false; Response.Redirect("~/Scoring/AutreDossier.aspx"); }
                }
                Session.Add("id_dossier", id_dossier);
            }
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            getInfoClient();
            getInfoDossier();
            getQuestionPack();
        }

        private void getInfoDossier()
        {
            //Session.Add("id_dossier", "1");
            var idDossier = Session["id_dossier"].ToString();

            var elements = service.InfoDossier(idDossier);
            foreach (var dossier in elements)
            {
                NomGroupe.Text = dossier.GROUPE_DOSSIER;
                NoteGroupe.Text = dossier.NOTE_GROUPE;

                TNomGroupe.Text = dossier.GROUPE_DOSSIER;
                StringBuilder sbFil = new StringBuilder();
                //if(dossier.NOTE_VAL != null)
                //{
                    foreach(var f in service.ListeFiliale(dossier.GROUPE_DOSSIER))
                    {   
                        sbFil.AppendLine(string.Format("<li><span class='wrapper'><span class='border'>{0}</span></span></li>", 
                            f.ETCIV_NOMREDUIT));
                        notifMessage.Visible = false;
                        treeDiv.Visible = true;
                        ListFiliale.InnerHtml = sbFil.ToString();
                    }
                //}
                //else
                //{
                //    notifMessage.Visible = true;
                //    treeDiv.Visible = false;
                //}
            }
        }

        private void getQuestionPack()
        {
            EspaceQuestionnaire.InnerHtml = buildQuestionPack();
        }

        private string buildQuestionPack()
        {
            string s = "<div class='row'> <div class='col-md-12 question_pack_space'>";

            // ITERATION CHAPITRES
            var chapitres = service.ListeChapitreIG();
            foreach (var chapitre in chapitres)
            {
                s += "<div class='ln_chapitre col-md-12'>" + chapitre.LIBELLE_CHAPITRE + "</div>";

                // ITERATATION QUESTIONS
                var questions = service.ListeQuestion(chapitre.CODE_CHAPITRE);
                foreach (var question in questions)
                {
                    s += "<div class='ln_question_reponse col-md-12'><div class='ln_question col-md-6'>" + question.LIBELLE_QUESTION + "</div>";

                    // ITERATATION REPONSES
                    s += "<div class='ln_reponse col-md-6'> <select class=''>";
                    var reponses = service.ListeReponse(question.ID_QUESTION);
                    foreach (var reponse in reponses)
                    {
                        s += "<option value='" + reponse.NOTE_REPONSE + "'>" + reponse.LIBELLE_REPONSE + "</option>";
                    }
                    s += "</select></div></div>";
                }
            }
            s += "</div></div>";

            return s;
        }

        protected void Enregistrer_Click(object sender, EventArgs e)
        {

        }
    }
}