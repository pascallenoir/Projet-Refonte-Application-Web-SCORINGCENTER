
//using ReportSource;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using ScoringCenter.Scoring;
using ScoringCenter.ScorManager;

namespace ScoringCenter
{
    public partial class PrintPreview : System.Web.UI.Page
    {

        StringBuilder sb = new StringBuilder();
        StringBuilder sbsd = new StringBuilder();
        StringBuilder sb2 = new StringBuilder();
        StringBuilder sbE = new StringBuilder();
        StringBuilder sbC = new StringBuilder();
        StringBuilder sbB = new StringBuilder();
        StringBuilder sbEcart = new StringBuilder();
        private System.Globalization.CultureInfo frCult = System.Globalization.CultureInfo.CreateSpecificCulture("fr-FR");

        StringBuilder sbBGM = new StringBuilder();
        StringBuilder sbBGM1 = new StringBuilder();
        StringBuilder sbTS = new StringBuilder();
        StringBuilder sbTAR = new StringBuilder();
        StringBuilder sbTR = new StringBuilder();
        StringBuilder sbTDR = new StringBuilder();

        static string Type_anafi;
        StringBuilder sbt = new StringBuilder();
        StringBuilder sbv = new StringBuilder();
        StringBuilder sbe = new StringBuilder();
        StringBuilder sba = new StringBuilder();
        static string code_banque = "";
        static string ent = "";
        static string analyseQualitati = "";
        static string Modeleanalyse = "";
        static string groupe = "";
        static string banque = "";
        static string agence = "";
        static string agenceUser = "";
        static string pays = "";
        static string fananciere = "";
        static string qualitative = "";
        static string MAnalyse = "";

        static string HTML = "";
        static string strHTML = "";
        static string strHTML2 = "";
        string modele = "";
        string NICalculee = "";
        private static string _idModele = "";
        Scoringws service = new Scoringws();
        private readonly Scoringws _service = new Scoringws();
        //private static string _idModele = "";
        string iddossierch = "";
        private static string nom_contrepartie = "";
        double[] TabLOTECART = new double[3];
        string[] TabEditeAnafi = new string[3];
        double[] TabLOTECART1 = new double[3];
        string compar = "";
        string compar1 = "";
        string ScoreQualit = "";
        string ScoreFinance = "";
        private static string co = "";
        private static string coo = "";
        private static string co2 = "";
        private static string coo2 = "";
        private static string co1 = "";
        private static string coo1 = "";
        PdfPTable tableAnotation = new PdfPTable(6);
        PdfPTable tableModeleSignature = new PdfPTable(2);
        //PdfPTable tableModeleStatut = new PdfPTable(6);
        PdfPTable tableModeleStatut = new PdfPTable(2);
        PdfPTable tableModeleRating = new PdfPTable(5);
        PdfPTable table2Modele6rating = new PdfPTable(6);
        PdfPTable tableModeleNotFinance = new PdfPTable(2);
        PdfPTable tableModeleNotQual = new PdfPTable(2);
        PdfPTable tableModeleNotGroup = new PdfPTable(3);
        PdfPTable tableModeleNotOperation = new PdfPTable(3);
        PdfPTable tableModeleNotPays = new PdfPTable(4);
        PdfPTable tablequalital = new PdfPTable(3);
        PdfPTable tableInfoEncours = new PdfPTable(6);
        PdfPTable tableoperation = new PdfPTable(3);
        PdfPTable table5 = new PdfPTable(4);
        PdfPTable table1 = new PdfPTable(2);
        PdfPTable table2 = new PdfPTable(2);
        PdfPTable table3 = new PdfPTable(2);
        PdfPTable table4 = new PdfPTable(2);
        PdfPTable debut = new PdfPTable(2);
        PdfPTable TABLEACTIFS = new PdfPTable(1);
        PdfPTable tableModeleNotQualTitre = new PdfPTable(1);
        PdfPTable cell1ModeleNotFinanceTitre = new PdfPTable(1);
        PdfPTable TABLEACTIFSBilan = new PdfPTable(1);
        PdfPTable TABLEPASSIFS = new PdfPTable(1);
        PdfPTable TABLEECART = new PdfPTable(1);
        PdfPTable TABLECharge = new PdfPTable(1);
        PdfPTable TABLEProduit = new PdfPTable(1);
        PdfPTable TABLEvide = new PdfPTable(1);
        PdfPTable TABLEGMS = new PdfPTable(1);
        PdfPTable TABLEGMS1 = new PdfPTable(1);
        PdfPTable TABLETS = new PdfPTable(1);
        PdfPTable TABLETDR = new PdfPTable(1);
        PdfPTable TABLETAR = new PdfPTable(1);
        PdfPTable TABLESTAT = new PdfPTable(1);
        PdfPTable TABLESTAT2 = new PdfPTable(1);
        PdfPTable TABLETR = new PdfPTable(1);
        PdfPTable TitleModeleNotation = new PdfPTable(1);
        PdfPTable TitleEncous = new PdfPTable(1);
        //PdfPTable TABLESTAT2 = new PdfPTable(1);
        PdfPTable TABLETRQUALIT = new PdfPTable(1);
        PdfPTable TABLETROPERATION = new PdfPTable(1);
        PdfPTable TABLEActCircul = new PdfPTable(6);
        PdfPTable TABLEActImmo = new PdfPTable(6);
        PdfPTable TABLEPassCapi = new PdfPTable(4);
        PdfPTable TABLEPasscircul = new PdfPTable(4);
        PdfPTable TABLECrCharge1 = new PdfPTable(4);
        PdfPTable TABLECrCharge2 = new PdfPTable(4);
        PdfPTable TABLECrProdruit1 = new PdfPTable(4);
        PdfPTable TABLECrProdruit2 = new PdfPTable(4);
        PdfPTable tablequalitalStructurelle = new PdfPTable(4);

        PdfPTable tableAnotationTitre = new PdfPTable(1);
        PdfPTable entete = new PdfPTable(1);
        PdfPTable Tableentete = new PdfPTable(1);
        string RSocial = "";
        string Adresse = "";
        string CPVille = "";
        string nom_user_editePRO = "";
        string Pays = "";
        string IPrincipal = "";
        string ISCenter = "";
        string Id_SCOR = "";
        string LBDateClotureLiasse = "";
        string LBDurreExoMoisLiasse = "";
        string LBTypeBilLiass = "";
        string LBNatureExoLiasse = "";
        string LBCertifCompteLiasse = "";
        string LBregimFiscalLiasse = "";
        string LBEffectifLiasse = "";
        string nom_user_edite = "";
        string nom_user_editeSup = "";
        string LblStatut = "";
        private static string bi1 = "";
        private static string cr1 = "";
        string userN = "";
        string dateRe = "";
        private static string bi1cr1 = "";
        string LblBanque = "";
        string LblAgence = "";
        string LblSClientele = "";
        string LblGroupe = "";
        string LblNAF2 = "";
        string LblAPE = "";
        string LblNAF = "";
        string LblUnite = "";
        string LblDevise = "";
        string LblChiffre = "";
        string lblTypeProspect = "";
        string LblBranche = "";
        string decision = "";
        string dateReOuvr = "";
        string notegroup = "";
        string ScorePro = "";
        string datePro = "";
        string dateval = "";
        string ScorePays = "";
        string ScoreVal = "";
        string AdireExpert = "";
        string connString = System.Configuration.ConfigurationManager.ConnectionStrings["ScoringDB_MultiBConnectionString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Request.QueryString["id"] != null)
            {
                if (Request.QueryString["id"].Trim() != "")
                {
                    //iddossierch = Request.QueryString["id"];
                    //afficherRatio();
                    //afficherAutreRatio();
                    //affichebilan();
                    //affichecompteresultat();
                    //afficheBilanGrandeMasse();
                    //afficheTableauSynthetique();
                    //afficheTDR();
                    //GetQuestionPack();
                    //ReinitReponse();
                }
                else
                {
                    //printReport();
                }
            }
            else
            {
                //printReport();
            }

        }

        protected void Page_Init(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null)
            {
                if (Request.QueryString["id"].Trim() != "")
                {
                    etatEdite();
                }
            }


        }

        public void etatEdite()
        {
            bi1cr1 = "";
            bi1 = "";
            cr1 = "";
            modele = "";
            string vol = "";
            string volAnfi = "";
            if (Request.QueryString["id"].Trim().Length > 3)
            {
                if (Request.QueryString["id"].Trim().Length > 5)
                {
                    if (Request.QueryString["id"].Trim().Substring(0, 5) == "ANAFI")
                    {
                        compar = Session["id_dossier"].ToString();
                        vol = "";
                        volAnfi = "ANAFI";
                        EtatsANAFI();
                    }
                    else
                    {
                        volAnfi = "";

                        vol = Request.QueryString["id"].Trim().Substring(0, 3);
                    }

                }
                else
                {
                    volAnfi = "";
                    vol = Request.QueryString["id"].Trim().Substring(0, 3);
                }

            }
            else
            {
                volAnfi = "";
                vol = Request.QueryString["id"].Trim();
            }
            if (volAnfi == "")
            {
                if (vol == "OUI")
                {
                    compar1 = Request.QueryString["id"].Trim().Substring(3, Convert.ToInt32(Request.QueryString["id"].Trim().Length - 3));
                    compar = Session["id_dossier"].ToString();
                }
                else
                {
                    compar = Session["id_dossier"].ToString();
                    compar1 = Request.QueryString["id"].Trim();
                }
            }
            AfficherInfoDossier();
            //if (Session["id_dossier"] == null) Response.Redirect("~/Scoring/Connexion.aspx");
            var idDossier = Session["id_dossier"].ToString();
            Session.Add("id_dossier", idDossier);
            string id_d = compar;

            var info = service.DetailsDossierContrepartie("", Session["id_scoring"].ToString());

            code_banque = info != null ? info.LastOrDefault().CODE_BANQUE.ToString().Trim() : ""; // ScorCryptage.Decrypt(Session["code_banque"].ToString());
            var bankInfo = service.AfficheLogoBank(code_banque);
            foreach (var banque in bankInfo)
            {

                if (banque.IMG_BANQUE != "" && banque.IMG_BANQUE != null)
                {
                    ent = banque.IMG_BANQUE.ToString().Trim();
                    //sb25.AppendLine(string.Format("<img src=\"../Images/Logo/{0}\"style=\"width: 100% ;height:100%; top:3%;\" />", banque.IMG_BANQUE.ToString().Trim()));
                }
            }

            //******************************************debut***********************************************

            //server folder path which is stored your PDF documents       
            string path = Server.MapPath("~/attachments");

            string scoring = Session["id_user"].ToString().Trim() + "_" + DateTime.Now.ToString("yyyyMMddHHmmss");
            //nom du fichier
            string enreg = path + "/DossierNotation_" + scoring + ".pdf";
            string nom = "DossierNotation_" + scoring;

            string filename = "DossierNotation_" + scoring + ".pdf";
            string imagepath = Server.MapPath("~/Images");

            //Create new PDF document
            Document document = new Document(PageSize.A4, 45f, 45f, 100f, 75f);

            //const int HorizontalMargin = 40;
            //const int VerticalMargin = 40;

            //Document document = new Document(PageSize.A4, HorizontalMargin, HorizontalMargin, VerticalMargin, VerticalMargin);
            //try
            //{
            //if (File.Exists(enreg))
            //{
            //    File.Delete(enreg);
            //    //PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(enreg, FileMode.Create));
            //}


            PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(enreg, FileMode.Create));
            int nbre = 0;



            entete.TotalWidth = 700f;
            //fix the absolute width of the table
            entete.LockedWidth = true;
            //entete.SpacingAfter = 30f;

            PdfPTable table = new PdfPTable(4);
            table.TotalWidth = 550f;
            //fix the absolute width of the table
            table.LockedWidth = true;
            float[] widths = new float[] { 6f, 2f, 2f, 2f };
            table.SetWidths(widths);
            table.HorizontalAlignment = 1;



            PdfPTable fichier = new PdfPTable(1);
            fichier.TotalWidth = 500f;
            fichier.HorizontalAlignment = 0;
            fichier.SpacingBefore = 15f;
            //fix the absolute width of the table
            fichier.LockedWidth = true;

            //leave a gap before and after the table
            table.SpacingBefore = 20f;
            table.SpacingAfter = 5f;

            int totalfonts = FontFactory.RegisterDirectory("C:\\WINDOWS\\Fonts");

            foreach (string fontname in FontFactory.RegisteredFonts)
            { }
            var palatino = FontFactory.GetFont("palatino linotype", BaseFont.CP1252, BaseFont.EMBEDDED, 9, Font.BOLD);
            var boldFont = FontFactory.GetFont("palatino linotype", BaseFont.CP1252, BaseFont.EMBEDDED, 12, Font.BOLD);
            var italicfont = FontFactory.GetFont("palatino linotype", BaseFont.CP1252, BaseFont.EMBEDDED, 9, Font.ITALIC);
            var boldFontTitle = FontFactory.GetFont("palatino linotype", BaseFont.CP1252, BaseFont.EMBEDDED, 14, Font.BOLD);
            var titleFont = FontFactory.GetFont("Segoe UI", 9, BaseColor.WHITE);

            Font boldFont2 = new Font(Font.FontFamily.TIMES_ROMAN, 9, Font.BOLD, BaseColor.BLACK);
            Font boldFont22 = new Font(Font.FontFamily.TIMES_ROMAN, 9, Font.BOLD, BaseColor.WHITE);
            Font normalFont2 = new Font(Font.FontFamily.TIMES_ROMAN, 9, Font.ITALIC, BaseColor.BLACK);
            //var id_scoring = ScorCryptage.Decrypt(Request.QueryString["id"]);

            //Session.Add("id_scoring", id_scoring);
            //var secBceao = service.searchActivite;
            //var secBranc = service.DetailsDossierContrepartie("", Session["id_scoring"].ToString());
            //var stat = service.DetailsDossierContrepartie("", Session["id_scoring"].ToString());
            //var secAct = service.DetailsDossierContrepartie("", Session["id_scoring"].ToString());
            //var secDevis = service.DetailsDossierContrepartie("", Session["id_scoring"].ToString());
            //var secunite = service.DetailsDossierContrepartie("", Session["id_scoring"].ToString());

            string id_dossier = "";

            foreach (var v in info)
            {
                nom_contrepartie = v.ETCIV_NOMREDUIT;
                RSocial = v.ETCIV_NOMREDUIT;
                Adresse = v.ETCIV_ADRESSE;
                CPVille = v.ETCIV_VILLE_RESIDENCE;
                Pays = v.PAYS;
                IPrincipal = v.ETCIV_MATRICULE;
                ISCenter = v.ID_SCORING;
                String ins = v.ID_SCORING.Substring(0, 3);
                Id_SCOR = v.ID_SCORING.Substring(0, 3);
                LblBranche = v.BRANCH_ACT_CODE;
                lblTypeProspect = v.TYPE_PROSPECT;

                if (v.TYPE_PROSPECT == "Prospect Ref") lblTypeProspect = "Prospect Reférencé";

                MAnalyse = AnalyseFinanciere.getModeleNotation(v.ID_DOSSIER);
                LblStatut = v.STATUT_LIBELLE;
                var banque_info = service.InfosBanqueByCode(v.CODE_BANQUE);
                LblBanque = banque_info.NOM_BANQUE + " (" + banque_info.SIGLE_BANQUE + ")";
                LblAgence = v.NOM_AGENCE;
                agence = v.NOM_AGENCE;
                LblSClientele = v.SEGMENT_CLIENT;
                if (v.GROUPE_DOSSIER != "") { LblGroupe = v.GROUPE_DOSSIER; }
                else { LblGroupe = "Aucun"; }
                LblNAF2 = v.SECTACT_LIBELLE;
                LblAPE = v.RCCM;
                LblNAF = v.ACTBCEAO_LIBELLE;
                LblUnite = v.UNITE;
                LblDevise = v.DEVISE;
                LblChiffre = Convert.ToString(string.Format(frCult, "{0:#,##0}", Convert.ToDecimal(v.CA)));
                id_dossier = v.ID_DOSSIER;
            }

            var infoLiass = service.DetailsDossierLiasseContrepartie(0, id_dossier.Trim(), null);
            foreach (var v in infoLiass)
            {
                LBDateClotureLiasse = "NC";
                if (v.DATE_CLOTURE != null) LBDateClotureLiasse = Convert.ToDateTime(v.DATE_CLOTURE).ToString("dd/MM/yyyy");
                LBDurreExoMoisLiasse = "NC";
                if (v.DUREE_EXERCICE_MOIS != null) LBDurreExoMoisLiasse = v.DUREE_EXERCICE_MOIS.ToString();
                LBTypeBilLiass = "NC";
                // if (v.TYPE_ANAFI_A != null) LBTypeBilLiass.Text = v.TYPE_ANAFI_A.ToString();
                if (v.TYPE_ANAFI_A != null)
                {
                    if (v.TYPE_ANAFI_A == "SMT") LBTypeBilLiass = "Systeme Minimal De Tresorerie";
                    if (v.TYPE_ANAFI_A == "SN") LBTypeBilLiass = "Bilan Normal";
                    if (v.TYPE_ANAFI_A == "SA") LBTypeBilLiass = "Bilan Allege";
                }
                LBNatureExoLiasse = "NC";
                if (v.NATURE_EXERCICE != null) LBNatureExoLiasse = v.NATURE_EXERCICE.ToString();
                LBCertifCompteLiasse = "NC";
                if (v.CERTIFICATION_COMPTES != null) LBCertifCompteLiasse = v.CERTIFICATION_COMPTES.ToString();
                LBEffectifLiasse = "NC";
                if (v.EFFECTIF != null) LBEffectifLiasse = v.EFFECTIF.ToString();
                LBregimFiscalLiasse = "NC";
                if (v.REGIME_FISCAL != null) LBregimFiscalLiasse = v.REGIME_FISCAL.ToString();
            }

            InfoSaisiAnalyse();

            if (volAnfi == "ANAFI")
            {
                writer.PageEvent = new PDFFooter();
                document.Open();
                titletableaux();
                if (bi1 != "")
                {
                    sbC = new StringBuilder();
                    sbB = new StringBuilder();

                    document.Add(TABLEACTIFSBilan);
                    document.Add(table4);
                    document.Add(TABLEActImmo);

                    document.NewPage();
                    document.Add(table4);
                    document.Add(TABLEActCircul);
                    document.NewPage();
                    //iTextSharp.text.html.simpleparser.HTMLWorker hw = new iTextSharp.text.html.simpleparser.HTMLWorker(document);
                    //hw.Parse(new StringReader(HTML));

                    //document.NewPage();
                    //document.Add(Chunk.NEXTPAGE);

                    document.Add(TABLEPASSIFS);

                    document.Add(table4);
                    document.Add(TABLEPassCapi);

                    document.NewPage();
                    document.Add(table4);
                    document.Add(TABLEPasscircul);
                    //iTextSharp.text.html.simpleparser.HTMLWorker hw1 = new iTextSharp.text.html.simpleparser.HTMLWorker(document);

                    //hw1.Parse(new StringReader(sbE.ToString()));

                    //document.NewPage();
                    //document.Add(Chunk.NEXTPAGE);

                    //document.Add(TABLEECART);
                    //iTextSharp.text.html.simpleparser.HTMLWorker hw2 = new iTextSharp.text.html.simpleparser.HTMLWorker(document);
                    //hw2.Parse(new StringReader(sbEcart.ToString()));
                    //document.NewPage();


                }
                if (cr1 != "")
                {
                    document.Add(TABLECharge);
                    document.Add(table4);
                    document.Add(TABLECrCharge1);

                    document.NewPage();
                    document.Add(table4);
                    document.Add(TABLECrCharge2);
                    document.NewPage();

                    document.Add(TABLEProduit);
                    document.Add(table4);
                    document.Add(TABLECrProdruit1);

                    document.NewPage();
                    document.Add(table4);
                    document.Add(TABLECrProdruit2);
                    //HTML = "";
                    // sbE = new StringBuilder();
                    // sbEcart = new StringBuilder();
                    ////document.NewPage();
                    // iTextSharp.text.html.simpleparser.HTMLWorker hw1 = new iTextSharp.text.html.simpleparser.HTMLWorker(document);

                    //document.Add(TABLECharge);
                    //hw1.Parse(new StringReader(sbC.ToString()));

                    ////document.NewPage();
                    ////document.Add(Chunk.NEXTPAGE);
                    //document.Add(TABLEProduit);
                    //hw1.Parse(new StringReader(sbB.ToString()));
                }

                if (bi1cr1 != "")
                {
                    document.Add(TABLEACTIFSBilan);
                    document.Add(table4);
                    document.Add(TABLEActImmo);

                    document.NewPage();
                    document.Add(table4);
                    document.Add(TABLEActCircul);
                    document.NewPage();
                    //iTextSharp.text.html.simpleparser.HTMLWorker hw = new iTextSharp.text.html.simpleparser.HTMLWorker(document);
                    //hw.Parse(new StringReader(HTML));

                    //document.NewPage();
                    //document.Add(Chunk.NEXTPAGE);

                    document.Add(TABLEPASSIFS);

                    document.Add(table4);
                    document.Add(TABLEPassCapi);

                    document.NewPage();
                    document.Add(table4);
                    document.Add(TABLEPasscircul);

                    document.NewPage();





                    document.Add(TABLECharge);
                    document.Add(table4);
                    document.Add(TABLECrCharge1);

                    document.NewPage();
                    document.Add(table4);
                    document.Add(TABLECrCharge2);
                    document.NewPage();

                    document.Add(TABLEProduit);
                    document.Add(table4);
                    document.Add(TABLECrProdruit1);

                    document.NewPage();
                    document.Add(table4);
                    document.Add(TABLECrProdruit2);
                    //document.Add(TABLEACTIFSBilan);
                    //iTextSharp.text.html.simpleparser.HTMLWorker hw = new iTextSharp.text.html.simpleparser.HTMLWorker(document);
                    //hw.Parse(new StringReader(HTML));

                    ////document.NewPage();
                    ////document.Add(Chunk.NEXTPAGE);

                    //document.Add(TABLEPASSIFS);
                    //iTextSharp.text.html.simpleparser.HTMLWorker hw1 = new iTextSharp.text.html.simpleparser.HTMLWorker(document);

                    //hw1.Parse(new StringReader(sbE.ToString()));

                    ////document.NewPage();
                    ////document.Add(Chunk.NEXTPAGE);

                    //document.Add(TABLEECART);
                    //iTextSharp.text.html.simpleparser.HTMLWorker hw2 = new iTextSharp.text.html.simpleparser.HTMLWorker(document);
                    //hw2.Parse(new StringReader(sbEcart.ToString()));
                    ////document.NewPage();

                    //document.Add(TABLECharge);
                    //hw1.Parse(new StringReader(sbC.ToString()));

                    ////document.NewPage();
                    ////document.Add(Chunk.NEXTPAGE);
                    //document.Add(TABLEProduit);
                    //hw1.Parse(new StringReader(sbB.ToString()));
                }

                document.Add(entete);
                document.Add(debut);

            }
            else
            {
                //les info à afficher
                InfoIdentPrincipal();
                InfoIdentifiants();
                InfoBancaire();
                InfoActivité();


                //anafi info
                BilanActifs();
                BilanPassifs();
                BilanEcarts();
                CompteResultatsCharge();
                CompteResultatsProduits();
                BGMAtifs();
                BGMPassifs();
                TS();
                TDR();
                TAR();
                Ratios();
                var bankInfo1 = service.AfficheLogoBank(code_banque);
                foreach (var banque in bankInfo1)
                {

                    if (banque.IMG_BANQUE != "" && banque.IMG_BANQUE != null)
                    {
                        ent = banque.IMG_BANQUE.ToString().Trim();
                    }
                }
                //les title des tableaux
                titletableaux();



                //tatbleaux des commentaire
                listCommentaire();
                // tatbleaux de signature
                //signature();
                // info sur analyse qualitatif
                QualitativeRepose();
                // info sur analyse qualitatif
                
                OperationReponse();

                OperationModelNotation();
                // les info surs la note d'analyse qualitatif
                InfoQualit();
                InfoGroup();
                InfoPays();
                // les info surs la note d'analyse financiere

                InfoAnafi();
                // les info sur le Statut
                Statut();

                // les info sur l'encours
                InfoEncours();
                // les info sur le Rating

                rating();
                // les info sur le Rating
                ratingInfo();

                writer.PageEvent = new PDFFooter();
                document.Open();

                document.Add(entete);
                document.Add(debut);
                document.Add(Tableentete);
                document.Add(table5);
                document.Add(table1);
                document.Add(table2);
                document.Add(table3);
                document.Add(table4);
                //document.Add(TABLESTAT);
                //document.Add(tableModeleStatut);
                document.NewPage();
                // infos statut   

                //document.Add(tableModeleRating);
                //document.Add(TABLESTAT2);
                //document.Add(table2Modele6rating);
                //document.NewPage();


                //document.Add(TABLEACTIFS);

                //document.NewPage();
                iTextSharp.text.html.simpleparser.HTMLWorker hw1 = new iTextSharp.text.html.simpleparser.HTMLWorker(document);
                var liste_annee = service.AnafiAfficheLiasse(7, compar, "", "SN");

                if (fananciere != "NC")
                {
                    if (vol.Trim() == "OUI")
                    {
                        //iTextSharp.text.html.simpleparser.HTMLWorker hw1 = new iTextSharp.text.html.simpleparser.HTMLWorker(document);
                        document.Add(TABLEACTIFSBilan);
                        iTextSharp.text.html.simpleparser.HTMLWorker hw = new iTextSharp.text.html.simpleparser.HTMLWorker(document);
                        hw.Parse(new StringReader(HTML));

                        //document.NewPage();
                        //document.Add(Chunk.NEXTPAGE);

                        document.Add(TABLEPASSIFS);

                        hw1.Parse(new StringReader(sbE.ToString()));

                        //document.NewPage();
                        //document.Add(Chunk.NEXTPAGE);

                        document.Add(TABLEECART);

                        hw1.Parse(new StringReader(sbEcart.ToString()));
                        //document.NewPage();

                        document.Add(TABLECharge);
                        hw1.Parse(new StringReader(sbC.ToString()));

                        //document.NewPage();
                        //document.Add(Chunk.NEXTPAGE);
                        document.Add(TABLEProduit);
                        hw1.Parse(new StringReader(sbB.ToString()));

                        //document.NewPage();
                        //document.Add(Chunk.NEXTPAGE);
                    }



                    document.Add(TABLEGMS);

                    hw1.Parse(new StringReader(sbBGM.ToString()));

                    //document.NewPage();
                    //document.Add(Chunk.NEXTPAGE);

                    document.Add(TABLEGMS1);
                    hw1.Parse(new StringReader(sbBGM1.ToString()));

                    //document.NewPage();
                    //document.Add(Chunk.NEXTPAGE);

                    document.Add(TABLETS);
                    hw1.Parse(new StringReader(sbTS.ToString()));

                    //document.NewPage();
                    //document.Add(Chunk.NEXTPAGE);

                    document.Add(TABLETDR);
                    hw1.Parse(new StringReader(sbTDR.ToString()));

                    //iTextSharp.text.html.simpleparser.HTMLWorker hw1 = new iTextSharp.text.html.simpleparser.HTMLWorker(document);


                    document.Add(TABLETR);
                    hw1.Parse(new StringReader(sbTR.ToString()));
                    document.Add(TABLEvide);
                    //document.Add(TABLETAR);
                    hw1.Parse(new StringReader(sbTAR.ToString()));

                    document.Add(TABLEvide); //mettre de space
                    //document.NewPage();
                    document.Add(tableModeleNotFinance);
                    //document.NewPage();
                }
                else
                {
                    //document.Add(TABLEvide);
                    document.Add(TABLETR);
                    //mettre de space
                    //document.NewPage();
                    document.Add(cell1ModeleNotFinanceTitre);
                    //document.Add(TABLEvide); //mettre de space
                    //document.NewPage();
                }




                if (modele.Trim() != "GROUP")
                {
                    if (qualitative.Trim() != "NC")
                    {
                        document.Add(TABLETRQUALIT);
                        document.Add(tablequalital);



                        document.Add(tableModeleNotQual);

                        document.Add(TABLETROPERATION);
                        document.Add(tableoperation);
                        //document.NewPage();
                        document.Add(TABLEvide);

                        document.Add(TitleEncous);
                        document.Add(tableInfoEncours);

                        document.NewPage();
                        document.Add(TitleModeleNotation); //mettre de space

                        document.Add(tableModeleNotGroup);
                        //document.NewPage();
                        document.Add(tableModeleNotOperation);
                        document.Add(TABLEvide);

                      

                        document.Add(tableModeleNotPays);
                        document.NewPage();
                        //document.Add(TABLEvide);
                        document.Add(tableAnotationTitre);
                    }
                    else
                    {
                        document.Add(TABLETRQUALIT);
                        document.Add(tableModeleNotQualTitre);
                        document.Add(TABLETROPERATION);
                        document.Add(tableModeleNotQualTitre);

                        document.Add(TitleEncous);
                        document.Add(tableInfoEncours);

                        //document.NewPage();
                        document.NewPage();
                        document.Add(TitleModeleNotation);

                        document.Add(tableModeleNotGroup);

                        

                        //document.NewPage();
                        document.Add(TABLEvide);
                        document.Add(tableModeleNotPays);
                        document.NewPage();
                        //document.Add(TABLEvide);
                        document.Add(tableAnotationTitre);
                    }

                }
                else
                {
                    //if (groupe.Trim() != "NC")
                    //{
                    document.Add(TABLETRQUALIT);
                    document.Add(tablequalitalStructurelle);
                    document.Add(TABLEvide);
                    document.Add(TABLETROPERATION);
                    document.Add(tablequalitalStructurelle);
                    //document.NewPage();
                    document.Add(TABLEvide); //mettre de space
                    document.Add(tableModeleNotQual);
                    document.Add(TABLEvide);
                    document.Add(tableModeleNotGroup);

                    document.Add(TitleEncous);
                    document.Add(tableInfoEncours);


                    //document.NewPage();
                    document.Add(TABLEvide);

                    document.Add(tableModeleNotPays);
                    //document.NewPage();
                    document.Add(TABLEvide);
                    document.Add(tableAnotationTitre);
                    //}
                    //else
                    //{
                    //document.Add(TABLEvide); //mettre de space
                    //document.Add(tableModeleNotQual);
                    //document.Add(TABLEvide);
                    //document.Add(tableModeleNotGroup);
                    ////document.NewPage();
                    //document.Add(TABLEvide);

                    //document.Add(tableModeleNotPays);
                    ////document.NewPage();
                    //document.Add(TABLEvide);
                    //document.Add(tableAnotationTitre);
                    //}

                }


                document.Add(tableAnotation);
                document.Add(TABLEvide); //mettre de space
                document.Add(table);
                document.Add(tableModeleSignature);
            }

            //}
            //catch (Exception ex)
            //{
            //}
            //finally
            //{
            document.Close();

            compar = "";



            string enregjkj = path + @"/DossierNotation_" + scoring + ".pdf";
            string ouvr = "/DossierNotation_" + scoring + ".pdf";

            ShowPdfWeb(ouvr);

            //Response.HeaderEncoding = System.Text.Encoding.UTF8;
            //Response.AppendHeader("Content-Disposition", "attachment; filename=" + enregjkj);
            //Response.TransmitFile(enregjkj);
            ////Response.TransmitFile(filename);

            //Response.End();
        }

        public class PDFFooter : PdfPageEventHelper
        {
            // This is the contentbyte object of the writer
            PdfContentByte cb;
            // we will put the final number of pages in a template
            PdfTemplate template;
            // this is the BaseFont we are going to use for the header / footer
            BaseFont bf = null;
            // This keeps track of the creation time
            DateTime PrintTime = DateTime.Now;
            // write on top of document
            public override void OnOpenDocument(PdfWriter writer, Document document)
            {
                base.OnOpenDocument(writer, document);
                //PdfPTable tabFot = new PdfPTable(new float[] { 1F });
                //PdfPCell cell;
                //tabFot.TotalWidth = 700F;

                try
                {
                    PrintTime = DateTime.Now;
                    bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                    cb = writer.DirectContent;
                    template = cb.CreateTemplate(50, 50);
                }
                catch (DocumentException de)
                {
                }
                catch (System.IO.IOException ioe)
                {
                }

                PdfPTable tabletabFot = new PdfPTable(2);
                tabletabFot.TotalWidth = 550f;
                //fix the absolute width of the table
                tabletabFot.LockedWidth = true;


                PdfPCell cell1;
                //lundicell.Colspan = 2;
                //lundicell.HorizontalAlignment = 1;
                //lundicell.UseVariableBorders = true;
                //lundicell.BorderWidth = 0;
                //lundicell.PaddingBottom = 5f;
                //Footer Image 
                //string ent = sb25.ToString();
                //List<IElement> ent1 = HTMLWorker.ParseToList(new StringReader(ent), null);

                PdfPCell cell = new PdfPCell();
                //cell.PaddingLeft = 3f;
                //cell.UseVariableBorders = true;
                //cell.BorderWidth = 0;

                //foreach (IElement element in ent1)
                //{
                //    cell.AddElement(element);
                //}

                //tabletabFot.AddCell(cell);



            }
            // write on start of each page
            public override void OnStartPage(PdfWriter writer, Document document)
            {
                base.OnStartPage(writer, document);
                PdfPTable tabFot = new PdfPTable(new float[] { 1F });
                PdfPCell cell;
                tabFot.TotalWidth = 700F;

                //Footer Image 
                //iTextSharp.text.Image imgheader = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath("~/Images/entetepdf.gif"));
                //imgheader.ScalePercent(48f);
                //cell = new PdfPCell(imgheader);
                //cell.UseVariableBorders = true;
                //cell.BorderWidth = 0;
                //tabFot.AddCell(cell);
                //tabFot.WriteSelectedRows(0, -1, 1, 840, writer.DirectContent);

                PdfPTable tabletabFot = new PdfPTable(2);
                tabletabFot.TotalWidth = 550f;
                //fix the absolute width of the table
                tabletabFot.LockedWidth = true;


                PdfPCell cell1;
                //lundicell.Colspan = 2;
                //lundicell.HorizontalAlignment = 1;
                //lundicell.UseVariableBorders = true;
                //lundicell.BorderWidth = 0;
                //lundicell.PaddingBottom = 5f;
                //Footer Image 
                //string ent = sb25.ToString();
                //List<IElement> ent1 = HTMLWorker.ParseToList(new StringReader(ent), null);

                PdfPCell cell123 = new PdfPCell();

                iTextSharp.text.Image imgheader = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath("~/Images/Logo/" + ent));
                //imgheader.ScalePercent(48f);
                imgheader.ScaleAbsolute(70f, 50f);

                cell123 = new PdfPCell(imgheader);
                //cell123.PaddingLeft = 5f;
                cell123.UseVariableBorders = true;
                cell123.BorderWidth = 0;
                cell123.PaddingLeft = 40;
                //cell123.Image.ScaleToFit(750f, 750f);
                //cell123.Image.ScaleToFit(70f,50);
                //cell123.HorizontalAlignment = 0;
                //cell123.HorizontalAlignment =1;
                cell123.PaddingTop = 10f;
                cell123.PaddingBottom = 2f;
                //cell123.BorderWidthBottom = 1;
                //cell123.BorderWidthLeft = 0;
                //cell123.BorderWidthTop = 0;
                //cell123.BorderWidthRight = 0;
                tabletabFot.AddCell(cell123);



                iTextSharp.text.Image imgheader2 = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath("~/Images/favicon.ico"));
                //imgheader2.ScalePercent(48f);
                imgheader2.ScaleAbsolute(40f, 40f);
                cell1 = new PdfPCell(imgheader2);
                cell1.UseVariableBorders = true;
                cell1.BorderWidth = 0;
                cell1.HorizontalAlignment = 2;
                cell1.PaddingTop = 10f;
                cell123.PaddingBottom = 2f;
                //cell1.BorderWidthBottom = 1;
                //cell1.BorderWidthLeft = 0;
                //cell1.BorderWidthTop = 0;
                //cell1.BorderWidthRight = 0;
                tabletabFot.AddCell(cell1);

                tabletabFot.WriteSelectedRows(0, -1, 1, 840, writer.DirectContent);
            }
            // write on end of each page
            //public override void OnEndPage(PdfWriter writer, Document document)
            //{
            //    base.OnEndPage(writer, document);
            //    PdfPTable tabFot = new PdfPTable(new float[] { 1F });
            //    PdfPCell cell;
            //    tabFot.TotalWidth = 700F;
            //    iTextSharp.text.Image imgfooter = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath("~/Images/footer.png"));
            //    imgfooter.ScalePercent(50f);
            //    cell = new PdfPCell(imgfooter);
            //    cell.UseVariableBorders = true;
            //    cell.BorderWidthLeft = 0;
            //    cell.BorderWidthRight = 0;
            //    cell.BorderWidthBottom = 0;
            //    cell.BorderWidthTop = 1;
            //    tabFot.AddCell(cell);
            //    tabFot.SpacingAfter = 10f;
            //    tabFot.SpacingAfter = 20f;
            //    tabFot.WriteSelectedRows(0, -1, 0, 90, writer.DirectContent);
            //}

            public override void OnEndPage(PdfWriter writer, Document document)
            {
                base.OnEndPage(writer, document);
                int pageN = writer.PageNumber;
                String text = "Page " + pageN;
                float len = bf.GetWidthPoint(text, 8);
                Rectangle pageSize = document.PageSize;
                cb.SetRGBColorFill(100, 100, 100);

                cb.BeginText();
                cb.SetFontAndSize(bf, 8);
                if (bi1 != "")
                {
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT,
               "Bilan système normal de « " + nom_contrepartie.Trim() + "»", pageSize.GetLeft(40),
               pageSize.GetBottom(30), 0);
                }
                else
                {
                    if (cr1 != "")
                    {
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT,
                   "Compte de resultat système normal de« " + nom_contrepartie.Trim() + "»",
                     pageSize.GetLeft(40),
                   pageSize.GetBottom(30), 0);
                    }
                    else
                    {
                        if (bi1cr1 != "")
                        {
                            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT,
                       "Analyse Financière de « " + nom_contrepartie.Trim() + "»",
                         pageSize.GetLeft(40),
                       pageSize.GetBottom(30), 0);
                        }
                        else
                        {
                            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT,
                       "Dossier de Notation de « " + nom_contrepartie.Trim() + "»",
                         pageSize.GetLeft(40),
                       pageSize.GetBottom(30), 0);

                        }
                    }
                }


                cb.EndText();

                cb.BeginText();
                cb.SetFontAndSize(bf, 8);
                cb.SetTextMatrix(pageSize.GetLeft(40), pageSize.GetBottom(30));
                cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, text,
                pageSize.GetLeft(300),
                pageSize.GetBottom(30), 0);
                cb.EndText();
                cb.AddTemplate(template, pageSize.GetLeft(300) + len, pageSize.GetBottom(30));

                cb.BeginText();
                cb.SetFontAndSize(bf, 8);
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT,
                "Imprimé le " + PrintTime.ToString(),
                pageSize.GetRight(40),
                pageSize.GetBottom(30), 0);
                cb.EndText();
            }

            //write on close of document
            public override void OnCloseDocument(PdfWriter writer, Document document)
            {
                base.OnCloseDocument(writer, document);
            }

        }

        public void ShowPdfWeb(string filename)
        {
            string path = Server.MapPath("attachments");
            //Clears all content output from Buffer Stream
            Response.ClearContent();
            //Clears all headers from Buffer Stream
            Response.ClearHeaders();
            //Adds an HTTP header to the output stream
            Response.ContentType = "application/octet-stream";
            //Response.AddHeader("Content-Disposition", "filename=" + filename + ".pdf");
            Response.AddHeader("Content-Disposition", "attachment;filename=" + filename);
            //Gets or Sets the HTTP MIME type of the output stream
            Response.ContentType = "application/pdf";
            //Writes the content of the specified file directory to an HTTP response output stream as a file block
            Response.WriteFile(path + "/" + filename);
            //sends all currently buffered output to the client
            Response.Flush();
            //Clears all content output from Buffer Stream
            Response.Clear();

        }
        public void AfficherInfoDossier()
        {
            AdireExpert = "";
            var listesET = service.ListeHistorique(Request.QueryString["id"], Session["id_scoring"].ToString());
            if (listesET.Count != 0)
            {
                var noteval = "";

                foreach (var v in listesET)
                {



                    if (v.ID_DOSSIER.Trim() == compar1.Trim())
                    {
                        //if (v.DATE_DOSSIER != null && v.DATE_DOSSIER != default(DateTime))
                        //{

                        //    dateReOuvr = v.DATE_DOSSIER.Date.Day.ToString() + "/" + v.DATE_DOSSIER.Date.Month.ToString() + "/" + v.DATE_DOSSIER.Date.Year.ToString();
                        //}
                        if (v.NOTE_VAL != null && v.NOTE_VAL.Trim() != "")
                        {
                            noteval = v.NOTE_VAL.ToString();
                            if (v.DATE_VAL != null) dateRe = v.DATE_VAL.Date.Day.ToString() + "/" + v.DATE_VAL.Date.Month.ToString() + "/" + v.DATE_VAL.Date.Year.ToString();
                        }

                        if (v.NOTE_AF != null && v.NOTE_AF.Trim() != "")
                        {
                            fananciere = v.NOTE_AF.ToString();
                            //if (v.DATE_NOTE_MODIF != null) datefi = v.DATE_NOTE_MODIF.Value.Date.Day.ToString() + "/" + v.DATE_NOTE_MODIF.Value.Date.Month.ToString() + "/" + v.DATE_NOTE_MODIF.Value.Date.Year.ToString();

                        }
                        else
                        {
                            fananciere = "NC";
                        }
                        if (v.NOTE_AQ != null && v.NOTE_AQ.Trim() != "")
                        {
                            qualitative = v.NOTE_AQ.ToString();
                            //if (v.DATE_NOTE != null) dateqa = v.DATE_NOTE.Value.Date.Day.ToString() + "/" + v.DATE_NOTE.Value.Date.Month.ToString() + "/" + v.DATE_NOTE.Value.Date.Year.ToString();
                        }
                        else
                        {
                            qualitative = "NC";
                        }

                        if (fananciere == "NC" && qualitative == "NC")
                        {

                            //dateReOuvr = v.DATE_DOSSIER.Date.Day.ToString() + "/" + v.DATE_DOSSIER.Date.Month.ToString() + "/" + v.DATE_DOSSIER.Date.Year.ToString();
                            dateReOuvr = "";
                        }
                        else
                        {
                            if (fananciere != "NC")
                            {
                                if (qualitative != "NC")
                                {
                                    if (v.DATE_NOTE_MODIF <= v.DATE_NOTE)
                                    {
                                        dateReOuvr = v.DATE_NOTE_MODIF.Value.Date.Day.ToString() + "/" + v.DATE_NOTE_MODIF.Value.Date.Month.ToString() + "/" + v.DATE_NOTE_MODIF.Value.Date.Year.ToString();
                                    }
                                    else
                                    {
                                        dateReOuvr = v.DATE_NOTE.Value.Date.Day.ToString() + "/" + v.DATE_NOTE.Value.Date.Month.ToString() + "/" + v.DATE_NOTE.Value.Date.Year.ToString();
                                    }
                                }
                                else
                                {
                                    dateReOuvr = v.DATE_NOTE_MODIF.Value.Date.Day.ToString() + "/" + v.DATE_NOTE_MODIF.Value.Date.Month.ToString() + "/" + v.DATE_NOTE_MODIF.Value.Date.Year.ToString();
                                }
                            }
                            else
                            {
                                dateReOuvr = v.DATE_NOTE.Value.Date.Day.ToString() + "/" + v.DATE_NOTE.Value.Date.Month.ToString() + "/" + v.DATE_NOTE.Value.Date.Year.ToString();
                            }
                        }

                        if (v.NOTE_PROP != null && v.NOTE_PROP.Trim() != "")
                        {
                            //notepropos = v.NOTE_PROP.ToString();

                            var User_Propose = service.ListeCommentaire(6, v.ID_USER, "", "", "", "", "", DateTime.UtcNow);
                            if (User_Propose.Count > 0) { 
                                nom_user_editePRO = User_Propose[0].NOM_USER + " " + User_Propose[0].PRENOM_USER;
                                agenceUser = User_Propose[0].NOM_AGENCE;
                            }
                            

                        //    nom_user_editePRO = service.ListeCommentaire(6, v.ID_USER, "", "", "", "", "", DateTime.UtcNow)
                        //.Where(nUser => nUser.NOM_USER != "").SingleOrDefault().NOM_USER;

                            if (v.DATE_PROP != null) datePro = v.DATE_PROP.Date.Day.ToString() + "/" + v.DATE_PROP.Date.Month.ToString() + "/" + v.DATE_PROP.Date.Year.ToString();
                        }
                        if (v.NOTE_VAL.Trim() != "")
                        {
                            var listesUser = service.ListeHistoriqueUserName(v.ID_DOSSIER.Trim());

                            if (listesUser.Count != 0)
                            {
                                foreach (var U in listesUser)
                                {
                                    string PARENT_SUPP = service.ListeCommentaire(6, U.ID_USER, "", "", "", "", "", DateTime.UtcNow).SingleOrDefault().PARENT_SUPP;

                                    if (string.IsNullOrEmpty(PARENT_SUPP))
                                    {
                                        nom_user_editeSup = "";

                                    }
                                    else
                                    {
                                        nom_user_editeSup = service.ListeCommentaire(6, PARENT_SUPP, "", "", "", "", "", DateTime.UtcNow)
                         .Where(nUser => nUser.NOM_USER != "").SingleOrDefault().NOM_USER;
                                    }

                                    //nom_user_edite = U.NOM_USER
                                    nom_user_edite = U.NOM_USER +" " + U.PRENOM_USER; // 21/11/2019 Blaise BDU
                                }

                            }
                        }

                        if (noteval.ToString().Trim() == "")
                        {
                            if (v.DECISION_PROP != null && v.DECISION_PROP != "")
                            {
                                decision = "rejeté";
                                if (v.FICHIER_VAL != null && v.FICHIER_VAL.Trim() != "")
                                {
                                    AdireExpert = v.FICHIER_VAL.ToString();
                                }
                            }
                            else
                            {
                                decision = "En cours";



                                //Blaise 05/12/2019
                                int i = 0;

                                if (v.NOTE_AF == null || v.NOTE_AF.Trim() == "")
                                {

                                    i = 1;
                                }
                                else
                                {
                                    i = 0;
                                }

                                if (v.NOTE_AQ == null || v.NOTE_AQ.Trim() == "")
                                {
                                  
                                    i = 2;
                                }
                               



                                if (i == 1)
                                {
                                    if (string.IsNullOrEmpty(v.NOTE_OP) || v.NOTE_SYN.Trim() == "")
                                    {
                                        AdireExpert = "";
                                    }
                                    else
                                    {
                                        AdireExpert = "A dire d'expert";
                                    }
                                }
                    
                               



                                


                            }
                        }
                        else
                        {
                            decision = "Validé";
                            if (v.FICHIER_VAL != null && v.FICHIER_VAL.Trim() != "")
                            {
                                AdireExpert = v.FICHIER_VAL.ToString();
                            }
                        }
                    }


                }
            }
            var id_dossier = compar1;
            // var id_scoring = Session["id_scoring"].ToString();
            //Session.Add("id_dossier", id_dossier);
            // Session.Add("id_scoring", id_scoring);

            var DetailNotes = service.DetailsNotesDossier(id_dossier);
            var AfficherCommProposer = service.AfficherCommProposer(id_dossier);
            var DetailNotesscorQual = service.DetailsNotesDossierPoint(6, id_dossier);
            var DetailNotesscorFinan = service.DetailsNotesDossierPoint(7, id_dossier);
            int iii = 1;
            if (DetailNotesscorQual.Count != 0)
            {
                foreach (var NotesFinan in DetailNotesscorQual)
                {
                    if (iii == 2)
                    {
                        ScoreQualit = NotesFinan.SAVE_VALEUR.ToString();
                    }
                    if (iii == 4)
                    {
                        ScorePays = NotesFinan.SAVE_VALEUR.ToString();
                    }
                    iii++;
                }
            }
            if (DetailNotesscorFinan.Count != 0)
            {
                foreach (var NotesFinan in DetailNotesscorFinan)
                {
                    ScoreFinance = NotesFinan.SAVE_VALEURAF.ToString();
                }
            }
            if (AfficherCommProposer.Count != 0)
            {
                foreach (var Notes in AfficherCommProposer)
                {
                    //TbNPropose.Text = Notes.COMMENTAIRE_PROP;
                    //TbNValidRejet.Text = Notes.COMMENTAIRE_PROP;
                }
            }

            if (DetailNotes.Count != 0)
            {
                foreach (var Notes in DetailNotes)
                {
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

                    if (Notes.NOTE_VAL.Trim() == "" || Notes.NOTE_VAL.Trim() == null)
                    {
                        ScoreVal = "NC";
                    }
                    else
                    {
                        ScoreVal = Notes.NOTE_VAL;
                    }

                    if (Notes.NOTE_PROP.Trim() == "" || Notes.NOTE_PROP.Trim() == null)
                    {
                        ScorePro = "NC";
                    }
                    else
                    {
                        ScorePro = Notes.NOTE_PROP;
                        //datePro = Notes.DATE_PROP.Date.Day.ToString() + "/" + Notes.DATE_PROP.Date.Month.ToString() + "/" + Notes.DATE_PROP.Date.Year.ToString();
                    }





                    if (i == 0)
                    {

                        NICalculee = Notes.NOTE_SYN;
                        //remplirCon(NICalculee.Text.Trim());
                    }
                    else
                    {
                        NICalculee = "NC";
                        //remplirCon("");
                    }


                }
            }

        }
        public void listCommentaire()
        {
            Font boldFont2 = new Font(Font.FontFamily.TIMES_ROMAN, 9, Font.BOLD, BaseColor.BLACK);
            Font boldFont22 = new Font(Font.FontFamily.TIMES_ROMAN, 9, Font.BOLD, BaseColor.WHITE);
            Font normalFont2 = new Font(Font.FontFamily.TIMES_ROMAN, 9, Font.ITALIC, BaseColor.BLACK);

            tableAnotation.TotalWidth = 500f;
            tableAnotation.PaddingTop = 5f;
            tableAnotation.LockedWidth = true;
            float[] widthstableAnotation = new float[] { 1f, 3f, 1.5f, 3f, 2f, 1.5f };
            tableAnotation.SetWidths(widthstableAnotation);
            tableAnotation.HorizontalAlignment = 1;


            //if (Session["id_scoring"] == null) Response.Redirect("~/Scoring/Connexion.aspx");
            var id_scoring = Session["id_scoring"].ToString();
            string id_dossier = compar1;
            Session.Add("id_scoring", id_scoring);

            var listcommentaire = service.ListeCommentaire(0, "", id_dossier, id_scoring, "", "", "", DateTime.Now);

            if (listcommentaire.Count != 0)
            {
                var id_user = Session["id_user"].ToString();
                foreach (var rel in listcommentaire)
                {
                    string  nom_User="";
                    //string nom_User = service.ListeCommentaire(6, rel.ID_USER, "", "", "", "", "", DateTime.UtcNow)
                    //   .Where(nUser => nUser.NOM_USER != "").SingleOrDefault().NOM_USER;

                    var User_ = service.ListeCommentaire(6, rel.ID_USER, "", "", "", "", "", DateTime.UtcNow);
                    if (User_.Count > 0) { 
                        nom_User = User_[0].NOM_USER + " " + User_[0].PRENOM_USER;
                        agenceUser = User_[0].NOM_AGENCE;
                    }

                    PdfPCell cell1Anotation = new PdfPCell(new Phrase("Bureau", boldFont2));
                    cell1Anotation.PaddingLeft = 5f;
                    cell1Anotation.HorizontalAlignment = 0;
                    cell1Anotation.UseVariableBorders = true;
                    cell1Anotation.BorderWidthBottom = 1;
                    cell1Anotation.BorderWidthLeft = 0;
                    cell1Anotation.BorderWidthTop = 1;
                    cell1Anotation.BorderWidthRight = 0;
                    cell1Anotation.BackgroundColor = new BaseColor(228, 235, 245);
                    cell1Anotation.BorderColor = new BaseColor(208, 211, 212);
                    cell1Anotation.PaddingBottom = 5f;
                    tableAnotation.AddCell(cell1Anotation);

                    //PdfPCell cell2Anotation = new PdfPCell(new Phrase(agence, normalFont2));
                    PdfPCell cell2Anotation = new PdfPCell(new Phrase(agenceUser, normalFont2)); //21/11/2019 blaise
                    cell2Anotation.PaddingLeft = 5f;
                    cell2Anotation.HorizontalAlignment = 0;
                    cell2Anotation.UseVariableBorders = true;
                    cell2Anotation.BorderWidthBottom = 1;
                    cell2Anotation.BorderWidthLeft = 0;
                    cell2Anotation.BorderWidthTop = 1;
                    cell2Anotation.BorderWidthRight = 0;
                    cell2Anotation.BackgroundColor = new BaseColor(228, 235, 245);
                    cell2Anotation.BorderColor = new BaseColor(208, 211, 212);
                    cell2Anotation.PaddingBottom = 5f;
                    tableAnotation.AddCell(cell2Anotation);


                    PdfPCell cell3Anotation = new PdfPCell(new Phrase("Utilisateur", boldFont2));
                    cell3Anotation.PaddingLeft = 5f;
                    cell3Anotation.HorizontalAlignment = 0;
                    cell3Anotation.UseVariableBorders = true;
                    cell3Anotation.BorderWidthBottom = 1;
                    cell3Anotation.BorderWidthLeft = 0;
                    cell3Anotation.BorderWidthTop = 1;
                    cell3Anotation.BorderWidthRight = 0;
                    cell3Anotation.BackgroundColor = new BaseColor(228, 235, 245);
                    cell3Anotation.BorderColor = new BaseColor(208, 211, 212);
                    cell3Anotation.PaddingBottom = 5f;
                    tableAnotation.AddCell(cell3Anotation);

                    PdfPCell cell4Anotation = new PdfPCell(new Phrase(nom_User, normalFont2));
                    cell4Anotation.PaddingLeft = 5f;
                    cell4Anotation.HorizontalAlignment = 0;
                    cell4Anotation.UseVariableBorders = true;
                    cell4Anotation.BorderWidthBottom = 1;
                    cell4Anotation.BorderWidthLeft = 0;
                    cell4Anotation.BorderWidthTop = 1;
                    cell4Anotation.BorderWidthRight = 0;
                    cell4Anotation.BackgroundColor = new BaseColor(228, 235, 245);
                    cell4Anotation.BorderColor = new BaseColor(208, 211, 212);
                    cell4Anotation.PaddingBottom = 5f;
                    tableAnotation.AddCell(cell4Anotation);


                    PdfPCell cell5Anotation = new PdfPCell(new Phrase("Date de soumission", boldFont2));
                    cell5Anotation.PaddingLeft = 5f;
                    cell5Anotation.HorizontalAlignment = 0;
                    cell5Anotation.UseVariableBorders = true;
                    cell5Anotation.BorderWidthBottom = 1;
                    cell5Anotation.BorderWidthLeft = 0;
                    cell5Anotation.BorderWidthTop = 1;
                    cell5Anotation.BorderWidthRight = 0;
                    cell5Anotation.BackgroundColor = new BaseColor(228, 235, 245);
                    cell5Anotation.BorderColor = new BaseColor(208, 211, 212);
                    cell5Anotation.PaddingBottom = 5f;
                    tableAnotation.AddCell(cell5Anotation);

                    string dateSou = rel.DATE_COMMENTAIRE.ToString("dd/MM/yyyy");

                    PdfPCell cell6Anotation = new PdfPCell(new Phrase(dateSou, normalFont2));
                    cell6Anotation.PaddingLeft = 5f;
                    cell6Anotation.HorizontalAlignment = 0;
                    cell6Anotation.UseVariableBorders = true;
                    cell6Anotation.BorderWidthBottom = 1;
                    cell6Anotation.BorderWidthLeft = 0;
                    cell6Anotation.BorderWidthTop = 1;
                    cell6Anotation.BorderWidthRight = 0;
                    cell6Anotation.BackgroundColor = new BaseColor(228, 235, 245);
                    cell6Anotation.BorderColor = new BaseColor(208, 211, 212);
                    cell6Anotation.PaddingBottom = 5f;
                    tableAnotation.AddCell(cell6Anotation);


                    PdfPCell cell7Anotation = new PdfPCell(new Phrase(rel.TEXTE_COMMENTAIRE, normalFont2));
                    cell7Anotation.Colspan = 6;
                    cell7Anotation.PaddingLeft = 10f;
                    cell7Anotation.UseVariableBorders = true;
                    cell7Anotation.PaddingTop = 2f;
                    cell7Anotation.PaddingBottom = 5f;
                    cell7Anotation.HorizontalAlignment = 0;
                    cell7Anotation.BorderWidthBottom = 0;
                    cell7Anotation.BorderWidthLeft = 1;
                    cell7Anotation.BorderWidthTop = 0;
                    cell7Anotation.BorderWidthRight = 1;
                    cell7Anotation.BorderColor = new BaseColor(208, 211, 212);
                    cell7Anotation.Bottom = 3f;
                    tableAnotation.AddCell(cell7Anotation);
                    if (rel.FICHIER_COMMENTAIRE != "")
                    {
                        PdfPCell cell8Anotation = new PdfPCell(new Phrase("Nom du fichier joint :", boldFont2));
                        cell8Anotation.Colspan = 4;
                        cell8Anotation.PaddingLeft = 3f;
                        cell8Anotation.UseVariableBorders = true;
                        cell8Anotation.PaddingTop = 2f;
                        cell8Anotation.PaddingBottom = 5f;
                        cell8Anotation.HorizontalAlignment = 2;
                        cell8Anotation.BorderWidthBottom = 1;
                        cell8Anotation.BorderWidthLeft = 1;
                        cell8Anotation.BorderWidthTop = 0;
                        cell8Anotation.BorderColor = new BaseColor(208, 211, 212);
                        cell8Anotation.BorderWidthRight = 0;
                        cell8Anotation.Bottom = 3f;
                        tableAnotation.AddCell(cell8Anotation);


                        PdfPCell cell9Anotation = new PdfPCell(new Phrase(rel.FICHIER_COMMENTAIRE.ToString().Trim(), normalFont2));
                        cell9Anotation.Colspan = 2;
                        cell9Anotation.PaddingLeft = 3f;
                        cell9Anotation.PaddingRight = 3f;
                        cell9Anotation.UseVariableBorders = true;
                        cell9Anotation.PaddingTop = 2f;
                        cell9Anotation.PaddingBottom = 5f;
                        cell9Anotation.HorizontalAlignment = 0;
                        cell9Anotation.BorderWidthBottom = 1;
                        cell9Anotation.BorderWidthLeft = 0;
                        cell9Anotation.BorderWidthTop = 0;
                        cell9Anotation.BorderColor = new BaseColor(208, 211, 212);
                        cell9Anotation.BorderWidthRight = 1;
                        cell9Anotation.Bottom = 3f;
                        tableAnotation.AddCell(cell9Anotation);

                    }
                    else
                    {
                        PdfPCell cell10Anotation = new PdfPCell(new Phrase("Aucun fichier joint", boldFont2));
                        cell10Anotation.Colspan = 6;
                        cell10Anotation.PaddingLeft = 3f;
                        cell10Anotation.PaddingRight = 5f;
                        cell10Anotation.UseVariableBorders = true;
                        cell10Anotation.PaddingTop = 2f;
                        cell10Anotation.PaddingBottom = 5f;
                        cell10Anotation.HorizontalAlignment = 2;
                        cell10Anotation.BorderWidthBottom = 1;
                        cell10Anotation.BorderWidthLeft = 1;
                        cell10Anotation.BorderWidthTop = 0;
                        cell10Anotation.BorderColor = new BaseColor(208, 211, 212);
                        cell10Anotation.BorderWidthRight = 1;
                        cell10Anotation.Bottom = 3f;
                        tableAnotation.AddCell(cell10Anotation);
                        //sb.AppendLine(string.Format("<b>Aucun fichier associé</b>"));
                    }

                    PdfPCell cell13Anotation = new PdfPCell(new Phrase("vide", boldFont22));
                    cell13Anotation.Colspan = 6;
                    cell13Anotation.HorizontalAlignment = 1;
                    cell13Anotation.UseVariableBorders = true;
                    cell13Anotation.BorderWidth = 1;
                    cell13Anotation.BackgroundColor = new BaseColor(255, 255, 255);
                    cell13Anotation.BorderColor = new BaseColor(255, 255, 255);
                    cell13Anotation.PaddingBottom = 5f;
                    tableAnotation.AddCell(cell13Anotation);



                }
            }
            else
            {
                PdfPCell cell17Anotation = new PdfPCell(new Phrase("Pas de commentaires", boldFont2));
                cell17Anotation.Colspan = 6;
                cell17Anotation.PaddingLeft = 5f;
                cell17Anotation.HorizontalAlignment = 1;
                cell17Anotation.UseVariableBorders = true;
                cell17Anotation.BorderWidthBottom = 1;
                cell17Anotation.BorderWidthLeft = 1;
                cell17Anotation.BorderWidthTop = 1;
                cell17Anotation.BorderWidthRight = 1;
                cell17Anotation.BackgroundColor = new BaseColor(228, 235, 245);
                cell17Anotation.BorderColor = new BaseColor(208, 211, 212);
                cell17Anotation.PaddingBottom = 5f;
                tableAnotation.AddCell(cell17Anotation);

                PdfPCell cell14Anotation = new PdfPCell(new Phrase("1", boldFont22));
                cell14Anotation.Colspan = 6;
                cell14Anotation.PaddingLeft = 3f;
                cell14Anotation.PaddingRight = 5f;
                cell14Anotation.UseVariableBorders = true;
                cell14Anotation.PaddingTop = 2f;
                cell14Anotation.PaddingBottom = 30f;
                cell14Anotation.HorizontalAlignment = 1;
                cell14Anotation.BorderWidthBottom = 1;
                cell14Anotation.BorderWidthLeft = 1;
                cell14Anotation.BorderWidthTop = 0;
                cell14Anotation.BorderColor = new BaseColor(208, 211, 212);
                cell14Anotation.BorderWidthRight = 1;
                cell14Anotation.Bottom = 3f;
                tableAnotation.AddCell(cell14Anotation);
            }
        }
        public void signature()
        {
            Font boldFont2 = new Font(Font.FontFamily.TIMES_ROMAN, 9, Font.BOLD, BaseColor.BLACK);
            Font boldFont22 = new Font(Font.FontFamily.TIMES_ROMAN, 9, Font.BOLD, BaseColor.WHITE);
            Font normalFont2 = new Font(Font.FontFamily.TIMES_ROMAN, 9, Font.ITALIC, BaseColor.BLACK);

            tableModeleSignature.TotalWidth = 500f;
            tableModeleSignature.PaddingTop = 5f;
            //fix the absolute width of the table
            tableModeleSignature.LockedWidth = true;
            //relative col widths in proportions - 1/3 and 2/3
            float[] widthstablequalital2 = new float[] { 5f, 7f };
            tableModeleSignature.SetWidths(widthstablequalital2);
            tableModeleSignature.HorizontalAlignment = 1;

            PdfPCell cell1ModeleSignature = new PdfPCell(new Phrase("Décision de l'unité", boldFont2));
            cell1ModeleSignature.PaddingLeft = 10f;
            cell1ModeleSignature.PaddingTop = 2f;
            cell1ModeleSignature.PaddingBottom = 5f;
            cell1ModeleSignature.UseVariableBorders = true;
            cell1ModeleSignature.BorderWidthBottom = 1;
            cell1ModeleSignature.BorderWidthLeft = 1;
            cell1ModeleSignature.BorderWidthTop = 1;
            cell1ModeleSignature.BackgroundColor = new BaseColor(228, 235, 245);
            cell1ModeleSignature.BorderColor = new BaseColor(208, 211, 212);
            cell1ModeleSignature.BorderWidthRight = 1;
            tableModeleSignature.AddCell(cell1ModeleSignature);

            PdfPCell cell2ModeleSignature = new PdfPCell(new Phrase("", normalFont2));
            cell2ModeleSignature.PaddingLeft = 10f;
            cell2ModeleSignature.UseVariableBorders = true;
            cell2ModeleSignature.PaddingTop = 2f;
            cell2ModeleSignature.PaddingBottom = 5f;
            cell2ModeleSignature.HorizontalAlignment = 0;
            cell2ModeleSignature.BorderWidthBottom = 1;
            cell2ModeleSignature.BorderWidthLeft = 1;
            cell2ModeleSignature.BorderWidthTop = 1;
            cell2ModeleSignature.BorderColor = new BaseColor(208, 211, 212);
            cell2ModeleSignature.BorderWidthRight = 1;
            cell2ModeleSignature.Bottom = 3f;
            tableModeleSignature.AddCell(cell2ModeleSignature);

            PdfPCell cell3ModeleSignature = new PdfPCell(new Phrase("Organe de délibération (Utilisateur)", boldFont2));
            cell3ModeleSignature.PaddingLeft = 10f;
            cell3ModeleSignature.PaddingTop = 2f;
            cell3ModeleSignature.PaddingBottom = 5f;
            cell3ModeleSignature.UseVariableBorders = true;
            cell3ModeleSignature.BorderWidthBottom = 1;
            cell3ModeleSignature.BorderWidthLeft = 1;
            cell3ModeleSignature.BorderWidthTop = 1;
            cell3ModeleSignature.BackgroundColor = new BaseColor(228, 235, 245);
            cell3ModeleSignature.BorderColor = new BaseColor(208, 211, 212);
            cell3ModeleSignature.BorderWidthRight = 1;
            tableModeleSignature.AddCell(cell3ModeleSignature);

            PdfPCell cell4ModeleSignature = new PdfPCell(new Phrase("", normalFont2));
            cell4ModeleSignature.PaddingLeft = 10f;
            cell4ModeleSignature.UseVariableBorders = true;
            cell4ModeleSignature.PaddingTop = 2f;
            cell4ModeleSignature.PaddingBottom = 5f;
            cell4ModeleSignature.HorizontalAlignment = 0;
            cell4ModeleSignature.BorderWidthBottom = 1;
            cell4ModeleSignature.BorderWidthLeft = 1;
            cell4ModeleSignature.BorderWidthTop = 1;
            cell4ModeleSignature.BorderColor = new BaseColor(208, 211, 212);
            cell4ModeleSignature.BorderWidthRight = 1;
            cell4ModeleSignature.Bottom = 3f;
            tableModeleSignature.AddCell(cell4ModeleSignature);

            PdfPCell cell5ModeleSignature = new PdfPCell(new Phrase("Date de l'approbation", boldFont2));
            cell5ModeleSignature.PaddingLeft = 10f;
            cell5ModeleSignature.PaddingTop = 2f;
            cell5ModeleSignature.PaddingBottom = 5f;
            cell5ModeleSignature.UseVariableBorders = true;
            cell5ModeleSignature.BorderWidthBottom = 1;
            cell5ModeleSignature.BorderWidthLeft = 1;
            cell5ModeleSignature.BorderWidthTop = 1;
            cell5ModeleSignature.BackgroundColor = new BaseColor(228, 235, 245);
            cell5ModeleSignature.BorderColor = new BaseColor(208, 211, 212);
            cell5ModeleSignature.BorderWidthRight = 1;
            tableModeleSignature.AddCell(cell5ModeleSignature);

            PdfPCell cell6ModeleSignature = new PdfPCell(new Phrase("", normalFont2));
            cell6ModeleSignature.PaddingLeft = 10f;
            cell6ModeleSignature.UseVariableBorders = true;
            cell6ModeleSignature.PaddingTop = 2f;
            cell6ModeleSignature.PaddingBottom = 5f;
            cell6ModeleSignature.HorizontalAlignment = 0;
            cell6ModeleSignature.BorderWidthBottom = 1;
            cell6ModeleSignature.BorderWidthLeft = 1;
            cell6ModeleSignature.BorderWidthTop = 1;
            cell6ModeleSignature.BorderColor = new BaseColor(208, 211, 212);
            cell6ModeleSignature.BorderWidthRight = 1;
            cell6ModeleSignature.Bottom = 3f;
            tableModeleSignature.AddCell(cell6ModeleSignature);

            PdfPCell cell7ModeleSignature = new PdfPCell(new Phrase("Signature", boldFont2));
            cell7ModeleSignature.PaddingLeft = 10f;
            cell7ModeleSignature.PaddingTop = 2f;
            cell7ModeleSignature.PaddingBottom = 20f;
            cell7ModeleSignature.UseVariableBorders = true;
            cell7ModeleSignature.BorderWidthBottom = 1;
            cell7ModeleSignature.BorderWidthLeft = 1;
            cell7ModeleSignature.BorderWidthTop = 1;
            cell7ModeleSignature.BackgroundColor = new BaseColor(228, 235, 245);
            cell7ModeleSignature.BorderColor = new BaseColor(208, 211, 212);
            cell7ModeleSignature.BorderWidthRight = 1;
            tableModeleSignature.AddCell(cell7ModeleSignature);

            PdfPCell cell8ModeleSignature = new PdfPCell(new Phrase(" ", normalFont2));
            cell8ModeleSignature.PaddingLeft = 10f;
            cell8ModeleSignature.UseVariableBorders = true;
            cell8ModeleSignature.PaddingTop = 2f;
            cell8ModeleSignature.PaddingBottom = 20f;
            cell8ModeleSignature.HorizontalAlignment = 0;
            cell8ModeleSignature.BorderWidthBottom = 1;
            cell8ModeleSignature.BorderWidthLeft = 1;
            cell8ModeleSignature.BorderWidthTop = 1;
            cell8ModeleSignature.BorderColor = new BaseColor(208, 211, 212);
            cell8ModeleSignature.BorderWidthRight = 1;
            cell8ModeleSignature.Bottom = 3f;
            tableModeleSignature.AddCell(cell8ModeleSignature);
        }
        public void Statut()
        {
            Font boldFont2 = new Font(Font.FontFamily.TIMES_ROMAN, 9, Font.BOLD, BaseColor.BLACK);
            Font boldFont22 = new Font(Font.FontFamily.TIMES_ROMAN, 9, Font.BOLD, BaseColor.WHITE);
            Font normalFont2 = new Font(Font.FontFamily.TIMES_ROMAN, 9, Font.ITALIC, BaseColor.BLACK);


            tableModeleStatut.TotalWidth = 500f;
            tableModeleStatut.PaddingTop = 5f;
            //fix the absolute width of the table
            tableModeleStatut.LockedWidth = true;
            //relative col widths in proportions - 1/3 and 2/3
            //float[] widthstablequalital312 = new float[] { 2.5f, 3f, 0.5f, 2f, 2f, 2f };
            float[] widthstablequalital312 = new float[] { 4f, 8f };
            tableModeleStatut.SetWidths(widthstablequalital312);
            tableModeleStatut.HorizontalAlignment = 1;
            //string LIBELLE_REPONSE = "fff";
            //PdfPCell cell1ModeleStatut = new PdfPCell(new Phrase("vider", boldFont22));
            //cell1ModeleStatut.Colspan = 3;
            //cell1ModeleStatut.PaddingLeft = 10f;
            //cell1ModeleStatut.PaddingTop = 2f;
            //cell1ModeleStatut.PaddingBottom = 5f;
            //cell1ModeleStatut.UseVariableBorders = true;
            //cell1ModeleStatut.BorderWidthBottom = 1;
            //cell1ModeleStatut.BorderWidthLeft = 1;
            //cell1ModeleStatut.BorderWidthTop = 1;
            //cell1ModeleStatut.BackgroundColor = new BaseColor(255, 255, 255);
            //cell1ModeleStatut.BorderColor = new BaseColor(255, 255, 255);
            //cell1ModeleStatut.BorderWidthRight = 1;
            //tableModeleStatut.AddCell(cell1ModeleStatut);

            //PdfPCell cell31ModeleStatut = new PdfPCell(new Phrase("vider", boldFont22));
            //cell31ModeleStatut.PaddingLeft = 10f;
            //cell31ModeleStatut.PaddingTop = 2f;
            //cell31ModeleStatut.PaddingBottom = 5f;
            //cell31ModeleStatut.UseVariableBorders = true;
            //cell31ModeleStatut.BorderWidthBottom = 1;
            //cell31ModeleStatut.BorderWidthLeft = 1;
            //cell31ModeleStatut.BorderWidthTop = 1;
            //cell31ModeleStatut.BackgroundColor = new BaseColor(255, 255, 255);
            //cell31ModeleStatut.BorderColor = new BaseColor(255, 255, 255);
            //cell31ModeleStatut.BorderWidthRight = 1;
            //tableModeleStatut.AddCell(cell31ModeleStatut);

            //PdfPCell cell11ModeleStatut = new PdfPCell(new Phrase("Notation", boldFont2));
            //cell11ModeleStatut.PaddingLeft = 10f;
            //cell11ModeleStatut.PaddingTop = 2f;
            //cell11ModeleStatut.PaddingBottom = 5f;
            //cell11ModeleStatut.UseVariableBorders = true;
            //cell11ModeleStatut.BorderWidthBottom = 1;
            //cell11ModeleStatut.BorderWidthLeft = 1;
            //cell11ModeleStatut.BorderWidthTop = 1;
            //cell11ModeleStatut.BackgroundColor = new BaseColor(228, 235, 245);
            //cell11ModeleStatut.BorderColor = new BaseColor(208, 211, 212);
            //cell11ModeleStatut.BorderWidthRight = 1;
            //tableModeleStatut.AddCell(cell11ModeleStatut);

            //PdfPCell cell12ModeleStatut = new PdfPCell(new Phrase("DT Notation", boldFont2));
            //cell12ModeleStatut.PaddingLeft = 10f;
            //cell12ModeleStatut.PaddingTop = 2f;
            //cell12ModeleStatut.PaddingBottom = 5f;
            //cell12ModeleStatut.UseVariableBorders = true;
            //cell12ModeleStatut.BorderWidthBottom = 1;
            //cell12ModeleStatut.BorderWidthLeft = 1;
            //cell12ModeleStatut.BorderWidthTop = 1;
            //cell12ModeleStatut.BackgroundColor = new BaseColor(228, 235, 245);
            //cell12ModeleStatut.BorderColor = new BaseColor(208, 211, 212);
            //cell12ModeleStatut.BorderWidthRight = 1;
            //tableModeleStatut.AddCell(cell12ModeleStatut);

            //deuxieme ligne
            PdfPCell cell13ModeleStatut = new PdfPCell(new Phrase("Information sur le statut", boldFont2));
            cell13ModeleStatut.PaddingLeft = 10f;
            cell13ModeleStatut.PaddingTop = 2f;
            cell13ModeleStatut.PaddingBottom = 2f;
            cell13ModeleStatut.UseVariableBorders = true;
            cell13ModeleStatut.BorderWidthBottom = 1;
            cell13ModeleStatut.BorderWidthLeft = 1;
            cell13ModeleStatut.BorderWidthTop = 1;
            cell13ModeleStatut.BackgroundColor = new BaseColor(228, 235, 245);
            cell13ModeleStatut.BorderColor = new BaseColor(208, 211, 212);
            cell13ModeleStatut.BorderWidthRight = 1;
            tableModeleStatut.AddCell(cell13ModeleStatut);

            PdfPCell cell2ModeleStatut = new PdfPCell(new Phrase(MAnalyse, normalFont2));
            cell2ModeleStatut.PaddingLeft = 3f;
            cell2ModeleStatut.UseVariableBorders = true;
            cell2ModeleStatut.PaddingTop = 2f;
            cell2ModeleStatut.PaddingBottom = 2f;
            cell2ModeleStatut.HorizontalAlignment = 0;
            cell2ModeleStatut.BorderWidthBottom = 1;
            cell2ModeleStatut.BorderWidthLeft = 1;
            cell2ModeleStatut.BorderWidthTop = 1;
            cell2ModeleStatut.BorderColor = new BaseColor(208, 211, 212);
            cell2ModeleStatut.BorderWidthRight = 1;
            tableModeleStatut.AddCell(cell2ModeleStatut);

            //PdfPCell cell32ModeleStatut = new PdfPCell(new Phrase("vider", boldFont22));
            //cell32ModeleStatut.PaddingLeft = 10f;
            //cell32ModeleStatut.PaddingTop = 2f;
            //cell32ModeleStatut.PaddingBottom = 2f;
            //cell32ModeleStatut.UseVariableBorders = true;
            //cell32ModeleStatut.BorderWidthBottom = 1;
            //cell32ModeleStatut.BorderWidthLeft = 1;
            //cell32ModeleStatut.BorderWidthTop = 1;
            //cell32ModeleStatut.BackgroundColor = new BaseColor(255, 255, 255);
            //cell32ModeleStatut.BorderColor = new BaseColor(255, 255, 255);
            //cell32ModeleStatut.BorderWidthRight = 1;
            //tableModeleStatut.AddCell(cell32ModeleStatut);

            //PdfPCell cell3ModeleStatut = new PdfPCell(new Phrase("Notation BC", boldFont2));
            //cell3ModeleStatut.PaddingLeft = 10f;
            //cell3ModeleStatut.PaddingTop = 2f;
            //cell3ModeleStatut.PaddingBottom = 2f;
            //cell3ModeleStatut.UseVariableBorders = true;
            //cell3ModeleStatut.BorderWidthBottom = 1;
            //cell3ModeleStatut.BorderWidthLeft = 1;
            //cell3ModeleStatut.BorderWidthTop = 1;
            //cell3ModeleStatut.BackgroundColor = new BaseColor(228, 235, 245);
            //cell3ModeleStatut.BorderColor = new BaseColor(208, 211, 212);
            //cell3ModeleStatut.BorderWidthRight = 1;
            //tableModeleStatut.AddCell(cell3ModeleStatut);

            //PdfPCell cell4ModeleStatut = new PdfPCell(new Phrase("-", normalFont2));
            //cell4ModeleStatut.PaddingLeft = 3f;
            //cell4ModeleStatut.UseVariableBorders = true;
            //cell4ModeleStatut.PaddingTop = 2f;
            //cell4ModeleStatut.PaddingBottom = 2f;
            //cell4ModeleStatut.HorizontalAlignment = 0;
            //cell4ModeleStatut.BorderWidthBottom = 1;
            //cell4ModeleStatut.BorderWidthLeft = 1;
            //cell4ModeleStatut.BorderWidthTop = 1;
            //cell4ModeleStatut.BorderColor = new BaseColor(208, 211, 212);
            //cell4ModeleStatut.BorderWidthRight = 1;
            //tableModeleStatut.AddCell(cell4ModeleStatut);

            //PdfPCell cell41ModeleStatut = new PdfPCell(new Phrase("-", normalFont2));
            //cell41ModeleStatut.PaddingLeft = 3f;
            //cell41ModeleStatut.UseVariableBorders = true;
            //cell41ModeleStatut.PaddingTop = 2f;
            //cell41ModeleStatut.PaddingBottom = 2f;
            //cell41ModeleStatut.HorizontalAlignment = 0;
            //cell41ModeleStatut.BorderWidthBottom = 1;
            //cell41ModeleStatut.BorderWidthLeft = 1;
            //cell41ModeleStatut.BorderWidthTop = 1;
            //cell41ModeleStatut.BorderColor = new BaseColor(208, 211, 212);
            //cell41ModeleStatut.BorderWidthRight = 1;
            //tableModeleStatut.AddCell(cell41ModeleStatut);

            //troixième ligne

            PdfPCell cell23ModeleStatut = new PdfPCell(new Phrase("Classe interne", boldFont2));
            cell23ModeleStatut.PaddingLeft = 10f;
            cell23ModeleStatut.PaddingTop = 2f;
            cell23ModeleStatut.PaddingBottom = 2f;
            cell23ModeleStatut.UseVariableBorders = true;
            cell23ModeleStatut.BorderWidthBottom = 1;
            cell23ModeleStatut.BorderWidthLeft = 1;
            cell23ModeleStatut.BorderWidthTop = 1;
            cell23ModeleStatut.BackgroundColor = new BaseColor(228, 235, 245);
            cell23ModeleStatut.BorderColor = new BaseColor(208, 211, 212);
            cell23ModeleStatut.BorderWidthRight = 1;
            tableModeleStatut.AddCell(cell23ModeleStatut);

            PdfPCell cell12ModeleStatut12 = new PdfPCell(new Phrase("Créances saines", normalFont2));
            cell12ModeleStatut12.PaddingLeft = 3f;
            cell12ModeleStatut12.UseVariableBorders = true;
            cell12ModeleStatut12.PaddingTop = 2f;
            cell12ModeleStatut12.PaddingBottom = 2f;
            cell12ModeleStatut12.HorizontalAlignment = 0;
            cell12ModeleStatut12.BorderWidthBottom = 1;
            cell12ModeleStatut12.BorderWidthLeft = 1;
            cell12ModeleStatut12.BorderWidthTop = 1;
            cell12ModeleStatut12.BorderColor = new BaseColor(208, 211, 212);
            cell12ModeleStatut12.BorderWidthRight = 1;
            tableModeleStatut.AddCell(cell12ModeleStatut12);

            //PdfPCell cell42ModeleStatut = new PdfPCell(new Phrase("vider", boldFont22));
            //cell42ModeleStatut.PaddingLeft = 10f;
            //cell42ModeleStatut.PaddingTop = 2f;
            //cell42ModeleStatut.PaddingBottom = 2f;
            //cell42ModeleStatut.UseVariableBorders = true;
            //cell42ModeleStatut.BorderWidthBottom = 1;
            //cell42ModeleStatut.BorderWidthLeft = 1;
            //cell42ModeleStatut.BorderWidthTop = 1;
            //cell42ModeleStatut.BackgroundColor = new BaseColor(255, 255, 255);
            //cell42ModeleStatut.BorderColor = new BaseColor(255, 255, 255);
            //cell42ModeleStatut.BorderWidthRight = 1;
            //tableModeleStatut.AddCell(cell42ModeleStatut);

            //PdfPCell cell33ModeleStatut = new PdfPCell(new Phrase("-", boldFont2));
            //cell33ModeleStatut.PaddingLeft = 10f;
            //cell33ModeleStatut.PaddingTop = 2f;
            //cell33ModeleStatut.PaddingBottom = 2f;
            //cell33ModeleStatut.UseVariableBorders = true;
            //cell33ModeleStatut.BorderWidthBottom = 1;
            //cell33ModeleStatut.BorderWidthLeft = 1;
            //cell33ModeleStatut.BorderWidthTop = 1;
            //cell33ModeleStatut.BackgroundColor = new BaseColor(228, 235, 245);
            //cell33ModeleStatut.BorderColor = new BaseColor(208, 211, 212);
            //cell33ModeleStatut.BorderWidthRight = 1;
            //tableModeleStatut.AddCell(cell33ModeleStatut);

            //PdfPCell cell411ModeleStatut = new PdfPCell(new Phrase("-", normalFont2));
            //cell411ModeleStatut.PaddingLeft = 3f;
            //cell411ModeleStatut.UseVariableBorders = true;
            //cell411ModeleStatut.PaddingTop = 2f;
            //cell411ModeleStatut.PaddingBottom = 2f;
            //cell411ModeleStatut.HorizontalAlignment = 0;
            //cell411ModeleStatut.BorderWidthBottom = 1;
            //cell411ModeleStatut.BorderWidthLeft = 1;
            //cell411ModeleStatut.BorderWidthTop = 1;
            //cell411ModeleStatut.BorderColor = new BaseColor(208, 211, 212);
            //cell411ModeleStatut.BorderWidthRight = 1;
            //tableModeleStatut.AddCell(cell411ModeleStatut);

            //PdfPCell cell42ModeleStatut1 = new PdfPCell(new Phrase("-", normalFont2));
            //cell42ModeleStatut1.PaddingLeft = 3f;
            //cell42ModeleStatut1.UseVariableBorders = true;
            //cell42ModeleStatut1.PaddingTop = 2f;
            //cell42ModeleStatut1.PaddingBottom = 2f;
            //cell42ModeleStatut1.HorizontalAlignment = 0;
            //cell42ModeleStatut1.BorderWidthBottom = 1;
            //cell42ModeleStatut1.BorderWidthLeft = 1;
            //cell42ModeleStatut1.BorderWidthTop = 1;
            //cell42ModeleStatut1.BorderColor = new BaseColor(208, 211, 212);
            //cell42ModeleStatut1.BorderWidthRight = 1;
            //tableModeleStatut.AddCell(cell42ModeleStatut1);



            //Quatrième ligne

            PdfPCell cell25ModeleStatut = new PdfPCell(new Phrase("Classe à risque élévé", boldFont2));
            cell25ModeleStatut.PaddingLeft = 10f;
            cell25ModeleStatut.PaddingTop = 2f;
            cell25ModeleStatut.PaddingBottom = 2f;
            cell25ModeleStatut.UseVariableBorders = true;
            cell25ModeleStatut.BorderWidthBottom = 1;
            cell25ModeleStatut.BorderWidthLeft = 1;
            cell25ModeleStatut.BorderWidthTop = 1;
            cell25ModeleStatut.BackgroundColor = new BaseColor(228, 235, 245);
            cell25ModeleStatut.BorderColor = new BaseColor(208, 211, 212);
            cell25ModeleStatut.BorderWidthRight = 1;
            tableModeleStatut.AddCell(cell25ModeleStatut);

            PdfPCell cell16ModeleStatut = new PdfPCell(new Phrase("-", normalFont2));
            cell16ModeleStatut.PaddingLeft = 3f;
            cell16ModeleStatut.UseVariableBorders = true;
            cell16ModeleStatut.PaddingTop = 2f;
            cell16ModeleStatut.PaddingBottom = 2f;
            cell16ModeleStatut.HorizontalAlignment = 0;
            cell16ModeleStatut.BorderWidthBottom = 1;
            cell16ModeleStatut.BorderWidthLeft = 1;
            cell16ModeleStatut.BorderWidthTop = 1;
            cell16ModeleStatut.BorderColor = new BaseColor(208, 211, 212);
            cell16ModeleStatut.BorderWidthRight = 1;
            tableModeleStatut.AddCell(cell16ModeleStatut);

            //PdfPCell cell44ModeleStatut = new PdfPCell(new Phrase("vider", boldFont22));
            //cell44ModeleStatut.PaddingLeft = 10f;
            //cell44ModeleStatut.PaddingTop = 2f;
            //cell44ModeleStatut.PaddingBottom = 2f;
            //cell44ModeleStatut.UseVariableBorders = true;
            //cell44ModeleStatut.BorderWidthBottom = 1;
            //cell44ModeleStatut.BorderWidthLeft = 1;
            //cell44ModeleStatut.BorderWidthTop = 1;
            //cell44ModeleStatut.BackgroundColor = new BaseColor(255, 255, 255);
            //cell44ModeleStatut.BorderColor = new BaseColor(255, 255, 255);
            //cell44ModeleStatut.BorderWidthRight = 1;
            //tableModeleStatut.AddCell(cell44ModeleStatut);

            //PdfPCell cell33ModeleStatut1 = new PdfPCell(new Phrase("-", boldFont2));
            //cell33ModeleStatut1.PaddingLeft = 10f;
            //cell33ModeleStatut1.PaddingTop = 2f;
            //cell33ModeleStatut1.PaddingBottom = 2f;
            //cell33ModeleStatut1.UseVariableBorders = true;
            //cell33ModeleStatut1.BorderWidthBottom = 1;
            //cell33ModeleStatut1.BorderWidthLeft = 1;
            //cell33ModeleStatut1.BorderWidthTop = 1;
            //cell33ModeleStatut1.BackgroundColor = new BaseColor(228, 235, 245);
            //cell33ModeleStatut1.BorderColor = new BaseColor(208, 211, 212);
            //cell33ModeleStatut1.BorderWidthRight = 1;
            //tableModeleStatut.AddCell(cell33ModeleStatut1);

            //PdfPCell cell411ModeleStatut2 = new PdfPCell(new Phrase("-", normalFont2));
            //cell411ModeleStatut2.PaddingLeft = 3f;
            //cell411ModeleStatut2.UseVariableBorders = true;
            //cell411ModeleStatut2.PaddingTop = 2f;
            //cell411ModeleStatut2.PaddingBottom = 2f;
            //cell411ModeleStatut2.HorizontalAlignment = 0;
            //cell411ModeleStatut2.BorderWidthBottom = 1;
            //cell411ModeleStatut2.BorderWidthLeft = 1;
            //cell411ModeleStatut2.BorderWidthTop = 1;
            //cell411ModeleStatut2.BorderColor = new BaseColor(208, 211, 212);
            //cell411ModeleStatut2.BorderWidthRight = 1;
            //tableModeleStatut.AddCell(cell411ModeleStatut2);

            //PdfPCell cell42ModeleStatut3 = new PdfPCell(new Phrase("-", normalFont2));
            //cell42ModeleStatut3.PaddingLeft = 3f;
            //cell42ModeleStatut3.UseVariableBorders = true;
            //cell42ModeleStatut3.PaddingTop = 2f;
            //cell42ModeleStatut3.PaddingBottom = 2f;
            //cell42ModeleStatut3.HorizontalAlignment = 0;
            //cell42ModeleStatut3.BorderWidthBottom = 1;
            //cell42ModeleStatut3.BorderWidthLeft = 1;
            //cell42ModeleStatut3.BorderWidthTop = 1;
            //cell42ModeleStatut3.BorderColor = new BaseColor(208, 211, 212);
            //cell42ModeleStatut3.BorderWidthRight = 1;
            //tableModeleStatut.AddCell(cell42ModeleStatut3);

            //5 eme ligne

            PdfPCell cell25ModeleStatut4 = new PdfPCell(new Phrase("Classification nationale", boldFont2));
            cell25ModeleStatut4.PaddingLeft = 10f;
            cell25ModeleStatut4.PaddingTop = 2f;
            cell25ModeleStatut4.PaddingBottom = 2f;
            cell25ModeleStatut4.UseVariableBorders = true;
            cell25ModeleStatut4.BorderWidthBottom = 1;
            cell25ModeleStatut4.BorderWidthLeft = 1;
            cell25ModeleStatut4.BorderWidthTop = 1;
            cell25ModeleStatut4.BackgroundColor = new BaseColor(228, 235, 245);
            cell25ModeleStatut4.BorderColor = new BaseColor(208, 211, 212);
            cell25ModeleStatut4.BorderWidthRight = 1;
            tableModeleStatut.AddCell(cell25ModeleStatut4);

            PdfPCell cell16ModeleStatut5 = new PdfPCell(new Phrase("-", normalFont2));
            cell16ModeleStatut5.PaddingLeft = 3f;
            cell16ModeleStatut5.UseVariableBorders = true;
            cell16ModeleStatut5.PaddingTop = 2f;
            cell16ModeleStatut5.PaddingBottom = 2f;
            cell16ModeleStatut5.HorizontalAlignment = 0;
            cell16ModeleStatut5.BorderWidthBottom = 1;
            cell16ModeleStatut5.BorderWidthLeft = 1;
            cell16ModeleStatut5.BorderWidthTop = 1;
            cell16ModeleStatut5.BorderColor = new BaseColor(208, 211, 212);
            cell16ModeleStatut5.BorderWidthRight = 1;
            tableModeleStatut.AddCell(cell16ModeleStatut5);

            //PdfPCell cell44ModeleStatut6 = new PdfPCell(new Phrase("vider", boldFont22));
            //cell44ModeleStatut6.PaddingLeft = 10f;
            //cell44ModeleStatut6.PaddingTop = 2f;
            //cell44ModeleStatut6.PaddingBottom = 2f;
            //cell44ModeleStatut6.UseVariableBorders = true;
            //cell44ModeleStatut6.BorderWidthBottom = 1;
            //cell44ModeleStatut6.BorderWidthLeft = 1;
            //cell44ModeleStatut6.BorderWidthTop = 1;
            //cell44ModeleStatut6.BackgroundColor = new BaseColor(255, 255, 255);
            //cell44ModeleStatut6.BorderColor = new BaseColor(255, 255, 255);
            //cell44ModeleStatut6.BorderWidthRight = 1;
            //tableModeleStatut.AddCell(cell44ModeleStatut6);

            //PdfPCell cell33ModeleStatut7 = new PdfPCell(new Phrase("-", boldFont2));
            //cell33ModeleStatut7.PaddingLeft = 10f;
            //cell33ModeleStatut7.PaddingTop = 2f;
            //cell33ModeleStatut7.PaddingBottom = 2f;
            //cell33ModeleStatut7.UseVariableBorders = true;
            //cell33ModeleStatut7.BorderWidthBottom = 1;
            //cell33ModeleStatut7.BorderWidthLeft = 1;
            //cell33ModeleStatut7.BorderWidthTop = 1;
            //cell33ModeleStatut7.BackgroundColor = new BaseColor(228, 235, 245);
            //cell33ModeleStatut7.BorderColor = new BaseColor(208, 211, 212);
            //cell33ModeleStatut7.BorderWidthRight = 1;
            //tableModeleStatut.AddCell(cell33ModeleStatut7);

            //PdfPCell cell411ModeleStatut8 = new PdfPCell(new Phrase("-", normalFont2));
            //cell411ModeleStatut8.PaddingLeft = 3f;
            //cell411ModeleStatut8.UseVariableBorders = true;
            //cell411ModeleStatut8.PaddingTop = 2f;
            //cell411ModeleStatut8.PaddingBottom = 2f;
            //cell411ModeleStatut8.HorizontalAlignment = 0;
            //cell411ModeleStatut8.BorderWidthBottom = 1;
            //cell411ModeleStatut8.BorderWidthLeft = 1;
            //cell411ModeleStatut8.BorderWidthTop = 1;
            //cell411ModeleStatut8.BorderColor = new BaseColor(208, 211, 212);
            //cell411ModeleStatut8.BorderWidthRight = 1;
            //tableModeleStatut.AddCell(cell411ModeleStatut8);

            //PdfPCell cell42ModeleStatut9 = new PdfPCell(new Phrase("-", normalFont2));
            //cell42ModeleStatut9.PaddingLeft = 3f;
            //cell42ModeleStatut9.UseVariableBorders = true;
            //cell42ModeleStatut9.PaddingTop = 2f;
            //cell42ModeleStatut9.PaddingBottom = 2f;
            //cell42ModeleStatut9.HorizontalAlignment = 0;
            //cell42ModeleStatut9.BorderWidthBottom = 1;
            //cell42ModeleStatut9.BorderWidthLeft = 1;
            //cell42ModeleStatut9.BorderWidthTop = 1;
            //cell42ModeleStatut9.BorderColor = new BaseColor(208, 211, 212);
            //cell42ModeleStatut9.BorderWidthRight = 1;
            //tableModeleStatut.AddCell(cell42ModeleStatut9);


            // 6 eme ligne 

            //PdfPCell cell1ModeleStatut10 = new PdfPCell(new Phrase("vider", boldFont22));
            //cell1ModeleStatut10.Colspan = 3;
            //cell1ModeleStatut10.PaddingLeft = 10f;
            //cell1ModeleStatut10.PaddingTop = 2f;
            //cell1ModeleStatut10.PaddingBottom = 5f;
            //cell1ModeleStatut10.UseVariableBorders = true;
            //cell1ModeleStatut10.BorderWidthBottom = 1;
            //cell1ModeleStatut10.BorderWidthLeft = 1;
            //cell1ModeleStatut10.BorderWidthTop = 1;
            //cell1ModeleStatut10.BackgroundColor = new BaseColor(255, 255, 255);
            //cell1ModeleStatut10.BorderColor = new BaseColor(255, 255, 255);
            //cell1ModeleStatut10.BorderWidthRight = 1;
            //tableModeleStatut.AddCell(cell1ModeleStatut10);

            //PdfPCell cell12ModeleStatut13 = new PdfPCell(new Phrase(" -", boldFont2));
            //cell12ModeleStatut13.PaddingLeft = 10f;
            //cell12ModeleStatut13.PaddingTop = 2f;
            //cell12ModeleStatut13.PaddingBottom = 5f;
            //cell12ModeleStatut13.UseVariableBorders = true;
            //cell12ModeleStatut13.BorderWidthBottom = 1;
            //cell12ModeleStatut13.BorderWidthLeft = 1;
            //cell12ModeleStatut13.BorderWidthTop = 1;
            //cell12ModeleStatut13.BackgroundColor = new BaseColor(228, 235, 245);
            //cell12ModeleStatut13.BorderColor = new BaseColor(208, 211, 212);
            //cell12ModeleStatut13.BorderWidthRight = 1;
            //tableModeleStatut.AddCell(cell12ModeleStatut13);

            //PdfPCell cell31ModeleStatut11 = new PdfPCell(new Phrase("-", normalFont2));
            //cell31ModeleStatut11.PaddingLeft = 10f;
            //cell31ModeleStatut11.PaddingTop = 2f;
            //cell31ModeleStatut11.PaddingBottom = 5f;
            //cell31ModeleStatut11.UseVariableBorders = true;
            //cell31ModeleStatut11.BorderWidthBottom = 1;
            //cell31ModeleStatut11.BorderWidthLeft = 1;
            //cell31ModeleStatut11.BorderWidthTop = 1;
            //cell31ModeleStatut11.BackgroundColor = new BaseColor(255, 255, 255);
            //cell31ModeleStatut11.BorderColor = new BaseColor(208, 211, 212);
            //cell31ModeleStatut11.BorderWidthRight = 1;
            //tableModeleStatut.AddCell(cell31ModeleStatut11);

            //PdfPCell cell11ModeleStatut12 = new PdfPCell(new Phrase("-", normalFont2));
            //cell11ModeleStatut12.PaddingLeft = 10f;
            //cell11ModeleStatut12.PaddingTop = 2f;
            //cell11ModeleStatut12.PaddingBottom = 5f;
            //cell11ModeleStatut12.UseVariableBorders = true;
            //cell11ModeleStatut12.BorderWidthBottom = 1;
            //cell11ModeleStatut12.BorderWidthLeft = 1;
            //cell11ModeleStatut12.BorderWidthTop = 1;
            //cell11ModeleStatut12.BackgroundColor = new BaseColor(255, 255, 255);
            //cell11ModeleStatut12.BorderColor = new BaseColor(208, 211, 212);
            //cell11ModeleStatut12.BorderWidthRight = 1;
            //tableModeleStatut.AddCell(cell11ModeleStatut12);
        }
        public void rating()
        {
            Font boldFont2 = new Font(Font.FontFamily.TIMES_ROMAN, 9, Font.BOLD, BaseColor.BLACK);
            Font boldFont22 = new Font(Font.FontFamily.TIMES_ROMAN, 9, Font.BOLD, BaseColor.WHITE);
            Font normalFont2 = new Font(Font.FontFamily.TIMES_ROMAN, 9, Font.ITALIC, BaseColor.BLACK);

            tableModeleRating.TotalWidth = 500f;
            tableModeleRating.PaddingTop = 5f;
            //fix the absolute width of the table
            tableModeleRating.LockedWidth = true;
            //relative col widths in proportions - 1/3 and 2/3
            float[] widthstablequalital3122 = new float[] { 2f, 3f, 2f, 3f, 2f };
            tableModeleRating.SetWidths(widthstablequalital3122);
            tableModeleRating.HorizontalAlignment = 1;

            // 1ere ligne
            PdfPCell cell1Modelerating10 = new PdfPCell(new Phrase("vider", boldFont22));
            cell1Modelerating10.PaddingLeft = 5f;
            cell1Modelerating10.PaddingTop = 2f;
            cell1Modelerating10.PaddingBottom = 5f;
            cell1Modelerating10.UseVariableBorders = true;
            cell1Modelerating10.BorderWidthBottom = 1;
            cell1Modelerating10.BorderWidthLeft = 1;
            cell1Modelerating10.BorderWidthTop = 1;
            cell1Modelerating10.BackgroundColor = new BaseColor(255, 255, 255);
            cell1Modelerating10.BorderColor = new BaseColor(255, 255, 255);
            cell1Modelerating10.BorderWidthRight = 1;
            tableModeleRating.AddCell(cell1Modelerating10);

            PdfPCell cell12Modelerating13 = new PdfPCell(new Phrase("Classe de Rating", boldFont2));
            cell12Modelerating13.PaddingLeft = 5f;
            cell12Modelerating13.PaddingTop = 2f;
            cell12Modelerating13.PaddingBottom = 5f;
            cell12Modelerating13.UseVariableBorders = true;
            cell12Modelerating13.BorderWidthBottom = 1;
            cell12Modelerating13.BorderWidthLeft = 1;
            cell12Modelerating13.BorderWidthTop = 1;
            cell12Modelerating13.BackgroundColor = new BaseColor(228, 235, 245);
            cell12Modelerating13.BorderColor = new BaseColor(208, 211, 212);
            cell12Modelerating13.BorderWidthRight = 1;
            tableModeleRating.AddCell(cell12Modelerating13);

            PdfPCell cell12Modelerating1 = new PdfPCell(new Phrase("Statut", boldFont2));
            cell12Modelerating1.PaddingLeft = 5f;
            cell12Modelerating1.PaddingTop = 2f;
            cell12Modelerating1.PaddingBottom = 5f;
            cell12Modelerating1.UseVariableBorders = true;
            cell12Modelerating1.BorderWidthBottom = 1;
            cell12Modelerating1.BorderWidthLeft = 1;
            cell12Modelerating1.BorderWidthTop = 1;
            cell12Modelerating1.BackgroundColor = new BaseColor(228, 235, 245);
            cell12Modelerating1.BorderColor = new BaseColor(208, 211, 212);
            cell12Modelerating1.BorderWidthRight = 1;
            tableModeleRating.AddCell(cell12Modelerating1);

            PdfPCell cell22Modelerating2 = new PdfPCell(new Phrase("Modif", boldFont2));
            cell22Modelerating2.PaddingLeft = 5f;
            cell22Modelerating2.PaddingTop = 2f;
            cell22Modelerating2.PaddingBottom = 5f;
            cell22Modelerating2.UseVariableBorders = true;
            cell22Modelerating2.BorderWidthBottom = 1;
            cell22Modelerating2.BorderWidthLeft = 1;
            cell22Modelerating2.BorderWidthTop = 1;
            cell22Modelerating2.BackgroundColor = new BaseColor(228, 235, 245);
            cell22Modelerating2.BorderColor = new BaseColor(208, 211, 212);
            cell22Modelerating2.BorderWidthRight = 1;
            tableModeleRating.AddCell(cell22Modelerating2);

            PdfPCell cell33Modelerating3 = new PdfPCell(new Phrase("Date d'expiration", boldFont2));
            cell33Modelerating3.PaddingLeft = 5f;
            cell33Modelerating3.PaddingTop = 2f;
            cell33Modelerating3.PaddingBottom = 5f;
            cell33Modelerating3.UseVariableBorders = true;
            cell33Modelerating3.BorderWidthBottom = 1;
            cell33Modelerating3.BorderWidthLeft = 1;
            cell33Modelerating3.BorderWidthTop = 1;
            cell33Modelerating3.BackgroundColor = new BaseColor(228, 235, 245);
            cell33Modelerating3.BorderColor = new BaseColor(208, 211, 212);
            cell33Modelerating3.BorderWidthRight = 1;
            tableModeleRating.AddCell(cell33Modelerating3);

            //2 eme ligne

            PdfPCell cell33Modelerating4 = new PdfPCell(new Phrase("Rating Précédant", boldFont2));
            cell33Modelerating4.PaddingLeft = 5f;
            cell33Modelerating4.PaddingTop = 2f;
            cell33Modelerating4.PaddingBottom = 2f;
            cell33Modelerating4.UseVariableBorders = true;
            cell33Modelerating4.BorderWidthBottom = 1;
            cell33Modelerating4.BorderWidthLeft = 1;
            cell33Modelerating4.BorderWidthTop = 1;
            cell33Modelerating4.BackgroundColor = new BaseColor(228, 235, 245);
            cell33Modelerating4.BorderColor = new BaseColor(208, 211, 212);
            cell33Modelerating4.BorderWidthRight = 1;
            tableModeleRating.AddCell(cell33Modelerating4);

            PdfPCell cell33Modelerating5 = new PdfPCell(new Phrase("-", normalFont2));
            cell33Modelerating5.PaddingLeft = 3f;
            cell33Modelerating5.PaddingTop = 2f;
            cell33Modelerating5.PaddingBottom = 5f;
            cell33Modelerating5.UseVariableBorders = true;
            cell33Modelerating5.BorderWidthBottom = 1;
            cell33Modelerating5.BorderWidthLeft = 1;
            cell33Modelerating5.BorderWidthTop = 1;
            cell33Modelerating5.BackgroundColor = new BaseColor(255, 255, 255);
            cell33Modelerating5.BorderColor = new BaseColor(208, 211, 212);
            cell33Modelerating5.BorderWidthRight = 1;
            tableModeleRating.AddCell(cell33Modelerating5);

            PdfPCell cell33Modelerating6 = new PdfPCell(new Phrase("-", normalFont2));
            cell33Modelerating6.PaddingLeft = 3f;
            cell33Modelerating6.PaddingTop = 2f;
            cell33Modelerating6.PaddingBottom = 5f;
            cell33Modelerating6.UseVariableBorders = true;
            cell33Modelerating6.BorderWidthBottom = 1;
            cell33Modelerating6.BorderWidthLeft = 1;
            cell33Modelerating6.BorderWidthTop = 1;
            cell33Modelerating6.BackgroundColor = new BaseColor(255, 255, 255);
            cell33Modelerating6.BorderColor = new BaseColor(208, 211, 212);
            cell33Modelerating6.BorderWidthRight = 1;
            tableModeleRating.AddCell(cell33Modelerating6);

            PdfPCell cell33Modelerating7 = new PdfPCell(new Phrase("-", normalFont2));
            cell33Modelerating7.PaddingLeft = 3f;
            cell33Modelerating7.PaddingTop = 2f;
            cell33Modelerating7.PaddingBottom = 5f;
            cell33Modelerating7.UseVariableBorders = true;
            cell33Modelerating7.BorderWidthBottom = 1;
            cell33Modelerating7.BorderWidthLeft = 1;
            cell33Modelerating7.BorderWidthTop = 1;
            cell33Modelerating7.BackgroundColor = new BaseColor(255, 255, 255);
            cell33Modelerating7.BorderColor = new BaseColor(208, 211, 212);
            cell33Modelerating7.BorderWidthRight = 1;
            tableModeleRating.AddCell(cell33Modelerating7);

            PdfPCell cell33Modelerating8 = new PdfPCell(new Phrase("-", normalFont2));
            cell33Modelerating8.PaddingLeft = 3f;
            cell33Modelerating8.PaddingTop = 2f;
            cell33Modelerating8.PaddingBottom = 5f;
            cell33Modelerating8.UseVariableBorders = true;
            cell33Modelerating8.BorderWidthBottom = 1;
            cell33Modelerating8.BorderWidthLeft = 1;
            cell33Modelerating8.BorderWidthTop = 1;
            cell33Modelerating8.BackgroundColor = new BaseColor(255, 255, 255);
            cell33Modelerating8.BorderColor = new BaseColor(208, 211, 212);
            cell33Modelerating8.BorderWidthRight = 1;
            tableModeleRating.AddCell(cell33Modelerating8);


            //3 eme ligne

            PdfPCell cell33Modele3rating4 = new PdfPCell(new Phrase("Rating Actuel", boldFont2));
            cell33Modele3rating4.PaddingLeft = 5f;
            cell33Modele3rating4.PaddingTop = 2f;
            cell33Modele3rating4.PaddingBottom = 2f;
            cell33Modele3rating4.UseVariableBorders = true;
            cell33Modele3rating4.BorderWidthBottom = 1;
            cell33Modele3rating4.BorderWidthLeft = 1;
            cell33Modele3rating4.BorderWidthTop = 1;
            cell33Modele3rating4.BackgroundColor = new BaseColor(228, 235, 245);
            cell33Modele3rating4.BorderColor = new BaseColor(208, 211, 212);
            cell33Modele3rating4.BorderWidthRight = 1;
            tableModeleRating.AddCell(cell33Modele3rating4);

            PdfPCell cell33Modele3rating5 = new PdfPCell(new Phrase("-", normalFont2));
            cell33Modele3rating5.PaddingLeft = 3f;
            cell33Modele3rating5.PaddingTop = 2f;
            cell33Modele3rating5.PaddingBottom = 5f;
            cell33Modele3rating5.UseVariableBorders = true;
            cell33Modele3rating5.BorderWidthBottom = 1;
            cell33Modele3rating5.BorderWidthLeft = 1;
            cell33Modele3rating5.BorderWidthTop = 1;
            cell33Modele3rating5.BackgroundColor = new BaseColor(255, 255, 255);
            cell33Modele3rating5.BorderColor = new BaseColor(208, 211, 212);
            cell33Modele3rating5.BorderWidthRight = 1;
            tableModeleRating.AddCell(cell33Modele3rating5);

            PdfPCell cell33Modele3rating6 = new PdfPCell(new Phrase("-", normalFont2));
            cell33Modele3rating6.PaddingLeft = 3f;
            cell33Modele3rating6.PaddingTop = 2f;
            cell33Modele3rating6.PaddingBottom = 5f;
            cell33Modele3rating6.UseVariableBorders = true;
            cell33Modele3rating6.BorderWidthBottom = 1;
            cell33Modele3rating6.BorderWidthLeft = 1;
            cell33Modele3rating6.BorderWidthTop = 1;
            cell33Modele3rating6.BackgroundColor = new BaseColor(255, 255, 255);
            cell33Modele3rating6.BorderColor = new BaseColor(208, 211, 212);
            cell33Modele3rating6.BorderWidthRight = 1;
            tableModeleRating.AddCell(cell33Modele3rating6);

            PdfPCell cell33Modele3rating7 = new PdfPCell(new Phrase("-", normalFont2));
            cell33Modele3rating7.PaddingLeft = 3f;
            cell33Modele3rating7.PaddingTop = 2f;
            cell33Modele3rating7.PaddingBottom = 5f;
            cell33Modele3rating7.UseVariableBorders = true;
            cell33Modele3rating7.BorderWidthBottom = 1;
            cell33Modele3rating7.BorderWidthLeft = 1;
            cell33Modele3rating7.BorderWidthTop = 1;
            cell33Modele3rating7.BackgroundColor = new BaseColor(255, 255, 255);
            cell33Modele3rating7.BorderColor = new BaseColor(208, 211, 212);
            cell33Modele3rating7.BorderWidthRight = 1;
            tableModeleRating.AddCell(cell33Modele3rating7);

            PdfPCell cell33Modele3rating8 = new PdfPCell(new Phrase("-", normalFont2));
            cell33Modele3rating8.PaddingLeft = 3f;
            cell33Modele3rating8.PaddingTop = 2f;
            cell33Modele3rating8.PaddingBottom = 5f;
            cell33Modele3rating8.UseVariableBorders = true;
            cell33Modele3rating8.BorderWidthBottom = 1;
            cell33Modele3rating8.BorderWidthLeft = 1;
            cell33Modele3rating8.BorderWidthTop = 1;
            cell33Modele3rating8.BackgroundColor = new BaseColor(255, 255, 255);
            cell33Modele3rating8.BorderColor = new BaseColor(208, 211, 212);
            cell33Modele3rating8.BorderWidthRight = 1;
            tableModeleRating.AddCell(cell33Modele3rating8);
        }
        public void ratingInfo()
        {
            Font boldFont2 = new Font(Font.FontFamily.TIMES_ROMAN, 9, Font.BOLD, BaseColor.BLACK);
            Font boldFont22 = new Font(Font.FontFamily.TIMES_ROMAN, 9, Font.BOLD, BaseColor.WHITE);
            Font normalFont2 = new Font(Font.FontFamily.TIMES_ROMAN, 9, Font.ITALIC, BaseColor.BLACK);

            table2Modele6rating.TotalWidth = 500f;
            table2Modele6rating.PaddingTop = 5f;
            //fix the absolute width of the table
            table2Modele6rating.LockedWidth = true;
            //relative col widths in proportions - 1/3 and 2/3
            float[] widthstablequalital31221 = new float[] { 2f, 2f, 2f, 2f, 2f, 2f };
            table2Modele6rating.SetWidths(widthstablequalital31221);
            table2Modele6rating.HorizontalAlignment = 1;

            // 1ere ligne
            PdfPCell cell1Modele6rating10 = new PdfPCell(new Phrase("vider", boldFont22));
            cell1Modele6rating10.PaddingLeft = 5f;
            cell1Modele6rating10.PaddingTop = 2f;
            cell1Modele6rating10.PaddingBottom = 5f;
            cell1Modele6rating10.UseVariableBorders = true;
            cell1Modele6rating10.BorderWidthBottom = 1;
            cell1Modele6rating10.BorderWidthLeft = 1;
            cell1Modele6rating10.BorderWidthTop = 1;
            cell1Modele6rating10.BackgroundColor = new BaseColor(255, 255, 255);
            cell1Modele6rating10.BorderColor = new BaseColor(255, 255, 255);
            cell1Modele6rating10.BorderWidthRight = 1;
            table2Modele6rating.AddCell(cell1Modele6rating10);

            PdfPCell cell12Modele6rating13 = new PdfPCell(new Phrase("Modele de Rating", boldFont2));
            cell12Modele6rating13.PaddingLeft = 5f;
            cell12Modele6rating13.PaddingTop = 2f;
            cell12Modele6rating13.PaddingBottom = 5f;
            cell12Modele6rating13.UseVariableBorders = true;
            cell12Modele6rating13.BorderWidthBottom = 1;
            cell12Modele6rating13.BorderWidthLeft = 1;
            cell12Modele6rating13.BorderWidthTop = 1;
            cell12Modele6rating13.BackgroundColor = new BaseColor(228, 235, 245);
            cell12Modele6rating13.BorderColor = new BaseColor(208, 211, 212);
            cell12Modele6rating13.BorderWidthRight = 1;
            table2Modele6rating.AddCell(cell12Modele6rating13);

            PdfPCell cell12Modele6rating1 = new PdfPCell(new Phrase("Groupe Influent", boldFont2));
            cell12Modele6rating1.PaddingLeft = 5f;
            cell12Modele6rating1.PaddingTop = 2f;
            cell12Modele6rating1.PaddingBottom = 5f;
            cell12Modele6rating1.UseVariableBorders = true;
            cell12Modele6rating1.BorderWidthBottom = 1;
            cell12Modele6rating1.BorderWidthLeft = 1;
            cell12Modele6rating1.BorderWidthTop = 1;
            cell12Modele6rating1.BackgroundColor = new BaseColor(228, 235, 245);
            cell12Modele6rating1.BorderColor = new BaseColor(208, 211, 212);
            cell12Modele6rating1.BorderWidthRight = 1;
            table2Modele6rating.AddCell(cell12Modele6rating1);

            PdfPCell cell22Modele6rating2 = new PdfPCell(new Phrase("Demande", boldFont2));
            cell22Modele6rating2.PaddingLeft = 5f;
            cell22Modele6rating2.PaddingTop = 2f;
            cell22Modele6rating2.PaddingBottom = 5f;
            cell22Modele6rating2.UseVariableBorders = true;
            cell22Modele6rating2.BorderWidthBottom = 1;
            cell22Modele6rating2.BorderWidthLeft = 1;
            cell22Modele6rating2.BorderWidthTop = 1;
            cell22Modele6rating2.BackgroundColor = new BaseColor(228, 235, 245);
            cell22Modele6rating2.BorderColor = new BaseColor(208, 211, 212);
            cell22Modele6rating2.BorderWidthRight = 1;
            table2Modele6rating.AddCell(cell22Modele6rating2);

            PdfPCell cell33Modele6rating3 = new PdfPCell(new Phrase("Approuvé", boldFont2));
            cell33Modele6rating3.PaddingLeft = 5f;
            cell33Modele6rating3.PaddingTop = 2f;
            cell33Modele6rating3.PaddingBottom = 5f;
            cell33Modele6rating3.UseVariableBorders = true;
            cell33Modele6rating3.BorderWidthBottom = 1;
            cell33Modele6rating3.BorderWidthLeft = 1;
            cell33Modele6rating3.BorderWidthTop = 1;
            cell33Modele6rating3.BackgroundColor = new BaseColor(228, 235, 245);
            cell33Modele6rating3.BorderColor = new BaseColor(208, 211, 212);
            cell33Modele6rating3.BorderWidthRight = 1;
            table2Modele6rating.AddCell(cell33Modele6rating3);

            PdfPCell cell33Modele6ratiing3 = new PdfPCell(new Phrase("Notching approuvé", boldFont2));
            cell33Modele6ratiing3.PaddingLeft = 5f;
            cell33Modele6ratiing3.PaddingTop = 2f;
            cell33Modele6ratiing3.PaddingBottom = 5f;
            cell33Modele6ratiing3.UseVariableBorders = true;
            cell33Modele6ratiing3.BorderWidthBottom = 1;
            cell33Modele6ratiing3.BorderWidthLeft = 1;
            cell33Modele6ratiing3.BorderWidthTop = 1;
            cell33Modele6ratiing3.BackgroundColor = new BaseColor(228, 235, 245);
            cell33Modele6ratiing3.BorderColor = new BaseColor(208, 211, 212);
            cell33Modele6ratiing3.BorderWidthRight = 1;
            table2Modele6rating.AddCell(cell33Modele6ratiing3);

            //2 eme ligne

            PdfPCell cell33Modele6rating4 = new PdfPCell(new Phrase("Notching Final", boldFont2));
            cell33Modele6rating4.PaddingLeft = 5f;
            cell33Modele6rating4.PaddingTop = 2f;
            cell33Modele6rating4.PaddingBottom = 2f;
            cell33Modele6rating4.UseVariableBorders = true;
            cell33Modele6rating4.BorderWidthBottom = 1;
            cell33Modele6rating4.BorderWidthLeft = 1;
            cell33Modele6rating4.BorderWidthTop = 1;
            cell33Modele6rating4.BackgroundColor = new BaseColor(228, 235, 245);
            cell33Modele6rating4.BorderColor = new BaseColor(208, 211, 212);
            cell33Modele6rating4.BorderWidthRight = 1;
            table2Modele6rating.AddCell(cell33Modele6rating4);

            PdfPCell cell33Modele6rating5 = new PdfPCell(new Phrase("-", normalFont2));
            cell33Modele6rating5.PaddingLeft = 3f;
            cell33Modele6rating5.PaddingTop = 2f;
            cell33Modele6rating5.PaddingBottom = 2f;
            cell33Modele6rating5.UseVariableBorders = true;
            cell33Modele6rating5.BorderWidthBottom = 1;
            cell33Modele6rating5.BorderWidthLeft = 1;
            cell33Modele6rating5.BorderWidthTop = 1;
            cell33Modele6rating5.BackgroundColor = new BaseColor(255, 255, 255);
            cell33Modele6rating5.BorderColor = new BaseColor(208, 211, 212);
            cell33Modele6rating5.BorderWidthRight = 1;
            table2Modele6rating.AddCell(cell33Modele6rating5);

            PdfPCell cell33Modele6rating6 = new PdfPCell(new Phrase("-", normalFont2));
            cell33Modele6rating6.PaddingLeft = 3f;
            cell33Modele6rating6.PaddingTop = 2f;
            cell33Modele6rating6.PaddingBottom = 2f;
            cell33Modele6rating6.UseVariableBorders = true;
            cell33Modele6rating6.BorderWidthBottom = 1;
            cell33Modele6rating6.BorderWidthLeft = 1;
            cell33Modele6rating6.BorderWidthTop = 1;
            cell33Modele6rating6.BackgroundColor = new BaseColor(255, 255, 255);
            cell33Modele6rating6.BorderColor = new BaseColor(208, 211, 212);
            cell33Modele6rating6.BorderWidthRight = 1;
            table2Modele6rating.AddCell(cell33Modele6rating6);

            PdfPCell cell33Modele6rating7 = new PdfPCell(new Phrase("-", normalFont2));
            cell33Modele6rating7.PaddingLeft = 3f;
            cell33Modele6rating7.PaddingTop = 2f;
            cell33Modele6rating7.PaddingBottom = 2f;
            cell33Modele6rating7.UseVariableBorders = true;
            cell33Modele6rating7.BorderWidthBottom = 1;
            cell33Modele6rating7.BorderWidthLeft = 1;
            cell33Modele6rating7.BorderWidthTop = 1;
            cell33Modele6rating7.BackgroundColor = new BaseColor(255, 255, 255);
            cell33Modele6rating7.BorderColor = new BaseColor(208, 211, 212);
            cell33Modele6rating7.BorderWidthRight = 1;
            table2Modele6rating.AddCell(cell33Modele6rating7);

            PdfPCell cell33Modele6rating8 = new PdfPCell(new Phrase("-", normalFont2));
            cell33Modele6rating8.PaddingLeft = 3f;
            cell33Modele6rating8.PaddingTop = 2f;
            cell33Modele6rating8.PaddingBottom = 2f;
            cell33Modele6rating8.UseVariableBorders = true;
            cell33Modele6rating8.BorderWidthBottom = 1;
            cell33Modele6rating8.BorderWidthLeft = 1;
            cell33Modele6rating8.BorderWidthTop = 1;
            cell33Modele6rating8.BackgroundColor = new BaseColor(255, 255, 255);
            cell33Modele6rating8.BorderColor = new BaseColor(208, 211, 212);
            cell33Modele6rating8.BorderWidthRight = 1;
            table2Modele6rating.AddCell(cell33Modele6rating8);

            PdfPCell cell33Modele6ra1ting8 = new PdfPCell(new Phrase("-", normalFont2));
            cell33Modele6ra1ting8.PaddingLeft = 3f;
            cell33Modele6ra1ting8.PaddingTop = 2f;
            cell33Modele6ra1ting8.PaddingBottom = 2f;
            cell33Modele6ra1ting8.UseVariableBorders = true;
            cell33Modele6ra1ting8.BorderWidthBottom = 1;
            cell33Modele6ra1ting8.BorderWidthLeft = 1;
            cell33Modele6ra1ting8.BorderWidthTop = 1;
            cell33Modele6ra1ting8.BackgroundColor = new BaseColor(255, 255, 255);
            cell33Modele6ra1ting8.BorderColor = new BaseColor(208, 211, 212);
            cell33Modele6ra1ting8.BorderWidthRight = 1;
            table2Modele6rating.AddCell(cell33Modele6ra1ting8);
            //3 eme ligne

            PdfPCell cell33Modele6rating41 = new PdfPCell(new Phrase("Rating Final", boldFont2));
            cell33Modele6rating41.PaddingLeft = 5f;
            cell33Modele6rating41.PaddingTop = 2f;
            cell33Modele6rating41.PaddingBottom = 2f;
            cell33Modele6rating41.UseVariableBorders = true;
            cell33Modele6rating41.BorderWidthBottom = 1;
            cell33Modele6rating41.BorderWidthLeft = 1;
            cell33Modele6rating41.BorderWidthTop = 1;
            cell33Modele6rating41.BackgroundColor = new BaseColor(228, 235, 245);
            cell33Modele6rating41.BorderColor = new BaseColor(208, 211, 212);
            cell33Modele6rating41.BorderWidthRight = 1;
            table2Modele6rating.AddCell(cell33Modele6rating41);

            PdfPCell cell33Modele6rating51 = new PdfPCell(new Phrase("-", normalFont2));
            cell33Modele6rating51.PaddingLeft = 3f;
            cell33Modele6rating51.PaddingTop = 2f;
            cell33Modele6rating51.PaddingBottom = 2f;
            cell33Modele6rating51.UseVariableBorders = true;
            cell33Modele6rating51.BorderWidthBottom = 1;
            cell33Modele6rating51.BorderWidthLeft = 1;
            cell33Modele6rating51.BorderWidthTop = 1;
            cell33Modele6rating51.BackgroundColor = new BaseColor(255, 255, 255);
            cell33Modele6rating51.BorderColor = new BaseColor(208, 211, 212);
            cell33Modele6rating51.BorderWidthRight = 1;
            table2Modele6rating.AddCell(cell33Modele6rating51);

            PdfPCell cell33Modele6rating61 = new PdfPCell(new Phrase("-", normalFont2));
            cell33Modele6rating61.PaddingLeft = 3f;
            cell33Modele6rating61.PaddingTop = 2f;
            cell33Modele6rating61.PaddingBottom = 2f;
            cell33Modele6rating61.UseVariableBorders = true;
            cell33Modele6rating61.BorderWidthBottom = 1;
            cell33Modele6rating61.BorderWidthLeft = 1;
            cell33Modele6rating61.BorderWidthTop = 1;
            cell33Modele6rating61.BackgroundColor = new BaseColor(255, 255, 255);
            cell33Modele6rating61.BorderColor = new BaseColor(208, 211, 212);
            cell33Modele6rating61.BorderWidthRight = 1;
            table2Modele6rating.AddCell(cell33Modele6rating61);

            PdfPCell cell33Modele6rating71 = new PdfPCell(new Phrase("-", normalFont2));
            cell33Modele6rating71.PaddingLeft = 3f;
            cell33Modele6rating71.PaddingTop = 2f;
            cell33Modele6rating71.PaddingBottom = 2f;
            cell33Modele6rating71.UseVariableBorders = true;
            cell33Modele6rating71.BorderWidthBottom = 1;
            cell33Modele6rating71.BorderWidthLeft = 1;
            cell33Modele6rating71.BorderWidthTop = 1;
            cell33Modele6rating71.BackgroundColor = new BaseColor(255, 255, 255);
            cell33Modele6rating71.BorderColor = new BaseColor(208, 211, 212);
            cell33Modele6rating71.BorderWidthRight = 1;
            table2Modele6rating.AddCell(cell33Modele6rating71);

            PdfPCell cell33Modeele6rating8 = new PdfPCell(new Phrase("-", normalFont2));
            cell33Modeele6rating8.PaddingLeft = 3f;
            cell33Modeele6rating8.PaddingTop = 2f;
            cell33Modeele6rating8.PaddingBottom = 2f;
            cell33Modeele6rating8.UseVariableBorders = true;
            cell33Modeele6rating8.BorderWidthBottom = 1;
            cell33Modeele6rating8.BorderWidthLeft = 1;
            cell33Modeele6rating8.BorderWidthTop = 1;
            cell33Modeele6rating8.BackgroundColor = new BaseColor(255, 255, 255);
            cell33Modeele6rating8.BorderColor = new BaseColor(208, 211, 212);
            cell33Modeele6rating8.BorderWidthRight = 1;
            table2Modele6rating.AddCell(cell33Modeele6rating8);

            PdfPCell cell33Mooodele6rating8 = new PdfPCell(new Phrase("-", normalFont2));
            cell33Mooodele6rating8.PaddingLeft = 3f;
            cell33Mooodele6rating8.PaddingTop = 2f;
            cell33Mooodele6rating8.PaddingBottom = 2f;
            cell33Mooodele6rating8.UseVariableBorders = true;
            cell33Mooodele6rating8.BorderWidthBottom = 1;
            cell33Mooodele6rating8.BorderWidthLeft = 1;
            cell33Mooodele6rating8.BorderWidthTop = 1;
            cell33Mooodele6rating8.BackgroundColor = new BaseColor(255, 255, 255);
            cell33Mooodele6rating8.BorderColor = new BaseColor(208, 211, 212);
            cell33Mooodele6rating8.BorderWidthRight = 1;
            table2Modele6rating.AddCell(cell33Mooodele6rating8);

            //4eme ligne 

            PdfPCell cell331Modele16rating4 = new PdfPCell(new Phrase("PD moyenne associé à la note", boldFont2));
            cell331Modele16rating4.PaddingLeft = 5f;
            cell331Modele16rating4.PaddingTop = 2f;
            cell331Modele16rating4.PaddingBottom = 5f;
            cell331Modele16rating4.UseVariableBorders = true;
            cell331Modele16rating4.BorderWidthBottom = 1;
            cell331Modele16rating4.BorderWidthLeft = 1;
            cell331Modele16rating4.BorderWidthTop = 1;
            cell331Modele16rating4.BackgroundColor = new BaseColor(228, 235, 245);
            cell331Modele16rating4.BorderColor = new BaseColor(208, 211, 212);
            cell331Modele16rating4.BorderWidthRight = 1;
            table2Modele6rating.AddCell(cell331Modele16rating4);

            PdfPCell cell331Modele16rating5 = new PdfPCell(new Phrase("-", normalFont2));
            cell331Modele16rating5.PaddingLeft = 3f;
            cell331Modele16rating5.PaddingTop = 2f;
            cell331Modele16rating5.PaddingBottom = 5f;
            cell331Modele16rating5.UseVariableBorders = true;
            cell331Modele16rating5.BorderWidthBottom = 1;
            cell331Modele16rating5.BorderWidthLeft = 1;
            cell331Modele16rating5.BorderWidthTop = 1;
            cell331Modele16rating5.BackgroundColor = new BaseColor(255, 255, 255);
            cell331Modele16rating5.BorderColor = new BaseColor(208, 211, 212);
            cell331Modele16rating5.BorderWidthRight = 1;
            table2Modele6rating.AddCell(cell331Modele16rating5);

            PdfPCell cell331Modele16rating6 = new PdfPCell(new Phrase("-", normalFont2));
            cell331Modele16rating6.PaddingLeft = 10f;
            cell331Modele16rating6.PaddingTop = 2f;
            cell331Modele16rating6.PaddingBottom = 5f;
            cell331Modele16rating6.UseVariableBorders = true;
            cell331Modele16rating6.BorderWidthBottom = 1;
            cell331Modele16rating6.BorderWidthLeft = 1;
            cell331Modele16rating6.BorderWidthTop = 1;
            cell331Modele16rating6.BackgroundColor = new BaseColor(255, 255, 255);
            cell331Modele16rating6.BorderColor = new BaseColor(208, 211, 212);
            cell331Modele16rating6.BorderWidthRight = 1;
            table2Modele6rating.AddCell(cell331Modele16rating6);

            PdfPCell cell331Modele16rating7 = new PdfPCell(new Phrase("-", normalFont2));
            cell331Modele16rating7.PaddingLeft = 10f;
            cell331Modele16rating7.PaddingTop = 2f;
            cell331Modele16rating7.PaddingBottom = 5f;
            cell331Modele16rating7.UseVariableBorders = true;
            cell331Modele16rating7.BorderWidthBottom = 1;
            cell331Modele16rating7.BorderWidthLeft = 1;
            cell331Modele16rating7.BorderWidthTop = 1;
            cell331Modele16rating7.BackgroundColor = new BaseColor(255, 255, 255);
            cell331Modele16rating7.BorderColor = new BaseColor(208, 211, 212);
            cell331Modele16rating7.BorderWidthRight = 1;
            table2Modele6rating.AddCell(cell331Modele16rating7);

            PdfPCell cell331Modele16rating8 = new PdfPCell(new Phrase("-", normalFont2));
            cell331Modele16rating8.PaddingLeft = 10f;
            cell331Modele16rating8.PaddingTop = 2f;
            cell331Modele16rating8.PaddingBottom = 5f;
            cell331Modele16rating8.UseVariableBorders = true;
            cell331Modele16rating8.BorderWidthBottom = 1;
            cell331Modele16rating8.BorderWidthLeft = 1;
            cell331Modele16rating8.BorderWidthTop = 1;
            cell331Modele16rating8.BackgroundColor = new BaseColor(255, 255, 255);
            cell331Modele16rating8.BorderColor = new BaseColor(208, 211, 212);
            cell331Modele16rating8.BorderWidthRight = 1;
            table2Modele6rating.AddCell(cell331Modele16rating8);

            PdfPCell cell331Modele16ra1ting8 = new PdfPCell(new Phrase("-", normalFont2));
            cell331Modele16ra1ting8.PaddingLeft = 10f;
            cell331Modele16ra1ting8.PaddingTop = 2f;
            cell331Modele16ra1ting8.PaddingBottom = 5f;
            cell331Modele16ra1ting8.UseVariableBorders = true;
            cell331Modele16ra1ting8.BorderWidthBottom = 1;
            cell331Modele16ra1ting8.BorderWidthLeft = 1;
            cell331Modele16ra1ting8.BorderWidthTop = 1;
            cell331Modele16ra1ting8.BackgroundColor = new BaseColor(255, 255, 255);
            cell331Modele16ra1ting8.BorderColor = new BaseColor(208, 211, 212);
            cell331Modele16ra1ting8.BorderWidthRight = 1;
            table2Modele6rating.AddCell(cell331Modele16ra1ting8);
        }
        public void InfoAnafi()
        {
            if (AdireExpert.Trim() != "")
            {
                MAnalyse = AdireExpert;
            }
            Font boldFont2 = new Font(Font.FontFamily.TIMES_ROMAN, 9, Font.BOLD, BaseColor.BLACK);
            Font boldFont22 = new Font(Font.FontFamily.TIMES_ROMAN, 9, Font.BOLD, BaseColor.WHITE);
            Font normalFont2 = new Font(Font.FontFamily.TIMES_ROMAN, 9, Font.ITALIC, BaseColor.BLACK);


            cell1ModeleNotFinanceTitre.TotalWidth = 500f;
            cell1ModeleNotFinanceTitre.PaddingTop = 5f;
            //fix the absolute width of the table
            cell1ModeleNotFinanceTitre.LockedWidth = true;
            //relative col widths in proportions - 1/3 and 2/3
            float[] widthstablequalital2tableModeleNotQualTitre = new float[] { 12f };
            cell1ModeleNotFinanceTitre.SetWidths(widthstablequalital2tableModeleNotQualTitre);
            cell1ModeleNotFinanceTitre.HorizontalAlignment = 1;
            //string LIBELLE_REPONSE = "fff";

            PdfPCell cell17Anotation = new PdfPCell(new Phrase("Non utilisée", boldFont2));
            cell17Anotation.Colspan = 6;
            cell17Anotation.PaddingLeft = 5f;
            cell17Anotation.HorizontalAlignment = 1;
            cell17Anotation.UseVariableBorders = true;
            cell17Anotation.BorderWidthBottom = 1;
            cell17Anotation.BorderWidthLeft = 1;
            cell17Anotation.BorderWidthTop = 1;
            cell17Anotation.BorderWidthRight = 1;
            cell17Anotation.BackgroundColor = new BaseColor(228, 235, 245);
            cell17Anotation.BorderColor = new BaseColor(208, 211, 212);
            cell17Anotation.PaddingBottom = 5f;
            cell1ModeleNotFinanceTitre.AddCell(cell17Anotation);

            PdfPCell cell14Anotation = new PdfPCell(new Phrase("1", boldFont22));
            cell14Anotation.Colspan = 6;
            cell14Anotation.PaddingLeft = 3f;
            cell14Anotation.PaddingRight = 5f;
            cell14Anotation.UseVariableBorders = true;
            cell14Anotation.PaddingTop = 2f;
            cell14Anotation.PaddingBottom = 30f;
            cell14Anotation.HorizontalAlignment = 1;
            cell14Anotation.BorderWidthBottom = 1;
            cell14Anotation.BorderWidthLeft = 1;
            cell14Anotation.BorderWidthTop = 0;
            cell14Anotation.BorderColor = new BaseColor(208, 211, 212);
            cell14Anotation.BorderWidthRight = 1;
            cell14Anotation.Bottom = 3f;
            cell1ModeleNotFinanceTitre.AddCell(cell14Anotation);



            tableModeleNotFinance.TotalWidth = 500f;
            tableModeleNotFinance.PaddingTop = 5f;
            //fix the absolute width of the table
            tableModeleNotFinance.LockedWidth = true;
            //relative col widths in proportions - 1/3 and 2/3
            float[] widthstablequalital23 = new float[] { 4f, 8f };
            tableModeleNotFinance.SetWidths(widthstablequalital23);
            tableModeleNotFinance.HorizontalAlignment = 1;
            string LIBELLE_REPONSE1 = "fff";


            PdfPCell cell1ModeleNotFinance = new PdfPCell(new Phrase("Modèle de notation", boldFont2));
            cell1ModeleNotFinance.PaddingLeft = 10f;
            cell1ModeleNotFinance.PaddingTop = 2f;
            cell1ModeleNotFinance.PaddingBottom = 5f;
            cell1ModeleNotFinance.UseVariableBorders = true;
            cell1ModeleNotFinance.BorderWidthBottom = 1;
            cell1ModeleNotFinance.BorderWidthLeft = 1;
            cell1ModeleNotFinance.BorderWidthTop = 1;
            cell1ModeleNotFinance.BackgroundColor = new BaseColor(228, 235, 245);
            cell1ModeleNotFinance.BorderColor = new BaseColor(208, 211, 212);
            cell1ModeleNotFinance.BorderWidthRight = 1;
            tableModeleNotFinance.AddCell(cell1ModeleNotFinance);

            PdfPCell cell2ModeleNotFinance = new PdfPCell(new Phrase(MAnalyse, normalFont2));
            cell2ModeleNotFinance.PaddingLeft = 3f;
            cell2ModeleNotFinance.UseVariableBorders = true;
            cell2ModeleNotFinance.PaddingTop = 2f;
            cell2ModeleNotFinance.PaddingBottom = 5f;
            cell2ModeleNotFinance.HorizontalAlignment = 0;
            cell2ModeleNotFinance.BorderWidthBottom = 1;
            cell2ModeleNotFinance.BorderWidthLeft = 1;
            cell2ModeleNotFinance.BorderWidthTop = 1;
            cell2ModeleNotFinance.BorderColor = new BaseColor(208, 211, 212);
            cell2ModeleNotFinance.BorderWidthRight = 1;
            cell2ModeleNotFinance.Bottom = 3f;
            tableModeleNotFinance.AddCell(cell2ModeleNotFinance);

            PdfPCell cell3ModeleNotFinance = new PdfPCell(new Phrase("Note financière", boldFont2));
            cell3ModeleNotFinance.PaddingLeft = 10f;
            cell3ModeleNotFinance.PaddingTop = 2f;
            cell3ModeleNotFinance.PaddingBottom = 5f;
            cell3ModeleNotFinance.UseVariableBorders = true;
            cell3ModeleNotFinance.BorderWidthBottom = 1;
            cell3ModeleNotFinance.BorderWidthLeft = 1;
            cell3ModeleNotFinance.BorderWidthTop = 1;
            cell3ModeleNotFinance.BackgroundColor = new BaseColor(228, 235, 245);
            cell3ModeleNotFinance.BorderColor = new BaseColor(208, 211, 212);
            cell3ModeleNotFinance.BorderWidthRight = 1;
            tableModeleNotFinance.AddCell(cell3ModeleNotFinance);

            PdfPCell cell4ModeleNotFinance = new PdfPCell(new Phrase(fananciere, normalFont2));
            cell4ModeleNotFinance.PaddingLeft = 3f;
            cell4ModeleNotFinance.UseVariableBorders = true;
            cell4ModeleNotFinance.PaddingTop = 2f;
            cell4ModeleNotFinance.PaddingBottom = 5f;
            cell4ModeleNotFinance.HorizontalAlignment = 0;
            cell4ModeleNotFinance.BorderWidthBottom = 1;
            cell4ModeleNotFinance.BorderWidthLeft = 1;
            cell4ModeleNotFinance.BorderWidthTop = 1;
            cell4ModeleNotFinance.BorderColor = new BaseColor(208, 211, 212);
            cell4ModeleNotFinance.BorderWidthRight = 1;
            cell4ModeleNotFinance.Bottom = 3f;
            tableModeleNotFinance.AddCell(cell4ModeleNotFinance);

            PdfPCell cell5ModeleNotFinance = new PdfPCell(new Phrase("Score financier", boldFont2));
            cell5ModeleNotFinance.PaddingLeft = 10f;
            cell5ModeleNotFinance.PaddingTop = 2f;
            cell5ModeleNotFinance.PaddingBottom = 5f;
            cell5ModeleNotFinance.UseVariableBorders = true;
            cell5ModeleNotFinance.BorderWidthBottom = 1;
            cell5ModeleNotFinance.BorderWidthLeft = 1;
            cell5ModeleNotFinance.BorderWidthTop = 1;
            cell5ModeleNotFinance.BackgroundColor = new BaseColor(228, 235, 245);
            cell5ModeleNotFinance.BorderColor = new BaseColor(208, 211, 212);
            cell5ModeleNotFinance.BorderWidthRight = 1;
            tableModeleNotFinance.AddCell(cell5ModeleNotFinance);

            PdfPCell cell6ModeleNotFinance = new PdfPCell(new Phrase(ScoreFinance, normalFont2));
            cell6ModeleNotFinance.PaddingLeft = 3f;
            cell6ModeleNotFinance.UseVariableBorders = true;
            cell6ModeleNotFinance.PaddingTop = 2f;
            cell6ModeleNotFinance.PaddingBottom = 5f;
            cell6ModeleNotFinance.HorizontalAlignment = 0;
            cell6ModeleNotFinance.BorderWidthBottom = 1;
            cell6ModeleNotFinance.BorderWidthLeft = 1;
            cell6ModeleNotFinance.BorderWidthTop = 1;
            cell6ModeleNotFinance.BorderColor = new BaseColor(208, 211, 212);
            cell6ModeleNotFinance.BorderWidthRight = 1;
            cell6ModeleNotFinance.Bottom = 3f;
            tableModeleNotFinance.AddCell(cell6ModeleNotFinance);

            PdfPCell cell7ModeleNotFinance = new PdfPCell(new Phrase("PD du modèle financier", boldFont2));
            cell7ModeleNotFinance.PaddingLeft = 10f;
            cell7ModeleNotFinance.PaddingTop = 2f;
            cell7ModeleNotFinance.PaddingBottom = 5f;
            cell7ModeleNotFinance.UseVariableBorders = true;
            cell7ModeleNotFinance.BorderWidthBottom = 1;
            cell7ModeleNotFinance.BorderWidthLeft = 1;
            cell7ModeleNotFinance.BorderWidthTop = 1;
            cell7ModeleNotFinance.BackgroundColor = new BaseColor(228, 235, 245);
            cell7ModeleNotFinance.BorderColor = new BaseColor(208, 211, 212);
            cell7ModeleNotFinance.BorderWidthRight = 1;
            tableModeleNotFinance.AddCell(cell7ModeleNotFinance);

            PdfPCell cell8ModeleNotFinance = new PdfPCell(new Phrase("0.0", normalFont2));
            cell8ModeleNotFinance.PaddingLeft = 3f;
            cell8ModeleNotFinance.UseVariableBorders = true;
            cell8ModeleNotFinance.PaddingTop = 2f;
            cell8ModeleNotFinance.PaddingBottom = 5f;
            cell8ModeleNotFinance.HorizontalAlignment = 0;
            cell8ModeleNotFinance.BorderWidthBottom = 1;
            cell8ModeleNotFinance.BorderWidthLeft = 1;
            cell8ModeleNotFinance.BorderWidthTop = 1;
            cell8ModeleNotFinance.BorderColor = new BaseColor(208, 211, 212);
            cell8ModeleNotFinance.BorderWidthRight = 1;
            cell8ModeleNotFinance.Bottom = 3f;
            tableModeleNotFinance.AddCell(cell8ModeleNotFinance);
        }
        public void InfoQualit()
        {
            if (AdireExpert.Trim() != "")
            {
                MAnalyse = AdireExpert;
            }
            Font boldFont2 = new Font(Font.FontFamily.TIMES_ROMAN, 9, Font.BOLD, BaseColor.BLACK);
            Font boldFont22 = new Font(Font.FontFamily.TIMES_ROMAN, 9, Font.BOLD, BaseColor.WHITE);
            Font normalFont2 = new Font(Font.FontFamily.TIMES_ROMAN, 9, Font.ITALIC, BaseColor.BLACK);

            tableModeleNotQualTitre.TotalWidth = 500f;
            tableModeleNotQualTitre.PaddingTop = 5f;
            //fix the absolute width of the table
            tableModeleNotQualTitre.LockedWidth = true;
            //relative col widths in proportions - 1/3 and 2/3
            float[] widthstablequalital2tableModeleNotQualTitre = new float[] { 12f };
            tableModeleNotQualTitre.SetWidths(widthstablequalital2tableModeleNotQualTitre);
            tableModeleNotQualTitre.HorizontalAlignment = 1;
            //string LIBELLE_REPONSE = "fff";

            PdfPCell cell17Anotation = new PdfPCell(new Phrase("Non utilisé", boldFont2));
            cell17Anotation.Colspan = 6;
            cell17Anotation.PaddingLeft = 5f;
            cell17Anotation.HorizontalAlignment = 1;
            cell17Anotation.UseVariableBorders = true;
            cell17Anotation.BorderWidthBottom = 1;
            cell17Anotation.BorderWidthLeft = 1;
            cell17Anotation.BorderWidthTop = 1;
            cell17Anotation.BorderWidthRight = 1;
            cell17Anotation.BackgroundColor = new BaseColor(228, 235, 245);
            cell17Anotation.BorderColor = new BaseColor(208, 211, 212);
            cell17Anotation.PaddingBottom = 5f;
            tableModeleNotQualTitre.AddCell(cell17Anotation);

            PdfPCell cell14Anotation = new PdfPCell(new Phrase("1", boldFont22));
            cell14Anotation.Colspan = 6;
            cell14Anotation.PaddingLeft = 3f;
            cell14Anotation.PaddingRight = 5f;
            cell14Anotation.UseVariableBorders = true;
            cell14Anotation.PaddingTop = 2f;
            cell14Anotation.PaddingBottom = 30f;
            cell14Anotation.HorizontalAlignment = 1;
            cell14Anotation.BorderWidthBottom = 1;
            cell14Anotation.BorderWidthLeft = 1;
            cell14Anotation.BorderWidthTop = 0;
            cell14Anotation.BorderColor = new BaseColor(208, 211, 212);
            cell14Anotation.BorderWidthRight = 1;
            cell14Anotation.Bottom = 3f;
            tableModeleNotQualTitre.AddCell(cell14Anotation);






            tableModeleNotQual.TotalWidth = 500f;
            tableModeleNotQual.PaddingTop = 5f;
            //fix the absolute width of the table
            tableModeleNotQual.LockedWidth = true;
            //relative col widths in proportions - 1/3 and 2/3
            float[] widthstablequalital2 = new float[] { 4f, 8f };
            tableModeleNotQual.SetWidths(widthstablequalital2);
            tableModeleNotQual.HorizontalAlignment = 1;
            string LIBELLE_REPONSE = "fff";
            PdfPCell cell1ModeleNotQual = new PdfPCell(new Phrase("Modèle de notation", boldFont2));
            cell1ModeleNotQual.PaddingLeft = 10f;
            cell1ModeleNotQual.PaddingTop = 2f;
            cell1ModeleNotQual.PaddingBottom = 5f;
            cell1ModeleNotQual.UseVariableBorders = true;
            cell1ModeleNotQual.BorderWidthBottom = 1;
            cell1ModeleNotQual.BorderWidthLeft = 1;
            cell1ModeleNotQual.BorderWidthTop = 1;
            cell1ModeleNotQual.BackgroundColor = new BaseColor(228, 235, 245);
            cell1ModeleNotQual.BorderColor = new BaseColor(208, 211, 212);
            cell1ModeleNotQual.BorderWidthRight = 1;
            tableModeleNotQual.AddCell(cell1ModeleNotQual);

            PdfPCell cell2ModeleNotQual = new PdfPCell(new Phrase(MAnalyse, normalFont2));
            cell2ModeleNotQual.PaddingLeft = 3f;
            cell2ModeleNotQual.UseVariableBorders = true;
            cell2ModeleNotQual.PaddingTop = 2f;
            cell2ModeleNotQual.PaddingBottom = 5f;
            cell2ModeleNotQual.HorizontalAlignment = 0;
            cell2ModeleNotQual.BorderWidthBottom = 1;
            cell2ModeleNotQual.BorderWidthLeft = 1;
            cell2ModeleNotQual.BorderWidthTop = 1;
            cell2ModeleNotQual.BorderColor = new BaseColor(208, 211, 212);
            cell2ModeleNotQual.BorderWidthRight = 1;
            cell2ModeleNotQual.Bottom = 3f;
            tableModeleNotQual.AddCell(cell2ModeleNotQual);

            PdfPCell cell3ModeleNotQual = new PdfPCell(new Phrase("Note Qualitative", boldFont2));
            cell3ModeleNotQual.PaddingLeft = 10f;
            cell3ModeleNotQual.PaddingTop = 2f;
            cell3ModeleNotQual.PaddingBottom = 5f;
            cell3ModeleNotQual.UseVariableBorders = true;
            cell3ModeleNotQual.BorderWidthBottom = 1;
            cell3ModeleNotQual.BorderWidthLeft = 1;
            cell3ModeleNotQual.BorderWidthTop = 1;
            cell3ModeleNotQual.BackgroundColor = new BaseColor(228, 235, 245);
            cell3ModeleNotQual.BorderColor = new BaseColor(208, 211, 212);
            cell3ModeleNotQual.BorderWidthRight = 1;
            tableModeleNotQual.AddCell(cell3ModeleNotQual);

            PdfPCell cell4ModeleNotQual = new PdfPCell(new Phrase(qualitative, normalFont2));
            cell4ModeleNotQual.PaddingLeft = 3f;
            cell4ModeleNotQual.UseVariableBorders = true;
            cell4ModeleNotQual.PaddingTop = 2f;
            cell4ModeleNotQual.PaddingBottom = 5f;
            cell4ModeleNotQual.HorizontalAlignment = 0;
            cell4ModeleNotQual.BorderWidthBottom = 1;
            cell4ModeleNotQual.BorderWidthLeft = 1;
            cell4ModeleNotQual.BorderWidthTop = 1;
            cell4ModeleNotQual.BorderColor = new BaseColor(208, 211, 212);
            cell4ModeleNotQual.BorderWidthRight = 1;
            cell4ModeleNotQual.Bottom = 3f;
            tableModeleNotQual.AddCell(cell4ModeleNotQual);

            PdfPCell cell5ModeleNotQual = new PdfPCell(new Phrase("Score qualitatif", boldFont2));
            cell5ModeleNotQual.PaddingLeft = 10f;
            cell5ModeleNotQual.PaddingTop = 2f;
            cell5ModeleNotQual.PaddingBottom = 5f;
            cell5ModeleNotQual.UseVariableBorders = true;
            cell5ModeleNotQual.BorderWidthBottom = 1;
            cell5ModeleNotQual.BorderWidthLeft = 1;
            cell5ModeleNotQual.BorderWidthTop = 1;
            cell5ModeleNotQual.BackgroundColor = new BaseColor(228, 235, 245);
            cell5ModeleNotQual.BorderColor = new BaseColor(208, 211, 212);
            cell5ModeleNotQual.BorderWidthRight = 1;
            tableModeleNotQual.AddCell(cell5ModeleNotQual);

            PdfPCell cell6ModeleNotQual = new PdfPCell(new Phrase(ScoreQualit, normalFont2));
            cell6ModeleNotQual.PaddingLeft = 3f;
            cell6ModeleNotQual.UseVariableBorders = true;
            cell6ModeleNotQual.PaddingTop = 2f;
            cell6ModeleNotQual.PaddingBottom = 5f;
            cell6ModeleNotQual.HorizontalAlignment = 0;
            cell6ModeleNotQual.BorderWidthBottom = 1;
            cell6ModeleNotQual.BorderWidthLeft = 1;
            cell6ModeleNotQual.BorderWidthTop = 1;
            cell6ModeleNotQual.BorderColor = new BaseColor(208, 211, 212);
            cell6ModeleNotQual.BorderWidthRight = 1;
            cell6ModeleNotQual.Bottom = 3f;
            tableModeleNotQual.AddCell(cell6ModeleNotQual);

            PdfPCell cell7ModeleNotQual = new PdfPCell(new Phrase("PD du modèle financier", boldFont2));
            cell7ModeleNotQual.PaddingLeft = 10f;
            cell7ModeleNotQual.PaddingTop = 2f;
            cell7ModeleNotQual.PaddingBottom = 5f;
            cell7ModeleNotQual.UseVariableBorders = true;
            cell7ModeleNotQual.BorderWidthBottom = 1;
            cell7ModeleNotQual.BorderWidthLeft = 1;
            cell7ModeleNotQual.BorderWidthTop = 1;
            cell7ModeleNotQual.BackgroundColor = new BaseColor(228, 235, 245);
            cell7ModeleNotQual.BorderColor = new BaseColor(208, 211, 212);
            cell7ModeleNotQual.BorderWidthRight = 1;
            tableModeleNotQual.AddCell(cell7ModeleNotQual);

            PdfPCell cell8ModeleNotQual = new PdfPCell(new Phrase("0.0", normalFont2));
            cell8ModeleNotQual.PaddingLeft = 3f;
            cell8ModeleNotQual.UseVariableBorders = true;
            cell8ModeleNotQual.PaddingTop = 2f;
            cell8ModeleNotQual.PaddingBottom = 5f;
            cell8ModeleNotQual.HorizontalAlignment = 0;
            cell8ModeleNotQual.BorderWidthBottom = 1;
            cell8ModeleNotQual.BorderWidthLeft = 1;
            cell8ModeleNotQual.BorderWidthTop = 1;
            cell8ModeleNotQual.BorderColor = new BaseColor(208, 211, 212);
            cell8ModeleNotQual.BorderWidthRight = 1;
            cell8ModeleNotQual.Bottom = 3f;
            tableModeleNotQual.AddCell(cell8ModeleNotQual);
        }


        public void InfoEncours()
        {
            Font boldFont2 = new Font(Font.FontFamily.TIMES_ROMAN, 9, Font.BOLD, BaseColor.BLACK);
            Font boldFont21 = new Font(Font.FontFamily.TIMES_ROMAN, 12, Font.BOLD, BaseColor.BLACK);
            Font boldFont22 = new Font(Font.FontFamily.TIMES_ROMAN, 9, Font.BOLD, BaseColor.WHITE);
            Font normalFont2 = new Font(Font.FontFamily.TIMES_ROMAN, 9, Font.ITALIC, BaseColor.BLACK);
            var boldFontTitle = FontFactory.GetFont("palatino linotype", BaseFont.CP1252, BaseFont.EMBEDDED, 14, Font.BOLD);
            var titleFont = FontFactory.GetFont("Segoe UI", 9, BaseColor.WHITE);

            tableInfoEncours.TotalWidth = 500f;
            tableInfoEncours.PaddingTop = 5f;
            //fix the absolute width of the table
            tableInfoEncours.LockedWidth = true;
            //relative col widths in proportions - 1/3 and 2/3
            float[] widthstablequalital = new float[] { 3.5f, 2f, 2f, 2f, 1.5f, 1f };
            tableInfoEncours.SetWidths(widthstablequalital);
            tableInfoEncours.HorizontalAlignment = 1;


            TitleEncous.TotalWidth = 550f;
            TitleEncous.HorizontalAlignment = 1;
            TitleEncous.LockedWidth = true;
            string etatDos = "";
            var id_dossier = Request.QueryString["id"].Trim();

            if (decision.Trim() == "En cours") etatDos = "Encours";

            DateTime DateComptable = service.SELECT_DATE_COMPTABLE(etatDos, id_dossier.Trim()).Where(DateC => DateC.DATE_CHARGEMENT != default(DateTime)).SingleOrDefault().DATE_CHARGEMENT;


            PdfPCell cell1ModeleNotFinance = new PdfPCell(new Phrase("ENCOURS", FontFactory.GetFont("palatino linotype", BaseFont.CP1252, BaseFont.EMBEDDED, 14, Font.BOLD)));
            cell1ModeleNotFinance.PaddingLeft = 10f;
            cell1ModeleNotFinance.PaddingTop = 2f;
            cell1ModeleNotFinance.PaddingBottom = 5f;
            cell1ModeleNotFinance.UseVariableBorders = true;
            cell1ModeleNotFinance.BorderWidthBottom = 1;
            cell1ModeleNotFinance.BorderWidthLeft = 1;
            cell1ModeleNotFinance.BorderWidthTop = 1;
            cell1ModeleNotFinance.Colspan = 4;
            cell1ModeleNotFinance.HorizontalAlignment = 1;
            cell1ModeleNotFinance.BackgroundColor = new BaseColor(255, 255, 255);
            cell1ModeleNotFinance.BorderColor = new BaseColor(255, 255, 255);
            cell1ModeleNotFinance.BorderWidthRight = 1;
            TitleEncous.AddCell(cell1ModeleNotFinance);

            PdfPCell SITUATION = new PdfPCell(new Phrase("Situation comptable au " + " " + DateComptable.ToString("dd/MM/yyyy hh:mm:ss"), boldFontTitle));
            SITUATION.PaddingTop = 5f;
            SITUATION.Colspan = 2;
            SITUATION.Border = 0;
            SITUATION.HorizontalAlignment = 1;
            TitleEncous.AddCell(SITUATION);
            TitleEncous.SpacingBefore = 10f;
            TitleEncous.SpacingAfter = 12.5f;


            PdfPCell cell1qualital = new PdfPCell(new Phrase("Intitulé", boldFont2));
            //cell1qualital.Colspan = 2;
            cell1qualital.HorizontalAlignment = 1;
            cell1qualital.UseVariableBorders = true;
            cell1qualital.BorderWidth = 1;
            cell1qualital.BackgroundColor = new BaseColor(228, 235, 245);
            cell1qualital.BorderColor = new BaseColor(208, 211, 212);
            cell1qualital.PaddingBottom = 5f;
            tableInfoEncours.AddCell(cell1qualital);

            PdfPCell cell1qualit21 = new PdfPCell(new Phrase("Compte", boldFont2));
            //cell1qualit21.Colspan = 2;
            cell1qualit21.HorizontalAlignment = 1;
            cell1qualit21.UseVariableBorders = true;
            cell1qualit21.BorderWidth = 1;
            cell1qualit21.BackgroundColor = new BaseColor(228, 235, 245);
            cell1qualit21.BorderColor = new BaseColor(208, 211, 212);
            cell1qualit21.PaddingBottom = 5f;
            tableInfoEncours.AddCell(cell1qualit21);

            PdfPCell cell1qualital123 = new PdfPCell(new Phrase("Solde", boldFont2));
            //cell1qualital123.Colspan = 2;
            cell1qualital123.HorizontalAlignment = 1;
            cell1qualital123.UseVariableBorders = true;
            cell1qualital123.BorderWidth = 1;
            cell1qualital123.BackgroundColor = new BaseColor(228, 235, 245);
            cell1qualital123.BorderColor = new BaseColor(208, 211, 212);
            cell1qualital123.PaddingBottom = 5f;
            tableInfoEncours.AddCell(cell1qualital123);

            PdfPCell cell1qualit2451 = new PdfPCell(new Phrase("Autorisation de découvert", boldFont2));
            //cell1qualit2451.Colspan = 2;
            cell1qualit2451.HorizontalAlignment = 1;
            cell1qualit2451.UseVariableBorders = true;
            cell1qualit2451.BorderWidth = 1;
            cell1qualit2451.BackgroundColor = new BaseColor(228, 235, 245);
            cell1qualit2451.BorderColor = new BaseColor(208, 211, 212);
            cell1qualit2451.PaddingBottom = 5f;
            tableInfoEncours.AddCell(cell1qualit2451);

            PdfPCell cell1qualital111 = new PdfPCell(new Phrase("Échéance de l'autorisation", boldFont2));
            //cell1qualital111.Colspan = 2;
            cell1qualital111.HorizontalAlignment = 1;
            cell1qualital111.UseVariableBorders = true;
            cell1qualital111.BorderWidth = 1;
            cell1qualital111.BackgroundColor = new BaseColor(228, 235, 245);
            cell1qualital111.BorderColor = new BaseColor(208, 211, 212);
            cell1qualital111.PaddingBottom = 5f;
            tableInfoEncours.AddCell(cell1qualital111);

            PdfPCell cell1qualit281 = new PdfPCell(new Phrase("Devise", boldFont2));
            //cell1qualit281.Colspan = 2;
            cell1qualit281.HorizontalAlignment = 1;
            cell1qualit281.UseVariableBorders = true;
            cell1qualit281.BorderWidth = 1;
            cell1qualit281.BackgroundColor = new BaseColor(228, 235, 245);
            cell1qualit281.BorderColor = new BaseColor(208, 211, 212);
            cell1qualit281.PaddingBottom = 5f;
            tableInfoEncours.AddCell(cell1qualit281);


            var listeCompteClient = service.Liste_ENCOURS_EDITION(id_dossier.Trim());

            if (listeCompteClient.Count != 0)
            {
                foreach (var listeCompte in listeCompteClient)
                {
                    string autorisation = listeCompte.AUTORISATION.Replace(".", ",");
                    if (string.IsNullOrEmpty(autorisation)) autorisation = "0";
                    string solde = listeCompte.SOLDE.Replace(".", ",");
                    if (string.IsNullOrEmpty(solde)) solde = "0";

                    //sb.AppendLine("\n <tr title=\"Sélectionner la ligne\">");
                    //sb.AppendLine(string.Format("\n <td class=\"text-left\" style=\"background-color: rgba(33, 150, 243, 0.57)\"><b>{0}</b></td>", listeCompte.LIBELLE.ToString()));
                    //sb.AppendLine(string.Format("\n <td class=\"text-left\" style=\"background-color: rgba(33, 150, 243, 0.57)\"><b>{0}</b></td>", listeCompte.COMPTE.ToString()));
                    //sb.AppendLine(string.Format("\n <td class=\"text-right\" style=\"background-color: rgba(33, 150, 243, 0.57)\"><b>{0}</b></td>", Convert.ToString(string.Format(frCult, "{0:#,##0}", Convert.ToDouble(solde)))));
                    //sb.AppendLine(string.Format("\n <td class=\"text-right\" style=\"background-color: rgba(33, 150, 243, 0.57)\"><b>{0}</b></td>", Convert.ToString(string.Format(frCult, "{0:#,##0}", Convert.ToDouble(autorisation)))));
                    //sb.AppendLine(string.Format("\n <td class=\"text-left\" style=\"background-color: rgba(33, 150, 243, 0.57)\"><b>{0}</b></td>", listeCompte.ECHEANCE.ToString()));
                    //sb.AppendLine(string.Format("\n <td class=\"text-left\" style=\"background-color: rgba(33, 150, 243, 0.57)\"><b>{0}</b></td>", listeCompte.DEVISE.ToString()));
                    //sb.AppendLine("\n </tr>");


                    PdfPCell cell3qualital = new PdfPCell(new Phrase(listeCompte.LIBELLE.ToString(), normalFont2));
                    cell3qualital.PaddingLeft = 3f;
                    cell3qualital.UseVariableBorders = true;
                    cell3qualital.PaddingTop = 2f;
                    cell3qualital.PaddingBottom = 5f;
                    cell3qualital.HorizontalAlignment = 0;
                    cell3qualital.BorderWidthBottom = 1;
                    cell3qualital.BorderWidthLeft = 1;
                    cell3qualital.BorderWidthTop = 1;
                    cell3qualital.BorderColor = new BaseColor(208, 211, 212);
                    cell3qualital.BorderWidthRight = 1;
                    cell3qualital.Bottom = 3f;
                    tableInfoEncours.AddCell(cell3qualital);

                    PdfPCell cell30vqualital = new PdfPCell(new Phrase(listeCompte.COMPTE.ToString(), normalFont2));
                    cell30vqualital.PaddingLeft = 3f;
                    cell30vqualital.UseVariableBorders = true;
                    cell30vqualital.PaddingTop = 2f;
                    cell30vqualital.PaddingBottom = 5f;
                    cell30vqualital.HorizontalAlignment = 1;
                    cell30vqualital.BorderWidthBottom = 1;
                    cell30vqualital.BorderWidthLeft = 1;
                    cell30vqualital.BorderWidthTop = 1;
                    cell30vqualital.BorderColor = new BaseColor(208, 211, 212);
                    cell30vqualital.BorderWidthRight = 1;
                    cell30vqualital.Bottom = 3f;
                    tableInfoEncours.AddCell(cell30vqualital);


                    PdfPCell Infoqualital = new PdfPCell(new Phrase(Convert.ToString(string.Format(frCult, "{0:#,##0}", Convert.ToDouble(solde))), normalFont2));
                    Infoqualital.PaddingLeft = 3f;
                    Infoqualital.UseVariableBorders = true;
                    Infoqualital.PaddingTop = 2f;
                    Infoqualital.PaddingBottom = 5f;
                    Infoqualital.HorizontalAlignment = 0;
                    Infoqualital.BorderWidthBottom = 1;
                    Infoqualital.BorderWidthLeft = 1;
                    Infoqualital.BorderWidthTop = 1;
                    Infoqualital.BorderColor = new BaseColor(208, 211, 212);
                    Infoqualital.BorderWidthRight = 1;
                    Infoqualital.Bottom = 3f;
                    tableInfoEncours.AddCell(Infoqualital);

                    PdfPCell Info0vqualital = new PdfPCell(new Phrase(Convert.ToString(string.Format(frCult, "{0:#,##0}", Convert.ToDouble(autorisation))), normalFont2));
                    Info0vqualital.PaddingLeft = 3f;
                    Info0vqualital.UseVariableBorders = true;
                    Info0vqualital.PaddingTop = 2f;
                    Info0vqualital.PaddingBottom = 5f;
                    Info0vqualital.HorizontalAlignment = 1;
                    Info0vqualital.BorderWidthBottom = 1;
                    Info0vqualital.BorderWidthLeft = 1;
                    Info0vqualital.BorderWidthTop = 1;
                    Info0vqualital.BorderColor = new BaseColor(208, 211, 212);
                    Info0vqualital.BorderWidthRight = 1;
                    Info0vqualital.Bottom = 3f;
                    tableInfoEncours.AddCell(Info0vqualital);


                    PdfPCell InfoEnqualital = new PdfPCell(new Phrase(listeCompte.ECHEANCE.ToString(), normalFont2));
                    InfoEnqualital.PaddingLeft = 3f;
                    InfoEnqualital.UseVariableBorders = true;
                    InfoEnqualital.PaddingTop = 2f;
                    InfoEnqualital.PaddingBottom = 5f;
                    InfoEnqualital.HorizontalAlignment = 0;
                    InfoEnqualital.BorderWidthBottom = 1;
                    InfoEnqualital.BorderWidthLeft = 1;
                    InfoEnqualital.BorderWidthTop = 1;
                    InfoEnqualital.BorderColor = new BaseColor(208, 211, 212);
                    InfoEnqualital.BorderWidthRight = 1;
                    InfoEnqualital.Bottom = 3f;
                    tableInfoEncours.AddCell(InfoEnqualital);

                    PdfPCell InfoEn0vqualital = new PdfPCell(new Phrase(listeCompte.DEVISE.ToString(), normalFont2));
                    InfoEn0vqualital.PaddingLeft = 3f;
                    InfoEn0vqualital.UseVariableBorders = true;
                    InfoEn0vqualital.PaddingTop = 2f;
                    InfoEn0vqualital.PaddingBottom = 5f;
                    InfoEn0vqualital.HorizontalAlignment = 1;
                    InfoEn0vqualital.BorderWidthBottom = 1;
                    InfoEn0vqualital.BorderWidthLeft = 1;
                    InfoEn0vqualital.BorderWidthTop = 1;
                    InfoEn0vqualital.BorderColor = new BaseColor(208, 211, 212);
                    InfoEn0vqualital.BorderWidthRight = 1;
                    InfoEn0vqualital.Bottom = 3f;
                    tableInfoEncours.AddCell(InfoEn0vqualital);

                }
            }


        }


        public void InfoGroup()
        {
            if (AdireExpert.Trim() != "")
            {
                MAnalyse = AdireExpert;
            }
            Font boldFont2 = new Font(Font.FontFamily.TIMES_ROMAN, 9, Font.BOLD, BaseColor.BLACK);
            Font boldFont21 = new Font(Font.FontFamily.TIMES_ROMAN, 12, Font.BOLD, BaseColor.BLACK);
            Font boldFont22 = new Font(Font.FontFamily.TIMES_ROMAN, 9, Font.BOLD, BaseColor.WHITE);
            Font normalFont2 = new Font(Font.FontFamily.TIMES_ROMAN, 9, Font.ITALIC, BaseColor.BLACK);
            var boldFontTitle = FontFactory.GetFont("palatino linotype", BaseFont.CP1252, BaseFont.EMBEDDED, 14, Font.BOLD);
            var titleFont = FontFactory.GetFont("Segoe UI", 9, BaseColor.WHITE);


            TitleModeleNotation.TotalWidth = 550f;
            TitleModeleNotation.HorizontalAlignment = 1;
            TitleModeleNotation.LockedWidth = true;


            PdfPCell cell1ModeleNotFinance = new PdfPCell(new Phrase("RÉSUMÉ", FontFactory.GetFont("palatino linotype", BaseFont.CP1252, BaseFont.EMBEDDED, 14, Font.BOLD)));
            cell1ModeleNotFinance.PaddingLeft = 10f;
            cell1ModeleNotFinance.PaddingTop = 2f;
            cell1ModeleNotFinance.PaddingBottom = 5f;
            cell1ModeleNotFinance.UseVariableBorders = true;
            cell1ModeleNotFinance.BorderWidthBottom = 1;
            cell1ModeleNotFinance.BorderWidthLeft = 1;
            cell1ModeleNotFinance.BorderWidthTop = 1;
            cell1ModeleNotFinance.Colspan = 4;
            cell1ModeleNotFinance.HorizontalAlignment = 1;
            cell1ModeleNotFinance.BackgroundColor = new BaseColor(255, 255, 255);
            cell1ModeleNotFinance.BorderColor = new BaseColor(255, 255, 255);
            cell1ModeleNotFinance.BorderWidthRight = 1;
            TitleModeleNotation.AddCell(cell1ModeleNotFinance);

            PdfPCell TDRTitleModeleNotation = new PdfPCell(new Phrase("Modèle de notation :" + " " + MAnalyse, boldFontTitle));
            TDRTitleModeleNotation.PaddingTop = 5f;
            TDRTitleModeleNotation.Colspan = 2;
            TDRTitleModeleNotation.Border = 0;
            TDRTitleModeleNotation.HorizontalAlignment = 1;
            TitleModeleNotation.AddCell(TDRTitleModeleNotation);
            TitleModeleNotation.SpacingBefore = 10f;
            TitleModeleNotation.SpacingAfter = 12.5f;

            tableModeleNotGroup.TotalWidth = 500f;
            tableModeleNotGroup.PaddingTop = 5f;
            //fix the absolute width of the table
            tableModeleNotGroup.LockedWidth = true;
            //relative col widths in proportions - 1/3 and 2/3
            float[] widthstablequalital2 = new float[] { 6f, 3f, 3f };
            tableModeleNotGroup.SetWidths(widthstablequalital2);
            tableModeleNotGroup.HorizontalAlignment = 1;
            string LIBELLE_REPONSE = "fff";
            //###
            Chunk valider = new Chunk("Analyse de la contrepartie", FontFactory.GetFont("palatino linotype", BaseFont.CP1252, BaseFont.EMBEDDED, 14, Font.ITALIC));
            valider.SetUnderline(2, -3);
            Phrase p2 = new Phrase();
            p2.Add(valider);
            Paragraph p = new Paragraph(p2);

            PdfPCell cell1qualital = new PdfPCell(p);
            cell1qualital.Colspan = 4;
            cell1qualital.HorizontalAlignment = 1;
            cell1qualital.UseVariableBorders = true;
            cell1qualital.BorderWidth = 0;
            cell1qualital.BackgroundColor = new BaseColor(255, 255, 255);
            cell1qualital.BorderColor = new BaseColor(255, 255, 255);
            cell1qualital.PaddingBottom = 5f;
            tableModeleNotGroup.AddCell(cell1qualital);

            PdfPCell cell1TitreBlabc = new PdfPCell(new Phrase("vide", boldFont22));
            cell1TitreBlabc.PaddingLeft = 10f;
            cell1TitreBlabc.PaddingTop = 2f;
            cell1TitreBlabc.Colspan = 4;
            cell1TitreBlabc.PaddingBottom = 5f;
            cell1TitreBlabc.UseVariableBorders = true;
            cell1TitreBlabc.BorderWidthBottom = 0;
            cell1TitreBlabc.BorderWidthLeft = 0;
            cell1TitreBlabc.BorderWidthTop = 0;
            cell1TitreBlabc.BorderColor = new BaseColor(255, 255, 255);
            cell1TitreBlabc.BorderWidthRight = 0;
            tableModeleNotGroup.AddCell(cell1TitreBlabc);
            //###
            PdfPCell cell1ModeleNotQual = new PdfPCell(new Phrase("vide", boldFont22));
            cell1ModeleNotQual.PaddingLeft = 10f;
            cell1ModeleNotQual.PaddingTop = 2f;
            cell1ModeleNotQual.PaddingBottom = 5f;
            cell1ModeleNotQual.UseVariableBorders = true;
            cell1ModeleNotQual.BorderWidthBottom = 0;
            cell1ModeleNotQual.BorderWidthLeft = 0;
            cell1ModeleNotQual.BorderWidthTop = 0;
            //cell1ModeleNotQual.BackgroundColor = new BaseColor(228, 235, 245);
            cell1ModeleNotQual.BorderColor = new BaseColor(255, 255, 255);
            cell1ModeleNotQual.BorderWidthRight = 0;
            tableModeleNotGroup.AddCell(cell1ModeleNotQual);

            PdfPCell cell1ModeleNotQualGroup = new PdfPCell(new Phrase("Note", boldFont2));
            cell1ModeleNotQualGroup.PaddingLeft = 10f;
            cell1ModeleNotQualGroup.PaddingTop = 2f;
            cell1ModeleNotQualGroup.PaddingBottom = 5f;
            cell1ModeleNotQualGroup.UseVariableBorders = true;
            cell1ModeleNotQualGroup.BorderWidthBottom = 1;
            cell1ModeleNotQualGroup.BorderWidthLeft = 1;
            cell1ModeleNotQualGroup.BorderWidthTop = 1;
            cell1ModeleNotQualGroup.BackgroundColor = new BaseColor(228, 235, 245);
            cell1ModeleNotQualGroup.BorderColor = new BaseColor(208, 211, 212);
            cell1ModeleNotQualGroup.BorderWidthRight = 1;
            tableModeleNotGroup.AddCell(cell1ModeleNotQualGroup);

            PdfPCell cell1ModeleNotQualGroup1 = new PdfPCell(new Phrase("Score", boldFont2));
            cell1ModeleNotQualGroup1.PaddingLeft = 10f;
            cell1ModeleNotQualGroup1.PaddingTop = 2f;
            cell1ModeleNotQualGroup1.PaddingBottom = 5f;
            cell1ModeleNotQualGroup1.UseVariableBorders = true;
            cell1ModeleNotQualGroup1.BorderWidthBottom = 1;
            cell1ModeleNotQualGroup1.BorderWidthLeft = 1;
            cell1ModeleNotQualGroup1.BorderWidthTop = 1;
            cell1ModeleNotQualGroup1.BackgroundColor = new BaseColor(228, 235, 245);
            cell1ModeleNotQualGroup1.BorderColor = new BaseColor(208, 211, 212);
            cell1ModeleNotQualGroup1.BorderWidthRight = 1;
            tableModeleNotGroup.AddCell(cell1ModeleNotQualGroup1);

            PdfPCell cell1ModeleNotQualGroup2 = new PdfPCell(new Phrase("Analyse Financière", boldFont2));
            cell1ModeleNotQualGroup2.PaddingLeft = 10f;
            cell1ModeleNotQualGroup2.PaddingTop = 2f;
            cell1ModeleNotQualGroup2.PaddingBottom = 5f;
            cell1ModeleNotQualGroup2.UseVariableBorders = true;
            cell1ModeleNotQualGroup2.BorderWidthBottom = 1;
            cell1ModeleNotQualGroup2.BorderWidthLeft = 1;
            cell1ModeleNotQualGroup2.BorderWidthTop = 1;
            cell1ModeleNotQualGroup2.BackgroundColor = new BaseColor(228, 235, 245);
            cell1ModeleNotQualGroup2.BorderColor = new BaseColor(208, 211, 212);
            cell1ModeleNotQualGroup2.BorderWidthRight = 1;
            tableModeleNotGroup.AddCell(cell1ModeleNotQualGroup2);

            if (fananciere.Trim() == "NC")
            {
                ScoreFinance = "";
            }
            PdfPCell cell2ModeleNotQualGroup2 = new PdfPCell(new Phrase(fananciere, normalFont2));
            cell2ModeleNotQualGroup2.PaddingLeft = 3f;
            cell2ModeleNotQualGroup2.UseVariableBorders = true;
            cell2ModeleNotQualGroup2.PaddingTop = 2f;
            cell2ModeleNotQualGroup2.PaddingBottom = 5f;
            cell2ModeleNotQualGroup2.HorizontalAlignment = 0;
            cell2ModeleNotQualGroup2.BorderWidthBottom = 1;
            cell2ModeleNotQualGroup2.BorderWidthLeft = 1;
            cell2ModeleNotQualGroup2.BorderWidthTop = 1;
            cell2ModeleNotQualGroup2.BorderColor = new BaseColor(208, 211, 212);
            cell2ModeleNotQualGroup2.BorderWidthRight = 1;
            cell2ModeleNotQualGroup2.Bottom = 3f;
            tableModeleNotGroup.AddCell(cell2ModeleNotQualGroup2);

            PdfPCell cell2ModeleNotQualGroup25 = new PdfPCell(new Phrase(ScoreFinance, normalFont2));
            cell2ModeleNotQualGroup25.PaddingLeft = 3f;
            cell2ModeleNotQualGroup25.UseVariableBorders = true;
            cell2ModeleNotQualGroup25.PaddingTop = 2f;
            cell2ModeleNotQualGroup25.PaddingBottom = 5f;
            cell2ModeleNotQualGroup25.HorizontalAlignment = 0;
            cell2ModeleNotQualGroup25.BorderWidthBottom = 1;
            cell2ModeleNotQualGroup25.BorderWidthLeft = 1;
            cell2ModeleNotQualGroup25.BorderWidthTop = 1;
            cell2ModeleNotQualGroup25.BorderColor = new BaseColor(208, 211, 212);
            cell2ModeleNotQualGroup25.BorderWidthRight = 1;
            cell2ModeleNotQualGroup25.Bottom = 3f;
            tableModeleNotGroup.AddCell(cell2ModeleNotQualGroup25);

            PdfPCell cell1ModeleNotQualGroup21 = new PdfPCell(new Phrase("Analyse Qualitative", boldFont2));
            cell1ModeleNotQualGroup21.PaddingLeft = 10f;
            cell1ModeleNotQualGroup21.PaddingTop = 2f;
            cell1ModeleNotQualGroup21.PaddingBottom = 5f;
            cell1ModeleNotQualGroup21.UseVariableBorders = true;
            cell1ModeleNotQualGroup21.BorderWidthBottom = 1;
            cell1ModeleNotQualGroup21.BorderWidthLeft = 1;
            cell1ModeleNotQualGroup21.BorderWidthTop = 1;
            cell1ModeleNotQualGroup21.BackgroundColor = new BaseColor(228, 235, 245);
            cell1ModeleNotQualGroup21.BorderColor = new BaseColor(208, 211, 212);
            cell1ModeleNotQualGroup21.BorderWidthRight = 1;
            tableModeleNotGroup.AddCell(cell1ModeleNotQualGroup21);


            PdfPCell cell2ModeleNotQualGroup22 = new PdfPCell(new Phrase(qualitative, normalFont2));
            cell2ModeleNotQualGroup22.PaddingLeft = 3f;
            cell2ModeleNotQualGroup22.UseVariableBorders = true;
            cell2ModeleNotQualGroup22.PaddingTop = 2f;
            cell2ModeleNotQualGroup22.PaddingBottom = 5f;
            cell2ModeleNotQualGroup22.HorizontalAlignment = 0;
            cell2ModeleNotQualGroup22.BorderWidthBottom = 1;
            cell2ModeleNotQualGroup22.BorderWidthLeft = 1;
            cell2ModeleNotQualGroup22.BorderWidthTop = 1;
            cell2ModeleNotQualGroup22.BorderColor = new BaseColor(208, 211, 212);
            cell2ModeleNotQualGroup22.BorderWidthRight = 1;
            cell2ModeleNotQualGroup22.Bottom = 3f;
            tableModeleNotGroup.AddCell(cell2ModeleNotQualGroup22);

            PdfPCell cell2ModeleNotQualGroup23 = new PdfPCell(new Phrase(ScoreQualit, normalFont2));
            cell2ModeleNotQualGroup23.PaddingLeft = 3f;
            cell2ModeleNotQualGroup23.UseVariableBorders = true;
            cell2ModeleNotQualGroup23.PaddingTop = 2f;
            cell2ModeleNotQualGroup23.PaddingBottom = 5f;
            cell2ModeleNotQualGroup23.HorizontalAlignment = 0;
            cell2ModeleNotQualGroup23.BorderWidthBottom = 1;
            cell2ModeleNotQualGroup23.BorderWidthLeft = 1;
            cell2ModeleNotQualGroup23.BorderWidthTop = 1;
            cell2ModeleNotQualGroup23.BorderColor = new BaseColor(208, 211, 212);
            cell2ModeleNotQualGroup23.BorderWidthRight = 1;
            cell2ModeleNotQualGroup23.Bottom = 3f;
            tableModeleNotGroup.AddCell(cell2ModeleNotQualGroup23);

            PdfPCell cell1ModeleNotQualGroup44 = new PdfPCell(new Phrase("Note Groupe", boldFont2));
            cell1ModeleNotQualGroup44.PaddingLeft = 10f;
            cell1ModeleNotQualGroup44.PaddingTop = 2f;
            cell1ModeleNotQualGroup44.PaddingBottom = 5f;
            cell1ModeleNotQualGroup44.UseVariableBorders = true;
            cell1ModeleNotQualGroup44.BorderWidthBottom = 1;
            cell1ModeleNotQualGroup44.BorderWidthLeft = 1;
            cell1ModeleNotQualGroup44.BorderWidthTop = 1;
            cell1ModeleNotQualGroup44.BackgroundColor = new BaseColor(228, 235, 245);
            cell1ModeleNotQualGroup44.BorderColor = new BaseColor(208, 211, 212);
            cell1ModeleNotQualGroup44.BorderWidthRight = 1;
            tableModeleNotGroup.AddCell(cell1ModeleNotQualGroup44);


            PdfPCell cell2ModeleNotQualGroup34 = new PdfPCell(new Phrase(groupe, normalFont2));
            cell2ModeleNotQualGroup34.PaddingLeft = 3f;
            cell2ModeleNotQualGroup34.UseVariableBorders = true;
            cell2ModeleNotQualGroup34.PaddingTop = 2f;
            cell2ModeleNotQualGroup34.PaddingBottom = 5f;
            cell2ModeleNotQualGroup34.HorizontalAlignment = 0;
            cell2ModeleNotQualGroup34.BorderWidthBottom = 1;
            cell2ModeleNotQualGroup34.BorderWidthLeft = 1;
            cell2ModeleNotQualGroup34.BorderWidthTop = 1;
            cell2ModeleNotQualGroup34.BorderColor = new BaseColor(208, 211, 212);
            cell2ModeleNotQualGroup34.BorderWidthRight = 1;
            cell2ModeleNotQualGroup34.Bottom = 3f;
            tableModeleNotGroup.AddCell(cell2ModeleNotQualGroup34);

            PdfPCell cell2ModeleNotQualGroup33 = new PdfPCell(new Phrase("", normalFont2));
            cell2ModeleNotQualGroup33.PaddingLeft = 3f;
            cell2ModeleNotQualGroup33.UseVariableBorders = true;
            cell2ModeleNotQualGroup33.PaddingTop = 2f;
            cell2ModeleNotQualGroup33.PaddingBottom = 5f;
            cell2ModeleNotQualGroup33.HorizontalAlignment = 0;
            cell2ModeleNotQualGroup33.BorderWidthBottom = 1;
            cell2ModeleNotQualGroup33.BorderWidthLeft = 1;
            cell2ModeleNotQualGroup33.BorderWidthTop = 1;
            cell2ModeleNotQualGroup33.BorderColor = new BaseColor(208, 211, 212);
            cell2ModeleNotQualGroup33.BorderWidthRight = 1;
            cell2ModeleNotQualGroup33.Bottom = 3f;
            tableModeleNotGroup.AddCell(cell2ModeleNotQualGroup33);

            PdfPCell cell3ModeleNotQual = new PdfPCell(new Phrase("Note Intrinsèque", boldFont2));
            cell3ModeleNotQual.PaddingLeft = 10f;
            cell3ModeleNotQual.PaddingTop = 2f;
            cell3ModeleNotQual.PaddingBottom = 5f;
            cell3ModeleNotQual.UseVariableBorders = true;
            cell3ModeleNotQual.BorderWidthBottom = 1;
            cell3ModeleNotQual.BorderWidthLeft = 1;
            cell3ModeleNotQual.BorderWidthTop = 1;
            cell3ModeleNotQual.BackgroundColor = new BaseColor(228, 235, 245);
            cell3ModeleNotQual.BorderColor = new BaseColor(208, 211, 212);
            cell3ModeleNotQual.BorderWidthRight = 1;
            tableModeleNotGroup.AddCell(cell3ModeleNotQual);

            PdfPCell cell4ModeleNotQual = new PdfPCell(new Phrase(NICalculee, normalFont2));
            cell4ModeleNotQual.PaddingLeft = 3f;
            cell4ModeleNotQual.UseVariableBorders = true;
            cell4ModeleNotQual.PaddingTop = 2f;
            cell4ModeleNotQual.PaddingBottom = 5f;
            cell4ModeleNotQual.HorizontalAlignment = 0;
            cell4ModeleNotQual.BorderWidthBottom = 1;
            cell4ModeleNotQual.BorderWidthLeft = 1;
            cell4ModeleNotQual.BorderWidthTop = 1;
            cell4ModeleNotQual.BorderColor = new BaseColor(208, 211, 212);
            cell4ModeleNotQual.BorderWidthRight = 1;
            cell4ModeleNotQual.Bottom = 3f;
            tableModeleNotGroup.AddCell(cell4ModeleNotQual);

            PdfPCell cell6ModeleNotQual = new PdfPCell(new Phrase("", normalFont2));
            cell6ModeleNotQual.PaddingLeft = 3f;
            cell6ModeleNotQual.UseVariableBorders = true;
            cell6ModeleNotQual.PaddingTop = 2f;
            cell6ModeleNotQual.PaddingBottom = 5f;
            cell6ModeleNotQual.HorizontalAlignment = 0;
            cell6ModeleNotQual.BorderWidthBottom = 1;
            cell6ModeleNotQual.BorderWidthLeft = 1;
            cell6ModeleNotQual.BorderWidthTop = 1;
            cell6ModeleNotQual.BorderColor = new BaseColor(208, 211, 212);
            cell6ModeleNotQual.BorderWidthRight = 1;
            cell6ModeleNotQual.Bottom = 3f;
            tableModeleNotGroup.AddCell(cell6ModeleNotQual);

            PdfPCell cell7ModeleSignature = new PdfPCell(new Phrase("Signature", boldFont22));
            cell7ModeleSignature.Colspan = 3;
            cell7ModeleSignature.PaddingLeft = 10f;
            cell7ModeleSignature.PaddingTop = 2f;
            cell7ModeleSignature.PaddingBottom = 20f;
            cell7ModeleSignature.UseVariableBorders = true;
            cell7ModeleSignature.BorderWidthBottom = 0;
            cell7ModeleSignature.BorderWidthLeft = 1;
            cell7ModeleSignature.BorderWidthTop = 0;
            cell7ModeleSignature.BackgroundColor = new BaseColor(255, 255, 255);
            cell7ModeleSignature.BorderColor = new BaseColor(255, 255, 255);
            cell7ModeleSignature.BorderWidthRight = 1;
            tableModeleNotGroup.AddCell(cell7ModeleSignature);
            string mo = "MOODY'S";
            if (pays.Trim() == "NC")
            {
                mo = "";
            }

            PdfPCell cell7ModeleSignature4 = new PdfPCell(new Phrase("Note Pays", boldFont21));
            cell7ModeleSignature4.PaddingLeft = 10f;
            cell7ModeleSignature4.PaddingTop = 2f;
            cell7ModeleSignature4.PaddingBottom = 10f;
            cell7ModeleSignature4.UseVariableBorders = true;
            cell7ModeleSignature4.BorderWidthBottom = 1;
            cell7ModeleSignature4.HorizontalAlignment = 1;
            cell7ModeleSignature4.BorderWidthLeft = 1;
            cell7ModeleSignature4.BorderWidthTop = 0;
            cell7ModeleSignature4.BackgroundColor = new BaseColor(255, 255, 255);
            cell7ModeleSignature4.BorderColor = new BaseColor(255, 255, 255);
            cell7ModeleSignature4.BorderWidthRight = 0;
            tableModeleNotGroup.AddCell(cell7ModeleSignature4);

            

            PdfPCell cell7ModeleSignature5 = new PdfPCell(new Phrase(pays, boldFont21));
            cell7ModeleSignature5.PaddingLeft = 10f;
            cell7ModeleSignature5.PaddingTop = 2f;
            cell7ModeleSignature5.PaddingBottom = 10f;
            cell7ModeleSignature5.UseVariableBorders = true;
            cell7ModeleSignature5.BorderWidthBottom = 0;
            cell7ModeleSignature5.HorizontalAlignment = 0;
            cell7ModeleSignature5.BorderWidthLeft = 0;
            cell7ModeleSignature5.BorderWidthTop = 0;
            cell7ModeleSignature5.BackgroundColor = new BaseColor(255, 255, 255);
            cell7ModeleSignature5.BorderColor = new BaseColor(255, 255, 255);
            cell7ModeleSignature5.BorderWidthRight = 0;
            tableModeleNotGroup.AddCell(cell7ModeleSignature5);

            PdfPCell cell7ModeleSignature6 = new PdfPCell(new Phrase(mo, boldFont21));
            cell7ModeleSignature6.PaddingLeft = 10f;
            cell7ModeleSignature6.PaddingTop = 2f;
            cell7ModeleSignature6.PaddingBottom = 10f;
            cell7ModeleSignature6.UseVariableBorders = true;
            cell7ModeleSignature6.BorderWidthBottom = 1;
            cell7ModeleSignature6.BorderWidthLeft = 0;
            cell7ModeleSignature6.BorderWidthTop = 0;
            cell7ModeleSignature6.BackgroundColor = new BaseColor(255, 255, 255);
            cell7ModeleSignature6.BorderColor = new BaseColor(255, 255, 255);
            cell7ModeleSignature6.BorderWidthRight = 0;
            tableModeleNotGroup.AddCell(cell7ModeleSignature6);
        }
        public void InfoPays()
        {
            if (AdireExpert.Trim() != "")
            {
                MAnalyse = AdireExpert;
            }
            Font boldFont2 = new Font(Font.FontFamily.TIMES_ROMAN, 9, Font.BOLD, BaseColor.BLACK);
            Font boldFont22 = new Font(Font.FontFamily.TIMES_ROMAN, 9, Font.BOLD, BaseColor.WHITE);
            Font normalFont2 = new Font(Font.FontFamily.TIMES_ROMAN, 9, Font.ITALIC, BaseColor.BLACK);
            var boldFontTitle = FontFactory.GetFont("palatino linotype", BaseFont.CP1252, BaseFont.EMBEDDED, 14, Font.BOLD);
            var titleFont = FontFactory.GetFont("Segoe UI", 9, BaseColor.WHITE);


            //relative col widths in proportions - 1/3 and 2/3
            tableModeleNotPays.TotalWidth = 500f;
            tableModeleNotPays.PaddingTop = 5f;
            //fix the absolute width of the table
            tableModeleNotPays.LockedWidth = true;
            //relative col widths in proportions - 1/3 and 2/3
            float[] widthstablequalital2 = new float[] { 5f, 2f, 2f, 3f };
            tableModeleNotPays.SetWidths(widthstablequalital2);
            tableModeleNotPays.HorizontalAlignment = 1;
            string LIBELLE_REPONSE = "fff";

            Chunk valider = new Chunk("Validation", FontFactory.GetFont("palatino linotype", BaseFont.CP1252, BaseFont.EMBEDDED, 14, Font.ITALIC));
            valider.SetUnderline(2, -3);
            Phrase p2 = new Phrase();
            p2.Add(valider);
            Paragraph p = new Paragraph(p2);

            PdfPCell cell1TitrOpe = new PdfPCell(p);
            cell1TitrOpe.PaddingLeft = 10f;
            cell1TitrOpe.PaddingTop = 2f;
            cell1TitrOpe.Colspan = 4;
            cell1TitrOpe.PaddingBottom = 5f;
            cell1TitrOpe.UseVariableBorders = true;
            cell1TitrOpe.BorderWidthBottom = 0;
            cell1TitrOpe.BorderWidthLeft = 0;
            cell1TitrOpe.BorderWidthTop = 0;
            //cell1TitrOpe.BackgroundColor = new BaseColor(228, 235, 245);
            cell1TitrOpe.BorderColor = new BaseColor(255, 255, 255);
            cell1TitrOpe.BorderWidthRight = 0;
            cell1TitrOpe.HorizontalAlignment = 1;
            tableModeleNotPays.AddCell(cell1TitrOpe);

            PdfPCell cell1TitreBlabc = new PdfPCell(new Phrase("vide", boldFont22));
            cell1TitreBlabc.PaddingLeft = 10f;
            cell1TitreBlabc.PaddingTop = 2f;
            cell1TitreBlabc.Colspan = 4;
            cell1TitreBlabc.PaddingBottom = 5f;
            cell1TitreBlabc.UseVariableBorders = true;
            cell1TitreBlabc.BorderWidthBottom = 0;
            cell1TitreBlabc.BorderWidthLeft = 0;
            cell1TitreBlabc.BorderWidthTop = 0;
            //cell1ModeleNotQual.BackgroundColor = new BaseColor(228, 235, 245);
            cell1TitreBlabc.BorderColor = new BaseColor(255, 255, 255);
            cell1TitreBlabc.BorderWidthRight = 0;
            tableModeleNotPays.AddCell(cell1TitreBlabc);
            //#########################################
            //##OSCAR 2019_10_08#######################
            //#########################################
            var Organe = "";
            var Délégataire = "";
            PdfPCell cell1ModeleNotQualDElegation = new PdfPCell(new Phrase("Organe de délégation", boldFont2));
            cell1ModeleNotQualDElegation.PaddingLeft = 10f;
            cell1ModeleNotQualDElegation.PaddingTop = 2f;
            cell1ModeleNotQualDElegation.PaddingBottom = 5f;
            cell1ModeleNotQualDElegation.UseVariableBorders = true;
            cell1ModeleNotQualDElegation.BorderWidthBottom = 1;
            cell1ModeleNotQualDElegation.BorderWidthLeft = 1;
            cell1ModeleNotQualDElegation.BorderWidthTop = 1;
            cell1ModeleNotQualDElegation.BackgroundColor = new BaseColor(228, 235, 245);
            cell1ModeleNotQualDElegation.BorderColor = new BaseColor(208, 211, 212);
            cell1ModeleNotQualDElegation.BorderWidthRight = 1;
            tableModeleNotPays.AddCell(cell1ModeleNotQualDElegation);


            var titi = 0;
            var id_dossier = Request.QueryString["id"].Trim();
            if (DataManager.Ps_scor_get_seuil_dossier(id_dossier.Trim()).Count != 0)
                titi = DataManager.Ps_scor_get_seuil_dossier(id_dossier.Trim())[0].ID_SCOR_SEUIL_DELEGUATION;
            else titi = 0;

            //var param = ScorCryptage.Decrypt(Session["code_banque"].ToString());
            var reponses = DataManager.ListeDecSpecif2(0, titi, "", code_banque);
            foreach (var reponse in reponses)
            {
                //if (reponse.ID_QUESTION != null)
                // if (reponse.ID_QUESTION.Trim() == question.ID_QUESTION.Trim())
                Organe += " " + reponse.LIBELLE_SCOR_DELEGATION + "; ";

                var ListeUtilisateurDec = DataManager.ListeUtilisateurDec(reponse.ID_SCOR_DELEGATION, code_banque);
                if (ListeUtilisateurDec.Count != 0)
                {
                    foreach (var uti in ListeUtilisateurDec)
                    {
                        Délégataire += "" + uti.NOM_USER.ToUpper() + " " + uti.PRENOM_USER + "; ";
                    }
                }

            }



            //var idDossier = Session["id_dossier"].ToString();
            //var param = ScorCryptage.Decrypt(Session["code_banque"].ToString());
            //var reponses = DataManager.ListeDecSpecif2(1,0,idDossier.ToString(), param);
            //foreach (var reponse in reponses)
            //{
            //    Organe += " " + reponse.LIBELLE_SCOR_DELEGATION + "; ";
            //    var ListeUtilisateurDec = DataManager.ListeUtilisateurDec(reponse.ID_SCOR_DELEGATION, param);
            //    if (ListeUtilisateurDec.Count != 0)
            //    {
            //        foreach (var uti in ListeUtilisateurDec)
            //        {
            //            Délégataire += "" + uti.NOM_USER.ToUpper() + " " + uti.PRENOM_USER + "; ";
            //        }
            //    }
            //}

            cell1ModeleNotQualDElegation.Phrase = new Phrase(Organe, boldFont2);
            cell1ModeleNotQualDElegation.Colspan = 3;
            cell1ModeleNotQualDElegation.BackgroundColor = new BaseColor(255, 255, 255);
            tableModeleNotPays.AddCell(cell1ModeleNotQualDElegation);

            

            cell1ModeleNotQualDElegation.Phrase = new Phrase("Délégataire (s) :", boldFont2);
            cell1ModeleNotQualDElegation.Colspan = 1; 
            cell1ModeleNotQualDElegation.BackgroundColor = new BaseColor(228, 235, 245);
            tableModeleNotPays.AddCell(cell1ModeleNotQualDElegation);


            cell1ModeleNotQualDElegation.Phrase = new Phrase(Délégataire, boldFont2);
            cell1ModeleNotQualDElegation.Colspan = 3;
            cell1ModeleNotQualDElegation.BackgroundColor = new BaseColor(255, 255, 255);
            tableModeleNotPays.AddCell(cell1ModeleNotQualDElegation);

            PdfPCell cell1ModeleNotQualDElegationBanc = new PdfPCell(new Phrase("vide", boldFont22));
            cell1ModeleNotQualDElegationBanc.PaddingLeft = 10f;
            cell1ModeleNotQualDElegationBanc.PaddingTop = 2f;
            cell1ModeleNotQualDElegationBanc.Colspan = 4;
            cell1ModeleNotQualDElegationBanc.PaddingBottom = 5f;
            cell1ModeleNotQualDElegationBanc.UseVariableBorders = true;
            cell1ModeleNotQualDElegationBanc.BorderWidthBottom = 0;
            cell1ModeleNotQualDElegationBanc.BorderWidthLeft = 0;
            cell1ModeleNotQualDElegationBanc.BorderWidthTop = 0;
            cell1ModeleNotQualDElegationBanc.BorderColor = new BaseColor(255, 255, 255);
            cell1ModeleNotQualDElegationBanc.BorderWidthRight = 0;
            tableModeleNotPays.AddCell(cell1ModeleNotQualDElegationBanc);


            //#########################################
            //##OSCAR 2019_10_08#######################
            //#########################################
            PdfPCell cell1ModeleNotQual = new PdfPCell(new Phrase("vide", boldFont22));
            cell1ModeleNotQual.PaddingLeft = 10f;
            cell1ModeleNotQual.PaddingTop = 2f;
            cell1ModeleNotQual.PaddingBottom = 5f;
            cell1ModeleNotQual.UseVariableBorders = true;
            cell1ModeleNotQual.BorderWidthBottom = 0;
            cell1ModeleNotQual.BorderWidthLeft = 0;
            cell1ModeleNotQual.BorderWidthTop = 0;
            //cell1ModeleNotQual.BackgroundColor = new BaseColor(228, 235, 245);
            cell1ModeleNotQual.BorderColor = new BaseColor(255, 255, 255);
            cell1ModeleNotQual.BorderWidthRight = 0;
            tableModeleNotPays.AddCell(cell1ModeleNotQual);

            PdfPCell cell1ModeleNotQualGroup = new PdfPCell(new Phrase("Note", boldFont2));
            cell1ModeleNotQualGroup.PaddingLeft = 10f;
            cell1ModeleNotQualGroup.PaddingTop = 2f;
            cell1ModeleNotQualGroup.PaddingBottom = 5f;
            cell1ModeleNotQualGroup.UseVariableBorders = true;
            cell1ModeleNotQualGroup.BorderWidthBottom = 1;
            cell1ModeleNotQualGroup.BorderWidthLeft = 1;
            cell1ModeleNotQualGroup.BorderWidthTop = 1;
            cell1ModeleNotQualGroup.BackgroundColor = new BaseColor(228, 235, 245);
            cell1ModeleNotQualGroup.BorderColor = new BaseColor(208, 211, 212);
            cell1ModeleNotQualGroup.BorderWidthRight = 1;
            tableModeleNotPays.AddCell(cell1ModeleNotQualGroup);

            PdfPCell cell2ModeleNotQualGroup1 = new PdfPCell(new Phrase("Date", boldFont2));
            cell2ModeleNotQualGroup1.PaddingLeft = 10f;
            cell2ModeleNotQualGroup1.PaddingTop = 2f;
            cell2ModeleNotQualGroup1.PaddingBottom = 5f;
            cell2ModeleNotQualGroup1.UseVariableBorders = true;
            cell2ModeleNotQualGroup1.BorderWidthBottom = 1;
            cell2ModeleNotQualGroup1.BorderWidthLeft = 1;
            cell2ModeleNotQualGroup1.BorderWidthTop = 1;
            cell2ModeleNotQualGroup1.BackgroundColor = new BaseColor(228, 235, 245);
            cell2ModeleNotQualGroup1.BorderColor = new BaseColor(208, 211, 212);
            cell2ModeleNotQualGroup1.BorderWidthRight = 1;
            tableModeleNotPays.AddCell(cell2ModeleNotQualGroup1);

            PdfPCell cell1ModeleNotQualGroup1 = new PdfPCell(new Phrase("Utilisateur", boldFont2));
            cell1ModeleNotQualGroup1.PaddingLeft = 10f;
            cell1ModeleNotQualGroup1.PaddingTop = 2f;
            cell1ModeleNotQualGroup1.PaddingBottom = 5f;
            cell1ModeleNotQualGroup1.UseVariableBorders = true;
            cell1ModeleNotQualGroup1.BorderWidthBottom = 1;
            cell1ModeleNotQualGroup1.BorderWidthLeft = 1;
            cell1ModeleNotQualGroup1.BorderWidthTop = 1;
            cell1ModeleNotQualGroup1.BackgroundColor = new BaseColor(228, 235, 245);
            cell1ModeleNotQualGroup1.BorderColor = new BaseColor(208, 211, 212);
            cell1ModeleNotQualGroup1.BorderWidthRight = 1;
            tableModeleNotPays.AddCell(cell1ModeleNotQualGroup1);

            PdfPCell cell1ModeleNotQualGroup2 = new PdfPCell(new Phrase("Note Proposée", boldFont2));
            cell1ModeleNotQualGroup2.PaddingLeft = 10f;
            cell1ModeleNotQualGroup2.PaddingTop = 2f;
            cell1ModeleNotQualGroup2.PaddingBottom = 5f;
            cell1ModeleNotQualGroup2.UseVariableBorders = true;
            cell1ModeleNotQualGroup2.BorderWidthBottom = 1;
            cell1ModeleNotQualGroup2.BorderWidthLeft = 1;
            cell1ModeleNotQualGroup2.BorderWidthTop = 1;
            cell1ModeleNotQualGroup2.BackgroundColor = new BaseColor(228, 235, 245);
            cell1ModeleNotQualGroup2.BorderColor = new BaseColor(208, 211, 212);
            cell1ModeleNotQualGroup2.BorderWidthRight = 1;
            tableModeleNotPays.AddCell(cell1ModeleNotQualGroup2);


            PdfPCell cell2ModeleNotQualGroup2 = new PdfPCell(new Phrase(ScorePro, normalFont2));
            cell2ModeleNotQualGroup2.PaddingLeft = 3f;
            cell2ModeleNotQualGroup2.UseVariableBorders = true;
            cell2ModeleNotQualGroup2.PaddingTop = 2f;
            cell2ModeleNotQualGroup2.PaddingBottom = 5f;
            cell2ModeleNotQualGroup2.HorizontalAlignment = 0;
            cell2ModeleNotQualGroup2.BorderWidthBottom = 1;
            cell2ModeleNotQualGroup2.BorderWidthLeft = 1;
            cell2ModeleNotQualGroup2.BorderWidthTop = 1;
            cell2ModeleNotQualGroup2.BorderColor = new BaseColor(208, 211, 212);
            cell2ModeleNotQualGroup2.BorderWidthRight = 1;
            cell2ModeleNotQualGroup2.Bottom = 3f;
            tableModeleNotPays.AddCell(cell2ModeleNotQualGroup2);

            PdfPCell cell2ModeleNotQualGroup25 = new PdfPCell(new Phrase(datePro, normalFont2));
            cell2ModeleNotQualGroup25.PaddingLeft = 3f;
            cell2ModeleNotQualGroup25.UseVariableBorders = true;
            cell2ModeleNotQualGroup25.PaddingTop = 2f;
            cell2ModeleNotQualGroup25.PaddingBottom = 5f;
            cell2ModeleNotQualGroup25.HorizontalAlignment = 0;
            cell2ModeleNotQualGroup25.BorderWidthBottom = 1;
            cell2ModeleNotQualGroup25.BorderWidthLeft = 1;
            cell2ModeleNotQualGroup25.BorderWidthTop = 1;
            cell2ModeleNotQualGroup25.BorderColor = new BaseColor(208, 211, 212);
            cell2ModeleNotQualGroup25.BorderWidthRight = 1;
            cell2ModeleNotQualGroup25.Bottom = 3f;
            tableModeleNotPays.AddCell(cell2ModeleNotQualGroup25);

            PdfPCell cell3ModeleNotQualGroup25 = new PdfPCell(new Phrase(nom_user_editePRO, normalFont2));
            cell3ModeleNotQualGroup25.PaddingLeft = 3f;
            cell3ModeleNotQualGroup25.UseVariableBorders = true;
            cell3ModeleNotQualGroup25.PaddingTop = 2f;
            cell3ModeleNotQualGroup25.PaddingBottom = 5f;
            cell3ModeleNotQualGroup25.HorizontalAlignment = 0;
            cell3ModeleNotQualGroup25.BorderWidthBottom = 1;
            cell3ModeleNotQualGroup25.BorderWidthLeft = 1;
            cell3ModeleNotQualGroup25.BorderWidthTop = 1;
            cell3ModeleNotQualGroup25.BorderColor = new BaseColor(208, 211, 212);
            cell3ModeleNotQualGroup25.BorderWidthRight = 1;
            cell3ModeleNotQualGroup25.Bottom = 3f;
            tableModeleNotPays.AddCell(cell3ModeleNotQualGroup25);

            PdfPCell cell1ModeleNotQualGroup21 = new PdfPCell(new Phrase("Note Validée", boldFont2));
            cell1ModeleNotQualGroup21.PaddingLeft = 10f;
            cell1ModeleNotQualGroup21.PaddingTop = 2f;
            cell1ModeleNotQualGroup21.PaddingBottom = 5f;
            cell1ModeleNotQualGroup21.UseVariableBorders = true;
            cell1ModeleNotQualGroup21.BorderWidthBottom = 0;
            cell1ModeleNotQualGroup21.BorderWidthLeft = 1;
            cell1ModeleNotQualGroup21.BorderWidthTop = 1;
            cell1ModeleNotQualGroup21.BackgroundColor = new BaseColor(228, 235, 245);
            cell1ModeleNotQualGroup21.BorderColor = new BaseColor(208, 211, 212);
            cell1ModeleNotQualGroup21.BorderWidthRight = 1;
            tableModeleNotPays.AddCell(cell1ModeleNotQualGroup21);
            string scorvalidate = "";
            string signifivalidate = "";
            if (ScoreVal.Trim() == "A+")
            {
                scorvalidate = "[18 - 20]";
                signifivalidate = "Crédit dont le risque est quasi nul. Signature d’excellente qualité avec une capacité extrêmement forte à honorer le service de la dette.";
            }
            if (ScoreVal.Trim() == "A")
            {
                scorvalidate = "[16 - 18]";
                signifivalidate = "Crédit à risque minimal. Signature d’excellente qualité avec une capacité forte à honorer le service de la dette.";
            }
            if (ScoreVal.Trim() == "A-")
            {
                scorvalidate = "[14 - 16]";
                signifivalidate = "Crédit à très faible risque. Signature de très bonne qualité avec une capacité forte à honorer le service de la dette.";
            }
            if (ScoreVal.Trim() == "B+")
            {
                scorvalidate = "[13 - 14]";
                signifivalidate = "Crédit à faible risque. Signature de bonne qualité avec une très bonne capacité à honorer le service de la dette.";
            }
            if (ScoreVal.Trim() == "B")
            {
                scorvalidate = "[12 - 13]";
                signifivalidate = "Crédit de qualité satisfaisante. Signature de qualité satisfaisante avec une bonne capacité à honorer le service de la dette.";
            }
            if (ScoreVal.Trim() == "B-")
            {
                scorvalidate = "[11 - 12]";
                signifivalidate = "Crédit de qualité acceptable. Signature de qualité acceptable avec une relative capacité à honorer le service de la dette.";
            }
            if (ScoreVal.Trim() == "C+")
            {
                scorvalidate = "[09 - 11]";
                signifivalidate = "Crédit de qualité acceptable mais démontrant des signes de faiblesse avec probabilité de dégradation. Signature de qualité passable.";
            }
            if (ScoreVal.Trim() == "C")
            {
                scorvalidate = "[07 - 09]";
                signifivalidate = "Crédit impayé ou immobilisé, crédit à surveiller de près. Signature de qualité médiocre.";
            }
            if (ScoreVal.Trim() == "C-")
            {
                scorvalidate = "[05 - 07]";
                signifivalidate = "Crédit douteur avec garanties réelles certaines mais avec probabilité de perte. Signature de qualité médiocre.";
            }
            if (ScoreVal.Trim() == "D")
            {
                scorvalidate = "[00 - 05]";
                signifivalidate = "Crédit douteux sans garanties réelles, perte certaines. Signature de mauvaise qualité.";
            }
            PdfPCell cell2ModeleNotQualGroup22 = new PdfPCell(new Phrase(ScoreVal, normalFont2));
            cell2ModeleNotQualGroup22.PaddingLeft = 3f;
            cell2ModeleNotQualGroup22.UseVariableBorders = true;
            cell2ModeleNotQualGroup22.PaddingTop = 2f;
            cell2ModeleNotQualGroup22.PaddingBottom = 5f;
            cell2ModeleNotQualGroup22.HorizontalAlignment = 0;
            cell2ModeleNotQualGroup22.BorderWidthBottom = 1;
            cell2ModeleNotQualGroup22.BorderWidthLeft = 1;
            cell2ModeleNotQualGroup22.BorderWidthTop = 1;
            cell2ModeleNotQualGroup22.BorderColor = new BaseColor(208, 211, 212);
            cell2ModeleNotQualGroup22.BorderWidthRight = 1;
            cell2ModeleNotQualGroup22.Bottom = 3f;
            tableModeleNotPays.AddCell(cell2ModeleNotQualGroup22);

            PdfPCell cell2ModeleNotQualGroup23 = new PdfPCell(new Phrase(dateRe, normalFont2));
            cell2ModeleNotQualGroup23.PaddingLeft = 3f;
            cell2ModeleNotQualGroup23.UseVariableBorders = true;
            cell2ModeleNotQualGroup23.PaddingTop = 2f;
            cell2ModeleNotQualGroup23.PaddingBottom = 5f;
            cell2ModeleNotQualGroup23.HorizontalAlignment = 0;
            cell2ModeleNotQualGroup23.BorderWidthBottom = 1;
            cell2ModeleNotQualGroup23.BorderWidthLeft = 1;
            cell2ModeleNotQualGroup23.BorderWidthTop = 1;
            cell2ModeleNotQualGroup23.BorderColor = new BaseColor(208, 211, 212);
            cell2ModeleNotQualGroup23.BorderWidthRight = 1;
            cell2ModeleNotQualGroup23.Bottom = 3f;
            tableModeleNotPays.AddCell(cell2ModeleNotQualGroup23);

            PdfPCell cell2ModeleNotQualGroup34 = new PdfPCell(new Phrase(nom_user_edite, normalFont2));
            cell2ModeleNotQualGroup34.PaddingLeft = 3f;
            cell2ModeleNotQualGroup34.UseVariableBorders = true;
            cell2ModeleNotQualGroup34.PaddingTop = 2f;
            cell2ModeleNotQualGroup34.PaddingBottom = 5f;
            cell2ModeleNotQualGroup34.HorizontalAlignment = 0;
            cell2ModeleNotQualGroup34.BorderWidthBottom = 1;
            cell2ModeleNotQualGroup34.BorderWidthLeft = 1;
            cell2ModeleNotQualGroup34.BorderWidthTop = 1;
            cell2ModeleNotQualGroup34.BorderColor = new BaseColor(208, 211, 212);
            cell2ModeleNotQualGroup34.BorderWidthRight = 1;
            cell2ModeleNotQualGroup34.Bottom = 3f;
            tableModeleNotPays.AddCell(cell2ModeleNotQualGroup34);

            PdfPCell cell1ModeleNotQualcooll = new PdfPCell(new Phrase("", boldFont22));
            cell1ModeleNotQualcooll.PaddingLeft = 10f;
            cell1ModeleNotQualcooll.PaddingTop = 2f;
            cell1ModeleNotQualcooll.PaddingBottom = 5f;
            cell1ModeleNotQualcooll.UseVariableBorders = true;
            cell1ModeleNotQualcooll.BorderWidthBottom = 0;
            cell1ModeleNotQualcooll.BorderWidthLeft = 1;
            cell1ModeleNotQualcooll.BorderWidthTop = 0;
            cell1ModeleNotQualcooll.BackgroundColor = new BaseColor(228, 235, 245);
            cell1ModeleNotQualcooll.BorderColor = new BaseColor(208, 211, 212);
            cell1ModeleNotQualcooll.BorderWidthRight = 1;
            tableModeleNotPays.AddCell(cell1ModeleNotQualcooll);

            PdfPCell cell1ModeleNotQualcool1de = new PdfPCell(new Phrase("Score :  " + scorvalidate, boldFont2));
            cell1ModeleNotQualcool1de.Colspan = 3;
            cell1ModeleNotQualcool1de.PaddingLeft = 10f;
            cell1ModeleNotQualcool1de.PaddingTop = 2f;
            cell1ModeleNotQualcool1de.PaddingBottom = 5f;
            cell1ModeleNotQualcool1de.UseVariableBorders = true;
            cell1ModeleNotQualcool1de.BorderWidthBottom = 0;
            cell1ModeleNotQualcool1de.BorderWidthLeft = 1;
            cell1ModeleNotQualcool1de.BorderWidthTop = 0;
            //cell1ModeleNotQual.BackgroundColor = new BaseColor(228, 235, 245);
            cell1ModeleNotQualcool1de.BorderColor = new BaseColor(208, 211, 212);
            cell1ModeleNotQualcool1de.BorderWidthRight = 1;
            tableModeleNotPays.AddCell(cell1ModeleNotQualcool1de);

            PdfPCell cell1ModeleNotQualcoolde = new PdfPCell(new Phrase("", boldFont22));
            cell1ModeleNotQualcoolde.PaddingLeft = 10f;
            cell1ModeleNotQualcoolde.PaddingTop = 2f;
            cell1ModeleNotQualcoolde.PaddingBottom = 5f;
            cell1ModeleNotQualcoolde.UseVariableBorders = true;
            cell1ModeleNotQualcoolde.BorderWidthBottom = 1;
            cell1ModeleNotQualcoolde.BorderWidthLeft = 1;
            cell1ModeleNotQualcoolde.BorderWidthTop = 0;
            cell1ModeleNotQualcoolde.BackgroundColor = new BaseColor(228, 235, 245);
            cell1ModeleNotQualcoolde.BorderColor = new BaseColor(208, 211, 212);
            cell1ModeleNotQualcoolde.BorderWidthRight = 1;
            tableModeleNotPays.AddCell(cell1ModeleNotQualcoolde);

            PdfPCell cell1ModeleNotQualcool1ser = new PdfPCell(new Phrase(signifivalidate, boldFont2));
            cell1ModeleNotQualcool1ser.Colspan = 3;
            cell1ModeleNotQualcool1ser.PaddingLeft = 10f;
            cell1ModeleNotQualcool1ser.PaddingTop = 2f;
            cell1ModeleNotQualcool1ser.PaddingBottom = 5f;
            cell1ModeleNotQualcool1ser.UseVariableBorders = true;
            cell1ModeleNotQualcool1ser.BorderWidthBottom = 1;
            cell1ModeleNotQualcool1ser.BorderWidthLeft = 1;
            cell1ModeleNotQualcool1ser.BorderWidthTop = 0;
            //cell1ModeleNotQual.BackgroundColor = new BaseColor(228, 235, 245);
            cell1ModeleNotQualcool1ser.BorderColor = new BaseColor(208, 211, 212);
            cell1ModeleNotQualcool1ser.BorderWidthRight = 1;
            tableModeleNotPays.AddCell(cell1ModeleNotQualcool1ser);

        }
        private void AnalyseStructurellegroupe()
        {
            if (AdireExpert.Trim() != "")
            {
                MAnalyse = AdireExpert;
            }
            var palatino = FontFactory.GetFont("palatino linotype", BaseFont.CP1252, BaseFont.EMBEDDED, 9, Font.BOLD);
            var boldFont = FontFactory.GetFont("palatino linotype", BaseFont.CP1252, BaseFont.EMBEDDED, 12, Font.BOLD);
            var italicfont = FontFactory.GetFont("palatino linotype", BaseFont.CP1252, BaseFont.EMBEDDED, 9, Font.ITALIC);
            var boldFontTitle = FontFactory.GetFont("palatino linotype", BaseFont.CP1252, BaseFont.EMBEDDED, 14, Font.BOLD);
            var titleFont = FontFactory.GetFont("Segoe UI", 9, BaseColor.WHITE);

            Font boldFont2 = new Font(Font.FontFamily.TIMES_ROMAN, 9, Font.BOLD, BaseColor.BLACK);
            Font boldFont22 = new Font(Font.FontFamily.TIMES_ROMAN, 9, Font.BOLD, BaseColor.WHITE);
            Font normalFont2 = new Font(Font.FontFamily.TIMES_ROMAN, 9, Font.ITALIC, BaseColor.BLACK);


            tablequalitalStructurelle.TotalWidth = 500f;
            tablequalitalStructurelle.PaddingTop = 5f;
            //fix the absolute width of the table
            tablequalitalStructurelle.LockedWidth = true;
            //relative col widths in proportions - 1/3 and 2/3
            float[] widthstablequalital = new float[] { 4f, 4f, 4f, 4f };
            tablequalitalStructurelle.SetWidths(widthstablequalital);
            tablequalitalStructurelle.HorizontalAlignment = 1;
            //Session.Add("id_dossier", "1");
            //if (Session["id_dossier"] == null) Response.Redirect("~/Scoring/Connexion.aspx");
            PdfPCell cell1qualital1Str = new PdfPCell(new Phrase("Filiale", boldFont2));
            //cell1qualital1Str.Colspan = 2;
            cell1qualital1Str.HorizontalAlignment = 1;
            cell1qualital1Str.UseVariableBorders = true;
            cell1qualital1Str.BorderWidth = 1;
            cell1qualital1Str.BackgroundColor = new BaseColor(228, 235, 245);
            cell1qualital1Str.BorderColor = new BaseColor(208, 211, 212);
            cell1qualital1Str.PaddingBottom = 5f;
            tablequalitalStructurelle.AddCell(cell1qualital1Str);

            PdfPCell cell1qualital2Str = new PdfPCell(new Phrase("Note Retenue", boldFont2));
            //cell1qualital2Str.Colspan = 2;
            cell1qualital2Str.HorizontalAlignment = 1;
            cell1qualital2Str.UseVariableBorders = true;
            cell1qualital2Str.BorderWidth = 1;
            cell1qualital2Str.BackgroundColor = new BaseColor(228, 235, 245);
            cell1qualital2Str.BorderColor = new BaseColor(208, 211, 212);
            cell1qualital2Str.PaddingBottom = 5f;
            tablequalitalStructurelle.AddCell(cell1qualital2Str);

            PdfPCell cell1qualital3Str = new PdfPCell(new Phrase("Part en chiffre d'affaire ", boldFont2));
            //cell1qualital3Str.Colspan = 2;
            cell1qualital3Str.HorizontalAlignment = 1;
            cell1qualital3Str.UseVariableBorders = true;
            cell1qualital3Str.BorderWidth = 1;
            cell1qualital3Str.BackgroundColor = new BaseColor(228, 235, 245);
            cell1qualital3Str.BorderColor = new BaseColor(208, 211, 212);
            cell1qualital3Str.PaddingBottom = 5f;
            tablequalitalStructurelle.AddCell(cell1qualital3Str);

            PdfPCell cell1qualital4Str = new PdfPCell(new Phrase("Poids économique", boldFont2));
            //cell1qualital4Str.Colspan = 2;
            cell1qualital4Str.HorizontalAlignment = 1;
            cell1qualital4Str.UseVariableBorders = true;
            cell1qualital4Str.BorderWidth = 1;
            cell1qualital4Str.BackgroundColor = new BaseColor(228, 235, 245);
            cell1qualital4Str.BorderColor = new BaseColor(208, 211, 212);
            cell1qualital4Str.PaddingBottom = 5f;
            tablequalitalStructurelle.AddCell(cell1qualital4Str);

            //var idDossier = Session["id_dossier"].ToString();
            var idDossier =  Request.QueryString["id"].Trim();
            decimal CAtot = 0;
            decimal CAtotG = 0;
            var elements = service.InfoDossier(idDossier);
            foreach (var dossier in elements)
            {
                //ModeleNotation.Text = dossier.LIBELLE_MODELE;
                //NomGroupe.Text = dossier.GROUPE_DOSSIER;
                //NoteGroupe.Text = dossier.NOTE_GROUPE;
                //TNomGroupev.Text = dossier.NOTE_GROUPE;
                //TNomGroupe.Text = dossier.GROUPE_DOSSIER;
                StringBuilder sbFil = new StringBuilder();
                //if(dossier.NOTE_VAL != null)
                //{

                //NoteGROUPE.Text = dossier.NOTE_AQ;

                var totval = service.SelectvaldesFiliales(dossier.GROUPE_DOSSIER);

                decimal tauxtot = 0;
                foreach (var f in service.ListeFiliale(dossier.GROUPE_DOSSIER))
                {
                    decimal jiji = 0, tauxx = 0;
                    var restt = service.SelectvalFiliale(f.ID_DOSSIER);
                    if (restt != null)
                    {
                        if (restt != 0)
                        {
                            if (totval != 0)
                                tauxx = 100 * (1 - (restt / totval));
                        }
                        else tauxx = 0;
                    }
                    else tauxx = 0;

                    tauxtot = tauxtot + tauxx;

                    if (f.CA != null) if (f.CA.ToString() != "") CAtot = CAtot + Convert.ToDecimal(f.CA);
                }
                foreach (var f in service.ListeFiliale(dossier.GROUPE_DOSSIER))
                {
                    var tv = "__"; if (f.PRECEDENTE_NOTE != null && f.PRECEDENTE_NOTE != "") tv = f.PRECEDENTE_NOTE;
                    if (f.NOTE_VAL != null) if (f.PRECEDENTE_NOTE != f.NOTE_VAL) if (f.NOTE_VAL.Trim() != "") tv = tv + "&nbsp;&nbsp;&nbsp; <span class=\"glyphicon glyphicon-arrow-right danger\"></span>&nbsp;&nbsp;&nbsp; <b class='text-danger'>" + f.NOTE_VAL + "</b>";

                    //sbFil.AppendLine(string.Format("<li><span class='wrapper'><span class='border'>{0} : {1}</span></span></li>",
                    //    f.ETCIV_NOMREDUIT, tv));
                    //notifMessage.Visible = false;
                    //treeDiv.Visible = true;
                    //ListFiliale.InnerHtml = sbFil.ToString();

                    //f.ID_DOSSIER


                    decimal jiji = 0, tauxx = 0;
                    var restt12 = service.SelectvalFiliale(f.ID_DOSSIER);
                    if (restt12 != null)
                    {
                        if (restt12 != 0)
                        {
                            if (totval != 0)
                            {

                                if (restt12 == totval)
                                {
                                    tauxx = 100;
                                }
                                else
                                {
                                    if (tauxtot == 0) tauxtot = 1;
                                    tauxx = (100 * (1 - (restt12 / totval)) / tauxtot) * 100;
                                }
                            }

                        }
                        else tauxx = 0;
                    }
                    else tauxx = 0;
                    if (f.CA != null) if (f.CA.ToString() != "") if (CAtotG != null) if (CAtotG != 0) jiji = (Convert.ToDecimal(f.CA) / CAtotG) * 100;

                    PdfPCell cell2qualital = new PdfPCell(new Phrase(f.ETCIV_NOMREDUIT.ToString(), boldFont2));
                    cell2qualital.PaddingLeft = 10f;
                    cell2qualital.PaddingTop = 2f;
                    cell2qualital.PaddingBottom = 5f;
                    cell2qualital.UseVariableBorders = true;
                    cell2qualital.BorderWidthBottom = 1;
                    cell2qualital.BorderWidthLeft = 1;
                    cell2qualital.BorderWidthTop = 1;
                    cell2qualital.BorderColor = new BaseColor(208, 211, 212);
                    cell2qualital.BorderWidthRight = 1;
                    tablequalitalStructurelle.AddCell(cell2qualital);

                    PdfPCell cell2qualital1 = new PdfPCell(new Phrase(tv.ToString(), normalFont2));
                    cell2qualital1.HorizontalAlignment = 1;
                    cell2qualital1.PaddingTop = 2f;
                    cell2qualital1.PaddingBottom = 5f;
                    cell2qualital1.UseVariableBorders = true;
                    cell2qualital1.BorderWidthBottom = 1;
                    cell2qualital1.BorderWidthLeft = 1;
                    cell2qualital1.BorderWidthTop = 1;
                    cell2qualital1.BorderColor = new BaseColor(208, 211, 212);
                    cell2qualital1.BorderWidthRight = 1;
                    tablequalitalStructurelle.AddCell(cell2qualital1);

                    PdfPCell cell2qualital11 = new PdfPCell(new Phrase(jiji.ToString("00.00"), normalFont2));
                    cell2qualital11.HorizontalAlignment = 1;
                    cell2qualital11.PaddingTop = 2f;
                    cell2qualital11.PaddingBottom = 5f;
                    cell2qualital11.UseVariableBorders = true;
                    cell2qualital11.BorderWidthBottom = 1;
                    cell2qualital11.BorderWidthLeft = 1;
                    cell2qualital11.BorderWidthTop = 1;
                    cell2qualital11.BorderColor = new BaseColor(208, 211, 212);
                    cell2qualital11.BorderWidthRight = 1;
                    tablequalitalStructurelle.AddCell(cell2qualital11);

                    PdfPCell cell2qualital111 = new PdfPCell(new Phrase(tauxx.ToString("00.00"), normalFont2));
                    cell2qualital111.HorizontalAlignment = 1;
                    cell2qualital111.PaddingTop = 2f;
                    cell2qualital111.PaddingBottom = 5f;
                    cell2qualital111.UseVariableBorders = true;
                    cell2qualital111.BorderWidthBottom = 1;
                    cell2qualital111.BorderWidthLeft = 1;
                    cell2qualital111.BorderWidthTop = 1;
                    cell2qualital111.BorderColor = new BaseColor(208, 211, 212);
                    cell2qualital111.BorderWidthRight = 1;
                    tablequalitalStructurelle.AddCell(cell2qualital111);
                }
            }
        }
        public void OperationReponse()
        {

            var palatino = FontFactory.GetFont("palatino linotype", BaseFont.CP1252, BaseFont.EMBEDDED, 9, Font.BOLD);
            var boldFont = FontFactory.GetFont("palatino linotype", BaseFont.CP1252, BaseFont.EMBEDDED, 12, Font.BOLD);
            var italicfont = FontFactory.GetFont("palatino linotype", BaseFont.CP1252, BaseFont.EMBEDDED, 9, Font.ITALIC);
            var boldFontTitle = FontFactory.GetFont("palatino linotype", BaseFont.CP1252, BaseFont.EMBEDDED, 14, Font.BOLD);
            var titleFont = FontFactory.GetFont("Segoe UI", 9, BaseColor.WHITE);

            Font boldFont2 = new Font(Font.FontFamily.TIMES_ROMAN, 9, Font.BOLD, BaseColor.BLACK);
            Font boldFont22 = new Font(Font.FontFamily.TIMES_ROMAN, 9, Font.BOLD, BaseColor.WHITE);
            Font normalFont2 = new Font(Font.FontFamily.TIMES_ROMAN, 9, Font.ITALIC, BaseColor.BLACK);


            tableoperation.TotalWidth = 500f;
            tableoperation.PaddingTop = 5f;
            //fix the absolute width of the table
            tableoperation.LockedWidth = true;
            //relative col widths in proportions - 1/3 and 2/3
            float[] widthstablequalital = new float[] { 5f, 6f, 1f };
            tableoperation.SetWidths(widthstablequalital);
            tableoperation.HorizontalAlignment = 1;

            var idDossier1 = compar1;
            //if (Session["id_dossier"] == null) Response.Redirect("~/Scoring/Connexion.aspx");
            //else idDossier = Session["id_dossier"].ToString();
            //Session.Add("id_dossier", idDossier);

            var elements = _service.InfoDossier(idDossier1);
            // ITERATION CHAPITRES
            var chapitres = _service.ListeChapitre("ANAOPE");
            var i1 = 0;
            decimal tot = 0;
            foreach (var chapitre in chapitres)
            {
                PdfPCell cell1qualital = new PdfPCell(new Phrase(chapitre.LIBELLE_CHAPITRE, boldFont2));
                cell1qualital.Colspan = 2;
                cell1qualital.HorizontalAlignment = 1;
                cell1qualital.UseVariableBorders = true;
                cell1qualital.BorderWidth = 1;
                cell1qualital.BackgroundColor = new BaseColor(228, 235, 245);
                cell1qualital.BorderColor = new BaseColor(208, 211, 212);
                cell1qualital.PaddingBottom = 5f;
                tableoperation.AddCell(cell1qualital);

                PdfPCell cell1qualit21 = new PdfPCell(new Phrase("Points", boldFont2));
                cell1qualit21.Colspan = 2;
                cell1qualit21.HorizontalAlignment = 1;
                cell1qualit21.UseVariableBorders = true;
                cell1qualit21.BorderWidth = 1;
                cell1qualit21.BackgroundColor = new BaseColor(228, 235, 245);
                cell1qualit21.BorderColor = new BaseColor(208, 211, 212);
                cell1qualit21.PaddingBottom = 5f;
                tableoperation.AddCell(cell1qualit21);

                //s += "<div class='ln_chapitre col-md-12'>" + chapitre.LIBELLE_CHAPITRE + "</div>";

                // ITERATATION QUESTIONS
                var questions = _service.ListeQuestion(chapitre.CODE_CHAPITRE.Trim());

                foreach (var question in questions)
                {
                    if (question.LIBELLE_QUESTION.Trim() != "")
                    {
                        //s += "<div class='ln_question_reponse col-md-12' ><div class='ln_question col-md-6'>" + question.LIBELLE_QUESTION + "</div>";

                        PdfPCell cell2qualital = new PdfPCell(new Phrase(question.LIBELLE_QUESTION, boldFont2));
                        cell2qualital.PaddingLeft = 10f;
                        cell2qualital.PaddingTop = 2f;
                        cell2qualital.PaddingBottom = 5f;
                        cell2qualital.UseVariableBorders = true;
                        cell2qualital.BorderWidthBottom = 1;
                        cell2qualital.BorderWidthLeft = 1;
                        cell2qualital.BorderWidthTop = 1;
                        cell2qualital.BorderColor = new BaseColor(208, 211, 212);
                        cell2qualital.BorderWidthRight = 1;
                        tableoperation.AddCell(cell2qualital);

                        tot = tot + question.NOTE_QUESTION;
                        // ITERATATION REPONSES
                        //s += "<div class='ln_reponse col-md-6'> <select  onchange=\"combo007($(this),'C')\"  class='checkboxx' id='selec" + i + "' onchange='get_docs()'>";
                        var reponses = _service.ListeReponse(question.ID_QUESTION);
                        var reponsesliste = _service.Listreponse(idDossier1.Trim(), "N6");
                        if (reponsesliste.Count > 0)
                        {
                            foreach (var reponse in reponses)
                            {

                                foreach (var reponseV in reponsesliste)
                                {
                                    if (reponse.ID_REPONSE.Trim() == reponseV.ID_REPONSE.Trim())
                                    {
                                        PdfPCell cell3qualital = new PdfPCell(new Phrase(reponse.LIBELLE_REPONSE, normalFont2));
                                        cell3qualital.PaddingLeft = 3f;
                                        cell3qualital.UseVariableBorders = true;
                                        cell3qualital.PaddingTop = 2f;
                                        cell3qualital.PaddingBottom = 5f;
                                        cell3qualital.HorizontalAlignment = 0;
                                        cell3qualital.BorderWidthBottom = 1;
                                        cell3qualital.BorderWidthLeft = 1;
                                        cell3qualital.BorderWidthTop = 1;
                                        cell3qualital.BorderColor = new BaseColor(208, 211, 212);
                                        cell3qualital.BorderWidthRight = 1;
                                        cell3qualital.Bottom = 3f;
                                        tableoperation.AddCell(cell3qualital);

                                        PdfPCell cell30vqualital = new PdfPCell(new Phrase(reponseV.NOTE_REPONSE.ToString(), normalFont2));
                                        cell30vqualital.PaddingLeft = 3f;
                                        cell30vqualital.UseVariableBorders = true;
                                        cell30vqualital.PaddingTop = 2f;
                                        cell30vqualital.PaddingBottom = 5f;
                                        cell30vqualital.HorizontalAlignment = 1;
                                        cell30vqualital.BorderWidthBottom = 1;
                                        cell30vqualital.BorderWidthLeft = 1;
                                        cell30vqualital.BorderWidthTop = 1;
                                        cell30vqualital.BorderColor = new BaseColor(208, 211, 212);
                                        cell30vqualital.BorderWidthRight = 1;
                                        cell30vqualital.Bottom = 3f;
                                        tableoperation.AddCell(cell30vqualital);
                                    }
                                    //var docrep = "@" + reponse.ID_REPONSE.Trim();
                                    //docs += docrep;
                                }

                            }

                        }
                        else
                        {
                            PdfPCell cell3qualital = new PdfPCell(new Phrase("-", boldFont22));
                            cell3qualital.PaddingLeft = 3f;
                            cell3qualital.UseVariableBorders = true;
                            cell3qualital.PaddingTop = 2f;
                            cell3qualital.PaddingBottom = 5f;
                            cell3qualital.HorizontalAlignment = 0;
                            cell3qualital.BorderWidthBottom = 1;
                            cell3qualital.BorderWidthLeft = 1;
                            cell3qualital.BorderWidthTop = 1;
                            cell3qualital.BorderColor = new BaseColor(208, 211, 212);
                            cell3qualital.BorderWidthRight = 1;
                            cell3qualital.Bottom = 3f;
                            tableoperation.AddCell(cell3qualital);


                            PdfPCell cell385qualital = new PdfPCell(new Phrase("-", boldFont22));
                            cell385qualital.PaddingLeft = 3f;
                            cell385qualital.UseVariableBorders = true;
                            cell385qualital.PaddingTop = 2f;
                            cell385qualital.PaddingBottom = 5f;
                            cell385qualital.HorizontalAlignment = 0;
                            cell385qualital.BorderWidthBottom = 1;
                            cell385qualital.BorderWidthLeft = 1;
                            cell385qualital.BorderWidthTop = 1;
                            cell385qualital.BorderColor = new BaseColor(208, 211, 212);
                            cell385qualital.BorderWidthRight = 1;
                            cell385qualital.Bottom = 3f;
                            tableoperation.AddCell(cell385qualital);
                        }

                        //s += "</select></div></div>";
                        i1++;
                    }
                }
            }
        }
        public void OperationModelNotation()
        {

            var palatino = FontFactory.GetFont("palatino linotype", BaseFont.CP1252, BaseFont.EMBEDDED, 9, Font.BOLD);
            var boldFont = FontFactory.GetFont("palatino linotype", BaseFont.CP1252, BaseFont.EMBEDDED, 12, Font.BOLD);
            var italicfont = FontFactory.GetFont("palatino linotype", BaseFont.CP1252, BaseFont.EMBEDDED, 9, Font.ITALIC);
            var boldFontTitle = FontFactory.GetFont("palatino linotype", BaseFont.CP1252, BaseFont.EMBEDDED, 14, Font.BOLD);
            var titleFont = FontFactory.GetFont("Segoe UI", 9, BaseColor.WHITE);

            Font boldFont2 = new Font(Font.FontFamily.TIMES_ROMAN, 9, Font.BOLD, BaseColor.BLACK);
            Font boldFont22 = new Font(Font.FontFamily.TIMES_ROMAN, 9, Font.BOLD, BaseColor.WHITE);
            Font normalFont2 = new Font(Font.FontFamily.TIMES_ROMAN, 9, Font.ITALIC, BaseColor.BLACK);


            tableModeleNotOperation.TotalWidth = 500f;
            tableModeleNotOperation.PaddingTop = 5f;
            tableModeleNotOperation.LockedWidth = true;
            float[] widthstablequalital = new float[] { 5f, 2f, 5f };
            tableModeleNotOperation.SetWidths(widthstablequalital);
            tableModeleNotOperation.HorizontalAlignment = 1;
            var idDossier1 = compar1;
            var elements = _service.InfoDossier(idDossier1);
            // ITERATION CHAPITRES
            var chapitres = _service.ListeChapitre("ANAOPE");
            var i1OSC = 0;
            decimal totOSC = 0;

            var i1 = 0;
            decimal tot = 0;

            Chunk valider = new Chunk("Analyse de l'opération", FontFactory.GetFont("palatino linotype", BaseFont.CP1252, BaseFont.EMBEDDED, 14, Font.ITALIC));
            valider.SetUnderline(2, -3);
            Phrase p2 = new Phrase();
            p2.Add(valider);
            Paragraph p = new Paragraph(p2);

            PdfPCell cell1qualital = new PdfPCell(p);
            cell1qualital.Colspan = 4;
            cell1qualital.HorizontalAlignment = 1;
            cell1qualital.UseVariableBorders = true;
            cell1qualital.BorderWidth = 0;
            cell1qualital.BackgroundColor = new BaseColor(255, 255, 255);
            cell1qualital.BorderColor = new BaseColor(255, 255, 255);
            cell1qualital.PaddingBottom = 5f;
            tableModeleNotOperation.AddCell(cell1qualital);

            PdfPCell cell1TitreBlabc = new PdfPCell(new Phrase("vide", boldFont22));
            cell1TitreBlabc.PaddingLeft = 10f;
            cell1TitreBlabc.PaddingTop = 2f;
            cell1TitreBlabc.Colspan = 4;
            cell1TitreBlabc.PaddingBottom = 5f;
            cell1TitreBlabc.UseVariableBorders = true;
            cell1TitreBlabc.BorderWidthBottom = 0;
            cell1TitreBlabc.BorderWidthLeft = 0;
            cell1TitreBlabc.BorderWidthTop = 0;
            cell1TitreBlabc.BorderColor = new BaseColor(255, 255, 255);
            cell1TitreBlabc.BorderWidthRight = 0;
            tableModeleNotOperation.AddCell(cell1TitreBlabc);

            foreach (var chapitre in chapitres)
            {
                decimal xxx = 0;

                PdfPCell cell3qualital = new PdfPCell(new Phrase(chapitre.LIBELLE_CHAPITRE, normalFont2));
                cell3qualital.PaddingLeft = 3f;
                cell3qualital.UseVariableBorders = true;
                cell3qualital.PaddingTop = 2f;
                cell3qualital.PaddingBottom = 5f;
                cell3qualital.Colspan = 2;
                cell3qualital.HorizontalAlignment = 0;
                cell3qualital.BorderWidthBottom = 1;
                cell3qualital.BorderWidthLeft = 1;
                cell3qualital.BorderWidthTop = 1;
                cell3qualital.BorderColor = new BaseColor(208, 211, 212);
                cell3qualital.BorderWidthRight = 1;
                cell3qualital.Bottom = 3f;
                tableModeleNotOperation.AddCell(cell3qualital);

                var questions = service.ListeQuestion(chapitre.CODE_CHAPITRE);
                foreach (var question in questions)
                {
                    /////////////////////////////////////////////////////
                    var reponses = service.Listreponse(idDossier1, "N6");
                    foreach (var reponse in reponses)
                    {
                        if (reponse.ID_QUESTION != null)
                            if (reponse.ID_QUESTION.Trim() == question.ID_QUESTION.Trim())
                                xxx += reponse.NOTE_REPONSE;
                    }
                }
                PdfPCell cell30vqualital = new PdfPCell(new Phrase(xxx + " / " + chapitre.NOTE_CHAPITRE, normalFont2));
                cell30vqualital.PaddingLeft = 3f;
                cell30vqualital.UseVariableBorders = true;
                cell30vqualital.PaddingTop = 2f;
                cell30vqualital.Colspan = 2;
                cell30vqualital.PaddingBottom = 5f;
                cell30vqualital.HorizontalAlignment = 1;
                cell30vqualital.BorderWidthBottom = 1;
                cell30vqualital.BorderWidthLeft = 1;
                cell30vqualital.BorderWidthTop = 1;
                cell30vqualital.BorderColor = new BaseColor(208, 211, 212);
                cell30vqualital.BorderWidthRight = 1;
                cell30vqualital.Bottom = 3f;
                tableModeleNotOperation.AddCell(cell30vqualital);
            }

            //PdfPCell cell1qualital = new PdfPCell(new Phrase("Note", boldFont2));
            //cell1qualital.Colspan = 2;
            //cell1qualital.HorizontalAlignment = 1;
            //cell1qualital.UseVariableBorders = true;
            //cell1qualital.BorderWidth = 1;
            //cell1qualital.BackgroundColor = new BaseColor(228, 235, 245);
            //cell1qualital.BorderColor = new BaseColor(208, 211, 212);
            //cell1qualital.PaddingBottom = 5f;
            ////tableModeleNotOperation.AddCell(cell1qualital);

            cell1qualital.Phrase = new Phrase("Note de l'opération", boldFont2);
            cell1qualital.Colspan = 2;
            cell1qualital.HorizontalAlignment = 0;
            cell1qualital.BorderWidth = 1;
            cell1qualital.BackgroundColor = new BaseColor(228, 235, 245);
            cell1qualital.BorderColor = new BaseColor(208, 211, 212);
            tableModeleNotOperation.AddCell(cell1qualital);

            var noteop = "";
            var DetailNotes = service.DetailsNotesDossier(idDossier1);
            if (DetailNotes.Count != 0)
            {
                foreach (var Notes in DetailNotes)
                {
                    noteop = Notes.NOTE_OP;
                }
            }
            cell1qualital.Phrase = new Phrase("" + noteop, boldFont2);
            cell1qualital.BorderWidth = 1;
            cell1qualital.HorizontalAlignment = 1;
            cell1qualital.BackgroundColor = new BaseColor(255, 255, 255);
            cell1qualital.BorderColor = new BaseColor(208, 211, 212);
            cell1qualital.BackgroundColor = new BaseColor(255, 255, 255);
            cell1qualital.Colspan = 2;

            tableModeleNotOperation.AddCell(cell1qualital);


        }

        public void QualitativeRepose()
        {

            var palatino = FontFactory.GetFont("palatino linotype", BaseFont.CP1252, BaseFont.EMBEDDED, 9, Font.BOLD);
            var boldFont = FontFactory.GetFont("palatino linotype", BaseFont.CP1252, BaseFont.EMBEDDED, 12, Font.BOLD);
            var italicfont = FontFactory.GetFont("palatino linotype", BaseFont.CP1252, BaseFont.EMBEDDED, 9, Font.ITALIC);
            var boldFontTitle = FontFactory.GetFont("palatino linotype", BaseFont.CP1252, BaseFont.EMBEDDED, 14, Font.BOLD);
            var titleFont = FontFactory.GetFont("Segoe UI", 9, BaseColor.WHITE);

            Font boldFont2 = new Font(Font.FontFamily.TIMES_ROMAN, 9, Font.BOLD, BaseColor.BLACK);
            Font boldFont22 = new Font(Font.FontFamily.TIMES_ROMAN, 9, Font.BOLD, BaseColor.WHITE);
            Font normalFont2 = new Font(Font.FontFamily.TIMES_ROMAN, 9, Font.ITALIC, BaseColor.BLACK);


            tablequalital.TotalWidth = 500f;
            tablequalital.PaddingTop = 5f;
            //fix the absolute width of the table
            tablequalital.LockedWidth = true;
            //relative col widths in proportions - 1/3 and 2/3
            float[] widthstablequalital = new float[] { 5f, 6f, 1f };
            tablequalital.SetWidths(widthstablequalital);
            tablequalital.HorizontalAlignment = 1;

            var idDossier1 = compar1;
            //if (Session["id_dossier"] == null) Response.Redirect("~/Scoring/Connexion.aspx");
            //else idDossier = Session["id_dossier"].ToString();
            //Session.Add("id_dossier", idDossier);

            var elements = _service.InfoDossier(idDossier1);
            foreach (var dossier in elements)
            {
                //ModeleNotation.Text = dossier.LIBELLE_MODELE;
                //NoteQualitative.Text = dossier.NOTE_AQ;
                modele = dossier.MODELE_DOSSIER;
            }

            if (modele.Trim() != "GROUP")
            {
                // ITERATION CHAPITRES
                var chapitres = _service.ListeChapitre(modele);
                var i1 = 0;
                decimal tot = 0;
                foreach (var chapitre in chapitres)
                {
                    PdfPCell cell1qualital = new PdfPCell(new Phrase(chapitre.LIBELLE_CHAPITRE, boldFont2));
                    cell1qualital.Colspan = 2;
                    cell1qualital.HorizontalAlignment = 1;
                    cell1qualital.UseVariableBorders = true;
                    cell1qualital.BorderWidth = 1;
                    cell1qualital.BackgroundColor = new BaseColor(228, 235, 245);
                    cell1qualital.BorderColor = new BaseColor(208, 211, 212);
                    cell1qualital.PaddingBottom = 5f;
                    tablequalital.AddCell(cell1qualital);

                    PdfPCell cell1qualit21 = new PdfPCell(new Phrase("Points", boldFont2));
                    cell1qualit21.Colspan = 2;
                    cell1qualit21.HorizontalAlignment = 1;
                    cell1qualit21.UseVariableBorders = true;
                    cell1qualit21.BorderWidth = 1;
                    cell1qualit21.BackgroundColor = new BaseColor(228, 235, 245);
                    cell1qualit21.BorderColor = new BaseColor(208, 211, 212);
                    cell1qualit21.PaddingBottom = 5f;
                    tablequalital.AddCell(cell1qualit21);

                    //s += "<div class='ln_chapitre col-md-12'>" + chapitre.LIBELLE_CHAPITRE + "</div>";

                    // ITERATATION QUESTIONS
                    var questions = _service.ListeQuestion(chapitre.CODE_CHAPITRE.Trim());
                    foreach (var question in questions)
                    {
                        //s += "<div class='ln_question_reponse col-md-12' ><div class='ln_question col-md-6'>" + question.LIBELLE_QUESTION + "</div>";

                        PdfPCell cell2qualital = new PdfPCell(new Phrase(question.LIBELLE_QUESTION, boldFont2));
                        cell2qualital.PaddingLeft = 10f;
                        cell2qualital.PaddingTop = 2f;
                        cell2qualital.PaddingBottom = 5f;
                        cell2qualital.UseVariableBorders = true;
                        cell2qualital.BorderWidthBottom = 1;
                        cell2qualital.BorderWidthLeft = 1;
                        cell2qualital.BorderWidthTop = 1;
                        cell2qualital.BorderColor = new BaseColor(208, 211, 212);
                        cell2qualital.BorderWidthRight = 1;
                        tablequalital.AddCell(cell2qualital);

                        tot = tot + question.NOTE_QUESTION;
                        // ITERATATION REPONSES
                        //s += "<div class='ln_reponse col-md-6'> <select  onchange=\"combo007($(this),'C')\"  class='checkboxx' id='selec" + i + "' onchange='get_docs()'>";
                        var reponses = _service.ListeReponse(question.ID_QUESTION);
                        var reponsesliste = _service.Listreponse(idDossier1.Trim(), "N2");
                        if (reponsesliste.Count > 0)
                        {
                            foreach (var reponse in reponses)
                            {

                                foreach (var reponseV in reponsesliste)
                                {
                                    if (reponse.ID_REPONSE.Trim() == reponseV.ID_REPONSE.Trim())
                                    {
                                        PdfPCell cell3qualital = new PdfPCell(new Phrase(reponse.LIBELLE_REPONSE, normalFont2));
                                        cell3qualital.PaddingLeft = 3f;
                                        cell3qualital.UseVariableBorders = true;
                                        cell3qualital.PaddingTop = 2f;
                                        cell3qualital.PaddingBottom = 5f;
                                        cell3qualital.HorizontalAlignment = 0;
                                        cell3qualital.BorderWidthBottom = 1;
                                        cell3qualital.BorderWidthLeft = 1;
                                        cell3qualital.BorderWidthTop = 1;
                                        cell3qualital.BorderColor = new BaseColor(208, 211, 212);
                                        cell3qualital.BorderWidthRight = 1;
                                        cell3qualital.Bottom = 3f;
                                        tablequalital.AddCell(cell3qualital);

                                        PdfPCell cell30vqualital = new PdfPCell(new Phrase(reponseV.NOTE_REPONSE.ToString(), normalFont2));
                                        cell30vqualital.PaddingLeft = 3f;
                                        cell30vqualital.UseVariableBorders = true;
                                        cell30vqualital.PaddingTop = 2f;
                                        cell30vqualital.PaddingBottom = 5f;
                                        cell30vqualital.HorizontalAlignment = 1;
                                        cell30vqualital.BorderWidthBottom = 1;
                                        cell30vqualital.BorderWidthLeft = 1;
                                        cell30vqualital.BorderWidthTop = 1;
                                        cell30vqualital.BorderColor = new BaseColor(208, 211, 212);
                                        cell30vqualital.BorderWidthRight = 1;
                                        cell30vqualital.Bottom = 3f;
                                        tablequalital.AddCell(cell30vqualital);
                                    }
                                    //var docrep = "@" + reponse.ID_REPONSE.Trim();
                                    //docs += docrep;
                                }

                            }

                        }
                        else
                        {
                            PdfPCell cell3qualital = new PdfPCell(new Phrase("-", boldFont22));
                            cell3qualital.PaddingLeft = 3f;
                            cell3qualital.UseVariableBorders = true;
                            cell3qualital.PaddingTop = 2f;
                            cell3qualital.PaddingBottom = 5f;
                            cell3qualital.HorizontalAlignment = 0;
                            cell3qualital.BorderWidthBottom = 1;
                            cell3qualital.BorderWidthLeft = 1;
                            cell3qualital.BorderWidthTop = 1;
                            cell3qualital.BorderColor = new BaseColor(208, 211, 212);
                            cell3qualital.BorderWidthRight = 1;
                            cell3qualital.Bottom = 3f;
                            tablequalital.AddCell(cell3qualital);


                            PdfPCell cell385qualital = new PdfPCell(new Phrase("-", boldFont22));
                            cell385qualital.PaddingLeft = 3f;
                            cell385qualital.UseVariableBorders = true;
                            cell385qualital.PaddingTop = 2f;
                            cell385qualital.PaddingBottom = 5f;
                            cell385qualital.HorizontalAlignment = 0;
                            cell385qualital.BorderWidthBottom = 1;
                            cell385qualital.BorderWidthLeft = 1;
                            cell385qualital.BorderWidthTop = 1;
                            cell385qualital.BorderColor = new BaseColor(208, 211, 212);
                            cell385qualital.BorderWidthRight = 1;
                            cell385qualital.Bottom = 3f;
                            tablequalital.AddCell(cell385qualital);
                        }

                        //s += "</select></div></div>";
                        i1++;
                    }

                }

                PdfPCell cell5qualital = new PdfPCell(new Phrase("vide", boldFont22));
                cell5qualital.Colspan = 3;
                cell5qualital.HorizontalAlignment = 1;
                cell5qualital.UseVariableBorders = true;
                cell5qualital.BorderWidth = 1;
                cell5qualital.BackgroundColor = new BaseColor(255, 255, 255);
                cell5qualital.BorderColor = new BaseColor(255, 255, 255);
                cell5qualital.PaddingBottom = 5f;
                tablequalital.AddCell(cell5qualital);
            }
            else
            {
                AnalyseStructurellegroupe();
            }


        }
        public void InfoIdentPrincipal()
        {
            if (AdireExpert.Trim() != "")
            {
                MAnalyse = AdireExpert;
            }
            Font boldFont2 = new Font(Font.FontFamily.TIMES_ROMAN, 9, Font.BOLD, BaseColor.BLACK);
            Font boldFont22 = new Font(Font.FontFamily.TIMES_ROMAN, 9, Font.BOLD, BaseColor.WHITE);
            Font normalFont2 = new Font(Font.FontFamily.TIMES_ROMAN, 9, Font.ITALIC, BaseColor.BLACK);
            var palatino = FontFactory.GetFont("palatino linotype", BaseFont.CP1252, BaseFont.EMBEDDED, 9, Font.BOLD);
            var boldFont = FontFactory.GetFont("palatino linotype", BaseFont.CP1252, BaseFont.EMBEDDED, 12, Font.BOLD);
            var italicfont = FontFactory.GetFont("palatino linotype", BaseFont.CP1252, BaseFont.EMBEDDED, 9, Font.ITALIC);
            var boldFontTitle = FontFactory.GetFont("palatino linotype", BaseFont.CP1252, BaseFont.EMBEDDED, 14, Font.BOLD);
            var titleFont = FontFactory.GetFont("Segoe UI", 9, BaseColor.WHITE);

            table5.TotalWidth = 500f;
            table5.PaddingTop = 5f;
            //fix the absolute width of the table
            table5.LockedWidth = true;
            //relative col widths in proportions - 1/3 and 2/3
            float[] widths3 = new float[] { 2.5f, 4.5f, 3.5f, 1.5f };
            table5.SetWidths(widths3);
            table5.HorizontalAlignment = 1;

            PdfPCell Ut_cell1 = new PdfPCell(new Phrase("Unité de charge :", palatino));
            Ut_cell1.PaddingLeft = 3f;
            Ut_cell1.PaddingTop = 5f;
            Ut_cell1.PaddingBottom = 5f;
            Ut_cell1.UseVariableBorders = true;
            Ut_cell1.BorderWidthBottom = 0;
            //Ut_cell1.BorderColor = new BaseColor(255, 255, 255);
            //Ut_cell1.BackgroundColor = new BaseColor(208, 211, 212);
            Ut_cell1.BorderWidthLeft = 0;
            Ut_cell1.BorderWidthTop = 0;
            Ut_cell1.BorderWidthRight = 0;
            table5.AddCell(Ut_cell1);

            //PdfPCell Ut_cell2 = new PdfPCell(new Phrase(nom_user_editeSup, italicfont));
            PdfPCell Ut_cell2 = new PdfPCell(new Phrase(agenceUser, italicfont)); //21/11/2019
            Ut_cell2.PaddingLeft = 3f;
            Ut_cell2.PaddingTop = 5f;
            Ut_cell2.PaddingBottom = 5f;
            Ut_cell2.UseVariableBorders = true;
            Ut_cell2.BorderWidthBottom = 0;
            //Ut_cell1.BorderColor = new BaseColor(255, 255, 255);
            //Ut_cell1.BackgroundColor = new BaseColor(208, 211, 212);
            Ut_cell2.BorderWidthLeft = 0;
            Ut_cell2.BorderWidthTop = 0;
            Ut_cell2.BorderWidthRight = 0;
            table5.AddCell(Ut_cell2);

            PdfPCell Ut_cell3 = new PdfPCell(new Phrase("Date d'ouverture :", palatino));
            Ut_cell3.PaddingLeft = 3f;
            Ut_cell3.PaddingTop = 5f;
            Ut_cell3.PaddingBottom = 5f;
            Ut_cell3.UseVariableBorders = true;
            Ut_cell3.BorderWidthBottom = 0;
            //Ut_cell1.BorderColor = new BaseColor(255, 255, 255);
            //Ut_cell1.BackgroundColor = new BaseColor(208, 211, 212);
            Ut_cell3.BorderWidthLeft = 0;
            Ut_cell3.BorderWidthTop = 0;
            Ut_cell3.BorderWidthRight = 0;
            table5.AddCell(Ut_cell3);

            PdfPCell Ut_cell4 = new PdfPCell(new Phrase(dateReOuvr.ToString(), italicfont));
            Ut_cell4.PaddingLeft = 3f;
            Ut_cell4.PaddingTop = 5f;
            Ut_cell4.PaddingBottom = 5f;
            Ut_cell4.UseVariableBorders = true;
            Ut_cell4.BorderWidthBottom = 0;
            //Ut_cell1.BorderColor = new BaseColor(255, 255, 255);
            //Ut_cell1.BackgroundColor = new BaseColor(208, 211, 212);
            Ut_cell4.BorderWidthLeft = 0;
            Ut_cell4.BorderWidthTop = 0;
            Ut_cell4.BorderWidthRight = 0;
            table5.AddCell(Ut_cell4);

            PdfPCell Ut_cell5 = new PdfPCell(new Phrase("Initiateur de dossier :", palatino));
            Ut_cell5.PaddingLeft = 3f;
            Ut_cell5.PaddingTop = 5f;
            Ut_cell5.PaddingBottom = 5f;
            Ut_cell5.UseVariableBorders = true;
            Ut_cell5.BorderWidthBottom = 0;
            //Ut_cell1.BorderColor = new BaseColor(255, 255, 255);
            //Ut_cell1.BackgroundColor = new BaseColor(208, 211, 212);
            Ut_cell5.BorderWidthLeft = 0;
            Ut_cell5.BorderWidthTop = 0;
            Ut_cell5.BorderWidthRight = 0;
            table5.AddCell(Ut_cell5);

            //PdfPCell Ut_cell6 = new PdfPCell(new Phrase(  nom_user_edite, italicfont));
            PdfPCell Ut_cell6 = new PdfPCell(new Phrase(nom_user_editePRO  , italicfont)); //blaise 21/11/2019+
            Ut_cell6.PaddingLeft = 3f;
            Ut_cell6.PaddingTop = 5f;
            Ut_cell6.PaddingBottom = 5f;
            Ut_cell6.UseVariableBorders = true;
            Ut_cell6.BorderWidthBottom = 0;
            //Ut_cell1.BorderColor = new BaseColor(255, 255, 255);
            //Ut_cell1.BackgroundColor = new BaseColor(208, 211, 212);
            Ut_cell6.BorderWidthLeft = 0;
            Ut_cell6.BorderWidthTop = 0;
            Ut_cell6.BorderWidthRight = 0;
            table5.AddCell(Ut_cell6);

            PdfPCell Ut_cell7 = new PdfPCell(new Phrase("Date de Cloture :", palatino));
            Ut_cell7.PaddingLeft = 3f;
            Ut_cell7.PaddingTop = 5f;
            Ut_cell7.PaddingBottom = 5f;
            Ut_cell7.UseVariableBorders = true;
            Ut_cell7.BorderWidthBottom = 0;
            //Ut_cell1.BorderColor = new BaseColor(255, 255, 255);
            //Ut_cell1.BackgroundColor = new BaseColor(208, 211, 212);
            Ut_cell7.BorderWidthLeft = 0;
            Ut_cell7.BorderWidthTop = 0;
            Ut_cell7.BorderWidthRight = 0;
            table5.AddCell(Ut_cell7);

            PdfPCell Ut_cell8 = new PdfPCell(new Phrase(dateRe.ToString(), italicfont));
            Ut_cell8.PaddingLeft = 3f;
            Ut_cell8.PaddingTop = 5f;
            Ut_cell8.PaddingBottom = 5f;
            Ut_cell8.UseVariableBorders = true;
            Ut_cell8.BorderWidthBottom = 0;
            //Ut_cell1.BorderColor = new BaseColor(255, 255, 255);
            //Ut_cell1.BackgroundColor = new BaseColor(208, 211, 212);
            Ut_cell8.BorderWidthLeft = 0;
            Ut_cell8.BorderWidthTop = 0;
            Ut_cell8.BorderWidthRight = 0;
            table5.AddCell(Ut_cell8);

            PdfPCell Ut_cell11 = new PdfPCell(new Phrase("Etat de la demande :", palatino));
            Ut_cell11.PaddingLeft = 3f;
            Ut_cell11.PaddingTop = 5f;
            Ut_cell11.PaddingBottom = 5f;
            Ut_cell11.UseVariableBorders = true;
            Ut_cell11.BorderWidthBottom = 0;
            //Ut_cell11.BorderColor = new BaseColor(255, 255, 255);
            //Ut_cell11.BackgroundColor = new BaseColor(208, 211, 212);
            Ut_cell11.BorderWidthLeft = 0;
            Ut_cell11.BorderWidthTop = 0;
            Ut_cell11.BorderWidthRight = 0;
            table5.AddCell(Ut_cell11);

            PdfPCell Ut_cell12 = new PdfPCell(new Phrase(decision.ToString(), italicfont));
            Ut_cell12.PaddingLeft = 3f;
            Ut_cell12.PaddingTop = 5f;
            Ut_cell12.PaddingBottom = 5f;
            Ut_cell12.UseVariableBorders = true;
            Ut_cell12.BorderWidthBottom = 0;
            //Ut_cell1.BorderColor = new BaseColor(255, 255, 255);
            //Ut_cell1.BackgroundColor = new BaseColor(208, 211, 212);
            Ut_cell12.BorderWidthLeft = 0;
            Ut_cell12.BorderWidthTop = 0;
            Ut_cell12.BorderWidthRight = 0;
            table5.AddCell(Ut_cell12);

            PdfPCell Ut_cell13 = new PdfPCell(new Phrase("Date d'expiration de la révésion annuelle", boldFont22));
            Ut_cell13.PaddingLeft = 3f;
            Ut_cell13.PaddingTop = 5f;
            Ut_cell13.PaddingBottom = 5f;
            Ut_cell13.UseVariableBorders = true;
            Ut_cell13.BorderWidthBottom = 0;
            //Ut_cell1.BorderColor = new BaseColor(255, 255, 255);
            //Ut_cell1.BackgroundColor = new BaseColor(208, 211, 212);
            Ut_cell13.BorderWidthLeft = 0;
            Ut_cell13.BorderWidthTop = 0;
            Ut_cell13.BorderWidthRight = 0;
            table5.AddCell(Ut_cell13);

            PdfPCell Ut_cell14 = new PdfPCell(new Phrase("12/12/2014", boldFont22));
            Ut_cell14.PaddingLeft = 3f;
            Ut_cell14.PaddingTop = 5f;
            Ut_cell14.PaddingBottom = 5f;
            Ut_cell14.UseVariableBorders = true;
            Ut_cell14.BorderWidthBottom = 0;
            //Ut_cell1.BorderColor = new BaseColor(255, 255, 255);
            //Ut_cell1.BackgroundColor = new BaseColor(208, 211, 212);
            Ut_cell14.BorderWidthLeft = 0;
            Ut_cell14.BorderWidthTop = 0;
            Ut_cell14.BorderWidthRight = 0;
            table5.AddCell(Ut_cell14);

            PdfPCell Ut_cell15 = new PdfPCell(new Phrase("Initiateur de dossier :", boldFont22));
            Ut_cell15.PaddingLeft = 3f;
            Ut_cell15.PaddingTop = 5f;
            Ut_cell15.PaddingBottom = 5f;
            Ut_cell15.UseVariableBorders = true;
            Ut_cell15.BorderWidthBottom = 0;
            //Ut_cell1.BorderColor = new BaseColor(255, 255, 255);
            //Ut_cell1.BackgroundColor = new BaseColor(208, 211, 212);
            Ut_cell15.BorderWidthLeft = 0;
            Ut_cell15.BorderWidthTop = 0;
            Ut_cell15.BorderWidthRight = 0;
            table5.AddCell(Ut_cell15);

            PdfPCell Ut_cell16 = new PdfPCell(new Phrase(nom_user_editePRO, boldFont22));
            Ut_cell16.PaddingLeft = 3f;
            Ut_cell16.PaddingTop = 5f;
            Ut_cell16.PaddingBottom = 5f;
            Ut_cell16.UseVariableBorders = true;
            Ut_cell16.BorderWidthBottom = 0;
            //Ut_cell1.BorderColor = new BaseColor(255, 255, 255);
            //Ut_cell1.BackgroundColor = new BaseColor(208, 211, 212);
            Ut_cell16.BorderWidthLeft = 0;
            Ut_cell16.BorderWidthTop = 0;
            Ut_cell16.BorderWidthRight = 0;
            table5.AddCell(Ut_cell16);

            PdfPCell Ut_cell17 = new PdfPCell(new Phrase("Date de la ECA", boldFont22));
            Ut_cell17.PaddingLeft = 3f;
            Ut_cell17.PaddingTop = 5f;
            Ut_cell17.PaddingBottom = 5f;
            Ut_cell17.UseVariableBorders = true;
            Ut_cell17.BorderWidthBottom = 0;
            //Ut_cell1.BorderColor = new BaseColor(255, 255, 255);
            //Ut_cell1.BackgroundColor = new BaseColor(208, 211, 212);
            Ut_cell17.BorderWidthLeft = 0;
            Ut_cell17.BorderWidthTop = 0;
            Ut_cell17.BorderWidthRight = 0;
            table5.AddCell(Ut_cell17);

            PdfPCell Ut_cell18 = new PdfPCell(new Phrase("12/12/2054", boldFont22));
            Ut_cell18.PaddingLeft = 3f;
            Ut_cell18.PaddingTop = 5f;
            Ut_cell18.PaddingBottom = 5f;
            Ut_cell18.UseVariableBorders = true;
            Ut_cell18.BorderWidthBottom = 0;
            //Ut_cell1.BorderColor = new BaseColor(255, 255, 255);
            //Ut_cell1.BackgroundColor = new BaseColor(208, 211, 212);
            Ut_cell18.BorderWidthLeft = 0;
            Ut_cell18.BorderWidthTop = 0;
            Ut_cell18.BorderWidthRight = 0;
            table5.AddCell(Ut_cell18);

            table5.SpacingBefore = 10f;
            table5.SpacingAfter = 12.5f;

        }
        public void InfoIdentifiants()
        {
            if (AdireExpert.Trim() != "")
            {
                MAnalyse = AdireExpert;
            }
            Font boldFont2 = new Font(Font.FontFamily.TIMES_ROMAN, 9, Font.BOLD, BaseColor.BLACK);
            Font boldFont22 = new Font(Font.FontFamily.TIMES_ROMAN, 9, Font.BOLD, BaseColor.WHITE);
            Font normalFont2 = new Font(Font.FontFamily.TIMES_ROMAN, 9, Font.ITALIC, BaseColor.BLACK);
            var palatino = FontFactory.GetFont("palatino linotype", BaseFont.CP1252, BaseFont.EMBEDDED, 9, Font.BOLD);
            var boldFont = FontFactory.GetFont("palatino linotype", BaseFont.CP1252, BaseFont.EMBEDDED, 12, Font.BOLD);
            var italicfont = FontFactory.GetFont("palatino linotype", BaseFont.CP1252, BaseFont.EMBEDDED, 9, Font.ITALIC);
            var boldFontTitle = FontFactory.GetFont("palatino linotype", BaseFont.CP1252, BaseFont.EMBEDDED, 14, Font.BOLD);
            var titleFont = FontFactory.GetFont("Segoe UI", 9, BaseColor.WHITE);

            table1.TotalWidth = 500f;
            table1.PaddingTop = 5f;
            //fix the absolute width of the table
            table1.LockedWidth = true;
            //relative col widths in proportions - 1/3 and 2/3
            float[] widths1 = new float[] { 5.5f, 6.5f };
            table1.SetWidths(widths1);
            table1.HorizontalAlignment = 1;


            PdfPCell IDENTIFIANTS1 = new PdfPCell(new Phrase("IDENTIFIANTS", boldFont2));
            IDENTIFIANTS1.Colspan = 2;
            IDENTIFIANTS1.HorizontalAlignment = 1;
            IDENTIFIANTS1.UseVariableBorders = true;
            IDENTIFIANTS1.BorderWidth = 1;
            IDENTIFIANTS1.BackgroundColor = new BaseColor(228, 235, 245);
            IDENTIFIANTS1.BorderColor = new BaseColor(208, 211, 212);
            IDENTIFIANTS1.PaddingBottom = 5f;
            table1.AddCell(IDENTIFIANTS1);

            PdfPCell ID_cell1 = new PdfPCell(new Phrase("Raison Sociale :", boldFont2));
            ID_cell1.PaddingLeft = 10f;
            ID_cell1.PaddingTop = 2f;
            ID_cell1.PaddingBottom = 2f;
            ID_cell1.UseVariableBorders = true;
            ID_cell1.BorderWidthBottom = 0;
            ID_cell1.BackgroundColor = new BaseColor(255, 255, 255);
            ID_cell1.BorderColor = new BaseColor(208, 211, 212);
            ID_cell1.BorderWidthLeft = 1;
            ID_cell1.BorderWidthTop = 0;
            ID_cell1.BorderWidthRight = 0;
            table1.AddCell(ID_cell1);

            PdfPCell ID_cell2 = new PdfPCell(new Phrase(RSocial, normalFont2));
            ID_cell2.PaddingLeft = 3f;
            ID_cell2.UseVariableBorders = true;
            ID_cell2.PaddingTop = 2f;
            ID_cell2.PaddingBottom = 2f;
            ID_cell2.HorizontalAlignment = 0;
            ID_cell2.BorderWidthBottom = 0;
            ID_cell2.BorderWidthLeft = 0;
            ID_cell2.BackgroundColor = new BaseColor(255, 255, 255);
            ID_cell2.BorderColor = new BaseColor(208, 211, 212);
            ID_cell2.BorderWidthTop = 0;
            ID_cell2.BorderWidthRight = 1;
            ID_cell2.Bottom = 3f;
            table1.AddCell(ID_cell2);


            PdfPCell ID_cell3 = new PdfPCell(new Phrase("Adresse C.P:", boldFont2));
            ID_cell3.PaddingLeft = 10f;
            ID_cell3.PaddingTop = 2f;
            ID_cell3.PaddingBottom = 2f;
            ID_cell3.UseVariableBorders = true;
            ID_cell3.BorderWidthBottom = 0;
            ID_cell3.BorderWidthLeft = 1;
            ID_cell3.BorderWidthTop = 0;

            ID_cell3.BackgroundColor = new BaseColor(255, 255, 255);
            ID_cell3.BorderColor = new BaseColor(208, 211, 212);
            ID_cell3.BorderWidthRight = 0;
            table1.AddCell(ID_cell3);

            PdfPCell ID_cell4 = new PdfPCell(new Phrase(Adresse, normalFont2));
            ID_cell4.PaddingLeft = 3f;
            ID_cell4.UseVariableBorders = true;
            ID_cell4.PaddingTop = 2f;
            ID_cell4.PaddingBottom = 2f;
            ID_cell4.HorizontalAlignment = 0;
            ID_cell4.BorderWidthBottom = 0;
            ID_cell4.BorderWidthLeft = 0;
            ID_cell4.BorderWidthTop = 0;
            ID_cell4.BackgroundColor = new BaseColor(255, 255, 255);
            ID_cell4.BorderColor = new BaseColor(208, 211, 212);
            ID_cell4.BorderWidthRight = 1;
            ID_cell4.Bottom = 3f;
            table1.AddCell(ID_cell4);

            PdfPCell ID_cell5 = new PdfPCell(new Phrase("Ville :", boldFont2));
            ID_cell5.PaddingLeft = 10f;
            ID_cell5.PaddingTop = 2f;
            ID_cell5.PaddingBottom = 2f;
            ID_cell5.UseVariableBorders = true;
            ID_cell5.BorderWidthBottom = 0;
            ID_cell5.BorderWidthLeft = 1;
            ID_cell5.BorderWidthTop = 0;
            ID_cell5.BackgroundColor = new BaseColor(255, 255, 255);
            ID_cell5.BorderColor = new BaseColor(208, 211, 212);
            ID_cell5.BorderWidthRight = 0;
            table1.AddCell(ID_cell5);

            PdfPCell ID_cell6 = new PdfPCell(new Phrase(CPVille, normalFont2));
            ID_cell6.PaddingLeft = 3f;
            ID_cell6.UseVariableBorders = true;
            ID_cell6.PaddingTop = 2f;
            ID_cell6.BackgroundColor = new BaseColor(255, 255, 255);
            ID_cell6.BorderColor = new BaseColor(208, 211, 212);
            ID_cell6.PaddingBottom = 2f;
            ID_cell6.HorizontalAlignment = 0;
            ID_cell6.BorderWidthBottom = 0;
            ID_cell6.BorderWidthLeft = 0;
            ID_cell6.BorderWidthTop = 0;
            ID_cell6.BorderWidthRight = 1;
            ID_cell6.Bottom = 3f;
            table1.AddCell(ID_cell6);

            PdfPCell ID_cell7 = new PdfPCell(new Phrase("Pays :", boldFont2));
            ID_cell7.PaddingLeft = 10f;
            ID_cell7.PaddingTop = 2f;
            ID_cell7.PaddingBottom = 2f;
            ID_cell7.UseVariableBorders = true;
            ID_cell7.BorderWidthBottom = 0;
            ID_cell7.BackgroundColor = new BaseColor(255, 255, 255);
            ID_cell7.BorderColor = new BaseColor(208, 211, 212);
            ID_cell7.BorderWidthLeft = 1;
            ID_cell7.BorderWidthTop = 0;
            ID_cell7.BorderWidthRight = 0;
            table1.AddCell(ID_cell7);

            PdfPCell ID_cell8 = new PdfPCell(new Phrase(Pays, normalFont2));
            ID_cell8.PaddingLeft = 3f;
            ID_cell8.UseVariableBorders = true;
            ID_cell8.PaddingTop = 2f;
            ID_cell8.PaddingBottom = 2f;
            ID_cell8.HorizontalAlignment = 0;
            ID_cell8.BorderWidthBottom = 0;
            ID_cell8.BorderWidthLeft = 0;
            ID_cell8.BackgroundColor = new BaseColor(255, 255, 255);
            ID_cell8.BorderColor = new BaseColor(208, 211, 212);
            ID_cell8.BorderWidthTop = 0;
            ID_cell8.BorderWidthRight = 1;
            ID_cell8.Bottom = 3f;
            table1.AddCell(ID_cell8);

            PdfPCell ID_cell9 = new PdfPCell(new Phrase("N° Régistre du commerce :", boldFont2));
            ID_cell9.PaddingLeft = 10f;
            ID_cell9.PaddingTop = 2f;
            ID_cell9.PaddingBottom = 2f;
            ID_cell9.BackgroundColor = new BaseColor(255, 255, 255);
            ID_cell9.BorderColor = new BaseColor(208, 211, 212);
            ID_cell9.UseVariableBorders = true;
            ID_cell9.BorderWidthBottom = 0;
            ID_cell9.BorderWidthLeft = 1;
            ID_cell9.BorderWidthTop = 0;
            ID_cell9.BorderWidthRight = 0;
            table1.AddCell(ID_cell9);

            PdfPCell ID_cell10 = new PdfPCell(new Phrase(LblAPE, normalFont2));
            ID_cell10.PaddingLeft = 3f;
            ID_cell10.UseVariableBorders = true;
            ID_cell10.PaddingTop = 2f;
            ID_cell10.PaddingBottom = 2f;
            ID_cell10.HorizontalAlignment = 0;
            ID_cell10.BorderWidthBottom = 0;
            ID_cell10.BorderWidthLeft = 0;
            ID_cell10.BackgroundColor = new BaseColor(255, 255, 255);
            ID_cell10.BorderColor = new BaseColor(208, 211, 212);
            ID_cell10.BorderWidthTop = 0;
            ID_cell10.BorderWidthRight = 1;
            ID_cell10.Bottom = 3f;
            table1.AddCell(ID_cell10);

            PdfPCell ID_cell11 = new PdfPCell(new Phrase("Identifiant principal :", boldFont2));
            ID_cell11.PaddingLeft = 10f;
            ID_cell11.PaddingTop = 2f;
            ID_cell11.PaddingBottom = 2f;
            ID_cell11.UseVariableBorders = true;
            ID_cell11.BorderWidthBottom = 0;
            ID_cell11.BackgroundColor = new BaseColor(255, 255, 255);
            ID_cell11.BorderColor = new BaseColor(208, 211, 212);
            ID_cell11.BorderWidthLeft = 1;
            ID_cell11.BorderWidthTop = 0;
            ID_cell11.BorderWidthRight = 0;
            table1.AddCell(ID_cell11);

            PdfPCell ID_cell12 = new PdfPCell(new Phrase(IPrincipal, normalFont2));
            ID_cell12.PaddingLeft = 3f;
            ID_cell12.UseVariableBorders = true;
            ID_cell12.PaddingTop = 2f;
            ID_cell12.PaddingBottom = 2f;
            ID_cell12.HorizontalAlignment = 0;
            ID_cell12.BorderWidthBottom = 0;
            ID_cell12.BorderWidthLeft = 0;
            ID_cell12.BackgroundColor = new BaseColor(255, 255, 255);
            ID_cell12.BorderColor = new BaseColor(208, 211, 212);
            ID_cell12.BorderWidthTop = 0;
            ID_cell12.BorderWidthRight = 1;
            ID_cell12.Bottom = 3f;
            table1.AddCell(ID_cell12);

            PdfPCell ID_cell13 = new PdfPCell(new Phrase("Identifiant scoring center  :", boldFont2));
            ID_cell13.PaddingLeft = 10f;
            ID_cell13.PaddingTop = 2f;
            ID_cell13.PaddingBottom = 2f;
            ID_cell13.UseVariableBorders = true;
            ID_cell13.BorderWidthBottom = 0;
            ID_cell13.BorderWidthLeft = 1;
            ID_cell13.BackgroundColor = new BaseColor(255, 255, 255);
            ID_cell13.BorderColor = new BaseColor(208, 211, 212);
            ID_cell13.BorderWidthTop = 0;
            ID_cell13.BorderWidthRight = 0;
            table1.AddCell(ID_cell13);

            PdfPCell ID_cell14 = new PdfPCell(new Phrase(ISCenter, normalFont2));
            ID_cell14.PaddingLeft = 3f;
            ID_cell14.UseVariableBorders = true;
            ID_cell14.PaddingTop = 2f;
            ID_cell14.PaddingBottom = 2f;
            ID_cell14.HorizontalAlignment = 0;
            ID_cell14.BorderWidthBottom = 0;
            ID_cell14.BorderWidthLeft = 0;
            ID_cell14.BackgroundColor = new BaseColor(255, 255, 255);
            ID_cell14.BorderColor = new BaseColor(208, 211, 212);
            ID_cell14.BorderWidthTop = 0;
            ID_cell14.BorderWidthRight = 1;
            ID_cell14.Bottom = 3f;
            table1.AddCell(ID_cell14);

            PdfPCell ID_cell15 = new PdfPCell(new Phrase("Type client :", boldFont2));
            ID_cell15.PaddingLeft = 10f;
            ID_cell15.PaddingTop = 2f;
            ID_cell15.PaddingBottom = 5f;
            ID_cell15.UseVariableBorders = true;
            ID_cell15.BackgroundColor = new BaseColor(255, 255, 255);
            ID_cell15.BorderColor = new BaseColor(208, 211, 212);
            ID_cell15.BorderWidthBottom = 1;
            ID_cell15.BorderWidthLeft = 1;
            ID_cell15.BorderWidthTop = 0;
            ID_cell15.BorderWidthRight = 0;
            table1.AddCell(ID_cell15);

            PdfPCell ID_cell16 = new PdfPCell(new Phrase(lblTypeProspect, normalFont2));
            ID_cell16.PaddingLeft = 3f;
            ID_cell16.UseVariableBorders = true;
            ID_cell16.PaddingTop = 2f;
            ID_cell16.PaddingBottom = 5f;
            ID_cell16.HorizontalAlignment = 0;
            ID_cell16.BackgroundColor = new BaseColor(255, 255, 255);
            ID_cell16.BorderColor = new BaseColor(208, 211, 212);
            ID_cell16.BorderWidthBottom = 1;
            ID_cell16.BorderWidthLeft = 0;
            ID_cell16.BorderWidthTop = 0;
            ID_cell16.BorderWidthRight = 1;
            ID_cell16.Bottom = 3f;
            table1.AddCell(ID_cell16);

            table1.SpacingBefore = 5f;
            table1.SpacingAfter = 5f;
        }
        public void InfoBancaire()
        {
            if (AdireExpert.Trim() != "")
            {
                MAnalyse = AdireExpert;
            }
            Font boldFont2 = new Font(Font.FontFamily.TIMES_ROMAN, 9, Font.BOLD, BaseColor.BLACK);
            Font boldFont22 = new Font(Font.FontFamily.TIMES_ROMAN, 9, Font.BOLD, BaseColor.WHITE);
            Font normalFont2 = new Font(Font.FontFamily.TIMES_ROMAN, 9, Font.ITALIC, BaseColor.BLACK);
            var palatino = FontFactory.GetFont("palatino linotype", BaseFont.CP1252, BaseFont.EMBEDDED, 9, Font.BOLD);
            var boldFont = FontFactory.GetFont("palatino linotype", BaseFont.CP1252, BaseFont.EMBEDDED, 12, Font.BOLD);
            var italicfont = FontFactory.GetFont("palatino linotype", BaseFont.CP1252, BaseFont.EMBEDDED, 9, Font.ITALIC);
            var boldFontTitle = FontFactory.GetFont("palatino linotype", BaseFont.CP1252, BaseFont.EMBEDDED, 14, Font.BOLD);
            var titleFont = FontFactory.GetFont("Segoe UI", 9, BaseColor.WHITE);

            table2.TotalWidth = 500f;
            table2.PaddingTop = 5f;
            //fix the absolute width of the table
            table2.LockedWidth = true;
            //relative col widths in proportions - 1/3 and 2/3
            //float[] widths2 = new float[] { 5.5f, 6.5f };
            float[] widths1 = new float[] { 5.5f, 6.5f };
            table2.SetWidths(widths1);
            table2.HorizontalAlignment = 1;

            PdfPCell INFORMATIONSBANCAIRES = new PdfPCell(new Phrase("INFORMATIONS BANCAIRES", boldFont2));
            INFORMATIONSBANCAIRES.Colspan = 2;
            INFORMATIONSBANCAIRES.HorizontalAlignment = 1;
            INFORMATIONSBANCAIRES.UseVariableBorders = true;
            INFORMATIONSBANCAIRES.BorderWidth = 1;
            INFORMATIONSBANCAIRES.BackgroundColor = new BaseColor(228, 235, 245);
            INFORMATIONSBANCAIRES.BorderColor = new BaseColor(208, 211, 212);
            //ville:
            INFORMATIONSBANCAIRES.PaddingBottom = 5f;
            table2.AddCell(INFORMATIONSBANCAIRES);

            PdfPCell ID_cell_IB_IB1 = new PdfPCell(new Phrase("Segment clientèle :", boldFont2));
            ID_cell_IB_IB1.PaddingLeft = 10f;
            ID_cell_IB_IB1.PaddingTop = 2f;
            ID_cell_IB_IB1.PaddingBottom = 2f;
            ID_cell_IB_IB1.BackgroundColor = new BaseColor(255, 255, 255);
            ID_cell_IB_IB1.BorderColor = new BaseColor(208, 211, 212);
            ID_cell_IB_IB1.UseVariableBorders = true;
            ID_cell_IB_IB1.BorderWidthBottom = 0;
            ID_cell_IB_IB1.BorderWidthLeft = 1;
            ID_cell_IB_IB1.BorderWidthTop = 0;
            ID_cell_IB_IB1.BorderWidthRight = 0;
            table2.AddCell(ID_cell_IB_IB1);

            PdfPCell ID_cell_IB_IB2 = new PdfPCell(new Phrase(LblSClientele, normalFont2));
            ID_cell_IB_IB2.PaddingLeft = 3f;
            ID_cell_IB_IB2.UseVariableBorders = true;
            ID_cell_IB_IB2.PaddingTop = 2f;
            ID_cell_IB_IB2.PaddingBottom = 2f;
            ID_cell_IB_IB2.HorizontalAlignment = 0;
            ID_cell_IB_IB2.BorderWidthBottom = 0;
            ID_cell_IB_IB2.BorderWidthLeft = 0;
            ID_cell_IB_IB2.BorderWidthTop = 0;
            ID_cell_IB_IB2.BackgroundColor = new BaseColor(255, 255, 255);
            ID_cell_IB_IB2.BorderColor = new BaseColor(208, 211, 212);
            ID_cell_IB_IB2.BorderWidthRight = 1;
            ID_cell_IB_IB2.Bottom = 3f;
            table2.AddCell(ID_cell_IB_IB2);

            PdfPCell ID_cell_IB_IB3 = new PdfPCell(new Phrase("Banque :", boldFont2));
            ID_cell_IB_IB3.PaddingLeft = 10f;
            ID_cell_IB_IB3.PaddingTop = 2f;
            ID_cell_IB_IB3.PaddingBottom = 2f;
            ID_cell_IB_IB3.UseVariableBorders = true;
            ID_cell_IB_IB3.BackgroundColor = new BaseColor(255, 255, 255);
            ID_cell_IB_IB3.BorderColor = new BaseColor(208, 211, 212);
            ID_cell_IB_IB3.BorderWidthBottom = 0;
            ID_cell_IB_IB3.BorderWidthLeft = 1;
            ID_cell_IB_IB3.BorderWidthTop = 0;
            ID_cell_IB_IB3.BorderWidthRight = 0;
            table2.AddCell(ID_cell_IB_IB3);

            PdfPCell ID_cell_IB_IB4 = new PdfPCell(new Phrase(LblBanque, normalFont2));
            ID_cell_IB_IB4.PaddingLeft = 3f;
            ID_cell_IB_IB4.UseVariableBorders = true;
            ID_cell_IB_IB4.PaddingTop = 2f;
            ID_cell_IB_IB4.PaddingBottom = 2f;
            ID_cell_IB_IB4.BackgroundColor = new BaseColor(255, 255, 255);
            ID_cell_IB_IB4.BorderColor = new BaseColor(208, 211, 212);
            ID_cell_IB_IB4.HorizontalAlignment = 0;
            ID_cell_IB_IB4.BorderWidthBottom = 0;
            ID_cell_IB_IB4.BorderWidthLeft = 0;
            ID_cell_IB_IB4.BorderWidthTop = 0;
            ID_cell_IB_IB4.BorderWidthRight = 1;
            ID_cell_IB_IB4.Bottom = 3f;
            table2.AddCell(ID_cell_IB_IB4);

            PdfPCell ID_cell_IB_IB3_1 = new PdfPCell(new Phrase("Agence :", boldFont2));
            ID_cell_IB_IB3_1.PaddingLeft = 10f;
            ID_cell_IB_IB3_1.PaddingTop = 2f;
            ID_cell_IB_IB3_1.PaddingBottom = 2f;
            ID_cell_IB_IB3_1.UseVariableBorders = true;
            ID_cell_IB_IB3_1.BackgroundColor = new BaseColor(255, 255, 255);
            ID_cell_IB_IB3_1.BorderColor = new BaseColor(208, 211, 212);
            ID_cell_IB_IB3_1.BorderWidthBottom = 0;
            ID_cell_IB_IB3_1.BorderWidthLeft = 1;
            ID_cell_IB_IB3_1.BorderWidthTop = 0;
            ID_cell_IB_IB3_1.BorderWidthRight = 0;
            table2.AddCell(ID_cell_IB_IB3_1);

            PdfPCell ID_cell_IB_IB4_1 = new PdfPCell(new Phrase(LblAgence, normalFont2));
            ID_cell_IB_IB4_1.PaddingLeft = 3f;
            ID_cell_IB_IB4_1.UseVariableBorders = true;
            ID_cell_IB_IB4_1.PaddingTop = 2f;
            ID_cell_IB_IB4_1.PaddingBottom = 2f;
            ID_cell_IB_IB4_1.BackgroundColor = new BaseColor(255, 255, 255);
            ID_cell_IB_IB4_1.BorderColor = new BaseColor(208, 211, 212);
            ID_cell_IB_IB4_1.HorizontalAlignment = 0;
            ID_cell_IB_IB4_1.BorderWidthBottom = 0;
            ID_cell_IB_IB4_1.BorderWidthLeft = 0;
            ID_cell_IB_IB4_1.BorderWidthTop = 0;
            ID_cell_IB_IB4_1.BorderWidthRight = 1;
            ID_cell_IB_IB4_1.Bottom = 3f;
            table2.AddCell(ID_cell_IB_IB4_1);

            PdfPCell ID_cell_IB_IB5 = new PdfPCell(new Phrase("Groupe :", boldFont2));
            ID_cell_IB_IB5.PaddingLeft = 10f;
            ID_cell_IB_IB5.PaddingTop = 2f;
            ID_cell_IB_IB5.PaddingBottom = 2f;
            ID_cell_IB_IB5.UseVariableBorders = true;
            ID_cell_IB_IB5.BorderWidthBottom = 0;
            ID_cell_IB_IB5.BorderWidthLeft = 1;
            ID_cell_IB_IB5.BackgroundColor = new BaseColor(255, 255, 255);
            ID_cell_IB_IB5.BorderColor = new BaseColor(208, 211, 212);
            ID_cell_IB_IB5.BorderWidthTop = 0;
            ID_cell_IB_IB5.BorderWidthRight = 0;
            table2.AddCell(ID_cell_IB_IB5);

            PdfPCell ID_cell_IB_IB6 = new PdfPCell(new Phrase(LblGroupe, normalFont2));
            ID_cell_IB_IB6.PaddingLeft = 3f;
            ID_cell_IB_IB6.UseVariableBorders = true;
            ID_cell_IB_IB6.PaddingTop = 2f;
            ID_cell_IB_IB6.PaddingBottom = 2f;
            ID_cell_IB_IB6.HorizontalAlignment = 0;
            ID_cell_IB_IB6.BorderWidthBottom = 0;
            ID_cell_IB_IB6.BorderWidthLeft = 0;
            ID_cell_IB_IB6.BackgroundColor = new BaseColor(255, 255, 255);
            ID_cell_IB_IB6.BorderColor = new BaseColor(208, 211, 212);
            ID_cell_IB_IB6.BorderWidthTop = 0;
            ID_cell_IB_IB6.BorderWidthRight = 1;
            ID_cell_IB_IB6.Bottom = 3f;
            table2.AddCell(ID_cell_IB_IB6);

            PdfPCell ID_cell_IB_IB7 = new PdfPCell(new Phrase("Chiffre d'affaire :", boldFont2));
            ID_cell_IB_IB7.PaddingLeft = 10f;
            ID_cell_IB_IB7.PaddingTop = 2f;
            ID_cell_IB_IB7.PaddingBottom = 5f;
            ID_cell_IB_IB7.UseVariableBorders = true;
            ID_cell_IB_IB7.BorderWidthBottom = 1;
            ID_cell_IB_IB7.BackgroundColor = new BaseColor(255, 255, 255);
            ID_cell_IB_IB7.BorderColor = new BaseColor(208, 211, 212);
            ID_cell_IB_IB7.BorderWidthLeft = 1;
            ID_cell_IB_IB7.BorderWidthTop = 0;
            ID_cell_IB_IB7.BorderWidthRight = 0;
            table2.AddCell(ID_cell_IB_IB7);

            PdfPCell ID_cell_IB_IB8 = new PdfPCell(new Phrase(LblChiffre, normalFont2));
            ID_cell_IB_IB8.PaddingLeft = 3f;
            ID_cell_IB_IB8.UseVariableBorders = true;
            ID_cell_IB_IB8.PaddingTop = 2f;
            ID_cell_IB_IB8.PaddingBottom = 5f;
            ID_cell_IB_IB8.BackgroundColor = new BaseColor(255, 255, 255);
            ID_cell_IB_IB8.BorderColor = new BaseColor(208, 211, 212);
            ID_cell_IB_IB8.HorizontalAlignment = 0;
            ID_cell_IB_IB8.BorderWidthBottom = 1;
            ID_cell_IB_IB8.BorderWidthLeft = 0;
            ID_cell_IB_IB8.BorderWidthTop = 0;
            ID_cell_IB_IB8.BorderWidthRight = 1;
            ID_cell_IB_IB8.Bottom = 3f;
            table2.AddCell(ID_cell_IB_IB8);

            table2.SpacingBefore = 10f;
            table2.SpacingAfter = 12.5f;
        }
        public void InfoActivité()
        {
            if (AdireExpert.Trim() != "")
            {
                MAnalyse = AdireExpert;
            }
            Font boldFont2 = new Font(Font.FontFamily.TIMES_ROMAN, 9, Font.BOLD, BaseColor.BLACK);
            Font boldFont22 = new Font(Font.FontFamily.TIMES_ROMAN, 9, Font.BOLD, BaseColor.WHITE);
            Font normalFont2 = new Font(Font.FontFamily.TIMES_ROMAN, 9, Font.ITALIC, BaseColor.BLACK);
            var palatino = FontFactory.GetFont("palatino linotype", BaseFont.CP1252, BaseFont.EMBEDDED, 9, Font.BOLD);
            var boldFont = FontFactory.GetFont("palatino linotype", BaseFont.CP1252, BaseFont.EMBEDDED, 12, Font.BOLD);
            var italicfont = FontFactory.GetFont("palatino linotype", BaseFont.CP1252, BaseFont.EMBEDDED, 9, Font.ITALIC);
            var boldFontTitle = FontFactory.GetFont("palatino linotype", BaseFont.CP1252, BaseFont.EMBEDDED, 14, Font.BOLD);
            var titleFont = FontFactory.GetFont("Segoe UI", 9, BaseColor.WHITE);

            table3.TotalWidth = 500f;
            table3.PaddingTop = 5f;
            //fix the absolute width of the table
            table3.LockedWidth = true;
            //relative col widths in proportions - 1/3 and 2/3
            //float[] widths2 = new float[] { 5.5f, 6.5f };
            float[] widths1 = new float[] { 5.5f, 6.5f };
            table3.SetWidths(widths1);
            table3.HorizontalAlignment = 1;


            PdfPCell ACTIVITES = new PdfPCell(new Phrase("ACTIVITÉS", boldFont2));
            ACTIVITES.Colspan = 2;
            ACTIVITES.HorizontalAlignment = 1;
            ACTIVITES.UseVariableBorders = true;
            ACTIVITES.BorderWidth = 1;
            ACTIVITES.BackgroundColor = new BaseColor(228, 235, 245);
            ACTIVITES.BorderColor = new BaseColor(208, 211, 212);
            ACTIVITES.PaddingBottom = 5f;
            table3.AddCell(ACTIVITES);

            PdfPCell ID_cell_IB_IB141 = new PdfPCell(new Phrase("Branche d'activité :", boldFont2));
            ID_cell_IB_IB141.PaddingLeft = 10f;
            ID_cell_IB_IB141.PaddingTop = 2f;
            ID_cell_IB_IB141.PaddingBottom = 2f;
            ID_cell_IB_IB141.UseVariableBorders = true;
            ID_cell_IB_IB141.BorderWidthBottom = 0;
            ID_cell_IB_IB141.BackgroundColor = new BaseColor(255, 255, 255);
            ID_cell_IB_IB141.BorderColor = new BaseColor(208, 211, 212);
            ID_cell_IB_IB141.BorderWidthLeft = 1;
            ID_cell_IB_IB141.BorderWidthTop = 0;
            ID_cell_IB_IB141.BorderWidthRight = 0;
            table3.AddCell(ID_cell_IB_IB141);

            PdfPCell ID_cell_IB_ACT2 = new PdfPCell(new Phrase(LblBranche, normalFont2));
            ID_cell_IB_ACT2.PaddingLeft = 3f;
            ID_cell_IB_ACT2.UseVariableBorders = true;
            ID_cell_IB_ACT2.PaddingTop = 2f;
            ID_cell_IB_ACT2.PaddingBottom = 2f;
            ID_cell_IB_ACT2.HorizontalAlignment = 0;
            ID_cell_IB_ACT2.BorderWidthBottom = 0;
            ID_cell_IB_ACT2.BorderWidthLeft = 0;
            ID_cell_IB_ACT2.BackgroundColor = new BaseColor(255, 255, 255);
            ID_cell_IB_ACT2.BorderColor = new BaseColor(208, 211, 212);
            ID_cell_IB_ACT2.BorderWidthTop = 0;
            ID_cell_IB_ACT2.BorderWidthRight = 1;
            ID_cell_IB_ACT2.Bottom = 3f;
            table3.AddCell(ID_cell_IB_ACT2);


            PdfPCell ID_cell_IB_ACT3 = new PdfPCell(new Phrase("Secteur d'activité :", boldFont2));
            ID_cell_IB_ACT3.PaddingLeft = 10f;
            ID_cell_IB_ACT3.PaddingTop = 2f;
            ID_cell_IB_ACT3.PaddingBottom = 2f;
            ID_cell_IB_ACT3.UseVariableBorders = true;
            ID_cell_IB_ACT3.BorderWidthBottom = 0;
            ID_cell_IB_ACT3.BorderWidthLeft = 1;
            ID_cell_IB_ACT3.BackgroundColor = new BaseColor(255, 255, 255);
            ID_cell_IB_ACT3.BorderColor = new BaseColor(208, 211, 212);
            ID_cell_IB_ACT3.BorderWidthTop = 0;
            ID_cell_IB_ACT3.BorderWidthRight = 0;
            table3.AddCell(ID_cell_IB_ACT3);

            PdfPCell ID_cell_IB_ACT4 = new PdfPCell(new Phrase(LblNAF2, normalFont2));
            ID_cell_IB_ACT4.PaddingLeft = 3f;
            ID_cell_IB_ACT4.UseVariableBorders = true;
            ID_cell_IB_ACT4.PaddingTop = 2f;
            ID_cell_IB_ACT4.PaddingBottom = 2f;
            ID_cell_IB_ACT4.HorizontalAlignment = 0;
            ID_cell_IB_ACT4.BorderWidthBottom = 0;
            ID_cell_IB_ACT4.BorderWidthLeft = 0;
            ID_cell_IB_ACT4.BorderWidthTop = 0;
            ID_cell_IB_ACT4.BackgroundColor = new BaseColor(255, 255, 255);
            ID_cell_IB_ACT4.BorderColor = new BaseColor(208, 211, 212);
            ID_cell_IB_ACT4.BorderWidthRight = 1;
            ID_cell_IB_ACT4.Bottom = 3f;
            table3.AddCell(ID_cell_IB_ACT4);

            PdfPCell ID_cell_IB_ACT5 = new PdfPCell(new Phrase("Activité principal de l'entreprise :", boldFont2));
            ID_cell_IB_ACT5.PaddingLeft = 10f;
            ID_cell_IB_ACT5.PaddingTop = 2f;
            ID_cell_IB_ACT5.PaddingBottom = 2f;
            ID_cell_IB_ACT5.UseVariableBorders = true;
            ID_cell_IB_ACT5.BorderWidthBottom = 0;
            ID_cell_IB_ACT5.BorderWidthLeft = 1;
            ID_cell_IB_ACT5.BackgroundColor = new BaseColor(255, 255, 255);
            ID_cell_IB_ACT5.BorderColor = new BaseColor(208, 211, 212);
            ID_cell_IB_ACT5.BorderWidthTop = 0;
            ID_cell_IB_ACT5.BorderWidthRight = 0;
            table3.AddCell(ID_cell_IB_ACT5);

            PdfPCell ID_cell_IB_ACT6 = new PdfPCell(new Phrase(LblNAF, normalFont2));
            ID_cell_IB_ACT6.PaddingLeft = 3f;
            ID_cell_IB_ACT6.UseVariableBorders = true;
            ID_cell_IB_ACT6.PaddingTop = 2f;
            ID_cell_IB_ACT6.PaddingBottom = 2f;
            ID_cell_IB_ACT6.HorizontalAlignment = 0;
            ID_cell_IB_ACT6.BorderWidthBottom = 0;
            ID_cell_IB_ACT6.BorderWidthLeft = 0;
            ID_cell_IB_ACT6.BorderWidthTop = 0;
            ID_cell_IB_ACT6.BackgroundColor = new BaseColor(255, 255, 255);
            ID_cell_IB_ACT6.BorderColor = new BaseColor(208, 211, 212);
            ID_cell_IB_ACT6.BorderWidthRight = 1;
            ID_cell_IB_ACT6.Bottom = 3f;
            table3.AddCell(ID_cell_IB_ACT6);

            PdfPCell ID_cell_IB_ACT7 = new PdfPCell(new Phrase("Statut juridique :", boldFont2));
            ID_cell_IB_ACT7.PaddingLeft = 10f;
            ID_cell_IB_ACT7.PaddingTop = 2f;
            ID_cell_IB_ACT7.PaddingBottom = 5f;
            ID_cell_IB_ACT7.UseVariableBorders = true;
            ID_cell_IB_ACT7.BorderWidthBottom = 1;
            ID_cell_IB_ACT7.BackgroundColor = new BaseColor(255, 255, 255);
            ID_cell_IB_ACT7.BorderColor = new BaseColor(208, 211, 212);
            ID_cell_IB_ACT7.BorderWidthLeft = 1;
            ID_cell_IB_ACT7.BorderWidthTop = 0;
            ID_cell_IB_ACT7.BorderWidthRight = 0;
            table3.AddCell(ID_cell_IB_ACT7);

            PdfPCell ID_cell_IB_ACT8 = new PdfPCell(new Phrase(LblStatut, normalFont2));
            ID_cell_IB_ACT8.PaddingLeft = 3f;
            ID_cell_IB_ACT8.UseVariableBorders = true;
            ID_cell_IB_ACT8.PaddingTop = 2f;
            ID_cell_IB_ACT8.PaddingBottom = 5f;
            ID_cell_IB_ACT8.HorizontalAlignment = 0;
            ID_cell_IB_ACT8.BorderWidthBottom = 1;
            ID_cell_IB_ACT8.BorderWidthLeft = 0;
            ID_cell_IB_ACT8.BackgroundColor = new BaseColor(255, 255, 255);
            ID_cell_IB_ACT8.BorderColor = new BaseColor(208, 211, 212);
            ID_cell_IB_ACT8.BorderWidthTop = 0;
            ID_cell_IB_ACT8.BorderWidthRight = 1;
            ID_cell_IB_ACT8.Bottom = 3f;
            table3.AddCell(ID_cell_IB_ACT8);

            table3.SpacingBefore = 10f;
            table3.SpacingAfter = 25f;

        }
        public void InfoSaisiAnalyse()
        {
            if (AdireExpert.Trim() != "")
            {
                MAnalyse = AdireExpert;
            }
            Font boldFont2 = new Font(Font.FontFamily.TIMES_ROMAN, 9, Font.BOLD, BaseColor.BLACK);
            Font boldFont22 = new Font(Font.FontFamily.TIMES_ROMAN, 9, Font.BOLD, BaseColor.WHITE);
            Font normalFont2 = new Font(Font.FontFamily.TIMES_ROMAN, 9, Font.ITALIC, BaseColor.BLACK);
            var palatino = FontFactory.GetFont("palatino linotype", BaseFont.CP1252, BaseFont.EMBEDDED, 9, Font.BOLD);
            var boldFont = FontFactory.GetFont("palatino linotype", BaseFont.CP1252, BaseFont.EMBEDDED, 12, Font.BOLD);
            var italicfont = FontFactory.GetFont("palatino linotype", BaseFont.CP1252, BaseFont.EMBEDDED, 9, Font.ITALIC);
            var boldFontTitle = FontFactory.GetFont("palatino linotype", BaseFont.CP1252, BaseFont.EMBEDDED, 14, Font.BOLD);
            var titleFont = FontFactory.GetFont("Segoe UI", 9, BaseColor.WHITE);

            table4.TotalWidth = 500f;
            table4.PaddingTop = 5f;
            //fix the absolute width of the table
            table4.LockedWidth = true;
            //relative col widths in proportions - 1/3 and 2/3
            //float[] widths2 = new float[] { 5.5f, 6.5f };
            float[] widths1 = new float[] { 5.5f, 6.5f };
            table4.SetWidths(widths1);
            table4.HorizontalAlignment = 1;


            PdfPCell SAISIESANALYSES = new PdfPCell(new Phrase("SAISIES ET ANALYSES", boldFont2));
            SAISIESANALYSES.Colspan = 2;
            SAISIESANALYSES.HorizontalAlignment = 1;
            SAISIESANALYSES.UseVariableBorders = true;
            SAISIESANALYSES.BorderWidth = 1;
            SAISIESANALYSES.BackgroundColor = new BaseColor(228, 235, 245);
            SAISIESANALYSES.BorderColor = new BaseColor(208, 211, 212);
            SAISIESANALYSES.PaddingBottom = 5f;
            table4.AddCell(SAISIESANALYSES);

            PdfPCell ID_cell_IB_IB11 = new PdfPCell(new Phrase("Modèle d'analyse :", boldFont2));
            ID_cell_IB_IB11.PaddingLeft = 10f;
            ID_cell_IB_IB11.PaddingTop = 2f;
            ID_cell_IB_IB11.BackgroundColor = new BaseColor(255, 255, 255);
            ID_cell_IB_IB11.BorderColor = new BaseColor(208, 211, 212);
            ID_cell_IB_IB11.PaddingBottom = 2f;
            ID_cell_IB_IB11.UseVariableBorders = true;
            ID_cell_IB_IB11.BorderWidthBottom = 0;
            ID_cell_IB_IB11.BorderWidthLeft = 1;
            ID_cell_IB_IB11.BorderWidthTop = 0;
            ID_cell_IB_IB11.BorderWidthRight = 0;
            table4.AddCell(ID_cell_IB_IB11);

            PdfPCell ID_cell_IB_SA2 = new PdfPCell(new Phrase(MAnalyse, normalFont2));
            ID_cell_IB_SA2.PaddingLeft = 3f;
            ID_cell_IB_SA2.UseVariableBorders = true;
            ID_cell_IB_SA2.PaddingTop = 2f;
            ID_cell_IB_SA2.BackgroundColor = new BaseColor(255, 255, 255);
            ID_cell_IB_SA2.BorderColor = new BaseColor(208, 211, 212);
            ID_cell_IB_SA2.PaddingBottom = 2f;
            ID_cell_IB_SA2.HorizontalAlignment = 0;
            ID_cell_IB_SA2.BorderWidthBottom = 0;
            ID_cell_IB_SA2.BorderWidthLeft = 0;
            ID_cell_IB_SA2.BorderWidthTop = 0;
            ID_cell_IB_SA2.BorderWidthRight = 1;
            ID_cell_IB_SA2.Bottom = 3f;
            table4.AddCell(ID_cell_IB_SA2);


            PdfPCell ID_cell_IB_SA3 = new PdfPCell(new Phrase("Unité :", boldFont2));
            ID_cell_IB_SA3.PaddingLeft = 10f;
            ID_cell_IB_SA3.PaddingTop = 2f;
            ID_cell_IB_SA3.PaddingBottom = 2f;
            ID_cell_IB_SA3.BackgroundColor = new BaseColor(255, 255, 255);
            ID_cell_IB_SA3.BorderColor = new BaseColor(208, 211, 212);
            ID_cell_IB_SA3.UseVariableBorders = true;
            ID_cell_IB_SA3.BorderWidthBottom = 0;
            ID_cell_IB_SA3.BorderWidthLeft = 1;
            ID_cell_IB_SA3.BorderWidthTop = 0;
            ID_cell_IB_SA3.BorderWidthRight = 0;
            table4.AddCell(ID_cell_IB_SA3);

            PdfPCell ID_cell_IB_SA4 = new PdfPCell(new Phrase(LblUnite, normalFont2));
            ID_cell_IB_SA4.PaddingLeft = 3f;
            ID_cell_IB_SA4.UseVariableBorders = true;
            ID_cell_IB_SA4.PaddingTop = 2f;
            ID_cell_IB_SA4.PaddingBottom = 2f;
            ID_cell_IB_SA4.HorizontalAlignment = 0;
            ID_cell_IB_SA4.BackgroundColor = new BaseColor(255, 255, 255);
            ID_cell_IB_SA4.BorderColor = new BaseColor(208, 211, 212);
            ID_cell_IB_SA4.BorderWidthBottom = 0;
            ID_cell_IB_SA4.BorderWidthLeft = 0;
            ID_cell_IB_SA4.BorderWidthTop = 0;
            ID_cell_IB_SA4.BorderWidthRight = 1;
            ID_cell_IB_SA4.Bottom = 3f;
            table4.AddCell(ID_cell_IB_SA4);

            PdfPCell ID_cell_IB_SA5 = new PdfPCell(new Phrase("Date de clôture :", boldFont2));
            ID_cell_IB_SA5.PaddingLeft = 10f;
            ID_cell_IB_SA5.PaddingTop = 2f;
            ID_cell_IB_SA5.PaddingBottom = 2f;
            ID_cell_IB_SA5.BackgroundColor = new BaseColor(255, 255, 255);
            ID_cell_IB_SA5.BorderColor = new BaseColor(208, 211, 212);
            ID_cell_IB_SA5.UseVariableBorders = true;
            ID_cell_IB_SA5.BorderWidthBottom = 0;
            ID_cell_IB_SA5.BorderWidthLeft = 1;
            ID_cell_IB_SA5.BorderWidthTop = 0;
            ID_cell_IB_SA5.BorderWidthRight = 0;
            table4.AddCell(ID_cell_IB_SA5);

            PdfPCell ID_cell_IB_SA6 = new PdfPCell(new Phrase(LBDateClotureLiasse, normalFont2));
            ID_cell_IB_SA6.PaddingLeft = 3f;
            ID_cell_IB_SA6.UseVariableBorders = true;
            ID_cell_IB_SA6.PaddingTop = 2f;
            ID_cell_IB_SA6.PaddingBottom = 2f;
            ID_cell_IB_SA6.HorizontalAlignment = 0;
            ID_cell_IB_SA6.BackgroundColor = new BaseColor(255, 255, 255);
            ID_cell_IB_SA6.BorderColor = new BaseColor(208, 211, 212);
            ID_cell_IB_SA6.BorderWidthBottom = 0;
            ID_cell_IB_SA6.BorderWidthLeft = 0;
            ID_cell_IB_SA6.BorderWidthTop = 0;
            ID_cell_IB_SA6.BorderWidthRight = 1;
            ID_cell_IB_SA6.Bottom = 3f;
            table4.AddCell(ID_cell_IB_SA6);

            PdfPCell ID_cell_IB_SA7 = new PdfPCell(new Phrase("Durée de l'exercice en mois :", boldFont2));
            ID_cell_IB_SA7.PaddingLeft = 10f;
            ID_cell_IB_SA7.PaddingTop = 2f;
            ID_cell_IB_SA7.PaddingBottom = 2f;
            ID_cell_IB_SA7.UseVariableBorders = true;
            ID_cell_IB_SA7.BackgroundColor = new BaseColor(255, 255, 255);
            ID_cell_IB_SA7.BorderColor = new BaseColor(208, 211, 212);
            ID_cell_IB_SA7.BorderWidthBottom = 0;
            ID_cell_IB_SA7.BorderWidthLeft = 1;
            ID_cell_IB_SA7.BorderWidthTop = 0;
            ID_cell_IB_SA7.BorderWidthRight = 0;
            table4.AddCell(ID_cell_IB_SA7);

            PdfPCell ID_cell_IB_SA8 = new PdfPCell(new Phrase(LBDurreExoMoisLiasse, normalFont2));
            ID_cell_IB_SA8.PaddingLeft = 3f;
            ID_cell_IB_SA8.UseVariableBorders = true;
            ID_cell_IB_SA8.PaddingTop = 2f;
            ID_cell_IB_SA8.PaddingBottom = 2f;
            ID_cell_IB_SA8.HorizontalAlignment = 0;
            ID_cell_IB_SA8.BorderWidthBottom = 0;
            ID_cell_IB_SA8.BackgroundColor = new BaseColor(255, 255, 255);
            ID_cell_IB_SA8.BorderColor = new BaseColor(208, 211, 212);
            ID_cell_IB_SA8.BorderWidthLeft = 0;
            ID_cell_IB_SA8.BorderWidthTop = 0;
            ID_cell_IB_SA8.BorderWidthRight = 1;
            ID_cell_IB_SA8.Bottom = 3f;
            table4.AddCell(ID_cell_IB_SA8);

            PdfPCell ID_cell_IB_SA81 = new PdfPCell(new Phrase("Type bilan :", boldFont2));
            ID_cell_IB_SA81.PaddingLeft = 10f;
            ID_cell_IB_SA81.PaddingTop = 2f;
            ID_cell_IB_SA81.PaddingBottom = 2f;
            ID_cell_IB_SA81.UseVariableBorders = true;
            ID_cell_IB_SA81.BorderWidthBottom = 0;
            ID_cell_IB_SA81.BorderWidthLeft = 1;
            ID_cell_IB_SA81.BackgroundColor = new BaseColor(255, 255, 255);
            ID_cell_IB_SA81.BorderColor = new BaseColor(208, 211, 212);
            ID_cell_IB_SA81.BorderWidthTop = 0;
            ID_cell_IB_SA81.BorderWidthRight = 0;
            table4.AddCell(ID_cell_IB_SA81);

            PdfPCell ID_cell_IB_SA82 = new PdfPCell(new Phrase(LBTypeBilLiass, normalFont2));
            ID_cell_IB_SA82.PaddingLeft = 3f;
            ID_cell_IB_SA82.UseVariableBorders = true;
            ID_cell_IB_SA82.PaddingTop = 2f;
            ID_cell_IB_SA82.PaddingBottom = 2f;
            ID_cell_IB_SA82.HorizontalAlignment = 0;
            ID_cell_IB_SA82.BorderWidthBottom = 0;
            ID_cell_IB_SA82.BackgroundColor = new BaseColor(255, 255, 255);
            ID_cell_IB_SA82.BorderColor = new BaseColor(208, 211, 212);
            ID_cell_IB_SA82.BorderWidthLeft = 0;
            ID_cell_IB_SA82.BorderWidthTop = 0;
            ID_cell_IB_SA82.BorderWidthRight = 1;
            ID_cell_IB_SA82.Bottom = 3f;
            table4.AddCell(ID_cell_IB_SA82);

            PdfPCell ID_cell_IB_SA9 = new PdfPCell(new Phrase("Nature de l'exercice :", boldFont2));
            ID_cell_IB_SA9.PaddingLeft = 10f;
            ID_cell_IB_SA9.PaddingTop = 2f;
            ID_cell_IB_SA9.PaddingBottom = 2f;
            ID_cell_IB_SA9.BackgroundColor = new BaseColor(255, 255, 255);
            ID_cell_IB_SA9.BorderColor = new BaseColor(208, 211, 212);
            ID_cell_IB_SA9.UseVariableBorders = true;
            ID_cell_IB_SA9.BorderWidthBottom = 0;
            ID_cell_IB_SA9.BorderWidthLeft = 1;
            ID_cell_IB_SA9.BorderWidthTop = 0;
            ID_cell_IB_SA9.BorderWidthRight = 0;
            table4.AddCell(ID_cell_IB_SA9);

            PdfPCell ID_cell_IB_SA91 = new PdfPCell(new Phrase(LBNatureExoLiasse, normalFont2));
            ID_cell_IB_SA91.PaddingLeft = 3f;
            ID_cell_IB_SA91.UseVariableBorders = true;
            ID_cell_IB_SA91.PaddingTop = 2f;
            ID_cell_IB_SA91.PaddingBottom = 2f;
            ID_cell_IB_SA91.BackgroundColor = new BaseColor(255, 255, 255);
            ID_cell_IB_SA91.BorderColor = new BaseColor(208, 211, 212);
            ID_cell_IB_SA91.HorizontalAlignment = 0;
            ID_cell_IB_SA91.BorderWidthBottom = 0;
            ID_cell_IB_SA91.BorderWidthLeft = 0;
            ID_cell_IB_SA91.BorderWidthTop = 0;
            ID_cell_IB_SA91.BorderWidthRight = 1;
            ID_cell_IB_SA91.Bottom = 3f;
            table4.AddCell(ID_cell_IB_SA91);


            PdfPCell ID_cell_IB_SA10 = new PdfPCell(new Phrase("Certification des comptes :", boldFont2));
            ID_cell_IB_SA10.PaddingLeft = 10f;
            ID_cell_IB_SA10.PaddingTop = 2f;
            ID_cell_IB_SA10.PaddingBottom = 2f;
            ID_cell_IB_SA10.UseVariableBorders = true;
            ID_cell_IB_SA10.BackgroundColor = new BaseColor(255, 255, 255);
            ID_cell_IB_SA10.BorderColor = new BaseColor(208, 211, 212);
            ID_cell_IB_SA10.BorderWidthBottom = 0;
            ID_cell_IB_SA10.BorderWidthLeft = 1;
            ID_cell_IB_SA10.BorderWidthTop = 0;
            ID_cell_IB_SA10.BorderWidthRight = 0;
            table4.AddCell(ID_cell_IB_SA10);

            PdfPCell ID_cell_IB_SA11 = new PdfPCell(new Phrase(LBCertifCompteLiasse, normalFont2));
            ID_cell_IB_SA11.PaddingLeft = 3f;
            ID_cell_IB_SA11.UseVariableBorders = true;
            ID_cell_IB_SA11.PaddingTop = 2f;
            ID_cell_IB_SA11.PaddingBottom = 2f;
            ID_cell_IB_SA11.HorizontalAlignment = 0;
            ID_cell_IB_SA11.BorderWidthBottom = 0;
            ID_cell_IB_SA11.BackgroundColor = new BaseColor(255, 255, 255);
            ID_cell_IB_SA11.BorderColor = new BaseColor(208, 211, 212);
            ID_cell_IB_SA11.BorderWidthLeft = 0;
            ID_cell_IB_SA11.BorderWidthTop = 0;
            ID_cell_IB_SA11.BorderWidthRight = 1;
            ID_cell_IB_SA11.Bottom = 3f;
            table4.AddCell(ID_cell_IB_SA11);

            PdfPCell ID_cell_IB_SA12 = new PdfPCell(new Phrase("Effectif :", boldFont2));
            ID_cell_IB_SA12.PaddingLeft = 10f;
            ID_cell_IB_SA12.PaddingTop = 2f;
            ID_cell_IB_SA12.PaddingBottom = 2f;
            ID_cell_IB_SA12.UseVariableBorders = true;
            ID_cell_IB_SA12.BackgroundColor = new BaseColor(255, 255, 255);
            ID_cell_IB_SA12.BorderColor = new BaseColor(208, 211, 212);
            ID_cell_IB_SA12.BorderWidthBottom = 0;
            ID_cell_IB_SA12.BorderWidthLeft = 1;
            ID_cell_IB_SA12.BorderWidthTop = 0;
            ID_cell_IB_SA12.BorderWidthRight = 0;
            table4.AddCell(ID_cell_IB_SA12);

            PdfPCell ID_cell_IB_SA13 = new PdfPCell(new Phrase(LBEffectifLiasse, normalFont2));
            ID_cell_IB_SA13.PaddingLeft = 3f;
            ID_cell_IB_SA13.UseVariableBorders = true;
            ID_cell_IB_SA13.PaddingTop = 2f;
            ID_cell_IB_SA13.PaddingBottom = 2f;
            ID_cell_IB_SA13.BackgroundColor = new BaseColor(255, 255, 255);
            ID_cell_IB_SA13.BorderColor = new BaseColor(208, 211, 212);
            ID_cell_IB_SA13.HorizontalAlignment = 0;
            ID_cell_IB_SA13.BorderWidthBottom = 0;
            ID_cell_IB_SA13.BorderWidthLeft = 0;
            ID_cell_IB_SA13.BorderWidthTop = 0;
            ID_cell_IB_SA13.BorderWidthRight = 1;
            ID_cell_IB_SA13.Bottom = 3f;
            table4.AddCell(ID_cell_IB_SA13);

            PdfPCell ID_cell_IB_SA14 = new PdfPCell(new Phrase("Devise :", boldFont2));
            ID_cell_IB_SA14.PaddingLeft = 10f;
            ID_cell_IB_SA14.PaddingTop = 2f;
            ID_cell_IB_SA14.PaddingBottom = 2f;
            ID_cell_IB_SA14.BackgroundColor = new BaseColor(255, 255, 255);
            ID_cell_IB_SA14.BorderColor = new BaseColor(208, 211, 212);
            ID_cell_IB_SA14.UseVariableBorders = true;
            ID_cell_IB_SA14.BorderWidthBottom = 0;
            ID_cell_IB_SA14.BorderWidthLeft = 1;
            ID_cell_IB_SA14.BorderWidthTop = 0;
            ID_cell_IB_SA14.BorderWidthRight = 0;
            table4.AddCell(ID_cell_IB_SA14);

            PdfPCell ID_cell_IB_SA15 = new PdfPCell(new Phrase(LblDevise, normalFont2));
            ID_cell_IB_SA15.PaddingLeft = 3f;
            ID_cell_IB_SA15.UseVariableBorders = true;
            ID_cell_IB_SA15.PaddingTop = 2f;
            ID_cell_IB_SA15.PaddingBottom = 2f;
            ID_cell_IB_SA15.HorizontalAlignment = 0;
            ID_cell_IB_SA15.BorderWidthBottom = 0;
            ID_cell_IB_SA15.BorderWidthLeft = 0;
            ID_cell_IB_SA15.BackgroundColor = new BaseColor(255, 255, 255);
            ID_cell_IB_SA15.BorderColor = new BaseColor(208, 211, 212);
            ID_cell_IB_SA15.BorderWidthTop = 0;
            ID_cell_IB_SA15.BorderWidthRight = 1;
            ID_cell_IB_SA15.Bottom = 3f;
            table4.AddCell(ID_cell_IB_SA15);

            PdfPCell ID_cell_IB_SA16 = new PdfPCell(new Phrase("Régime fiscal :", boldFont2));
            ID_cell_IB_SA16.PaddingLeft = 10f;
            ID_cell_IB_SA16.PaddingTop = 2f;
            ID_cell_IB_SA16.PaddingBottom = 5f;
            ID_cell_IB_SA16.BackgroundColor = new BaseColor(255, 255, 255);
            ID_cell_IB_SA16.BorderColor = new BaseColor(208, 211, 212);
            ID_cell_IB_SA16.UseVariableBorders = true;
            ID_cell_IB_SA16.BorderWidthBottom = 1;
            ID_cell_IB_SA16.BorderWidthLeft = 1;
            ID_cell_IB_SA16.BorderWidthTop = 0;
            ID_cell_IB_SA16.BorderWidthRight = 0;
            table4.AddCell(ID_cell_IB_SA16);

            PdfPCell ID_cell_IB_SA17 = new PdfPCell(new Phrase(LBregimFiscalLiasse, normalFont2));
            ID_cell_IB_SA17.PaddingLeft = 3f;
            ID_cell_IB_SA17.UseVariableBorders = true;
            ID_cell_IB_SA17.PaddingTop = 2f;
            ID_cell_IB_SA17.PaddingBottom = 5f;
            ID_cell_IB_SA17.BackgroundColor = new BaseColor(255, 255, 255);
            ID_cell_IB_SA17.BorderColor = new BaseColor(208, 211, 212);
            ID_cell_IB_SA17.HorizontalAlignment = 0;
            ID_cell_IB_SA17.BorderWidthBottom = 1;
            ID_cell_IB_SA17.BorderWidthLeft = 0;
            ID_cell_IB_SA17.BorderWidthTop = 0;
            ID_cell_IB_SA17.BorderWidthRight = 1;
            ID_cell_IB_SA17.Bottom = 3f;
            table4.AddCell(ID_cell_IB_SA17);

            table4.SpacingBefore = 10f;
            table4.SpacingAfter = 12.5f;

        }
        public void BilanActifs()
        {
            var liste_annee = service.AnafiAfficheLiasse(7, compar, "", "SN");
            var nombre_annee = service.AnafiAfficheLiasse(8, compar, "", "SN");

            strHTML = sb2.ToString();
            sbt.AppendLine(string.Format("<table id='BA' font size='1'class='table-hover table table-bordered text-center'>"));
            sbt.AppendLine("<tbody>");
            if (liste_annee.Count != 0)
            {

                sb.AppendLine("<table id='' border = '1' font size='1' class='table table-hover table-bordered text-center'>");
                sb.AppendLine("<thead class='table-heigth'    border-radius='3px' border='2px solid #022D65' margin-left='5px'>");
                sb.AppendLine(string.Format("<tr bgcolor='#022D65' color='#FFFFFF' align='center'><th>Actifs</th>"));
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
                                sb.AppendLine(string.Format("<th onclick='transfertval($(this))' width=15% background-color='#022D65'>{0}</th>", lr.ANNEE_DETAIL));
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
                            sb.AppendLine(string.Format("<th onclick='transfertval($(this))' width=15% background-color='#022D65'>{0}</th>", lr.ANNEE_DETAIL));
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
                    if (lr.RUBR_ETAT_CODE.ToString().Trim() == "BAX12" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BA12A" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BA13A"
                        || lr.RUBR_ETAT_CODE.ToString().Trim() == "BA15A" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BAX53" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BAX54" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BA1A"
                        || lr.RUBR_ETAT_CODE.ToString().Trim() == "BA22A" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BA2X9" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BA2A" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BA3A"
                        || lr.RUBR_ETAT_CODE.ToString().Trim() == "BA4A" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BAX11" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BA11B" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BAX13"
                        || lr.RUBR_ETAT_CODE.ToString().Trim() == "BA21A" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BA2X4" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BA14A")
                    {
                    }
                    else
                    {
                        if (lr.RUBR_ETAT_CODE.ToString().Trim() == "BAX21" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BAX22" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BAX23"
                        || lr.RUBR_ETAT_CODE.ToString().Trim() == "BAX24" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BAX31" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BAX32" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BAX35"
                        || lr.RUBR_ETAT_CODE.ToString().Trim() == "BA22A" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BAX51" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BAX52" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BA2X2"
                        || lr.RUBR_ETAT_CODE.ToString().Trim() == "BA2X3" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BA2X8" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BA2X6" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BA2X7"
                        || lr.RUBR_ETAT_CODE.ToString().Trim() == "BA3X1" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BA32A" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BA33A"
                         || lr.RUBR_ETAT_CODE.ToString().Trim() == "BA2X5" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BAX34" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BAX33" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BXA")
                        {
                            if (lr.RUBR_ETAT_CODE.ToString().Trim() == "BXA")
                            {

                                sbt.AppendLine(string.Format("<tr bgcolor='rgba(210, 210, 210, 1);'>"));

                                sbt.AppendLine(string.Format("<td align='left'><strong>&nbsp;&nbsp;&nbsp;<i class=\"glyphicon glyphicon-share-alt gly-flip-vertical \"></i><i style=\"color:#69a8f4\">{0}</i></strong></td>", lr.RUBR_ETAT_LIBELLE));
                                // TabLOTA = new string[Convert.ToInt32(liste_annee.Count)];
                                int p = 0;
                                var liste_valeur3 = service.AnafiAfficheLiasse(9, compar, lr.RUBR_ETAT_CODE.ToString().Trim(), "SN");

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
                                            sbt.AppendLine(string.Format("<td align='right' width=15%><i style=\"color:#69a8f4\">{0}</i></td>", formatMillier(l.VALEUR_B_DETAIL.ToString())));
                                            // TabLOTA[p] = l.VALEUR_B_DETAIL.ToString();
                                            p++;
                                        }

                                    }
                                    else
                                    {
                                        sbt.AppendLine(string.Format("<td align='right' width=15%><i style=\"color:#69a8f4\">{0}</i></td>", formatMillier(l.VALEUR_B_DETAIL.ToString())));
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
                                // sb.AppendLine(string.Format("<td align='left'>{0}</td>", lr.CODE_POSTE.ToString()));
                                sb.AppendLine(string.Format("<td align='left'>&nbsp;&nbsp;&nbsp;<i class=\"glyphicon glyphicon-share-alt gly-flip-vertical \"></i><i style=\"color:#69a8f4\">{0}</i></td>", lr.RUBR_ETAT_LIBELLE.ToString()));

                                var liste_valeur2 = service.AnafiAfficheLiasse(9, compar, lr.RUBR_ETAT_CODE.ToString().Trim(), "SN");

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
                                                sb.AppendLine(string.Format("<td align='right'></td>"));
                                            }
                                            else
                                            {
                                                sb.AppendLine(string.Format("<td align='right' class='text-right {1}'><i  color='#69a8f4' >{0}</i></td>", formatMillier(l.VALEUR_B_DETAIL.ToString()), l.ANNEE_B_DETAIL.Replace("/", "")));
                                            }
                                        }

                                    }
                                    else
                                    {
                                        if (l.RUBR_ETAT_LIBELLE.Trim().Length <= 1)
                                        {
                                            sb.AppendLine(string.Format("<td align='right'></td>"));
                                        }
                                        else
                                        {
                                            sb.AppendLine(string.Format("<td align='right' class='text-right {1}'><i style=\"color:#69a8f4\">{0}</i></td>", formatMillier(l.VALEUR_B_DETAIL.ToString()), l.ANNEE_B_DETAIL.Replace("/", "")));
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
                                        // sb.AppendLine(string.Format("<td align='left'>{0}</td>", lr.CODE_POSTE.ToString()));
                                        sb.AppendLine(string.Format("<td align='left'>{0}</td>", lr.RUBR_ETAT_LIBELLE.ToString()));

                                        var liste_valeur2 = service.AnafiAfficheLiasse(9, compar, lr.RUBR_ETAT_CODE.ToString().Trim(), "SN");

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
                                                        sb.AppendLine(string.Format("<td align='right'></td>"));
                                                    }
                                                    else
                                                    {
                                                        sb.AppendLine(string.Format("<td align='right' class='text-right {1}'>{0}</td>", formatMillier(l.VALEUR_B_DETAIL.ToString()), l.ANNEE_B_DETAIL.Replace("/", "")));
                                                    }
                                                }

                                            }
                                            else
                                            {
                                                if (l.RUBR_ETAT_LIBELLE.Trim().Length <= 1)
                                                {
                                                    sb.AppendLine(string.Format("<td align='right'></td>"));
                                                }
                                                else
                                                {
                                                    sb.AppendLine(string.Format("<td align='right' class='text-right {1}'>{0}</td>", formatMillier(l.VALEUR_B_DETAIL.ToString()), l.ANNEE_B_DETAIL.Replace("/", "")));
                                                }
                                            }
                                        }

                                        sb.AppendLine("</tr>");
                                    }
                                    else
                                    {

                                        sb.AppendLine(string.Format("<tr data_code='{0}' bgcolor='#ddd'>", lr.RUBR_ETAT_CODE.ToString().Trim()));
                                        // sb.AppendLine(string.Format("<td align='left'>{0}</td>", lr.CODE_POSTE.ToString()));


                                        if (lr.RUBR_ETAT_LIBELLE.Trim().Length <= 1)
                                        {
                                            sb.AppendLine(string.Format("<td align='left'color='#FFFFFF'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE.ToString()));
                                        }
                                        else
                                        {
                                            sb.AppendLine(string.Format("<td align='left'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE.ToString()));
                                        }
                                        var liste_valeur1 = service.AnafiAfficheLiasse(9, compar, lr.RUBR_ETAT_CODE.ToString().Trim(), "SN");
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
                                                        sb.AppendLine(string.Format("<td align='right'></td>"));
                                                    }
                                                    else
                                                    {
                                                        sb.AppendLine(string.Format("<td align='right' class='text-right {1}'><strong>{0}</strong></td>", formatMillier(l.VALEUR_B_DETAIL.ToString()), l.ANNEE_B_DETAIL.Replace("/", "")));
                                                    }
                                                }

                                            }
                                            else
                                            {
                                                if (l.RUBR_ETAT_LIBELLE.Trim().Length <= 1)
                                                {
                                                    sb.AppendLine(string.Format("<td align='right'></td>"));
                                                }
                                                else
                                                {
                                                    sb.AppendLine(string.Format("<td align='right' class='text-right {1}'><strong>{0}</strong></td>", formatMillier(l.VALEUR_B_DETAIL.ToString()), l.ANNEE_B_DETAIL.Replace("/", "")));
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
                                            // sb.AppendLine(string.Format("<td align='left'>{0}</td>", lr.CODE_POSTE.ToString()));
                                            sb.AppendLine(string.Format("<td align='left'>{0}</td>", lr.RUBR_ETAT_LIBELLE.ToString()));

                                            var liste_valeur2 = service.AnafiAfficheLiasse(9, compar, lr.RUBR_ETAT_CODE.ToString().Trim(), "SN");

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
                                                            sb.AppendLine(string.Format("<td align='right'></td>"));
                                                        }
                                                        else
                                                        {
                                                            sb.AppendLine(string.Format("<td align='right' class='text-right {1}'>{0}</td>", formatMillier(l.VALEUR_B_DETAIL.ToString()), l.ANNEE_B_DETAIL.Replace("/", "")));
                                                        }
                                                    }

                                                }
                                                else
                                                {
                                                    if (l.RUBR_ETAT_LIBELLE.Trim().Length <= 1)
                                                    {
                                                        sb.AppendLine(string.Format("<td align='right'></td>"));
                                                    }
                                                    else
                                                    {
                                                        sb.AppendLine(string.Format("<td align='right' class='text-right {1}'>{0}</td>", formatMillier(l.VALEUR_B_DETAIL.ToString()), l.ANNEE_B_DETAIL.Replace("/", "")));
                                                    }
                                                }
                                            }

                                            sb.AppendLine("</tr>");
                                        }
                                        else
                                        {
                                            sb.AppendLine(string.Format("<tr data_code='{0}'>", lr.RUBR_ETAT_CODE.ToString().Trim()));
                                            // sb.AppendLine(string.Format("<td align='left'>{0}</td>", lr.CODE_POSTE.ToString()));
                                            sb.AppendLine(string.Format("<td align='left'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE.ToString()));

                                            var liste_valeur2 = service.AnafiAfficheLiasse(9, compar, lr.RUBR_ETAT_CODE.ToString().Trim(), "SN");

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
                                                            sb.AppendLine(string.Format("<td align='right'></td>"));
                                                        }
                                                        else
                                                        {
                                                            sb.AppendLine(string.Format("<td align='right' class='text-right {1}'><strong>{0}</strong></td>", formatMillier(l.VALEUR_B_DETAIL.ToString()), l.ANNEE_B_DETAIL.Replace("/", "")));
                                                        }
                                                    }

                                                }
                                                else
                                                {
                                                    if (l.RUBR_ETAT_LIBELLE.Trim().Length <= 1)
                                                    {
                                                        sb.AppendLine(string.Format("<td align='right'></td>"));
                                                    }
                                                    else
                                                    {
                                                        sb.AppendLine(string.Format("<td align='right' class='text-right {1}'><strong>{0}</strong></td>", formatMillier(l.VALEUR_B_DETAIL.ToString()), l.ANNEE_B_DETAIL.Replace("/", "")));
                                                    }
                                                }
                                            }

                                            sb.AppendLine("</tr>");
                                        }

                                    }
                                    else
                                    {
                                        sb.AppendLine(string.Format("<tr data_code='{0}'>", lr.RUBR_ETAT_CODE.ToString().Trim()));
                                        // sb.AppendLine(string.Format("<td align='left'>{0}</td>", lr.CODE_POSTE.ToString()));
                                        sb.AppendLine(string.Format("<td align='left'>{0}</td>", lr.RUBR_ETAT_LIBELLE.ToString()));

                                        var liste_valeur2 = service.AnafiAfficheLiasse(9, compar, lr.RUBR_ETAT_CODE.ToString().Trim(), "SN");

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
                                                        sb.AppendLine(string.Format("<td align='right'></td>"));
                                                    }
                                                    else
                                                    {
                                                        sb.AppendLine(string.Format("<td align='right' class='text-right {1}'>{0}</td>", formatMillier(l.VALEUR_B_DETAIL.ToString()), l.ANNEE_B_DETAIL.Replace("/", "")));
                                                    }
                                                }

                                            }
                                            else
                                            {
                                                if (l.RUBR_ETAT_LIBELLE.Trim().Length <= 1)
                                                {
                                                    sb.AppendLine(string.Format("<td align='right'></td>"));
                                                }
                                                else
                                                {
                                                    sb.AppendLine(string.Format("<td align='right' class='text-right {1}'>{0}</td>", formatMillier(l.VALEUR_B_DETAIL.ToString()), l.ANNEE_B_DETAIL.Replace("/", "")));
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
                                sbt.AppendLine(string.Format("<tr bgcolor='#EAF2F8'>"));

                                sbt.AppendLine(string.Format("<td align='left'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE));
                                // TabLOTA = new string[Convert.ToInt32(liste_annee.Count)];
                                int p = 0;
                                var liste_valeur3 = service.AnafiAfficheLiasse(9, compar, lr.RUBR_ETAT_CODE.ToString().Trim(), "SN");

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
                                            sbt.AppendLine(string.Format("<td align='right' width=15%>{0}</td>", formatMillier(l.VALEUR_B_DETAIL.ToString())));
                                            // TabLOTA[p] = l.VALEUR_B_DETAIL.ToString();
                                            p++;
                                        }

                                    }
                                    else
                                    {
                                        sbt.AppendLine(string.Format("<td align='right' width=15%>{0}</td>", formatMillier(l.VALEUR_B_DETAIL.ToString())));
                                        // TabLOTA[p] = l.VALEUR_B_DETAIL.ToString();
                                        p++;
                                    }
                                }
                                sbt.AppendLine("</tr>");

                                sb.AppendLine(string.Format("<tr bgcolor='#EAF2F8'>"));

                                sb.AppendLine(string.Format("<td align='left'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE));
                                // TabLOTA = new string[Convert.ToInt32(liste_annee.Count)];
                                //int p = 0;
                                var liste_valeur4 = service.AnafiAfficheLiasse(9, compar, lr.RUBR_ETAT_CODE.ToString().Trim(), "SN");

                                int t = 0;
                                int u = 0;
                                u = Convert.ToInt32(liste_valeur4.Count) - 3;
                                foreach (var l in liste_valeur4)
                                {

                                    if (liste_valeur4.Count > 3)
                                    {
                                        t++;
                                        if (u < t)
                                        {
                                            sb.AppendLine(string.Format("<td align='right' width=15%>{0}</td>", formatMillier(l.VALEUR_B_DETAIL.ToString())));
                                            // TabLOTA[p] = l.VALEUR_B_DETAIL.ToString();
                                            //p++;
                                        }

                                    }
                                    else
                                    {
                                        sb.AppendLine(string.Format("<td align='right' width=15%>{0}</td>", formatMillier(l.VALEUR_B_DETAIL.ToString())));
                                        // TabLOTA[p] = l.VALEUR_B_DETAIL.ToString();
                                        //p++;
                                    }
                                }
                                sb.AppendLine("</tr>");
                            }


                        }

                    }


                }

                sb.AppendLine("</tbody>");
                sb.AppendLine("</table>");
            }
            else
            {
                sb.AppendLine("<table id='' border = '1' font size='1' class='table table-hover table-bordered text-center'>");
                sb.AppendLine("<thead class='table-heigth'    border-radius='3px' border='2px solid #022D65' margin-left='5px'>");
                sb.AppendLine(string.Format("<tr bgcolor='#022D65' color='#FFFFFF' align='center'><th>Actifs</th>"));
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
                                    sb.AppendLine(string.Format("<tr data_code='{0}' bgcolor='#ddd'>", lr.RUBR_ETAT_CODE.ToString().Trim()));
                                    // sb.AppendLine(string.Format("<td class='text-left'>{0}</td>", lr.CODE_POSTE.ToString()));


                                    if (lr.RUBR_ETAT_LIBELLE.Trim().Length <= 1)
                                    {
                                        sb.AppendLine(string.Format("<td class='text-left' color='#FFFFFF'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE.ToString()));
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
                            sb.AppendLine(string.Format("<tr bgcolor='#EAF2F8' data_code='{0}'>", lr.RUBR_ETAT_CODE.ToString().Trim()));

                            sb.AppendLine(string.Format("<td class='text-left'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE));
                            sb.AppendLine(string.Format("<td width=23%></td>"));
                            sb.AppendLine("</tr>");

                            sbt.AppendLine(string.Format("<tr bgcolor='#EAF2F8' data_code='{0}'>", lr.RUBR_ETAT_CODE.ToString().Trim()));

                            sbt.AppendLine(string.Format("<td class='text-left'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE));
                            sbt.AppendLine(string.Format("<td width=23%></td>"));
                            sbt.AppendLine("</tr>");
                            //sbt.AppendLine("</table>");
                            //DIVtotauxActif.InnerHtml = sbt.ToString();


                        }
                    }
                }

                sb.AppendLine("</tbody>");
                sb.AppendLine("</table>");
            }

            HTML = sb.ToString();
        }
        public void BilanPassifs()
        {
            var liste_annee = service.AnafiAfficheLiasse(7, compar, "", "SN");
            var nombre_annee = service.AnafiAfficheLiasse(8, compar, "", "SN");
            if (liste_annee.Count != 0)
            {
                sbE.AppendLine("<table id='' border = '1' font size='1' class='table table-hover table-bordered text-center'>");
                sbE.AppendLine("<thead class='table-heigth'>");
                sbE.AppendLine(string.Format("<tr bgcolor='#022D65' color='#FFFFFF' align='center'><th>Passifs</th>"));

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
                                sbE.AppendLine(string.Format("<th onclick='transfertval($(this))' width=15%>{0}</th>", lr.ANNEE_DETAIL));
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
                            sbE.AppendLine(string.Format("<th onclick='transfertval($(this))' width=15%>{0}</th>", lr.ANNEE_DETAIL));
                        }
                        i++;
                    }
                }

                sbE.AppendLine("</thead>");
                sbE.AppendLine("<tbody>");

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
                            sbE.AppendLine(string.Format("<tr data_code='{0}' bgcolor='#ddd'>", lr.RUBR_ETAT_CODE.ToString().Trim()));
                            if (lr.RUBR_ETAT_LIBELLE.Trim().Length <= 1)
                            {
                                sbE.AppendLine(string.Format("<td align='left' color='#FFFFFF'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE.ToString()));
                            }
                            else
                            {
                                sbE.AppendLine(string.Format("<td align='left'><strong><strong>{0}</strong></strong></td>", lr.RUBR_ETAT_LIBELLE.ToString()));
                            }
                            var liste_valeur4 = service.AnafiAfficheLiasse(9, compar, lr.RUBR_ETAT_CODE.ToString().Trim(), "SN");
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
                                        sbE.AppendLine(string.Format("<td align='right' class='text-right {1}' width=15%><strong><strong>{0}</strong></strong></td>", formatMillier(l.VALEUR_B_DETAIL.ToString()), l.ANNEE_B_DETAIL.Replace("/", "")));
                                    }

                                }
                                else
                                {
                                    sbE.AppendLine(string.Format("<td align='right' class='text-right {1}' width=15%><strong><strong>{0}</strong></strong></td>", formatMillier(l.VALEUR_B_DETAIL.ToString()), l.ANNEE_B_DETAIL.Replace("/", "")));
                                }
                            }


                            sbE.AppendLine("</tr>");
                        }
                        else
                        {
                            if (lr.RUBR_ETAT_CODE.ToString().Trim() == "BP1")
                            {
                                sbE.AppendLine(string.Format("<tr data_code='{0}' bgcolor='##b7abab'>", lr.RUBR_ETAT_CODE.ToString().Trim()));
                                if (lr.RUBR_ETAT_LIBELLE.Trim().Length <= 1)
                                {
                                    sbE.AppendLine(string.Format("<td align='left' color='#FFFFFF'>{0}</td>", lr.RUBR_ETAT_LIBELLE.ToString()));
                                }
                                else
                                {
                                    sbE.AppendLine(string.Format("<td align='left'>{0}</td>", lr.RUBR_ETAT_LIBELLE.ToString()));
                                }
                                var liste_valeur4 = service.AnafiAfficheLiasse(9, compar, lr.RUBR_ETAT_CODE.ToString().Trim(), "SN");
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
                                            sbE.AppendLine(string.Format("<td align='right' class='text-right {1}' width=15%>{0}</td>", formatMillier(l.VALEUR_B_DETAIL.ToString()), l.ANNEE_B_DETAIL.Replace("/", "")));
                                        }

                                    }
                                    else
                                    {
                                        sbE.AppendLine(string.Format("<td align='right' class='text-right {1}' width=15%>{0}</td>", formatMillier(l.VALEUR_B_DETAIL.ToString()), l.ANNEE_B_DETAIL.Replace("/", "")));
                                    }
                                }


                                sbE.AppendLine("</tr>");
                            }
                            else
                            {
                                if (lr.RUBR_ETAT_CODE.ToString().Trim() == "BP1A1" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BP1A3" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BP1A9" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BP1AX")
                                {
                                    sbE.AppendLine(string.Format("<tr data_code='{0}'>", lr.RUBR_ETAT_CODE.ToString().Trim()));
                                    sbE.AppendLine(string.Format("<td align='left'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE.ToString()));

                                    var liste_valeur5 = service.AnafiAfficheLiasse(9, compar, lr.RUBR_ETAT_CODE.ToString().Trim(), "SN");
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
                                                    sbE.AppendLine(string.Format("<td align='right' width=15%></td>"));
                                                }
                                                else
                                                {
                                                    sbE.AppendLine(string.Format("<td align='right' class='text-right {1}' width=15%><strong>{0}</strong></td>", formatMillier(l.VALEUR_B_DETAIL.ToString()), l.ANNEE_B_DETAIL.Replace("/", "")));
                                                }
                                            }

                                        }
                                        else
                                        {
                                            if (l.RUBR_ETAT_LIBELLE.Trim().Length <= 1)
                                            {
                                                sbE.AppendLine(string.Format("<td align='right' width=15%></td>"));
                                            }
                                            else
                                            {
                                                sbE.AppendLine(string.Format("<td align='right' class='text-right {1}' width=15%><strong>{0}</strong></td>", formatMillier(l.VALEUR_B_DETAIL.ToString()), l.ANNEE_B_DETAIL.Replace("/", "")));
                                            }
                                        }
                                    }

                                    sbE.AppendLine("</tr>");

                                }
                                else
                                {

                                    sbE.AppendLine(string.Format("<tr data_code='{0}'>", lr.RUBR_ETAT_CODE.ToString().Trim()));
                                    sbE.AppendLine(string.Format("<td align='left'>{0}</td>", lr.RUBR_ETAT_LIBELLE.ToString()));

                                    var liste_valeur5 = service.AnafiAfficheLiasse(9, compar, lr.RUBR_ETAT_CODE.ToString().Trim(), "SN");
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
                                                    sbE.AppendLine(string.Format("<td align='right' width=15%></td>"));
                                                }
                                                else
                                                {
                                                    sbE.AppendLine(string.Format("<td align='right' class='text-right {1}' width=15%>{0}</td>", formatMillier(l.VALEUR_B_DETAIL.ToString()), l.ANNEE_B_DETAIL.Replace("/", "")));
                                                }
                                            }

                                        }
                                        else
                                        {
                                            if (l.RUBR_ETAT_LIBELLE.Trim().Length <= 1)
                                            {
                                                sbE.AppendLine(string.Format("<td align='right' width=15%></td>"));
                                            }
                                            else
                                            {
                                                sbE.AppendLine(string.Format("<td align='right' class='text-right {1}' width=15%>{0}</td>", formatMillier(l.VALEUR_B_DETAIL.ToString()), l.ANNEE_B_DETAIL.Replace("/", "")));
                                            }
                                        }
                                    }

                                    sbE.AppendLine("</tr>");
                                }

                            }
                        }
                    }
                    if (lr.RUBR_ETAT_CODE.Trim() == "BP")
                    {
                        sbE.AppendLine(string.Format("<tr bgcolor='#EAF2F8'>"));

                        sbE.AppendLine(string.Format("<td align='left'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE));
                        int p = 0;
                        var liste_valeur6 = service.AnafiAfficheLiasse(9, compar, lr.RUBR_ETAT_CODE.ToString().Trim(), "SN");
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
                                    sbE.AppendLine(string.Format("<td align='right' width=15%>{0}</td>", formatMillier(l.VALEUR_B_DETAIL.ToString())));
                                    p++;
                                }

                            }
                            else
                            {
                                sbE.AppendLine(string.Format("<td align='right' width=15%>{0}</td>", formatMillier(l.VALEUR_B_DETAIL.ToString())));
                                p++;
                            }
                        }
                        sbE.AppendLine("</tr>");
                    }
                }

                sbE.AppendLine("</tbody>");
                sbE.AppendLine("</table>");

            }
            else
            {
                sbE.AppendLine("<table id='' border = '1' font size='1' class='table table-hover table-bordered text-center'>");
                sbE.AppendLine("<thead class='table-heigth'>");
                sbE.AppendLine(string.Format("<tr bgcolor='#022D65' color='#FFFFFF' align='center'><th>Passifs</th>"));
                sbE.AppendLine(string.Format("<th width=23%></th>"));

                sbE.AppendLine("</thead>");
                sbE.AppendLine("<tbody>");

                var liste_libelle = service.AnafiAfficheLiasse(0, "", "", "BIN");

                foreach (var lr in liste_libelle)
                {
                    if (lr.RUBR_ETAT_LIBELLE.ToString() != "Ecart")
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
                                sbE.AppendLine(string.Format("<tr data_code='{0}' bgcolor='#ddd'>", lr.RUBR_ETAT_CODE.ToString().Trim()));
                                if (lr.RUBR_ETAT_LIBELLE.Trim().Length <= 1)
                                {
                                    sbE.AppendLine(string.Format("<td class='text-left' color='#FFFFFF'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE.ToString()));
                                    sbE.AppendLine(string.Format("<td></td>"));
                                }
                                else
                                {
                                    sbE.AppendLine(string.Format("<td class='text-left'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE.ToString()));
                                    sbE.AppendLine(string.Format("<td></td>"));
                                }
                                sb.AppendLine("</tr>");
                            }
                            else
                            {
                                if (lr.RUBR_ETAT_CODE.ToString().Trim() == "BP1")
                                {
                                    sbE.AppendLine(string.Format("<tr data_code='{0}' bgcolor='#b7abab'>", lr.RUBR_ETAT_CODE.ToString().Trim()));
                                    if (lr.RUBR_ETAT_LIBELLE.Trim().Length <= 1)
                                    {
                                        sbE.AppendLine(string.Format("<td class='text-left' color='#FFFFFF'>{0}</td>", lr.RUBR_ETAT_LIBELLE.ToString()));
                                        sbE.AppendLine(string.Format("<td></td>"));
                                    }
                                    else
                                    {
                                        sbE.AppendLine(string.Format("<td class='text-left'>{0}</td>", lr.RUBR_ETAT_LIBELLE.ToString()));
                                        sbE.AppendLine(string.Format("<td></td>"));
                                    }
                                    sb.AppendLine("</tr>");
                                }
                                else
                                {
                                    if (lr.RUBR_ETAT_CODE.ToString().Trim() == "BP1A1" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BP1A3" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BP1A9" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BP1AX")
                                    {
                                        sbE.AppendLine(string.Format("<tr data_code='{0}'>", lr.RUBR_ETAT_CODE.ToString().Trim()));
                                        sbE.AppendLine(string.Format("<td class='text-left'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE.ToString()));

                                        sbE.AppendLine(string.Format("<td></td>"));

                                        sbE.AppendLine("</tr>");

                                    }
                                    else
                                    {

                                        sbE.AppendLine(string.Format("<tr data_code='{0}'>", lr.RUBR_ETAT_CODE.ToString().Trim()));
                                        sbE.AppendLine(string.Format("<td class='text-left'>{0}</td>", lr.RUBR_ETAT_LIBELLE.ToString()));
                                        sbE.AppendLine(string.Format("<td></td>"));


                                        sbE.AppendLine("</tr>");
                                    }

                                }
                            }
                        }
                        if (lr.RUBR_ETAT_CODE.Trim() == "BP")
                        {
                            sbE.AppendLine(string.Format("<tr bgcolor='#EAF2F8'>"));

                            sbE.AppendLine(string.Format("<td class='text-left'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE));
                            sbE.AppendLine(string.Format("<td width=23%></td>"));
                            sbE.AppendLine("</tr>");

                        }
                    }

                }

                sbE.AppendLine("</tbody>");
                sbE.AppendLine("</table>");
            }
        }
        public void BilanEcarts()
        {
            var liste_annee = service.AnafiAfficheLiasse(7, compar, "", "SN");
            var nombre_annee = service.AnafiAfficheLiasse(8, compar, "", "SN");

            if (liste_annee.Count != 0)
            {

                sbEcart.AppendLine("<table id='' style='border-style: dotted !important; border-color:#D0D3D4;' border = '1' font size='1' class='table table-hover table-bordered text-center'>");
                sbEcart.AppendLine("<thead class='table-heigth'    border-radius='3px' border='2px solid #022D65' margin-left='5px'>");
                sbEcart.AppendLine(string.Format("<tr bgcolor='#022D65' color='#FFFFFF'  align='center'><th>Ecrats des totaux</th>"));
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
                                sbEcart.AppendLine(string.Format("<th onclick='transfertval($(this))' width=15% background-color='#022D65'>{0}</th>", lr.ANNEE_DETAIL));
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
                            sbEcart.AppendLine(string.Format("<th onclick='transfertval($(this))' width=15% background-color='#022D65'>{0}</th>", lr.ANNEE_DETAIL));
                        }
                        i++;
                    }
                }


                sbEcart.AppendLine("</thead>");
                sbEcart.AppendLine("<tbody>");

                var liste_libelle = service.AnafiAfficheLiasse(0, "", "", "BIN");

                int limite = 0;

                foreach (var lr in liste_libelle)
                {
                    limite++;
                    if (lr.RUBR_ETAT_CODE.Trim() == "BA")
                    {

                        sbEcart.AppendLine(string.Format("<tr >"));

                        sbEcart.AppendLine(string.Format("<td align='left'><strong>{0}</strong></td>", "TOTAL GÉNERAL DES ACTIFS"));

                        var liste_valeur4 = service.AnafiAfficheLiasse(9, compar, lr.RUBR_ETAT_CODE.ToString().Trim(), "SN");

                        int t = 0;
                        int u = 0;
                        int i = 0;
                        u = Convert.ToInt32(liste_valeur4.Count) - 3;
                        foreach (var l in liste_valeur4)
                        {

                            if (liste_valeur4.Count > 3)
                            {
                                t++;
                                if (u < t)
                                {

                                    sbEcart.AppendLine(string.Format("<td align='right' width=15%>{0}</td>", formatMillier(l.VALEUR_B_DETAIL.ToString())));
                                    TabLOTECART[i] = Convert.ToDouble(l.VALEUR_B_DETAIL);
                                    i++;
                                }

                            }
                            else
                            {
                                sbEcart.AppendLine(string.Format("<td align='right' width=15%>{0}</td>", formatMillier(l.VALEUR_B_DETAIL.ToString())));
                                TabLOTECART[i] = Convert.ToDouble(l.VALEUR_B_DETAIL);
                                i++;
                            }

                        }
                        sbEcart.AppendLine("</tr>");
                    }

                    if (lr.RUBR_ETAT_CODE.Trim() == "BP")
                    {
                        sbEcart.AppendLine(string.Format("<tr >"));

                        sbEcart.AppendLine(string.Format("<td align='left'><strong>{0}</strong></td>", "TOTAL GÉNERAL DES PASSIFS"));

                        int p = 0;
                        var liste_valeur6 = service.AnafiAfficheLiasse(9, compar, lr.RUBR_ETAT_CODE.ToString().Trim(), "SN");
                        int j = 0;
                        int v = 0;
                        v = Convert.ToInt32(liste_valeur6.Count) - 3;
                        int i = 0;
                        foreach (var l in liste_valeur6)
                        {

                            if (liste_valeur6.Count > 3)
                            {
                                j++;
                                if (v < j)
                                {
                                    var testjkjh = formatMillier(l.VALEUR_B_DETAIL.ToString()).Replace(" ", "&nbsp;");
                                    sbEcart.AppendLine(string.Format("<td align='right' width=15%>{0}</td>", formatMillier(l.VALEUR_B_DETAIL.ToString()).Replace(" ", "&nbsp;")));
                                    TabLOTECART1[i] = Convert.ToDouble(l.VALEUR_B_DETAIL);
                                    i++;
                                    p++;
                                }

                            }
                            else
                            {
                                var testjkjh = formatMillier(l.VALEUR_B_DETAIL.ToString()).Replace("&nbsp;", " ");
                                sbEcart.AppendLine(string.Format("<td align='right' width=15%>{0}</td>", formatMillier(l.VALEUR_B_DETAIL.ToString())));
                                TabLOTECART1[i] = Convert.ToDouble(l.VALEUR_B_DETAIL);
                                i++;
                                p++;
                            }
                            //i++;
                        }
                        sbt.AppendLine("</tr>");



                        if (limite == liste_libelle.Count)
                        {

                            sbEcart.AppendLine(string.Format("<tr >"));

                            sbEcart.AppendLine(string.Format("<td align='left'><strong>{0}</strong></td>", "ECARTS"));

                            var liste_valeur4 = service.AnafiAfficheLiasse(9, compar, lr.RUBR_ETAT_CODE.ToString().Trim(), "SN");

                            int t = 0;
                            int u = 0;
                            int b = 0;
                            u = Convert.ToInt32(liste_valeur4.Count) - 3;
                            foreach (var l in liste_valeur4)
                            {

                                if (liste_valeur4.Count > 3)
                                {
                                    t++;
                                    if (u < t)
                                    {
                                        double nombre = TabLOTECART[b] - TabLOTECART1[b];
                                        if (nombre == 0)
                                        {
                                            sbEcart.AppendLine(string.Format("<td align='right' width=15%>{0}</td>", formatMillier(nombre.ToString())));

                                        }
                                        else
                                        {
                                            sbEcart.AppendLine(string.Format("<td align='right' color='#FF5733' width=15%>{0}</td>", formatMillier(nombre.ToString())));

                                        }
                                        b++;
                                    }

                                }
                                else
                                {
                                    double nombre = TabLOTECART[b] - TabLOTECART1[b];
                                    if (nombre == 0)
                                    {
                                        sbEcart.AppendLine(string.Format("<td align='right' width=15%>{0}</td>", formatMillier(nombre.ToString())));
                                    }
                                    else
                                    {
                                        sbEcart.AppendLine(string.Format("<td align='right' color='#FF5733' width=15%>{0}</td>", formatMillier(nombre.ToString())));
                                    }
                                    b++;
                                }


                            }
                            sbEcart.AppendLine("</tr>");

                        }

                    }
                }
                sbEcart.AppendLine("</tbody>");
                sbEcart.AppendLine("</table>");
            }
            else
            {
                sbEcart.AppendLine("<table id='' style='border-style: dotted !important; border-color:#D0D3D4;'  border = '1' font size='1' class='table table-hover table-bordered text-center'>");
                sbEcart.AppendLine("<thead class='table-heigth'    border-radius='3px' border='2px solid #022D65' margin-left='5px'>");
                sbEcart.AppendLine(string.Format("<tr bgcolor='#E4EBF5'  align='center'><th>Ecrats des totaux</th>"));
                sbEcart.AppendLine(string.Format("<th width=23%></th>"));
                sbEcart.AppendLine("</thead>");
                sbEcart.AppendLine("<tbody>");
                sbEcart.AppendLine(string.Format("<tr >"));
                sbEcart.AppendLine(string.Format("<td align='left'><strong>{0}</strong></td>", "TOTAL GÉNERAL DES ACTIFS"));
                sbEcart.AppendLine(string.Format("<td width=23%></td>"));
                sbEcart.AppendLine("</tr>");

                sbEcart.AppendLine(string.Format("<tr >"));
                sbEcart.AppendLine(string.Format("<td align='left'><strong>{0}</strong></td>", "TOTAL GÉNERAL DES PASSIFS"));
                sbEcart.AppendLine(string.Format("<td width=23%></td>"));
                sbEcart.AppendLine("</tr>");

                sbEcart.AppendLine(string.Format("<tr >"));
                sbEcart.AppendLine(string.Format("<td align='left'><strong>{0}</strong></td>", "ECARTS"));
                sbEcart.AppendLine(string.Format("<td width=23%></td>"));
                sbEcart.AppendLine("</tr>");

                sbEcart.AppendLine("</tbody>");
                sbEcart.AppendLine("</table>");
            }

            Type_anafi = "BN";
        }
        public void CompteResultatsCharge()
        {
            var liste_annee = service.AnafiAfficheLiasse(7, compar, "", "SN");
            var nombre_annee = service.AnafiAfficheLiasse(8, compar, "", "SN");

            if (liste_annee.Count != 0)
            {
                sbC.AppendLine("<table id='' border = '1' font size='1' class='table table-hover table-bordered text-center'>");
                sbC.AppendLine("<thead class='table-heigth'>");
                sbC.AppendLine(string.Format("<tr bgcolor='#022D65' color='#FFFFFF' align='center'><th>Charges</th>"));

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
                                sbC.AppendLine(string.Format("<th onclick='transfertval($(this))' width=15%>{0}</th>", lr.ANNEE_DETAIL));
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
                            sbC.AppendLine(string.Format("<th onclick='transfertval($(this))' width=15%>{0}</th>", lr.ANNEE_DETAIL));
                        }
                        i++;
                    }
                }
                sbC.AppendLine("</thead>");
                sbC.AppendLine("<tbody>");

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
                            sbC.AppendLine(string.Format("<tr data_code='{0}' bgcolor='#ddd'>", lr.RUBR_ETAT_CODE.ToString().Trim()));


                            if (lr.RUBR_ETAT_LIBELLE.Trim().Length <= 1)
                            {
                                sbC.AppendLine(string.Format("<td align='left' color='#FFFFFF'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE.ToString()));
                            }
                            else
                            {
                                sbC.AppendLine(string.Format("<td align='left'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE.ToString()));
                            }

                            var liste_valeur = service.AnafiAfficheLiasse(10, compar, lr.RUBR_ETAT_CODE.ToString().Trim(), "SN");

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
                                            sbC.AppendLine(string.Format("<td align='right'></td>"));
                                        }
                                        else
                                        {
                                            sbC.AppendLine(string.Format("<td align='right' class='text-right {1}'><strong>{0}</strong></td>", formatMillier(l.VALEUR_CR_DETAIL.ToString()), l.ANNEE_CR_DETAIL.Replace("/", "")));

                                            // sbC.AppendLine(string.Format("<td align='right'><strong>{0}</strong></td>", formatMillier(l.VALEUR_CR_DETAIL.ToString())));
                                        }
                                    }

                                }
                                else
                                {
                                    if (l.RUBR_ETAT_LIBELLE.Trim().Length <= 1)
                                    {
                                        sbC.AppendLine(string.Format("<td align='right'></td>"));
                                    }
                                    else
                                    {
                                        sbC.AppendLine(string.Format("<td align='right' class='text-right {1}'><strong>{0}</strong></td>", formatMillier(l.VALEUR_CR_DETAIL.ToString()), l.ANNEE_CR_DETAIL.Replace("/", "")));
                                    }
                                }
                            }




                            sbC.AppendLine("</tr>");
                        }
                        else
                        {
                            sbC.AppendLine(string.Format("<tr data_code='{0}'>", lr.RUBR_ETAT_CODE.ToString().Trim()));
                            sbC.AppendLine(string.Format("<td align='left'>{0}</td>", lr.RUBR_ETAT_LIBELLE.ToString()));

                            var liste_valeur = service.AnafiAfficheLiasse(10, compar, lr.RUBR_ETAT_CODE.ToString().Trim(), "SN");
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
                                            sbC.AppendLine(string.Format("<td align='right'></td>"));
                                        }
                                        else
                                        {
                                            sbC.AppendLine(string.Format("<td align='right' class='text-right {1}'>{0}</td>", formatMillier(l.VALEUR_CR_DETAIL.ToString()), l.ANNEE_CR_DETAIL.Replace("/", "")));

                                        }
                                    }

                                }
                                else
                                {
                                    if (l.RUBR_ETAT_LIBELLE.Trim().Length <= 1)
                                    {
                                        sbC.AppendLine(string.Format("<td align='right'></td>"));
                                    }
                                    else
                                    {
                                        sbC.AppendLine(string.Format("<td align='right' class='text-right {1}'>{0}</td>", formatMillier(l.VALEUR_CR_DETAIL.ToString()), l.ANNEE_CR_DETAIL.Replace("/", "")));
                                    }
                                }
                            }


                            sbC.AppendLine("</tr>");

                        }
                    }

                    if (lr.RUBR_ETAT_CODE.Trim() == "CC")
                    {
                        //sbt.AppendLine(string.Format("<table id='{0}' class='table-hover table table-bordered text-center'>", lr.RUBR_ETAT_CODE.Trim()));
                        sbC.AppendLine(string.Format("<tr bgcolor='#EAF2F8'>"));

                        sbC.AppendLine(string.Format("<td align='left'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE));
                        int p = 0;
                        var liste_valeur = service.AnafiAfficheLiasse(10, compar, lr.RUBR_ETAT_CODE.ToString().Trim(), "SN");

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
                                    sbC.AppendLine(string.Format("<td  width=15% align='right'><strong>{0}</strong></td>", formatMillier(l.VALEUR_CR_DETAIL.ToString())));
                                    p++;
                                }

                            }
                            else
                            {
                                sbC.AppendLine(string.Format("<td  width=15% align='right'><strong>{0}</strong></td>", formatMillier(l.VALEUR_CR_DETAIL.ToString())));
                                p++;
                            }
                        }
                        sbC.AppendLine("</tr>");
                    }

                }

                sbC.AppendLine("</tbody>");
                sbC.AppendLine("</table>");
            }
            else
            {
                sbC.AppendLine("<table id='' border = '1' font size='1'  class='table table-hover table-bordered text-center'>");
                sbC.AppendLine("<thead class='table-heigth'>");
                sbC.AppendLine(string.Format("<tr bgcolor='#022D65' color='#FFFFFF' align='center'><th>Charges</th>"));
                sbC.AppendLine(string.Format("<th width=23%></th>"));

                sbC.AppendLine("</thead>");
                sbC.AppendLine("<tbody>");

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
                            sbC.AppendLine(string.Format("<tr data_code='{0}' bgcolor='#ddd' >", lr.RUBR_ETAT_CODE.ToString().Trim()));


                            if (lr.RUBR_ETAT_LIBELLE.Trim().Length <= 1)
                            {
                                sbC.AppendLine(string.Format("<td align='left' color='#FFFFFF'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE.ToString()));
                                sbC.AppendLine(string.Format("<td></td>"));
                            }
                            else
                            {
                                sbC.AppendLine(string.Format("<td align='left'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE.ToString()));
                                sbC.AppendLine(string.Format("<td></td>"));
                            }


                            sbC.AppendLine("</tr>");
                        }
                        else
                        {
                            sbC.AppendLine(string.Format("<tr data_code='{0}'>", lr.RUBR_ETAT_CODE.ToString().Trim()));
                            sbC.AppendLine(string.Format("<td align='left'>{0}</td>", lr.RUBR_ETAT_LIBELLE.ToString()));
                            sbC.AppendLine(string.Format("<td></td>"));
                            sbC.AppendLine("</tr>");

                        }
                    }

                    if (lr.RUBR_ETAT_CODE.Trim() == "CC")
                    {
                        //sbt.AppendLine(string.Format("<table id='{0}' border = '1' font size='1'  class='table-hover table table-bordered text-center'>", lr.RUBR_ETAT_CODE.Trim()));
                        sbC.AppendLine(string.Format("<tr bgcolor='#EAF2F8'>"));

                        sbC.AppendLine(string.Format("<td align='left'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE));
                        sbC.AppendLine(string.Format("<td width='23%'></td>"));
                        sbC.AppendLine("</tr>");

                    }

                }

                sbC.AppendLine("</tbody>");
                sbC.AppendLine("</table>");
            }

        }
        public void CompteResultatsProduits()
        {
            var liste_annee = service.AnafiAfficheLiasse(7, compar, "", "SN");
            var nombre_annee = service.AnafiAfficheLiasse(8, compar, "", "SN");

            //debut produit 
            //si liste des année est superrieur à 0

            if (liste_annee.Count != 0)
            {
                sbB.AppendLine("<table id='' border = '1' font size='1' class='table table-hover table-bordered text-center'>");
                sbB.AppendLine("<thead class='table-heigth'>");
                sbB.AppendLine(string.Format("<tr bgcolor='#022D65' color='#FFFFFF' align='center'><th>Produits</th>"));

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
                                sbB.AppendLine(string.Format("<th onclick='transfertval($(this))' width=15%>{0}</th>", lr.ANNEE_DETAIL));
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
                            sbB.AppendLine(string.Format("<th onclick='transfertval($(this))' width=15%>{0}</th>", lr.ANNEE_DETAIL));
                            //TabLOT[i] = lr.ANNEE_DETAIL;
                        }
                        i++;
                    }
                }

                sbB.AppendLine("</thead>");
                sbB.AppendLine("<tbody>");

                var liste_libelle = service.AnafiAfficheLiasse(0, "", "", "CRN");

                //sbv.AppendLine(string.Format("<table id='' class='table-hover table table-bordered text-center matb'>", lr.RUBR_ETAT_CODE.Trim()));
                sbv.AppendLine(string.Format("<table id='' border = '1' font size='1'  class='table-hover table table-bordered text-center matb'>"));
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
                                    sbB.AppendLine(string.Format("<tr bgcolor='#EAF2F8' data_code='{0}'>", lr.RUBR_ETAT_CODE.ToString().Trim()));
                                    sbB.AppendLine(string.Format("<td align='left'>{0}</td>", lr.RUBR_ETAT_LIBELLE.ToString()));

                                    var liste_valeur = service.AnafiAfficheLiasse(10, compar, lr.RUBR_ETAT_CODE.ToString().Trim(), "SN");
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
                                                    sbB.AppendLine(string.Format("<td align='right'></td>"));
                                                }
                                                else
                                                {
                                                    sbB.AppendLine(string.Format("<td align='right' class='text-right {1}'>{0}</td>", formatMillier(l.VALEUR_CR_DETAIL.ToString()), l.ANNEE_CR_DETAIL.Replace("/", "")));

                                                    //sbv.AppendLine(string.Format("<td align='right'>{0}</td>", formatMillier(l.VALEUR_CR_DETAIL.ToString())));
                                                }
                                            }

                                        }
                                        else
                                        {
                                            if (l.RUBR_ETAT_LIBELLE.Trim().Length <= 1)
                                            {
                                                sbB.AppendLine(string.Format("<td align='right'></td>"));
                                            }
                                            else
                                            {
                                                sbB.AppendLine(string.Format("<td align='right' class='text-right {1}'>{0}</td>", formatMillier(l.VALEUR_CR_DETAIL.ToString()), l.ANNEE_CR_DETAIL.Replace("/", "")));

                                                //sbv.AppendLine(string.Format("<td align='right'>{0}</td>", formatMillier(l.VALEUR_CR_DETAIL.ToString())));
                                            }
                                        }
                                    }

                                    sbB.AppendLine("</tr>");
                                }
                                else
                                {
                                    sbB.AppendLine(string.Format("<tr bgcolor='#EAF2F8'>"));

                                    if (lr.RUBR_ETAT_LIBELLE.Trim().Length <= 1)
                                    {
                                        sbB.AppendLine(string.Format("<td align='left' color='#FFFFFF'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE.ToString()));
                                    }
                                    else
                                    {
                                        sbB.AppendLine(string.Format("<td align='left'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE.ToString()));
                                    }
                                    var liste_valeur = service.AnafiAfficheLiasse(10, compar, lr.RUBR_ETAT_CODE.ToString().Trim(), "SN");
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
                                                sbB.AppendLine(string.Format("<td width=15%  align='right' class='text-right {1}'><strong>{0}</strong></td>", formatMillier(l.VALEUR_CR_DETAIL.ToString()), l.ANNEE_CR_DETAIL.Replace("/", "")));

                                                // sbv.AppendLine(string.Format("<td  width=15% align='right'><strong>{0}</strong></td>", formatMillier(l.VALEUR_CR_DETAIL.ToString())));
                                            }

                                        }
                                        else
                                        {
                                            sbB.AppendLine(string.Format("<td width=15% align='right' class='text-right {1}'><strong>{0}</strong></td>", formatMillier(l.VALEUR_CR_DETAIL.ToString()), l.ANNEE_CR_DETAIL.Replace("/", "")));

                                            //sbv.AppendLine(string.Format("<td  width=15% align='right'><strong>{0}</strong></td>", formatMillier(l.VALEUR_CR_DETAIL.ToString())));
                                        }
                                    }
                                    sbB.AppendLine("</tr>");
                                }

                            }
                            else
                            {

                                sbB.AppendLine(string.Format("<tr data_code='{0}' bgcolor='#ddd' >", lr.RUBR_ETAT_CODE.ToString().Trim()));

                                if (lr.RUBR_ETAT_LIBELLE.Trim().Length <= 1)
                                {
                                    sbB.AppendLine(string.Format("<td align='left' color='#FFFFFF'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE.ToString()));
                                }
                                else
                                {
                                    sbB.AppendLine(string.Format("<td align='left'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE.ToString()));
                                }
                                var liste_valeur = service.AnafiAfficheLiasse(10, compar, lr.RUBR_ETAT_CODE.ToString().Trim(), "SN");
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
                                            sbB.AppendLine(string.Format("<td width=15% align='right' class='text-right {1}'><strong>{0}</strong></td>", formatMillier(l.VALEUR_CR_DETAIL.ToString()), l.ANNEE_CR_DETAIL.Replace("/", "")));

                                            //sbB.AppendLine(string.Format("<td align='right'><strong>{0}</strong></td>", formatMillier(l.VALEUR_CR_DETAIL.ToString())));
                                        }

                                    }
                                    else
                                    {
                                        sbB.AppendLine(string.Format("<td width=15% align='right' class='text-right {1}'><strong>{0}</strong></td>", formatMillier(l.VALEUR_CR_DETAIL.ToString()), l.ANNEE_CR_DETAIL.Replace("/", "")));

                                        // sbB.AppendLine(string.Format("<td align='right'><strong>{0}</strong></td>", formatMillier(l.VALEUR_CR_DETAIL.ToString())));
                                    }
                                }

                                sbB.AppendLine("</tr>");
                            }
                        }
                        else
                        {
                            if (lr.RUBR_ETAT_CODE.ToString().Trim() != "CP6C")
                            {
                                sbB.AppendLine(string.Format("<tr data_code='{0}'>", lr.RUBR_ETAT_CODE.ToString().Trim()));
                                sbB.AppendLine(string.Format("<td align='left'>{0}</td>", lr.RUBR_ETAT_LIBELLE.ToString()));

                                var liste_valeur = service.AnafiAfficheLiasse(10, compar, lr.RUBR_ETAT_CODE.ToString().Trim(), "SN");
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
                                                sbB.AppendLine(string.Format("<td align='right'></td>"));
                                            }
                                            else
                                            {
                                                sbB.AppendLine(string.Format("<td align='right' class='text-right {1}'>{0}</td>", formatMillier(l.VALEUR_CR_DETAIL.ToString()), l.ANNEE_CR_DETAIL.Replace("/", "")));

                                                // sbB.AppendLine(string.Format("<td align='right'>{0}</td>", formatMillier(l.VALEUR_CR_DETAIL.ToString())));
                                            }
                                        }

                                    }
                                    else
                                    {
                                        if (l.RUBR_ETAT_LIBELLE.Trim().Length <= 1)
                                        {
                                            sbB.AppendLine(string.Format("<td align='right'></td>"));
                                        }
                                        else
                                        {
                                            sbB.AppendLine(string.Format("<td align='right' class='text-right {1}'>{0}</td>", formatMillier(l.VALEUR_CR_DETAIL.ToString()), l.ANNEE_CR_DETAIL.Replace("/", "")));

                                            //sbB.AppendLine(string.Format("<td align='right'>{0}</td>", formatMillier(l.VALEUR_CR_DETAIL.ToString())));
                                        }
                                    }
                                }

                                sbB.AppendLine("</tr>");
                            }

                        }
                    }

                    if (lr.RUBR_ETAT_CODE.Trim() == "CP")
                    {
                        sbB.AppendLine(string.Format("<tr bgcolor='rgba(210, 210, 210, 1);'>"));

                        sbB.AppendLine(string.Format("<td align='left'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE));
                        // TabLOTP = new string[Convert.ToInt32(liste_annee.Count)];
                        int p = 0;
                        var liste_valeur = service.AnafiAfficheLiasse(10, compar, lr.RUBR_ETAT_CODE.ToString().Trim(), "SN");
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
                                    sbB.AppendLine(string.Format("<td align='right'>{0}</td>", formatMillier(l.VALEUR_CR_DETAIL.ToString())));
                                    // TabLOTP[p] = l.VALEUR_B_DETAIL.ToString();
                                    p++;
                                }

                            }
                            else
                            {
                                sbB.AppendLine(string.Format("<td align='right'>{0}</td>", formatMillier(l.VALEUR_CR_DETAIL.ToString())));
                                // TabLOTP[p] = l.VALEUR_B_DETAIL.ToString();
                                p++;
                            }
                        }

                    }
                }

                sbB.AppendLine("</tbody>");
                sbB.AppendLine("</table>");

                sbv.AppendLine("</table>");
                //divProduit.InnerHtml = sbv.ToString();

            }
            else
            {
                sbB.AppendLine("<table id='' border = '1' font size='1'  class='table table-hover table-bordered text-center'>");
                sbB.AppendLine("<thead class='table-heigth'>");
                sbB.AppendLine(string.Format("<tr bgcolor='#022D65' color='#FFFFFF' align='center'><th>Produits</th>"));
                sbB.AppendLine(string.Format("<th width=23%></th>"));

                sbB.AppendLine("</thead>");
                sbB.AppendLine("<tbody>");

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
                                    sbB.AppendLine(string.Format("<tr data_code='{0}' bgcolor='#EAF2F8'>", lr.RUBR_ETAT_CODE.ToString().Trim()));
                                    sbB.AppendLine(string.Format("<td align='left'>{0}</td>", lr.RUBR_ETAT_LIBELLE.ToString()));
                                    sbB.AppendLine(string.Format("<td width='15%' ></td>"));
                                    sbB.AppendLine("</tr>");
                                }
                                else
                                {
                                    //sbv.AppendLine(string.Format("<tr  width=15% style='background-color:rgba(210, 210, 210, 1);'>"));

                                    //sbv.AppendLine(string.Format("<tr data_code='{0}' style='background-color:#ddd'>", lr.RUBR_ETAT_CODE.ToString().Trim()));
                                    sbB.AppendLine(string.Format("<tr data_code='{0}' bgcolor='rgba(210, 210, 210, 1);'>", lr.RUBR_ETAT_CODE.ToString().Trim()));

                                    if (lr.RUBR_ETAT_LIBELLE.Trim().Length <= 1)
                                    {
                                        sbB.AppendLine(string.Format("<td align='left' ><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE.ToString()));
                                        sbB.AppendLine(string.Format("<td width='23%'></td>"));
                                    }
                                    else
                                    {
                                        sbB.AppendLine(string.Format("<td align='left'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE.ToString()));
                                        sbB.AppendLine(string.Format("<td width='23%'></td>"));
                                    }
                                    sbB.AppendLine("</tr>");
                                }



                            }
                            else
                            {

                                sbB.AppendLine(string.Format("<tr data_code='{0}' bgcolor='#ddd'>", lr.RUBR_ETAT_CODE.ToString().Trim()));

                                if (lr.RUBR_ETAT_LIBELLE.Trim().Length <= 1)
                                {
                                    sbB.AppendLine(string.Format("<td align='left'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE.ToString()));
                                    sbB.AppendLine(string.Format("<td></td>"));
                                }
                                else
                                {
                                    sbB.AppendLine(string.Format("<td align='left'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE.ToString()));
                                    sbB.AppendLine(string.Format("<td></td>"));
                                }

                                sbB.AppendLine("</tr>");
                            }


                        }
                        else
                        {
                            if (lr.RUBR_ETAT_CODE.ToString().Trim() != "CP6C")
                            {
                                sbB.AppendLine(string.Format("<tr data_code='{0}'>", lr.RUBR_ETAT_CODE.ToString().Trim()));
                                sbB.AppendLine(string.Format("<td align='left'>{0}</td>", lr.RUBR_ETAT_LIBELLE.ToString()));
                                sbB.AppendLine(string.Format("<td></td>"));

                                sbB.AppendLine("</tr>");
                            }

                        }
                    }


                    if (lr.RUBR_ETAT_CODE.Trim() == "CP")
                    {
                        sbB.AppendLine(string.Format("<tr bgcolor='rgba(210, 210, 210, 1);'>"));

                        sbB.AppendLine(string.Format("<td align='left'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE));
                        sbB.AppendLine(string.Format("<td></td>"));
                    }
                }

                sbB.AppendLine("</tbody>");
                sbB.AppendLine("</table>");


                sbv.AppendLine("</table>");
            }


        }
        public void BGMAtifs()
        {
            var liste_annee = service.AnafiAfficheLiasse(7, compar, "", "SN");
            var nombre_annee = service.AnafiAfficheLiasse(8, compar, "", "SN");

            //BGM  ACTIF

            Type_anafi = "BN";

            if (liste_annee.Count != 0)
            {

                sbBGM.AppendLine("<table id='' border = '1' font size='1'  class='table table-hover table-bordered text-center'>");
                sbBGM.AppendLine("<thead class='table-heigth'>");
                sbBGM.AppendLine(string.Format("<tr bgcolor='#022D65' color='#FFFFFF' align='center'><th>Actifs</th>"));

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
                                sbBGM.AppendLine(string.Format("<th colspan=\"2\" width=18%>{0}</th>", lr.ANNEE_DETAIL));
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
                            sbBGM.AppendLine(string.Format("<th colspan=\"2\" width=18%>{0}</th>", lr.ANNEE_DETAIL));
                            //TabLOT[i] = lr.ANNEE_DETAIL;
                        }
                        i++;
                    }
                }

                sbBGM.AppendLine("</thead>");
                sbBGM.AppendLine("<tbody>");

                var liste_libelle = service.AnafiAfficheLiasse(0, "", "", "BIL");
                string[] TabLOTN = null;
                sbt.AppendLine("<table border = '1' font size='1'  id='totauxActif' class='table-hover table table-bordered text-center'>");
                foreach (var lr in liste_libelle)
                {

                    string SENS = lr.RUBR_ETAT_CODE.ToString().Trim().Substring(0, 3);
                    if (SENS == "BI1" || SENS == "BI2" || SENS == "BI3")
                    {
                        if (lr.RUBR_ETAT_CODE.Trim().Length == 4)
                        {
                            if (lr.RUBR_ETAT_CODE.Trim() == "BI3Z")
                            {
                                //sbt.AppendLine("<table id='totauxActif' class='table-hover table table-bordered text-center'>");
                                sbt.AppendLine(string.Format("<tr bgcolor='rgba(210, 210, 210, 1);'>"));

                                sbt.AppendLine(string.Format("<td align='left'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE));
                                // TabLOTA = new string[Convert.ToInt32(liste_annee.Count)];
                                int pa = 0;
                                var liste_valeur = service.AnafiAfficheLiasse(3, compar, lr.RUBR_ETAT_CODE.ToString().Trim(), "SN");

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
                                            //sbt.AppendLine(string.Format("<td align='left'>{0}</td>", Convert.ToString(string.Format(frCult, "{0:#,##0}", k))));
                                            sbt.AppendLine(string.Format("<td align='left' width=16%><strong>{0}</strong></td>", l.VALEUR_BGR_DETAIL != Convert.ToDouble(0) ? formatMillier(l.VALEUR_BGR_DETAIL.ToString()) : "0"));
                                            sbt.AppendLine(string.Format("<td align='right'><strong>{0}</strong></td>", l.TAUX_BGR_DETAIL != Convert.ToDouble(0) ? Convert.ToDecimal(l.TAUX_BGR_DETAIL).ToString("#,##0.##") + "%" : "0%"));

                                            //pa++;
                                        }

                                    }
                                    else
                                    {
                                        //string k = "";
                                        //k = TabLOTN[1];
                                        //sbt.AppendLine(string.Format("<td align='left'>{0}</td>", Convert.ToString(string.Format(frCult, "{0:#,##0}", k))));
                                        sbt.AppendLine(string.Format("<td align='left' width=16%><strong>{0}</strong></td>", l.VALEUR_BGR_DETAIL != Convert.ToDouble(0) ? formatMillier(l.VALEUR_BGR_DETAIL.ToString()) : "0"));
                                        sbt.AppendLine(string.Format("<td align='right'><strong>{0}</strong></td>", l.TAUX_BGR_DETAIL != Convert.ToDouble(0) ? Convert.ToDecimal(l.TAUX_BGR_DETAIL).ToString("#,##0.##") + "%" : "0%"));

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

                                    sbBGM.AppendLine(string.Format("<tr data_code='{0}' bgcolor='rgba(210, 210, 210, 1);'>", lr.RUBR_ETAT_CODE.ToString().Trim()));
                                    sbBGM.AppendLine(string.Format("<td align='left'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE.ToString()));
                                    // TabLOTP = new string[Convert.ToInt32(liste_annee.Count)];
                                    int p = 0;
                                    var liste_valeur = service.AnafiAfficheLiasse(3, compar, lr.RUBR_ETAT_CODE.ToString().Trim(), "SN");

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
                                                    sbBGM.AppendLine(string.Format("<td align='right' width=12%><strong>{0}</strong></td>", l.VALEUR_BGR_DETAIL != Convert.ToDouble(0) ? formatMillier(l.VALEUR_BGR_DETAIL.ToString()) : "0"));
                                                    sbBGM.AppendLine(string.Format("<td align='right' width=8%><strong>{0}</strong></td>", l.TAUX_BGR_DETAIL != Convert.ToDouble(0) ? Convert.ToDecimal(l.TAUX_BGR_DETAIL).ToString("#,##0.##") + "%" : "0%"));

                                                    // TabLOTA[p] = l.VALEUR_BGR_DETAIL.ToString();

                                                }
                                            }

                                        }
                                        else
                                        {
                                            if (l.TYPE_ANAFI_A.Trim() == "SN")
                                            {
                                                sbBGM.AppendLine(string.Format("<td align='right' width=12%><strong>{0}</strong></td>", l.VALEUR_BGR_DETAIL != Convert.ToDouble(0) ? formatMillier(l.VALEUR_BGR_DETAIL.ToString()) : "0"));
                                                sbBGM.AppendLine(string.Format("<td align='right' width=8%><strong>{0}</strong></td>", l.TAUX_BGR_DETAIL != Convert.ToDouble(0) ? Convert.ToDecimal(l.TAUX_BGR_DETAIL).ToString("#,##0.##") + "%" : "0%"));
                                                // TabLOTA[p] = l.VALEUR_BGR_DETAIL.ToString();

                                            }
                                        }
                                    }

                                    sbBGM.AppendLine("</tr>");
                                }
                            }

                            //sbBGM.AppendLine("</tr>");

                        }
                        else
                        {
                            if (lr.RUBR_ETAT_CODE.Trim() == "BI3Z1")
                            {

                                sbt.AppendLine(string.Format("<tr data_code='{0}'>", lr.RUBR_ETAT_CODE.ToString().Trim()));
                                sbt.AppendLine(string.Format("<td align='left'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE.ToString()));
                                // TabLOTP = new string[Convert.ToInt32(liste_annee.Count)];
                                int p = 0;
                                var liste_valeur = service.AnafiAfficheLiasse(3, compar, lr.RUBR_ETAT_CODE.ToString().Trim(), "SN");

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
                                                    sbt.AppendLine(string.Format("<td align='left' width=12%></td>"));
                                                    sbt.AppendLine(string.Format("<td align='right' width=8%><strong></strong></td>", l.TAUX_BGR_DETAIL != Convert.ToDouble(0) ? Convert.ToDecimal(l.TAUX_BGR_DETAIL).ToString("#,##0.##") : ""));

                                                    // TabLOTA[p] = l.VALEUR_BGR_DETAIL.ToString();
                                                }
                                                else
                                                {
                                                    sbt.AppendLine(string.Format("<td align='left' width=12%><strong>{0}</strong></td>", l.VALEUR_BGR_DETAIL != Convert.ToDouble(0) ? formatMillier(l.VALEUR_BGR_DETAIL.ToString()) : ""));
                                                    sbt.AppendLine(string.Format("<td align='right' width=8%><strong>{0}</strong></td>", l.TAUX_BGR_DETAIL != Convert.ToDouble(0) ? Convert.ToDecimal(l.TAUX_BGR_DETAIL).ToString("#,##0.##") + "%" : ""));

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
                                                sbt.AppendLine(string.Format("<td align='right' width=12%></td>"));
                                                sbt.AppendLine(string.Format("<td align='right' width=8%><strong></strong></td>", l.TAUX_BGR_DETAIL != Convert.ToDouble(0) ? Convert.ToDecimal(l.TAUX_BGR_DETAIL).ToString("#,##0.##") + "%" : ""));

                                                // TabLOTA[p] = l.VALEUR_BGR_DETAIL.ToString();
                                            }
                                            else
                                            {
                                                sbt.AppendLine(string.Format("<td align='right' width=12%><strong>{0}</strong></td>", l.VALEUR_BGR_DETAIL != Convert.ToDouble(0) ? formatMillier(l.VALEUR_BGR_DETAIL.ToString()) : ""));
                                                sbt.AppendLine(string.Format("<td align='right'  width=8%><strong>{0}</strong></td>", l.TAUX_BGR_DETAIL != Convert.ToDouble(0) ? Convert.ToDecimal(l.TAUX_BGR_DETAIL).ToString("#,##0.##") + "%" : ""));
                                                // TabLOTA[p] = l.VALEUR_BGR_DETAIL.ToString();
                                            }


                                        }
                                    }
                                }

                                sbt.AppendLine("</tr>");
                            }
                            else
                            {
                                sbBGM.AppendLine(string.Format("<tr data_code='{0}'>", lr.RUBR_ETAT_CODE.ToString().Trim()));


                                sbBGM.AppendLine(string.Format("<td align='left'>{0}</td>", lr.RUBR_ETAT_LIBELLE.ToString()));


                                var liste_valeur = service.AnafiAfficheLiasse(3, compar, lr.RUBR_ETAT_CODE.ToString().Trim(), "SN");


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
                                                sbBGM.AppendLine(string.Format("<td align='right' width=12%>{0}</td>", l.VALEUR_BGR_DETAIL != Convert.ToDouble(0) ? formatMillier(l.VALEUR_BGR_DETAIL.ToString()) : ""));
                                                sbBGM.AppendLine(string.Format("<td align='right' width=8%><strong>{0}</strong></td>", l.TAUX_BGR_DETAIL != Convert.ToDouble(0) ? Convert.ToDecimal(l.TAUX_BGR_DETAIL).ToString("#,##0.##") + "%" : ""));
                                            }
                                        }

                                    }
                                    else
                                    {
                                        if (l.TYPE_ANAFI_A.Trim() == "SN")
                                        {
                                            sbBGM.AppendLine(string.Format("<td align='right' width=12%>{0}</td>", l.VALEUR_BGR_DETAIL != Convert.ToDouble(0) ? formatMillier(l.VALEUR_BGR_DETAIL.ToString()) : ""));
                                            sbBGM.AppendLine(string.Format("<td align='right' width=8%><strong>{0}</strong></td>", l.TAUX_BGR_DETAIL != Convert.ToDouble(0) ? Convert.ToDecimal(l.TAUX_BGR_DETAIL).ToString("#,##0.##") + "%" : ""));
                                        }
                                    }
                                }

                                sbBGM.AppendLine("</tr>");
                            }


                        }
                    }
                }

                sbBGM.AppendLine("</tbody>");
                sbBGM.AppendLine("</table>");

            }
            else
            {

                sbBGM.AppendLine("<table id='' border = '1' font size='1'  class='table table-hover table-bordered text-center'>");
                sbBGM.AppendLine("<thead class='table-heigth'>");
                sbBGM.AppendLine(string.Format("<tr bgcolor='#022D65' color='#FFFFFF' align='center'><th>Actifs</th>"));
                sbBGM.AppendLine(string.Format("<th width=23%></th>"));

                sbBGM.AppendLine("</thead>");
                sbBGM.AppendLine("<tbody>");

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


                                sbt.AppendLine(string.Format("<tr bgcolor='rgba(210, 210, 210, 1);'>"));

                                sbt.AppendLine(string.Format("<td align='left'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE));
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
                                    sbBGM.AppendLine(string.Format("<tr data_code='{0}' bgcolor='rgba(210, 210, 210, 1);'>", lr.RUBR_ETAT_CODE.ToString().Trim()));
                                    sbBGM.AppendLine(string.Format("<td align='left'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE.ToString()));
                                    sbBGM.AppendLine(string.Format("<td></td>"));

                                    sbBGM.AppendLine("</tr>");
                                }
                            }

                            //sbBGM.AppendLine("</tr>");

                        }
                        else
                        {
                            if (lr.RUBR_ETAT_CODE.Trim() == "BI3Z1")
                            {
                                sbBGM.AppendLine(string.Format("<tr data_code='{0}'>", lr.RUBR_ETAT_CODE.ToString().Trim()));


                                sbBGM.AppendLine(string.Format("<td align='left'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE.ToString()));
                                sbBGM.AppendLine(string.Format("<td></td>"));

                                sbBGM.AppendLine("</tr>");
                            }
                            else
                            {
                                sbBGM.AppendLine(string.Format("<tr data_code='{0}'>", lr.RUBR_ETAT_CODE.ToString().Trim()));


                                sbBGM.AppendLine(string.Format("<td align='left'>{0}</td>", lr.RUBR_ETAT_LIBELLE.ToString()));
                                sbBGM.AppendLine(string.Format("<td></td>"));

                                sbBGM.AppendLine("</tr>");
                            }


                        }
                    }
                }

                sbBGM.AppendLine("</tbody>");
                sbBGM.AppendLine("</table>");
            }
        }
        public void BGMPassifs()
        {
            var liste_annee = service.AnafiAfficheLiasse(7, compar, "", "SN");
            var nombre_annee = service.AnafiAfficheLiasse(8, compar, "", "SN");

            //BGM passif 


            if (liste_annee.Count != 0)
            {
                sbBGM1.AppendLine("<table id='' border = '1' font size='1'  class='table table-hover table-bordered text-center'>");
                sbBGM1.AppendLine("<thead class='table-heigth'>");
                sbBGM1.AppendLine(string.Format("<tr bgcolor='#022D65' color='#FFFFFF' align='center'><th>Passifs</th>"));

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
                                sbBGM1.AppendLine(string.Format("<th colspan=\"2\" width=18%>{0}</th>", lr.ANNEE_DETAIL));
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
                            sbBGM1.AppendLine(string.Format("<th colspan=\"2\" width=18%>{0}</th>", lr.ANNEE_DETAIL));
                            //TabLOT[i] = lr.ANNEE_DETAIL;
                        }
                        i++;
                    }
                }

                sbBGM1.AppendLine("</thead>");
                sbBGM1.AppendLine("<tbody>");

                var liste_libelle1 = service.AnafiAfficheLiasse(0, "", "", "BIL");
                string[] TabLOTN = null;
                sbv.AppendLine("<table id='totauxPassif' border = '1' font size='1'  class='table-hover table table-bordered text-center'>");
                foreach (var lr in liste_libelle1)
                {



                    string SENS = lr.RUBR_ETAT_CODE.ToString().Trim().Substring(0, 3);
                    if (SENS == "BI4" || SENS == "BI5" || SENS == "BI6" || SENS == "BI7")
                    {
                        if (lr.RUBR_ETAT_CODE.Trim().Length == 4)
                        {
                            if (lr.RUBR_ETAT_CODE.ToString().Trim() == "BI7Z")
                            {


                                sbv.AppendLine(string.Format("<tr bgcolor='#022D65' color='#FFFFFF' align='center'>"));

                                sbv.AppendLine(string.Format("<td align='left'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE));
                                int iv = 0;
                                var liste_valeur = service.AnafiAfficheLiasse(3, compar, lr.RUBR_ETAT_CODE.ToString().Trim(), "SN");

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
                                            sbv.AppendLine(string.Format("<td align='left' width=16%><strong>{0}</strong></td>", l.VALEUR_BGR_DETAIL != Convert.ToDouble(0) ? formatMillier(l.VALEUR_BGR_DETAIL.ToString()) : "0"));
                                            sbv.AppendLine(string.Format("<td align='right'><strong>{0}</strong></td>", l.TAUX_BGR_DETAIL != Convert.ToDouble(0) ? Convert.ToDecimal(l.TAUX_BGR_DETAIL).ToString("#,##0.##") + "%" : "0%"));

                                            //sbv.AppendLine(string.Format("<td align='left'>{0}</td>", Convert.ToString(string.Format(frCult, "{0:#,##0}", TabLOTN[iv]))));
                                            //iv++;
                                        }

                                    }
                                    else
                                    {
                                        sbv.AppendLine(string.Format("<td align='left' width=16%><strong>{0}</strong></td>", l.VALEUR_BGR_DETAIL != Convert.ToDouble(0) ? formatMillier(l.VALEUR_BGR_DETAIL.ToString()) : "0"));
                                        sbv.AppendLine(string.Format("<td align='right'><strong>{0}</strong></td>", l.TAUX_BGR_DETAIL != Convert.ToDouble(0) ? Convert.ToDecimal(l.TAUX_BGR_DETAIL).ToString("#,##0.##") + "%" : "0%"));

                                        //sbv.AppendLine(string.Format("<td align='left'>{0}</td>", Convert.ToString(string.Format(frCult, "{0:#,##0}", TabLOTN[iv]))));
                                        //iv++;
                                    }
                                }


                            }
                            else
                            {
                                sbBGM1.AppendLine(string.Format("<tr data_code='{0}' bgcolor='rgba(210, 210, 210, 1);'>", lr.RUBR_ETAT_CODE.ToString().Trim()));
                                sbBGM1.AppendLine(string.Format("<td align='left'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE.ToString()));
                                // TabLOTA = new string[Convert.ToInt32(liste_annee.Count)];
                                int p = 0;
                                var liste_valeur = service.AnafiAfficheLiasse(3, compar, lr.RUBR_ETAT_CODE.ToString().Trim(), "SN");

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
                                            sbBGM1.AppendLine(string.Format("<td align='right' width=12%><strong>{0}</strong></td>", l.VALEUR_BGR_DETAIL != Convert.ToDouble(0) ? formatMillier(l.VALEUR_BGR_DETAIL.ToString()) : "0"));
                                            sbBGM1.AppendLine(string.Format("<td align='right' width=8%><strong>{0}</strong></td>", l.TAUX_BGR_DETAIL != Convert.ToDouble(0) ? Convert.ToDecimal(l.TAUX_BGR_DETAIL).ToString("#,##0.##") + "%" : "0%"));


                                        }

                                    }
                                    else
                                    {
                                        sbBGM1.AppendLine(string.Format("<td align='right' width=12%><strong>{0}</strong></td>", l.VALEUR_BGR_DETAIL != Convert.ToDouble(0) ? formatMillier(l.VALEUR_BGR_DETAIL.ToString()) : ""));
                                        sbBGM1.AppendLine(string.Format("<td align='right' width=8%><strong>{0}</strong></td>", l.TAUX_BGR_DETAIL != Convert.ToDouble(0) ? Convert.ToDecimal(l.TAUX_BGR_DETAIL).ToString("#,##0.##") + "%" : "0%"));
                                        //sbBGM1.AppendLine(string.Format("<td align='right'><strong>{0}%</strong></td>", l.TAUX_BGR_DETAIL));


                                    }
                                }

                                sbBGM1.AppendLine("</tr>");
                            }


                        }
                        else
                        {
                            if (lr.RUBR_ETAT_CODE.ToString().Trim() == "BI7Z1")
                            {
                                sbv.AppendLine(string.Format("<tr data_code='{0}'>", lr.RUBR_ETAT_CODE.ToString().Trim()));
                                sbv.AppendLine(string.Format("<td  align='left'>{0}</td>", lr.RUBR_ETAT_LIBELLE.ToString()));

                                var liste_valeur = service.AnafiAfficheLiasse(3, compar, lr.RUBR_ETAT_CODE.ToString().Trim(), "SN");
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
                                                    sbv.AppendLine(string.Format("<td align='right'></td>"));
                                                }
                                                else
                                                {
                                                    sbv.AppendLine(string.Format("<td align='right' width=12%>{0}</td>", formatMillier(l.VALEUR_BGR_DETAIL.ToString())));
                                                    sbv.AppendLine(string.Format("<td align='right' width=8%><strong>{0}</strong></td>", l.TAUX_BGR_DETAIL != Convert.ToDouble(0) ? Convert.ToDecimal(l.TAUX_BGR_DETAIL).ToString("#,##0.##") + "%" : ""));
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
                                                sbv.AppendLine(string.Format("<td align='right' width=12%></td>"));
                                                sbv.AppendLine(string.Format("<td align='right' width=8%><strong></strong></td>", l.TAUX_BGR_DETAIL != Convert.ToDouble(0) ? Convert.ToDecimal(l.TAUX_BGR_DETAIL).ToString("#,##0.##") + "%" : ""));

                                            }
                                            else
                                            {
                                                sbv.AppendLine(string.Format("<td align='right' width=12%>{0}</td>", l.VALEUR_BGR_DETAIL != Convert.ToDouble(0) ? formatMillier(l.VALEUR_BGR_DETAIL.ToString()) : ""));
                                                sbv.AppendLine(string.Format("<td align='right' width=8%><strong>{0}</strong></td>", l.TAUX_BGR_DETAIL != Convert.ToDouble(0) ? Convert.ToDecimal(l.TAUX_BGR_DETAIL).ToString("#,##0.##") + "%" : ""));
                                            }

                                        }
                                    }
                                }




                                sbv.AppendLine("</tr>");
                            }
                            else
                            {
                                sbBGM1.AppendLine(string.Format("<tr data_code='{0}'>", lr.RUBR_ETAT_CODE.ToString().Trim()));


                                sbBGM1.AppendLine(string.Format("<td align='left'>{0}</td>", lr.RUBR_ETAT_LIBELLE.ToString()));


                                var liste_valeur = service.AnafiAfficheLiasse(3, compar, lr.RUBR_ETAT_CODE.ToString().Trim(), "SN");
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
                                                sbBGM1.AppendLine(string.Format("<td align='right' width=12%>{0}</td>", l.VALEUR_BGR_DETAIL != Convert.ToDouble(0) ? formatMillier(l.VALEUR_BGR_DETAIL.ToString()) : ""));
                                                sbBGM1.AppendLine(string.Format("<td align='right' width=8%><strong>{0}</strong></td>", l.TAUX_BGR_DETAIL != Convert.ToDouble(0) ? Convert.ToDecimal(l.TAUX_BGR_DETAIL).ToString("#,##0.##") + "%" : ""));
                                            }
                                        }

                                    }
                                    else
                                    {
                                        if (l.TYPE_ANAFI_A.Trim() == "SN")
                                        {
                                            sbBGM1.AppendLine(string.Format("<td align='right' width=12%>{0}</td>", l.VALEUR_BGR_DETAIL != Convert.ToDouble(0) ? formatMillier(l.VALEUR_BGR_DETAIL.ToString()) : ""));
                                            sbBGM1.AppendLine(string.Format("<td align='right' width=8%><strong>{0}</strong></td>", l.TAUX_BGR_DETAIL != Convert.ToDouble(0) ? Convert.ToDecimal(l.TAUX_BGR_DETAIL).ToString("#,##0.##") + "%" : ""));
                                        }
                                    }
                                }




                                sbBGM1.AppendLine("</tr>");
                            }


                        }
                    }
                }

                sbBGM1.AppendLine("</tbody>");
                sbBGM1.AppendLine("</table>");

            }
            else
            {
                sbBGM1.AppendLine("<table id='' border = '1' font size='1'  class='table table-hover table-bordered text-center'>");
                sbBGM1.AppendLine("<thead class='table-heigth'>");
                sbBGM1.AppendLine(string.Format("<tr bgcolor='#022D65' color='#FFFFFF' align='center'><th>Passifs</th>"));
                sbBGM1.AppendLine(string.Format("<th width=23%></th>"));

                sbBGM1.AppendLine("</thead>");
                sbBGM1.AppendLine("<tbody>");

                var liste_libelle2 = service.AnafiAfficheLiasse(0, "", "", "BIL");
                //string[] TabLOTN = null;
                sbv.AppendLine("<table id='totauxPassif' class='table-hover table table-bordered text-center'>");
                foreach (var lr in liste_libelle2)
                {



                    string SENS = lr.RUBR_ETAT_CODE.ToString().Trim().Substring(0, 3);
                    if (SENS == "BI4" || SENS == "BI5" || SENS == "BI6" || SENS == "BI7")
                    {
                        if (lr.RUBR_ETAT_CODE.Trim().Length == 4)
                        {
                            if (lr.RUBR_ETAT_CODE.ToString().Trim() == "BI7Z")
                            {


                                sbv.AppendLine(string.Format("<tr bgcolor='rgba(210, 210, 210, 1);'>"));

                                sbv.AppendLine(string.Format("<td align='left'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE));
                                sbv.AppendLine(string.Format("<th width=23%></th>"));
                                //sbv.AppendLine("</table>");
                                //DIVtotauxPassif.InnerHtml = sbv.ToString();
                            }
                            else
                            {
                                sbBGM1.AppendLine(string.Format("<tr data_code='{0}' bgcolor='rgba(210, 210, 210, 1);'>", lr.RUBR_ETAT_CODE.ToString().Trim()));
                                sbBGM1.AppendLine(string.Format("<td align='left'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE.ToString()));
                                sbBGM1.AppendLine(string.Format("<th width=23%></th>"));

                                sbBGM1.AppendLine("</tr>");
                            }


                            //sbBGM1.AppendLine("</tr>");

                        }
                        else
                        {
                            if (lr.RUBR_ETAT_CODE.ToString().Trim() == "BI7Z1")
                            {
                                sbv.AppendLine(string.Format("<tr data_code='{0}'>", lr.RUBR_ETAT_CODE.ToString().Trim()));

                                sbv.AppendLine(string.Format("<td align='left'>{0}</td>", lr.RUBR_ETAT_LIBELLE.ToString()));
                                sbv.AppendLine(string.Format("<th width=23%></th>"));

                                sbv.AppendLine("</tr>");
                            }
                            else
                            {
                                sbBGM1.AppendLine(string.Format("<tr data_code='{0}'>", lr.RUBR_ETAT_CODE.ToString().Trim()));


                                sbBGM1.AppendLine(string.Format("<td align='left'>{0}</td>", lr.RUBR_ETAT_LIBELLE.ToString()));
                                sbBGM1.AppendLine(string.Format("<th width=23%></th>"));

                                sbBGM1.AppendLine("</tr>");
                            }


                        }
                    }
                }

                sbBGM1.AppendLine("</tbody>");
                sbBGM1.AppendLine("</table>");

            }

        }
        public void TS()
        {

            var palatino = FontFactory.GetFont("palatino linotype", BaseFont.CP1252, BaseFont.EMBEDDED, 9, Font.BOLD);
            var boldFont = FontFactory.GetFont("palatino linotype", BaseFont.CP1252, BaseFont.EMBEDDED, 12, Font.BOLD);
            var italicfont = FontFactory.GetFont("palatino linotype", BaseFont.CP1252, BaseFont.EMBEDDED, 9, Font.ITALIC);
            var boldFontTitle = FontFactory.GetFont("palatino linotype", BaseFont.CP1252, BaseFont.EMBEDDED, 14, Font.BOLD);
            var titleFont = FontFactory.GetFont("Segoe UI", 9, BaseColor.WHITE);

            var liste_annee = service.AnafiAfficheLiasse(7, compar, "", "SN");
            var nombre_annee = service.AnafiAfficheLiasse(8, compar, "", "SN");

            //Tableau synthétique

            if (liste_annee.Count != 0)
            {
                sbTS.AppendLine("<table id='' border = '1' font size='1'   class='table table-hover table-bordered text-center'>");
                sbTS.AppendLine("<thead color=\"#0000FF\" background-color='rgba(210, 210, 210,1)' class='table-heigth'>");
                sbTS.AppendLine(string.Format("<tr bgcolor='#022D65' color='#FFFFFF' align='center'><th >Libellés</th>"));

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
                                sbTS.AppendLine(string.Format("<th colspan=\"2\" width=18%>{0}</th>", lr.ANNEE_DETAIL));
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
                            sbTS.AppendLine(string.Format("<th  colspan=\"2\" width=18%>{0}</th>", lr.ANNEE_DETAIL));
                            //TabLOT[i] = lr.ANNEE_DETAIL;
                        }
                        i++;
                    }
                }

                sbTS.AppendLine("</thead>");
                sbTS.AppendLine("<tbody>");

                var liste_libelle = service.AnafiAfficheLiasse(0, "", "", "CR");

                foreach (var lr in liste_libelle)
                {
                    if (lr.RUBR_ETAT_CODE.Trim() == "C019" || lr.RUBR_ETAT_CODE.Trim() == "C029" || lr.RUBR_ETAT_CODE.Trim() == "C039" || lr.RUBR_ETAT_CODE.Trim() == "C049" || lr.RUBR_ETAT_CODE.Trim() == "C059" || lr.RUBR_ETAT_CODE.Trim() == "C069" || lr.RUBR_ETAT_CODE.Trim() == "C079" || lr.RUBR_ETAT_CODE.Trim() == "C089" || lr.RUBR_ETAT_CODE.Trim() == "C099" || lr.RUBR_ETAT_CODE.Trim() == "C109" || lr.RUBR_ETAT_CODE.Trim() == "C119")
                    {
                        sbTS.AppendLine(string.Format("<tr data_code='{0}' bgcolor='#ddd'>", lr.RUBR_ETAT_CODE.ToString().Trim()));

                        sbTS.AppendLine(string.Format("<td align='left'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE));
                        // TabLOTA = new string[Convert.ToInt32(liste_annee.Count)];
                        int p = 0;
                        var liste_valeur = service.AnafiAfficheLiasse(4, compar, lr.RUBR_ETAT_CODE.ToString().Trim(), "SN");
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
                                        sbTS.AppendLine(string.Format("<td align='right' width=12%><strong>{0}</strong></td>", l.VALEUR_TS_DETAIL != Convert.ToDouble(0) ? formatMillier(l.VALEUR_TS_DETAIL.ToString()) : "0"));
                                        sbTS.AppendLine(string.Format("<td align='right' width=8%><strong>{0}</strong></td>", l.TAUX_TS_DETAIL != Convert.ToDouble(0) ? Convert.ToDecimal(l.TAUX_TS_DETAIL).ToString("#,##0.##") + "%" : "0%"));
                                        // TabLOTA[p] = l.VALEUR_RAT_AFF_DETAIL.ToString();
                                        p++;
                                    }
                                }
                            }
                            else
                            {
                                if (l.TYPE_ANAFI_A.Trim() == "SN")
                                {
                                    sbTS.AppendLine(string.Format("<td align='right' width=12%><strong>{0}</strong></td>", l.VALEUR_TS_DETAIL != Convert.ToDouble(0) ? formatMillier(l.VALEUR_TS_DETAIL.ToString()) : "0"));
                                    sbTS.AppendLine(string.Format("<td align='right' width=8%><strong>{0}</strong></td>", l.TAUX_TS_DETAIL != Convert.ToDouble(0) ? Convert.ToDecimal(l.TAUX_TS_DETAIL).ToString("#,##0.##") + "%" : "0%"));
                                    // TabLOTA[p] = l.VALEUR_RAT_AFF_DETAIL.ToString();
                                    p++;
                                }
                            }
                        }


                        sbTS.AppendLine("</tr>");
                    }
                    else
                    {
                        if (lr.RUBR_ETAT_CODE.Trim() != "C0203" && lr.RUBR_ETAT_CODE.Trim() != "C0204" && lr.RUBR_ETAT_CODE.Trim() != "C0205" && lr.RUBR_ETAT_CODE.Trim() != "C0206" && lr.RUBR_ETAT_CODE.Trim() != "C0207")

                        //  if (lr.RUBR_ETAT_CODE.Trim() != "C0203" || lr.RUBR_ETAT_CODE.Trim() != "C0204" || lr.RUBR_ETAT_CODE.Trim() != "C0205" || lr.RUBR_ETAT_CODE.Trim() != "C0206" || lr.RUBR_ETAT_CODE.Trim() != "C0207")
                        {
                            //C0203
                            sbTS.AppendLine(string.Format("<tr data_code='{0}'>", lr.RUBR_ETAT_CODE.ToString().Trim()));

                            sbTS.AppendLine(string.Format("<td align='left' >{0}</td>", lr.RUBR_ETAT_LIBELLE));
                            // TabLOTA = new string[Convert.ToInt32(liste_annee.Count)];
                            int p = 0;
                            var liste_valeur = service.AnafiAfficheLiasse(4, compar, lr.RUBR_ETAT_CODE.ToString().Trim(), "SN");

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
                                            sbTS.AppendLine(string.Format("<td align='right' width=12%>{0}</td>", l.VALEUR_TS_DETAIL != Convert.ToDouble(0) ? formatMillier(l.VALEUR_TS_DETAIL.ToString()) : ""));
                                            sbTS.AppendLine(string.Format("<td align='right' width=8%>{0}</td>", l.TAUX_TS_DETAIL != Convert.ToDouble(0) ? Convert.ToDecimal(l.TAUX_TS_DETAIL).ToString("#,##0.##") + "%" : ""));
                                            // TabLOTA[p] = l.VALEUR_RAT_AFF_DETAIL.ToString();
                                            p++;
                                        }
                                    }

                                }
                                else
                                {
                                    if (l.TYPE_ANAFI_A.Trim() == "SN")
                                    {
                                        sbTS.AppendLine(string.Format("<td align='right' width=12%>{0}</td>", l.VALEUR_TS_DETAIL != Convert.ToDouble(0) ? formatMillier(l.VALEUR_TS_DETAIL.ToString()) : ""));
                                        sbTS.AppendLine(string.Format("<td align='right' width=8%>{0}</td>", l.TAUX_TS_DETAIL != Convert.ToDouble(0) ? Convert.ToDecimal(l.TAUX_TS_DETAIL).ToString("#,##0.##") + "%" : ""));
                                        // TabLOTA[p] = l.VALEUR_RAT_AFF_DETAIL.ToString();
                                        p++;
                                    }
                                }
                            }


                            sbTS.AppendLine("</tr>");
                        }
                    }

                }

                sbTS.AppendLine("</tbody>");
                sbTS.AppendLine("</table>");
            }
            else
            {
                sbTS.AppendLine("<table id='' border = '1' font size='1'  class='table table-hover table-bordered text-center'>");
                sbTS.AppendLine("<thead class='table-heigth'>");
                sbTS.AppendLine(string.Format("<tr bgcolor='#022D65' color='#FFFFFF' align='center'><th>Libellés</th>"));
                sbTS.AppendLine(string.Format("<th width=23%></th>"));

                sbTS.AppendLine("</thead>");
                sbTS.AppendLine("<tbody>");

                var liste_libelle = service.AnafiAfficheLiasse(0, "", "", "CR");

                foreach (var lr in liste_libelle)
                {


                    if (lr.RUBR_ETAT_CODE.Trim() == "C019" || lr.RUBR_ETAT_CODE.Trim() == "C029" || lr.RUBR_ETAT_CODE.Trim() == "C039" || lr.RUBR_ETAT_CODE.Trim() == "C049" || lr.RUBR_ETAT_CODE.Trim() == "C059" || lr.RUBR_ETAT_CODE.Trim() == "C069" || lr.RUBR_ETAT_CODE.Trim() == "C079" || lr.RUBR_ETAT_CODE.Trim() == "C089" || lr.RUBR_ETAT_CODE.Trim() == "C099" || lr.RUBR_ETAT_CODE.Trim() == "C109" || lr.RUBR_ETAT_CODE.Trim() == "C119")
                    {
                        sbTS.AppendLine(string.Format("<tr data_code='{0}' bgcolor='#0ddd'>", lr.RUBR_ETAT_CODE.ToString().Trim()));
                        sbTS.AppendLine(string.Format("<td align='left'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE));
                        sbTS.AppendLine(string.Format("<td ></td >"));
                    }
                    else
                    {
                        if (lr.RUBR_ETAT_CODE.Trim() != "C0203" && lr.RUBR_ETAT_CODE.Trim() != "C0204" && lr.RUBR_ETAT_CODE.Trim() != "C0205" && lr.RUBR_ETAT_CODE.Trim() != "C0206" && lr.RUBR_ETAT_CODE.Trim() != "C0207")
                        {
                            //C0203
                            sbTS.AppendLine(string.Format("<tr data_code='{0}'>", lr.RUBR_ETAT_CODE.ToString().Trim()));
                            sbTS.AppendLine(string.Format("<td align='left'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE));
                            sbTS.AppendLine(string.Format("<td ></td >"));
                        }
                    }



                    sbTS.AppendLine("</tr>");
                }

                sbTS.AppendLine("</tbody>");
                sbTS.AppendLine("</table>");
            }


        }
        public void TDR()
        {
            var palatino = FontFactory.GetFont("palatino linotype", BaseFont.CP1252, BaseFont.EMBEDDED, 9, Font.BOLD);
            var boldFont = FontFactory.GetFont("palatino linotype", BaseFont.CP1252, BaseFont.EMBEDDED, 12, Font.BOLD);
            var italicfont = FontFactory.GetFont("palatino linotype", BaseFont.CP1252, BaseFont.EMBEDDED, 9, Font.ITALIC);
            var boldFontTitle = FontFactory.GetFont("palatino linotype", BaseFont.CP1252, BaseFont.EMBEDDED, 14, Font.BOLD);
            var titleFont = FontFactory.GetFont("Segoe UI", 9, BaseColor.WHITE);

            var liste_annee = service.AnafiAfficheLiasse(7, compar, "", "SN");
            var nombre_annee = service.AnafiAfficheLiasse(8, compar, "", "SN");

            // tableau des documents resumé

            if (liste_annee.Count != 0)
            {
                sbTDR.AppendLine("<table id='' border = '1' font size='1'  class='table table-hover table-bordered text-center'>");
                sbTDR.AppendLine("<thead class='table-heigth'>");
                sbTDR.AppendLine(string.Format("<tr bgcolor='#022D65' color='#FFFFFF' align='center'><th>Valeurs structurelles</th>"));

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
                                sbTDR.AppendLine(string.Format("<th width=18%>{0}</th>", lr.ANNEE_DETAIL));
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
                            sbTDR.AppendLine(string.Format("<th width=18%>{0}</th>", lr.ANNEE_DETAIL));
                            //TabLOT[i] = lr.ANNEE_DETAIL;
                        }
                        i++;
                    }
                }


                sbTDR.AppendLine("</thead>");
                sbTDR.AppendLine("<tbody>");

                var liste_libelle = service.AnafiAfficheLiasse(0, "", "", "TDR");

                foreach (var lr in liste_libelle)
                {
                    if (lr.RUBR_ETAT_CODE.Trim() == "BI40" || lr.RUBR_ETAT_CODE.Trim() == "BI41" || lr.RUBR_ETAT_CODE.Trim() == "BI42" || lr.RUBR_ETAT_CODE.Trim() == "BI43" || lr.RUBR_ETAT_CODE.Trim() == "BJ00" || lr.RUBR_ETAT_CODE.Trim() == "BJ1" || lr.RUBR_ETAT_CODE.Trim() == "BI6A" || lr.RUBR_ETAT_CODE.Trim() == "BK1" || lr.RUBR_ETAT_CODE.Trim() == "TN1" || lr.RUBR_ETAT_CODE.Trim() == "TN20" || lr.RUBR_ETAT_CODE.Trim() == "TN21" || lr.RUBR_ETAT_CODE.Trim() == "ZN2" || lr.RUBR_ETAT_CODE.Trim() == "BI2A" || lr.RUBR_ETAT_CODE.Trim() == "BI3A" || lr.RUBR_ETAT_CODE.Trim() == "BI7A")
                    {
                        if (lr.RUBR_ETAT_CODE.Trim() == "BJ1" || lr.RUBR_ETAT_CODE.Trim() == "BK1" || lr.RUBR_ETAT_CODE.Trim() == "TN1" || lr.RUBR_ETAT_CODE.Trim() == "ZN2")
                        {
                            sbTDR.AppendLine(string.Format("<tr data_code='{0}' style='background-color:#ddd'>", lr.RUBR_ETAT_CODE.ToString().Trim()));

                            sbTDR.AppendLine(string.Format("<td align='left'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE));
                            // TabLOTA = new string[Convert.ToInt32(liste_annee.Count)];
                            int p = 0;
                            var liste_valeur = service.AnafiAfficheLiasse(5, compar, lr.RUBR_ETAT_CODE.ToString().Trim(), "SN");

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
                                            //sbTDR.AppendLine(string.Format("<td align='right'><strong>{0}</strong></td>", Convert.ToString(string.Format(frCult, "{0:#,##0}", l.VALEUR_TDR_DETAIL))));
                                            sbTDR.AppendLine(string.Format("<td align='right'><strong>{0}</strong></td>", formatMillier(Convert.ToDecimal(l.VALEUR_TDR_DETAIL).ToString("#,##0.##")))); //21112019 blaise 
                                            // TabLOTA[p] = l.VALEUR_TDR_DETAIL.ToString();
                                            p++;
                                        }
                                    }

                                }
                                else
                                {
                                    if (l.TYPE_ANAFI_A.Trim() == "SN")
                                    {
                                        sbTDR.AppendLine(string.Format("<td align='right'><strong>{0}</strong></td>", formatMillier(Convert.ToDecimal(l.VALEUR_TDR_DETAIL).ToString("#,##0.##")))); //21112019 blaise 
                                        // TabLOTA[p] = l.VALEUR_TDR_DETAIL.ToString();
                                        p++;
                                    }
                                }
                            }


                            sbTDR.AppendLine("</tr>");
                        }
                        else
                        {
                            sbTDR.AppendLine(string.Format("<tr data_code='{0}'>", lr.RUBR_ETAT_CODE.ToString().Trim()));

                            sbTDR.AppendLine(string.Format("<td align='left'>{0}</td>", lr.RUBR_ETAT_LIBELLE));
                            // TabLOTA = new string[Convert.ToInt32(liste_annee.Count)];
                            int p = 0;
                            var liste_valeur = service.AnafiAfficheLiasse(5, compar, lr.RUBR_ETAT_CODE.ToString().Trim(), "SN");

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
                                            sbTDR.AppendLine(string.Format("<td align='right'>{0}</td>", formatMillier(Convert.ToDecimal(l.VALEUR_TDR_DETAIL).ToString("#,##0.##")))); //21112019 blaise 
                                            // TabLOTA[p] = l.VALEUR_TDR_DETAIL.ToString();
                                            p++;
                                        }
                                    }

                                }
                                else
                                {
                                    if (l.TYPE_ANAFI_A.Trim() == "SN")
                                    {
                                        sbTDR.AppendLine(string.Format("<td align='right'>{0}</td>", formatMillier(Convert.ToDecimal(l.VALEUR_TDR_DETAIL).ToString("#,##0.##")))); //21112019 blaise 
                                        // TabLOTA[p] = l.VALEUR_TDR_DETAIL.ToString();
                                        p++;
                                    }
                                }
                            }

                            sbTDR.AppendLine("</tr>");
                        }
                    }
                    else
                    {
                        if (lr.RUBR_ETAT_CODE.Trim() == "ZN3")
                        {
                            sbTDR.AppendLine(string.Format("<tr border = '0' style='background-color:transparent; border:none;'>"));
                            sbTDR.AppendLine(string.Format("<td align='center' border = '0' style='background-color:transparent; border:none;'><strong>RATIOS</strong></td>"));

                            int p = 0;
                            var liste_valeur = service.AnafiAfficheLiasse(5, compar, lr.RUBR_ETAT_CODE.ToString().Trim(), "SN");

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
                                            sbTDR.AppendLine(string.Format("<td border = '0' align='left' style='background-color:transparent; border:none;'><strong></strong></td>"));

                                            p++;
                                        }
                                    }

                                }
                                else
                                {
                                    if (l.TYPE_ANAFI_A.Trim() == "SN")
                                    {
                                        sbTDR.AppendLine(string.Format("<td border = '0' align='left' style='background-color:transparent; border:none;'><strong></strong></td>"));

                                        p++;
                                    }
                                }
                            }

                            sbTDR.AppendLine("</tr>");
                        }
                        else
                        {
                            sbTDR.AppendLine(string.Format("<tr data_code='{0}'>", lr.RUBR_ETAT_CODE.ToString().Trim()));

                            sbTDR.AppendLine(string.Format("<td align='left'>{0}</td>", lr.RUBR_ETAT_LIBELLE));
                            // TabLOTA = new string[Convert.ToInt32(liste_annee.Count)];
                            int p = 0;
                            var liste_valeur = service.AnafiAfficheLiasse(5, compar, lr.RUBR_ETAT_CODE.ToString().Trim(), "SN");

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
                                            sbTDR.AppendLine(string.Format("<td align='right'>{0}</td>", formatMillier(Convert.ToDecimal(l.VALEUR_TDR_DETAIL).ToString("#,##0.##")))); //21112019 blaise 
                                            // TabLOTA[p] = l.VALEUR_TDR_DETAIL.ToString();
                                            p++;
                                        }
                                    }

                                }
                                else
                                {
                                    if (l.TYPE_ANAFI_A.Trim() == "SN")
                                    {
                                        sbTDR.AppendLine(string.Format("<td align='right'>{0}</td>", formatMillier(Convert.ToDecimal(l.VALEUR_TDR_DETAIL).ToString("#,##0.##")))); //21112019 blaise 
                                        // TabLOTA[p] = l.VALEUR_TDR_DETAIL.ToString();
                                        p++;
                                    }
                                }
                            }

                            sbTDR.AppendLine("</tr>");
                        }
                    }



                }

                sbTDR.AppendLine("</tbody>");
                sbTDR.AppendLine("</table>");
            }
            else
            {
                sbTDR.AppendLine("<table id='' border = '1' font size='1'  class='table table-hover table-bordered text-center'>");
                sbTDR.AppendLine("<thead class='table-heigth'>");
                sbTDR.AppendLine(string.Format("<tr bgcolor='#022D65' color='#FFFFFF' align='center'><th>Valeurs structurelles</th>"));
                sbTDR.AppendLine(string.Format("<th width=23%></th></tr>"));

                sbTDR.AppendLine("</thead>");
                sbTDR.AppendLine("<tbody>");

                var liste_libelle = service.AnafiAfficheLiasse(0, "", "", "TDR");

                foreach (var lr in liste_libelle)
                {
                    if (lr.RUBR_ETAT_CODE.Trim() == "BI40" || lr.RUBR_ETAT_CODE.Trim() == "BI41" || lr.RUBR_ETAT_CODE.Trim() == "BI42" || lr.RUBR_ETAT_CODE.Trim() == "BI43" || lr.RUBR_ETAT_CODE.Trim() == "BJ00" || lr.RUBR_ETAT_CODE.Trim() == "BJ1" || lr.RUBR_ETAT_CODE.Trim() == "BI6A" || lr.RUBR_ETAT_CODE.Trim() == "BK1" || lr.RUBR_ETAT_CODE.Trim() == "TN1" || lr.RUBR_ETAT_CODE.Trim() == "TN20" || lr.RUBR_ETAT_CODE.Trim() == "TN21" || lr.RUBR_ETAT_CODE.Trim() == "ZN2" || lr.RUBR_ETAT_CODE.Trim() == "BI2A" || lr.RUBR_ETAT_CODE.Trim() == "BI3A" || lr.RUBR_ETAT_CODE.Trim() == "BI7A")
                    {
                        if (lr.RUBR_ETAT_CODE.Trim() == "BJ1" || lr.RUBR_ETAT_CODE.Trim() == "BK1" || lr.RUBR_ETAT_CODE.Trim() == "TN1" || lr.RUBR_ETAT_CODE.Trim() == "ZN2")
                        {
                            sbTDR.AppendLine(string.Format("<tr data_code='{0}' style='background-color:#ddd'>", lr.RUBR_ETAT_CODE.ToString().Trim()));

                            sbTDR.AppendLine(string.Format("<td align='left'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE));
                            sbTDR.AppendLine(string.Format("<td></td>"));

                            sbTDR.AppendLine("</tr>");
                        }
                        else
                        {
                            sbTDR.AppendLine(string.Format("<tr data_code='{0}'>", lr.RUBR_ETAT_CODE.ToString().Trim()));

                            sbTDR.AppendLine(string.Format("<td align='left'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE));
                            sbTDR.AppendLine(string.Format("<td></td>"));

                            sbTDR.AppendLine("</tr>");
                        }
                    }
                    else
                    {
                        if (lr.RUBR_ETAT_CODE.Trim() == "ZN3")
                        {
                            sbTDR.AppendLine(string.Format("<tr border = '0' style='background-color:transparent; border:none;'>"));
                            sbTDR.AppendLine(string.Format("<td align='center' border = '0' style='background-color:transparent; border:none;'><strong>RATIOS</strong></td>"));
                            sbTDR.AppendLine(string.Format("<td align='center' border = '0' style='background-color:transparent; border:none;'></td>"));
                            sbTDR.AppendLine("</tr>");
                        }
                        else
                        {
                            sbTDR.AppendLine(string.Format("<tr data_code='{0}'>", lr.RUBR_ETAT_CODE.ToString().Trim()));

                            sbTDR.AppendLine(string.Format("<td align='left'>{0}</td>", lr.RUBR_ETAT_LIBELLE));
                            sbTDR.AppendLine(string.Format("<td></td>"));

                            sbTDR.AppendLine("</tr>");
                        }
                    }



                }

                sbTDR.AppendLine("</tbody>");
                sbTDR.AppendLine("</table>");
            }
        }
        public void TAR()
        {
            var palatino = FontFactory.GetFont("palatino linotype", BaseFont.CP1252, BaseFont.EMBEDDED, 9, Font.BOLD);
            var boldFont = FontFactory.GetFont("palatino linotype", BaseFont.CP1252, BaseFont.EMBEDDED, 12, Font.BOLD);
            var italicfont = FontFactory.GetFont("palatino linotype", BaseFont.CP1252, BaseFont.EMBEDDED, 9, Font.ITALIC);
            var boldFontTitle = FontFactory.GetFont("palatino linotype", BaseFont.CP1252, BaseFont.EMBEDDED, 14, Font.BOLD);
            var titleFont = FontFactory.GetFont("Segoe UI", 9, BaseColor.WHITE);

            var liste_annee = service.AnafiAfficheLiasse(7, compar, "", "SN");
            var nombre_annee = service.AnafiAfficheLiasse(8, compar, "", "SN");

            //Tableau des autre ratio


            if (liste_annee.Count != 0)
            {
                sbTAR.AppendLine("<table id='' border = '1' font size='1'  class='table table-hover table-bordered text-center'>");
                sbTAR.AppendLine("<thead class='table-heigth'>");
                sbTAR.AppendLine(string.Format("<tr bgcolor='#022D65' color='#FFFFFF' align='center'><th>Autres ratios</th>"));

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
                                sbTAR.AppendLine(string.Format("<th width=13%>{0}</th>", lr.ANNEE_DETAIL));
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
                            sbTAR.AppendLine(string.Format("<th width=13%>{0}</th>", lr.ANNEE_DETAIL));
                            //TabLOT[i] = lr.ANNEE_DETAIL;
                        }
                        i++;
                    }
                }

                sbTAR.AppendLine("</thead>");
                sbTAR.AppendLine("<tbody>");

                var liste_libelle = service.AnafiAfficheLiasse(0, "", "", "AUT");

                foreach (var lr in liste_libelle)
                {

                    sbTAR.AppendLine(string.Format("<tr>"));

                    sbTAR.AppendLine(string.Format("<td align='left'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE));
                    // TabLOTA = new string[Convert.ToInt32(liste_annee.Count)];
                    int p = 0;
                    var liste_valeur = service.AnafiAfficheLiasse(13, compar, lr.RUBR_ETAT_CODE.ToString().Trim(), "SN");

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
                                        sbTAR.AppendLine(string.Format("<td align='right'><strong>{0}%</strong></td>", formatMillier(Convert.ToDecimal(l.VALEUR_AUTRE_RAT_AFF_DETAIL).ToString("#,##0.##"))));
                                    else
                                        sbTAR.AppendLine(string.Format("<td align='right'><strong>{0}</strong></td>", formatMillier(Convert.ToDecimal(l.VALEUR_AUTRE_RAT_AFF_DETAIL).ToString("#,##0.##"))));
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
                                    sbTAR.AppendLine(string.Format("<td align='right'><strong>{0}%</strong></td>", formatMillier(Convert.ToDecimal(l.VALEUR_AUTRE_RAT_AFF_DETAIL).ToString("#,##0.##"))));
                                else
                                    sbTAR.AppendLine(string.Format("<td align='right'><strong>{0}</strong></td>", formatMillier(Convert.ToDecimal(l.VALEUR_AUTRE_RAT_AFF_DETAIL).ToString("#,##0.##"))));
                                // TabLOTA[p] = l.VALEUR_RAT_AFF_DETAIL.ToString();
                                p++;
                            }
                        }
                    }


                    sbTAR.AppendLine("</tr>");
                }

                sbTAR.AppendLine("</tbody>");
                sbTAR.AppendLine("</table>");
            }
            else
            {
                sbTAR.AppendLine("<table id='' border = '1' font size='1'  class='table table-hover table-bordered text-center'>");
                sbTAR.AppendLine("<thead class='table-heigth'>");
                sbTAR.AppendLine(string.Format("<tr bgcolor='#022D65' color='#FFFFFF' align='center'><th>Autres ratios</th>"));
                sbTAR.AppendLine(string.Format("<th width=23%></th>"));

                sbTAR.AppendLine("</thead>");
                sbTAR.AppendLine("<tbody>");

                var liste_libelle = service.AnafiAfficheLiasse(0, "", "", "AUT");

                foreach (var lr in liste_libelle)
                {

                    sbTAR.AppendLine(string.Format("<tr>"));

                    sbTAR.AppendLine(string.Format("<td align='left'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE));
                    sbTAR.AppendLine(string.Format("<td ></td >"));

                    sbTAR.AppendLine("</tr>");
                }

                sbTAR.AppendLine("</tbody>");
                sbTAR.AppendLine("</table>");
            }

        }
        public void Ratios()
        {
            var palatino = FontFactory.GetFont("palatino linotype", BaseFont.CP1252, BaseFont.EMBEDDED, 9, Font.BOLD);
            var boldFont = FontFactory.GetFont("palatino linotype", BaseFont.CP1252, BaseFont.EMBEDDED, 12, Font.BOLD);
            var italicfont = FontFactory.GetFont("palatino linotype", BaseFont.CP1252, BaseFont.EMBEDDED, 9, Font.ITALIC);
            var boldFontTitle = FontFactory.GetFont("palatino linotype", BaseFont.CP1252, BaseFont.EMBEDDED, 14, Font.BOLD);
            var titleFont = FontFactory.GetFont("Segoe UI", 9, BaseColor.WHITE);

            var liste_annee = service.AnafiAfficheLiasse(7, compar, "", "SN");
            var nombre_annee = service.AnafiAfficheLiasse(8, compar, "", "SN");

            // Tableau des ratios

            if (liste_annee.Count != 0)
            {
                sbTR.AppendLine("<table id='' border = '1' font size='1'  class='table table-hover table-bordered text-center'>");
                sbTR.AppendLine("<thead class='table-heigth'>");
                sbTR.AppendLine(string.Format("<tr bgcolor='#022D65' color='#FFFFFF' align='center'><th >Ratios</th>"));

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
                                sbTR.AppendLine(string.Format("<th width=13%>{0}</th>", lr.ANNEE_DETAIL));
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
                            sbTR.AppendLine(string.Format("<th width=13%>{0}</th>", lr.ANNEE_DETAIL));
                            //TabLOT[i] = lr.ANNEE_DETAIL;
                        }
                        i++;
                    }
                }

                sbTR.AppendLine("</thead>");
                sbTR.AppendLine("<tbody>");

                var liste_libelle = service.AnafiAfficheLiasse(0, "", "", "RAT");

                foreach (var lr in liste_libelle)
                {

                    sbTR.AppendLine(string.Format("<tr>"));

                    sbTR.AppendLine(string.Format("<td align='left'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE));
                    // TabLOTA = new string[Convert.ToInt32(liste_annee.Count)];
                    int p = 0;
                    var liste_valeur = service.AnafiAfficheLiasse(6, compar, lr.RUBR_ETAT_CODE.ToString().Trim(), "SN");

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
                                        sbTR.AppendLine(string.Format("<td align='right'><strong>{0}</strong></td>",formatMillier( Convert.ToDecimal(l.VALEUR_RAT_AFF_DETAIL).ToString("#,##0.##"))));
                                    else
                                        sbTR.AppendLine(string.Format("<td align='right'><strong>{0}%</strong></td>", formatMillier(Convert.ToDecimal(l.VALEUR_RAT_AFF_DETAIL).ToString("#,##0.##"))));
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
                                    sbTR.AppendLine(string.Format("<td align='right'><strong>{0}</strong></td>", formatMillier(Convert.ToDecimal(l.VALEUR_RAT_AFF_DETAIL).ToString("#,##0.##"))));
                                else
                                    sbTR.AppendLine(string.Format("<td align='right'><strong>{0}%</strong></td>", formatMillier(Convert.ToDecimal(l.VALEUR_RAT_AFF_DETAIL).ToString("#,##0.##"))));
                                // TabLOTA[p] = l.VALEUR_RAT_AFF_DETAIL.ToString();
                                p++;
                            }
                        }
                    }


                    sbTR.AppendLine("</tr>");
                }

                sbTR.AppendLine("</tbody>");
                sbTR.AppendLine("</table>");
            }
            else
            {

                sbTR.AppendLine("<table id='' border = '1' font size='1'  class='table table-hover table-bordered text-center'>");
                sbTR.AppendLine("<thead class='table-heigth'>");
                sbTR.AppendLine(string.Format("<tr bgcolor='#022D65' color='#FFFFFF' align='center'><th>Ratios</th>"));
                sbTR.AppendLine(string.Format("<th width=23%></th>"));

                sbTR.AppendLine("</thead>");
                sbTR.AppendLine("<tbody>");

                var liste_libelle = service.AnafiAfficheLiasse(0, "", "", "RAT");

                foreach (var lr in liste_libelle)
                {

                    sbTR.AppendLine(string.Format("<tr>"));

                    sbTR.AppendLine(string.Format("<td align='left'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE));
                    sbTR.AppendLine(string.Format("<td ></td >"));

                    sbTR.AppendLine("</tr>");
                }

                sbTR.AppendLine("</tbody>");
                sbTR.AppendLine("</table>");
            }
        }
        public void titletableaux()
        {
            Font boldFont2 = new Font(Font.FontFamily.TIMES_ROMAN, 9, Font.BOLD, BaseColor.BLACK);
            Font boldFont22 = new Font(Font.FontFamily.TIMES_ROMAN, 9, Font.BOLD, BaseColor.WHITE);
            Font normalFont2 = new Font(Font.FontFamily.TIMES_ROMAN, 9, Font.ITALIC, BaseColor.BLACK);
            Font boldFontTitle2 = new Font(Font.FontFamily.TIMES_ROMAN, 19, Font.BOLD, BaseColor.RED);
            var palatino = FontFactory.GetFont("palatino linotype", BaseFont.CP1252, BaseFont.EMBEDDED, 9, Font.BOLD);
            var boldFont = FontFactory.GetFont("palatino linotype", BaseFont.CP1252, BaseFont.EMBEDDED, 12, Font.BOLD);
            var italicfont = FontFactory.GetFont("palatino linotype", BaseFont.CP1252, BaseFont.EMBEDDED, 9, Font.ITALIC);
            var boldFontTitle = FontFactory.GetFont("palatino linotype", BaseFont.CP1252, BaseFont.EMBEDDED, 14, Font.BOLD);
            //var boldFontTitle2 = FontFactory.GetFont("palatino linotype", BaseFont.CP1252, BaseFont.EMBEDDED, 12, Font.ITALIC, BaseColor.RED);
            var titleFont = FontFactory.GetFont("Segoe UI", 9, BaseColor.WHITE);


            debut.TotalWidth = 550f;
            debut.HorizontalAlignment = 1;
            debut.LockedWidth = true;

            Tableentete.TotalWidth = 470f;
            Tableentete.HorizontalAlignment = 1;
            Tableentete.LockedWidth = true;

            TABLEACTIFS.TotalWidth = 550f;
            TABLEACTIFS.HorizontalAlignment = 1;
            TABLEACTIFS.LockedWidth = true;


            TABLEACTIFSBilan.TotalWidth = 550f;
            TABLEACTIFSBilan.HorizontalAlignment = 1;
            TABLEACTIFSBilan.LockedWidth = true;

            PdfPCell ACTIFSBilan = new PdfPCell(new Phrase("Bilan", boldFontTitle));
            ACTIFSBilan.PaddingTop = 5f;
            ACTIFSBilan.Colspan = 2;
            ACTIFSBilan.Border = 0;
            ACTIFSBilan.HorizontalAlignment = 1;
            TABLEACTIFSBilan.AddCell(ACTIFSBilan);
            TABLEACTIFSBilan.SpacingBefore = 10f;
            TABLEACTIFSBilan.SpacingAfter = 12.5f;


            TABLEPASSIFS.TotalWidth = 550f;
            TABLEPASSIFS.HorizontalAlignment = 1;
            TABLEPASSIFS.LockedWidth = true;


            PdfPCell PASSIFS = new PdfPCell(new Phrase("Bilan", boldFontTitle));
            PASSIFS.PaddingTop = 5f;
            PASSIFS.Colspan = 2;
            PASSIFS.Border = 0;
            PASSIFS.HorizontalAlignment = 1;
            TABLEPASSIFS.AddCell(PASSIFS);
            TABLEPASSIFS.SpacingBefore = 10f;
            TABLEPASSIFS.SpacingAfter = 12.5f;

            TABLEECART.TotalWidth = 550f;
            TABLEECART.HorizontalAlignment = 1;
            TABLEECART.LockedWidth = true;
            PdfPCell Ecart = new PdfPCell(new Phrase("Ecarts", boldFontTitle));
            Ecart.PaddingTop = 5f;
            Ecart.Colspan = 2;
            Ecart.Border = 0;
            Ecart.HorizontalAlignment = 1;
            TABLEECART.AddCell(Ecart);
            TABLEECART.SpacingBefore = 10f;
            TABLEECART.SpacingAfter = 12.5f;

            if (AdireExpert.Trim() != "")
            {
                PdfPCell title11 = new PdfPCell(new Phrase("[" + AdireExpert + "]", boldFontTitle2));
                title11.PaddingTop = 5f;
                title11.Colspan = 2;
                title11.Border = 0;
                //title.BackgroundColor =;
                title11.HorizontalAlignment = 2;
                title11.VerticalAlignment = Element.ALIGN_TOP;
                Tableentete.AddCell(title11);
            }


            PdfPCell title = new PdfPCell(new Phrase("DOSSIER DE NOTATION", boldFontTitle));
            title.PaddingTop = 15f;
            title.Colspan = 2;
            title.Border = 0;
            title.HorizontalAlignment = 1;
            Tableentete.AddCell(title);

            TABLECharge.TotalWidth = 550f;
            TABLECharge.HorizontalAlignment = 1;
            TABLEACTIFS.LockedWidth = true;
            PdfPCell Charge = new PdfPCell(new Phrase("Compte de résultat", boldFontTitle));
            Charge.PaddingTop = 5f;
            Charge.Colspan = 2;
            Charge.Border = 0;
            Charge.HorizontalAlignment = 1;
            TABLECharge.AddCell(Charge);
            TABLECharge.SpacingBefore = 10f;
            TABLECharge.SpacingAfter = 12.5f;
            TABLEProduit.TotalWidth = 550f;
            TABLEProduit.HorizontalAlignment = 1;
            TABLEProduit.LockedWidth = true;
            PdfPCell Produit = new PdfPCell(new Phrase("Compte de résultat", boldFontTitle));
            Produit.PaddingTop = 5f;
            Produit.Colspan = 2;
            Produit.Border = 0;
            Produit.HorizontalAlignment = 1;
            TABLEProduit.AddCell(Produit);
            TABLEProduit.SpacingBefore = 10f;
            TABLEProduit.SpacingAfter = 12.5f;

            TABLEProduit.TotalWidth = 550f;
            TABLEProduit.HorizontalAlignment = 1;
            TABLEProduit.LockedWidth = true;
            PdfPCell cellvide = new PdfPCell(new Phrase("Compte de résultat", boldFont22));
            cellvide.PaddingTop = 5f;
            cellvide.Colspan = 2;
            cellvide.Border = 0;
            cellvide.HorizontalAlignment = 1;
            TABLEvide.AddCell(cellvide);
            TABLEvide.SpacingBefore = 10f;
            TABLEvide.SpacingAfter = 12.5f;


            TABLEGMS.TotalWidth = 550f;
            TABLEGMS.HorizontalAlignment = 1;
            TABLEGMS.LockedWidth = true;
            PdfPCell GMS = new PdfPCell(new Phrase("BILAN EN GRANDES MASSES ACTIFS", boldFontTitle));
            GMS.PaddingTop = 5f;
            GMS.Colspan = 2;
            GMS.Border = 0;
            GMS.HorizontalAlignment = 1;
            TABLEGMS.AddCell(GMS);
            TABLEGMS.SpacingBefore = 10f;
            TABLEGMS.SpacingAfter = 12.5f;

            TABLEGMS1.TotalWidth = 550f;
            TABLEGMS1.HorizontalAlignment = 1;
            TABLEGMS1.LockedWidth = true;
            PdfPCell GMS1 = new PdfPCell(new Phrase("BILAN EN GRANDES MASSES  PASSIFS", boldFontTitle));
            GMS1.PaddingTop = 5f;
            GMS1.Colspan = 2;
            GMS1.Border = 0;
            GMS1.HorizontalAlignment = 1;
            TABLEGMS1.AddCell(GMS1);
            TABLEGMS1.SpacingBefore = 10f;
            TABLEGMS1.SpacingAfter = 12.5f;

            TABLETS.TotalWidth = 550f;
            TABLETS.HorizontalAlignment = 1;
            TABLETS.LockedWidth = true;
            PdfPCell TS = new PdfPCell(new Phrase("TABLEAU SYNTHETIQUE DES SSG", boldFontTitle));
            TS.PaddingTop = 5f;
            TS.Colspan = 2;
            TS.Border = 0;
            TS.HorizontalAlignment = 1;
            TABLETS.AddCell(TS);
            TABLETS.SpacingBefore = 10f;
            TABLETS.SpacingAfter = 12.5f;

            TABLETDR.TotalWidth = 550f;
            TABLETDR.HorizontalAlignment = 1;
            TABLETDR.LockedWidth = true;
            PdfPCell TDR = new PdfPCell(new Phrase("TABLEAU DES DOCUMENTS RESUMES", boldFontTitle));
            TDR.PaddingTop = 5f;
            TDR.Colspan = 2;
            TDR.Border = 0;
            TDR.HorizontalAlignment = 1;
            TABLETDR.AddCell(TDR);
            TABLETDR.SpacingBefore = 10f;
            TABLETDR.SpacingAfter = 12.5f;


            TABLETAR.TotalWidth = 550f;
            TABLETAR.HorizontalAlignment = 1;
            TABLETAR.LockedWidth = true;
            PdfPCell TAR = new PdfPCell(new Phrase("TABLEAU DES AUTRES RATIOS", boldFontTitle));
            TAR.PaddingTop = 5f;
            TAR.Colspan = 2;
            TAR.Border = 0;
            TAR.HorizontalAlignment = 1;
            TABLETAR.AddCell(TAR);
            TABLETAR.SpacingBefore = 10f;
            TABLETAR.SpacingAfter = 12.5f;

            TABLESTAT.TotalWidth = 550f;
            TABLESTAT.HorizontalAlignment = 1;
            TABLESTAT.LockedWidth = true;
            PdfPCell STATU = new PdfPCell(new Phrase("Notation / Information sur le statut", boldFontTitle));
            STATU.PaddingTop = 5f;
            STATU.Colspan = 2;
            STATU.Border = 0;
            STATU.HorizontalAlignment = 1;
            TABLESTAT.AddCell(STATU);
            TABLESTAT.SpacingBefore = 10f;
            TABLESTAT.SpacingAfter = 12.5f;

            TABLESTAT2.TotalWidth = 550f;
            TABLESTAT2.HorizontalAlignment = 1;
            TABLESTAT2.LockedWidth = true;

            TABLETR.TotalWidth = 550f;
            TABLETR.HorizontalAlignment = 1;
            TABLETR.LockedWidth = true;

            TABLETRQUALIT.TotalWidth = 550f;
            TABLETRQUALIT.HorizontalAlignment = 1;
            TABLETRQUALIT.LockedWidth = true;

            TABLETROPERATION.TotalWidth = 550f;
            TABLETROPERATION.HorizontalAlignment = 1;
            TABLETROPERATION.LockedWidth = true;
            var idDossier1 = compar1;
            var elements = _service.InfoDossier(idDossier1);
            foreach (var dossier in elements)
            {
                modele = dossier.MODELE_DOSSIER;
            }

            if (modele.Trim() != "GROUP")
            {
                PdfPCell TR = new PdfPCell(new Phrase("Analyse Financière", boldFontTitle));
                TR.PaddingTop = 5f;
                TR.Colspan = 2;
                TR.Border = 0;
                TR.HorizontalAlignment = 1;
                TABLETR.AddCell(TR);
                TABLETR.SpacingBefore = 10f;
                TABLETR.SpacingAfter = 12.5f;


                PdfPCell TRTABLETROPERATION = new PdfPCell(new Phrase("Analyse de l'opération", boldFontTitle));
                TRTABLETROPERATION.PaddingTop = 5f;
                TRTABLETROPERATION.Colspan = 2;
                TRTABLETROPERATION.Border = 0;
                TRTABLETROPERATION.HorizontalAlignment = 1;
                TABLETROPERATION.AddCell(TRTABLETROPERATION);
                TABLETROPERATION.SpacingBefore = 10f;
                TABLETROPERATION.SpacingAfter = 12.5f;

                PdfPCell TRTABLETRQUALIT = new PdfPCell(new Phrase("Analyse Qualitative", boldFontTitle));
                TRTABLETRQUALIT.PaddingTop = 5f;
                TRTABLETRQUALIT.Colspan = 2;
                TRTABLETRQUALIT.Border = 0;
                TRTABLETRQUALIT.HorizontalAlignment = 1;
                TABLETRQUALIT.AddCell(TRTABLETRQUALIT);
                TABLETRQUALIT.SpacingBefore = 10f;
                TABLETRQUALIT.SpacingAfter = 12.5f;


                PdfPCell ACTIFS = new PdfPCell(new Phrase("Etat financière", boldFontTitle));
                ACTIFS.PaddingTop = 5f;
                ACTIFS.Colspan = 2;
                ACTIFS.Border = 0;
                ACTIFS.HorizontalAlignment = 1;
                TABLEACTIFS.AddCell(ACTIFS);
                TABLEACTIFS.SpacingBefore = 10f;
                TABLEACTIFS.SpacingAfter = 12.5f;
            }
            else
            {
                PdfPCell TR = new PdfPCell(new Phrase("Analyse Consolidée", boldFontTitle));
                TR.PaddingTop = 5f;
                TR.Colspan = 2;
                TR.Border = 0;
                TR.HorizontalAlignment = 1;
                TABLETR.AddCell(TR);
                TABLETR.SpacingBefore = 10f;
                TABLETR.SpacingAfter = 12.5f;


                PdfPCell TRTABLETRQUALIT = new PdfPCell(new Phrase("Analyse Structurelle groupe", boldFontTitle));
                TRTABLETRQUALIT.PaddingTop = 5f;
                TRTABLETRQUALIT.Colspan = 2;
                TRTABLETRQUALIT.Border = 0;
                TRTABLETRQUALIT.HorizontalAlignment = 1;
                TABLETRQUALIT.AddCell(TRTABLETRQUALIT);
                TABLETRQUALIT.SpacingBefore = 10f;
                TABLETRQUALIT.SpacingAfter = 12.5f;


                PdfPCell TRTABLETROPERATION = new PdfPCell(new Phrase("Analyse de l'opération", boldFontTitle));
                TRTABLETROPERATION.PaddingTop = 5f;
                TRTABLETROPERATION.Colspan = 2;
                TRTABLETROPERATION.Border = 0;
                TRTABLETROPERATION.HorizontalAlignment = 1;
                TABLETROPERATION.AddCell(TRTABLETROPERATION);
                TABLETROPERATION.SpacingBefore = 10f;
                TABLETROPERATION.SpacingAfter = 12.5f;
            }



            PdfPCell STATU2 = new PdfPCell(new Phrase("Output RatingPro (Résultats Finals) ", boldFontTitle));
            STATU2.PaddingTop = 5f;
            STATU2.Colspan = 2;
            STATU2.Border = 0;
            STATU2.HorizontalAlignment = 1;
            TABLESTAT2.AddCell(STATU2);
            TABLESTAT2.SpacingBefore = 10f;
            TABLESTAT2.SpacingAfter = 12.5f;




            tableAnotationTitre.TotalWidth = 550f;
            tableAnotationTitre.HorizontalAlignment = 1;
            tableAnotationTitre.LockedWidth = true;
            PdfPCell TRtableAnotationTitre = new PdfPCell(new Phrase("Commentaires", boldFontTitle));
            TRtableAnotationTitre.PaddingTop = 5f;
            TRtableAnotationTitre.Colspan = 2;
            TRtableAnotationTitre.Border = 0;
            TRtableAnotationTitre.HorizontalAlignment = 1;
            tableAnotationTitre.AddCell(TRtableAnotationTitre);
            tableAnotationTitre.SpacingBefore = 10f;
            tableAnotationTitre.SpacingAfter = 12.5f;
        }
        public void EtatsANAFI()
        {
            string etat = Request.QueryString["id"].Trim();
            //TabEditeAnafi etat.Split("@");
            Char delimiter = '@';
            string[] resutdonnee = etat.ToString().Split(delimiter);
            int nobr = resutdonnee.Length;
            string annrecup = resutdonnee[nobr - 1];
            string annMoinUn = (Convert.ToDecimal(annrecup.Trim().Substring(3, 4)) - 1).ToString();
            if (nobr == 3)
            {
                if (resutdonnee[1] == "COMPTERESULTAT")
                {
                    cr1 = "COMPTERESULTAT";
                    bi1 = "";
                    bi1cr1 = "";
                    PS_SCOR_ETATBILAN_CHARGE1(annrecup);
                    PS_SCOR_ETATBILAN_PRODUIT1(annrecup);
                    PS_SCOR_ETATBILAN_CHARGE2(annrecup);
                    PS_SCOR_ETATBILAN_PRODUIT2(annrecup);
                    //PS_SCOR_ETATBILAN_AM(annrecup);
                    //PS_SCOR_ETATBILAN_ACT_CIRCUL(annrecup);
                    //CompteResultatsChargeAnfi(annrecup, annMoinUn);
                    //CompteResultatsProduitsAnfi(annrecup, annMoinUn);
                }
                if (resutdonnee[1] == "BILAN")
                {
                    bi1 = "BILAN";
                    cr1 = "";
                    bi1cr1 = "";
                    PS_SCOR_ETATBILAN_AM(annrecup);
                    PS_SCOR_ETATBILAN_ACT_CIRCUL(annrecup);
                    PS_SCOR_ETATBILAN_PCIRCUL(annrecup);
                    PS_SCOR_ETATBILAN_PC(annrecup);
                    //PS_SCOR_ETATBILAN_ACT_CIRCUL(annrecup);
                    //BilanActifsAnfi(annrecup, annMoinUn);
                    //BilanPassifsAnfi(annrecup, annMoinUn);
                    //BilanEcartsAnfi(annrecup, annMoinUn);

                }
            }
            if (nobr == 4)
            {
                bi1cr1 = "COMPTERESULTATBILAN";
                cr1 = "";
                bi1 = "";
                PS_SCOR_ETATBILAN_CHARGE1(annrecup);
                PS_SCOR_ETATBILAN_CHARGE2(annrecup);
                PS_SCOR_ETATBILAN_PRODUIT1(annrecup);
                PS_SCOR_ETATBILAN_PRODUIT2(annrecup);
                PS_SCOR_ETATBILAN_AM(annrecup);
                PS_SCOR_ETATBILAN_ACT_CIRCUL(annrecup);
                PS_SCOR_ETATBILAN_PCIRCUL(annrecup);
                PS_SCOR_ETATBILAN_PC(annrecup);
                //CompteResultatsChargeAnfi(annrecup, annMoinUn);
                //CompteResultatsProduitsAnfi(annrecup, annMoinUn);
                //BilanActifsAnfi(annrecup, annMoinUn);
                //BilanPassifsAnfi(annrecup, annMoinUn);
                //BilanEcartsAnfi(annrecup, annMoinUn);

            }

        }
        public void CompteResultatsChargeAnfi(string anneD, string AnneCompar)
        {
            sbC = new StringBuilder();
            string VarAnnee = "";
            var liste_annee = service.AnafiAfficheLiasse(7, compar, "", "SN");
            var nombre_annee = service.AnafiAfficheLiasse(8, compar, "", "SN");

            if (liste_annee.Count != 0)
            {
                sbC.AppendLine("<table id='' border = '1' font size='1' class='table table-hover table-bordered text-center'>");
                sbC.AppendLine("<thead class='table-heigth'>");
                sbC.AppendLine(string.Format("<tr bgcolor='#022D65' color='#FFFFFF' align='center'><th>Charges</th>"));
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
                                if (anneD == lr.ANNEE_DETAIL)
                                {
                                    sbC.AppendLine(string.Format("<th onclick='transfertval($(this))' width=15%>{0}</th>", "Exercice  N (" + lr.ANNEE_DETAIL + ")"));
                                }
                                if (AnneCompar == lr.ANNEE_DETAIL.Trim().Substring(3, 4))
                                {
                                    VarAnnee = "Exercice  N - 1";
                                }

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
                            if (anneD == lr.ANNEE_DETAIL)
                            {
                                sbC.AppendLine(string.Format("<th onclick='transfertval($(this))' width=15%>{0}</th>", "Exercice  N (" + lr.ANNEE_DETAIL + ")"));
                            }
                            if (AnneCompar == lr.ANNEE_DETAIL.Trim().Substring(3, 4))
                            {
                                VarAnnee = "Exercice  N - 1";
                            }

                        }
                        i++;
                    }
                }
                if (VarAnnee != "")
                {
                    sbC.AppendLine(string.Format("<th onclick='transfertval($(this))' width=15% background-color='#022D65'>{0}</th>", VarAnnee));
                    //TabLOT[i] = lr.ANNEE_DETAIL;
                }
                sbC.AppendLine("</tr>");
                sbC.AppendLine("</thead>");
                sbC.AppendLine("<tbody>");

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
                            sbC.AppendLine(string.Format("<tr data_code='{0}' bgcolor='#ddd'>", lr.RUBR_ETAT_CODE.ToString().Trim()));


                            if (lr.RUBR_ETAT_LIBELLE.Trim().Length <= 1)
                            {
                                //sbC.AppendLine(string.Format("<td align='left' color='#FFFFFF'></td>"));
                                sbC.AppendLine(string.Format("<td align='left' color='#FFFFFF'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE.ToString()));

                            }
                            else
                            {
                                sbC.AppendLine(string.Format("<td align='left'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE.ToString()));
                                //co2 = "";
                                //coo2 = "";
                                //co2 = lr.RUBR_ETAT_LIBELLE.Trim().ToString().Substring(0, 2);
                                //coo2 = lr.RUBR_ETAT_LIBELLE.Trim().ToString().Substring(3, Convert.ToInt32(lr.RUBR_ETAT_LIBELLE.Trim().Length - 3));
                                //sbC.AppendLine(string.Format("<td align='left'><strong>"+co2+"</strong></td>"));
                                //sbC.AppendLine(string.Format("<td align='left'><strong>" + coo2 + "</strong></td>"));
                                //sbC.AppendLine(string.Format("<td align='left' color='#FFFFFF'><strong>{0}</strong></td>", co2));
                                //sbC.AppendLine(string.Format("<td align='left' color='#FFFFFF'><strong>{0}</strong></td>", coo2));
                            }

                            var liste_valeur = service.AnafiAfficheLiasse(10, compar, lr.RUBR_ETAT_CODE.ToString().Trim(), "SN");

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
                                            sbC.AppendLine(string.Format("<td align='right'></td>"));
                                        }
                                        else
                                        {
                                            if (anneD == l.ANNEE_CR_DETAIL)
                                            {
                                                sbC.AppendLine(string.Format("<td align='right' class='text-right {1}'><strong>{0}</strong></td>", formatMillier(l.VALEUR_CR_DETAIL.ToString()), l.ANNEE_CR_DETAIL.Replace("/", "")));

                                            }
                                            if (AnneCompar == l.ANNEE_CR_DETAIL.Trim().Substring(3, 4))
                                            {
                                                VarAnnee = l.VALEUR_CR_DETAIL.ToString();
                                            }

                                            // sbC.AppendLine(string.Format("<td align='right'><strong>{0}</strong></td>", formatMillier(l.VALEUR_CR_DETAIL.ToString())));
                                        }
                                    }

                                }
                                else
                                {
                                    if (l.RUBR_ETAT_LIBELLE.Trim().Length <= 1)
                                    {
                                        sbC.AppendLine(string.Format("<td align='right'></td>"));
                                    }
                                    else
                                    {
                                        if (anneD == l.ANNEE_CR_DETAIL)
                                        {
                                            sbC.AppendLine(string.Format("<td align='right' class='text-right {1}'><strong>{0}</strong></td>", formatMillier(l.VALEUR_CR_DETAIL.ToString()), l.ANNEE_CR_DETAIL.Replace("/", "")));
                                        }
                                        if (AnneCompar == l.ANNEE_CR_DETAIL.Trim().Substring(3, 4))
                                        {
                                            VarAnnee = l.VALEUR_CR_DETAIL.ToString();
                                        }

                                    }
                                }
                            }
                            if (VarAnnee != "")
                            {
                                sbC.AppendLine(string.Format("<td align='right' class='text-right' width=15%><strong><strong>{0}</strong></strong></td>", Convert.ToString(string.Format(frCult, "{0:#,##0}", Convert.ToDecimal(VarAnnee)))));
                            }

                            sbC.AppendLine("</tr>");
                        }
                        else
                        {
                            sbC.AppendLine(string.Format("<tr data_code='{0}'>", lr.RUBR_ETAT_CODE.ToString().Trim()));

                            sbC.AppendLine(string.Format("<td align='left'>{0}</td>", lr.RUBR_ETAT_LIBELLE.ToString()));
                            //if (!string.IsNullOrEmpty(lr.RUBR_ETAT_LIBELLE))
                            //{
                            //    co1 = new string('');
                            //    coo1 = new string('');
                            //    co1 = lr.RUBR_ETAT_LIBELLE.ToString().Substring(0, 2);
                            //    coo1 = lr.RUBR_ETAT_LIBELLE.ToString().Substring(3, Convert.ToInt32(lr.RUBR_ETAT_LIBELLE.Trim().Length - 3));
                            //    //sbC.AppendLine("<td align='left'><strong>" + co1 + "</strong></td>");
                            //    sbC.AppendLine(string.Format("<td align='left'><strong>{0}</strong></td>", co1));
                            //    sbC.AppendLine(string.Format("<td align='left'><strong>{0}</strong></td>", coo1));
                            //}


                            var liste_valeur = service.AnafiAfficheLiasse(10, compar, lr.RUBR_ETAT_CODE.ToString().Trim(), "SN");
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
                                            sbC.AppendLine(string.Format("<td align='right'></td>"));
                                        }
                                        else
                                        {
                                            if (anneD == l.ANNEE_CR_DETAIL)
                                            {
                                                sbC.AppendLine(string.Format("<td align='right' class='text-right {1}'>{0}</td>", formatMillier(l.VALEUR_CR_DETAIL.ToString()), l.ANNEE_CR_DETAIL.Replace("/", "")));

                                            }
                                            if (AnneCompar == l.ANNEE_CR_DETAIL.Trim().Substring(3, 4))
                                            {
                                                VarAnnee = l.VALEUR_CR_DETAIL.ToString();
                                            }
                                        }
                                    }

                                }
                                else
                                {
                                    if (l.RUBR_ETAT_LIBELLE.Trim().Length <= 1)
                                    {
                                        sbC.AppendLine(string.Format("<td align='right'></td>"));
                                    }
                                    else
                                    {
                                        if (anneD == l.ANNEE_CR_DETAIL)
                                        {
                                            sbC.AppendLine(string.Format("<td align='right' class='text-right {1}'>{0}</td>", formatMillier(l.VALEUR_CR_DETAIL.ToString()), l.ANNEE_CR_DETAIL.Replace("/", "")));

                                        }
                                        if (AnneCompar == l.ANNEE_CR_DETAIL.Trim().Substring(3, 4))
                                        {
                                            VarAnnee = l.VALEUR_CR_DETAIL.ToString();
                                        }
                                    }
                                }
                            }
                            if (VarAnnee != "")
                            {
                                sbC.AppendLine(string.Format("<td align='right' class='text-right' width=15%><strong><strong>{0}</strong></strong></td>", Convert.ToString(string.Format(frCult, "{0:#,##0}", Convert.ToDecimal(VarAnnee)))));
                            }

                            sbC.AppendLine("</tr>");

                        }
                    }

                    if (lr.RUBR_ETAT_CODE.Trim() == "CC")
                    {

                        sbC.AppendLine(string.Format("<tr bgcolor='#EAF2F8'>"));

                        //co = "";
                        // coo = "";
                        // co = lr.RUBR_ETAT_LIBELLE.Trim().ToString().Substring(0, 2);
                        // coo = lr.RUBR_ETAT_LIBELLE.Trim().ToString().Substring(3, Convert.ToInt32(lr.RUBR_ETAT_LIBELLE.Trim().Length - 3));
                        // sbC.AppendLine(string.Format("<td align='left'><strong>{0}</strong></td>", co));
                        // sbC.AppendLine(string.Format("<td align='left'><strong>{0}</strong></td>", coo));
                        sbC.AppendLine(string.Format("<td align='left'>strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE.ToString()));
                        int p = 0;
                        var liste_valeur = service.AnafiAfficheLiasse(10, compar, lr.RUBR_ETAT_CODE.ToString().Trim(), "SN");

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
                                    if (anneD == l.ANNEE_CR_DETAIL)
                                    {
                                        sbC.AppendLine(string.Format("<td  width=15% align='right'><strong>{0}</strong></td>", formatMillier(l.VALEUR_CR_DETAIL.ToString())));
                                        p++;
                                    }
                                    if (AnneCompar == l.ANNEE_CR_DETAIL.Trim().Substring(3, 4))
                                    {
                                        VarAnnee = l.VALEUR_CR_DETAIL.ToString();
                                    }
                                }

                            }
                            else
                            {
                                if (anneD == l.ANNEE_CR_DETAIL)
                                {
                                    sbC.AppendLine(string.Format("<td  width=15% align='right'><strong>{0}</strong></td>", formatMillier(l.VALEUR_CR_DETAIL.ToString())));
                                    p++;
                                }
                                if (AnneCompar == l.ANNEE_CR_DETAIL.Trim().Substring(3, 4))
                                {
                                    VarAnnee = l.VALEUR_CR_DETAIL.ToString();
                                }
                            }
                        }
                        if (VarAnnee != "")
                        {
                            sbC.AppendLine(string.Format("<td align='right' class='text-right' width=15%><strong><strong>{0}</strong></strong></td>", Convert.ToString(string.Format(frCult, "{0:#,##0}", Convert.ToDecimal(VarAnnee)))));
                        }
                        sbC.AppendLine("</tr>");
                    }

                }

                sbC.AppendLine("</tbody>");
                sbC.AppendLine("</table>");
            }
            else
            {
                sbC.AppendLine("<table id='' border = '1' font size='1'  class='table table-hover table-bordered text-center'>");
                sbC.AppendLine("<thead class='table-heigth'>");
                sbC.AppendLine(string.Format("<tr bgcolor='#022D65' color='#FFFFFF' align='center'><th>Charges</th>"));
                sbC.AppendLine(string.Format("<th width=23%></th>"));

                sbC.AppendLine("</thead>");
                sbC.AppendLine("<tbody>");

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
                            sbC.AppendLine(string.Format("<tr data_code='{0}' bgcolor='#ddd' >", lr.RUBR_ETAT_CODE.ToString().Trim()));


                            if (lr.RUBR_ETAT_LIBELLE.Trim().Length <= 1)
                            {
                                sbC.AppendLine(string.Format("<td align='left' color='#FFFFFF'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE.ToString()));
                                sbC.AppendLine(string.Format("<td></td>"));
                            }
                            else
                            {
                                sbC.AppendLine(string.Format("<td align='left'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE.ToString()));
                                sbC.AppendLine(string.Format("<td></td>"));
                            }


                            sbC.AppendLine("</tr>");
                        }
                        else
                        {
                            sbC.AppendLine(string.Format("<tr data_code='{0}'>", lr.RUBR_ETAT_CODE.ToString().Trim()));
                            sbC.AppendLine(string.Format("<td align='left'>{0}</td>", lr.RUBR_ETAT_LIBELLE.ToString()));
                            sbC.AppendLine(string.Format("<td></td>"));
                            sbC.AppendLine("</tr>");

                        }
                    }

                    if (lr.RUBR_ETAT_CODE.Trim() == "CC")
                    {
                        //sbt.AppendLine(string.Format("<table id='{0}' border = '1' font size='1'  class='table-hover table table-bordered text-center'>", lr.RUBR_ETAT_CODE.Trim()));
                        sbC.AppendLine(string.Format("<tr bgcolor='#EAF2F8'>"));
                        sbC.AppendLine(string.Format("<td align='left'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE));
                        sbC.AppendLine(string.Format("<td width='23%'></td>"));
                        sbC.AppendLine("</tr>");

                    }

                }

                sbC.AppendLine("</tbody>");
                sbC.AppendLine("</table>");
            }

        }
        public void CompteResultatsProduitsAnfi(string anneD, string AnneCompar)
        {
            string VarAnnee = "";
            var liste_annee = service.AnafiAfficheLiasse(7, compar, "", "SN");
            var nombre_annee = service.AnafiAfficheLiasse(8, compar, "", "SN");

            //debut produit 
            //si liste des année est superrieur à 0

            if (liste_annee.Count != 0)
            {
                sbB.AppendLine("<table id='' border = '1' font size='1' class='table table-hover table-bordered text-center'>");
                sbB.AppendLine("<thead class='table-heigth'>");
                sbB.AppendLine(string.Format("<tr bgcolor='#022D65' color='#FFFFFF' align='center'><th>Produits</th>"));

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
                                if (anneD == lr.ANNEE_DETAIL)
                                {
                                    sbB.AppendLine(string.Format("<th onclick='transfertval($(this))' width=15% background-color='#022D65'>{0}</th>", "Exercice  N (" + lr.ANNEE_DETAIL + ")"));
                                    //TabLOT[i] = lr.ANNEE_DETAIL;
                                }
                                if (AnneCompar == lr.ANNEE_DETAIL.Trim().Substring(3, 4))
                                {
                                    VarAnnee = "Exercice  N - 1";
                                }

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
                            if (anneD == lr.ANNEE_DETAIL)
                            {
                                sbB.AppendLine(string.Format("<th onclick='transfertval($(this))' width=15% background-color='#022D65'>{0}</th>", "Exercice  N (" + lr.ANNEE_DETAIL + ")"));
                                //TabLOT[i] = lr.ANNEE_DETAIL;
                            }
                            if (AnneCompar == lr.ANNEE_DETAIL.Trim().Substring(3, 4))
                            {
                                VarAnnee = "Exercice  N - 1";
                            }
                        }

                        i++;
                    }
                }
                if (VarAnnee != "")
                {
                    sbB.AppendLine(string.Format("<th onclick='transfertval($(this))' width=15% background-color='#022D65'>{0}</th>", VarAnnee));
                    //TabLOT[i] = lr.ANNEE_DETAIL;
                }
                sbB.AppendLine("</tr>");
                sbB.AppendLine("</thead>");
                sbB.AppendLine("<tbody>");

                var liste_libelle = service.AnafiAfficheLiasse(0, "", "", "CRN");

                //sbv.AppendLine(string.Format("<table id='' class='table-hover table table-bordered text-center matb'>", lr.RUBR_ETAT_CODE.Trim()));
                sbv.AppendLine(string.Format("<table id='' border = '1' font size='1'  class='table-hover table table-bordered text-center matb'>"));
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
                                    sbB.AppendLine(string.Format("<tr data_code='{0}' bgcolor='#EAF2F8'>", lr.RUBR_ETAT_CODE.ToString().Trim()));
                                    sbB.AppendLine(string.Format("<td align='left'>{0}</td>", lr.RUBR_ETAT_LIBELLE.ToString()));

                                    var liste_valeur = service.AnafiAfficheLiasse(10, compar, lr.RUBR_ETAT_CODE.ToString().Trim(), "SN");
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
                                                    sbB.AppendLine(string.Format("<td align='right'></td>"));
                                                }
                                                else
                                                {
                                                    if (anneD == l.ANNEE_CR_DETAIL)
                                                    {
                                                        sbB.AppendLine(string.Format("<td align='right' width=15% class='text-right {1}'>{0}</td>", formatMillier(l.VALEUR_CR_DETAIL.ToString()), l.ANNEE_CR_DETAIL.Replace("/", "")));

                                                        //sbv.AppendLine(string.Format("<td align='right'>{0}</td>", formatMillier(l.VALEUR_CR_DETAIL.ToString())));
                                                    }

                                                    if (AnneCompar == l.ANNEE_CR_DETAIL.Trim().Substring(3, 4))
                                                    {
                                                        VarAnnee = l.VALEUR_CR_DETAIL.ToString();
                                                    }

                                                }
                                            }

                                        }
                                        else
                                        {
                                            if (l.RUBR_ETAT_LIBELLE.Trim().Length <= 1)
                                            {
                                                sbB.AppendLine(string.Format("<td align='right'></td>"));
                                            }
                                            else
                                            {
                                                if (anneD == l.ANNEE_CR_DETAIL)
                                                {
                                                    sbB.AppendLine(string.Format("<td align='right' width=15% class='text-right {1}'>{0}</td>", formatMillier(l.VALEUR_CR_DETAIL.ToString()), l.ANNEE_CR_DETAIL.Replace("/", "")));

                                                    //sbv.AppendLine(string.Format("<td align='right'>{0}</td>", formatMillier(l.VALEUR_CR_DETAIL.ToString())));
                                                }
                                                if (AnneCompar == l.ANNEE_CR_DETAIL.Trim().Substring(3, 4))
                                                {
                                                    VarAnnee = l.VALEUR_CR_DETAIL.ToString();
                                                }

                                            }
                                        }
                                    }

                                    if (VarAnnee != "")
                                    {
                                        sbB.AppendLine(string.Format("<td align='right' class='text-right ' width=15%><strong><strong>{0}</strong></strong></td>", Convert.ToString(string.Format(frCult, "{0:#,##0}", Convert.ToDecimal(VarAnnee)))));

                                    }
                                    sbB.AppendLine("</tr>");
                                }
                                else
                                {
                                    sbB.AppendLine(string.Format("<tr bgcolor='rgba(210, 210, 210, 1);'>"));

                                    if (lr.RUBR_ETAT_LIBELLE.Trim().Length <= 1)
                                    {
                                        sbB.AppendLine(string.Format("<td align='left' color='#FFFFFF'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE.ToString()));
                                    }
                                    else
                                    {
                                        sbB.AppendLine(string.Format("<td align='left'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE.ToString()));
                                    }
                                    var liste_valeur = service.AnafiAfficheLiasse(10, compar, lr.RUBR_ETAT_CODE.ToString().Trim(), "SN");
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
                                                if (anneD == l.ANNEE_CR_DETAIL)
                                                {
                                                    sbB.AppendLine(string.Format("<td width=15%  align='right' class='text-right {1}'><strong>{0}</strong></td>", formatMillier(l.VALEUR_CR_DETAIL.ToString()), l.ANNEE_CR_DETAIL.Replace("/", "")));


                                                }
                                                if (AnneCompar == l.ANNEE_CR_DETAIL.Trim().Substring(3, 4))
                                                {
                                                    VarAnnee = l.VALEUR_CR_DETAIL.ToString();
                                                }
                                            }

                                        }
                                        else
                                        {
                                            if (anneD == l.ANNEE_CR_DETAIL)
                                            {
                                                sbB.AppendLine(string.Format("<td width=15% align='right' v class='text-right {1}'><strong>{0}</strong></td>", formatMillier(l.VALEUR_CR_DETAIL.ToString()), l.ANNEE_CR_DETAIL.Replace("/", "")));

                                            }
                                            if (AnneCompar == l.ANNEE_CR_DETAIL.Trim().Substring(3, 4))
                                            {
                                                VarAnnee = l.VALEUR_CR_DETAIL.ToString();
                                            }
                                            //sbv.AppendLine(string.Format("<td  width=15% align='right'><strong>{0}</strong></td>", formatMillier(l.VALEUR_CR_DETAIL.ToString())));
                                        }
                                    }
                                    if (VarAnnee != "")
                                    {
                                        sbB.AppendLine(string.Format("<td align='right' class='text-right' width=15%><strong><strong>{0}</strong></strong></td>", Convert.ToString(string.Format(frCult, "{0:#,##0}", Convert.ToDecimal(VarAnnee)))));

                                    }
                                    sbB.AppendLine("</tr>");
                                }

                            }
                            else
                            {

                                sbB.AppendLine(string.Format("<tr data_code='{0}' bgcolor='#ddd' >", lr.RUBR_ETAT_CODE.ToString().Trim()));

                                if (lr.RUBR_ETAT_LIBELLE.Trim().Length <= 1)
                                {
                                    sbB.AppendLine(string.Format("<td align='left' color='#FFFFFF'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE.ToString()));
                                }
                                else
                                {
                                    sbB.AppendLine(string.Format("<td align='left'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE.ToString()));
                                }
                                var liste_valeur = service.AnafiAfficheLiasse(10, compar, lr.RUBR_ETAT_CODE.ToString().Trim(), "SN");
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
                                            if (anneD == l.ANNEE_CR_DETAIL)
                                            {
                                                sbB.AppendLine(string.Format("<td width=15% align='right' class='text-right {1}'><strong>{0}</strong></td>", formatMillier(l.VALEUR_CR_DETAIL.ToString()), l.ANNEE_CR_DETAIL.Replace("/", "")));

                                            }
                                            if (AnneCompar == l.ANNEE_CR_DETAIL.Trim().Substring(3, 4))
                                            {
                                                VarAnnee = l.VALEUR_CR_DETAIL.ToString();
                                            }
                                            //sbB.AppendLine(string.Format("<td align='right'><strong>{0}</strong></td>", formatMillier(l.VALEUR_CR_DETAIL.ToString())));
                                        }

                                    }
                                    else
                                    {
                                        if (anneD == l.ANNEE_CR_DETAIL)
                                        {
                                            sbB.AppendLine(string.Format("<td width=15% align='right' class='text-right {1}'><strong>{0}</strong></td>", formatMillier(l.VALEUR_CR_DETAIL.ToString()), l.ANNEE_CR_DETAIL.Replace("/", "")));

                                        }
                                        if (AnneCompar == l.ANNEE_CR_DETAIL.Trim().Substring(3, 4))
                                        {
                                            VarAnnee = l.VALEUR_CR_DETAIL.ToString();
                                        }
                                        // sbB.AppendLine(string.Format("<td align='right'><strong>{0}</strong></td>", formatMillier(l.VALEUR_CR_DETAIL.ToString())));
                                    }
                                }
                                if (VarAnnee != "")
                                {
                                    sbB.AppendLine(string.Format("<td align='right' class='text-right' width=15%><strong><strong>{0}</strong></strong></td>", Convert.ToString(string.Format(frCult, "{0:#,##0}", Convert.ToDecimal(VarAnnee)))));

                                }
                                sbB.AppendLine("</tr>");
                            }
                        }
                        else
                        {
                            if (lr.RUBR_ETAT_CODE.ToString().Trim() != "CP6C")
                            {
                                sbB.AppendLine(string.Format("<tr data_code='{0}'>", lr.RUBR_ETAT_CODE.ToString().Trim()));
                                sbB.AppendLine(string.Format("<td align='left'>{0}</td>", lr.RUBR_ETAT_LIBELLE.ToString()));

                                var liste_valeur = service.AnafiAfficheLiasse(10, compar, lr.RUBR_ETAT_CODE.ToString().Trim(), "SN");
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
                                                sbB.AppendLine(string.Format("<td align='right'></td>"));
                                            }
                                            else
                                            {
                                                if (anneD == l.ANNEE_CR_DETAIL)
                                                {
                                                    sbB.AppendLine(string.Format("<td align='right' width=15% class='text-right {1}'>{0}</td>", formatMillier(l.VALEUR_CR_DETAIL.ToString()), l.ANNEE_CR_DETAIL.Replace("/", "")));

                                                }
                                                if (AnneCompar == l.ANNEE_CR_DETAIL.Trim().Substring(3, 4))
                                                {
                                                    VarAnnee = l.VALEUR_CR_DETAIL.ToString();
                                                }
                                                // sbB.AppendLine(string.Format("<td align='right'>{0}</td>", formatMillier(l.VALEUR_CR_DETAIL.ToString())));
                                            }
                                        }

                                    }
                                    else
                                    {
                                        if (l.RUBR_ETAT_LIBELLE.Trim().Length <= 1)
                                        {
                                            sbB.AppendLine(string.Format("<td align='right'></td>"));
                                        }
                                        else
                                        {
                                            if (anneD == l.ANNEE_CR_DETAIL)
                                            {
                                                sbB.AppendLine(string.Format("<td align='right' width=15% class='text-right {1}'>{0}</td>", formatMillier(l.VALEUR_CR_DETAIL.ToString()), l.ANNEE_CR_DETAIL.Replace("/", "")));

                                            }
                                            if (AnneCompar == l.ANNEE_CR_DETAIL.Trim().Substring(3, 4))
                                            {
                                                VarAnnee = l.VALEUR_CR_DETAIL.ToString();
                                            }
                                            //sbB.AppendLine(string.Format("<td align='right'>{0}</td>", formatMillier(l.VALEUR_CR_DETAIL.ToString())));
                                        }
                                    }
                                }
                                if (VarAnnee != "")
                                {
                                    sbB.AppendLine(string.Format("<td align='right' class='text-right' width=15%><strong><strong>{0}</strong></strong></td>", Convert.ToString(string.Format(frCult, "{0:#,##0}", Convert.ToDecimal(VarAnnee)))));

                                }
                                sbB.AppendLine("</tr>");
                            }

                        }
                    }

                    if (lr.RUBR_ETAT_CODE.Trim() == "CP")
                    {
                        sbB.AppendLine(string.Format("<tr bgcolor='rgba(210, 210, 210, 1);'>"));

                        sbB.AppendLine(string.Format("<td align='left'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE));
                        // TabLOTP = new string[Convert.ToInt32(liste_annee.Count)];
                        int p = 0;
                        var liste_valeur = service.AnafiAfficheLiasse(10, compar, lr.RUBR_ETAT_CODE.ToString().Trim(), "SN");
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
                                    if (anneD == l.ANNEE_CR_DETAIL)
                                    {
                                        sbB.AppendLine(string.Format("<td width=15% align='right'>{0}</td>", formatMillier(l.VALEUR_CR_DETAIL.ToString())));
                                        // TabLOTP[p] = l.VALEUR_B_DETAIL.ToString();
                                        p++;
                                    }
                                    if (AnneCompar == l.ANNEE_CR_DETAIL.Trim().Substring(3, 4))
                                    {
                                        VarAnnee = l.VALEUR_CR_DETAIL.ToString();
                                    }
                                }

                            }
                            else
                            {
                                if (anneD == l.ANNEE_CR_DETAIL)
                                {
                                    sbB.AppendLine(string.Format("<td width=15% align='right'>{0}</td>", formatMillier(l.VALEUR_CR_DETAIL.ToString())));
                                    // TabLOTP[p] = l.VALEUR_B_DETAIL.ToString();
                                    p++;
                                }
                                if (AnneCompar == l.ANNEE_CR_DETAIL.Trim().Substring(3, 4))
                                {
                                    VarAnnee = l.VALEUR_CR_DETAIL.ToString();
                                }
                            }
                        }

                        if (VarAnnee != "")
                        {
                            sbB.AppendLine(string.Format("<td align='right' class='text-right' width=15%><strong><strong>{0}</strong></strong></td>", Convert.ToString(string.Format(frCult, "{0:#,##0}", Convert.ToDecimal(VarAnnee)))));

                        }
                        sbB.AppendLine("</tr>");

                    }
                }

                sbB.AppendLine("</tbody>");
                sbB.AppendLine("</table>");

                sbv.AppendLine("</table>");
                //divProduit.InnerHtml = sbv.ToString();

            }
            else
            {
                sbB.AppendLine("<table id='' border = '1' font size='1'  class='table table-hover table-bordered text-center'>");
                sbB.AppendLine("<thead class='table-heigth'>");
                sbB.AppendLine(string.Format("<tr bgcolor='#022D65' color='#FFFFFF' align='center'><th>Produits</th>"));
                sbB.AppendLine(string.Format("<th width=23%></th>"));

                sbB.AppendLine("</thead>");
                sbB.AppendLine("<tbody>");

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
                                    sbB.AppendLine(string.Format("<tr data_code='{0}' bgcolor='#EAF2F8'>", lr.RUBR_ETAT_CODE.ToString().Trim()));
                                    sbB.AppendLine(string.Format("<td align='left'>{0}</td>", lr.RUBR_ETAT_LIBELLE.ToString()));
                                    sbB.AppendLine(string.Format("<td width='15%' ></td>"));
                                    sbB.AppendLine("</tr>");
                                }
                                else
                                {
                                    //sbv.AppendLine(string.Format("<tr  width=15% style='background-color:rgba(210, 210, 210, 1);'>"));

                                    //sbv.AppendLine(string.Format("<tr data_code='{0}' style='background-color:#ddd'>", lr.RUBR_ETAT_CODE.ToString().Trim()));
                                    sbv.AppendLine(string.Format("<tr data_code='{0}' bgcolor='rgba(210, 210, 210, 1);'>", lr.RUBR_ETAT_CODE.ToString().Trim()));

                                    if (lr.RUBR_ETAT_LIBELLE.Trim().Length <= 1)
                                    {
                                        sbv.AppendLine(string.Format("<td align='left' ><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE.ToString()));
                                        sbv.AppendLine(string.Format("<td width='23%'></td>"));
                                    }
                                    else
                                    {
                                        sbv.AppendLine(string.Format("<td align='left'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE.ToString()));
                                        sbv.AppendLine(string.Format("<td width='23%'></td>"));
                                    }
                                    sbv.AppendLine("</tr>");
                                }



                            }
                            else
                            {

                                sbB.AppendLine(string.Format("<tr data_code='{0}' bgcolor='#ddd'>", lr.RUBR_ETAT_CODE.ToString().Trim()));

                                if (lr.RUBR_ETAT_LIBELLE.Trim().Length <= 1)
                                {
                                    sbB.AppendLine(string.Format("<td align='left'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE.ToString()));
                                    sbB.AppendLine(string.Format("<td></td>"));
                                }
                                else
                                {
                                    sbB.AppendLine(string.Format("<td align='left'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE.ToString()));
                                    sbB.AppendLine(string.Format("<td></td>"));
                                }

                                sbB.AppendLine("</tr>");
                            }


                        }
                        else
                        {
                            if (lr.RUBR_ETAT_CODE.ToString().Trim() != "CP6C")
                            {
                                sbB.AppendLine(string.Format("<tr data_code='{0}'>", lr.RUBR_ETAT_CODE.ToString().Trim()));
                                sbB.AppendLine(string.Format("<td align='left'>{0}</td>", lr.RUBR_ETAT_LIBELLE.ToString()));
                                sbB.AppendLine(string.Format("<td></td>"));

                                sbB.AppendLine("</tr>");
                            }

                        }
                    }


                    if (lr.RUBR_ETAT_CODE.Trim() == "CP")
                    {
                        sbB.AppendLine(string.Format("<tr bgcolor='rgba(210, 210, 210, 1);'>"));

                        sbB.AppendLine(string.Format("<td align='left'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE));
                        sbB.AppendLine(string.Format("<td></td>"));
                    }
                }

                sbB.AppendLine("</tbody>");
                sbB.AppendLine("</table>");


                sbv.AppendLine("</table>");
            }


        }
        public void BilanActifsAnfi(string anneD, string AnneCompar)
        {

            var liste_annee = service.AnafiAfficheLiasse(7, compar, "", "SN");
            var nombre_annee = service.AnafiAfficheLiasse(8, compar, "", "SN");
            string VarAnnee = "";
            strHTML = sb2.ToString();
            sbt.AppendLine(string.Format("<table id='BA' font size='1'class='table-hover table table-bordered text-center'>"));
            sbt.AppendLine("<tbody>");
            if (liste_annee.Count != 0)
            {

                sb.AppendLine("<table id='' border = '1' font size='1' class='table table-hover table-bordered text-center'>");
                sb.AppendLine("<thead class='table-heigth'    border-radius='3px' border='2px solid #022D65' margin-left='5px'>");
                sb.AppendLine(string.Format("<tr bgcolor='#022D65' color='#FFFFFF' align='center'><th>Actifs</th>"));
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
                                if (anneD == lr.ANNEE_DETAIL)
                                {
                                    sb.AppendLine(string.Format("<th onclick='transfertval($(this))' width=15% background-color='#022D65'>{0}</th>", "Exercice  N (" + lr.ANNEE_DETAIL + ")"));
                                    //TabLOT[i] = lr.ANNEE_DETAIL;
                                }

                                if (AnneCompar == lr.ANNEE_DETAIL.Trim().Substring(3, 4))
                                {
                                    //VarAnnee=lr.ANNEE_DETAIL;
                                    VarAnnee = "Exercice  N - 1";
                                }


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
                            if (anneD == lr.ANNEE_DETAIL)
                            {
                                sb.AppendLine(string.Format("<th onclick='transfertval($(this))' width=15% background-color='#022D65'>{0}</th>", "Exercice  N (" + lr.ANNEE_DETAIL + ")"));
                                //TabLOT[i] = lr.ANNEE_DETAIL;
                            }

                            if (AnneCompar == lr.ANNEE_DETAIL.Trim().Substring(3, 4))
                            {
                                VarAnnee = "Exercice  N - 1";
                            }

                        }
                        i++;
                    }
                }
                if (VarAnnee != "")
                {
                    sb.AppendLine(string.Format("<th onclick='transfertval($(this))' width=15% background-color='#022D65'>{0}</th>", VarAnnee));
                    //TabLOT[i] = lr.ANNEE_DETAIL;
                }


                sb.AppendLine("</thead>");
                sb.AppendLine("<tbody>");

                var liste_libelle = service.AnafiAfficheLiasse(0, "", "", "BIN");



                foreach (var lr in liste_libelle)
                {
                    if (lr.RUBR_ETAT_CODE.ToString().Trim() == "BAX12" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BA12A" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BA13A"
                        || lr.RUBR_ETAT_CODE.ToString().Trim() == "BA15A" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BAX53" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BAX54" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BA1A"
                        || lr.RUBR_ETAT_CODE.ToString().Trim() == "BA22A" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BA2X9" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BA2A" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BA3A"
                        || lr.RUBR_ETAT_CODE.ToString().Trim() == "BA4A" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BAX11" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BA11B" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BAX13"
                        || lr.RUBR_ETAT_CODE.ToString().Trim() == "BA21A" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BA2X4" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BA14A")
                    {
                    }
                    else
                    {
                        if (lr.RUBR_ETAT_CODE.ToString().Trim() == "BAX21" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BAX22" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BAX23"
                        || lr.RUBR_ETAT_CODE.ToString().Trim() == "BAX24" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BAX31" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BAX32" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BAX35"
                        || lr.RUBR_ETAT_CODE.ToString().Trim() == "BA22A" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BAX51" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BAX52" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BA2X2"
                        || lr.RUBR_ETAT_CODE.ToString().Trim() == "BA2X3" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BA2X8" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BA2X6" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BA2X7"
                        || lr.RUBR_ETAT_CODE.ToString().Trim() == "BA3X1" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BA32A" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BA33A"
                         || lr.RUBR_ETAT_CODE.ToString().Trim() == "BA2X5" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BAX34" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BAX33" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BXA")
                        {
                            if (lr.RUBR_ETAT_CODE.ToString().Trim() == "BXA")
                            {

                                sbt.AppendLine(string.Format("<tr bgcolor='rgba(210, 210, 210, 1);'>"));

                                sbt.AppendLine(string.Format("<td align='left'><strong>&nbsp;&nbsp;&nbsp;<i class=\"glyphicon glyphicon-share-alt gly-flip-vertical \"></i><i style=\"color:#69a8f4\">{0}</i></strong></td>", lr.RUBR_ETAT_LIBELLE));
                                // TabLOTA = new string[Convert.ToInt32(liste_annee.Count)];
                                int p = 0;
                                var liste_valeur3 = service.AnafiAfficheLiasse(9, compar, lr.RUBR_ETAT_CODE.ToString().Trim(), "SN");

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
                                            if (anneD == l.ANNEE_B_DETAIL.ToString())
                                            {
                                                sbt.AppendLine(string.Format("<td align='right' width=15%><i style=\"color:#69a8f4\">{0}</i></td>", formatMillier(l.VALEUR_B_DETAIL.ToString())));
                                                // TabLOTA[p] = l.VALEUR_B_DETAIL.ToString();
                                                p++;
                                            }
                                            if (AnneCompar == l.ANNEE_B_DETAIL.Trim().Substring(3, 4))
                                            {
                                                VarAnnee = l.VALEUR_B_DETAIL.ToString();
                                            }

                                        }

                                    }
                                    else
                                    {
                                        if (anneD == l.ANNEE_B_DETAIL.ToString())
                                        {
                                            sbt.AppendLine(string.Format("<td align='right' width=15%><i style=\"color:#69a8f4\">{0}</i></td>", formatMillier(l.VALEUR_B_DETAIL.ToString())));
                                            // TabLOTA[p] = l.VALEUR_B_DETAIL.ToString();
                                            p++;
                                        }

                                        if (AnneCompar == l.ANNEE_B_DETAIL.Trim().Substring(3, 4))
                                        {
                                            VarAnnee = l.VALEUR_B_DETAIL.ToString();
                                        }

                                    }
                                }
                                if (VarAnnee != "")
                                {
                                    sbt.AppendLine(string.Format("<td align='right' width=15%><i style=\"color:#69a8f4\">{0}</i></td>", Convert.ToString(string.Format(frCult, "{0:#,##0}", Convert.ToDecimal(VarAnnee)))));
                                    // TabLOTA[p] = l.VALEUR_B_DETAIL.ToString();
                                }

                                sbt.AppendLine("</tr>");
                                //sbt.AppendLine("</table>");
                                //DIVtotauxActif.InnerHtml = sbt.ToString();
                            }
                            else
                            {
                                sb.AppendLine(string.Format("<tr data_code='{0}'>", lr.RUBR_ETAT_CODE.ToString().Trim()));
                                // sb.AppendLine(string.Format("<td align='left'>{0}</td>", lr.CODE_POSTE.ToString()));
                                sb.AppendLine(string.Format("<td align='left'>&nbsp;&nbsp;&nbsp;<i class=\"glyphicon glyphicon-share-alt gly-flip-vertical \"></i><i style=\"color:#69a8f4\">{0}</i></td>", lr.RUBR_ETAT_LIBELLE.ToString()));

                                var liste_valeur2 = service.AnafiAfficheLiasse(9, compar, lr.RUBR_ETAT_CODE.ToString().Trim(), "SN");

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
                                                sb.AppendLine(string.Format("<td align='right'></td>"));
                                            }
                                            else
                                            {
                                                if (anneD == l.ANNEE_B_DETAIL.ToString())
                                                {
                                                    sb.AppendLine(string.Format("<td align='right' class='text-right {1}'><i  color='#69a8f4' >{0}</i></td>", formatMillier(l.VALEUR_B_DETAIL.ToString()), l.ANNEE_B_DETAIL.Replace("/", "")));

                                                }
                                                if (AnneCompar == l.ANNEE_B_DETAIL.Trim().Substring(3, 4))
                                                {
                                                    VarAnnee = l.VALEUR_B_DETAIL.ToString();
                                                }
                                            }
                                        }

                                    }
                                    else
                                    {
                                        if (l.RUBR_ETAT_LIBELLE.Trim().Length <= 1)
                                        {
                                            sb.AppendLine(string.Format("<td align='right'></td>"));
                                        }
                                        else
                                        {
                                            if (anneD == l.ANNEE_B_DETAIL.ToString())
                                            {
                                                sb.AppendLine(string.Format("<td align='right' class='text-right {1}'><i style=\"color:#69a8f4\">{0}</i></td>", formatMillier(l.VALEUR_B_DETAIL.ToString()), l.ANNEE_B_DETAIL.Replace("/", "")));

                                            }
                                            if (AnneCompar == l.ANNEE_B_DETAIL.Trim().Substring(3, 4))
                                            {
                                                VarAnnee = l.VALEUR_B_DETAIL.ToString();
                                            }
                                        }
                                    }
                                }
                                if (VarAnnee != "")
                                {
                                    sb.AppendLine(string.Format("<td align='right' class='text-right'><i style=\"color:#69a8f4\">{0}</i></td>", Convert.ToString(string.Format(frCult, "{0:#,##0}", Convert.ToDecimal(VarAnnee)))));

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
                                        // sb.AppendLine(string.Format("<td align='left'>{0}</td>", lr.CODE_POSTE.ToString()));
                                        sb.AppendLine(string.Format("<td align='left'>{0}</td>", lr.RUBR_ETAT_LIBELLE.ToString()));

                                        var liste_valeur2 = service.AnafiAfficheLiasse(9, compar, lr.RUBR_ETAT_CODE.ToString().Trim(), "SN");

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
                                                        sb.AppendLine(string.Format("<td align='right'></td>"));
                                                    }
                                                    else
                                                    {
                                                        if (anneD == l.ANNEE_B_DETAIL.ToString())
                                                        {
                                                            sb.AppendLine(string.Format("<td align='right' class='text-right {1}'>{0}</td>", formatMillier(l.VALEUR_B_DETAIL.ToString()), l.ANNEE_B_DETAIL.Replace("/", "")));
                                                        }
                                                        if (AnneCompar == l.ANNEE_B_DETAIL.Trim().Substring(3, 4))
                                                        {
                                                            VarAnnee = l.VALEUR_B_DETAIL.ToString();
                                                        }
                                                    }
                                                }

                                            }
                                            else
                                            {
                                                if (l.RUBR_ETAT_LIBELLE.Trim().Length <= 1)
                                                {
                                                    sb.AppendLine(string.Format("<td align='right'></td>"));
                                                }
                                                else
                                                {
                                                    if (anneD == l.ANNEE_B_DETAIL.ToString())
                                                    {
                                                        sb.AppendLine(string.Format("<td align='right' class='text-right {1}'>{0}</td>", formatMillier(l.VALEUR_B_DETAIL.ToString()), l.ANNEE_B_DETAIL.Replace("/", "")));
                                                    }
                                                    if (AnneCompar == l.ANNEE_B_DETAIL.Trim().Substring(3, 4))
                                                    {
                                                        VarAnnee = l.VALEUR_B_DETAIL.ToString();
                                                    }
                                                }
                                            }
                                        }
                                        if (VarAnnee != "")
                                        {
                                            sb.AppendLine(string.Format("<td align='right' class='text-right'>{0}</td>", Convert.ToString(string.Format(frCult, "{0:#,##0}", Convert.ToDecimal(VarAnnee)))));

                                        }

                                        sb.AppendLine("</tr>");
                                    }
                                    else
                                    {

                                        sb.AppendLine(string.Format("<tr data_code='{0}' bgcolor='#ddd'>", lr.RUBR_ETAT_CODE.ToString().Trim()));
                                        // sb.AppendLine(string.Format("<td align='left'>{0}</td>", lr.CODE_POSTE.ToString()));


                                        if (lr.RUBR_ETAT_LIBELLE.Trim().Length <= 1)
                                        {
                                            sb.AppendLine(string.Format("<td align='left'color='#FFFFFF'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE.ToString()));
                                        }
                                        else
                                        {
                                            sb.AppendLine(string.Format("<td align='left'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE.ToString()));
                                        }
                                        var liste_valeur1 = service.AnafiAfficheLiasse(9, compar, lr.RUBR_ETAT_CODE.ToString().Trim(), "SN");
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
                                                        sb.AppendLine(string.Format("<td align='right'></td>"));
                                                    }
                                                    else
                                                    {
                                                        if (anneD == l.ANNEE_B_DETAIL.ToString())
                                                        {
                                                            sb.AppendLine(string.Format("<td align='right' class='text-right {1}'><strong>{0}</strong></td>", formatMillier(l.VALEUR_B_DETAIL.ToString()), l.ANNEE_B_DETAIL.Replace("/", "")));
                                                        }

                                                        if (AnneCompar == l.ANNEE_B_DETAIL.Trim().Substring(3, 4))
                                                        {
                                                            VarAnnee = l.VALEUR_B_DETAIL.ToString();
                                                        }
                                                    }
                                                }

                                            }
                                            else
                                            {
                                                if (l.RUBR_ETAT_LIBELLE.Trim().Length <= 1)
                                                {
                                                    sb.AppendLine(string.Format("<td align='right'></td>"));
                                                }
                                                else
                                                {
                                                    if (anneD == l.ANNEE_B_DETAIL.ToString())
                                                    {
                                                        sb.AppendLine(string.Format("<td align='right' class='text-right {1}'><strong>{0}</strong></td>", formatMillier(l.VALEUR_B_DETAIL.ToString()), l.ANNEE_B_DETAIL.Replace("/", "")));
                                                    }
                                                    if (AnneCompar == l.ANNEE_B_DETAIL.Trim().Substring(3, 4))
                                                    {
                                                        VarAnnee = l.VALEUR_B_DETAIL.ToString();
                                                    }
                                                }
                                            }

                                        }
                                        if (VarAnnee != "")
                                        {
                                            sb.AppendLine(string.Format("<td align='right' class='text-right '><strong>{0}</strong></td>", Convert.ToString(string.Format(frCult, "{0:#,##0}", Convert.ToDecimal(VarAnnee)))));

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
                                            // sb.AppendLine(string.Format("<td align='left'>{0}</td>", lr.CODE_POSTE.ToString()));
                                            sb.AppendLine(string.Format("<td align='left'>{0}</td>", lr.RUBR_ETAT_LIBELLE.ToString()));

                                            var liste_valeur2 = service.AnafiAfficheLiasse(9, compar, lr.RUBR_ETAT_CODE.ToString().Trim(), "SN");

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
                                                            sb.AppendLine(string.Format("<td align='right'></td>"));
                                                        }
                                                        else
                                                        {
                                                            if (anneD == l.ANNEE_B_DETAIL.ToString())
                                                            {
                                                                sb.AppendLine(string.Format("<td align='right' class='text-right {1}'>{0}</td>", formatMillier(l.VALEUR_B_DETAIL.ToString()), l.ANNEE_B_DETAIL.Replace("/", "")));
                                                            }
                                                            if (AnneCompar == l.ANNEE_B_DETAIL.Trim().Substring(3, 4))
                                                            {
                                                                VarAnnee = l.VALEUR_B_DETAIL.ToString();
                                                            }
                                                        }
                                                    }

                                                }
                                                else
                                                {
                                                    if (l.RUBR_ETAT_LIBELLE.Trim().Length <= 1)
                                                    {
                                                        sb.AppendLine(string.Format("<td align='right'></td>"));
                                                    }
                                                    else
                                                    {
                                                        if (anneD == l.ANNEE_B_DETAIL.ToString())
                                                        {
                                                            sb.AppendLine(string.Format("<td align='right' class='text-right {1}'>{0}</td>", formatMillier(l.VALEUR_B_DETAIL.ToString()), l.ANNEE_B_DETAIL.Replace("/", "")));
                                                        }
                                                        if (AnneCompar == l.ANNEE_B_DETAIL.Trim().Substring(3, 4))
                                                        {
                                                            VarAnnee = l.VALEUR_B_DETAIL.ToString();
                                                        }
                                                    }
                                                }
                                            }
                                            if (VarAnnee != "")
                                            {
                                                sb.AppendLine(string.Format("<td align='right' class='text-right'>{0}</td>", Convert.ToString(string.Format(frCult, "{0:#,##0}", Convert.ToDecimal(VarAnnee)))));

                                            }
                                            sb.AppendLine("</tr>");
                                        }
                                        else
                                        {
                                            sb.AppendLine(string.Format("<tr data_code='{0}'>", lr.RUBR_ETAT_CODE.ToString().Trim()));
                                            // sb.AppendLine(string.Format("<td align='left'>{0}</td>", lr.CODE_POSTE.ToString()));
                                            sb.AppendLine(string.Format("<td align='left'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE.ToString()));

                                            var liste_valeur2 = service.AnafiAfficheLiasse(9, compar, lr.RUBR_ETAT_CODE.ToString().Trim(), "SN");

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
                                                            sb.AppendLine(string.Format("<td align='right'></td>"));
                                                        }
                                                        else
                                                        {
                                                            if (anneD == l.ANNEE_B_DETAIL.ToString())
                                                            {
                                                                sb.AppendLine(string.Format("<td align='right' class='text-right {1}'><strong>{0}</strong></td>", formatMillier(l.VALEUR_B_DETAIL.ToString()), l.ANNEE_B_DETAIL.Replace("/", "")));
                                                            }
                                                            if (AnneCompar == l.ANNEE_B_DETAIL.Trim().Substring(3, 4))
                                                            {
                                                                VarAnnee = l.VALEUR_B_DETAIL.ToString();
                                                            }
                                                        }
                                                    }

                                                }
                                                else
                                                {
                                                    if (l.RUBR_ETAT_LIBELLE.Trim().Length <= 1)
                                                    {
                                                        sb.AppendLine(string.Format("<td align='right'></td>"));
                                                    }
                                                    else
                                                    {
                                                        if (anneD == l.ANNEE_B_DETAIL.ToString())
                                                        {
                                                            sb.AppendLine(string.Format("<td align='right' class='text-right {1}'><strong>{0}</strong></td>", formatMillier(l.VALEUR_B_DETAIL.ToString()), l.ANNEE_B_DETAIL.Replace("/", "")));
                                                        }
                                                        if (AnneCompar == l.ANNEE_B_DETAIL.Trim().Substring(3, 4))
                                                        {
                                                            VarAnnee = l.VALEUR_B_DETAIL.ToString();
                                                        }
                                                    }
                                                }
                                            }

                                            if (VarAnnee != "")
                                            {
                                                sb.AppendLine(string.Format("<td align='right' class='text-right'><strong>{0}</strong></td>", Convert.ToString(string.Format(frCult, "{0:#,##0}", Convert.ToDecimal(VarAnnee)))));

                                            }

                                            sb.AppendLine("</tr>");
                                        }

                                    }
                                    else
                                    {
                                        sb.AppendLine(string.Format("<tr data_code='{0}'>", lr.RUBR_ETAT_CODE.ToString().Trim()));
                                        // sb.AppendLine(string.Format("<td align='left'>{0}</td>", lr.CODE_POSTE.ToString()));
                                        sb.AppendLine(string.Format("<td align='left'>{0}</td>", lr.RUBR_ETAT_LIBELLE.ToString()));

                                        var liste_valeur2 = service.AnafiAfficheLiasse(9, compar, lr.RUBR_ETAT_CODE.ToString().Trim(), "SN");

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
                                                        sb.AppendLine(string.Format("<td align='right'></td>"));
                                                    }
                                                    else
                                                    {
                                                        if (anneD == l.ANNEE_B_DETAIL.ToString())
                                                        {
                                                            sb.AppendLine(string.Format("<td align='right' class='text-right {1}'>{0}</td>", formatMillier(l.VALEUR_B_DETAIL.ToString()), l.ANNEE_B_DETAIL.Replace("/", "")));
                                                        }
                                                        if (AnneCompar == l.ANNEE_B_DETAIL.Trim().Substring(3, 4))
                                                        {
                                                            VarAnnee = l.VALEUR_B_DETAIL.ToString();
                                                        }
                                                    }
                                                }

                                            }
                                            else
                                            {
                                                if (l.RUBR_ETAT_LIBELLE.Trim().Length <= 1)
                                                {
                                                    sb.AppendLine(string.Format("<td align='right'></td>"));
                                                }
                                                else
                                                {
                                                    if (anneD == l.ANNEE_B_DETAIL.ToString())
                                                    {
                                                        sb.AppendLine(string.Format("<td align='right' class='text-right {1}'>{0}</td>", formatMillier(l.VALEUR_B_DETAIL.ToString()), l.ANNEE_B_DETAIL.Replace("/", "")));
                                                    }
                                                    if (AnneCompar == l.ANNEE_B_DETAIL.Trim().Substring(3, 4))
                                                    {
                                                        VarAnnee = l.VALEUR_B_DETAIL.ToString();
                                                    }
                                                }
                                            }
                                        }
                                        if (VarAnnee != "")
                                        {
                                            sb.AppendLine(string.Format("<td align='right' class='text-right'>{0}</td>", Convert.ToString(string.Format(frCult, "{0:#,##0}", Convert.ToDecimal(VarAnnee)))));

                                        }
                                        sb.AppendLine("</tr>");
                                    }


                                }
                            }

                            if (lr.RUBR_ETAT_CODE.Trim() == "BA")
                            {
                                //string[]  // TabLOTP = null;

                                //sbt.AppendLine(string.Format("<table id='{0}' class='table-hover table table-bordered text-center'>", lr.RUBR_ETAT_CODE.Trim()));
                                sbt.AppendLine(string.Format("<tr bgcolor='#EAF2F8'>"));

                                sbt.AppendLine(string.Format("<td align='left'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE));
                                // TabLOTA = new string[Convert.ToInt32(liste_annee.Count)];
                                int p = 0;
                                var liste_valeur3 = service.AnafiAfficheLiasse(9, compar, lr.RUBR_ETAT_CODE.ToString().Trim(), "SN");

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
                                            if (anneD == l.ANNEE_B_DETAIL.ToString())
                                            {
                                                sbt.AppendLine(string.Format("<td align='right' width=15%>{0}</td>", formatMillier(l.VALEUR_B_DETAIL.ToString())));
                                                // TabLOTA[p] = l.VALEUR_B_DETAIL.ToString();
                                                p++;
                                            }

                                            if (AnneCompar == l.ANNEE_B_DETAIL.Trim().Substring(3, 4))
                                            {
                                                VarAnnee = l.VALEUR_B_DETAIL.ToString();
                                            }

                                        }

                                    }
                                    else
                                    {
                                        if (anneD == l.ANNEE_B_DETAIL.ToString())
                                        {
                                            sbt.AppendLine(string.Format("<td align='right' width=15%>{0}</td>", formatMillier(l.VALEUR_B_DETAIL.ToString())));
                                            // TabLOTA[p] = l.VALEUR_B_DETAIL.ToString();
                                            p++;
                                        }
                                        if (AnneCompar == l.ANNEE_B_DETAIL.Trim().Substring(3, 4))
                                        {
                                            VarAnnee = l.VALEUR_B_DETAIL.ToString();
                                        }
                                    }
                                }
                                if (VarAnnee != "")
                                {
                                    sbt.AppendLine(string.Format("<td align='right' width=15%>{0}</td>", Convert.ToString(string.Format(frCult, "{0:#,##0}", Convert.ToDecimal(VarAnnee)))));
                                    // TabLOTA[p] = l.VALEUR_B_DETAIL.ToString();
                                }
                                sbt.AppendLine("</tr>");

                                sb.AppendLine(string.Format("<tr bgcolor='#EAF2F8'>"));

                                sb.AppendLine(string.Format("<td align='left'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE));
                                // TabLOTA = new string[Convert.ToInt32(liste_annee.Count)];
                                //int p = 0;
                                var liste_valeur4 = service.AnafiAfficheLiasse(9, compar, lr.RUBR_ETAT_CODE.ToString().Trim(), "SN");

                                int t = 0;
                                int u = 0;
                                u = Convert.ToInt32(liste_valeur4.Count) - 3;
                                foreach (var l in liste_valeur4)
                                {

                                    if (liste_valeur4.Count > 3)
                                    {
                                        t++;
                                        if (u < t)
                                        {
                                            if (anneD == l.ANNEE_B_DETAIL.ToString())
                                            {
                                                sb.AppendLine(string.Format("<td align='right' width=15%>{0}</td>", formatMillier(l.VALEUR_B_DETAIL.ToString())));
                                                // TabLOTA[p] = l.VALEUR_B_DETAIL.ToString();
                                                //p++;
                                            }

                                            if (AnneCompar == l.ANNEE_B_DETAIL.Trim().Substring(3, 4))
                                            {
                                                VarAnnee = l.VALEUR_B_DETAIL.ToString();
                                            }

                                        }

                                    }
                                    else
                                    {
                                        if (anneD == l.ANNEE_B_DETAIL.ToString())
                                        {
                                            sb.AppendLine(string.Format("<td align='right' width=15%>{0}</td>", formatMillier(l.VALEUR_B_DETAIL.ToString())));
                                            // TabLOTA[p] = l.VALEUR_B_DETAIL.ToString();
                                            //p++;
                                        }

                                        if (AnneCompar == l.ANNEE_B_DETAIL.Trim().Substring(3, 4))
                                        {
                                            VarAnnee = l.VALEUR_B_DETAIL.ToString();
                                        }
                                    }
                                }
                                if (VarAnnee != "")
                                {
                                    sb.AppendLine(string.Format("<td align='right' width=15%>{0}</td>", Convert.ToString(string.Format(frCult, "{0:#,##0}", Convert.ToDecimal(VarAnnee)))));
                                    // TabLOTA[p] = l.VALEUR_B_DETAIL.ToString();
                                }
                                sb.AppendLine("</tr>");
                            }


                        }

                    }


                }

                sb.AppendLine("</tbody>");
                sb.AppendLine("</table>");
            }
            else
            {
                sb.AppendLine("<table id='' border = '1' font size='1' class='table table-hover table-bordered text-center'>");
                sb.AppendLine("<thead class='table-heigth'    border-radius='3px' border='2px solid #022D65' margin-left='5px'>");
                sb.AppendLine(string.Format("<tr bgcolor='#022D65' color='#FFFFFF' align='center'><th>Actifs</th>"));
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
                                    sb.AppendLine(string.Format("<tr data_code='{0}' bgcolor='#ddd'>", lr.RUBR_ETAT_CODE.ToString().Trim()));
                                    // sb.AppendLine(string.Format("<td class='text-left'>{0}</td>", lr.CODE_POSTE.ToString()));


                                    if (lr.RUBR_ETAT_LIBELLE.Trim().Length <= 1)
                                    {
                                        sb.AppendLine(string.Format("<td class='text-left' color='#FFFFFF'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE.ToString()));
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
                            //sbt.AppendLine(string.Format("<table id='{0}' class='table-hover table table-bordered text-center'>", lr.RUBR_ETAT_CODE.Trim()));
                            sb.AppendLine(string.Format("<tr bgcolor='#EAF2F8' data_code='{0}'>", lr.RUBR_ETAT_CODE.ToString().Trim()));

                            sb.AppendLine(string.Format("<td class='text-left'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE));
                            sb.AppendLine(string.Format("<td width=23%></td>"));
                            sb.AppendLine("</tr>");

                            sbt.AppendLine(string.Format("<tr bgcolor='#EAF2F8' data_code='{0}'>", lr.RUBR_ETAT_CODE.ToString().Trim()));

                            sbt.AppendLine(string.Format("<td class='text-left'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE));
                            sbt.AppendLine(string.Format("<td width=23%></td>"));
                            sbt.AppendLine("</tr>");
                            //sbt.AppendLine("</table>");
                            //DIVtotauxActif.InnerHtml = sbt.ToString();


                        }
                    }
                }

                sb.AppendLine("</tbody>");
                sb.AppendLine("</table>");
            }

            HTML = sb.ToString();
        }
        public void BilanPassifsAnfi(string anneD, string AnneCompar)
        {
            string VarAnnee = "";
            var liste_annee = service.AnafiAfficheLiasse(7, compar, "", "SN");
            var nombre_annee = service.AnafiAfficheLiasse(8, compar, "", "SN");
            if (liste_annee.Count != 0)
            {
                sbE.AppendLine("<table id='' border = '1' font size='1' class='table table-hover table-bordered text-center'>");
                sbE.AppendLine("<thead class='table-heigth'>");
                sbE.AppendLine(string.Format("<tr bgcolor='#022D65' color='#FFFFFF' align='center'><th>Passifs</th>"));

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
                                if (anneD == lr.ANNEE_DETAIL)
                                {
                                    sbE.AppendLine(string.Format("<th onclick='transfertval($(this))' width=15%>{0}</th>", "Exercice  N (" + lr.ANNEE_DETAIL + ")"));

                                }
                                if (AnneCompar == lr.ANNEE_DETAIL.Trim().Substring(3, 4))
                                {
                                    VarAnnee = "Exercice  N - 1";
                                }
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
                            if (anneD == lr.ANNEE_DETAIL)
                            {
                                sbE.AppendLine(string.Format("<th onclick='transfertval($(this))' width=15%>{0}</th>", "Exercice  N (" + lr.ANNEE_DETAIL + ")"));

                            }
                            if (AnneCompar == lr.ANNEE_DETAIL.Trim().Substring(3, 4))
                            {
                                VarAnnee = "Exercice  N - 1";
                            }
                        }
                        i++;
                    }
                }
                if (VarAnnee != "")
                {
                    sbE.AppendLine(string.Format("<th onclick='transfertval($(this))' width=15% background-color='#022D65'>{0}</th>", VarAnnee));
                    //TabLOT[i] = lr.ANNEE_DETAIL;
                }
                sbE.AppendLine("</tr>");
                sbE.AppendLine("</thead>");
                sbE.AppendLine("<tbody>");

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
                            sbE.AppendLine(string.Format("<tr data_code='{0}' bgcolor='#ddd'>", lr.RUBR_ETAT_CODE.ToString().Trim()));
                            if (lr.RUBR_ETAT_LIBELLE.Trim().Length <= 1)
                            {
                                sbE.AppendLine(string.Format("<td align='left' color='#FFFFFF'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE.ToString()));
                            }
                            else
                            {
                                sbE.AppendLine(string.Format("<td align='left'><strong><strong>{0}</strong></strong></td>", lr.RUBR_ETAT_LIBELLE.ToString()));
                            }
                            var liste_valeur4 = service.AnafiAfficheLiasse(9, compar, lr.RUBR_ETAT_CODE.ToString().Trim(), "SN");
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
                                        if (anneD == l.ANNEE_B_DETAIL.ToString())
                                        {
                                            sbE.AppendLine(string.Format("<td align='right' class='text-right {1}' width=15%><strong><strong>{0}</strong></strong></td>", formatMillier(l.VALEUR_B_DETAIL.ToString()), l.ANNEE_B_DETAIL.Replace("/", "")));

                                        }
                                        if (AnneCompar == l.ANNEE_B_DETAIL.Trim().Substring(3, 4))
                                        {
                                            VarAnnee = l.VALEUR_B_DETAIL.ToString();
                                        }
                                    }

                                }
                                else
                                {
                                    if (anneD == l.ANNEE_B_DETAIL.ToString())
                                    {
                                        sbE.AppendLine(string.Format("<td align='right' class='text-right {1}' width=15%><strong><strong>{0}</strong></strong></td>", formatMillier(l.VALEUR_B_DETAIL.ToString()), l.ANNEE_B_DETAIL.Replace("/", "")));

                                    }
                                    if (AnneCompar == l.ANNEE_B_DETAIL.Trim().Substring(3, 4))
                                    {
                                        VarAnnee = l.VALEUR_B_DETAIL.ToString();
                                    }
                                }
                            }

                            if (VarAnnee != "")
                            {
                                sbE.AppendLine(string.Format("<td align='right' class='text-right' width=15%><strong><strong>{0}</strong></strong></td>", Convert.ToString(string.Format(frCult, "{0:#,##0}", Convert.ToDecimal(VarAnnee)))));

                            }
                            sbE.AppendLine("</tr>");
                        }
                        else
                        {
                            if (lr.RUBR_ETAT_CODE.ToString().Trim() == "BP1")
                            {
                                sbE.AppendLine(string.Format("<tr data_code='{0}' bgcolor='##b7abab'>", lr.RUBR_ETAT_CODE.ToString().Trim()));
                                if (lr.RUBR_ETAT_LIBELLE.Trim().Length <= 1)
                                {
                                    sbE.AppendLine(string.Format("<td align='left' color='#FFFFFF'>{0}</td>", lr.RUBR_ETAT_LIBELLE.ToString()));
                                }
                                else
                                {
                                    sbE.AppendLine(string.Format("<td align='left'>{0}</td>", lr.RUBR_ETAT_LIBELLE.ToString()));
                                }
                                var liste_valeur4 = service.AnafiAfficheLiasse(9, compar, lr.RUBR_ETAT_CODE.ToString().Trim(), "SN");
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
                                            if (anneD == l.ANNEE_B_DETAIL.ToString())
                                            {
                                                sbE.AppendLine(string.Format("<td align='right' class='text-right {1}' width=15%>{0}</td>", formatMillier(l.VALEUR_B_DETAIL.ToString()), l.ANNEE_B_DETAIL.Replace("/", "")));

                                            }
                                            if (AnneCompar == l.ANNEE_B_DETAIL.Trim().Substring(3, 4))
                                            {
                                                VarAnnee = l.VALEUR_B_DETAIL.ToString();
                                            }
                                        }

                                    }
                                    else
                                    {
                                        if (anneD == l.ANNEE_B_DETAIL.ToString())
                                        {
                                            sbE.AppendLine(string.Format("<td align='right' class='text-right {1}' width=15%>{0}</td>", formatMillier(l.VALEUR_B_DETAIL.ToString()), l.ANNEE_B_DETAIL.Replace("/", "")));

                                        }
                                        if (AnneCompar == l.ANNEE_B_DETAIL.Trim().Substring(3, 4))
                                        {
                                            VarAnnee = l.VALEUR_B_DETAIL.ToString();
                                        }
                                    }
                                }

                                if (VarAnnee != "")
                                {
                                    sbE.AppendLine(string.Format("<td align='right' class='text-right ' width=15%><strong><strong>{0}</strong></strong></td>", Convert.ToString(string.Format(frCult, "{0:#,##0}", Convert.ToDecimal(VarAnnee)))));

                                }
                                sbE.AppendLine("</tr>");
                            }
                            else
                            {
                                if (lr.RUBR_ETAT_CODE.ToString().Trim() == "BP1A1" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BP1A3" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BP1A9" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BP1AX")
                                {
                                    sbE.AppendLine(string.Format("<tr data_code='{0}'>", lr.RUBR_ETAT_CODE.ToString().Trim()));
                                    sbE.AppendLine(string.Format("<td align='left'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE.ToString()));

                                    var liste_valeur5 = service.AnafiAfficheLiasse(9, compar, lr.RUBR_ETAT_CODE.ToString().Trim(), "SN");
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
                                                    sbE.AppendLine(string.Format("<td align='right' width=15%></td>"));
                                                }
                                                else
                                                {
                                                    if (anneD == l.ANNEE_B_DETAIL.ToString())
                                                    {
                                                        sbE.AppendLine(string.Format("<td align='right' class='text-right {1}' width=15%><strong>{0}</strong></td>", formatMillier(l.VALEUR_B_DETAIL.ToString()), l.ANNEE_B_DETAIL.Replace("/", "")));

                                                    }
                                                    if (AnneCompar == l.ANNEE_B_DETAIL.Trim().Substring(3, 4))
                                                    {
                                                        VarAnnee = l.VALEUR_B_DETAIL.ToString();
                                                    }
                                                }
                                            }

                                        }
                                        else
                                        {
                                            if (l.RUBR_ETAT_LIBELLE.Trim().Length <= 1)
                                            {
                                                sbE.AppendLine(string.Format("<td align='right' width=15%></td>"));
                                            }
                                            else
                                            {
                                                if (anneD == l.ANNEE_B_DETAIL.ToString())
                                                {
                                                    sbE.AppendLine(string.Format("<td align='right' class='text-right {1}' width=15%><strong>{0}</strong></td>", formatMillier(l.VALEUR_B_DETAIL.ToString()), l.ANNEE_B_DETAIL.Replace("/", "")));

                                                }
                                                if (AnneCompar == l.ANNEE_B_DETAIL.Trim().Substring(3, 4))
                                                {
                                                    VarAnnee = l.VALEUR_B_DETAIL.ToString();
                                                }
                                            }
                                        }
                                    }
                                    if (VarAnnee != "")
                                    {
                                        sbE.AppendLine(string.Format("<td align='right' class='text-right ' width=15%><strong><strong>{0}</strong></strong></td>", Convert.ToString(string.Format(frCult, "{0:#,##0}", Convert.ToDecimal(VarAnnee)))));

                                    }
                                    sbE.AppendLine("</tr>");

                                }
                                else
                                {

                                    sbE.AppendLine(string.Format("<tr data_code='{0}'>", lr.RUBR_ETAT_CODE.ToString().Trim()));
                                    sbE.AppendLine(string.Format("<td align='left'>{0}</td>", lr.RUBR_ETAT_LIBELLE.ToString()));

                                    var liste_valeur5 = service.AnafiAfficheLiasse(9, compar, lr.RUBR_ETAT_CODE.ToString().Trim(), "SN");
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
                                                    sbE.AppendLine(string.Format("<td align='right' width=15%></td>"));
                                                }
                                                else
                                                {
                                                    if (anneD == l.ANNEE_B_DETAIL.ToString())
                                                    {
                                                        sbE.AppendLine(string.Format("<td align='right' class='text-right {1}' width=15%>{0}</td>", formatMillier(l.VALEUR_B_DETAIL.ToString()), l.ANNEE_B_DETAIL.Replace("/", "")));

                                                    }
                                                    if (AnneCompar == l.ANNEE_B_DETAIL.Trim().Substring(3, 4))
                                                    {
                                                        VarAnnee = l.VALEUR_B_DETAIL.ToString();
                                                    }
                                                }
                                            }

                                        }
                                        else
                                        {
                                            if (l.RUBR_ETAT_LIBELLE.Trim().Length <= 1)
                                            {
                                                sbE.AppendLine(string.Format("<td align='right' width=15%></td>"));
                                            }
                                            else
                                            {
                                                if (anneD == l.ANNEE_B_DETAIL.ToString())
                                                {
                                                    sbE.AppendLine(string.Format("<td align='right' class='text-right {1}' width=15%>{0}</td>", formatMillier(l.VALEUR_B_DETAIL.ToString()), l.ANNEE_B_DETAIL.Replace("/", "")));

                                                }
                                                if (AnneCompar == l.ANNEE_B_DETAIL.Trim().Substring(3, 4))
                                                {
                                                    VarAnnee = l.VALEUR_B_DETAIL.ToString();
                                                }
                                            }
                                        }
                                    }
                                    if (VarAnnee != "")
                                    {
                                        sbE.AppendLine(string.Format("<td align='right' class='text-right' width=15%><strong><strong>{0}</strong></strong></td>", Convert.ToString(string.Format(frCult, "{0:#,##0}", Convert.ToDecimal(VarAnnee)))));

                                    }
                                    sbE.AppendLine("</tr>");
                                }

                            }
                        }
                    }
                    if (lr.RUBR_ETAT_CODE.Trim() == "BP")
                    {
                        sbE.AppendLine(string.Format("<tr bgcolor='#EAF2F8'>"));

                        sbE.AppendLine(string.Format("<td align='left'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE));
                        int p = 0;
                        var liste_valeur6 = service.AnafiAfficheLiasse(9, compar, lr.RUBR_ETAT_CODE.ToString().Trim(), "SN");
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
                                    if (anneD == l.ANNEE_B_DETAIL.ToString())
                                    {
                                        sbE.AppendLine(string.Format("<td align='right' width=15%>{0}</td>", formatMillier(l.VALEUR_B_DETAIL.ToString())));
                                        p++;
                                    }
                                    if (AnneCompar == l.ANNEE_B_DETAIL.Trim().Substring(3, 4))
                                    {
                                        VarAnnee = l.VALEUR_B_DETAIL.ToString();
                                    }

                                }

                            }
                            else
                            {
                                if (anneD == l.ANNEE_B_DETAIL.ToString())
                                {
                                    sbE.AppendLine(string.Format("<td align='right' width=15%>{0}</td>", formatMillier(l.VALEUR_B_DETAIL.ToString())));
                                    p++;
                                }
                                if (AnneCompar == l.ANNEE_B_DETAIL.Trim().Substring(3, 4))
                                {
                                    VarAnnee = l.VALEUR_B_DETAIL.ToString();
                                }

                            }
                        }
                        if (VarAnnee != "")
                        {
                            sbE.AppendLine(string.Format("<td align='right' class='text-right' width=15%><strong><strong>{0}</strong></strong></td>", Convert.ToString(string.Format(frCult, "{0:#,##0}", Convert.ToDecimal(VarAnnee)))));

                        }
                        sbE.AppendLine("</tr>");
                    }
                }

                sbE.AppendLine("</tbody>");
                sbE.AppendLine("</table>");

            }
            else
            {
                sbE.AppendLine("<table id='' border = '1' font size='1' class='table table-hover table-bordered text-center'>");
                sbE.AppendLine("<thead class='table-heigth'>");
                sbE.AppendLine(string.Format("<tr bgcolor='#022D65' color='#FFFFFF' align='center'><th>Passifs</th>"));
                sbE.AppendLine(string.Format("<th width=23%></th>"));

                sbE.AppendLine("</thead>");
                sbE.AppendLine("<tbody>");

                var liste_libelle = service.AnafiAfficheLiasse(0, "", "", "BIN");

                foreach (var lr in liste_libelle)
                {
                    if (lr.RUBR_ETAT_LIBELLE.ToString() != "Ecart")
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
                                sbE.AppendLine(string.Format("<tr data_code='{0}' bgcolor='#ddd'>", lr.RUBR_ETAT_CODE.ToString().Trim()));
                                if (lr.RUBR_ETAT_LIBELLE.Trim().Length <= 1)
                                {
                                    sbE.AppendLine(string.Format("<td class='text-left' color='#FFFFFF'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE.ToString()));
                                    sbE.AppendLine(string.Format("<td></td>"));
                                }
                                else
                                {
                                    sbE.AppendLine(string.Format("<td class='text-left'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE.ToString()));
                                    sbE.AppendLine(string.Format("<td></td>"));
                                }
                                sb.AppendLine("</tr>");
                            }
                            else
                            {
                                if (lr.RUBR_ETAT_CODE.ToString().Trim() == "BP1")
                                {
                                    sbE.AppendLine(string.Format("<tr data_code='{0}' bgcolor='#b7abab'>", lr.RUBR_ETAT_CODE.ToString().Trim()));
                                    if (lr.RUBR_ETAT_LIBELLE.Trim().Length <= 1)
                                    {
                                        sbE.AppendLine(string.Format("<td class='text-left' color='#FFFFFF'>{0}</td>", lr.RUBR_ETAT_LIBELLE.ToString()));
                                        sbE.AppendLine(string.Format("<td></td>"));
                                    }
                                    else
                                    {
                                        sbE.AppendLine(string.Format("<td class='text-left'>{0}</td>", lr.RUBR_ETAT_LIBELLE.ToString()));
                                        sbE.AppendLine(string.Format("<td></td>"));
                                    }
                                    sb.AppendLine("</tr>");
                                }
                                else
                                {
                                    if (lr.RUBR_ETAT_CODE.ToString().Trim() == "BP1A1" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BP1A3" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BP1A9" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BP1AX")
                                    {
                                        sbE.AppendLine(string.Format("<tr data_code='{0}'>", lr.RUBR_ETAT_CODE.ToString().Trim()));
                                        sbE.AppendLine(string.Format("<td class='text-left'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE.ToString()));

                                        sbE.AppendLine(string.Format("<td></td>"));

                                        sbE.AppendLine("</tr>");

                                    }
                                    else
                                    {

                                        sbE.AppendLine(string.Format("<tr data_code='{0}'>", lr.RUBR_ETAT_CODE.ToString().Trim()));
                                        sbE.AppendLine(string.Format("<td class='text-left'>{0}</td>", lr.RUBR_ETAT_LIBELLE.ToString()));
                                        sbE.AppendLine(string.Format("<td></td>"));


                                        sbE.AppendLine("</tr>");
                                    }

                                }
                            }
                        }
                        if (lr.RUBR_ETAT_CODE.Trim() == "BP")
                        {
                            sbE.AppendLine(string.Format("<tr bgcolor='#EAF2F8'>"));

                            sbE.AppendLine(string.Format("<td class='text-left'><strong>{0}</strong></td>", lr.RUBR_ETAT_LIBELLE));
                            sbE.AppendLine(string.Format("<td width=23%></td>"));
                            sbE.AppendLine("</tr>");

                        }
                    }

                }

                sbE.AppendLine("</tbody>");
                sbE.AppendLine("</table>");
            }
        }
        public void BilanEcartsAnfi(string anneD, string AnneCompar)
        {
            string VarAnnee = "";
            var liste_annee = service.AnafiAfficheLiasse(7, compar, "", "SN");
            var nombre_annee = service.AnafiAfficheLiasse(8, compar, "", "SN");

            if (liste_annee.Count != 0)
            {

                sbEcart.AppendLine("<table id='' style='border-style: dotted !important; border-color:#D0D3D4;' border = '1' font size='1' class='table table-hover table-bordered text-center'>");
                sbEcart.AppendLine("<thead class='table-heigth'    border-radius='3px' border='2px solid #022D65' margin-left='5px'>");
                sbEcart.AppendLine(string.Format("<tr bgcolor='#022D65' color='#FFFFFF'  align='center'><th>Ecrats des totaux</th>"));
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
                                if (anneD == lr.ANNEE_DETAIL)
                                {
                                    sbEcart.AppendLine(string.Format("<th onclick='transfertval($(this))' width=15% background-color='#022D65'>{0}</th>", "Exercice  N (" + lr.ANNEE_DETAIL + ")"));

                                }
                                //if (AnneCompar == lr.ANNEE_DETAIL.Trim().Substring(3, 4))
                                //{
                                //    VarAnnee = "Exercice  N - 1";
                                //}
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
                            if (anneD == lr.ANNEE_DETAIL)
                            {
                                sbEcart.AppendLine(string.Format("<th onclick='transfertval($(this))' width=15% background-color='#022D65'>{0}</th>", "Exercice  N (" + lr.ANNEE_DETAIL + ")"));

                            }
                            //if (AnneCompar == lr.ANNEE_DETAIL.Trim().Substring(3, 4))
                            //{
                            //    VarAnnee = "Exercice  N - 1";
                            //}
                        }
                        i++;
                    }
                }

                //if (VarAnnee != "")
                //{
                //    sbEcart.AppendLine(string.Format("<th onclick='transfertval($(this))' width=15% background-color='#022D65'>{0}</th>", VarAnnee));
                //    //TabLOT[i] = lr.ANNEE_DETAIL;
                //}
                sbEcart.AppendLine("</thead>");
                sbEcart.AppendLine("<tbody>");

                var liste_libelle = service.AnafiAfficheLiasse(0, "", "", "BIN");

                int limite = 0;

                foreach (var lr in liste_libelle)
                {
                    limite++;
                    if (lr.RUBR_ETAT_CODE.Trim() == "BA")
                    {

                        sbEcart.AppendLine(string.Format("<tr >"));

                        sbEcart.AppendLine(string.Format("<td align='left'><strong>{0}</strong></td>", "TOTAL GÉNERAL DES ACTIFS"));

                        var liste_valeur4 = service.AnafiAfficheLiasse(9, compar, lr.RUBR_ETAT_CODE.ToString().Trim(), "SN");

                        int t = 0;
                        int u = 0;
                        int i = 0;
                        u = Convert.ToInt32(liste_valeur4.Count) - 3;
                        foreach (var l in liste_valeur4)
                        {

                            if (liste_valeur4.Count > 3)
                            {
                                t++;
                                if (u < t)
                                {
                                    if (anneD == l.ANNEE_B_DETAIL.ToString())
                                    {
                                        sbEcart.AppendLine(string.Format("<td align='right' width=15%>{0}</td>", formatMillier(l.VALEUR_B_DETAIL.ToString())));
                                        TabLOTECART[i] = Convert.ToDouble(l.VALEUR_B_DETAIL);
                                    }

                                }

                            }
                            else
                            {
                                if (anneD == l.ANNEE_B_DETAIL.ToString())
                                {
                                    sbEcart.AppendLine(string.Format("<td align='right' width=15%>{0}</td>", formatMillier(l.VALEUR_B_DETAIL.ToString())));
                                    TabLOTECART[i] = Convert.ToDouble(l.VALEUR_B_DETAIL);
                                }

                            }
                            i++;
                        }
                        sbEcart.AppendLine("</tr>");
                    }

                    if (lr.RUBR_ETAT_CODE.Trim() == "BP")
                    {
                        sbEcart.AppendLine(string.Format("<tr >"));

                        sbEcart.AppendLine(string.Format("<td align='left'><strong>{0}</strong></td>", "TOTAL GÉNERAL DES PASSIFS"));

                        int p = 0;
                        var liste_valeur6 = service.AnafiAfficheLiasse(9, compar, lr.RUBR_ETAT_CODE.ToString().Trim(), "SN");
                        int j = 0;
                        int v = 0;
                        v = Convert.ToInt32(liste_valeur6.Count) - 3;
                        int i = 0;
                        foreach (var l in liste_valeur6)
                        {

                            if (liste_valeur6.Count > 3)
                            {
                                j++;
                                if (v < j)
                                {
                                    if (anneD == l.ANNEE_B_DETAIL.ToString())
                                    {
                                        var testjkjh = formatMillier(l.VALEUR_B_DETAIL.ToString()).Replace(" ", "&nbsp;");
                                        sbEcart.AppendLine(string.Format("<td align='right' width=15%>{0}</td>", formatMillier(l.VALEUR_B_DETAIL.ToString())));
                                        TabLOTECART1[i] = Convert.ToDouble(l.VALEUR_B_DETAIL);
                                        p++;
                                    }

                                }

                            }
                            else
                            {
                                if (anneD == l.ANNEE_B_DETAIL.ToString())
                                {
                                    var testjkjh = formatMillier(l.VALEUR_B_DETAIL.ToString()).Replace("&nbsp;", " ");
                                    sbEcart.AppendLine(string.Format("<td align='right' width=15%>{0}</td>", formatMillier(l.VALEUR_B_DETAIL.ToString())));
                                    TabLOTECART1[i] = Convert.ToDouble(l.VALEUR_B_DETAIL);
                                    p++;
                                }

                            }
                            i++;
                        }
                        sbt.AppendLine("</tr>");



                        if (limite == liste_libelle.Count)
                        {

                            sbEcart.AppendLine(string.Format("<tr >"));

                            sbEcart.AppendLine(string.Format("<td align='left'><strong>{0}</strong></td>", "ECARTS"));

                            var liste_valeur4 = service.AnafiAfficheLiasse(9, compar, lr.RUBR_ETAT_CODE.ToString().Trim(), "SN");

                            int t = 0;
                            int u = 0;
                            int b = 0;
                            u = Convert.ToInt32(liste_valeur4.Count) - 3;
                            foreach (var l in liste_valeur4)
                            {

                                if (liste_valeur4.Count > 3)
                                {
                                    t++;
                                    if (u < t)
                                    {
                                        double nombre = TabLOTECART[b] - TabLOTECART1[b];
                                        if (nombre == 0)
                                        {
                                            if (anneD == l.ANNEE_B_DETAIL.ToString())
                                            {
                                                sbEcart.AppendLine(string.Format("<td align='right' width=15%>{0}</td>", formatMillier(nombre.ToString())));

                                            }

                                        }
                                        else
                                        {
                                            if (anneD == l.ANNEE_B_DETAIL.ToString())
                                            {
                                                sbEcart.AppendLine(string.Format("<td align='right' color='#FF5733' width=15%>{0}</td>", formatMillier(nombre.ToString())));

                                            }

                                        }

                                    }

                                }
                                else
                                {
                                    double nombre = TabLOTECART[b] - TabLOTECART1[b];
                                    if (nombre == 0)
                                    {
                                        if (anneD == l.ANNEE_B_DETAIL.ToString())
                                        {
                                            sbEcart.AppendLine(string.Format("<td align='right' width=15%>{0}</td>", formatMillier(nombre.ToString())));

                                        }
                                    }
                                    else
                                    {
                                        if (anneD == l.ANNEE_B_DETAIL.ToString())
                                        {
                                            sbEcart.AppendLine(string.Format("<td align='right' color='#FF5733' width=15%>{0}</td>", formatMillier(nombre.ToString())));

                                        }
                                    }

                                }

                                b++;
                            }
                            sbEcart.AppendLine("</tr>");

                        }

                    }
                }
                sbEcart.AppendLine("</tbody>");
                sbEcart.AppendLine("</table>");
            }
            else
            {
                sbEcart.AppendLine("<table id='' style='border-style: dotted !important; border-color:#D0D3D4;'  border = '1' font size='1' class='table table-hover table-bordered text-center'>");
                sbEcart.AppendLine("<thead class='table-heigth'    border-radius='3px' border='2px solid #022D65' margin-left='5px'>");
                sbEcart.AppendLine(string.Format("<tr bgcolor='#E4EBF5'  align='center'><th>Ecrats des totaux</th>"));
                sbEcart.AppendLine(string.Format("<th width=23%></th>"));
                sbEcart.AppendLine("</thead>");
                sbEcart.AppendLine("<tbody>");
                sbEcart.AppendLine(string.Format("<tr >"));
                sbEcart.AppendLine(string.Format("<td align='left'><strong>{0}</strong></td>", "TOTAL GÉNERAL DES ACTIFS"));
                sbEcart.AppendLine(string.Format("<td width=23%></td>"));
                sbEcart.AppendLine("</tr>");

                sbEcart.AppendLine(string.Format("<tr >"));
                sbEcart.AppendLine(string.Format("<td align='left'><strong>{0}</strong></td>", "TOTAL GÉNERAL DES PASSIFS"));
                sbEcart.AppendLine(string.Format("<td width=23%></td>"));
                sbEcart.AppendLine("</tr>");

                sbEcart.AppendLine(string.Format("<tr >"));
                sbEcart.AppendLine(string.Format("<td align='left'><strong>{0}</strong></td>", "ECARTS"));
                sbEcart.AppendLine(string.Format("<td width=23%></td>"));
                sbEcart.AppendLine("</tr>");

                sbEcart.AppendLine("</tbody>");
                sbEcart.AppendLine("</table>");
            }

            Type_anafi = "BN";
        }
        public void EtatsANAFIExcelPossible()
        {
            string etat = Request.QueryString["id"].Trim();
            //TabEditeAnafi etat.Split("@");
            Char delimiter = '@';
            string[] resutdonnee = etat.ToString().Split(delimiter);
            int nobr = resutdonnee.Length;
            string annrecup = resutdonnee[nobr - 1];
            string annMoinUn = (Convert.ToDecimal(annrecup.Trim().Substring(3, 4)) - 1).ToString();
            if (nobr == 3)
            {
                if (resutdonnee[1] == "COMPTERESULTAT")
                {
                    cr1 = "COMPTERESULTAT";
                    bi1 = "";
                    bi1cr1 = "";
                    CompteResultatsChargeAnfi(annrecup, annMoinUn);
                    CompteResultatsProduitsAnfi(annrecup, annMoinUn);
                }
                if (resutdonnee[1] == "BILAN")
                {
                    bi1 = "BILAN";
                    cr1 = "";
                    bi1cr1 = "";
                    BilanActifsAnfi(annrecup, annMoinUn);
                    BilanPassifsAnfi(annrecup, annMoinUn);
                    BilanEcartsAnfi(annrecup, annMoinUn);

                }
            }
            if (nobr == 4)
            {
                bi1cr1 = "COMPTERESULTATBILAN";
                cr1 = "";
                bi1 = "";
                CompteResultatsChargeAnfi(annrecup, annMoinUn);
                CompteResultatsProduitsAnfi(annrecup, annMoinUn);
                BilanActifsAnfi(annrecup, annMoinUn);
                BilanPassifsAnfi(annrecup, annMoinUn);
                BilanEcartsAnfi(annrecup, annMoinUn);

            }

        }
        public void PS_SCOR_ETATBILAN_ACT_CIRCUL(string annee)
        {
            var palatino = FontFactory.GetFont("palatino linotype", BaseFont.CP1252, BaseFont.EMBEDDED, 9, Font.BOLD);
            var boldFont = FontFactory.GetFont("palatino linotype", BaseFont.CP1252, BaseFont.EMBEDDED, 12, Font.BOLD);
            var italicfont = FontFactory.GetFont("palatino linotype", BaseFont.CP1252, BaseFont.EMBEDDED, 9, Font.ITALIC);
            var boldFontTitle = FontFactory.GetFont("palatino linotype", BaseFont.CP1252, BaseFont.EMBEDDED, 14, Font.BOLD);
            var titleFont = FontFactory.GetFont("Segoe UI", 9, BaseColor.WHITE);

            Font boldFont2 = new Font(Font.FontFamily.TIMES_ROMAN, 9, Font.BOLD, BaseColor.BLACK);
            Font boldFont22 = new Font(Font.FontFamily.TIMES_ROMAN, 9, Font.BOLD, BaseColor.WHITE);
            Font normalFont2 = new Font(Font.FontFamily.TIMES_ROMAN, 9, Font.ITALIC, BaseColor.BLACK);


            TABLEActCircul.TotalWidth = 500f;
            TABLEActCircul.PaddingTop = 5f;
            TABLEActCircul.LockedWidth = true;
            float[] widthstablequalital = new float[] { 1f, 5f, 1.5f, 1.5f, 1.5f, 1.5f };
            TABLEActCircul.SetWidths(widthstablequalital);
            TABLEActCircul.HorizontalAlignment = 1;
            var idDossier1 = Request.QueryString["id"].Trim();
            //var idDossier1 = Session["id_dossier"].ToString();
            //if (Session["id_dossier"] == null) Response.Redirect("~/Scoring/Connexion.aspx");
            //else idDossier = Session["id_dossier"].ToString();
            //Session.Add("id_dossier", idDossier);
            string modele = "";
            var elements = _service.InfoDossier(idDossier1);

            PdfPCell cell1qualital = new PdfPCell(new Phrase("Ref", boldFont2));
            cell1qualital.Rowspan = 2;
            cell1qualital.HorizontalAlignment = 1;
            cell1qualital.UseVariableBorders = true;
            cell1qualital.BorderWidth = 1;
            cell1qualital.BackgroundColor = new BaseColor(228, 235, 245);
            cell1qualital.BorderColor = new BaseColor(208, 211, 212);
            cell1qualital.PaddingBottom = 5f;
            TABLEActCircul.AddCell(cell1qualital);

            PdfPCell cell1qualital1 = new PdfPCell(new Phrase("ACTIF", boldFont2));
            cell1qualital1.Rowspan = 2;
            cell1qualital1.HorizontalAlignment = 1;
            cell1qualital1.UseVariableBorders = true;
            cell1qualital1.BorderWidth = 1;
            cell1qualital1.BackgroundColor = new BaseColor(228, 235, 245);
            cell1qualital1.BorderColor = new BaseColor(208, 211, 212);
            cell1qualital1.PaddingBottom = 5f;
            TABLEActCircul.AddCell(cell1qualital1);

            PdfPCell cell1qualital2 = new PdfPCell(new Phrase("Exercice N", boldFont2));
            cell1qualital2.Colspan = 3;
            cell1qualital2.HorizontalAlignment = 1;
            cell1qualital2.UseVariableBorders = true;
            cell1qualital2.BorderWidth = 1;
            cell1qualital2.BackgroundColor = new BaseColor(228, 235, 245);
            cell1qualital2.BorderColor = new BaseColor(208, 211, 212);
            cell1qualital2.PaddingBottom = 5f;
            TABLEActCircul.AddCell(cell1qualital2);

            PdfPCell cell1qualital3 = new PdfPCell(new Phrase("Exercice N-1", boldFont2));
            //cell1qualital3.Rowspan = 2;
            cell1qualital3.HorizontalAlignment = 1;
            cell1qualital3.UseVariableBorders = true;
            cell1qualital3.BorderWidth = 1;
            cell1qualital3.BackgroundColor = new BaseColor(228, 235, 245);
            cell1qualital3.BorderColor = new BaseColor(208, 211, 212);
            cell1qualital3.PaddingBottom = 5f;
            TABLEActCircul.AddCell(cell1qualital3);

            PdfPCell cell1qualital4 = new PdfPCell(new Phrase("BRUT", boldFont2));
            //cell1qualital4.Rowspan = 2;
            cell1qualital4.HorizontalAlignment = 1;
            cell1qualital4.UseVariableBorders = true;
            cell1qualital4.BorderWidth = 1;
            cell1qualital4.BackgroundColor = new BaseColor(228, 235, 245);
            cell1qualital4.BorderColor = new BaseColor(208, 211, 212);
            cell1qualital4.PaddingBottom = 5f;
            TABLEActCircul.AddCell(cell1qualital4);

            PdfPCell cell1qualital5 = new PdfPCell(new Phrase("Amort. / Prov.", boldFont2));
            //cell1qualital4.Rowspan = 2;
            cell1qualital5.HorizontalAlignment = 1;
            cell1qualital5.UseVariableBorders = true;
            cell1qualital5.BorderWidth = 1;
            cell1qualital5.BackgroundColor = new BaseColor(228, 235, 245);
            cell1qualital5.BorderColor = new BaseColor(208, 211, 212);
            cell1qualital5.PaddingBottom = 5f;
            TABLEActCircul.AddCell(cell1qualital5);

            PdfPCell cell1qualital6 = new PdfPCell(new Phrase("Net", boldFont2));
            //cell1qualital4.Rowspan = 2;
            cell1qualital6.HorizontalAlignment = 1;
            cell1qualital6.UseVariableBorders = true;
            cell1qualital6.BorderWidth = 1;
            cell1qualital6.BackgroundColor = new BaseColor(228, 235, 245);
            cell1qualital6.BorderColor = new BaseColor(208, 211, 212);
            cell1qualital6.PaddingBottom = 5f;
            TABLEActCircul.AddCell(cell1qualital6);

            PdfPCell cell1qualital7 = new PdfPCell(new Phrase("Net", boldFont2));
            //cell1qualital4.Rowspan = 2;
            cell1qualital7.HorizontalAlignment = 1;
            cell1qualital7.UseVariableBorders = true;
            cell1qualital7.BorderWidth = 1;
            cell1qualital7.BackgroundColor = new BaseColor(228, 235, 245);
            cell1qualital7.BorderColor = new BaseColor(208, 211, 212);
            cell1qualital7.PaddingBottom = 5f;
            TABLEActCircul.AddCell(cell1qualital7);


            var listes = _service.LIST_PS_SCOR_ETATBILAN_ACT_CIRCUL(annee, idDossier1);
            var i1 = 0;
            decimal tot = 0;
            foreach (var lr in listes)
            {
                PdfPCell cell2qualital8 = new PdfPCell(new Phrase(lr.REF, boldFont2));
                cell2qualital8.PaddingLeft = 10f;
                cell2qualital8.PaddingTop = 2f;
                cell2qualital8.PaddingBottom = 5f;
                cell2qualital8.UseVariableBorders = true;
                cell2qualital8.BorderWidthBottom = 1;
                cell2qualital8.BorderWidthLeft = 1;
                cell2qualital8.BorderWidthTop = 1;
                cell2qualital8.BorderColor = new BaseColor(208, 211, 212);
                cell2qualital8.BorderWidthRight = 1;
                TABLEActCircul.AddCell(cell2qualital8);

                PdfPCell cell2qualital9 = new PdfPCell(new Phrase(lr.RUBR_ETAT_LIBELLE, boldFont2));
                cell2qualital9.PaddingLeft = 10f;
                cell2qualital9.PaddingTop = 2f;
                cell2qualital9.PaddingBottom = 5f;
                cell2qualital9.UseVariableBorders = true;
                cell2qualital9.BorderWidthBottom = 1;
                cell2qualital9.BorderWidthLeft = 1;
                cell2qualital9.BorderWidthTop = 1;
                cell2qualital9.BorderColor = new BaseColor(208, 211, 212);
                cell2qualital9.BorderWidthRight = 1;
                TABLEActCircul.AddCell(cell2qualital9);

                PdfPCell cell2qualital10 = new PdfPCell(new Phrase(formatMillier((lr.VALEUR_B_AMMORT + lr.VALEUR_B_DETAIL).ToString()), boldFont2));
                cell2qualital10.PaddingRight = 5f;
                cell2qualital10.HorizontalAlignment = 2;
                cell2qualital10.PaddingTop = 2f;
                cell2qualital10.PaddingBottom = 5f;
                cell2qualital10.UseVariableBorders = true;
                cell2qualital10.BorderWidthBottom = 1;
                cell2qualital10.BorderWidthLeft = 1;
                cell2qualital10.BorderWidthTop = 1;
                cell2qualital10.BorderColor = new BaseColor(208, 211, 212);
                cell2qualital10.BorderWidthRight = 1;
                TABLEActCircul.AddCell(cell2qualital10);

                PdfPCell cell2qualital11 = new PdfPCell(new Phrase(formatMillier(lr.VALEUR_B_AMMORT.ToString()), normalFont2));
                cell2qualital11.PaddingRight = 5f;
                cell2qualital11.HorizontalAlignment = 2;
                cell2qualital11.PaddingTop = 2f;
                cell2qualital11.PaddingBottom = 5f;
                cell2qualital11.UseVariableBorders = true;
                cell2qualital11.BorderWidthBottom = 1;
                cell2qualital11.BorderWidthLeft = 1;
                cell2qualital11.BorderWidthTop = 1;
                cell2qualital11.BorderColor = new BaseColor(208, 211, 212);
                cell2qualital11.BorderWidthRight = 1;
                TABLEActCircul.AddCell(cell2qualital11);

                PdfPCell cell2qualital12 = new PdfPCell(new Phrase(formatMillier(lr.VALEUR_B_DETAIL.ToString()), normalFont2));
                cell2qualital12.PaddingRight = 5f;
                cell2qualital12.HorizontalAlignment = 2;
                cell2qualital12.PaddingTop = 2f;
                cell2qualital12.PaddingBottom = 5f;
                cell2qualital12.UseVariableBorders = true;
                cell2qualital12.BorderWidthBottom = 1;
                cell2qualital12.BorderWidthLeft = 1;
                cell2qualital12.BorderWidthTop = 1;
                cell2qualital12.BorderColor = new BaseColor(208, 211, 212);
                cell2qualital12.BorderWidthRight = 1;
                TABLEActCircul.AddCell(cell2qualital12);

                PdfPCell cell2qualital13 = new PdfPCell(new Phrase(formatMillier(lr.VALEUR_B_N_1.ToString()), normalFont2));
                cell2qualital13.PaddingRight = 5f;
                cell2qualital13.HorizontalAlignment = 2;
                cell2qualital13.PaddingTop = 2f;
                cell2qualital13.PaddingBottom = 5f;
                cell2qualital13.UseVariableBorders = true;
                cell2qualital13.BorderWidthBottom = 1;
                cell2qualital13.BorderWidthLeft = 1;
                cell2qualital13.BorderWidthTop = 1;
                cell2qualital13.BorderColor = new BaseColor(208, 211, 212);
                cell2qualital13.BorderWidthRight = 1;
                TABLEActCircul.AddCell(cell2qualital13);
                //tot = tot + question.NOTE_QUESTION;
                // ITERATATION REPONSES
                //s += "<div class='ln_reponse col-md-6'> <select  onchange=\"combo007($(this),'C')\"  class='checkboxx' id='selec" + i + "' onchange='get_docs()'>";

                //PdfPCell cell5qualital = new PdfPCell(new Phrase("vide", boldFont22));
                //cell5qualital.Colspan = 2;
                //cell5qualital.HorizontalAlignment = 1;
                //cell5qualital.UseVariableBorders = true;
                //cell5qualital.BorderWidth = 1;
                //cell5qualital.BackgroundColor = new BaseColor(255, 255, 255);
                //cell5qualital.BorderColor = new BaseColor(255, 255, 255);
                //cell5qualital.PaddingBottom = 5f;
                //tablequalital.AddCell(cell5qualital);
            }
        }
        public void PS_SCOR_ETATBILAN_AM(string annee)
        {
            var palatino = FontFactory.GetFont("palatino linotype", BaseFont.CP1252, BaseFont.EMBEDDED, 9, Font.BOLD);
            var boldFont = FontFactory.GetFont("palatino linotype", BaseFont.CP1252, BaseFont.EMBEDDED, 12, Font.BOLD);
            var italicfont = FontFactory.GetFont("palatino linotype", BaseFont.CP1252, BaseFont.EMBEDDED, 9, Font.ITALIC);
            var boldFontTitle = FontFactory.GetFont("palatino linotype", BaseFont.CP1252, BaseFont.EMBEDDED, 14, Font.BOLD);
            var titleFont = FontFactory.GetFont("Segoe UI", 9, BaseColor.WHITE);

            Font boldFont2 = new Font(Font.FontFamily.TIMES_ROMAN, 9, Font.BOLD, BaseColor.BLACK);
            Font boldFont22 = new Font(Font.FontFamily.TIMES_ROMAN, 9, Font.BOLD, BaseColor.WHITE);
            Font normalFont2 = new Font(Font.FontFamily.TIMES_ROMAN, 9, Font.ITALIC, BaseColor.BLACK);


            TABLEActImmo.TotalWidth = 500f;
            TABLEActImmo.PaddingTop = 5f;
            TABLEActImmo.LockedWidth = true;
            float[] widthstablequalital = new float[] { 1f, 5f, 1.5f, 1.5f, 1.5f, 1.5f };
            TABLEActImmo.SetWidths(widthstablequalital);
            TABLEActImmo.HorizontalAlignment = 1;

            var idDossier1 = Request.QueryString["id"].Trim();
            //var idDossier1 = Session["id_dossier"].ToString();
            //if (Session["id_dossier"] == null) Response.Redirect("~/Scoring/Connexion.aspx");
            //else idDossier = Session["id_dossier"].ToString();
            //Session.Add("id_dossier", idDossier);
            string modele = "";
            var elements = _service.InfoDossier(idDossier1);

            PdfPCell cell1qualital = new PdfPCell(new Phrase("Ref", boldFont2));
            cell1qualital.Rowspan = 2;
            cell1qualital.HorizontalAlignment = 1;
            cell1qualital.UseVariableBorders = true;
            cell1qualital.BorderWidth = 1;
            cell1qualital.BackgroundColor = new BaseColor(228, 235, 245);
            cell1qualital.BorderColor = new BaseColor(208, 211, 212);
            cell1qualital.PaddingBottom = 5f;
            TABLEActImmo.AddCell(cell1qualital);

            PdfPCell cell1qualital1 = new PdfPCell(new Phrase("ACTIF", boldFont2));
            cell1qualital1.Rowspan = 2;
            cell1qualital1.HorizontalAlignment = 1;
            cell1qualital1.UseVariableBorders = true;
            cell1qualital1.BorderWidth = 1;
            cell1qualital1.BackgroundColor = new BaseColor(228, 235, 245);
            cell1qualital1.BorderColor = new BaseColor(208, 211, 212);
            cell1qualital1.PaddingBottom = 5f;
            TABLEActImmo.AddCell(cell1qualital1);

            PdfPCell cell1qualital2 = new PdfPCell(new Phrase("Exercice N", boldFont2));
            cell1qualital2.Colspan = 3;
            cell1qualital2.HorizontalAlignment = 1;
            cell1qualital2.UseVariableBorders = true;
            cell1qualital2.BorderWidth = 1;
            cell1qualital2.BackgroundColor = new BaseColor(228, 235, 245);
            cell1qualital2.BorderColor = new BaseColor(208, 211, 212);
            cell1qualital2.PaddingBottom = 5f;
            TABLEActImmo.AddCell(cell1qualital2);

            PdfPCell cell1qualital3 = new PdfPCell(new Phrase("Exercice N-1", boldFont2));
            //cell1qualital3.Rowspan = 2;
            cell1qualital3.HorizontalAlignment = 1;
            cell1qualital3.UseVariableBorders = true;
            cell1qualital3.BorderWidth = 1;
            cell1qualital3.BackgroundColor = new BaseColor(228, 235, 245);
            cell1qualital3.BorderColor = new BaseColor(208, 211, 212);
            cell1qualital3.PaddingBottom = 5f;
            TABLEActImmo.AddCell(cell1qualital3);

            PdfPCell cell1qualital4 = new PdfPCell(new Phrase("BRUT", boldFont2));
            //cell1qualital4.Rowspan = 2;
            cell1qualital4.HorizontalAlignment = 1;
            cell1qualital4.UseVariableBorders = true;
            cell1qualital4.BorderWidth = 1;
            cell1qualital4.BackgroundColor = new BaseColor(228, 235, 245);
            cell1qualital4.BorderColor = new BaseColor(208, 211, 212);
            cell1qualital4.PaddingBottom = 5f;
            TABLEActImmo.AddCell(cell1qualital4);

            PdfPCell cell1qualital5 = new PdfPCell(new Phrase("Amort. / Prov.", boldFont2));
            //cell1qualital4.Rowspan = 2;
            cell1qualital5.HorizontalAlignment = 1;
            cell1qualital5.UseVariableBorders = true;
            cell1qualital5.BorderWidth = 1;
            cell1qualital5.BackgroundColor = new BaseColor(228, 235, 245);
            cell1qualital5.BorderColor = new BaseColor(208, 211, 212);
            cell1qualital5.PaddingBottom = 5f;
            TABLEActImmo.AddCell(cell1qualital5);

            PdfPCell cell1qualital6 = new PdfPCell(new Phrase("Net", boldFont2));
            //cell1qualital4.Rowspan = 2;
            cell1qualital6.HorizontalAlignment = 1;
            cell1qualital6.UseVariableBorders = true;
            cell1qualital6.BorderWidth = 1;
            cell1qualital6.BackgroundColor = new BaseColor(228, 235, 245);
            cell1qualital6.BorderColor = new BaseColor(208, 211, 212);
            cell1qualital6.PaddingBottom = 5f;
            TABLEActImmo.AddCell(cell1qualital6);

            PdfPCell cell1qualital7 = new PdfPCell(new Phrase("Net", boldFont2));
            //cell1qualital4.Rowspan = 2;
            cell1qualital7.HorizontalAlignment = 1;
            cell1qualital7.UseVariableBorders = true;
            cell1qualital7.BorderWidth = 1;
            cell1qualital7.BackgroundColor = new BaseColor(228, 235, 245);
            cell1qualital7.BorderColor = new BaseColor(208, 211, 212);
            cell1qualital7.PaddingBottom = 5f;
            TABLEActImmo.AddCell(cell1qualital7);


            var listes = _service.LIST_PS_SCOR_ETATBILAN_AM(annee, idDossier1);
            var i1 = 0;
            decimal tot = 0;
            foreach (var lr in listes)
            {
                PdfPCell cell2qualital8 = new PdfPCell(new Phrase(lr.REF, boldFont2));
                cell2qualital8.PaddingLeft = 10f;
                cell2qualital8.PaddingTop = 2f;
                cell2qualital8.PaddingBottom = 5f;
                cell2qualital8.UseVariableBorders = true;
                cell2qualital8.BorderWidthBottom = 1;
                cell2qualital8.BorderWidthLeft = 1;
                cell2qualital8.BorderWidthTop = 1;
                cell2qualital8.BorderColor = new BaseColor(208, 211, 212);
                cell2qualital8.BorderWidthRight = 1;
                TABLEActImmo.AddCell(cell2qualital8);

                PdfPCell cell2qualital9 = new PdfPCell(new Phrase(lr.RUBR_ETAT_LIBELLE, boldFont2));
                cell2qualital9.PaddingLeft = 10f;
                cell2qualital9.PaddingTop = 2f;
                cell2qualital9.PaddingBottom = 5f;
                cell2qualital9.UseVariableBorders = true;
                cell2qualital9.BorderWidthBottom = 1;
                cell2qualital9.BorderWidthLeft = 1;
                cell2qualital9.BorderWidthTop = 1;
                cell2qualital9.BorderColor = new BaseColor(208, 211, 212);
                cell2qualital9.BorderWidthRight = 1;
                TABLEActImmo.AddCell(cell2qualital9);

                PdfPCell cell2qualital10 = new PdfPCell(new Phrase(formatMillier((lr.VALEUR_B_AMMORT + lr.VALEUR_B_DETAIL).ToString()), normalFont2));
                cell2qualital10.PaddingRight = 5f;
                cell2qualital10.HorizontalAlignment = 2;
                cell2qualital10.PaddingTop = 2f;
                cell2qualital10.PaddingBottom = 5f;
                cell2qualital10.UseVariableBorders = true;
                cell2qualital10.BorderWidthBottom = 1;
                cell2qualital10.BorderWidthLeft = 1;
                cell2qualital10.BorderWidthTop = 1;
                cell2qualital10.BorderColor = new BaseColor(208, 211, 212);
                cell2qualital10.BorderWidthRight = 1;
                TABLEActImmo.AddCell(cell2qualital10);

                PdfPCell cell2qualital11 = new PdfPCell(new Phrase(formatMillier(lr.VALEUR_B_AMMORT.ToString()), normalFont2));
                cell2qualital11.PaddingRight = 5f;
                cell2qualital11.HorizontalAlignment = 2;
                cell2qualital11.PaddingTop = 2f;
                cell2qualital11.PaddingBottom = 5f;
                cell2qualital11.UseVariableBorders = true;
                cell2qualital11.BorderWidthBottom = 1;
                cell2qualital11.BorderWidthLeft = 1;
                cell2qualital11.BorderWidthTop = 1;
                cell2qualital11.BorderColor = new BaseColor(208, 211, 212);
                cell2qualital11.BorderWidthRight = 1;
                TABLEActImmo.AddCell(cell2qualital11);

                PdfPCell cell2qualital12 = new PdfPCell(new Phrase(formatMillier(lr.VALEUR_B_DETAIL.ToString()), normalFont2));
                cell2qualital12.PaddingRight = 5f;
                cell2qualital12.HorizontalAlignment = 2;
                cell2qualital12.PaddingTop = 2f;
                cell2qualital12.PaddingBottom = 5f;
                cell2qualital12.UseVariableBorders = true;
                cell2qualital12.BorderWidthBottom = 1;
                cell2qualital12.BorderWidthLeft = 1;
                cell2qualital12.BorderWidthTop = 1;
                cell2qualital12.BorderColor = new BaseColor(208, 211, 212);
                cell2qualital12.BorderWidthRight = 1;
                TABLEActImmo.AddCell(cell2qualital12);

                PdfPCell cell2qualital13 = new PdfPCell(new Phrase(formatMillier(lr.VALEUR_B_N_1.ToString()), normalFont2));
                cell2qualital13.PaddingRight = 5f;
                cell2qualital13.HorizontalAlignment = 2;
                cell2qualital13.PaddingTop = 2f;
                cell2qualital13.PaddingBottom = 5f;
                cell2qualital13.UseVariableBorders = true;
                cell2qualital13.BorderWidthBottom = 1;
                cell2qualital13.BorderWidthLeft = 1;
                cell2qualital13.BorderWidthTop = 1;
                cell2qualital13.BorderColor = new BaseColor(208, 211, 212);
                cell2qualital13.BorderWidthRight = 1;
                TABLEActImmo.AddCell(cell2qualital13);
                //tot = tot + question.NOTE_QUESTION;
                // ITERATATION REPONSES
                //s += "<div class='ln_reponse col-md-6'> <select  onchange=\"combo007($(this),'C')\"  class='checkboxx' id='selec" + i + "' onchange='get_docs()'>";

                //PdfPCell cell5qualital = new PdfPCell(new Phrase("vide", boldFont22));
                //cell5qualital.Colspan = 2;
                //cell5qualital.HorizontalAlignment = 1;
                //cell5qualital.UseVariableBorders = true;
                //cell5qualital.BorderWidth = 1;
                //cell5qualital.BackgroundColor = new BaseColor(255, 255, 255);
                //cell5qualital.BorderColor = new BaseColor(255, 255, 255);
                //cell5qualital.PaddingBottom = 5f;
                //tablequalital.AddCell(cell5qualital);
            }
        }
        public void PS_SCOR_ETATBILAN_CHARGE1(string annee)
        {
            var palatino = FontFactory.GetFont("palatino linotype", BaseFont.CP1252, BaseFont.EMBEDDED, 9, Font.BOLD);
            var boldFont = FontFactory.GetFont("palatino linotype", BaseFont.CP1252, BaseFont.EMBEDDED, 12, Font.BOLD);
            var italicfont = FontFactory.GetFont("palatino linotype", BaseFont.CP1252, BaseFont.EMBEDDED, 9, Font.ITALIC);
            var boldFontTitle = FontFactory.GetFont("palatino linotype", BaseFont.CP1252, BaseFont.EMBEDDED, 14, Font.BOLD);
            var titleFont = FontFactory.GetFont("Segoe UI", 9, BaseColor.WHITE);

            Font boldFont2 = new Font(Font.FontFamily.TIMES_ROMAN, 9, Font.BOLD, BaseColor.BLACK);
            Font boldFont22 = new Font(Font.FontFamily.TIMES_ROMAN, 9, Font.BOLD, BaseColor.WHITE);
            Font normalFont2 = new Font(Font.FontFamily.TIMES_ROMAN, 9, Font.ITALIC, BaseColor.BLACK);


            TABLECrCharge1.TotalWidth = 500f;
            TABLECrCharge1.PaddingTop = 5f;
            TABLECrCharge1.LockedWidth = true;
            float[] widthstablequalital = new float[] { 1f, 8f, 2f, 2f };
            TABLECrCharge1.SetWidths(widthstablequalital);
            TABLECrCharge1.HorizontalAlignment = 1;

            var idDossier1 = Request.QueryString["id"].Trim();
            //var idDossier1 = Session["id_dossier"].ToString();
            //if (Session["id_dossier"] == null) Response.Redirect("~/Scoring/Connexion.aspx");
            //else idDossier = Session["id_dossier"].ToString();
            //Session.Add("id_dossier", idDossier);
            string modele = "";
            var elements = _service.InfoDossier(idDossier1);

            PdfPCell cell1qualital = new PdfPCell(new Phrase("Ref", boldFont2));
            //cell1qualital.Rowspan = 2;
            cell1qualital.HorizontalAlignment = 1;
            cell1qualital.UseVariableBorders = true;
            cell1qualital.BorderWidth = 1;
            cell1qualital.BackgroundColor = new BaseColor(228, 235, 245);
            cell1qualital.BorderColor = new BaseColor(208, 211, 212);
            cell1qualital.PaddingBottom = 5f;
            TABLECrCharge1.AddCell(cell1qualital);

            PdfPCell cell1qualital1 = new PdfPCell(new Phrase("CHARGES ( 1ère partie )", boldFont2));
            //cell1qualital1.Rowspan = 2;
            cell1qualital1.HorizontalAlignment = 1;
            cell1qualital1.UseVariableBorders = true;
            cell1qualital1.BorderWidth = 1;
            cell1qualital1.BackgroundColor = new BaseColor(228, 235, 245);
            cell1qualital1.BorderColor = new BaseColor(208, 211, 212);
            cell1qualital1.PaddingBottom = 5f;
            TABLECrCharge1.AddCell(cell1qualital1);

            PdfPCell cell1qualital2 = new PdfPCell(new Phrase("Exercice N", boldFont2));
            //cell1qualital2.Colspan = 3;
            cell1qualital2.HorizontalAlignment = 1;
            cell1qualital2.UseVariableBorders = true;
            cell1qualital2.BorderWidth = 1;
            cell1qualital2.BackgroundColor = new BaseColor(228, 235, 245);
            cell1qualital2.BorderColor = new BaseColor(208, 211, 212);
            cell1qualital2.PaddingBottom = 5f;
            TABLECrCharge1.AddCell(cell1qualital2);

            PdfPCell cell1qualital3 = new PdfPCell(new Phrase("Exercice N-1", boldFont2));
            //cell1qualital3.Rowspan = 2;
            cell1qualital3.HorizontalAlignment = 1;
            cell1qualital3.UseVariableBorders = true;
            cell1qualital3.BorderWidth = 1;
            cell1qualital3.BackgroundColor = new BaseColor(228, 235, 245);
            cell1qualital3.BorderColor = new BaseColor(208, 211, 212);
            cell1qualital3.PaddingBottom = 5f;
            TABLECrCharge1.AddCell(cell1qualital3);


            var listes = _service.LIST_PS_SCOR_ETATBILAN_CHARGE1(annee, idDossier1);
            var i1 = 0;
            decimal tot = 0;
            foreach (var lr in listes)
            {
                PdfPCell cell2qualital8 = new PdfPCell(new Phrase(lr.REF, boldFont2));
                cell2qualital8.PaddingLeft = 10f;
                cell2qualital8.PaddingTop = 2f;
                cell2qualital8.PaddingBottom = 5f;
                cell2qualital8.UseVariableBorders = true;
                cell2qualital8.BorderWidthBottom = 1;
                cell2qualital8.BorderWidthLeft = 1;
                cell2qualital8.BorderWidthTop = 1;
                cell2qualital8.BorderColor = new BaseColor(208, 211, 212);
                cell2qualital8.BorderWidthRight = 1;
                TABLECrCharge1.AddCell(cell2qualital8);

                PdfPCell cell2qualital9 = new PdfPCell(new Phrase(lr.RUBR_ETAT_LIBELLE, boldFont2));
                cell2qualital9.PaddingLeft = 10f;
                cell2qualital9.PaddingTop = 2f;
                cell2qualital9.PaddingBottom = 5f;
                cell2qualital9.UseVariableBorders = true;
                cell2qualital9.BorderWidthBottom = 1;
                cell2qualital9.BorderWidthLeft = 1;
                cell2qualital9.BorderWidthTop = 1;
                cell2qualital9.BorderColor = new BaseColor(208, 211, 212);
                cell2qualital9.BorderWidthRight = 1;
                TABLECrCharge1.AddCell(cell2qualital9);

                PdfPCell cell2qualital12 = new PdfPCell(new Phrase(formatMillier(lr.VALEUR_CR_DETAIL.ToString()), normalFont2));
                cell2qualital12.PaddingRight = 5f;
                cell2qualital12.HorizontalAlignment = 2;
                cell2qualital12.PaddingTop = 2f;
                cell2qualital12.PaddingBottom = 5f;
                cell2qualital12.UseVariableBorders = true;
                cell2qualital12.BorderWidthBottom = 1;
                cell2qualital12.BorderWidthLeft = 1;
                cell2qualital12.BorderWidthTop = 1;
                cell2qualital12.BorderColor = new BaseColor(208, 211, 212);
                cell2qualital12.BorderWidthRight = 1;
                TABLECrCharge1.AddCell(cell2qualital12);

                PdfPCell cell2qualital11 = new PdfPCell(new Phrase(formatMillier(lr.VALEUR_B_AMMORT.ToString()), normalFont2));
                cell2qualital11.PaddingRight = 5f;
                cell2qualital11.HorizontalAlignment = 2;
                cell2qualital11.PaddingTop = 2f;
                cell2qualital11.PaddingBottom = 5f;
                cell2qualital11.UseVariableBorders = true;
                cell2qualital11.BorderWidthBottom = 1;
                cell2qualital11.BorderWidthLeft = 1;
                cell2qualital11.BorderWidthTop = 1;
                cell2qualital11.BorderColor = new BaseColor(208, 211, 212);
                cell2qualital11.BorderWidthRight = 1;
                TABLECrCharge1.AddCell(cell2qualital11);



                //tot = tot + question.NOTE_QUESTION;
                // ITERATATION REPONSES
                //s += "<div class='ln_reponse col-md-6'> <select  onchange=\"combo007($(this),'C')\"  class='checkboxx' id='selec" + i + "' onchange='get_docs()'>";

                //PdfPCell cell5qualital = new PdfPCell(new Phrase("vide", boldFont22));
                //cell5qualital.Colspan = 2;
                //cell5qualital.HorizontalAlignment = 1;
                //cell5qualital.UseVariableBorders = true;
                //cell5qualital.BorderWidth = 1;
                //cell5qualital.BackgroundColor = new BaseColor(255, 255, 255);
                //cell5qualital.BorderColor = new BaseColor(255, 255, 255);
                //cell5qualital.PaddingBottom = 5f;
                //tablequalital.AddCell(cell5qualital);
            }
        }
        public void PS_SCOR_ETATBILAN_CHARGE2(string annee)
        {
            var palatino = FontFactory.GetFont("palatino linotype", BaseFont.CP1252, BaseFont.EMBEDDED, 9, Font.BOLD);
            var boldFont = FontFactory.GetFont("palatino linotype", BaseFont.CP1252, BaseFont.EMBEDDED, 12, Font.BOLD);
            var italicfont = FontFactory.GetFont("palatino linotype", BaseFont.CP1252, BaseFont.EMBEDDED, 9, Font.ITALIC);
            var boldFontTitle = FontFactory.GetFont("palatino linotype", BaseFont.CP1252, BaseFont.EMBEDDED, 14, Font.BOLD);
            var titleFont = FontFactory.GetFont("Segoe UI", 9, BaseColor.WHITE);

            Font boldFont2 = new Font(Font.FontFamily.TIMES_ROMAN, 9, Font.BOLD, BaseColor.BLACK);
            Font boldFont22 = new Font(Font.FontFamily.TIMES_ROMAN, 9, Font.BOLD, BaseColor.WHITE);
            Font normalFont2 = new Font(Font.FontFamily.TIMES_ROMAN, 9, Font.ITALIC, BaseColor.BLACK);


            TABLECrCharge2.TotalWidth = 500f;
            TABLECrCharge2.PaddingTop = 5f;
            TABLECrCharge2.LockedWidth = true;
            float[] widthstablequalital = new float[] { 1f, 8f, 2f, 2f };
            TABLECrCharge2.SetWidths(widthstablequalital);
            TABLECrCharge2.HorizontalAlignment = 1;

            var idDossier1 = Request.QueryString["id"].Trim();
            //var idDossier1 = Session["id_dossier"].ToString();
            //if (Session["id_dossier"] == null) Response.Redirect("~/Scoring/Connexion.aspx");
            //else idDossier = Session["id_dossier"].ToString();
            //Session.Add("id_dossier", idDossier);
            string modele = "";
            var elements = _service.InfoDossier(idDossier1);

            PdfPCell cell1qualital = new PdfPCell(new Phrase("Ref", boldFont2));
            //cell1qualital.Rowspan = 2;
            cell1qualital.HorizontalAlignment = 1;
            cell1qualital.UseVariableBorders = true;
            cell1qualital.BorderWidth = 1;
            cell1qualital.BackgroundColor = new BaseColor(228, 235, 245);
            cell1qualital.BorderColor = new BaseColor(208, 211, 212);
            cell1qualital.PaddingBottom = 5f;
            TABLECrCharge2.AddCell(cell1qualital);

            PdfPCell cell1qualital1 = new PdfPCell(new Phrase("CHARGES ( 2ème partie )", boldFont2));
            //cell1qualital1.Rowspan = 2;
            cell1qualital1.HorizontalAlignment = 1;
            cell1qualital1.UseVariableBorders = true;
            cell1qualital1.BorderWidth = 1;
            cell1qualital1.BackgroundColor = new BaseColor(228, 235, 245);
            cell1qualital1.BorderColor = new BaseColor(208, 211, 212);
            cell1qualital1.PaddingBottom = 5f;
            TABLECrCharge2.AddCell(cell1qualital1);

            PdfPCell cell1qualital2 = new PdfPCell(new Phrase("Exercice N", boldFont2));
            //cell1qualital2.Colspan = 3;
            cell1qualital2.HorizontalAlignment = 1;
            cell1qualital2.UseVariableBorders = true;
            cell1qualital2.BorderWidth = 1;
            cell1qualital2.BackgroundColor = new BaseColor(228, 235, 245);
            cell1qualital2.BorderColor = new BaseColor(208, 211, 212);
            cell1qualital2.PaddingBottom = 5f;
            TABLECrCharge2.AddCell(cell1qualital2);

            PdfPCell cell1qualital3 = new PdfPCell(new Phrase("Exercice N-1", boldFont2));
            //cell1qualital3.Rowspan = 2;
            cell1qualital3.HorizontalAlignment = 1;
            cell1qualital3.UseVariableBorders = true;
            cell1qualital3.BorderWidth = 1;
            cell1qualital3.BackgroundColor = new BaseColor(228, 235, 245);
            cell1qualital3.BorderColor = new BaseColor(208, 211, 212);
            cell1qualital3.PaddingBottom = 5f;
            TABLECrCharge2.AddCell(cell1qualital3);


            var listes = _service.LIST_SCOR_ETATBILAN_CHARGE2(annee, idDossier1);
            var i1 = 0;
            decimal tot = 0;
            foreach (var lr in listes)
            {
                PdfPCell cell2qualital8 = new PdfPCell(new Phrase(lr.REF, boldFont2));
                cell2qualital8.PaddingLeft = 10f;
                cell2qualital8.PaddingTop = 2f;
                cell2qualital8.PaddingBottom = 5f;
                cell2qualital8.UseVariableBorders = true;
                cell2qualital8.BorderWidthBottom = 1;
                cell2qualital8.BorderWidthLeft = 1;
                cell2qualital8.BorderWidthTop = 1;
                cell2qualital8.BorderColor = new BaseColor(208, 211, 212);
                cell2qualital8.BorderWidthRight = 1;
                TABLECrCharge2.AddCell(cell2qualital8);

                PdfPCell cell2qualital9 = new PdfPCell(new Phrase(lr.RUBR_ETAT_LIBELLE, boldFont2));
                cell2qualital9.PaddingLeft = 10f;
                cell2qualital9.PaddingTop = 2f;
                cell2qualital9.PaddingBottom = 5f;
                cell2qualital9.UseVariableBorders = true;
                cell2qualital9.BorderWidthBottom = 1;
                cell2qualital9.BorderWidthLeft = 1;
                cell2qualital9.BorderWidthTop = 1;
                cell2qualital9.BorderColor = new BaseColor(208, 211, 212);
                cell2qualital9.BorderWidthRight = 1;
                TABLECrCharge2.AddCell(cell2qualital9);

                PdfPCell cell2qualital12 = new PdfPCell(new Phrase(formatMillier(lr.VALEUR_CR_DETAIL.ToString()), normalFont2));
                cell2qualital12.PaddingRight = 5f;
                cell2qualital12.HorizontalAlignment = 2;
                cell2qualital12.PaddingTop = 2f;
                cell2qualital12.PaddingBottom = 5f;
                cell2qualital12.UseVariableBorders = true;
                cell2qualital12.BorderWidthBottom = 1;
                cell2qualital12.BorderWidthLeft = 1;
                cell2qualital12.BorderWidthTop = 1;
                cell2qualital12.BorderColor = new BaseColor(208, 211, 212);
                cell2qualital12.BorderWidthRight = 1;
                TABLECrCharge2.AddCell(cell2qualital12);

                PdfPCell cell2qualital11 = new PdfPCell(new Phrase(formatMillier(lr.VALEUR_B_AMMORT.ToString()), normalFont2));
                cell2qualital11.PaddingRight = 5f;
                cell2qualital11.HorizontalAlignment = 2;
                cell2qualital11.PaddingTop = 2f;
                cell2qualital11.PaddingBottom = 5f;
                cell2qualital11.UseVariableBorders = true;
                cell2qualital11.BorderWidthBottom = 1;
                cell2qualital11.BorderWidthLeft = 1;
                cell2qualital11.BorderWidthTop = 1;
                cell2qualital11.BorderColor = new BaseColor(208, 211, 212);
                cell2qualital11.BorderWidthRight = 1;
                TABLECrCharge2.AddCell(cell2qualital11);



                //tot = tot + question.NOTE_QUESTION;
                // ITERATATION REPONSES
                //s += "<div class='ln_reponse col-md-6'> <select  onchange=\"combo007($(this),'C')\"  class='checkboxx' id='selec" + i + "' onchange='get_docs()'>";

                //PdfPCell cell5qualital = new PdfPCell(new Phrase("vide", boldFont22));
                //cell5qualital.Colspan = 2;
                //cell5qualital.HorizontalAlignment = 1;
                //cell5qualital.UseVariableBorders = true;
                //cell5qualital.BorderWidth = 1;
                //cell5qualital.BackgroundColor = new BaseColor(255, 255, 255);
                //cell5qualital.BorderColor = new BaseColor(255, 255, 255);
                //cell5qualital.PaddingBottom = 5f;
                //tablequalital.AddCell(cell5qualital);
            }
        }
        public void PS_SCOR_ETATBILAN_PC(string annee)
        {
            var palatino = FontFactory.GetFont("palatino linotype", BaseFont.CP1252, BaseFont.EMBEDDED, 9, Font.BOLD);
            var boldFont = FontFactory.GetFont("palatino linotype", BaseFont.CP1252, BaseFont.EMBEDDED, 12, Font.BOLD);
            var italicfont = FontFactory.GetFont("palatino linotype", BaseFont.CP1252, BaseFont.EMBEDDED, 9, Font.ITALIC);
            var boldFontTitle = FontFactory.GetFont("palatino linotype", BaseFont.CP1252, BaseFont.EMBEDDED, 14, Font.BOLD);
            var titleFont = FontFactory.GetFont("Segoe UI", 9, BaseColor.WHITE);

            Font boldFont2 = new Font(Font.FontFamily.TIMES_ROMAN, 9, Font.BOLD, BaseColor.BLACK);
            Font boldFont22 = new Font(Font.FontFamily.TIMES_ROMAN, 9, Font.BOLD, BaseColor.WHITE);
            Font normalFont2 = new Font(Font.FontFamily.TIMES_ROMAN, 9, Font.ITALIC, BaseColor.BLACK);


            TABLEPassCapi.TotalWidth = 500f;
            TABLEPassCapi.PaddingTop = 5f;
            TABLEPassCapi.LockedWidth = true;
            float[] widthstablequalital = new float[] { 1f, 8f, 2f, 2f };
            TABLEPassCapi.SetWidths(widthstablequalital);
            TABLEPassCapi.HorizontalAlignment = 1;

            var idDossier1 = Request.QueryString["id"].Trim();
            //var idDossier1 = Session["id_dossier"].ToString();
            //if (Session["id_dossier"] == null) Response.Redirect("~/Scoring/Connexion.aspx");
            //else idDossier = Session["id_dossier"].ToString();
            //Session.Add("id_dossier", idDossier);
            string modele = "";
            var elements = _service.InfoDossier(idDossier1);

            PdfPCell cell1qualital = new PdfPCell(new Phrase("Ref", boldFont2));
            //cell1qualital.Rowspan = 2;
            cell1qualital.HorizontalAlignment = 1;
            cell1qualital.UseVariableBorders = true;
            cell1qualital.BorderWidth = 1;
            cell1qualital.BackgroundColor = new BaseColor(228, 235, 245);
            cell1qualital.BorderColor = new BaseColor(208, 211, 212);
            cell1qualital.PaddingBottom = 5f;
            TABLEPassCapi.AddCell(cell1qualital);

            PdfPCell cell1qualital1 = new PdfPCell(new Phrase("PASSIFS (Avant Répartition)", boldFont2));
            //cell1qualital1.Rowspan = 2;
            cell1qualital1.HorizontalAlignment = 1;
            cell1qualital1.UseVariableBorders = true;
            cell1qualital1.BorderWidth = 1;
            cell1qualital1.BackgroundColor = new BaseColor(228, 235, 245);
            cell1qualital1.BorderColor = new BaseColor(208, 211, 212);
            cell1qualital1.PaddingBottom = 5f;
            TABLEPassCapi.AddCell(cell1qualital1);

            PdfPCell cell1qualital2 = new PdfPCell(new Phrase("Exercice N", boldFont2));
            //cell1qualital2.Colspan = 3;
            cell1qualital2.HorizontalAlignment = 1;
            cell1qualital2.UseVariableBorders = true;
            cell1qualital2.BorderWidth = 1;
            cell1qualital2.BackgroundColor = new BaseColor(228, 235, 245);
            cell1qualital2.BorderColor = new BaseColor(208, 211, 212);
            cell1qualital2.PaddingBottom = 5f;
            TABLEPassCapi.AddCell(cell1qualital2);

            PdfPCell cell1qualital3 = new PdfPCell(new Phrase("Exercice N-1", boldFont2));
            //cell1qualital3.Rowspan = 2;
            cell1qualital3.HorizontalAlignment = 1;
            cell1qualital3.UseVariableBorders = true;
            cell1qualital3.BorderWidth = 1;
            cell1qualital3.BackgroundColor = new BaseColor(228, 235, 245);
            cell1qualital3.BorderColor = new BaseColor(208, 211, 212);
            cell1qualital3.PaddingBottom = 5f;
            TABLEPassCapi.AddCell(cell1qualital3);


            var listes = _service.LIST_PS_SCOR_ETATBILAN_PC(annee, idDossier1);
            var i1 = 0;
            decimal tot = 0;
            foreach (var lr in listes)
            {
                PdfPCell cell2qualital8 = new PdfPCell(new Phrase(lr.REF, boldFont2));
                cell2qualital8.PaddingLeft = 10f;
                cell2qualital8.PaddingTop = 2f;
                cell2qualital8.PaddingBottom = 5f;
                cell2qualital8.UseVariableBorders = true;
                cell2qualital8.BorderWidthBottom = 1;
                cell2qualital8.BorderWidthLeft = 1;
                cell2qualital8.BorderWidthTop = 1;
                cell2qualital8.BorderColor = new BaseColor(208, 211, 212);
                cell2qualital8.BorderWidthRight = 1;
                TABLEPassCapi.AddCell(cell2qualital8);

                PdfPCell cell2qualital9 = new PdfPCell(new Phrase(lr.RUBR_ETAT_LIBELLE, boldFont2));
                cell2qualital9.PaddingLeft = 10f;
                cell2qualital9.PaddingTop = 2f;
                cell2qualital9.PaddingBottom = 5f;
                cell2qualital9.UseVariableBorders = true;
                cell2qualital9.BorderWidthBottom = 1;
                cell2qualital9.BorderWidthLeft = 1;
                cell2qualital9.BorderWidthTop = 1;
                cell2qualital9.BorderColor = new BaseColor(208, 211, 212);
                cell2qualital9.BorderWidthRight = 1;
                TABLEPassCapi.AddCell(cell2qualital9);

                PdfPCell cell2qualital12 = new PdfPCell(new Phrase(formatMillier(lr.VALEUR_B_DETAIL.ToString()), normalFont2));
                cell2qualital12.PaddingRight = 5f;
                cell2qualital12.HorizontalAlignment = 2;
                cell2qualital12.PaddingTop = 2f;
                cell2qualital12.PaddingBottom = 5f;
                cell2qualital12.UseVariableBorders = true;
                cell2qualital12.BorderWidthBottom = 1;
                cell2qualital12.BorderWidthLeft = 1;
                cell2qualital12.BorderWidthTop = 1;
                cell2qualital12.BorderColor = new BaseColor(208, 211, 212);
                cell2qualital12.BorderWidthRight = 1;
                TABLEPassCapi.AddCell(cell2qualital12);

                PdfPCell cell2qualital11 = new PdfPCell(new Phrase(formatMillier(lr.VALEUR_B_N_1.ToString()), normalFont2));
                cell2qualital11.PaddingRight = 5f;
                cell2qualital11.HorizontalAlignment = 2;
                cell2qualital11.PaddingTop = 2f;
                cell2qualital11.PaddingBottom = 5f;
                cell2qualital11.UseVariableBorders = true;
                cell2qualital11.BorderWidthBottom = 1;
                cell2qualital11.BorderWidthLeft = 1;
                cell2qualital11.BorderWidthTop = 1;
                cell2qualital11.BorderColor = new BaseColor(208, 211, 212);
                cell2qualital11.BorderWidthRight = 1;
                TABLEPassCapi.AddCell(cell2qualital11);



                //tot = tot + question.NOTE_QUESTION;
                // ITERATATION REPONSES
                //s += "<div class='ln_reponse col-md-6'> <select  onchange=\"combo007($(this),'C')\"  class='checkboxx' id='selec" + i + "' onchange='get_docs()'>";

                //PdfPCell cell5qualital = new PdfPCell(new Phrase("vide", boldFont22));
                //cell5qualital.Colspan = 2;
                //cell5qualital.HorizontalAlignment = 1;
                //cell5qualital.UseVariableBorders = true;
                //cell5qualital.BorderWidth = 1;
                //cell5qualital.BackgroundColor = new BaseColor(255, 255, 255);
                //cell5qualital.BorderColor = new BaseColor(255, 255, 255);
                //cell5qualital.PaddingBottom = 5f;
                //tablequalital.AddCell(cell5qualital);
            }
        }
        public void PS_SCOR_ETATBILAN_PCIRCUL(string annee)
        {
            var palatino = FontFactory.GetFont("palatino linotype", BaseFont.CP1252, BaseFont.EMBEDDED, 9, Font.BOLD);
            var boldFont = FontFactory.GetFont("palatino linotype", BaseFont.CP1252, BaseFont.EMBEDDED, 12, Font.BOLD);
            var italicfont = FontFactory.GetFont("palatino linotype", BaseFont.CP1252, BaseFont.EMBEDDED, 9, Font.ITALIC);
            var boldFontTitle = FontFactory.GetFont("palatino linotype", BaseFont.CP1252, BaseFont.EMBEDDED, 14, Font.BOLD);
            var titleFont = FontFactory.GetFont("Segoe UI", 9, BaseColor.WHITE);

            Font boldFont2 = new Font(Font.FontFamily.TIMES_ROMAN, 9, Font.BOLD, BaseColor.BLACK);
            Font boldFont22 = new Font(Font.FontFamily.TIMES_ROMAN, 9, Font.BOLD, BaseColor.WHITE);
            Font normalFont2 = new Font(Font.FontFamily.TIMES_ROMAN, 9, Font.ITALIC, BaseColor.BLACK);


            TABLEPasscircul.TotalWidth = 500f;
            TABLEPasscircul.PaddingTop = 5f;
            TABLEPasscircul.LockedWidth = true;
            float[] widthstablequalital = new float[] { 1f, 8f, 2f, 2f };
            TABLEPasscircul.SetWidths(widthstablequalital);
            TABLEPasscircul.HorizontalAlignment = 1;

            var idDossier1 = Request.QueryString["id"].Trim();
            //var idDossier1 = Session["id_dossier"].ToString();
            //if (Session["id_dossier"] == null) Response.Redirect("~/Scoring/Connexion.aspx");
            //else idDossier = Session["id_dossier"].ToString();
            //Session.Add("id_dossier", idDossier);
            string modele = "";
            var elements = _service.InfoDossier(idDossier1);

            PdfPCell cell1qualital = new PdfPCell(new Phrase("Ref", boldFont2));
            //cell1qualital.Rowspan = 2;
            cell1qualital.HorizontalAlignment = 1;
            cell1qualital.UseVariableBorders = true;
            cell1qualital.BorderWidth = 1;
            cell1qualital.BackgroundColor = new BaseColor(228, 235, 245);
            cell1qualital.BorderColor = new BaseColor(208, 211, 212);
            cell1qualital.PaddingBottom = 5f;
            TABLEPasscircul.AddCell(cell1qualital);

            PdfPCell cell1qualital1 = new PdfPCell(new Phrase("PASSIFS (Avant Répartition)", boldFont2));
            //cell1qualital1.Rowspan = 2;
            cell1qualital1.HorizontalAlignment = 1;
            cell1qualital1.UseVariableBorders = true;
            cell1qualital1.BorderWidth = 1;
            cell1qualital1.BackgroundColor = new BaseColor(228, 235, 245);
            cell1qualital1.BorderColor = new BaseColor(208, 211, 212);
            cell1qualital1.PaddingBottom = 5f;
            TABLEPasscircul.AddCell(cell1qualital1);

            PdfPCell cell1qualital2 = new PdfPCell(new Phrase("Exercice N", boldFont2));
            //cell1qualital2.Colspan = 3;
            cell1qualital2.HorizontalAlignment = 1;
            cell1qualital2.UseVariableBorders = true;
            cell1qualital2.BorderWidth = 1;
            cell1qualital2.BackgroundColor = new BaseColor(228, 235, 245);
            cell1qualital2.BorderColor = new BaseColor(208, 211, 212);
            cell1qualital2.PaddingBottom = 5f;
            TABLEPasscircul.AddCell(cell1qualital2);

            PdfPCell cell1qualital3 = new PdfPCell(new Phrase("Exercice N-1", boldFont2));
            //cell1qualital3.Rowspan = 2;
            cell1qualital3.HorizontalAlignment = 1;
            cell1qualital3.UseVariableBorders = true;
            cell1qualital3.BorderWidth = 1;
            cell1qualital3.BackgroundColor = new BaseColor(228, 235, 245);
            cell1qualital3.BorderColor = new BaseColor(208, 211, 212);
            cell1qualital3.PaddingBottom = 5f;
            TABLEPasscircul.AddCell(cell1qualital3);


            var listes = _service.LIST_PS_SCOR_ETATBILAN_PC(annee, idDossier1);
            var i1 = 0;
            decimal tot = 0;
            foreach (var lr in listes)
            {
                PdfPCell cell2qualital8 = new PdfPCell(new Phrase(lr.REF, boldFont2));
                cell2qualital8.PaddingLeft = 10f;
                cell2qualital8.PaddingTop = 2f;
                cell2qualital8.PaddingBottom = 5f;
                cell2qualital8.UseVariableBorders = true;
                cell2qualital8.BorderWidthBottom = 1;
                cell2qualital8.BorderWidthLeft = 1;
                cell2qualital8.BorderWidthTop = 1;
                cell2qualital8.BorderColor = new BaseColor(208, 211, 212);
                cell2qualital8.BorderWidthRight = 1;
                TABLEPasscircul.AddCell(cell2qualital8);

                PdfPCell cell2qualital9 = new PdfPCell(new Phrase(lr.RUBR_ETAT_LIBELLE, boldFont2));
                cell2qualital9.PaddingLeft = 10f;
                cell2qualital9.PaddingTop = 2f;
                cell2qualital9.PaddingBottom = 5f;
                cell2qualital9.UseVariableBorders = true;
                cell2qualital9.BorderWidthBottom = 1;
                cell2qualital9.BorderWidthLeft = 1;
                cell2qualital9.BorderWidthTop = 1;
                cell2qualital9.BorderColor = new BaseColor(208, 211, 212);
                cell2qualital9.BorderWidthRight = 1;
                TABLEPasscircul.AddCell(cell2qualital9);

                PdfPCell cell2qualital12 = new PdfPCell(new Phrase(formatMillier(lr.VALEUR_B_DETAIL.ToString()), normalFont2));
                cell2qualital12.PaddingRight = 5f;
                cell2qualital12.HorizontalAlignment = 2;
                cell2qualital12.PaddingTop = 2f;
                cell2qualital12.PaddingBottom = 5f;
                cell2qualital12.UseVariableBorders = true;
                cell2qualital12.BorderWidthBottom = 1;
                cell2qualital12.BorderWidthLeft = 1;
                cell2qualital12.BorderWidthTop = 1;
                cell2qualital12.BorderColor = new BaseColor(208, 211, 212);
                cell2qualital12.BorderWidthRight = 1;
                TABLEPasscircul.AddCell(cell2qualital12);

                PdfPCell cell2qualital11 = new PdfPCell(new Phrase(formatMillier(lr.VALEUR_B_N_1.ToString()), normalFont2));
                cell2qualital11.PaddingRight = 5f;
                cell2qualital11.HorizontalAlignment = 2;
                cell2qualital11.PaddingTop = 2f;
                cell2qualital11.PaddingBottom = 5f;
                cell2qualital11.UseVariableBorders = true;
                cell2qualital11.BorderWidthBottom = 1;
                cell2qualital11.BorderWidthLeft = 1;
                cell2qualital11.BorderWidthTop = 1;
                cell2qualital11.BorderColor = new BaseColor(208, 211, 212);
                cell2qualital11.BorderWidthRight = 1;
                TABLEPasscircul.AddCell(cell2qualital11);



                //tot = tot + question.NOTE_QUESTION;
                // ITERATATION REPONSES
                //s += "<div class='ln_reponse col-md-6'> <select  onchange=\"combo007($(this),'C')\"  class='checkboxx' id='selec" + i + "' onchange='get_docs()'>";

                //PdfPCell cell5qualital = new PdfPCell(new Phrase("vide", boldFont22));
                //cell5qualital.Colspan = 2;
                //cell5qualital.HorizontalAlignment = 1;
                //cell5qualital.UseVariableBorders = true;
                //cell5qualital.BorderWidth = 1;
                //cell5qualital.BackgroundColor = new BaseColor(255, 255, 255);
                //cell5qualital.BorderColor = new BaseColor(255, 255, 255);
                //cell5qualital.PaddingBottom = 5f;
                //tablequalital.AddCell(cell5qualital);
            }
        }
        public void PS_SCOR_ETATBILAN_PRODUIT1(string annee)
        {
            var palatino = FontFactory.GetFont("palatino linotype", BaseFont.CP1252, BaseFont.EMBEDDED, 9, Font.BOLD);
            var boldFont = FontFactory.GetFont("palatino linotype", BaseFont.CP1252, BaseFont.EMBEDDED, 12, Font.BOLD);
            var italicfont = FontFactory.GetFont("palatino linotype", BaseFont.CP1252, BaseFont.EMBEDDED, 9, Font.ITALIC);
            var boldFontTitle = FontFactory.GetFont("palatino linotype", BaseFont.CP1252, BaseFont.EMBEDDED, 14, Font.BOLD);
            var titleFont = FontFactory.GetFont("Segoe UI", 9, BaseColor.WHITE);

            Font boldFont2 = new Font(Font.FontFamily.TIMES_ROMAN, 9, Font.BOLD, BaseColor.BLACK);
            Font boldFont22 = new Font(Font.FontFamily.TIMES_ROMAN, 9, Font.BOLD, BaseColor.WHITE);
            Font normalFont2 = new Font(Font.FontFamily.TIMES_ROMAN, 9, Font.ITALIC, BaseColor.BLACK);


            TABLECrProdruit1.TotalWidth = 500f;
            TABLECrProdruit1.PaddingTop = 5f;
            TABLECrProdruit1.LockedWidth = true;
            float[] widthstablequalital = new float[] { 1f, 8f, 2f, 2f };
            TABLECrProdruit1.SetWidths(widthstablequalital);
            TABLECrProdruit1.HorizontalAlignment = 1;

            var idDossier1 = Request.QueryString["id"].Trim();
            //var idDossier1 = Session["id_dossier"].ToString();
            //if (Session["id_dossier"] == null) Response.Redirect("~/Scoring/Connexion.aspx");
            //else idDossier = Session["id_dossier"].ToString();
            //Session.Add("id_dossier", idDossier);
            string modele = "";
            var elements = _service.InfoDossier(idDossier1);

            PdfPCell cell1qualital = new PdfPCell(new Phrase("Ref", boldFont2));
            //cell1qualital.Rowspan = 2;
            cell1qualital.HorizontalAlignment = 1;
            cell1qualital.UseVariableBorders = true;
            cell1qualital.BorderWidth = 1;
            cell1qualital.BackgroundColor = new BaseColor(228, 235, 245);
            cell1qualital.BorderColor = new BaseColor(208, 211, 212);
            cell1qualital.PaddingBottom = 5f;
            TABLECrProdruit1.AddCell(cell1qualital);

            PdfPCell cell1qualital1 = new PdfPCell(new Phrase("PRODUITS ( 1ère partie )", boldFont2));
            //cell1qualital1.Rowspan = 2;
            cell1qualital1.HorizontalAlignment = 1;
            cell1qualital1.UseVariableBorders = true;
            cell1qualital1.BorderWidth = 1;
            cell1qualital1.BackgroundColor = new BaseColor(228, 235, 245);
            cell1qualital1.BorderColor = new BaseColor(208, 211, 212);
            cell1qualital1.PaddingBottom = 5f;
            TABLECrProdruit1.AddCell(cell1qualital1);

            PdfPCell cell1qualital2 = new PdfPCell(new Phrase("Exercice N", boldFont2));
            //cell1qualital2.Colspan = 3;
            cell1qualital2.HorizontalAlignment = 1;
            cell1qualital2.UseVariableBorders = true;
            cell1qualital2.BorderWidth = 1;
            cell1qualital2.BackgroundColor = new BaseColor(228, 235, 245);
            cell1qualital2.BorderColor = new BaseColor(208, 211, 212);
            cell1qualital2.PaddingBottom = 5f;
            TABLECrProdruit1.AddCell(cell1qualital2);

            PdfPCell cell1qualital3 = new PdfPCell(new Phrase("Exercice N-1", boldFont2));
            //cell1qualital3.Rowspan = 2;
            cell1qualital3.HorizontalAlignment = 1;
            cell1qualital3.UseVariableBorders = true;
            cell1qualital3.BorderWidth = 1;
            cell1qualital3.BackgroundColor = new BaseColor(228, 235, 245);
            cell1qualital3.BorderColor = new BaseColor(208, 211, 212);
            cell1qualital3.PaddingBottom = 5f;
            TABLECrProdruit1.AddCell(cell1qualital3);


            var listes = _service.LIST_PS_SCOR_ETATBILAN_PRODUIT1(annee, idDossier1);
            var i1 = 0;
            decimal tot = 0;
            foreach (var lr in listes)
            {
                PdfPCell cell2qualital8 = new PdfPCell(new Phrase(lr.REF, boldFont2));
                cell2qualital8.PaddingLeft = 10f;
                cell2qualital8.PaddingTop = 2f;
                cell2qualital8.PaddingBottom = 5f;
                cell2qualital8.UseVariableBorders = true;
                cell2qualital8.BorderWidthBottom = 1;
                cell2qualital8.BorderWidthLeft = 1;
                cell2qualital8.BorderWidthTop = 1;
                cell2qualital8.BorderColor = new BaseColor(208, 211, 212);
                cell2qualital8.BorderWidthRight = 1;
                TABLECrProdruit1.AddCell(cell2qualital8);

                PdfPCell cell2qualital9 = new PdfPCell(new Phrase(lr.RUBR_ETAT_LIBELLE, boldFont2));
                cell2qualital9.PaddingLeft = 10f;
                cell2qualital9.PaddingTop = 2f;
                cell2qualital9.PaddingBottom = 5f;
                cell2qualital9.UseVariableBorders = true;
                cell2qualital9.BorderWidthBottom = 1;
                cell2qualital9.BorderWidthLeft = 1;
                cell2qualital9.BorderWidthTop = 1;
                cell2qualital9.BorderColor = new BaseColor(208, 211, 212);
                cell2qualital9.BorderWidthRight = 1;
                TABLECrProdruit1.AddCell(cell2qualital9);

                PdfPCell cell2qualital12 = new PdfPCell(new Phrase(formatMillier(lr.VALEUR_CR_DETAIL.ToString()), normalFont2));
                cell2qualital12.PaddingRight = 5f;
                cell2qualital12.HorizontalAlignment = 2;
                cell2qualital12.PaddingTop = 2f;
                cell2qualital12.PaddingBottom = 5f;
                cell2qualital12.UseVariableBorders = true;
                cell2qualital12.BorderWidthBottom = 1;
                cell2qualital12.BorderWidthLeft = 1;
                cell2qualital12.BorderWidthTop = 1;
                cell2qualital12.BorderColor = new BaseColor(208, 211, 212);
                cell2qualital12.BorderWidthRight = 1;
                TABLECrProdruit1.AddCell(cell2qualital12);

                PdfPCell cell2qualital11 = new PdfPCell(new Phrase(formatMillier(lr.VALEUR_B_AMMORT.ToString()), normalFont2));
                cell2qualital11.PaddingRight = 5f;
                cell2qualital11.HorizontalAlignment = 2;
                cell2qualital11.PaddingTop = 2f;
                cell2qualital11.PaddingBottom = 5f;
                cell2qualital11.UseVariableBorders = true;
                cell2qualital11.BorderWidthBottom = 1;
                cell2qualital11.BorderWidthLeft = 1;
                cell2qualital11.BorderWidthTop = 1;
                cell2qualital11.BorderColor = new BaseColor(208, 211, 212);
                cell2qualital11.BorderWidthRight = 1;
                TABLECrProdruit1.AddCell(cell2qualital11);



                //tot = tot + question.NOTE_QUESTION;
                // ITERATATION REPONSES
                //s += "<div class='ln_reponse col-md-6'> <select  onchange=\"combo007($(this),'C')\"  class='checkboxx' id='selec" + i + "' onchange='get_docs()'>";

                //PdfPCell cell5qualital = new PdfPCell(new Phrase("vide", boldFont22));
                //cell5qualital.Colspan = 2;
                //cell5qualital.HorizontalAlignment = 1;
                //cell5qualital.UseVariableBorders = true;
                //cell5qualital.BorderWidth = 1;
                //cell5qualital.BackgroundColor = new BaseColor(255, 255, 255);
                //cell5qualital.BorderColor = new BaseColor(255, 255, 255);
                //cell5qualital.PaddingBottom = 5f;
                //tablequalital.AddCell(cell5qualital);
            }
        }
        public void PS_SCOR_ETATBILAN_PRODUIT2(string annee)
        {
            var palatino = FontFactory.GetFont("palatino linotype", BaseFont.CP1252, BaseFont.EMBEDDED, 9, Font.BOLD);
            var boldFont = FontFactory.GetFont("palatino linotype", BaseFont.CP1252, BaseFont.EMBEDDED, 12, Font.BOLD);
            var italicfont = FontFactory.GetFont("palatino linotype", BaseFont.CP1252, BaseFont.EMBEDDED, 9, Font.ITALIC);
            var boldFontTitle = FontFactory.GetFont("palatino linotype", BaseFont.CP1252, BaseFont.EMBEDDED, 14, Font.BOLD);
            var titleFont = FontFactory.GetFont("Segoe UI", 9, BaseColor.WHITE);

            Font boldFont2 = new Font(Font.FontFamily.TIMES_ROMAN, 9, Font.BOLD, BaseColor.BLACK);
            Font boldFont22 = new Font(Font.FontFamily.TIMES_ROMAN, 9, Font.BOLD, BaseColor.WHITE);
            Font normalFont2 = new Font(Font.FontFamily.TIMES_ROMAN, 9, Font.ITALIC, BaseColor.BLACK);


            TABLECrProdruit2.TotalWidth = 500f;
            TABLECrProdruit2.PaddingTop = 5f;
            TABLECrProdruit2.LockedWidth = true;
            float[] widthstablequalital = new float[] { 1f, 8f, 2f, 2f };
            TABLECrProdruit2.SetWidths(widthstablequalital);
            TABLECrProdruit2.HorizontalAlignment = 1;

            var idDossier1 = Request.QueryString["id"].Trim();
            //var idDossier1 = Session["id_dossier"].ToString();
            //if (Session["id_dossier"] == null) Response.Redirect("~/Scoring/Connexion.aspx");
            //else idDossier = Session["id_dossier"].ToString();
            //Session.Add("id_dossier", idDossier);
            string modele = "";
            var elements = _service.InfoDossier(idDossier1);

            PdfPCell cell1qualital = new PdfPCell(new Phrase("Ref", boldFont2));
            //cell1qualital.Rowspan = 2;
            cell1qualital.HorizontalAlignment = 1;
            cell1qualital.UseVariableBorders = true;
            cell1qualital.BorderWidth = 1;
            cell1qualital.BackgroundColor = new BaseColor(228, 235, 245);
            cell1qualital.BorderColor = new BaseColor(208, 211, 212);
            cell1qualital.PaddingBottom = 5f;
            TABLECrProdruit2.AddCell(cell1qualital);

            PdfPCell cell1qualital1 = new PdfPCell(new Phrase("PRODUITS ( 2ère partie )", boldFont2));
            //cell1qualital1.Rowspan = 2;
            cell1qualital1.HorizontalAlignment = 1;
            cell1qualital1.UseVariableBorders = true;
            cell1qualital1.BorderWidth = 1;
            cell1qualital1.BackgroundColor = new BaseColor(228, 235, 245);
            cell1qualital1.BorderColor = new BaseColor(208, 211, 212);
            cell1qualital1.PaddingBottom = 5f;
            TABLECrProdruit2.AddCell(cell1qualital1);

            PdfPCell cell1qualital2 = new PdfPCell(new Phrase("Exercice N", boldFont2));
            //cell1qualital2.Colspan = 3;
            cell1qualital2.HorizontalAlignment = 1;
            cell1qualital2.UseVariableBorders = true;
            cell1qualital2.BorderWidth = 1;
            cell1qualital2.BackgroundColor = new BaseColor(228, 235, 245);
            cell1qualital2.BorderColor = new BaseColor(208, 211, 212);
            cell1qualital2.PaddingBottom = 5f;
            TABLECrProdruit2.AddCell(cell1qualital2);

            PdfPCell cell1qualital3 = new PdfPCell(new Phrase("Exercice N-1", boldFont2));
            //cell1qualital3.Rowspan = 2;
            cell1qualital3.HorizontalAlignment = 1;
            cell1qualital3.UseVariableBorders = true;
            cell1qualital3.BorderWidth = 1;
            cell1qualital3.BackgroundColor = new BaseColor(228, 235, 245);
            cell1qualital3.BorderColor = new BaseColor(208, 211, 212);
            cell1qualital3.PaddingBottom = 5f;
            TABLECrProdruit2.AddCell(cell1qualital3);


            var listes = _service.LIST_PS_SCOR_ETATBILAN_PRODUIT2(annee, idDossier1);
            var i1 = 0;
            decimal tot = 0;
            foreach (var lr in listes)
            {
                PdfPCell cell2qualital8 = new PdfPCell(new Phrase(lr.REF, boldFont2));
                cell2qualital8.PaddingLeft = 10f;
                cell2qualital8.PaddingTop = 2f;
                cell2qualital8.PaddingBottom = 5f;
                cell2qualital8.UseVariableBorders = true;
                cell2qualital8.BorderWidthBottom = 1;
                cell2qualital8.BorderWidthLeft = 1;
                cell2qualital8.BorderWidthTop = 1;
                cell2qualital8.BorderColor = new BaseColor(208, 211, 212);
                cell2qualital8.BorderWidthRight = 1;
                TABLECrProdruit2.AddCell(cell2qualital8);

                PdfPCell cell2qualital9 = new PdfPCell(new Phrase(lr.RUBR_ETAT_LIBELLE, boldFont2));
                cell2qualital9.PaddingLeft = 10f;
                cell2qualital9.PaddingTop = 2f;
                cell2qualital9.PaddingBottom = 5f;
                cell2qualital9.UseVariableBorders = true;
                cell2qualital9.BorderWidthBottom = 1;
                cell2qualital9.BorderWidthLeft = 1;
                cell2qualital9.BorderWidthTop = 1;
                cell2qualital9.BorderColor = new BaseColor(208, 211, 212);
                cell2qualital9.BorderWidthRight = 1;
                TABLECrProdruit2.AddCell(cell2qualital9);

                PdfPCell cell2qualital12 = new PdfPCell(new Phrase(formatMillier(lr.VALEUR_CR_DETAIL.ToString()), normalFont2));
                cell2qualital12.PaddingRight = 5f;
                cell2qualital12.HorizontalAlignment = 2;
                cell2qualital12.PaddingTop = 2f;
                cell2qualital12.PaddingBottom = 5f;
                cell2qualital12.UseVariableBorders = true;
                cell2qualital12.BorderWidthBottom = 1;
                cell2qualital12.BorderWidthLeft = 1;
                cell2qualital12.BorderWidthTop = 1;
                cell2qualital12.BorderColor = new BaseColor(208, 211, 212);
                cell2qualital12.BorderWidthRight = 1;
                TABLECrProdruit2.AddCell(cell2qualital12);

                PdfPCell cell2qualital11 = new PdfPCell(new Phrase(formatMillier(lr.VALEUR_B_AMMORT.ToString()), normalFont2));
                cell2qualital11.PaddingRight = 5f;
                cell2qualital11.HorizontalAlignment = 2;
                cell2qualital11.PaddingTop = 2f;
                cell2qualital11.PaddingBottom = 5f;
                cell2qualital11.UseVariableBorders = true;
                cell2qualital11.BorderWidthBottom = 1;
                cell2qualital11.BorderWidthLeft = 1;
                cell2qualital11.BorderWidthTop = 1;
                cell2qualital11.BorderColor = new BaseColor(208, 211, 212);
                cell2qualital11.BorderWidthRight = 1;
                TABLECrProdruit2.AddCell(cell2qualital11);



                //tot = tot + question.NOTE_QUESTION;
                // ITERATATION REPONSES
                //s += "<div class='ln_reponse col-md-6'> <select  onchange=\"combo007($(this),'C')\"  class='checkboxx' id='selec" + i + "' onchange='get_docs()'>";

                //PdfPCell cell5qualital = new PdfPCell(new Phrase("vide", boldFont22));
                //cell5qualital.Colspan = 2;
                //cell5qualital.HorizontalAlignment = 1;
                //cell5qualital.UseVariableBorders = true;
                //cell5qualital.BorderWidth = 1;
                //cell5qualital.BackgroundColor = new BaseColor(255, 255, 255);
                //cell5qualital.BorderColor = new BaseColor(255, 255, 255);
                //cell5qualital.PaddingBottom = 5f;
                //tablequalital.AddCell(cell5qualital);
            }
        }
        /** AJOUTER SEPARATEUR DE MILLIERS **/
        public string formatMillier(string str)
        {

            char[] toto1 = str.ToCharArray();
            var toto2 = "";
            foreach (var t in toto1)
            {
                toto2 = t + toto2;
            }
            str = "";
            int cpt = 0;
            toto1 = toto2.ToCharArray();
            foreach (var t in toto1)
            {
                if (cpt == 3)
                {
                    str = t + " " + str;
                    cpt = 1;
                }
                else
                {
                    str = t + str;
                    cpt++;
                }
            }
            return str;
        }
    }
}