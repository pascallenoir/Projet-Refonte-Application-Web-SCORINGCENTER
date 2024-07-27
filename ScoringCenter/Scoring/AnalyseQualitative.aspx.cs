using System;
using System.Linq;
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
        private System.Globalization.CultureInfo frCult = System.Globalization.CultureInfo.CreateSpecificCulture("fr-FR");
        Scoringws service = new Scoringws();

        protected void Page_Load(object sender, EventArgs e)
        {
            ControllerPage();
            if (!IsPostBack)
            {
                
            }
            //vergroupe_pays();
            //DemoFonct();
            //milod.Visible = false;
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
                AF1.Visible = false;
                AF2.Visible = false;
                AQ.Visible = false;
                IG.Visible = false;
                RP.Visible = false;
                E.Visible = false;
                VN.Visible = false;
                AN.Visible = false;



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
                    if (element.ID_DROIT.Trim() == "AF1")
                    {
                        if (element.ID_TYPE_DROIT.Trim() != "0") AF1.Visible = true;
                    }
                    if (element.ID_DROIT.Trim() == "AF2")
                    {
                        if (element.ID_TYPE_DROIT.Trim() != "0") AF2.Visible = true;
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
            GetInfoClient(); EBF.Visible = false; ////Fin_Controle////////////////////////////////////////////////////
            controlDisableMenu();
        }

        private void controlDisableMenu()
        {
            if (Session["id_dossier"] == null) Response.Redirect("~/Scoring/Connexion.aspx");

            // griser certains menus pour l'utilisateur s'il n'est pas de la mm banque que le tiers
            string id_scoring = Session["id_scoring"].ToString();
            string id_user = Session["id_user"].ToString();
            var info_contrepartie = service.DetailsDossierContrepartie("", id_scoring).LastOrDefault();
            var user = service.InfoUser(id_user);
            if (info_contrepartie.CODE_BANQUE != user.CODE_BANQUE)
            {
                TB.InnerHtml = "<a class='pureCssMenui btn disabled'>Tableau de bord</a>";
                DN.InnerHtml = "<a class='pureCssMenui btn disabled'>Effectuer une notation</a>";
                AN.InnerHtml = "<a class='pureCssMenui btn disabled'>Annotations</a>";

                NCP.InnerHtml = "<a class='pureCssMenui btn disabled'>Notation de la contrepartie</a>";
                NOP.InnerHtml = "<a class='pureCssMenui btn disabled'>Notation de l'opération</a>";
                VN.InnerHtml = "<a class='pureCssMenui btn disabled'>Validation de la note</a>";

                AF1.InnerHtml = "<a class='pureCssMenui btn disabled'>Analyse financière</a>";
                AQ.InnerHtml = "<a class='pureCssMenui btn disabled'>Analyse qualitative</a>";
                RP.InnerHtml = "<a class='pureCssMenui btn disabled'>Risque pays</a>";
                AOP.InnerHtml = "<a class='pureCssMenui btn disabled'>Analyse de l'opération</a>";
                E.InnerHtml = "<a class='pureCssMenui btn disabled'>Encours</a>";
            }
        }

        protected void Page_Init(object sender, EventArgs e)
        {
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
                        idDossier = v.ID_DOSSIER;
                        SaiTypeClient.Text = v.TYPE_PROSPECT;
                        //IdScoringCenter.Text = v.ID_SCORING;
                        SigleBanq.Text = service.InfosBanqueByCode(v.CODE_BANQUE).SIGLE_BANQUE;

                        Siren.Text = v.ACTBCEAO_CODE + " " + v.ACTBCEAO_LIBELLE;
                        Devise.Text = v.DEVISE;
                        ChiffreAffaire.Text = v.CA != 0 ? Convert.ToString(string.Format(frCult, "{0:#,##0}", Convert.ToDecimal("0" + v.CA))) : "NC";
                        if (v.GROUPE_DOSSIER != "" && v.GROUPE_DOSSIER != null) { SaiGroupe.Text = v.GROUPE_DOSSIER; }
                        else { SaiGroupe.Text = "Aucun"; IG.Visible = false; }                        
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
                    idDossier = v.ID_DOSSIER;
                    SaiTypeClient.Text = v.TYPE_PROSPECT;
                    //IdScoringCenter.Text = v.ID_SCORING;
                    SigleBanq.Text = service.InfosBanqueByCode(v.CODE_BANQUE).SIGLE_BANQUE;

                    Siren.Text = v.ACTBCEAO_CODE + " " + v.ACTBCEAO_LIBELLE;
                    Devise.Text = v.DEVISE;
                    ChiffreAffaire.Text = v.CA != 0 ? Convert.ToString(string.Format(frCult, "{0:#,##0}", Convert.ToDecimal("0" + v.CA))) : "NC";
                    if (v.GROUPE_DOSSIER != "" && v.GROUPE_DOSSIER != null) { SaiGroupe.Text = v.GROUPE_DOSSIER; }
                    else { SaiGroupe.Text = "Aucun"; IG.Visible = false; }
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

                Page.ClientScript.RegisterStartupScript(GetType(), "alert", string.Format("positionMarker('{0}');", NoteQualitative.Text.Trim()), true);
            }

            /*Modèle de notation*/
            LblModeleNotation.Text = "Modèle de notation : " + AnalyseFinanciere.getModeleNotation(idDossier);
            if (AnalyseFinanciere.getADireExpert(idDossier)) LblADireExpert.Text = "A dire d'expert : OUI";
            else LblADireExpert.Text = "A dire d'expert : NON";
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
                    s += "<option id='" + "' value='" + "'>" + "</option>";
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
            var intRep = _service.calculerNoteQuest(Convert.ToInt32(Totcha.Value.Trim() != "NaN" ? Totcha.Value.Trim() : "0"), "N2", modext);
           // valnotecalc.Value = IntRep.ToString().Trim().Replace(",", ".");
            var valeur = intRep;
            if(intRep!=0)
            NoteQualitative.Text=_service.Notereponsecalc("N2", valeur).Trim();
            //Response.Redirect("AnalyseQualitative.aspx");
        }

        protected void Calculer_Click(object sender, EventArgs e)
        {
            //milod.Visible = true;
            Calc();
            if(Totcha.Value.Trim() != "NaN") _service.PS_SCOR_SPY(Session["id_user"].ToString().Trim(), "AnalyseQualitative", connmou007.Value, "I");
            Hidden1.Value = checked_docs.Value;
        }

        public void StopLoading(){
            //this.st
            Hidden1.Value = checked_docs.Value;
        }

        protected void Enregistrer_Click(object sender, EventArgs e)
        {
           // milod.Visible = true;
            var idDossier = "";
            if (Session["id_dossier"] == null) Response.Redirect("~/Scoring/Connexion.aspx");
            else idDossier = Session["id_dossier"].ToString();
            Session.Add("id_dossier", idDossier);

            var idUser = Session["id_user"].ToString();
            Session.Add("id_user", idUser);
            _service.PS_SCOR_SPY(Session["id_user"].ToString().Trim(), "AnalyseQualitative", connmou007.Value, "I");
            var tableau = checked_docs.Value.Split('@');
            
            var iiik = 1;
            for (var i = 1; i < tableau.Length; i++)
            {
                // alert(tableau[i]);

                if (tableau[i].Trim() != "")
                    iiik++;
                //else
            }
            
            if (iiik == tableau.Length){
                _service.SupLesreponse(idDossier.Trim(), "N2", idUser.Trim(), "");
                for (var i = 1; i < tableau.Length; i++)
                {
                    _service.Insertreponse(idDossier.Trim(), "N2", idUser.Trim(), tableau[i], "" + i);

                }
                Page.Response.Redirect(Page.Request.Url.ToString(), true);
            }
            else
            {
                this.StopLoading();
               // _service.SupLesreponse(idDossier.Trim(), "N2", idUser.Trim(), "");
            }
        }
    }
}