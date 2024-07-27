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
    public partial class SchemaDelegataire : System.Web.UI.Page
    {
        StringBuilder sb = new StringBuilder();
        StringBuilder sc = new StringBuilder();

        Scoringws service = new Scoringws();

        string vartest = "";
        protected void Page_Load(object sender, EventArgs e)
        {
           // ControllerPage();
            if (!IsPostBack)
            {
                Button2.Disabled = false;
            }
            
        }



        protected void Page_Init(object sender, EventArgs e)
        {
            ListeBanque();
            initChampActivation();

        }

        public void AfficherSeuil(string paramext)
        {
            //var Compo = "";
            var param = ScorCryptage.Decrypt(Session["code_banque"].ToString());
            if (paramext != null && paramext != "") param = paramext;
            TextDeleg.Value = "";
            SeuilSelect.Items.Clear();
            if (DataManager.ListeSeuil(param).Count != 0)
            {

                foreach (var seuil in DataManager.ListeSeuil(param))
                {
                    //Compo += " " + "<option value=\"" +  + "\">" +  + "</option> ";

                    ListItem l = new ListItem();
                    l.Value = seuil.ID_SCOR_SEUIL_DELEGUATION.ToString();
                    if (seuil.MAX_SCOR_SEUIL_DELEGUATION.ToString() == Int64.MaxValue + "")
                        l.Text = seuil.MIN_SCOR_SEUIL_DELEGUATION + " à " + "illimité";
                    else
                        l.Text = seuil.MIN_SCOR_SEUIL_DELEGUATION + " à " + seuil.MAX_SCOR_SEUIL_DELEGUATION;

                    SeuilSelect.Items.Add(l);
                }


                //.InnerHtml = Compo;
            }
        }

        public void AfficherAgence(string paramext)
        {

            var param = ScorCryptage.Decrypt(Session["code_banque"].ToString());
            if (paramext != null && paramext != "") param = paramext;
            var xcd= "<label for=\"Tousagc\"> <input type = \"checkbox\" onchange=\"TousAgencecheck()\" id = \"Tousagc\" /> Tous </label> ";
            foreach (var v in service.ListeAgenceBanque(param))
            {
                xcd += "<label for='" + v.CODE_AGENCE + "'> ";
                xcd += "<input type='checkbox' class='Agencesput' valeur='" + v.CODE_AGENCE + "' id='" + v.CODE_AGENCE + "' />" + v.GUICHET_AGENCE.ToString() + " - " + v.NOM_AGENCE.ToString() + "</label> ";
            }
            //xcd += "</div>";
            serve_checkboxes_Agence.InnerHtml = xcd;
        }

        public void AfficherDELEGATAIRE(string paramext)
        {
            //var param = Session["code_banque"].ToString();

            var param = ScorCryptage.Decrypt(Session["code_banque"].ToString());
            if (paramext != null && paramext != "") param = paramext;

            var xcd = "";

            var list_user = service.ListeUser(0, "", "", "", "", "", "", "", "", DateTime.Now, true, param, "");

            if(list_user!=null)
            foreach (var v in list_user)
            {
                if (v.LIBELLE_PROFIL != "scoradm")
                {
                    if (param == v.CODE_BANQUE)
                    {
                        xcd += "<label for='" + v.ID_USER + "'>";
                        xcd += "<input type='checkbox' class='Utilisput' valeur='" + v.ID_USER + "' id='" + v.ID_USER + "' />" + v.NOM_USER.ToUpper() + " - " + v.PRENOM_USER.ToString() + "</label>";
                    }
                }
            }
            serve_checkboxes.InnerHtml = xcd;
        }


        public void AfficherTableau(string paramext)
        {
            var param = ScorCryptage.Decrypt(Session["code_banque"].ToString());
            if (paramext != null && paramext != "")
            {
                param = paramext;
                Button2.Disabled = false;
            }

            var xcd = "";
            var ListeDeclaration = DataManager.ListeDeclaration(param);
            if(ListeDeclaration!=null)
            if (ListeDeclaration.Count != 0)
            {
                foreach (var dec in ListeDeclaration)
                {
                    xcd += "<tr id='" + dec.ID_LIGNE+"'>";
                    xcd += "<td>" + dec.NOM_DELEG + "</td>";
                    
                    var ListeUtilisateurDec = DataManager.ListeUtilisateurDec(dec.ID_LIGNE, param);
                    xcd += "<td>";
                    if (ListeUtilisateurDec.Count != 0)
                    {
                        foreach (var uti in ListeUtilisateurDec)
                        {
                            xcd += ""+uti.NOM_USER.ToUpper()+"; ";
                        }
                    }
                    xcd += "</td>";
                    

                    if (dec.MAXSEUIL.ToString() == Int64.MaxValue + "")
                        xcd += "<td>" + Convert.ToDecimal(dec.MINSEUIL).ToString("#,##0.##") + " à " + "illimité" + "</td>";
                    else
                        xcd += "<td>" + Convert.ToDecimal(dec.MINSEUIL).ToString("#,##0.##") + " à " + Convert.ToDecimal(dec.MAXSEUIL).ToString("#,##0.##") + "</td>";

                    //xcd += "<td>Toutes</td>";
                    var ListeAgenceDec = DataManager.ListeAgenceDec(dec.ID_LIGNE, param);
                    xcd += "<td>";
                    if (ListeAgenceDec.Count != 0)
                    {
                        foreach (var Agc in ListeAgenceDec)
                        {
                            xcd += "" + Agc.NOMAGENCE.ToUpper() + "; ";
                        }
                    }
                    xcd += "</td>";
                    xcd += "<td>";
                    xcd +="<button ";
                    xcd +="class=\"btn btn-sm btn-primary button_div\" ";
                    xcd +="style=\"margin-right:5px;color:red; background-color:#c3c3c3; height:24px; border:none; padding-top:0px; padding-bottom:0px;\" ";
                    xcd +="title=\"Supprimer\" ";
                    xcd +=" onclick=\"chargerchamptxt($(this))\" ";
                    xcd += "id=\"btnSupprimer\">";
                    xcd +="<span class=\"glyphicon glyphicon-trash\"></span>";
                    xcd += "</button>";
                    xcd += "</td>";
                    xcd += "</tr>";
                }
            }

            ListIntervalDeleg.InnerHtml = xcd;
        }

        protected void Button1_ServerClick(object sender, EventArgs e)
        {
            TextDeleg.Disabled = false;
            serve_checkboxes.Disabled = false;
            SeuilSelect.Disabled = false;
            serve_checkboxes_Agence.Disabled = false;
            DdlBanque.Enabled = true;

        }

        public void initChampActivation()
        {
            TextDeleg.Disabled = true;
            serve_checkboxes.Disabled = true;
            SeuilSelect.Disabled = true;
            serve_checkboxes_Agence.Disabled = true;
            DdlBanque.Enabled = false;
            Button2.Disabled = true;
        }

        protected void Button2_ServerClick(object sender, EventArgs e)
        {
            var deleg = TextDeleg.Value;
            if(SeuilSelect.Value!=null) if (SeuilSelect.Value != "")
            {

            var seuil = Convert.ToInt32(SeuilSelect.Value.Trim());
            var stockA = stockAg.Value.Split('@');
            var stockU = stockUt.Value.Split('@');
            if (DataManager.ListeDecSpecif(seuil, deleg).Count == 0)
            {
                if (DataManager.InsertDeleguat(deleg, seuil))
                {
                var xcd = 0;
                var ListeDecSpecif = DataManager.ListeDecSpecif(seuil, deleg);
                if (ListeDecSpecif.Count != 0)
                {
                    foreach (var Decsp in ListeDecSpecif)
                    {
                        xcd = Decsp.ID_LIGNE;
                    }
                    foreach (var util in stockU)
                    {
                        if (util.Trim() != "")
                        {
                            foreach (var Ag in stockA)
                            {
                                if (util.Trim() != "")
                                {
                                    DataManager.InsertAjoutUTAGDeleguat(xcd, util.ToString(), Ag.ToString());
                                }
                            }
                        }
                        
                    }
                    
                }

               
            }
            }

            }

            Response.Redirect("~/Scoring/SchemaDelegataire.aspx");
            
            
            
           
        }

        protected void ValMod_ServerChange(object sender, EventArgs e)
        {
           
           try
            {
                DataManager.DeleteUTAGDeleguat(Convert.ToInt32(ValMod.Value));
            }
            catch
            {

            }
            vartest = "";
            Response.Redirect("~/Scoring/SchemaDelegataire.aspx");
        }

        protected void OpenModal01(object sender, EventArgs e)
        {
            if (vartest == "")
            {
                vartest = ValMod.Value.ToString();
                OpenShowSuppModal("Suppression ...", " Voulez-vous vraiment Supprimer cette Délegation ?...");
            }
            else
            {
                vartest = "";
            }
        }
        void OpenShowSuppModal(string titre, string msg)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowSupp_Choix();", true);
            this.lblMsg.Text = msg;
            this.lblTitre.Text = titre;
        }

        protected void ButtonNO_ServerClick(object sender, EventArgs e)
        {
            ValMod.Value = "";
            //vartest = "";
        }

        //public void ListeBanque()
        //{
        //    if (Session["code_banque"] == null) Response.Redirect("~/Scoring/Connexion.aspx");

        //    if (Session["code_banque"] != null)
        //    {
        //        var param = Session["code_banque"].ToString();

        //        foreach (var v in service.ListeBanque(ScorCryptage.Decrypt(param)))
        //        {
        //            DdlBanque.Items.Add(new ListItem(v.SIGLE_BANQUE.ToString() + " - " + v.NOM_BANQUE.ToString(), v.CODE_BANQUE.ToString()));
        //        }
               
        //    }

        //}

        public void ListeBanque()
        {
            if (Session["code_banque"] == null) Response.Redirect("~/Scoring/Connexion.aspx");

            // récupérer les banques appartenant au même groupe banque que la banque de l'utilisateur
            string param = Session["code_banque"].ToString();
            foreach (var element in service.ListeBanque(ScorCryptage.Decrypt(param)))
            {
                DdlBanque.Items.Add(new ListItem(element.SIGLE_BANQUE.ToString(), element.CODE_BANQUE));
            }
            AfficherSeuil("" + DdlBanque.SelectedValue);
            AfficherAgence("" + DdlBanque.SelectedValue);
            AfficherDELEGATAIRE("" + DdlBanque.SelectedValue);
            AfficherTableau("" + DdlBanque.SelectedValue);
        }

        protected void OnBanqueChangeLoadAgences(object sender, EventArgs e)
        {
            if (DdlBanque.SelectedValue != string.Empty)
            {
                TextDeleg.Value = "";
                AfficherSeuil("" + DdlBanque.SelectedValue);
                AfficherAgence(""+ DdlBanque.SelectedValue);
                AfficherDELEGATAIRE("" + DdlBanque.SelectedValue);
                AfficherTableau("" + DdlBanque.SelectedValue);
            }
        }
    }
}