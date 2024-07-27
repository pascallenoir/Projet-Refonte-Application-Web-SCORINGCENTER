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
        private static string ETCIV_MATRICULE = "";
        Scoringws service = new Scoringws();
        private System.Globalization.CultureInfo frCult = System.Globalization.CultureInfo.CreateSpecificCulture("fr-FR");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["id_scoring"] == null) Response.Redirect("~/Scoring/Connexion.aspx");
            ControllerPage();
            dessinGraphique();
            if (!IsPostBack)
            {
                //getInfoClient();
            }
            lili();
        }
        public void DemoFonct()
        {
            AF1.Visible = true;
            AS.Visible = false;
            AF2.Visible = false;
            IG.Visible = false;
            RP.Visible = false;
        }
        public void verifSession(){
            if (Session["id_scoring"] == null) Response.Redirect("~/Scoring/Connexion.aspx");
            
        }
        private String affectValeurCalReel(string notequa)
        {
            String laNoteReel="0";
            if (notequa == "A+") { laNoteReel = "20"; }
            else if (notequa == "A") { laNoteReel = "17.7"; }
            else if (notequa == "A-") { laNoteReel = "15.4"; }
            else if (notequa == "B+") { laNoteReel = "13.1"; }
            else if (notequa == "B") { laNoteReel = "10.8"; }
            else if (notequa == "B-") { laNoteReel = "8.5"; }
            else if (notequa == "C+") { laNoteReel = "6.2"; }
            else if (notequa == "C") { laNoteReel = "3.9"; }
            else if (notequa == "C-") { laNoteReel = "1.6"; }
            else if (notequa == "D") { laNoteReel = "0"; }
            else { laNoteReel = "0"; }
            return laNoteReel;
        }
        public void dessinGraphique()
        {
            verifSession();
            var id_scoring = Session["id_scoring"].ToString();
            Session.Add("id_scoring", id_scoring);
            var id_dossier = Session["id_dossier"].ToString();
            Session.Add("id_dossier", id_dossier);
            string myScript = "\n<script type=\"text/javascript\" language=\"Javascript\" id=\"EventScriptBlock\">\n";
            //*****************charte entete**************************
            myScript += "Highcharts.chart('GraphContainer', {";
 myScript += "   chart: {";
  myScript += "      zoomType: 'xy'";
   myScript += " },";
myScript += "    title: {";
 myScript += "       text: 'Historique des Notes Validées'";
  myScript += "  },";
   myScript += " subtitle: {";
    myScript += "    text: 'Source: Scoring'";
 myScript += "   },";
  myScript += "  xAxis: [{";
  myScript += "     categories: [";

  //****************chate contenue code*******************
  var listes = service.ListeHistorique(id_dossier, id_scoring);
  int compteDossier = listes.Count;
  if (compteDossier != 0)
  {
      int i = 1;
      foreach (var v in listes)
      {
          string Dateindividuel =v.DATE_VAL.ToString("MM")+"/"+ v.DATE_VAL.ToString("yyyy");

          myScript += "'" + Dateindividuel + "'";
          if (i < compteDossier) myScript += ",";
          i++;
      }
  }
    myScript += "],";
     myScript += "   crosshair: true";
myScript += "    }],";
 myScript += "   yAxis: [{ // Primary yAxis";
 myScript += "  \n     labels: {";
   myScript += "         format: '{value}',"; /*"         format: '{value}°C',"*/
    myScript += "        style: {";
     myScript += "           color: Highcharts.getOptions().colors[1]";
      myScript += "      }";
       myScript += " },";
myScript += "        title: {";
 myScript += "           text: 'Note Proposée',";
  myScript += "          style: {";
   myScript += "             color: Highcharts.getOptions().colors[1]";
    myScript += "        }";
     myScript += "   }";
myScript += "    }, { // Secondary yAxis";
myScript += " \n       title: {";
  myScript += "          text: 'Note Proposée',";
   myScript += "         style: {";
    myScript += "            color: Highcharts.getOptions().colors[0]";
     myScript += "       }";
      myScript += "  },";
myScript += "        labels: {";
 myScript += "           format: '{value} ',"; /*"           format: '{value} mm',"*/
  myScript += "          style: {";
   myScript += "             color: Highcharts.getOptions().colors[0]";
    myScript += "        }";
     myScript += "   },";
      myScript += "  opposite: true";
myScript += "    }],";
 myScript += "   tooltip: {";
  myScript += "      shared: true";
   myScript += " },";
    myScript += "legend: {";
     myScript += "   layout: 'vertical',";
      myScript += "  align: 'left',";
       myScript += " x: 0,";
        myScript += "verticalAlign: 'top',";
myScript += "        y: 0,";
 myScript += "       floating: true,";
  myScript += "      backgroundColor: (Highcharts.theme && Highcharts.theme.legendBackgroundColor) || '#FFFFFF'";
   myScript += " },";
 myScript += "   series: [";
  myScript += "      {";
   myScript += "      name: 'Note Validée',";
   myScript += "     type: 'column',";
    myScript += "    yAxis: 1,";
    myScript += "   data: [";

    //********************
    if (compteDossier != 0)
    {
        int i = 1;
        foreach (var v in listes)
        {
            //myScript += "   49.9, 71.5, 106.4, 129.2, 144.0, 176.0, 135.6, 148.5, 216.4, 194.1, 95.6, 54.4";
            myScript += "" + affectValeurCalReel(v.NOTE_VAL.ToString().Trim()) + "";
            if (i < compteDossier) myScript += ",";
            i++;
        }
    }
    myScript += "  ],";
    //**********************
      myScript += "  tooltip: {";
        myScript += "     valueSuffix: ' '";/*"     valueSuffix: ' mm'"*/
           myScript += "\n}";
 

                    


myScript += "\n";
 myScript += "   }, {\n";
  myScript += "      name: 'Note Validée',";
   myScript += "     type: 'spline',";
   myScript += "   data: [";

   //********************
   if (compteDossier != 0)
   {
       int i = 1;
       foreach (var v in listes)
       {
           //myScript += "   49.9, 71.5, 106.4, 129.2, 144.0, 176.0, 135.6, 148.5, 216.4, 194.1, 95.6, 54.4";
           myScript += "" + affectValeurCalReel(v.NOTE_VAL.ToString().Trim()) + "";
           if (i < compteDossier) myScript += ",";
           i++;
       }
   }
   myScript += "  ],";
     myScript += "   tooltip: {";
     myScript += "      valueSuffix: ' '";/*"      valueSuffix: '°C'"*/
       myScript += " }";
       myScript += "    }";
        myScript += "    ]";
       myScript += "});";

            myScript += "\n\n </script>";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "myKey", myScript, false);
        }

         //public void dessinGraphique()
        //{
        //    verifSession();
        //    var id_scoring = Session["id_scoring"].ToString();
        //    Session.Add("id_scoring", id_scoring);
        //    var id_dossier = Session["id_dossier"].ToString();
        //    Session.Add("id_dossier", id_dossier);

        //    //*****************charte entete**************************
        //    string myScript = "\n<script type=\"text/javascript\" language=\"Javascript\" id=\"EventScriptBlock\">\n";
        //    myScript += "Highcharts.chart('GraphContainer', {";
        //    myScript += " chart: {";
        //    myScript += " type: 'column'";
        //    myScript += " },";
        //    myScript += "title: {";
        //    myScript += " text: 'Graphique'";
        //    myScript += "  },";
        //    myScript += " xAxis: {";
        //    myScript += " categories: [";
        //    //****************chate contenue code*******************
        //    var listes = service.ListeHistorique(id_dossier, id_scoring);
        //    int compteDossier=listes.Count;
        //    if ( compteDossier!= 0)
        //    {
        //        int i = 1;
        //        foreach (var v in listes)
        //        {
        //            string Dateindividuel =v.DATE_VAL.ToString("yyyy");

        //            myScript += "'" + Dateindividuel + "'";
        //            if (i < compteDossier) myScript += ",";
        //            i++;
        //        }
        //    }

        //    //*****************charte Body**************************
        //    myScript += "  ]";
        //    myScript += "  },";
        //    myScript += " yAxis: [{";
        //    myScript += " min: 0,";
        //    myScript += "   title: {";
        //    myScript += " text: 'Note'";
        //    myScript += " }";
        //    myScript += "  }, {";
        //    myScript += "  title: {";
        //    myScript += "   text: 'Note'";
        //    myScript += "   },";
        //    myScript += "  opposite: true";
        //    myScript += "  }],";
        //    myScript += " legend: {";
        //    myScript += " shadow: false";
        //    myScript += " },";
        //    myScript += "  tooltip: {";
        //    myScript += "  shared: true";
        //    myScript += "  },";
        //    myScript += "  plotOptions: {";
        //    myScript += "  column: {";
        //    myScript += "   grouping: false,";
        //    myScript += "  shadow: false,";
        //    myScript += " borderWidth: 0";
        //    myScript += " }";
        //    myScript += "  },";
        //    myScript += "\n series:\n [";

        //    //****************chate contenue code*******************

        //    if (compteDossier != 0)
        //    {
        //        myScript += "{name: 'Note Calculée',";
        //        myScript += "color: 'rgba(165,170,217,1)',";
        //        int i = 1;
        //        myScript += "data: [";

        //        foreach (var v in listes)
        //        {
        //            myScript += "" + affectValeurCalReel(v.NOTE_SYN.ToString().Trim()) + "";

        //            if (i < compteDossier) myScript += ",";
        //            i++;
        //        }
        //        myScript += "],";
        //        myScript += "pointPadding: 0.3,";
        //        myScript += "pointPlacement: -0.2},";
        //    }

        //    if (compteDossier != 0)
        //    {
        //        myScript += "\n{name: 'Note Validée',";
        //        myScript += "color: 'rgba(126,86,134,.9)',";
        //        int i = 1;
        //        myScript += "data: [";

        //        foreach (var v in listes)
        //        {
        //            myScript += "" + affectValeurCalReel(v.NOTE_VAL.ToString().Trim()) + "";
        //            if (i < compteDossier) myScript += ",";
        //            i++;
        //        }
        //        myScript += "],";
        //        myScript += "pointPadding: 0.4,";
        //        myScript += "pointPlacement: -0.2}\n";
        //    }

        //    //*****************charte Footer**************************
        //    myScript += "\n]";
        //    myScript += "});";
        //    //*******************************************
        //    myScript += "\n\n </script>";
        //    Page.ClientScript.RegisterStartupScript(this.GetType(), "myKey", myScript, false);
        //}
        public void vergroupe_pays()
        {
            if (Session["id_scoring"] == null) Response.Redirect("~/Scoring/Connexion.aspx");
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

        public void getInfoClient()
        {
            if (string.IsNullOrEmpty(Request.QueryString["id"]))
            {
                if (Session["id_scoring"]==null || Session["id_scoring"].ToString().Trim()=="" )
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
                        ETCIV_MATRICULE = v.ETCIV_MATRICULE;
                        NClient.Text = v.ETCIV_NOMREDUIT;
                        Idprincip.Text = v.TYPE_PROSPECT.Equals("Prospect") ? v.ID_SCORING : v.ETCIV_MATRICULE;
                        //CodeAPE.Text = v.RCCM;
                        //AEntreprise.Text = v.SECTACT_LIBELLE;
                        if (v.LIBELLE_MODELE.Trim() == "Groupe")
                        {
                            
                            DQTH.InnerHtml = "Données Structurelle";
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


                    service.ENREGISTREMENT_ENCOURS(id_dossier.Trim(), ETCIV_MATRICULE.Trim());
                    Session.Add("id_dossier", id_dossier);
                   // Session["id_dossier"] = id_dossier;
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
                    ETCIV_MATRICULE = v.ETCIV_MATRICULE;
                    NClient.Text = v.ETCIV_NOMREDUIT;
                    Idprincip.Text = v.TYPE_PROSPECT.Equals("Prospect") ? v.ID_SCORING : v.ETCIV_MATRICULE;
                    //CodeAPE.Text = v.RCCM;
                    //AEntreprise.Text = v.SECTACT_LIBELLE;
                    if (v.LIBELLE_MODELE.Trim() == "Groupe")
                    {
                        DQTH.InnerHtml = "Données Structurelle";
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
                service.ENREGISTREMENT_ENCOURS(id_dossier.Trim(), ETCIV_MATRICULE.Trim());
                // Session["id_dossier"] = id_dossier;
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

                    sc.AppendLine(string.Format("<tr   >"));
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
                   var noteOpera = ""; if (v.NOTE_OP != null) noteOpera = v.NOTE_OP.ToString();
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
                                userN = U.NOM_USER.ToUpper() + " " + U.PRENOM_USER;
                            }

                        }
                    }
                    if (userN.Length > 23)
                        userN = userN.Substring(0, 24);

                    if (notefi == "")
                    {
                        notesys = notequa;
                    }

                    if (notequa == "")
                    {
                        notesys = "";
                    }

                    string modeleNotation = AnalyseFinanciere.getModeleNotation(v.ID_DOSSIER);

                    //if (couleurnote.Value.Days >= nombre) { couleurs = couleur; }

                    //noteOpera
                    sc.AppendLine(string.Format("<td>{0}</td>", notefi.ToString()));
                    sc.AppendLine(string.Format("<td>{0}</td>", notequa.ToString()));
                    //if (notefi.ToString() == "" || notequa.ToString() == "") sc.AppendLine(string.Format("<td ></td>"));else 
                    sc.AppendLine(string.Format("<td>{0}</td>", notesys.ToString()));
                    sc.AppendLine(string.Format("<td>{0}</td>", noteOpera.ToString()));
                    sc.AppendLine(string.Format("<td>{0}</td>", notepropos.ToString()));
                    sc.AppendLine(string.Format("<td>{0}</td>", noteval.ToString()));
                    sc.AppendLine(string.Format("<td>{0}</td>", dateRe.ToString()));
                    sc.AppendLine(string.Format("<td>{0}</td>", "-"));
                    sc.AppendLine(string.Format("<td>{0}</td>", "-"));
                    sc.AppendLine(string.Format("<td>{0}</td>", modeleNotation ));
                    //sc.AppendLine(string.Format("<td class='text-left'> {0}</td>", userN));
                    if (noteval.ToString().Trim() == "") {
                        sc.AppendLine("<td >En cours</td>");
                    } else if (DateTime.Now.Year - Convert.ToInt32(dateRe.ToString().Trim().Substring(dateRe.ToString().Trim().Length - 4)) > 1) {
                        sc.AppendLine("<td >Expiré</td>");
                    } else { 
                        sc.AppendLine("<td >Validé</td>");
                    }

                   sc.AppendLine(string.Format("<td ><div class=\" btn-sm btn-primary button_div\""+
                                   " style=\"margin-right: 5px; color:#022451; background-color:#ffffff; height: 24px; border: none; padding-top: 0px; padding-bottom: 0px;\""+
                                   " title=\"Detail\"  onclick='ligneclick({0})' >" +
                                    "<span class=\" glyphicon glyphicon-print\"></span>"+
                                "</div></td>", v.ID_DOSSIER.Trim()));
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