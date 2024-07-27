using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using ScoringCenter.Scoring;

namespace ScoringCenter
{
    public partial class ChartData 
    {
        static Scoringws service = new Scoringws();

        public void AfficherTablu()
        {
            
            //var id_scoring = Session["id_scoring"].ToString();
            //Session.Add("id_scoring", id_scoring);
            //var id_dossier = Session["id_dossier"].ToString();
            //Session.Add("id_dossier", id_dossier);
           
            
            
        }

        //public static List<ChartData> GetData()
        //{
        //    ////var id_scoring = Session["id_scoring"].ToString();
        //    ////Session.Add("id_scoring", id_scoring);
        //    ////var id_dossier = Session["id_dossier"].ToString();
        //    ////Session.Add("id_dossier", id_dossier);

        //    //string id_dossier = "";
        //    //string id_scoring = "";
        //    //// List<string> lili = new List<string>();

            

        //    //id_dossier = lili[1];
        //    //id_scoring = lili[0];


        //    //var data = new List<ChartData>();
        //    //var listes = service.ListeHistorique(id_dossier, id_scoring);

        //    //if (listes.Count != 0)
        //    //{
        //    //    data.Add(new ChartData("0", 0, 0,0));
               
        //    //    var vnotefi = 0;
        //    //    var vnotequa = 0;
        //    //    var vnotesys = 0;
        //    //    var vnotepropos = 0;
        //    //    var vnoteval = 0;
        //    //    foreach (var v in listes)
        //    //    {

        //    //        //ls.ID_SCORING.ToString())
        //    //        //Encrypt(ls.ID_SCORING.ToString())
        //    //        var notefi = ""; if (v.noteAF != null) notefi = v.noteAF.ToString();
        //    //        var notequa = ""; if (v.noteAQ != null) notequa = v.noteAQ.ToString();
        //    //        var notesys = ""; if (v.notesy != null) notesys = v.notesy.ToString();
        //    //        var notepropos = ""; if (v.noteprop != null) notepropos = v.noteprop.ToString();
        //    //        var noteval = ""; if (v.noteval != null) noteval = v.noteval.ToString().Trim();
        //    //        var datefi = 0; if (v.dateAF != null) datefi = v.dateAF.Value.Date.Year;
        //    //        var dateqa = 0; if (v.dateAQ != null) dateqa = v.dateAQ.Value.Date.Year;
        //    //        var dateprop = 0; if (v.dateprop != null) dateprop = v.dateprop.Value.Date.Year;

        //    //        if (notesys.Trim() == "A+") { vnotesys = 100; }
        //    //        if (notesys.Trim() == "A") { vnotesys = 90; }
        //    //        if (notesys.Trim() == "A-") { vnotesys = 80; }
        //    //        if (notesys.Trim() == "B+") { vnotesys = 70; }
        //    //        if (notesys.Trim() == "B-") { vnotesys = 50; }
        //    //        if (notesys.Trim() == "C+") { vnotesys = 40; }
        //    //        if (notesys.Trim() == "C") { vnotesys = 30; }
        //    //        if (notesys.Trim() == "C-") { vnotesys = 20; }
        //    //        if (notesys.Trim() == "D") { vnotesys = 10; }

        //    //        if (noteval.Trim() == "A+") { vnoteval = 100; }
        //    //        if (noteval.Trim() == "A") { vnoteval = 90; }
        //    //        if (noteval.Trim() == "A-") { vnoteval = 80; }
        //    //        if (noteval.Trim() == "B+") { vnoteval = 70; }
        //    //        if (noteval.Trim() == "B") { vnoteval = 60; }
        //    //        if (noteval.Trim() == "B-") { vnoteval = 50; }
        //    //        if (noteval.Trim() == "C+") { vnoteval = 40; }
        //    //        if (noteval.Trim() == "C") { vnoteval = 30; }
        //    //        if (noteval.Trim() == "C-") { vnoteval = 20; }
        //    //        if (noteval.Trim() == "D") { vnoteval = 10; }

        //    //        if (notepropos.Trim() == "A+") { vnotepropos = 100; }
        //    //        if (notepropos.Trim() == "A") { vnotepropos = 90; }
        //    //        if (notepropos.Trim() == "A-") { vnotepropos = 80; }
        //    //        if (notepropos.Trim() == "B+") { vnotepropos = 70; }
        //    //        if (notepropos.Trim() == "B-") { vnotepropos = 50; }
        //    //        if (notepropos.Trim() == "C+") { vnotepropos = 40; }
        //    //        if (notepropos.Trim() == "C") { vnotepropos = 30; }
        //    //        if (notepropos.Trim() == "C-") { vnotepropos = 20; }
        //    //        if (notepropos.Trim() == "D") { vnotepropos = 10; }

        //    //        data.Add(new ChartData(dateqa.ToString(), vnotesys, vnoteval, vnotepropos));
        //    //        data.Add(new ChartData((dateqa + 1).ToString(), vnotesys, vnoteval, vnotepropos));

        //    //    }


        //    //}
        //    ////service.lilia(lili);
        //    //return data;

        //    //////var info = service
        //    ////var data = new List<ChartData>();
        //    ////data.Add(new ChartData("", 0, 0));
        //    ////data.Add(new ChartData("2014", 46, 0));
        //    ////data.Add(new ChartData("2015", 46, 0));
        //    ////data.Add(new ChartData("2016", 68, 0));
        //    //////data.Add(new ChartData("2014", 48));
        //    //////data.Add(new ChartData("2015", 48));
        //    //////data.Add(new ChartData("2016", 49.68));

        //    ////return data;
        //}

        public ChartData(string label, double value1, double value2, double value3)
        {
            this.Label = label;
            this.Value1 = value1;
            this.Value2 = value2;
            this.Value3 = value3;
        }

        public string Label { get; set; }
        public double Value1 { get; set; }
        public double Value2 { get; set; }
        public double Value3 { get; set; }
        public static List<string> lili;
    }
}