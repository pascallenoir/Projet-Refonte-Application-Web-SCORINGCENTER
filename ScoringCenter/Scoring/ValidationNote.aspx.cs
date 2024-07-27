using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Net.Mime;
using System.Configuration;
using ScoringCenter.Models;
using ScoringCenter.ScorManager;

namespace ScoringCenter.Scoring
{
    public partial class ValidationNote : System.Web.UI.Page
    {
        StringBuilder sb = new StringBuilder();
        Scoringws service = new Scoringws();
        decimal dossierMail = 0;
        decimal PlafondMaiil = 0;
        string ETCIV_NOMREDUIT = "";
        private System.Globalization.CultureInfo frCult = System.Globalization.CultureInfo.CreateSpecificCulture("fr-FR");
        protected void Page_Load(object sender, EventArgs e)
        {
            ControllerPage();
            if (!IsPostBack)
            {
                verCA();
                ADEFonc();
            }

            //vergroupe_pays();

            //DemoFonct();
            //controlDelegation();
        }
        //public void controlDelegation()
        //{
        //    var idDossier = Session["id_dossier"].ToString();
        //    Session.Add("id_dossier", idDossier);
        //    var docs = "";
        //    var decompte = DataManager.Ps_scor_get_seuil_dossier(idDossier);
        //    if (decompte.Count == 0)
        //    {
        //        //Page.ClientScript.RegisterStartupScript(this.GetType(), "myKey", "<script>$(':input').attr('disabled','disabled');</script>", false);
        //        //EnvoyerVN.Visible = false;
        //        //RejeterVN.Disabled = false;
        //        //ValiderVN.Disabled = false;
        //    }
        //}
        public void ADEFonc()
        {
            if (Session["id_dossier"] == null) Response.Redirect("~/Scoring/Connexion.aspx");
            var idDossier = Session["id_dossier"].ToString();
            var ser = service.selectAdiredexpert(idDossier);
            if (ser.Count != 0)
            {
                foreach (var s in ser)
                {
                    if (s.FICHIER_VAL != null) if (s.FICHIER_VAL.Trim() != "")
                        {
                            CHMPADE.InnerHtml = "<h3><b class='text-danger'>A dire d'expert</b></h3>";
                            //ADE_ServerChange();
                            //ADE.Checked = true;
                            SelectNotation.Items.FindByValue("ADE").Selected = true;
                        }
                }
            }

        }
        public void DemoFonct()
        {
            AF1.Visible = true;
            AS.Visible = false;
            AF2.Visible = false;
            IG.Visible = false;
            RP.Visible = false;
        }
        void OpenShowPasvalideConsult(string titre, string msg)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPasvalideConsult();", true);
            this.lblPasValidemessageConsult.Text = msg;
            this.lblPasValideTitreConsult.Text = titre;
        }

