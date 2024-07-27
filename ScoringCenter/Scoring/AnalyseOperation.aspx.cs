using ScoringCenter.ScorManager;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ScoringCenter.Scoring
{
    public partial class AnalyseOperation : System.Web.UI.Page
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
                AOP.Visible = false;
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
                    if (element.ID_DROIT.Trim() == "OP")
                    {
                        if (element.ID_TYPE_DROIT.Trim() != "0") AOP.Visible = true;
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
                    if (element.ID_DROIT.Trim() == "EBF")
                    {
                        if (element.ID_TYPE_DROIT.Trim() != "0") EBF.Visible = true;
                    }


                    //et pour les actions sur la page
                    if (element.ID_DROIT.Trim() == "OP")
                    {
                        switch (element.ID_TYPE_DROIT.Trim())
                        {
                            case "1":
                                test = 1;
                                Scriptos.InnerHtml = "<script>$(':input').removeAttr('disabled');</script>";
                                break;
                            case "2":
                                if (test != 1)
                                {
                                    Scriptos.InnerHtml = "<script>$(':input').attr('disabled','disabled');</script>";
                                }
                                break;
                        }
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
            ReinitEmbranchement();
        
        }

        void OpenShowPasvalideConsult(string titre, string msg)
        {
         
            Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPasvalideConsult();", true);
            this.idtitre.Text = titre;
            this.idmesa.Text = msg;
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
            var reponses = _service.Listreponse(idDossier, "N6");
            foreach (var reponse in reponses)
            {
                var docrep = "@" + reponse.ID_REPONSE.Trim();
                docs += docrep;
            }
            
            if (DataManager.Ps_scor_get_seuil_dossier(idDossier.Trim()).Count!=0)
                docs += "@" + DataManager.Ps_scor_get_seuil_dossier(idDossier.Trim())[0].ID_SCOR_SEUIL_DELEGUATION;
            else docs += "@" + 0;
            Hidden1.Value = docs;
        }
        private void ReinitEmbranchement()
        {
            var idDossier = Session["id_dossier"].ToString();
            Session.Add("id_dossier", idDossier);
            string docs = "";
            var reponses = _service.Listreponse(idDossier, "N6");
            foreach (var reponse in reponses)
            {
                if (reponse.QUESTION_FILS.Trim() != "")
                {
                    var docrep = "@" + reponse.QUESTION_FILS.Trim();
                    docs += docrep;
                }
                Hidden2.Value = docs;
            }
        }
        private void GetInfoDossier()
        {
            // Session.Add("id_dossier", "1");
            var idDossier = "";
            if (Session["id_dossier"] == null) Response.Redirect("~/Scoring/Connexion.aspx");
            else idDossier = Session["id_dossier"].ToString();
            Session.Add("id_dossier", idDossier);

            var elements = _service.InfoDossier(idDossier);
            //if (elements.Count == 0) NoteQualitative.Text = "A+";
            foreach (var dossier in elements)
            {
                NoteQualitative1.Text = dossier.NOTE_OP;
                _idModele = dossier.MODELE_DOSSIER;

                Page.ClientScript.RegisterStartupScript(GetType(), "alert", string.Format("positionMarker('{0}');", NoteQualitative1.Text.Trim()), true);
            }

            /*Modèle de notation*/
            LblModeleNotation.Text = "Modèle de notation : " + AnalyseFinanciere.getModeleNotation(idDossier);
            if (AnalyseFinanciere.getADireExpert(idDossier)) LblADireExpert.Text = "A dire d'expert : OUI";
            else LblADireExpert.Text = "A dire d'expert : NON";
        }

        private void GetQuestionPack()
        {
            EspaceQuestionnaire.InnerHtml = BuildQuestionPack("ANAOPE")+" "+BuildMontantCreditPack();
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
                    var visible = ((question.HAVE_PARENT == "true" || question.HAVE_PARENT == "truetrue") ? " style=\"visibility: hidden\" " : " ");
                    s += "<div class='ln_question_reponse '  data-idquestion=\"" + question.ID_QUESTION.Trim() + "\">" + ((question.HAVE_PARENT == "true") ? "<div class='col-md-1'> <i class=\"glyphicon glyphicon-share-alt gly-flip-vertical \"></i></div>" : "") + ((question.HAVE_PARENT == "truetrue") ? "<div class='col-md-2'> <i class=\"glyphicon glyphicon-share-alt gly-flip-vertical \"></i></div>" : "") + " <div class='ln_question " + ((question.HAVE_PARENT == "true") ?  " col-md-7" : " col-md-8 ") + ((question.HAVE_PARENT == "truetrue") ? " col-md-6" : " col-md-8 ") + " '>" + question.LIBELLE_QUESTION + "</div>";
                    tot = tot + question.NOTE_QUESTION;
                    // ITERATATION REPONSES
                    
                    s += "<div class='ln_reponse col-md-4  '> <select  data-identifient=\"" + question.ID_QUESTION.Trim() + "\" data-parent=\"" + question.QUEST_PARENT.Trim() + "\"   class='checkboxx' id='selec" + i + "' onchange='get_docs()'>";
                    var reponses = _service.ListeReponseOperation(question.ID_QUESTION.Trim());
                    foreach (var reponse in reponses)
                    {
                        s += "<option id='" + reponse.ID_REPONSE.Trim() + "' data-parent=\"" + reponse.QUESTION_FILS.Trim() + "\" value='" + reponse.NOTE_REPONSE + "'>" + reponse.LIBELLE_REPONSE + "</option>";
                    }
                    s += "</select></div></div>";
                    i++;
                }
            }
            s += "</div></div>";
            Totcha.Value = tot.ToString(CultureInfo.InvariantCulture);
            return s;
        }


        private string BuildMontantCreditPack()
        {
            var s = "<div class='row'> <div class='col-md-12 question_pack_space'>";
            // ITERATION CHAPITRES
            //var chapitres = _service.ListeChapitre(modele);
            //var i = 0;
            //decimal tot = 0;
            //foreach (var chapitre in chapitres)
            //{
                s += "<div class='ln_chapitre col-md-12'>" + "Montant (Délégation)"+ "</div>";
                // ITERATATION QUESTIONS

                //var questions = _service.ListeQuestion(chapitre.CODE_CHAPITRE);
                //foreach (var question in questions)
                //{
                    //var visible = ((question.HAVE_PARENT == "true" || question.HAVE_PARENT == "truetrue") ? " style=\"visibility: hidden\" " : " ");
                    s += "<div class='ln_question_reponse '  data-idquestion=\"" + "" + "\">" +  "" +  "" + " <div class='ln_question " + " col-md-8 " + " col-md-8 " + " '>" + "Montant du prêt<label style='color: red'>*</label>" + "</div>";
                    //tot = tot + question.NOTE_QUESTION;
                    // ITERATATION REPONSES

                    s += "<div class='ln_reponse col-md-4  '> <select  onchange='get_docs_delegation()' class='_NO_checkboxx' id='selec" + "FIN" + "' >";
            //var reponses = _service.ListeReponseOperation(question.ID_QUESTION.Trim());
            //s += "<option value=''><option>";

            string code_banque;
            try
            {
                code_banque = ScorCryptage.Decrypt(Session["code_banque"].ToString());
            }
            catch (Exception e)
            {
                code_banque = Session["code_banque"].ToString();
            }
            if (DataManager.ListeSeuil(code_banque).Count != 0)
                    {
                        s += "<option value='0'></option>";
                        foreach (var seuil in DataManager.ListeSeuil(code_banque))
                        {
                            var MText = "";
                            if (seuil.MAX_SCOR_SEUIL_DELEGUATION.ToString() == Int64.MaxValue + "")
                                MText = Convert.ToDecimal(seuil.MIN_SCOR_SEUIL_DELEGUATION).ToString("#,##0.##") + " à " + "illimité";
                            else
                                MText = Convert.ToDecimal(seuil.MIN_SCOR_SEUIL_DELEGUATION).ToString("#,##0.##") + " à " + Convert.ToDecimal(seuil.MAX_SCOR_SEUIL_DELEGUATION).ToString("#,##0.##");
                            
                            s += "<option id='" + seuil.ID_SCOR_SEUIL_DELEGUATION + "' data-parent=\"" + "" + "\" value='" + seuil.ID_SCOR_SEUIL_DELEGUATION + "'>" + MText + "</option>";
                        }
                    }
                    s += "</select></div></div>";
                    //i++;
                //}
            //}
            s += "</div></div>";
            //Totcha.Value = tot.ToString(CultureInfo.InvariantCulture);
            return s;
        }


        public void Calc()
        {
            var idDossier = "";
            if (Session["id_dossier"] == null) Response.Redirect("~/Scoring/Connexion.aspx");
            else idDossier = Session["id_dossier"].ToString();
            Session.Add("id_dossier", idDossier);

            var modext = "ANAOPE";
            //calculerNoteQuest
            var intRep = _service.calculerNoteQuest(Convert.ToInt32(Totcha.Value.Trim()), "N6", modext);
            // valnotecalc.Value = IntRep.ToString().Trim().Replace(",", ".");
            var valeur = intRep;
            NoteQualitative1.Text = _service.Notereponsecalc("N6", valeur).Trim();
            //Response.Redirect("AnalyseQualitative.aspx");
        }

        protected void Calculer_Click(object sender, EventArgs e)
        {
            //milod.Visible = true;
            Calc();
            _service.PS_SCOR_SPY(Session["id_user"].ToString().Trim(), "AnalyseOperation", connmou007.Value, "I");
            Hidden1.Value = checked_docs.Value;
        }

        protected void Unnamed_ServerClick(object sender, EventArgs e)
        {
            NoteQualitative1.Text = "";
            Response.Redirect("~/Scoring/AnalyseOperation.aspx");
        }
        protected void Enregistrer_Click(object sender, EventArgs e)
        {
            // milod.Visible = true;
            var idDossier = "";
            if (Session["id_dossier"] == null) Response.Redirect("~/Scoring/Connexion.aspx");
            else idDossier = Session["id_dossier"].ToString();
            Session.Add("id_dossier", idDossier);

            var DetailNotes= _service.DetailsNotesDossier(idDossier).Where(nUser => nUser.NOTE_AQ != "" && nUser.NOTE_AQ != null).SingleOrDefault().NOTE_AQ; ;

            if (DetailNotes == null || DetailNotes.Trim()=="")
            {
                OpenShowPasvalideConsult("Information...", " La note de la contrepartie n’est pas déterminée, impossible de calculer la note de l’opération ");
            }
            else
            {

                var idUser = Session["id_user"].ToString();
                Session.Add("id_user", idUser);
                _service.PS_SCOR_SPY(Session["id_user"].ToString().Trim(), "AnalyseOperation", connmou007.Value, "I");
                var tableau = checked_docs.Value.Split('@');
                _service.SupLesreponse(idDossier.Trim(), "N6", idUser.Trim(), "");
                for (var i = 1; i < tableau.Length; i++)
                {
                    // alert(tableau[i]);
                    _service.Insertreponse(idDossier.Trim(), "N6", idUser.Trim(), tableau[i], "" + i);
                }
                DataManager.Ps_scor_insert_credit_dossier(Convert.ToInt32(checked_docs_delegation.Value), idDossier.Trim());
                Response.Redirect("~/Scoring/AnalyseOperation.aspx");
            }
           


        }
    }
}