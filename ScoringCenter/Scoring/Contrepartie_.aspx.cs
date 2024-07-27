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
    public partial class Contrepartie : System.Web.UI.Page
    {
        StringBuilder sb = new StringBuilder();
        Scoringws service = new Scoringws();
        static string code_banque = "";
        static string statutM = "";
        static string agenceM = "";
        static string activiteM = "";
        static string groupeM = "";
        static string ModeleM = "";
        static string ACTB = "";

        protected void Page_Load(object sender, EventArgs e)
        {
         
            ControllerPage();
            if (!IsPostBack)
            {
             
              
            }
        }

       

        protected void Page_Init(object sender, EventArgs e)
        {
            if (Session["code_banque"] == null) Response.Redirect("~/Scoring/Connexion.aspx"); 

            code_banque = ScorCryptage.Decrypt(Session["code_banque"].ToString());
            ListeTableParam();
            BrancheActivite();
            SecteurActivite();
            searchStatutDbl();
            //searchGroupeDbl();
            searchDevise();
            
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static string[] searchStatut(string text)
        {
            string[] res = new string[1];
            StringBuilder sbS = new StringBuilder();

            List<PS_VSCOR_CONTREPARTIEResult> get_statut;
            Scoringws service = new Scoringws();

            
            get_statut = service.searchStatut();

            if (get_statut.Count != 0)
            {
                foreach (var v in get_statut)
                {
                    sbS.AppendLine(string.Format("<option class='' id='{0}' value='{0}'>{1}</option>",
                        v.STATUT_CODE, v.STATUT_LIBELLE));
                }
            }
            else
            {
                sbS.AppendLine("<option class='' id='' value=''>Aucune donnée ne correspond aux termes de recherche spécifiés</option>");
            }

            res[0] = sbS.ToString();
            return res;
        }

   

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static string[] ActiviteBCAO(string text)
        {
            string[] res = new string[1];
            StringBuilder sbS = new StringBuilder();

            List<PS_VSCOR_CONTREPARTIEResult> get_ActiviteBCAO;
            Scoringws service = new Scoringws();

            get_ActiviteBCAO = service.ActiviteBCAO(text);

            if (get_ActiviteBCAO.Count != 0)
            {
                foreach (var v in get_ActiviteBCAO)
                {
                    sbS.AppendLine(string.Format("<option class='' id='{0}' value='{0}'>{1}</option>",
                        v.ACTBCEAO_CODE, v.ACTBCEAO_CODE+" - "+v.ACTBCEAO_LIBELLE));
                }
            }
            else
            {
                sbS.AppendLine("<option class='' id='' value=''>Aucune donnée ne correspond aux termes de recherche spécifiés</option>");
            }

            res[0] = sbS.ToString();
            return res;
        }


        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static string[] AjouterFiliale(string text)
        {
            string[] res = new string[1];
            StringBuilder sbS = new StringBuilder();

            List<PS_VSCOR_CONTREPARTIEResult> get_AjouterFiliale;
            Scoringws service = new Scoringws();

            get_AjouterFiliale = service.AjouterFiliale(text);

            if (get_AjouterFiliale.Count != 0)
            {

                foreach (var v in get_AjouterFiliale)
                {
                    if (v.ID_SCORING.Substring(0, 3) != "SCG")
                    {
                        sbS.AppendLine(string.Format("<option class='' id='{0}' value='{0}'>{1}</option>",
                            v.ID_SCORING, v.ID_SCORING + " - " + v.ETCIV_NOMREDUIT));
                    }
                    
                }
            }
            else
            {
                sbS.AppendLine("<option class='' id='' value=''>Aucune donnée ne correspond aux termes de recherche spécifiés</option>");
            }

            res[0] = sbS.ToString();
            return res;
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static string[] ListPaysReach(string text)
        {
            string[] res = new string[1];
            StringBuilder sbS = new StringBuilder();

            List<PS_VSCOR_CONTREPARTIEResult> get_ListPays;
            Scoringws service = new Scoringws();

            get_ListPays = service.SecteurPAYS(text);

            if (get_ListPays.Count != 0)
            {
                foreach (var v in get_ListPays)
                {
                    sbS.AppendLine(string.Format("<option class='' id='{0}' value='{0}'>{1}</option>",
                        v.DEVISE_CODE, v.PAYS_NOM));
                }
            }
            else
            {
                sbS.AppendLine("<option class='' id='' value=''>Aucune donnée ne correspond aux termes de recherche spécifiés</option>");
            }

            res[0] = sbS.ToString();
            return res;
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static string[] searchGroupe(string text)
        {
            string[] res = new string[1];
            StringBuilder sbS = new StringBuilder();

            List<PS_VSCOR_CONTREPARTIEResult> get_Groupe;
            Scoringws service = new Scoringws();

            get_Groupe = service.searchGroupe(text);

            if (get_Groupe.Count != 0)
            {
                foreach (var v in get_Groupe)
                {
                    sbS.AppendLine(string.Format("<option class='' id='{0}' value='{0}'>{1}</option>",
                        v.ID_GROUPE, v.ID_GROUPE + "-" + v.LIBELLE_GROUPE));
                }
            }
            else
            {
                sbS.AppendLine("<option class='' id='' value=''>Aucune donnée ne correspond aux termes de recherche spécifiés</option>");
            }

            res[0] = sbS.ToString();
            return res;
        }



        public void ControllerPage()
        {
            ////Debut_Controle///////////////////////////////////////////////////
            if (Session["login"] == null) Response.Redirect("~/Scoring/Connexion.aspx");
            else
            {
                if (Session["id_profil"] == null) Response.Redirect("~/Scoring/Connexion.aspx"); 

                var idprofil = Session["id_profil"].ToString();
                var elements = service.VHABILITATION(idprofil);
                AD.Visible = false;
                
                //Cen.Visible = false;
                //Con.Visible = false;

                var test = 0;
                foreach (var element in elements)
                {
                    if (element.ID_DROIT.ToString().Trim() == "AD")
                    {
                        if (element.ID_TYPE_DROIT.ToString().Trim() != "0") AD.Visible = true;
                    }

                    
                    //if (element.ID_DROIT.ToString().Trim() == "Cen")
                    //{
                    //    if (element.ID_TYPE_DROIT.ToString().Trim() != "0") Cen.Visible = true;
                    //}
                    
                    //et pour les actions sur la page
                    if (element.ID_DROIT.ToString().Trim() == "Con")
                    {
                       
                        switch (element.ID_TYPE_DROIT.ToString().Trim())
                        {
                            case "1":

                                test = 1;
                                Scriptos.InnerHtml = "<script>$(':input').removeAttr('disabled');</script>";

                                break;
                            case "2":
                                if (test != 1)
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

        void OpenShowPasvalideConsult(string titre, string msg)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPasvalideConsult();", true);
            this.lblPasValidemessageConsult.Text = msg;
            this.lblPasValideTitreConsult.Text = titre;
        }

        public void vider()
        {
            //TbMatricule.Value = "";
            Nom.Value = "";
            DdlAgence.Value = "";
            //TbStatut1.Value = "";
            Adresse.Value = "";
            Ville.Value = "";
            TbPays.Value = "";
            Rccm.Value = "";
            //Activite_B.Value = "";
            Segment.Value = "";
            Ca.Value = "";
            //Mois.Value = "";
            DdlStatut.Value = "";
            DeviseLabel.Text = "";
            ACTB = "";
            Tbgroupe.Value = "";
            Tbgroupe1.Value = "";
            DdlSecteurActive1.SelectedValue = "";
            DdlBranchActiv.SelectedValue ="";
            TypeAnalyse.Value = "";
            TbActivite.Value = "";
            TbActivite1.Value = "";
            DeviseD.SelectedIndex = -1;
            DblUntie.Value = "";
            R_non.Checked = false;
            G_non.Checked = false;
            G_oui.Checked = false;
            TbPays.Value = "";
            TbPays1.Value = "";
            Tbgroupe.Value = "";
            Tbgroupe1.Value = "";
        }

        protected void ValideContrepartie_ServerClick(object sender, EventArgs e)
        {
            if (Session["id_user"] == null) Response.Redirect("~/Scoring/Connexion.aspx"); 

            service.PS_SCOR_SPY(Session["id_user"].ToString().Trim(), "Contrepartie", connmou007.Value.ToString(), "I");
            var id_user = Session["id_user"].ToString();

            string mode = "";
          
            if (G_oui.Checked)
            {
                R_non.Checked = false;
                R_oui.Checked = false;

                mode = "";
                Tbgroupe.Value = "";

                if (Nom.Value == "" || DdlStatut.Value == "" || TbPays.Value == "" || TbActivite.Value == "" || Ca.Value == "")
                {
                    OpenShowPasvalideConsult("Erreur...", "Un champ n'a pas été renseigné !!!");
                }
                else
                {
                    service.InsertContrepartieGroup(id_user.Trim(), DdlAgence.Value.Trim(), "", Nom.Value.Trim(), Adresse.Value.Trim(), Ville.Value.Trim(), Rccm.Value.Trim(), Segment.Value.Trim(), mode.Trim(), TypeAnalyse.Value.Trim(), DblUntie.Value, DeviseD.SelectedValue.Trim(), Convert.ToDecimal(Ca.Value.Trim()), TbPays.Value.Trim(), DdlStatut.Value.Trim(), TbActivite1.Value, DdlSecteurActive1.SelectedValue.Trim(), Tbgroupe.Value.Trim(), DdlBranchActiv.SelectedValue.ToString().Trim());
                 
                    string[] result_doc_completsV = null;
                    char[] splitchar = { ';' };
                    string doc_completsV = Idscor.Text.Trim();
                    result_doc_completsV = doc_completsV.Split(splitchar);

                    for (int i = 0; i < result_doc_completsV.Length; i++)
                    {
                        service.InsertContrepartieGroupModif(id_user.Trim(), DdlAgence.Value.Trim(), "", Nom.Value.Trim(), Adresse.Value.Trim(), Ville.Value.Trim(), Rccm.Value.Trim(), Segment.Value.Trim(), mode.Trim(), TypeAnalyse.Value.Trim(), DblUntie.Value, DeviseD.SelectedValue.Trim(), Convert.ToDecimal(Ca.Value.Trim()), TbPays.Value.Trim(), DdlStatut.Value.Trim(), TbActivite1.Value, DdlSecteurActive1.SelectedValue.Trim(), result_doc_completsV[i].ToString().Trim(), DdlBranchActiv.SelectedValue.ToString().Trim());

                    }
                       vider();
                    OpenShowPasvalideConsult("Enregistrement...", "Enregistrement effectué avec succès !!!");

                }



            }
            else
            {

                R_non.Checked = false;
                R_oui.Checked = false;

                mode = "";
                //Tbgroupe.Value = "";

                if (R_non.Checked)
                {
                    G_non.Checked = false;
                    G_oui.Checked = false;
                    mode = "ENTEXI";
                    //Tbgroupe.Value = "";
                }
                else
                {
                    if (R_oui.Checked)
                    {
                        G_non.Checked = false;
                        G_oui.Checked = false;

                        mode = "ENTCRE";
                        //Tbgroupe.Value = "";
                    }
                    else
                    {
                        OpenShowPasvalideConsult("Erreur...", "Renseigner le type d'entreprise!!!");
                    }

                }

                if (Nom.Value == "" || DdlStatut.Value == "" || TbPays.Value == "" || TbActivite.Value == "" || Ca.Value == "" || DeviseD.SelectedValue == "" || TbActivite1.Value=="")
                {
                    OpenShowPasvalideConsult("Erreur...", "Un champ n'a pas été renseigné !!!");
                }
                else
                {
                    service.InsertContrepartie(id_user.Trim(), DdlAgence.Value.Trim(), "", Nom.Value.Trim(), Adresse.Value.Trim(), Ville.Value.Trim(), Rccm.Value.Trim(), Segment.Value.Trim(), mode.Trim(), TypeAnalyse.Value.Trim(), DblUntie.Value, DeviseD.SelectedValue.Trim(), Convert.ToDecimal(Ca.Value.Trim()), TbPays.Value.Trim(), DdlStatut.Value.Trim(), TbActivite1.Value, DdlSecteurActive1.SelectedValue.Trim(), Tbgroupe1.Value.Trim(), DdlBranchActiv.SelectedValue.ToString().Trim());
                    vider();
                    OpenShowPasvalideConsult("Enregistrement...", "Enregistrement effectué avec succès !!!");

                }
            }
            //if (Nom.Value == "" || DdlStatut.Value == "" || TbPays.Value == "" || TbActivite.Value == "" || DdlBranchActiv.SelectedValue == "" || Ca.Value == "" || DeviseD.SelectedValue == "" || DdlSecteurActive1.SelectedValue == "" || DblUntie.Value == "")
             
        }

        protected void btnRefreshBil_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect("~/Scoring/Contrepartie.aspx");
        }

        public void ListeTableParam()
        {
            if (Session["code_banque"] == null) Response.Redirect("~/Scoring/Connexion.aspx"); 

            if (Session["code_banque"] != null)
            {
                if (Session["code_banque"] == null) Response.Redirect("~/Scoring/Connexion.aspx"); 

                var param = Session["code_banque"].ToString();

                foreach (var v in service.ListeAgenceBanque(ScorCryptage.Decrypt(param)))
                {
                    DdlAgence.Items.Add(new ListItem(v.GUICHET_AGENCE.ToString() + " - " + v.NOM_AGENCE.ToString(), v.CODE_AGENCE));
                }
            }
            else
            {
                //sb.AppendLine("<div class='alert alert-danger fade in'>");
                //sb.AppendLine("<a href='#' class='close' data-dismiss='alert' style='margin-top: -0.4%;'>&times;</a>");
                //sb.AppendLine("<strong>Veuillez vous connecter pour evoluer !!!<br/></strong>");
                //sb.AppendLine("</div>");
                //getMessage.InnerHtml = sb.ToString();
                Response.Redirect("Connexion.aspx");
            }

        }


        public void BrancheActivite()
        {
           
            var branchActivite = service.BrancheActivite();
            DdlBranchActiv.Items.Add("");
            if (branchActivite.Count !=0)
            {
                foreach (var v in branchActivite)
                {
                    DdlBranchActiv.Items.Add(new ListItem(v.BRANCH_ACT_LIBELLE,v.BRANCH_ACT_CODE));
                }
            }
           

        }
        public void SecteurActivite()
        {
            //if (DdlBranchActiv.SelectedValue != "")
            //{
            var ActiviteBCEO = service.SecteurActivite(DdlBranchActiv.SelectedValue.ToString().Trim());
            //var ActiviteBCEO = service.SecteurActivite();
                
                DdlSecteurActive1.Items.Add("");
                if (ActiviteBCEO.Count != 0)
                {
                    foreach (var v in ActiviteBCEO)
                    {
                        DdlSecteurActive1.Items.Add(new ListItem(v.SECTACT_LIBELLE.Trim(), v.SECTACT_CODE.Trim()));
                    }
                }
            //}

        }

        public void searchStatutDbl()
        {
             var searchStatut = service.searchStatut();
                if (searchStatut.Count != 0)
                {
                    foreach (var v in searchStatut)
                    {
                        DdlStatut.Items.Add(new ListItem(v.STATUT_LIBELLE, v.STATUT_CODE));
                    }
                }
            
        }

        public void searchDevise()
        {
            var searchDeviseL = service.searchDevise();
            DeviseD.Items.Add("");
            if (searchDeviseL.Count != 0)
            {
                foreach (var v in searchDeviseL)
                {
                    DeviseD.Items.Add(new ListItem(v.SCOR_DEVISE_LIBELLE, v.SCOR_DEVISE_CODE));
                }
            }

        }

       //public void searchGroupeDbl()
       // {
       //      var searchGroupe = service.searchGroupe();
       //         if (searchGroupe.Count != 0)
       //         {
       //             foreach (var v in searchGroupe)
       //             {
       //                 Ddlgroupe.Items.Add(new ListItem(v.GROUPE_DOSSIER, v.GROUPE_DOSSIER));
       //             }
       //         }
            
       // }

        protected void DdlBranchActiv_SelectedIndexChanged(object sender, EventArgs e)
        {
            //DdlSecteurActive1.Items.Clear();
            //SecteurActivite();
        }

        protected void DeviseD_SelectedIndexChanged(object sender, EventArgs e)
        {
            DeviseLabel.Text = DeviseD.SelectedValue;
        }


        protected void DdlSecteurActive1_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }
    }
}