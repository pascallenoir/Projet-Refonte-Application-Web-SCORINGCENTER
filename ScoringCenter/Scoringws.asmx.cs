using ScoringCenter.ScorManager;
using ScoringCenter.Scoring;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Script.Services;
using System.Web.Script.Serialization;
using Microsoft.Ajax.Utilities;

namespace ScoringCenter
{
    /// <summary>
    /// Summary description for Scoringws
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class Scoringws : System.Web.Services.WebService
    {
        //-VERIFIER HABILITATION- Stephane Kassa

        public List<PS_SCOR_LIRE_HABILITATIONResult> VHABILITATION(string id_profil)
        {
            return DataManager.VHABILITATION(id_profil);
        }
        //-CONNEXION- Stephane Kassa
        public bool Authentification(string login_user, string password_user)
        {
            if (DataManager.Authentification(login_user, password_user).Count != 0)
                return true;
            else
                return false;
        }
        public List<PS_LOG_RECHERCHECONTREPARTIEResult> AuthentificationClient(string login_user, string password_user)
        {
            return DataManager.AuthentificationClient(login_user, password_user);
        }

        public List<PS_VSCOR_CONNEXIONResult> InfoUtilisateur(string login_user, string password_user)
        {
            return DataManager.Authentification(login_user, password_user).ToList();
        }

        public List<PS_VSCOR_CONNEXIONResult> InfoBanque(string code_agence)
        {
            return DataManager.InfoBanque(code_agence).ToList();
        }

        //Eloi 18/01/2023
        public PS_VSCOR_AUTREDOSSIERResult InfosBanqueByCode(string code_banque)
        {
            return DataManager.InfosBanqueByCode(code_banque);
        }


        //-AUTRE DOSSIER- Stephane Kassa - @it
        public List<PS_VSCOR_AUTREDOSSIERResult> ListeBanque(string code_banque)
        {
            return DataManager.ListeBanque(code_banque).ToList();
        }

        public List<PS_VSCOR_AUTREDOSSIERResult> ListeAgenceBanque(string code_banque)
        {
            return DataManager.ListeAgenceBanque(code_banque).ToList();
        }
        public List<PS_VSCOR_AUTREDOSSIERResult> ListeContrepartie(string code_banque, string code_agence, string id_scoring, string etciv_nomreduit)
        {
            return DataManager.ListeContrepartie(code_banque, code_agence, id_scoring, etciv_nomreduit);
        }
        //-FICHE SIGNALETIQUE- Stephane Kassa
        public List<PS_VSCOR_FICHESIGNALETIQUEResult> DetailsDossierContrepartie(string code_banque, string id_scoring)
        {
            return DataManager.DetailsDossierContrepartie("", id_scoring);
        }

        public List<PS_VSCOR_VALIDATIONNOTEResult> DetailsNotesDossier(string id_dossier)
        {
            return DataManager.DetailsNotesDossier(id_dossier);
        }

        public List<PS_VSCOR_VALIDATIONNOTEResult> AfficherCommProposer(string id_dossier)
        {
            return DataManager.AfficherCommProposer(id_dossier);
        }
        public List<PS_VSCOR_VALIDATIONNOTEResult> ProposeNotesDossier(string id_dossier, string Note_Prop, string id_user, string commentaire)
        {
            return DataManager.ProposeNotesDossier(id_dossier, Note_Prop, id_user, commentaire);
        }

        //public List<PS_VSCOR_VALIDATIONNOTEResult> Adiredexpert(string id_dossier)
        //{
        //    return DataManager.Adiredexpert(id_dossier);
        //}
        //public List<PS_VSCOR_VALIDATIONNOTEResult> selectAdiredexpert(string id_dossier)
        //{
        //    return DataManager.selectAdiredexpert(id_dossier);
        //}

        public List<PS_VSCOR_VALIDATIONNOTEResult> Adiredexpert(string id_dossier)
        {
            return DataManager.Adiredexpert(id_dossier);
        }
        public List<PS_VSCOR_VALIDATIONNOTEResult> selectAdiredexpert(string id_dossier)
        {
            return DataManager.selectAdiredexpert(id_dossier);
        }
        public List<PS_VSCOR_VALIDATIONNOTEResult> offAdiredexpert(string id_dossier)
        {
            return DataManager.offAdiredexpert(id_dossier);
        }

        //[WebMethod]
        //[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        //public string[] offAdiredexpert(string id_dossier)
        //{
        //    string[] res = new string[1];
        //    //id_dossier = Session["id_dossier"].ToString();
        //    DataManager.offAdiredexpert(id_dossier);
        //   // Session["id_dossier"] = id_dossier;
        //    res[0] = "";
        //    return res;
        //}
        public List<PS_VSCOR_VALIDATIONNOTEResult> ValideNotesDossier(string id_dossier, string Note_Val, string id_user, string commentaire)
        {
            return DataManager.ValideNotesDossier(id_dossier, Note_Val, id_user, commentaire);
        }
        public void RejetNotesDossier(string id_dossier, string id_user, string commentaire)
        {
            DataManager.RejetNotesDossier(id_dossier, id_user, commentaire);
        }
        public List<PS_VSCOR_VALIDATIONNOTEResult> listpropver(string id_dossier)
        {
            return DataManager.listpropver(id_dossier);
        }

        //-TABLEAU_DE_BORD - Stephane Kassa
        public List<PS_VSCOR_TABLEAU_DE_BORDResult> select_TABLEAU(string code_banque)
        {
            return DataManager.select_TABLEAU(code_banque);
        }

        public List<PS_VSCOR_TABLEAU_DE_BORDResult> select_Couleur()
        {
            return DataManager.select_Couleur();
        }
        //( !!! Supprimer la partie ANALYSE QUALITATIVE !!!)
        //-ANALYSE GENERALE 
        public List<PS_VSCOR_GENERALEResult> InfoDossier(string id_dossier)
        {
            return DataManager.InfoDossier(id_dossier).ToList();
        }

        public List<PS_VSCOR_GENERALEResult> ListeChapitre(string id_modele)
        {
            return DataManager.ListeChapitre(id_modele).ToList();
        }

        public List<PS_VSCOR_GENERALEResult> ListeQuestion(string id_chapitre)
        {
            return DataManager.ListeQuestion(id_chapitre).ToList();
        }

        public List<PS_VSCOR_GENERALEResult> ListeReponse(string id_question)
        {
            return DataManager.ListeReponse(id_question).ToList();
        }
        public List<PS_VSCOR_GENERALEResult> ListeReponseOperation(string id_question)
        {
            return DataManager.ListeReponseOperation(id_question).ToList();
        }
        //-stephane
        public decimal calculerNoteQuest(int valeur_recu, string id_notation, string id_modele)
        {

            decimal VMAX = valeur_recu != 0 ? DataManager.calculerNoteQuest(valeur_recu, id_notation, id_modele) : 0;

            return VMAX;
        }

        public void Insertreponse(string @id_dossier, string @type_note, string @id_user, string @id_reponse, string iif)
        {
            DataManager.Insertreponse(@id_dossier, @type_note, @id_user, @id_reponse, iif);
        }
        public void SupLesreponse(string @id_dossier, string @type_note, string @id_user, string @id_reponse)
        {
            DataManager.SupLesreponse(@id_dossier, @type_note, @id_user, @id_reponse);
        }
        public List<PS_VSCOR_ANA_QUALITATIVEResult> Listreponse(string @id_dossier, string @type_note)
        {
            return DataManager.Listreponse(@id_dossier, @type_note);
        }

        public string Notereponsecalc(string type_note, decimal valeur)
        {
            var oo = "";
            if (valeur == 20)
            {
                //Assah on t'as fait faveur!!! Remercies Muneza...16/08/2017
                var il = DataManager.Notereponsecalc(type_note, 19);
                foreach (var l in il)
                {
                    oo = l.NOTE_AQ;
                }
            }
            else
            {
                var il = DataManager.Notereponsecalc(type_note, valeur);
                foreach (var l in il)
                {
                    oo = l.NOTE_AQ;
                }
            }

            return oo;
        }

        //public void ChangerBilan(string id_dossier, string cODE_CHARGEMENT, decimal aNNEE1, decimal aNNEE2, decimal aNNEE3, int esay)
        //{
        //    DataManager.ChangerBilan(id_dossier, cODE_CHARGEMENT, aNNEE1, aNNEE2, aNNEE3, esay);
        //}
        //public List<PS_ANAFI_LIRE_CHARGEMENTResult> Listbilan(string id_dossier)
        //{,
        //   return DataManager.Listbilan(id_dossier);
        //}
        //public List<PS_ANAFI_LIRE_CHARGEMENTResult> Listbilanvide(string id_dossier)
        //{
        //    return DataManager.Listbilanvide(id_dossier);
        //}

        //public List<PS_ANAFI_LIRE_CHARGEMENTResult> ListbilanSmtvide(string id_dossier)
        //{
        //    return DataManager.ListbilanSmtvide(id_dossier);
        //}

        //public List<PS_ANAFI_LIRE_CHARGEMENTResult> ListbilanSAvide(string id_dossier)
        //{
        //    return DataManager.ListbilanSAvide(id_dossier);
        //}
        //public List<PS_ANAFI_LIRE_CHARGEMENTResult> Listcompteresultat(string id_dossier)
        //{
        //    return DataManager.Listcompteresultat(id_dossier);
        //}
        //public List<PS_ANAFI_LIRE_CHARGEMENTResult> Listcompteresultatvide(string id_dossier)
        //{
        //    return DataManager.Listcompteresultatvide(id_dossier);
        //}
        //public List<PS_ANAFI_LIRE_CHARGEMENTResult> ListcompteresultatSmtvide(string id_dossier)
        //{
        //    return DataManager.ListcompteresultatSmtvide(id_dossier);
        //}

        //public List<PS_ANAFI_LIRE_CHARGEMENTResult> ListcompteresultatSAvide(string id_dossier)
        //{
        //    return DataManager.ListcompteresultatSAvide(id_dossier);
        //}
        //public List<PS_ANAFI_LIRE_TDRResult> ListTDR(string id_dossier)
        //{
        //    return DataManager.ListTDR(id_dossier);
        //}
        //public List<PS_ANAFI_LIRE_TDRResult> ListTDRatio(string id_dossier)
        //{
        //    return DataManager.ListTDRatio(id_dossier);
        //}
        //public List<PS_ANAFI_LIRE_RATIOResult> ListRatioAjoute(string id_dossier)
        //{
        //    return DataManager.ListRatioAjoute(id_dossier);
        //}
        //public List<PS_ANAFI_LIRE_TABLEAUSYNTHETIQUEResult> ListTableauSynthetique(string id_dossier)
        //{
        //    return DataManager.ListTableauSynthetique(id_dossier);
        //}

        //public List<PS_ANAFI_LIRE_BILANGRANDEMASSEResult> ListBilanGrandeMasse(string id_dossier)
        //{
        //    return DataManager.ListBilanGrandeMasse(id_dossier);
        //}

        //public string Voiranneeexercice(string id_dossier)
        //{
        //    return DataManager.Voiranneeexercice(id_dossier);
        //}
        //-INTEGRATION GROUPE
        public List<PS_VSCOR_INTEG_GROUPEResult> ListeChapitreIG()
        {
            return DataManager.ListeChapitreIG().ToList();
        }
        //-INTEGRATION GROUPE-MAGLOIRE
        public List<PS_VSCOR_INTEG_GROUPEResult> ListeFiliale(string groupe_dossier)
        {
            return DataManager.ListeFiliale(groupe_dossier);
        }

        public void MAJListeFiliale(string iddoc, string notess)
        {
            DataManager.MAJListeFiliale(iddoc, notess);
        }

        public void MAJGROUPENOTE(string iddoc, string notess)
        {
            DataManager.MAJGROUPENOTE(iddoc, notess);

        }
        //-RISQUE PAYS
        public List<PS_VSCOR_RISQUE_PAYSResult> ListeChapitreRP()
        {
            return DataManager.ListeChapitreRP().ToList();
        }


        //-NOTES- Magloire
        public List<PS_VSCOR_NOTESResult> ListeCommentaire(int bloc, string id_user, string id_dossier, string id_scoring,
            string id_commentaire, string texte_commentaire, string fichier_commentaire, DateTime date_commentaire)
        {
            return DataManager.ListeCommentaire(bloc, id_user, id_dossier, id_scoring, id_commentaire, texte_commentaire,
                fichier_commentaire, date_commentaire);
        }
        public void traiterCommentaire(int bloc, string id_user, string id_dossier, string id_scoring, string id_commentaire,
            string texte_commentaire, string fichier_commentaire, DateTime date_commentaire)
        {
            DataManager.traiterCommentaire(bloc, id_user, id_dossier, id_scoring, id_commentaire, texte_commentaire,
                fichier_commentaire, date_commentaire);
        }
        //-PROFIL- Magloire
        public List<PS_VSCOR_PROFILResult> ListeProfil(int bloc, string id_profil, string code_banque, string code_profil,
            string libelle_profil, decimal plafond_profil, bool etat_profil)
        {
            return DataManager.ListeProfil(bloc, id_profil, code_banque, code_profil, libelle_profil, plafond_profil,
                etat_profil);
        }
        public void traiterProfil(int bloc, string id_profil, string code_banque, string code_profil,
            string libelle_profil, decimal plafond_profil, bool etat_profil)
        {
            DataManager.traiterProfil(bloc, id_profil, code_banque, code_profil, libelle_profil, plafond_profil,
                etat_profil);
        }
        //-UTILISATEUR- Magloire
        public List<PS_VSCOR_UTILISATEURResult> ListeUser(int bloc, string id_user, string id_profil, string code_agence,
            string nom_user, string prenom_user, string email_user, string login_user, string password_user,
            DateTime date_user, bool statut_user, string code_banque, string nom_agence)
        {
            return DataManager.ListeUser(bloc, id_user, id_profil, code_agence, nom_user, prenom_user, email_user,
                login_user, password_user, date_user, statut_user, code_banque, nom_agence);
        }
        //scoringws
        public void traiterUser(int bloc, string id_user, string id_profil, string code_agence, string nom_user,
                    string prenom_user, string email_user, string login_user, string password_user, DateTime date_user,
                    bool statut_user, string code_banque, string nom_agence, string suphierarchique)
        {
            DataManager.traiterUser(bloc, id_user, id_profil, code_agence, nom_user, prenom_user, email_user,
                login_user, password_user, date_user, statut_user, code_banque, nom_agence, suphierarchique);
        }

        public PS_VSCOR_UTILISATEURResult InfoUser(string id_user)
        {
            return DataManager.InfoUser(id_user);
        }

        //-HISTORIQUE DE NOTATION- Magloire
        public List<PS_VSCOR_HISTORIQUENOTATION_TResult> ListeHistorique(string id_dossier, string id_scoring)
        {
            return DataManager.ListeHistorique(0, id_dossier, id_scoring);
        }

        public List<PS_VSCOR_HISTORIQUENOTATION_TResult> ListeDerniersNotes()
        {
            return DataManager.ListeHistorique(1, "", "");
        }


        // GESTION DES ALERTES  Blaise

        public void InsertAlerte(int nombre_alerte, string couleur_alerte)
        {
            DataManager.InsertAlerte(nombre_alerte, couleur_alerte);
        }

        public List<PS_VSCOR_PARAMATREResult> ListeAlertes()
        {
            return DataManager.ListeAlertes();
        }



        public List<PS_VSCOR_PARAMATREResult> ListeDroit()
        {
            return DataManager.ListeDroit();
        }

        public void InsertDroit_Profil(decimal id_droit_profil, string id_droit, string id_profil, string id_type_droit)
        {
            DataManager.InsertDroit_Profil(id_droit_profil, id_droit, id_profil, id_type_droit);
        }

        public void DeleteDroit_Profil(string id_profil)
        {
            DataManager.DeleteDroit_Profil(id_profil);
        }

        public List<PS_VSCOR_PARAMATREResult> ListeDroit_profil(string id_profil)
        {
            return DataManager.ListeDroit_profil(id_profil);
        }

        public int id_Droit_profil()
        {
            return DataManager.id_Droit_profil();
        }

        public List<PS_VSCOR_PARAMATREResult> Liste_IdDroit_IdProfil(string id_droit, string id_profil)
        {
            return DataManager.Liste_IdDroit_IdProfil(id_droit, id_profil);
        }
        //steph
        protected void verifsession()
        {

            if (DataManager.id_dossier != "" && DataManager.id_dossier != null) Session.Add("id_dossier", DataManager.id_dossier);
            if (DataManager.id_scoring != "" && DataManager.id_dossier != null) Session.Add("id_scoring", DataManager.id_scoring);

        }

        public List<PS_VSCOR_CONTREPARTIEResult> searchGroupe(string libelle)
        {
            return DataManager.searchGroupe(libelle);
        }

        public List<PS_VSCOR_CONTREPARTIEResult> searchStatut()
        {
            return DataManager.searchStatut();
        }

        public List<PS_VSCOR_CONTREPARTIEResult> searchDevise()
        {
            return DataManager.searchDevise();
        }

        public List<PS_VSCOR_CONTREPARTIEResult> BrancheActivite()
        {
            return DataManager.BrancheActivite();
        }
        public List<PS_VSCOR_CONTREPARTIEResult> SecteurActivite(string CodeBranchActiv)
        {
            return DataManager.SecteurActivite(CodeBranchActiv);
        }
        public List<PS_VSCOR_CONTREPARTIEResult> ActiviteBCAO(string CodeBranchActiv)
        {
            return DataManager.ActiviteBCAO(CodeBranchActiv);
        }

        public void UpdateContrepartie(string iduser, string CODE_AGENCE, string MATRICULE, string NOM, string ADRESSE, string VILLE_RESIDENCE, string RCCM, string SEGMENT_CLIENT, DateTime MOIS_ARRETE, string MODE_ANALYSE, string UNITE, string UNITEPRO, string DEVISE, decimal CA, string PAYS, string STATUT, string ACTIVITE_BCEAO, string SECTEUR_ACTIVITE, string GROUPE, String BRANCHE_ACTIV)
        {
            if (SECTEUR_ACTIVITE == "") SECTEUR_ACTIVITE = "1003";
            if (BRANCHE_ACTIV == "") BRANCHE_ACTIV = "B03";
            if (ACTIVITE_BCEAO == "") ACTIVITE_BCEAO = "000 000";
            DataManager.UpdateContrepartie(iduser, CODE_AGENCE, MATRICULE, NOM, ADRESSE, VILLE_RESIDENCE, RCCM, SEGMENT_CLIENT, MOIS_ARRETE, MODE_ANALYSE, UNITE, UNITEPRO, DEVISE, CA, PAYS, STATUT, ACTIVITE_BCEAO, SECTEUR_ACTIVITE, GROUPE, BRANCHE_ACTIV);
        }
        public List<PS_VSCOR_CONTREPARTIEResult> SecteurPAYS(string libelle)
        {
            return DataManager.SecteurPAYS(libelle);
        }

        public void PS_SCOR_SPY(string uTILISATEUR, string eCRAN, string eVENEMENT, string aCTIONS)
        {
            DataManager.PS_SCOR_SPY(uTILISATEUR, eCRAN, eVENEMENT, aCTIONS);
        }
        public List<PS_VSCOR_SPYResult> ListeMouch007()
        {
            return DataManager.LISTE_MOUCHE007();
        }
        public List<PS_VSCOR_SPY_FICHE_DESCRITIVEResult> AfficheMouche007(string idAction)
        {
            return DataManager.AFFICHE_MOUCHE007(idAction);
        }

        // Modifier une note
        public void Modif_note(string id_dossier)
        {
            DataManager.Modif_note(id_dossier);
        }
        //service OSCAR
        //Analyse Financiere saisir liasse
        public void AnafiSaisirLiasse(string annee_detail, DateTime date_cloture, int duree_exercice_mois, string type_anafi_a, string nature_exercice, string certification_comptes, int effectif, string devise, string regime_fiscal, string id_dossier, DateTime date_note_modif, Double tva, string Auto)
        {
            DataManager.AnafiSaisirLiasse(annee_detail, date_cloture, duree_exercice_mois, type_anafi_a, nature_exercice, certification_comptes, effectif, devise, regime_fiscal, id_dossier, date_note_modif, tva, Auto);
        }

        public void AnafiModifLiasse(string annee_detail, DateTime date_cloture, int duree_exercice_mois, string type_anafi_a, string nature_exercice, string certification_comptes, int effectif, string devise, string regime_fiscal, string id_dossier, DateTime date_note_modif, Double tva)
        {
            DataManager.AnafiModifLiasse(annee_detail, date_cloture, duree_exercice_mois, type_anafi_a, nature_exercice, certification_comptes, effectif, devise, regime_fiscal, id_dossier, date_note_modif, tva);
        }


        public void miseAjrDateFinan(string iddossier)
        {
            DataManager.miseAjrDateFinan(iddossier);
        }

        //-FICHE SIGNALETIQUE Liasse- oscar
        public List<PS_VSCOR_LIASSE_FICHESIGNALETIQUEResult> DetailsDossierLiasseContrepartie(int bloc, string id_dossier, string annee_detail)
        {
            return DataManager.DetailsDossierLiasseContrepartie(bloc, id_dossier, annee_detail);
        }
        //  Affichage des liasses blaise
        public List<PS_VSCOR_AFFICHER_LIASSEResult> AnafiAfficheLiasse(int bloc, string id_dossier, string code_poste, string type_Anafi)
        {
            return DataManager.AnafiAfficheLiasse(bloc, id_dossier, code_poste, type_Anafi);
        }
        //Supprimer Liasse Stephane

        public void SuppLiasse(string iddossier, string annee)
        {
            if (annee != "")
                DataManager.SuppLiasse(annee, iddossier);
        }

        public void CalclueTotauxLiasse(string iddossier, string annee)
        {
            DataManager.CalclueTotauxLiasse(iddossier, annee);
        }
        public void RetranscriptionDonnee(string iddossier)
        {
            DataManager.RetranscriptionDonnee(iddossier);
        }

        public void suppHistoNotation(string dossier)
        {
            DataManager.SUPP_HISTORIQUENOTATION(dossier);
        }


        public List<PS_SCOR_LIST_UTILResult> AfficheAdresseMail(string code_banque)
        {
            return DataManager.AfficheAdresseMail(code_banque);
        }

        public List<PS_SCOR_AFFICHE_LOGO_BANKResult> AfficheLogoBank(string code_banque)
        {
            return DataManager.AfficheLogoBank(code_banque);
        }

        public List<PS_VSCOR_VALIDATION_USERNAMEResult> ListeHistoriqueUserName(string id_dossier)
        {
            return DataManager.ListeHistoriqueUserName(0, id_dossier);
        }

        public void UpdateContrepartiemd(string iD_SCORING, string eTCIV_MATRICULE, string eTCIV_NOMREDUIT, string ETCIV_ADRESSE, string eTCIV_VILLE_RESIDENCE,
                string pAYS, string sEGMENT_CLIENT, string cODE_AGENCE, decimal cA, string dEVISE, string rCCM, string sECTEUR_D_ACTIVITE,
                string aCTIVITE_BCEAO, string sTATUT, string mODE_ANALYSE, string uNITE, string IDGOUPE, string IDBRANCH)
        {
            if (sECTEUR_D_ACTIVITE == "") sECTEUR_D_ACTIVITE = "1003";
            if (IDBRANCH == "") IDBRANCH = "B03";
            if (aCTIVITE_BCEAO == "") aCTIVITE_BCEAO = "000 000";
            DataManager.UpdateContrepartiemd(iD_SCORING, eTCIV_MATRICULE, eTCIV_NOMREDUIT, ETCIV_ADRESSE, eTCIV_VILLE_RESIDENCE,
                            pAYS, sEGMENT_CLIENT, cODE_AGENCE, cA, dEVISE, rCCM, sECTEUR_D_ACTIVITE,
                            aCTIVITE_BCEAO, sTATUT, mODE_ANALYSE, uNITE, IDGOUPE, IDBRANCH);
        }

        public List<PS_VSCOR_CONTREPARTIEResult> AjouterFiliale(string Identifiant_Nom)
        {
            return DataManager.AjouterFiliale(Identifiant_Nom);
        }
        public void InsertContrepartie(string iduser, string CODE_AGENCE, string MATRICULE, string NOM, string ADRESSE, string VILLE_RESIDENCE, string RCCM, string SEGMENT_CLIENT, string MODE_ANALYSE, string UNITE, string UNITEPRO, string DEVISE, decimal CA, string PAYS, string STATUT, string ACTIVITE_BCEAO, string SECTEUR_ACTIVITE, string GROUPE, string BRANCHE_ACTIV)
        {
            if (SECTEUR_ACTIVITE == "") SECTEUR_ACTIVITE = "1003";
            if (BRANCHE_ACTIV == "") BRANCHE_ACTIV = "B03";
            if (ACTIVITE_BCEAO == "") ACTIVITE_BCEAO = "000 000";
            DataManager.InsertContrepartie(iduser, CODE_AGENCE, MATRICULE, NOM, ADRESSE, VILLE_RESIDENCE, RCCM, SEGMENT_CLIENT, MODE_ANALYSE, UNITE, UNITEPRO, DEVISE, CA, PAYS, STATUT, ACTIVITE_BCEAO, SECTEUR_ACTIVITE, GROUPE, BRANCHE_ACTIV);
        }

        public void InsertContrepartieGroup(string iduser, string CODE_AGENCE, string MATRICULE, string NOM, string ADRESSE, string VILLE_RESIDENCE, string RCCM, string SEGMENT_CLIENT, string MODE_ANALYSE, string UNITE, string UNITEPRO, string DEVISE, decimal CA, string PAYS, string STATUT, string ACTIVITE_BCEAO, string SECTEUR_ACTIVITE, string GROUPE, string BRANCHE_ACTIV)
        {
            if (SECTEUR_ACTIVITE == "") SECTEUR_ACTIVITE = "1003";
            if (BRANCHE_ACTIV == "") BRANCHE_ACTIV = "B03";
            if (ACTIVITE_BCEAO == "") ACTIVITE_BCEAO = "000 000";
            DataManager.InsertContrepartieGroup(iduser, CODE_AGENCE, MATRICULE, NOM, ADRESSE, VILLE_RESIDENCE, RCCM, SEGMENT_CLIENT, MODE_ANALYSE, UNITE, UNITEPRO, DEVISE, CA, PAYS, STATUT, ACTIVITE_BCEAO, SECTEUR_ACTIVITE, GROUPE, BRANCHE_ACTIV);
        }

        public void InsertContrepartieGroupModif(string iduser, string CODE_AGENCE, string MATRICULE, string NOM, string ADRESSE, string VILLE_RESIDENCE, string RCCM, string SEGMENT_CLIENT, string MODE_ANALYSE, string UNITE, string UNITEPRO, string DEVISE, decimal CA, string PAYS, string STATUT, string ACTIVITE_BCEAO, string SECTEUR_ACTIVITE, string GROUPE, string BRANCHE_ACTIV)
        {
            if (SECTEUR_ACTIVITE == "") SECTEUR_ACTIVITE = "1003";
            if (BRANCHE_ACTIV == "") BRANCHE_ACTIV = "B03";
            if (ACTIVITE_BCEAO == "") ACTIVITE_BCEAO = "000 000";
            DataManager.InsertContrepartieGroupModif(iduser, CODE_AGENCE, MATRICULE, NOM, ADRESSE, VILLE_RESIDENCE, RCCM, SEGMENT_CLIENT, MODE_ANALYSE, UNITE, UNITEPRO, DEVISE, CA, PAYS, STATUT, ACTIVITE_BCEAO, SECTEUR_ACTIVITE, GROUPE, BRANCHE_ACTIV);
        }

        public void InsertContrepartieGroupModif2(string iduser, string CODE_AGENCE, string MATRICULE, string NOM, string ADRESSE, string VILLE_RESIDENCE, string RCCM, string SEGMENT_CLIENT, string MODE_ANALYSE, string UNITE, string UNITEPRO, string DEVISE, decimal CA, string PAYS, string STATUT, string ACTIVITE_BCEAO, string SECTEUR_ACTIVITE, string GROUPE, string BRANCHE_ACTIV)
        {
            if (SECTEUR_ACTIVITE == "") SECTEUR_ACTIVITE = "1003";
            if (BRANCHE_ACTIV == "") BRANCHE_ACTIV = "B03";
            if (ACTIVITE_BCEAO == "") ACTIVITE_BCEAO = "000 000";
            DataManager.InsertContrepartieGroupModif2(iduser, CODE_AGENCE, MATRICULE, NOM, ADRESSE, VILLE_RESIDENCE, RCCM, SEGMENT_CLIENT, MODE_ANALYSE, UNITE, UNITEPRO, DEVISE, CA, PAYS, STATUT, ACTIVITE_BCEAO, SECTEUR_ACTIVITE, GROUPE, BRANCHE_ACTIV);
        }

        public List<PS_VSCOR_FICHESIGNALETIQUEResult> DetailsDossierContrepartieCodeG(string code_banque, string id_scoring)
        {
            return DataManager.DetailsDossierContrepartieCodeG(code_banque, id_scoring);
        }

        public List<PS_VSCOR_FICHESIGNALETIQUEResult> DetailsDossierContrepartieFilialeDeja(string id_scoring)
        {
            return DataManager.DetailsDossierContrepartieFilialeDeja(id_scoring);
        }


        public void InsertContrepartieGroupModifFS(string iduser, string CODE_AGENCE, string MATRICULE, string NOM, string ADRESSE, string VILLE_RESIDENCE, string RCCM, string SEGMENT_CLIENT, string MODE_ANALYSE, string UNITE, string UNITEPRO, string DEVISE, decimal CA, string PAYS, string STATUT, string ACTIVITE_BCEAO, string SECTEUR_ACTIVITE, string GROUPE, string BRANCHE_ACTIV)
        {
            DataManager.InsertContrepartieGroupModifFS(iduser, CODE_AGENCE, MATRICULE, NOM, ADRESSE, VILLE_RESIDENCE, RCCM, SEGMENT_CLIENT, MODE_ANALYSE, UNITE, UNITEPRO, DEVISE, CA, PAYS, STATUT, ACTIVITE_BCEAO, SECTEUR_ACTIVITE, GROUPE, BRANCHE_ACTIV);
        }

        public decimal SelectvalFiliale(string iD_DOSSIER)
        {
            decimal ret = 0;
            var ii = DataManager.SelectvalFiliale(iD_DOSSIER);
            foreach (var i in ii)
            {
                ret = Convert.ToDecimal(i.VALEUR);
            }
            return ret;
        }

        public decimal SelectvaldesFiliales(string gROUPE_DOSSIER)
        {
            decimal ret = 0;
            var ii = DataManager.SelectvaldesFiliales(gROUPE_DOSSIER);
            foreach (var i in ii)
            {
                ret = Convert.ToDecimal(i.VALEUR);
            }
            return ret;
        }
        /// <summary>
        /// //////
        /// </summary>
        /// <param name="pAYS_CODE"></param>
        /// <param name="nOTE_PAYS"></param>
        /// <param name="vALEUR_NOTE_PAYS"></param>
        /// <param name="pERSPECTIVE_PAYS"></param>
        public void INSERT_STDOPAYS(string pAYS_CODE, string nOTE_PAYS, string vALEUR_NOTE_PAYS, string pERSPECTIVE_PAYS)
        {
            DataManager.INSERT_STDOPAYS(pAYS_CODE, nOTE_PAYS, vALEUR_NOTE_PAYS, pERSPECTIVE_PAYS);
        }
        public List<PS_SCOR_SELECTION_STDPO_PAYSResult> LIST_STDOPAYS()
        {
            return DataManager.LIST_STDOPAYS();
        }
        public List<PS_SCOR_SELECTION_STDPO_PAYSResult> LIST_STDOPAYS2()
        {
            return DataManager.LIST_STDOPAYS2();
        }
        public List<PS_SCOR_SELECTION_STDPO_PAYSResult> LIST_STDOPAYS3()
        {
            return DataManager.LIST_STDOPAYS3();
        }
        public List<PS_SCOR_SELECTION_STDPO_PAYSResult> SelectionPaysParNom(string nompays, string structure)
        {
            return DataManager.SelectionPaysParNom(nompays, structure);
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] Save(string inv, string StdNots)
        {
            int errorsNumber = 0;
            int updatedNumber = 0;
            int createdNumber = 0;
            int deletedNumber = 0;
            JavaScriptSerializer js = new JavaScriptSerializer();
            dynamic investissements = js.Deserialize<dynamic>(inv);
            foreach (var investissement in investissements)
            {
                string id_pays_note = ScorCryptage.Decrypt(investissement["pays_code"]);
                string note = investissement["note"] == null ? 0 : investissement["note"];
                string perspective = investissement["perspective"] == null ? 0 : investissement["perspective"];
                var lePays = LIST_STDOPAYS();
                if (StdNots == "STPO")
                {
                    lePays = LIST_STDOPAYS();
                }
                if (StdNots == "MOOD")
                {
                    lePays = LIST_STDOPAYS2();
                }
                if (StdNots == "FITC")
                {
                    lePays = LIST_STDOPAYS3();
                }
                foreach (var element in lePays)
                {
                    INSERT_STDOPAYS(element.PAYS_CODE.ToString(), note, "0", perspective);
                }
            }
            string[] res = new string[1];
            return res;
        }



        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] Connexion_Click(string ReconnexLogin, string ReconnexPassword)
        {
            var code_banque = "";
            var id_user = "";
            var id_profil = "";
            var nom_user = "";
            string[] res = new string[1];
            Scoringws service = new Scoringws();

            if (service.Authentification(ReconnexLogin, ReconnexPassword))
            {
                foreach (var Info in service.InfoUtilisateur(ReconnexLogin, ReconnexPassword))
                {
                    nom_user = Info.PRENOM_USER + "  " + Info.NOM_USER;
                    id_user = Info.ID_USER;
                    id_profil = Info.ID_PROFIL;
                    foreach (var banque in service.InfoBanque(Info.CODE_AGENCE))
                    {
                        code_banque = banque.CODE_BANQUE;
                    }
                }

                Session.Add("code_banque", ScorCryptage.Encrypt(code_banque));
                Session.Add("login", ScorCryptage.Encrypt("1"));
                Session.Add("id_user", id_user);
                Session.Add("id_profil", id_profil);
                Session.Add("nom_user", nom_user);

                res[0] = "true";
                return res;
            }
            else
            {
                //Response.Redirect("~/Scoring/Connexion.aspx");

                res[0] = "~/Scoring/Connexion.aspx";
                return res;

            }
            //string[] res = new string[1];
            return res;
        }

