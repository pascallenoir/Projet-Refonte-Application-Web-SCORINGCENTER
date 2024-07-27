using ScoringCenter.ScorManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ScoringCenter.Scoring
{
    public partial class HistoriqueNotation : System.Web.UI.Page
    {
        StringBuilder sb = new StringBuilder();
        StringBuilder sc = new StringBuilder();

        Scoringws service = new Scoringws();

        protected void Page_Load(object sender, EventArgs e)
        {
           // verifsession();
            ControllerPage();
            if (!IsPostBack)
            {

            }
            vergroupe_pays();

            lili();
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
                    if (element.ID_DROIT.ToString().Trim() == "HN")
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
            EBF.Visible = false; ////Fin_Controle////////////////////////////////////////////////////
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
                        //Idprincip.Text = v.ID_SCORING;
                        CodeAPE.Text = v.RCCM;
                        //AEntreprise.Text = v.SECTACT_LIBELLE;
                        SaiTypeClient.Text = v.TYPE_PROSPECT;
                        IdScoringCenter.Text = v.ID_SCORING;
                        Siren.Text = v.ACTBCEAO_LIBELLE;
                        Devise.Text = v.DEVISE;
                        ChiffreAffaire.Text = Convert.ToString(string.Format("{0:#,##0}", v.CA));
                        id_dossier = v.ID_DOSSIER;
                        if (v.GROUPE_DOSSIER != "") {  }
                        else {IG.Visible = false; }
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
            }
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            getInfoClient();
            AfficherHistorique();
        }
        protected void suppHisto(object sender, EventArgs e)
        {
            if (Session["id_user"] == null) Response.Redirect("~/Scoring/Connexion.aspx"); 

            service.PS_SCOR_SPY(Session["id_user"].ToString().Trim(), "HistoriqueNotation", connmou007.Value.ToString(), "S");
            var id_scoring = Session["id_scoring"].ToString();
            Session.Add("id_scoring", id_scoring);
            var id_dossier = Session["id_dossier"].ToString();
            Session.Add("id_dossier", id_dossier);
            service.suppHistoNotation(id_scoring);
            Response.Redirect("~/Scoring/HistoriqueNotation.aspx");

        }

        public void AfficherHistorique()
        {
            AfficherTableau();
        }

        void AfficherTableau()
        {
            if (Session["id_scoring"] == null) Response.Redirect("~/Scoring/Connexion.aspx"); 

            // var Vcouleur = Scoringws.Liste_TIMING(0, 0, "");
            // var couleur = Vcouleur[0].COULEUR_TIMING;
            // var nombre = Convert.ToInt32(Vcouleur[0].NOMBRE_TIMING);
            var id_scoring = Session["id_scoring"].ToString();
            Session.Add("id_scoring", id_scoring);
            var id_dossier = Session["id_dossier"].ToString();
            Session.Add("id_dossier", id_dossier);
            
            
           // ChartHistorique.Series.FirstOrDefault().Title = id_scoring;

            var listes = service.ListeHistorique(id_dossier, id_scoring);
            
            if (listes.Count != 0)
            {
                

                foreach (var v in listes)
                {
                    sc.AppendLine(string.Format("<tr title='Sélectionner la ligne'>"));
                    //ls.ID_SCORING.ToString())
                    //Encrypt(ls.ID_SCORING.ToString())
                    var datefi = "";
                    var notefi = "";
                    if (v.NOTE_AF != null && v.NOTE_AF.Trim() != "")
                    {
                        notefi = v.NOTE_AF.ToString();
                        if (v.DATE_NOTE_MODIF != null) datefi = v.DATE_NOTE_MODIF.Value.Date.Day.ToString() + "/" + v.DATE_NOTE_MODIF.Value.Date.Month.ToString() + "/" + v.DATE_NOTE_MODIF.Value.Date.Year.ToString();

                    }
                    var dateqa = "";
                   var notequa = "";
                   if (v.NOTE_AQ != null && v.NOTE_AQ.Trim() != "")
                   {
                       notequa = v.NOTE_AQ.ToString();
                       if (v.DATE_NOTE != null) dateqa = v.DATE_NOTE.Value.Date.Day.ToString() + "/" + v.DATE_NOTE.Value.Date.Month.ToString() + "/" + v.DATE_NOTE.Value.Date.Year.ToString();
                   }
                   var notesys = ""; if (v.NOTE_SYN != null) notesys = v.NOTE_SYN.ToString();
                    var dateprop = ""; 
                    var notepropos = "";
                    if (v.NOTE_PROP != null && v.NOTE_PROP.Trim() != "")
                    {
                        notepropos = v.NOTE_PROP.ToString();
                        if (v.DATE_PROP != null) dateprop = v.DATE_PROP.Date.Day.ToString() + "/" + v.DATE_PROP.Date.Month.ToString() + "/" + v.DATE_PROP.Date.Year.ToString();
                    }
                    var dateRe = "";
                    var noteval = "";
                    if (v.NOTE_VAL != null && v.NOTE_VAL.Trim() != "")
                    {
                        noteval = v.NOTE_VAL.ToString();
                        if (v.DATE_VAL != null) dateRe = v.DATE_VAL.Date.Day.ToString() + "/" + v.DATE_VAL.Date.Month.ToString() + "/" + v.DATE_VAL.Date.Year.ToString();
                    }

                    string userN = "";

                    if (v.NOTE_VAL.Trim() != "")
                    {
                        var listesUser = service.ListeHistoriqueUserName(v.ID_DOSSIER.Trim());

                        if (listesUser.Count != 0)
                        {
                            foreach (var U in listesUser)
                            {
                                userN = U.NOM_USER;
                            }

                        }
                    }

                    
                   
            
                    //if (couleurnote.Value.Days >= nombre) { couleurs = couleur; }


                    sc.AppendLine(string.Format("<td  onclick='ligneclick(this.title)'>{0} {1}</td>", notefi.ToString(), datefi));
                    sc.AppendLine(string.Format("<td  onclick='ligneclick(this.title)'>{0} {1}</td>", notequa.ToString(), dateqa));
                    if (notefi.ToString() == "" || notequa.ToString()=="") sc.AppendLine(string.Format("<td  onclick='ligneclick(this.title)' ></td>"));
                    else sc.AppendLine(string.Format("<td  onclick='ligneclick(this.title)' >{0}</td>", notesys.ToString()));
                    sc.AppendLine(string.Format("<td  onclick='ligneclick(this.title)'>{0} {1}</td>", notepropos.ToString(), dateprop));
                    sc.AppendLine(string.Format("<td  onclick='ligneclick(this.title)' >{0} {1}</td>", noteval.ToString(), dateRe.ToString()));
                    sc.AppendLine(string.Format("<td  onclick='ligneclick(this.title)' > {0}</td>", userN));
                   if( noteval.ToString().Trim()==""){
                       if (v.DECISION_PROP != null && v.DECISION_PROP != "")
                       {
                           sc.AppendLine("<td  onclick='ligneclick(this.title)' >rejeté</td>");
                       }
                       else
                       {
                           sc.AppendLine("<td  onclick='ligneclick(this.title)' >En cours</td>");
                       }
                   }
                   else
                   {
                       sc.AppendLine("<td  onclick='ligneclick(this.title)' >Validé</td>");
                       
                   }

                   
                  
                    sc.AppendLine("</tr>");
                }

               
            }
            ListDocTableauBord.InnerHtml = sc.ToString();
        }


        public void lili()
        {
            List<string> lili = new List<string>();

            if (Session["id_scoring"] == null) Response.Redirect("~/Scoring/Connexion.aspx"); 
          
            var id_scoring = Session["id_scoring"].ToString();
            var id_dossier = Session["id_dossier"].ToString();
            lili.Add(id_scoring);
            lili.Add(id_dossier);
            Session.Add("id_scoring", id_scoring);
            Session.Add("id_dossier", id_dossier);
            DataManager.id_dossier = id_dossier;
            DataManager.id_scoring = id_scoring;
            //}
            ChartData.lili = lili;
           
        }

        //public List<ChartData> GetData()
        //{//List<string> lili
        //    var id_scoring = Session["id_scoring"].ToString();
        //    Session.Add("id_scoring", id_scoring);
        //    var id_dossier = Session["id_dossier"].ToString();
        //    Session.Add("id_dossier", id_dossier);

        //    //string id_dossier = "";
        //    //string id_scoring = "";
        //    // List<string> lili = new List<string>();

        //    //lili = service.lili();

        //    //id_dossier = lili[1];
        //    //id_scoring = lili[0];


        //    var data = new List<ChartData>();
        //    var listes = service.ListeHistorique(id_dossier, id_scoring);

        //    if (listes.Count != 0)
        //    {
        //        data.Add(new ChartData("2016", 0, 0));
        //        var vnotefi = 0;
        //        var vnotequa = 0;
        //        var vnotesys = 0;
        //        var vnotepropos = 0;
        //        var vnoteval = 0;
        //        foreach (var v in listes)
        //        {

        //            //ls.ID_SCORING.ToString())
        //            //Encrypt(ls.ID_SCORING.ToString())
        //            var notefi = ""; if (v.noteAF != null) notefi = v.noteAF.ToString();
        //            var notequa = ""; if (v.noteAQ != null) notequa = v.noteAQ.ToString();
        //            var notesys = ""; if (v.notesy != null) notesys = v.notesy.ToString();
        //            var notepropos = ""; if (v.noteprop != null) notepropos = v.noteprop.ToString();
        //            var noteval = ""; if (v.noteval != null) noteval = v.noteval.ToString();
        //            var datefi = ""; if (v.dateAF != null) datefi = v.dateAF.Value.Date.Year.ToString();
        //            var dateqa = ""; if (v.dateAQ != null) dateqa = v.dateAQ.Value.Date.Year.ToString();
        //            var dateprop = ""; if (v.dateprop != null) dateprop = v.dateprop.Value.Date.Year.ToString();

        //            if (notefi == "A+") { vnotefi = 100; }
        //            if (notefi == "A") { vnotefi = 90; }
        //            if (notefi == "A-") { vnotefi = 80; }
        //            if (notefi == "B+") { vnotefi = 70; }
        //            if (notefi == "B") { vnotefi = 60; }
        //            if (notefi == "B-") { vnotefi = 50; }
        //            if (notefi == "C+") { vnotefi = 40; }
        //            if (notefi == "C") { vnotefi = 30; }
        //            if (notefi == "C-") { vnotefi = 20; }
        //            if (notefi == "D") { vnotefi = 10; }

        //            if (notequa == "A+") { vnotequa = 100; }
        //            if (notequa == "A") { vnotequa = 90; }
        //            if (notequa == "A-") { vnotequa = 80; }
        //            if (notequa == "B+") { vnotequa = 70; }
        //            if (notequa == "B") { vnotequa = 60; }
        //            if (notequa == "B-") { vnotequa = 50; }
        //            if (notequa == "C+") { vnotequa = 40; }
        //            if (notequa == "C") { vnotequa = 30; }
        //            if (notequa == "C-") { vnotequa = 20; }
        //            if (notequa == "D") { vnotequa = 10; }

        //            data.Add(new ChartData(dateqa, vnotefi, vnotequa));
        //            data.Add(new ChartData(dateqa + 1, vnotefi, vnotequa));

        //        }


        //    }
        //    //service.lilia(lili);
        //    return data;

        //    ////var info = service
        //    //var data = new List<ChartData>();
        //    //data.Add(new ChartData("", 0, 0));
        //    //data.Add(new ChartData("2014", 46, 0));
        //    //data.Add(new ChartData("2015", 46, 0));
        //    //data.Add(new ChartData("2016", 68, 0));
        //    ////data.Add(new ChartData("2014", 48));
        //    ////data.Add(new ChartData("2015", 48));
        //    ////data.Add(new ChartData("2016", 49.68));

        //    //return data;
        //}

        


    }
}