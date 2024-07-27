using ScoringCenter.Scoring;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Web.Script.Services;
using System.Web.Services;

namespace ScoringCenter
{
    public partial class FicheSignaletique : System.Web.UI.Page
    {
        //modif
        StringBuilder sb = new StringBuilder();
        Scoringws service = new Scoringws();
        static string code_banque = "";
        static string statutM = "";
        static string agenceM = "";
        static string activiteM = "";
        static string groupeM = "";
        static string ModeleM = "";
        static string idG= "";
        static string ACTB = "";
        static string AgenceSave = "";
        static string stoppeur = "";

        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (!IsPostBack)
            {
                ControllerPages();
                vergroupe_pays();
                ListeTableParam();
                BrancheActivite();
                searchStatutDbl();
                searchDevise();
                autoselectcombo(sender, e);
                Panneau1.Visible = true;
                Panneau2.Visible = false;
            }
            else
            {
                Panneau1.Visible = false;
                Panneau2.Visible = true;
            }
            
        }
        protected void Page_Init(object sender, EventArgs e)
        {
            getInfoClient();
            
        }
        protected void afficher_input(object sender, EventArgs e)
        {
            Panneau1.Visible = false;
            Panneau2.Visible = true;
        }
        protected void cacher_input(object sender, EventArgs e)
        {
            Panneau1.Visible = true;
            Panneau2.Visible = false;
        }
        public void gestionaffichage()
        {

        }
        public void vergroupe_pays()
        {
            if (Session["id_dossier"] == null) Response.Redirect("~/Scoring/Connexion.aspx");
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
        public void modifierFiche(object sender, EventArgs e)
        {
            StringBuilder sc = new StringBuilder();
            if (Session["id_user"] == null) Response.Redirect("~/Scoring/Connexion.aspx");
            var id_user = Session["id_user"].ToString();
            service.PS_SCOR_SPY(Session["id_user"].ToString().Trim(), "FicheSignaletique", connmou007.Value.ToString(), "M");
            if ( DeviseD.SelectedValue == ""
                || Nom.Value == "" || paysLab.Value == "" || Ca.Value == "" || TbActivite1.Value == "" || DeviseD.SelectedValue == "" || DdlStatut.Value == "")
            {
                //sc.AppendLine("<div class='alert alert-danger fade in'>");
                //sc.AppendLine("<a href='#' class='close' data-dismiss='alert' style='margin-top: -0.4%;'>&times;</a>");
                //sc.AppendLine("<strong>Veuillez Renseigner tous les champs !!!<br/></strong>");
                //sc.AppendLine("</div>");
                //getMessageValide.InnerHtml = sb.ToString();
                OpenShowPasvalideConsult("Erreur...", "Un champ n'a pas été renseigné !!!");
            }
            else
            {
                service.UpdateContrepartiemd(ISCenter.Text.ToString().Trim(), IPrincipal.Text.ToString(), Nom.Value.ToString(),
                adr.Value.ToString(), Ville.Value.ToString(),
                paysLab.Value.ToString(), Segment.Value.ToString(), DdlAgence.Value, Convert.ToDecimal(Ca.Value.ToString()),
                DeviseD.SelectedValue.ToString(), Rccm.Value.ToString(), DdlSecteurActive1.SelectedValue.ToString(),
                TbActivite1.Value.ToString(), DdlStatut.Value, "", DblUntie.Value.ToString(), Tbgroupe1.Value.ToString().Trim());
               
                string[] result_doc_completsV1 = null;
                char[] splitchar1 = { ';' };
                string doc_completsV1 = Idscor1.Text.Trim();
                result_doc_completsV1 = doc_completsV1.Split(splitchar1);
                if (doc_completsV1.Trim().Length >0)
                {
                    for (int i1 = 0; i1 < result_doc_completsV1.Length; i1++)
                    {

                        service.InsertContrepartieGroupModif2("", "", "", "", "", "", "", "", "", "", "", "", 0, "", "", "", "", result_doc_completsV1[i1].ToString().Trim(), "");

                    }
                }
              

                string[] result_doc_completsV = null;
                char[] splitchar = { ';' };
                string doc_completsV = Idscor.Text.Trim();
                result_doc_completsV = doc_completsV.Split(splitchar);
                if (doc_completsV.Trim().Length >0)
                {
                    for (int i = 0; i < result_doc_completsV.Length; i++)
                    {
                
                        service.InsertContrepartieGroupModifFS("", "", "", "", "", "", "", "", "", "", "", "", 0, "", "", "", "", result_doc_completsV[i].ToString().Trim(), idG.Trim());


                    }
                }

                Response.Redirect("~/Scoring/FicheSignaletique.aspx");

               

                OpenShowPasvalideConsult("Enregistrement...", "Enregistrement effectué avec succès !!!");
            }

        }
        public void ControllerPages()
        {
            ////Debut_Controle///////////////////////////////////////////////////
            if (Session["login"] == null) Response.Redirect("~/Scoring/Connexion.aspx");
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
                VN.Visible = false;
                AN.Visible = false;
                E.Visible = false;
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
                    if (element.ID_DROIT.ToString().Trim() == "FS")
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
                        v.ID_GROUPE, v.ID_GROUPE+"-"+v.LIBELLE_GROUPE));
                }
            }
            else
            {
                sbS.AppendLine("<option class='' id='' value=''>Aucune donnée ne correspond aux termes de recherche spécifiés</option>");
            }

            res[0] = sbS.ToString();
            return res;
        }

        protected void btnRefreshBil_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect("~/Scoring/FicheSignaletique.aspx");
        }

        public void ListeTableParam()
        {
            if (Session["code_banque"] == null) Response.Redirect("~/Scoring/Connexion.aspx");

            if (Session["code_banque"] != null)
            {
                DdlAgence.Items.Clear();
                var param = Session["code_banque"].ToString();

                foreach (var v in service.ListeAgenceBanque(ScorCryptage.Decrypt(param)))
                {

                    DdlAgence.Items.Add(new ListItem(v.GUICHET_AGENCE.ToString() + " - " + v.NOM_AGENCE.ToString(), v.CODE_AGENCE));
                    if (stoppeur == v.NOM_AGENCE.ToString())
                        AgenceSave = v.CODE_AGENCE;
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
            if (branchActivite.Count != 0)
            {
                foreach (var v in branchActivite)
                {
                    if (v.BRANCH_ACT_LIBELLE == LblBranche.Text.ToString())
                    {
                        DdlBranchActiv.Items.Add(new ListItem(v.BRANCH_ACT_LIBELLE, v.BRANCH_ACT_CODE,true));
                    }
                    else
                    {
                        DdlBranchActiv.Items.Add(new ListItem(v.BRANCH_ACT_LIBELLE, v.BRANCH_ACT_CODE));

                    }
                }
            }


        }
        public void SecteurActivite()
        {

                //var ActiviteBCEO = service.SecteurActivite(DdlBranchActiv.SelectedValue.ToString().Trim());
                var ActiviteBCEO = service.SecteurActivite(DdlBranchActiv.SelectedValue.ToString().Trim());
                DdlSecteurActive1.Items.Add("");
                if (ActiviteBCEO.Count != 0)
                {
                    foreach (var v in ActiviteBCEO)
                    {
                        DdlSecteurActive1.Items.Add(new ListItem(v.SECTACT_LIBELLE, v.SECTACT_CODE));
                    }
                }
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
            DdlSecteurActive1.Items.Clear();
            SecteurActivite();
        }

        protected void DeviseD_SelectedIndexChanged(object sender, EventArgs e)
        {
            DeviseLabel.Text = DeviseD.SelectedValue;
        }

        protected void DdlSecteurActive1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ACTB = DdlSecteurActive1.SelectedValue;
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
        public static string[] VoirFiliale(string text)
        {
            string[] res2 = new string[1];
            StringBuilder sbS2 = new StringBuilder();

            List<PS_VSCOR_FICHESIGNALETIQUEResult> get_VoirFiliale;
            Scoringws service = new Scoringws();

            get_VoirFiliale = service.DetailsDossierContrepartieFilialeDeja(idG.Trim());

            if (get_VoirFiliale.Count != 0)
            {

                foreach (var s in get_VoirFiliale)
                {
                    if (s.ID_SCORING.Substring(0, 3) != "SCG")
                    {
                        sbS2.AppendLine(string.Format("<option class='' id='{0}' value='{0}'>{1}</option>",
                            s.ID_SCORING, s.ID_SCORING + " - " + s.ETCIV_NOMREDUIT));
                    }

                }
            }
            else
            {
                sbS2.AppendLine("<option class='' id='' value=''>Aucune Filiale</option>");
            }

            res2[0] = sbS2.ToString();
            return res2;
        }

        void OpenShowPasvalideConsult(string titre, string msg)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPasvalideConsult();", true);
            this.lblPasValidemessageConsult.Text = msg;
            this.lblPasValideTitreConsult.Text = titre;
        }
        public void autoselectcombo(object sender, EventArgs e)
        {
            if (Session["id_scoring"] == null) Response.Redirect("~/Scoring/Connexion.aspx");
            var id_scoring = Session["id_scoring"].ToString();
            Session.Add("id_scoring", id_scoring);
            if (Session["code_banque"] == null) Response.Redirect("~/Scoring/Connexion.aspx");
            var code_banque = Session["code_banque"].ToString();
            var info = service.DetailsDossierContrepartie(code_banque, id_scoring);
            foreach (var v in info)
            {
                DeviseD.SelectedIndex = DeviseD.Items.IndexOf(DeviseD.Items.FindByValue(v.DEVISE.Trim()));
                DdlBranchActiv.SelectedIndex = DdlBranchActiv.Items.IndexOf(DdlBranchActiv.Items.FindByValue(v.BRANCHE_ACTIVITE.Trim()));
                DdlBranchActiv_SelectedIndexChanged(sender, e);
                DdlSecteurActive1.SelectedIndex = DdlSecteurActive1.Items.IndexOf(DdlSecteurActive1.Items.FindByText(v.SECTACT_LIBELLE));
                DdlStatut.SelectedIndex = DdlStatut.Items.IndexOf(DdlStatut.Items.FindByText(v.STATUT_LIBELLE));
                DdlAgence.SelectedIndex = DdlAgence.Items.IndexOf(DdlAgence.Items.FindByValue(AgenceSave)); 
                LblBranche.Text = DdlBranchActiv.SelectedItem.Text.ToString();
                if ((v.TYPE_PROSPECT).ToLower() == "prospect")
                {
                    Button1.Visible = true;
                    idscoringDiv.Visible = true;
                }
                else
                {
                    Button1.Visible = false;
                    idscoringDiv.Visible = true;
                }
            }
            
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
                        RSocial.Text = v.ETCIV_NOMREDUIT;
                        Adresse.Text = v.ETCIV_ADRESSE;
                        CPVille.Text = v.ETCIV_VILLE_RESIDENCE;
                        Pays.Text = v.PAYS;
                        IPrincipal.Text = v.ETCIV_MATRICULE;
                        //Siret.Text = v.ACTIVITE_BCEAO;
                        ISCenter.Text = v.ID_SCORING;
                        String ins = v.ID_SCORING.Substring(0, 3);
                        if (ins.Trim() != "SCG")
                        {
                            ModifierrFiliale.Visible = false;
                        }
                        MAnalyse.Text = v.LIBELLE_MODELE;
                        if (v.LIBELLE_MODELE.Trim() == "Groupe") AQ.Visible = false; else AS.Visible = true;
                       
                        LblStatut.Text = v.STATUT_LIBELLE;
                        LblAgence.Text = v.NOM_AGENCE;
                        LblSClientele.Text = v.SEGMENT_CLIENT;
                        if (v.GROUPE_DOSSIER != "") { LblGroupe.Text = v.GROUPE_DOSSIER; }
                        else { LblGroupe.Text = "Aucun"; IG.Visible = false; }
                        LblNAF2.Text = v.SECTACT_LIBELLE;
                        LblAPE.Text = v.RCCM;
                        LblBranche.Text = v.BRANCH_ACT_CODE;
                        LblNAF.Text = v.ACTBCEAO_LIBELLE;
                        LblUnite.Text = v.UNITE;
                        LblDevise.Text = v.DEVISE;
                        LblChiffre.Text = Convert.ToString(string.Format("{0:#,##0}", Convert.ToDecimal(v.CA)));
                        id_dossier = v.ID_DOSSIER;
                        lblTypeProspect.Text = v.TYPE_PROSPECT;

                        if (v.TYPE_PROSPECT == "Prospect Ref") lblTypeProspect.Text = "Prospect Reférencé";
                        

                        //++++++++++++++++++++++++++
                        //DdlBranchActiv.SelectedItem.Value= v.BRANCH_ACT_CODE;
                        //DeviseD.SelectedIndex = DeviseD.Items.IndexOf(DeviseD.Items.FindByText(v.DEVISE));
                        Nom.Value = v.ETCIV_NOMREDUIT.ToString();
                        adr.Value = v.ETCIV_ADRESSE;
                        Ville.Value = v.ETCIV_VILLE_RESIDENCE;
                        paysLab.Value = v.PAYS;
                        if (v.SEGMENT_CLIENT.ToString().Trim() == "" || v.SEGMENT_CLIENT.ToString().Trim() == null) { Segment.Value = "Segment ()"; }
                        else Segment.Value = v.SEGMENT_CLIENT;
                        var infoGoup = service.DetailsDossierContrepartieCodeG(code_banque, v.GROUPE_DOSSIER);
                        foreach (var w in infoGoup)
                        {
                            idG = w.ID_GROUPE.Trim();
                            Tbgroupe.Value = w.LIBELLE_GROUPE;
                            Tbgroupe1.Value = w.ID_GROUPE;
                        }
                        TbActivite.Value = v.ACTBCEAO_CODE+" - "+ v.ACTBCEAO_LIBELLE;
                        TbActivite1.Value = v.ACTBCEAO_CODE;
                        DdlAgence.Value = v.NOM_AGENCE;
                        stoppeur = v.NOM_AGENCE;

                        Ca.Value = Convert.ToString(string.Format("{0:#,##0}", Convert.ToDecimal(v.CA)));
                        Rccm.Value = v.RCCM;

                    }
                    var infoLiass = service.DetailsDossierLiasseContrepartie(id_dossier.Trim());
                    foreach (var v in infoLiass)
                    {
                        LBDateClotureLiasse.Text = "NC";
                        if (v.DATE_CLOTURE != null) LBDateClotureLiasse.Text = Convert.ToDateTime(v.DATE_CLOTURE).ToString("dd/MM/yyyy");
                        LBDurreExoMoisLiasse.Text = "NC";
                        if (v.DUREE_EXERCICE_MOIS != null) LBDurreExoMoisLiasse.Text = v.DUREE_EXERCICE_MOIS.ToString();
                        LBTypeBilLiass.Text = "NC";
                       // if (v.TYPE_ANAFI_A != null) LBTypeBilLiass.Text = v.TYPE_ANAFI_A.ToString();
                        if (v.TYPE_ANAFI_A != null)
                        {
                            if (v.TYPE_ANAFI_A == "SMT") LBTypeBilLiass.Text = "Systeme Minimal De Tresorerie";
                            if (v.TYPE_ANAFI_A == "SN") LBTypeBilLiass.Text = "Bilan Normal";
                            if (v.TYPE_ANAFI_A == "SA") LBTypeBilLiass.Text = "Bilan Allege";

                        }
                        LBNatureExoLiasse.Text = "NC";
                        if (v.NATURE_EXERCICE != null) LBNatureExoLiasse.Text = v.NATURE_EXERCICE.ToString();
                        LBCertifCompteLiasse.Text = "NC";
                        if (v.CERTIFICATION_COMPTES != null) LBCertifCompteLiasse.Text = v.CERTIFICATION_COMPTES.ToString();
                        LBEffectifLiasse.Text = "NC";
                        if (v.EFFECTIF != null) LBEffectifLiasse.Text = v.EFFECTIF.ToString();
                        LBregimFiscalLiasse.Text = "NC";
                        if (v.REGIME_FISCAL != null) LBregimFiscalLiasse.Text = v.REGIME_FISCAL.ToString();
                    }
                    Session.Add("id_dossier", id_dossier);
                    Session.Add("code_banque", code_banque);
                }
            }
            else
            {
                
                var id_scoring = ScorCryptage.Decrypt(Request.QueryString["id"]);
                if (Session["code_banque"] == null) Response.Redirect("~/Scoring/Connexion.aspx");
                Session.Add("id_scoring", id_scoring);
                var code_banque = Session["code_banque"].ToString();
                var info = service.DetailsDossierContrepartie(code_banque, id_scoring);
                //var secBceao = service.searchActivite;
                var secBranc = service.DetailsDossierContrepartie(code_banque, id_scoring);
                var stat = service.DetailsDossierContrepartie(code_banque, id_scoring);
                var secAct = service.DetailsDossierContrepartie(code_banque, id_scoring);
                var secDevis = service.DetailsDossierContrepartie(code_banque, id_scoring);
                var secunite = service.DetailsDossierContrepartie(code_banque, id_scoring);
                string id_dossier = "";
                foreach (var v in info)
                {
                    RSocial.Text = v.ETCIV_NOMREDUIT;
                    Adresse.Text = v.ETCIV_ADRESSE;
                    CPVille.Text = v.ETCIV_VILLE_RESIDENCE;
                    Pays.Text = v.PAYS;
                    IPrincipal.Text = v.ETCIV_MATRICULE;
                    //Siret.Text = v.ACTIVITE_BCEAO;
                    ISCenter.Text = v.ID_SCORING;
                    String ins = v.ID_SCORING.Substring(0, 3);
                    if (ins.Trim() != "SCG")
                    {

                        ModifierrFiliale.Visible = false;
                    }
                    MAnalyse.Text = v.LIBELLE_MODELE;
                    if (v.LIBELLE_MODELE.Trim() == "Groupe") AQ.Visible = false; else AS.Visible = true;

                    LblStatut.Text = v.STATUT_LIBELLE;
                    LblAgence.Text = v.NOM_AGENCE;
                    LblSClientele.Text = v.SEGMENT_CLIENT;
                    if (v.GROUPE_DOSSIER != "") { LblGroupe.Text = v.GROUPE_DOSSIER; }
                    else { LblGroupe.Text = "Aucun"; IG.Visible = false; }
                    LblNAF2.Text = v.SECTACT_LIBELLE;
                    LblAPE.Text = v.RCCM;
                    LblNAF.Text = v.ACTBCEAO_LIBELLE;
                    LblUnite.Text = v.UNITE;
                    LblDevise.Text = v.DEVISE;
                    LblChiffre.Text = Convert.ToString(string.Format("{0:#,##0}", Convert.ToDecimal(v.CA)));
                    id_dossier = v.ID_DOSSIER;
                    //++++++++++++++++++++++++++

                    //une fois les valeurs des contreparties defini changer ca
                    if ((v.TYPE_PROSPECT).ToLower() == "prospect") { 
                        Button1.Visible = true;
                        idscoringDiv.Visible = true;
                    }
                    else
                    {
                        Button1.Visible = false;
                        idscoringDiv.Visible = false;
                    }
                    //DeviseD.SelectedIndex = DeviseD.Items.IndexOf(DeviseD.Items.FindByValue(v.DEVISE));
                    DdlBranchActiv.SelectedValue = v.BRANCH_ACT_CODE;
                    lblTypeProspect.Text = v.TYPE_PROSPECT;
                    Nom.Value = v.ETCIV_NOMREDUIT.ToString();
                    adr.Value = v.ETCIV_ADRESSE;
                    Ville.Value = v.ETCIV_VILLE_RESIDENCE;
                    paysLab.Value = v.PAYS;
                    if (v.SEGMENT_CLIENT.ToString().Trim() == "" || v.SEGMENT_CLIENT.ToString().Trim() == null) { Segment.Value = "Segment ()"; }
                    else Segment.Value = v.SEGMENT_CLIENT;
                    var infoGoup = service.DetailsDossierContrepartieCodeG(code_banque, v.GROUPE_DOSSIER);
                    foreach (var w in infoGoup)
                    {
                        idG = w.ID_GROUPE.Trim();
                        Tbgroupe.Value =w.LIBELLE_GROUPE;
                        Tbgroupe1.Value = w.ID_GROUPE;
                    }
                 
                    TbActivite.Value = v.ACTBCEAO_CODE + " - " + v.ACTBCEAO_LIBELLE;
                    TbActivite1.Value = v.ACTBCEAO_CODE;
                    DdlAgence.Value = v.NOM_AGENCE;
                    stoppeur = v.NOM_AGENCE;
                    Ca.Value = Convert.ToString(string.Format("{0:#,##0}", Convert.ToDecimal(v.CA)));
                    Rccm.Value = v.RCCM;
                    if (v.TYPE_PROSPECT == "Prospect Ref") lblTypeProspect.Text = "Prospect Reférencé";
                }
                var infoLiass = service.DetailsDossierLiasseContrepartie(id_dossier.Trim());
                foreach (var v in infoLiass)
                {
                    LBDateClotureLiasse.Text = "NC";
                    if (v.DATE_CLOTURE != null) LBDateClotureLiasse.Text = Convert.ToDateTime(v.DATE_CLOTURE).ToString("dd/MM/yyyy");
                    LBDurreExoMoisLiasse.Text = "NC";
                    if (v.DUREE_EXERCICE_MOIS != null) LBDurreExoMoisLiasse.Text = v.DUREE_EXERCICE_MOIS.ToString();
                    LBTypeBilLiass.Text = "NC";
                    //if (v.TYPE_ANAFI_A != null) LBTypeBilLiass.Text = v.TYPE_ANAFI_A.ToString();
                    if (v.TYPE_ANAFI_A != null)
                    {
                        if (v.TYPE_ANAFI_A == "SMT") LBTypeBilLiass.Text = "Systeme Minimal De Tresorerie";
                        if (v.TYPE_ANAFI_A == "SN") LBTypeBilLiass.Text = "Bilan Normal";
                        if (v.TYPE_ANAFI_A == "SA") LBTypeBilLiass.Text = "Bilan Allege";

                    }
                    LBNatureExoLiasse.Text = "NC";
                    if (v.NATURE_EXERCICE != null) LBNatureExoLiasse.Text = v.NATURE_EXERCICE.ToString();
                    LBCertifCompteLiasse.Text = "NC";
                    if (v.CERTIFICATION_COMPTES != null) LBCertifCompteLiasse.Text = v.CERTIFICATION_COMPTES.ToString();
                    LBEffectifLiasse.Text = "NC";
                    if (v.EFFECTIF != null) LBEffectifLiasse.Text = v.EFFECTIF.ToString();
                    LBregimFiscalLiasse.Text = "NC";
                    if (v.REGIME_FISCAL != null) LBregimFiscalLiasse.Text = v.REGIME_FISCAL.ToString();
                }
                Session.Add("id_dossier", id_dossier);
                Session.Add("code_banque", code_banque);
                
            }
           
        }
    }
}