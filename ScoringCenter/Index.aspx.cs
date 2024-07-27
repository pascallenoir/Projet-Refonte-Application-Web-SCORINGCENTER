using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ScoringCenter
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Redirect("~/Scoring/Connexion.aspx");
            //var URL = "~/Scoring/Connexion.aspx";
            //nownow.InnerHtml = "<script> window.open('" + URL + "'); return false; </script>";
        }
    }
}