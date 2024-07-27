using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Security.Cryptography;
using ScoringCenter.ScorManager;

namespace ScoringCenter.Scoring
{
    public partial class TableauBordAutresDossier : System.Web.UI.Page
    {
        StringBuilder sb = new StringBuilder();
        StringBuilder sc = new StringBuilder();
        Scoringws service = new Scoringws();
        private static string idModele = "";
        private static string ETCIV_MATRICULE = "";
        private System.Globalization.CultureInfo frCult = System.Globalization.CultureInfo.CreateSpecificCulture("fr-FR");
        protected void Page_Load(object sender, EventArgs e)
        {
            ControllerPage();
            if (!IsPostBack)
            {
                AfficherTableau();
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
                //GP.Visible = false;
                //GU.Visible = false;
                //GPA.Visible = false;
                //PARAM.Visible = false;
                ////Cen.Visible = false;
                ////CC.Visible = false;
                //Pay.Visible = false;
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

                    //if (element.ID_DROIT.ToString().Trim() == "GP")
                    //{
                    //    if (element.ID_TYPE_DROIT.ToString().Trim() != "0") GP.Visible = true;
                    //}
                    //if (element.ID_DROIT.ToString().Trim() == "PARAM")
                    //{
                    //    if (element.ID_TYPE_DROIT.ToString().Trim() != "0") PARAM.Visible = true;
                    //}

                    //if (element.ID_DROIT.ToString().Trim() == "GU")
                    //{
                    //    if (element.ID_TYPE_DROIT.ToString().Trim() != "0") GU.Visible = true;
                    //}
                    //if (element.ID_DROIT.ToString().Trim() == "GPA")
                    //{
                    //    if (element.ID_TYPE_DROIT.ToString().Trim() != "0") GPA.Visible = true;
                    //}
                    //et pour les actions sur la page
                    if (element.ID_DROIT.ToString().Trim() == "TB")
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

        }


        public void getInfoClient(string id_scoring)
        {
            var code_banque = Session["code_banque"].ToString();
            var info = service.DetailsDossierContrepartie(code_banque, id_scoring);
            string id_dossier = "";
            foreach (var v in info)
            {
                ETCIV_MATRICULE = v.ETCIV_MATRICULE;
                id_dossier = v.ID_DOSSIER.Trim();
                       
            }
            service.ENREGISTREMENT_ENCOURS(id_dossier.Trim(), ETCIV_MATRICULE.Trim());
        }

        protected void Valider_Selection(object sender, EventArgs e)
        {
            var tabx = checked_docs.Value.Split('@');
            var id_user = Session["id_user"].ToString();
            Session.Add("id_user", id_user);
            var j = 1;
            while (j < tabx.Length)
            {
                //val tabx[j].Trim();
                if (tabx[j].Trim().Substring(0, 1) != "S")
                {
                    if (tabx[j].Trim() == "1")
                    {
                        //rejete 

                        var code_banque = Session["code_banque"].ToString();
                        var info = service.DetailsDossierContrepartie(code_banque, tabx[j + 1].Trim());
                        string id_dossier0 = "";
                        foreach (var v in info)
                        {
                            id_dossier0 = v.ID_DOSSIER;
                        }


                        var DetailNotes = service.DetailsNotesDossier(id_dossier0);

                        if (DetailNotes.Count != 0)
                        {
                            foreach (var Notes in DetailNotes)
                            {
                                service.RejetNotesDossier(Notes.ID_DOSSIER, id_user,"");
                            }
                        }
                    }
                    else
                    {
                        //valide
                        var code_banque = Session["code_banque"].ToString();
                        var info = service.DetailsDossierContrepartie(code_banque, tabx[j + 1].Trim());
                        string id_dossier0 = "";
                        foreach (var v in info)
                        {
                            id_dossier0 = v.ID_DOSSIER;
                        }


                        var DetailNotes = service.DetailsNotesDossier(id_dossier0);

                        if (DetailNotes.Count != 0)
                        {
                            foreach (var Notes in DetailNotes)
                            {
                                service.ValideNotesDossier(Notes.ID_DOSSIER, Notes.NOTE_PROP, id_user,"");
                            }
                        }
                        getInfoClient(tabx[j + 1].Trim());
                    }
                }


                j = j + 2;
            }

            //for (var i = 1; i < tabx.Length; i++)
            //{

            //    var DetailNotes= service.DetailsNotesDossier(tabx[i].Trim());

            //    if (DetailNotes.Count != 0)
            //    {
            //        foreach (var Notes in DetailNotes)
            //        {
            //            service.ValideNotesDossier(Notes.ID_DOSSIER, Notes.NOTE_PROP, id_user);
            //        }
            //    }
            //}
            Response.Redirect("~/Scoring/TableauBordAutreDossier.aspx");
        }

        private void getInfoDossier()
        {
            // Session.Add("id_dossier", "1");
            if (Session["id_dossier"] == null) Response.Redirect("~/Scoring/Connexion.aspx"); 

            var idDossier = Session["id_dossier"].ToString();
            Session.Add("id_dossier", idDossier);

            var elements = service.InfoDossier(idDossier);
            foreach (var dossier in elements)
            {
               
                idModele = dossier.MODELE_DOSSIER;
            }
        }

        void AfficherTableau()
        {
            var Vcouleur = service.select_Couleur();
            var couleur = "";
            int Ii = 0;
            //foreach(var fo in Vcouleur)
            couleur = Vcouleur[0].COULEUR_ALERTE;
            var nombre = Convert.ToInt32(Vcouleur[0].NOMBRE_ALERTE);
            var listes = service.select_TABLEAU(ScorCryptage.Decrypt(Session["code_banque"].ToString()));

            sc.AppendLine("<table id='datatable_bord' class='table table-bordered table-hover scor_table1'><thead class='table-heigth1'>");
            sc.AppendLine("<th class='text-center' style='width:20%'>Raison sociale</th>");
            //sc.AppendLine("<th class='text-center' style='width:10%' >Chiffre d'affaire</th>");
            sc.AppendLine("<th class='text-center' style='width:10%'>Modèle Notation</th><th class='text-center ' style='width: 5%;'>Note financière</th><th class='text-center' style='width: 5%;' >Note qualitative</th>");
            sc.AppendLine("<th class='text-center' style='width:5%' >Note contrepartie</th>");
            sc.AppendLine("<th class='text-center' style='width: 5%;'>Note opération</th><th class='text-center' style='width: 10%;'>Note proposée</th><th class='text-center' style='width:20%'>Proposée par</th>");
            /*<th>Date Note Proposée</th>*/
            sc.AppendLine("<th class='text-center' style='width:5%'>Durée</th><th class='text-center' style='width:15%'>Avis</th></tr>");
            sc.AppendLine("</thead>");
            sc.AppendLine("<tbody style=\"background-color:#FFFFFF;\">");

            var id_user = Session["id_user"].ToString();

            if (listes.Count != 0)
            {



                foreach (var v in listes)
                {
                    var test222 = 0;
                    var test111 = DataManager.Ps_scor_get_seuil_dossier(v.ID_DOSSIER)[0].ID_SCOR_SEUIL_DELEGUATION;

                    foreach (var ki in DataManager.Ps_scor_verifseuil_Uti(id_user))
                    {
                        if (test111 == Convert.ToInt32(ki.ID_SCOR_SEUIL_DELEGUATION))
                        {
                            test222++;
                        }
                    }

                    if (test222 != 0)
                    {
                        //v.ID_DOSSIER
                        //ls.ID_SCORING.ToString())
                        //Encrypt(ls.ID_SCORING.ToString())
                        var idscoring = ""; if (v.ID_SCORING != null) idscoring = v.ID_SCORING.ToString();
                        var etcivnom = ""; if (v.ETCIV_NOMREDUIT != null) etcivnom = v.ETCIV_NOMREDUIT.ToString();
                        var secteuract = ""; if (v.SECTEUR_D_ACTIVITE != null) secteuract = v.SECTEUR_D_ACTIVITE.ToString();
                        var ca = ""; if (v.CA != null) ca = Convert.ToString(string.Format(frCult, "{0:#,##0}", Convert.ToDecimal(v.CA)));
                        var modeledossier = idModele; if (v.LIBELLE_MODELE != null) modeledossier = v.LIBELLE_MODELE.ToString();
                        var nomuser = ""; if (v.NOM_USER != null) nomuser = v.NOM_USER.ToString();
                        var prenomuser = ""; if (v.PRENOM_USER != null) prenomuser = v.PRENOM_USER.ToString();
                        var notefi = ""; if (v.NOTE_AF != null && v.NOTE_AF.Trim() != "") notefi = v.NOTE_AF.ToString(); else notefi = "NC";
                        var notequa = ""; if (v.NOTE_AQ != null && v.NOTE_AQ.Trim() != "") notequa = v.NOTE_AQ.ToString(); else notequa = "NC";
                        var notecontrep = ""; if (v.NOTE_SYN != null && v.NOTE_SYN.Trim() != "") notecontrep = v.NOTE_SYN.ToString(); else notecontrep = "NC";
                        var notesys = ""; if (v.NOTE_OP != null && v.NOTE_OP.Trim() != "") notesys = v.NOTE_OP.ToString(); else notesys = "NC";
                        var notepropos = ""; if (v.NOTE_PROP != null && v.NOTE_PROP.Trim() != "") notepropos = v.NOTE_PROP.ToString(); else notepropos = "NC";
                        var couleurs = "";
                        var couleurnote = DateTime.UtcNow - v.DATE_PROP;
                        if (couleurnote.Days >= nombre) { couleurs = couleur; }

                        if (notefi == "NC")
                        {
                            modeledossier = "A dire d'exp";
                            notecontrep = notequa;
                        }

                        string Nomprenom = nomuser + " " + prenomuser;
                        if (Nomprenom.Length>20)
                            Nomprenom = (nomuser + " " + prenomuser).Substring(0, 20) + "...";

                        if (notepropos.Trim() != "")
                        {

                            sc.AppendLine(string.Format("<tr title='Sélectionner la ligne' >"));
                            //sc.AppendLine(string.Format("<td style='text-align: left;'><span style='font-weight: bold; color: #022D65; text-decoration: none;'>{0}</span></td>", idscoring));
                            sc.AppendLine(string.Format("<td id={1} class='text-left' style='margin-left: 2%' title='Selectionner la ligne' onclick='ligneclick(this.id)' >{0}</td>", etcivnom, ScorCryptage.Encrypt(idscoring)));
                            //sc.AppendLine(string.Format("<td id={1} title='Selectionner la ligne' onclick='ligneclick(this.id)'>{0}</td>", secteuract, ScorCryptage.Encrypt(idscoring)));
                            //sc.AppendLine(string.Format("<td id={1} title='Selectionner la ligne' onclick='ligneclick(this.id)'>{0}</td>", ca, ScorCryptage.Encrypt(idscoring)));
                            sc.AppendLine(string.Format("<td id={1} class='text-center' title='Selectionner la ligne' onclick='ligneclick(this.id)'>{0}</td>", modeledossier, ScorCryptage.Encrypt(idscoring)));
                            sc.AppendLine(string.Format("<td id={1} class='text-center' title='Selectionner la ligne' onclick='ligneclick(this.id)'>{0}</td>", notefi.ToString(), ScorCryptage.Encrypt(idscoring)));
                            sc.AppendLine(string.Format("<td id={1} class='text-center' title='Selectionner la ligne' onclick='ligneclick(this.id)'>{0}</td>", notequa.ToString(), ScorCryptage.Encrypt(idscoring)));
                            sc.AppendLine(string.Format("<td id={1} class='text-center' title='Selectionner la ligne' onclick='ligneclick(this.id)'>{0}</td>", notecontrep.ToString(), ScorCryptage.Encrypt(idscoring)));
                            sc.AppendLine(string.Format("<td id={1} class='text-center' title='Selectionner la ligne' onclick='ligneclick(this.id)' >{0}</td>", notesys.ToString(), ScorCryptage.Encrypt(idscoring)));
                            sc.AppendLine(string.Format("<td id={2} class='text-center' title='Selectionner la ligne' onclick='ligneclick(this.id)'>{0}  {1}</td>", notepropos.ToString(), Convert.ToString(v.DATE_PROP.Date.Day + "/" + v.DATE_PROP.Date.Month + "/" + v.DATE_PROP.Date.Year), ScorCryptage.Encrypt(idscoring)));
                            //sc.AppendLine(string.Format("<td id={1} class='text-left' title='Selectionner la ligne' onclick='ligneclick(this.id)' ><span style='font-weight: bold; color: #022D65; text-decoration: none;'>{0}</span></td>", nomuser, ScorCryptage.Encrypt(idscoring)));
                            sc.AppendLine(string.Format("<td id={1} class='text-left' style='margin-left: 2px' title='Selectionner la ligne' onclick='ligneclick(this.id)' >{0}</td>", Nomprenom, ScorCryptage.Encrypt(idscoring)));
                            //sc.AppendLine(string.Format("<td style='text-align: left; width: 15%;'>{0}</td>", Convert.ToString(v.DATE_PROPOS.Value.Date.Day + "/" + v.DATE_PROPOS.Value.Date.Month + "/" + v.DATE_PROPOS.Value.Date.Year)));
                            sc.AppendLine(string.Format("<td id={2} class='text-center' onclick='ligneclick(this.id)' style=' background-color:{0};'>{1}</td>", couleurs, couleurnote.Days, ScorCryptage.Encrypt(idscoring)));
                            sc.AppendLine(string.Format("<td> Rejeté <input type=\"radio\" class='checkboxx Cocher{0}' name=\"{0}\" data-toggle='switch'  runat=\"server\" id=\"{0}@1\" onmousedown=\"\" value=\"1\"/> validé <input type=\"radio\" class='checkboxx Cocher{0}' name=\"{0}\" data-toggle='switch'  runat=\"server\" id=\"{0}@2\" onmousedown=\"\" value=\"2\"/></td>", idscoring.Trim()));

                            sc.AppendLine("</tr>");
                        }
                        else
                        {
                            Ii = 1;

                        }
                    }


                }
                if (Ii == 1)
                    sc.AppendLine("<tr> Pas de donnees</tr>");
                validd.Visible = true;
            }
            else
            {
                validd.Visible = false;
            }
            sc.AppendLine("</tbody></table>");
            ListDocTableauBord.InnerHtml = sc.ToString();
        }

        //void AfficherTableau()
        //{
        //    var Vcouleur = service.select_Couleur();
        //    var couleur = "";
        //    int Ii = 0;
        //    //foreach(var fo in Vcouleur)
        //    couleur = Vcouleur[0].COULEUR_ALERTE;
        //    var nombre = Convert.ToInt32(Vcouleur[0].NOMBRE_ALERTE);
        //    var listes = service.select_TABLEAU(ScorCryptage.Decrypt(Session["code_banque"].ToString()));
        //    sc.AppendLine("<table id='datatable_bord' class='table table-bordered table-hover scor_table1'><thead class='table-heigth1'>");
        //    sc.AppendLine("<th class='text-center' style='width:5%'>Identifiant</th><th class='text-center' style='width:15%'>Raison sociale</th>");
        //    sc.AppendLine("<th class='text-center' style='width:10%' >Chiffre d'affaire</th>");
        //    sc.AppendLine("<th class='text-center' style='width:10%'>Modèle Notation</th><th class='text-center ' style='width: 5%;'>Note financière</th><th class='text-center' style='width: 5%;' >Note qualitative</th>");
        //    sc.AppendLine("<th class='text-center' style='width: 5%;'>Note calculée</th><th class='text-center' style='width: 10%;'>Note proposée</th><th class='text-center' style='width:15%'>Proposée par</th>");
        //    /*<th>Date Note Proposée</th>*/
        //    sc.AppendLine("<th class='text-center' style='width:5%'>Durée</th><th class='text-center' style='width:15%'>Avis</th></tr>");
        //    sc.AppendLine("</thead>");
        //    sc.AppendLine("<tbody style=\"background-color:#FFFFFF;\">");
        //    if (listes.Count != 0)
        //    {
               

        //        foreach (var v in listes)
        //        {
        //            //ls.ID_SCORING.ToString())
        //            //Encrypt(ls.ID_SCORING.ToString())
        //            var idscoring = ""; if (v.ID_SCORING != null) idscoring = v.ID_SCORING.ToString();
        //            var etcivnom = ""; if (v.ETCIV_NOMREDUIT != null) etcivnom = v.ETCIV_NOMREDUIT.ToString();
        //            var secteuract = ""; if (v.SECTEUR_D_ACTIVITE != null) secteuract = v.SECTEUR_D_ACTIVITE.ToString();
        //            var ca = ""; if (v.CA != null) ca = Convert.ToString(string.Format(frCult, "{0:#,##0}", Convert.ToDecimal(v.CA)));
        //            var modeledossier = idModele; if (v.MODELE_DOSSIER != null) modeledossier = v.MODELE_DOSSIER.ToString();
        //            var nomuser = ""; if (v.NOM_USER != null) nomuser = v.NOM_USER.ToString();
        //            var notefi = ""; if (v.NOTE_AF != null) notefi = v.NOTE_AF.ToString();
        //            var notequa = ""; if (v.NOTE_AQ != null) notequa = v.NOTE_AQ.ToString();
        //            var notesys = ""; if (v.NOTE_SYN != null) notesys = v.NOTE_SYN.ToString();
        //            var notepropos = ""; if (v.NOTE_PROP != null) notepropos = v.NOTE_PROP.ToString();
        //            var couleurs = "";
        //            var couleurnote = DateTime.UtcNow - v.DATE_PROP;
        //            if (couleurnote.Days >= nombre) { couleurs = couleur; }
        //            if (notepropos.Trim() != "")
        //            {
        //                sc.AppendLine(string.Format("<tr title='Sélectionner la ligne' >"));
        //                sc.AppendLine(string.Format("<td style='text-align: left;'><span style='font-weight: bold; color: #022D65; text-decoration: none;'>{0}</span></td>", idscoring));
        //                sc.AppendLine(string.Format("<td id={1} title='Selectionner la ligne' onclick='ligneclick(this.id)' >{0}</td>", etcivnom, ScorCryptage.Encrypt(idscoring)));
        //                //sc.AppendLine(string.Format("<td id={1} title='Selectionner la ligne' onclick='ligneclick(this.id)'>{0}</td>", secteuract, ScorCryptage.Encrypt(idscoring)));
        //                sc.AppendLine(string.Format("<td id={1} title='Selectionner la ligne' onclick='ligneclick(this.id)'>{0}</td>", ca, ScorCryptage.Encrypt(idscoring)));
        //                sc.AppendLine(string.Format("<td id={1} title='Selectionner la ligne' onclick='ligneclick(this.id)'>{0}</td>", modeledossier, ScorCryptage.Encrypt(idscoring)));
        //                sc.AppendLine(string.Format("<td id={1} title='Selectionner la ligne' onclick='ligneclick(this.id)'>{0}</td>", notefi.ToString(), ScorCryptage.Encrypt(idscoring)));
        //                sc.AppendLine(string.Format("<td id={1} title='Selectionner la ligne' onclick='ligneclick(this.id)'>{0}</td>", notequa.ToString(), ScorCryptage.Encrypt(idscoring)));
        //                sc.AppendLine(string.Format("<td id={1} title='Selectionner la ligne' onclick='ligneclick(this.id)' >{0}</td>", notesys.ToString(), ScorCryptage.Encrypt(idscoring)));
        //                sc.AppendLine(string.Format("<td id={2} title='Selectionner la ligne' onclick='ligneclick(this.id)'>{0}  {1}</td>", notepropos.ToString(), Convert.ToString(v.DATE_PROP.Date.Day + "/" + v.DATE_PROP.Date.Month + "/" + v.DATE_PROP.Date.Year), ScorCryptage.Encrypt(idscoring)));
        //                sc.AppendLine(string.Format("<td id={1} title='Selectionner la ligne' onclick='ligneclick(this.id)' ><span style='font-weight: bold; color: #022D65; text-decoration: none;'>{0}</span></td>", nomuser, ScorCryptage.Encrypt(idscoring)));
        //                //sc.AppendLine(string.Format("<td style='text-align: left; width: 15%;'>{0}</td>", Convert.ToString(v.DATE_PROPOS.Value.Date.Day + "/" + v.DATE_PROPOS.Value.Date.Month + "/" + v.DATE_PROPOS.Value.Date.Year)));
        //                sc.AppendLine(string.Format("<td id={2} onclick='ligneclick(this.id)' style=' background-color:{0};'>{1}</td>", couleurs, couleurnote.Days, ScorCryptage.Encrypt(idscoring)));
        //                sc.AppendLine(string.Format("<td> Rejeté <input type=\"radio\" class='checkboxx' name=\"{0}\" data-toggle='switch'  runat=\"server\" id=\"{0}@1\" onmousedown=\"\" value=\"1\"/> validé <input type=\"radio\" class='checkboxx' name=\"{0}\" data-toggle='switch'  runat=\"server\" id=\"{0}@2\" onmousedown=\"\" value=\"2\"/></td>", idscoring.Trim()));

        //                sc.AppendLine("</tr>");
        //            }
        //            else
        //            {
        //                Ii = 1;

        //            }
                    
        //        }
        //        if (Ii == 1)
        //            sc.AppendLine("<tr> Pas de donnees</tr>");
        //        validd.Visible = true;
        //    }
        //    else
        //    {
        //        validd.Visible = false;
        //    }
        //    sc.AppendLine("</tbody></table>");

        //    ListDocTableauBord.InnerHtml = sc.ToString();
        //}
    }
}