        public List<PS_VSCOR_VALIDATIONNOTEResult> DetailsNotesDossierPoint(int bloc, string id_dossier)
        {
            return DataManager.DetailsNotesDossierPoint(bloc, id_dossier);
        }


        public List<PS_SCOR_ETATBILAN_ACT_CIRCULResult> LIST_PS_SCOR_ETATBILAN_ACT_CIRCUL(string annee, string dossier)
        {
            //ScoringEntityDataContext se = new ScoringEntityDataContext();
            return DataManager.LIST_PS_SCOR_ETATBILAN_ACT_CIRCUL(annee, dossier);
        }

        public List<PS_SCOR_ETATBILAN_AMResult> LIST_PS_SCOR_ETATBILAN_AM(string annee, string dossier)
        {
            return DataManager.LIST_PS_SCOR_ETATBILAN_AM(annee, dossier);
        }

        public List<PS_SCOR_ETATBILAN_CHARGE1Result> LIST_PS_SCOR_ETATBILAN_CHARGE1(string annee, string dossier)
        {
            return DataManager.LIST_PS_SCOR_ETATBILAN_CHARGE1(annee, dossier);
        }

        public List<PS_SCOR_ETATBILAN_CHARGE2Result> LIST_SCOR_ETATBILAN_CHARGE2(string annee, string dossier)
        {
            return DataManager.LIST_SCOR_ETATBILAN_CHARGE2(annee, dossier);
        }

