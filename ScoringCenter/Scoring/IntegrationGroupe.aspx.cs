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
        private System.Globalization.CultureInfo frCult = System.Globalization.CultureInfo.CreateSpecificCulture("fr-FR");
        protected void Page_Load(object sender, EventArgs e)
        {
            ControllerPage();
            if (!IsPostBack)
            {

            }
            //vergroupe_pays();
            //DemoFonct();
        }
        public void DemoFonct()
        {
            AF1.Visible = true;
            AS.Visible = false;
            AF2.Visible = false;
            IG.Visible = false;
            RP.Visible = false;
        }
        public void vergroupe_pays()
        {
            var idDossier = Session["id_dossier"].ToString();
            var elements = service.InfoDossier(idDossier);
            foreach (var dossier in elements)
            {
                if (dossier.NOTE_GROUPE.Trim() == "" || dossier.NOTE_GROUPE == null)
                {
                    IG.Visible = false;
                }
                //if (dossier.NOTE_PAYS.Trim() == "" || dossier.NOTE_PAYS == null)
                //{
                //    RP.Visible = false;
                //}
            }
        }
        public void ControllerPage()
        {
            ////Debut_Controle///////////////////////////////////////////////////
            if (Session["id_scoring"] == null) Response.Redirect("~/Scoring/Connexion.aspx");
            else
            {
                var idprofil = Session["id_profil"].ToString();
                var elements = service.VHABILITATION(idprofil);
                AD.Visible = false;
                TB.Visible = false;
                FS.Visible = false;
                HN.Visible = false;
                DN.Visible = false;
                AF1.Visible = false; AF2.Visible = false;
                AQ.Visible = false;
                IG.Visible = false;
                RP.Visible = false;
                E.Visible = false;
                VN.Visible = false;
                AN.Visible = false;


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

                    if (element.ID_DROIT.ToString().Trim() == "FS")
                    {
                        if (element.ID_TYPE_DROIT.ToString().Trim() != "0") FS.Visible = true;
                    }

                    if (element.ID_DROIT.ToString().Trim() == "HN")
                    {
                        if (element.ID_TYPE_DROIT.ToString().Trim() != "0") HN.Visible = true;
                    }
                    if (element.ID_DROIT.ToString().Trim() == "DN")
                    {
                        if (element.ID_TYPE_DROIT.ToString().Trim() != "0") DN.Visible = true;
                    }
                    if (element.ID_DROIT.ToString().Trim() == "AF1")
                    {
                        if (element.ID_TYPE_DROIT.ToString().Trim() != "0") AF1.Visible = true;
                    }
                    if (element.ID_DROIT.ToString().Trim() == "AQ")
                    {
                        if (element.ID_TYPE_DROIT.ToString().Trim() != "0") AQ.Visible = true;
                    }
                    if (element.ID_DROIT.ToString().Trim() == "IG")
                    {
                        if (element.ID_TYPE_DROIT.ToString().Trim() != "0") IG.Visible = true;
                    }
                    if (element.ID_DROIT.ToString().Trim() == "RP")
                    {
                        if (element.ID_TYPE_DROIT.ToString().Trim() != "0") RP.Visible = true;
                    }
                    if (element.ID_DROIT.ToString().Trim() == "E")
                    {
                        if (element.ID_TYPE_DROIT.ToString().Trim() != "0") E.Visible = true;
                    }
                    if (element.ID_DROIT.ToString().Trim() == "VN")
                    {
                        if (element.ID_TYPE_DROIT.ToString().Trim() != "0") VN.Visible = true;
                    }
                    if (element.ID_DROIT.ToString().Trim() == "AN")
                    {
                        if (element.ID_TYPE_DROIT.ToString().Trim() != "0") AN.Visible = true;
                    }
                    if (element.ID_DROIT.ToString().Trim() == "EBF")
                    {
                        if (element.ID_TYPE_DROIT.ToString().Trim() != "0") EBF.Visible = true;
                    }
                    //et pour les actions sur la page
                    if (element.ID_DROIT.ToString().Trim() == "IG")
                    {
                       
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
            getInfoClient(); EBF.Visible = false; ////Fin_Controle////////////////////////////////////////////////////
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
                        Idprincip.Text = v.TYPE_PROSPECT.Equals("Prospect") ? v.ID_SCORING : v.ETCIV_MATRICULE;
                        //CodeAPE.Text = v.RCCM;
                        //AEntreprise.Text = v.SECTACT_LIBELLE;
                        if (v.LIBELLE_MODELE.Trim() == "Groupe")
                        {
                            IG.Visible = false;
                            AQ.Visible = false;
                            AF1.Visible = false;
                            AF2.Visible = true;
                        }
                        else
                        {
                            AQ.Visible = true;
                            AF1.Visible = true;
                            AF2.Visible = false;
                            AS.Visible = false;

                        }
                        id_dossier = v.ID_DOSSIER;
                        SaiTypeClient.Text = v.TYPE_PROSPECT;
                        //IdScoringCenter.Text = v.ID_SCORING;
                        SigleBanq.Text = service.InfosBanqueByCode(v.CODE_BANQUE).SIGLE_BANQUE;

                        Siren.Text = v.ACTBCEAO_CODE + " " + v.ACTBCEAO_LIBELLE;
                        Devise.Text = v.DEVISE;
                        ChiffreAffaire.Text = v.CA != 0 ? Convert.ToString(string.Format(frCult, "{0:#,##0}", Convert.ToDecimal("0" + v.CA))) : "NC";
                        if (v.GROUPE_DOSSIER != "" && v.GROUPE_DOSSIER != null) { SaiGroupe.Text = v.GROUPE_DOSSIER; }
                        else { SaiGroupe.Text = "Aucun"; IG.Visible = false; Response.Redirect("~/Scoring/AutreDossier.aspx"); }
                    }
                    Session.Add("id_dossier", id_dossier);
                }
            }
            else
            {
                if (Session["id_scoring"] == null) Response.Redirect("~/Scoring/Connexion.aspx"); 

                var id_scoring = ScorCryptage.Decrypt(Request.QueryString["id"]);
                Session.Add("id_scoring", id_scoring);
                var code_banque = Session["code_banque"].ToString();
                var info = service.DetailsDossierContrepartie(code_banque, id_scoring);
                string id_dossier = "";
                foreach (var v in info)
                {
                    NClient.Text = v.ETCIV_NOMREDUIT;
                    Idprincip.Text = v.TYPE_PROSPECT.Equals("Prospect") ? v.ID_SCORING : v.ETCIV_MATRICULE;
                    //CodeAPE.Text = v.RCCM;
                    //AEntreprise.Text = v.SECTACT_LIBELLE;
                    if (v.LIBELLE_MODELE.Trim() == "Groupe")
                    {
                        IG.Visible = false;
                        AQ.Visible = false;
                        AF1.Visible = false;
                        AF2.Visible = true;
                    }
                    else
                    {
                        AQ.Visible = true;
                        AF1.Visible = true;
                        AF2.Visible = false;
                        AS.Visible = false;

                    }
                    id_dossier = v.ID_DOSSIER;
                    SaiTypeClient.Text = v.TYPE_PROSPECT;
                    //IdScoringCenter.Text = v.ID_SCORING;
                    SigleBanq.Text = service.InfosBanqueByCode(v.CODE_BANQUE).SIGLE_BANQUE;

                    Siren.Text = v.ACTBCEAO_CODE + " " + v.ACTBCEAO_LIBELLE;
                    Devise.Text = v.DEVISE;
                    ChiffreAffaire.Text = v.CA != 0 ? Convert.ToString(string.Format(frCult, "{0:#,##0}", Convert.ToDecimal("0" + v.CA))) : "NC";
                    if (v.GROUPE_DOSSIER != "" && v.GROUPE_DOSSIER != null) { SaiGroupe.Text = v.GROUPE_DOSSIER; }
                    else { SaiGroupe.Text = "Aucun"; IG.Visible = false; Response.Redirect("~/Scoring/AutreDossier.aspx"); }
                }
                Session.Add("id_dossier", id_dossier);
            }
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            getInfoClient();
            getInfoDossier();
            getQuestionPack();
            reinitReponse();
        }
        private void reinitReponse()
        {
            if (Session["id_dossier"] == null) Response.Redirect("~/Scoring/Connexion.aspx"); 

            var idDossier = Session["id_dossier"].ToString();
            Session.Add("id_dossier", idDossier);
            var docs = "";
            var reponses = service.Listreponse(idDossier, "N3");
            foreach (var reponse in reponses)
            {

                var docrep = "@" + reponse.ID_REPONSE.Trim();
                docs += docrep;
            }
            Hidden1.Value = docs;
        }
        private void getInfoDossier()
        {
            //Session.Add("id_dossier", "1");
            if (Session["id_dossier"] == null) Response.Redirect("~/Scoring/Connexion.aspx"); 

            var idDossier = Session["id_dossier"].ToString();

            var elements = service.InfoDossier(idDossier);
            foreach (var dossier in elements)
            {
                NomGroupe.Text = dossier.GROUPE_DOSSIER;
                NoteGroupe.Text = dossier.NOTE_GROUPE;
                TNomGroupev.Text = dossier.NOTE_GROUPE;
                TNomGroupe.Text = dossier.GROUPE_DOSSIER;
                StringBuilder sbFil = new StringBuilder();
                //if(dossier.NOTE_VAL != null)
                //{
                    foreach(var f in service.ListeFiliale(dossier.GROUPE_DOSSIER))
                    {
                        var tv = "__"; if (f.PRECEDENTE_NOTE != null && f.PRECEDENTE_NOTE != "") tv = f.PRECEDENTE_NOTE;
                        
                        sbFil.AppendLine(string.Format("<li><span class='wrapper'><span class='border'>{0} : {1}</span></span></li>", 
                            f.ETCIV_NOMREDUIT,tv));
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

            /*Modèle de notation*/
            LblModeleNotation.Text = "Modèle de notation : " + AnalyseFinanciere.getModeleNotation(idDossier);
            if (AnalyseFinanciere.getADireExpert(idDossier)) LblADireExpert.Text = "A dire d'expert : OUI";
            else LblADireExpert.Text = "A dire d'expert : NON";
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
            //foreach (var chapitre in chapitres)
            //{
            //    s += "<div class='ln_chapitre col-md-12'>" + chapitre.LIBELLE_CHAPITRE + "</div>";

            //    // ITERATATION QUESTIONS
            //    var questions = service.ListeQuestion(chapitre.CODE_CHAPITRE);
            //    foreach (var question in questions)
            //    {
            //        s += "<div class='ln_question_reponse col-md-12'><div class='ln_question col-md-6'>" + question.LIBELLE_QUESTION + "</div>";

            //        // ITERATATION REPONSES
            //        s += "<div class='ln_reponse col-md-6'> <select class=''>";
            //        var reponses = service.ListeReponse(question.ID_QUESTION);
            //        foreach (var reponse in reponses)
            //        {
            //            s += "<option value='" + reponse.NOTE_REPONSE + "'>" + reponse.LIBELLE_REPONSE + "</option>";
            //        }
            //        s += "</select></div></div>";
            //    }
                
            //}
            //s += "</div></div>";

            var i = 0;
            decimal tot = 0;
            foreach (var chapitre in chapitres)
            {
                s += "<div class='ln_chapitre col-md-12'>" + chapitre.LIBELLE_CHAPITRE + "</div>";

                // ITERATATION QUESTIONS
                var questions = service.ListeQuestion(chapitre.CODE_CHAPITRE);

                foreach (var question in questions)
                {
                    s += "<div class='ln_question_reponse col-md-12' ><div class='ln_question col-md-6'>" + question.LIBELLE_QUESTION + "</div>";
                    tot = tot + question.NOTE_QUESTION;
                    // ITERATATION REPONSES
                    s += "<div class='ln_reponse col-md-6'> <select  onchange=\"combo007($(this),'C')\" class='checkboxx' id='selec" + i + "' onchange='get_docs()'>";
                    var reponses = service.ListeReponse(question.ID_QUESTION);
                    foreach (var reponse in reponses)
                    {
                        s += "<option id='" + reponse.ID_REPONSE.Trim() + "' value='" + reponse.NOTE_REPONSE + "'>" + reponse.LIBELLE_REPONSE + "</option>";
                    }
                    s += "</select></div></div>";
                    i++;
                }
            }
            s += "</div></div>";
            Totcha.Value = tot.ToString();

            return s;
        }

        protected void Enregistrer_Click(object sender, EventArgs e)
        {
            if (Session["id_dossier"] == null) Response.Redirect("~/Scoring/Connexion.aspx"); 

            var idDossier = Session["id_dossier"].ToString();
            //var id_user = Session["id_user"].ToString();
            //Session.Add("id_user", id_user);
            //Session.Add("id_dossier", idDossier);
            //var tableau = checked_docs.Value.Split('@');
            //service.SupLesreponse(idDossier.Trim(), "N3", id_user.Trim(), "");
            //for (var i = 1; i < tableau.Length; i++)
            //{
            //    // alert(tableau[i]);
            //    service.Insertreponse(idDossier.Trim(), "N3", id_user.Trim(), tableau[i].ToString(), "" + i);
            //}

            var idUser = Session["id_user"].ToString();
            Session.Add("id_user", idUser);
            //_service.PS_SCOR_SPY(Session["id_user"].ToString().Trim(), "AnalyseQulitative", connmou007.Value, "I");
            var tableau = checked_docs.Value.Split('@');
            service.SupLesreponse(idDossier.Trim(), "N3", idUser.Trim(), "");
            for (var i = 1; i < tableau.Length; i++)
            {
                // alert(tableau[i]);
                service.Insertreponse(idDossier.Trim(), "N3", idUser.Trim(), tableau[i], "" + i);
            }
            Response.Redirect("IntegrationGroupe.aspx");
        }
       
    }
}