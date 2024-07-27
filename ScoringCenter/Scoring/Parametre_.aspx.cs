using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ScoringCenter.Scoring
{
    public partial class Parametre : System.Web.UI.Page
    {
        Scoringws service = new Scoringws();
        StringBuilder sb = new StringBuilder();
        static string code_banque = "";
        List<string> list_doc_completsV = new List<string>();
        protected void Page_Load(object sender, EventArgs e)
        {
            AfficheLogoBank();
            ControllerPage();
           

            //if (!IsPostBack)
            //{
            //}

            //code_banque = ScorCryptage.Decrypt(Session["code_banque"].ToString());
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
                GPA.Visible = false;
                PARAM.Visible = false;

                //Cen.Visible = false;
                //CC.Visible = false;
                Pay.Visible = false;
                //Con.Visible = false;

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
                        //if (element.ID_TYPE_DROIT.ToString().Trim() != "0") //Cen.Visible = true;
                    }
                    if (element.ID_DROIT.ToString().Trim() == "CC")
                    {
                        //if (element.ID_TYPE_DROIT.ToString().Trim() != "0") //CC.Visible = true;
                    }
                    if (element.ID_DROIT.ToString().Trim() == "Pay")
                    {
                        if (element.ID_TYPE_DROIT.ToString().Trim() != "0") Pay.Visible = true;
                    }
                    

                    //et pour les actions sur la page
                    if (element.ID_DROIT.ToString().Trim() == "GPA")
                    {
                        // if (element.ID_TYPE_DROIT.ToString().Trim() != "0") AD.Visible = true;

                      
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
            //getInfoClient(); EBF.Visible = false; ////Fin_Controle////////////////////////////////////////////////////
        }
        protected void Page_Init(object sender, EventArgs e)
        {
            TextBox2.Text = DblProfil.SelectedValue;
            //scoradm

            RemplirGrilleHabilitation();
            InitCouleur();
            ListeProfil();
        }

        protected void btnValider_ServerClick(object sender, EventArgs e)
        {
            if (nombre.Value == "")
            {
                nombre.Focus();
            }
            service.InsertAlerte(Convert.ToInt32(nombre.Value), couleur.Value.ToString());
            OpenShowPasvalideConsult("Enregistrement", "Enregistrement effectuée avec succès !!!");
        }


        protected void ShowvalideOpenConsult_ServerClick(object sender, EventArgs e)
        {

        }

        public void InitCouleur()
        {

            var Vcouleur = service.ListeAlertes();
            if (Vcouleur.Count != 0)
            {
                foreach (var lcouleur in Vcouleur)
                {
                    couleur.Value = lcouleur.COULEUR_ALERTE;
                    nombre.Value = Convert.ToString(lcouleur.NOMBRE_ALERTE);
                }
                
            }
            
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


        public void ListeProfil()
        {
            var i_typeEvaluation = service.ListeUser(2, "", "", "", "", "", "", "", "", DateTime.Now, true, ScorCryptage.Decrypt(Session["code_banque"].ToString()), "");

            DblProfil.Items.Clear();
            DblProfil.Items.Add("");
            foreach (var v in i_typeEvaluation)
            {
                ListItem l = new ListItem();
                l.Value = v.ID_PROFIL;
                l.Text = v.LIBELLE_PROFIL;
                if (v.LIBELLE_PROFIL!="scoradm")
                DblProfil.Items.Add(l);
            }
        }

        public void RemplirGrilleHabilitation()
        {

            StringBuilder sb = new StringBuilder();
            var Vdroit = service.ListeDroit();
            if (Session["id_profil"] == null) Response.Redirect("~/Scoring/Connexion.aspx");
            var id_profil = Session["id_profil"].ToString();
            if (id_profil.Trim() == "0")
            {
                if (Vdroit.Count > 0)
                {
                    int k = 1;
                    foreach (var v in Vdroit)
                    {
                        sb.AppendLine("<tr onclick=\"ClickCheckbox($(this))\" class='clickable'>");
                        sb.AppendLine(string.Format("<td class='text-left' style='display:none'>{0}</td>", v.ID_DROIT.Trim()));
                        sb.AppendLine(string.Format("<td  style='padding-left:5%'>{0}</td>", v.LIBELLE_DROIT));
                        sb.AppendLine(string.Format("<td  class='text-center'><input name='selectM' runat='server' type='checkbox' id='M' class='singlechkbox caseACocher M_Cocher{0}' codeM=" + v.ID_DROIT + "/></td>", k));
                        sb.AppendLine(string.Format("<td class='text-center' ><input name='selectV' runat='server' type='checkbox' id='V' class='singlechkbox caseACocher V_Cocher{0}' codeV=" + v.ID_DROIT + "/></td>", k));
                        k++;
                    }
                }
            }
            else
            {
                if (Vdroit.Count > 0)
                {
                    int k = 1;
                    foreach (var v in Vdroit)
                    {
                        if (v.ID_DROIT.Trim() != "PARAM" || v.ID_DROIT.Trim() != "GP" || v.ID_DROIT.Trim() != "GPA" || v.ID_DROIT.Trim() != "GU")
                        {
                            sb.AppendLine("<tr onclick=\"ClickCheckbox($(this))\" class='clickable'>");
                            sb.AppendLine(string.Format("<td class='text-left' style='display:none'>{0}</td>", v.ID_DROIT.Trim()));
                            sb.AppendLine(string.Format("<td  style='padding-left:5%'>{0}</td>", v.LIBELLE_DROIT));
                            sb.AppendLine(string.Format("<td  class='text-center'><input name='selectM' runat='server' type='checkbox' id='M' class='singlechkbox caseACocher M_Cocher{0}' codeM=" + v.ID_DROIT + "/></td>", k));
                            sb.AppendLine(string.Format("<td class='text-center' ><input name='selectV' runat='server' type='checkbox' id='V' class='singlechkbox caseACocher V_Cocher{0}' codeV=" + v.ID_DROIT + "/></td>", k));
                            k++;
                        }
                    }
                }
            }
            
            
            ListDroit.InnerHtml = sb.ToString();
        }

        protected void editSelectionM(object sender, CommandEventArgs e)
        {
            if (DblProfil.Text.Trim() == "")
            {
                OpenShowPasvalideConsult("Message erreur", "Sélectionner votre Profil.");
                return;
            }

            var ListeDroit_profil = service.ListeDroit_profil(DblProfil.Text.Trim());
            if (ListeDroit_profil.Count != 0)
            {
                service.DeleteDroit_Profil( DblProfil.Text.Trim());
            }

            int cpt = int.Parse(e.CommandArgument.ToString());
            //List<string> list_vNumords = new List<string>();
            List<string> list_doc_completsM = new List<string>();
            string[] result_doc_completsM = null;
            char[] splitchar = { '@' };
            string doc_completsM = checked_doc_completsM.Value;
            result_doc_completsM = doc_completsM.Split(splitchar);


            for (int i = 1; i < result_doc_completsM.Length; i++)
            {
                list_doc_completsM.Add(result_doc_completsM[i]);
            }
            editSelectionV();
            editerSelectionM(cpt, list_doc_completsM);
        }

        protected void editSelectionV()
        {
            //List<string> list_doc_completsV = new List<string>();
            string[] result_doc_completsV = null;
            char[] splitchar = { '@' };
            string doc_completsV = checked_doc_completsV.Value;
            result_doc_completsV = doc_completsV.Split(splitchar);

            for (int i = 1; i < result_doc_completsV.Length; i++)
            {
                list_doc_completsV.Add(result_doc_completsV[i]);
            }
        }



        public void editerSelectionM(int cpt, List<string> list_doc_complets)
        {

            string id_ecranM = String.Empty;
            string id_type_droitM = String.Empty;
            string id_ecranV = String.Empty;
            string id_type_droitV = String.Empty;
            string id_ecran = "";

            List<string[]> int_docs = new List<string[]>();
            foreach (var ligne in list_doc_complets)
            {
                //var ligne = code_dec
                var Params = ligne.Split('#');
                id_ecranM = Params[0].Trim();
                id_type_droitM = Params[1].Trim();
               
                foreach (var ligneV in list_doc_completsV)
                {
                    //var ligne = code_dec
                    var ParamsV = ligneV.Split('#');
                    id_ecranV = ParamsV[0].Trim();
                    id_type_droitV = ParamsV[1].Trim();
                    if (id_ecranM.Trim() == id_ecranV.Trim())
                    {
                        id_ecran = id_ecranV.Trim();
                        int id_Droit_profil =0;
                        var Var_id_Droit_profil = service.id_Droit_profil();
                        if (Var_id_Droit_profil== 0)
                        {
                            id_Droit_profil = 1;
                        }
                        else
                        {
                            id_Droit_profil = Var_id_Droit_profil + 1;
                        }

                        if (id_type_droitM.Trim() == id_type_droitV.Trim())
                        {
                            service.InsertDroit_Profil(id_Droit_profil, id_ecran.Trim(), DblProfil.Text.Trim(), "0");
                            id_Droit_profil = id_Droit_profil + 1;
                        }
                        else
                        {
                            service.InsertDroit_Profil(id_Droit_profil, id_ecran.Trim(), DblProfil.Text.Trim(), id_type_droitM.Trim());

                           var id_Droit_profil2 = id_Droit_profil + 1;

                           service.InsertDroit_Profil(id_Droit_profil2, id_ecran.Trim(), DblProfil.Text.Trim(), id_type_droitV.Trim());
                        }
                      
                    }
                }
            }

            OpenShowPasvalideConsult("Modification", "Modification effectuée avec succès !!!");
            DblProfil.SelectedIndex = 0;
            RemplirGrilleHabilitation();

        }


        protected void DblProfil_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            StringBuilder sb = new StringBuilder();
            var Vdroit = service.ListeDroit();
            TextBox2.Text = DblProfil.SelectedValue;
            if (Vdroit.Count > 0)
            {
                int k = 1;
                foreach (var v in Vdroit)
                {
                    sb.AppendLine("<tr class='clickable'>");
                    sb.AppendLine(string.Format("<td class='text-left' style='display:none'>{0}</td>", v.ID_DROIT.Trim()));
                    sb.AppendLine(string.Format("<td  style='padding-left:5%'>{0}</td>", v.LIBELLE_DROIT));

                    string droit = v.ID_DROIT.Trim();
                    string profile = DblProfil.SelectedValue.Trim();

                    var Var_Liste_IdDroit_IdProfil = service.Liste_IdDroit_IdProfil(droit, profile);

                    if (Var_Liste_IdDroit_IdProfil.Count == 2)
                    {
                        bool mo = false;
                        bool vu = false;


                        foreach (var ligne in Var_Liste_IdDroit_IdProfil)
                        {
                            if (ligne.ID_TYPE_DROIT.Trim() == "1")
                            {
                                mo = true;

                            }
                            if (ligne.ID_TYPE_DROIT.Trim() == "2")
                            {
                                vu = true;
                            }
                        }

                        if (mo)
                        {
                            sb.AppendLine(string.Format("<td  class='text-center'><input name='selectM' runat='server' checked='checked' type='checkbox' id='M' class='singlechkbox caseACocher M_Cocher{0}' codeM=" + v.ID_DROIT + "/></td>", k));
                        }
                        else
                        {
                            sb.AppendLine(string.Format("<td  class='text-center'><input name='selectM' runat='server' type='checkbox' id='M' class='singlechkbox caseACocher M_Cocher{0}' codeM=" + v.ID_DROIT + "/></td>", k));
                        }

                        if (vu)
                        {
                            sb.AppendLine(string.Format("<td class='text-center' ><input name='selectV' runat='server' checked='checked' type='checkbox' id='V' class='singlechkbox caseACocher V_Cocher{0}' codeV=" + v.ID_DROIT + "/></td>", k));
                        }
                        else
                        {
                            sb.AppendLine(string.Format("<td class='text-center' ><input name='selectV' runat='server' type='checkbox' id='V' class='singlechkbox caseACocher V_Cocher{0}' codeV=" + v.ID_DROIT + "/></td>", k));
                        }

                    }

                    if (Var_Liste_IdDroit_IdProfil.Count == 1)
                    {
                        sb.AppendLine(string.Format("<td  class='text-center'><input name='selectM' runat='server' type='checkbox' id='M' class='singlechkbox caseACocher M_Cocher{0}' codeM=" + v.ID_DROIT + "/></td>", k));
                        sb.AppendLine(string.Format("<td class='text-center' ><input name='selectV' runat='server' type='checkbox' id='V' class='singlechkbox caseACocher V_Cocher{0}' codeV=" + v.ID_DROIT + "/></td>", k));

                    }

                    if (Var_Liste_IdDroit_IdProfil.Count == 0)
                    {
                        sb.AppendLine(string.Format("<td  class='text-center'><input name='selectM' runat='server' type='checkbox' id='M' class='singlechkbox caseACocher M_Cocher{0}' codeM=" + v.ID_DROIT + "/></td>", k));
                        sb.AppendLine(string.Format("<td class='text-center' ><input name='selectV' runat='server' type='checkbox' id='V' class='singlechkbox caseACocher V_Cocher{0}' codeV=" + v.ID_DROIT + "/></td>", k));

                    }


                    k++;

                }
            }
            ListDroit.InnerHtml = sb.ToString();
        }


    }
}