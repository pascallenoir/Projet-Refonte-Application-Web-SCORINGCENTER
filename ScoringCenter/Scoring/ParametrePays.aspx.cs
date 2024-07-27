using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ScoringCenter.Scoring
{
    public partial class ParametrePays : System.Web.UI.Page
    {
        Scoringws service = new Scoringws();
        StringBuilder sb = new StringBuilder();
        StringBuilder sc = new StringBuilder();

        static string code_banque = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            AfficheLogoBank();

        }
        public void AfficheLogoBank()
        {
            if (Session["code_banque"] != null)
            {
                var code_banque = Session["code_banque"].ToString();
                var bankInfo = service.AfficheLogoBank(ScorCryptage.Decrypt(code_banque.ToString().Trim()));
                foreach (var banque in bankInfo)
                {

                    if (banque.IMG_BANQUE != "" && banque.IMG_BANQUE != null)
                    {
                        sb.AppendLine(string.Format("<img src=\"../Images/Logo/{0}\"style=\"width: 100% ;height:100%\" />", banque.IMG_BANQUE.ToString().Trim()));
                    }
                }
                idimgLogoBanque.InnerHtml = sb.ToString();
            }
        }
        protected void Page_Init(object sender, EventArgs e)
        {
            if (Session["code_banque"] == null) Response.Redirect("~/Scoring/Connexion.aspx"); 

            code_banque = ScorCryptage.Decrypt(Session["code_banque"].ToString());
            afficher_liste_pays();
            //ListeTableParam();

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
                GP.Visible = false;
                GU.Visible = false;
                GPA.Visible = false;
                PARAM.Visible = false;

                //Cen.Visible = false;
                //CC.Visible = false;
                Pay.Visible = false;
                //Con.Visible = false;

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

                    if (element.ID_DROIT.ToString().Trim() == "GP")
                    {
                        if (element.ID_TYPE_DROIT.ToString().Trim() != "0") GP.Visible = true;
                    }
                    if (element.ID_DROIT.ToString().Trim() == "PARAM")
                    {
                        if (element.ID_TYPE_DROIT.ToString().Trim() != "0") PARAM.Visible = true;
                    }
                    if (element.ID_DROIT.ToString().Trim() == "GU")
                    {
                        if (element.ID_TYPE_DROIT.ToString().Trim() != "0") GU.Visible = true;
                    }
                    if (element.ID_DROIT.ToString().Trim() == "GPA")
                    {
                        if (element.ID_TYPE_DROIT.ToString().Trim() != "0") GPA.Visible = true;
                    }

                    //if (element.ID_DROIT.ToString().Trim() == "Cen")
                    //{
                    //    if (element.ID_TYPE_DROIT.ToString().Trim() != "0") Cen.Visible = true;
                    //}
                    //if (element.ID_DROIT.ToString().Trim() == "CC")
                    //{
                    //    if (element.ID_TYPE_DROIT.ToString().Trim() != "0") CC.Visible = true;
                    //}
                    if (element.ID_DROIT.ToString().Trim() == "Pay")
                    {
                        if (element.ID_TYPE_DROIT.ToString().Trim() != "0") Pay.Visible = true;
                    }


                    //et pour les actions sur la page
                    if (element.ID_DROIT.ToString().Trim() == "Pay")
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
            //getInfoClient(); EBF.Visible = false; ////Fin_Controle////////////////////////////////////////////////////
        }

        public void afficher_liste_pays()
        {
            var Liste = service.LIST_STDOPAYS();
            if (StdNot.Value == "STPO") Liste = service.LIST_STDOPAYS();
            if (StdNot.Value == "MOOD") Liste = service.LIST_STDOPAYS2();
            if (StdNot.Value == "FITC") Liste = service.LIST_STDOPAYS3();
            if (Liste.Count != 0)
            {
                //dataTables-example
                sc.AppendLine("<div class='row push_entete'><div class='col-lg-12 col-sm-12 col-md-12 table-responsive'>");
                sc.AppendLine("<table id='datatable_bord' class='table table-bordered table-hover'>");
                sc.AppendLine("<thead class='table-heigth'>");
                sc.AppendLine("<tr><th class='text-center _dynamic'>PAYS</th>");
                sc.AppendLine("<th class='text-center _dynamic'>NOTES</th>");
                sc.AppendLine("<th class='text-center _dynamic'>PERSPECTIVES</th>");
                sc.AppendLine("<th class='text-center _dynamic'>DATE MAJ</th>");
                // sc.AppendLine("<th class='text-center'>TYPE DE MAJ</th>");
                //sc.AppendLine("<th class='text-center'>ACTION</th></tr>");
                sc.AppendLine("</thead>");
                sc.AppendLine("<tbody style=\"background-color:#FFFFFF;\">");

                foreach (var detail in Liste)
                {
                    var nompays = ""; if (detail.PAYS_NOM != null) nompays = detail.PAYS_NOM.ToString();
                    var notepays = ""; if (detail.NOTE_PAYS != null) notepays = detail.NOTE_PAYS.ToString();
                    var perspective = ""; if (detail.PERSPECTIVE_PAYS != null) perspective = detail.PERSPECTIVE_PAYS.ToString();
                    var datemaj = ""; if (detail.DATE_MAJ_PAYS != null) datemaj = detail.DATE_MAJ_PAYS.ToString();

                    sc.AppendLine(string.Format("<tr id='{0}' title='Sélectionner la ligne'>", ScorCryptage.Encrypt(detail.ID_NOTE_PAYS.ToString())));
                    sc.AppendLine(string.Format("<td style='text-align: left; width: 30%;' class='_dynamic'>{0}</td>", nompays));
                    sc.AppendLine(string.Format("<td style='text-align: left; width: 15%;' class=''>{0}</td>", notepays));
                    sc.AppendLine(string.Format("<td style='text-align: left; width: 20%;' class=''>{0}</td>", perspective));
                    sc.AppendLine(string.Format("<td style='text-align: left; width: 20%;' class='_dynamic'>{0}</td>", datemaj));
                    //sc.AppendLine(string.Format("<td >"+"<div class=\"IndivEdit btn-sm btn-primary button_div pull-right\"" +
                    //           " style=\"margin-right: 5px; color:#022451; background-color:#ffffff; height: 24px; border: none; padding-top: 0px; padding-bottom: 0px;\"" +
                    //           " title=\"Editer\"  onclick='Maligneclick($(this))' >" +
                    //            "<span class=\" glyphicon glyphicon-edit\"></span>" +
                    //        "</div>"+
                    //        "<div class=\"IndivAnnul hidden btn-sm btn-primary button_div pull-right\"" +
                    //           " style=\"margin-right: 5px; color:rgba(204, 92, 11, 0.84); background-color:#ffffff; height: 24px; border: none; padding-top: 0px; padding-bottom: 0px;\"" +
                    //           " title=\"Annuler\"  >" +
                    //            "<span class=\" glyphicon glyphicon-remove\"></span>" +
                    //        "</div>"+
                    //        "<div class=\"IndivValid hidden btn-sm btn-primary button_div pull-right\"" +
                    //           " style=\"margin-right: 5px; color:#0a8f3a; background-color:#ffffff; height: 24px; border: none; padding-top: 0px; padding-bottom: 0px;\"" +
                    //           " title=\"Valider\"  >" +
                    //            "<span class=\" glyphicon glyphicon-ok\"></span>" +
                    //        "</div>"+"</td>"
                    //        , detail.ID_NOTE_PAYS.ToString().Trim()));
                    sc.AppendLine("</tr>");
                }

                sc.AppendLine("</tbody></table></div></div>");
            }
            else
            {
                sc.AppendLine("<div class='row push_entete'><div class='col-lg-12 col-sm-12 col-md-12 table-responsive'>");
                sc.AppendLine("<table id='datatable_bord' class='table table-bordered table-hover'>");
                sc.AppendLine("<thead class='table-heigth'>");
                sc.AppendLine("<tr><th class='text-center'>PAYS</th>");
                sc.AppendLine("<th class='text-center'>NOTES</th>");
                sc.AppendLine("<th class='text-center'>PERSPECTIVES</th>");
                sc.AppendLine("<th class='text-center'>DATE MAJ</th>");
                // sc.AppendLine("<th class='text-center'>TYPE DE MAJ</th>");
                //sc.AppendLine("<th class='text-center'>ACTION</th></tr>");
                sc.AppendLine("</thead>");
                sc.AppendLine("<tbody style=\"background-color:#FFFFFF;\">");
                sc.AppendLine("<tr><td> </td>");
                sc.AppendLine("<td> </td>");
                sc.AppendLine("<td> </td>");
                //sc.AppendLine("<td> </td>");
                sc.AppendLine("<td> </td></tr>");
                sc.AppendLine("</tbody></table></div></div>");
                sb.AppendLine("<div class='alert alert-warning fade in'>");
                sb.AppendLine("<strong>Aucun résultat de recherche trouvé !!!</strong>");
                sb.AppendLine("</div>");
            }
            getMessage.InnerHtml = sc.ToString();

        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static string[] Save(string inv, string StdNots)
        {
            int errorsNumber = 0;
            int updatedNumber = 0;
            int createdNumber = 0;
            int deletedNumber = 0;
            JavaScriptSerializer js = new JavaScriptSerializer();
            dynamic investissements = js.Deserialize<dynamic>(inv);
            Scoringws servicePropre = new Scoringws();
            StdNots = "STPO";
            foreach (var investissement in investissements)
            {
                string id_pays_note = ScorCryptage.Decrypt(investissement["pays_code"]);
                string note = investissement["note"] == null ? 0 : investissement["note"];
                string nom_pays = investissement["nom_pays"] == null ? 0 : investissement["nom_pays"];
                string perspective = investissement["perspective"] == null ? 0 : investissement["perspective"];
                var lePays = servicePropre.LIST_STDOPAYS();
                if (StdNots == "STPO")
                {
                    lePays = servicePropre.LIST_STDOPAYS();
                }
                if (StdNots == "MOOD")
                {
                    lePays = servicePropre.LIST_STDOPAYS2();
                }
                if (StdNots == "FITC")
                {
                    lePays = servicePropre.LIST_STDOPAYS3();
                }
                foreach (var element in lePays)
                {
                    if (element.PAYS_NOM.ToString() == nom_pays)
                    servicePropre.INSERT_STDOPAYS(element.PAYS_CODE.ToString(), note, "0", perspective);
                }
            }
            string[] res = new string[1];
            return res;
        }
        
        void OpenShowPasvalideConsult(string titre, string msg)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPasvalideConsult();", true);
            this.lblPasValidemessageConsult.Text = msg;
            this.lblPasValideTitreConsult.Text = titre;
        }

        protected void AnnulerGeneral_ServerClick(object sender, EventArgs e)
        {

        }
    }
}