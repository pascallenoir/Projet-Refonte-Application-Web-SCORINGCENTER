using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ScoringCenter
{
    public partial class PremierePage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["nom_user"] == null) utilisateur.Text = Session["nom_user"].ToString();
            if (Session["login"] != null) utilisateur.Text = Session["nom_user"].ToString();
            else
            {
                //centerfoot.("text-align:center;");
                centerfoot.Attributes.Remove("class");
                centerfoot.Attributes.Remove("style");
                centerfoot.Attributes.Add("style", "text-align:center; margin-top:15px;");
                ACACHER.Attributes.Add("hidden", "hidden");
            }
        }
    }
}