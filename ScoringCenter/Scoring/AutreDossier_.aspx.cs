
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ScoringCenter
{
    using Scoring;
    public partial class AutreDossier : System.Web.UI.Page
    {
        Scoringws service = new Scoringws();
        StringBuilder sb = new StringBuilder();
        StringBuilder scripts = new StringBuilder();


        protected void Page_Load(object sender, EventArgs e)
        {
            ControllerPage();
            if (!IsPostBack)
            {
                Session.Remove("id_scoring");
            }
        }
        protected void Page_Init(object sender, EventArgs e)
        {
            ListeTableParam();
        }

        public void ControllerPage()
        {
            ////Debut_Controle///////////////////////////////////////////////////
            if (Session["login"] == null) Response.Redirect("~/Scoring/Connexion.aspx");
            else
            {
                var idprofil = Session["id_profil"].ToString();
                var elements = service.VHABILITATION(idprofil);
                TB.Visible = false;
                GP.Visible = false;
                GU.Visible = false;
                GPA.Visible = false;
                PARAM.Visible = false;
                Cen.Visible = false;
                Con.Visible = false;

                var test = 0;
                foreach (var element in elements)
                {
                    if (element.ID_DROIT.ToString().Trim() == "TB")
                    {
                        if (element.ID_TYPE_DROIT.ToString().Trim() != "0") TB.Visible = true;
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
                        if (element.ID_TYPE_DROIT.ToString().Trim() != "0") Cen.Visible = true;
                    }
                    if (element.ID_DROIT.ToString().Trim() == "Con")
                    {
                        if (element.ID_TYPE_DROIT.ToString().Trim() != "0") Con.Visible = true;
                    }
                    //et pour les actions sur la page
                    if (element.ID_DROIT.ToString().Trim() == "AD")
                    {
                       // if (element.ID_TYPE_DROIT.ToString().Trim() != "0") AD.Visible = true;
                        
                        
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

        protected void Ok_Click(object sender, EventArgs e)
        {

        }

        protected void ShowvalideOpenConsult_ServerClick(object sender, EventArgs e)
        {

        }

        void OpenShowPasvalideConsult(string titre, string msg)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPasvalideConsult();", true);
            this.lblPasValidemessageConsult.Text = msg;
            this.lblPasValideTitreConsult.Text = titre;
        }

        public void ListeTableParam()
        {
            if (Session["code_banque"] != null)
            {
                var param = Session["code_banque"].ToString();
               
                foreach (var v in service.ListeAgenceBanque( ScorCryptage.Decrypt(param)))
                {
                   DdlAgence.Items.Add(new ListItem(v.GUICHET_AGENCE.ToString() + " - " + v.NOM_AGENCE.ToString(),v.CODE_AGENCE));
                }
            }
            else
            {
                //sb.AppendLine("<div class='alert alert-danger fade in'>");
                //sb.AppendLine("<a href='#' class='close' data-dismiss='alert' style='margin-top: -0.4%;'>&times;</a>");
                //sb.AppendLine("<strong>Veuillez vous connecter pour evoluer !!!<br/></strong>");
                //sb.AppendLine("</div>");
                //getMessage.InnerHtml = sb.ToString();
                Response.Redirect("Connexion.aspx");
            }

        }

        

        public void recherche()
        {
            StringBuilder sc = new StringBuilder();

            //var p_code_banque = Session["code_banque"].ToString();

            if (DdlAgence.Value == "")
            {
                sb.AppendLine("<div class='alert alert-warning fade in'>");
                sb.AppendLine("<strong>Veuillez renseigner les champs obligatoires (*) !!!</strong>");
                sb.AppendLine("</div>");
            }
          
            if (DdlAgence.Value != "")
            {
                var fiche = service.ListeContrepartie(DdlAgence.Value.Trim(), TbIContrepartie.Text, TbNContrepartie.Text);

                if (fiche.Count != 0)
                {
                    //dataTables-example
                    sc.AppendLine("<div class='row push_entete'><div class='col-lg-12 col-sm-12 col-md-12 table-responsive'>");
                    sc.AppendLine("<table id='datatable_bord' class='table table-bordered table-hover'>");
                    sc.AppendLine("<thead class='table-heigth'>");
                    sc.AppendLine("<tr><th>Raison sociale</th>");
                    sc.AppendLine("<th class='text-left'>Groupe</th>");
                    sc.AppendLine("<th class='text-left'>Type client</th>");
                    sc.AppendLine("<th class='text-left'>ID Scoring</th>");
                    sc.AppendLine("<th class='text-left'>ID principal</th></tr>");
                    sc.AppendLine("</thead>");
                    sc.AppendLine("<tbody style=\"background-color:#FFFFFF;\">");

                    foreach (var ls in fiche)
                    {
                        sc.AppendLine(string.Format("<tr id='{0}' class='' onclick='ligneclick(this.id)' title='Sélectionner la ligne'>", ScorCryptage.Encrypt(ls.ID_SCORING.ToString())));
                        //ls.ID_SCORING.ToString())
                        //Encrypt(ls.ID_SCORING.ToString())
                        sc.AppendLine(string.Format("<td style='text-align: left;'><span style='font-weight: bold; color: #022D65; text-decoration: none;'>{0}</span></td>", ls.ETCIV_NOMREDUIT.ToString()));
                        var group = "Aucun"; if (ls.GROUPE_DOSSIER != null && ls.GROUPE_DOSSIER.Trim() != "") group = ls.GROUPE_DOSSIER.ToString();
                        var prospect = ""; if (ls.TYPE_PROSPECT != null && ls.TYPE_PROSPECT.Trim() != "") prospect = ls.TYPE_PROSPECT.ToString();
                        sc.AppendLine(string.Format("<td style='text-align: left; width: 20%;'>{0}</td>", group));
                        sc.AppendLine(string.Format("<td style='text-align: left; width: 13%;'>{0}</td>", prospect));
                        sc.AppendLine(string.Format("<td style='text-align: left; width: 10%;'>{0}</td>", ls.ID_SCORING.ToString()));
                        sc.AppendLine(string.Format("<td style='text-align: left; width: 10%;'>{0}</td>", ls.ETCIV_MATRICULE.ToString()));
                        sc.AppendLine("</tr>");
                    }

                    sc.AppendLine("</tbody></table></div></div>");
                }
                else
                {
                    sc.AppendLine("<div class='row push_entete'><div class='col-lg-12 col-sm-12 col-md-12 table-responsive'>");
                    sc.AppendLine("<table id='dataTables-example' class='table table-bordered table-striped table-hover'>");
                    sc.AppendLine("<thead class='table-heigth'>");
                    sc.AppendLine("<tr><th>Nom Société</th>");
                    sc.AppendLine("<th>ID Scoring</th>");
                    sc.AppendLine("<th>ID principal</th>");
                    sc.AppendLine("<th>Modèle</th></tr>");
                    sc.AppendLine("</thead>");
                    sc.AppendLine("<tbody>");

                    sc.AppendLine("<tr><td> </td>");
                    sc.AppendLine("<td> </td>");
                    sc.AppendLine("<td> </td>");
                    sc.AppendLine("<td> </td></tr>");

                    sc.AppendLine("</tbody></table></div></div>");

                    sb.AppendLine("<div class='alert alert-warning fade in'>");
                    sb.AppendLine("<strong>Aucun résultat de recherche trouvé !!!</strong>");
                    sb.AppendLine("</div>");
                }


               
            }
            getMessage.InnerHtml = sb.ToString();

            ListDFinanciers.InnerHtml = sc.ToString();
        }

        protected void Ok_Click1(object sender, EventArgs e)
        {
            recherche();
        }
       
    }
}