        public List<PS_SCOR_ETATBILAN_PCResult> LIST_PS_SCOR_ETATBILAN_PC(string annee, string dossier)
        {
            return DataManager.LIST_PS_SCOR_ETATBILAN_PC(annee, dossier);
        }

        public List<PS_SCOR_ETATBILAN_PCIRCULResult> LIST_PS_SCOR_ETATBILAN_PCIRCUL(string annee, string dossier)
        {
            return DataManager.LIST_PS_SCOR_ETATBILAN_PCIRCUL(annee, dossier);
        }

        public List<PS_SCOR_ETATBILAN_PRODUIT1Result> LIST_PS_SCOR_ETATBILAN_PRODUIT1(string annee, string dossier)
        {
            return DataManager.LIST_PS_SCOR_ETATBILAN_PRODUIT1(annee, dossier);
        }

        public List<PS_SCOR_ETATBILAN_PRODUIT2Result> LIST_PS_SCOR_ETATBILAN_PRODUIT2(string annee, string dossier)
        {
            return DataManager.LIST_PS_SCOR_ETATBILAN_PRODUIT2(annee, dossier);
        }

        public void ENREGISTREMENT_ENCOURS(string idDossier, string Numero)
        {
            DataManager.ENREGISTREMENT_ENCOURS(idDossier, Numero);
        }

