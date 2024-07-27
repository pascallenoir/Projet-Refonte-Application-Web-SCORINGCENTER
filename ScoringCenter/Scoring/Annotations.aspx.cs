using ScoringCenter.ScorManager;
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
    public partial class Notes : System.Web.UI.Page
    {
        StringBuilder sb = new StringBuilder();
        Scoringws service = new Scoringws();
        string id_user = "";
        string id_dossier = "";
        private System.Globalization.CultureInfo frCult = System.Globalization.CultureInfo.CreateSpecificCulture("fr-FR");
        protected void Page_Load(object sender, EventArgs e)
        {
           
            ControllerPage();
            id_user = Session["id_user"].ToString();
            
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
                    if (element.ID_DROIT.ToString().Trim() == "AN")
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
           // getInfoClient();
        }

        public void getInfoClient()
        {
            if (Session["id_scoring"] == null) Response.Redirect("~/Scoring/Connexion.aspx"); 
            if (string.IsNullOrEmpty(Request.QueryString["id"]))
            {
                if (string.IsNullOrEmpty(Session["id_scoring"].ToString()))
                    Response.Redirect("AutreDossier.aspx");
                else
                {
                    if (Session["id_scoring"] == null) Response.Redirect("~/Scoring/Connexion.aspx"); 

                    var id_scoring = Session["id_scoring"].ToString();
                    Session.Add("id_scoring", id_scoring);

                    if (Session["code_banque"] == null) Response.Redirect("~/Scoring/Connexion.aspx"); 
                    var code_banque = Session["code_banque"].ToString();
                    var info = service.DetailsDossierContrepartie(code_banque, id_scoring);
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
                    listCommentaire(id_dossier);
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
                listCommentaire(id_dossier);
            }
        }

        public void listCommentaire(string id_dossier)
        {
            if (Session["id_scoring"] == null) Response.Redirect("~/Scoring/Connexion.aspx");
            var id_scoring = Session["id_scoring"].ToString();
            Session.Add("id_scoring", id_scoring);

            var listDDos = DataManager.LIST_DOSSIER(0, id_scoring);
            if (listDDos.Count != 0)
            {
                foreach (var lst in listDDos)
                {
                    var listcommentaire = service.ListeCommentaire(0, "", lst.ID_DOSSIER, id_scoring, "", "", "", DateTime.Now);

                    if (listcommentaire.Count != 0)
                    {
                        if (Session["id_user"] == null) Response.Redirect("~/Scoring/Connexion.aspx");

                        id_user = Session["id_user"].ToString();
                        var comment = "";
                        if (listcommentaire.First().TEXTE_COMMENTAIRE.Length < 15) comment = listcommentaire.First().TEXTE_COMMENTAIRE + "...";
                        if (listcommentaire.First().TEXTE_COMMENTAIRE.Length >= 15) comment = listcommentaire.First().TEXTE_COMMENTAIRE.Substring(0, 15) + "...";

                        sb.AppendLine(string.Format("<a href=\"#DossierCom{1}\" style=\"background-color:rgba(208, 245, 117, 0.34);text-align: left;\" class=\"btn  text-left col-md-12 \" data-toggle=\"collapse\"> <div class=\"col-md-11\">Dossier N° :  {1}; Dernier Commentaire : {0}</div> <i class=\" glyphicon-chevron-down col-md-1  glyphicon-align-right\"></i> </a>", comment, lst.ID_DOSSIER.Trim()));
                        sb.AppendLine(string.Format("<div id=\"DossierCom{0}\" class=\"collapse panel-body \">", lst.ID_DOSSIER.Trim()));
                        sb.AppendLine("<br/>");
                        sb.AppendLine("<hr/>");
                        foreach (var rel in listcommentaire)
                        {
                            string totovi = "";
                            string nom_User = service.ListeCommentaire(6, rel.ID_USER, "", "", "", "", "", DateTime.UtcNow)
                               .Where(nUser => nUser.NOM_USER != "").SingleOrDefault().NOM_USER;
                            sb.AppendLine("<div class=\"row\" style=\"margin-bottom: 2%;\" >");
                            sb.AppendLine("<div class=\"col-lg-7 col-sm-7 col-md-7 col-sm-off container text-left\" style=\"overflow:hidden\">");
                            sb.AppendLine(string.Format("<textarea hidden=\"hidden\" name=\"{2}\" id=\"{1}\">{0}</textarea>", rel.TEXTE_COMMENTAIRE, rel.ID_COMMENTAIRE.ToString().Trim(), rel.ID_USER.ToString().Trim()));
                            sb.AppendLine(string.Format("<b>{1}: </b>{0}", rel.TEXTE_COMMENTAIRE, nom_User));
                            sb.AppendLine("</div>");
                            sb.AppendLine("<div id=\"\" class=\"col-lg-2 col-sm-2 col-md-2 col-sm-off text-left\" >");
                            if (rel.FICHIER_COMMENTAIRE != "")
                            {
                                sb.AppendLine(string.Format("<a href=\"../Fichiers_joints/{0}\" class=\"col-lg-12 col-sm-12 col-md-12 col-sm-off\"" +
                                    "target=\"_blank\" style=\"overflow:hidden;padding:0px\" title=\"{0}\"><span class=\"glyphicon glyphicon-file\" ></span> {0}</a>&nbsp;",
                                    rel.FICHIER_COMMENTAIRE.ToString().Trim()));
                            }
                            else
                            {
                                //sb.AppendLine(string.Format("<b>Aucun fichier associé</b>"));
                            }
                            sb.AppendLine("</div>");
                            if (rel.FICHIER_COMMENTAIRE != "")
                                totovi = rel.FICHIER_COMMENTAIRE.ToString().Trim();
                            sb.AppendLine(string.Format("<div class=\"col-lg-2 col-sm-2 col-md-2 col-sm-off alert-info text-left\">Fait le {0}</div>",
                                rel.DATE_COMMENTAIRE.ToString("dd/MM/yyyy")));
                            /*** A traiter plus tard..... ***/

                            sb.AppendLine("<div class=\"col-lg-1 col-sm-1 col-md-1 col-sm-off text-left\">");
                            if (id_user.Trim() == rel.ID_USER.ToString().Trim())
                            {
                                sb.AppendLine(string.Format("<a class=\"btn btn-sm\" style=\"background: rgba(0, 0, 0, 0.00);padding:0px;margin:0px\" onclick=\"recharger({0},{1});con007($(this),'B')\" id=\"1{0}\" title=\"Modifier\"><span class=\" glyphicon glyphicon-edit\"></span></a>", rel.ID_COMMENTAIRE.ToString().Trim(), rel.ID_USER.ToString().Trim()));
                                sb.AppendLine(string.Format(" <a class=\"btn btn-sm\" style=\"background: rgba(0, 0, 0, 0.00);padding:0px;margin:0px\" href=\"#SUPPMODAL\"   onmousedown=\"Unnamed1_Click({0},{1});con007($(this),'B')\"  data-target=\"#SUPPMODAL\"  data-toggle=\"modal\" id=\"\" title=\"Supprimer\"><span class=\" glyphicon glyphicon-trash\"></span></a>", rel.ID_COMMENTAIRE.ToString(), rel.ID_USER.ToString().Trim()));

                            }
                            else
                            {
                                sb.AppendLine(string.Format("<div class=\"btn btn-sm\" style=\"background: rgba(0, 0, 0, 0.00);\"><span class=\"    \"></span></div>"));
                                sb.AppendLine(string.Format("<div class=\"btn btn-sm\" style=\"background: rgba(0, 0, 0, 0.00);\"><span class=\" \"></span></div>"));
                            }
                            sb.AppendLine("</div>");
                            sb.AppendLine("</div>");
                            sb.AppendLine("<hr/>");
                        }
                        sb.AppendLine("</div>");
                    }
                }
            }
            intermess.InnerHtml = sb.ToString();
        }

        //public void listCommentaire(string id_dossier)
        //{
        //    if (Session["id_scoring"] == null) Response.Redirect("~/Scoring/Connexion.aspx"); 

        //    var id_scoring = Session["id_scoring"].ToString();
        //    Session.Add("id_scoring", id_scoring);

        //    var listcommentaire = service.ListeCommentaire(0, "", id_dossier, id_scoring, "", "", "", DateTime.Now);
        //    if (listcommentaire.Count != 0)
        //    {
        //        if (Session["id_user"] == null) Response.Redirect("~/Scoring/Connexion.aspx"); 

        //        id_user = Session["id_user"].ToString();
        //        foreach (var rel in listcommentaire)
        //        {
        //            string totovi = "";
        //            string nom_User = service.ListeCommentaire(6, rel.ID_USER, "", "", "", "", "", DateTime.UtcNow)
        //               .Where(nUser => nUser.NOM_USER != "").SingleOrDefault().NOM_USER;
        //            sb.AppendLine("<div class=\"row\" style=\"margin-bottom: 2%;\" >");
        //            sb.AppendLine("<div class=\"col-lg-7 col-sm-7 col-md-7 col-sm-off container text-left\" style=\"overflow:hidden\">");
        //            sb.AppendLine(string.Format("<textarea hidden=\"hidden\" name=\"{2}\" id=\"{1}\">{0}</textarea>",rel.TEXTE_COMMENTAIRE, rel.ID_COMMENTAIRE.ToString().Trim(), rel.ID_USER.ToString().Trim()));
        //            sb.AppendLine(string.Format("<b>{1}: </b>{0}", rel.TEXTE_COMMENTAIRE, nom_User));
        //            sb.AppendLine("</div>");
        //            sb.AppendLine("<div id=\"\" class=\"col-lg-2 col-sm-2 col-md-2 col-sm-off text-left\" >");
        //            if (rel.FICHIER_COMMENTAIRE != "")
        //            {
        //                sb.AppendLine(string.Format("<a href=\"../Fichiers_joints/{0}\" class=\"col-lg-12 col-sm-12 col-md-12 col-sm-off\"" +
        //                    "target=\"_blank\" style=\"overflow:hidden;padding:0px\" title=\"{0}\"><span class=\"glyphicon glyphicon-file\" ></span> {0}</a>&nbsp;",
        //                    rel.FICHIER_COMMENTAIRE.ToString().Trim()));
        //            }
        //            else
        //            {
        //                //sb.AppendLine(string.Format("<b>Aucun fichier associé</b>"));
        //            }
        //            sb.AppendLine("</div>");
        //            if (rel.FICHIER_COMMENTAIRE != "")
        //                totovi = rel.FICHIER_COMMENTAIRE.ToString().Trim();
        //            sb.AppendLine(string.Format("<div class=\"col-lg-2 col-sm-2 col-md-2 col-sm-off alert-info text-left\">Fait le {0}</div>",
        //                rel.DATE_COMMENTAIRE.ToString("dd/MM/yyyy")));
        //            /*** A traiter plus tard..... ***/

        //            sb.AppendLine("<div class=\"col-lg-1 col-sm-1 col-md-1 col-sm-off text-left\">");
        //            if (id_user.Trim() == rel.ID_USER.ToString().Trim())
        //            {
        //                sb.AppendLine(string.Format("<a class=\"btn btn-sm\" style=\"background: rgba(0, 0, 0, 0.00);padding:0px;margin:0px\" onclick=\"recharger({0},{1});con007($(this),'B')\" id=\"1{0}\" title=\"Modifier\"><span class=\" glyphicon glyphicon-edit\"></span></a>", rel.ID_COMMENTAIRE.ToString().Trim(), rel.ID_USER.ToString().Trim()));
        //                sb.AppendLine(string.Format(" <a class=\"btn btn-sm\" style=\"background: rgba(0, 0, 0, 0.00);padding:0px;margin:0px\" href=\"#SUPPMODAL\"   onmousedown=\"Unnamed1_Click({0},{1});con007($(this),'B')\"  data-target=\"#SUPPMODAL\"  data-toggle=\"modal\" id=\"\" title=\"Supprimer\"><span class=\" glyphicon glyphicon-trash\"></span></a>", rel.ID_COMMENTAIRE.ToString(), rel.ID_USER.ToString().Trim()));
                    
        //            }
        //            else
        //            {
        //                sb.AppendLine(string.Format("<div class=\"btn btn-sm\" style=\"background: rgba(0, 0, 0, 0.00);\"><span class=\" \"></span></div>"));
        //                sb.AppendLine(string.Format("<div class=\"btn btn-sm\" style=\"background: rgba(0, 0, 0, 0.00);\"><span class=\" \"></span></div>"));
        //            }
        //           sb.AppendLine("</div>");
        //           sb.AppendLine("</div>");
        //           sb.AppendLine("<hr/>");
        //        }
        //        intermess.InnerHtml = sb.ToString();
        //    }
        //}

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            if (Session["id_user"] == null) Response.Redirect("~/Scoring/Connexion.aspx"); 

            string m = "";
            if (MyNameUs.Value != "") m = MyNameUs.Value;
            ValiderVN_Click(m);
            if (MyNameUs.Value != "") service.PS_SCOR_SPY(Session["id_user"].ToString().Trim(), "Annotations", connmou007.Value.ToString(), "M");
            else service.PS_SCOR_SPY(Session["id_user"].ToString().Trim(), "Annotations", connmou007.Value.ToString(), "I");
            Response.Redirect("Annotations.aspx");
        }

        protected void Unnamed2_Click(object sender, EventArgs e)
        {
            if (Session["id_user"] == null) Response.Redirect("~/Scoring/Connexion.aspx"); 

            string m = "";
            if (MyNameUs.Value != "") m = MyNameUs.Value.Trim();
            if (id_user.Trim() == m)
                SupprimerVN_Click(m);
            service.PS_SCOR_SPY(Session["id_user"].ToString().Trim(), "Annotations", connmou007.Value.ToString(), "S");
            Response.Redirect("Annotations.aspx");
        }

        protected void SupprimerVN_Click(string m)
        {
            int valcho = 0;
            if (MyName.Value != "")
                valcho = Convert.ToInt32(MyName.Value);
            if (id_user.Trim() == m) service.traiterCommentaire(4, "", "", "", MyName.Value.Trim(), "", "", DateTime.Now);
        }

        protected void ValiderVN_Click(string m)
        {
            if (Session["id_scoring"] == null) Response.Redirect("~/Scoring/Connexion.aspx"); 

            string saveLocation = "", fn = "";
            var param = Session["id_scoring"].ToString();
            Session.Add("id_scoring", param);
            var idDossier = Session["id_dossier"].ToString();
            var listenote = service.ListeCommentaire(1, "", idDossier.Trim(), "", "", "", "", DateTime.Now);

            HttpPostedFile fileSend = fileTxt.PostedFile;
            if (fileSend != null && fileSend.ContentLength > 0)
            {
                fn = Path.GetFileName(fileSend.FileName);
                saveLocation = Server.MapPath("../Fichiers_joints") + "\\" + fn;
                fileSend.SaveAs(saveLocation);
            }
            if (listenote.Count != 0)
            {
                foreach (var xx in listenote)
                {
                    string savef = ""; int saveid = 0;
                    if (TbCommentaire.Text.Trim() != "")
                    {
                        int ji = 0, valcho = 0;
                        if (MyName.Value != "")
                            valcho = Convert.ToInt32(MyName.Value);
                        foreach (var ti in service.ListeCommentaire(-1, "", "", "", "", "", "", DateTime.Now))
                        {
                            ti.ID_COMMENTAIRE = ti.ID_COMMENTAIRE.Trim();
                            if (Convert.ToInt32(ti.ID_COMMENTAIRE)==valcho)
                            {
                                ji = 1;
                                savef = ti.FICHIER_COMMENTAIRE.Trim();
                                saveid = Convert.ToInt32(ti.ID_COMMENTAIRE.Trim());
                            }
                         
                        }
                        if (ji == 0)
                        {
                            int incrComment = 0;
                            foreach (var incr in service.ListeCommentaire(5, "", "", "", "", "", "", DateTime.Now))
                            {
                                incrComment = Int16.Parse(incr.ID_COMMENTAIRE.Trim());
                                incrComment++;
                            }

                            service.traiterCommentaire(2, id_user.Trim(), id_dossier.Trim(), "", incrComment.ToString(), TbCommentaire.Text.Trim(), fn, DateTime.Now);
                        }
                        else
                        {
                            if (fileTxt.PostedFile != null && fileTxt.PostedFile.ContentLength > 0)
                            {
                                if (id_user.Trim() == m)
                                    service.traiterCommentaire(3, id_user.Trim(), id_dossier.Trim(), "", MyName.Value.Trim(), TbCommentaire.Text.Trim(), fn, DateTime.Now);
                            }
                            else
                            {
                                if (id_user.Trim() == m && Convert.ToInt32(MyName.Value.Trim()) == saveid)
                                    service.traiterCommentaire(3, id_user.Trim(), id_dossier.Trim(), "", MyName.Value.Trim(), TbCommentaire.Text.Trim(), savef, DateTime.Now);
                            }
                        }
                    }
                }
            }
        }
    }
}