
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ScoringCenter
{
    using Scoring;
    using ScoringCenter.Models;
    using System.Configuration;
    using System.Web.UI.WebControls.WebParts;

    public partial class AutreDossier : System.Web.UI.Page
    {
        Scoringws service = new Scoringws();

        StringBuilder sblogo = new StringBuilder();
        StringBuilder sb = new StringBuilder();
        StringBuilder scripts = new StringBuilder();


        protected void Page_Load(object sender, EventArgs e)
        {
            //ReadFileTxt();
            //ControllerPage();

            if (!IsPostBack)
            {
                Session.Remove("id_scoring");
            }
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            LoadAgences();
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
                //Cen.Visible = false;
                //CC.Visible = false;
                Pay.Visible = false;
                Con.Visible = false;
                //CC
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
            //getInfoClient(); EBF.Visible = false; ////Fin_Controle////////////////////////////////////////////////////
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
            if (Session["code_banque"] == null) Response.Redirect("~/Scoring/Connexion.aspx");

            // récupérer les banques appartenant au même groupe banque que la banque de l'utilisateur
            DdlBanque.Items.Clear();
            DdlBanque.Items.Add(new ListItem("", ""));
            string code_banque;
            try
            {
                code_banque = ScorCryptage.Decrypt(Session["code_banque"].ToString());
            }
            catch (Exception e)
            {
                code_banque = Session["code_banque"].ToString();
            }
            foreach (var element in service.ListeBanque(code_banque)) {
                DdlBanque.Items.Add(new ListItem(element.SIGLE_BANQUE.ToString(), element.CODE_BANQUE));
            }
            LoadAgences();
        }

        public void LoadAgences()
        {
            if (Session["code_banque"] == null) Response.Redirect("~/Scoring/Connexion.aspx");

            // filtrer la liste des agences en fonction de la banque sélectionnée
            DdlAgence.Items.Clear();
            if (DdlBanque.SelectedValue != string.Empty)
            {
                var liste_agences = service.ListeAgenceBanque(DdlBanque.SelectedValue);
                if (liste_agences.Any())
                {
                    DdlAgence.Items.Add(new ListItem("Tous", "Tous"));
                    foreach (var element in liste_agences)
                    {
                        DdlAgence.Items.Add(new ListItem(element.GUICHET_AGENCE.ToString() + " - " + element.NOM_AGENCE.ToString(), element.CODE_AGENCE));
                    }
                }
            }
        }

        protected void OnBanqueChangeLoadAgences(object sender, EventArgs e)
        {
            LoadAgences();
        }

        public void recherche()
        {
            StringBuilder sc = new StringBuilder();

            //var p_code_banque = Session["code_banque"].ToString();

            if (DdlAgence.Value == "")
            {
                sb.AppendLine("<div class='alert alert-soft-primary alert-dismissible fade show'>");
                sb.AppendLine("<strong>Veuillez renseigner les champs obligatoires (<i style='color: red'>* </i>) !</strong>");
                sb.AppendLine(" <button type='button' class='close' data-dismiss='alert' aria-label='Close'>");
                sb.AppendLine(" <i class='tio-clear tio-lg'></i>");
                sb.AppendLine("</button>");
                sb.AppendLine("</div>");
            }
          
            if (DdlAgence.Value != "" && DdlBanque.SelectedValue != "")
            {
                var fiche = service.ListeContrepartie(DdlBanque.SelectedValue.Trim(), DdlAgence.Value.Trim(), TbIContrepartie.Text, TbNContrepartie.Text);

                if (fiche.Count != 0)
                {
                    //dataTables-example
                    sc.AppendLine("<div class='row'>");
                    sc.AppendLine("<div class='table-responsive col-lg-12 col-sm-12 col-md-12' datatable-custom>");
                    sc.AppendLine("<table id='datatable_bord' class='table table-borderless table-thead-bordered table-nowrap table-align-middle card-table table-hover'>");
                    sc.AppendLine("<thead class='thead-light'>");
                    sc.AppendLine("<tr>");
                    sc.AppendLine("<th>Raison sociale</th>");
                    sc.AppendLine("<th>Groupe</th>");
                    sc.AppendLine("<th>Type client</th>");
                    sc.AppendLine("<th>ID Scoring</th>");
                    sc.AppendLine("<th>ID principal</th>");
                    sc.AppendLine("</tr>");
                    sc.AppendLine("</thead>");
                    sc.AppendLine("<tbody>");

                    foreach (var ls in fiche)
                    {
                        sc.AppendLine(string.Format("<tr id='{0}' onclick='ligneclick(this.id)' title='Sélectionner la ligne'>", ScorCryptage.Encrypt(ls.ID_SCORING.ToString())));
                        //ls.ID_SCORING.ToString())
                        //Encrypt(ls.ID_SCORING.ToString())
                        sc.AppendLine(string.Format("<td><span class='h5 mb-0'>{0}</span></td>", ls.ETCIV_NOMREDUIT.ToString()));
                        var group = "Aucun"; 
                        if (ls.GROUPE_DOSSIER != null && ls.GROUPE_DOSSIER.Trim() != "") 
                            group = ls.GROUPE_DOSSIER.ToString();
                        var prospect = ""; 
                        if (ls.TYPE_PROSPECT != null && ls.TYPE_PROSPECT.Trim() != "") 
                            prospect = ls.TYPE_PROSPECT.ToString();
                        sc.AppendLine(string.Format("<td>{0}</td>", group));
                        sc.AppendLine(string.Format("<td>{0}</td>", prospect));
                        sc.AppendLine(string.Format("<td>{0}</td>", ls.ID_SCORING.ToString()));
                        sc.AppendLine(string.Format("<td>{0}</td>", ls.ETCIV_MATRICULE.ToString()));
                        sc.AppendLine("</tr>");
                    }
                    sc.AppendLine("</tbody>");
                    sc.AppendLine("</table>");
                    sc.AppendLine("</div>");
                    sc.AppendLine("</div>");
                }
                else
                {
                    sc.AppendLine("<table id='datatable_bord' class='table table-borderless table-thead-bordered table-nowrap table-align-middle card-table'>");
                    sc.AppendLine("<thead class='thead-light'>");
                    sc.AppendLine("<tr>");
                    sc.AppendLine("<th>Nom Société</th>");
                    sc.AppendLine("<th>ID Scoring</th>");
                    sc.AppendLine("<th>ID principal</th>");
                    sc.AppendLine("<th>Modèle</th></tr>");
                    sc.AppendLine("</thead>");
                    sc.AppendLine("<tbody>");

                    sc.AppendLine("<tr><td> </td>");
                    sc.AppendLine("<td> </td>");
                    sc.AppendLine("<td> </td>");
                    sc.AppendLine("<td> </td></tr>");

                    sc.AppendLine("</tbody>");
                    sc.AppendLine("</table>");

                    sb.AppendLine("<div class='alert alert-warning fade show'>");
                    sb.AppendLine("<strong>Aucun résultat de recherche trouvé !!!</strong>");
                    sb.AppendLine("</div>");
                }

            }

           
            // Afficher le spinner
            getMessage.InnerHtml = sb.ToString();

            ListDFinanciers.InnerHtml = sc.ToString();
          
        }

        protected void Ok_Click1(object sender, EventArgs e)
        {
            // Afficher le spinner avant de commencer le traitement

            if (Session["id_user"] == null) Response.Redirect("~/Scoring/Connexion.aspx"); 

            service.PS_SCOR_SPY(Session["id_user"].ToString().Trim(), "AutreDossier", connmou007.Value.ToString(), "R");

           
            recherche();

            // Masquer le spinner après le traitement
        }

    }
}