        public List<PS_SELECT_DATE_COMPTABLEResult> SELECT_DATE_COMPTABLE(string ETATDOS, string ID_DOSSIER)
        {
            return DataManager.SELECT_DATE_COMPTABLE(ETATDOS, ID_DOSSIER);
        }

        public List<PS_VSCOR_ENCOURSResult> select_TABLEAU_ENCOURS(string idDossier)
        {
            return DataManager.Liste_ENCOURS(idDossier);
        }
        public List<PS_VSCOR_ENCOURSResult> Liste_ENCOURS_EDITION(string idDossier)
        {
            return DataManager.Liste_ENCOURS_EDITION(idDossier);
        }

        public List<PS_VSCOR_CONTRO_CONTREPARTIEResult> CONTRO_CONTREPARTIE(string raisonSocial)
        {
            return DataManager.CONTRO_CONTREPARTIE(raisonSocial);
        }

        public PS_SCOR_MODELE_NOTATIONResult GetModeleNotation(string code_modele)
        {
            return DataManager.MODELE_NOTATION(0, code_modele, null, null, 0, null, null).FirstOrDefault();
        }

        public List<PS_SCOR_MODELE_NOTATIONResult> ListeModelesNotation()
        {
            return DataManager.MODELE_NOTATION(1, null, null, null, 0, null, null);
        }

