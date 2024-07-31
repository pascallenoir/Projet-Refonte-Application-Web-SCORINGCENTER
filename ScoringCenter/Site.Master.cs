
using ScoringCenter.Scoring;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Web.Script.Services;
using ScoringCenter.ScorManager;
using System.Web.Optimization;
using System.Web.Services.Description;

namespace ScoringCenter
{
    public partial class SiteMaster : MasterPage
    {
        private const string AntiXsrfTokenKey = "__AntiXsrfToken";
        private const string AntiXsrfUserNameKey = "__AntiXsrfUserName";
        private string _antiXsrfTokenValue;
        Scoringws service1 = new Scoringws();
        StringBuilder sbLogoBanque = new StringBuilder();
        StringBuilder sbNomBanque = new StringBuilder();


        protected void Page_Init(object sender, EventArgs e)
        {
            // The code below helps to protect against XSRF attacks
            var requestCookie = Request.Cookies[AntiXsrfTokenKey];
            Guid requestCookieGuidValue;
            if (requestCookie != null && Guid.TryParse(requestCookie.Value, out requestCookieGuidValue))
            {
                // Use the Anti-XSRF token from the cookie
                _antiXsrfTokenValue = requestCookie.Value;
                Page.ViewStateUserKey = _antiXsrfTokenValue;
            }
            else
            {
                // Generate a new Anti-XSRF token and save to the cookie
                _antiXsrfTokenValue = Guid.NewGuid().ToString("N");
                Page.ViewStateUserKey = _antiXsrfTokenValue;

                var responseCookie = new HttpCookie(AntiXsrfTokenKey)
                {
                    HttpOnly = true,
                    Value = _antiXsrfTokenValue
                };
                if (FormsAuthentication.RequireSSL && Request.IsSecureConnection)
                {
                    responseCookie.Secure = true;
                }
                Response.Cookies.Set(responseCookie);
            }

            Page.PreLoad += master_Page_PreLoad;
        }

        protected void master_Page_PreLoad(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Set Anti-XSRF token
                ViewState[AntiXsrfTokenKey] = Page.ViewStateUserKey;
                ViewState[AntiXsrfUserNameKey] = Context.User.Identity.Name ?? String.Empty;
            }
            else
            {
                // Validate the Anti-XSRF token
                if ((string)ViewState[AntiXsrfTokenKey] != _antiXsrfTokenValue
                    || (string)ViewState[AntiXsrfUserNameKey] != (Context.User.Identity.Name ?? String.Empty))
                {
                    throw new InvalidOperationException("Validation of Anti-XSRF token failed.");
                }

            }

            AfficheLogoBank();
        }

        public void AfficheLogoBank()
        {
            if (Session["code_banque"] != null)
            {
                string code_banque;
                try
                {
                    code_banque = ScorCryptage.Decrypt(Session["code_banque"].ToString());
                }
                catch (Exception e)
                {
                    code_banque = Session["code_banque"].ToString();
                }
                var bankInfo = service1.AfficheLogoBank(code_banque);
                foreach (var banque in bankInfo)
                {

                    if (banque.IMG_BANQUE != "" && banque.IMG_BANQUE != null)
                    {
                        sbLogoBanque.AppendLine(string.Format("<img src=\"../Images/Logo/{0}\"style=\"width: 100% ;height:100%\" />", banque.IMG_BANQUE.ToString().Trim()));
                    }
                }
                idimgLogoBanque.InnerHtml = sbLogoBanque.ToString();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (Session["login"] == null) Response.Redirect("~/Scoring/Connexion.aspx");
            if (Session["nom_user"] != null) utilisateur.Text = Session["nom_user"].ToString();
            verEtatDossier();
            //AfficheLogoBank();
            if (HttpContext.Current.Request.Url.AbsolutePath == "/Scoring/ValidationNote.aspx")
            controlDelegation();
        }


        protected void gotoHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Scoring/Connexion.aspx");
        }

        public void controlDelegation()
        {
            var idDossier = Session["id_dossier"].ToString();
            Session.Add("id_dossier", idDossier);
            var docs = "";
            var decompte = DataManager.Ps_scor_get_seuil_dossier(idDossier);
            if (decompte.Count == 0)
            {
                //griser
                heba.InnerHtml = "<script>$(':input').attr('disabled','disabled');</script>" +
                "<script>$('.bg-claire').addClass('bg-sombre');</script>" +
            "<script>$('#messageEtat').html('Veuillez Renseigner le Montant du crédit de l\'opération');</script>";

            }
        }
    
