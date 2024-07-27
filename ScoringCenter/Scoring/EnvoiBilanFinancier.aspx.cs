using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ScoringCenter.Scoring
{
    public partial class EnvoiBilanFinancier : System.Web.UI.Page
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
            //DemoFonct();
        }
        public void DemoFonct()
        {
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
                    if (element.ID_DROIT.ToString().Trim() == "EBF")
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

        public void afficherlistedate()
        {
            if (Session["id_dossier"] == null) Response.Redirect("~/Scoring/Connexion.aspx");
            var idDossier = Session["id_dossier"].ToString();
            Session.Add("id_dossier", idDossier);
            var ladate = Convert.ToInt32(DateTime.UtcNow.Year);
            for (var i = 1; i <= 25; i++)
            {
                var l=ladate-i;
                datepicker.Items.Add(new ListItem("" + l + "", "" + l + ""));
            }
            //var ann = service.Voiranneeexercice(idDossier);
            //if (ann.Trim() != "")
            //{
            //    datepicker.Value = ann;
            //    datepicker.Disabled = true;
            //}

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

        protected void Page_Init(object sender, EventArgs e)
        {
            getInfoClient();
            afficherlistedate();
        }

        protected void Envoyer_Click(object sender, EventArgs e)
        {
            //if (fichier.PostedFile != null && fichier.PostedFile.ContentLength > 0)
            //{

            //    string fn = System.IO.Path.GetFileName(fichier.PostedFile.FileName);

            //    string saveLocation = @"" + Server.MapPath("Data") + "\\" + fn;
            //    //File.Delete(saveLocation);
            //    fichier.PostedFile.SaveAs(saveLocation);
            //    if (Session["id_dossier"] == null) Response.Redirect("~/Scoring/Connexion.aspx"); 
                
            //    var id_dossier = Session["id_dossier"].ToString();
            //    Session.Add("id_dossier", id_dossier);
            //    //service.ChargerFichier(id_dossier.Trim(), saveLocation, DdlRubrique.Text, datepicker.Value);
            //    File.Delete(saveLocation);
                
            //     if(DdlRubrique.Text=="Bilan"){
            //          var list_allFinances = service.Listbilan(id_dossier);
            //          if (list_allFinances.Count != 0)
            //          {
            //              sb.AppendLine("<div class='alert alert-success fade in'>");
            //              sb.AppendLine("<a href='#' class='close' data-dismiss='alert' style='margin-top: -0.4%;'>&times;</a>");
            //              sb.AppendLine(string.Format("<p><strong>{0}</strong></p>", fn));
            //              sb.AppendLine("<strong>Fichier chargé avec succès ...</strong>");
            //              sb.AppendLine("</div>");
            //          }
            //         else
            //          {
            //              sb.AppendLine("<div class='alert alert-danger fade in'>");
            //              sb.AppendLine("<a href='#' class='close' data-dismiss='alert' style='margin-top: -0.4%;'>&times;</a>");
            //              sb.AppendLine(string.Format("<p><strong>{0}</strong></p>", fn));
            //              sb.AppendLine("<strong>Fichier non chargé ...</strong>");
            //              sb.AppendLine("</div>");
            //          }
            //     }
            //     if (DdlRubrique.Text == "Compte de Résultat")
            //     {
            //         var list_allFinances = service.Listcompteresultat(id_dossier);
            //         if (list_allFinances.Count != 0)
            //         {
            //             sb.AppendLine("<div class='alert alert-success fade in'>");
            //             sb.AppendLine("<a href='#' class='close' data-dismiss='alert' style='margin-top: -0.4%;'>&times;</a>");
            //             sb.AppendLine(string.Format("<p><strong>{0}</strong></p>", fn));
            //             sb.AppendLine("<strong>Fichier chargé avec succès ...</strong>");
            //             sb.AppendLine("</div>");
            //         }
            //         else
            //         {
            //             sb.AppendLine("<div class='alert alert-danger fade in'>");
            //             sb.AppendLine("<a href='#' class='close' data-dismiss='alert' style='margin-top: -0.4%;'>&times;</a>");
            //             sb.AppendLine(string.Format("<p><strong>{0}</strong></p>", fn));
            //             sb.AppendLine("<strong>Fichier non chargé ...</strong>");
            //             sb.AppendLine("</div>");
            //         }
            //     }


                 
            //}
            //getMessage.InnerHtml = sb.ToString();
        }
    }
}