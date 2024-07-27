using System;
using System.Globalization;

//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Web;
//using System.Web.UI;
//using System.Web.UI.WebControls;

namespace ScoringCenter.Scoring
{
    public partial class AnalyseQualitative : System.Web.UI.Page
    {
        //StringBuilder _sb = new StringBuilder();
        private readonly Scoringws _service = new Scoringws();

        private static string _idModele = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            ControllerPage();
            if (!IsPostBack)
            {
                
            }
            vergroupe_pays();
        }
        public void vergroupe_pays()
        {
            var idDossier = Session["id_dossier"].ToString();
            var elements = _service.InfoDossier(idDossier);
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
                var elements = _service.VHABILITATION(idprofil);
                AD.Visible = false;
                TB.Visible = false;
                FS.Visible = false;
                HN.Visible = false;
                DN.Visible = false;
                AF.Visible = false;
                AQ.Visible = false;
                IG.Visible = false;
                RP.Visible = false;
                E.Visible = false;
                VN.Visible = false;
                AN.Visible = false;
                EBF.Visible = false;



                var test = 0;
                foreach (var element in elements)
                {
                    if (element.ID_DROIT.Trim() == "AD")
                    {
                        if (element.ID_TYPE_DROIT.Trim() != "0") AD.Visible = true;
                    }
                    if (element.ID_DROIT.Trim() == "TB")
                    {
                        if (element.ID_TYPE_DROIT.Trim() != "0") TB.Visible = true;
                    }

                    if (element.ID_DROIT.Trim() == "FS")
                    {
                        if (element.ID_TYPE_DROIT.Trim() != "0") FS.Visible = true;
                    }

                    if (element.ID_DROIT.Trim() == "HN")
                    {
                        if (element.ID_TYPE_DROIT.Trim() != "0") HN.Visible = true;
                    }
                    if (element.ID_DROIT.Trim() == "DN")
                    {
                        if (element.ID_TYPE_DROIT.Trim() != "0") DN.Visible = true;
                    }
                    if (element.ID_DROIT.Trim() == "AF")
                    {
                        if (element.ID_TYPE_DROIT.Trim() != "0") AF.Visible = true;
                    }
                    if (element.ID_DROIT.Trim() == "AQ")
                    {
                        if (element.ID_TYPE_DROIT.Trim() != "0") AQ.Visible = true;
                    }
                    if (element.ID_DROIT.Trim() == "IG")
                    {
                        if (element.ID_TYPE_DROIT.Trim() != "0") IG.Visible = true;
                    }
                    if (element.ID_DROIT.Trim() == "RP")
                    {
                        if (element.ID_TYPE_DROIT.Trim() != "0") RP.Visible = true;
                    }
                    if (element.ID_DROIT.Trim() == "E")
                    {
                        if (element.ID_TYPE_DROIT.Trim() != "0") E.Visible = true;
                    }
                    if (element.ID_DROIT.Trim() == "VN")
                    {
                        if (element.ID_TYPE_DROIT.Trim() != "0") VN.Visible = true;
                    }
                    if (element.ID_DROIT.Trim() == "AN")
                    {
                        if (element.ID_TYPE_DROIT.Trim() != "0") AN.Visible = true;
                    }
                    if (element.ID_DROIT.Trim() == "EBF")
                    {
                        if (element.ID_TYPE_DROIT.Trim() != "0") EBF.Visible = true;
                    }
                    //et pour les actions sur la page
                    if (element.ID_DROIT.Trim() != "AQ") continue;
                    switch (element.ID_TYPE_DROIT.Trim())
                    {
                        case "1": test = 1;
                            Scriptos.InnerHtml = "<script>$(':input').removeAttr('disabled');</script>";
                            break;
                        case "2": if (test != 1)
                            {
                                Scriptos.InnerHtml = "<script>$(':input').attr('disabled','disabled');</script>";
                            }
                            break;
                    }



                }
            }
            EBF.Visible = false; EBF.Visible = false; ////Fin_Controle////////////////////////////////////////////////////
        }
        protected void Page_Init(object sender, EventArgs e)
        {
            GetInfoClient();
            GetInfoDossier();
            GetQuestionPack();
            ReinitReponse();

            
        }

        public void GetInfoClient()
        {
            if (string.IsNullOrEmpty(Request.QueryString["id"]))
            {
                if (string.IsNullOrEmpty(Session["id_scoring"].ToString()))
                    Response.Redirect("AutreDossier.aspx");
                else
                {
                    var idScoring = Session["id_scoring"].ToString();
                    Session.Add("id_scoring", idScoring);
                    var codeBanque = Session["code_banque"].ToString();
                    var info = _service.DetailsDossierContrepartie(codeBanque, idScoring);
                    var idDossier = "";
                    foreach (var v in info)
                    {
                        NClient.Text = v.ETCIV_NOMREDUIT;
                        //Idprincip.Text = v.ID_SCORING;
                        CodeAPE.Text = v.RCCM;
                        //AEntreprise.Text = v.SECTACT_LIBELLE;
                        SaiTypeClient.Text = v.TYPE_PROSPECT;
                        IdScoringCenter.Text = v.ID_SCORING;
                        Siren.Text = v.ACTBCEAO_LIBELLE;
                        Devise.Text = v.DEVISE;
                        ChiffreAffaire.Text = Convert.ToString(string.Format("{0:#,##0}", v.CA));
                        idDossier = v.ID_DOSSIER;
                        if (v.GROUPE_DOSSIER != "") { }
                        else { IG.Visible = false; }
                    }
                    Session.Add("id_dossier", idDossier);
                }
            }
            else
            {
                var idScoring = ScorCryptage.Decrypt(Request.QueryString["id"]);
                Session.Add("id_scoring", idScoring);
                var codeBanque = Session["code_banque"].ToString();
                var info = _service.DetailsDossierContrepartie(codeBanque, idScoring);
                var idDossier = "";
                foreach (var v in info)
                {
                    NClient.Text = v.ETCIV_NOMREDUIT;
                    //Idprincip.Text = v.ID_SCORING;
                    CodeAPE.Text = v.RCCM;
                    //AEntreprise.Text = v.SECTACT_LIBELLE;
                    SaiTypeClient.Text = v.TYPE_PROSPECT;
                    IdScoringCenter.Text = v.ID_SCORING;
                    Siren.Text = v.ACTBCEAO_LIBELLE;
                    Devise.Text = v.DEVISE;
                    ChiffreAffaire.Text = Convert.ToString(string.Format("{0:#,##0}", v.CA));
                    idDossier = v.ID_DOSSIER;
                    if (v.GROUPE_DOSSIER != "") { }
                    else { IG.Visible = false; }
                }
                Session.Add("id_dossier", idDossier);
            }
            
        }

        private void ReinitReponse()
        {
            var idDossier = Session["id_dossier"].ToString();
            Session.Add("id_dossier", idDossier);
            var docs = "";
            var reponses = _service.Listreponse(idDossier, "N2");
            foreach (var reponse in reponses)
            {
                var docrep = "@" + reponse.ID_REPONSE.Trim();
                docs += docrep;
            }
            Hidden1.Value = docs;
        }

        private void GetInfoDossier()
        {
           // Session.Add("id_dossier", "1");
            var idDossier = "";
            if (Session["id_dossier"] == null) Response.Redirect("~/Scoring/Connexion.aspx");
            else idDossier = Session["id_dossier"].ToString();
            Session.Add("id_dossier", idDossier);

            var elements = _service.InfoDossier(idDossier);
            foreach (var dossier in elements) {
                ModeleNotation.Text = dossier.LIBELLE_MODELE;
                NoteQualitative.Text = dossier.NOTE_AQ;
                _idModele = dossier.MODELE_DOSSIER;
            }
        }

        private void GetQuestionPack()
        {
            EspaceQuestionnaire.InnerHtml = BuildQuestionPack(_idModele);
        }


        private string BuildQuestionPack(string modele)
        {
            var s = "<div class='row'> <div class='col-md-12 question_pack_space'>";

            // ITERATION CHAPITRES
            var chapitres = _service.ListeChapitre(modele);
            var i = 0;
            decimal tot = 0;
            foreach (var chapitre in chapitres)
            {
                s += "<div class='ln_chapitre col-md-12'>" + chapitre.LIBELLE_CHAPITRE + "</div>";

                // ITERATATION QUESTIONS
                var questions = _service.ListeQuestion(chapitre.CODE_CHAPITRE);
                
                foreach (var question in questions)
                {
                    s += "<div class='ln_question_reponse col-md-12' ><div class='ln_question col-md-6'>" + question.LIBELLE_QUESTION + "</div>";
                   tot= tot + question.NOTE_QUESTION;
                    // ITERATATION REPONSES
                    s += "<div class='ln_reponse col-md-6'> <select  onchange=\"combo007($(this),'C')\"  class='checkboxx' id='selec"+i+"' onchange='get_docs()'>";
                    var reponses = _service.ListeReponse(question.ID_QUESTION);
                    foreach (var reponse in reponses)
                    {
                        s += "<option id='" + reponse.ID_REPONSE.Trim() + "' value='" + reponse.NOTE_REPONSE + "'>" + reponse.LIBELLE_REPONSE + "</option>";
                    }
                    s += "</select></div></div>";
                    i++;
                }
            }
            s += "</div></div>";
            Totcha.Value = tot.ToString(CultureInfo.InvariantCulture);
            return s;
        }
        
        
        public void Calc()
        {
            var idDossier = "";
            if (Session["id_dossier"] == null) Response.Redirect("~/Scoring/Connexion.aspx");
            else idDossier = Session["id_dossier"].ToString();
            Session.Add("id_dossier", idDossier);

            var modext="";
            var elements = _service.InfoDossier(idDossier);
            foreach (var dossier in elements)
            {
                modext = dossier.CODE_MODELE;
               
            }
            //calculerNoteQuest
            var intRep = _service.calculerNoteQuest(Convert.ToInt32(Totcha.Value.Trim()), "N2", modext);
           // valnotecalc.Value = IntRep.ToString().Trim().Replace(",", ".");
            var valeur = intRep;
            NoteQualitative.Text=_service.Notereponsecalc("N2", valeur).Trim();
            //Response.Redirect("AnalyseQualitative.aspx");
        }

        protected void Calculer_Click(object sender, EventArgs e)
        {
            Calc();
            _service.PS_SCOR_SPY(Session["id_user"].ToString().Trim(), "AnalyseQulitative", connmou007.Value, "I");
            Hidden1.Value = checked_docs.Value;
        }

        protected void Enregistrer_Click(object sender, EventArgs e)
        {
            var idDossier = "";
            if (Session["id_dossier"] == null) Response.Redirect("~/Scoring/Connexion.aspx");
            else idDossier = Session["id_dossier"].ToString();
            Session.Add("id_dossier", idDossier);

            var idUser = Session["id_user"].ToString();
            Session.Add("id_user", idUser);
            _service.PS_SCOR_SPY(Session["id_user"].ToString().Trim(), "AnalyseQulitative", connmou007.Value, "I");
            var tableau = checked_docs.Value.Split('@');
            _service.SupLesreponse(idDossier.Trim(), "N2", idUser.Trim(), "");
            for (var i = 1; i < tableau.Length; i++)
            {
                // alert(tableau[i]);
                _service.Insertreponse(idDossier.Trim(), "N2", idUser.Trim(), tableau[i],""+i);
            }
            Response.Redirect("~/Scoring/AnalyseQualitative.aspx");
        }
        
    }
}