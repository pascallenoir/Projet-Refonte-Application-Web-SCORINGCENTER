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

                GP.Visible = false;
                GU.Visible = false;
                GPA.Visible = false;
                PARAM.Visible = false;
                //Cen.Visible = false;
                //CC.Visible = false;
                Pay.Visible = false;
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


                    if (element.ID_DROIT.ToString().Trim() == "PARAM")
                    {
                        if (element.ID_TYPE_DROIT.ToString().Trim() != "0") PARAM.Visible = true;
                    }

                    if (element.ID_DROIT.ToString().Trim() == "GP")
                    {
                        if (element.ID_TYPE_DROIT.ToString().Trim() != "0") GP.Visible = true;
                    }

                    if (element.ID_DROIT.ToString().Trim() == "GU")
                    {
                        if (element.ID_TYPE_DROIT.ToString().Trim() != "0") GU.Visible = true;
                    }

                    if (element.ID_DROIT.ToString().Trim() == "GPA")
                    {
                        if (element.ID_TYPE_DROIT.ToString().Trim() != "0") GPA.Visible = true;
                    }
                    if (element.ID_DROIT.ToString().Trim() == "Cen")
                    {
                        //if (element.ID_TYPE_DROIT.ToString().Trim() != "0") //Cen.Visible = true;
                    }
                    if (element.ID_DROIT.ToString().Trim() == "CC")
                    {
                       //if (element.ID_TYPE_DROIT.ToString().Trim() != "0") //CC.Visible = true;
                    }
                    if (element.ID_DROIT.ToString().Trim() == "Pay")
                    {
                        if (element.ID_TYPE_DROIT.ToString().Trim() != "0") Pay.Visible = true;
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
            //getInfoClient(); EBF.Visible = false; ////Fin_Controle////////////////////////////////////////////////////
        }
        
        //MUGIRANEZA 07-07-2017
        void AfficherTableau()
        {
            //var listes = service.select_TABLEAU_ENCOURS();
            //sb.AppendLine("<div class='row push_entete'><div class='col-lg-12 col-sm-12 col-md-12 table-responsive'>");
            //sb.AppendLine("<table id='datatable_Encours' class='table table-bordered table-hover'>");
            //sb.AppendLine("<thead class='table-heigth'>");
            //sb.AppendLine("<tr>");
            //sb.AppendLine("<th  class='text-center' style='width: 5%;'>Autorisation</th>");
            //sb.AppendLine("<th  class='text-center' style='width: 5%;'>Encours</th>");
            //sb.AppendLine("<th  class='text-center' style='width: 5%;'>&Eacute;chéances</th>");
            //sb.AppendLine("<th  class='text-center' style='width: 5%;'>Date traitement</th>");
            //sb.AppendLine("<th  class='text-center' style='width: 5%;'>Raison sociale</th>");
            //sb.AppendLine("</tr>");
            //sb.AppendLine("</thead>");
            //sb.AppendLine("<tbody style=\"background-color:#FFFFFF;\">");
            //if (listes.Count != 0)
            //{
                

            //    foreach (var v in listes)
            //    {
            //        sb.AppendLine(string.Format("<tr title='Sélectionner la ligne'>"));
            //        sb.AppendLine(string.Format("<td class='text-center' style='height:80%'>{0}</td>", v.AUTORISATION.ToString()));
            //        sb.AppendLine(string.Format("<td class='text-center' style='height:80%'>{0}</td>", v.ENCOURS.ToString()));
            //        sb.AppendLine(string.Format("<td class='text-center' style='height:80%'>{0}</td>", v.ECHEANCES.ToString()));
            //        sb.AppendLine(string.Format("<td class='text-center' style='height:80%'>{0}</td>", Convert.ToDateTime(v.DATETRAITEMENT).ToString("dd/MM/yyyy")));
            //        sb.AppendLine(string.Format("<td class='text-left' style='height:80%'>{0}</td>", v.ETCIV_NOMREDUIT.ToString()));
            //        sb.AppendLine("</tr>");
            //    }

            //}
            //else
            //{

            //}
            //sb.AppendLine("</tbody></table></div></div>");

            //ListDesEncoursTableau.InnerHtml = sb.ToString();
        }
    }
}