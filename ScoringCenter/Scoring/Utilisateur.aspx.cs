using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ScoringCenter.Scoring
{
    public partial class Utilisateur : System.Web.UI.Page
    {
        Scoringws service = new Scoringws();
        StringBuilder sblogo = new StringBuilder();
        StringBuilder sb = new StringBuilder();

        protected void Page_Load(object sender, EventArgs e)
        {
            AfficheLogoBank();
            ControllerPage();
        }

        public void AfficheLogoBank()
        {
            if (Session["code_banque"] != null)
            {
                var code_banque = Session["code_banque"].ToString();
                var bankInfo = service.AfficheLogoBank(ScorCryptage.Decrypt(code_banque.ToString().Trim()));
                foreach (var banque in bankInfo)
                {
                    if (banque.IMG_BANQUE != "" && banque.IMG_BANQUE != null)
                    {
                        sb.AppendLine(string.Format("<img src=\"../Images/Logo/{0}\"style=\"width: 100% ;height:100%\" />", banque.IMG_BANQUE.ToString().Trim()));
                    }
                }
                idimgLogoBanque.InnerHtml = sb.ToString();
            }
        }

        public void ControllerPage()
        {
            ////Debut_Controle///////////////////////////////////////////////////
            if (Session["login"] == null) Response.Redirect("~/Scoring/Connexion.aspx");
            else
            {
                var idprofil = Session["id_profil"].ToString();
                var elements = service.VHABILITATION(idprofil);
                AD.Visible = false;
                TB.Visible = false;
                GP.Visible = false;
                GU.Visible = false;
                PARAM.Visible = false;
                GPA.Visible = false;

                //Cen.Visible = false;
                //CC.Visible = false;
                Pay.Visible = false;
                // Con.Visible = false;

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

                    if (element.ID_DROIT.ToString().Trim() == "GP")
                    {
                        if (element.ID_TYPE_DROIT.ToString().Trim() != "0") GP.Visible = true;
                    }
                    if (element.ID_DROIT.ToString().Trim() == "PARAM")
                    {
                        if (element.ID_TYPE_DROIT.ToString().Trim() != "0") PARAM.Visible = true;
                    }
                    if (element.ID_DROIT.ToString().Trim() == "GU")
                    {
                        if (element.ID_TYPE_DROIT.ToString().Trim() != "0") GU.Visible = true;
                    }
                    if (element.ID_DROIT.ToString().Trim() == "GPA")
                    {
                        if (element.ID_TYPE_DROIT.ToString().Trim() != "0") GPA.Visible = true;
                    }

                    if (element.ID_DROIT.ToString().Trim() == "Cen")
                    {
                        //if (element.ID_TYPE_DROIT.ToString().Trim() != "0") Cen.Visible = true;
                    }
                    if (element.ID_DROIT.ToString().Trim() == "CC")
                    {
                        //if (element.ID_TYPE_DROIT.ToString().Trim() != "0") CC.Visible = true;
                    }
                    if (element.ID_DROIT.ToString().Trim() == "Pay")
                    {
                        if (element.ID_TYPE_DROIT.ToString().Trim() != "0") Pay.Visible = true;
                    }


                    //et pour les actions sur la page
                    if (element.ID_DROIT.ToString().Trim() == "GU")
                    {
                        // if (element.ID_TYPE_DROIT.ToString().Trim() != "0") AD.Visible = true;


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
            //getInfoClient(); EBF.Visible = false; ////Fin_Controle////////////////////////////////////////////////////
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            if (Session["code_banque"] == null) Response.Redirect("~/Scoring/Connexion.aspx");
            if(!IsPostBack) {
                actifsParDefaut();
                ListeBanque();
                griserChamps();
            }
        }

        public void ListeProfil()
        {
            if (Session["code_banque"] == null) Response.Redirect("~/Scoring/Connexion.aspx");

            DdlProfil.Items.Clear();

            if (DdlBanque.SelectedValue != string.Empty)
            {
                var liste_profils = service.ListeUser(2, "", "", "", "", "", "", "", "", DateTime.Now, true, DdlBanque.SelectedValue.Substring(0, 5), "");
                if (liste_profils.Any())
                {
                    DdlProfil.Items.Add(new ListItem("", ""));
                    foreach (var v in liste_profils)
                    {
                        DdlProfil.Items.Add(new ListItem(v.LIBELLE_PROFIL.ToString(), v.ID_PROFIL.ToString().Trim()));
                    }
                }
            }
        }

        protected void validation(bool changeUserState = false)
        {
            // activer ou désactiver utilisateur
            if (changeUserState) {
                var utilisateur = service.ListeUser(10, TbIdUtilisateur.Text, "", "", "", "", "", "", "", DateTime.Now, true, "", "").LastOrDefault();
                try
                {
                    service.traiterUser(5, TbIdUtilisateur.Text, utilisateur.ID_PROFIL, utilisateur.CODE_AGENCE, utilisateur.NOM_USER, utilisateur.PRENOM_USER,
                                utilisateur.EMAIL_USER, utilisateur.LOGIN_USER, "", DateTime.Now, !utilisateur.STATUT_USER, "", "", "");
                    service.PS_SCOR_SPY(Session["id_user"].ToString().Trim(), "Utilisateur", connmou007.Value.ToString(), "M");
                }
                catch (Exception e)
                {
                    OpenShowPasvalideConsult("Erreur...", e.Message);
                    return;
                }

                if (utilisateur.STATUT_USER == true) actifsParDefaut();
                else inactif();
                return;
            }

            // ajuster les valeurs des boîtes de sélection
            DdlBanque.SelectedValue = TbCodeBanqueRemote.Text.Trim();
            ListeAgence();
            ListeProfil();
            DdlAgence.Value = TbCodeAgenceRemote.Text.Trim();
            DdlProfil.Value = TbIdProfilRemote.Text.Trim();
            degriserChamps();
            DdlBanque.Attributes.Add("c-disable", "1");

            // insérer un nouvel utilisateur
            if (TbIdUtilisateur.Text.Trim() == "new") {
                if (TbCodeAgenceRemote.Text.Trim() == "" || TbIdProfilRemote.Text.Trim() == "" || TbNom.Text.Trim() == "" || TbPrenom.Text.Trim() == ""
                    || TbLoginUser.Text.Trim() == "" || TbEmail.Text.Trim() == "" || TbPassword.Text == "" || TbConfirm.Text == "") {
                    OpenShowPasvalideConsult("Erreur...", "Veuillez remplir tous les champs !!!");
                    return;
                }
                if (IsValidEmailAddress(TbEmail.Text.Trim()) == false) { 
                    OpenShowPasvalideConsult("Information...", "L'adresse mail est incorrecte !!!");
                    return;
                }
                if (TbPassword.Text != TbConfirm.Text) {
                    OpenShowPasvalideConsult("Erreur...", "Confirmation de mot de passe incorrecte !!!");
                    return;
                }

                PS_VSCOR_UTILISATEURResult old_user = service.ListeUser(13, "", "", "", "", "", "", TbLoginUser.Text.Trim(), "", DateTime.Now, true, "", "").FirstOrDefault();
                if(old_user != null) {
                    OpenShowPasvalideConsult("Erreur...", "Ce nom d'utilisateur est déjà utilisé !!!");
                    return;
                }

                try
                {
                    service.traiterUser(4, "", TbIdProfilRemote.Text.Trim(), TbCodeAgenceRemote.Text.Trim(), TbNom.Text.Trim(),
                                TbPrenom.Text.Trim(), TbEmail.Text.Trim(), TbLoginUser.Text.Trim(), TbPassword.Text, DateTime.Now, true, "", "", "");
                    service.PS_SCOR_SPY(Session["id_user"].ToString().Trim(), "Utilisateur", connmou007.Value.ToString(), "I");
                    OpenShowPasvalideConsult("Enregistrement", "Enregistrement effectué avec succès !!!");
                }
                catch(Exception e)
                {
                    OpenShowPasvalideConsult("Erreur...", e.Message);
                    return;
                }
            }

            // modifier un utilisateur
            if (TbIdUtilisateur.Text.Trim() != "" && TbIdUtilisateur.Text.Trim() != "new")
            {
                if (TbCodeAgenceRemote.Text.Trim() == "" || TbIdProfilRemote.Text.Trim() == "" || TbNom.Text.Trim() == "" || TbPrenom.Text.Trim() == ""
                    || TbLoginUser.Text.Trim() == "" || TbEmail.Text.Trim() == "") {
                    OpenShowPasvalideConsult("Erreur...", "Veuillez remplir tous les champs !!!");
                    return;
                }
                if (IsValidEmailAddress(TbEmail.Text.Trim()) == false) {
                    OpenShowPasvalideConsult("Information...", "L'adresse mail est incorrecte !!!");
                    return;
                }
                if (TbPassword.Text != TbConfirm.Text) {
                    OpenShowPasvalideConsult("Erreur...", "Confirmation de mot de passe incorrecte !!!");
                    return;
                }

                PS_VSCOR_UTILISATEURResult old_user = service.ListeUser(13, "", "", "", "", "", "", TbLoginUser.Text.Trim(), "", DateTime.Now, true, "", "").FirstOrDefault();
                if (old_user != null && old_user.ID_USER.Trim() != TbIdUtilisateur.Text.Trim()) {
                    OpenShowPasvalideConsult("Erreur...", "Ce nom d'utilisateur est déjà utilisé !!!");
                    return;
                }

                try
                {
                    service.traiterUser(5, TbIdUtilisateur.Text.Trim(), TbIdProfilRemote.Text.Trim(), TbCodeAgenceRemote.Text.Trim(), TbNom.Text.Trim(),
                                TbPrenom.Text.Trim(), TbEmail.Text.Trim(), TbLoginUser.Text.Trim(), TbPassword.Text, DateTime.Now, true, "", "", "");
                    service.PS_SCOR_SPY(Session["id_user"].ToString().Trim(), "Utilisateur", connmou007.Value.ToString(), "M");
                    OpenShowPasvalideConsult("Modification", "Modification effectuée avec succès !!!");
                }
                catch (Exception e)
                {
                    OpenShowPasvalideConsult("Erreur...", e.Message);
                    return;
                }
            }

            if (btnActifs.Visible == false) actifsParDefaut();
            else inactif();
            initialiserChamps();
        }

        protected void btnValider_Click(object sender, EventArgs e)
        {
            btnActifs.Visible = false;
            btnInactifs.Visible = true;
            validation();
        }

        public void ListeAgence()
        {
            if (Session["code_banque"] == null) Response.Redirect("~/Scoring/Connexion.aspx");

            DdlAgence.Items.Clear();

            if (DdlBanque.SelectedValue != string.Empty)
            {
                var liste_agences = service.ListeAgenceBanque(DdlBanque.SelectedValue.Substring(0, 5));
                if (liste_agences.Any())
                {
                    DdlAgence.Items.Add(new ListItem("", ""));

                    foreach (var v in liste_agences)
                    {
                        DdlAgence.Items.Add(new ListItem(v.GUICHET_AGENCE.ToString() + " - " + v.NOM_AGENCE.ToString(), v.CODE_AGENCE.ToString().Trim()));
                    }
                }
            }
        }

        protected void OnBanqueChangeLoadAgences(object sender, EventArgs e)
        {
            // AutreDossier ad = new AutreDossier();
            ListeAgence();
            ListeProfil();
        }

        public void ListeBanque()
        {
            if (Session["code_banque"] == null) Response.Redirect("~/Scoring/Connexion.aspx");

            if (Session["code_banque"] != null)
            {
                // if (Session["code_banque"] == null) Response.Redirect("~/Scoring/Connexion.aspx");

                var param = Session["code_banque"].ToString();

                foreach (var v in service.ListeBanque(ScorCryptage.Decrypt(param)))
                {
                    DdlBanque.Items.Add(new ListItem(v.SIGLE_BANQUE.ToString(), v.CODE_BANQUE.ToString()));
                }
                ListeAgence();
                ListeProfil();
            }
        }

        public bool IsValidEmailAddress(string email)
        {
            try
            {
                var emailChecked = new System.Net.Mail.MailAddress(email);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void InitCouleur()
        {

        }

        protected void ShowvalideOpenConsult_ServerClick(object sender, EventArgs e)
        {
            //OpenShowPasvalideConsult("Suppression...", "Suppression effectuée avec succès !!!");
        }

        protected void TIMINGOpenConsult_ServerClick(object sender, EventArgs e)
        {
            //OpenShowPasvalideConsult("Enregistrement...", "Enregistrement effectué avec succès !!!");
        }

        void OpenShowPasvalideConsult(string titre, string msg)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPasvalideConsult();", true);
            this.lblPasValidemessageConsult.Text = msg;
            this.lblPasValideTitreConsult.Text = titre;
        }

        void OpenShowvalideConsult(string titre, string msg)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowvalideConsult();", true);
            this.lblValidemessageConsult.Text = msg;
            this.lblValideTitreConsult.Text = titre;
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static string[] searchAgence(string text)
        {
            return new string[1];
        }

        protected void actifsParDefaut()
        {
            if (Session["id_user"] == null) Response.Redirect("~/Scoring/Connexion.aspx");

            StringBuilder sbData = new StringBuilder();
            var list_user = service.ListeUser(11, "", "", "", "", "", "", "", "", DateTime.Now, true, "", "");

            foreach (var v in list_user)
            {
                sbData.AppendLine("<tr onclick=\"chargerchamptxt($(this))\" class='tr_backgr' data-pers='" + (v.ID_USER.Trim() == Session["id_user"].ToString().Trim() ? "1" : "0") + "' title='Sélectionner cette ligne'>");
                sbData.AppendLine(string.Format("<td class='text-left' Data1='{2}' Data2='{3}'>{0} {1}</td>", v.NOM_USER.ToUpper(), v.PRENOM_USER, v.NOM_USER.ToUpper(), v.PRENOM_USER));
                sbData.AppendLine(string.Format("<td class='text-left'>{0}</td>", v.LOGIN_USER.ToLower()));
                sbData.AppendLine(string.Format("<td class='text-left'>{0}</td>", v.EMAIL_USER.ToLower()));
                sbData.AppendLine(string.Format("<td class='text-left' Data='{1}'>{0}</td>", v.LIBELLE_PROFIL, v.ID_PROFIL.Trim()));
                sbData.AppendLine(string.Format("<td class='text-left' Data='{1}'>{0}</td>", v.NOM_AGENCE, v.CODE_AGENCE.Trim()));
                sbData.AppendLine(string.Format("<td class='text-left' Data='{1}'>{0}</td>", v.SIGLE_BANQUE, v.CODE_BANQUE.Trim()));
                sbData.AppendLine(string.Format("<td class='display'>{0}</td>", v.STATUT_USER));
                sbData.AppendLine(string.Format("<td class='display'>{0}</td>", v.ID_USER.Trim()));
                sbData.AppendLine("</tr>");
            }
            ListUtilisateur.InnerHtml = sbData.ToString();

            btnActifs.Visible = false;
            btnInactifs.Visible = true;
        }

        protected void btnActifs_Click(object sender, EventArgs e)
        {
            initialiserChamps();
            griserChamps();
            actifsParDefaut();
            btnNouveau.Visible = true;
        }

        protected void inactif()
        {
            if (Session["id_user"] == null) Response.Redirect("~/Scoring/Connexion.aspx");

            StringBuilder sbData = new StringBuilder();
            var list_user = service.ListeUser(12, "", "", "", "", "", "", "", "", DateTime.Now, true, "", "");

            foreach (var v in list_user)
            {
                sbData.AppendLine("<tr onclick=\"chargerchamptxt($(this))\" class='tr_backgr' data-pers='" + (v.ID_USER.Trim() == Session["id_user"].ToString().Trim() ? "1" : "0") + "' title='Sélectionner cette ligne'>");
                sbData.AppendLine(string.Format("<td class='text-left' Data1='{2}' Data2='{3}'>{0} {1}</td>", v.NOM_USER.ToUpper(), v.PRENOM_USER, v.NOM_USER.ToUpper(), v.PRENOM_USER));
                sbData.AppendLine(string.Format("<td class='text-left'>{0}</td>", v.LOGIN_USER.ToLower()));
                sbData.AppendLine(string.Format("<td class='text-left'>{0}</td>", v.EMAIL_USER.ToLower()));
                sbData.AppendLine(string.Format("<td class='text-left' Data='{1}'>{0}</td>", v.LIBELLE_PROFIL, v.ID_PROFIL.Trim()));
                sbData.AppendLine(string.Format("<td class='text-left' Data='{1}'>{0}</td>", v.NOM_AGENCE, v.CODE_AGENCE.Trim()));
                sbData.AppendLine(string.Format("<td class='text-left' Data='{1}'>{0}</td>", v.SIGLE_BANQUE, v.CODE_BANQUE.Trim()));
                sbData.AppendLine(string.Format("<td class='display'>{0}</td>", v.STATUT_USER));
                sbData.AppendLine(string.Format("<td class='display'>{0}</td>", v.ID_USER.Trim()));
                sbData.AppendLine("</tr>");
            }
            ListUtilisateur.InnerHtml = sbData.ToString();

            btnActifs.Visible = true;
            btnInactifs.Visible = false;
        }

        protected void btnInactifs_Click(object sender, EventArgs e)
        {
            initialiserChamps();
            griserChamps();
            inactif();
            btnNouveau.Visible = false;
        }

        protected void initialiserChamps()
        {
            DdlBanque.SelectedIndex = 0;
            DdlAgence.Value = "";
            DdlProfil.Value = "";
            TbNom.Text = "";
            TbPrenom.Text = "";
            TbLoginUser.Text = "";
            TbPassword.Text = "";
            TbEmail.Text = "";
            TbConfirm.Text = "";
            TbIdUtilisateur.Text = "";

            ListeAgence();
            ListeProfil();
        }

        protected void griserChamps()
        {
            DdlBanque.Attributes.Add("c-disable", "1");
            DdlAgence.Attributes.Add("c-disable", "1");
            DdlProfil.Attributes.Add("c-disable", "1");
            TbNom.Attributes.Add("c-disable", "1");
            TbPrenom.Attributes.Add("c-disable", "1");
            TbLoginUser.Attributes.Add("c-disable", "1");
            TbEmail.Attributes.Add("c-disable", "1");
        }

        protected void degriserChamps()
        {
            DdlBanque.Attributes.Add("c-disable", "0");
            DdlAgence.Attributes.Add("c-disable", "0");
            DdlProfil.Attributes.Add("c-disable", "0");
            TbNom.Attributes.Add("c-disable", "0");
            TbPrenom.Attributes.Add("c-disable", "0");
            TbLoginUser.Attributes.Add("c-disable", "0");
            TbEmail.Attributes.Add("c-disable", "0");
        }

        protected void btnNouveau_Click(object sender, EventArgs e)
        {
            degriserChamps();
            initialiserChamps();
            TbIdUtilisateur.Text = "new"; // nécessaire pour afficher les champs mot de passe
        }

        protected void btnDisabled_Click(object sender, EventArgs e)
        {
            validation(true);
            btnNouveau.Visible = true;
            initialiserChamps();
            griserChamps();
            OpenShowPasvalideConsult("Désactivation...", "Cet utilisateur est désactivé avec succès !!!");
        }

        protected void btnEnabled_Click(object sender, EventArgs e)
        {
            validation(true);
            btnNouveau.Visible = false;
            initialiserChamps();
            OpenShowPasvalideConsult("Activation...", "Cet utilisateur est activé avec succès !!!");
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static object LoadAgencesProfilsSelectOptionsHtml(string code_banque)
        {
            return new { _agences = LoadAgencesOptionHtml(code_banque), _profils = LoadProfilsOptionHtml(code_banque) };
        }

        public static string LoadAgencesOptionHtml(string code_banque)
        {
            string content = "";
            Scoringws service = new Scoringws();
            
            if (code_banque != string.Empty) {
                var elements = service.ListeAgenceBanque(code_banque);
                foreach (var element in elements) content += String.Format("<option value='{0}'>{1}</option>", element.CODE_AGENCE.Trim(), element.GUICHET_AGENCE + " - " + element.NOM_AGENCE);
            }

            return content;
        }

        public static string LoadProfilsOptionHtml(string code_banque)
        {
            string content = "";
            Scoringws service = new Scoringws();

            if (code_banque != string.Empty) {
                var elements = service.ListeUser(2, "", "", "", "", "", "", "", "", DateTime.Now, true, code_banque, "");
                foreach (var element in elements) content += String.Format("<option value='{0}'>{1}</option>", element.ID_PROFIL.Trim(), element.LIBELLE_PROFIL);
            }

            return content;
        }
    }
}