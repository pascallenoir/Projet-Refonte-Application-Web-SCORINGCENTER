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
                        NClient.Text = v.ETCIV_NOMREDUIT;
                        //Idprincip.Text = v.ID_SCORING;
                        CodeAPE.Text = v.RCCM;
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
                        SaiTypeClient.Text = v.TYPE_PROSPECT;
                        IdScoringCenter.Text = v.ID_SCORING;
                        Siren.Text = v.ACTBCEAO_LIBELLE;
                        Devise.Text = v.DEVISE;
                        ChiffreAffaire.Text = Convert.ToString(string.Format("{0:#,##0}", v.CA));
                        id_dossier = v.ID_DOSSIER;
                        if (v.GROUPE_DOSSIER != "" && v.GROUPE_DOSSIER != null) { }
                        else { IG.Visible = false; }
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
                    //Idprincip.Text = v.ID_SCORING;
                    CodeAPE.Text = v.RCCM;
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
                    SaiTypeClient.Text = v.TYPE_PROSPECT;
                    IdScoringCenter.Text = v.ID_SCORING;
                    Siren.Text = v.ACTBCEAO_LIBELLE;
                    Devise.Text = v.DEVISE;
                    ChiffreAffaire.Text = Convert.ToString(string.Format("{0:#,##0}", v.CA));
                    id_dossier = v.ID_DOSSIER;
                    if (v.GROUPE_DOSSIER != "" && v.GROUPE_DOSSIER != null) { }
                    else { IG.Visible = false; }
                }
                Session.Add("id_dossier", id_dossier);
            }
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
        }
        private void AfficherTableau()
        {
            sb.AppendLine("\n <div class=\"row push_entete\">");
            sb.AppendLine("\n <div class=\"ol-lg-12 col-sm-12 col-md-12 table-responsive\">");
            sb.AppendLine("\n <table id=\"datatable_bord\" class=\"table table-bordered table-hover scor_table1\">");
            sb.AppendLine("\n <thead class='table-heigth1'>");
            sb.AppendLine("\n <tr>");
            sb.AppendLine("\n <th class=\"text-center\" >Type Compte</th>");
            sb.AppendLine("\n <th class=\"text-center\" >Num Compte</th>");
            sb.AppendLine("\n <th class=\"text-center\" >Autorisation</th>");
            sb.AppendLine("\n <th class=\"text-center\" >Encours Bilan</th>");
            sb.AppendLine("\n <th class=\"text-center\" >Encours Hors Bilan</th>");
            sb.AppendLine("\n <th class=\"text-center\" >&Eacute;chéances</th>");
            sb.AppendLine("\n <th class=\"text-center\" >Devise</th>");
            sb.AppendLine("\n </tr>");
            sb.AppendLine("\n </thead>");
            sb.AppendLine("\n <tbody style=\"background-color: #FFFFFF;\">");
            //boucle 
            if (Session["id_dossier"] == null) Response.Redirect("~/Scoring/Connexion.aspx");
            var idDossier = Session["id_dossier"].ToString();
            Session.Add("id_dossier", idDossier);

            var listeCompteClient = service.select_TABLEAU_ENCOURS(idDossier);
            if (listeCompteClient.Count != 0)
            {
                foreach (var listeCompte in listeCompteClient)
                {
                    sb.AppendLine("\n <tr title=\"Sélectionner la ligne\">");
                    sb.AppendLine(string.Format("\n <td class=\"text-center\" style=\"background-color: rgba(33, 150, 243, 0.57)\"><b>{0}</b></td>", listeCompte.LIBELLECMPT.ToString()));
                    sb.AppendLine(string.Format("\n <td class=\"text-left\" style=\"background-color: rgba(33, 150, 243, 0.57)\"><b>{0}</b></td>", listeCompte.NUMCMPT.ToString()));
                    sb.AppendLine(string.Format("\n <td class=\"text-left\" style=\"background-color: rgba(33, 150, 243, 0.57)\"><b>{0}</b></td>", listeCompte.AUTORISATION.ToString()));
                    sb.AppendLine(string.Format("\n <td class=\"text-left\" style=\"background-color: rgba(33, 150, 243, 0.57)\"><b>{0}</b></td>", listeCompte.ENCOURSBIL.ToString()));
                    sb.AppendLine(string.Format("\n <td class=\"text-left\" style=\"background-color: rgba(33, 150, 243, 0.57)\"><b>{0}</b></td>", listeCompte.ENCOURSHBIL.ToString()));
                    sb.AppendLine(string.Format("\n <td class=\"text-left\" style=\"background-color: rgba(33, 150, 243, 0.57)\"><b>{0}</b></td>", (listeCompte.ECHEANCES.ToString() == "") ? "" : Convert.ToDateTime(listeCompte.ECHEANCES).ToShortDateString()));
                    sb.AppendLine(string.Format("\n <td class=\"text-center\" style=\"background-color: rgba(33, 150, 243, 0.57)\"><b>{0}</b></td>", listeCompte.DEVISE.ToString()));
                    sb.AppendLine("\n </tr>");

                    var listeCompteDetail = service.select_TABLEAU_ENCOURS_DETAIL(idDossier, listeCompte.IDCMPT);
                    foreach (var listeEncours in listeCompteDetail)
                    {
                        sb.AppendLine("\n <tr title=\"Sélectionner la ligne\">");
                        sb.AppendLine(string.Format("\n <td class=\"text-left\"><b>&nbsp;&nbsp;&nbsp;<i class=\"glyphicon glyphicon-share-alt gly-flip-vertical\"></i>{0}</b></td>", listeEncours.LIBEMGAG.ToString()));
                        sb.AppendLine(string.Format("\n <td class=\"text-left\"><b>{0}</b></td>", listeEncours.LIBELLEENGMT.ToString()));
                        sb.AppendLine(string.Format("\n <td class=\"text-left\"><b>{0}</b></td>", listeEncours.AUTORISATION_EMGAG.ToString()));
                        sb.AppendLine(string.Format("\n <td class=\"text-left\"><b>{0}</b></td>", listeEncours.ENCOURSBIL_EMGAG.ToString()));
                        sb.AppendLine(string.Format("\n <td class=\"text-left\"><b>{0}</b></td>", listeEncours.ENCOURSHBIL_EMGAG.ToString()));
                        sb.AppendLine(string.Format("\n <td class=\"text-left\"><b>{0}</b></td>", Convert.ToDateTime(listeEncours.ECHEANCES_EMGAG).ToShortDateString()));
                        sb.AppendLine(string.Format("\n <td class=\"text-center\"><b>{0}</b></td>", listeEncours.DEVISE_EMGAG.ToString()));
                        sb.AppendLine("\n </tr>");
                    }
                }
            }
            else
            {
                sb.AppendLine("\n <tr title=\"Sélectionner la ligne\">");
                sb.AppendLine("\n <div class=\"text-center bg-danger col-lg-12\">Aucun</div>");
                sb.AppendLine("\n </tr>");

            }
            
            //fin boucle
            sb.AppendLine("\n </thead>");
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
        //                 CT_Auto.InnerText = (l.AUTORISATION_DETAIL == 0) ? ("-") : Convert.ToString(string.Format("{0:#,##0}", l.AUTORISATION_DETAIL));
        //                 CT_Encours.InnerText = (l.ENCOURS_DETAIL == 0) ? ("-") : Convert.ToString(string.Format("{0:#,##0}", l.ENCOURS_DETAIL));
        //                 CT_Ech.InnerText = Convert.ToDateTime(l.ECHEANCES_DETAIL).ToString("dd/MM/yyyy");
        //                 CT_Devise.InnerText = l.DEVISE_DETAIL.Trim();
        //             }
        //             if (l.LIBELLE_ENCOURS.Trim() == "Prêt MT")
        //             {
        //                 //Prêt MT
        //                 MT_Auto.InnerText = (l.AUTORISATION_DETAIL == 0) ? ("-") : Convert.ToString(string.Format("{0:#,##0}", l.AUTORISATION_DETAIL));
        //                 MT_Encours.InnerText = (l.ENCOURS_DETAIL == 0) ? ("-") : Convert.ToString(string.Format("{0:#,##0}", l.ENCOURS_DETAIL));
        //                 MT_Ech.InnerText =Convert.ToDateTime(l.ECHEANCES_DETAIL).ToString("dd/MM/yyyy");
        //                 MT_Devise.InnerText = l.DEVISE_DETAIL.Trim();
        //             }
        //             if (l.LIBELLE_ENCOURS.Trim() == "Credoc")
        //             {
        //                 //Crédits indirects
        //                 Credoc_Auto.InnerText = (l.AUTORISATION_DETAIL == 0) ? ("-") : Convert.ToString(string.Format("{0:#,##0}", l.AUTORISATION_DETAIL));
        //                 Credoc_Encours.InnerText = (l.ENCOURS_DETAIL == 0) ? ("-") : Convert.ToString(string.Format("{0:#,##0}", l.ENCOURS_DETAIL));
        //                 Credoc_Ech.InnerText = Convert.ToDateTime(l.ECHEANCES_DETAIL).ToString("dd/MM/yyyy");
        //                 Credoc_Devise.InnerText = l.DEVISE_DETAIL.Trim();
        //             }
        //             if (l.LIBELLE_ENCOURS.Trim() == "Caution S.")
        //             {
        //                 //Caution S.
        //                 Caution_Auto.InnerText = (l.AUTORISATION_DETAIL == 0) ? ("-") : Convert.ToString(string.Format("{0:#,##0}", l.AUTORISATION_DETAIL));
        //                 Caution_Encours.InnerText = (l.ENCOURS_DETAIL == 0) ? ("-") : Convert.ToString(string.Format("{0:#,##0}", l.ENCOURS_DETAIL));
        //                 Caution_Ech.InnerText = Convert.ToDateTime(l.ECHEANCES_DETAIL).ToString("dd/MM/yyyy");
        //                 Caution_Devise.InnerText = l.DEVISE_DETAIL.Trim();
        //             }
        //             if (l.LIBELLE_ENCOURS.Trim() == "Hypoth.")
        //             {
        //                 //Hypoth.
        //                 Hypoth_Auto.InnerText = (l.AUTORISATION_DETAIL == 0) ? ("-") : Convert.ToString(string.Format("{0:#,##0}", l.AUTORISATION_DETAIL));
        //                 Hypoth_Encours.InnerText = (l.ENCOURS_DETAIL == 0) ? ("-") : Convert.ToString(string.Format("{0:#,##0}", l.ENCOURS_DETAIL));
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