        public void verEtatDossier()
        {
            var id_scoring = ""; if (Session["id_scoring"] != null)
            {
                var noval = "La Note du Dossier est : ";
                id_scoring = Session["id_scoring"].ToString();
                string code_banque;
                try{
                    code_banque = ScorCryptage.Decrypt(Session["code_banque"].ToString());
                }
                catch (Exception e) { 
                    code_banque = Session["code_banque"].ToString();
                }

                var id_profil = "";
               if (Session["id_profil"] != null)
                   id_profil = Session["id_profil"].ToString();
                var id_dossier = Session["id_dossier"].ToString();
                Session.Add("id_dossier", id_dossier);
                var DetailNotes = service1.DetailsNotesDossier(id_dossier);
                decimal plafond = 0;
                
                var elements = service1.DetailsDossierContrepartie(code_banque, id_scoring);
                var list_profil = service1.ListeProfil(6, id_profil.Trim(), code_banque, id_profil.Trim(), "", 0, true);
                if (list_profil.Count != 0)
                {
                    foreach (var li in list_profil)
                    {
                        plafond = Convert.ToInt64(li.PLAFOND_PROFIL);
                    }
                }
                //++++++++++++++++++++++++++++++++
                Int64 xcd = 0;
                int xxd1 = 0;
                var inin = DataManager.Ps_scor_leseuil(Convert.ToInt32(plafond));
                if (inin.Count != 0)
                {
                    xcd =0;
                    var MAXSEUIL = inin.FirstOrDefault().MAX_SCOR_SEUIL_DELEGUATION;
                    var MINSEUIL = inin.FirstOrDefault().MIN_SCOR_SEUIL_DELEGUATION;
                    ID = inin.FirstOrDefault().ID_SCOR_SEUIL_DELEGUATION.ToString();
                    //if (MAXSEUIL.ToString() == Int64.MaxValue + "")
                    //    xcd += "illimité";
                    //else
                    xcd =Convert.ToInt64(MAXSEUIL);
                }
                if (DataManager.Ps_scor_get_seuil_dossier(id_dossier.Trim()).Count != 0)
                    xxd1 =  DataManager.Ps_scor_get_seuil_dossier(id_dossier.Trim())[0].ID_SCOR_SEUIL_DELEGUATION;

                var inin1 = DataManager.Ps_scor_leseuil(Convert.ToInt32(xxd1));
                Int64 xcd1 = 0;
                if (inin1.Count != 0)
                {
                    xcd1 = 0;
                    var MAXSEUIL = inin1.FirstOrDefault().MAX_SCOR_SEUIL_DELEGUATION;
                    var MINSEUIL = inin1.FirstOrDefault().MIN_SCOR_SEUIL_DELEGUATION;
                    ID = inin1.FirstOrDefault().ID_SCOR_SEUIL_DELEGUATION.ToString();
                    xcd1 = Convert.ToInt64(MAXSEUIL);
                }
                //++++++++++++++++++++++++++++++++
                if (DetailNotes.Count != 0)
                {
                    
                    foreach (var Notes in DetailNotes)
                    {
                        if (Notes.NOTE_PROP != null)
                        {
                            if (Notes.NOTE_PROP.Trim() != "")
                            {
                                if (Notes.NOTE_VAL != null)
                                {
                                    if (Notes.NOTE_VAL.Trim() != "")
                                    {
                                    //tout griser
                                    //    Scriptos1.InnerHtml = "<script>$(':input').removeAttr('disabled');</script>" +
                                    //"<script>$('.bg-claire').removeClass('bg-sombre');</script>" +
                                    //        "<script>$('#messageEtat').html('Dossier Validé sur <h1>" + Notes.NOTE_VAL.Trim() + "</h1>');</script>";
                                    //    noval = noval+ Notes.NOTE_VAL.Trim();
                                    }
                                    else
                                    {
                                       
                                           
                                                //griser pour certains
                                                foreach (var dossier in elements)
                                                {
                                                    if (xcd1 <= xcd)
                                                    {
                                                        //degriser
                                                        Scriptos1.InnerHtml = "<script>$(':input').removeAttr('disabled');</script>" +
                                            "<script>$('.bg-claire').removeClass('bg-sombre');</script>";

                                                    }
                                                    if (xcd1 > xcd)
                                                    {
                                                        //griser
                                                        Scriptos1.InnerHtml = "<script>$(':input').attr('disabled','disabled');</script>" +
                                            "<script>$('.bg-claire').addClass('bg-sombre');</script>" +
                                                    "<script>$('#messageEtat').html('Veuillez Patienter. Dossier en cours de Validation...');</script>";

                                                    }
                                                
                                            
                                        }

                                       
                                    }
                                }
                                else
                                {
                                    //griser pour certains
                                            foreach (var dossier in elements)
                                            {
                                                if (xcd1 <= xcd)
                                                {
                                                    //degriser
                                                    Scriptos1.InnerHtml = "<script>$(':input').removeAttr('disabled');</script>" +
                                            "<script>$('.bg-claire').removeClass('bg-sombre');</script>";

                                                }
                                                if (xcd1 > xcd)
                                                {
                                                    //griser
                                                    Scriptos1.InnerHtml = "<script>$(':input').attr('disabled','disabled');</script>" +
                                            "<script>$('.bg-claire').addClass('bg-sombre');</script>" +
                                                    "<script>$('#messageEtat').html('Veuillez Patienter. Dossier en cours de Validation...');</script>";

                                                }
                                            
                                        
                                    }
                                   
                                }

                            }else
                            {
                                Scriptos1.InnerHtml = "<script>$(':input').removeAttr('disabled');</script>" +
                                    "<script>$('.bg-claire').removeClass('bg-sombre');</script>";
                                //removeClass
                            }
                        }
                        else
                        {
                            Scriptos1.InnerHtml = "<script>$(':input').removeAttr('disabled');</script>" +
                                    "<script>$('.bg-claire').removeClass('bg-sombre');</script>";
                        }
                    }
                }

                var listpopver = service1.listpropver(id_dossier);
                foreach (var listefi in listpopver)
                {
                    if (listefi.DECISION_PROP != null && listefi.DECISION_PROP != "")
                    {
                        if (noval == "La Note du Dossier est : ") noval = "Aucune Note";
                        //griser pour degriser apres
                        //Scriptos1.InnerHtml = "<script>$(':input').removeAttr('disabled');</script>" +
                        // "<script>$('.bg-claire').removeClass('bg-sombre');</script>" +
                        //"<script>$('#messageEtat').html(\"Dossier Rejeté ..." + noval + "\");</script>";
                        ////"<script>$('#messageEtat').html(\"Dossier Rejeté ... <div class='btn btn_cergicolor btn_hover ModProp' id='ModProp' >Modifier</div>\");</script>";

                    }
                    else
                    {

                    }
                }


            }
        }
    }
}