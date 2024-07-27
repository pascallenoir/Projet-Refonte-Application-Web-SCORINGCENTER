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

        protected void Page_Load(object sender, EventArgs e)
        {
           
            ControllerPage();
            id_user = Session["id_user"].ToString();
            
            vergroupe_pays();
        }
        public void vergroupe_pays()
        {
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
            if (Session["login"] == null) Response.Redirect("~/Scoring/Connexion.aspx");
            else
            {
                var idprofil = Session["id_profil"].ToString();
                var elements = service.VHABILITATION(idprofil);
                AD.Visible = false;
                TB.Visible = false;
                FS.Visible = false;
                HN.Visible = false;
                DN.Visible = false;
                AF.Visible = false;
                AQ.Visible = false;
                IG.Visible = false;
                RP.Visible = false;
                E.Visible = false;
                VN.Visible = false;
                AN.Visible = false;
                EBF.Visible = false;

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
                    if (element.ID_DROIT.ToString().Trim() == "AF")
                    {
                        if (element.ID_TYPE_DROIT.ToString().Trim() != "0") AF.Visible = true;
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
            ////Fin_Controle////////////////////////////////////////////////////
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            getInfoClient();
        }

        public void getInfoClient()
        {
            if (string.IsNullOrEmpty(Request.QueryString["id"]))
            {
                if (string.IsNullOrEmpty(Session["id_scoring"].ToString()))
                    Response.Redirect("AutreDossier.aspx");
                else
                {
                    var id_scoring = Session["id_scoring"].ToString();
                    Session.Add("id_scoring", id_scoring);
                    string id_dossier = "";
                    var code_banque = Session["code_banque"].ToString();
                    var info = service.DetailsDossierContrepartie(code_banque, id_scoring);
                    foreach (var v in info)
                    {
                        NClient.Text = v.ETCIV_NOMREDUIT;
                        //Idprincip.Text = v.ID_SCORING;
                        CodeAPE.Text = v.RCCM;
                        //AEntreprise.Text = v.SECTACT_LIBELLE;
                        SaiTypeClient.Text = v.TYPE_PROSPECT;
                        IdScoringCenter.Text = v.ID_SCORING;
                        Siren.Text = v.ACTBCEAO_LIBELLE;
                        Devise.Text = v.DEVISE;
                        ChiffreAffaire.Text = Convert.ToString(string.Format("{0:#,##0}", v.CA));
                        id_dossier = v.ID_DOSSIER;
                        if (v.GROUPE_DOSSIER != "") { }
                        else { IG.Visible = false; }
                    }
                    Session.Add("id_dossier", id_dossier);
                    listCommentaire(id_scoring);
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
                    //Idprincip.Text = v.ID_SCORING;
                    CodeAPE.Text = v.RCCM;
                    //AEntreprise.Text = v.SECTACT_LIBELLE;
                    SaiTypeClient.Text = v.TYPE_PROSPECT;
                    IdScoringCenter.Text = v.ID_SCORING;
                    Siren.Text = v.ACTBCEAO_LIBELLE;
                    Devise.Text = v.DEVISE;
                    ChiffreAffaire.Text = Convert.ToString(string.Format("{0:#,##0}", v.CA));
                    id_dossier = v.ID_DOSSIER;
                    if (v.GROUPE_DOSSIER != "") { }
                    else { IG.Visible = false; }
                }
                Session.Add("id_dossier", id_dossier);
                listCommentaire(id_scoring);
            }
        }

        public void listCommentaire(string id_scoring)
        {
            var listcommentaire = service.ListeCommentaire(0, "", "", id_scoring, "", "", "", DateTime.Now);
            if (listcommentaire.Count != 0)
            {
                id_user = Session["id_user"].ToString();
                foreach (var rel in listcommentaire)
                {
                    string totovi = "";
                    string nom_User = service.ListeCommentaire(6, rel.ID_USER, "", "", "", "", "", DateTime.UtcNow)
                       .Where(nUser => nUser.NOM_USER != "").SingleOrDefault().NOM_USER;
                    sb.AppendLine("<div class=\"row\" style=\"margin-bottom: 2%;\" >");
                    sb.AppendLine("<div class=\"col-lg-7 col-sm-7 col-md-7 col-sm-off container text-left\" style=\"overflow:hidden\">");
                    sb.AppendLine(string.Format("<textarea hidden=\"hidden\" name=\"{2}\" id=\"{1}\">{0}</textarea>",rel.TEXTE_COMMENTAIRE, rel.ID_COMMENTAIRE.ToString().Trim(), rel.ID_USER.ToString().Trim()));
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
                        sb.AppendLine(string.Format("<a class=\"btn btn-sm\" style=\"background: rgba(0, 0, 0, 0.00);padding:0px;margin:0px\" onclick=\"recharger({0},{1})\" id=\"1{0}\" title=\"Modifier\"><span class=\" glyphicon glyphicon-edit\"></span></a>", rel.ID_COMMENTAIRE.ToString().Trim(), rel.ID_USER.ToString().Trim()));
                        sb.AppendLine(string.Format(" <a class=\"btn btn-sm\" style=\"background: rgba(0, 0, 0, 0.00);padding:0px;margin:0px\" href=\"#SUPPMODAL\"   onmousedown=\"Unnamed1_Click({0},{1})\"  data-target=\"#SUPPMODAL\"  data-toggle=\"modal\" id=\"\" title=\"Supprimer\"><span class=\" glyphicon glyphicon-trash\"></span></a>", rel.ID_COMMENTAIRE.ToString(), rel.ID_USER.ToString().Trim()));
                    
                    }
                    else
                    {
                        sb.AppendLine(string.Format("<div class=\"btn btn-sm\" style=\"background: rgba(0, 0, 0, 0.00);\"><span class=\" \"></span></div>"));
                        sb.AppendLine(string.Format("<div class=\"btn btn-sm\" style=\"background: rgba(0, 0, 0, 0.00);\"><span class=\" \"></span></div>"));
                    }
                   sb.AppendLine("</div>");
                   sb.AppendLine("</div>");
                   sb.AppendLine("<hr/>");
                }
                intermess.InnerHtml = sb.ToString();
            }
        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            string m = "";
            if (MyNameUs.Value != "") m = MyNameUs.Value;
            ValiderVN_Click(m);
            Response.Redirect("Annotations.aspx");
        }

        protected void Unnamed2_Click(object sender, EventArgs e)
        {
            string m = "";
            if (MyNameUs.Value != "") m = MyNameUs.Value.Trim();
            if (id_user.Trim() == m)
                SupprimerVN_Click(m);
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
            string saveLocation = "", fn = "";
            var param = Session["id_scoring"].ToString();
            Session.Add("id_scoring", param);
            var listenote = service.ListeCommentaire(1, "", "", param, "", "", "", DateTime.Now);
            var id_dossier = Session["id_dossier"].ToString();

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