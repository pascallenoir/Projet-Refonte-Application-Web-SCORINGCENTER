using ScoringCenter.ScorManager;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ScoringCenter.Scoring
{
    public partial class SeuilDelegataire : System.Web.UI.Page
    {
        StringBuilder sb = new StringBuilder();
        StringBuilder sc = new StringBuilder();

        Scoringws service = new Scoringws();

        protected void Page_Load(object sender, EventArgs e)
        {
           // ControllerPage();
            if (!IsPostBack)
            {
                
            }
            
        }



        protected void Page_Init(object sender, EventArgs e)
        {
            ListeBanque();
            
        }

        public void ListeBanque()
        {
            if (Session["code_banque"] == null) Response.Redirect("~/Scoring/Connexion.aspx");

            // récupérer les banques appartenant au même groupe banque que la banque de l'utilisateur
            string param = Session["code_banque"].ToString();
            foreach (var element in service.ListeBanque(ScorCryptage.Decrypt(param)))
            {
                DdlBanque.Items.Add(new ListItem(element.SIGLE_BANQUE.ToString(), element.CODE_BANQUE));
            }
            AfficherTableau("" + DdlBanque.SelectedValue);
            CodeBanque11.Value = "" + DdlBanque.SelectedValue;
            //CodeBanque11.Value = ScorCryptage.Decrypt(Session["code_banque"].ToString());
        }
        protected void OnBanqueChangeLoadAgences(object sender, EventArgs e)
        {
            if (DdlBanque.SelectedValue != string.Empty)
            {
                AfficherTableau("" + DdlBanque.SelectedValue);
                CodeBanque11.Value = "" + DdlBanque.SelectedValue;
            }
        }

        public void AfficherTableau(string paramext)
        {
            var param = ScorCryptage.Decrypt(Session["code_banque"].ToString());
            if (paramext != null && paramext != "")
            {
                param = paramext;
            }

            StringBuilder tabl = new StringBuilder();
            if(DataManager.ListeSeuil(param).Count!=0){
                var tot = DataManager.ListeSeuil(param).Count;
                var ii = 0;
                foreach (var seuil in DataManager.ListeSeuil(param))
                {
                    ii++;
                    tabl.AppendLine(string.Format("<tr id=\"{0}\">", seuil.ID_SCOR_SEUIL_DELEGUATION));
                    tabl.AppendLine(string.Format("<td style=\"min-height:34px\" class='text-left min'>{0}</td>", Convert.ToDecimal(seuil.MIN_SCOR_SEUIL_DELEGUATION).ToString("#,##0.##")));
                    if (seuil.MAX_SCOR_SEUIL_DELEGUATION.ToString() == Int64.MaxValue + "")
                        tabl.AppendLine(string.Format("<td style=\"min-height:34px\" class='text-left'>illimité</td>"));
                    else
                        tabl.AppendLine(string.Format("<td style=\"min-height:34px\" class='text-left'>{0}</td>", Convert.ToDecimal(seuil.MAX_SCOR_SEUIL_DELEGUATION).ToString("#,##0.##")));

                    tabl.AppendLine(string.Format("</tr>"));
                }
                
            }
            else
            {
                tabl.AppendLine(string.Format("<tr>"));
                tabl.AppendLine(string.Format("<td style=\"min-height:34px\" class='text-left min'>0</td>"));
                tabl.AppendLine(string.Format("<td style=\"min-height:34px\" class='text-left'>illimité</td>"));
                tabl.AppendLine(string.Format("</tr>"));
            }
            Tbody1.InnerHtml = tabl.ToString();
            
        }

        protected void nbintervalle_ServerChange(object sender, EventArgs e)
        {
            StringBuilder tabl = new StringBuilder();
            var nbligne = Convert.ToInt32(nbintervalle.Text.Trim());
            if (nbligne != 0)
            {
                for (var i = 0; i < nbligne; i++)
                {
                    tabl.AppendLine(string.Format("<tr>"));

                    if (i == 0)
                        tabl.AppendLine(string.Format("<td style=\"min-height:34px\" class='text-left min'>0</td>"));
                    else
                        tabl.AppendLine(string.Format("<td style=\"min-height:34px\" class='text-left min'></td>"));

                    if (i == (nbligne-1))
                        tabl.AppendLine(string.Format("<td style=\"min-height:34px\" class='text-left'>illimité</td>"));
                    else
                        tabl.AppendLine(string.Format("<td style=\"min-height:34px\" class='text-left'></td>"));

                    tabl.AppendLine(string.Format("</tr>"));
                }
            }
            else
            {
                tabl.AppendLine(string.Format("<tr>"));
                tabl.AppendLine(string.Format("<td style=\"min-height:34px\" class='text-left min'>0</td>"));
                tabl.AppendLine(string.Format("<td style=\"min-height:34px\" class='text-left'>illimité</td>"));
                tabl.AppendLine(string.Format("</tr>"));
            }
            Tbody1.InnerHtml = tabl.ToString();
            
        }

        //public 
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static bool[] insertValInt(string text)
        {
            bool[] res = new bool[1];
            var recup=text.Split('@');
            var cODE_BANQUE = recup[0].Trim();
            //var Position=Convert.ToInt32(recup[1].Trim());
            try
            {
                var mAX_SCOR_SEUIL_DELEGUATION = Convert.ToInt64(recup[2].Trim().Replace("illimité", Int64.MaxValue+""));
                var mIN_SCOR_SEUIL_DELEGUATION = Convert.ToInt64(recup[3].Trim());
                res[0] = DataManager.InsertSeuil(cODE_BANQUE, "", mAX_SCOR_SEUIL_DELEGUATION, mIN_SCOR_SEUIL_DELEGUATION);
                return res;
                //res[0] = sbS.ToString();
            } 
            catch(Exception e)
            {
                return res;
            }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static bool[] suppValInt(string text)
        {
            bool[] res = new bool[1];

            res[0] = DataManager.suppValInt(text.Trim());
            //res[0] = sbS.ToString();
            return res;
        }
    }
}