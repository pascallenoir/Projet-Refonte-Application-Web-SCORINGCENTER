using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ScoringCenter.Scoring
{
    public partial class DossierNotationGroupe : System.Web.UI.Page
    {
        StringBuilder sb = new StringBuilder();

        Scoringws service = new Scoringws();

        decimal CAtot = 0, CAtotG = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            dessinGraphique();
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

        protected void Page_Init(object sender, EventArgs e)
        {
            GetInfoClient();
            getInfoDossier();
          
        }

        public void GetInfoClient()
        {
            if (Session["id_dossier"] == null) Response.Redirect("~/Scoring/Connexion.aspx");
            if (string.IsNullOrEmpty(Request.QueryString["id"]))
            {
                if (string.IsNullOrEmpty(Session["id_scoring"].ToString()))
                    Response.Redirect("AutreDossier.aspx");
                else
                {
                    var idScoring = Session["id_scoring"].ToString();
                    Session.Add("id_scoring", idScoring);
                    var codeBanque = Session["code_banque"].ToString();
                    var info = service.DetailsDossierContrepartie(codeBanque, idScoring);
                    var idDossier = "";
                    foreach (var v in info)
                    {
                        NClient.Text = v.ETCIV_NOMREDUIT;
                        LabelNomDuGroupe.Text = v.ETCIV_NOMREDUIT;

                        //Idprincip.Text = v.ID_SCORING;
                        CodeAPE.Text = v.RCCM;
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
                        SaiTypeClient.Text = v.TYPE_PROSPECT;
                        IdScoringCenter.Text = v.ID_SCORING;
                        Siren.Text = v.ACTBCEAO_LIBELLE;
                        Devise.Text = v.DEVISE;
                        CAtotG = Convert.ToDecimal( v.CA);
                        ChiffreAffaire.Text = Convert.ToString(string.Format("{0:#,##0}", v.CA));
                        idDossier = v.ID_DOSSIER;
                        if (v.GROUPE_DOSSIER != "" && v.GROUPE_DOSSIER != null) { }
                        else { IG.Visible = false; }
                    }
                    Session.Add("id_dossier", idDossier);
                }
            }
            else
            {
                var idScoring = ScorCryptage.Decrypt(Request.QueryString["id"]);
                Session.Add("id_scoring", idScoring);
                var codeBanque = Session["code_banque"].ToString();
                var info = service.DetailsDossierContrepartie(codeBanque, idScoring);
                var idDossier = "";
                foreach (var v in info)
                {
                    NClient.Text = v.ETCIV_NOMREDUIT;
                    LabelNomDuGroupe.Text = v.ETCIV_NOMREDUIT;
                    //Idprincip.Text = v.ID_SCORING;
                    CodeAPE.Text = v.RCCM;
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
                    SaiTypeClient.Text = v.TYPE_PROSPECT;
                    IdScoringCenter.Text = v.ID_SCORING;
                    Siren.Text = v.ACTBCEAO_LIBELLE;
                    Devise.Text = v.DEVISE;
                    CAtotG = Convert.ToDecimal(v.CA);
                    ChiffreAffaire.Text = Convert.ToString(string.Format("{0:#,##0}", v.CA));
                    idDossier = v.ID_DOSSIER;
                  //  ModeleNotation.Text = v.MODELE_DOSSIER;
                    if (v.GROUPE_DOSSIER != "" && v.GROUPE_DOSSIER != null) { }
                    else { IG.Visible = false; }
                }
                Session.Add("id_dossier", idDossier);
            }

        }

        private void getInfoDossier()
        {
            //Session.Add("id_dossier", "1");
            if (Session["id_dossier"] == null) Response.Redirect("~/Scoring/Connexion.aspx");

            var idDossier = Session["id_dossier"].ToString();

            var elements = service.InfoDossier(idDossier);
            foreach (var dossier in elements)
            {
                ModeleNotation.Text = dossier.LIBELLE_MODELE;
                //NomGroupe.Text = dossier.GROUPE_DOSSIER;
                //NoteGroupe.Text = dossier.NOTE_GROUPE;
                //TNomGroupev.Text = dossier.NOTE_GROUPE;
                //TNomGroupe.Text = dossier.GROUPE_DOSSIER;
                StringBuilder sbFil = new StringBuilder();
                //if(dossier.NOTE_VAL != null)
                //{

                NoteGROUPE.Text = dossier.NOTE_AQ;

                var totval = service.SelectvaldesFiliales(dossier.GROUPE_DOSSIER);

                decimal tauxtot = 0;
                foreach (var f in service.ListeFiliale(dossier.GROUPE_DOSSIER))
                {
                    decimal jiji = 0, tauxx = 0;
                    var restt = service.SelectvalFiliale(f.ID_DOSSIER);
                    if (restt != null)
                    {
                        if (restt != 0)
                        {
                            if (totval != 0)
                                tauxx = 100 * (1 - (restt / totval));
                        }
                        else tauxx = 0;
                    }
                    else tauxx = 0;

                    tauxtot = tauxtot + tauxx;

                    if (f.CA != null) if (f.CA.ToString() != "") CAtot = CAtot + Convert.ToDecimal(f.CA);
                }
                foreach (var f in service.ListeFiliale(dossier.GROUPE_DOSSIER))
                {
                    var tv = "__"; if (f.PRECEDENTE_NOTE != null && f.PRECEDENTE_NOTE != "") tv = f.PRECEDENTE_NOTE;
                    if (f.NOTE_VAL != null) if (f.PRECEDENTE_NOTE != f.NOTE_VAL) if (f.NOTE_VAL.Trim() != "") tv = tv + "&nbsp;&nbsp;&nbsp; <span class=\"glyphicon glyphicon-arrow-right danger\"></span>&nbsp;&nbsp;&nbsp; <b class='text-danger'>" + f.NOTE_VAL + "</b>";
                    
                    //sbFil.AppendLine(string.Format("<li><span class='wrapper'><span class='border'>{0} : {1}</span></span></li>",
                    //    f.ETCIV_NOMREDUIT, tv));
                    //notifMessage.Visible = false;
                    //treeDiv.Visible = true;
                    //ListFiliale.InnerHtml = sbFil.ToString();

                    //f.ID_DOSSIER
                   

                    decimal jiji = 0, tauxx = 0;
                    var restt12 = service.SelectvalFiliale(f.ID_DOSSIER);
                    if (restt12 != null)
                    {
                        if (restt12 != 0)
                        {
                            if (totval != 0)
                                tauxx = (100 * (1 - (restt12 / totval)) / tauxtot)*100;
                        }
                        else tauxx = 0;
                    }
                    else tauxx = 0;
                    if (f.CA != null) if (f.CA.ToString() != "") if (CAtotG != null) if (CAtotG != 0) jiji = (Convert.ToDecimal(f.CA) / CAtotG) * 100;

                  //  if (f.CA != null) if (f.CA.ToString() != "") if (CAtot != null) if (CAtot != 0) jiji = Convert.ToDecimal(f.CA) / CAtot;
                    sb.AppendLine(string.Format("<tr>"));
                    sb.AppendLine(string.Format("<td>"));
                    sb.AppendLine(string.Format("{0}", f.ETCIV_NOMREDUIT));
                    sb.AppendLine(string.Format("</td>"));
                    sb.AppendLine(string.Format("<td>"));
                    sb.AppendLine(string.Format("{0}",tv));
                    sb.AppendLine(string.Format("</td>"));
                    sb.AppendLine(string.Format("<td>"));
                    sb.AppendLine(string.Format("{0}",jiji.ToString()));
                    sb.AppendLine(string.Format("</td>"));
                    sb.AppendLine(string.Format("<td>"));
                    sb.AppendLine(string.Format("{0}",tauxx.ToString("00.00")));
                    sb.AppendLine(string.Format("</td>"));
                    sb.AppendLine(string.Format("</tr>"));

                    ListDocTableauBord.InnerHtml = sb.ToString();

                }
                //}
                //else
                //{
                //    notifMessage.Visible = true;
                //    treeDiv.Visible = false;
                //}
            }
        }

        public void dessinGraphique()
        {
            if (Session["id_dossier"] == null) Response.Redirect("~/Scoring/Connexion.aspx");
            var idDossier = Session["id_dossier"].ToString();

            string myScript = "\n<script type=\"text/javascript\" language=\"Javascript\" id=\"EventScriptBlock\">\n";
            myScript += "$(document).ready(function () {";
            // Build the chart
            myScript += "Highcharts.chart('CamemberPartFinanciere', {";
            myScript += "chart: {";
            myScript += "plotBackgroundColor: null,";
            myScript += "plotBorderWidth: null,";
            myScript += "plotShadow: false,";
            myScript += "type: 'pie'";
            myScript += "},";
            myScript += "title: {text: 'Part CA Filiale'},";
            myScript += "tooltip: {pointFormat: '{series.name}: <b>{point.percentage:.1f}%</b>'},";
            myScript += "plotOptions: {pie: {allowPointSelect: true,cursor: 'pointer',";
            myScript += "dataLabels: {enabled: false},showInLegend: true}},";
            myScript += "series: [{ name: 'Portion',colorByPoint: true,data:";
            myScript += "\n [";

            var elements = service.InfoDossier(idDossier);
            foreach (var dossier in elements)
            {
                var totval = service.SelectvaldesFiliales(dossier.GROUPE_DOSSIER);
                var obj = service.ListeFiliale(dossier.GROUPE_DOSSIER);
                int i = 1;
                foreach (var f in obj)
                {
                    decimal jiji = 0, tauxx = 0;
                    var restt = service.SelectvalFiliale(f.ID_DOSSIER);
                    if (restt != null)
                    {
                        if (restt != 0)
                        {
                            if (totval != 0)
                                tauxx = 100*(1 - (restt / totval));
                        }
                        else tauxx = 0;
                    }
                    else tauxx = 0;
                    if (f.CA != null) if (f.CA.ToString() != "") if (CAtotG != null) if (CAtotG != 0) jiji = (Convert.ToDecimal(f.CA) / CAtotG) * 100;

                   // if (f.CA != null) if (f.CA.ToString() != "") if (CAtot != null) if (CAtot != 0) jiji = (Convert.ToDecimal(f.CA) / CAtot)*100;
                    //if (f.PART_DS_GROUPE != null) if (f.PART_DS_GROUPE.ToString() != "") jiji = Convert.ToDecimal(f.PART_DS_GROUPE);
                    if (f.ETCIV_NOMREDUIT != null) myScript += "{name: '" + f.ETCIV_NOMREDUIT.ToString() + "',";
                    myScript += "y:" + jiji.ToString().Replace(",", ".") + "},";
                    //if (i < obj.Count())
                    //{
                        
                    //    myScript += ",";
                    //}
                    i++;
                }
            }
            myScript += "{name: 'Residue',y:" + ((CAtotG - CAtot) * 100 / CAtotG).ToString().Replace(",", ".") + "}";
            myScript += " ]\n";
            //les donnees
            myScript += " }]});});";



            myScript += "$(document).ready(function () {";
            // Build the chart
            myScript += "Highcharts.chart('CamemberTaux', {";
            myScript += "chart: {";
            myScript += "plotBackgroundColor: null,";
            myScript += "plotBorderWidth: null,";
            myScript += "plotShadow: false,";
            myScript += "type: 'pie'";
            myScript += "},";
            myScript += "title: {text: 'Poids économique'},";
            myScript += "tooltip: {pointFormat: '{series.name}: <b>{point.percentage:.1f}%</b>'},";
            myScript += "plotOptions: {pie: {allowPointSelect: true,cursor: 'pointer',";
            myScript += "dataLabels: {enabled: false},showInLegend: true}},";
            myScript += "series: [{ name: 'Portion',colorByPoint: true,data:";
            myScript += "\n [";
            ////les donnees
            foreach (var dossier in elements)
            {
                var totval = service.SelectvaldesFiliales(dossier.GROUPE_DOSSIER);
                var obj = service.ListeFiliale(dossier.GROUPE_DOSSIER);
                int i = 1;
                foreach (var f in obj)
                {
                    decimal jiji = 0, tauxx = 0;
                    var restt = service.SelectvalFiliale(f.ID_DOSSIER);
                    if (restt != null)
                    {
                        if (restt != 0)
                        {
                            if (totval != 0)
                                tauxx = 100 * (1 - (restt / totval));
                        }
                        else tauxx = 0;
                    }
                    else tauxx = 0;
                    if (f.ETCIV_NOMREDUIT != null) myScript += " {name: '" + f.ETCIV_NOMREDUIT.ToString() + "',";
                    myScript += "y:" + tauxx.ToString().Replace(",",".") +"}";
                    if (i < obj.Count()) myScript += ",";
                    i++;
                }
            }
            myScript += " ]\n";
            //les donnees
            myScript += " }]});});";

            myScript += "\n\n </script>";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "myKey", myScript, false);
        }


        protected void BtnEnregistrer_ServerClick(object sender, EventArgs e)
        {
            if (Session["id_dossier"] == null) Response.Redirect("~/Scoring/Connexion.aspx");

            var idDossier = Session["id_dossier"].ToString();

            var elements = service.InfoDossier(idDossier);
            decimal resss = 0;

            foreach (var dossier in elements)
            {
               //decimal totval = 0;
                var totval = service.SelectvaldesFiliales(dossier.GROUPE_DOSSIER);
                decimal Ensemble = 0; int nbf=0, nb1=0, nb2=0;
                foreach (var f in service.ListeFiliale(dossier.GROUPE_DOSSIER))
                {
                    
                    decimal tauxx = 0;
                    var restt = service.SelectvalFiliale(f.ID_DOSSIER);
                    if (restt != null)
                    {
                        if (restt != 0)
                        {
                            if (totval != 0)
                                //taux pour calcule note est different de taux affiche

                                tauxx = (1 - (restt / totval));
                        }
                        else { tauxx = 0; }
                    }
                    else 
                    {
                        tauxx = 0; 
                    }
                    
                    if (baremeval(f.PRECEDENTE_NOTE) != 0 && tauxx!=0)
                    {
                        nb1++;
                        Ensemble = Ensemble + (baremeval(f.PRECEDENTE_NOTE) * tauxx);
                    }
                    if (baremeval(f.PRECEDENTE_NOTE) != 0 && tauxx == 0)
                    {
                        nb2++;
                        Ensemble = Ensemble + (baremeval(f.PRECEDENTE_NOTE));
                    }
                    

                    if (f.NOTE_VAL != null && f.NOTE_VAL != "")
                        service.MAJListeFiliale(f.ID_DOSSIER, f.NOTE_VAL);
                    else
                        service.MAJListeFiliale(f.ID_DOSSIER, "");

                    nbf++;
                }
                
                if (nbf != 0)
                {
                    if (nb2 == nbf)
                    {
                        resss = Ensemble / nbf;
                    }
                    if (nb2 != nbf)
                    {
                        if (nbf != 1)
                        resss = Ensemble / (nbf - 1);
                    }
                }

                NoteGROUPE.Text=baremenote(resss);

                
                
            }
            service.MAJGROUPENOTE(idDossier, baremenote(resss));
            Response.Redirect("~/Scoring/DossierNotationGroupe.aspx");
        }

        public decimal baremeval(string note)
        {
            if (note != null)
            {
                if (note.Trim() == "A+") return 19;
                if (note.Trim() == "A") return 17;
                if (note.Trim() == "A-") return 15;
                if (note.Trim() == "B+") return 13;
                if (note.Trim() == "B") return 11;
                if (note.Trim() == "B-") return 9;
                if (note.Trim() == "C+") return 7;
                if (note.Trim() == "C") return 5;
                if (note.Trim() == "C-") return 3;
                if (note.Trim() == "D") return 1;
            }
           

            return 0;
        }

        public string baremenote(decimal vale)
        {
            if (vale != null)
            {
            if (vale > 0 && vale <= 2) return "D";
            if (vale > 2 && vale <= 4) return "C-";
            if (vale > 4 && vale <= 6) return "C";
            if (vale > 6 && vale <= 8) return "C+";
            if (vale > 8 && vale <= 10) return "B-";
            if (vale > 10 && vale <= 12) return "B";
            if (vale > 12 && vale <= 14) return "B+";
            if (vale > 14 && vale <= 16) return "A-";
            if (vale > 16 && vale <= 18) return "A";
            if (vale > 18 && vale <= 20) return "A+";
            }
           
            return "";
        }

    }
}