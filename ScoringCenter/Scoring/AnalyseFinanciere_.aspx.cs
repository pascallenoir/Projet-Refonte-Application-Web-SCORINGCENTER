using ScoringCenter.Scoring;
using ScoringCenter.ScorManager;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ScoringCenter
{
    public partial class AnalyseFinanciere : System.Web.UI.Page
    {
        /// <summary>
        /// bommm
        /// </summary>

        StringBuilder sb = new StringBuilder();
        static string Type_anafi;
        StringBuilder sbt = new StringBuilder();
        StringBuilder sbv = new StringBuilder();
        StringBuilder sbe = new StringBuilder();
        StringBuilder sba = new StringBuilder();

        Scoringws service = new Scoringws();
        NumberFormatInfo convertMoney = new NumberFormatInfo { NumberGroupSeparator = " ", NumberDecimalDigits = 0 };

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["id_scoring"] == null) Response.Redirect("~/Scoring/Connexion.aspx");
            //DataManager.RubANAFI = valeurtype.Text + "@" + DdlRubrique.Text;
            if (DataManager.RubANAFI != null)
            {
                if (DataManager.RubANAFI != "")
                {

                    var rub = DataManager.RubANAFI.Split('@');
                    valeurtype.Text = rub[0];
                    DdlRubrique.Text = rub[1];
                }
            }
            //aleatoir();
            ControllerPage();
            if (!IsPostBack)
            {
                if (DataManager.RubANAFI != null)
                {
                    if (DataManager.RubANAFI != "")
                    {
                        DataManager.RubANAFI = "";
                    }
                }
                affichebilan();
                affichecompteresultat();
                afficheBilanGrandeMasse();
                afficherRatio();
                afficheTableauSynthetique();
                afficheTDR();
                afficherAutreRatio();
                //if (valeurtype.Text == "Bilan Normal")
                //{
                //    affichebilan();
                //   //afficheBCompteResultatSA decommenter une fois seulement
                //   //// afficheTableauSynthetique();
                //   // afficheBilanGrandeMasse();
                //   // //afficheTDR();
                //   // //afficherRatio();
                //}
                //else
                //{
                //    if (valeurtype.Text == "Systeme Minimal De Tresorerie")
                //    {
                //        affichebilan();
                //        //afficheBCompteResultatSA decommenter une fois seulement
                //        //afficheBilanSMT();

                //    }
                //    else
                //    {

                //        //afficheBCompteResultatSA decommenter une fois seulement
                //        //afficheBilanSA();
                //    }
                //}
            }
            cachezafficher();
            vergroupe_pays();
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
            if (Session["login"] == null) Response.Redirect("~/Scoring/Connexion.aspx");
            else
            {
                var idprofil = Session["id_profil"].ToString();
                var elements = service.VHABILITATION(idprofil);
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
                    if (element.ID_DROIT.ToString().Trim() == "AF")
                    {
                        if (element.ID_TYPE_DROIT.ToString().Trim() != "0") AF.Visible = true;
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
                    if (element.ID_DROIT.ToString().Trim() == "AF")
                    {
                        // if (element.ID_TYPE_DROIT.ToString().Trim() != "0") AD.Visible = true;


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
            //IG.Visible = false;
            EBF.Visible = false; ////Fin_Controle////////////////////////////////////////////////////
        }

        private void getInfoDossier()
        {
            // Session.Add("id_dossier", "1");
            if (Session["id_dossier"] == null) Response.Redirect("~/Scoring/Connexion.aspx");
            var idDossier = Session["id_dossier"].ToString();
            Session.Add("id_dossier", idDossier);

            var elements = service.InfoDossier(idDossier);
            foreach (var dossier in elements)
            {
                //ModeleNotation.Text = dossier.LIBELLE_MODELE;
                NoteF.Text = dossier.NOTE_AF;
                //idModele = dossier.MODELE_DOSSIER;
            }
        }

        public void getInfoClient()
        {
            if (string.IsNullOrEmpty(Request.QueryString["id"]))
            {
                if (Session["id_scoring"] == null) Response.Redirect("~/Scoring/Connexion.aspx");

                if (string.IsNullOrEmpty(Session["id_scoring"].ToString()))
                    Response.Redirect("AutreDossier.aspx");
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
                        NClient.Text = v.ETCIV_NOMREDUIT;
                        //Idprincip.Text = v.ID_SCORING;
                        CodeAPE.Text = v.RCCM;
                        //AEntreprise.Text = v.SECTACT_LIBELLE;
                        SaiTypeClient.Text = v.TYPE_PROSPECT;
                        IdScoringCenter.Text = v.ID_SCORING;

                        Siren.Text = v.ACTBCEAO_LIBELLE;
                        Devise.Text = v.DEVISE;
                        ChiffreAffaire.Text = Convert.ToString(string.Format("{0:#,##0}", v.CA));
                        id_dossier = v.ID_DOSSIER;
                        SystemeList.Value = v.TYPE_ANAFI.Trim();
                        valeurtype.Text = v.TYPE_ANAFI.Trim();
                        if (v.GROUPE_DOSSIER != "") { }
                        else { IG.Visible = false; }
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
                    //Idprincip.Text = v.ID_SCORING;
                    CodeAPE.Text = v.RCCM;
                    //AEntreprise.Text = v.SECTACT_LIBELLE;
                    SaiTypeClient.Text = v.TYPE_PROSPECT;
                    IdScoringCenter.Text = v.ID_SCORING;
                    Siren.Text = v.ACTBCEAO_LIBELLE;
                    Devise.Text = v.DEVISE;
                    ChiffreAffaire.Text = v.CA.ToString();
                    id_dossier = v.ID_DOSSIER;
                    SystemeList.Value = v.TYPE_ANAFI.Trim();
                    valeurtype.Text = v.TYPE_ANAFI.Trim();

                    if (v.GROUPE_DOSSIER != "") { }
                    else { IG.Visible = false; }
                }
                Session.Add("id_dossier", id_dossier);
            }
        }

        public void cachezafficher()
        {
            //if (DdlRubrique.Text != "Tableau des scores")
            //    affnote.Visible = false;
            //else
            //    affnote.Visible = true;

            if (DdlRubrique.Text == "Bilan")
            {

                btnRefreshBil.Visible = true;
                btnModifBil.Visible = true;
                BtnEnregistrer.Visible = true;
                SuppLiasseBtn.Visible = true;
            }
            else
            {
                if (DdlRubrique.Text == "Compte de résultat")
                {
                    btnRefreshBil.Visible = true;
                    btnModifBil.Visible = true;
                    BtnEnregistrer.Visible = true;
                    SuppLiasseBtn.Visible = true;
                }
                else
                {
                    btnRefreshBil.Visible = false;
                    btnModifBil.Visible = false;
                    BtnEnregistrer.Visible = false;
                    SuppLiasseBtn.Visible = false;

                }
            }

        }

        protected void Page_Init(object sender, EventArgs e)
        {
            getInfoDossier();
            getInfoClient();
            cachezafficher();

        }

        protected void Systeme_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataManager.RubANAFI = "";
            affichebilan();
            affichecompteresultat();
            afficheBilanGrandeMasse();
            afficherRatio();
            afficheTableauSynthetique();
            afficheTDR();
            afficherAutreRatio();
        }

        protected void DdlRubrique_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataManager.RubANAFI = "";

            affichebilan();
            affichecompteresultat();
            afficheBilanGrandeMasse();
            afficherRatio();
            afficheTableauSynthetique();
            afficheTDR();
            afficherAutreRatio();

        }

        public void affichebilan()
        {
            //*********************************************************afficher le bilan Bilan Normal*****************************************************************************
            if (valeurtype.Text == "Bilan Normal")
            {
                afficheBilanBN();

            }
            else
            {
                //***************************************************afficher le bilan Systeme Minimal De Tresorerie***********************************************************************
                //valeurtype.Text = "Bilan Normal";
                //OpenShowPasvalideConsult("Information", "Ce module n'est pas disponible pour cette version . veuillez contacter votre fournisseur <br/> <a href='https://www.google.com'> Le lien fournisseur</a>");

                if (valeurtype.Text == "Systeme Minimal De Tresorerie")
                {
                    afficheBilanSMT();
                }
                //************************************************************afficher le bilan systeme allégee**********************************************************************
                else
                {
                    afficheBilanSA();
                }
            }

        }

        public void affichecompteresultat()
        {
            //*********************************************************afficher le bilan  Normal*****************************************************************************
            if (valeurtype.Text == "Bilan Normal")
            {
                affichecompteresultatBN();
            }
            else
            {
                //***************************************************afficher le bilan Systeme Minimal De Tresorerie***********************************************************************
                //valeurtype.Text = "Bilan Normal";
                //OpenShowPasvalideConsult("Information", "Ce module n'est pas disponible pour cette version . veuillez contacter votre fournisseur <br/> <a href='https://www.google.com'> Le lien fournisseur</a>");


                if (valeurtype.Text == "Systeme Minimal De Tresorerie")
                {

                    afficheBCompteResultatSMT();
                }
                //************************************************************afficher le bilan systeme allégee**********************************************************************
                else
                {
                    afficheBCompteResultatSA();
                }
            }

        }

        public void afficheBilanGrandeMasse()
        {
            //*********************************************************afficher le bilan Bilan Normal*****************************************************************************
            if (valeurtype.Text == "Bilan Normal")
            {
                afficheBilanGrandeMasseBN();

            }
            else
            {
                //***************************************************afficher le bilan Systeme Minimal De Tresorerie***********************************************************************
                //valeurtype.Text = "Bilan Normal";
                //OpenShowPasvalideConsult("Information", "Ce module n'est pas disponible pour cette version . veuillez contacter votre fournisseur <br/> <a href='https://www.google.com'> Le lien fournisseur</a>");


                if (valeurtype.Text == "Systeme Minimal De Tresorerie")
                {
                    afficheBilanGrandeMasseSMT();
                }
                //************************************************************afficher le bilan systeme allégee**********************************************************************
                else
                {
                    afficheBilanGrandeMasseSA();
                }
            }

        }

        public void afficheTableauSynthetique()
        {
            //*********************************************************afficher le bilan Bilan Normal*****************************************************************************
            if (valeurtype.Text == "Bilan Normal")
            {
                afficheTableauSynthetiqueBN();

            }
            else
            {
                //***************************************************afficher le bilan Systeme Minimal De Tresorerie***********************************************************************
                //valeurtype.Text = "Bilan Normal";
                //OpenShowPasvalideConsult("Information", "Ce module n'est pas disponible pour cette version . veuillez contacter votre fournisseur <br/> <a href='https://www.google.com'> Le lien fournisseur</a>");


                if (valeurtype.Text == "Systeme Minimal De Tresorerie")
                {
                    afficheTableauSynthetiqueSMT();
                }
                //************************************************************afficher le bilan systeme allégee**********************************************************************
                else
                {
                    afficheTableauSynthetiqueSA();
                }
            }
        }

        public void afficheTDR()
        {
            //*********************************************************afficher le bilan Bilan Normal*****************************************************************************
            if (valeurtype.Text == "Bilan Normal")
            {
                afficheTDRBN();

            }
            else
            {
                //***************************************************afficher le bilan Systeme Minimal De Tresorerie***********************************************************************

                //valeurtype.Text = "Bilan Normal";
                //OpenShowPasvalideConsult("Information", "Ce module n'est pas disponible pour cette version . veuillez contacter votre fournisseur <br/> <a href='https://www.google.com'> Le lien fournisseur</a>");

                if (valeurtype.Text == "Systeme Minimal De Tresorerie")
                {
                    afficheTDRSMT();
                }
                //************************************************************afficher le bilan systeme allégee**********************************************************************
                else
                {
                    afficheTDRSA();
                }
            }
        }

        public void afficherRatio()
        {
            //*********************************************************afficher le bilan Bilan Normal*****************************************************************************
            if (valeurtype.Text == "Bilan Normal")
            {
                afficherRatioBN();

            }
            else
            {
                //***************************************************afficher le bilan Systeme Minimal De Tresorerie***********************************************************************

                //valeurtype.Text = "Bilan Normal";
                //OpenShowPasvalideConsult("Information", "Ce module n'est pas disponible pour cette version . veuillez contacter votre fournisseur <br/> <a href='https://www.google.com'> Le lien fournisseur</a>");

                if (valeurtype.Text == "Systeme Minimal De Tresorerie")
                {
                    afficherRatioSMT();
                }
                //************************************************************afficher le bilan systeme allégee**********************************************************************
                else
                {
                    afficherRatioSA();
                }
            }

        }

        public void afficherAutreRatio()
        {
            //*********************************************************afficher le bilan Bilan Normal*****************************************************************************
            if (valeurtype.Text == "Bilan Normal")
            {
                afficherAutreRatioBN();

            }
            else
            {
                //***************************************************afficher le bilan Systeme Minimal De Tresorerie***********************************************************************

                //valeurtype.Text = "Bilan Normal";
                //OpenShowPasvalideConsult("Information", "Ce module n'est pas disponible pour cette version . veuillez contacter votre fournisseur <br/> <a href='https://www.google.com'> Le lien fournisseur</a>");

                if (valeurtype.Text == "Systeme Minimal De Tresorerie")
                {
                    afficherRatioSMT();
                }
                //************************************************************afficher le bilan systeme allégee**********************************************************************
                else
                {
                    afficherRatioSA();
                }
            }

        }

        public void afficheBilanSMT()
        {
            //string[]  // TabLOTA = null;

            // TabLOTA = new string[] { String.Empty };

            // string[]  // TabLOTP = null;

            // TabLOTP = new string[] { String.Empty };
            if (Session["id_dossier"] == null) Response.Redirect("~/Scoring/Connexion.aspx");

            var idDossier = Session["id_dossier"].ToString();
            Session.Add("id_dossier", idDossier);
            if (DdlRubrique.Text == "Bilan")
            {
                Type_anafi = "BN";
                Div1.Visible = true;
                Div2.Visible = true;
                var liste_annee = service.AnafiAfficheLiasse(7, idDossier, "", "SMT");
                var nombre_annee = service.AnafiAfficheLiasse(8, idDossier, "", "SMT");

                if (liste_annee.Count != 0)
                {
                    sb.AppendLine("<div class='col-lg-6 col-sm-6 col-md-6' >");
                    sb.AppendLine("<table id='' class='table table-hover table-bordered text-center'>");
                    sb.AppendLine("<thead class='table-heigth'>");
                    sb.AppendLine(string.Format("<tr><th>Actifs</th>"));
                    if (liste_annee.Count > 3)
                    {
                        int j = 0;
                        int v = 0;
                        int i = 0;
                        v = Convert.ToInt32(liste_annee.Count) - 3;
                        foreach (var lr in liste_annee)
                        {
                            j++;
                            if (v < j)
                            {
                                if (i < Convert.ToInt32(liste_annee.Count))
                                {
                                    sb.AppendLine(string.Format("<th onclick='transfertval($(this))' width=20%>{0}</th>", lr.ANNEE_DETAIL));
                                    //TabLOT[i] = lr.ANNEE_DETAIL;
                                }
                            }

                            i++;
                        }
                    }
                    else
                    {
                        int i = 0;
                        foreach (var lr in liste_annee)
                        {

                            if (i < Convert.ToInt32(liste_annee.Count))
                            {
                                sb.AppendLine(string.Format("<th onclick='transfertval($(this))' width=20%>{0}</th>", lr.ANNEE_DETAIL));
                                //TabLOT[i] = lr.ANNEE_DETAIL;
                            }
                            i++;
                        }
                    }


                    sb.AppendLine("</thead>");
                    sb.AppendLine("<tbody>");

                    var liste_libelle = service.AnafiAfficheLiasse(0, "", "", "BSM");

                    foreach (var lr in liste_libelle)
                    {
                        string SENS = "";
                        if (lr.RUBR_ETAT_CODE.Trim().Length > 2)
                        {
                            SENS = lr.RUBR_ETAT_CODE.ToString().Trim().Substring(0, 3);
                        }

                        if (SENS == "BA1" || SENS == "BA2" || SENS == "BA3" || SENS == "BA4")
                        {
                            if (lr.RUBR_ETAT_CODE.ToString().Trim().Length == 3)
                            {
                                sb.AppendLine(string.Format("<tr data_code='{0}' style='background-color:#ddd'>", lr.RUBR_ETAT_CODE.ToString().Trim()));
                                // sb.AppendLine(string.Format("<td class='text-left'>{0}</td>", lr.CODE_POSTE.ToString()));


                                if (lr.RUBR_ETAT_LIBELLE.Trim().Length <= 1)
                                {
                                    sb.AppendLine(string.Format("<td class='text-left' style='color:#fff'>{0}</td>", lr.RUBR_ETAT_LIBELLE.ToString()));
                                }
                                else
                                {
                                    sb.AppendLine(string.Format("<td class='text-left'>{0}</td>", lr.RUBR_ETAT_LIBELLE.ToString()));
                                }
                                var liste_valeur1 = service.AnafiAfficheLiasse(1, idDossier, lr.RUBR_ETAT_CODE.ToString().Trim(), "SMT");
                                int j = 0;
                                int v = 0;
                                v = Convert.ToInt32(liste_valeur1.Count) - 3;
                                foreach (var l in liste_valeur1)
                                {

                                    if (liste_valeur1.Count > 3)
                                    {
                                        j++;
                                        if (v < j)
                                        {
                                            if (l.RUBR_ETAT_LIBELLE.Trim().Length <= 1)
                                            {
                                                sb.AppendLine(string.Format("<td class='text-right'></td>"));
                                            }
                                            else
                                            {
                                                sb.AppendLine(string.Format("<td class='text-right {1}'>{0}</td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_B_DETAIL)), l.ANNEE_B_DETAIL.Replace("/", "")));
                                            }
                                        }

                                    }
                                    else
                                    {
                                        if (l.RUBR_ETAT_LIBELLE.Trim().Length <= 1)
                                        {
                                            sb.AppendLine(string.Format("<td class='text-right'></td>"));
                                        }
                                        else
                                        {
                                            sb.AppendLine(string.Format("<td class='text-right {1}'>{0}</td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_B_DETAIL)), l.ANNEE_B_DETAIL.Replace("/", "")));
                                        }
                                    }

                                }

                                sb.AppendLine("</tr>");
                            }
                            else
                            {
                                sb.AppendLine(string.Format("<tr data_code='{0}'>", lr.RUBR_ETAT_CODE.ToString().Trim()));
                                // sb.AppendLine(string.Format("<td class='text-left'>{0}</td>", lr.CODE_POSTE.ToString()));
                                sb.AppendLine(string.Format("<td class='text-left'>{0}</td>", lr.RUBR_ETAT_LIBELLE.ToString()));

                                var liste_valeur2 = service.AnafiAfficheLiasse(1, idDossier, lr.RUBR_ETAT_CODE.ToString().Trim(), "SMT");

                                int j = 0;
                                int v = 0;
                                v = Convert.ToInt32(liste_valeur2.Count) - 3;
                                foreach (var l in liste_valeur2)
                                {

                                    if (liste_valeur2.Count > 3)
                                    {
                                        j++;
                                        if (v < j)
                                        {
                                            if (l.RUBR_ETAT_LIBELLE.Trim().Length <= 1)
                                            {
                                                sb.AppendLine(string.Format("<td class='text-right'></td>"));
                                            }
                                            else
                                            {
                                                sb.AppendLine(string.Format("<td class='text-right {1}'>{0}</td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_B_DETAIL)), l.ANNEE_B_DETAIL.Replace("/", "")));
                                            }
                                        }

                                    }
                                    else
                                    {
                                        if (l.RUBR_ETAT_LIBELLE.Trim().Length <= 1)
                                        {
                                            sb.AppendLine(string.Format("<td class='text-right'></td>"));
                                        }
                                        else
                                        {
                                            sb.AppendLine(string.Format("<td class='text-right {1}'>{0}</td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_B_DETAIL)), l.ANNEE_B_DETAIL.Replace("/", "")));
                                        }
                                    }
                                }

                                sb.AppendLine("</tr>");

                            }
                        }

                        if (lr.RUBR_ETAT_CODE.Trim() == "BA")
                        {
                            //string[]  // TabLOTP = null;

                            // sbt.AppendLine("<table id='totauxActif' class='table-hover table table-bordered text-center'>");
                            sbt.AppendLine(string.Format("<table id='{0}' class='table-hover table table-bordered text-center'>", lr.RUBR_ETAT_CODE.Trim()));
                            sbt.AppendLine(string.Format("<tr style='background-color:rgba(210, 210, 210, 1);'>"));

                            sbt.AppendLine(string.Format("<td class='text-left'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE));
                            // TabLOTA = new string[Convert.ToInt32(liste_annee.Count)];
                            int p = 0;
                            var liste_valeur3 = service.AnafiAfficheLiasse(1, idDossier, lr.RUBR_ETAT_CODE.ToString().Trim(), "SMT");

                            int j = 0;
                            int v = 0;
                            v = Convert.ToInt32(liste_valeur3.Count) - 3;
                            foreach (var l in liste_valeur3)
                            {

                                if (liste_valeur3.Count > 3)
                                {
                                    j++;
                                    if (v < j)
                                    {
                                        sbt.AppendLine(string.Format("<td class='text-right' width=20%>{0}</td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_B_DETAIL)), l.ANNEE_B_DETAIL.Replace("/", "")));
                                        // TabLOTA[p] = l.VALEUR_B_DETAIL.ToString();
                                        p++;
                                    }

                                }
                                else
                                {
                                    sbt.AppendLine(string.Format("<td class='text-right' width=20%>{0}</td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_B_DETAIL)), l.ANNEE_B_DETAIL.Replace("/", "")));
                                    // TabLOTA[p] = l.VALEUR_B_DETAIL.ToString();
                                    p++;
                                }
                            }
                            sbt.AppendLine("</table>");
                            DIVtotauxActif.InnerHtml = sbt.ToString();


                        }

                    }

                    sb.AppendLine("</tbody>");
                    sb.AppendLine("</table>");
                }
                else
                {
                    sb.AppendLine("<div class='col-lg-6 col-sm-6 col-md-6' >");
                    sb.AppendLine("<table id='' class='table table-hover table-bordered text-center'>");
                    sb.AppendLine("<thead class='table-heigth'>");
                    sb.AppendLine(string.Format("<tr><th>Actifs</th>"));
                    sb.AppendLine(string.Format("<th width=23%></th>"));


                    sb.AppendLine("</thead>");
                    sb.AppendLine("<tbody>");

                    var liste_libelle = service.AnafiAfficheLiasse(0, "", "", "BSM");

                    foreach (var lr in liste_libelle)
                    {
                        string SENS = "";
                        if (lr.RUBR_ETAT_CODE.Trim().Length > 2)
                        {
                            SENS = lr.RUBR_ETAT_CODE.ToString().Trim().Substring(0, 3);
                        }

                        if (SENS == "BA1" || SENS == "BA2" || SENS == "BA3" || SENS == "BA4")
                        {
                            if (lr.RUBR_ETAT_CODE.ToString().Trim().Length == 3)
                            {
                                sb.AppendLine(string.Format("<tr data_code='{0}' style='background-color:#ddd'>", lr.RUBR_ETAT_CODE.ToString().Trim()));
                                // sb.AppendLine(string.Format("<td class='text-left'>{0}</td>", lr.CODE_POSTE.ToString()));


                                if (lr.RUBR_ETAT_LIBELLE.Trim().Length <= 1)
                                {
                                    sb.AppendLine(string.Format("<td class='text-left' style='color:#fff'>{0}</td>", lr.RUBR_ETAT_LIBELLE.ToString()));
                                    sb.AppendLine(string.Format("<td></td>"));
                                }
                                else
                                {
                                    sb.AppendLine(string.Format("<td class='text-left'>{0}</td>", lr.RUBR_ETAT_LIBELLE.ToString()));
                                    sb.AppendLine(string.Format("<td></td>"));
                                }



                                sb.AppendLine("</tr>");
                            }
                            else
                            {
                                sb.AppendLine(string.Format("<tr data_code='{0}'>", lr.RUBR_ETAT_CODE.ToString().Trim()));
                                // sb.AppendLine(string.Format("<td class='text-left'>{0}</td>", lr.CODE_POSTE.ToString()));
                                sb.AppendLine(string.Format("<td class='text-left'>{0}</td>", lr.RUBR_ETAT_LIBELLE.ToString()));
                                sb.AppendLine(string.Format("<td></td>"));

                                sb.AppendLine("</tr>");

                            }
                        }

                        if (lr.RUBR_ETAT_CODE.Trim() == "BA")
                        {
                            //string[]  // TabLOTP = null;

                            //sbt.AppendLine("<table id='totauxActif' class='table-hover table table-bordered text-center'>");
                            sbt.AppendLine(string.Format("<table id='{0}' class='table-hover table table-bordered text-center'>", lr.RUBR_ETAT_CODE.Trim()));
                            sbt.AppendLine(string.Format("<tr style='background-color:rgba(210, 210, 210, 1);'>"));

                            sbt.AppendLine(string.Format("<td class='text-left'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE));
                            sbt.AppendLine(string.Format("<td width=23%></td>"));
                            sbt.AppendLine("</table>");
                            DIVtotauxActif.InnerHtml = sbt.ToString();


                        }

                    }

                    sb.AppendLine("</tbody>");
                    sb.AppendLine("</table>");
                }
                sb.AppendLine("</div>");

                //var list_all = service.Listbilan(idDossier);
                //sb.AppendLine("<div class='col-lg-6 col-sm-6 col-md-6' >");

                if (liste_annee.Count != 0)
                {
                    sb.AppendLine("<div class='col-lg-6 col-sm-6 col-md-6' >");
                    sb.AppendLine("<table id='' class='table table-hover table-bordered text-center'>");
                    sb.AppendLine("<thead class='table-heigth'>");
                    sb.AppendLine(string.Format("<tr><th>Passifs</th>"));

                    if (liste_annee.Count > 3)
                    {
                        int j = 0;
                        int v = 0;
                        int i = 0;
                        v = Convert.ToInt32(liste_annee.Count) - 3;
                        foreach (var lr in liste_annee)
                        {
                            j++;
                            if (v < j)
                            {
                                if (i < Convert.ToInt32(liste_annee.Count))
                                {
                                    sb.AppendLine(string.Format("<th onclick='transfertval($(this))' width=20%>{0}</th>", lr.ANNEE_DETAIL));
                                    //TabLOT[i] = lr.ANNEE_DETAIL;
                                }
                            }

                            i++;
                        }
                    }
                    else
                    {
                        int i = 0;
                        foreach (var lr in liste_annee)
                        {

                            if (i < Convert.ToInt32(liste_annee.Count))
                            {
                                sb.AppendLine(string.Format("<th onclick='transfertval($(this))' width=20%>{0}</th>", lr.ANNEE_DETAIL));
                                //TabLOT[i] = lr.ANNEE_DETAIL;
                            }
                            i++;
                        }
                    }

                    sb.AppendLine("</thead>");
                    sb.AppendLine("<tbody>");

                    var liste_libelle = service.AnafiAfficheLiasse(0, "", "", "BSM");

                    foreach (var lr in liste_libelle)
                    {
                        string SENS = "";
                        if (lr.RUBR_ETAT_CODE.Trim().Length > 2)
                        {
                            SENS = lr.RUBR_ETAT_CODE.ToString().Trim().Substring(0, 3);
                        }

                        if (SENS == "BP1" || SENS == "BP2" || SENS == "BP3" || SENS == "BP4" || SENS == "BP5" || SENS == "BP")
                        {
                            if (lr.RUBR_ETAT_CODE.ToString().Trim().Length == 3)
                            {
                                sb.AppendLine(string.Format("<tr data_code='{0}' style='background-color:#ddd'>", lr.RUBR_ETAT_CODE.ToString().Trim()));
                                // sb.AppendLine(string.Format("<td class='text-left'>{0}</td>", lr.CODE_POSTE.ToString()));
                                //sb.AppendLine(string.Format("<td class='text-left'>{0}</td>", lr.RUBR_ETAT_LIBELLE.ToString()));

                                if (lr.RUBR_ETAT_LIBELLE.Trim().Length <= 1)
                                {
                                    sb.AppendLine(string.Format("<td class='text-left' style='color:#fff'>{0}</td>", lr.RUBR_ETAT_LIBELLE.ToString()));
                                }
                                else
                                {
                                    sb.AppendLine(string.Format("<td class='text-left'>{0}</td>", lr.RUBR_ETAT_LIBELLE.ToString()));
                                }
                                var liste_valeur4 = service.AnafiAfficheLiasse(1, idDossier, lr.RUBR_ETAT_CODE.ToString().Trim(), "SMT");
                                int j = 0;
                                int v = 0;
                                v = Convert.ToInt32(liste_valeur4.Count) - 3;
                                foreach (var l in liste_valeur4)
                                {

                                    if (liste_valeur4.Count > 3)
                                    {
                                        j++;
                                        if (v < j)
                                        {
                                            sb.AppendLine(string.Format("<td class='text-right {1}' width=20%>{0}</td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_B_DETAIL)), l.ANNEE_B_DETAIL.Replace("/", "")));
                                        }

                                    }
                                    else
                                    {
                                        sb.AppendLine(string.Format("<td class='text-right {1}' width=20%>{0}</td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_B_DETAIL)), l.ANNEE_B_DETAIL.Replace("/", "")));
                                    }
                                }


                                sb.AppendLine("</tr>");
                            }
                            else
                            {
                                sb.AppendLine(string.Format("<tr data_code='{0}'>", lr.RUBR_ETAT_CODE.ToString().Trim()));
                                // sb.AppendLine(string.Format("<td class='text-left'>{0}</td>", lr.CODE_POSTE.ToString()));
                                sb.AppendLine(string.Format("<td class='text-left'>{0}</td>", lr.RUBR_ETAT_LIBELLE.ToString()));

                                var liste_valeur5 = service.AnafiAfficheLiasse(1, idDossier, lr.RUBR_ETAT_CODE.ToString().Trim(), "SMT");
                                int j = 0;
                                int v = 0;
                                v = Convert.ToInt32(liste_valeur5.Count) - 3;
                                foreach (var l in liste_valeur5)
                                {

                                    if (liste_valeur5.Count > 3)
                                    {
                                        j++;
                                        if (v < j)
                                        {
                                            if (l.RUBR_ETAT_LIBELLE.Trim().Length <= 1)
                                            {
                                                sb.AppendLine(string.Format("<td class='text-right' width=20%></td>"));
                                            }
                                            else
                                            {
                                                sb.AppendLine(string.Format("<td class='text-right {1}' width=20%>{0}</td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_B_DETAIL)), l.ANNEE_B_DETAIL.Replace("/", "")));
                                            }
                                        }

                                    }
                                    else
                                    {
                                        if (l.RUBR_ETAT_LIBELLE.Trim().Length <= 1)
                                        {
                                            sb.AppendLine(string.Format("<td class='text-right' width=20%></td>"));
                                        }
                                        else
                                        {
                                            sb.AppendLine(string.Format("<td class='text-right {1}' width=20%>{0}</td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_B_DETAIL)), l.ANNEE_B_DETAIL.Replace("/", "")));
                                        }
                                    }
                                }

                                sb.AppendLine("</tr>");
                            }
                        }
                        if (lr.RUBR_ETAT_CODE.Trim() == "BP")
                        {
                            //string[]  // TabLOTP = null;

                            //sbv.AppendLine("<table id='totauxPassif' class='table-hover table table-bordered text-center matb'>");
                            sbv.AppendLine(string.Format("<table id='{0}' class='table-hover table table-bordered text-center matb'>", lr.RUBR_ETAT_CODE.Trim()));
                            sbv.AppendLine(string.Format("<tr style='background-color:rgba(210, 210, 210, 1);'>"));

                            sbv.AppendLine(string.Format("<td class='text-left'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE));
                            // TabLOTP = new string[Convert.ToInt32(liste_annee.Count)];
                            int p = 0;
                            var liste_valeur6 = service.AnafiAfficheLiasse(1, idDossier, lr.RUBR_ETAT_CODE.ToString().Trim(), "SMT");
                            int j = 0;
                            int v = 0;
                            v = Convert.ToInt32(liste_valeur6.Count) - 3;
                            foreach (var l in liste_valeur6)
                            {

                                if (liste_valeur6.Count > 3)
                                {
                                    j++;
                                    if (v < j)
                                    {
                                        sbv.AppendLine(string.Format("<td class='text-right' width=20%>{0}</td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_B_DETAIL)), l.ANNEE_B_DETAIL.Replace("/", "")));
                                        // TabLOTP[p] = l.VALEUR_B_DETAIL.ToString();
                                        p++;
                                    }

                                }
                                else
                                {
                                    sbv.AppendLine(string.Format("<td class='text-right' width=20%>{0}</td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_B_DETAIL)), l.ANNEE_B_DETAIL.Replace("/", "")));
                                    // TabLOTP[p] = l.VALEUR_B_DETAIL.ToString();
                                    p++;
                                }
                            }
                            sbv.AppendLine("</table>");
                            DIVtotauxPassif.InnerHtml = sbv.ToString();


                            sbe.AppendLine("<table id='totauxPassif' class='table-hover table table-bordered text-center'>");
                            sbe.AppendLine(string.Format("<tr style='background-color:rgba(210, 210, 210, 1);'>"));

                            sbe.AppendLine(string.Format("<td class='text-left'>Ecart</td>"));
                            // TabLOTP = new string[Convert.ToInt32(liste_annee.Count)];
                            p = 0;
                            //var liste_valeur = service.AnafiAfficheLiasse(1, idDossier, lr.RUBR_ETAT_CODE.ToString().Trim(), "");
                            j = 0;
                            v = 0;
                            v = Convert.ToInt32(liste_valeur6.Count) - 3;
                            foreach (var l in liste_valeur6)
                            {

                                if (liste_valeur6.Count > 3)
                                {
                                    j++;
                                    if (v < j)
                                    {
                                        sbe.AppendLine(string.Format("<td class='text-right' width=20%></td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_B_DETAIL)), l.ANNEE_B_DETAIL.Replace("/", "")));
                                        // TabLOTP[p] = l.VALEUR_B_DETAIL.ToString();
                                        p++;
                                    }

                                }
                                else
                                {
                                    sbe.AppendLine(string.Format("<td class='text-right' width=20%></td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_B_DETAIL)), l.ANNEE_B_DETAIL.Replace("/", "")));
                                    // TabLOTP[p] = l.VALEUR_B_DETAIL.ToString();
                                    p++;
                                }
                            }


                            sbe.AppendLine("</table>");
                            DivecartsActifPassif.InnerHtml = sbe.ToString();
                            //TPAnnee3.InnerHtml = "<strong>" + Convert.ToString(string.Format("{0:#,##0}", lr.ANNEE3)) + "</strong>";
                        }
                    }

                    sb.AppendLine("</tbody>");
                    sb.AppendLine("</table>");

                    DIVtotauxActif.Visible = true;
                    DIVtotauxPassif.Visible = true;
                    DivecartsActifPassif.Visible = true;
                }
                else
                {
                    sb.AppendLine("<div class='col-lg-6 col-sm-6 col-md-6' >");
                    sb.AppendLine("<table id='' class='table table-hover table-bordered text-center'>");
                    sb.AppendLine("<thead class='table-heigth'>");
                    sb.AppendLine(string.Format("<tr><th>Passifs</th>"));
                    sb.AppendLine(string.Format("<th width=23%></th>"));

                    sb.AppendLine("</thead>");
                    sb.AppendLine("<tbody>");

                    var liste_libelle = service.AnafiAfficheLiasse(0, "", "", "BSM");

                    foreach (var lr in liste_libelle)
                    {
                        string SENS = "";
                        if (lr.RUBR_ETAT_CODE.Trim().Length > 2)
                        {
                            SENS = lr.RUBR_ETAT_CODE.ToString().Trim().Substring(0, 3);
                        }

                        if (SENS == "BP1" || SENS == "BP2" || SENS == "BP3" || SENS == "BP4" || SENS == "BP5" || SENS == "BP")
                        {
                            if (lr.RUBR_ETAT_CODE.ToString().Trim().Length == 3)
                            {
                                sb.AppendLine(string.Format("<tr data_code='{0}' style='background-color:#ddd'>", lr.RUBR_ETAT_CODE.ToString().Trim()));
                                // sb.AppendLine(string.Format("<td class='text-left'>{0}</td>", lr.CODE_POSTE.ToString()));
                                //sb.AppendLine(string.Format("<td class='text-left'>{0}</td>", lr.RUBR_ETAT_LIBELLE.ToString()));

                                if (lr.RUBR_ETAT_LIBELLE.Trim().Length <= 1)
                                {
                                    sb.AppendLine(string.Format("<td class='text-left' style='color:#fff'>{0}</td>", lr.RUBR_ETAT_LIBELLE.ToString()));
                                    sb.AppendLine(string.Format("<td></td>"));
                                }
                                else
                                {
                                    sb.AppendLine(string.Format("<td class='text-left'>{0}</td>", lr.RUBR_ETAT_LIBELLE.ToString()));
                                    sb.AppendLine(string.Format("<td></td>"));
                                }


                                sb.AppendLine("</tr>");
                            }
                            else
                            {
                                sb.AppendLine(string.Format("<tr data_code='{0}'>", lr.RUBR_ETAT_CODE.ToString().Trim()));
                                // sb.AppendLine(string.Format("<td class='text-left'>{0}</td>", lr.CODE_POSTE.ToString()));
                                sb.AppendLine(string.Format("<td class='text-left'>{0}</td>", lr.RUBR_ETAT_LIBELLE.ToString()));
                                sb.AppendLine(string.Format("<td></td>"));

                                sb.AppendLine("</tr>");
                            }
                        }
                        if (lr.RUBR_ETAT_CODE.Trim() == "BP")
                        {
                            //string[]  // TabLOTP = null;

                            // sbv.AppendLine("<table id='totauxPassif' class='table-hover table table-bordered text-center'>");
                            sbv.AppendLine(string.Format("<table id='{0}' class='table-hover table table-bordered text-center matb'>", lr.RUBR_ETAT_CODE.Trim()));

                            sbv.AppendLine(string.Format("<tr style='background-color:rgba(210, 210, 210, 1);'>"));

                            sbv.AppendLine(string.Format("<td class='text-left'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE));
                            sbv.AppendLine(string.Format("<td width=23%></td>"));
                            sbv.AppendLine("</table>");
                            DIVtotauxPassif.InnerHtml = sbv.ToString();


                            sbe.AppendLine("<table id='totauxPassif' class='table-hover table table-bordered text-center'>");
                            sbe.AppendLine(string.Format("<tr style='background-color:rgba(210, 210, 210, 1);'>"));

                            sbe.AppendLine(string.Format("<td class='text-left'>Ecart</td>"));
                            sbe.AppendLine(string.Format("<td width=23%></td>"));
                            sbe.AppendLine("</table>");
                            DivecartsActifPassif.InnerHtml = sbe.ToString();
                        }
                    }

                    sb.AppendLine("</tbody>");
                    sb.AppendLine("</table>");

                    DIVtotauxActif.Visible = true;
                    DIVtotauxPassif.Visible = true;
                    DivecartsActifPassif.Visible = true;
                }



                sb.AppendLine("</div>");
            }
            else
            {
                if (DdlRubrique.Text != "Bilan")
                {
                    DIVtotauxActif.Visible = false;
                    DIVtotauxPassif.Visible = false;
                    DivecartsActifPassif.Visible = false;
                }
            }
            ListDFinanciers.InnerHtml = sb.ToString();

        }

        public void afficheBCompteResultatSMT()
        {

            //string[]  // TabLOTA = null;

            // TabLOTA = new string[] { String.Empty };

            // string[]  // TabLOTP = null;

            // TabLOTP = new string[] { String.Empty };
            if (Session["id_dossier"] == null) Response.Redirect("~/Scoring/Connexion.aspx");

            var idDossier = Session["id_dossier"].ToString();
            Session.Add("id_dossier", idDossier);
            if (DdlRubrique.Text == "Compte de résultat")
            {
                Type_anafi = "BN";
                Div1.Visible = true;
                Div2.Visible = true;
                var liste_annee = service.AnafiAfficheLiasse(7, idDossier, "", "SMT");
                var nombre_annee = service.AnafiAfficheLiasse(8, idDossier, "", "SMT");

                if (liste_annee.Count != 0)
                {
                    sb.AppendLine("<div class='col-lg-6 col-sm-6 col-md-6' >");
                    sb.AppendLine("<table id='' class='table table-hover table-bordered text-center'>");
                    sb.AppendLine("<thead class='table-heigth'>");
                    sb.AppendLine(string.Format("<tr><th>Charges</th>"));

                    if (liste_annee.Count > 3)
                    {
                        int j = 0;
                        int v = 0;
                        int i = 0;
                        v = Convert.ToInt32(liste_annee.Count) - 3;
                        foreach (var lr in liste_annee)
                        {
                            j++;
                            if (v < j)
                            {
                                if (i < Convert.ToInt32(liste_annee.Count))
                                {
                                    sb.AppendLine(string.Format("<th onclick='transfertval($(this))' >{0}</th>", lr.ANNEE_DETAIL));
                                    //TabLOT[i] = lr.ANNEE_DETAIL;
                                }
                            }

                            i++;
                        }
                    }
                    else
                    {
                        int i = 0;
                        foreach (var lr in liste_annee)
                        {

                            if (i < Convert.ToInt32(liste_annee.Count))
                            {
                                sb.AppendLine(string.Format("<th onclick='transfertval($(this))'>{0}</th>", lr.ANNEE_DETAIL));
                                //TabLOT[i] = lr.ANNEE_DETAIL;
                            }
                            i++;
                        }
                    }
                    sb.AppendLine("</thead>");
                    sb.AppendLine("<tbody>");

                    var liste_libelle = service.AnafiAfficheLiasse(0, "", "", "CSM");

                    foreach (var lr in liste_libelle)
                    {
                        string SENS = "";
                        if (lr.RUBR_ETAT_CODE.Trim().Length > 2)
                        {
                            SENS = lr.RUBR_ETAT_CODE.ToString().Trim().Substring(0, 3);
                        }

                        if (SENS == "CC0" || SENS == "CC1")
                        {
                            if (lr.RUBR_ETAT_CODE.ToString().Trim().Length == 3)
                            {
                                sb.AppendLine(string.Format("<tr data_code='{0}' style='background-color:#ddd'>", lr.RUBR_ETAT_CODE.ToString().Trim()));


                                if (lr.RUBR_ETAT_LIBELLE.Trim().Length <= 1)
                                {
                                    sb.AppendLine(string.Format("<td class='text-left' style='color:#fff'>{0}</td>", lr.RUBR_ETAT_LIBELLE.ToString()));
                                }
                                else
                                {
                                    sb.AppendLine(string.Format("<td class='text-left'>{0}</td>", lr.RUBR_ETAT_LIBELLE.ToString()));
                                }

                                var liste_valeur = service.AnafiAfficheLiasse(2, idDossier, lr.RUBR_ETAT_CODE.ToString().Trim(), "SMT");

                                int j = 0;
                                int v = 0;
                                v = Convert.ToInt32(liste_valeur.Count) - 3;
                                foreach (var l in liste_valeur)
                                {

                                    if (liste_valeur.Count > 3)
                                    {
                                        j++;
                                        if (v < j)
                                        {
                                            if (l.RUBR_ETAT_LIBELLE.Trim().Length <= 1)
                                            {
                                                sb.AppendLine(string.Format("<td class='text-right'></td>"));
                                            }
                                            else
                                            {
                                                sb.AppendLine(string.Format("<td class='text-right {1}'>{0}</td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_CR_DETAIL)), l.ANNEE_CR_DETAIL.Replace("/", "")));

                                               // sb.AppendLine(string.Format("<td class='text-right'>{0}</td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_CR_DETAIL))));
                                            }
                                        }

                                    }
                                    else
                                    {
                                        if (l.RUBR_ETAT_LIBELLE.Trim().Length <= 1)
                                        {
                                            sb.AppendLine(string.Format("<td class='text-right'></td>"));
                                        }
                                        else
                                        {
                                            sb.AppendLine(string.Format("<td class='text-right {1}'>{0}</td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_CR_DETAIL)), l.ANNEE_CR_DETAIL.Replace("/", "")));

                                            //sb.AppendLine(string.Format("<td class='text-right'>{0}</td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_CR_DETAIL))));
                                        }
                                    }
                                }




                                sb.AppendLine("</tr>");
                            }
                            else
                            {
                                sb.AppendLine(string.Format("<tr data_code='{0}'>", lr.RUBR_ETAT_CODE.ToString().Trim()));
                                sb.AppendLine(string.Format("<td class='text-left'>{0}</td>", lr.RUBR_ETAT_LIBELLE.ToString()));

                                var liste_valeur = service.AnafiAfficheLiasse(2, idDossier, lr.RUBR_ETAT_CODE.ToString().Trim(), "SMT");
                                int j = 0;
                                int v = 0;
                                v = Convert.ToInt32(liste_valeur.Count) - 3;
                                foreach (var l in liste_valeur)
                                {

                                    if (liste_valeur.Count > 3)
                                    {
                                        j++;
                                        if (v < j)
                                        {
                                            if (l.RUBR_ETAT_LIBELLE.Trim().Length <= 1)
                                            {
                                                sb.AppendLine(string.Format("<td class='text-right'></td>"));
                                            }
                                            else
                                            {
                                                sb.AppendLine(string.Format("<td class='text-right {1}'>{0}</td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_CR_DETAIL)), l.ANNEE_CR_DETAIL.Replace("/", "")));

                                               // sb.AppendLine(string.Format("<td class='text-right'>{0}</td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_CR_DETAIL))));
                                            }
                                        }

                                    }
                                    else
                                    {
                                        if (l.RUBR_ETAT_LIBELLE.Trim().Length <= 1)
                                        {
                                            sb.AppendLine(string.Format("<td class='text-right'></td>"));
                                        }
                                        else
                                        {

                                            sb.AppendLine(string.Format("<td class='text-right {1}'>{0}</td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_CR_DETAIL)), l.ANNEE_CR_DETAIL.Replace("/", "")));

                                           // sb.AppendLine(string.Format("<td class='text-right'>{0}</td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_CR_DETAIL))));
                                        }
                                    }
                                }


                                sb.AppendLine("</tr>");

                            }
                        }

                        if (lr.RUBR_ETAT_CODE.Trim() == "CC")
                        {
                            sb.AppendLine(string.Format("<tr style='background-color:rgba(210, 210, 210, 1);'>"));

                            sb.AppendLine(string.Format("<td class='text-left'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE));
                            // TabLOTA = new string[Convert.ToInt32(liste_annee.Count)];
                            int p = 0;
                            var liste_valeur = service.AnafiAfficheLiasse(2, idDossier, lr.RUBR_ETAT_CODE.ToString().Trim(), "SMT");

                            int j = 0;
                            int v = 0;
                            v = Convert.ToInt32(liste_valeur.Count) - 3;
                            foreach (var l in liste_valeur)
                            {

                                if (liste_valeur.Count > 3)
                                {
                                    j++;
                                    if (v < j)
                                    {
                                        sb.AppendLine(string.Format("<td class='text-right'>{0}</td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_CR_DETAIL))));
                                        // TabLOTA[p] = l.VALEUR_B_DETAIL.ToString();
                                        p++;
                                    }

                                }
                                else
                                {
                                    sb.AppendLine(string.Format("<td class='text-right'>{0}</td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_CR_DETAIL))));
                                    // TabLOTA[p] = l.VALEUR_B_DETAIL.ToString();
                                    p++;
                                }
                            }

                        }

                    }

                    sb.AppendLine("</tbody>");
                    sb.AppendLine("</table>");
                }
                else
                {
                    sb.AppendLine("<div class='col-lg-6 col-sm-6 col-md-6' >");
                    sb.AppendLine("<table id='' class='table table-hover table-bordered text-center'>");
                    sb.AppendLine("<thead class='table-heigth'>");
                    sb.AppendLine(string.Format("<tr><th>Charges</th>"));
                    sb.AppendLine(string.Format("<th width=23%></th>"));

                    sb.AppendLine("</thead>");
                    sb.AppendLine("<tbody>");

                    var liste_libelle = service.AnafiAfficheLiasse(0, "", "", "CSM");

                    foreach (var lr in liste_libelle)
                    {
                        string SENS = "";
                        if (lr.RUBR_ETAT_CODE.Trim().Length > 2)
                        {
                            SENS = lr.RUBR_ETAT_CODE.ToString().Trim().Substring(0, 3);
                        }

                        if (SENS == "CC0" || SENS == "CC1")
                        {
                            if (lr.RUBR_ETAT_CODE.ToString().Trim().Length == 3)
                            {
                                sb.AppendLine(string.Format("<tr data_code='{0}' style='background-color:#ddd'>", lr.RUBR_ETAT_CODE.ToString().Trim()));


                                if (lr.RUBR_ETAT_LIBELLE.Trim().Length <= 1)
                                {
                                    sb.AppendLine(string.Format("<td class='text-left' style='color:#fff'>{0}</td>", lr.RUBR_ETAT_LIBELLE.ToString()));
                                    sb.AppendLine(string.Format("<td></td>"));
                                }
                                else
                                {
                                    sb.AppendLine(string.Format("<td class='text-left'>{0}</td>", lr.RUBR_ETAT_LIBELLE.ToString()));
                                    sb.AppendLine(string.Format("<td></td>"));
                                }


                                sb.AppendLine("</tr>");
                            }
                            else
                            {
                                sb.AppendLine(string.Format("<tr data_code='{0}'>", lr.RUBR_ETAT_CODE.ToString().Trim()));
                                sb.AppendLine(string.Format("<td class='text-left'>{0}</td>", lr.RUBR_ETAT_LIBELLE.ToString()));
                                sb.AppendLine(string.Format("<td></td>"));
                                sb.AppendLine("</tr>");

                            }
                        }

                        if (lr.RUBR_ETAT_CODE.Trim() == "CC")
                        {
                            sb.AppendLine(string.Format("<tr style='background-color:rgba(210, 210, 210, 1);'>"));

                            sb.AppendLine(string.Format("<td class='text-left'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE));
                            sb.AppendLine(string.Format("<td></td>"));

                        }

                    }

                    sb.AppendLine("</tbody>");
                    sb.AppendLine("</table>");
                }
                sb.AppendLine("</div>");

                if (liste_annee.Count != 0)
                {
                    sb.AppendLine("<div class='col-lg-6 col-sm-6 col-md-6' >");
                    sb.AppendLine("<table id='' class='table table-hover table-bordered text-center'>");
                    sb.AppendLine("<thead class='table-heigth'>");
                    sb.AppendLine(string.Format("<tr><th>Produits</th>"));

                    if (liste_annee.Count > 3)
                    {
                        int j = 0;
                        int v = 0;
                        int i = 0;
                        v = Convert.ToInt32(liste_annee.Count) - 3;
                        foreach (var lr in liste_annee)
                        {
                            j++;
                            if (v < j)
                            {
                                if (i < Convert.ToInt32(liste_annee.Count))
                                {
                                    sb.AppendLine(string.Format("<th onclick='transfertval($(this))'>{0}</th>", lr.ANNEE_DETAIL));
                                    //TabLOT[i] = lr.ANNEE_DETAIL;
                                }
                            }

                            i++;
                        }
                    }
                    else
                    {
                        int i = 0;
                        foreach (var lr in liste_annee)
                        {

                            if (i < Convert.ToInt32(liste_annee.Count))
                            {
                                sb.AppendLine(string.Format("<th onclick='transfertval($(this))'>{0}</th>", lr.ANNEE_DETAIL));
                                //TabLOT[i] = lr.ANNEE_DETAIL;
                            }
                            i++;
                        }
                    }

                    sb.AppendLine("</thead>");
                    sb.AppendLine("<tbody>");

                    var liste_libelle = service.AnafiAfficheLiasse(0, "", "", "CSM");

                    foreach (var lr in liste_libelle)
                    {
                        string SENS = "";
                        if (lr.RUBR_ETAT_CODE.Trim().Length > 2)
                        {
                            SENS = lr.RUBR_ETAT_CODE.ToString().Trim().Substring(0, 3);
                        }

                        if (SENS == "CP0" || SENS == "CP1")
                        {
                            if (lr.RUBR_ETAT_CODE.ToString().Trim().Length == 3)
                            {
                                sb.AppendLine(string.Format("<tr data_code='{0}' style='background-color:#ddd'>", lr.RUBR_ETAT_CODE.ToString().Trim()));

                                if (lr.RUBR_ETAT_LIBELLE.Trim().Length <= 1)
                                {
                                    sb.AppendLine(string.Format("<td class='text-left' style='color:#fff'>{0}</td>", lr.RUBR_ETAT_LIBELLE.ToString()));
                                }
                                else
                                {
                                    sb.AppendLine(string.Format("<td class='text-left'>{0}</td>", lr.RUBR_ETAT_LIBELLE.ToString()));
                                }
                                var liste_valeur = service.AnafiAfficheLiasse(2, idDossier, lr.RUBR_ETAT_CODE.ToString().Trim(), "SMT");
                                int j = 0;
                                int v = 0;
                                v = Convert.ToInt32(liste_valeur.Count) - 3;
                                foreach (var l in liste_valeur)
                                {

                                    if (liste_valeur.Count > 3)
                                    {
                                        j++;
                                        if (v < j)
                                        {
                                            sb.AppendLine(string.Format("<td class='text-right'>{0}</td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_CR_DETAIL))));
                                        }

                                    }
                                    else
                                    {
                                        sb.AppendLine(string.Format("<td class='text-right {1}'>{0}</td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_CR_DETAIL)), l.ANNEE_CR_DETAIL.Replace("/", "")));

                                      //  sb.AppendLine(string.Format("<td class='text-right'>{0}</td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_CR_DETAIL))));
                                    }
                                }

                                sb.AppendLine("</tr>");
                            }
                            else
                            {
                                sb.AppendLine(string.Format("<tr data_code='{0}'>", lr.RUBR_ETAT_CODE.ToString().Trim()));
                                sb.AppendLine(string.Format("<td class='text-left'>{0}</td>", lr.RUBR_ETAT_LIBELLE.ToString()));

                                var liste_valeur = service.AnafiAfficheLiasse(2, idDossier, lr.RUBR_ETAT_CODE.ToString().Trim(), "SMT");
                                int j = 0;
                                int v = 0;
                                v = Convert.ToInt32(liste_valeur.Count) - 3;
                                foreach (var l in liste_valeur)
                                {

                                    if (liste_valeur.Count > 3)
                                    {
                                        j++;
                                        if (v < j)
                                        {
                                            if (l.RUBR_ETAT_LIBELLE.Trim().Length <= 1)
                                            {
                                                sb.AppendLine(string.Format("<td class='text-right'></td>"));
                                            }
                                            else
                                            {
                                                sb.AppendLine(string.Format("<td class='text-right {1}'>{0}</td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_CR_DETAIL)), l.ANNEE_CR_DETAIL.Replace("/", "")));

                                                //sb.AppendLine(string.Format("<td class='text-right'>{0}</td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_CR_DETAIL))));
                                            }
                                        }

                                    }
                                    else
                                    {
                                        if (l.RUBR_ETAT_LIBELLE.Trim().Length <= 1)
                                        {
                                            sb.AppendLine(string.Format("<td class='text-right'></td>"));
                                        }
                                        else
                                        {
                                            sb.AppendLine(string.Format("<td class='text-right {1}'>{0}</td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_CR_DETAIL)), l.ANNEE_CR_DETAIL.Replace("/", "")));

                                            //sb.AppendLine(string.Format("<td class='text-right'>{0}</td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_CR_DETAIL))));
                                        }
                                    }
                                }

                                sb.AppendLine("</tr>");
                            }
                        }
                        if (lr.RUBR_ETAT_CODE.Trim() == "CP")
                        {
                            sb.AppendLine(string.Format("<tr style='background-color:rgba(210, 210, 210, 1);'>"));

                            sb.AppendLine(string.Format("<td class='text-left'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE));
                            // TabLOTP = new string[Convert.ToInt32(liste_annee.Count)];
                            int p = 0;
                            var liste_valeur = service.AnafiAfficheLiasse(2, idDossier, lr.RUBR_ETAT_CODE.ToString().Trim(), "SMT");
                            int j = 0;
                            int v = 0;
                            v = Convert.ToInt32(liste_valeur.Count) - 3;
                            foreach (var l in liste_valeur)
                            {

                                if (liste_valeur.Count > 3)
                                {
                                    j++;
                                    if (v < j)
                                    {
                                        sb.AppendLine(string.Format("<td class='text-right'>{0}</td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_CR_DETAIL))));
                                        // TabLOTP[p] = l.VALEUR_B_DETAIL.ToString();
                                        p++;
                                    }

                                }
                                else
                                {
                                    sb.AppendLine(string.Format("<td class='text-right'>{0}</td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_CR_DETAIL))));
                                    // TabLOTP[p] = l.VALEUR_B_DETAIL.ToString();
                                    p++;
                                }
                            }

                        }
                    }

                    sb.AppendLine("</tbody>");
                    sb.AppendLine("</table>");

                }
                else
                {
                    sb.AppendLine("<div class='col-lg-6 col-sm-6 col-md-6' >");
                    sb.AppendLine("<table id='' class='table table-hover table-bordered text-center'>");
                    sb.AppendLine("<thead class='table-heigth'>");
                    sb.AppendLine(string.Format("<tr><th>Produits</th>"));
                    sb.AppendLine(string.Format("<th width=23%></th>"));

                    sb.AppendLine("</thead>");
                    sb.AppendLine("<tbody>");

                    var liste_libelle = service.AnafiAfficheLiasse(0, "", "", "CSM");

                    foreach (var lr in liste_libelle)
                    {
                        string SENS = "";
                        if (lr.RUBR_ETAT_CODE.Trim().Length > 2)
                        {
                            SENS = lr.RUBR_ETAT_CODE.ToString().Trim().Substring(0, 3);
                        }

                        if (SENS == "CP0" || SENS == "CP1")
                        {
                            if (lr.RUBR_ETAT_CODE.ToString().Trim().Length == 3)
                            {
                                sb.AppendLine(string.Format("<tr data_code='{0}' style='background-color:#ddd'>", lr.RUBR_ETAT_CODE.ToString().Trim()));

                                if (lr.RUBR_ETAT_LIBELLE.Trim().Length <= 1)
                                {
                                    sb.AppendLine(string.Format("<td class='text-left' style='color:#fff'>{0}</td>", lr.RUBR_ETAT_LIBELLE.ToString()));
                                    sb.AppendLine(string.Format("<td></td>"));
                                }
                                else
                                {
                                    sb.AppendLine(string.Format("<td class='text-left'>{0}</td>", lr.RUBR_ETAT_LIBELLE.ToString()));
                                    sb.AppendLine(string.Format("<td></td>"));
                                }

                                sb.AppendLine("</tr>");
                            }
                            else
                            {
                                sb.AppendLine(string.Format("<tr data_code='{0}'>", lr.RUBR_ETAT_CODE.ToString().Trim()));
                                sb.AppendLine(string.Format("<td class='text-left'>{0}</td>", lr.RUBR_ETAT_LIBELLE.ToString()));
                                sb.AppendLine(string.Format("<td></td>"));

                                sb.AppendLine("</tr>");
                            }
                        }
                        if (lr.RUBR_ETAT_CODE.Trim() == "CP")
                        {
                            sb.AppendLine(string.Format("<tr style='background-color:rgba(210, 210, 210, 1);'>"));

                            sb.AppendLine(string.Format("<td class='text-left'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE));
                            sb.AppendLine(string.Format("<td></td>"));
                        }
                    }

                    sb.AppendLine("</tbody>");
                    sb.AppendLine("</table>");

                }



                sb.AppendLine("</div>");
            }
            else
            {
                if (DdlRubrique.Text != "Bilan")
                {
                    DIVtotauxActif.Visible = false;
                    DIVtotauxPassif.Visible = false;
                    DivecartsActifPassif.Visible = false;
                }
            }
            ListDFinanciers.InnerHtml = sb.ToString();
        }

        public void afficheBilanGrandeMasseSMT()
        {
            //string[]  // TabLOTA = null;

            // TabLOTA = new string[] { String.Empty };

            // string[]  // TabLOTP = null;

            // TabLOTP = new string[] { String.Empty };
            if (Session["id_dossier"] == null) Response.Redirect("~/Scoring/Connexion.aspx");

            var idDossier = Session["id_dossier"].ToString();
            Session.Add("id_dossier", idDossier);
            if (DdlRubrique.Text == "Bilan en grandes masses")
            {
                Type_anafi = "BN";
                Div1.Visible = true;
                Div2.Visible = true;
                var liste_annee = service.AnafiAfficheLiasse(7, idDossier, "", "SMT");
                var nombre_annee = service.AnafiAfficheLiasse(8, idDossier, "", "SMT");

                if (liste_annee.Count != 0)
                {
                    sb.AppendLine("<div class='col-lg-6col-sm-6 col-md-6' style=\"overflow-x:auto\" >");
                    sb.AppendLine("<table id='' class='table table-hover table-bordered text-center'>");
                    sb.AppendLine("<thead class='table-heigth'>");
                    sb.AppendLine(string.Format("<tr><th>Actifs</th>"));

                    if (liste_annee.Count > 3)
                    {
                        int j = 0;
                        int v = 0;
                        int i = 0;
                        v = Convert.ToInt32(liste_annee.Count) - 3;
                        foreach (var lr in liste_annee)
                        {
                            j++;
                            if (v < j)
                            {
                                if (i < Convert.ToInt32(liste_annee.Count))
                                {
                                    sb.AppendLine(string.Format("<th width=20%>{0}</th>", lr.ANNEE_DETAIL));
                                    //TabLOT[i] = lr.ANNEE_DETAIL;
                                }
                            }

                            i++;
                        }
                    }
                    else
                    {
                        int i = 0;
                        foreach (var lr in liste_annee)
                        {

                            if (i < Convert.ToInt32(liste_annee.Count))
                            {
                                sb.AppendLine(string.Format("<th width=20%>{0}</th>", lr.ANNEE_DETAIL));
                                //TabLOT[i] = lr.ANNEE_DETAIL;
                            }
                            i++;
                        }
                    }

                    sb.AppendLine("</thead>");
                    sb.AppendLine("<tbody>");

                    var liste_libelle = service.AnafiAfficheLiasse(0, "", "", "BIL");
                    string[] TabLOTN = null;
                    foreach (var lr in liste_libelle)
                    {

                        string SENS = lr.RUBR_ETAT_CODE.ToString().Trim().Substring(0, 3);
                        if (SENS == "BI1" || SENS == "BI2" || SENS == "BI3")
                        {
                            if (lr.RUBR_ETAT_CODE.Trim().Length == 4)
                            {
                                if (lr.RUBR_ETAT_CODE.Trim() == "BI3Z")
                                {

                                    sbt.AppendLine("<table id='totauxActif' class='table-hover table table-bordered text-center'>");
                                    sbt.AppendLine(string.Format("<tr style='background-color:rgba(210, 210, 210, 1);'>"));

                                    sbt.AppendLine(string.Format("<td class='text-left'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE));
                                    // TabLOTA = new string[Convert.ToInt32(liste_annee.Count)];
                                    int pa = 0;
                                    var liste_valeur = service.AnafiAfficheLiasse(3, idDossier, lr.RUBR_ETAT_CODE.ToString().Trim(), "SMT");

                                    int j = 0;
                                    int v = 0;
                                    v = Convert.ToInt32(liste_valeur.Count) - 3;
                                    foreach (var l in liste_valeur)
                                    {

                                        if (liste_valeur.Count > 3)
                                        {
                                            j++;
                                            if (v < j)
                                            {
                                                //string k = "";
                                                //k = TabLOTN[1];
                                                //sbt.AppendLine(string.Format("<td class='text-left'>{0}</td>", Convert.ToString(string.Format("{0:#,##0}", k))));
                                                sbt.AppendLine(string.Format("<td class='text-left' width=16%><strong>{0}</strong></td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_BGR_DETAIL))));
                                                //pa++;
                                            }

                                        }
                                        else
                                        {
                                            //string k = "";
                                            //k = TabLOTN[1];
                                            //sbt.AppendLine(string.Format("<td class='text-left'>{0}</td>", Convert.ToString(string.Format("{0:#,##0}", k))));
                                            sbt.AppendLine(string.Format("<td class='text-left' width=16%><strong>{0}</strong></td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_BGR_DETAIL))));
                                            //pa++;
                                        }
                                    }

                                    sbt.AppendLine("</table>");
                                    DIVtotauxActif.InnerHtml = sbt.ToString();
                                }
                                else
                                {
                                    if (lr.RUBR_ETAT_CODE.ToString().Trim() == "BI7Z")
                                    {


                                    }
                                    else
                                    {

                                        sb.AppendLine(string.Format("<tr data_code='{0}' style='background-color:rgba(210, 210, 210, 1);'>", lr.RUBR_ETAT_CODE.ToString().Trim()));
                                        sb.AppendLine(string.Format("<td class='text-left'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE.ToString()));
                                        // TabLOTP = new string[Convert.ToInt32(liste_annee.Count)];
                                        int p = 0;
                                        var liste_valeur = service.AnafiAfficheLiasse(3, idDossier, lr.RUBR_ETAT_CODE.ToString().Trim(), "SMT");

                                        int j = 0;
                                        int v = 0;
                                        v = Convert.ToInt32(liste_valeur.Count) - 3;
                                        foreach (var l in liste_valeur)
                                        {

                                            if (liste_valeur.Count > 3)
                                            {
                                                j++;
                                                if (v < j)
                                                {
                                                    if (l.TYPE_ANAFI_A.Trim() == "SMT")
                                                    {
                                                        sb.AppendLine(string.Format("<td class='text-right'><strong>{0}</strong></td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_BGR_DETAIL))));

                                                        // TabLOTA[p] = l.VALEUR_BGR_DETAIL.ToString();

                                                    }
                                                }

                                            }
                                            else
                                            {
                                                if (l.TYPE_ANAFI_A.Trim() == "SMT")
                                                {
                                                    sb.AppendLine(string.Format("<td class='text-right'><strong>{0}</strong></td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_BGR_DETAIL))));

                                                    // TabLOTA[p] = l.VALEUR_BGR_DETAIL.ToString();

                                                }
                                            }
                                        }

                                        sb.AppendLine("</tr>");
                                    }
                                }

                                //sb.AppendLine("</tr>");

                            }
                            else
                            {
                                sb.AppendLine(string.Format("<tr data_code='{0}'>", lr.RUBR_ETAT_CODE.ToString().Trim()));


                                sb.AppendLine(string.Format("<td class='text-left'>{0}</td>", lr.RUBR_ETAT_LIBELLE.ToString()));


                                var liste_valeur = service.AnafiAfficheLiasse(3, idDossier, lr.RUBR_ETAT_CODE.ToString().Trim(), "SMT");


                                int j = 0;
                                int v = 0;
                                v = Convert.ToInt32(liste_valeur.Count) - 3;
                                foreach (var l in liste_valeur)
                                {

                                    if (liste_valeur.Count > 3)
                                    {
                                        j++;
                                        if (v < j)
                                        {
                                            if (l.TYPE_ANAFI_A.Trim() == "SMT")
                                            {
                                                sb.AppendLine(string.Format("<td class='text-right'>{0}</td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_BGR_DETAIL))));
                                            }
                                        }

                                    }
                                    else
                                    {
                                        if (l.TYPE_ANAFI_A.Trim() == "SMT")
                                        {
                                            sb.AppendLine(string.Format("<td class='text-right'>{0}</td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_BGR_DETAIL))));
                                        }
                                    }
                                }

                                sb.AppendLine("</tr>");

                            }
                        }
                    }

                    sb.AppendLine("</tbody>");
                    sb.AppendLine("</table>");

                    DIVtotauxActif.Visible = true;
                    DIVtotauxPassif.Visible = true;
                }
                else
                {
                    sb.AppendLine("<div class='col-lg-6col-sm-6 col-md-6' style=\"overflow-x:auto\" >");
                    sb.AppendLine("<table id='' class='table table-hover table-bordered text-center'>");
                    sb.AppendLine("<thead class='table-heigth'>");
                    sb.AppendLine(string.Format("<tr><th>Actifs</th>"));
                    sb.AppendLine(string.Format("<th width=23%></th>"));

                    sb.AppendLine("</thead>");
                    sb.AppendLine("<tbody>");

                    var liste_libelle = service.AnafiAfficheLiasse(0, "", "", "BIL");
                    string[] TabLOTN = null;
                    foreach (var lr in liste_libelle)
                    {

                        string SENS = lr.RUBR_ETAT_CODE.ToString().Trim().Substring(0, 3);
                        if (SENS == "BI1" || SENS == "BI2" || SENS == "BI3")
                        {
                            if (lr.RUBR_ETAT_CODE.Trim().Length == 4)
                            {
                                if (lr.RUBR_ETAT_CODE.Trim() == "BI3Z")
                                {

                                    sbt.AppendLine("<table id='totauxActif' class='table-hover table table-bordered text-center'>");
                                    sbt.AppendLine(string.Format("<tr style='background-color:rgba(210, 210, 210, 1);'>"));

                                    sbt.AppendLine(string.Format("<td class='text-left'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE));
                                    sbt.AppendLine(string.Format("<td width=23%></td>"));

                                    sbt.AppendLine("</table>");
                                    DIVtotauxActif.InnerHtml = sbt.ToString();
                                }
                                else
                                {
                                    if (lr.RUBR_ETAT_CODE.ToString().Trim() == "BI7Z")
                                    {
                                    }
                                    else
                                    {
                                        sb.AppendLine(string.Format("<tr data_code='{0}' style='background-color:rgba(210, 210, 210, 1);'>", lr.RUBR_ETAT_CODE.ToString().Trim()));
                                        sb.AppendLine(string.Format("<td class='text-left'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE.ToString()));
                                        sb.AppendLine(string.Format("<td></td>"));

                                        sb.AppendLine("</tr>");
                                    }
                                }

                                //sb.AppendLine("</tr>");

                            }
                            else
                            {
                                sb.AppendLine(string.Format("<tr data_code='{0}'>", lr.RUBR_ETAT_CODE.ToString().Trim()));


                                sb.AppendLine(string.Format("<td class='text-left'>{0}</td>", lr.RUBR_ETAT_LIBELLE.ToString()));
                                sb.AppendLine(string.Format("<td></td>"));

                                sb.AppendLine("</tr>");

                            }
                        }
                    }

                    sb.AppendLine("</tbody>");
                    sb.AppendLine("</table>");

                    DIVtotauxActif.Visible = true;
                    DIVtotauxPassif.Visible = true;
                }
                sb.AppendLine("</div>");

                if (liste_annee.Count != 0)
                {
                    sb.AppendLine("<div class='col-lg-6 col-sm-6 col-md-6' >");
                    sb.AppendLine("<table id='' class='table table-hover table-bordered text-center'>");
                    sb.AppendLine("<thead class='table-heigth'>");
                    sb.AppendLine(string.Format("<tr><th>Passifs</th>"));

                    if (liste_annee.Count > 3)
                    {
                        int j = 0;
                        int v = 0;
                        int i = 0;
                        v = Convert.ToInt32(liste_annee.Count) - 3;
                        foreach (var lr in liste_annee)
                        {
                            j++;
                            if (v < j)
                            {
                                if (i < Convert.ToInt32(liste_annee.Count))
                                {
                                    sb.AppendLine(string.Format("<th width=20%>{0}</th>", lr.ANNEE_DETAIL));
                                    //TabLOT[i] = lr.ANNEE_DETAIL;
                                }
                            }

                            i++;
                        }
                    }
                    else
                    {
                        int i = 0;
                        foreach (var lr in liste_annee)
                        {

                            if (i < Convert.ToInt32(liste_annee.Count))
                            {
                                sb.AppendLine(string.Format("<th width=20%>{0}</th>", lr.ANNEE_DETAIL));
                                //TabLOT[i] = lr.ANNEE_DETAIL;
                            }
                            i++;
                        }
                    }

                    sb.AppendLine("</thead>");
                    sb.AppendLine("<tbody>");

                    var liste_libelle = service.AnafiAfficheLiasse(0, "", "", "BIL");
                    string[] TabLOTN = null;
                    foreach (var lr in liste_libelle)
                    {



                        string SENS = lr.RUBR_ETAT_CODE.ToString().Trim().Substring(0, 3);
                        if (SENS == "BI4" || SENS == "BI5" || SENS == "BI6" || SENS == "BI7")
                        {
                            if (lr.RUBR_ETAT_CODE.Trim().Length == 4)
                            {
                                if (lr.RUBR_ETAT_CODE.ToString().Trim() == "BI7Z")
                                {

                                    sbv.AppendLine("<table id='totauxPassif' class='table-hover table table-bordered text-center'>");
                                    sbv.AppendLine(string.Format("<tr style='background-color:rgba(210, 210, 210, 1);'>"));

                                    sbv.AppendLine(string.Format("<td class='text-left'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE));
                                    int iv = 0;
                                    var liste_valeur = service.AnafiAfficheLiasse(3, idDossier, lr.RUBR_ETAT_CODE.ToString().Trim(), "SMT");

                                    int j = 0;
                                    int v = 0;
                                    v = Convert.ToInt32(liste_valeur.Count) - 3;
                                    foreach (var l in liste_valeur)
                                    {

                                        if (liste_valeur.Count > 3)
                                        {
                                            j++;
                                            if (v < j)
                                            {
                                                sbv.AppendLine(string.Format("<td class='text-left' width=16%><strong>{0}</strong></td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_BGR_DETAIL))));
                                                //sbv.AppendLine(string.Format("<td class='text-left'>{0}</td>", Convert.ToString(string.Format("{0:#,##0}", TabLOTN[iv]))));
                                                //iv++;
                                            }

                                        }
                                        else
                                        {
                                            sbv.AppendLine(string.Format("<td class='text-left' width=16%><strong>{0}</strong></td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_BGR_DETAIL))));
                                            //sbv.AppendLine(string.Format("<td class='text-left'>{0}</td>", Convert.ToString(string.Format("{0:#,##0}", TabLOTN[iv]))));
                                            //iv++;
                                        }
                                    }

                                    sbv.AppendLine("</table>");
                                    DIVtotauxPassif.InnerHtml = sbv.ToString();
                                }
                                else
                                {
                                    sb.AppendLine(string.Format("<tr data_code='{0}' style='background-color:rgba(210, 210, 210, 1);'>", lr.RUBR_ETAT_CODE.ToString().Trim()));
                                    sb.AppendLine(string.Format("<td class='text-left'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE.ToString()));
                                    // TabLOTA = new string[Convert.ToInt32(liste_annee.Count)];
                                    int p = 0;
                                    var liste_valeur = service.AnafiAfficheLiasse(3, idDossier, lr.RUBR_ETAT_CODE.ToString().Trim(), "SMT");

                                    int j = 0;
                                    int v = 0;
                                    v = Convert.ToInt32(liste_valeur.Count) - 3;
                                    foreach (var l in liste_valeur)
                                    {

                                        if (liste_valeur.Count > 3)
                                        {
                                            j++;
                                            if (v < j)
                                            {
                                                sb.AppendLine(string.Format("<td class='text-right'><strong>{0}</strong></td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_BGR_DETAIL))));

                                            }

                                        }
                                        else
                                        {
                                            sb.AppendLine(string.Format("<td class='text-right'><strong>{0}</strong></td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_BGR_DETAIL))));

                                        }
                                    }





                                    //TabLOTN = new string[Convert.ToInt32(liste_annee.Count)];
                                    //int pi = 0;
                                    //foreach (var r in liste_annee)
                                    //{

                                    //    if (i < Convert.ToInt32(liste_annee.Count))
                                    //    {
                                    //        var nbr = service.AnafiAfficheLiasse(9, idDossier, r.ANNEE_DETAIL.Trim(), "BIL");
                                    //        TabLOTN[pi] = nbr.ToString();
                                    //        pi++;
                                    //    }

                                    //}
                                    sb.AppendLine("</tr>");
                                }


                                //sb.AppendLine("</tr>");

                            }
                            else
                            {
                                sb.AppendLine(string.Format("<tr data_code='{0}'>", lr.RUBR_ETAT_CODE.ToString().Trim()));


                                sb.AppendLine(string.Format("<td class='text-left'>{0}</td>", lr.RUBR_ETAT_LIBELLE.ToString()));


                                var liste_valeur = service.AnafiAfficheLiasse(3, idDossier, lr.RUBR_ETAT_CODE.ToString().Trim(), "SMT");
                                int j = 0;
                                int v = 0;
                                v = Convert.ToInt32(liste_valeur.Count) - 3;
                                foreach (var l in liste_valeur)
                                {

                                    if (liste_valeur.Count > 3)
                                    {
                                        j++;
                                        if (v < j)
                                        {
                                            if (l.TYPE_ANAFI_A.Trim() == "SMT")
                                            {
                                                sb.AppendLine(string.Format("<td class='text-right'>{0}</td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_BGR_DETAIL))));
                                            }
                                        }

                                    }
                                    else
                                    {
                                        if (l.TYPE_ANAFI_A.Trim() == "SMT")
                                        {
                                            sb.AppendLine(string.Format("<td class='text-right'>{0}</td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_BGR_DETAIL))));
                                        }
                                    }
                                }




                                sb.AppendLine("</tr>");

                            }
                        }
                    }

                    sb.AppendLine("</tbody>");
                    sb.AppendLine("</table>");

                    DIVtotauxActif.Visible = true;
                    DIVtotauxPassif.Visible = true;
                }
                else
                {
                    sb.AppendLine("<div class='col-lg-6 col-sm-6 col-md-6' >");
                    sb.AppendLine("<table id='' class='table table-hover table-bordered text-center'>");
                    sb.AppendLine("<thead class='table-heigth'>");
                    sb.AppendLine(string.Format("<tr><th>Passifs</th>"));
                    sb.AppendLine(string.Format("<th width=23%></th>"));

                    sb.AppendLine("</thead>");
                    sb.AppendLine("<tbody>");

                    var liste_libelle = service.AnafiAfficheLiasse(0, "", "", "BIL");
                    string[] TabLOTN = null;
                    foreach (var lr in liste_libelle)
                    {



                        string SENS = lr.RUBR_ETAT_CODE.ToString().Trim().Substring(0, 3);
                        if (SENS == "BI4" || SENS == "BI5" || SENS == "BI6" || SENS == "BI7")
                        {
                            if (lr.RUBR_ETAT_CODE.Trim().Length == 4)
                            {
                                if (lr.RUBR_ETAT_CODE.ToString().Trim() == "BI7Z")
                                {

                                    sbv.AppendLine("<table id='totauxPassif' class='table-hover table table-bordered text-center'>");
                                    sbv.AppendLine(string.Format("<tr style='background-color:rgba(210, 210, 210, 1);'>"));

                                    sbv.AppendLine(string.Format("<td class='text-left'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE));
                                    sbv.AppendLine(string.Format("<th width=23%></th>"));
                                    sbv.AppendLine("</table>");
                                    DIVtotauxPassif.InnerHtml = sbv.ToString();
                                }
                                else
                                {
                                    sb.AppendLine(string.Format("<tr data_code='{0}' style='background-color:rgba(210, 210, 210, 1);'>", lr.RUBR_ETAT_CODE.ToString().Trim()));
                                    sb.AppendLine(string.Format("<td class='text-left'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE.ToString()));
                                    sb.AppendLine(string.Format("<th width=23%></th>"));

                                    sb.AppendLine("</tr>");
                                }


                                //sb.AppendLine("</tr>");

                            }
                            else
                            {
                                sb.AppendLine(string.Format("<tr data_code='{0}'>", lr.RUBR_ETAT_CODE.ToString().Trim()));


                                sb.AppendLine(string.Format("<td class='text-left'>{0}</td>", lr.RUBR_ETAT_LIBELLE.ToString()));
                                sb.AppendLine(string.Format("<th width=23%></th>"));

                                sb.AppendLine("</tr>");

                            }
                        }
                    }

                    sb.AppendLine("</tbody>");
                    sb.AppendLine("</table>");

                    DIVtotauxActif.Visible = true;
                    DIVtotauxPassif.Visible = true;
                }



                sb.AppendLine("</div>");
            }
            else
            {
                if (DdlRubrique.Text != "Bilan")
                {
                    DIVtotauxActif.Visible = false;
                    DIVtotauxPassif.Visible = false;
                    DivecartsActifPassif.Visible = false;
                }

            }
            ListDFinanciers.InnerHtml = sb.ToString();
        }

        public void afficheTableauSynthetiqueSMT()
        {

            //string[]  // TabLOTA = null;

            // TabLOTA = new string[] { String.Empty };

            // string[]  // TabLOTP = null;

            // TabLOTP = new string[] { String.Empty };
            if (Session["id_dossier"] == null) Response.Redirect("~/Scoring/Connexion.aspx");

            var idDossier = Session["id_dossier"].ToString();
            Session.Add("id_dossier", idDossier);
            if (DdlRubrique.Text == "Tableau synthétique des SSG")
            {
                Type_anafi = "BN";
                Div1.Visible = true;
                Div2.Visible = true;
                var liste_annee = service.AnafiAfficheLiasse(7, idDossier, "", "SMT");
                var nombre_annee = service.AnafiAfficheLiasse(8, idDossier, "", "SMT");

                if (liste_annee.Count != 0)
                {
                    sb.AppendLine("<div class='col-lg-12 col-sm-12 col-md-12' >");
                    sb.AppendLine("<table id='' class='table table-hover table-bordered text-center'>");
                    sb.AppendLine("<thead class='table-heigth'>");
                    sb.AppendLine(string.Format("<tr><th>Libellés</th>"));

                    if (liste_annee.Count > 3)
                    {
                        int j = 0;
                        int v = 0;
                        int i = 0;
                        v = Convert.ToInt32(liste_annee.Count) - 3;
                        foreach (var lr in liste_annee)
                        {
                            j++;
                            if (v < j)
                            {
                                if (i < Convert.ToInt32(liste_annee.Count))
                                {
                                    sb.AppendLine(string.Format("<th>{0}</th>", lr.ANNEE_DETAIL));
                                    //TabLOT[i] = lr.ANNEE_DETAIL;
                                }
                            }

                            i++;
                        }
                    }
                    else
                    {
                        int i = 0;
                        foreach (var lr in liste_annee)
                        {

                            if (i < Convert.ToInt32(liste_annee.Count))
                            {
                                sb.AppendLine(string.Format("<th>{0}</th>", lr.ANNEE_DETAIL));
                                //TabLOT[i] = lr.ANNEE_DETAIL;
                            }
                            i++;
                        }
                    }

                    sb.AppendLine("</thead>");
                    sb.AppendLine("<tbody>");

                    var liste_libelle = service.AnafiAfficheLiasse(0, "", "", "CR");

                    foreach (var lr in liste_libelle)
                    {
                        if (lr.RUBR_ETAT_CODE.Trim() == "C019" || lr.RUBR_ETAT_CODE.Trim() == "C029" || lr.RUBR_ETAT_CODE.Trim() == "C039" || lr.RUBR_ETAT_CODE.Trim() == "C049" || lr.RUBR_ETAT_CODE.Trim() == "C059" || lr.RUBR_ETAT_CODE.Trim() == "C069" || lr.RUBR_ETAT_CODE.Trim() == "C079" || lr.RUBR_ETAT_CODE.Trim() == "C089" || lr.RUBR_ETAT_CODE.Trim() == "C099" || lr.RUBR_ETAT_CODE.Trim() == "C109" || lr.RUBR_ETAT_CODE.Trim() == "C119")
                        {
                            sb.AppendLine(string.Format("<tr data_code='{0}' style='background-color:#ddd'>", lr.RUBR_ETAT_CODE.ToString().Trim()));

                            sb.AppendLine(string.Format("<td class='text-left'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE));
                            // TabLOTA = new string[Convert.ToInt32(liste_annee.Count)];
                            int p = 0;
                            var liste_valeur = service.AnafiAfficheLiasse(4, idDossier, lr.RUBR_ETAT_CODE.ToString().Trim(), "SMT");
                            int j = 0;
                            int v = 0;
                            v = Convert.ToInt32(liste_valeur.Count) - 3;
                            foreach (var l in liste_valeur)
                            {

                                if (liste_valeur.Count > 3)
                                {
                                    j++;
                                    if (v < j)
                                    {
                                        if (l.TYPE_ANAFI_A.Trim() == "SMT")
                                        {
                                            sb.AppendLine(string.Format("<td class='text-right'><strong>{0}</strong></td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_TS_DETAIL))));
                                            // TabLOTA[p] = l.VALEUR_RAT_AFF_DETAIL.ToString();
                                            p++;
                                        }
                                    }

                                }
                                else
                                {
                                    if (l.TYPE_ANAFI_A.Trim() == "SMT")
                                    {
                                        sb.AppendLine(string.Format("<td class='text-right'><strong>{0}</strong></td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_TS_DETAIL))));
                                        // TabLOTA[p] = l.VALEUR_RAT_AFF_DETAIL.ToString();
                                        p++;
                                    }
                                }
                            }


                            sb.AppendLine("</tr>");
                        }
                        else
                        {
                            sb.AppendLine(string.Format("<tr data_code='{0}'>", lr.RUBR_ETAT_CODE.ToString().Trim()));

                            sb.AppendLine(string.Format("<td class='text-left'>{0}</td>", lr.RUBR_ETAT_LIBELLE));
                            // TabLOTA = new string[Convert.ToInt32(liste_annee.Count)];
                            int p = 0;
                            var liste_valeur = service.AnafiAfficheLiasse(4, idDossier, lr.RUBR_ETAT_CODE.ToString().Trim(), "SMT");

                            int j = 0;
                            int v = 0;
                            v = Convert.ToInt32(liste_valeur.Count) - 3;
                            foreach (var l in liste_valeur)
                            {

                                if (liste_valeur.Count > 3)
                                {
                                    j++;
                                    if (v < j)
                                    {
                                        if (l.TYPE_ANAFI_A.Trim() == "SMT")
                                        {
                                            sb.AppendLine(string.Format("<td class='text-right'>{0}</td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_TS_DETAIL))));
                                            // TabLOTA[p] = l.VALEUR_RAT_AFF_DETAIL.ToString();
                                            p++;
                                        }
                                    }

                                }
                                else
                                {
                                    if (l.TYPE_ANAFI_A.Trim() == "SMT")
                                    {
                                        sb.AppendLine(string.Format("<td class='text-right'>{0}</td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_TS_DETAIL))));
                                        // TabLOTA[p] = l.VALEUR_RAT_AFF_DETAIL.ToString();
                                        p++;
                                    }
                                }
                            }


                            sb.AppendLine("</tr>");
                        }

                    }

                    sb.AppendLine("</tbody>");
                    sb.AppendLine("</table>");
                }
                else
                {
                    sb.AppendLine("<div class='col-lg-12 col-sm-12 col-md-12' >");
                    sb.AppendLine("<table id='' class='table table-hover table-bordered text-center'>");
                    sb.AppendLine("<thead class='table-heigth'>");
                    sb.AppendLine(string.Format("<tr><th>Libellé</th>"));
                    sb.AppendLine(string.Format("<th width=23%></th>"));

                    sb.AppendLine("</thead>");
                    sb.AppendLine("<tbody>");

                    var liste_libelle = service.AnafiAfficheLiasse(0, "", "", "CR");

                    foreach (var lr in liste_libelle)
                    {


                        if (lr.RUBR_ETAT_CODE.Trim() == "C019" || lr.RUBR_ETAT_CODE.Trim() == "C029" || lr.RUBR_ETAT_CODE.Trim() == "C039" || lr.RUBR_ETAT_CODE.Trim() == "C049" || lr.RUBR_ETAT_CODE.Trim() == "C059" || lr.RUBR_ETAT_CODE.Trim() == "C069" || lr.RUBR_ETAT_CODE.Trim() == "C079" || lr.RUBR_ETAT_CODE.Trim() == "C089" || lr.RUBR_ETAT_CODE.Trim() == "C099" || lr.RUBR_ETAT_CODE.Trim() == "C109" || lr.RUBR_ETAT_CODE.Trim() == "C119")
                        {
                            sb.AppendLine(string.Format("<tr data_code='{0}' style='background-color:#ddd'>", lr.RUBR_ETAT_CODE.ToString().Trim()));
                            sb.AppendLine(string.Format("<td class='text-left'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE));
                            sb.AppendLine(string.Format("<td ></td >"));
                        }
                        else
                        {
                            sb.AppendLine(string.Format("<tr data_code='{0}'>", lr.RUBR_ETAT_CODE.ToString().Trim()));
                            sb.AppendLine(string.Format("<td class='text-left'>{0}</td>", lr.RUBR_ETAT_LIBELLE));
                            sb.AppendLine(string.Format("<td ></td >"));
                        }



                        sb.AppendLine("</tr>");
                    }

                    sb.AppendLine("</tbody>");
                    sb.AppendLine("</table>");
                }
                sb.AppendLine("</div>");


            }
            else
            {
                //DIVtotauxActif.Visible = false;
                //DIVtotauxPassif.Visible = false;
                //DivecartsActifPassif.Visible = false;
            }
            ListDFinanciers.InnerHtml = sb.ToString();
        }

        public void afficheTDRSMT()
        {
            //string[]  // TabLOTA = null;

            // TabLOTA = new string[] { String.Empty };
            if (Session["id_dossier"] == null) Response.Redirect("~/Scoring/Connexion.aspx");

            var idDossier = Session["id_dossier"].ToString();
            Session.Add("id_dossier", idDossier);
            if (DdlRubrique.Text == "Tableau des documents résumés")
            {
                Type_anafi = "BN";
                Div1.Visible = true;
                Div2.Visible = true;
                var liste_annee = service.AnafiAfficheLiasse(7, idDossier, "", "SMT");
                var nombre_annee = service.AnafiAfficheLiasse(8, idDossier, "", "SMT");

                if (liste_annee.Count != 0)
                {
                    sb.AppendLine("<div class='col-lg-12 col-sm-12 col-md-12' >");
                    sb.AppendLine("<table id='' class='table table-hover table-bordered text-center'>");
                    sb.AppendLine("<thead class='table-heigth'>");
                    sb.AppendLine(string.Format("<tr><th>Valeurs structurelles</th>"));

                    if (liste_annee.Count > 3)
                    {
                        int j = 0;
                        int v = 0;
                        int i = 0;
                        v = Convert.ToInt32(liste_annee.Count) - 3;
                        foreach (var lr in liste_annee)
                        {
                            j++;
                            if (v < j)
                            {
                                if (i < Convert.ToInt32(liste_annee.Count))
                                {
                                    sb.AppendLine(string.Format("<th>{0}</th>", lr.ANNEE_DETAIL));
                                    //TabLOT[i] = lr.ANNEE_DETAIL;
                                }
                            }

                            i++;
                        }
                    }
                    else
                    {
                        int i = 0;
                        foreach (var lr in liste_annee)
                        {

                            if (i < Convert.ToInt32(liste_annee.Count))
                            {
                                sb.AppendLine(string.Format("<th>{0}</th>", lr.ANNEE_DETAIL));
                                //TabLOT[i] = lr.ANNEE_DETAIL;
                            }
                            i++;
                        }
                    }


                    sb.AppendLine("</thead>");
                    sb.AppendLine("<tbody>");

                    var liste_libelle = service.AnafiAfficheLiasse(0, "", "", "TDR");

                    foreach (var lr in liste_libelle)
                    {
                        if (lr.RUBR_ETAT_CODE.Trim() == "BI40" || lr.RUBR_ETAT_CODE.Trim() == "BI41" || lr.RUBR_ETAT_CODE.Trim() == "BI42" || lr.RUBR_ETAT_CODE.Trim() == "BI43" || lr.RUBR_ETAT_CODE.Trim() == "BJ00" || lr.RUBR_ETAT_CODE.Trim() == "BJ1" || lr.RUBR_ETAT_CODE.Trim() == "BI6A" || lr.RUBR_ETAT_CODE.Trim() == "BK1" || lr.RUBR_ETAT_CODE.Trim() == "TN1" || lr.RUBR_ETAT_CODE.Trim() == "TN20" || lr.RUBR_ETAT_CODE.Trim() == "TN21" || lr.RUBR_ETAT_CODE.Trim() == "ZN2" || lr.RUBR_ETAT_CODE.Trim() == "BI2A" || lr.RUBR_ETAT_CODE.Trim() == "BI3A" || lr.RUBR_ETAT_CODE.Trim() == "BI7A")
                        {
                            if (lr.RUBR_ETAT_CODE.Trim() == "BJ1" || lr.RUBR_ETAT_CODE.Trim() == "BK1" || lr.RUBR_ETAT_CODE.Trim() == "TN1" || lr.RUBR_ETAT_CODE.Trim() == "ZN2")
                            {
                                sb.AppendLine(string.Format("<tr data_code='{0}' style='background-color:#ddd'>", lr.RUBR_ETAT_CODE.ToString().Trim()));

                                sb.AppendLine(string.Format("<td class='text-left'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE));
                                // TabLOTA = new string[Convert.ToInt32(liste_annee.Count)];
                                int p = 0;
                                var liste_valeur = service.AnafiAfficheLiasse(5, idDossier, lr.RUBR_ETAT_CODE.ToString().Trim(), "SMT");

                                int j = 0;
                                int v = 0;
                                v = Convert.ToInt32(liste_valeur.Count) - 3;
                                foreach (var l in liste_valeur)
                                {

                                    if (liste_valeur.Count > 3)
                                    {
                                        j++;
                                        if (v < j)
                                        {
                                            if (l.TYPE_ANAFI_A.Trim() == "SMT")
                                            {
                                                sb.AppendLine(string.Format("<td class='text-right'><strong>{0}</strong></td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_TDR_DETAIL))));
                                                // TabLOTA[p] = l.VALEUR_TDR_DETAIL.ToString();
                                                p++;
                                            }
                                        }

                                    }
                                    else
                                    {
                                        if (l.TYPE_ANAFI_A.Trim() == "SMT")
                                        {
                                            sb.AppendLine(string.Format("<td class='text-right'><strong>{0}</strong></td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_TDR_DETAIL))));
                                            // TabLOTA[p] = l.VALEUR_TDR_DETAIL.ToString();
                                            p++;
                                        }
                                    }
                                }


                                sb.AppendLine("</tr>");
                            }
                            else
                            {
                                sb.AppendLine(string.Format("<tr data_code='{0}'>", lr.RUBR_ETAT_CODE.ToString().Trim()));

                                sb.AppendLine(string.Format("<td class='text-left'>{0}</td>", lr.RUBR_ETAT_LIBELLE));
                                // TabLOTA = new string[Convert.ToInt32(liste_annee.Count)];
                                int p = 0;
                                var liste_valeur = service.AnafiAfficheLiasse(5, idDossier, lr.RUBR_ETAT_CODE.ToString().Trim(), "SMT");

                                int j = 0;
                                int v = 0;
                                v = Convert.ToInt32(liste_valeur.Count) - 3;
                                foreach (var l in liste_valeur)
                                {

                                    if (liste_valeur.Count > 3)
                                    {
                                        j++;
                                        if (v < j)
                                        {
                                            if (l.TYPE_ANAFI_A.Trim() == "SMT")
                                            {
                                                sb.AppendLine(string.Format("<td class='text-right'>{0}</td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_TDR_DETAIL))));
                                                // TabLOTA[p] = l.VALEUR_TDR_DETAIL.ToString();
                                                p++;
                                            }
                                        }

                                    }
                                    else
                                    {
                                        if (l.TYPE_ANAFI_A.Trim() == "SMT")
                                        {
                                            sb.AppendLine(string.Format("<td class='text-right'>{0}</td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_TDR_DETAIL))));
                                            // TabLOTA[p] = l.VALEUR_TDR_DETAIL.ToString();
                                            p++;
                                        }
                                    }
                                }

                                sb.AppendLine("</tr>");
                            }
                        }
                        else
                        {
                            if (lr.RUBR_ETAT_CODE.Trim() == "ZN3")
                            {
                                sb.AppendLine(string.Format("<tr style='background-color:transparent; border:none;'>"));
                                sb.AppendLine(string.Format("<td class='text-left' style='background-color:transparent; border:none;'><strong>RATIOS</strong></td>"));
                                sb.AppendLine("</tr>");
                            }
                            else
                            {
                                sb.AppendLine(string.Format("<tr data_code='{0}'>", lr.RUBR_ETAT_CODE.ToString().Trim()));

                                sb.AppendLine(string.Format("<td class='text-left'>{0}</td>", lr.RUBR_ETAT_LIBELLE));
                                // TabLOTA = new string[Convert.ToInt32(liste_annee.Count)];
                                int p = 0;
                                var liste_valeur = service.AnafiAfficheLiasse(5, idDossier, lr.RUBR_ETAT_CODE.ToString().Trim(), "SMT");

                                int j = 0;
                                int v = 0;
                                v = Convert.ToInt32(liste_valeur.Count) - 3;
                                foreach (var l in liste_valeur)
                                {

                                    if (liste_valeur.Count > 3)
                                    {
                                        j++;
                                        if (v < j)
                                        {
                                            if (l.TYPE_ANAFI_A.Trim() == "SMT")
                                            {
                                                sb.AppendLine(string.Format("<td class='text-right'>{0}</td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_TDR_DETAIL))));
                                                // TabLOTA[p] = l.VALEUR_TDR_DETAIL.ToString();
                                                p++;
                                            }
                                        }

                                    }
                                    else
                                    {
                                        if (l.TYPE_ANAFI_A.Trim() == "SMT")
                                        {
                                            sb.AppendLine(string.Format("<td class='text-right'>{0}</td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_TDR_DETAIL))));
                                            // TabLOTA[p] = l.VALEUR_TDR_DETAIL.ToString();
                                            p++;
                                        }
                                    }
                                }

                                sb.AppendLine("</tr>");
                            }
                        }



                    }

                    sb.AppendLine("</tbody>");
                    sb.AppendLine("</table>");
                }
                else
                {
                    sb.AppendLine("<div class='col-lg-12 col-sm-12 col-md-12' >");
                    sb.AppendLine("<table id='' class='table table-hover table-bordered text-center'>");
                    sb.AppendLine("<thead class='table-heigth'>");
                    sb.AppendLine(string.Format("<tr><th>Valeurs structurelles</th>"));
                    sb.AppendLine(string.Format("<th width=23%></th></tr>"));

                    sb.AppendLine("</thead>");
                    sb.AppendLine("<tbody>");

                    var liste_libelle = service.AnafiAfficheLiasse(0, "", "", "TDR");

                    foreach (var lr in liste_libelle)
                    {
                        if (lr.RUBR_ETAT_CODE.Trim() == "BI40" || lr.RUBR_ETAT_CODE.Trim() == "BI41" || lr.RUBR_ETAT_CODE.Trim() == "BI42" || lr.RUBR_ETAT_CODE.Trim() == "BI43" || lr.RUBR_ETAT_CODE.Trim() == "BJ00" || lr.RUBR_ETAT_CODE.Trim() == "BJ1" || lr.RUBR_ETAT_CODE.Trim() == "BI6A" || lr.RUBR_ETAT_CODE.Trim() == "BK1" || lr.RUBR_ETAT_CODE.Trim() == "TN1" || lr.RUBR_ETAT_CODE.Trim() == "TN20" || lr.RUBR_ETAT_CODE.Trim() == "TN21" || lr.RUBR_ETAT_CODE.Trim() == "ZN2" || lr.RUBR_ETAT_CODE.Trim() == "BI2A" || lr.RUBR_ETAT_CODE.Trim() == "BI3A" || lr.RUBR_ETAT_CODE.Trim() == "BI7A")
                        {
                            if (lr.RUBR_ETAT_CODE.Trim() == "BJ1" || lr.RUBR_ETAT_CODE.Trim() == "BK1" || lr.RUBR_ETAT_CODE.Trim() == "TN1" || lr.RUBR_ETAT_CODE.Trim() == "ZN2")
                            {
                                sb.AppendLine(string.Format("<tr data_code='{0}' style='background-color:#ddd'>", lr.RUBR_ETAT_CODE.ToString().Trim()));

                                sb.AppendLine(string.Format("<td class='text-left'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE));
                                sb.AppendLine(string.Format("<td></td>"));

                                sb.AppendLine("</tr>");
                            }
                            else
                            {
                                sb.AppendLine(string.Format("<tr data_code='{0}'>", lr.RUBR_ETAT_CODE.ToString().Trim()));

                                sb.AppendLine(string.Format("<td class='text-left'>{0}</td>", lr.RUBR_ETAT_LIBELLE));
                                sb.AppendLine(string.Format("<td></td>"));

                                sb.AppendLine("</tr>");
                            }
                        }
                        else
                        {
                            if (lr.RUBR_ETAT_CODE.Trim() == "ZN3")
                            {
                                sb.AppendLine(string.Format("<tr style='background-color:transparent; border:none;'>"));
                                sb.AppendLine(string.Format("<td class='text-left' style='background-color:transparent; border:none;'><strong>RATIOS</strong></td>"));
                                sb.AppendLine("</tr>");
                            }
                            else
                            {
                                sb.AppendLine(string.Format("<tr data_code='{0}'>", lr.RUBR_ETAT_CODE.ToString().Trim()));

                                sb.AppendLine(string.Format("<td class='text-left'>{0}</td>", lr.RUBR_ETAT_LIBELLE));
                                sb.AppendLine(string.Format("<td></td>"));

                                sb.AppendLine("</tr>");
                            }
                        }



                    }

                    sb.AppendLine("</tbody>");
                    sb.AppendLine("</table>");


                }
                sb.AppendLine("</div>");


            }
            else
            {
                //DIVtotauxActif.Visible = false;
                //DIVtotauxPassif.Visible = false;
                //DivecartsActifPassif.Visible = false;
            }
            ListDFinanciers.InnerHtml = sb.ToString();

        }

        public void afficherRatioSMT()
        {

            //string[]  // TabLOTA = null;

            // TabLOTA = new string[] { String.Empty };

            // string[]  // TabLOTP = null;

            // TabLOTP = new string[] { String.Empty };
            if (Session["id_dossier"] == null) Response.Redirect("~/Scoring/Connexion.aspx");

            var idDossier = Session["id_dossier"].ToString();
            Session.Add("id_dossier", idDossier);
            if (DdlRubrique.Text == "Tableau des scores")
            {
                Type_anafi = "BN";
                Div1.Visible = true;
                Div2.Visible = true;
                var liste_annee = service.AnafiAfficheLiasse(7, idDossier, "", "SMT");
                var nombre_annee = service.AnafiAfficheLiasse(8, idDossier, "", "SMT");

                if (liste_annee.Count != 0)
                {
                    sb.AppendLine("<div class='col-lg-12 col-sm-12 col-md-12' >");
                    sb.AppendLine("<table id='' class='table table-hover table-bordered text-center'>");
                    sb.AppendLine("<thead class='table-heigth'>");
                    sb.AppendLine(string.Format("<tr><th>Ratios</th>"));

                    if (liste_annee.Count > 3)
                    {
                        int j = 0;
                        int v = 0;
                        int i = 0;
                        v = Convert.ToInt32(liste_annee.Count) - 3;
                        foreach (var lr in liste_annee)
                        {
                            j++;
                            if (v < j)
                            {
                                if (i < Convert.ToInt32(liste_annee.Count))
                                {
                                    sb.AppendLine(string.Format("<th>{0}</th>", lr.ANNEE_DETAIL));
                                    //TabLOT[i] = lr.ANNEE_DETAIL;
                                }
                            }

                            i++;
                        }
                    }
                    else
                    {
                        int i = 0;
                        foreach (var lr in liste_annee)
                        {

                            if (i < Convert.ToInt32(liste_annee.Count))
                            {
                                sb.AppendLine(string.Format("<th>{0}</th>", lr.ANNEE_DETAIL));
                                //TabLOT[i] = lr.ANNEE_DETAIL;
                            }
                            i++;
                        }
                    }

                    sb.AppendLine("</thead>");
                    sb.AppendLine("<tbody>");

                    var liste_libelle = service.AnafiAfficheLiasse(0, "", "", "RAT");

                    foreach (var lr in liste_libelle)
                    {

                        sb.AppendLine(string.Format("<tr>"));

                        sb.AppendLine(string.Format("<td class='text-left'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE));
                        // TabLOTA = new string[Convert.ToInt32(liste_annee.Count)];
                        int p = 0;
                        var liste_valeur = service.AnafiAfficheLiasse(6, idDossier, lr.RUBR_ETAT_CODE.ToString().Trim(), "SMT");

                        int j = 0;
                        int v = 0;
                        v = Convert.ToInt32(liste_valeur.Count) - 3;
                        foreach (var l in liste_valeur)
                        {

                            if (liste_valeur.Count > 3)
                            {
                                j++;
                                if (v < j)
                                {
                                    if (l.TYPE_ANAFI_A.Trim() == "SMT")
                                    {
                                        sb.AppendLine(string.Format("<td class='text-right'><strong>{0}</strong></td>", Convert.ToDecimal(l.VALEUR_RAT_AFF_DETAIL).ToString("#,##0.##")));
                                        // TabLOTA[p] = l.VALEUR_RAT_AFF_DETAIL.ToString();
                                        p++;
                                    }
                                }

                            }
                            else
                            {
                                if (l.TYPE_ANAFI_A.Trim() == "SMT")
                                {
                                    sb.AppendLine(string.Format("<td class='text-right'><strong>{0}</strong></td>", Convert.ToDecimal(l.VALEUR_RAT_AFF_DETAIL).ToString("#,##0.##")));
                                    // TabLOTA[p] = l.VALEUR_RAT_AFF_DETAIL.ToString();
                                    p++;
                                }
                            }
                        }


                        sb.AppendLine("</tr>");
                    }

                    sb.AppendLine("</tbody>");
                    sb.AppendLine("</table>");
                }
                else
                {
                    sb.AppendLine("<div class='col-lg-12 col-sm-12 col-md-12' >");
                    sb.AppendLine("<table id='' class='table table-hover table-bordered text-center'>");
                    sb.AppendLine("<thead class='table-heigth'>");
                    sb.AppendLine(string.Format("<tr><th>Ratios</th>"));
                    sb.AppendLine(string.Format("<th width=23%></th>"));

                    sb.AppendLine("</thead>");
                    sb.AppendLine("<tbody>");

                    var liste_libelle = service.AnafiAfficheLiasse(0, "", "", "RAT");

                    foreach (var lr in liste_libelle)
                    {

                        sb.AppendLine(string.Format("<tr>"));

                        sb.AppendLine(string.Format("<td class='text-left'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE));
                        sb.AppendLine(string.Format("<td ></td >"));

                        sb.AppendLine("</tr>");
                    }

                    sb.AppendLine("</tbody>");
                    sb.AppendLine("</table>");
                }
                sb.AppendLine("</div>");


            }
            else
            {
                //DIVtotauxActif.Visible = false;
                //DIVtotauxPassif.Visible = false;
                //DivecartsActifPassif.Visible = false;
            }
            ListDFinanciers.InnerHtml = sb.ToString();
        }

        public void afficheBilanBN()
        {

            if (Session["id_dossier"] == null) Response.Redirect("~/Scoring/Connexion.aspx");

            var idDossier = Session["id_dossier"].ToString();
            Session.Add("id_dossier", idDossier);
            if (DdlRubrique.Text == "Bilan")
            {
                Type_anafi = "BN";
                Div1.Visible = true;
                Div2.Visible = true;

                CompteResult.Visible = false;
                divCharge.Visible = false;
                divProduit.Visible = false;

                var liste_annee = service.AnafiAfficheLiasse(7, idDossier, "", "SN");
                var nombre_annee = service.AnafiAfficheLiasse(8, idDossier, "", "SN");

                if (liste_annee.Count != 0)
                {
                    sb.AppendLine("<div class='col-lg-6 col-sm-6 col-md-6' >");
                    sb.AppendLine("<table id='' class='table table-hover table-bordered text-center'>");
                    sb.AppendLine("<thead class='table-heigth'>");
                    sb.AppendLine(string.Format("<tr><th>Actifs</th>"));
                    if (liste_annee.Count > 3)
                    {
                        int j = 0;
                        int v = 0;
                        int i = 0;
                        v = Convert.ToInt32(liste_annee.Count) - 3;
                        foreach (var lr in liste_annee)
                        {
                            j++;
                            if (v < j)
                            {
                                if (i < Convert.ToInt32(liste_annee.Count))
                                {
                                    sb.AppendLine(string.Format("<th onclick='transfertval($(this))' width=15%>{0}</th>", lr.ANNEE_DETAIL));
                                    //TabLOT[i] = lr.ANNEE_DETAIL;
                                }
                            }

                            i++;
                        }
                    }
                    else
                    {
                        int i = 0;
                        foreach (var lr in liste_annee)
                        {

                            if (i < Convert.ToInt32(liste_annee.Count))
                            {
                                sb.AppendLine(string.Format("<th onclick='transfertval($(this))' width=15%>{0}</th>", lr.ANNEE_DETAIL));
                                //TabLOT[i] = lr.ANNEE_DETAIL;
                            }
                            i++;
                        }
                    }


                    sb.AppendLine("</thead>");
                    sb.AppendLine("<tbody>");

                    var liste_libelle = service.AnafiAfficheLiasse(0, "", "", "BIN");

                    sbt.AppendLine(string.Format("<table id='BA' class='table-hover table table-bordered text-center'>"));

                    foreach (var lr in liste_libelle)
                    {
                        if (lr.RUBR_ETAT_CODE.ToString().Trim() == "BAX12" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BA12A" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BA13A"
                            || lr.RUBR_ETAT_CODE.ToString().Trim() == "BA15A" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BAX53" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BAX54" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BA1A"
                            || lr.RUBR_ETAT_CODE.ToString().Trim() == "BA22A" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BA2X9" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BA2A" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BA3A"
                            || lr.RUBR_ETAT_CODE.ToString().Trim() == "BA4A" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BAX11" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BA11B" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BAX13"
                            || lr.RUBR_ETAT_CODE.ToString().Trim() == "BA21A" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BA2X4" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BA14A" )
                        {
                        }
                        else{
                            if (lr.RUBR_ETAT_CODE.ToString().Trim() == "BAX21" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BAX22" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BAX23"
                            || lr.RUBR_ETAT_CODE.ToString().Trim() == "BAX24" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BAX31" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BAX32" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BAX35"
                            || lr.RUBR_ETAT_CODE.ToString().Trim() == "BA22A" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BAX51" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BAX52" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BA2X2"
                            || lr.RUBR_ETAT_CODE.ToString().Trim() == "BA2X3" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BA2X8" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BA2X6" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BA2X7"
                            || lr.RUBR_ETAT_CODE.ToString().Trim() == "BA3X1" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BA32A" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BA33A"
                             || lr.RUBR_ETAT_CODE.ToString().Trim() == "BA2X5" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BAX34" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BAX33" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BXA")
                           {
                               if (lr.RUBR_ETAT_CODE.ToString().Trim() == "BXA")
                               {
                                  
                                   sbt.AppendLine(string.Format("<tr style='background-color:rgba(210, 210, 210, 1);'>"));

                                   sbt.AppendLine(string.Format("<td class='text-left'><strong>&nbsp;&nbsp;&nbsp;<i class=\"glyphicon glyphicon-share-alt gly-flip-vertical \"></i><i style=\"color:#69a8f4\">{0}</i></strong></td>", lr.RUBR_ETAT_LIBELLE));
                                   // TabLOTA = new string[Convert.ToInt32(liste_annee.Count)];
                                   int p = 0;
                                   var liste_valeur3 = service.AnafiAfficheLiasse(9, idDossier, lr.RUBR_ETAT_CODE.ToString().Trim(), "SN");

                                   int j = 0;
                                   int v = 0;
                                   v = Convert.ToInt32(liste_valeur3.Count) - 3;
                                   foreach (var l in liste_valeur3)
                                   {

                                       if (liste_valeur3.Count > 3)
                                       {
                                           j++;
                                           if (v < j)
                                           {
                                               sbt.AppendLine(string.Format("<td class='text-right' width=15%><i style=\"color:#69a8f4\">{0}</i></td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_B_DETAIL))));
                                               // TabLOTA[p] = l.VALEUR_B_DETAIL.ToString();
                                               p++;
                                           }

                                       }
                                       else
                                       {
                                           sbt.AppendLine(string.Format("<td class='text-right' width=15%><i style=\"color:#69a8f4\">{0}</i></td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_B_DETAIL))));
                                           // TabLOTA[p] = l.VALEUR_B_DETAIL.ToString();
                                           p++;
                                       }
                                   }
                                   sbt.AppendLine("</tr>");
                                   //sbt.AppendLine("</table>");
                                   //DIVtotauxActif.InnerHtml = sbt.ToString();
                               }
                               else
                               {
                                   sb.AppendLine(string.Format("<tr data_code='{0}'>", lr.RUBR_ETAT_CODE.ToString().Trim()));
                                   // sb.AppendLine(string.Format("<td class='text-left'>{0}</td>", lr.CODE_POSTE.ToString()));
                                   sb.AppendLine(string.Format("<td class='text-left'>&nbsp;&nbsp;&nbsp;<i class=\"glyphicon glyphicon-share-alt gly-flip-vertical \"></i><i style=\"color:#69a8f4\">{0}</i></td>", lr.RUBR_ETAT_LIBELLE.ToString()));

                                   var liste_valeur2 = service.AnafiAfficheLiasse(9, idDossier, lr.RUBR_ETAT_CODE.ToString().Trim(), "SN");

                                   int j = 0;
                                   int v = 0;
                                   v = Convert.ToInt32(liste_valeur2.Count) - 3;
                                   foreach (var l in liste_valeur2)
                                   {

                                       if (liste_valeur2.Count > 3)
                                       {
                                           j++;
                                           if (v < j)
                                           {
                                               if (l.RUBR_ETAT_LIBELLE.Trim().Length <= 1)
                                               {
                                                   sb.AppendLine(string.Format("<td class='text-right'></td>"));
                                               }
                                               else
                                               {
                                                   sb.AppendLine(string.Format("<td class='text-right {1}'><i style=\"color:#69a8f4\">{0}</i></td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_B_DETAIL)), l.ANNEE_B_DETAIL.Replace("/", "")));
                                               }
                                           }

                                       }
                                       else
                                       {
                                           if (l.RUBR_ETAT_LIBELLE.Trim().Length <= 1)
                                           {
                                               sb.AppendLine(string.Format("<td class='text-right'></td>"));
                                           }
                                           else
                                           {
                                               sb.AppendLine(string.Format("<td class='text-right {1}'><i style=\"color:#69a8f4\">{0}</i></td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_B_DETAIL)), l.ANNEE_B_DETAIL.Replace("/", "")));
                                           }
                                       }
                                   }

                                   sb.AppendLine("</tr>");
                               }
                                          
                                        
                                       
                        } 
                            else

                            {

                                string SENS = "";
                                if (lr.RUBR_ETAT_CODE.Trim().Length > 2)
                                {
                                    SENS = lr.RUBR_ETAT_CODE.ToString().Trim().Substring(0, 3);
                                }

                                if (SENS == "BA1" || SENS == "BA2" || SENS == "BA3" || SENS == "BA4" || SENS == "BAX")
                                {
                                    if (lr.RUBR_ETAT_CODE.ToString().Trim().Length == 3)
                                    {
                                        if (lr.RUBR_ETAT_CODE.ToString().Trim() == "BA4")
                                        {
                                            sb.AppendLine(string.Format("<tr data_code='{0}'>", lr.RUBR_ETAT_CODE.ToString().Trim()));
                                            // sb.AppendLine(string.Format("<td class='text-left'>{0}</td>", lr.CODE_POSTE.ToString()));
                                            sb.AppendLine(string.Format("<td class='text-left'>{0}</td>", lr.RUBR_ETAT_LIBELLE.ToString()));

                                            var liste_valeur2 = service.AnafiAfficheLiasse(9, idDossier, lr.RUBR_ETAT_CODE.ToString().Trim(), "SN");

                                            int j = 0;
                                            int v = 0;
                                            v = Convert.ToInt32(liste_valeur2.Count) - 3;
                                            foreach (var l in liste_valeur2)
                                            {

                                                if (liste_valeur2.Count > 3)
                                                {
                                                    j++;
                                                    if (v < j)
                                                    {
                                                        if (l.RUBR_ETAT_LIBELLE.Trim().Length <= 1)
                                                        {
                                                            sb.AppendLine(string.Format("<td class='text-right'></td>"));
                                                        }
                                                        else
                                                        {
                                                            sb.AppendLine(string.Format("<td class='text-right {1}'>{0}</td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_B_DETAIL)), l.ANNEE_B_DETAIL.Replace("/", "")));
                                                        }
                                                    }

                                                }
                                                else
                                                {
                                                    if (l.RUBR_ETAT_LIBELLE.Trim().Length <= 1)
                                                    {
                                                        sb.AppendLine(string.Format("<td class='text-right'></td>"));
                                                    }
                                                    else
                                                    {
                                                        sb.AppendLine(string.Format("<td class='text-right {1}'>{0}</td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_B_DETAIL)), l.ANNEE_B_DETAIL.Replace("/", "")));
                                                    }
                                                }
                                            }

                                            sb.AppendLine("</tr>");
                                        }
                                        else
                                        {

                                            sb.AppendLine(string.Format("<tr data_code='{0}' style='background-color:#ddd'>", lr.RUBR_ETAT_CODE.ToString().Trim()));
                                            // sb.AppendLine(string.Format("<td class='text-left'>{0}</td>", lr.CODE_POSTE.ToString()));


                                            if (lr.RUBR_ETAT_LIBELLE.Trim().Length <= 1)
                                            {
                                                sb.AppendLine(string.Format("<td class='text-left' style='color:#fff'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE.ToString()));
                                            }
                                            else
                                            {
                                                sb.AppendLine(string.Format("<td class='text-left'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE.ToString()));
                                            }
                                            var liste_valeur1 = service.AnafiAfficheLiasse(9, idDossier, lr.RUBR_ETAT_CODE.ToString().Trim(), "SN");
                                            int j = 0;
                                            int v = 0;
                                            v = Convert.ToInt32(liste_valeur1.Count) - 3;
                                            foreach (var l in liste_valeur1)
                                            {

                                                if (liste_valeur1.Count > 3)
                                                {
                                                    j++;
                                                    if (v < j)
                                                    {
                                                        if (l.RUBR_ETAT_LIBELLE.Trim().Length <= 1)
                                                        {
                                                            sb.AppendLine(string.Format("<td class='text-right'></td>"));
                                                        }
                                                        else
                                                        {
                                                            sb.AppendLine(string.Format("<td class='text-right {1}'><strong>{0}</strong></td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_B_DETAIL)), l.ANNEE_B_DETAIL.Replace("/", "")));
                                                        }
                                                    }

                                                }
                                                else
                                                {
                                                    if (l.RUBR_ETAT_LIBELLE.Trim().Length <= 1)
                                                    {
                                                        sb.AppendLine(string.Format("<td class='text-right'></td>"));
                                                    }
                                                    else
                                                    {
                                                        sb.AppendLine(string.Format("<td class='text-right {1}'><strong>{0}</strong></td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_B_DETAIL)), l.ANNEE_B_DETAIL.Replace("/", "")));
                                                    }
                                                }

                                            }

                                            sb.AppendLine("</tr>");
                                        }
                                    }
                                    else
                                    {
                                        if (lr.RUBR_ETAT_CODE.ToString().Trim().Length == 4)
                                        {
                                            if (lr.RUBR_ETAT_CODE.ToString() == "BA31" || lr.RUBR_ETAT_CODE.ToString() == "BA32" || lr.RUBR_ETAT_CODE.ToString() == "BA33")
                                            {
                                                sb.AppendLine(string.Format("<tr data_code='{0}'>", lr.RUBR_ETAT_CODE.ToString().Trim()));
                                                // sb.AppendLine(string.Format("<td class='text-left'>{0}</td>", lr.CODE_POSTE.ToString()));
                                                sb.AppendLine(string.Format("<td class='text-left'>{0}</td>", lr.RUBR_ETAT_LIBELLE.ToString()));

                                                var liste_valeur2 = service.AnafiAfficheLiasse(9, idDossier, lr.RUBR_ETAT_CODE.ToString().Trim(), "SN");

                                                int j = 0;
                                                int v = 0;
                                                v = Convert.ToInt32(liste_valeur2.Count) - 3;
                                                foreach (var l in liste_valeur2)
                                                {

                                                    if (liste_valeur2.Count > 3)
                                                    {
                                                        j++;
                                                        if (v < j)
                                                        {
                                                            if (l.RUBR_ETAT_LIBELLE.Trim().Length <= 1)
                                                            {
                                                                sb.AppendLine(string.Format("<td class='text-right'></td>"));
                                                            }
                                                            else
                                                            {
                                                                sb.AppendLine(string.Format("<td class='text-right {1}'>{0}</td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_B_DETAIL)), l.ANNEE_B_DETAIL.Replace("/", "")));
                                                            }
                                                        }

                                                    }
                                                    else
                                                    {
                                                        if (l.RUBR_ETAT_LIBELLE.Trim().Length <= 1)
                                                        {
                                                            sb.AppendLine(string.Format("<td class='text-right'></td>"));
                                                        }
                                                        else
                                                        {
                                                            sb.AppendLine(string.Format("<td class='text-right {1}'>{0}</td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_B_DETAIL)), l.ANNEE_B_DETAIL.Replace("/", "")));
                                                        }
                                                    }
                                                }

                                                sb.AppendLine("</tr>");
                                            }
                                            else
                                            {
                                                sb.AppendLine(string.Format("<tr data_code='{0}'>", lr.RUBR_ETAT_CODE.ToString().Trim()));
                                                // sb.AppendLine(string.Format("<td class='text-left'>{0}</td>", lr.CODE_POSTE.ToString()));
                                                sb.AppendLine(string.Format("<td class='text-left'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE.ToString()));

                                                var liste_valeur2 = service.AnafiAfficheLiasse(9, idDossier, lr.RUBR_ETAT_CODE.ToString().Trim(), "SN");

                                                int j = 0;
                                                int v = 0;
                                                v = Convert.ToInt32(liste_valeur2.Count) - 3;
                                                foreach (var l in liste_valeur2)
                                                {

                                                    if (liste_valeur2.Count > 3)
                                                    {
                                                        j++;
                                                        if (v < j)
                                                        {
                                                            if (l.RUBR_ETAT_LIBELLE.Trim().Length <= 1)
                                                            {
                                                                sb.AppendLine(string.Format("<td class='text-right'></td>"));
                                                            }
                                                            else
                                                            {
                                                                sb.AppendLine(string.Format("<td class='text-right {1}'><strong>{0}</strong></td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_B_DETAIL)), l.ANNEE_B_DETAIL.Replace("/", "")));
                                                            }
                                                        }

                                                    }
                                                    else
                                                    {
                                                        if (l.RUBR_ETAT_LIBELLE.Trim().Length <= 1)
                                                        {
                                                            sb.AppendLine(string.Format("<td class='text-right'></td>"));
                                                        }
                                                        else
                                                        {
                                                            sb.AppendLine(string.Format("<td class='text-right {1}'><strong>{0}</strong></td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_B_DETAIL)), l.ANNEE_B_DETAIL.Replace("/", "")));
                                                        }
                                                    }
                                                }

                                                sb.AppendLine("</tr>");
                                            }

                                        }
                                        else
                                        {
                                            sb.AppendLine(string.Format("<tr data_code='{0}'>", lr.RUBR_ETAT_CODE.ToString().Trim()));
                                            // sb.AppendLine(string.Format("<td class='text-left'>{0}</td>", lr.CODE_POSTE.ToString()));
                                            sb.AppendLine(string.Format("<td class='text-left'>{0}</td>", lr.RUBR_ETAT_LIBELLE.ToString()));

                                            var liste_valeur2 = service.AnafiAfficheLiasse(9, idDossier, lr.RUBR_ETAT_CODE.ToString().Trim(), "SN");

                                            int j = 0;
                                            int v = 0;
                                            v = Convert.ToInt32(liste_valeur2.Count) - 3;
                                            foreach (var l in liste_valeur2)
                                            {

                                                if (liste_valeur2.Count > 3)
                                                {
                                                    j++;
                                                    if (v < j)
                                                    {
                                                        if (l.RUBR_ETAT_LIBELLE.Trim().Length <= 1)
                                                        {
                                                            sb.AppendLine(string.Format("<td class='text-right'></td>"));
                                                        }
                                                        else
                                                        {
                                                            sb.AppendLine(string.Format("<td class='text-right {1}'>{0}</td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_B_DETAIL)), l.ANNEE_B_DETAIL.Replace("/", "")));
                                                        }
                                                    }

                                                }
                                                else
                                                {
                                                    if (l.RUBR_ETAT_LIBELLE.Trim().Length <= 1)
                                                    {
                                                        sb.AppendLine(string.Format("<td class='text-right'></td>"));
                                                    }
                                                    else
                                                    {
                                                        sb.AppendLine(string.Format("<td class='text-right {1}'>{0}</td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_B_DETAIL)), l.ANNEE_B_DETAIL.Replace("/", "")));
                                                    }
                                                }
                                            }

                                            sb.AppendLine("</tr>");
                                        }


                                    }
                                }

                                if (lr.RUBR_ETAT_CODE.Trim() == "BA")
                                {
                                    //string[]  // TabLOTP = null;

                                    //sbt.AppendLine(string.Format("<table id='{0}' class='table-hover table table-bordered text-center'>", lr.RUBR_ETAT_CODE.Trim()));
                                    sbt.AppendLine(string.Format("<tr style='background-color:rgba(210, 210, 210, 1);'>"));

                                    sbt.AppendLine(string.Format("<td class='text-left'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE));
                                    // TabLOTA = new string[Convert.ToInt32(liste_annee.Count)];
                                    int p = 0;
                                    var liste_valeur3 = service.AnafiAfficheLiasse(9, idDossier, lr.RUBR_ETAT_CODE.ToString().Trim(), "SN");

                                    int j = 0;
                                    int v = 0;
                                    v = Convert.ToInt32(liste_valeur3.Count) - 3;
                                    foreach (var l in liste_valeur3)
                                    {

                                        if (liste_valeur3.Count > 3)
                                        {
                                            j++;
                                            if (v < j)
                                            {
                                                sbt.AppendLine(string.Format("<td class='text-right' width=15%>{0}</td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_B_DETAIL))));
                                                // TabLOTA[p] = l.VALEUR_B_DETAIL.ToString();
                                                p++;
                                            }

                                        }
                                        else
                                        {
                                            sbt.AppendLine(string.Format("<td class='text-right' width=15%>{0}</td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_B_DETAIL))));
                                            // TabLOTA[p] = l.VALEUR_B_DETAIL.ToString();
                                            p++;
                                        }
                                    }
                                    sbt.AppendLine("</tr>");
                                    //sbt.AppendLine("</table>");
                                    //DIVtotauxActif.InnerHtml = sbt.ToString();


                                }
                        } 
                          
                        }
                       

                    }

                    sb.AppendLine("</tbody>");
                    sb.AppendLine("</table>");
                }
                else
                {
                    sb.AppendLine("<div class='col-lg-6 col-sm-6 col-md-6' >");
                    sb.AppendLine("<table id='' class='table table-hover table-bordered text-center'>");
                    sb.AppendLine("<thead class='table-heigth'>");
                    sb.AppendLine(string.Format("<tr><th>Actifs</th>"));
                    sb.AppendLine(string.Format("<th width=23%></th>"));


                    sb.AppendLine("</thead>");
                    sb.AppendLine("<tbody>");

                    var liste_libelle = service.AnafiAfficheLiasse(0, "", "", "BIN");

                    foreach (var lr in liste_libelle)
                    {
                        if (lr.RUBR_ETAT_CODE.ToString().Trim() == "BAX12" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BA12A" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BA13A"
                           || lr.RUBR_ETAT_CODE.ToString().Trim() == "BA15A" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BAX53" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BAX54" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BA1A"
                           || lr.RUBR_ETAT_CODE.ToString().Trim() == "BA22A" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BA2X9" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BA2A" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BA3A"
                           || lr.RUBR_ETAT_CODE.ToString().Trim() == "BA4A" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BAX11" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BA11B" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BAX13"
                           || lr.RUBR_ETAT_CODE.ToString().Trim() == "BA21A" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BA2X4" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BA14A"
                            || lr.RUBR_ETAT_CODE.ToString().Trim() == "BAX21" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BAX22" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BAX23"
                            || lr.RUBR_ETAT_CODE.ToString().Trim() == "BAX24" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BAX31" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BAX32" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BAX35"
                            || lr.RUBR_ETAT_CODE.ToString().Trim() == "BA22A" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BAX51" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BAX52" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BA2X2"
                            || lr.RUBR_ETAT_CODE.ToString().Trim() == "BA2X3" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BA2X8" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BA2X6" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BA2X7"
                            || lr.RUBR_ETAT_CODE.ToString().Trim() == "BA3X1" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BA32A" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BA33A"
                            )
                        {
                        }
                        else
                        {

                        string SENS = "";
                        if (lr.RUBR_ETAT_CODE.Trim().Length > 2)
                        {
                            SENS = lr.RUBR_ETAT_CODE.ToString().Trim().Substring(0, 3);
                        }

                        if (SENS == "BA1" || SENS == "BA2" || SENS == "BA3" || SENS == "BA4" || SENS == "BAX")
                        {
                            if (lr.RUBR_ETAT_CODE.ToString().Trim().Length == 3)
                            {
                                if (lr.RUBR_ETAT_CODE.ToString().Trim() == "BA4")
                                {
                                    sb.AppendLine(string.Format("<tr data_code='{0}'>", lr.RUBR_ETAT_CODE.ToString().Trim()));
                                    // sb.AppendLine(string.Format("<td class='text-left'>{0}</td>", lr.CODE_POSTE.ToString()));
                                    sb.AppendLine(string.Format("<td class='text-left'>{0}</td>", lr.RUBR_ETAT_LIBELLE.ToString()));
                                    sb.AppendLine(string.Format("<td></td>"));

                                    sb.AppendLine("</tr>");

                                }
                                else
                                {
                                    sb.AppendLine(string.Format("<tr data_code='{0}' style='background-color:#ddd'>", lr.RUBR_ETAT_CODE.ToString().Trim()));
                                    // sb.AppendLine(string.Format("<td class='text-left'>{0}</td>", lr.CODE_POSTE.ToString()));


                                    if (lr.RUBR_ETAT_LIBELLE.Trim().Length <= 1)
                                    {
                                        sb.AppendLine(string.Format("<td class='text-left' style='color:#fff'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE.ToString()));
                                        sb.AppendLine(string.Format("<td></td>"));
                                    }
                                    else
                                    {
                                        sb.AppendLine(string.Format("<td class='text-left'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE.ToString()));
                                        sb.AppendLine(string.Format("<td></td>"));
                                    }



                                    sb.AppendLine("</tr>");
                                }

                            }
                            else
                            {
                                if (lr.RUBR_ETAT_CODE.ToString().Trim().Length == 4)
                                {
                                    if (lr.RUBR_ETAT_CODE.ToString() == "BA31" || lr.RUBR_ETAT_CODE.ToString() == "BA32" || lr.RUBR_ETAT_CODE.ToString() == "BA33")
                                    {
                                        sb.AppendLine(string.Format("<tr data_code='{0}'>", lr.RUBR_ETAT_CODE.ToString().Trim()));
                                        // sb.AppendLine(string.Format("<td class='text-left'>{0}</td>", lr.CODE_POSTE.ToString()));
                                        sb.AppendLine(string.Format("<td class='text-left'>{0}</td>", lr.RUBR_ETAT_LIBELLE.ToString()));
                                        sb.AppendLine(string.Format("<td></td>"));

                                        sb.AppendLine("</tr>");
                                    }
                                    else
                                    {
                                        sb.AppendLine(string.Format("<tr data_code='{0}'>", lr.RUBR_ETAT_CODE.ToString().Trim()));
                                        // sb.AppendLine(string.Format("<td class='text-left'>{0}</td>", lr.CODE_POSTE.ToString()));
                                        sb.AppendLine(string.Format("<td class='text-left'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE.ToString()));
                                        sb.AppendLine(string.Format("<td></td>"));

                                        sb.AppendLine("</tr>");
                                    }

                                }
                                else
                                {
                                    sb.AppendLine(string.Format("<tr data_code='{0}'>", lr.RUBR_ETAT_CODE.ToString().Trim()));
                                    // sb.AppendLine(string.Format("<td class='text-left'>{0}</td>", lr.CODE_POSTE.ToString()));
                                    sb.AppendLine(string.Format("<td class='text-left'>{0}</td>", lr.RUBR_ETAT_LIBELLE.ToString()));
                                    sb.AppendLine(string.Format("<td></td>"));

                                    sb.AppendLine("</tr>");
                                }

                            }
                        }

                        if (lr.RUBR_ETAT_CODE.Trim() == "BA")
                        {
                            //string[]  // TabLOTP = null;

                            //sbt.AppendLine("<table id='totauxActif' class='table-hover table table-bordered text-center'>");
                            sbt.AppendLine(string.Format("<table id='{0}' class='table-hover table table-bordered text-center'>", lr.RUBR_ETAT_CODE.Trim()));
                            sbt.AppendLine(string.Format("<tr style='background-color:rgba(210, 210, 210, 1);'>"));

                            sbt.AppendLine(string.Format("<td class='text-left'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE));
                            sbt.AppendLine(string.Format("<td width=23%></td>"));
                            sbt.AppendLine("</table>");
                            DIVtotauxActif.InnerHtml = sbt.ToString();


                        }
                    }
                    }

                    sb.AppendLine("</tbody>");
                    sb.AppendLine("</table>");
                }
                sb.AppendLine("</div>");

                //var list_all = service.Listbilan(idDossier);
                //sb.AppendLine("<div class='col-lg-6 col-sm-6 col-md-6' >");

                if (liste_annee.Count != 0)
                {
                    sb.AppendLine("<div class='col-lg-6 col-sm-6 col-md-6' >");
                    sb.AppendLine("<table id='' class='table table-hover table-bordered text-center'>");
                    sb.AppendLine("<thead class='table-heigth'>");
                    sb.AppendLine(string.Format("<tr><th>Passifs</th>"));

                    if (liste_annee.Count > 3)
                    {
                        int j = 0;
                        int v = 0;
                        int i = 0;
                        v = Convert.ToInt32(liste_annee.Count) - 3;
                        foreach (var lr in liste_annee)
                        {
                            j++;
                            if (v < j)
                            {
                                if (i < Convert.ToInt32(liste_annee.Count))
                                {
                                    sb.AppendLine(string.Format("<th onclick='transfertval($(this))' width=15%>{0}</th>", lr.ANNEE_DETAIL));
                                    //TabLOT[i] = lr.ANNEE_DETAIL;
                                }
                            }

                            i++;
                        }
                    }
                    else
                    {
                        int i = 0;
                        foreach (var lr in liste_annee)
                        {

                            if (i < Convert.ToInt32(liste_annee.Count))
                            {
                                sb.AppendLine(string.Format("<th onclick='transfertval($(this))' width=15%>{0}</th>", lr.ANNEE_DETAIL));
                                //TabLOT[i] = lr.ANNEE_DETAIL;
                            }
                            i++;
                        }
                    }

                    sb.AppendLine("</thead>");
                    sb.AppendLine("<tbody>");

                    var liste_libelle = service.AnafiAfficheLiasse(0, "", "", "BIN");

                    foreach (var lr in liste_libelle)
                    {
                        string SENS = "";
                        if (lr.RUBR_ETAT_CODE.Trim().Length > 2)
                        {
                            SENS = lr.RUBR_ETAT_CODE.ToString().Trim().Substring(0, 3);
                        }

                        if (SENS == "BP1" || SENS == "BP2" || SENS == "BP3" || SENS == "BP4" || SENS == "BP5" || SENS == "BP")
                        {
                            if (lr.RUBR_ETAT_CODE.ToString().Trim() == "BP1A" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BP1B" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BP2" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BP3")
                            {
                                sb.AppendLine(string.Format("<tr data_code='{0}' style='background-color:#ddd'>", lr.RUBR_ETAT_CODE.ToString().Trim()));
                                // sb.AppendLine(string.Format("<td class='text-left'>{0}</td>", lr.CODE_POSTE.ToString()));
                                //sb.AppendLine(string.Format("<td class='text-left'>{0}</td>", lr.RUBR_ETAT_LIBELLE.ToString()));

                                if (lr.RUBR_ETAT_LIBELLE.Trim().Length <= 1)
                                {
                                    sb.AppendLine(string.Format("<td class='text-left' style='color:#fff'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE.ToString()));
                                }
                                else
                                {
                                    sb.AppendLine(string.Format("<td class='text-left'><strong><strong>{0}</strong></strong></td>", lr.RUBR_ETAT_LIBELLE.ToString()));
                                }
                                var liste_valeur4 = service.AnafiAfficheLiasse(9, idDossier, lr.RUBR_ETAT_CODE.ToString().Trim(), "SN");
                                int j = 0;
                                int v = 0;
                                v = Convert.ToInt32(liste_valeur4.Count) - 3;
                                foreach (var l in liste_valeur4)
                                {

                                    if (liste_valeur4.Count > 3)
                                    {
                                        j++;
                                        if (v < j)
                                        {
                                            sb.AppendLine(string.Format("<td class='text-right {1}' width=15%><strong><strong>{0}</strong></strong></td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_B_DETAIL)), l.ANNEE_B_DETAIL.Replace("/", "")));
                                        }

                                    }
                                    else
                                    {
                                        sb.AppendLine(string.Format("<td class='text-right {1}' width=15%><strong><strong>{0}</strong></strong></td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_B_DETAIL)), l.ANNEE_B_DETAIL.Replace("/", "")));
                                    }
                                }


                                sb.AppendLine("</tr>");
                            }
                            else
                            {
                                if (lr.RUBR_ETAT_CODE.ToString().Trim() == "BP1")
                                {
                                    sb.AppendLine(string.Format("<tr data_code='{0}' style='background-color:#b7abab'>", lr.RUBR_ETAT_CODE.ToString().Trim()));
                                    // sb.AppendLine(string.Format("<td class='text-left'>{0}</td>", lr.CODE_POSTE.ToString()));
                                    //sb.AppendLine(string.Format("<td class='text-left'>{0}</td>", lr.RUBR_ETAT_LIBELLE.ToString()));

                                    if (lr.RUBR_ETAT_LIBELLE.Trim().Length <= 1)
                                    {
                                        sb.AppendLine(string.Format("<td class='text-left' style='color:#fff'>{0}</td>", lr.RUBR_ETAT_LIBELLE.ToString()));
                                    }
                                    else
                                    {
                                        sb.AppendLine(string.Format("<td class='text-left'>{0}</td>", lr.RUBR_ETAT_LIBELLE.ToString()));
                                    }
                                    var liste_valeur4 = service.AnafiAfficheLiasse(9, idDossier, lr.RUBR_ETAT_CODE.ToString().Trim(), "SN");
                                    int j = 0;
                                    int v = 0;
                                    v = Convert.ToInt32(liste_valeur4.Count) - 3;
                                    foreach (var l in liste_valeur4)
                                    {

                                        if (liste_valeur4.Count > 3)
                                        {
                                            j++;
                                            if (v < j)
                                            {
                                                sb.AppendLine(string.Format("<td class='text-right {1}' width=15%>{0}</td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_B_DETAIL)), l.ANNEE_B_DETAIL.Replace("/", "")));
                                            }

                                        }
                                        else
                                        {
                                            sb.AppendLine(string.Format("<td class='text-right {1}' width=15%>{0}</td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_B_DETAIL)), l.ANNEE_B_DETAIL.Replace("/", "")));
                                        }
                                    }


                                    sb.AppendLine("</tr>");
                                }
                                else
                                {
                                    if (lr.RUBR_ETAT_CODE.ToString().Trim() == "BP1A1" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BP1A3" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BP1A9" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BP1AX")
                                    {
                                        sb.AppendLine(string.Format("<tr data_code='{0}'>", lr.RUBR_ETAT_CODE.ToString().Trim()));
                                        // sb.AppendLine(string.Format("<td class='text-left'>{0}</td>", lr.CODE_POSTE.ToString()));
                                        sb.AppendLine(string.Format("<td class='text-left'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE.ToString()));

                                        var liste_valeur5 = service.AnafiAfficheLiasse(9, idDossier, lr.RUBR_ETAT_CODE.ToString().Trim(), "SN");
                                        int j = 0;
                                        int v = 0;
                                        v = Convert.ToInt32(liste_valeur5.Count) - 3;
                                        foreach (var l in liste_valeur5)
                                        {

                                            if (liste_valeur5.Count > 3)
                                            {
                                                j++;
                                                if (v < j)
                                                {
                                                    if (l.RUBR_ETAT_LIBELLE.Trim().Length <= 1)
                                                    {
                                                        sb.AppendLine(string.Format("<td class='text-right' width=15%></td>"));
                                                    }
                                                    else
                                                    {
                                                        sb.AppendLine(string.Format("<td class='text-right {1}' width=15%><strong>{0}</strong></td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_B_DETAIL)), l.ANNEE_B_DETAIL.Replace("/", "")));
                                                    }
                                                }

                                            }
                                            else
                                            {
                                                if (l.RUBR_ETAT_LIBELLE.Trim().Length <= 1)
                                                {
                                                    sb.AppendLine(string.Format("<td class='text-right' width=15%></td>"));
                                                }
                                                else
                                                {
                                                    sb.AppendLine(string.Format("<td class='text-right {1}' width=15%><strong>{0}</strong></td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_B_DETAIL)), l.ANNEE_B_DETAIL.Replace("/", "")));
                                                }
                                            }
                                        }

                                        sb.AppendLine("</tr>");

                                    }
                                    else
                                    {

                                        sb.AppendLine(string.Format("<tr data_code='{0}'>", lr.RUBR_ETAT_CODE.ToString().Trim()));
                                        // sb.AppendLine(string.Format("<td class='text-left'>{0}</td>", lr.CODE_POSTE.ToString()));
                                        sb.AppendLine(string.Format("<td class='text-left'>{0}</td>", lr.RUBR_ETAT_LIBELLE.ToString()));

                                        var liste_valeur5 = service.AnafiAfficheLiasse(9, idDossier, lr.RUBR_ETAT_CODE.ToString().Trim(), "SN");
                                        int j = 0;
                                        int v = 0;
                                        v = Convert.ToInt32(liste_valeur5.Count) - 3;
                                        foreach (var l in liste_valeur5)
                                        {

                                            if (liste_valeur5.Count > 3)
                                            {
                                                j++;
                                                if (v < j)
                                                {
                                                    if (l.RUBR_ETAT_LIBELLE.Trim().Length <= 1)
                                                    {
                                                        sb.AppendLine(string.Format("<td class='text-right' width=15%></td>"));
                                                    }
                                                    else
                                                    {
                                                        sb.AppendLine(string.Format("<td class='text-right {1}' width=15%>{0}</td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_B_DETAIL)), l.ANNEE_B_DETAIL.Replace("/", "")));
                                                    }
                                                }

                                            }
                                            else
                                            {
                                                if (l.RUBR_ETAT_LIBELLE.Trim().Length <= 1)
                                                {
                                                    sb.AppendLine(string.Format("<td class='text-right' width=15%></td>"));
                                                }
                                                else
                                                {
                                                    sb.AppendLine(string.Format("<td class='text-right {1}' width=15%>{0}</td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_B_DETAIL)), l.ANNEE_B_DETAIL.Replace("/", "")));
                                                }
                                            }
                                        }

                                        sb.AppendLine("</tr>");
                                    }

                                }
                            }
                        }
                        if (lr.RUBR_ETAT_CODE.Trim() == "BP")
                        {
                            //string[]  // TabLOTP = null;

                            //sbv.AppendLine("<table id='totauxPassif' class='table-hover table table-bordered text-center'>");
                            sbv.AppendLine(string.Format("<table id='{0}' class='table-hover table table-bordered text-center matb'>", lr.RUBR_ETAT_CODE.Trim()));

                            sbv.AppendLine(string.Format("<tr style='background-color:rgba(210, 210, 210, 1);'>"));

                            sbv.AppendLine(string.Format("<td class='text-left'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE));
                            // TabLOTP = new string[Convert.ToInt32(liste_annee.Count)];
                            int p = 0;
                            var liste_valeur6 = service.AnafiAfficheLiasse(9, idDossier, lr.RUBR_ETAT_CODE.ToString().Trim(), "SN");
                            int j = 0;
                            int v = 0;
                            v = Convert.ToInt32(liste_valeur6.Count) - 3;
                            foreach (var l in liste_valeur6)
                            {

                                if (liste_valeur6.Count > 3)
                                {
                                    j++;
                                    if (v < j)
                                    {
                                        sbv.AppendLine(string.Format("<td class='text-right' width=15%>{0}</td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_B_DETAIL))));
                                        // TabLOTP[p] = l.VALEUR_B_DETAIL.ToString();
                                        p++;
                                    }

                                }
                                else
                                {
                                    sbv.AppendLine(string.Format("<td class='text-right' width=15%>{0}</td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_B_DETAIL))));
                                    // TabLOTP[p] = l.VALEUR_B_DETAIL.ToString();
                                    p++;
                                }
                            }
                            sbv.AppendLine("</tr>");
                            sbv.AppendLine("</table>");
                            DIVtotauxPassif.InnerHtml = sbv.ToString();


                            sbe.AppendLine("<table id='totauxEcart' class='table-hover table table-bordered text-center'>");
                            sbe.AppendLine(string.Format("<tr style='background-color:rgba(210, 210, 210, 1);'>"));

                            sbe.AppendLine(string.Format("<td class='text-left'><strong>Ecart</strong></td>"));
                            // TabLOTP = new string[Convert.ToInt32(liste_annee.Count)];
                            p = 0;
                            //var liste_valeur = service.AnafiAfficheLiasse(1, idDossier, lr.RUBR_ETAT_CODE.ToString().Trim(), "");
                            j = 0;
                            v = 0;
                            v = Convert.ToInt32(liste_valeur6.Count) - 3;
                            foreach (var l in liste_valeur6)
                            {

                                if (liste_valeur6.Count > 3)
                                {
                                    j++;
                                    if (v < j)
                                    {
                                        sbe.AppendLine(string.Format("<td class='text-right' width=15%></td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_B_DETAIL))));
                                        // TabLOTP[p] = l.VALEUR_B_DETAIL.ToString();
                                        p++;
                                    }

                                }
                                else
                                {
                                    sbe.AppendLine(string.Format("<td class='text-right' width=15%></td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_B_DETAIL))));
                                    // TabLOTP[p] = l.VALEUR_B_DETAIL.ToString();
                                    p++;
                                }
                            }

                            sbe.AppendLine("</tr>");

                            sbe.AppendLine("</table>");
                            DivecartsActifPassif.InnerHtml = sbe.ToString();
                            //TPAnnee3.InnerHtml = "<strong>" + Convert.ToString(string.Format("{0:#,##0}", lr.ANNEE3)) + "</strong>";
                        }
                    }

                    sb.AppendLine("</tbody>");
                    sb.AppendLine("</table>");

                    DIVtotauxActif.Visible = true;
                    DIVtotauxPassif.Visible = true;
                    DivecartsActifPassif.Visible = true;
                }
                else
                {
                    sb.AppendLine("<div class='col-lg-6 col-sm-6 col-md-6' >");
                    sb.AppendLine("<table id='' class='table table-hover table-bordered text-center'>");
                    sb.AppendLine("<thead class='table-heigth'>");
                    sb.AppendLine(string.Format("<tr><th>Passifs</th>"));
                    sb.AppendLine(string.Format("<th width=23%></th>"));

                    sb.AppendLine("</thead>");
                    sb.AppendLine("<tbody>");

                    var liste_libelle = service.AnafiAfficheLiasse(0, "", "", "BIN");

                    foreach (var lr in liste_libelle)
                    {
                        string SENS = "";
                        if (lr.RUBR_ETAT_CODE.Trim().Length > 2)
                        {
                            SENS = lr.RUBR_ETAT_CODE.ToString().Trim().Substring(0, 3);
                        }






                        if (SENS == "BP1" || SENS == "BP2" || SENS == "BP3" || SENS == "BP4" || SENS == "BP5" || SENS == "BP")
                        {
                            if (lr.RUBR_ETAT_CODE.ToString().Trim() == "BP1A" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BP1B" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BP2" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BP3")
                            {
                                sb.AppendLine(string.Format("<tr data_code='{0}' style='background-color:#ddd'>", lr.RUBR_ETAT_CODE.ToString().Trim()));
                                // sb.AppendLine(string.Format("<td class='text-left'>{0}</td>", lr.CODE_POSTE.ToString()));
                                //sb.AppendLine(string.Format("<td class='text-left'>{0}</td>", lr.RUBR_ETAT_LIBELLE.ToString()));
                                if (lr.RUBR_ETAT_LIBELLE.Trim().Length <= 1)
                                {
                                    sb.AppendLine(string.Format("<td class='text-left' style='color:#fff'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE.ToString()));
                                    sb.AppendLine(string.Format("<td></td>"));
                                }
                                else
                                {
                                    sb.AppendLine(string.Format("<td class='text-left'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE.ToString()));
                                    sb.AppendLine(string.Format("<td></td>"));
                                }
                                sb.AppendLine("</tr>");
                            }
                            else
                            {
                                if (lr.RUBR_ETAT_CODE.ToString().Trim() == "BP1")
                                {
                                    sb.AppendLine(string.Format("<tr data_code='{0}' style='background-color:#b7abab'>", lr.RUBR_ETAT_CODE.ToString().Trim()));
                                    // sb.AppendLine(string.Format("<td class='text-left'>{0}</td>", lr.CODE_POSTE.ToString()));
                                    //sb.AppendLine(string.Format("<td class='text-left'>{0}</td>", lr.RUBR_ETAT_LIBELLE.ToString()));

                                    if (lr.RUBR_ETAT_LIBELLE.Trim().Length <= 1)
                                    {
                                        sb.AppendLine(string.Format("<td class='text-left' style='color:#fff'>{0}</td>", lr.RUBR_ETAT_LIBELLE.ToString()));
                                        sb.AppendLine(string.Format("<td></td>"));
                                    }
                                    else
                                    {
                                        sb.AppendLine(string.Format("<td class='text-left'>{0}</td>", lr.RUBR_ETAT_LIBELLE.ToString()));
                                        sb.AppendLine(string.Format("<td></td>"));
                                    }
                                    sb.AppendLine("</tr>");
                                }
                                else
                                {
                                    if (lr.RUBR_ETAT_CODE.ToString().Trim() == "BP1A1" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BP1A3" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BP1A9" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BP1AX")
                                    {
                                        sb.AppendLine(string.Format("<tr data_code='{0}'>", lr.RUBR_ETAT_CODE.ToString().Trim()));
                                        // sb.AppendLine(string.Format("<td class='text-left'>{0}</td>", lr.CODE_POSTE.ToString()));
                                        sb.AppendLine(string.Format("<td class='text-left'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE.ToString()));

                                        sb.AppendLine(string.Format("<td></td>"));

                                        sb.AppendLine("</tr>");

                                    }
                                    else
                                    {

                                        sb.AppendLine(string.Format("<tr data_code='{0}'>", lr.RUBR_ETAT_CODE.ToString().Trim()));
                                        // sb.AppendLine(string.Format("<td class='text-left'>{0}</td>", lr.CODE_POSTE.ToString()));
                                        sb.AppendLine(string.Format("<td class='text-left'>{0}</td>", lr.RUBR_ETAT_LIBELLE.ToString()));
                                        sb.AppendLine(string.Format("<td></td>"));


                                        sb.AppendLine("</tr>");
                                    }

                                }
                            }
                        }
                        if (lr.RUBR_ETAT_CODE.Trim() == "BP")
                        {
                            //string[]  // TabLOTP = null;

                            //sbv.AppendLine("<table id='totauxPassif' class='table-hover table table-bordered text-center'>");
                            sbv.AppendLine(string.Format("<table id='{0}' class='table-hover table table-bordered text-center matb'>", lr.RUBR_ETAT_CODE.Trim()));

                            sbv.AppendLine(string.Format("<tr style='background-color:rgba(210, 210, 210, 1);'>"));

                            sbv.AppendLine(string.Format("<td class='text-left'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE));
                            sbv.AppendLine(string.Format("<td width=23%></td>"));
                            sbv.AppendLine("</table>");
                            DIVtotauxPassif.InnerHtml = sbv.ToString();


                            sbe.AppendLine("<table id='totauxPassif' class='table-hover table table-bordered text-center'>");
                            sbe.AppendLine(string.Format("<tr style='background-color:rgba(210, 210, 210, 1);'>"));

                            sbe.AppendLine(string.Format("<td class='text-left'>Ecart</td>"));
                            sbe.AppendLine(string.Format("<td width=23%></td>"));
                            sbe.AppendLine("</table>");
                            DivecartsActifPassif.InnerHtml = sbe.ToString();
                        }
                    }

                    sb.AppendLine("</tbody>");
                    sb.AppendLine("</table>");

                    DIVtotauxActif.Visible = true;
                    DIVtotauxPassif.Visible = true;
                    DivecartsActifPassif.Visible = true;
                }



                sb.AppendLine("</div>");
            }
            else
            {
                if (DdlRubrique.Text != "Bilan")
                {
                    DIVtotauxActif.Visible = false;
                    DIVtotauxPassif.Visible = false;
                    DivecartsActifPassif.Visible = false;
                }
            }
            ListDFinanciers.InnerHtml = "<div class='row'>" + sb.ToString() + "</div>";
            sbt.AppendLine("</table>");
            DIVtotauxActif.InnerHtml = sbt.ToString();

        }

        public void afficheBilanSA()
        {
            if (Session["id_dossier"] == null) Response.Redirect("~/Scoring/Connexion.aspx");

            var idDossier = Session["id_dossier"].ToString();
            Session.Add("id_dossier", idDossier);
            if (DdlRubrique.Text == "Bilan")
            {
                Type_anafi = "BN";
                Div1.Visible = true;
                Div2.Visible = true;
                var liste_annee = service.AnafiAfficheLiasse(7, idDossier, "", "SA");
                var nombre_annee = service.AnafiAfficheLiasse(8, idDossier, "", "SA");

                if (liste_annee.Count != 0)
                {
                    sb.AppendLine("<div class='col-lg-6 col-sm-6 col-md-6' >");
                    sb.AppendLine("<table id='' class='table table-hover table-bordered text-center'>");
                    sb.AppendLine("<thead class='table-heigth'>");
                    sb.AppendLine(string.Format("<tr><th>Actifs</th>"));
                    if (liste_annee.Count > 3)
                    {
                        int j = 0;
                        int v = 0;
                        int i = 0;
                        v = Convert.ToInt32(liste_annee.Count) - 3;
                        foreach (var lr in liste_annee)
                        {
                            j++;
                            if (v < j)
                            {
                                if (i < Convert.ToInt32(liste_annee.Count))
                                {
                                    sb.AppendLine(string.Format("<th onclick='transfertval($(this))' width=15%>{0}</th>", lr.ANNEE_DETAIL));
                                    //TabLOT[i] = lr.ANNEE_DETAIL;
                                }
                            }

                            i++;
                        }
                    }
                    else
                    {
                        int i = 0;
                        foreach (var lr in liste_annee)
                        {

                            if (i < Convert.ToInt32(liste_annee.Count))
                            {
                                sb.AppendLine(string.Format("<th onclick='transfertval($(this))' width=15%>{0}</th>", lr.ANNEE_DETAIL));
                                //TabLOT[i] = lr.ANNEE_DETAIL;
                            }
                            i++;
                        }
                    }


                    sb.AppendLine("</thead>");
                    sb.AppendLine("<tbody>");

                    var liste_libelle = service.AnafiAfficheLiasse(0, "", "", "BIA");

                    foreach (var lr in liste_libelle)
                    {
                        string SENS = "";
                        if (lr.RUBR_ETAT_CODE.Trim().Length > 2)
                        {
                            SENS = lr.RUBR_ETAT_CODE.ToString().Trim().Substring(0, 3);
                        }

                        if (SENS == "BA1" || SENS == "BA2" || SENS == "BA3" || SENS == "BA4")
                        {
                            if (lr.RUBR_ETAT_CODE.ToString().Trim().Length == 3)
                            {
                                if (lr.RUBR_ETAT_CODE.ToString().Trim() == "BA4")
                                {
                                    sb.AppendLine(string.Format("<tr data_code='{0}'>", lr.RUBR_ETAT_CODE.ToString().Trim()));
                                    // sb.AppendLine(string.Format("<td class='text-left'>{0}</td>", lr.CODE_POSTE.ToString()));
                                    sb.AppendLine(string.Format("<td class='text-left'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE.ToString()));

                                    var liste_valeur2 = service.AnafiAfficheLiasse(11, idDossier, lr.RUBR_ETAT_CODE.ToString().Trim(), "SA");

                                    int j = 0;
                                    int v = 0;
                                    v = Convert.ToInt32(liste_valeur2.Count) - 3;
                                    foreach (var l in liste_valeur2)
                                    {

                                        if (liste_valeur2.Count > 3)
                                        {
                                            j++;
                                            if (v < j)
                                            {
                                                if (l.RUBR_ETAT_LIBELLE.Trim().Length <= 1)
                                                {
                                                    sb.AppendLine(string.Format("<td class='text-right'></td>"));
                                                }
                                                else
                                                {
                                                    sb.AppendLine(string.Format("<td class='text-right {1}'><strong>{0}</strong></td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_B_DETAIL)), l.ANNEE_B_DETAIL.Replace("/", "")));
                                                }
                                            }

                                        }
                                        else
                                        {
                                            if (l.RUBR_ETAT_LIBELLE.Trim().Length <= 1)
                                            {
                                                sb.AppendLine(string.Format("<td class='text-right'></td>"));
                                            }
                                            else
                                            {
                                                sb.AppendLine(string.Format("<td class='text-right {1}'><strong>{0}</strong></td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_B_DETAIL)), l.ANNEE_B_DETAIL.Replace("/", "")));
                                            }
                                        }
                                    }

                                    sb.AppendLine("</tr>");
                                }
                                else
                                {

                                    sb.AppendLine(string.Format("<tr data_code='{0}' style='background-color:#ddd'>", lr.RUBR_ETAT_CODE.ToString().Trim()));
                                    // sb.AppendLine(string.Format("<td class='text-left'>{0}</td>", lr.CODE_POSTE.ToString()));


                                    if (lr.RUBR_ETAT_LIBELLE.Trim().Length <= 1)
                                    {
                                        sb.AppendLine(string.Format("<td class='text-left' style='color:#fff'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE.ToString()));
                                    }
                                    else
                                    {
                                        sb.AppendLine(string.Format("<td class='text-left'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE.ToString()));
                                    }
                                    var liste_valeur1 = service.AnafiAfficheLiasse(11, idDossier, lr.RUBR_ETAT_CODE.ToString().Trim(), "SA");
                                    int j = 0;
                                    int v = 0;
                                    v = Convert.ToInt32(liste_valeur1.Count) - 3;
                                    foreach (var l in liste_valeur1)
                                    {

                                        if (liste_valeur1.Count > 3)
                                        {
                                            j++;
                                            if (v < j)
                                            {
                                                if (l.RUBR_ETAT_LIBELLE.Trim().Length <= 1)
                                                {
                                                    sb.AppendLine(string.Format("<td class='text-right'></td>"));
                                                }
                                                else
                                                {
                                                    sb.AppendLine(string.Format("<td class='text-right {1}'><strong>{0}</strong></td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_B_DETAIL)), l.ANNEE_B_DETAIL.Replace("/", "")));
                                                }
                                            }

                                        }
                                        else
                                        {
                                            if (l.RUBR_ETAT_LIBELLE.Trim().Length <= 1)
                                            {
                                                sb.AppendLine(string.Format("<td class='text-right'></td>"));
                                            }
                                            else
                                            {
                                                sb.AppendLine(string.Format("<td class='text-right {1}'><strong>{0}</strong></td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_B_DETAIL)), l.ANNEE_B_DETAIL.Replace("/", "")));
                                            }
                                        }

                                    }

                                    sb.AppendLine("</tr>");
                                }
                            }
                            else
                            {
                                if (lr.RUBR_ETAT_CODE.ToString().Trim().Length == 4)
                                {
                                    if (lr.RUBR_ETAT_CODE.ToString().Trim() == "BA31" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BA32")
                                    {
                                        sb.AppendLine(string.Format("<tr data_code='{0}'>", lr.RUBR_ETAT_CODE.ToString().Trim()));
                                        // sb.AppendLine(string.Format("<td class='text-left'>{0}</td>", lr.CODE_POSTE.ToString()));
                                        sb.AppendLine(string.Format("<td class='text-left'>{0}</td>", lr.RUBR_ETAT_LIBELLE.ToString()));

                                        var liste_valeur2 = service.AnafiAfficheLiasse(11, idDossier, lr.RUBR_ETAT_CODE.ToString().Trim(), "SA");

                                        int j = 0;
                                        int v = 0;
                                        v = Convert.ToInt32(liste_valeur2.Count) - 3;
                                        foreach (var l in liste_valeur2)
                                        {

                                            if (liste_valeur2.Count > 3)
                                            {
                                                j++;
                                                if (v < j)
                                                {
                                                    if (l.RUBR_ETAT_LIBELLE.Trim().Length <= 1)
                                                    {
                                                        sb.AppendLine(string.Format("<td class='text-right'></td>"));
                                                    }
                                                    else
                                                    {
                                                        sb.AppendLine(string.Format("<td class='text-right {1}'>{0}</td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_B_DETAIL)), l.ANNEE_B_DETAIL.Replace("/", "")));
                                                    }
                                                }

                                            }
                                            else
                                            {
                                                if (l.RUBR_ETAT_LIBELLE.Trim().Length <= 1)
                                                {
                                                    sb.AppendLine(string.Format("<td class='text-right'></td>"));
                                                }
                                                else
                                                {
                                                    sb.AppendLine(string.Format("<td class='text-right {1}'>{0}</td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_B_DETAIL)), l.ANNEE_B_DETAIL.Replace("/", "")));
                                                }
                                            }
                                        }

                                        sb.AppendLine("</tr>");
                                    }
                                    else
                                    {
                                        sb.AppendLine(string.Format("<tr data_code='{0}'>", lr.RUBR_ETAT_CODE.ToString().Trim()));
                                        // sb.AppendLine(string.Format("<td class='text-left'>{0}</td>", lr.CODE_POSTE.ToString()));
                                        sb.AppendLine(string.Format("<td class='text-left'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE.ToString()));

                                        var liste_valeur2 = service.AnafiAfficheLiasse(11, idDossier, lr.RUBR_ETAT_CODE.ToString().Trim(), "SA");

                                        int j = 0;
                                        int v = 0;
                                        v = Convert.ToInt32(liste_valeur2.Count) - 3;
                                        foreach (var l in liste_valeur2)
                                        {

                                            if (liste_valeur2.Count > 3)
                                            {
                                                j++;
                                                if (v < j)
                                                {
                                                    if (l.RUBR_ETAT_LIBELLE.Trim().Length <= 1)
                                                    {
                                                        sb.AppendLine(string.Format("<td class='text-right'></td>"));
                                                    }
                                                    else
                                                    {
                                                        sb.AppendLine(string.Format("<td class='text-right {1}'><strong>{0}</strong></td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_B_DETAIL)), l.ANNEE_B_DETAIL.Replace("/", "")));
                                                    }
                                                }

                                            }
                                            else
                                            {
                                                if (l.RUBR_ETAT_LIBELLE.Trim().Length <= 1)
                                                {
                                                    sb.AppendLine(string.Format("<td class='text-right'></td>"));
                                                }
                                                else
                                                {
                                                    sb.AppendLine(string.Format("<td class='text-right {1}'><strong>{0}</strong></td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_B_DETAIL)), l.ANNEE_B_DETAIL.Replace("/", "")));
                                                }
                                            }
                                        }

                                        sb.AppendLine("</tr>");
                                    }

                                }
                                else
                                {
                                    sb.AppendLine(string.Format("<tr data_code='{0}'>", lr.RUBR_ETAT_CODE.ToString().Trim()));
                                    // sb.AppendLine(string.Format("<td class='text-left'>{0}</td>", lr.CODE_POSTE.ToString()));
                                    sb.AppendLine(string.Format("<td class='text-left'>{0}</td>", lr.RUBR_ETAT_LIBELLE.ToString()));

                                    var liste_valeur2 = service.AnafiAfficheLiasse(11, idDossier, lr.RUBR_ETAT_CODE.ToString().Trim(), "SA");

                                    int j = 0;
                                    int v = 0;
                                    v = Convert.ToInt32(liste_valeur2.Count) - 3;
                                    foreach (var l in liste_valeur2)
                                    {

                                        if (liste_valeur2.Count > 3)
                                        {
                                            j++;
                                            if (v < j)
                                            {
                                                if (l.RUBR_ETAT_LIBELLE.Trim().Length <= 1)
                                                {
                                                    sb.AppendLine(string.Format("<td class='text-right'></td>"));
                                                }
                                                else
                                                {
                                                    sb.AppendLine(string.Format("<td class='text-right {1}'>{0}</td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_B_DETAIL)), l.ANNEE_B_DETAIL.Replace("/", "")));
                                                }
                                            }

                                        }
                                        else
                                        {
                                            if (l.RUBR_ETAT_LIBELLE.Trim().Length <= 1)
                                            {
                                                sb.AppendLine(string.Format("<td class='text-right'></td>"));
                                            }
                                            else
                                            {
                                                sb.AppendLine(string.Format("<td class='text-right {1}'>{0}</td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_B_DETAIL)), l.ANNEE_B_DETAIL.Replace("/", "")));
                                            }
                                        }
                                    }

                                    sb.AppendLine("</tr>");
                                }


                            }
                        }

                        if (lr.RUBR_ETAT_CODE.Trim() == "BAA")
                        {
                            //string[]  // TabLOTP = null;

                            sbt.AppendLine("<table id='totauxActif' class='table-hover table table-bordered text-center'>");
                            sbt.AppendLine(string.Format("<tr style='background-color:rgba(210, 210, 210, 1);'>"));

                            sbt.AppendLine(string.Format("<td class='text-left'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE));
                            // TabLOTA = new string[Convert.ToInt32(liste_annee.Count)];
                            int p = 0;
                            var liste_valeur3 = service.AnafiAfficheLiasse(11, idDossier, lr.RUBR_ETAT_CODE.ToString().Trim(), "SA");

                            int j = 0;
                            int v = 0;
                            v = Convert.ToInt32(liste_valeur3.Count) - 3;
                            foreach (var l in liste_valeur3)
                            {

                                if (liste_valeur3.Count > 3)
                                {
                                    j++;
                                    if (v < j)
                                    {
                                        sbt.AppendLine(string.Format("<td class='text-right' width=15%>{0}</td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_B_DETAIL))));
                                        // TabLOTA[p] = l.VALEUR_B_DETAIL.ToString();
                                        p++;
                                    }

                                }
                                else
                                {
                                    sbt.AppendLine(string.Format("<td class='text-right' width=15%>{0}</td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_B_DETAIL))));
                                    // TabLOTA[p] = l.VALEUR_B_DETAIL.ToString();
                                    p++;
                                }
                            }
                            sbt.AppendLine("</table>");
                            DIVtotauxActif.InnerHtml = sbt.ToString();


                        }

                    }

                    sb.AppendLine("</tbody>");
                    sb.AppendLine("</table>");
                }
                else
                {
                    sb.AppendLine("<div class='col-lg-6 col-sm-6 col-md-6' >");
                    sb.AppendLine("<table id='' class='table table-hover table-bordered text-center'>");
                    sb.AppendLine("<thead class='table-heigth'>");
                    sb.AppendLine(string.Format("<tr><th>Actifs</th>"));
                    sb.AppendLine(string.Format("<th width=23%></th>"));


                    sb.AppendLine("</thead>");
                    sb.AppendLine("<tbody>");

                    var liste_libelle = service.AnafiAfficheLiasse(0, "", "", "BIA");

                    foreach (var lr in liste_libelle)
                    {
                        string SENS = "";
                        if (lr.RUBR_ETAT_CODE.Trim().Length > 2)
                        {
                            SENS = lr.RUBR_ETAT_CODE.ToString().Trim().Substring(0, 3);
                        }

                        if (SENS == "BA1" || SENS == "BA2" || SENS == "BA3" || SENS == "BA4")
                        {
                            if (lr.RUBR_ETAT_CODE.ToString().Trim().Length == 3)
                            {
                                if (lr.RUBR_ETAT_CODE.ToString().Trim() == "BA4")
                                {
                                    sb.AppendLine(string.Format("<tr data_code='{0}'>", lr.RUBR_ETAT_CODE.ToString().Trim()));
                                    // sb.AppendLine(string.Format("<td class='text-left'>{0}</td>", lr.CODE_POSTE.ToString()));
                                    sb.AppendLine(string.Format("<td class='text-left'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE.ToString()));
                                    sb.AppendLine(string.Format("<td width=23%></td>"));

                                    sb.AppendLine("</tr>");

                                }
                                else
                                {
                                    sb.AppendLine(string.Format("<tr data_code='{0}' style='background-color:#ddd'>", lr.RUBR_ETAT_CODE.ToString().Trim()));
                                    // sb.AppendLine(string.Format("<td class='text-left'>{0}</td>", lr.CODE_POSTE.ToString()));


                                    if (lr.RUBR_ETAT_LIBELLE.Trim().Length <= 1)
                                    {
                                        sb.AppendLine(string.Format("<td class='text-left' style='color:#fff'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE.ToString()));
                                        sb.AppendLine(string.Format("<td width=23%></td>"));
                                    }
                                    else
                                    {
                                        sb.AppendLine(string.Format("<td class='text-left'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE.ToString()));
                                        sb.AppendLine(string.Format("<td width=23%></td>"));
                                    }



                                    sb.AppendLine("</tr>");
                                }

                            }
                            else
                            {
                                if (lr.RUBR_ETAT_CODE.ToString().Trim().Length == 4)
                                {
                                    if (lr.RUBR_ETAT_CODE.ToString().Trim() == "BA31" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BA32" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BA33")
                                    {
                                        sb.AppendLine(string.Format("<tr data_code='{0}'>", lr.RUBR_ETAT_CODE.ToString().Trim()));
                                        // sb.AppendLine(string.Format("<td class='text-left'>{0}</td>", lr.CODE_POSTE.ToString()));
                                        sb.AppendLine(string.Format("<td class='text-left'>{0}</td>", lr.RUBR_ETAT_LIBELLE.ToString()));
                                        sb.AppendLine(string.Format("<td width=23%></td>"));

                                        sb.AppendLine("</tr>");
                                    }
                                    else
                                    {
                                        sb.AppendLine(string.Format("<tr data_code='{0}'>", lr.RUBR_ETAT_CODE.ToString().Trim()));
                                        // sb.AppendLine(string.Format("<td class='text-left'>{0}</td>", lr.CODE_POSTE.ToString()));
                                        sb.AppendLine(string.Format("<td class='text-left'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE.ToString()));
                                        sb.AppendLine(string.Format("<td width=23%></td>"));

                                        sb.AppendLine("</tr>");
                                    }

                                }
                                else
                                {
                                    sb.AppendLine(string.Format("<tr data_code='{0}'>", lr.RUBR_ETAT_CODE.ToString().Trim()));
                                    // sb.AppendLine(string.Format("<td class='text-left'>{0}</td>", lr.CODE_POSTE.ToString()));
                                    sb.AppendLine(string.Format("<td class='text-left'>{0}</td>", lr.RUBR_ETAT_LIBELLE.ToString()));
                                    sb.AppendLine(string.Format("<td width=23%></td>"));

                                    sb.AppendLine("</tr>");
                                }

                            }
                        }

                        if (lr.RUBR_ETAT_CODE.Trim() == "BAA")
                        {
                            //string[]  // TabLOTP = null;

                            sbt.AppendLine("<table id='totauxActif' class='table-hover table table-bordered text-center'>");
                            sbt.AppendLine(string.Format("<tr style='background-color:rgba(210, 210, 210, 1);'>"));

                            sbt.AppendLine(string.Format("<td class='text-left'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE));
                            sbt.AppendLine(string.Format("<td width=23%></td>"));
                            sbt.AppendLine("</table>");
                            DIVtotauxActif.InnerHtml = sbt.ToString();


                        }

                    }

                    sb.AppendLine("</tbody>");
                    sb.AppendLine("</table>");
                }
                sb.AppendLine("</div>");

                if (liste_annee.Count != 0)
                {
                    sb.AppendLine("<div class='col-lg-6 col-sm-6 col-md-6' >");
                    sb.AppendLine("<table id='' class='table table-hover table-bordered text-center'>");
                    sb.AppendLine("<thead class='table-heigth'>");
                    sb.AppendLine(string.Format("<tr><th>Passifs</th>"));

                    if (liste_annee.Count > 3)
                    {
                        int j = 0;
                        int v = 0;
                        int i = 0;
                        v = Convert.ToInt32(liste_annee.Count) - 3;
                        foreach (var lr in liste_annee)
                        {
                            j++;
                            if (v < j)
                            {
                                if (i < Convert.ToInt32(liste_annee.Count))
                                {
                                    sb.AppendLine(string.Format("<th onclick='transfertval($(this))' width=15%>{0}</th>", lr.ANNEE_DETAIL));
                                    //TabLOT[i] = lr.ANNEE_DETAIL;
                                }
                            }

                            i++;
                        }
                    }
                    else
                    {
                        int i = 0;
                        foreach (var lr in liste_annee)
                        {

                            if (i < Convert.ToInt32(liste_annee.Count))
                            {
                                sb.AppendLine(string.Format("<th onclick='transfertval($(this))' width=15%>{0}</th>", lr.ANNEE_DETAIL));
                                //TabLOT[i] = lr.ANNEE_DETAIL;
                            }
                            i++;
                        }
                    }

                    sb.AppendLine("</thead>");
                    sb.AppendLine("<tbody>");

                    var liste_libelle = service.AnafiAfficheLiasse(0, "", "", "BIA");

                    foreach (var lr in liste_libelle)
                    {
                        string SENS = "";
                        if (lr.RUBR_ETAT_CODE.Trim().Length > 2)
                        {
                            SENS = lr.RUBR_ETAT_CODE.ToString().Trim().Substring(0, 3);
                        }

                        if (SENS == "BA6" || SENS == "BA7" || SENS == "BA8" || SENS == "BA9" || SENS == "BAX")
                        {
                            if (lr.RUBR_ETAT_CODE.ToString().Trim().Length == 3)
                            {
                                if (lr.RUBR_ETAT_CODE.ToString().Trim() == "BA8")
                                {
                                    sb.AppendLine(string.Format("<tr data_code='{0}' style='background-color:#b7abab'>", lr.RUBR_ETAT_CODE.ToString().Trim()));
                                    // sb.AppendLine(string.Format("<td class='text-left'>{0}</td>", lr.CODE_POSTE.ToString()));
                                    //sb.AppendLine(string.Format("<td class='text-left'>{0}</td>", lr.RUBR_ETAT_LIBELLE.ToString()));

                                    if (lr.RUBR_ETAT_LIBELLE.Trim().Length <= 1)
                                    {
                                        sb.AppendLine(string.Format("<td class='text-left' style='color:#fff'>{0}</td>", lr.RUBR_ETAT_LIBELLE.ToString()));
                                    }
                                    else
                                    {
                                        sb.AppendLine(string.Format("<td class='text-left'>{0}</td>", lr.RUBR_ETAT_LIBELLE.ToString()));
                                    }
                                    var liste_valeur4 = service.AnafiAfficheLiasse(11, idDossier, lr.RUBR_ETAT_CODE.ToString().Trim(), "SA");
                                    int j = 0;
                                    int v = 0;
                                    v = Convert.ToInt32(liste_valeur4.Count) - 3;
                                    foreach (var l in liste_valeur4)
                                    {

                                        if (liste_valeur4.Count > 3)
                                        {
                                            j++;
                                            if (v < j)
                                            {
                                                sb.AppendLine(string.Format("<td class='text-right {1}' width=15%>{0}</td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_B_DETAIL)), l.ANNEE_B_DETAIL.Replace("/", "")));
                                            }

                                        }
                                        else
                                        {
                                            sb.AppendLine(string.Format("<td class='text-right {1}' width=15%>{0}</td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_B_DETAIL)), l.ANNEE_B_DETAIL.Replace("/", "")));
                                        }
                                    }


                                    sb.AppendLine("</tr>");
                                }
                                else
                                {
                                    sb.AppendLine(string.Format("<tr data_code='{0}' style='background-color:#ddd'>", lr.RUBR_ETAT_CODE.ToString().Trim()));
                                    // sb.AppendLine(string.Format("<td class='text-left'>{0}</td>", lr.CODE_POSTE.ToString()));
                                    //sb.AppendLine(string.Format("<td class='text-left'>{0}</td>", lr.RUBR_ETAT_LIBELLE.ToString()));

                                    if (lr.RUBR_ETAT_LIBELLE.Trim().Length <= 1)
                                    {
                                        sb.AppendLine(string.Format("<td class='text-left' style='color:#fff'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE.ToString()));
                                    }
                                    else
                                    {
                                        sb.AppendLine(string.Format("<td class='text-left'><strong><strong>{0}</strong></strong></td>", lr.RUBR_ETAT_LIBELLE.ToString()));
                                    }
                                    var liste_valeur4 = service.AnafiAfficheLiasse(11, idDossier, lr.RUBR_ETAT_CODE.ToString().Trim(), "SA");
                                    int j = 0;
                                    int v = 0;
                                    v = Convert.ToInt32(liste_valeur4.Count) - 3;
                                    foreach (var l in liste_valeur4)
                                    {

                                        if (liste_valeur4.Count > 3)
                                        {
                                            j++;
                                            if (v < j)
                                            {
                                                sb.AppendLine(string.Format("<td class='text-right {1}' width=15%><strong><strong>{0}</strong></strong></td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_B_DETAIL)), l.ANNEE_B_DETAIL.Replace("/", "")));
                                            }

                                        }
                                        else
                                        {
                                            sb.AppendLine(string.Format("<td class='text-right {1}' width=15%><strong><strong>{0}</strong></strong></td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_B_DETAIL)), l.ANNEE_B_DETAIL.Replace("/", "")));
                                        }
                                    }


                                    sb.AppendLine("</tr>");
                                }



                            }
                            else
                            {
                                if (lr.RUBR_ETAT_CODE.ToString().Trim() == "BA66" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BAXI")
                                {
                                    sb.AppendLine(string.Format("<tr data_code='{0}'>", lr.RUBR_ETAT_CODE.ToString().Trim()));
                                    // sb.AppendLine(string.Format("<td class='text-left'>{0}</td>", lr.CODE_POSTE.ToString()));
                                    sb.AppendLine(string.Format("<td class='text-left'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE.ToString()));

                                    var liste_valeur5 = service.AnafiAfficheLiasse(11, idDossier, lr.RUBR_ETAT_CODE.ToString().Trim(), "SA");
                                    int j = 0;
                                    int v = 0;
                                    v = Convert.ToInt32(liste_valeur5.Count) - 3;
                                    foreach (var l in liste_valeur5)
                                    {

                                        if (liste_valeur5.Count > 3)
                                        {
                                            j++;
                                            if (v < j)
                                            {
                                                if (l.RUBR_ETAT_LIBELLE.Trim().Length <= 1)
                                                {
                                                    sb.AppendLine(string.Format("<td class='text-right' width=15%></td>"));
                                                }
                                                else
                                                {
                                                    sb.AppendLine(string.Format("<td class='text-right {1}' width=15%><strong>{0}</strong></td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_B_DETAIL)), l.ANNEE_B_DETAIL.Replace("/", "")));
                                                }
                                            }

                                        }
                                        else
                                        {
                                            if (l.RUBR_ETAT_LIBELLE.Trim().Length <= 1)
                                            {
                                                sb.AppendLine(string.Format("<td class='text-right' width=15%></td>"));
                                            }
                                            else
                                            {
                                                sb.AppendLine(string.Format("<td class='text-right {1}' width=15%><strong>{0}</strong></td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_B_DETAIL)), l.ANNEE_B_DETAIL.Replace("/", "")));
                                            }
                                        }
                                    }

                                    sb.AppendLine("</tr>");

                                }
                                else
                                {

                                    sb.AppendLine(string.Format("<tr data_code='{0}'>", lr.RUBR_ETAT_CODE.ToString().Trim()));
                                    // sb.AppendLine(string.Format("<td class='text-left'>{0}</td>", lr.CODE_POSTE.ToString()));
                                    sb.AppendLine(string.Format("<td class='text-left'>{0}</td>", lr.RUBR_ETAT_LIBELLE.ToString()));

                                    var liste_valeur5 = service.AnafiAfficheLiasse(11, idDossier, lr.RUBR_ETAT_CODE.ToString().Trim(), "SA");
                                    int j = 0;
                                    int v = 0;
                                    v = Convert.ToInt32(liste_valeur5.Count) - 3;
                                    foreach (var l in liste_valeur5)
                                    {

                                        if (liste_valeur5.Count > 3)
                                        {
                                            j++;
                                            if (v < j)
                                            {
                                                if (l.RUBR_ETAT_LIBELLE.Trim().Length <= 1)
                                                {
                                                    sb.AppendLine(string.Format("<td class='text-right' width=15%></td>"));
                                                }
                                                else
                                                {
                                                    sb.AppendLine(string.Format("<td class='text-right {1}' width=15%>{0}</td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_B_DETAIL)), l.ANNEE_B_DETAIL.Replace("/", "")));
                                                }
                                            }

                                        }
                                        else
                                        {
                                            if (l.RUBR_ETAT_LIBELLE.Trim().Length <= 1)
                                            {
                                                sb.AppendLine(string.Format("<td class='text-right' width=15%></td>"));
                                            }
                                            else
                                            {
                                                sb.AppendLine(string.Format("<td class='text-right {1}' width=15%>{0}</td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_B_DETAIL)), l.ANNEE_B_DETAIL.Replace("/", "")));
                                            }
                                        }
                                    }

                                    sb.AppendLine("</tr>");
                                }
                            }
                        }
                        if (lr.RUBR_ETAT_CODE.Trim() == "BAP")
                        {
                            //string[]  // TabLOTP = null;

                            sbv.AppendLine("<table id='totauxPassif' class='table-hover table table-bordered text-center'>");
                            sbv.AppendLine(string.Format("<tr style='background-color:rgba(210, 210, 210, 1);'>"));

                            sbv.AppendLine(string.Format("<td class='text-left'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE));
                            // TabLOTP = new string[Convert.ToInt32(liste_annee.Count)];
                            int p = 0;
                            var liste_valeur6 = service.AnafiAfficheLiasse(11, idDossier, lr.RUBR_ETAT_CODE.ToString().Trim(), "SA");
                            int j = 0;
                            int v = 0;
                            v = Convert.ToInt32(liste_valeur6.Count) - 3;
                            foreach (var l in liste_valeur6)
                            {

                                if (liste_valeur6.Count > 3)
                                {
                                    j++;
                                    if (v < j)
                                    {
                                        sbv.AppendLine(string.Format("<td class='text-right' width=15%>{0}</td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_B_DETAIL))));
                                        // TabLOTP[p] = l.VALEUR_B_DETAIL.ToString();
                                        p++;
                                    }

                                }
                                else
                                {
                                    sbv.AppendLine(string.Format("<td class='text-right' width=15%>{0}</td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_B_DETAIL))));
                                    // TabLOTP[p] = l.VALEUR_B_DETAIL.ToString();
                                    p++;
                                }
                            }
                            sbv.AppendLine("</table>");
                            DIVtotauxPassif.InnerHtml = sbv.ToString();


                            sbe.AppendLine("<table id='totauxPassif' class='table-hover table table-bordered text-center'>");
                            sbe.AppendLine(string.Format("<tr style='background-color:rgba(210, 210, 210, 1);'>"));

                            sbe.AppendLine(string.Format("<td class='text-left'>Ecart</td>"));
                            // TabLOTP = new string[Convert.ToInt32(liste_annee.Count)];
                            p = 0;
                            //var liste_valeur = service.AnafiAfficheLiasse(1, idDossier, lr.RUBR_ETAT_CODE.ToString().Trim(), "");
                            j = 0;
                            v = 0;
                            v = Convert.ToInt32(liste_valeur6.Count) - 3;
                            foreach (var l in liste_valeur6)
                            {

                                if (liste_valeur6.Count > 3)
                                {
                                    j++;
                                    if (v < j)
                                    {
                                        sbe.AppendLine(string.Format("<td class='text-right' width=15%></td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_B_DETAIL))));
                                        // TabLOTP[p] = l.VALEUR_B_DETAIL.ToString();
                                        p++;
                                    }

                                }
                                else
                                {
                                    sbe.AppendLine(string.Format("<td class='text-right' width=15%></td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_B_DETAIL))));
                                    // TabLOTP[p] = l.VALEUR_B_DETAIL.ToString();
                                    p++;
                                }
                            }


                            sbe.AppendLine("</table>");
                            DivecartsActifPassif.InnerHtml = sbe.ToString();
                            //TPAnnee3.InnerHtml = "<strong>" + Convert.ToString(string.Format("{0:#,##0}", lr.ANNEE3)) + "</strong>";
                        }
                    }

                    sb.AppendLine("</tbody>");
                    sb.AppendLine("</table>");

                    DIVtotauxActif.Visible = true;
                    DIVtotauxPassif.Visible = true;
                    DivecartsActifPassif.Visible = true;
                }
                else
                {
                    sb.AppendLine("<div class='col-lg-6 col-sm-6 col-md-6' >");
                    sb.AppendLine("<table id='' class='table table-hover table-bordered text-center'>");
                    sb.AppendLine("<thead class='table-heigth'>");
                    sb.AppendLine(string.Format("<tr><th>Passifs</th>"));
                    sb.AppendLine(string.Format("<th width=23%></th>"));

                    sb.AppendLine("</thead>");
                    sb.AppendLine("<tbody>");

                    var liste_libelle = service.AnafiAfficheLiasse(0, "", "", "BIA");

                    foreach (var lr in liste_libelle)
                    {
                        string SENS = "";
                        if (lr.RUBR_ETAT_CODE.Trim().Length > 2)
                        {
                            SENS = lr.RUBR_ETAT_CODE.ToString().Trim().Substring(0, 3);
                        }

                        if (SENS == "BA6" || SENS == "BA7" || SENS == "BA8" || SENS == "BA9" || SENS == "BAX")
                        {
                            if (lr.RUBR_ETAT_CODE.ToString().Trim().Length == 3)
                            {
                                if (lr.RUBR_ETAT_CODE.ToString().Trim() == "BA8")
                                {
                                    sb.AppendLine(string.Format("<tr data_code='{0}' style='background-color:#b7abab'>", lr.RUBR_ETAT_CODE.ToString().Trim()));
                                    // sb.AppendLine(string.Format("<td class='text-left'>{0}</td>", lr.CODE_POSTE.ToString()));
                                    //sb.AppendLine(string.Format("<td class='text-left'>{0}</td>", lr.RUBR_ETAT_LIBELLE.ToString()));

                                    if (lr.RUBR_ETAT_LIBELLE.Trim().Length <= 1)
                                    {
                                        sb.AppendLine(string.Format("<td class='text-left' style='color:#fff'>{0}</td>", lr.RUBR_ETAT_LIBELLE.ToString()));
                                        sb.AppendLine(string.Format("<td width=23%></td>"));
                                    }
                                    else
                                    {
                                        sb.AppendLine(string.Format("<td class='text-left'>{0}</td>", lr.RUBR_ETAT_LIBELLE.ToString()));
                                        sb.AppendLine(string.Format("<td width=23%></td>"));
                                    }
                                    sb.AppendLine("</tr>");
                                }
                                else
                                {
                                    sb.AppendLine(string.Format("<tr data_code='{0}' style='background-color:#ddd'>", lr.RUBR_ETAT_CODE.ToString().Trim()));
                                    // sb.AppendLine(string.Format("<td class='text-left'>{0}</td>", lr.CODE_POSTE.ToString()));
                                    //sb.AppendLine(string.Format("<td class='text-left'>{0}</td>", lr.RUBR_ETAT_LIBELLE.ToString()));

                                    if (lr.RUBR_ETAT_LIBELLE.Trim().Length <= 1)
                                    {
                                        sb.AppendLine(string.Format("<td class='text-left' style='color:#fff'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE.ToString()));
                                        sb.AppendLine(string.Format("<td width=23%></td>"));
                                    }
                                    else
                                    {
                                        sb.AppendLine(string.Format("<td class='text-left'><strong><strong>{0}</strong></strong></td>", lr.RUBR_ETAT_LIBELLE.ToString()));
                                        sb.AppendLine(string.Format("<td width=23%></td>"));
                                    }
                                    sb.AppendLine("</tr>");
                                }



                            }
                            else
                            {
                                if (lr.RUBR_ETAT_CODE.ToString().Trim() == "BA66" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BAXI")
                                {
                                    sb.AppendLine(string.Format("<tr data_code='{0}'>", lr.RUBR_ETAT_CODE.ToString().Trim()));
                                    // sb.AppendLine(string.Format("<td class='text-left'>{0}</td>", lr.CODE_POSTE.ToString()));
                                    sb.AppendLine(string.Format("<td class='text-left'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE.ToString()));
                                    sb.AppendLine(string.Format("<td width=23%></td>"));
                                    sb.AppendLine("</tr>");

                                }
                                else
                                {

                                    sb.AppendLine(string.Format("<tr data_code='{0}'>", lr.RUBR_ETAT_CODE.ToString().Trim()));
                                    // sb.AppendLine(string.Format("<td class='text-left'>{0}</td>", lr.CODE_POSTE.ToString()));
                                    sb.AppendLine(string.Format("<td class='text-left'>{0}</td>", lr.RUBR_ETAT_LIBELLE.ToString()));
                                    sb.AppendLine(string.Format("<td width=23%></td>"));

                                    sb.AppendLine("</tr>");
                                }
                            }
                        }
                        if (lr.RUBR_ETAT_CODE.Trim() == "BAP")
                        {
                            //string[]  // TabLOTP = null;

                            sbv.AppendLine("<table id='totauxPassif' class='table-hover table table-bordered text-center'>");
                            sbv.AppendLine(string.Format("<tr style='background-color:rgba(210, 210, 210, 1);'>"));

                            sbv.AppendLine(string.Format("<td class='text-left'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE));
                            sbv.AppendLine(string.Format("<td width=23%></td>"));
                            // TabLOTP = new string[Convert.ToInt32(liste_annee.Count)];

                            sbv.AppendLine("</table>");
                            DIVtotauxPassif.InnerHtml = sbv.ToString();


                            sbe.AppendLine("<table id='totauxPassif' class='table-hover table table-bordered text-center'>");
                            sbe.AppendLine(string.Format("<tr style='background-color:rgba(210, 210, 210, 1);'>"));

                            sbe.AppendLine(string.Format("<td class='text-left'>Ecart</td>"));
                            sbe.AppendLine(string.Format("<td width=23%></td>"));
                            sbe.AppendLine("</table>");
                            DivecartsActifPassif.InnerHtml = sbe.ToString();
                            //TPAnnee3.InnerHtml = "<strong>" + Convert.ToString(string.Format("{0:#,##0}", lr.ANNEE3)) + "</strong>";
                        }
                    }
                    sb.AppendLine("</tbody>");
                    sb.AppendLine("</table>");

                    DIVtotauxActif.Visible = true;
                    DIVtotauxPassif.Visible = true;
                    DivecartsActifPassif.Visible = true;
                }



                sb.AppendLine("</div>");
            }
            else
            {
                if (DdlRubrique.Text != "Bilan")
                {
                    DIVtotauxActif.Visible = false;
                    DIVtotauxPassif.Visible = false;
                    DivecartsActifPassif.Visible = false;
                }
            }
            ListDFinanciers.InnerHtml = sb.ToString();

        }

        public void affichecompteresultatBN()
        {

            //string[]  // TabLOTA = null;

            if (Session["id_dossier"] == null) Response.Redirect("~/Scoring/Connexion.aspx");

            var idDossier = Session["id_dossier"].ToString();
            Session.Add("id_dossier", idDossier);
            if (DdlRubrique.Text == "Compte de résultat")
            {
                Type_anafi = "BN";
                CompteResult.Visible = true;
                divCharge.Visible = true;
                divProduit.Visible = true;

                var liste_annee = service.AnafiAfficheLiasse(7, idDossier, "", "SN");
                var nombre_annee = service.AnafiAfficheLiasse(8, idDossier, "", "SN");

                if (liste_annee.Count != 0)
                {
                    sb.AppendLine("<div class='col-lg-6 col-sm-6 col-md-6' >");
                    sb.AppendLine("<table id='' class='table table-hover table-bordered text-center'>");
                    sb.AppendLine("<thead class='table-heigth'>");
                    sb.AppendLine(string.Format("<tr><th>Charges</th>"));

                    if (liste_annee.Count > 3)
                    {
                        int j = 0;
                        int v = 0;
                        int i = 0;
                        v = Convert.ToInt32(liste_annee.Count) - 3;
                        foreach (var lr in liste_annee)
                        {
                            j++;
                            if (v < j)
                            {
                                if (i < Convert.ToInt32(liste_annee.Count))
                                {
                                    sb.AppendLine(string.Format("<th onclick='transfertval($(this))' width=15%>{0}</th>", lr.ANNEE_DETAIL));
                                    //TabLOT[i] = lr.ANNEE_DETAIL;
                                }
                            }

                            i++;
                        }
                    }
                    else
                    {
                        int i = 0;
                        foreach (var lr in liste_annee)
                        {

                            if (i < Convert.ToInt32(liste_annee.Count))
                            {
                                sb.AppendLine(string.Format("<th onclick='transfertval($(this))' width=15%>{0}</th>", lr.ANNEE_DETAIL));
                                //TabLOT[i] = lr.ANNEE_DETAIL;
                            }
                            i++;
                        }
                    }
                    sb.AppendLine("</thead>");
                    sb.AppendLine("<tbody>");

                    var liste_libelle = service.AnafiAfficheLiasse(0, "", "", "CRN");

                    foreach (var lr in liste_libelle)
                    {
                        string SENS = "";
                        if (lr.RUBR_ETAT_CODE.Trim().Length > 2)
                        {
                            SENS = lr.RUBR_ETAT_CODE.ToString().Trim().Substring(0, 3);
                        }

                        if (SENS == "CC0" || SENS == "CC1" || SENS == "CC2" || SENS == "CC3" || SENS == "CC4" || SENS == "CC5")
                        {
                            if (lr.RUBR_ETAT_CODE.ToString().Trim().Length == 3)
                            {
                                sb.AppendLine(string.Format("<tr data_code='{0}' style='background-color:#ddd'>", lr.RUBR_ETAT_CODE.ToString().Trim()));


                                if (lr.RUBR_ETAT_LIBELLE.Trim().Length <= 1)
                                {
                                    sb.AppendLine(string.Format("<td class='text-left' style='color:#fff'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE.ToString()));
                                }
                                else
                                {
                                    sb.AppendLine(string.Format("<td class='text-left'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE.ToString()));
                                }

                                var liste_valeur = service.AnafiAfficheLiasse(10, idDossier, lr.RUBR_ETAT_CODE.ToString().Trim(), "SN");

                                int j = 0;
                                int v = 0;
                                v = Convert.ToInt32(liste_valeur.Count) - 3;
                                foreach (var l in liste_valeur)
                                {

                                    if (liste_valeur.Count > 3)
                                    {
                                        j++;
                                        if (v < j)
                                        {
                                            if (l.RUBR_ETAT_LIBELLE.Trim().Length <= 1)
                                            {
                                                sb.AppendLine(string.Format("<td class='text-right'></td>"));
                                            }
                                            else
                                            {
                                                sb.AppendLine(string.Format("<td class='text-right {1}'><strong>{0}</strong></td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_CR_DETAIL)), l.ANNEE_CR_DETAIL.Replace("/", "")));

                                               // sb.AppendLine(string.Format("<td class='text-right'><strong>{0}</strong></td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_CR_DETAIL))));
                                            }
                                        }

                                    }
                                    else
                                    {
                                        if (l.RUBR_ETAT_LIBELLE.Trim().Length <= 1)
                                        {
                                            sb.AppendLine(string.Format("<td class='text-right'></td>"));
                                        }
                                        else
                                        {
                                            sb.AppendLine(string.Format("<td class='text-right {1}'><strong>{0}</strong></td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_CR_DETAIL)), l.ANNEE_CR_DETAIL.Replace("/", "")));

                                           // sb.AppendLine(string.Format("<td class='text-right'><strong>{0}</strong></td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_CR_DETAIL))));
                                        }
                                    }
                                }




                                sb.AppendLine("</tr>");
                            }
                            else
                            {
                                sb.AppendLine(string.Format("<tr data_code='{0}'>", lr.RUBR_ETAT_CODE.ToString().Trim()));
                                sb.AppendLine(string.Format("<td class='text-left'>{0}</td>", lr.RUBR_ETAT_LIBELLE.ToString()));

                                var liste_valeur = service.AnafiAfficheLiasse(10, idDossier, lr.RUBR_ETAT_CODE.ToString().Trim(), "SN");
                                int j = 0;
                                int v = 0;
                                v = Convert.ToInt32(liste_valeur.Count) - 3;
                                foreach (var l in liste_valeur)
                                {

                                    if (liste_valeur.Count > 3)
                                    {
                                        j++;
                                        if (v < j)
                                        {
                                            if (l.RUBR_ETAT_LIBELLE.Trim().Length <= 1)
                                            {
                                                sb.AppendLine(string.Format("<td class='text-right'></td>"));
                                            }
                                            else
                                            {
                                                sb.AppendLine(string.Format("<td class='text-right {1}'>{0}</td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_CR_DETAIL)), l.ANNEE_CR_DETAIL.Replace("/", "")));

                                                //sb.AppendLine(string.Format("<td class='text-right'>{0}</td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_CR_DETAIL))));
                                            }
                                        }

                                    }
                                    else
                                    {
                                        if (l.RUBR_ETAT_LIBELLE.Trim().Length <= 1)
                                        {
                                            sb.AppendLine(string.Format("<td class='text-right'></td>"));
                                        }
                                        else
                                        {
                                            sb.AppendLine(string.Format("<td class='text-right {1}'>{0}</td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_CR_DETAIL)), l.ANNEE_CR_DETAIL.Replace("/", "")));

                                           // sb.AppendLine(string.Format("<td class='text-right'>{0}</td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_CR_DETAIL))));
                                        }
                                    }
                                }


                                sb.AppendLine("</tr>");

                            }
                        }

                        if (lr.RUBR_ETAT_CODE.Trim() == "CC")
                        {



                            sbt.AppendLine(string.Format("<table id='{0}' class='table-hover table table-bordered text-center'>", lr.RUBR_ETAT_CODE.Trim()));
                            sbt.AppendLine(string.Format("<tr style='background-color:rgba(210, 210, 210, 1);'>"));

                            sbt.AppendLine(string.Format("<td class='text-left'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE));
                            int p = 0;
                            var liste_valeur = service.AnafiAfficheLiasse(10, idDossier, lr.RUBR_ETAT_CODE.ToString().Trim(), "SN");

                            int j = 0;
                            int v = 0;
                            v = Convert.ToInt32(liste_valeur.Count) - 3;
                            foreach (var l in liste_valeur)
                            {

                                if (liste_valeur.Count > 3)
                                {
                                    j++;
                                    if (v < j)
                                    {
                                        sbt.AppendLine(string.Format("<td  width=15% class='text-right'><strong>{0}</strong></td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_CR_DETAIL))));
                                        // TabLOTA[p] = l.VALEUR_B_DETAIL.ToString();
                                        p++;
                                    }

                                }
                                else
                                {
                                    sbt.AppendLine(string.Format("<td  width=15% class='text-right'><strong>{0}</strong></td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_CR_DETAIL))));
                                    // TabLOTA[p] = l.VALEUR_B_DETAIL.ToString();
                                    p++;
                                }
                            }
                            sbt.AppendLine("</table>");
                            divCharge.InnerHtml = sbt.ToString();

                            //sb.AppendLine(string.Format("<tr data_code='{0}' style='background-color:rgba(210, 210, 210, 1);'>", lr.RUBR_ETAT_CODE.ToString().Trim()));

                            //sb.AppendLine(string.Format("<td class='text-left'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE));
                            // TabLOTA = new string[Convert.ToInt32(liste_annee.Count)];
                            //int p = 0;
                            //var liste_valeur = service.AnafiAfficheLiasse(10, idDossier, lr.RUBR_ETAT_CODE.ToString().Trim(), "SN");

                            //int j = 0;
                            //int v = 0;
                            //v = Convert.ToInt32(liste_valeur.Count) - 3;
                            //foreach (var l in liste_valeur)
                            //{

                            //    if (liste_valeur.Count > 3)
                            //    {
                            //        j++;
                            //        if (v < j)
                            //        {
                            //            sb.AppendLine(string.Format("<td class='text-right'>{0}</td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_CR_DETAIL))));
                            //            // TabLOTA[p] = l.VALEUR_B_DETAIL.ToString();
                            //            p++;
                            //        }

                            //    }
                            //    else
                            //    {
                            //        sb.AppendLine(string.Format("<td class='text-right'>{0}</td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_CR_DETAIL))));
                            //        // TabLOTA[p] = l.VALEUR_B_DETAIL.ToString();
                            //        p++;
                            //    }
                            //}

                        }

                    }

                    sb.AppendLine("</tbody>");
                    sb.AppendLine("</table>");
                }
                else
                {
                    sb.AppendLine("<div class='col-lg-6 col-sm-6 col-md-6' >");
                    sb.AppendLine("<table id='' class='table table-hover table-bordered text-center'>");
                    sb.AppendLine("<thead class='table-heigth'>");
                    sb.AppendLine(string.Format("<tr><th>Charges</th>"));
                    sb.AppendLine(string.Format("<th width=23%></th>"));

                    sb.AppendLine("</thead>");
                    sb.AppendLine("<tbody>");

                    var liste_libelle = service.AnafiAfficheLiasse(0, "", "", "CRN");

                    foreach (var lr in liste_libelle)
                    {
                        string SENS = "";
                        if (lr.RUBR_ETAT_CODE.Trim().Length > 2)
                        {
                            SENS = lr.RUBR_ETAT_CODE.ToString().Trim().Substring(0, 3);
                        }

                        if (SENS == "CC0" || SENS == "CC1" || SENS == "CC2" || SENS == "CC3" || SENS == "CC4" || SENS == "CC5")
                        {
                            if (lr.RUBR_ETAT_CODE.ToString().Trim().Length == 3)
                            {
                                sb.AppendLine(string.Format("<tr data_code='{0}' style='background-color:#ddd'>", lr.RUBR_ETAT_CODE.ToString().Trim()));


                                if (lr.RUBR_ETAT_LIBELLE.Trim().Length <= 1)
                                {
                                    sb.AppendLine(string.Format("<td class='text-left' style='color:#fff'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE.ToString()));
                                    sb.AppendLine(string.Format("<td></td>"));
                                }
                                else
                                {
                                    sb.AppendLine(string.Format("<td class='text-left'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE.ToString()));
                                    sb.AppendLine(string.Format("<td></td>"));
                                }


                                sb.AppendLine("</tr>");
                            }
                            else
                            {
                                sb.AppendLine(string.Format("<tr data_code='{0}'>", lr.RUBR_ETAT_CODE.ToString().Trim()));
                                sb.AppendLine(string.Format("<td class='text-left'>{0}</td>", lr.RUBR_ETAT_LIBELLE.ToString()));
                                sb.AppendLine(string.Format("<td></td>"));
                                sb.AppendLine("</tr>");

                            }
                        }

                        if (lr.RUBR_ETAT_CODE.Trim() == "CC")
                        {
                            sbt.AppendLine(string.Format("<table id='{0}' class='table-hover table table-bordered text-center'>", lr.RUBR_ETAT_CODE.Trim()));
                            sbt.AppendLine(string.Format("<tr style='background-color:rgba(210, 210, 210, 1);'>"));

                            sbt.AppendLine(string.Format("<td class='text-left'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE));
                            sbt.AppendLine(string.Format("<td width='23%'></td>"));
                            sbt.AppendLine("</table>");
                            divCharge.InnerHtml = sbt.ToString();

                            //sb.AppendLine(string.Format("<tr style='background-color:rgba(210, 210, 210, 1);'>"));

                            //sb.AppendLine(string.Format("<td class='text-left'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE));
                            //sb.AppendLine(string.Format("<td></td>"));

                        }

                    }

                    sb.AppendLine("</tbody>");
                    sb.AppendLine("</table>");
                }
                sb.AppendLine("</div>");

                if (liste_annee.Count != 0)
                {
                    sb.AppendLine("<div class='col-lg-6 col-sm-6 col-md-6' >");
                    sb.AppendLine("<table id='' class='table table-hover table-bordered text-center'>");
                    sb.AppendLine("<thead class='table-heigth'>");
                    sb.AppendLine(string.Format("<tr><th>Produits</th>"));

                    if (liste_annee.Count > 3)
                    {
                        int j = 0;
                        int v = 0;
                        int i = 0;
                        v = Convert.ToInt32(liste_annee.Count) - 3;
                        foreach (var lr in liste_annee)
                        {
                            j++;
                            if (v < j)
                            {
                                if (i < Convert.ToInt32(liste_annee.Count))
                                {
                                    sb.AppendLine(string.Format("<th onclick='transfertval($(this))' width=15%>{0}</th>", lr.ANNEE_DETAIL));
                                    //TabLOT[i] = lr.ANNEE_DETAIL;
                                }
                            }

                            i++;
                        }
                    }
                    else
                    {
                        int i = 0;
                        foreach (var lr in liste_annee)
                        {

                            if (i < Convert.ToInt32(liste_annee.Count))
                            {
                                sb.AppendLine(string.Format("<th onclick='transfertval($(this))' width=15%>{0}</th>", lr.ANNEE_DETAIL));
                                //TabLOT[i] = lr.ANNEE_DETAIL;
                            }
                            i++;
                        }
                    }

                    sb.AppendLine("</thead>");
                    sb.AppendLine("<tbody>");

                    var liste_libelle = service.AnafiAfficheLiasse(0, "", "", "CRN");

                    //sbv.AppendLine(string.Format("<table id='' class='table-hover table table-bordered text-center matb'>", lr.RUBR_ETAT_CODE.Trim()));
                    sbv.AppendLine(string.Format("<table id='' class='table-hover table table-bordered text-center matb'>"));
                    foreach (var lr in liste_libelle)
                    {
                        string SENS = "";
                        if (lr.RUBR_ETAT_CODE.Trim().Length > 2)
                        {
                            SENS = lr.RUBR_ETAT_CODE.ToString().Trim().Substring(0, 3);
                        }

                        if (SENS == "CP0" || SENS == "CP1" || SENS == "CP2" || SENS == "CP3" || SENS == "CP4" || SENS == "CP5" || SENS == "CP6" || SENS == "CP7" || SENS == "CP8")
                        {
                            if (lr.RUBR_ETAT_CODE.ToString().Trim().Length == 3)
                            {


                                if (lr.RUBR_ETAT_CODE.ToString().Trim() == "CP7" || lr.RUBR_ETAT_CODE.ToString().Trim() == "CP8")
                                {


                                    if (SENS == "CP8")
                                    {
                                        sbv.AppendLine(string.Format("<tr data_code='{0}'>", lr.RUBR_ETAT_CODE.ToString().Trim()));
                                        sbv.AppendLine(string.Format("<td class='text-left'>{0}</td>", lr.RUBR_ETAT_LIBELLE.ToString()));

                                        var liste_valeur = service.AnafiAfficheLiasse(10, idDossier, lr.RUBR_ETAT_CODE.ToString().Trim(), "SN");
                                        int j = 0;
                                        int v = 0;
                                        v = Convert.ToInt32(liste_valeur.Count) - 3;
                                        foreach (var l in liste_valeur)
                                        {

                                            if (liste_valeur.Count > 3)
                                            {
                                                j++;
                                                if (v < j)
                                                {
                                                    if (l.RUBR_ETAT_LIBELLE.Trim().Length <= 1)
                                                    {
                                                        sbv.AppendLine(string.Format("<td class='text-right'></td>"));
                                                    }
                                                    else
                                                    {
                                                        sbv.AppendLine(string.Format("<td class='text-right {1}'>{0}</td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_CR_DETAIL)), l.ANNEE_CR_DETAIL.Replace("/", "")));

                                                        //sbv.AppendLine(string.Format("<td class='text-right'>{0}</td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_CR_DETAIL))));
                                                    }
                                                }

                                            }
                                            else
                                            {
                                                if (l.RUBR_ETAT_LIBELLE.Trim().Length <= 1)
                                                {
                                                    sbv.AppendLine(string.Format("<td class='text-right'></td>"));
                                                }
                                                else
                                                {
                                                    sbv.AppendLine(string.Format("<td class='text-right {1}'>{0}</td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_CR_DETAIL)), l.ANNEE_CR_DETAIL.Replace("/", "")));

                                                    //sbv.AppendLine(string.Format("<td class='text-right'>{0}</td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_CR_DETAIL))));
                                                }
                                            }
                                        }

                                        sbv.AppendLine("</tr>");
                                    }
                                    else
                                    {
                                        sbv.AppendLine(string.Format("<tr style='background-color:rgba(210, 210, 210, 1);'>"));

                                        if (lr.RUBR_ETAT_LIBELLE.Trim().Length <= 1)
                                        {
                                            sbv.AppendLine(string.Format("<td class='text-left' style='color:#fff'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE.ToString()));
                                        }
                                        else
                                        {
                                            sbv.AppendLine(string.Format("<td class='text-left'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE.ToString()));
                                        }
                                        var liste_valeur = service.AnafiAfficheLiasse(10, idDossier, lr.RUBR_ETAT_CODE.ToString().Trim(), "SN");
                                        int j = 0;
                                        int v = 0;
                                        v = Convert.ToInt32(liste_valeur.Count) - 3;
                                        foreach (var l in liste_valeur)
                                        {

                                            if (liste_valeur.Count > 3)
                                            {
                                                j++;
                                                if (v < j)
                                                {
                                                    sbv.AppendLine(string.Format("<td width=15% class='text-right {1}'><strong>{0}</strong></td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_CR_DETAIL)), l.ANNEE_CR_DETAIL.Replace("/", "")));

                                                   // sbv.AppendLine(string.Format("<td  width=15% class='text-right'><strong>{0}</strong></td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_CR_DETAIL))));
                                                }

                                            }
                                            else
                                            {
                                                sbv.AppendLine(string.Format("<td width=15% class='text-right {1}'><strong>{0}</strong></td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_CR_DETAIL)), l.ANNEE_CR_DETAIL.Replace("/", "")));

                                                //sbv.AppendLine(string.Format("<td  width=15% class='text-right'><strong>{0}</strong></td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_CR_DETAIL))));
                                            }
                                        }
                                        sbv.AppendLine("</tr>");
                                    }

                                }
                                else
                                {

                                    sb.AppendLine(string.Format("<tr data_code='{0}' style='background-color:#ddd'>", lr.RUBR_ETAT_CODE.ToString().Trim()));

                                    if (lr.RUBR_ETAT_LIBELLE.Trim().Length <= 1)
                                    {
                                        sb.AppendLine(string.Format("<td class='text-left' style='color:#fff'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE.ToString()));
                                    }
                                    else
                                    {
                                        sb.AppendLine(string.Format("<td class='text-left'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE.ToString()));
                                    }
                                    var liste_valeur = service.AnafiAfficheLiasse(10, idDossier, lr.RUBR_ETAT_CODE.ToString().Trim(), "SN");
                                    int j = 0;
                                    int v = 0;
                                    v = Convert.ToInt32(liste_valeur.Count) - 3;
                                    foreach (var l in liste_valeur)
                                    {

                                        if (liste_valeur.Count > 3)
                                        {
                                            j++;
                                            if (v < j)
                                            {
                                                sb.AppendLine(string.Format("<td width=15% class='text-right {1}'><strong>{0}</strong></td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_CR_DETAIL)), l.ANNEE_CR_DETAIL.Replace("/", "")));

                                                //sb.AppendLine(string.Format("<td class='text-right'><strong>{0}</strong></td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_CR_DETAIL))));
                                            }

                                        }
                                        else
                                        {
                                            sb.AppendLine(string.Format("<td width=15% class='text-right {1}'><strong>{0}</strong></td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_CR_DETAIL)), l.ANNEE_CR_DETAIL.Replace("/", "")));

                                           // sb.AppendLine(string.Format("<td class='text-right'><strong>{0}</strong></td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_CR_DETAIL))));
                                        }
                                    }

                                    sb.AppendLine("</tr>");
                                }
                            }
                            else
                            {
                                if (lr.RUBR_ETAT_CODE.ToString().Trim() != "CP6C")
                                {
                                    sb.AppendLine(string.Format("<tr data_code='{0}'>", lr.RUBR_ETAT_CODE.ToString().Trim()));
                                    sb.AppendLine(string.Format("<td class='text-left'>{0}</td>", lr.RUBR_ETAT_LIBELLE.ToString()));

                                    var liste_valeur = service.AnafiAfficheLiasse(10, idDossier, lr.RUBR_ETAT_CODE.ToString().Trim(), "SN");
                                    int j = 0;
                                    int v = 0;
                                    v = Convert.ToInt32(liste_valeur.Count) - 3;
                                    foreach (var l in liste_valeur)
                                    {

                                        if (liste_valeur.Count > 3)
                                        {
                                            j++;
                                            if (v < j)
                                            {
                                                if (l.RUBR_ETAT_LIBELLE.Trim().Length <= 1)
                                                {
                                                    sb.AppendLine(string.Format("<td class='text-right'></td>"));
                                                }
                                                else
                                                {
                                                    sb.AppendLine(string.Format("<td class='text-right {1}'>{0}</td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_CR_DETAIL)), l.ANNEE_CR_DETAIL.Replace("/", "")));

                                                   // sb.AppendLine(string.Format("<td class='text-right'>{0}</td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_CR_DETAIL))));
                                                }
                                            }

                                        }
                                        else
                                        {
                                            if (l.RUBR_ETAT_LIBELLE.Trim().Length <= 1)
                                            {
                                                sb.AppendLine(string.Format("<td class='text-right'></td>"));
                                            }
                                            else
                                            {
                                                sb.AppendLine(string.Format("<td class='text-right {1}'>{0}</td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_CR_DETAIL)), l.ANNEE_CR_DETAIL.Replace("/", "")));

                                                //sb.AppendLine(string.Format("<td class='text-right'>{0}</td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_CR_DETAIL))));
                                            }
                                        }
                                    }

                                    sb.AppendLine("</tr>");
                                }

                            }
                        }

                        if (lr.RUBR_ETAT_CODE.Trim() == "CP")
                        {
                            sb.AppendLine(string.Format("<tr style='background-color:rgba(210, 210, 210, 1);'>"));

                            sb.AppendLine(string.Format("<td class='text-left'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE));
                            // TabLOTP = new string[Convert.ToInt32(liste_annee.Count)];
                            int p = 0;
                            var liste_valeur = service.AnafiAfficheLiasse(10, idDossier, lr.RUBR_ETAT_CODE.ToString().Trim(), "SN");
                            int j = 0;
                            int v = 0;
                            v = Convert.ToInt32(liste_valeur.Count) - 3;
                            foreach (var l in liste_valeur)
                            {

                                if (liste_valeur.Count > 3)
                                {
                                    j++;
                                    if (v < j)
                                    {
                                        sb.AppendLine(string.Format("<td class='text-right'>{0}</td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_CR_DETAIL))));
                                        // TabLOTP[p] = l.VALEUR_B_DETAIL.ToString();
                                        p++;
                                    }

                                }
                                else
                                {
                                    sb.AppendLine(string.Format("<td class='text-right'>{0}</td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_CR_DETAIL))));
                                    // TabLOTP[p] = l.VALEUR_B_DETAIL.ToString();
                                    p++;
                                }
                            }

                        }
                    }

                    sb.AppendLine("</tbody>");
                    sb.AppendLine("</table>");

                    sbv.AppendLine("</table>");
                    //divProduit.InnerHtml = sbv.ToString();

                }
                else
                {
                    sb.AppendLine("<div class='col-lg-6 col-sm-6 col-md-6' >");
                    sb.AppendLine("<table id='' class='table table-hover table-bordered text-center'>");
                    sb.AppendLine("<thead class='table-heigth'>");
                    sb.AppendLine(string.Format("<tr><th>Produits</th>"));
                    sb.AppendLine(string.Format("<th width=23%></th>"));

                    sb.AppendLine("</thead>");
                    sb.AppendLine("<tbody>");

                    var liste_libelle = service.AnafiAfficheLiasse(0, "", "", "CRN");

                    //sbv.AppendLine(string.Format("<table id='{0}' class='table-hover table table-bordered text-center matb'>", lr.RUBR_ETAT_CODE.Trim()));
                    sbv.AppendLine(string.Format("<table id='' class='table-hover table table-bordered text-center matb'>"));

                    foreach (var lr in liste_libelle)
                    {
                        string SENS = "";
                        if (lr.RUBR_ETAT_CODE.Trim().Length > 2)
                        {
                            SENS = lr.RUBR_ETAT_CODE.ToString().Trim().Substring(0, 3);
                        }

                        if (SENS == "CP0" || SENS == "CP1" || SENS == "CP2" || SENS == "CP3" || SENS == "CP4" || SENS == "CP5" || SENS == "CP6" || SENS == "CP7" || SENS == "CP8")
                        {
                            if (lr.RUBR_ETAT_CODE.ToString().Trim().Length == 3)
                            {

                                if (lr.RUBR_ETAT_CODE.ToString().Trim() == "CP7" || lr.RUBR_ETAT_CODE.ToString().Trim() == "CP8")
                                {


                                    if (SENS == "CP8")
                                    {
                                        sbv.AppendLine(string.Format("<tr data_code='{0}'>", lr.RUBR_ETAT_CODE.ToString().Trim()));
                                        sbv.AppendLine(string.Format("<td class='text-left'>{0}</td>", lr.RUBR_ETAT_LIBELLE.ToString()));
                                        sbv.AppendLine(string.Format("<td width='15%' ></td>"));
                                        sbv.AppendLine("</tr>");
                                    }
                                    else
                                    {
                                        //sbv.AppendLine(string.Format("<tr  width=15% style='background-color:rgba(210, 210, 210, 1);'>"));

                                        //sbv.AppendLine(string.Format("<tr data_code='{0}' style='background-color:#ddd'>", lr.RUBR_ETAT_CODE.ToString().Trim()));
                                        sbv.AppendLine(string.Format("<tr data_code='{0}' style='background-color:rgba(210, 210, 210, 1);'>", lr.RUBR_ETAT_CODE.ToString().Trim()));

                                        if (lr.RUBR_ETAT_LIBELLE.Trim().Length <= 1)
                                        {
                                            sbv.AppendLine(string.Format("<td class='text-left' style='color:#fff'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE.ToString()));
                                            sbv.AppendLine(string.Format("<td width='23%'></td>"));
                                        }
                                        else
                                        {
                                            sbv.AppendLine(string.Format("<td class='text-left'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE.ToString()));
                                            sbv.AppendLine(string.Format("<td width='23%'></td>"));
                                        }
                                        sbv.AppendLine("</tr>");
                                    }



                                }
                                else
                                {

                                    sb.AppendLine(string.Format("<tr data_code='{0}' style='background-color:#ddd'>", lr.RUBR_ETAT_CODE.ToString().Trim()));

                                    if (lr.RUBR_ETAT_LIBELLE.Trim().Length <= 1)
                                    {
                                        sb.AppendLine(string.Format("<td class='text-left' style='color:#fff'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE.ToString()));
                                        sb.AppendLine(string.Format("<td></td>"));
                                    }
                                    else
                                    {
                                        sb.AppendLine(string.Format("<td class='text-left'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE.ToString()));
                                        sb.AppendLine(string.Format("<td></td>"));
                                    }

                                    sb.AppendLine("</tr>");
                                }


                            }
                            else
                            {
                                if (lr.RUBR_ETAT_CODE.ToString().Trim() != "CP6C")
                                {
                                    sb.AppendLine(string.Format("<tr data_code='{0}'>", lr.RUBR_ETAT_CODE.ToString().Trim()));
                                    sb.AppendLine(string.Format("<td class='text-left'>{0}</td>", lr.RUBR_ETAT_LIBELLE.ToString()));
                                    sb.AppendLine(string.Format("<td></td>"));

                                    sb.AppendLine("</tr>");
                                }

                            }
                        }


                        if (lr.RUBR_ETAT_CODE.Trim() == "CP")
                        {
                            sb.AppendLine(string.Format("<tr style='background-color:rgba(210, 210, 210, 1);'>"));

                            sb.AppendLine(string.Format("<td class='text-left'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE));
                            sb.AppendLine(string.Format("<td></td>"));
                        }
                    }

                    sb.AppendLine("</tbody>");
                    sb.AppendLine("</table>");


                    sbv.AppendLine("</table>");
                    //divProduit.InnerHtml = sbv.ToString();

                    DIVtotauxActif.Visible = true;
                    DIVtotauxPassif.Visible = true;
                }

                DIVtotauxActif.Visible = true;
                DIVtotauxPassif.Visible = true;

                sb.AppendLine("</div>");
            }
            else
            {
                if (DdlRubrique.Text != "Bilan")
                {
                    DIVtotauxActif.Visible = true;
                    DIVtotauxPassif.Visible = true;
                    DivecartsActifPassif.Visible = false;
                }
            }
            divProduit.InnerHtml = sbv.ToString();

            ListDFinanciers.InnerHtml = sb.ToString();
        }
        public void afficheBCompteResultatSA()
        {
            if (Session["id_dossier"] == null) Response.Redirect("~/Scoring/Connexion.aspx");

            var idDossier = Session["id_dossier"].ToString();
            Session.Add("id_dossier", idDossier);
            if (DdlRubrique.Text == "Compte de résultat")
            {
                Type_anafi = "BN";
                Div1.Visible = true;
                Div2.Visible = true;
                var liste_annee = service.AnafiAfficheLiasse(7, idDossier, "", "SA");
                var nombre_annee = service.AnafiAfficheLiasse(8, idDossier, "", "SA");

                if (liste_annee.Count != 0)
                {
                    sb.AppendLine("<div class='col-lg-6 col-sm-6 col-md-6' >");
                    sb.AppendLine("<table id='' class='table table-hover table-bordered text-center'>");
                    sb.AppendLine("<thead class='table-heigth'>");
                    sb.AppendLine(string.Format("<tr><th>Charges</th>"));

                    if (liste_annee.Count > 3)
                    {
                        int j = 0;
                        int v = 0;
                        int i = 0;
                        v = Convert.ToInt32(liste_annee.Count) - 3;
                        foreach (var lr in liste_annee)
                        {
                            j++;
                            if (v < j)
                            {
                                if (i < Convert.ToInt32(liste_annee.Count))
                                {
                                    sb.AppendLine(string.Format("<th width=15%>{0}</th>", lr.ANNEE_DETAIL));
                                    //TabLOT[i] = lr.ANNEE_DETAIL;
                                }
                            }

                            i++;
                        }
                    }
                    else
                    {
                        int i = 0;
                        foreach (var lr in liste_annee)
                        {

                            if (i < Convert.ToInt32(liste_annee.Count))
                            {
                                sb.AppendLine(string.Format("<th width=15%>{0}</th>", lr.ANNEE_DETAIL));
                                //TabLOT[i] = lr.ANNEE_DETAIL;
                            }
                            i++;
                        }
                    }
                    sb.AppendLine("</thead>");
                    sb.AppendLine("<tbody>");

                    var liste_libelle = service.AnafiAfficheLiasse(0, "", "", "CRA");

                    foreach (var lr in liste_libelle)
                    {
                        string SENS = "";
                        if (lr.RUBR_ETAT_CODE.Trim().Length > 2)
                        {
                            SENS = lr.RUBR_ETAT_CODE.ToString().Trim().Substring(0, 3);
                        }

                        if (SENS == "CA0" || SENS == "CA1" || SENS == "CA2")
                        {
                            if (lr.RUBR_ETAT_CODE.ToString().Trim().Length == 3)
                            {
                                sb.AppendLine(string.Format("<tr data_code='{0}' style='background-color:#ddd'>", lr.RUBR_ETAT_CODE.ToString().Trim()));


                                if (lr.RUBR_ETAT_LIBELLE.Trim().Length <= 1)
                                {
                                    sb.AppendLine(string.Format("<td class='text-left' style='color:#fff'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE.ToString()));
                                }
                                else
                                {
                                    sb.AppendLine(string.Format("<td class='text-left'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE.ToString()));
                                }

                                var liste_valeur = service.AnafiAfficheLiasse(12, idDossier, lr.RUBR_ETAT_CODE.ToString().Trim(), "SA");

                                int j = 0;
                                int v = 0;
                                v = Convert.ToInt32(liste_valeur.Count) - 3;
                                foreach (var l in liste_valeur)
                                {

                                    if (liste_valeur.Count > 3)
                                    {
                                        j++;
                                        if (v < j)
                                        {
                                            if (l.RUBR_ETAT_LIBELLE.Trim().Length <= 1)
                                            {
                                                sb.AppendLine(string.Format("<td class='text-right'></td>"));
                                            }
                                            else
                                            {
                                                sb.AppendLine(string.Format("<td class='text-right'><strong>{0}</strong></td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_CR_DETAIL))));
                                            }
                                        }

                                    }
                                    else
                                    {
                                        if (l.RUBR_ETAT_LIBELLE.Trim().Length <= 1)
                                        {
                                            sb.AppendLine(string.Format("<td class='text-right'></td>"));
                                        }
                                        else
                                        {
                                            sb.AppendLine(string.Format("<td class='text-right'><strong>{0}</strong></td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_CR_DETAIL))));
                                        }
                                    }
                                }




                                sb.AppendLine("</tr>");
                            }
                            else
                            {
                                sb.AppendLine(string.Format("<tr data_code='{0}'>", lr.RUBR_ETAT_CODE.ToString().Trim()));
                                sb.AppendLine(string.Format("<td class='text-left'>{0}</td>", lr.RUBR_ETAT_LIBELLE.ToString()));

                                var liste_valeur = service.AnafiAfficheLiasse(12, idDossier, lr.RUBR_ETAT_CODE.ToString().Trim(), "SA");
                                int j = 0;
                                int v = 0;
                                v = Convert.ToInt32(liste_valeur.Count) - 3;
                                foreach (var l in liste_valeur)
                                {

                                    if (liste_valeur.Count > 3)
                                    {
                                        j++;
                                        if (v < j)
                                        {
                                            if (l.RUBR_ETAT_LIBELLE.Trim().Length <= 1)
                                            {
                                                sb.AppendLine(string.Format("<td class='text-right'></td>"));
                                            }
                                            else
                                            {
                                                sb.AppendLine(string.Format("<td class='text-right'>{0}</td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_CR_DETAIL))));
                                            }
                                        }

                                    }
                                    else
                                    {
                                        if (l.RUBR_ETAT_LIBELLE.Trim().Length <= 1)
                                        {
                                            sb.AppendLine(string.Format("<td class='text-right'></td>"));
                                        }
                                        else
                                        {
                                            sb.AppendLine(string.Format("<td class='text-right'>{0}</td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_CR_DETAIL))));
                                        }
                                    }
                                }


                                sb.AppendLine("</tr>");

                            }
                        }

                        if (lr.RUBR_ETAT_CODE.Trim() == "CA")
                        {
                            sb.AppendLine(string.Format("<tr style='background-color:rgba(210, 210, 210, 1);'>"));

                            sb.AppendLine(string.Format("<td class='text-left'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE));
                            // TabLOTA = new string[Convert.ToInt32(liste_annee.Count)];
                            int p = 0;
                            var liste_valeur = service.AnafiAfficheLiasse(12, idDossier, lr.RUBR_ETAT_CODE.ToString().Trim(), "SA");

                            int j = 0;
                            int v = 0;
                            v = Convert.ToInt32(liste_valeur.Count) - 3;
                            foreach (var l in liste_valeur)
                            {

                                if (liste_valeur.Count > 3)
                                {
                                    j++;
                                    if (v < j)
                                    {
                                        sb.AppendLine(string.Format("<td class='text-right'>{0}</td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_CR_DETAIL))));
                                        // TabLOTA[p] = l.VALEUR_B_DETAIL.ToString();
                                        p++;
                                    }

                                }
                                else
                                {
                                    sb.AppendLine(string.Format("<td class='text-right'>{0}</td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_CR_DETAIL))));
                                    // TabLOTA[p] = l.VALEUR_B_DETAIL.ToString();
                                    p++;
                                }
                            }

                        }

                    }

                    sb.AppendLine("</tbody>");
                    sb.AppendLine("</table>");
                }
                else
                {
                    sb.AppendLine("<div class='col-lg-6 col-sm-6 col-md-6' >");
                    sb.AppendLine("<table id='' class='table table-hover table-bordered text-center'>");
                    sb.AppendLine("<thead class='table-heigth'>");
                    sb.AppendLine(string.Format("<tr><th>Charges</th>"));
                    sb.AppendLine(string.Format("<th width=23%></th>"));

                    sb.AppendLine("</thead>");
                    sb.AppendLine("<tbody>");

                    var liste_libelle = service.AnafiAfficheLiasse(0, "", "", "CRA");

                    foreach (var lr in liste_libelle)
                    {
                        string SENS = "";
                        if (lr.RUBR_ETAT_CODE.Trim().Length > 2)
                        {
                            SENS = lr.RUBR_ETAT_CODE.ToString().Trim().Substring(0, 3);
                        }

                        if (SENS == "CA0" || SENS == "CA1" || SENS == "CA2" || SENS == "CA3")
                        {
                            if (lr.RUBR_ETAT_CODE.ToString().Trim().Length == 3)
                            {
                                sb.AppendLine(string.Format("<tr data_code='{0}' style='background-color:#ddd'>", lr.RUBR_ETAT_CODE.ToString().Trim()));


                                if (lr.RUBR_ETAT_LIBELLE.Trim().Length <= 1)
                                {
                                    sb.AppendLine(string.Format("<td class='text-left' style='color:#fff'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE.ToString()));
                                    sb.AppendLine(string.Format("<td></td>"));
                                }
                                else
                                {
                                    sb.AppendLine(string.Format("<td class='text-left'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE.ToString()));
                                    sb.AppendLine(string.Format("<td></td>"));
                                }


                                sb.AppendLine("</tr>");
                            }
                            else
                            {
                                sb.AppendLine(string.Format("<tr data_code='{0}'>", lr.RUBR_ETAT_CODE.ToString().Trim()));
                                sb.AppendLine(string.Format("<td class='text-left'>{0}</td>", lr.RUBR_ETAT_LIBELLE.ToString()));
                                sb.AppendLine(string.Format("<td></td>"));
                                sb.AppendLine("</tr>");

                            }
                        }

                        if (lr.RUBR_ETAT_CODE.Trim() == "CA")
                        {
                            sb.AppendLine(string.Format("<tr style='background-color:rgba(210, 210, 210, 1);'>"));

                            sb.AppendLine(string.Format("<td class='text-left'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE));
                            sb.AppendLine(string.Format("<td></td>"));

                        }

                    }

                    sb.AppendLine("</tbody>");
                    sb.AppendLine("</table>");
                }
                sb.AppendLine("</div>");

                if (liste_annee.Count != 0)
                {
                    sb.AppendLine("<div class='col-lg-6 col-sm-6 col-md-6' >");
                    sb.AppendLine("<table id='' class='table table-hover table-bordered text-center'>");
                    sb.AppendLine("<thead class='table-heigth'>");
                    sb.AppendLine(string.Format("<tr><th>Produits</th>"));

                    if (liste_annee.Count > 3)
                    {
                        int j = 0;
                        int v = 0;
                        int i = 0;
                        v = Convert.ToInt32(liste_annee.Count) - 3;
                        foreach (var lr in liste_annee)
                        {
                            j++;
                            if (v < j)
                            {
                                if (i < Convert.ToInt32(liste_annee.Count))
                                {
                                    sb.AppendLine(string.Format("<th width=15%>{0}</th>", lr.ANNEE_DETAIL));
                                    //TabLOT[i] = lr.ANNEE_DETAIL;
                                }
                            }

                            i++;
                        }
                    }
                    else
                    {
                        int i = 0;
                        foreach (var lr in liste_annee)
                        {

                            if (i < Convert.ToInt32(liste_annee.Count))
                            {
                                sb.AppendLine(string.Format("<th width=15%>{0}</th>", lr.ANNEE_DETAIL));
                                //TabLOT[i] = lr.ANNEE_DETAIL;
                            }
                            i++;
                        }
                    }

                    sb.AppendLine("</thead>");
                    sb.AppendLine("<tbody>");

                    var liste_libelle = service.AnafiAfficheLiasse(0, "", "", "CRA");

                    foreach (var lr in liste_libelle)
                    {
                        string SENS = "";
                        if (lr.RUBR_ETAT_CODE.Trim().Length > 2)
                        {
                            SENS = lr.RUBR_ETAT_CODE.ToString().Trim().Substring(0, 3);
                        }

                        if (SENS == "CP0" || SENS == "CP1" || SENS == "CP2")
                        {
                            if (lr.RUBR_ETAT_CODE.ToString().Trim().Length == 3)
                            {
                                sb.AppendLine(string.Format("<tr data_code='{0}' style='background-color:#ddd'>", lr.RUBR_ETAT_CODE.ToString().Trim()));

                                if (lr.RUBR_ETAT_LIBELLE.Trim().Length <= 1)
                                {
                                    sb.AppendLine(string.Format("<td class='text-left' style='color:#fff'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE.ToString()));
                                }
                                else
                                {
                                    sb.AppendLine(string.Format("<td class='text-left'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE.ToString()));
                                }
                                var liste_valeur = service.AnafiAfficheLiasse(12, idDossier, lr.RUBR_ETAT_CODE.ToString().Trim(), "SA");
                                int j = 0;
                                int v = 0;
                                v = Convert.ToInt32(liste_valeur.Count) - 3;
                                foreach (var l in liste_valeur)
                                {

                                    if (liste_valeur.Count > 3)
                                    {
                                        j++;
                                        if (v < j)
                                        {
                                            sb.AppendLine(string.Format("<td class='text-right'><strong>{0}</strong></td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_CR_DETAIL))));
                                        }

                                    }
                                    else
                                    {
                                        sb.AppendLine(string.Format("<td class='text-right'><strong>{0}</strong></td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_CR_DETAIL))));
                                    }
                                }

                                sb.AppendLine("</tr>");
                            }
                            else
                            {
                                if (lr.RUBR_ETAT_CODE.ToString().Trim() == "CP1G" || lr.RUBR_ETAT_CODE.ToString().Trim() == "CP1I" || lr.RUBR_ETAT_CODE.ToString().Trim() == "CP2A")
                                {
                                    sb.AppendLine(string.Format("<tr data_code='{0}'>", lr.RUBR_ETAT_CODE.ToString().Trim()));
                                    sb.AppendLine(string.Format("<td class='text-left'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE.ToString()));

                                    var liste_valeur = service.AnafiAfficheLiasse(12, idDossier, lr.RUBR_ETAT_CODE.ToString().Trim(), "SA");
                                    int j = 0;
                                    int v = 0;
                                    v = Convert.ToInt32(liste_valeur.Count) - 3;
                                    foreach (var l in liste_valeur)
                                    {

                                        if (liste_valeur.Count > 3)
                                        {
                                            j++;
                                            if (v < j)
                                            {
                                                if (l.RUBR_ETAT_LIBELLE.Trim().Length <= 1)
                                                {
                                                    sb.AppendLine(string.Format("<td class='text-right'></td>"));
                                                }
                                                else
                                                {

                                                    sb.AppendLine(string.Format("<td class='text-right'><strong>{0}</strong></td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_CR_DETAIL))));
                                                }
                                            }

                                        }
                                        else
                                        {
                                            if (l.RUBR_ETAT_LIBELLE.Trim().Length <= 1)
                                            {
                                                sb.AppendLine(string.Format("<td class='text-right'></td>"));
                                            }
                                            else
                                            {

                                                sb.AppendLine(string.Format("<td class='text-right'><strong>{0}</strong></td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_CR_DETAIL))));
                                            }
                                        }
                                    }

                                    sb.AppendLine("</tr>");
                                }
                                else
                                {

                                    sb.AppendLine(string.Format("<tr data_code='{0}'>", lr.RUBR_ETAT_CODE.ToString().Trim()));
                                    sb.AppendLine(string.Format("<td class='text-left'>{0}</td>", lr.RUBR_ETAT_LIBELLE.ToString()));

                                    var liste_valeur = service.AnafiAfficheLiasse(12, idDossier, lr.RUBR_ETAT_CODE.ToString().Trim(), "SA");
                                    int j = 0;
                                    int v = 0;
                                    v = Convert.ToInt32(liste_valeur.Count) - 3;
                                    foreach (var l in liste_valeur)
                                    {

                                        if (liste_valeur.Count > 3)
                                        {
                                            j++;
                                            if (v < j)
                                            {
                                                if (l.RUBR_ETAT_LIBELLE.Trim().Length <= 1)
                                                {
                                                    sb.AppendLine(string.Format("<td class='text-right'></td>"));
                                                }
                                                else
                                                {

                                                    sb.AppendLine(string.Format("<td class='text-right'>{0}</td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_CR_DETAIL))));
                                                }
                                            }

                                        }
                                        else
                                        {
                                            if (l.RUBR_ETAT_LIBELLE.Trim().Length <= 1)
                                            {
                                                sb.AppendLine(string.Format("<td class='text-right'></td>"));
                                            }
                                            else
                                            {

                                                sb.AppendLine(string.Format("<td class='text-right'>{0}</td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_CR_DETAIL))));
                                            }
                                        }
                                    }

                                    sb.AppendLine("</tr>");
                                }
                            }
                        }
                        if (SENS == "CP3")
                        {
                            sb.AppendLine(string.Format("<tr data_code='{0}'>", lr.RUBR_ETAT_CODE.ToString().Trim()));
                            sb.AppendLine(string.Format("<td class='text-left'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE.ToString()));

                            var liste_valeur = service.AnafiAfficheLiasse(12, idDossier, lr.RUBR_ETAT_CODE.ToString().Trim(), "SA");
                            int j = 0;
                            int v = 0;
                            v = Convert.ToInt32(liste_valeur.Count) - 3;
                            foreach (var l in liste_valeur)
                            {

                                if (liste_valeur.Count > 3)
                                {
                                    j++;
                                    if (v < j)
                                    {
                                        if (l.RUBR_ETAT_LIBELLE.Trim().Length <= 1)
                                        {
                                            sb.AppendLine(string.Format("<td class='text-right'></td>"));
                                        }
                                        else
                                        {

                                            sb.AppendLine(string.Format("<td class='text-right'><strong>{0}</strong></td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_CR_DETAIL))));
                                        }
                                    }

                                }
                                else
                                {
                                    if (l.RUBR_ETAT_LIBELLE.Trim().Length <= 1)
                                    {
                                        sb.AppendLine(string.Format("<td class='text-right'></td>"));
                                    }
                                    else
                                    {

                                        sb.AppendLine(string.Format("<td class='text-right'><strong>{0}</strong></td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_CR_DETAIL))));
                                    }
                                }
                            }

                            sb.AppendLine("</tr>");
                        }
                        if (lr.RUBR_ETAT_CODE.Trim() == "CP")
                        {
                            sb.AppendLine(string.Format("<tr style='background-color:rgba(210, 210, 210, 1);'>"));

                            sb.AppendLine(string.Format("<td class='text-left'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE));
                            // TabLOTP = new string[Convert.ToInt32(liste_annee.Count)];
                            int p = 0;
                            var liste_valeur = service.AnafiAfficheLiasse(12, idDossier, lr.RUBR_ETAT_CODE.ToString().Trim(), "SA");
                            int j = 0;
                            int v = 0;
                            v = Convert.ToInt32(liste_valeur.Count) - 3;
                            foreach (var l in liste_valeur)
                            {

                                if (liste_valeur.Count > 3)
                                {
                                    j++;
                                    if (v < j)
                                    {
                                        sb.AppendLine(string.Format("<td class='text-right'>{0}</td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_CR_DETAIL))));
                                        // TabLOTP[p] = l.VALEUR_B_DETAIL.ToString();
                                        p++;
                                    }

                                }
                                else
                                {
                                    sb.AppendLine(string.Format("<td class='text-right'>{0}</td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_CR_DETAIL))));
                                    // TabLOTP[p] = l.VALEUR_B_DETAIL.ToString();
                                    p++;
                                }
                            }

                        }
                    }

                    sb.AppendLine("</tbody>");
                    sb.AppendLine("</table>");

                }
                else
                {
                    sb.AppendLine("<div class='col-lg-6 col-sm-6 col-md-6' >");
                    sb.AppendLine("<table id='' class='table table-hover table-bordered text-center'>");
                    sb.AppendLine("<thead class='table-heigth'>");
                    sb.AppendLine(string.Format("<tr><th>Produits</th>"));
                    sb.AppendLine(string.Format("<th width=23%></th>"));

                    sb.AppendLine("</thead>");
                    sb.AppendLine("<tbody>");

                    var liste_libelle = service.AnafiAfficheLiasse(0, "", "", "CRA");

                    foreach (var lr in liste_libelle)
                    {
                        string SENS = "";
                        if (lr.RUBR_ETAT_CODE.Trim().Length > 2)
                        {
                            SENS = lr.RUBR_ETAT_CODE.ToString().Trim().Substring(0, 3);
                        }

                        if (SENS == "CP0" || SENS == "CP1" || SENS == "CP2")
                        {
                            if (lr.RUBR_ETAT_CODE.ToString().Trim().Length == 3)
                            {
                                sb.AppendLine(string.Format("<tr data_code='{0}' style='background-color:#ddd'>", lr.RUBR_ETAT_CODE.ToString().Trim()));

                                if (lr.RUBR_ETAT_LIBELLE.Trim().Length <= 1)
                                {
                                    sb.AppendLine(string.Format("<td class='text-left' style='color:#fff'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE.ToString()));
                                    sb.AppendLine(string.Format("<td></td>"));
                                }
                                else
                                {
                                    sb.AppendLine(string.Format("<td class='text-left'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE.ToString()));
                                    sb.AppendLine(string.Format("<td></td>"));
                                }

                                sb.AppendLine("</tr>");
                            }
                            else
                            {
                                sb.AppendLine(string.Format("<tr data_code='{0}'>", lr.RUBR_ETAT_CODE.ToString().Trim()));
                                sb.AppendLine(string.Format("<td class='text-left'>{0}</td>", lr.RUBR_ETAT_LIBELLE.ToString()));
                                sb.AppendLine(string.Format("<td></td>"));

                                sb.AppendLine("</tr>");
                            }
                        }
                        if (SENS == "CP3")
                        {
                            sb.AppendLine(string.Format("<tr data_code='{0}'>", lr.RUBR_ETAT_CODE.ToString().Trim()));
                            sb.AppendLine(string.Format("<td class='text-left'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE.ToString()));
                            sb.AppendLine(string.Format("<td></td>"));
                        }

                        if (lr.RUBR_ETAT_CODE.Trim() == "CP")
                        {
                            sb.AppendLine(string.Format("<tr style='background-color:rgba(210, 210, 210, 1);'>"));

                            sb.AppendLine(string.Format("<td class='text-left'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE));
                            sb.AppendLine(string.Format("<td></td>"));
                        }
                    }

                    sb.AppendLine("</tbody>");
                    sb.AppendLine("</table>");

                }



                sb.AppendLine("</div>");
            }
            else
            {
                if (DdlRubrique.Text != "Bilan")
                {
                    DIVtotauxActif.Visible = false;
                    DIVtotauxPassif.Visible = false;
                    DivecartsActifPassif.Visible = false;
                }
            }
            ListDFinanciers.InnerHtml = sb.ToString();
        }

        public void afficheBilanGrandeMasseBN()
        {
            if (Session["id_dossier"] == null) Response.Redirect("~/Scoring/Connexion.aspx");

            var idDossier = Session["id_dossier"].ToString();
            Session.Add("id_dossier", idDossier);
            if (DdlRubrique.Text == "Bilan en grandes masses")
            {
                Type_anafi = "BN";
                Div1.Visible = true;
                Div2.Visible = true;


                CompteResult.Visible = false;
                divCharge.Visible = false;
                divProduit.Visible = false;

                var liste_annee = service.AnafiAfficheLiasse(7, idDossier, "", "SN");
                var nombre_annee = service.AnafiAfficheLiasse(8, idDossier, "", "SN");
                
                if (liste_annee.Count != 0)
                {
                    sb.AppendLine("<div class='col-lg-6col-sm-6 col-md-6' style=\"overflow-x:auto\" >");
                    sb.AppendLine("<table id='' class='table table-hover table-bordered text-center'>");
                    sb.AppendLine("<thead class='table-heigth'>");
                    sb.AppendLine(string.Format("<tr><th>Actifs</th>"));

                    if (liste_annee.Count > 3)
                    {
                        int j = 0;
                        int v = 0;
                        int i = 0;
                        v = Convert.ToInt32(liste_annee.Count) - 3;
                        foreach (var lr in liste_annee)
                        {
                            j++;
                            if (v < j)
                            {
                                if (i < Convert.ToInt32(liste_annee.Count))
                                {
                                    sb.AppendLine(string.Format("<th colspan=\"2\" width=15%>{0}</th>", lr.ANNEE_DETAIL));
                                    //TabLOT[i] = lr.ANNEE_DETAIL;
                                }
                            }

                            i++;
                        }
                    }
                    else
                    {
                        int i = 0;
                        foreach (var lr in liste_annee)
                        {

                            if (i < Convert.ToInt32(liste_annee.Count))
                            {
                                sb.AppendLine(string.Format("<th colspan=\"2\" width=15%>{0}</th>", lr.ANNEE_DETAIL));
                                //TabLOT[i] = lr.ANNEE_DETAIL;
                            }
                            i++;
                        }
                    }

                    sb.AppendLine("</thead>");
                    sb.AppendLine("<tbody>");

                    var liste_libelle = service.AnafiAfficheLiasse(0, "", "", "BIL");
                    string[] TabLOTN = null;
                    sbt.AppendLine("<table id='totauxActif' class='table-hover table table-bordered text-center'>");
                    foreach (var lr in liste_libelle)
                    {

                        string SENS = lr.RUBR_ETAT_CODE.ToString().Trim().Substring(0, 3);
                        if (SENS == "BI1" || SENS == "BI2" || SENS == "BI3")
                        {
                            if (lr.RUBR_ETAT_CODE.Trim().Length == 4)
                            {
                                if (lr.RUBR_ETAT_CODE.Trim() == "BI3Z" )
                                {
                                        //sbt.AppendLine("<table id='totauxActif' class='table-hover table table-bordered text-center'>");
                                        sbt.AppendLine(string.Format("<tr style='background-color:rgba(210, 210, 210, 1);'>"));

                                        sbt.AppendLine(string.Format("<td class='text-left'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE));
                                        // TabLOTA = new string[Convert.ToInt32(liste_annee.Count)];
                                        int pa = 0;
                                        var liste_valeur = service.AnafiAfficheLiasse(3, idDossier, lr.RUBR_ETAT_CODE.ToString().Trim(), "SN");

                                        int j = 0;
                                        int v = 0;
                                        v = Convert.ToInt32(liste_valeur.Count) - 3;
                                        foreach (var l in liste_valeur)
                                        {

                                            if (liste_valeur.Count > 3)
                                            {
                                                j++;
                                                if (v < j)
                                                {
                                                    //string k = "";
                                                    //k = TabLOTN[1];
                                                    //sbt.AppendLine(string.Format("<td class='text-left'>{0}</td>", Convert.ToString(string.Format("{0:#,##0}", k))));
                                                    sbt.AppendLine(string.Format("<td class='text-left' width=16%><strong>{0}</strong></td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_BGR_DETAIL))));
                                                    sbt.AppendLine(string.Format("<td class='text-right'><strong>{0}%</strong></td>", Convert.ToDecimal(l.TAUX_BGR_DETAIL).ToString("#,##0.##")));

                                                    //pa++;
                                                }

                                            }
                                            else
                                            {
                                                //string k = "";
                                                //k = TabLOTN[1];
                                                //sbt.AppendLine(string.Format("<td class='text-left'>{0}</td>", Convert.ToString(string.Format("{0:#,##0}", k))));
                                                sbt.AppendLine(string.Format("<td class='text-left' width=16%><strong>{0}</strong></td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_BGR_DETAIL))));
                                                sbt.AppendLine(string.Format("<td class='text-right'><strong>{0}%</strong></td>", Convert.ToDecimal(l.TAUX_BGR_DETAIL).ToString("#,##0.##")));

                                                //pa++;
                                            }
                                        }

                                        sbt.AppendLine("</tr>");
                                    
                                }
                                else
                                {
                                    if (lr.RUBR_ETAT_CODE.ToString().Trim() == "BI7Z")
                                    {


                                    }
                                    else
                                    {

                                        sb.AppendLine(string.Format("<tr data_code='{0}' style='background-color:rgba(210, 210, 210, 1);'>", lr.RUBR_ETAT_CODE.ToString().Trim()));
                                        sb.AppendLine(string.Format("<td class='text-left'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE.ToString()));
                                        // TabLOTP = new string[Convert.ToInt32(liste_annee.Count)];
                                        int p = 0;
                                        var liste_valeur = service.AnafiAfficheLiasse(3, idDossier, lr.RUBR_ETAT_CODE.ToString().Trim(), "SN");

                                        int j = 0;
                                        int v = 0;
                                        v = Convert.ToInt32(liste_valeur.Count) - 3;
                                        foreach (var l in liste_valeur)
                                        {

                                            if (liste_valeur.Count > 3)
                                            {
                                                j++;
                                                if (v < j)
                                                {
                                                    if (l.TYPE_ANAFI_A.Trim() == "SN")
                                                    {
                                                        sb.AppendLine(string.Format("<td class='text-right'><strong>{0}</strong></td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_BGR_DETAIL))));
                                                        sb.AppendLine(string.Format("<td class='text-right'><strong>{0}%</strong></td>", Convert.ToDecimal(l.TAUX_BGR_DETAIL).ToString("#,##0.##")));

                                                        // TabLOTA[p] = l.VALEUR_BGR_DETAIL.ToString();

                                                    }
                                                }

                                            }
                                            else
                                            {
                                                if (l.TYPE_ANAFI_A.Trim() == "SN")
                                                {
                                                    sb.AppendLine(string.Format("<td class='text-right'><strong>{0}</strong></td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_BGR_DETAIL))));
                                                    sb.AppendLine(string.Format("<td class='text-right'><strong>{0}%</strong></td>", Convert.ToDecimal(l.TAUX_BGR_DETAIL).ToString("#,##0.##")));
                                                    // TabLOTA[p] = l.VALEUR_BGR_DETAIL.ToString();

                                                }
                                            }
                                        }

                                        sb.AppendLine("</tr>");
                                    }
                                }

                                //sb.AppendLine("</tr>");

                            }
                            else
                            {
                                if(lr.RUBR_ETAT_CODE.Trim() == "BI3Z1"){

                                    sbt.AppendLine(string.Format("<tr data_code='{0}'>", lr.RUBR_ETAT_CODE.ToString().Trim()));
                                        sbt.AppendLine(string.Format("<td class='text-left'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE.ToString()));
                                        // TabLOTP = new string[Convert.ToInt32(liste_annee.Count)];
                                        int p = 0;
                                        var liste_valeur = service.AnafiAfficheLiasse(3, idDossier, lr.RUBR_ETAT_CODE.ToString().Trim(), "SN");

                                        int j = 0;
                                        int v = 0;
                                        v = Convert.ToInt32(liste_valeur.Count) - 3;
                                        foreach (var l in liste_valeur)
                                        {

                                            if (liste_valeur.Count > 3)
                                            {
                                                j++;
                                                if (v < j)
                                                {
                                                    if (l.TYPE_ANAFI_A.Trim() == "SN")
                                                    {
                                                        if (l.VALEUR_BGR_DETAIL == 0)
                                                        {
                                                            sbt.AppendLine(string.Format("<td class='text-left'></td>"));
                                                            sbt.AppendLine(string.Format("<td class='text-right'><strong></strong></td>", Convert.ToDecimal(l.TAUX_BGR_DETAIL).ToString("#,##0.##")));

                                                            // TabLOTA[p] = l.VALEUR_BGR_DETAIL.ToString();
                                                        }
                                                        else
                                                        {
                                                            sbt.AppendLine(string.Format("<td class='text-left'><strong>{0}</strong></td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_BGR_DETAIL))));
                                                            sbt.AppendLine(string.Format("<td class='text-right'><strong>{0}%</strong></td>", Convert.ToDecimal(l.TAUX_BGR_DETAIL).ToString("#,##0.##")));

                                                            // TabLOTA[p] = l.VALEUR_BGR_DETAIL.ToString();
                                                        }

                                                       
                                                    }
                                                }

                                            }
                                            else
                                            {
                                                if (l.TYPE_ANAFI_A.Trim() == "SN")
                                                {
                                                    if (l.VALEUR_BGR_DETAIL == 0)
                                                    {
                                                        sbt.AppendLine(string.Format("<td class='text-right'></td>"));
                                                        sbt.AppendLine(string.Format("<td class='text-right'><strong></strong></td>", Convert.ToDecimal(l.TAUX_BGR_DETAIL).ToString("#,##0.##")));

                                                        // TabLOTA[p] = l.VALEUR_BGR_DETAIL.ToString();
                                                    }
                                                    else
                                                    {
                                                        sbt.AppendLine(string.Format("<td class='text-right'><strong>{0}</strong></td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_BGR_DETAIL))));
                                                        sbt.AppendLine(string.Format("<td class='text-right'><strong>{0}%</strong></td>", Convert.ToDecimal(l.TAUX_BGR_DETAIL).ToString("#,##0.##")));
                                                        // TabLOTA[p] = l.VALEUR_BGR_DETAIL.ToString();
                                                    }
                                                    

                                                }
                                            }
                                        }

                                        sbt.AppendLine("</tr>");
                                }
                                else{
                                sb.AppendLine(string.Format("<tr data_code='{0}'>", lr.RUBR_ETAT_CODE.ToString().Trim()));


                                sb.AppendLine(string.Format("<td class='text-left'>{0}</td>", lr.RUBR_ETAT_LIBELLE.ToString()));


                                var liste_valeur = service.AnafiAfficheLiasse(3, idDossier, lr.RUBR_ETAT_CODE.ToString().Trim(), "SN");


                                int j = 0;
                                int v = 0;
                                v = Convert.ToInt32(liste_valeur.Count) - 3;
                                foreach (var l in liste_valeur)
                                {

                                    if (liste_valeur.Count > 3)
                                    {
                                        j++;
                                        if (v < j)
                                        {
                                            if (l.TYPE_ANAFI_A.Trim() == "SN")
                                            {
                                                sb.AppendLine(string.Format("<td class='text-right'>{0}</td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_BGR_DETAIL))));
                                                sb.AppendLine(string.Format("<td class='text-right'><strong>{0}%</strong></td>", Convert.ToDecimal(l.TAUX_BGR_DETAIL).ToString("#,##0.##")));
                                            }
                                        }

                                    }
                                    else
                                    {
                                        if (l.TYPE_ANAFI_A.Trim() == "SN")
                                        {
                                            sb.AppendLine(string.Format("<td class='text-right'>{0}</td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_BGR_DETAIL))));
                                            sb.AppendLine(string.Format("<td class='text-right'><strong>{0}%</strong></td>", Convert.ToDecimal(l.TAUX_BGR_DETAIL).ToString("#,##0.##")));
                                        }
                                    }
                                }

                                sb.AppendLine("</tr>");
                                }
                             

                            }
                        }
                    }

                    sb.AppendLine("</tbody>");
                    sb.AppendLine("</table>");

                    DIVtotauxActif.Visible = true;
                    DIVtotauxPassif.Visible = true;
                }
                else
                {
                    sb.AppendLine("<div class='col-lg-6col-sm-6 col-md-6' style=\"overflow-x:auto\" >");
                    sb.AppendLine("<table id='' class='table table-hover table-bordered text-center'>");
                    sb.AppendLine("<thead class='table-heigth'>");
                    sb.AppendLine(string.Format("<tr><th>Actifs</th>"));
                    sb.AppendLine(string.Format("<th width=23%></th>"));

                    sb.AppendLine("</thead>");
                    sb.AppendLine("<tbody>");

                    var liste_libelle = service.AnafiAfficheLiasse(0, "", "", "BIL");
                    string[] TabLOTN = null;
                    sbt.AppendLine("<table id='totauxActif' class='table-hover table table-bordered text-center'>");
                    foreach (var lr in liste_libelle)
                    {

                        string SENS = lr.RUBR_ETAT_CODE.ToString().Trim().Substring(0, 3);
                        if (SENS == "BI1" || SENS == "BI2" || SENS == "BI3")
                        {
                            if (lr.RUBR_ETAT_CODE.Trim().Length == 4)
                            {
                                if (lr.RUBR_ETAT_CODE.Trim() == "BI3Z")
                                {

                                 
                                    sbt.AppendLine(string.Format("<tr style='background-color:rgba(210, 210, 210, 1);'>"));

                                    sbt.AppendLine(string.Format("<td class='text-left'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE));
                                    sbt.AppendLine(string.Format("<td width=23%></td>"));

                                    //sbt.AppendLine("</table>");
                                    //DIVtotauxActif.InnerHtml = sbt.ToString();
                                }
                                else
                                {
                                    if (lr.RUBR_ETAT_CODE.ToString().Trim() == "BI7Z")
                                    {
                                    }
                                    else
                                    {
                                        sb.AppendLine(string.Format("<tr data_code='{0}' style='background-color:rgba(210, 210, 210, 1);'>", lr.RUBR_ETAT_CODE.ToString().Trim()));
                                        sb.AppendLine(string.Format("<td class='text-left'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE.ToString()));
                                        sb.AppendLine(string.Format("<td></td>"));

                                        sb.AppendLine("</tr>");
                                    }
                                }

                                //sb.AppendLine("</tr>");

                            }
                            else
                            {
                                if (lr.RUBR_ETAT_CODE.Trim() == "BI3Z1")
                                {
                                    sb.AppendLine(string.Format("<tr data_code='{0}'>", lr.RUBR_ETAT_CODE.ToString().Trim()));


                                    sb.AppendLine(string.Format("<td class='text-left'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE.ToString()));
                                    sb.AppendLine(string.Format("<td></td>"));

                                    sb.AppendLine("</tr>");
                                }
                                else
                                {
                                    sb.AppendLine(string.Format("<tr data_code='{0}'>", lr.RUBR_ETAT_CODE.ToString().Trim()));


                                    sb.AppendLine(string.Format("<td class='text-left'>{0}</td>", lr.RUBR_ETAT_LIBELLE.ToString()));
                                    sb.AppendLine(string.Format("<td></td>"));

                                    sb.AppendLine("</tr>");
                                }
                               

                            }
                        }
                    }

                    sb.AppendLine("</tbody>");
                    sb.AppendLine("</table>");

                    DIVtotauxActif.Visible = true;
                    DIVtotauxPassif.Visible = true;
                }
                sb.AppendLine("</div>");

                if (liste_annee.Count != 0)
                {
                    sb.AppendLine("<div class='col-lg-6 col-sm-6 col-md-6' style=\"overflow-x:auto\" >");
                    sb.AppendLine("<table id='' class='table table-hover table-bordered text-center'>");
                    sb.AppendLine("<thead class='table-heigth'>");
                    sb.AppendLine(string.Format("<tr><th>Passifs</th>"));

                    if (liste_annee.Count > 3)
                    {
                        int j = 0;
                        int v = 0;
                        int i = 0;
                        v = Convert.ToInt32(liste_annee.Count) - 3;
                        foreach (var lr in liste_annee)
                        {
                            j++;
                            if (v < j)
                            {
                                if (i < Convert.ToInt32(liste_annee.Count))
                                {
                                    sb.AppendLine(string.Format("<th colspan=\"2\" width=15%>{0}</th>", lr.ANNEE_DETAIL));
                                    //TabLOT[i] = lr.ANNEE_DETAIL;
                                }
                            }

                            i++;
                        }
                    }
                    else
                    {
                        int i = 0;
                        foreach (var lr in liste_annee)
                        {

                            if (i < Convert.ToInt32(liste_annee.Count))
                            {
                                sb.AppendLine(string.Format("<th colspan=\"2\" width=15%>{0}</th>", lr.ANNEE_DETAIL));
                                //TabLOT[i] = lr.ANNEE_DETAIL;
                            }
                            i++;
                        }
                    }

                    sb.AppendLine("</thead>");
                    sb.AppendLine("<tbody>");

                    var liste_libelle = service.AnafiAfficheLiasse(0, "", "", "BIL");
                    string[] TabLOTN = null;
                    sbv.AppendLine("<table id='totauxPassif' class='table-hover table table-bordered text-center'>");
                    foreach (var lr in liste_libelle)
                    {



                        string SENS = lr.RUBR_ETAT_CODE.ToString().Trim().Substring(0, 3);
                        if (SENS == "BI4" || SENS == "BI5" || SENS == "BI6" || SENS == "BI7")
                        {
                            if (lr.RUBR_ETAT_CODE.Trim().Length == 4)
                            {
                                if (lr.RUBR_ETAT_CODE.ToString().Trim() == "BI7Z")
                                {

                                  
                                    sbv.AppendLine(string.Format("<tr style='background-color:rgba(210, 210, 210, 1);'>"));

                                    sbv.AppendLine(string.Format("<td class='text-left'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE));
                                    int iv = 0;
                                    var liste_valeur = service.AnafiAfficheLiasse(3, idDossier, lr.RUBR_ETAT_CODE.ToString().Trim(), "SN");

                                    int j = 0;
                                    int v = 0;
                                    v = Convert.ToInt32(liste_valeur.Count) - 3;
                                    foreach (var l in liste_valeur)
                                    {

                                        if (liste_valeur.Count > 3)
                                        {
                                            j++;
                                            if (v < j)
                                            {
                                                sbv.AppendLine(string.Format("<td class='text-left' width=16%><strong>{0}</strong></td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_BGR_DETAIL))));
                                                sbv.AppendLine(string.Format("<td class='text-right'><strong>{0}%</strong></td>", Convert.ToDecimal(l.TAUX_BGR_DETAIL).ToString("#,##0.##")));
                                               
                                                //sbv.AppendLine(string.Format("<td class='text-left'>{0}</td>", Convert.ToString(string.Format("{0:#,##0}", TabLOTN[iv]))));
                                                //iv++;
                                            }

                                        }
                                        else
                                        {
                                            sbv.AppendLine(string.Format("<td class='text-left' width=16%><strong>{0}</strong></td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_BGR_DETAIL))));
                                            sbv.AppendLine(string.Format("<td class='text-right'><strong>{0}%</strong></td>", Convert.ToDecimal(l.TAUX_BGR_DETAIL).ToString("#,##0.##")));
                                           
                                            //sbv.AppendLine(string.Format("<td class='text-left'>{0}</td>", Convert.ToString(string.Format("{0:#,##0}", TabLOTN[iv]))));
                                            //iv++;
                                        }
                                    }

                               
                                }
                                else
                                {
                                    sb.AppendLine(string.Format("<tr data_code='{0}' style='background-color:rgba(210, 210, 210, 1);'>", lr.RUBR_ETAT_CODE.ToString().Trim()));
                                    sb.AppendLine(string.Format("<td class='text-left'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE.ToString()));
                                    // TabLOTA = new string[Convert.ToInt32(liste_annee.Count)];
                                    int p = 0;
                                    var liste_valeur = service.AnafiAfficheLiasse(3, idDossier, lr.RUBR_ETAT_CODE.ToString().Trim(), "SN");

                                    int j = 0;
                                    int v = 0;
                                    v = Convert.ToInt32(liste_valeur.Count) - 3;
                                    foreach (var l in liste_valeur)
                                    {

                                        if (liste_valeur.Count > 3)
                                        {
                                            j++;
                                            if (v < j)
                                            {
                                                sb.AppendLine(string.Format("<td class='text-right'><strong>{0}</strong></td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_BGR_DETAIL))));
                                                sb.AppendLine(string.Format("<td class='text-right'><strong>{0}%</strong></td>", Convert.ToDecimal(l.TAUX_BGR_DETAIL).ToString("#,##0.##")));


                                            }

                                        }
                                        else
                                        {
                                            sb.AppendLine(string.Format("<td class='text-right'><strong>{0}</strong></td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_BGR_DETAIL))));
                                           sb.AppendLine(string.Format("<td class='text-right'><strong>{0}%</strong></td>", Convert.ToDecimal(l.TAUX_BGR_DETAIL).ToString("#,##0.##")));
                                            //sb.AppendLine(string.Format("<td class='text-right'><strong>{0}%</strong></td>", l.TAUX_BGR_DETAIL));


                                        }
                                    }

                                    sb.AppendLine("</tr>");
                                }


                            }
                            else
                            {
                                if (lr.RUBR_ETAT_CODE.ToString().Trim() == "BI7Z1")
                                {
                                sbv.AppendLine(string.Format("<tr data_code='{0}'>", lr.RUBR_ETAT_CODE.ToString().Trim()));
                               sbv.AppendLine(string.Format("<td  class='text-left'>{0}</td>", lr.RUBR_ETAT_LIBELLE.ToString()));

                                var liste_valeur = service.AnafiAfficheLiasse(3, idDossier, lr.RUBR_ETAT_CODE.ToString().Trim(), "SN");
                                int j = 0;
                                int v = 0;
                                v = Convert.ToInt32(liste_valeur.Count) - 3;
                                foreach (var l in liste_valeur)
                                {

                                    if (liste_valeur.Count > 3)
                                    {
                                        j++;
                                        if (v < j)
                                        {
                                            if (l.TYPE_ANAFI_A.Trim() == "SN")
                                            {
                                                if (l.VALEUR_BGR_DETAIL == 0)
                                                {
                                                    sbv.AppendLine(string.Format("<td class='text-right'></td>"));      
                                                }
                                                else
                                                {
                                                    sbv.AppendLine(string.Format("<td class='text-right'>{0}</td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_BGR_DETAIL))));
                                                    sbv.AppendLine(string.Format("<td class='text-right'><strong>{0}%</strong></td>", Convert.ToDecimal(l.TAUX_BGR_DETAIL).ToString("#,##0.##")));
                                                }
                                               
                                            }
                                        }

                                    }
                                    else
                                    {
                                        if (l.TYPE_ANAFI_A.Trim() == "SN")
                                        {
                                            if (l.VALEUR_BGR_DETAIL == 0)
                                            {
                                                sbv.AppendLine(string.Format("<td class='text-right'></td>"));
                                                sbv.AppendLine(string.Format("<td class='text-right'><strong></strong></td>", Convert.ToDecimal(l.TAUX_BGR_DETAIL).ToString("#,##0.##")));
                
                                            }
                                            else
                                            {
                                                sbv.AppendLine(string.Format("<td class='text-right'>{0}</td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_BGR_DETAIL))));
                                                sbv.AppendLine(string.Format("<td class='text-right'><strong>{0}%</strong></td>", Convert.ToDecimal(l.TAUX_BGR_DETAIL).ToString("#,##0.##")));
                                            }
                                          
                                        }
                                    }
                                }




                                sbv.AppendLine("</tr>");
                                }
                                else{
                                       sb.AppendLine(string.Format("<tr data_code='{0}'>", lr.RUBR_ETAT_CODE.ToString().Trim()));


                                sb.AppendLine(string.Format("<td class='text-left'>{0}</td>", lr.RUBR_ETAT_LIBELLE.ToString()));


                                var liste_valeur = service.AnafiAfficheLiasse(3, idDossier, lr.RUBR_ETAT_CODE.ToString().Trim(), "SN");
                                int j = 0;
                                int v = 0;
                                v = Convert.ToInt32(liste_valeur.Count) - 3;
                                foreach (var l in liste_valeur)
                                {

                                    if (liste_valeur.Count > 3)
                                    {
                                        j++;
                                        if (v < j)
                                        {
                                            if (l.TYPE_ANAFI_A.Trim() == "SN")
                                            {
                                                sb.AppendLine(string.Format("<td class='text-right'>{0}</td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_BGR_DETAIL))));
                                                sb.AppendLine(string.Format("<td class='text-right'><strong>{0}%</strong></td>", Convert.ToDecimal(l.TAUX_BGR_DETAIL).ToString("#,##0.##")));
                                            }
                                        }

                                    }
                                    else
                                    {
                                        if (l.TYPE_ANAFI_A.Trim() == "SN")
                                        {
                                            sb.AppendLine(string.Format("<td class='text-right'>{0}</td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_BGR_DETAIL))));
                                            sb.AppendLine(string.Format("<td class='text-right'><strong>{0}%</strong></td>", Convert.ToDecimal(l.TAUX_BGR_DETAIL).ToString("#,##0.##")));
                                        }
                                    }
                                }




                                sb.AppendLine("</tr>");
                                }
                             

                            }
                        }
                    }

                    sb.AppendLine("</tbody>");
                    sb.AppendLine("</table>");

                    DIVtotauxActif.Visible = true;
                    DIVtotauxPassif.Visible = true;
                }
                else
                {
                    sb.AppendLine("<div class='col-lg-6 col-sm-6 col-md-6' style=\"overflow-x:auto\" >");
                    sb.AppendLine("<table id='' class='table table-hover table-bordered text-center'>");
                    sb.AppendLine("<thead class='table-heigth'>");
                    sb.AppendLine(string.Format("<tr><th>Passifs</th>"));
                    sb.AppendLine(string.Format("<th width=23%></th>"));

                    sb.AppendLine("</thead>");
                    sb.AppendLine("<tbody>");

                    var liste_libelle = service.AnafiAfficheLiasse(0, "", "", "BIL");
                    string[] TabLOTN = null;
                    sbv.AppendLine("<table id='totauxPassif' class='table-hover table table-bordered text-center'>");
                    foreach (var lr in liste_libelle)
                    {



                        string SENS = lr.RUBR_ETAT_CODE.ToString().Trim().Substring(0, 3);
                        if (SENS == "BI4" || SENS == "BI5" || SENS == "BI6" || SENS == "BI7")
                        {
                            if (lr.RUBR_ETAT_CODE.Trim().Length == 4)
                            {
                                if (lr.RUBR_ETAT_CODE.ToString().Trim() == "BI7Z")
                                {

                                   
                                    sbv.AppendLine(string.Format("<tr style='background-color:rgba(210, 210, 210, 1);'>"));

                                    sbv.AppendLine(string.Format("<td class='text-left'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE));
                                    sbv.AppendLine(string.Format("<th width=23%></th>"));
                                    //sbv.AppendLine("</table>");
                                    //DIVtotauxPassif.InnerHtml = sbv.ToString();
                                }
                                else
                                {
                                    sb.AppendLine(string.Format("<tr data_code='{0}' style='background-color:rgba(210, 210, 210, 1);'>", lr.RUBR_ETAT_CODE.ToString().Trim()));
                                    sb.AppendLine(string.Format("<td class='text-left'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE.ToString()));
                                    sb.AppendLine(string.Format("<th width=23%></th>"));

                                    sb.AppendLine("</tr>");
                                }


                                //sb.AppendLine("</tr>");

                            }
                            else
                            {
                                if(lr.RUBR_ETAT_CODE.ToString().Trim()=="BI7Z1"){
                               sbv.AppendLine(string.Format("<tr data_code='{0}'>", lr.RUBR_ETAT_CODE.ToString().Trim()));

                                sbv.AppendLine(string.Format("<td class='text-left'>{0}</td>", lr.RUBR_ETAT_LIBELLE.ToString()));
                                sbv.AppendLine(string.Format("<th width=23%></th>"));

                                sbv.AppendLine("</tr>");
                                }
                                else{
                                       sb.AppendLine(string.Format("<tr data_code='{0}'>", lr.RUBR_ETAT_CODE.ToString().Trim()));


                                sb.AppendLine(string.Format("<td class='text-left'>{0}</td>", lr.RUBR_ETAT_LIBELLE.ToString()));
                                sb.AppendLine(string.Format("<th width=23%></th>"));

                                sb.AppendLine("</tr>");
                                }
                             

                            }
                        }
                    }

                    sb.AppendLine("</tbody>");
                    sb.AppendLine("</table>");

                    DIVtotauxActif.Visible = true;
                    DIVtotauxPassif.Visible = true;
                }



                sb.AppendLine("</div>");
            }
            else
            {
                if (DdlRubrique.Text != "Bilan")
                {
                    DIVtotauxActif.Visible = false;
                    DIVtotauxPassif.Visible = false;
                    DivecartsActifPassif.Visible = false;
                }

            }

            sbt.AppendLine("</table>");
            DIVtotauxActif.InnerHtml = sbt.ToString();
            sbv.AppendLine("</table>");
            DIVtotauxPassif.InnerHtml = sbv.ToString();
            ListDFinanciers.InnerHtml = "<div class='row'>" + sb.ToString() + "</div>";
        }

        public void afficheBilanGrandeMasseSA()
        {

            if (Session["id_dossier"] == null) Response.Redirect("~/Scoring/Connexion.aspx");

            var idDossier = Session["id_dossier"].ToString();
            Session.Add("id_dossier", idDossier);
            if (DdlRubrique.Text == "Bilan en grandes masses")
            {
                Type_anafi = "BN";
                Div1.Visible = true;
                Div2.Visible = true;
                var liste_annee = service.AnafiAfficheLiasse(7, idDossier, "", "SA");
                var nombre_annee = service.AnafiAfficheLiasse(8, idDossier, "", "SA");

                if (liste_annee.Count != 0)
                {
                    sb.AppendLine("<div class='col-lg-6col-sm-6 col-md-6' style=\"overflow-x:auto\" >");
                    sb.AppendLine("<table id='' class='table table-hover table-bordered text-center'>");
                    sb.AppendLine("<thead class='table-heigth'>");
                    sb.AppendLine(string.Format("<tr><th>Actifs</th>"));

                    if (liste_annee.Count > 3)
                    {
                        int j = 0;
                        int v = 0;
                        int i = 0;
                        v = Convert.ToInt32(liste_annee.Count) - 3;
                        foreach (var lr in liste_annee)
                        {
                            j++;
                            if (v < j)
                            {
                                if (i < Convert.ToInt32(liste_annee.Count))
                                {
                                    sb.AppendLine(string.Format("<th  colspan=\"2\" width=15%>{0}</th>", lr.ANNEE_DETAIL));
                                    //TabLOT[i] = lr.ANNEE_DETAIL;
                                }
                            }

                            i++;
                        }
                    }
                    else
                    {
                        int i = 0;
                        foreach (var lr in liste_annee)
                        {

                            if (i < Convert.ToInt32(liste_annee.Count))
                            {
                                sb.AppendLine(string.Format("<th  colspan=\"2\" width=15%>{0}</th>", lr.ANNEE_DETAIL));
                                //TabLOT[i] = lr.ANNEE_DETAIL;
                            }
                            i++;
                        }
                    }

                    sb.AppendLine("</thead>");
                    sb.AppendLine("<tbody>");

                    var liste_libelle = service.AnafiAfficheLiasse(0, "", "", "BIL");
                    string[] TabLOTN = null;
                    foreach (var lr in liste_libelle)
                    {

                        string SENS = lr.RUBR_ETAT_CODE.ToString().Trim().Substring(0, 3);
                        if (SENS == "BI1" || SENS == "BI2" || SENS == "BI3")
                        {
                            if (lr.RUBR_ETAT_CODE.Trim().Length == 4)
                            {
                                if (lr.RUBR_ETAT_CODE.Trim() == "BI3Z")
                                {

                                    sbt.AppendLine("<table id='totauxActif' class='table-hover table table-bordered text-center'>");
                                    sbt.AppendLine(string.Format("<tr style='background-color:rgba(210, 210, 210, 1);'>"));

                                    sbt.AppendLine(string.Format("<td class='text-left'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE));
                                    // TabLOTA = new string[Convert.ToInt32(liste_annee.Count)];
                                    int pa = 0;
                                    var liste_valeur = service.AnafiAfficheLiasse(3, idDossier, lr.RUBR_ETAT_CODE.ToString().Trim(), "SA");

                                    int j = 0;
                                    int v = 0;
                                    v = Convert.ToInt32(liste_valeur.Count) - 3;
                                    foreach (var l in liste_valeur)
                                    {

                                        if (liste_valeur.Count > 3)
                                        {
                                            j++;
                                            if (v < j)
                                            {
                                                //string k = "";
                                                //k = TabLOTN[1];
                                                //sbt.AppendLine(string.Format("<td class='text-left'>{0}</td>", Convert.ToString(string.Format("{0:#,##0}", k))));
                                                sbt.AppendLine(string.Format("<td class='text-left' width=16%><strong>{0}</strong></td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_BGR_DETAIL))));
                                                sbt.AppendLine(string.Format("<td class='text-right'><strong>{0}%</strong></td>", Convert.ToDecimal(l.TAUX_BGR_DETAIL).ToString("#,##0.##")));
                                                
                                                //pa++;
                                            }

                                        }
                                        else
                                        {
                                            //string k = "";
                                            //k = TabLOTN[1];
                                            //sbt.AppendLine(string.Format("<td class='text-left'>{0}</td>", Convert.ToString(string.Format("{0:#,##0}", k))));
                                            sbt.AppendLine(string.Format("<td class='text-left' width=16%><strong>{0}</strong></td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_BGR_DETAIL))));
                                            sbt.AppendLine(string.Format("<td class='text-right'><strong>{0}%</strong></td>", Convert.ToDecimal(l.TAUX_BGR_DETAIL).ToString("#,##0.##")));
                                            
                                            //pa++;
                                        }
                                    }

                                    sbt.AppendLine("</table>");
                                    DIVtotauxActif.InnerHtml = sbt.ToString();
                                }
                                else
                                {
                                    if (lr.RUBR_ETAT_CODE.ToString().Trim() == "BI7Z")
                                    {


                                    }
                                    else
                                    {

                                        sb.AppendLine(string.Format("<tr data_code='{0}' style='background-color:rgba(210, 210, 210, 1);'>", lr.RUBR_ETAT_CODE.ToString().Trim()));
                                        sb.AppendLine(string.Format("<td class='text-left'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE.ToString()));
                                        // TabLOTP = new string[Convert.ToInt32(liste_annee.Count)];
                                        int p = 0;
                                        var liste_valeur = service.AnafiAfficheLiasse(3, idDossier, lr.RUBR_ETAT_CODE.ToString().Trim(), "SA");

                                        int j = 0;
                                        int v = 0;
                                        v = Convert.ToInt32(liste_valeur.Count) - 3;
                                        foreach (var l in liste_valeur)
                                        {

                                            if (liste_valeur.Count > 3)
                                            {
                                                j++;
                                                if (v < j)
                                                {
                                                    if (l.TYPE_ANAFI_A.Trim() == "SA")
                                                    {
                                                        sb.AppendLine(string.Format("<td class='text-right'><strong>{0}</strong></td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_BGR_DETAIL))));
                                                        sb.AppendLine(string.Format("<td class='text-right'><strong>{0}%</strong></td>", Convert.ToDecimal(l.TAUX_BGR_DETAIL).ToString("#,##0.##")));

                                                        // TabLOTA[p] = l.VALEUR_BGR_DETAIL.ToString();

                                                    }
                                                }

                                            }
                                            else
                                            {
                                                if (l.TYPE_ANAFI_A.Trim() == "SA")
                                                {
                                                    sb.AppendLine(string.Format("<td class='text-right'><strong>{0}</strong></td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_BGR_DETAIL))));
                                                    sb.AppendLine(string.Format("<td class='text-right'><strong>{0}%</strong></td>", Convert.ToDecimal(l.TAUX_BGR_DETAIL).ToString("#,##0.##")));

                                                    // TabLOTA[p] = l.VALEUR_BGR_DETAIL.ToString();

                                                }
                                            }
                                        }

                                        sb.AppendLine("</tr>");
                                    }
                                }

                                //sb.AppendLine("</tr>");

                            }
                            else
                            {
                                sb.AppendLine(string.Format("<tr data_code='{0}'>", lr.RUBR_ETAT_CODE.ToString().Trim()));


                                sb.AppendLine(string.Format("<td class='text-left'>{0}</td>", lr.RUBR_ETAT_LIBELLE.ToString()));


                                var liste_valeur = service.AnafiAfficheLiasse(3, idDossier, lr.RUBR_ETAT_CODE.ToString().Trim(), "SA");


                                int j = 0;
                                int v = 0;
                                v = Convert.ToInt32(liste_valeur.Count) - 3;
                                foreach (var l in liste_valeur)
                                {

                                    if (liste_valeur.Count > 3)
                                    {
                                        j++;
                                        if (v < j)
                                        {
                                            if (l.TYPE_ANAFI_A.Trim() == "SA")
                                            {
                                                sb.AppendLine(string.Format("<td class='text-right'>{0}</td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_BGR_DETAIL))));
                                                sb.AppendLine(string.Format("<td class='text-right'><strong>{0}%</strong></td>", Convert.ToDecimal(l.TAUX_BGR_DETAIL).ToString("#,##0.##")));

                                            }
                                        }

                                    }
                                    else
                                    {
                                        if (l.TYPE_ANAFI_A.Trim() == "SA")
                                        {
                                            sb.AppendLine(string.Format("<td class='text-right'>{0}</td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_BGR_DETAIL))));
                                        }
                                    }
                                }

                                sb.AppendLine("</tr>");

                            }
                        }
                    }

                    sb.AppendLine("</tbody>");
                    sb.AppendLine("</table>");

                    DIVtotauxActif.Visible = true;
                    DIVtotauxPassif.Visible = true;
                }
                else
                {
                    sb.AppendLine("<div class='col-lg-6col-sm-6 col-md-6' style=\"overflow-x:auto\" >");
                    sb.AppendLine("<table id='' class='table table-hover table-bordered text-center'>");
                    sb.AppendLine("<thead class='table-heigth'>");
                    sb.AppendLine(string.Format("<tr><th>Actifs</th>"));
                    sb.AppendLine(string.Format("<th width=23%></th>"));

                    sb.AppendLine("</thead>");
                    sb.AppendLine("<tbody>");

                    var liste_libelle = service.AnafiAfficheLiasse(0, "", "", "BIL");
                    string[] TabLOTN = null;
                    foreach (var lr in liste_libelle)
                    {

                        string SENS = lr.RUBR_ETAT_CODE.ToString().Trim().Substring(0, 3);
                        if (SENS == "BI1" || SENS == "BI2" || SENS == "BI3")
                        {
                            if (lr.RUBR_ETAT_CODE.Trim().Length == 4)
                            {
                                if (lr.RUBR_ETAT_CODE.Trim() == "BI3Z")
                                {

                                    sbt.AppendLine("<table id='totauxActif' class='table-hover table table-bordered text-center'>");
                                    sbt.AppendLine(string.Format("<tr style='background-color:rgba(210, 210, 210, 1);'>"));

                                    sbt.AppendLine(string.Format("<td class='text-left'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE));
                                    sbt.AppendLine(string.Format("<td width=23%></td>"));

                                    sbt.AppendLine("</table>");
                                    DIVtotauxActif.InnerHtml = sbt.ToString();
                                }
                                else
                                {
                                    if (lr.RUBR_ETAT_CODE.ToString().Trim() == "BI7Z")
                                    {
                                    }
                                    else
                                    {
                                        sb.AppendLine(string.Format("<tr data_code='{0}' style='background-color:rgba(210, 210, 210, 1);'>", lr.RUBR_ETAT_CODE.ToString().Trim()));
                                        sb.AppendLine(string.Format("<td class='text-left'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE.ToString()));
                                        sb.AppendLine(string.Format("<td></td>"));

                                        sb.AppendLine("</tr>");
                                    }
                                }

                                //sb.AppendLine("</tr>");

                            }
                            else
                            {
                                sb.AppendLine(string.Format("<tr data_code='{0}'>", lr.RUBR_ETAT_CODE.ToString().Trim()));


                                sb.AppendLine(string.Format("<td class='text-left'>{0}</td>", lr.RUBR_ETAT_LIBELLE.ToString()));
                                sb.AppendLine(string.Format("<td></td>"));

                                sb.AppendLine("</tr>");

                            }
                        }
                    }

                    sb.AppendLine("</tbody>");
                    sb.AppendLine("</table>");

                    DIVtotauxActif.Visible = true;
                    DIVtotauxPassif.Visible = true;
                }
                sb.AppendLine("</div>");

                if (liste_annee.Count != 0)
                {
                    sb.AppendLine("<div class='col-lg-6 col-sm-6 col-md-6' >");
                    sb.AppendLine("<table id='' class='table table-hover table-bordered text-center'>");
                    sb.AppendLine("<thead class='table-heigth'>");
                    sb.AppendLine(string.Format("<tr><th>Passifs</th>"));

                    if (liste_annee.Count > 3)
                    {
                        int j = 0;
                        int v = 0;
                        int i = 0;
                        v = Convert.ToInt32(liste_annee.Count) - 3;
                        foreach (var lr in liste_annee)
                        {
                            j++;
                            if (v < j)
                            {
                                if (i < Convert.ToInt32(liste_annee.Count))
                                {
                                    sb.AppendLine(string.Format("<th width=15%>{0}</th>", lr.ANNEE_DETAIL));
                                    //TabLOT[i] = lr.ANNEE_DETAIL;
                                }
                            }

                            i++;
                        }
                    }
                    else
                    {
                        int i = 0;
                        foreach (var lr in liste_annee)
                        {

                            if (i < Convert.ToInt32(liste_annee.Count))
                            {
                                sb.AppendLine(string.Format("<th width=15%>{0}</th>", lr.ANNEE_DETAIL));
                                //TabLOT[i] = lr.ANNEE_DETAIL;
                            }
                            i++;
                        }
                    }

                    sb.AppendLine("</thead>");
                    sb.AppendLine("<tbody>");

                    var liste_libelle = service.AnafiAfficheLiasse(0, "", "", "BIL");
                    string[] TabLOTN = null;
                    foreach (var lr in liste_libelle)
                    {



                        string SENS = lr.RUBR_ETAT_CODE.ToString().Trim().Substring(0, 3);
                        if (SENS == "BI4" || SENS == "BI5" || SENS == "BI6" || SENS == "BI7")
                        {
                            if (lr.RUBR_ETAT_CODE.Trim().Length == 4)
                            {
                                if (lr.RUBR_ETAT_CODE.ToString().Trim() == "BI7Z")
                                {

                                    sbv.AppendLine("<table id='totauxPassif' class='table-hover table table-bordered text-center'>");
                                    sbv.AppendLine(string.Format("<tr style='background-color:rgba(210, 210, 210, 1);'>"));

                                    sbv.AppendLine(string.Format("<td class='text-left'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE));
                                    int iv = 0;
                                    var liste_valeur = service.AnafiAfficheLiasse(3, idDossier, lr.RUBR_ETAT_CODE.ToString().Trim(), "SA");

                                    int j = 0;
                                    int v = 0;
                                    v = Convert.ToInt32(liste_valeur.Count) - 3;
                                    foreach (var l in liste_valeur)
                                    {

                                        if (liste_valeur.Count > 3)
                                        {
                                            j++;
                                            if (v < j)
                                            {
                                                sbv.AppendLine(string.Format("<td class='text-left' width=16%><strong>{0}</strong></td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_BGR_DETAIL))));

                                            }

                                        }
                                        else
                                        {
                                            sbv.AppendLine(string.Format("<td class='text-left' width=16%><strong>{0}</strong></td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_BGR_DETAIL))));

                                        }
                                    }

                                    sbv.AppendLine("</table>");
                                    DIVtotauxPassif.InnerHtml = sbv.ToString();
                                }
                                else
                                {
                                    sb.AppendLine(string.Format("<tr data_code='{0}' style='background-color:rgba(210, 210, 210, 1);'>", lr.RUBR_ETAT_CODE.ToString().Trim()));
                                    sb.AppendLine(string.Format("<td class='text-left'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE.ToString()));
                                    // TabLOTA = new string[Convert.ToInt32(liste_annee.Count)];
                                    int p = 0;
                                    var liste_valeur = service.AnafiAfficheLiasse(3, idDossier, lr.RUBR_ETAT_CODE.ToString().Trim(), "SA");

                                    int j = 0;
                                    int v = 0;
                                    v = Convert.ToInt32(liste_valeur.Count) - 3;
                                    foreach (var l in liste_valeur)
                                    {

                                        if (liste_valeur.Count > 3)
                                        {
                                            j++;
                                            if (v < j)
                                            {
                                                sb.AppendLine(string.Format("<td class='text-right'><strong>{0}</strong></td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_BGR_DETAIL))));

                                            }

                                        }
                                        else
                                        {
                                            sb.AppendLine(string.Format("<td class='text-right'><strong>{0}</strong></td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_BGR_DETAIL))));

                                        }
                                    }

                                    sb.AppendLine("</tr>");
                                }


                            }
                            else
                            {
                                sb.AppendLine(string.Format("<tr data_code='{0}'>", lr.RUBR_ETAT_CODE.ToString().Trim()));


                                sb.AppendLine(string.Format("<td class='text-left'>{0}</td>", lr.RUBR_ETAT_LIBELLE.ToString()));


                                var liste_valeur = service.AnafiAfficheLiasse(3, idDossier, lr.RUBR_ETAT_CODE.ToString().Trim(), "SA");
                                int j = 0;
                                int v = 0;
                                v = Convert.ToInt32(liste_valeur.Count) - 3;
                                foreach (var l in liste_valeur)
                                {

                                    if (liste_valeur.Count > 3)
                                    {
                                        j++;
                                        if (v < j)
                                        {
                                            if (l.TYPE_ANAFI_A.Trim() == "SA")
                                            {
                                                sb.AppendLine(string.Format("<td class='text-right'>{0}</td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_BGR_DETAIL))));
                                            }
                                        }

                                    }
                                    else
                                    {
                                        if (l.TYPE_ANAFI_A.Trim() == "SA")
                                        {
                                            sb.AppendLine(string.Format("<td class='text-right'>{0}</td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_BGR_DETAIL))));
                                        }
                                    }
                                }




                                sb.AppendLine("</tr>");

                            }
                        }
                    }

                    sb.AppendLine("</tbody>");
                    sb.AppendLine("</table>");

                    DIVtotauxActif.Visible = true;
                    DIVtotauxPassif.Visible = true;
                }
                else
                {
                    sb.AppendLine("<div class='col-lg-6 col-sm-6 col-md-6' >");
                    sb.AppendLine("<table id='' class='table table-hover table-bordered text-center'>");
                    sb.AppendLine("<thead class='table-heigth'>");
                    sb.AppendLine(string.Format("<tr><th>Passifs</th>"));
                    sb.AppendLine(string.Format("<th width=23%></th>"));

                    sb.AppendLine("</thead>");
                    sb.AppendLine("<tbody>");

                    var liste_libelle = service.AnafiAfficheLiasse(0, "", "", "BIL");
                    string[] TabLOTN = null;
                    foreach (var lr in liste_libelle)
                    {
                        string SENS = lr.RUBR_ETAT_CODE.ToString().Trim().Substring(0, 3);
                        if (SENS == "BI4" || SENS == "BI5" || SENS == "BI6" || SENS == "BI7")
                        {
                            if (lr.RUBR_ETAT_CODE.Trim().Length == 4)
                            {
                                if (lr.RUBR_ETAT_CODE.ToString().Trim() == "BI7Z")
                                {

                                    sbv.AppendLine("<table id='totauxPassif' class='table-hover table table-bordered text-center'>");
                                    sbv.AppendLine(string.Format("<tr style='background-color:rgba(210, 210, 210, 1);'>"));

                                    sbv.AppendLine(string.Format("<td class='text-left'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE));
                                    sbv.AppendLine(string.Format("<th width=23%></th>"));
                                    sbv.AppendLine("</table>");
                                    DIVtotauxPassif.InnerHtml = sbv.ToString();
                                }
                                else
                                {
                                    sb.AppendLine(string.Format("<tr data_code='{0}' style='background-color:rgba(210, 210, 210, 1);'>", lr.RUBR_ETAT_CODE.ToString().Trim()));
                                    sb.AppendLine(string.Format("<td class='text-left'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE.ToString()));
                                    sb.AppendLine(string.Format("<th width=23%></th>"));

                                    sb.AppendLine("</tr>");
                                }


                                //sb.AppendLine("</tr>");

                            }
                            else
                            {
                                sb.AppendLine(string.Format("<tr data_code='{0}'>", lr.RUBR_ETAT_CODE.ToString().Trim()));


                                sb.AppendLine(string.Format("<td class='text-left'>{0}</td>", lr.RUBR_ETAT_LIBELLE.ToString()));
                                sb.AppendLine(string.Format("<th width=23%></th>"));

                                sb.AppendLine("</tr>");

                            }
                        }
                    }

                    sb.AppendLine("</tbody>");
                    sb.AppendLine("</table>");

                    DIVtotauxActif.Visible = true;
                    DIVtotauxPassif.Visible = true;
                }



                sb.AppendLine("</div>");
            }
            else
            {
                if (DdlRubrique.Text != "Bilan")
                {
                    DIVtotauxActif.Visible = false;
                    DIVtotauxPassif.Visible = false;
                    DivecartsActifPassif.Visible = false;
                }

            }
            ListDFinanciers.InnerHtml = sb.ToString();
        }

        public void afficheTableauSynthetiqueBN()
        {
            if (Session["id_dossier"] == null) Response.Redirect("~/Scoring/Connexion.aspx");

            var idDossier = Session["id_dossier"].ToString();
            Session.Add("id_dossier", idDossier);
            if (DdlRubrique.Text == "Tableau synthétique des SSG")
            {
                Type_anafi = "BN";
                Div1.Visible = true;
                Div2.Visible = true;
                CompteResult.Visible = false;
                divCharge.Visible = false;
                divProduit.Visible = false;
                var liste_annee = service.AnafiAfficheLiasse(7, idDossier, "", "SN");
                var nombre_annee = service.AnafiAfficheLiasse(8, idDossier, "", "SN");

                if (liste_annee.Count != 0)
                {
                    sb.AppendLine("<div class='col-lg-12 col-sm-12 col-md-12' >");
                    sb.AppendLine("<table id='' class='table table-hover table-bordered text-center'>");
                    sb.AppendLine("<thead class='table-heigth'>");
                    sb.AppendLine(string.Format("<tr><th>Libellés</th>"));

                    if (liste_annee.Count > 3)
                    {
                        int j = 0;
                        int v = 0;
                        int i = 0;
                        v = Convert.ToInt32(liste_annee.Count) - 3;
                        foreach (var lr in liste_annee)
                        {
                            j++;
                            if (v < j)
                            {
                                if (i < Convert.ToInt32(liste_annee.Count))
                                {
                                    sb.AppendLine(string.Format("<th colspan=\"2\" width=15%>{0}</th>", lr.ANNEE_DETAIL));
                                    //TabLOT[i] = lr.ANNEE_DETAIL;
                                }
                            }

                            i++;
                        }
                    }
                    else
                    {
                        int i = 0;
                        foreach (var lr in liste_annee)
                        {

                            if (i < Convert.ToInt32(liste_annee.Count))
                            {
                                sb.AppendLine(string.Format("<th  colspan=\"2\" width=15%>{0}</th>", lr.ANNEE_DETAIL));
                                //TabLOT[i] = lr.ANNEE_DETAIL;
                            }
                            i++;
                        }
                    }

                    sb.AppendLine("</thead>");
                    sb.AppendLine("<tbody>");

                    var liste_libelle = service.AnafiAfficheLiasse(0, "", "", "CR");

                    foreach (var lr in liste_libelle)
                    {
                        if (lr.RUBR_ETAT_CODE.Trim() == "C019" || lr.RUBR_ETAT_CODE.Trim() == "C029" || lr.RUBR_ETAT_CODE.Trim() == "C039" || lr.RUBR_ETAT_CODE.Trim() == "C049" || lr.RUBR_ETAT_CODE.Trim() == "C059" || lr.RUBR_ETAT_CODE.Trim() == "C069" || lr.RUBR_ETAT_CODE.Trim() == "C079" || lr.RUBR_ETAT_CODE.Trim() == "C089" || lr.RUBR_ETAT_CODE.Trim() == "C099" || lr.RUBR_ETAT_CODE.Trim() == "C109" || lr.RUBR_ETAT_CODE.Trim() == "C119")
                        {
                            sb.AppendLine(string.Format("<tr data_code='{0}' style='background-color:#ddd'>", lr.RUBR_ETAT_CODE.ToString().Trim()));

                            sb.AppendLine(string.Format("<td class='text-left'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE));
                            // TabLOTA = new string[Convert.ToInt32(liste_annee.Count)];
                            int p = 0;
                            var liste_valeur = service.AnafiAfficheLiasse(4, idDossier, lr.RUBR_ETAT_CODE.ToString().Trim(), "SN");
                            int j = 0;
                            int v = 0;
                            v = Convert.ToInt32(liste_valeur.Count) - 3;
                            foreach (var l in liste_valeur)
                            {

                                if (liste_valeur.Count > 3)
                                {
                                    j++;
                                    if (v < j)
                                    {
                                        if (l.TYPE_ANAFI_A.Trim() == "SN")
                                        {
                                            sb.AppendLine(string.Format("<td class='text-right'><strong>{0}</strong></td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_TS_DETAIL))));
                                            sb.AppendLine(string.Format("<td class='text-right'><strong>{0}%</strong></td>", Convert.ToDecimal(l.TAUX_TS_DETAIL).ToString("#,##0.##")));
                                            // TabLOTA[p] = l.VALEUR_RAT_AFF_DETAIL.ToString();
                                            p++;
                                        }
                                    }
                                }
                                else
                                {
                                    if (l.TYPE_ANAFI_A.Trim() == "SN")
                                    {
                                        sb.AppendLine(string.Format("<td class='text-right'><strong>{0}</strong></td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_TS_DETAIL))));
                                        sb.AppendLine(string.Format("<td class='text-right'><strong>{0}%</strong></td>", Convert.ToDecimal(l.TAUX_TS_DETAIL).ToString("#,##0.##")));
                                        // TabLOTA[p] = l.VALEUR_RAT_AFF_DETAIL.ToString();
                                        p++;
                                    }
                                }
                            }


                            sb.AppendLine("</tr>");
                        }
                        else
                        {
                            if (lr.RUBR_ETAT_CODE.Trim() != "C0203" && lr.RUBR_ETAT_CODE.Trim() != "C0204" && lr.RUBR_ETAT_CODE.Trim() != "C0205" && lr.RUBR_ETAT_CODE.Trim() != "C0206" && lr.RUBR_ETAT_CODE.Trim() != "C0207")

                            //  if (lr.RUBR_ETAT_CODE.Trim() != "C0203" || lr.RUBR_ETAT_CODE.Trim() != "C0204" || lr.RUBR_ETAT_CODE.Trim() != "C0205" || lr.RUBR_ETAT_CODE.Trim() != "C0206" || lr.RUBR_ETAT_CODE.Trim() != "C0207")
                            {
                                //C0203
                                sb.AppendLine(string.Format("<tr data_code='{0}'>", lr.RUBR_ETAT_CODE.ToString().Trim()));

                                sb.AppendLine(string.Format("<td class='text-left'>{0}</td>", lr.RUBR_ETAT_LIBELLE));
                                // TabLOTA = new string[Convert.ToInt32(liste_annee.Count)];
                                int p = 0;
                                var liste_valeur = service.AnafiAfficheLiasse(4, idDossier, lr.RUBR_ETAT_CODE.ToString().Trim(), "SN");

                                int j = 0;
                                int v = 0;
                                v = Convert.ToInt32(liste_valeur.Count) - 3;
                                foreach (var l in liste_valeur)
                                {

                                    if (liste_valeur.Count > 3)
                                    {
                                        j++;
                                        if (v < j)
                                        {
                                            if (l.TYPE_ANAFI_A.Trim() == "SN")
                                            {
                                                sb.AppendLine(string.Format("<td class='text-right'>{0}</td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_TS_DETAIL))));
                                                sb.AppendLine(string.Format("<td class='text-right'>{0}%</td>", Convert.ToDecimal(l.TAUX_TS_DETAIL).ToString("#,##0.##")));
                                                // TabLOTA[p] = l.VALEUR_RAT_AFF_DETAIL.ToString();
                                                p++;
                                            }
                                        }

                                    }
                                    else
                                    {
                                        if (l.TYPE_ANAFI_A.Trim() == "SN")
                                        {
                                            sb.AppendLine(string.Format("<td class='text-right'>{0}</td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_TS_DETAIL))));
                                            sb.AppendLine(string.Format("<td class='text-right'>{0}%</td>", Convert.ToDecimal(l.TAUX_TS_DETAIL).ToString("#,##0.##")));
                                            // TabLOTA[p] = l.VALEUR_RAT_AFF_DETAIL.ToString();
                                            p++;
                                        }
                                    }
                                }


                                sb.AppendLine("</tr>");
                            }
                        }

                    }

                    sb.AppendLine("</tbody>");
                    sb.AppendLine("</table>");
                }
                else
                {
                    sb.AppendLine("<div class='col-lg-12 col-sm-12 col-md-12' >");
                    sb.AppendLine("<table id='' class='table table-hover table-bordered text-center'>");
                    sb.AppendLine("<thead class='table-heigth'>");
                    sb.AppendLine(string.Format("<tr><th>Libellés</th>"));
                    sb.AppendLine(string.Format("<th width=23%></th>"));

                    sb.AppendLine("</thead>");
                    sb.AppendLine("<tbody>");

                    var liste_libelle = service.AnafiAfficheLiasse(0, "", "", "CR");

                    foreach (var lr in liste_libelle)
                    {


                        if (lr.RUBR_ETAT_CODE.Trim() == "C019" || lr.RUBR_ETAT_CODE.Trim() == "C029" || lr.RUBR_ETAT_CODE.Trim() == "C039" || lr.RUBR_ETAT_CODE.Trim() == "C049" || lr.RUBR_ETAT_CODE.Trim() == "C059" || lr.RUBR_ETAT_CODE.Trim() == "C069" || lr.RUBR_ETAT_CODE.Trim() == "C079" || lr.RUBR_ETAT_CODE.Trim() == "C089" || lr.RUBR_ETAT_CODE.Trim() == "C099" || lr.RUBR_ETAT_CODE.Trim() == "C109" || lr.RUBR_ETAT_CODE.Trim() == "C119")
                        {
                            sb.AppendLine(string.Format("<tr data_code='{0}' style='background-color:#ddd'>", lr.RUBR_ETAT_CODE.ToString().Trim()));
                            sb.AppendLine(string.Format("<td class='text-left'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE));
                            sb.AppendLine(string.Format("<td ></td >"));
                        }
                        else
                        {
                            if (lr.RUBR_ETAT_CODE.Trim() != "C0203" && lr.RUBR_ETAT_CODE.Trim() != "C0204" && lr.RUBR_ETAT_CODE.Trim() != "C0205" && lr.RUBR_ETAT_CODE.Trim() != "C0206" && lr.RUBR_ETAT_CODE.Trim() != "C0207")
                            {
                                //C0203
                                sb.AppendLine(string.Format("<tr data_code='{0}'>", lr.RUBR_ETAT_CODE.ToString().Trim()));
                                sb.AppendLine(string.Format("<td class='text-left'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE));
                                sb.AppendLine(string.Format("<td ></td >"));
                            }
                        }



                        sb.AppendLine("</tr>");
                    }

                    sb.AppendLine("</tbody>");
                    sb.AppendLine("</table>");
                }
                sb.AppendLine("</div>");


            }
            else
            {
                //DIVtotauxActif.Visible = false;
                //DIVtotauxPassif.Visible = false;
                //DivecartsActifPassif.Visible = false;
            }
            ListDFinanciers.InnerHtml = sb.ToString();
        }

        public void afficheTableauSynthetiqueSA()
        {
            if (Session["id_dossier"] == null) Response.Redirect("~/Scoring/Connexion.aspx");

            var idDossier = Session["id_dossier"].ToString();
            Session.Add("id_dossier", idDossier);
            if (DdlRubrique.Text == "Tableau synthétique des SSG")
            {
                Type_anafi = "BN";
                Div1.Visible = true;
                Div2.Visible = true;
                var liste_annee = service.AnafiAfficheLiasse(7, idDossier, "", "SA");
                var nombre_annee = service.AnafiAfficheLiasse(8, idDossier, "", "SA");

                if (liste_annee.Count != 0)
                {
                    sb.AppendLine("<div class='col-lg-12 col-sm-12 col-md-12' >");
                    sb.AppendLine("<table id='' class='table table-hover table-bordered text-center'>");
                    sb.AppendLine("<thead class='table-heigth'>");
                    sb.AppendLine(string.Format("<tr><th>Libellés</th>"));

                    if (liste_annee.Count > 3)
                    {
                        int j = 0;
                        int v = 0;
                        int i = 0;
                        v = Convert.ToInt32(liste_annee.Count) - 3;
                        foreach (var lr in liste_annee)
                        {
                            j++;
                            if (v < j)
                            {
                                if (i < Convert.ToInt32(liste_annee.Count))
                                {
                                    sb.AppendLine(string.Format("<th width=15%>{0}</th>", lr.ANNEE_DETAIL));
                                    //TabLOT[i] = lr.ANNEE_DETAIL;
                                }
                            }

                            i++;
                        }
                    }
                    else
                    {
                        int i = 0;
                        foreach (var lr in liste_annee)
                        {

                            if (i < Convert.ToInt32(liste_annee.Count))
                            {
                                sb.AppendLine(string.Format("<th width=15%>{0}</th>", lr.ANNEE_DETAIL));
                                //TabLOT[i] = lr.ANNEE_DETAIL;
                            }
                            i++;
                        }
                    }

                    sb.AppendLine("</thead>");
                    sb.AppendLine("<tbody>");

                    var liste_libelle = service.AnafiAfficheLiasse(0, "", "", "CR");

                    foreach (var lr in liste_libelle)
                    {
                        if (lr.RUBR_ETAT_CODE.Trim() == "C019" || lr.RUBR_ETAT_CODE.Trim() == "C029" || lr.RUBR_ETAT_CODE.Trim() == "C039" || lr.RUBR_ETAT_CODE.Trim() == "C049" || lr.RUBR_ETAT_CODE.Trim() == "C059" || lr.RUBR_ETAT_CODE.Trim() == "C069" || lr.RUBR_ETAT_CODE.Trim() == "C079" || lr.RUBR_ETAT_CODE.Trim() == "C089" || lr.RUBR_ETAT_CODE.Trim() == "C099" || lr.RUBR_ETAT_CODE.Trim() == "C109" || lr.RUBR_ETAT_CODE.Trim() == "C119")
                        {
                            sb.AppendLine(string.Format("<tr data_code='{0}' style='background-color:#ddd'>", lr.RUBR_ETAT_CODE.ToString().Trim()));

                            sb.AppendLine(string.Format("<td class='text-left'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE));
                            // TabLOTA = new string[Convert.ToInt32(liste_annee.Count)];
                            int p = 0;
                            var liste_valeur = service.AnafiAfficheLiasse(4, idDossier, lr.RUBR_ETAT_CODE.ToString().Trim(), "SA");
                            int j = 0;
                            int v = 0;
                            v = Convert.ToInt32(liste_valeur.Count) - 3;
                            foreach (var l in liste_valeur)
                            {

                                if (liste_valeur.Count > 3)
                                {
                                    j++;
                                    if (v < j)
                                    {
                                        if (l.TYPE_ANAFI_A.Trim() == "SA")
                                        {
                                            sb.AppendLine(string.Format("<td class='text-right'><strong>{0}</strong></td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_TS_DETAIL))));
                                            // TabLOTA[p] = l.VALEUR_RAT_AFF_DETAIL.ToString();
                                            p++;
                                        }
                                    }

                                }
                                else
                                {
                                    if (l.TYPE_ANAFI_A.Trim() == "SA")
                                    {
                                        sb.AppendLine(string.Format("<td class='text-right'><strong>{0}</strong></td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_TS_DETAIL))));
                                        // TabLOTA[p] = l.VALEUR_RAT_AFF_DETAIL.ToString();
                                        p++;
                                    }
                                }
                            }


                            sb.AppendLine("</tr>");
                        }
                        else
                        {
                            sb.AppendLine(string.Format("<tr data_code='{0}'>", lr.RUBR_ETAT_CODE.ToString().Trim()));

                            sb.AppendLine(string.Format("<td class='text-left'>{0}</td>", lr.RUBR_ETAT_LIBELLE));
                            // TabLOTA = new string[Convert.ToInt32(liste_annee.Count)];
                            int p = 0;
                            var liste_valeur = service.AnafiAfficheLiasse(4, idDossier, lr.RUBR_ETAT_CODE.ToString().Trim(), "SA");

                            int j = 0;
                            int v = 0;
                            v = Convert.ToInt32(liste_valeur.Count) - 3;
                            foreach (var l in liste_valeur)
                            {

                                if (liste_valeur.Count > 3)
                                {
                                    j++;
                                    if (v < j)
                                    {
                                        if (l.TYPE_ANAFI_A.Trim() == "SA")
                                        {
                                            sb.AppendLine(string.Format("<td class='text-right'>{0}</td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_TS_DETAIL))));
                                            // TabLOTA[p] = l.VALEUR_RAT_AFF_DETAIL.ToString();
                                            p++;
                                        }
                                    }

                                }
                                else
                                {
                                    if (l.TYPE_ANAFI_A.Trim() == "SA")
                                    {
                                        sb.AppendLine(string.Format("<td class='text-right'>{0}</td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_TS_DETAIL))));
                                        // TabLOTA[p] = l.VALEUR_RAT_AFF_DETAIL.ToString();
                                        p++;
                                    }
                                }
                            }


                            sb.AppendLine("</tr>");
                        }

                    }

                    sb.AppendLine("</tbody>");
                    sb.AppendLine("</table>");
                }
                else
                {
                    sb.AppendLine("<div class='col-lg-12 col-sm-12 col-md-12' >");
                    sb.AppendLine("<table id='' class='table table-hover table-bordered text-center'>");
                    sb.AppendLine("<thead class='table-heigth'>");
                    sb.AppendLine(string.Format("<tr><th>Libellés</th>"));
                    sb.AppendLine(string.Format("<th width=23%></th>"));

                    sb.AppendLine("</thead>");
                    sb.AppendLine("<tbody>");

                    var liste_libelle = service.AnafiAfficheLiasse(0, "", "", "CR");

                    foreach (var lr in liste_libelle)
                    {


                        if (lr.RUBR_ETAT_CODE.Trim() == "C019" || lr.RUBR_ETAT_CODE.Trim() == "C029" || lr.RUBR_ETAT_CODE.Trim() == "C039" || lr.RUBR_ETAT_CODE.Trim() == "C049" || lr.RUBR_ETAT_CODE.Trim() == "C059" || lr.RUBR_ETAT_CODE.Trim() == "C069" || lr.RUBR_ETAT_CODE.Trim() == "C079" || lr.RUBR_ETAT_CODE.Trim() == "C089" || lr.RUBR_ETAT_CODE.Trim() == "C099" || lr.RUBR_ETAT_CODE.Trim() == "C109" || lr.RUBR_ETAT_CODE.Trim() == "C119")
                        {
                            sb.AppendLine(string.Format("<tr data_code='{0}' style='background-color:#ddd'>", lr.RUBR_ETAT_CODE.ToString().Trim()));
                            sb.AppendLine(string.Format("<td class='text-left'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE));
                            sb.AppendLine(string.Format("<td ></td >"));
                        }
                        else
                        {
                            sb.AppendLine(string.Format("<tr data_code='{0}'>", lr.RUBR_ETAT_CODE.ToString().Trim()));
                            sb.AppendLine(string.Format("<td class='text-left'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE));
                            sb.AppendLine(string.Format("<td ></td >"));
                        }



                        sb.AppendLine("</tr>");
                    }

                    sb.AppendLine("</tbody>");
                    sb.AppendLine("</table>");
                }
                sb.AppendLine("</div>");


            }
            else
            {
                //DIVtotauxActif.Visible = false;
                //DIVtotauxPassif.Visible = false;
                //DivecartsActifPassif.Visible = false;
            }
            ListDFinanciers.InnerHtml = sb.ToString();
        }

        public void afficheTDRBN()
        {
            if (Session["id_dossier"] == null) Response.Redirect("~/Scoring/Connexion.aspx");

            var idDossier = Session["id_dossier"].ToString();
            Session.Add("id_dossier", idDossier);
            if (DdlRubrique.Text == "Tableau des documents résumés")
            {
                Type_anafi = "BN";
                Div1.Visible = true;
                Div2.Visible = true;


                CompteResult.Visible = false;
                divCharge.Visible = false;
                divProduit.Visible = false;

                var liste_annee = service.AnafiAfficheLiasse(7, idDossier, "", "SN");
                var nombre_annee = service.AnafiAfficheLiasse(8, idDossier, "", "SN");

                if (liste_annee.Count != 0)
                {
                    sb.AppendLine("<div class='col-lg-12 col-sm-12 col-md-12' >");
                    sb.AppendLine("<table id='' class='table table-hover table-bordered text-center'>");
                    sb.AppendLine("<thead class='table-heigth'>");
                    sb.AppendLine(string.Format("<tr><th>Valeurs structurelles</th>"));

                    if (liste_annee.Count > 3)
                    {
                        int j = 0;
                        int v = 0;
                        int i = 0;
                        v = Convert.ToInt32(liste_annee.Count) - 3;
                        foreach (var lr in liste_annee)
                        {
                            j++;
                            if (v < j)
                            {
                                if (i < Convert.ToInt32(liste_annee.Count))
                                {
                                    sb.AppendLine(string.Format("<th width=15%>{0}</th>", lr.ANNEE_DETAIL));
                                    //TabLOT[i] = lr.ANNEE_DETAIL;
                                }
                            }

                            i++;
                        }
                    }
                    else
                    {
                        int i = 0;
                        foreach (var lr in liste_annee)
                        {

                            if (i < Convert.ToInt32(liste_annee.Count))
                            {
                                sb.AppendLine(string.Format("<th width=15%>{0}</th>", lr.ANNEE_DETAIL));
                                //TabLOT[i] = lr.ANNEE_DETAIL;
                            }
                            i++;
                        }
                    }


                    sb.AppendLine("</thead>");
                    sb.AppendLine("<tbody>");

                    var liste_libelle = service.AnafiAfficheLiasse(0, "", "", "TDR");

                    foreach (var lr in liste_libelle)
                    {
                        if (lr.RUBR_ETAT_CODE.Trim() == "BI40" || lr.RUBR_ETAT_CODE.Trim() == "BI41" || lr.RUBR_ETAT_CODE.Trim() == "BI42" || lr.RUBR_ETAT_CODE.Trim() == "BI43" || lr.RUBR_ETAT_CODE.Trim() == "BJ00" || lr.RUBR_ETAT_CODE.Trim() == "BJ1" || lr.RUBR_ETAT_CODE.Trim() == "BI6A" || lr.RUBR_ETAT_CODE.Trim() == "BK1" || lr.RUBR_ETAT_CODE.Trim() == "TN1" || lr.RUBR_ETAT_CODE.Trim() == "TN20" || lr.RUBR_ETAT_CODE.Trim() == "TN21" || lr.RUBR_ETAT_CODE.Trim() == "ZN2" || lr.RUBR_ETAT_CODE.Trim() == "BI2A" || lr.RUBR_ETAT_CODE.Trim() == "BI3A" || lr.RUBR_ETAT_CODE.Trim() == "BI7A")
                        {
                            if (lr.RUBR_ETAT_CODE.Trim() == "BJ1" || lr.RUBR_ETAT_CODE.Trim() == "BK1" || lr.RUBR_ETAT_CODE.Trim() == "TN1" || lr.RUBR_ETAT_CODE.Trim() == "ZN2")
                            {
                                sb.AppendLine(string.Format("<tr data_code='{0}' style='background-color:#ddd'>", lr.RUBR_ETAT_CODE.ToString().Trim()));

                                sb.AppendLine(string.Format("<td class='text-left'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE));
                                // TabLOTA = new string[Convert.ToInt32(liste_annee.Count)];
                                int p = 0;
                                var liste_valeur = service.AnafiAfficheLiasse(5, idDossier, lr.RUBR_ETAT_CODE.ToString().Trim(), "SN");

                                int j = 0;
                                int v = 0;
                                v = Convert.ToInt32(liste_valeur.Count) - 3;
                                foreach (var l in liste_valeur)
                                {

                                    if (liste_valeur.Count > 3)
                                    {
                                        j++;
                                        if (v < j)
                                        {
                                            if (l.TYPE_ANAFI_A.Trim() == "SN")
                                            {
                                                sb.AppendLine(string.Format("<td class='text-right'><strong>{0}</strong></td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_TDR_DETAIL))));
                                                // TabLOTA[p] = l.VALEUR_TDR_DETAIL.ToString();
                                                p++;
                                            }
                                        }

                                    }
                                    else
                                    {
                                        if (l.TYPE_ANAFI_A.Trim() == "SN")
                                        {
                                            sb.AppendLine(string.Format("<td class='text-right'><strong>{0}</strong></td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_TDR_DETAIL))));
                                            // TabLOTA[p] = l.VALEUR_TDR_DETAIL.ToString();
                                            p++;
                                        }
                                    }
                                }


                                sb.AppendLine("</tr>");
                            }
                            else
                            {
                                sb.AppendLine(string.Format("<tr data_code='{0}'>", lr.RUBR_ETAT_CODE.ToString().Trim()));

                                sb.AppendLine(string.Format("<td class='text-left'>{0}</td>", lr.RUBR_ETAT_LIBELLE));
                                // TabLOTA = new string[Convert.ToInt32(liste_annee.Count)];
                                int p = 0;
                                var liste_valeur = service.AnafiAfficheLiasse(5, idDossier, lr.RUBR_ETAT_CODE.ToString().Trim(), "SN");

                                int j = 0;
                                int v = 0;
                                v = Convert.ToInt32(liste_valeur.Count) - 3;
                                foreach (var l in liste_valeur)
                                {

                                    if (liste_valeur.Count > 3)
                                    {
                                        j++;
                                        if (v < j)
                                        {
                                            if (l.TYPE_ANAFI_A.Trim() == "SN")
                                            {
                                                sb.AppendLine(string.Format("<td class='text-right'>{0}</td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_TDR_DETAIL))));
                                                // TabLOTA[p] = l.VALEUR_TDR_DETAIL.ToString();
                                                p++;
                                            }
                                        }

                                    }
                                    else
                                    {
                                        if (l.TYPE_ANAFI_A.Trim() == "SN")
                                        {
                                            sb.AppendLine(string.Format("<td class='text-right'>{0}</td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_TDR_DETAIL))));
                                            // TabLOTA[p] = l.VALEUR_TDR_DETAIL.ToString();
                                            p++;
                                        }
                                    }
                                }

                                sb.AppendLine("</tr>");
                            }
                        }
                        else
                        {
                            if (lr.RUBR_ETAT_CODE.Trim() == "ZN3")
                            {
                                sb.AppendLine(string.Format("<tr style='background-color:transparent; border:none;'>"));
                                sb.AppendLine(string.Format("<td class='text-left' style='background-color:transparent; border:none;'><strong>RATIOS</strong></td>"));
                                sb.AppendLine("</tr>");
                            }
                            else
                            {
                                sb.AppendLine(string.Format("<tr data_code='{0}'>", lr.RUBR_ETAT_CODE.ToString().Trim()));

                                sb.AppendLine(string.Format("<td class='text-left'>{0}</td>", lr.RUBR_ETAT_LIBELLE));
                                // TabLOTA = new string[Convert.ToInt32(liste_annee.Count)];
                                int p = 0;
                                var liste_valeur = service.AnafiAfficheLiasse(5, idDossier, lr.RUBR_ETAT_CODE.ToString().Trim(), "SN");

                                int j = 0;
                                int v = 0;
                                v = Convert.ToInt32(liste_valeur.Count) - 3;
                                foreach (var l in liste_valeur)
                                {

                                    if (liste_valeur.Count > 3)
                                    {
                                        j++;
                                        if (v < j)
                                        {
                                            if (l.TYPE_ANAFI_A.Trim() == "SN")
                                            {
                                                sb.AppendLine(string.Format("<td class='text-right'>{0}</td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_TDR_DETAIL))));
                                                // TabLOTA[p] = l.VALEUR_TDR_DETAIL.ToString();
                                                p++;
                                            }
                                        }

                                    }
                                    else
                                    {
                                        if (l.TYPE_ANAFI_A.Trim() == "SN")
                                        {
                                            sb.AppendLine(string.Format("<td class='text-right'>{0}</td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_TDR_DETAIL))));
                                            // TabLOTA[p] = l.VALEUR_TDR_DETAIL.ToString();
                                            p++;
                                        }
                                    }
                                }

                                sb.AppendLine("</tr>");
                            }
                        }



                    }

                    sb.AppendLine("</tbody>");
                    sb.AppendLine("</table>");
                }
                else
                {
                    sb.AppendLine("<div class='col-lg-12 col-sm-12 col-md-12' >");
                    sb.AppendLine("<table id='' class='table table-hover table-bordered text-center'>");
                    sb.AppendLine("<thead class='table-heigth'>");
                    sb.AppendLine(string.Format("<tr><th>Valeurs structurelles</th>"));
                    sb.AppendLine(string.Format("<th width=23%></th></tr>"));

                    sb.AppendLine("</thead>");
                    sb.AppendLine("<tbody>");

                    var liste_libelle = service.AnafiAfficheLiasse(0, "", "", "TDR");

                    foreach (var lr in liste_libelle)
                    {
                        if (lr.RUBR_ETAT_CODE.Trim() == "BI40" || lr.RUBR_ETAT_CODE.Trim() == "BI41" || lr.RUBR_ETAT_CODE.Trim() == "BI42" || lr.RUBR_ETAT_CODE.Trim() == "BI43" || lr.RUBR_ETAT_CODE.Trim() == "BJ00" || lr.RUBR_ETAT_CODE.Trim() == "BJ1" || lr.RUBR_ETAT_CODE.Trim() == "BI6A" || lr.RUBR_ETAT_CODE.Trim() == "BK1" || lr.RUBR_ETAT_CODE.Trim() == "TN1" || lr.RUBR_ETAT_CODE.Trim() == "TN20" || lr.RUBR_ETAT_CODE.Trim() == "TN21" || lr.RUBR_ETAT_CODE.Trim() == "ZN2" || lr.RUBR_ETAT_CODE.Trim() == "BI2A" || lr.RUBR_ETAT_CODE.Trim() == "BI3A" || lr.RUBR_ETAT_CODE.Trim() == "BI7A")
                        {
                            if (lr.RUBR_ETAT_CODE.Trim() == "BJ1" || lr.RUBR_ETAT_CODE.Trim() == "BK1" || lr.RUBR_ETAT_CODE.Trim() == "TN1" || lr.RUBR_ETAT_CODE.Trim() == "ZN2")
                            {
                                sb.AppendLine(string.Format("<tr data_code='{0}' style='background-color:#ddd'>", lr.RUBR_ETAT_CODE.ToString().Trim()));

                                sb.AppendLine(string.Format("<td class='text-left'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE));
                                sb.AppendLine(string.Format("<td></td>"));

                                sb.AppendLine("</tr>");
                            }
                            else
                            {
                                sb.AppendLine(string.Format("<tr data_code='{0}'>", lr.RUBR_ETAT_CODE.ToString().Trim()));

                                sb.AppendLine(string.Format("<td class='text-left'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE));
                                sb.AppendLine(string.Format("<td></td>"));

                                sb.AppendLine("</tr>");
                            }
                        }
                        else
                        {
                            if (lr.RUBR_ETAT_CODE.Trim() == "ZN3")
                            {
                                sb.AppendLine(string.Format("<tr style='background-color:transparent; border:none;'>"));
                                sb.AppendLine(string.Format("<td class='text-left' style='background-color:transparent; border:none;'><strong>RATIOS</strong></td>"));
                                sb.AppendLine("</tr>");
                            }
                            else
                            {
                                sb.AppendLine(string.Format("<tr data_code='{0}'>", lr.RUBR_ETAT_CODE.ToString().Trim()));

                                sb.AppendLine(string.Format("<td class='text-left'>{0}</td>", lr.RUBR_ETAT_LIBELLE));
                                sb.AppendLine(string.Format("<td></td>"));

                                sb.AppendLine("</tr>");
                            }
                        }



                    }

                    sb.AppendLine("</tbody>");
                    sb.AppendLine("</table>");


                }
                sb.AppendLine("</div>");


            }
            else
            {
                //DIVtotauxActif.Visible = false;
                //DIVtotauxPassif.Visible = false;
                //DivecartsActifPassif.Visible = false;
            }
            ListDFinanciers.InnerHtml = sb.ToString();

        }

        public void afficheTDRSA()
        {
            if (Session["id_dossier"] == null) Response.Redirect("~/Scoring/Connexion.aspx");

            var idDossier = Session["id_dossier"].ToString();
            Session.Add("id_dossier", idDossier);
            if (DdlRubrique.Text == "Tableau des documents résumés")
            {
                Type_anafi = "BN";
                Div1.Visible = true;
                Div2.Visible = true;
                var liste_annee = service.AnafiAfficheLiasse(7, idDossier, "", "SA");
                var nombre_annee = service.AnafiAfficheLiasse(8, idDossier, "", "SA");

                if (liste_annee.Count != 0)
                {
                    sb.AppendLine("<div class='col-lg-12 col-sm-12 col-md-12' >");
                    sb.AppendLine("<table id='' class='table table-hover table-bordered text-center'>");
                    sb.AppendLine("<thead class='table-heigth'>");
                    sb.AppendLine(string.Format("<tr><th>Valeurs structurelles</th>"));

                    if (liste_annee.Count > 3)
                    {
                        int j = 0;
                        int v = 0;
                        int i = 0;
                        v = Convert.ToInt32(liste_annee.Count) - 3;
                        foreach (var lr in liste_annee)
                        {
                            j++;
                            if (v < j)
                            {
                                if (i < Convert.ToInt32(liste_annee.Count))
                                {
                                    sb.AppendLine(string.Format("<th width=15%>{0}</th>", lr.ANNEE_DETAIL));
                                    //TabLOT[i] = lr.ANNEE_DETAIL;
                                }
                            }

                            i++;
                        }
                    }
                    else
                    {
                        int i = 0;
                        foreach (var lr in liste_annee)
                        {

                            if (i < Convert.ToInt32(liste_annee.Count))
                            {
                                sb.AppendLine(string.Format("<th width=15%>{0}</th>", lr.ANNEE_DETAIL));
                                //TabLOT[i] = lr.ANNEE_DETAIL;
                            }
                            i++;
                        }
                    }


                    sb.AppendLine("</thead>");
                    sb.AppendLine("<tbody>");

                    var liste_libelle = service.AnafiAfficheLiasse(0, "", "", "TDR");

                    foreach (var lr in liste_libelle)
                    {
                        if (lr.RUBR_ETAT_CODE.Trim() == "BI40" || lr.RUBR_ETAT_CODE.Trim() == "BI41" || lr.RUBR_ETAT_CODE.Trim() == "BI42" || lr.RUBR_ETAT_CODE.Trim() == "BI43" || lr.RUBR_ETAT_CODE.Trim() == "BJ00" || lr.RUBR_ETAT_CODE.Trim() == "BJ1" || lr.RUBR_ETAT_CODE.Trim() == "BI6A" || lr.RUBR_ETAT_CODE.Trim() == "BK1" || lr.RUBR_ETAT_CODE.Trim() == "TN1" || lr.RUBR_ETAT_CODE.Trim() == "TN20" || lr.RUBR_ETAT_CODE.Trim() == "TN21" || lr.RUBR_ETAT_CODE.Trim() == "ZN2" || lr.RUBR_ETAT_CODE.Trim() == "BI2A" || lr.RUBR_ETAT_CODE.Trim() == "BI3A" || lr.RUBR_ETAT_CODE.Trim() == "BI7A")
                        {
                            if (lr.RUBR_ETAT_CODE.Trim() == "BJ1" || lr.RUBR_ETAT_CODE.Trim() == "BK1" || lr.RUBR_ETAT_CODE.Trim() == "TN1" || lr.RUBR_ETAT_CODE.Trim() == "ZN2")
                            {
                                sb.AppendLine(string.Format("<tr data_code='{0}' style='background-color:#ddd'>", lr.RUBR_ETAT_CODE.ToString().Trim()));

                                sb.AppendLine(string.Format("<td class='text-left'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE));
                                // TabLOTA = new string[Convert.ToInt32(liste_annee.Count)];
                                int p = 0;
                                var liste_valeur = service.AnafiAfficheLiasse(5, idDossier, lr.RUBR_ETAT_CODE.ToString().Trim(), "SA");

                                int j = 0;
                                int v = 0;
                                v = Convert.ToInt32(liste_valeur.Count) - 3;
                                foreach (var l in liste_valeur)
                                {

                                    if (liste_valeur.Count > 3)
                                    {
                                        j++;
                                        if (v < j)
                                        {
                                            if (l.TYPE_ANAFI_A.Trim() == "SA")
                                            {
                                                sb.AppendLine(string.Format("<td class='text-right'><strong>{0}</strong></td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_TDR_DETAIL))));
                                                // TabLOTA[p] = l.VALEUR_TDR_DETAIL.ToString();
                                                p++;
                                            }
                                        }

                                    }
                                    else
                                    {
                                        if (l.TYPE_ANAFI_A.Trim() == "SA")
                                        {
                                            sb.AppendLine(string.Format("<td class='text-right'><strong>{0}</strong></td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_TDR_DETAIL))));
                                            // TabLOTA[p] = l.VALEUR_TDR_DETAIL.ToString();
                                            p++;
                                        }
                                    }
                                }


                                sb.AppendLine("</tr>");
                            }
                            else
                            {
                                sb.AppendLine(string.Format("<tr data_code='{0}'>", lr.RUBR_ETAT_CODE.ToString().Trim()));

                                sb.AppendLine(string.Format("<td class='text-left'>{0}</td>", lr.RUBR_ETAT_LIBELLE));
                                // TabLOTA = new string[Convert.ToInt32(liste_annee.Count)];
                                int p = 0;
                                var liste_valeur = service.AnafiAfficheLiasse(5, idDossier, lr.RUBR_ETAT_CODE.ToString().Trim(), "SA");

                                int j = 0;
                                int v = 0;
                                v = Convert.ToInt32(liste_valeur.Count) - 3;
                                foreach (var l in liste_valeur)
                                {

                                    if (liste_valeur.Count > 3)
                                    {
                                        j++;
                                        if (v < j)
                                        {
                                            if (l.TYPE_ANAFI_A.Trim() == "SA")
                                            {
                                                sb.AppendLine(string.Format("<td class='text-right'>{0}</td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_TDR_DETAIL))));
                                                // TabLOTA[p] = l.VALEUR_TDR_DETAIL.ToString();
                                                p++;
                                            }
                                        }

                                    }
                                    else
                                    {
                                        if (l.TYPE_ANAFI_A.Trim() == "SA")
                                        {
                                            sb.AppendLine(string.Format("<td class='text-right'>{0}</td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_TDR_DETAIL))));
                                            // TabLOTA[p] = l.VALEUR_TDR_DETAIL.ToString();
                                            p++;
                                        }
                                    }
                                }

                                sb.AppendLine("</tr>");
                            }
                        }
                        else
                        {
                            if (lr.RUBR_ETAT_CODE.Trim() == "ZN3")
                            {
                                sb.AppendLine(string.Format("<tr style='background-color:transparent; border:none;'>"));
                                sb.AppendLine(string.Format("<td class='text-left' style='background-color:transparent; border:none;'><strong>RATIOS</strong></td>"));
                                sb.AppendLine("</tr>");
                            }
                            else
                            {
                                sb.AppendLine(string.Format("<tr data_code='{0}'>", lr.RUBR_ETAT_CODE.ToString().Trim()));

                                sb.AppendLine(string.Format("<td class='text-left'>{0}</td>", lr.RUBR_ETAT_LIBELLE));
                                // TabLOTA = new string[Convert.ToInt32(liste_annee.Count)];
                                int p = 0;
                                var liste_valeur = service.AnafiAfficheLiasse(5, idDossier, lr.RUBR_ETAT_CODE.ToString().Trim(), "SA");

                                int j = 0;
                                int v = 0;
                                v = Convert.ToInt32(liste_valeur.Count) - 3;
                                foreach (var l in liste_valeur)
                                {

                                    if (liste_valeur.Count > 3)
                                    {
                                        j++;
                                        if (v < j)
                                        {
                                            if (l.TYPE_ANAFI_A.Trim() == "SA")
                                            {
                                                sb.AppendLine(string.Format("<td class='text-right'>{0}</td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_TDR_DETAIL))));
                                                // TabLOTA[p] = l.VALEUR_TDR_DETAIL.ToString();
                                                p++;
                                            }
                                        }

                                    }
                                    else
                                    {
                                        if (l.TYPE_ANAFI_A.Trim() == "SA")
                                        {
                                            sb.AppendLine(string.Format("<td class='text-right'>{0}</td>", Convert.ToString(string.Format("{0:#,##0}", l.VALEUR_TDR_DETAIL))));
                                            // TabLOTA[p] = l.VALEUR_TDR_DETAIL.ToString();
                                            p++;
                                        }
                                    }
                                }

                                sb.AppendLine("</tr>");
                            }
                        }



                    }

                    sb.AppendLine("</tbody>");
                    sb.AppendLine("</table>");
                }
                else
                {
                    sb.AppendLine("<div class='col-lg-12 col-sm-12 col-md-12' >");
                    sb.AppendLine("<table id='' class='table table-hover table-bordered text-center'>");
                    sb.AppendLine("<thead class='table-heigth'>");
                    sb.AppendLine(string.Format("<tr><th>Valeurs structurelles</th>"));
                    sb.AppendLine(string.Format("<th width=23%></th></tr>"));

                    sb.AppendLine("</thead>");
                    sb.AppendLine("<tbody>");

                    var liste_libelle = service.AnafiAfficheLiasse(0, "", "", "TDR");

                    foreach (var lr in liste_libelle)
                    {
                        if (lr.RUBR_ETAT_CODE.Trim() == "BI40" || lr.RUBR_ETAT_CODE.Trim() == "BI41" || lr.RUBR_ETAT_CODE.Trim() == "BI42" || lr.RUBR_ETAT_CODE.Trim() == "BI43" || lr.RUBR_ETAT_CODE.Trim() == "BJ00" || lr.RUBR_ETAT_CODE.Trim() == "BJ1" || lr.RUBR_ETAT_CODE.Trim() == "BI6A" || lr.RUBR_ETAT_CODE.Trim() == "BK1" || lr.RUBR_ETAT_CODE.Trim() == "TN1" || lr.RUBR_ETAT_CODE.Trim() == "TN20" || lr.RUBR_ETAT_CODE.Trim() == "TN21" || lr.RUBR_ETAT_CODE.Trim() == "ZN2" || lr.RUBR_ETAT_CODE.Trim() == "BI2A" || lr.RUBR_ETAT_CODE.Trim() == "BI3A" || lr.RUBR_ETAT_CODE.Trim() == "BI7A")
                        {
                            if (lr.RUBR_ETAT_CODE.Trim() == "BJ1" || lr.RUBR_ETAT_CODE.Trim() == "BK1" || lr.RUBR_ETAT_CODE.Trim() == "TN1" || lr.RUBR_ETAT_CODE.Trim() == "ZN2")
                            {
                                sb.AppendLine(string.Format("<tr data_code='{0}' style='background-color:#ddd'>", lr.RUBR_ETAT_CODE.ToString().Trim()));

                                sb.AppendLine(string.Format("<td class='text-left'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE));
                                sb.AppendLine(string.Format("<td></td>"));

                                sb.AppendLine("</tr>");
                            }
                            else
                            {
                                sb.AppendLine(string.Format("<tr data_code='{0}'>", lr.RUBR_ETAT_CODE.ToString().Trim()));

                                sb.AppendLine(string.Format("<td class='text-left'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE));
                                sb.AppendLine(string.Format("<td></td>"));

                                sb.AppendLine("</tr>");
                            }
                        }
                        else
                        {
                            if (lr.RUBR_ETAT_CODE.Trim() == "ZN3")
                            {
                                sb.AppendLine(string.Format("<tr style='background-color:transparent; border:none;'>"));
                                sb.AppendLine(string.Format("<td class='text-left' style='background-color:transparent; border:none;'><strong>RATIOS</strong></td>"));
                                sb.AppendLine("</tr>");
                            }
                            else
                            {
                                sb.AppendLine(string.Format("<tr data_code='{0}'>", lr.RUBR_ETAT_CODE.ToString().Trim()));

                                sb.AppendLine(string.Format("<td class='text-left'>{0}</td>", lr.RUBR_ETAT_LIBELLE));
                                sb.AppendLine(string.Format("<td></td>"));

                                sb.AppendLine("</tr>");
                            }
                        }



                    }

                    sb.AppendLine("</tbody>");
                    sb.AppendLine("</table>");


                }
                sb.AppendLine("</div>");


            }
            else
            {
                //DIVtotauxActif.Visible = false;
                //DIVtotauxPassif.Visible = false;
                //DivecartsActifPassif.Visible = false;
            }
            ListDFinanciers.InnerHtml = sb.ToString();

        }

        public void afficherRatioBN()
        {
            if (Session["id_dossier"] == null) Response.Redirect("~/Scoring/Connexion.aspx");

            var idDossier = Session["id_dossier"].ToString();
            Session.Add("id_dossier", idDossier);
            if (DdlRubrique.Text == "Tableau des scores")
            {
                Div1.Visible = true;
                Div2.Visible = true;

                CompteResult.Visible = false;
                divCharge.Visible = false;
                divProduit.Visible = false;

                var liste_annee = service.AnafiAfficheLiasse(7, idDossier, "", "SN");
                var nombre_annee = service.AnafiAfficheLiasse(8, idDossier, "", "SN");

                if (liste_annee.Count != 0)
                {
                    sb.AppendLine("<div class='col-lg-12 col-sm-12 col-md-12' >");
                    sb.AppendLine("<table id='' class='table table-hover table-bordered text-center'>");
                    sb.AppendLine("<thead class='table-heigth'>");
                    sb.AppendLine(string.Format("<tr><th>Ratios</th>"));

                    if (liste_annee.Count > 3)
                    {
                        int j = 0;
                        int v = 0;
                        int i = 0;
                        v = Convert.ToInt32(liste_annee.Count) - 3;
                        foreach (var lr in liste_annee)
                        {
                            j++;
                            if (v < j)
                            {
                                if (i < Convert.ToInt32(liste_annee.Count))
                                {
                                    sb.AppendLine(string.Format("<th width=15%>{0}</th>", lr.ANNEE_DETAIL));
                                    //TabLOT[i] = lr.ANNEE_DETAIL;
                                }
                            }

                            i++;
                        }
                    }
                    else
                    {
                        int i = 0;
                        foreach (var lr in liste_annee)
                        {

                            if (i < Convert.ToInt32(liste_annee.Count))
                            {
                                sb.AppendLine(string.Format("<th width=15%>{0}</th>", lr.ANNEE_DETAIL));
                                //TabLOT[i] = lr.ANNEE_DETAIL;
                            }
                            i++;
                        }
                    }

                    sb.AppendLine("</thead>");
                    sb.AppendLine("<tbody>");

                    var liste_libelle = service.AnafiAfficheLiasse(0, "", "", "RAT");

                    foreach (var lr in liste_libelle)
                    {

                        sb.AppendLine(string.Format("<tr>"));

                        sb.AppendLine(string.Format("<td class='text-left'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE));
                        // TabLOTA = new string[Convert.ToInt32(liste_annee.Count)];
                        int p = 0;
                        var liste_valeur = service.AnafiAfficheLiasse(6, idDossier, lr.RUBR_ETAT_CODE.ToString().Trim(), "SN");

                        int j = 0;
                        int v = 0;
                        v = Convert.ToInt32(liste_valeur.Count) - 3;
                        foreach (var l in liste_valeur)
                        {

                            if (liste_valeur.Count > 3)
                            {
                                j++;
                                if (v < j)
                                {
                                    if (l.TYPE_ANAFI_A.Trim() == "SN")
                                    {
                                        if (lr.RUBR_ETAT_CODE.ToString().Trim() == "R03" || lr.RUBR_ETAT_CODE.ToString().Trim() == "R04" || lr.RUBR_ETAT_CODE.ToString().Trim() == "R05" || lr.RUBR_ETAT_CODE.ToString().Trim() == "R06" || lr.RUBR_ETAT_CODE.ToString().Trim() == "R07" || lr.RUBR_ETAT_CODE.ToString().Trim() == "R08")
                                        sb.AppendLine(string.Format("<td class='text-right'><strong>{0}</strong></td>", Convert.ToDecimal(l.VALEUR_RAT_AFF_DETAIL).ToString("#,##0.##")));
                                        else
                                            sb.AppendLine(string.Format("<td class='text-right'><strong>{0}%</strong></td>", Convert.ToDecimal(l.VALEUR_RAT_AFF_DETAIL).ToString("#,##0.##")));
                                        // TabLOTA[p] = l.VALEUR_RAT_AFF_DETAIL.ToString();
                                        p++;
                                    }
                                }

                            }
                            else
                            {
                                if (l.TYPE_ANAFI_A.Trim() == "SN")
                                {
                                    if (lr.RUBR_ETAT_CODE.ToString().Trim() == "R03" || lr.RUBR_ETAT_CODE.ToString().Trim() == "R04" || lr.RUBR_ETAT_CODE.ToString().Trim() == "R05" || lr.RUBR_ETAT_CODE.ToString().Trim() == "R06" || lr.RUBR_ETAT_CODE.ToString().Trim() == "R07" || lr.RUBR_ETAT_CODE.ToString().Trim() == "R08")
                                        sb.AppendLine(string.Format("<td class='text-right'><strong>{0}</strong></td>", Convert.ToDecimal(l.VALEUR_RAT_AFF_DETAIL).ToString("#,##0.##")));
                                    else
                                    sb.AppendLine(string.Format("<td class='text-right'><strong>{0}%</strong></td>", Convert.ToDecimal(l.VALEUR_RAT_AFF_DETAIL).ToString("#,##0.##")));
                                    // TabLOTA[p] = l.VALEUR_RAT_AFF_DETAIL.ToString();
                                    p++;
                                }
                            }
                        }


                        sb.AppendLine("</tr>");
                    }

                    sb.AppendLine("</tbody>");
                    sb.AppendLine("</table>");
                }
                else
                {
                    sb.AppendLine("<div class='col-lg-12 col-sm-12 col-md-12' >");
                    sb.AppendLine("<table id='' class='table table-hover table-bordered text-center'>");
                    sb.AppendLine("<thead class='table-heigth'>");
                    sb.AppendLine(string.Format("<tr><th>Ratios</th>"));
                    sb.AppendLine(string.Format("<th width=23%></th>"));

                    sb.AppendLine("</thead>");
                    sb.AppendLine("<tbody>");

                    var liste_libelle = service.AnafiAfficheLiasse(0, "", "", "RAT");

                    foreach (var lr in liste_libelle)
                    {

                        sb.AppendLine(string.Format("<tr>"));

                        sb.AppendLine(string.Format("<td class='text-left'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE));
                        sb.AppendLine(string.Format("<td ></td >"));

                        sb.AppendLine("</tr>");
                    }

                    sb.AppendLine("</tbody>");
                    sb.AppendLine("</table>");
                }
                sb.AppendLine("</div>");


            }
            else
            {
                //DIVtotauxActif.Visible = false;
                //DIVtotauxPassif.Visible = false;
                //DivecartsActifPassif.Visible = false;
            }
            ListDFinanciers.InnerHtml = sb.ToString();
        }


        public void afficherAutreRatioBN()
        {
            if (Session["id_dossier"] == null) Response.Redirect("~/Scoring/Connexion.aspx");

            var idDossier = Session["id_dossier"].ToString();
            Session.Add("id_dossier", idDossier);
            if (DdlRubrique.Text == "Tableau des autres ratios")
            {
                Div1.Visible = true;
                Div2.Visible = true;

                CompteResult.Visible = false;
                divCharge.Visible = false;
                divProduit.Visible = false;

                var liste_annee = service.AnafiAfficheLiasse(7, idDossier, "", "SN");
                var nombre_annee = service.AnafiAfficheLiasse(8, idDossier, "", "SN");

                if (liste_annee.Count != 0)
                {
                    sb.AppendLine("<div class='col-lg-12 col-sm-12 col-md-12' >");
                    sb.AppendLine("<table id='' class='table table-hover table-bordered text-center'>");
                    sb.AppendLine("<thead class='table-heigth'>");
                    sb.AppendLine(string.Format("<tr><th>Autres ratios</th>"));

                    if (liste_annee.Count > 3)
                    {
                        int j = 0;
                        int v = 0;
                        int i = 0;
                        v = Convert.ToInt32(liste_annee.Count) - 3;
                        foreach (var lr in liste_annee)
                        {
                            j++;
                            if (v < j)
                            {
                                if (i < Convert.ToInt32(liste_annee.Count))
                                {
                                    sb.AppendLine(string.Format("<th width=15%>{0}</th>", lr.ANNEE_DETAIL));
                                    //TabLOT[i] = lr.ANNEE_DETAIL;
                                }
                            }

                            i++;
                        }
                    }
                    else
                    {
                        int i = 0;
                        foreach (var lr in liste_annee)
                        {

                            if (i < Convert.ToInt32(liste_annee.Count))
                            {
                                sb.AppendLine(string.Format("<th width=15%>{0}</th>", lr.ANNEE_DETAIL));
                                //TabLOT[i] = lr.ANNEE_DETAIL;
                            }
                            i++;
                        }
                    }

                    sb.AppendLine("</thead>");
                    sb.AppendLine("<tbody>");

                    var liste_libelle = service.AnafiAfficheLiasse(0, "", "", "AUT");

                    foreach (var lr in liste_libelle)
                    {

                        sb.AppendLine(string.Format("<tr>"));

                        sb.AppendLine(string.Format("<td class='text-left'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE));
                        // TabLOTA = new string[Convert.ToInt32(liste_annee.Count)];
                        int p = 0;
                        var liste_valeur = service.AnafiAfficheLiasse(13, idDossier, lr.RUBR_ETAT_CODE.ToString().Trim(), "SN");

                        int j = 0;
                        int v = 0;
                        v = Convert.ToInt32(liste_valeur.Count) - 3;
                        foreach (var l in liste_valeur)
                        {

                            if (liste_valeur.Count > 3)
                            {
                                j++;
                                if (v < j)
                                {
                                    if (l.TYPE_ANAFI_A.Trim() == "SN")
                                    {
                                        if (lr.RUBR_ETAT_CODE.ToString().Trim() == "AU1")
                                            sb.AppendLine(string.Format("<td class='text-right'><strong>{0}%</strong></td>", Convert.ToDecimal(l.VALEUR_AUTRE_RAT_AFF_DETAIL).ToString("#,##0.##")));
                                        else
                                        sb.AppendLine(string.Format("<td class='text-right'><strong>{0}</strong></td>", Convert.ToDecimal(l.VALEUR_AUTRE_RAT_AFF_DETAIL).ToString("#,##0.##")));
                                        // TabLOTA[p] = l.VALEUR_RAT_AFF_DETAIL.ToString();
                                        p++;
                                    }
                                }

                            }
                            else
                            {
                                if (l.TYPE_ANAFI_A.Trim() == "SN")
                                {
                                    if (lr.RUBR_ETAT_CODE.ToString().Trim() == "AU1")
                                        sb.AppendLine(string.Format("<td class='text-right'><strong>{0}%</strong></td>", Convert.ToDecimal(l.VALEUR_AUTRE_RAT_AFF_DETAIL).ToString("#,##0.##")));
                                    else
                                    sb.AppendLine(string.Format("<td class='text-right'><strong>{0}</strong></td>", Convert.ToDecimal(l.VALEUR_AUTRE_RAT_AFF_DETAIL).ToString("#,##0.##")));
                                    // TabLOTA[p] = l.VALEUR_RAT_AFF_DETAIL.ToString();
                                    p++;
                                }
                            }
                        }


                        sb.AppendLine("</tr>");
                    }

                    sb.AppendLine("</tbody>");
                    sb.AppendLine("</table>");
                }
                else
                {
                    sb.AppendLine("<div class='col-lg-12 col-sm-12 col-md-12' >");
                    sb.AppendLine("<table id='' class='table table-hover table-bordered text-center'>");
                    sb.AppendLine("<thead class='table-heigth'>");
                    sb.AppendLine(string.Format("<tr><th>Autres ratios</th>"));
                    sb.AppendLine(string.Format("<th width=23%></th>"));

                    sb.AppendLine("</thead>");
                    sb.AppendLine("<tbody>");

                    var liste_libelle = service.AnafiAfficheLiasse(0, "", "", "AUT");

                    foreach (var lr in liste_libelle)
                    {

                        sb.AppendLine(string.Format("<tr>"));

                        sb.AppendLine(string.Format("<td class='text-left'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE));
                        sb.AppendLine(string.Format("<td ></td >"));

                        sb.AppendLine("</tr>");
                    }

                    sb.AppendLine("</tbody>");
                    sb.AppendLine("</table>");
                }
                sb.AppendLine("</div>");


            }
            else
            {
                //DIVtotauxActif.Visible = false;
                //DIVtotauxPassif.Visible = false;
                //DivecartsActifPassif.Visible = false;
            }
            ListDFinanciers.InnerHtml = sb.ToString();
        }




        public void afficherRatioSA()
        {
            var idDossier = Session["id_dossier"].ToString();
            Session.Add("id_dossier", idDossier);
            if (DdlRubrique.Text == "Tableau des scores")
            {
                Div1.Visible = true;
                Div2.Visible = true;
                var liste_annee = service.AnafiAfficheLiasse(7, idDossier, "", "SA");
                var nombre_annee = service.AnafiAfficheLiasse(8, idDossier, "", "SA");

                if (liste_annee.Count != 0)
                {
                    sb.AppendLine("<div class='col-lg-12 col-sm-12 col-md-12' >");
                    sb.AppendLine("<table id='' class='table table-hover table-bordered text-center'>");
                    sb.AppendLine("<thead class='table-heigth'>");
                    sb.AppendLine(string.Format("<tr><th>Ratios</th>"));

                    if (liste_annee.Count > 3)
                    {
                        int j = 0;
                        int v = 0;
                        int i = 0;
                        v = Convert.ToInt32(liste_annee.Count) - 3;
                        foreach (var lr in liste_annee)
                        {
                            j++;
                            if (v < j)
                            {
                                if (i < Convert.ToInt32(liste_annee.Count))
                                {
                                    sb.AppendLine(string.Format("<th width=15%>{0}</th>", lr.ANNEE_DETAIL));
                                    //TabLOT[i] = lr.ANNEE_DETAIL;
                                }
                            }

                            i++;
                        }
                    }
                    else
                    {
                        int i = 0;
                        foreach (var lr in liste_annee)
                        {

                            if (i < Convert.ToInt32(liste_annee.Count))
                            {
                                sb.AppendLine(string.Format("<th width=15%>{0}</th>", lr.ANNEE_DETAIL));
                                //TabLOT[i] = lr.ANNEE_DETAIL;
                            }
                            i++;
                        }
                    }

                    sb.AppendLine("</thead>");
                    sb.AppendLine("<tbody>");

                    var liste_libelle = service.AnafiAfficheLiasse(0, "", "", "RAT");

                    foreach (var lr in liste_libelle)
                    {

                        sb.AppendLine(string.Format("<tr>"));

                        sb.AppendLine(string.Format("<td class='text-left'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE));
                        // TabLOTA = new string[Convert.ToInt32(liste_annee.Count)];
                        int p = 0;
                        var liste_valeur = service.AnafiAfficheLiasse(6, idDossier, lr.RUBR_ETAT_CODE.ToString().Trim(), "SA");

                        int j = 0;
                        int v = 0;
                        v = Convert.ToInt32(liste_valeur.Count) - 3;
                        foreach (var l in liste_valeur)
                        {

                            if (liste_valeur.Count > 3)
                            {
                                j++;
                                if (v < j)
                                {
                                    if (l.TYPE_ANAFI_A.Trim() == "SA")
                                    {
                                        sb.AppendLine(string.Format("<td class='text-right'><strong>{0}</strong></td>", l.VALEUR_RAT_AFF_DETAIL));
                                        //sb.AppendLine(string.Format("<td class='text-right'><strong>{0}</strong></td>", Convert.ToDecimal(l.VALEUR_RAT_AFF_DETAIL).ToString("#,##0.##")));
                                        // TabLOTA[p] = l.VALEUR_RAT_AFF_DETAIL.ToString();
                                        p++;
                                    }
                                }

                            }
                            else
                            {
                                if (l.TYPE_ANAFI_A.Trim() == "SA")
                                {
                                    sb.AppendLine(string.Format("<td class='text-right'><strong>{0}</strong></td>", Convert.ToDecimal(l.VALEUR_RAT_AFF_DETAIL).ToString("#,##0.##")));
                                    // TabLOTA[p] = l.VALEUR_RAT_AFF_DETAIL.ToString();
                                    p++;
                                }
                            }
                        }


                        sb.AppendLine("</tr>");
                    }

                    sb.AppendLine("</tbody>");
                    sb.AppendLine("</table>");
                }
                else
                {
                    sb.AppendLine("<div class='col-lg-12 col-sm-12 col-md-12' >");
                    sb.AppendLine("<table id='' class='table table-hover table-bordered text-center'>");
                    sb.AppendLine("<thead class='table-heigth'>");
                    sb.AppendLine(string.Format("<tr><th>Ratios</th>"));
                    sb.AppendLine(string.Format("<th width=23%></th>"));

                    sb.AppendLine("</thead>");
                    sb.AppendLine("<tbody>");

                    var liste_libelle = service.AnafiAfficheLiasse(0, "", "", "RAT");

                    foreach (var lr in liste_libelle)
                    {

                        sb.AppendLine(string.Format("<tr>"));

                        sb.AppendLine(string.Format("<td class='text-left'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE));
                        sb.AppendLine(string.Format("<td ></td >"));

                        sb.AppendLine("</tr>");
                    }

                    sb.AppendLine("</tbody>");
                    sb.AppendLine("</table>");
                }
                sb.AppendLine("</div>");


            }
            else
            {
                //DIVtotauxActif.Visible = false;
                //DIVtotauxPassif.Visible = false;
                //DivecartsActifPassif.Visible = false;
            }
            ListDFinanciers.InnerHtml = sb.ToString();
        }

        //ListTDR(id_dossier)
        public void ModifVal(object sender, EventArgs e)
        {
            service.PS_SCOR_SPY(Session["id_user"].ToString().Trim(), "AnalyseFianciere", connmou007.Value.ToString(), "I");

            ModifValBilan();

            DataManager.RubANAFI = valeurtype.Text + "@" + DdlRubrique.Text;
            Maj_CA();
            Response.Redirect("~/Scoring/AnalyseFinanciere.aspx");
            //OpenShowPasvalideConsult("Enregistrement...", "Enregistrement effectué avec succès !!!");

        }

        // public void aleatoir() {

        //     if (DataManager.NoteFii == "") { NoteF.Text = ""; DataManager.NoteFii = "C"; }
        //    else
        //         if (DataManager.NoteFii == "C") { NoteF.Text = "B"; DataManager.NoteFii = "B"; }
        //        else
        //             if (DataManager.NoteFii == "B") { NoteF.Text = "A"; DataManager.NoteFii = "A"; }
        //            else
        //                 if (DataManager.NoteFii == "A") { NoteF.Text = "A+"; DataManager.NoteFii = "A+"; }
        //                else
        //                     if (DataManager.NoteFii == "A+") { NoteF.Text = "A-"; DataManager.NoteFii = "A-"; }
        //                     else { NoteF.Text = "C"; DataManager.NoteFii = "C"; } 

        //}


        public void ModifValBilan()
        {
            if (Session["id_dossier"] == null) Response.Redirect("~/Scoring/Connexion.aspx");

            DataManager.RubANAFI = valeurtype.Text + "@" + DdlRubrique.Text;

            //DdlRubrique
            //valeurtype
            // aleatoir();
            var codepostes = ModifID.Value.Split('@');
            var valeurs = ModifValeur.Value.Split('@');
            var annees = ModifAnnee.Value.Split('@');
            var idDossier = Session["id_dossier"].ToString();
            Session.Add("id_dossier", idDossier);
            var nbcol = Convert.ToInt32(nobcol.Value) - 1;
            var rubrType = "";
            var rubriq = "";
            if (valeurtype.Text.ToString() == "Bilan Normal") rubrType = "SN";
            if (valeurtype.Text.ToString() == "Bilan Allege") rubrType = "SA";
            if (valeurtype.Text.ToString() == "Systeme Minimal De Tresorerie") rubrType = "SMT";
            if (DdlRubrique.Text.ToString() == "Bilan") rubriq = "BIL";
            if (DdlRubrique.Text.ToString() == "Compte de résultat") rubriq = "CR";

            var totalis = codepostes.Length - 1;
            //var jj = 0;
            for (var i = 0; i < totalis; i++)
            {
                var actuoposte = codepostes[i];
                for (var j = 0; j < (annees.Length - 1); j++)
                {
                    service.ModiDonneLiasse(idDossier.ToString().Trim(), annees[j], Convert.ToDecimal(valeurs[(i * nbcol) + j]), actuoposte, rubrType, rubriq);
                }
                //   // var DetailNotes = service.DetailsNotesDossier(IDs[i].Trim());

                //   if (IDs[i].Trim() != "BI1A" && IDs[i].Trim() != "BI2A" && IDs[i].Trim() != "BI3A" && IDs[i].Trim() != "BI41" && IDs[i].Trim() != "BI43" && IDs[i].Trim() != "BI5A" && IDs[i].Trim() != "BI6A" && IDs[i].Trim() != "BI7A")
                //    {
                //       // IDs[i]; VALEURs[(i * 3)]; VALEURs[(i * 3) + 1]; VALEURs[(i * 3) + 2];
                //        service.ChangerBilan(idDossier.Trim(), IDs[i], Convert.ToDecimal(VALEURs[(i * 3)]), Convert.ToDecimal(VALEURs[(i * 3) + 1]), Convert.ToDecimal(VALEURs[(i * 3) + 2]), totalis-8);


                service.miseAjrDateFinan(idDossier);
            }
            for (var j = 0; j < (annees.Length - 1); j++)
            {
                service.CalclueTotauxLiasse(idDossier.ToString().Trim(), annees[j].ToString().Trim());
            }

        }



        protected void Ajouter_Liasse(object sender, EventArgs e)
        {
            DataManager.RubANAFI = valeurtype.Text + "@" + DdlRubrique.Text;
            DataManager.verification = "0";
            var idDossier = Session["id_dossier"].ToString();
            Session.Add("id_dossier", idDossier);
            //Boolean verification=false;
            var liste_annee = service.AnafiAfficheLiasse(7, idDossier, "", DdlAgenceTypeBilan.Value);
            foreach (var lr in liste_annee)
            {
                if (lr.ANNEE_DETAIL.Substring(3, 4) == /*Convert.ToDateTime(DateCloture.Value).Month.ToString("00") + "/" +*/ Convert.ToDateTime(DateCloture.Value).Year.ToString())
                {
                    DataManager.verification = lr.ANNEE_DETAIL;
                }
            }
            if (DataManager.verification != "0")
            {
                OpenShowvalideConsult("Attention...", "On ne peut avoir qu'une liasse par année. L'année choisie contient déja une liasse !!!  Voulez-vous Supprimer l'ancienne liasse ?");
            }
            else
            {
                service.AnafiSaisirLiasse(Convert.ToDateTime(DateCloture.Value).Month.ToString("00") + "/" + Convert.ToDateTime(DateCloture.Value).Year.ToString(), Convert.ToDateTime(DateCloture.Value), Convert.ToInt32(dureeExercice.Value), DdlAgenceTypeBilan.Value,
                                    DdlNatureExo.Value, DdlCertification.Value, Convert.ToInt32(TxtEffectif.Value), "XOF", TxtRegimeFiscale.Value, idDossier, DateTime.UtcNow, 0.18);

                OpenShowPasvalideConsult("Enregistrement...", "Enregistrement effectué avec succès !!!");


            }
            //verification = "0";
        }


        protected void SuppLiasseBtn_ServerClick(object sender, EventArgs e)
        {
            DataManager.RubANAFI = valeurtype.Text + "@" + DdlRubrique.Text;
            //var idDossier = Session["id_dossier"].ToString();
            //Session.Add("id_dossier", idDossier);
            //var annee=valdeselect.Value;
            //service.SuppLiasse(annee, idDossier);
            //Response.Redirect("~/Scoring/AnalyseFinanciere.aspx");

            OpenShowvalideConsult("Suppression ...", "Confirmez-vous la suppression de la liasse ?");



        }

        void OpenShowPasvalideConsult(string titre, string msg)
        {
            DataManager.RubANAFI = valeurtype.Text + "@" + DdlRubrique.Text;
            Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPasvalideConsult();", true);
            this.idtitre.Text = titre;
            this.idmesa.Text = msg;
        }

        void OpenShowvalideConsult(string titre, string msg)
        {
            DataManager.RubANAFI = valeurtype.Text + "@" + DdlRubrique.Text;
            Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowvalideConsult();", true);
            this.lblValidemessageConsult.Text = msg;
            this.lblValideTitreConsult.Text = titre;
        }

        protected void ShowvalideOpenConsult_ServerClick(object sender, EventArgs e)
        {
            DataManager.RubANAFI = valeurtype.Text + "@" + DdlRubrique.Text;
            if (Session["id_dossier"] == null) Response.Redirect("~/Scoring/Connexion.aspx");

            var idDossier = Session["id_dossier"].ToString();
            Session.Add("id_dossier", idDossier);

            if (DataManager.verification != "0")
            {
                var annee = DataManager.verification;
                service.SuppLiasse(annee, idDossier);
                DataManager.verification = "0";
                service.AnafiSaisirLiasse(Convert.ToDateTime(DateCloture.Value).Month.ToString("00") + "/" + Convert.ToDateTime(DateCloture.Value).Year.ToString(), Convert.ToDateTime(DateCloture.Value), Convert.ToInt32(dureeExercice.Value), DdlAgenceTypeBilan.Value,
                                       DdlNatureExo.Value, DdlCertification.Value, Convert.ToInt32(TxtEffectif.Value), "XOF", TxtRegimeFiscale.Value, idDossier, DateTime.UtcNow, 0.18);



                OpenShowPasvalideConsult("Enregistrement...", "Enregistrement effectué avec succès !!!");
            }
            else
            {
                var annee = valdeselect.Value;
                service.SuppLiasse(annee, idDossier);
                Maj_CA();
                OpenShowPasvalideConsult("Suppression...", "Suppression effectuée avec succès !!!");
                //Response.Redirect("~/Scoring/AnalyseFinanciere.aspx");

            }

        }

        protected void Unnamed_ServerClick(object sender, EventArgs e)
        {
            DataManager.RubANAFI = valeurtype.Text + "@" + DdlRubrique.Text;

            Response.Redirect("~/Scoring/AnalyseFinanciere.aspx");
        }

        protected void btnModifBil_ServerClick(object sender, EventArgs e)
        {
            if (Session["id_dossier"] == null) Response.Redirect("~/Scoring/Connexion.aspx");

            service.PS_SCOR_SPY(Session["id_user"].ToString().Trim(), "AnalyseFinanciere", connmou007.Value.ToString(), "M");
            DataManager.RubANAFI = valeurtype.Text + "@" + DdlRubrique.Text;
            var idDossier = Session["id_dossier"].ToString();
            Session.Add("id_dossier", idDossier);
            //A mettre sous le button calculer
            service.RetranscriptionDonnee(idDossier.ToString().Trim());
            //Response.Redirect("~/Scoring/AnalyseFinanciere.aspx");
            OpenShowPasvalideConsult("Modification...", "Calcul effectué avec succès !!!");
        }

        protected void Maj_CA()
        {
            if (Session["id_dossier"] == null) Response.Redirect("~/Scoring/Connexion.aspx");

            if (string.IsNullOrEmpty(Session["id_scoring"].ToString())) Response.Redirect("~/Scoring/AutreDossier.aspx");
                else
                {
                    var id_scoring = Session["id_scoring"].ToString();
                    var idDossier = Session["id_dossier"].ToString();
                var liste_annee = service.AnafiAfficheLiasse(7, idDossier, "", "SN");
                string annee1, annee2, annee3;
                var nombre_annee = service.AnafiAfficheLiasse(8, idDossier, "", "SN");

                if (liste_annee.Count != 0)
                {
                    if (liste_annee.Count > 3)
                    {
                        int j = 0;
                        int v = 0;
                        int i = 0;
                        v = Convert.ToInt32(liste_annee.Count) - 3;
                        foreach (var lr in liste_annee)
                        {
                            j++;
                            if (v < j)
                            {
                                if (i < Convert.ToInt32(liste_annee.Count))
                                {
                                    service.MAJ_CA(idDossier, lr.ANNEE_DETAIL, id_scoring);
                                }
                            }

                            i++;
                        }
                    }
                    else
                    {
                        int i = 0;
                        foreach (var lr in liste_annee)
                        {

                            if (i < Convert.ToInt32(liste_annee.Count))
                            {
                                service.MAJ_CA(idDossier, lr.ANNEE_DETAIL, id_scoring);
                            }
                            i++;
                        }
                    }

                }
               }

            }

        protected void Charger_Click(object sender, EventArgs e)
        {
            Envoyer_Click();
        }

        protected void Envoyer_Click()
        {
            if (fichier.PostedFile != null && fichier.PostedFile.ContentLength > 0)
            {

                string fn = System.IO.Path.GetFileName(fichier.PostedFile.FileName);
                string fexe = System.IO.Path.GetExtension(fichier.PostedFile.FileName);
                string saveLocation = @"" + Server.MapPath("Data") + "\\" + fn;
                string saveOutputLocation = @"" + Server.MapPath("Data") + "\\" + "csv" + fn.Replace(".xls", ".csv");
                //File.Delete(saveLocation);
                fichier.PostedFile.SaveAs(saveLocation);
                if (Session["id_dossier"] == null) Response.Redirect("~/Scoring/Connexion.aspx");
                var id_dossier = Session["id_dossier"].ToString();
                Session.Add("id_dossier", id_dossier);

                List<string> sheets = new List<string>();
                if (DropDownList3.Text.ToString() == "Bilan Normal")
                {
                    sheets.Add("Actif-Immo");
                    sheets.Add("Act-circul");
                    sheets.Add("Capitaux");
                    sheets.Add("Passif-circul");
                    sheets.Add("Charge1");
                    sheets.Add("Produit1");
                    sheets.Add("Charge2");
                    sheets.Add("Produit2");

                }
                else
                {
                    sheets.Add("Bilan (7)");
                    sheets.Add("Cpterés# (8)");
                }
                if (fexe == ".csv")
                {

                    //service.ChargerFichier(id_dossier.Trim(), saveLocation, DropDownList2.Text.ToString(), DropDownList3.Text.ToString(), datepicker.Value);
                    //Response.Redirect("~/Scoring/AnalyseFinanciere.aspx");
                    //service.CalclueTotauxLiasse(id_dossier.ToString().Trim(), datepicker.Value.ToString().Trim());



                }
                else if (fexe == ".xls")
                {
                    foreach (var sheet in sheets)
                    {
                        string strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + saveLocation + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=1\"";
                        ConvertExcelToCsv(saveLocation, saveOutputLocation, sheet, strConn);
                        service.ChargerFichier(id_dossier.Trim(), saveOutputLocation, DropDownList2.Text.ToString(), DropDownList3.Text.ToString(), datepicker.Value, sheet);
                        var hihi = 1;
                        File.Delete(saveOutputLocation);

                    }
                    Response.Redirect("~/Scoring/AnalyseFinanciere.aspx");
                    service.CalclueTotauxLiasse(id_dossier.ToString().Trim(), datepicker.Value.ToString().Trim());
                }
                else
                {
                    sb.AppendLine("<div class='alert alert-danger fade in'>");
                    sb.AppendLine("<a href='#' class='close' data-dismiss='alert' style='margin-top: -0.4%;'>&times;</a>");
                    sb.AppendLine(string.Format("<p><strong>{0}</strong></p>", fn));
                    sb.AppendLine("<strong>Fichier non chargé ...</strong>");
                    sb.AppendLine(string.Format("<strong>Le format actuel du fichier est </strong>", fexe));
                    sb.AppendLine("<strong>Charger un fichier au format .csv ou au format .xls</strong>");
                    sb.AppendLine("</div>");
                }

                File.Delete(saveLocation);
            }
            getMessageModd.InnerHtml = sb.ToString();
        }
        static void ConvertExcelToCsv(string excelFilePath, string csvOutputFile, string worksheet, string strConn)
        {
            string query = String.Format("select * from  [{0}$]", worksheet);
            var dt = new DataTable();
            var da = new OleDbDataAdapter(query, strConn);
            da.Fill(dt);
            
            using (var wtr = new StreamWriter(csvOutputFile))
            {
                foreach (DataRow row in dt.Rows)
                {
                    bool firstLine = true;
                    foreach (DataColumn col in dt.Columns)
                    {
                        if (!firstLine) { wtr.Write(';'); } else { firstLine = false; }
                        var data = row[col.ColumnName].ToString().Replace("\"", "\"\"");
                        wtr.Write(String.Format("{0}", data.Replace("â€¦", "").Replace("Ã©", "e")));
                    }
                    wtr.WriteLine();
                }
            }

            //using (var wtr = new StreamWriter(csvOutputFile))
            //{
            //    //string entête;
            //    //entête = string.Join(";", dt.Columns.OfType<DataColumn>().Select(c => c.ColumnName));

            //    //wtr.WriteLine(entête);

            //    foreach (DataRow ligne in dt.Rows)
            //    {
            //        string l;
            //        l = string.Join(";", ligne.ItemArray);

            //        wtr.WriteLine(l);
            //    }
            //}

        }
    //    protected void Envoyer_Click()
    //    {
    //        string fn = System.IO.Path.GetFileName(fichier.PostedFile.FileName);
    //        string fexe = System.IO.Path.GetExtension(fichier.PostedFile.FileName);
    //        string savelocation = @"" + Server.MapPath("data") + "\\" + fn;
    //        string saveoutputlocation = @"" + Server.MapPath("data") + "\\" + "csv" + fn.Replace(".xls", ".csv");
    //        fichier.PostedFile.SaveAs(savelocation);
    //        //if File is not selected then return  
    //        //Get the file extension  

    //        //If file is not in excel format then return  
    //        if (fexe != ".xls")
    //        { return; }

    //        //Get the File name and create new path to save it on server  
    //        string fileLocation = savelocation;

    //        //if the File is exist on serevr then delete it  
    //        if (File.Exists(fileLocation))
    //        {
    //            File.Delete(fileLocation);
    //        }
    //        //save the file lon the server before loading  
    //        fichier.PostedFile.SaveAs(savelocation);

    //        //Create the QueryString for differnt version of fexcel file  
    //        string strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + fileLocation
    //+ ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=1\"";
                   

    //        //Get the data from the excel sheet1 which is default  
    //        string query = "select * from  [Capitaux$]";
    //        OleDbConnection objConn;
    //        OleDbDataAdapter oleDA;
    //        DataTable dt = new DataTable();
    //        objConn = new OleDbConnection(strConn);
    //        objConn.Open();
    //        oleDA = new OleDbDataAdapter(query, objConn);
    //        oleDA.Fill(dt);
    //        objConn.Close();
    //        oleDA.Dispose();
    //        objConn.Dispose();

    //        //Bind the datatable to the Grid  
    //        GridView1.DataSource = dt;
           
    //        GridView1.DataBind();

           
    //        //Delete the excel file from the server  
    //        File.Delete(fileLocation);
               
    //    }
   }
}