        public List<PS_SCOR_MODELE_NOTATIONResult> ListeParametresModeleNotation()
        {
            return DataManager.MODELE_NOTATION(2, null, null, null, 0, null, null);
        }

        public List<PS_SCOR_MODELE_NOTATIONResult> ValeursParametreModeleNotation(int bloc, string code_modele, string code_modele_param = "")
        {
            return DataManager.MODELE_NOTATION(bloc, code_modele, code_modele_param, null, 0, null, null);
        }

        public PS_SCOR_MODELE_NOTATIONResult DeterminerModeleNotation(string segment, decimal ca = 0, string code_activite = null, string code_statut = null)
        {
            return DataManager.MODELE_NOTATION(5, null, null, segment, ca, code_activite, code_statut).FirstOrDefault();
        }

        public void MajContrepartie(string ID_SCORING, string CODE_AGENCE, string MATRICULE, string NOM, string ADRESSE, string VILLE_RESIDENCE, string RCCM, string SEGMENT_CLIENT, DateTime MOIS_ARRETE, string MODE_ANALYSE,
                                       string UNITE, string UNITEPRO, string DEVISE, decimal CA, string PAYS, string STATUT, string ACTIVITE_BCEAO, string SECTEUR_ACTIVITE, string GROUPE, string BRANCHE_ACTIV, string CODE_BANQUE)
        {
            DataManager.CONTREPARTIE(1, ID_SCORING, CODE_AGENCE, MATRICULE, NOM, ADRESSE, VILLE_RESIDENCE, RCCM, SEGMENT_CLIENT, MOIS_ARRETE, MODE_ANALYSE, UNITE, DEVISE, CA, PAYS, STATUT, ACTIVITE_BCEAO, SECTEUR_ACTIVITE, CODE_BANQUE);
            return;
        }

        public void MajCaModeleNotationContrepartie(string ID_SCORING, string MODE_ANALYSE, decimal CA)
        {
            DataManager.MAJ_CA_MODELE_NOTATION_CONTREPARTIE(ID_SCORING, MODE_ANALYSE, CA);
            return;
        }

        public void MajModeleNotationDossier(string ID_DOSSIER, string MODELE_DOSSIER)
        {
            DataManager.MAJ_MODELE_NOTATION_DOSSIER(ID_DOSSIER, MODELE_DOSSIER);
            return;
        }

        public PS_SCOR_DOSSIERResult GetDossier(string ID_DOSSIER)
        {
            return DataManager.DOSSIER(ID_DOSSIER).FirstOrDefault();
        }

        //-LISTE DES DERNIERS NOTES
        internal List<object> ListeDernieresNotes(string id_dossier, string id_scoring)
        {
            throw new NotImplementedException();
        }

        
        
    }
}
