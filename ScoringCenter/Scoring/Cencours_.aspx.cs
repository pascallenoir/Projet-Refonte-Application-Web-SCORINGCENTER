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
    public partial class Cencours : System.Web.UI.Page
    {
        StringBuilder sb = new StringBuilder();
        StringBuilder sc = new StringBuilder();

        Scoringws service = new Scoringws();

        protected void Page_Load(object sender, EventArgs e)
        {
            ControllerPage();
            if (!IsPostBack)
            {
                AfficherTableau();
            }
        }



        protected void Page_Init(object sender, EventArgs e)
        {

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

                Con.Visible = false;

                var test = 0;
                foreach (var element in elements)
                {
                    if (element.ID_DROIT.ToString().Trim() == "AD")
                    {
                        if (element.ID_TYPE_DROIT.ToString().Trim() != "0") AD.Visible = true;
                    }


                    if (element.ID_DROIT.ToString().Trim() == "Con")
                    {
                        if (element.ID_TYPE_DROIT.ToString().Trim() != "0") Con.Visible = true;
                    }

                    //et pour les actions sur la page
                    if (element.ID_DROIT.ToString().Trim() == "Cen")
                    {

                        switch (element.ID_TYPE_DROIT.ToString().Trim())
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
                            default:
                                break;
                        }
                    }



                }
            }
            ////Fin_Controle////////////////////////////////////////////////////
        }
        //MUGIRANEZA OSCAR  07-07-2017  
        public void ChargementEncours(object sender, EventArgs e)
        {
            if (fichier.PostedFile != null && fichier.PostedFile.ContentLength > 0)
            {

                string fn = System.IO.Path.GetFileName(fichier.PostedFile.FileName);

                string saveLocation = @"" + Server.MapPath("Data") + "\\" + fn;
                //File.Delete(saveLocation);
                fichier.PostedFile.SaveAs(saveLocation);
                service.ChargerFichierEncours(saveLocation);
                File.Delete(saveLocation);
                sc.AppendLine("<div class='alert alert-success fade in'>");
                sc.AppendLine("<a href='#' class='close' data-dismiss='alert' style='margin-top: -0.4%;'>&times;</a>");
                sc.AppendLine(string.Format("<p><strong>{0}</strong></p>", fn));
                sc.AppendLine("<strong>Fichier chargé avec succès ...</strong>");
                sc.AppendLine("</div>");
                getMessage.InnerHtml = sc.ToString();
                Response.Redirect("~/Scoring/Cencours.aspx");

               

            }
        }

        //MUGIRANEZA 07-07-2017

        void AfficherTableau()
        {
            var listes = service.select_TABLEAU_ENCOURS();
            sb.AppendLine("<table class='table table-bordered table-hover scor_table1' id='table-encours'> <thead>");
            sb.AppendLine("<tr class='table-headheight'>");
            sb.AppendLine("<th  class='text-center' style='width: 5%;'>Autorisation</th>");
            sb.AppendLine("<th  class='text-center' style='width: 5%;'>Encours</th>");
            sb.AppendLine("<th  class='text-center' style='width: 5%;'>&Eacute;chéances</th>");
            sb.AppendLine("<th  class='text-center' style='width: 5%;'>Date traitement</th>");
            sb.AppendLine("<th  class='text-center' style='width: 5%;'>Raison sociale</th>");
            sb.AppendLine("</tr>");
            sb.AppendLine("</thead>");
            sb.AppendLine("<tbody>");
            if (listes.Count != 0)
            {
                

                foreach (var v in listes)
                {
                    sb.AppendLine(string.Format("<tr title='Sélectionner la ligne'>"));
                    sb.AppendLine(string.Format("<td class='text-center' style='height:80%'>{0}</td>", v.AUTORISATION.ToString()));
                    sb.AppendLine(string.Format("<td class='text-center' style='height:80%'>{0}</td>", v.ENCOURS.ToString()));
                    sb.AppendLine(string.Format("<td class='text-center' style='height:80%'>{0}</td>", v.ECHEANCES.ToString()));
                    sb.AppendLine(string.Format("<td class='text-center' style='height:80%'>{0}</td>", Convert.ToDateTime(v.DATETRAITEMENT).ToString("dd/MM/yyyy")));
                    sb.AppendLine(string.Format("<td class='text-left' style='height:80%'>{0}</td>", v.ETCIV_NOMREDUIT.ToString()));
                    sb.AppendLine("</tr>");
                }

            }
            else
            {

            }
            sb.AppendLine("</tbody></table>");

            ListDesEncoursTableau.InnerHtml = sb.ToString();
        }
    }
}