        public void verCA()
        {
            if (Session["id_scoring"] == null) Response.Redirect("~/Scoring/Connexion.aspx");

            var id_scoring = Session["id_scoring"].ToString();
            var code_banque = Session["code_banque"].ToString();
            var id_profil = Session["id_profil"].ToString();
            decimal plafond = 0;
            var elements = service.DetailsDossierContrepartie(code_banque, id_scoring);
            var list_profil = service.ListeProfil(6, id_profil.Trim(), code_banque, id_profil.Trim(), "", 0, true);
            if (list_profil.Count != 0)
            {
                foreach (var li in list_profil)
                {
                    plafond = Convert.ToDecimal(li.PLAFOND_PROFIL);
                    PlafondMaiil = plafond;
                }
            }
            //++++++++++++++++++++++++++++++++
            var iddossier = Session["id_dossier"].ToString();
            Int64 xcd = 0;
            int xxd1 = 0;
            var inin = DataManager.Ps_scor_leseuil(Convert.ToInt32(plafond));
            if (inin.Count != 0)
            {
                xcd = 0;
                var MAXSEUIL = inin.FirstOrDefault().MAX_SCOR_SEUIL_DELEGUATION;
                var MINSEUIL = inin.FirstOrDefault().MIN_SCOR_SEUIL_DELEGUATION;
                ID = inin.FirstOrDefault().ID_SCOR_SEUIL_DELEGUATION.ToString();
                //if (MAXSEUIL.ToString() == Int64.MaxValue + "")
                //    xcd += "illimité";
                //else
                xcd = Convert.ToInt64(MAXSEUIL);
            }
            if (DataManager.Ps_scor_get_seuil_dossier(iddossier.Trim()).Count != 0)
                xxd1 = DataManager.Ps_scor_get_seuil_dossier(iddossier.Trim())[0].ID_SCOR_SEUIL_DELEGUATION;

            var inin1 = DataManager.Ps_scor_leseuil(Convert.ToInt32(xxd1));
            Int64 xcd1 = 0;
            if (inin1.Count != 0)
            {
                xcd1 = 0;
                var MAXSEUIL = inin1.FirstOrDefault().MAX_SCOR_SEUIL_DELEGUATION;
                var MINSEUIL = inin1.FirstOrDefault().MIN_SCOR_SEUIL_DELEGUATION;
                ID = inin1.FirstOrDefault().ID_SCOR_SEUIL_DELEGUATION.ToString();
                xcd1 = Convert.ToInt64(MAXSEUIL);
            }
            //++++++++++++++++++++++++++++++++
            foreach (var dossier in elements)
            {
                dossierMail = Convert.ToDecimal(dossier.CA);

                if (xcd1 <= xcd)
                {
                    VerifSaisi.Text = "1";
                    //buttons
                    //ValiderVN.Visible = true;
                    //ValiderVN.Enabled = true;

                    //RejeterVN.Visible = true;
                    //RejeterVN.Enabled = true;

                    //EnvoyerVN.Visible = false;
                    //EnvoyerVN.Enabled = false;
                    ////text box
                    //TbNPropose.Visible = true;
                    //TbNPropose.Enabled=false;

                    //TbNValidRejet.Visible = true;
                    //TbNValidRejet.Enabled = true;
                    ////combos
                    //DdlNPropose.Visible=false;
                    //DdlNPropose.Enabled = false;

                    //DdlNValidRejet.Visible = true;
                    //DdlNValidRejet.Enabled = true;



                    //i1.Visible = true;
                    //i2.Visible = true;
                    //i3.Visible = true;
                }
                if (xcd1 > xcd)
                {
                    VerifSaisi.Text = "2";
                    //buttons
                    ////ValiderVN.Visible = false;
                    //ValiderVN.Enabled = false;

                    ////RejeterVN.Visible = false;
                    //RejeterVN.Enabled = false;

                    //EnvoyerVN.Visible = true;
                    //EnvoyerVN.Enabled = true;
                    ////text box
                    //TbNPropose.Visible = true;
                    //TbNPropose.Enabled = true;

                    ////TbNValidRejet.Visible = false;
                    //TbNValidRejet.Enabled = false;
                    ////combos
                    //DdlNPropose.Visible = true;
                    //DdlNPropose.Enabled = true;

                    ////DdlNValidRejet.Visible = false;
                    //DdlNValidRejet.Enabled = false;

                    //i1.Visible = true;
                    //i2.Visible = true;
                    //i3.Visible = true;
                }
            }
            if (Session["id_dossier"] == null) Response.Redirect("~/Scoring/Connexion.aspx");

            var id_dossier = Session["id_dossier"].ToString();
            // var id_scoring = Session["id_scoring"].ToString();
            Session.Add("id_dossier", id_dossier);
            // Session.Add("id_scoring", id_scoring);
            iddossierdef.Value = id_dossier;

            var DetailNotes = service.DetailsNotesDossier(id_dossier);

            if (DetailNotes.Count != 0)
            {
                foreach (var Notes in DetailNotes)
                {
                    if (Notes.NOTE_VAL.Trim() != "" && Notes.NOTE_VAL.Trim() != null)
                    {
                        VerifValide.Text = "Déjà valide";
                        NoteValid.Text = Notes.NOTE_VAL.Trim();
                        //message.InnerHtml = "Note Validée : <b>" + Notes.NOTE_VAL.Trim() + "</b>";
                    }
                }
            }
        }
        public void vergroupe_pays()
        {
            if (Session["id_dossier"] == null) Response.Redirect("~/Scoring/Connexion.aspx");

            var idDossier = Session["id_dossier"].ToString();
            var elements = service.InfoDossier(idDossier);
            foreach (var dossier in elements)
            {
                if (dossier.NOTE_GROUPE.Trim() == "" || dossier.NOTE_GROUPE == null)
                {
                    IG.Visible = false;
                    //libgroup.Visible = false;
                }
                //if (dossier.NOTE_PAYS.Trim() == "" || dossier.NOTE_GROUPE == null)
                //{
                //    RP.Visible = false;
                //    libpays.Visible = false;
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
                    if (element.ID_DROIT.ToString().Trim() == "VN")
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
            if (info_contrepartie.CODE_BANQUE != user.CODE_BANQUE) {
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

        public void getInfoClient()
        {
            //SelectNotation.Items.Clear();
            //SelectNotation.Items.Add(new ListItem("Corporate", "corporate"));
            //SelectNotation.Items.Add(new ListItem("A dire d'expert", "ade"));
            if (string.IsNullOrEmpty(Request.QueryString["id"]))
            {
                if (Session["id_scoring"] == null) Response.Redirect("~/Scoring/Connexion.aspx");
                if (string.IsNullOrEmpty(Session["id_scoring"].ToString()))
                    Response.Redirect("~/Scoring/AutreDossier.aspx");
                else
                {
                    if (Session["id_scoring"] == null) Response.Redirect("~/Scoring/Connexion.aspx");
                    var id_scoring = Session["id_scoring"].ToString();
                    Session.Add("id_scoring", id_scoring);
                    var code_banque = Session["code_banque"].ToString();
                    var info = service.DetailsDossierContrepartie(code_banque, id_scoring);
                    string id_dossier = "";
                    foreach (var v in info)
                    {
                        ETCIV_NOMREDUIT = v.ETCIV_NOMREDUIT;
                        NClient.Text = v.ETCIV_NOMREDUIT;
                        Idprincip.Text = v.TYPE_PROSPECT.Equals("Prospect") ? v.ID_SCORING : v.ETCIV_MATRICULE;
                        //CodeAPE.Text = v.RCCM;
                        //AEntreprise.Text = v.SECTACT_LIBELLE;
                        MNotation.Text = v.LIBELLE_MODELE;
                        StringBuilder sb = new StringBuilder();
                        if (v.LIBELLE_MODELE.Trim() == "Groupe")
                        {

                            NFN.Visible = false;
                            NCO.Visible = true;
                            NST.Visible = true;
                            NQA.Visible = false;
                            libgroup.Visible = false;
                        }
                        else
                        {
                            NST.Visible = false;
                            NQA.Visible = true;
                            NFN.Visible = true;
                            NCO.Visible = false;

                        }
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
                        else { SaiGroupe.Text = "Aucun"; IG.Visible = false; }
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
                    ETCIV_NOMREDUIT = v.ETCIV_NOMREDUIT;
                    NClient.Text = v.ETCIV_NOMREDUIT;
                    Idprincip.Text = v.TYPE_PROSPECT.Equals("Prospect") ? v.ID_SCORING : v.ETCIV_MATRICULE;
                    //CodeAPE.Text = v.RCCM;
                    //AEntreprise.Text = v.SECTACT_LIBELLE;
                    MNotation.Text = v.LIBELLE_MODELE;
                    if (v.LIBELLE_MODELE.Trim() == "Groupe")
                    {
                        NST.Visible = true;
                        NQA.Visible = false;
                        libgroup.Visible = false;
                    }
                    else
                    {
                        NST.Visible = false;
                        NQA.Visible = true;

                    }
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
                    else { SaiGroupe.Text = "Aucun"; IG.Visible = false; }
                }
                Session.Add("id_dossier", id_dossier);
            }
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            getInfoClient();
            AfficherInfoDossier();

        }
        protected void ValiderVN_Click(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                ValiderVN.Disabled = true;
                if (DdlNValidRejet.Text != "" && TbNValidRejet.Text != "")
                {
                    if (Session["id_user"] == null) Response.Redirect("~/Scoring/Connexion.aspx");

                    service.PS_SCOR_SPY(Session["id_user"].ToString().Trim(), "ValidationNote", connmou007.Value.ToString(), "I");
                    var id_dossier = Session["id_dossier"].ToString();
                    Session.Add("id_dossier", id_dossier);
                    var id_user = Session["id_user"].ToString();
                    Session.Add("id_user", id_user);
                    // service.ProposeNotesDossier(id_dossier, "", id_user);
                    if (TbNValidRejet.Text.Trim() != "")
                    { service.traiterCommentaire(2, id_user.Trim(), id_dossier.Trim(), "", "", TbNValidRejet.Text.Trim(), "", DateTime.Now); }

                    service.ValideNotesDossier(id_dossier, DdlNValidRejet.Text, id_user, TbNValidRejet.Text);

                    if (SelectNotation.SelectedValue == "ADE")
                    { service.Adiredexpert(id_dossier); }
                    else
                    { service.offAdiredexpert(id_dossier); }

                    //Page_Init(sender, e);
                    //ValiderVN.Disabled = false;
                    //Session.Add("id_dossier", (Convert.ToInt32(id_dossier.Trim())+2).ToString());
                    //DdlNValidRejet.Text = ""; TbNValidRejet.Text = "";
                    Response.Redirect("~/Scoring/HistoriqueNotation.aspx");
                }
                else
                {
                    if (DdlNValidRejet.Text.Trim() != NICalculee.Text.Trim())
                    {
                        ValiderVN.Disabled = false;
                        if (SelectNotation.SelectedValue == "ADE")
                            OpenShowPasvalideConsult("", "Vous devez argumenter le choix de la note.");
                        else
                            OpenShowPasvalideConsult("", "L’écart entre la note calculée et la note Validée doit être justifié dans la zone commentaire.");

                    }
                    else
                    {
                        if (Session["id_user"] == null) Response.Redirect("~/Scoring/Connexion.aspx");

                        service.PS_SCOR_SPY(Session["id_user"].ToString().Trim(), "ValidationNote", connmou007.Value.ToString(), "I");
                        var id_dossier = Session["id_dossier"].ToString();
                        Session.Add("id_dossier", id_dossier);
                        var id_user = Session["id_user"].ToString();
                        Session.Add("id_user", id_user);
                        // service.ProposeNotesDossier(id_dossier, "", id_user);
                        if (TbNValidRejet.Text.Trim() != "")
                            service.traiterCommentaire(2, id_user.Trim(), id_dossier.Trim(), "", "", TbNValidRejet.Text.Trim(), "", DateTime.Now);

                        service.ValideNotesDossier(id_dossier, DdlNValidRejet.Text, id_user, TbNValidRejet.Text);
                        if (SelectNotation.SelectedValue == "ADE") service.Adiredexpert(id_dossier);
                        else service.offAdiredexpert(id_dossier);
                        //Page_Init(sender, e);
                        ValiderVN.Disabled = false;
                        //Session.Add("id_dossier", (Convert.ToInt32(id_dossier.Trim()) + 2).ToString());
                        Response.Redirect("~/Scoring/HistoriqueNotation.aspx");
                    }

                }
            }
            else
            {
                Response.Redirect("~/Scoring/HistoriqueNotation.aspx");
            }

        }

        public void envoyerMail( string NomContrepartie)
        {

            string delegataire = "";
            string adress = "";
            string adressCopie = "";
            string DateEnvoi = DateTime.Now.ToString("dd/MM/yyyy");
            string NomPropoNote = Session["nom_user"].ToString();
            string[] arr1 = new string[1];
            var titi = 0;
            var id_dossier = Session["id_dossier"].ToString();
            if (DataManager.Ps_scor_get_seuil_dossier(id_dossier.Trim()).Count != 0)
                titi = DataManager.Ps_scor_get_seuil_dossier(id_dossier.Trim())[0].ID_SCOR_SEUIL_DELEGUATION;
            else titi = 0;
            int ii = 1;
            var param = Session["code_banque"].ToString();
            var reponses = DataManager.ListeDecSpecif2(0, titi, "", param);
            foreach (var reponse in reponses)
            {

                var ListeUtilisateurDec = DataManager.ListeUtilisateurDec(reponse.ID_SCOR_DELEGATION, param);
                if (ListeUtilisateurDec.Count != 0)
                {
                    foreach (var uti in ListeUtilisateurDec)
                    {
                        if (ii == 1)
                        {
                            adress = uti.EMAIL_USER;
                        }
                        else
                        {
                            if (reponses.Count == ii) adressCopie += uti.EMAIL_USER ;
                            else
                            adressCopie += uti.EMAIL_USER +";";
                        }

                        delegataire += "" + uti.NOM_USER.ToUpper() + " " + uti.PRENOM_USER.ToUpper() + "; ";
                        ii++;
                    }
                }

            }
            if (adressCopie == "") arr1[0] = null;
            else
            arr1[0] = adressCopie;


            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Bonjour Monsieur, <br/>");
            sb.AppendLine(string.Format("Le dossier de notation de l'entreprise  <b>{0} </b> est en attente de décision.<br/>", NomContrepartie));
            sb.AppendLine(string.Format("Délégataire (s)  : <b> {0}</b><br/>", delegataire));
            sb.AppendLine(string.Format("Proposé par : <b>{0}</b>  <br/>", NomPropoNote));
            sb.AppendLine(string.Format("Date d'envoi :<b> {0} </b><br/>", DateEnvoi));
          
            string res = SendMail.SendMessage(ConfigurationManager.AppSettings["SmtpUsername"], "Scoring Center", adress, arr1, " Délégation dossier de notation " + NomContrepartie + " " + DateEnvoi, sb.ToString() + "\r\nCordialement \r\nScoring Center", null);
               
        }
        protected void EnvoyerVN_Click(object sender, EventArgs e)
        {
            if (DdlNPropose.Text != "" && TbNPropose.Text != "")
            {
                if (Session["id_user"] == null) Response.Redirect("~/Scoring/Connexion.aspx");

                service.PS_SCOR_SPY(Session["id_user"].ToString().Trim(), "ValidationNote", connmou007.Value.ToString(), "I");
                var id_dossier = Session["id_dossier"].ToString();
                Session.Add("id_dossier", id_dossier);
                var id_user = Session["id_user"].ToString();
                Session.Add("id_user", id_user);
                service.ProposeNotesDossier(id_dossier, DdlNPropose.Text, id_user, TbNPropose.Text);
                if (SelectNotation.SelectedValue == "ADE") service.Adiredexpert(id_dossier);
                else service.offAdiredexpert(id_dossier);

                if (TbNPropose.Text.Trim() != "")
                    service.traiterCommentaire(2, id_user.Trim(), id_dossier.Trim(), "", "", TbNPropose.Text.Trim(), "", DateTime.Now);


                //Send Mail
                //string Destinataire = "";
                //var Listemail = service.AfficheAdresseMail(ScorCryptage.Decrypt(Session["code_banque"].ToString()));

                //if (Listemail.Count > 0)
                //{
                //    foreach (var l in Listemail)
                //    {
                //        if (l.PLAFOND_PROFIL > PlafondMaiil)
                //        {
                //            if (l.PLAFOND_PROFIL > dossierMail)
                //            {
                //                if (Destinataire == "")
                //                {
                //                    Destinataire = l.EMAIL_USER.Trim();
                //                }
                //                else
                //                {
                //                    Destinataire = Destinataire + ";" + l.EMAIL_USER.Trim();
                //                }

                //            }
                //        }

                //    }
                //    if (Session["nom_user"] == null) Response.Redirect("~/Scoring/Connexion.aspx");

                //    string NomPropoNote = Session["nom_user"].ToString();
                //    StringBuilder sb = new StringBuilder();
                //    sb.AppendLine("<i>Vous avez recu un nouveau message.</i><br/>");
                //    sb.AppendLine(string.Format("<b>Auteur:</b> {0}<br/>", NomPropoNote));
                //    sb.AppendLine(string.Format("<b>Contrepartie étudie:</b> {0}<br/>", NClient.Text));
                //    sb.AppendLine(string.Format("<b>Note proposée:</b>  {0}<br/>", DdlNPropose.Text));
                //    sb.AppendLine(string.Format("<b>Commentaire:</b> {0}<br/>", TbNPropose.Text));


                //    MailMessage msg = new MailMessage();

                //    var DestiMail = Destinataire.ToString().Split(';');


                //    string delegataire = "";
                //    string DateEnvoi = "";

                //    foreach (string adress in DestiMail)
                //    {
                //        if (adress != null && adress.Trim() != "" && adress != " ")
                //        {
                //            msg.To.Add(new MailAddress(adress));

                //            //string res = SendMail.SendMessage(ConfigurationManager.AppSettings["SmtpUsername"], "Scoring Center", adress, null, " Délégation dossier de notation ABEL CIE 09/12/2019", "<p>Bonjour Monsieur,</p><pLe dossier de notation de l'entreprise ABEL CIE est en attente de décision.  </p><p>Délégataire (s)  : " + delegataire + " </p><p>Proposé par : " + NomPropoNote + " </p><p>Date d'envoi : " + DateEnvoi + " </p>", null);
                          
                //        }
                //        //mail.To.Add(adress);
                //    }
                //    //msg.To = Destinataire;
                //    //msg.To =;
                //    msg.Subject = "Scoring Center: Nouveau Message..";
                //    msg.Body = sb.ToString();
                //    msg.IsBodyHtml = true;
                //    bool success = false;
                //    int count = 0;
                try
                {
                    envoyerMail(ETCIV_NOMREDUIT);
                }
                catch (Exception ex)
                {
                    //OpenShowPasvalideConsult("Alerte", "La note a été proposé mais le mail n'a pas été envoyé. Faute de connexion !!!");
                }
                

                Response.Redirect("~/Scoring/HistoriqueNotation.aspx");

                // Page_Init(sender, e);
            }
            else
            {
                if (DdlNPropose.Text.Trim() != NICalculee.Text.Trim())
                {
                    if (SelectNotation.SelectedValue == "ADE")
                        OpenShowPasvalideConsult("", "Vous devez argumenter le choix de la note.");
                    else
                        OpenShowPasvalideConsult("", "L’écart entre la note calculée et la note proposée doit être justifié dans la zone commentaire.");

                }
                else
                {
                    if (Session["id_user"] == null) Response.Redirect("~/Scoring/Connexion.aspx");

                    service.PS_SCOR_SPY(Session["id_user"].ToString().Trim(), "ValidationNote", connmou007.Value.ToString(), "I");
                    var id_dossier = Session["id_dossier"].ToString();
                    Session.Add("id_dossier", id_dossier);
                    var id_user = Session["id_user"].ToString();
                    Session.Add("id_user", id_user);
                    service.ProposeNotesDossier(id_dossier, DdlNPropose.Text, id_user, TbNPropose.Text);
                    if (SelectNotation.SelectedValue == "ADE") service.Adiredexpert(id_dossier);
                    else service.offAdiredexpert(id_dossier);

                    if (TbNPropose.Text.Trim() != "")
                        service.traiterCommentaire(2, id_user.Trim(), id_dossier.Trim(), "", "", TbNPropose.Text.Trim(), "", DateTime.Now);


                    //Send Mail
                    //string Destinataire = "";
                    //var Listemail = service.AfficheAdresseMail(ScorCryptage.Decrypt(Session["code_banque"].ToString()));

                    //if (Listemail.Count > 0)
                    //{
                    //    foreach (var l in Listemail)
                    //    {
                    //        if (l.PLAFOND_PROFIL > PlafondMaiil)
                    //        {
                    //            if (l.PLAFOND_PROFIL > dossierMail)
                    //            {
                    //                if (Destinataire == "")
                    //                {
                    //                    Destinataire = l.EMAIL_USER.Trim();
                    //                }
                    //                else
                    //                {
                    //                    Destinataire = Destinataire + ";" + l.EMAIL_USER.Trim();
                    //                }

                    //            }
                    //        }

                    //    }
                    //    if (Session["nom_user"] == null) Response.Redirect("~/Scoring/Connexion.aspx");

                    //    string NomPropoNote = Session["nom_user"].ToString();
                    //    StringBuilder sb = new StringBuilder();
                    //    sb.AppendLine("<i>Vous avez recu un nouveau message.</i><br/>");
                    //    sb.AppendLine(string.Format("<b>Auteur:</b> {0}<br/>", NomPropoNote));
                    //    sb.AppendLine(string.Format("<b>Contrepartie étudie:</b> {0}<br/>", NClient.Text));
                    //    sb.AppendLine(string.Format("<b>Note proposée:</b>  {0}<br/>", DdlNPropose.Text));
                    //    sb.AppendLine(string.Format("<b>Commentaire:</b> {0}<br/>", TbNPropose.Text));


                    //    MailMessage msg = new MailMessage();

                    //    var DestiMail = Destinataire.ToString().Split(';');

                    //    foreach (string adress in DestiMail)
                    //    {
                    //        if (adress != null && adress.Trim() != "" && adress != " ")
                    //        {
                    //            msg.To.Add(new MailAddress(adress));
                    //        }
                    //        //mail.To.Add(adress);
                    //    }
                    //    //msg.To = Destinataire;
                    //    //msg.To =;
                    //    msg.Subject = "Scoring Center: Nouveau Message..";
                    //    msg.Body = sb.ToString();
                    //    msg.IsBodyHtml = true;
                    //    bool success = false;
                    //    int count = 0;
                    //    try
                    //    {
                    //        SendMail.EnvoyerMail(msg);
                    //    }
                    //    catch (Exception ex)
                    //    {
                    //        //OpenShowPasvalideConsult("Alerte", "La note a été proposé mais le mail n'a pas été envoyé. Faute de connexion !!!");
                    //    }
                    //}


                    try
                    {
                        envoyerMail(ETCIV_NOMREDUIT);
                    }
                    catch (Exception ex)
                    {
                        //OpenShowPasvalideConsult("Alerte", "La note a été proposé mais le mail n'a pas été envoyé. Faute de connexion !!!");
                    }
                
                    Response.Redirect("~/Scoring/HistoriqueNotation.aspx");

                    // Page_Init(sender, e);
                }
            }




        }

        public class comboNoteADE
        {
            public string NoteId { get; set; }
            public string NoteHtml { get; set; }
        }
        [WebMethod(EnableSession = true)]
        public static List<comboNoteADE> remplirConNADE()
        {
            List<comboNoteADE> lst = new List<comboNoteADE>();
            string[] res = new string[1];
            StringBuilder noteEnsemble = new StringBuilder();
            lst.Add(new comboNoteADE() { NoteId = " ", NoteHtml = "" });
            lst.Add(new comboNoteADE() { NoteId = "A+", NoteHtml = "A+" });
            lst.Add(new comboNoteADE() { NoteId = "A", NoteHtml = "A" });
            lst.Add(new comboNoteADE() { NoteId = "A-", NoteHtml = "A-" });

            lst.Add(new comboNoteADE() { NoteId = "B+", NoteHtml = "B+" });
            lst.Add(new comboNoteADE() { NoteId = "B", NoteHtml = "B" });
            lst.Add(new comboNoteADE() { NoteId = "B-", NoteHtml = "B-" });

            lst.Add(new comboNoteADE() { NoteId = "C+", NoteHtml = "C+" });
            lst.Add(new comboNoteADE() { NoteId = "C", NoteHtml = "C" });
            lst.Add(new comboNoteADE() { NoteId = "C-", NoteHtml = "C-" });

            lst.Add(new comboNoteADE() { NoteId = "D+", NoteHtml = "D+" });
            lst.Add(new comboNoteADE() { NoteId = "D", NoteHtml = "D" });
            lst.Add(new comboNoteADE() { NoteId = "D-", NoteHtml = "D-" });
            return lst;
        }



        public void remplirCon(string val)
        {
            DdlNPropose.Items.Clear();
            DdlNValidRejet.Items.Clear();
            if (val == "A+")
            {
                DdlNPropose.Items.Add(new ListItem(""));
                DdlNPropose.Items.Add(new ListItem("A+"));
                DdlNPropose.Items.Add(new ListItem("A"));
                DdlNPropose.Items.Add(new ListItem("A-"));
                DdlNValidRejet.Items.Add(new ListItem("A+"));
                DdlNValidRejet.Items.Add(new ListItem("A"));
                DdlNValidRejet.Items.Add(new ListItem("A-"));
            }
            if (val == "A")
            {
                DdlNPropose.Items.Add(new ListItem(""));
                DdlNPropose.Items.Add(new ListItem("A+"));
                DdlNPropose.Items.Add(new ListItem("A"));
                DdlNPropose.Items.Add(new ListItem("A-"));
                DdlNPropose.Items.Add(new ListItem("B+"));
                DdlNValidRejet.Items.Add(new ListItem("A+"));
                DdlNValidRejet.Items.Add(new ListItem("A"));
                DdlNValidRejet.Items.Add(new ListItem("A-"));
                DdlNValidRejet.Items.Add(new ListItem("B+"));
            }
            if (val == "A-")
            {
                DdlNPropose.Items.Add(new ListItem(""));
                DdlNPropose.Items.Add(new ListItem("A+"));
                DdlNPropose.Items.Add(new ListItem("A"));
                DdlNPropose.Items.Add(new ListItem("A-"));
                DdlNPropose.Items.Add(new ListItem("B+"));
                DdlNPropose.Items.Add(new ListItem("B"));
                DdlNValidRejet.Items.Add(new ListItem(""));
                DdlNValidRejet.Items.Add(new ListItem("A+"));
                DdlNValidRejet.Items.Add(new ListItem("A"));
                DdlNValidRejet.Items.Add(new ListItem("A-"));
                DdlNValidRejet.Items.Add(new ListItem("B+"));
                DdlNValidRejet.Items.Add(new ListItem("B"));
            }
            if (val == "B+")
            {
                DdlNPropose.Items.Add(new ListItem(""));
                DdlNPropose.Items.Add(new ListItem("A"));
                DdlNPropose.Items.Add(new ListItem("A-"));
                DdlNPropose.Items.Add(new ListItem("B+"));
                DdlNPropose.Items.Add(new ListItem("B"));
                DdlNPropose.Items.Add(new ListItem("B-"));
                DdlNValidRejet.Items.Add(new ListItem(""));
                DdlNValidRejet.Items.Add(new ListItem("A"));
                DdlNValidRejet.Items.Add(new ListItem("A-"));
                DdlNValidRejet.Items.Add(new ListItem("B+"));
                DdlNValidRejet.Items.Add(new ListItem("B"));
                DdlNValidRejet.Items.Add(new ListItem("B-"));
            }
            if (val == "B")
            {
                DdlNPropose.Items.Add(new ListItem(""));
                DdlNPropose.Items.Add(new ListItem("A-"));
                DdlNPropose.Items.Add(new ListItem("B+"));
                DdlNPropose.Items.Add(new ListItem("B"));
                DdlNPropose.Items.Add(new ListItem("B-"));
                DdlNPropose.Items.Add(new ListItem("C+"));
                DdlNValidRejet.Items.Add(new ListItem(""));
                DdlNValidRejet.Items.Add(new ListItem("A-"));
                DdlNValidRejet.Items.Add(new ListItem("B+"));
                DdlNValidRejet.Items.Add(new ListItem("B"));
                DdlNValidRejet.Items.Add(new ListItem("B-"));
                DdlNValidRejet.Items.Add(new ListItem("C+"));
            }
            if (val == "B-")
            {
                DdlNPropose.Items.Add(new ListItem(""));
                DdlNPropose.Items.Add(new ListItem("B+"));
                DdlNPropose.Items.Add(new ListItem("B"));
                DdlNPropose.Items.Add(new ListItem("B-"));
                DdlNPropose.Items.Add(new ListItem("C+"));
                DdlNPropose.Items.Add(new ListItem("C"));
                DdlNValidRejet.Items.Add(new ListItem(""));
                DdlNValidRejet.Items.Add(new ListItem("B+"));
                DdlNValidRejet.Items.Add(new ListItem("B"));
                DdlNValidRejet.Items.Add(new ListItem("B-"));
                DdlNValidRejet.Items.Add(new ListItem("C+"));
                DdlNValidRejet.Items.Add(new ListItem("C"));
            }
            if (val == "C+")
            {
                DdlNPropose.Items.Add(new ListItem(""));
                DdlNPropose.Items.Add(new ListItem("B"));
                DdlNPropose.Items.Add(new ListItem("B-"));
                DdlNPropose.Items.Add(new ListItem("C+"));
                DdlNPropose.Items.Add(new ListItem("C"));
                DdlNPropose.Items.Add(new ListItem("C-"));
                DdlNValidRejet.Items.Add(new ListItem(""));
                DdlNValidRejet.Items.Add(new ListItem("B"));
                DdlNValidRejet.Items.Add(new ListItem("B-"));
                DdlNValidRejet.Items.Add(new ListItem("C+"));
                DdlNValidRejet.Items.Add(new ListItem("C"));
                DdlNValidRejet.Items.Add(new ListItem("C-"));
            }
            if (val == "C")
            {
                DdlNPropose.Items.Add(new ListItem(""));
                DdlNPropose.Items.Add(new ListItem("B-"));
                DdlNPropose.Items.Add(new ListItem("C+"));
                DdlNPropose.Items.Add(new ListItem("C"));
                DdlNPropose.Items.Add(new ListItem("C-"));
                DdlNPropose.Items.Add(new ListItem("D"));
                DdlNValidRejet.Items.Add(new ListItem(""));
                DdlNValidRejet.Items.Add(new ListItem("B-"));
                DdlNValidRejet.Items.Add(new ListItem("C+"));
                DdlNValidRejet.Items.Add(new ListItem("C"));
                DdlNValidRejet.Items.Add(new ListItem("C-"));
                DdlNValidRejet.Items.Add(new ListItem("D"));
            }
            if (val == "C-")
            {
                DdlNPropose.Items.Add(new ListItem(""));
                DdlNPropose.Items.Add(new ListItem("C+"));
                DdlNPropose.Items.Add(new ListItem("C"));
                DdlNPropose.Items.Add(new ListItem("C-"));
                DdlNPropose.Items.Add(new ListItem("D"));
                DdlNValidRejet.Items.Add(new ListItem(""));
                DdlNValidRejet.Items.Add(new ListItem("C+"));
                DdlNValidRejet.Items.Add(new ListItem("C"));
                DdlNValidRejet.Items.Add(new ListItem("C-"));
                DdlNValidRejet.Items.Add(new ListItem("D"));
            }
            if (val == "D")
            {
                DdlNPropose.Items.Add(new ListItem(""));
                DdlNPropose.Items.Add(new ListItem("C"));
                DdlNPropose.Items.Add(new ListItem("C-"));
                DdlNPropose.Items.Add(new ListItem("D"));
                DdlNValidRejet.Items.Add(new ListItem(""));
                DdlNValidRejet.Items.Add(new ListItem("C"));
                DdlNValidRejet.Items.Add(new ListItem("C-"));
                DdlNValidRejet.Items.Add(new ListItem("D"));

            }
        }

        public void AfficherInfoDossier()
        {
            if (Session["id_dossier"] == null) Response.Redirect("~/Scoring/Connexion.aspx");

            var id_dossier = Session["id_dossier"].ToString();
            // var id_scoring = Session["id_scoring"].ToString();
            Session.Add("id_dossier", id_dossier);
            // Session.Add("id_scoring", id_scoring);

            /*Modèle de notation*/
            LblModeleNotation.Text = "Modèle de notation : " + AnalyseFinanciere.getModeleNotation(id_dossier);
            if (AnalyseFinanciere.getADireExpert(id_dossier)) LblADireExpert.Text = "A dire d'expert : OUI";
            else LblADireExpert.Text = "A dire d'expert : NON";


            var DetailNotes = service.DetailsNotesDossier(id_dossier);
            var AfficherCommProposer = service.AfficherCommProposer(id_dossier);

            if (AfficherCommProposer.Count != 0)
            {
                foreach (var Notes in AfficherCommProposer)
                {
                    TbNPropose.Text = Notes.COMMENTAIRE_PROP;
                    //TbNValidRejet.Text = Notes.COMMENTAIRE_PROP;
                }
            }

            if (DetailNotes.Count != 0)
            {
                foreach (var Notes in DetailNotes)
                {
                    string groupe = "";
                    string pays = "";
                    string fananciere = "";
                    string qualitative = "";
                    int i = 0;
                    if (Notes.NOTE_GROUPE.Trim() == "" || Notes.NOTE_GROUPE.Trim() == null)
                    {
                        groupe = "NC";
                    }
                    else
                    {
                        groupe = Notes.NOTE_GROUPE;
                    }
                    if (Notes.NOTE_PAYS.Trim() == "" || Notes.NOTE_PAYS.Trim() == null)
                    {
                        pays = "NC";
                    }
                    else
                    {
                        pays = Notes.NOTE_PAYS;
                    }

                    if (Notes.NOTE_AF.Trim() == "" || Notes.NOTE_AF.Trim() == null)
                    {
                        fananciere = "NC";
                        i = 1;
                    }
                    else
                    {
                        fananciere = Notes.NOTE_AF;
                    }

                    if (Notes.NOTE_AQ.Trim() == "" || Notes.NOTE_AQ.Trim() == null)
                    {
                        qualitative = "NC";
                        i = 2;
                    }
                    else
                    {
                        qualitative = Notes.NOTE_AQ;
                    }


                    /*  if (Notes.NOTE_SYN.Trim() == "" || Notes.NOTE_SYN.Trim() == null)
                      {
                          Label1Calc.Text = "NC";
                          remplirCon("");
                      }
                      else
                      {
                          Label1Calc.Text = Notes.NOTE_SYN;
                          remplirCon(NICalculee.Text.Trim());
                      }*/


                    if (string.IsNullOrEmpty(Notes.NOTE_OP) || Notes.NOTE_SYN.Trim() == "")
                    {
                        NICalculee.Text = "NC";
                    }
                    else
                    {
                        NICalculee.Text = Notes.NOTE_OP;
                    }



                    if (i == 1)
                    {
                        Label1Calc.Text = Notes.NOTE_AQ;
                        //NICalculee.Text = Notes.NOTE_OP;
                        ADE_ServerChange();

                        if (NICalculee.Text != "NC")
                        {
                            CHMPADE.InnerHtml = "<h3><b class='text-danger'>A dire d'expert</b></h3>";
                            //ADE_ServerChange();
                            //ADE.Checked = true;
                            //SelectNotation.Items.FindByValue("ADE").Selected = true;
                            SelectNotation.SelectedValue = "ADE";
                        }


                     
                    }
                    else
                    {
                        if (i == 0)
                        {
                            Label1Calc.Text = Notes.NOTE_SYN;
                            //NICalculee.Text = Notes.NOTE_OP;
                            remplirCon(NICalculee.Text.Trim());
                     
                            //remplirCon(NICalculee.Text.Trim());
                        }
                        else
                        {
                            Label1Calc.Text = "NC";
                            //NICalculee.Text = "NC";
                            remplirCon("");
                        }

                    }


                    /*    if (i == 0)
                      {
                          Label1Calc.Text = Notes.NOTE_SYN;
                          NICalculee.Text = Notes.NOTE_OP;
                          remplirCon(NICalculee.Text.Trim());
                      }
                      else
                     {
                          Label1Calc.Text = "NC";
                         NICalculee.Text = "NC";
                         remplirCon("");
                      }
                     */
                    NFinanciere.Text = fananciere;
                    NConsolide.Text = fananciere;

                    NQualitative.Text = qualitative;
                    NStructurelle.Text = qualitative;

                    NGroupe.Text = groupe;
                    RPays.Text = pays;


                    //NICalculee.Text = "";
                    //if (Notes.NOTE_AQ != "" && Notes.NOTE_AQ != null && Notes.NOTE_AF != "" && Notes.NOTE_AF != null)
                    //    NICalculee.Text = Notes.NOTE_SYN;
                    NoteProp.Text = Notes.NOTE_PROP;
                    VerifNoteProp.Text = NoteProp.Text.Trim();
                    //if (Notes.NOTE_VAL == "") DdlNValidRejet.Text = Notes.NOTE_PROP ; else DdlNValidRejet.Text = Notes.NOTE_VAL;

                    Page.ClientScript.RegisterStartupScript(GetType(), "alert", string.Format("positionMarker('{0}', '{1}'); positionMarker('{2}', '{3}');", Label1Calc.Text.Trim(), "contrep", NICalculee.Text.Trim(), "operat"), true);
                }
            }


            // ITERATION CHAPITRES

            var chapitres = service.ListeChapitre("ANAOPE");
            LabelOP1.Text = "";
            foreach (var chapitre in chapitres)
            {
                decimal xxx = 0;
                LabelOP1.Text = LabelOP1.Text.Trim() + " <p style=\"/*font-family: cursive; */font-size: 13px;\" class=\"text-left\"> " + chapitre.LIBELLE_CHAPITRE;
                var questions = service.ListeQuestion(chapitre.CODE_CHAPITRE);
                foreach (var question in questions)
                {
                    /////////////////////////////////////////////////////
                    var reponses = service.Listreponse(id_dossier, "N6");
                    foreach (var reponse in reponses)
                    {
                        if (reponse.ID_QUESTION != null)
                            if (reponse.ID_QUESTION.Trim() == question.ID_QUESTION.Trim())
                                xxx += reponse.NOTE_REPONSE;
                    }
                }
                LabelOP1.Text = LabelOP1.Text.Trim() + " " + xxx + " / " + chapitre.NOTE_CHAPITRE + " </p>";
            }

            //DELEGATION 
            AfficheDelegation();


        }

        public void AfficheDelegation()
        {
            //var chapitres = service.ListeChapitre("ANAOPE");
            LabelCont.Text = "";
            //foreach (var chapitre in chapitres)
            //{
            var xxx = "";
            var xcd = "";
            var zzz = "35";

            LabelCont.Text = LabelCont.Text.Trim() + "<p class='text-left' style='font-size: 13px;'><strong>" + "Organe de délégation :" + "</strong> </p> \n";
            //var questions = service.ListeQuestion(chapitre.CODE_CHAPITRE);
            //foreach (var question in questions)
            //{
            /////////////////////////////////////////////////////
            var titi = 0;
            var id_dossier = Session["id_dossier"].ToString();
            if (DataManager.Ps_scor_get_seuil_dossier(id_dossier.Trim()).Count != 0)
                titi = DataManager.Ps_scor_get_seuil_dossier(id_dossier.Trim())[0].ID_SCOR_SEUIL_DELEGUATION;
            else titi = 0;
            string code_banque = Session["code_banque"].ToString();
            var reponses = DataManager.ListeDecSpecif2(0, titi, "", code_banque);
            foreach (var reponse in reponses)
            {
                //if (reponse.ID_QUESTION != null)
                // if (reponse.ID_QUESTION.Trim() == question.ID_QUESTION.Trim())
                xxx += " " + reponse.LIBELLE_SCOR_DELEGATION + "; ";

                var ListeUtilisateurDec = DataManager.ListeUtilisateurDec(reponse.ID_SCOR_DELEGATION, code_banque);
                if (ListeUtilisateurDec.Count != 0)
                {
                    foreach (var uti in ListeUtilisateurDec)
                    {
                        xcd += "" + uti.NOM_USER.ToUpper()+ " "+uti.PRENOM_USER + "; ";
                    }
                }

            }

            //}
            LabelCont.Text = LabelCont.Text.Trim() + " <p class='text-left' style='font-size: 13px;'> " + xxx + " </p>";
            LabelCont.Text = LabelCont.Text.Trim() + "<p class='text-left' style='font-size: 13px;'><strong>" + "Délégataire (s) :" + "</strong> </p> \n";
            LabelCont.Text = LabelCont.Text.Trim() + " <p class='text-left' style='font-size: 13px;'> " + xcd + " </p>";
            LabelCont.Text = LabelCont.Text.Trim() + "<div class='row text-left' style='font-size: 13px;'>" +
                "<div class='col-xs-8' style=''>" +
		            "<strong>Taux de LGD associé<br> à la contrepartie :  " + zzz + "% </strong>" +
	            "</div>" +
                "<div class='col-xs-4' style='margin-top:5%; padding-left:0%;'>" +
                    "<div style='background:url(../Images/img_livre.png) no-repeat; height:25px; width:30px;'></div>" +
                "</div>" +
            "</div> \n";
            //}
        }

        //AccordRejet
        //
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static void AccordRejet(string text)
        {
            //var id_dossier = Session["id_dossier"].ToString();
            Scoringws service = new Scoringws();
            service.Modif_note(text);
        }

        public void AccRejet()
        {
            if (Session["id_user"] == null) Response.Redirect("~/Scoring/Connexion.aspx");

            var id_user = Session["id_user"].ToString();
            Session.Add("id_user", id_user);
            var id_dossier = Session["id_dossier"].ToString();
            Scoringws service = new Scoringws();
            service.RejetNotesDossier(id_dossier, id_user, TbNValidRejet.Text);
            if (SelectNotation.SelectedValue == "ADE") service.Adiredexpert(id_dossier);

            if (TbNValidRejet.Text.Trim() != "")
            {
                //if(ADE.Checked==true)
                //    service.traiterCommentaire(2, id_user.Trim(), id_dossier.Trim(), "", "A dire d'expert", TbNValidRejet.Text.Trim(), "", DateTime.Now);
                //else
                service.traiterCommentaire(2, id_user.Trim(), id_dossier.Trim(), "", "A dire d'expert", TbNValidRejet.Text.Trim(), "", DateTime.Now);
            }

        }

        protected void RejeterVN_ServerClick(object sender, EventArgs e)
        {
            if (Session["id_user"] == null) Response.Redirect("~/Scoring/Connexion.aspx");

            service.PS_SCOR_SPY(Session["id_user"].ToString().Trim(), "ValidationNote", connmou007.Value.ToString(), "I");
            AccRejet();
            Response.Redirect("~/Scoring/HistoriqueNotation.aspx");
        }
        protected void ADE_ServerChange()
        {
            DdlNPropose.Items.Clear();
            DdlNPropose.Items.Add(new ListItem(""));
            DdlNPropose.Items.Add(new ListItem("A+"));
            DdlNPropose.Items.Add(new ListItem("A"));
            DdlNPropose.Items.Add(new ListItem("A-"));
            DdlNPropose.Items.Add(new ListItem("B+"));
            DdlNPropose.Items.Add(new ListItem("B"));
            DdlNPropose.Items.Add(new ListItem("B-"));
            DdlNPropose.Items.Add(new ListItem("C+"));
            DdlNPropose.Items.Add(new ListItem("C"));
            DdlNPropose.Items.Add(new ListItem("C-"));
            DdlNPropose.Items.Add(new ListItem("D+"));
            DdlNPropose.Items.Add(new ListItem("D"));
            DdlNPropose.Items.Add(new ListItem("D-"));

            DdlNValidRejet.Items.Clear();
            DdlNValidRejet.Items.Add(new ListItem(""));
            DdlNValidRejet.Items.Add(new ListItem("A+"));
            DdlNValidRejet.Items.Add(new ListItem("A"));
            DdlNValidRejet.Items.Add(new ListItem("A-"));
            DdlNValidRejet.Items.Add(new ListItem("B+"));
            DdlNValidRejet.Items.Add(new ListItem("B"));
            DdlNValidRejet.Items.Add(new ListItem("B-"));
            DdlNValidRejet.Items.Add(new ListItem("C+"));
            DdlNValidRejet.Items.Add(new ListItem("C"));
            DdlNValidRejet.Items.Add(new ListItem("C-"));
            DdlNValidRejet.Items.Add(new ListItem("D+"));
            DdlNValidRejet.Items.Add(new ListItem("D"));
            DdlNValidRejet.Items.Add(new ListItem("D-"));
        }

        protected void SelectNotation_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SelectNotation.SelectedValue == "ADE") ADE_ServerChange();
            else
            {
                AfficherInfoDossier();
            }
        }
        //protected void ADE_ServerChange(object sender, EventArgs e)
        //{
        //    if (SelectNotation.SelectedValue=="ade")
        //    {
        //        DdlNPropose.Items.Clear();
        //        DdlNPropose.Items.Add(new ListItem(""));
        //        DdlNPropose.Items.Add(new ListItem("A+"));
        //        DdlNPropose.Items.Add(new ListItem("A"));
        //        DdlNPropose.Items.Add(new ListItem("A-"));
        //        DdlNPropose.Items.Add(new ListItem("B+"));
        //        DdlNPropose.Items.Add(new ListItem("B"));
        //        DdlNPropose.Items.Add(new ListItem("B-"));
        //        DdlNPropose.Items.Add(new ListItem("C+"));
        //        DdlNPropose.Items.Add(new ListItem("C"));
        //        DdlNPropose.Items.Add(new ListItem("C-"));
        //        DdlNPropose.Items.Add(new ListItem("D+"));
        //        DdlNPropose.Items.Add(new ListItem("D"));
        //        DdlNPropose.Items.Add(new ListItem("D-"));

        //        DdlNValidRejet.Items.Clear();
        //        DdlNValidRejet.Items.Add(new ListItem(""));
        //        DdlNValidRejet.Items.Add(new ListItem("A+"));
        //        DdlNValidRejet.Items.Add(new ListItem("A"));
        //        DdlNValidRejet.Items.Add(new ListItem("A-"));
        //        DdlNValidRejet.Items.Add(new ListItem("B+"));
        //        DdlNValidRejet.Items.Add(new ListItem("B"));
        //        DdlNValidRejet.Items.Add(new ListItem("B-"));
        //        DdlNValidRejet.Items.Add(new ListItem("C+"));
        //        DdlNValidRejet.Items.Add(new ListItem("C"));
        //        DdlNValidRejet.Items.Add(new ListItem("C-"));
        //        DdlNValidRejet.Items.Add(new ListItem("D+"));
        //        DdlNValidRejet.Items.Add(new ListItem("D"));
        //        DdlNValidRejet.Items.Add(new ListItem("D-"));
        //    }
        //    else
        //    {
        //        DdlNPropose.Items.Clear();
        //        DdlNValidRejet.Items.Clear();
        //    }
        //}
    }
}