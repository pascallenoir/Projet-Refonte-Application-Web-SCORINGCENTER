using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ScoringCenter.Scoring
{
    public partial class Encours : System.Web.UI.Page
    {
        StringBuilder sb = new StringBuilder();
        Scoringws service = new Scoringws();
        private static string idModele = "";
        private static string ETCIV_MATRICULE = "";
        
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
            if (Session["id_scoring"] == null) Response.Redirect("~/Scoring/Connexion.aspx");
            else
            {
                if (Session["id_profil"] == null) Response.Redirect("~/Scoring/Connexion.aspx");

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
                    if (element.ID_DROIT.ToString().Trim() == "E")
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
            getInfoClient();
            getInfoDossier();
            AfficherTableau();
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
                        ETCIV_MATRICULE = v.ETCIV_MATRICULE;
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
                        else { SaiGroupe.Text = "Aucun"; IG.Visible = false; }
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
                    ETCIV_MATRICULE = v.ETCIV_MATRICULE;
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
                    else { SaiGroupe.Text = "Aucun"; IG.Visible = false; }
                }

                Session.Add("id_dossier", id_dossier);
            }

            DateTime DateComptable = service.SELECT_DATE_COMPTABLE("Encours", "").Where(DateC => DateC.DATE_CHARGEMENT != default(DateTime)).SingleOrDefault().DATE_CHARGEMENT;


            DateCompta.Text = DateComptable.ToString("dd/MM/yyyy hh:mm:ss");
        }

        private void getInfoDossier()
        {
            if (Session["id_dossier"] == null) Response.Redirect("~/Scoring/Connexion.aspx");

            // Session.Add("id_dossier", "1");
            var idDossier = Session["id_dossier"].ToString();
            Session.Add("id_dossier", idDossier);

            var elements = service.InfoDossier(idDossier);
            foreach (var dossier in elements)
            {
                ModeleNotation.Text = dossier.LIBELLE_MODELE;
                idModele = dossier.MODELE_DOSSIER;
            }

            /*Modèle de notation*/
            LblModeleNotation.Text = "Modèle de notation : " + AnalyseFinanciere.getModeleNotation(idDossier);
            if (AnalyseFinanciere.getADireExpert(idDossier)) LblADireExpert.Text = "A dire d'expert : OUI";
            else LblADireExpert.Text = "A dire d'expert : NON";
        }
        private void AfficherTableau()
        {
            sb.AppendLine("\n <div class=\"row push_entete\">");
            sb.AppendLine("\n <div class=\"ol-lg-12 col-sm-12 col-md-12 table-responsive\">");
            sb.AppendLine("\n <table id=\"datatable_bord\" class=\"table table-bordered table-hover scor_table1\">");
            sb.AppendLine("\n <thead class='table-heigth1'>");
            sb.AppendLine("\n <tr><th class=\"text-center\" colspan=\"6\">Encours</th> </tr>");
            sb.AppendLine("\n <tr>");
            sb.AppendLine("\n <th class=\"text-center\" >Intitulé</th>");
            sb.AppendLine("\n <th class=\"text-center\" >Compte</th>");
            sb.AppendLine("\n <th class=\"text-center\" >Solde</th>");
            sb.AppendLine("\n <th class=\"text-center\" >Autorisation de découvert</th>");
            sb.AppendLine("\n <th class=\"text-center\" >Échéance de l'autorisation</th>");
            sb.AppendLine("\n <th class=\"text-center\" >Devise</th>");
            sb.AppendLine("\n </tr>");
            sb.AppendLine("\n </thead>");
            sb.AppendLine("\n <tbody style=\"background-color: #FFFFFF;\">");
            //boucle 
            if (Session["id_dossier"] == null) Response.Redirect("~/Scoring/Connexion.aspx");
            var idDossier = Session["id_dossier"].ToString();
            Session.Add("id_dossier", idDossier);

            var listeCompteClient = service.select_TABLEAU_ENCOURS(ETCIV_MATRICULE);
            if (listeCompteClient.Count != 0)
            {
                foreach (var listeCompte in listeCompteClient)
                {
                    string autorisation = listeCompte.AUTORISATION.Replace(".", ",");
                    if (string.IsNullOrEmpty(autorisation)) autorisation = "0";
                    string solde = listeCompte.SOLDE.Replace(".", ",");
                    if (string.IsNullOrEmpty(solde)) solde = "0";

                    sb.AppendLine("\n <tr title=\"Sélectionner la ligne\">");
                    sb.AppendLine(string.Format("\n <td class=\"text-left\" style=\"background-color: rgba(33, 150, 243, 0.57)\"><b>{0}</b></td>", listeCompte.LIBELLE.ToString()));
                    sb.AppendLine(string.Format("\n <td class=\"text-left\" style=\"background-color: rgba(33, 150, 243, 0.57)\"><b>{0}</b></td>", listeCompte.COMPTE.ToString()));
                    sb.AppendLine(string.Format("\n <td class=\"text-right\" style=\"background-color: rgba(33, 150, 243, 0.57)\"><b>{0}</b></td>", Convert.ToString(string.Format(frCult, "{0:#,##0}", Convert.ToDouble(solde)))));
                    sb.AppendLine(string.Format("\n <td class=\"text-right\" style=\"background-color: rgba(33, 150, 243, 0.57)\"><b>{0}</b></td>", Convert.ToString(string.Format(frCult, "{0:#,##0}", Convert.ToDouble(autorisation)))));
                    sb.AppendLine(string.Format("\n <td class=\"text-left\" style=\"background-color: rgba(33, 150, 243, 0.57)\"><b>{0}</b></td>", listeCompte.ECHEANCE.ToString()));
                    sb.AppendLine(string.Format("\n <td class=\"text-left\" style=\"background-color: rgba(33, 150, 243, 0.57)\"><b>{0}</b></td>", listeCompte.DEVISE.ToString()));
                    sb.AppendLine("\n </tr>");
                }
            }
            else
            {
                sb.AppendLine("\n <tr title=\"Sélectionner la ligne\">");
                sb.AppendLine("\n <td class=\"text-center bg-danger col-lg-12\" colspan=\"7\">Aucun</td>");
                sb.AppendLine("\n </tr>");

            }
            
            //fin boucle
            sb.AppendLine("\n </tbody>");
            sb.AppendLine("\n </table>");
            sb.AppendLine("\n </div>");
            sb.AppendLine("\n </div>");
            ListDesEncoursTableau.InnerHtml = sb.ToString();
        }

        //void AfficherTableau()
        //{
        //    if (Session["id_dossier"] == null) Response.Redirect("~/Scoring/Connexion.aspx"); 

        //    var id_scoring = Session["id_scoring"].ToString();
        //     var idDossier = Session["id_dossier"].ToString();
        //     var listes = service.Liste_ENCOURS_N(0, idDossier.ToString().Trim());
        //     if (listes.Count > 0)
        //     {
        //         foreach (var l in listes)
        //         {
        //             if (l.LIBELLE_ENCOURS.Trim() == "Prêt CT")
        //             {
        //                 //Prêt CT
        //                 CT_Auto.InnerText = (l.AUTORISATION_DETAIL == 0) ? ("-") : Convert.ToString(string.Format(frCult, "{0:#,##0}", l.AUTORISATION_DETAIL));
        //                 CT_Encours.InnerText = (l.ENCOURS_DETAIL == 0) ? ("-") : Convert.ToString(string.Format(frCult, "{0:#,##0}", l.ENCOURS_DETAIL));
        //                 CT_Ech.InnerText = Convert.ToDateTime(l.ECHEANCES_DETAIL).ToString("dd/MM/yyyy");
        //                 CT_Devise.InnerText = l.DEVISE_DETAIL.Trim();
        //             }
        //             if (l.LIBELLE_ENCOURS.Trim() == "Prêt MT")
        //             {
        //                 //Prêt MT
        //                 MT_Auto.InnerText = (l.AUTORISATION_DETAIL == 0) ? ("-") : Convert.ToString(string.Format(frCult, "{0:#,##0}", l.AUTORISATION_DETAIL));
        //                 MT_Encours.InnerText = (l.ENCOURS_DETAIL == 0) ? ("-") : Convert.ToString(string.Format(frCult, "{0:#,##0}", l.ENCOURS_DETAIL));
        //                 MT_Ech.InnerText =Convert.ToDateTime(l.ECHEANCES_DETAIL).ToString("dd/MM/yyyy");
        //                 MT_Devise.InnerText = l.DEVISE_DETAIL.Trim();
        //             }
        //             if (l.LIBELLE_ENCOURS.Trim() == "Credoc")
        //             {
        //                 //Crédits indirects
        //                 Credoc_Auto.InnerText = (l.AUTORISATION_DETAIL == 0) ? ("-") : Convert.ToString(string.Format(frCult, "{0:#,##0}", l.AUTORISATION_DETAIL));
        //                 Credoc_Encours.InnerText = (l.ENCOURS_DETAIL == 0) ? ("-") : Convert.ToString(string.Format(frCult, "{0:#,##0}", l.ENCOURS_DETAIL));
        //                 Credoc_Ech.InnerText = Convert.ToDateTime(l.ECHEANCES_DETAIL).ToString("dd/MM/yyyy");
        //                 Credoc_Devise.InnerText = l.DEVISE_DETAIL.Trim();
        //             }
        //             if (l.LIBELLE_ENCOURS.Trim() == "Caution S.")
        //             {
        //                 //Caution S.
        //                 Caution_Auto.InnerText = (l.AUTORISATION_DETAIL == 0) ? ("-") : Convert.ToString(string.Format(frCult, "{0:#,##0}", l.AUTORISATION_DETAIL));
        //                 Caution_Encours.InnerText = (l.ENCOURS_DETAIL == 0) ? ("-") : Convert.ToString(string.Format(frCult, "{0:#,##0}", l.ENCOURS_DETAIL));
        //                 Caution_Ech.InnerText = Convert.ToDateTime(l.ECHEANCES_DETAIL).ToString("dd/MM/yyyy");
        //                 Caution_Devise.InnerText = l.DEVISE_DETAIL.Trim();
        //             }
        //             if (l.LIBELLE_ENCOURS.Trim() == "Hypoth.")
        //             {
        //                 //Hypoth.
        //                 Hypoth_Auto.InnerText = (l.AUTORISATION_DETAIL == 0) ? ("-") : Convert.ToString(string.Format(frCult, "{0:#,##0}", l.AUTORISATION_DETAIL));
        //                 Hypoth_Encours.InnerText = (l.ENCOURS_DETAIL == 0) ? ("-") : Convert.ToString(string.Format(frCult, "{0:#,##0}", l.ENCOURS_DETAIL));
        //                 Hypoth_Ech.InnerText = Convert.ToDateTime(l.ECHEANCES_DETAIL).ToString("dd/MM/yyyy");
        //                 Hypoth_Devise.InnerText = l.DEVISE_DETAIL.Trim();
        //             }
        //         }
        //     }
        //     else
        //     {
        //             //Prêt CT
        //             CT_Auto.InnerText = "-";
        //             CT_Encours.InnerText = "-";
        //             CT_Ech.InnerText = "-";
        //             CT_Devise.InnerText = "-";
        //             //Prêt MT
        //             MT_Auto.InnerText = "-";
        //             MT_Encours.InnerText = "-";
        //             MT_Ech.InnerText = "-";
        //             MT_Devise.InnerText = "-";
        //             //Crédits indirects
        //             Credoc_Auto.InnerText = "-";
        //             Credoc_Encours.InnerText = "-";
        //             Credoc_Ech.InnerText = "-";
        //             Credoc_Devise.InnerText = "-";
        //             //Caution S.
        //             Caution_Auto.InnerText = "-";
        //             Caution_Encours.InnerText = "-";
        //             Caution_Ech.InnerText = "-";
        //             Caution_Devise.InnerText = "-";
        //             //Hypoth.
        //             Hypoth_Auto.InnerText = "-";
        //             Hypoth_Encours.InnerText = "-";
        //             Hypoth_Ech.InnerText = "-";
        //             Hypoth_Devise.InnerText = "-";
        //     }


        //}
    }
}