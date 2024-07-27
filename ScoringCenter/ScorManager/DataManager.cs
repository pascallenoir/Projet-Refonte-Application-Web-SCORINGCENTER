using ScoringCenter.Scoring;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScoringCenter.ScorManager
{
    public class DataManager
    {
        /// <summary>
        /// lalalala lalalala 
        /// </summary>
        private static ScoringEntityDataContext se = new ScoringEntityDataContext();
        //-VERIFIER HABILITATION- Stephane Kassa
        public static string id_dossier;
        public static string id_scoring;
        public static string NoteFii;
        public static string RubANAFI;
        public static string verification = "0";    

        public static List<PS_SCOR_LIRE_HABILITATIONResult> VHABILITATION(string id_profil)
        {
         ScoringEntityDataContext sh = new ScoringEntityDataContext();

            var elements = sh.PS_SCOR_LIRE_HABILITATION(0,id_profil).ToList();
            
            return elements;
        }
        //-CONNEXION- Stephane Kassa
        public static List<PS_VSCOR_CONNEXIONResult> Authentification(string login_user, string password_user)
        {
            //ScoringEntityDataContext se = new ScoringEntityDataContext();
            var listqualitatif = se.PS_VSCOR_CONNEXION(0,login_user, ScorCryptage.HashString(password_user),DateTime.UtcNow,"").ToList();
            return listqualitatif;
        }
        public static List<PS_LOG_RECHERCHECONTREPARTIEResult> AuthentificationClient(string login_user, string password_user)
        {
            //ScoringEntityDataContext se = new ScoringEntityDataContext();
            var listqualitatif = se.PS_LOG_RECHERCHECONTREPARTIE(1, login_user, password_user).ToList();
            return listqualitatif;
        }
        public static List<PS_VSCOR_CONNEXIONResult> InfoBanque(string code_agence)
        {
            //ScoringEntityDataContext se = new ScoringEntityDataContext();
            var listqualitatif = se.PS_VSCOR_CONNEXION(1, "", "", DateTime.UtcNow, code_agence).ToList();
            return listqualitatif;
        }

        //Eloi 18/01/2023
        public static PS_VSCOR_AUTREDOSSIERResult InfosBanqueByCode(string code_banque)
        {
            var result = se.PS_VSCOR_AUTREDOSSIER(3, code_banque, "", "", "", DateTime.UtcNow, "").ToList();
            return result.FirstOrDefault();
        }

        //-AUTRE DOSSIER- Stephane Kassa - @it
        public static List<PS_VSCOR_AUTREDOSSIERResult> ListeBanque(string code_banque)
        {
            var elements = se.PS_VSCOR_AUTREDOSSIER(2, code_banque, "", "", "", DateTime.UtcNow, "").ToList();
            return elements;
        }

        public static List<PS_VSCOR_AUTREDOSSIERResult> ListeAgenceBanque(string code_banque)
        {
            //ScoringEntityDataContext se = new ScoringEntityDataContext();
            var listqualitatif = se.PS_VSCOR_AUTREDOSSIER(0,code_banque,"","","",DateTime.UtcNow,"").ToList();
            return listqualitatif;
        }
        public static List<PS_VSCOR_AUTREDOSSIERResult> ListeContrepartie(string code_banque, string code_agence, string id_scoring, string etciv_nomreduit)
        {
            //ScoringEntityDataContext se = new ScoringEntityDataContext();
            var listqualitatif = se.PS_VSCOR_AUTREDOSSIER(1, code_banque, code_agence, id_scoring.Trim(), etciv_nomreduit.Trim(), DateTime.UtcNow,id_scoring.Trim()).ToList();
            return listqualitatif;
        }

        //-FICHE SIGNALETIQUE- Stephane Kassa
        public static List<PS_VSCOR_FICHESIGNALETIQUEResult> DetailsDossierContrepartie(string code_banque, string id_scoring)
        {
            //ScoringEntityDataContext se = new ScoringEntityDataContext();
            var listqualitatif = se.PS_VSCOR_FICHESIGNALETIQUE(1, "",id_scoring ,DateTime.UtcNow).ToList();
            return listqualitatif;
        }


        public static List<PS_VSCOR_VALIDATIONNOTEResult> DetailsNotesDossier(string id_dossier)
        {
            //ScoringEntityDataContext se = new ScoringEntityDataContext();
            var listqualitatif = se.PS_VSCOR_VALIDATIONNOTE(0, id_dossier, DateTime.UtcNow, "", "", "", "").ToList();
            return listqualitatif;
        }

        public static List<PS_VSCOR_VALIDATIONNOTEResult> AfficherCommProposer(string id_dossier)
        {
            //ScoringEntityDataContext se = new ScoringEntityDataContext();
            var AfficherCommProposer = se.PS_VSCOR_VALIDATIONNOTE(5, id_dossier, DateTime.UtcNow, "", "", "", "").ToList();
            return AfficherCommProposer;
        }

        public static List<PS_VSCOR_VALIDATIONNOTEResult> ProposeNotesDossier(string id_dossier, string Note_Prop, string id_user, string commentaire)
        {
            ScoringEntityDataContext so = new ScoringEntityDataContext();
            var listqualitatif = so.PS_VSCOR_VALIDATIONNOTE(1, id_dossier, DateTime.UtcNow, Note_Prop, "", id_user, commentaire).ToList();
            return listqualitatif;
        }
        public static List<PS_VSCOR_VALIDATIONNOTEResult> Adiredexpert(string id_dossier)
        {
            ScoringEntityDataContext so = new ScoringEntityDataContext();
            var listqualitatif = so.PS_VSCOR_VALIDATIONNOTE(8, id_dossier, DateTime.UtcNow, "", "", "", "").ToList();
            return listqualitatif;
        }

        public static List<PS_VSCOR_VALIDATIONNOTEResult> selectAdiredexpert(string id_dossier)
        {
            ScoringEntityDataContext so = new ScoringEntityDataContext();
            var listqualitatif = so.PS_VSCOR_VALIDATIONNOTE(9, id_dossier, DateTime.UtcNow, "", "", "", "").ToList();
            return listqualitatif;
        }
        public static List<PS_VSCOR_VALIDATIONNOTEResult> offAdiredexpert(string id_dossier)
        {
            ScoringEntityDataContext so = new ScoringEntityDataContext();
            var listqualitatif = so.PS_VSCOR_VALIDATIONNOTE(10, id_dossier, DateTime.UtcNow, "", "", "", "").ToList();
            return listqualitatif;
        }
        public static List<PS_VSCOR_VALIDATIONNOTEResult> ValideNotesDossier(string id_dossier, string Note_Val, string id_user, string commentaire)
        {

            ScoringEntityDataContext so = new ScoringEntityDataContext();
            var listqualitatif = so.PS_VSCOR_VALIDATIONNOTE(2, id_dossier, DateTime.UtcNow, "", Note_Val, id_user, commentaire).ToList();
            ScoringEntityDataContext sr = new ScoringEntityDataContext();
            sr.PS_SCOR_NEW_DOSSIER(0, id_dossier.Trim(), DateTime.UtcNow, id_user, Note_Val);
            //sr.PS_SCOR_INITIALISER_PROP_VAL(id_dossier, id_user, DateTime.UtcNow);

            return listqualitatif;
        }
        public static void RejetNotesDossier(string id_dossier, string id_user, string commentaire)
        {
            ScoringEntityDataContext so = new ScoringEntityDataContext();
            so.PS_VSCOR_VALIDATIONNOTE(3, id_dossier, DateTime.UtcNow, "", "", id_user, commentaire);

        }
        public static List<PS_VSCOR_VALIDATIONNOTEResult> listpropver(string id_dossier)
        {
            ScoringEntityDataContext so = new ScoringEntityDataContext();
            var listqualitatif = so.PS_VSCOR_VALIDATIONNOTE(4, id_dossier, DateTime.UtcNow, "", "", "", "").ToList();
            return listqualitatif;
        }




        ////-VALIDATION DE LA NOTE- Stephane Kassa
        //public static List<PS_VSCOR_VALIDATIONNOTEResult> DetailsNotesDossier(string id_dossier)
        //{
        //    //ScoringEntityDataContext se = new ScoringEntityDataContext();
        //    var listqualitatif = se.PS_VSCOR_VALIDATIONNOTE(0, id_dossier, DateTime.UtcNow,"","","").ToList();
        //    return listqualitatif;
        //}
        //public static List<PS_VSCOR_VALIDATIONNOTEResult> ProposeNotesDossier(string id_dossier, string Note_Prop, string id_user)
        //{
        //    ScoringEntityDataContext so = new ScoringEntityDataContext();
        //    var listqualitatif = so.PS_VSCOR_VALIDATIONNOTE(1, id_dossier, DateTime.UtcNow, Note_Prop, "",id_user).ToList();
        //    return listqualitatif;
        //}
        //public static List<PS_VSCOR_VALIDATIONNOTEResult> ValideNotesDossier(string id_dossier, string Note_Val, string id_user)
        //{
            
        //    ScoringEntityDataContext so = new ScoringEntityDataContext();
        //    var listqualitatif = so.PS_VSCOR_VALIDATIONNOTE(2, id_dossier, DateTime.UtcNow, "", Note_Val, id_user).ToList();
        //    ScoringEntityDataContext sr = new ScoringEntityDataContext();
        //    sr.PS_SCOR_NEW_DOSSIER(0, id_dossier, DateTime.UtcNow, id_user);
        //    //sr.PS_SCOR_INITIALISER_PROP_VAL(id_dossier, id_user, DateTime.UtcNow);

        //    return listqualitatif;
        //}
        //public static void RejetNotesDossier(string id_dossier, string id_user)
        //{
        //    ScoringEntityDataContext so = new ScoringEntityDataContext();
        //   so.PS_VSCOR_VALIDATIONNOTE(3, id_dossier, DateTime.UtcNow, "", "", id_user);
            
        //}
        //public static List<PS_VSCOR_VALIDATIONNOTEResult> listpropver(string id_dossier)
        //{
        //    ScoringEntityDataContext so = new ScoringEntityDataContext();
        //    var listqualitatif = so.PS_VSCOR_VALIDATIONNOTE(4, id_dossier, DateTime.UtcNow, "", "", "").ToList();
        //    return listqualitatif;
        //}
        //-TABLEAU_DE_BORD - Stephane Kassa
        public static List<PS_VSCOR_TABLEAU_DE_BORDResult> select_TABLEAU(string code_banque)
        {
            //ScoringEntityDataContext se = new ScoringEntityDataContext();
            var listqualitatif = se.PS_VSCOR_TABLEAU_DE_BORD(0, code_banque).ToList();
            return listqualitatif;
        }

        public static List<PS_VSCOR_TABLEAU_DE_BORDResult> select_Couleur()
        {
            ScoringEntityDataContext s1 = new ScoringEntityDataContext();
            var listqualitatif = s1.PS_VSCOR_TABLEAU_DE_BORD(1,"").ToList();
            return listqualitatif;
        }
        //( !!! Supprimer la partie ANALYSE QUALITATIVE !!!)
        //-ANALYSE GENERALE
        public static List<PS_VSCOR_GENERALEResult> InfoDossier(string id_dossier)
        {
            var element = se.PS_VSCOR_GENERALE(1, id_dossier, "", "","").ToList();
            return element;
        }

        public static List<PS_VSCOR_GENERALEResult> ListeChapitre(string id_modele)
        {
            var elements = se.PS_VSCOR_GENERALE(2, "", id_modele, "", "").ToList();
            return elements;
        }

        public static List<PS_VSCOR_GENERALEResult> ListeQuestion(string id_chapitre)
        {
            var elements = se.PS_VSCOR_GENERALE(3, "", "", id_chapitre, "").ToList();
            return elements;
        }

        public static List<PS_VSCOR_GENERALEResult> ListeReponse(string id_question)
        {
            var elements = se.PS_VSCOR_GENERALE(4, "", "", "", id_question).ToList();
            return elements;
        }
        public static List<PS_VSCOR_GENERALEResult> ListeReponseOperation(string id_question)
        {
            var elements = se.PS_VSCOR_GENERALE(5, "", "", "", id_question).ToList();
            return elements;
        }
        //Calcule QUALITATIVE - Stephane
        public static decimal calculerNoteQuest(int valeur_recu, string id_notation, string id_modele)
        {
            decimal noteV = 0;
            //ScoringEntityDataContext se = new ScoringEntityDataContext();
            noteV = Convert.ToDecimal(se.FN_SCOR_CALCULER_NOTE_QUESTIONNAIRE(valeur_recu, id_notation, id_modele));
            return noteV;
        }
        public static void Insertreponse(string @id_dossier, string @type_note, string @id_user, string @id_reponse, string iif)
        {
            ScoringEntityDataContext so = new ScoringEntityDataContext();
            so.PS_VSCOR_ANA_QUALITATIVE(5, @id_dossier, "", "", "", @type_note, @id_user, @id_reponse, DateTime.UtcNow, 0, iif);
            
        }
        public static void SupLesreponse(string @id_dossier, string @type_note, string @id_user, string @id_reponse)
        {
            ScoringEntityDataContext so = new ScoringEntityDataContext();
            so.PS_VSCOR_ANA_QUALITATIVE(7, @id_dossier, "", "", "", @type_note, @id_user, @id_reponse, DateTime.UtcNow, 0, "2");

        }
        public static List<PS_VSCOR_ANA_QUALITATIVEResult > Listreponse(string @id_dossier, string @type_note)
        {
            var elements = se.PS_VSCOR_ANA_QUALITATIVE(6, @id_dossier, "", "", "", @type_note, "", "", DateTime.UtcNow, 0, "2").ToList();
            return elements;
        }
        public static List<PS_VSCOR_ANA_QUALITATIVEResult> Notereponsecalc(string type_note, decimal valeur)
        {
            var elements = se.PS_VSCOR_ANA_QUALITATIVE(8, "", "", "", "", @type_note, "", "", DateTime.UtcNow, valeur, "2").ToList();
            return elements;
        }
        
        //public static void ChangerBilan(string id_dossier, string cODE_CHARGEMENT, decimal aNNEE1, decimal aNNEE2, decimal aNNEE3, int esay)
        //{ 
        //    se.PS_ANAFI_CHANGERBILAN(0,id_dossier,DateTime.UtcNow.Date.Year.ToString(),cODE_CHARGEMENT,aNNEE1,aNNEE2,aNNEE3,esay);
        //    ScoringEntityDataContext si = new ScoringEntityDataContext();
        //   // si.PS_ANAFI_CHARGEMENT_BILANGRANDEMASSE(id_dossier);

        //    var testbil = Listbilan(id_dossier).ToList();
        //    if (testbil.Count == 26)
        //    {
        //        si.PS_ANAFI_CHARGEMENT_BILANGRANDEMASSE(id_dossier);
        //        var testCR = Listcompteresultat(id_dossier).ToList();
        //        if (testCR.Count != 0)
        //        {
        //            ScoringEntityDataContext sa = new ScoringEntityDataContext();
        //            sa.PS_ANAFI_CHARGEMENT_TDR(id_dossier);
        //            ScoringEntityDataContext sz = new ScoringEntityDataContext();
        //            sz.PS_ANAFI_CHARGEMENT_RATIO(id_dossier);
        //            ScoringEntityDataContext sy = new ScoringEntityDataContext();
        //            sy.PS_ANAFI_CALCUL_NOTE(id_dossier);
        //        }
        //    }
        //}
        //public static List<PS_ANAFI_LIRE_CHARGEMENTResult> Listbilan(string id_dossier)
        //{
        //    var elements = se.PS_ANAFI_LIRE_CHARGEMENT(0, id_dossier).ToList();
        //    return elements;
        //}
        //public static List<PS_ANAFI_LIRE_CHARGEMENTResult> Listbilanvide(string id_dossier)
        //{
        //    var elements = se.PS_ANAFI_LIRE_CHARGEMENT(4, id_dossier).ToList();
        //    return elements;
        //}
        //public static List<PS_ANAFI_LIRE_CHARGEMENTResult> ListbilanSmtvide(string id_dossier)
        //{
        //    var elements = se.PS_ANAFI_LIRE_CHARGEMENT(5, id_dossier).ToList();
        //    return elements;
        //}
        //public static List<PS_ANAFI_LIRE_CHARGEMENTResult> ListbilanSAvide(string id_dossier)
        //{
        //    var elements = se.PS_ANAFI_LIRE_CHARGEMENT(7, id_dossier).ToList();
        //    return elements;
        //}
       
        //public static List<PS_ANAFI_LIRE_CHARGEMENTResult> Listcompteresultat(string id_dossier)
        //{
        //    var elements = se.PS_ANAFI_LIRE_CHARGEMENT(1, id_dossier).ToList();
        //    return elements;
        //}
        //public static List<PS_ANAFI_LIRE_CHARGEMENTResult> Listcompteresultatvide(string id_dossier)
        //{
        //    var elements = se.PS_ANAFI_LIRE_CHARGEMENT(3, id_dossier).ToList();
        //    return elements;
        //}
        //public static List<PS_ANAFI_LIRE_CHARGEMENTResult> ListcompteresultatSmtvide(string id_dossier)
        //{
        //    var elements = se.PS_ANAFI_LIRE_CHARGEMENT(6, id_dossier).ToList();
        //    return elements;
        //}
        //public static List<PS_ANAFI_LIRE_CHARGEMENTResult> ListcompteresultatSAvide(string id_dossier)
        //{
        //    var elements = se.PS_ANAFI_LIRE_CHARGEMENT(8, id_dossier).ToList();
        //    return elements;
        //}
        //public static List<PS_ANAFI_LIRE_TDRResult> ListTDR(string id_dossier)
        //{
        //    var elements = se.PS_ANAFI_LIRE_TDR(0, id_dossier).ToList();
        //    return elements;
        //}
        //public static List<PS_ANAFI_LIRE_TDRResult> ListTDRatio(string id_dossier)
        //{
        //    var elements = se.PS_ANAFI_LIRE_TDR(1, id_dossier).ToList();
        //    return elements;
        //}

        //public static List<PS_ANAFI_LIRE_RATIOResult> ListRatioAjoute(string id_dossier)
        //{
        //    var elements = se.PS_ANAFI_LIRE_RATIO(0, id_dossier).ToList();
        //    return elements;
        //}

        //public static List<PS_ANAFI_LIRE_TABLEAUSYNTHETIQUEResult> ListTableauSynthetique(string id_dossier)
        //{
        //    var elements = se.PS_ANAFI_LIRE_TABLEAUSYNTHETIQUE(0, id_dossier).ToList();
        //    return elements;
        //}
        //public static List<PS_ANAFI_LIRE_BILANGRANDEMASSEResult> ListBilanGrandeMasse(string id_dossier)
        //{
        //    var elements = se.PS_ANAFI_LIRE_BILANGRANDEMASSE(0, id_dossier).ToList();
        //    return elements;
        //}

        //public static string Voiranneeexercice(string id_dossier)
        //{
        //    var elements = se.PS_ANAFI_LIRE_CHARGEMENT(2, id_dossier).ToList();
        //    var ret="";
        //    if (elements.Count != 0)
        //    {
        //        foreach (var annees in elements)
        //        {
        //            ret = annees.MyANNEE31;
        //        }
        //    }
            
        //    return ret;
        //}

        //-INTEGRATION GROUPE
        public static List<PS_VSCOR_INTEG_GROUPEResult> ListeChapitreIG()
        {
            var elements = se.PS_VSCOR_INTEG_GROUPE(1, "", "", "", DateTime.Now, "").ToList();
            return elements;
        }
        //-INTEGRATION GROUPE-MAGLOIRE
        public static List<PS_VSCOR_INTEG_GROUPEResult> ListeFiliale(string groupe_dossier)
        {
            var elements = se.PS_VSCOR_INTEG_GROUPE(2, "", "", "", DateTime.Now, groupe_dossier).ToList();
            return elements;
        }

        public static void MAJListeFiliale(string iddoc,string groupe_dossier)
        {
           se.PS_VSCOR_INTEG_GROUPE(3, iddoc, "", "", DateTime.Now, groupe_dossier);
            
        }

        public static void MAJGROUPENOTE(string iddoc, string groupe_dossier)
        {
            se.PS_VSCOR_INTEG_GROUPE(4, iddoc, "", "", DateTime.Now, groupe_dossier);

        }

        //-RISQUE PAYS
        public static List<PS_VSCOR_RISQUE_PAYSResult> ListeChapitreRP()
        {
            var elements = se.PS_VSCOR_RISQUE_PAYS(1, "", "", "").ToList();
            return elements;
        }

        //-NOTES- Magloire
        public static List<PS_VSCOR_NOTESResult> ListeCommentaire(int bloc, string id_user, string id_dossier, string id_scoring,
            string id_commentaire, string texte_commentaire, string fichier_commentaire, DateTime date_commentaire)
        {
            ScoringEntityDataContext se = new ScoringEntityDataContext();
            var listCommentaire = se.PS_VSCOR_NOTES(bloc, id_user, id_dossier, id_scoring, id_commentaire, texte_commentaire,
                fichier_commentaire, date_commentaire).ToList();
            return listCommentaire;
        }
        public static void traiterCommentaire(int bloc, string id_user, string id_dossier, string id_scoring,
            string id_commentaire, string texte_commentaire, string fichier_commentaire, DateTime date_commentaire)
        {
            ScoringEntityDataContext se = new ScoringEntityDataContext();
            se.PS_VSCOR_NOTES(bloc, id_user, id_dossier, id_scoring, id_commentaire, texte_commentaire, fichier_commentaire,
                date_commentaire);
        }
        //-PROFIL- Magloire
        public static List<PS_VSCOR_PROFILResult> ListeProfil(int bloc, string id_profil, string code_banque, string code_profil,
            string libelle_profil, decimal plafond_profil, bool etat_profil)
        {
            ScoringEntityDataContext se = new ScoringEntityDataContext();
            var listProfil = se.PS_VSCOR_PROFIL(bloc, id_profil, code_banque, code_profil, libelle_profil, plafond_profil,
                etat_profil).ToList();
            return listProfil;
        }
        public static void traiterProfil(int bloc, string id_profil, string code_banque, string code_profil,
            string libelle_profil, decimal plafond_profil, bool etat_profil)
        {
            ScoringEntityDataContext se = new ScoringEntityDataContext();
            se.PS_VSCOR_PROFIL(bloc, id_profil, code_banque, code_profil, libelle_profil, plafond_profil, etat_profil);
        }
        //-UTILISATEUR- Magloire
        public static List<PS_VSCOR_UTILISATEURResult> ListeUser(int bloc, string id_user, string id_profil, string code_agence,
            string nom_user, string prenom_user, string email_user, string login_user, string password_user,
            DateTime date_user, bool statut_user, string code_banque, string nom_agence)
        {
            ScoringEntityDataContext se = new ScoringEntityDataContext();
            var VlistUser = se.PS_VSCOR_UTILISATEUR(bloc, id_user, id_profil, code_agence, nom_user, prenom_user, email_user,
                login_user, password_user, date_user, statut_user, code_banque, nom_agence, "");
               var listUser = VlistUser!=null? VlistUser.ToList():null;
            return listUser;
        }
        //datamanager
        public static void traiterUser(int bloc, string id_user, string id_profil, string code_agence, string nom_user,
            string prenom_user, string email_user, string login_user, string password_user, DateTime date_user,
            bool statut_user, string code_banque, string nom_agence, string suphierarchique)
        {

            ScoringEntityDataContext se = new ScoringEntityDataContext();
            se.PS_VSCOR_UTILISATEUR(bloc, id_user, id_profil, code_agence, nom_user, prenom_user, email_user,
                login_user, password_user == "" ? "" : ScorCryptage.HashString(password_user), date_user, statut_user, code_banque, nom_agence, suphierarchique);
        }
        //public static void traiterUser(int bloc, string id_user, string id_profil, string code_agence, string nom_user,
        //    string prenom_user, string email_user, string login_user, string password_user, DateTime date_user,
        //    bool statut_user, string code_banque, string nom_agence)
        //{
            
        //    ScoringEntityDataContext se = new ScoringEntityDataContext();
        //    se.PS_VSCOR_UTILISATEUR(bloc, id_user, id_profil, code_agence, nom_user, prenom_user, email_user,
        //        login_user, ScorCryptage.HashString(password_user), date_user, statut_user, code_banque, nom_agence);
        //}

        public static PS_VSCOR_UTILISATEURResult InfoUser(string id_user)
        {
            ScoringEntityDataContext se = new ScoringEntityDataContext();
            return se.PS_VSCOR_UTILISATEUR(10, id_user, "", "", "", "", "", "", "", DateTime.UtcNow, true, "", "", "").SingleOrDefault();
        }

       //HISTORIQUE DE NOTATION- Magloire
        public static List<PS_VSCOR_HISTORIQUENOTATION_TResult> ListeHistorique(int bloc,  string id_dossier,string id_scoring)
        {
            ScoringEntityDataContext se = new ScoringEntityDataContext();
            var listUser = se.PS_VSCOR_HISTORIQUENOTATION_T( bloc,   id_dossier, id_scoring).ToList();
            return listUser;
        }

        // GESTION DES ALERTES  Blaise

        public static void InsertAlerte(int nombre_alerte, string couleur_alerte)
        {
            ScoringEntityDataContext so = new ScoringEntityDataContext();
            so.PS_VSCOR_PARAMATRE(0, nombre_alerte, couleur_alerte, "", 0, "", "", "", DateTime.UtcNow);
        }

        public static List<PS_VSCOR_PARAMATREResult> ListeAlertes()
        {
            ScoringEntityDataContext so = new ScoringEntityDataContext();
            var listAlert = so.PS_VSCOR_PARAMATRE(1, 0, "", "", 0, "", "", "", DateTime.UtcNow).ToList();
            return listAlert;
        }

        public static List<PS_VSCOR_PARAMATREResult> ListeDroit()
        {
            ScoringEntityDataContext so = new ScoringEntityDataContext();
            var ListeDroit = so.PS_VSCOR_PARAMATRE(2, 0, "", "", 0, "", "", "", DateTime.UtcNow).ToList();
            return ListeDroit;
        }

        public static void InsertDroit_Profil(decimal id_droit_profil, string id_droit, string id_profil, string id_type_droit)
        {
            ScoringEntityDataContext so = new ScoringEntityDataContext();
            so.PS_VSCOR_PARAMATRE(3, 0, "", "", id_droit_profil, id_droit, id_profil, id_type_droit, DateTime.UtcNow);
        }

        public static void DeleteDroit_Profil(string id_profil)
        {
            ScoringEntityDataContext so = new ScoringEntityDataContext();
            so.PS_VSCOR_PARAMATRE(4, 0, "", "", 0, "", id_profil, "", DateTime.UtcNow);
        }

        public static List<PS_VSCOR_PARAMATREResult> ListeDroit_profil(string id_profil)
        {
            ScoringEntityDataContext so = new ScoringEntityDataContext();
            var ListeDroit_profil = so.PS_VSCOR_PARAMATRE(5, 0, "", "", 0, "", id_profil, "", DateTime.UtcNow).ToList();
            return ListeDroit_profil;
        }

        //public static List<PS_VSCOR_PARAMATREResult> id_Droit_profil()
        //{
        //    ScoringEntityDataContext so = new ScoringEntityDataContext();
        //    var id_Droit_profil = so.PS_VSCOR_PARAMATRE(6, 0, "", "", "", "", "", "", DateTime.UtcNow).ToList();
        //    return id_Droit_profil;
        //}
        public static int  id_Droit_profil()
        {
            ScoringEntityDataContext so = new ScoringEntityDataContext();
            var t = 0;
            var id_Droit_profil = so.PS_VSCOR_PARAMATRE(6, 0, "", "", 0, "", "", "", DateTime.UtcNow).ToList();
            if (id_Droit_profil.Count != 0)
            {
                foreach (var il in id_Droit_profil)
                {
                    t = Convert.ToInt32(il.ID_DROIT_PROFIL);
                }
            }
            
            return t;
        }

        public static List<PS_VSCOR_PARAMATREResult> Liste_IdDroit_IdProfil(string id_droit, string id_profil)
        {
            ScoringEntityDataContext so = new ScoringEntityDataContext();
            var Liste_IdDroit_IdProfil = so.PS_VSCOR_PARAMATRE(8, 0, "", "", 0, id_droit, id_profil, "", DateTime.UtcNow).ToList();
            return Liste_IdDroit_IdProfil;
        }
        // MUGIRANEZA OSCAR 07-07-2017
        //public static void ChargerFichierEncours(string emplacement_Fichier)
        //{
        //    ScoringEntityDataContext si = new ScoringEntityDataContext();
        //    si.PS_SCOR_CHARGEMENT_ENCOURS(0, emplacement_Fichier);
        //}

        //public static List<PS_VSCOR_ENCOURSResult> Liste_ENCOURS()
        //{
        //    ScoringEntityDataContext so = new ScoringEntityDataContext();
        //    var Liste_encours = so.PS_VSCOR_ENCOURS(0,"").ToList();
        //    return Liste_encours;
        //}

        ////////BLAISE  ecran contrepartie

        //////public static List<PS_VSCOR_CONTREPARTIEResult> searchStatut(string libelle)
        //////{
        //////    ScoringEntityDataContext si = new ScoringEntityDataContext();
        //////    var Liste_statut = si.PS_VSCOR_CONTREPARTIE(1, libelle, "", "", "").ToList();
        //////    return Liste_statut;
        //////}
        //////public static List<PS_VSCOR_CONTREPARTIEResult> searchActivite(string libelle)
        //////{
        //////    ScoringEntityDataContext si = new ScoringEntityDataContext();
        //////    var Liste_Activite = si.PS_VSCOR_CONTREPARTIE(2, "", libelle, "", "").ToList();
        //////    return Liste_Activite;
        //////}
        //////public static List<PS_VSCOR_CONTREPARTIEResult> searchMatricule(string libelle)
        //////{
        //////    ScoringEntityDataContext si = new ScoringEntityDataContext();
        //////    var Liste_Matricule = si.PS_VSCOR_CONTREPARTIE(3, "", "", "", libelle).ToList();
        //////    return Liste_Matricule;
        //////}
        //////public static List<PS_VSCOR_CONTREPARTIEResult> searchGroupe(string libelle)
        //////{
        //////    ScoringEntityDataContext si = new ScoringEntityDataContext();
        //////    var Liste_Groupe = si.PS_VSCOR_CONTREPARTIE(5, "", "", "", libelle).ToList();
        //////    return Liste_Groupe;
        //////}
        //////public static List<PS_VSCOR_CONTREPARTIEResult> searchContrepartie(string libelle)
        //////{
        //////    ScoringEntityDataContext si = new ScoringEntityDataContext();
        //////    var Liste_Contrepartie = si.PS_VSCOR_CONTREPARTIE(4, "", "", libelle, "").ToList();
        //////    return Liste_Contrepartie;
        //////}

        //////public static void ChargerFichierContrepartie(string emplacement_Fichier, string iduser)
        //////{
        //////    ScoringEntityDataContext si = new ScoringEntityDataContext();
        //////    si.PS_SCOR_CHARGEMENT_CONTREPARTIE(0, emplacement_Fichier, DateTime.UtcNow, iduser);
        //////}

        //////public static void InsertContrepartie(string iduser, string CODE_AGENCE, string MATRICULE, string NOM, string ADRESSE, string VILLE_RESIDENCE, string RCCM, string SEGMENT_CLIENT, DateTime MOIS_ARRETE, string MODE_ANALYSE, string UNITE, string DEVISE, decimal CA, string PAYS, string STATUT, string ACTIVITE_BCEAO, string SECTEUR_ACTIVITE, string GROUPE)
        //////{
        //////    ScoringEntityDataContext si = new ScoringEntityDataContext();
        //////    si.PS_VSCOR_CONTREPARTIE_INS(0, DateTime.UtcNow, iduser, CODE_AGENCE, MATRICULE, NOM, ADRESSE, VILLE_RESIDENCE, RCCM, SEGMENT_CLIENT, MOIS_ARRETE, MODE_ANALYSE, UNITE, DEVISE, CA, PAYS, STATUT, ACTIVITE_BCEAO, SECTEUR_ACTIVITE, GROUPE);
        //////}

        //////BLAISE  ecran contrepartie

        
        public static List<PS_VSCOR_CONTREPARTIEResult> searchStatut()
        {
            ScoringEntityDataContext si = new ScoringEntityDataContext();
            var Liste_statut = si.PS_VSCOR_CONTREPARTIE(1, "", "", "", "").ToList();
            return Liste_statut;
        }

        public static List<PS_VSCOR_CONTREPARTIEResult> searchDevise()
        {
            ScoringEntityDataContext si = new ScoringEntityDataContext();
            var Liste_Devise = si.PS_VSCOR_CONTREPARTIE(10, "", "", "", "").ToList();
            return Liste_Devise;
        }

        public static List<PS_VSCOR_CONTREPARTIEResult> BrancheActivite()
        {
            ScoringEntityDataContext si = new ScoringEntityDataContext();
            var BrancheActiviteList = si.PS_VSCOR_CONTREPARTIE(2, "", "", "", "").ToList();
            return BrancheActiviteList;
        }
        public static List<PS_VSCOR_CONTREPARTIEResult> SecteurActivite(string CodeBranchActiv)
        {
            ScoringEntityDataContext si = new ScoringEntityDataContext();
            var SecteurActiviteList = si.PS_VSCOR_CONTREPARTIE(12, "", "", CodeBranchActiv, "").ToList();
            return SecteurActiviteList;
        }

        public static List<PS_VSCOR_CONTREPARTIEResult> ActiviteBCAO(string Libelle)
        {
            ScoringEntityDataContext si = new ScoringEntityDataContext();
            var ActiviteBECAOList = si.PS_VSCOR_CONTREPARTIE(9, "", Libelle, "", "").ToList();
            return ActiviteBECAOList;
        }

        public static List<PS_VSCOR_CONTREPARTIEResult> searchGroupe(string libille)
        {
            ScoringEntityDataContext si = new ScoringEntityDataContext();
            var Liste_Groupe = si.PS_VSCOR_CONTREPARTIE(5, "", libille, "", "").ToList();
            return Liste_Groupe;
        }

        //public static void InsertContrepartie(string iduser, string CODE_AGENCE, string MATRICULE, string NOM, string ADRESSE, string VILLE_RESIDENCE, string RCCM, string SEGMENT_CLIENT, string MODE_ANALYSE, string UNITE, string UNITEPRO, string DEVISE, decimal CA, string PAYS, string STATUT, string ACTIVITE_BCEAO, string SECTEUR_ACTIVITE, string GROUPE, string BRANCHE_ACTIV)
        //{
        //    ScoringEntityDataContext si = new ScoringEntityDataContext();
        //    si.PS_VSCOR_CONTREPARTIE_INS(0, DateTime.UtcNow, iduser, CODE_AGENCE, MATRICULE, NOM, ADRESSE, VILLE_RESIDENCE, RCCM, SEGMENT_CLIENT, DateTime.UtcNow, MODE_ANALYSE, UNITE, UNITEPRO, DEVISE, CA, PAYS, STATUT, ACTIVITE_BCEAO, SECTEUR_ACTIVITE, GROUPE, BRANCHE_ACTIV);
        //}

        //public static void UpdateContrepartie(string iduser, string CODE_AGENCE, string MATRICULE, string NOM, string ADRESSE, string VILLE_RESIDENCE, string RCCM, string SEGMENT_CLIENT, DateTime MOIS_ARRETE, string MODE_ANALYSE, string UNITE, string UNITEPRO, string DEVISE, decimal CA, string PAYS, string STATUT, string ACTIVITE_BCEAO, string SECTEUR_ACTIVITE, string GROUPE, string BRANCHE_ACTIV)
        //{
        //    ScoringEntityDataContext si = new ScoringEntityDataContext();
        //    si.PS_VSCOR_CONTREPARTIE_INS(1, DateTime.UtcNow, iduser, CODE_AGENCE, MATRICULE, NOM, ADRESSE, VILLE_RESIDENCE, RCCM, SEGMENT_CLIENT, MOIS_ARRETE, MODE_ANALYSE, UNITE, UNITEPRO, DEVISE, CA, PAYS, STATUT, ACTIVITE_BCEAO, SECTEUR_ACTIVITE, GROUPE, BRANCHE_ACTIV);
        //}
        public static List<PS_VSCOR_CONTREPARTIEResult> SecteurPAYS(string libelle)
        {
            ScoringEntityDataContext si = new ScoringEntityDataContext();
            var SecteurPAYSList = si.PS_VSCOR_CONTREPARTIE(11, "", libelle, "", "").ToList();
            return SecteurPAYSList;
        }

        public static List<PS_VSCOR_ENCOURSResult> Liste_ENCOURS_id(string idScoring)
        {
            ScoringEntityDataContext so = new ScoringEntityDataContext();
            var Liste_encours = so.PS_VSCOR_ENCOURS(1, idScoring,"").ToList();
            return Liste_encours;
        }
        public static void PS_SCOR_SPY(string uTILISATEUR, string eCRAN, string eVENEMENT, string aCTIONS)
        {
            ScoringEntityDataContext so = new ScoringEntityDataContext();
            so.PS_SCOR_SPY(DateTime.Now, uTILISATEUR, eCRAN, ScorCryptage.Encrypt(eVENEMENT), aCTIONS, "ASP:OBJECT");
        }

        public static List<PS_VSCOR_SPYResult> LISTE_MOUCHE007()
        {
            ScoringEntityDataContext so = new ScoringEntityDataContext();
            var Liste_007 = so.PS_VSCOR_SPY().ToList();
            return Liste_007;
        }
        public static List<PS_VSCOR_SPY_FICHE_DESCRITIVEResult> AFFICHE_MOUCHE007(string idAction)
        {
            ScoringEntityDataContext so = new ScoringEntityDataContext();
            var Liste_007 = so.PS_VSCOR_SPY_FICHE_DESCRITIVE(idAction).ToList();
            return Liste_007;
        }
        //DATAMANAGER
        //MUGIRANEZA OSCAR 07-07-2017

        //public static void UpdateContrepartiemd(string ID_SCORING, string ETCIV_MATRICULE, string ETCIV_NOMREDUIT, string ETCIV_ADRESSE, string ETCIV_VILLE_RESIDENCE,
        //string PAYS, string SEGMENT_CLIENT, string CODE_AGENCE, decimal CA, string DEVISE, string RCCM, string SECTEUR_D_ACTIVITE,
        //string ACTIVITE_BCEAO, string STATUT, string MODE_ANALYSE, string UNITE)
        //{
        //    ScoringEntityDataContext si = new ScoringEntityDataContext();
        //    si.PS_VSCOR_CONTREPARTIE_MOD(1, ID_SCORING, ETCIV_MATRICULE, ETCIV_NOMREDUIT, ETCIV_ADRESSE, ETCIV_VILLE_RESIDENCE,
        //                    PAYS, SEGMENT_CLIENT, CODE_AGENCE, CA, DEVISE, RCCM, SECTEUR_D_ACTIVITE,
        //                    ACTIVITE_BCEAO, STATUT, MODE_ANALYSE, UNITE);
        //}

        //public static void UpdateContrepartiemd(string ID_SCORING, string ETCIV_MATRICULE, string ETCIV_NOMREDUIT, string ETCIV_ADRESSE, string ETCIV_VILLE_RESIDENCE,
        //string PAYS, string SEGMENT_CLIENT, string CODE_AGENCE, decimal CA, string DEVISE, string RCCM, string SECTEUR_D_ACTIVITE,
        //string ACTIVITE_BCEAO, string STATUT, string MODE_ANALYSE, string UNITE,string IDGOUPE)
        //{
        //    ScoringEntityDataContext si = new ScoringEntityDataContext();
        //    si.PS_VSCOR_CONTREPARTIE_MOD(1, ID_SCORING, ETCIV_MATRICULE, ETCIV_NOMREDUIT, ETCIV_ADRESSE, ETCIV_VILLE_RESIDENCE,
        //                    PAYS, SEGMENT_CLIENT, CODE_AGENCE, CA, DEVISE, RCCM, SECTEUR_D_ACTIVITE,
        //                    ACTIVITE_BCEAO, STATUT, MODE_ANALYSE, UNITE,IDGOUPE);
        //    si.PS_SCOR_TRIG_INS_CONTREPARTIE(ID_SCORING, ETCIV_MATRICULE, ETCIV_NOMREDUIT, CA, ACTIVITE_BCEAO, SECTEUR_D_ACTIVITE);
        //}


        public static void UpdateContrepartiemd(string ID_SCORING, string ETCIV_MATRICULE, string ETCIV_NOMREDUIT, string ETCIV_ADRESSE, string ETCIV_VILLE_RESIDENCE,
         string PAYS, string SEGMENT_CLIENT, string CODE_AGENCE, decimal CA, string DEVISE, string RCCM, string SECTEUR_D_ACTIVITE,
        string ACTIVITE_BCEAO, string STATUT, string MODE_ANALYSE, string UNITE, string IDGOUPE, string IDBRANCH)
        {
            ScoringEntityDataContext si = new ScoringEntityDataContext();
            si.PS_VSCOR_CONTREPARTIE_MOD(1, ID_SCORING, ETCIV_MATRICULE, ETCIV_NOMREDUIT, ETCIV_ADRESSE, ETCIV_VILLE_RESIDENCE,
                            PAYS, SEGMENT_CLIENT, CODE_AGENCE, CA, DEVISE, RCCM, SECTEUR_D_ACTIVITE,
                            ACTIVITE_BCEAO, STATUT, MODE_ANALYSE, UNITE, IDGOUPE, IDBRANCH);
            si.PS_SCOR_TRIG_INS_CONTREPARTIE(ID_SCORING, ETCIV_MATRICULE, ETCIV_NOMREDUIT, CA, ACTIVITE_BCEAO, SECTEUR_D_ACTIVITE);
        }

        // Modifier une note
        public static void Modif_note(string id_dossier)
        {
            ScoringEntityDataContext si = new ScoringEntityDataContext();
            si.PS_SCOR_MODIFIER_NOTE(0, id_dossier);
        }

        //manager OSCAR
        public static List<PS_VSCOR_LIASSE_FICHESIGNALETIQUEResult> DetailsDossierLiasseContrepartie(int bloc, string id_dossier, string annee_detail)
        {
            //ScoringEntityDataContext se = new ScoringEntityDataContext();
            var listqualitatif = se.PS_VSCOR_LIASSE_FICHESIGNALETIQUE(bloc, id_dossier, annee_detail).ToList();
            return listqualitatif;
        }

        public static void AnafiSaisirLiasse(string annee_detail, DateTime date_cloture, int duree_exercice_mois, string type_anafi_a, string nature_exercice, string certification_comptes, int effectif, string devise, string regime_fiscal, string id_dossier, DateTime date_note_modif, Double tva, string Auto)
        {
            ScoringEntityDataContext si = new ScoringEntityDataContext();
            si.PS_VSCOR_SAISIR_LIASSE(0, annee_detail, date_cloture, duree_exercice_mois, type_anafi_a, nature_exercice, certification_comptes, effectif, devise, regime_fiscal, id_dossier, date_note_modif, tva, Auto);
            ScoringEntityDataContext s2 = new ScoringEntityDataContext();
            s2.PS_SCOR_ANAFI_MAJ_DATE_FINAN(id_dossier,DateTime.UtcNow);
        }
        public static void AnafiModifLiasse(string annee_detail, DateTime date_cloture, int duree_exercice_mois, string type_anafi_a, string nature_exercice, string certification_comptes, int effectif, string devise, string regime_fiscal, string id_dossier, DateTime date_note_modif, Double tva)
        {
            ScoringEntityDataContext si = new ScoringEntityDataContext();
            si.PS_VSCOR_SAISIR_LIASSE(2, annee_detail, date_cloture, duree_exercice_mois, type_anafi_a, nature_exercice, certification_comptes, effectif, devise, regime_fiscal, id_dossier, date_note_modif, tva,"");
            //ScoringEntityDataContext s2 = new ScoringEntityDataContext();
            //s2.PS_SCOR_ANAFI_MAJ_DATE_FINAN(id_dossier, DateTime.UtcNow);
        }
        //  Affichage des liasses blaise
        public static List<PS_VSCOR_AFFICHER_LIASSEResult> AnafiAfficheLiasse(int bloc, string id_dossier, string code_poste, string type_Anafi)
        {
            ScoringEntityDataContext si = new ScoringEntityDataContext();
            var ListAnafiAfficheLiasse = si.PS_VSCOR_AFFICHER_LIASSE(bloc, id_dossier, code_poste, type_Anafi).ToList();
            return ListAnafiAfficheLiasse;
        }


        //Supprimer Liasse Stephane

        public static void SuppLiasse(string iddossier, string annee)
        {
            ScoringEntityDataContext si = new ScoringEntityDataContext();
            si.PS_VSCOR_SUPRIMER_LIASSE(0, annee, iddossier);
            ScoringEntityDataContext s2 = new ScoringEntityDataContext();
            s2.PS_SCOR_ANAFI_MAJ_DATE_FINAN(iddossier, DateTime.UtcNow);

           
        }

        public static void miseAjrDateFinan(string iddossier)
        {
            ScoringEntityDataContext s2 = new ScoringEntityDataContext();
            s2.PS_SCOR_ANAFI_MAJ_DATE_FINAN(iddossier, DateTime.UtcNow);
        }
        public static void CalclueTotauxLiasse(string iddossier, string annee)
        {
            ScoringEntityDataContext si = new ScoringEntityDataContext();
            si.PS_SCORE_ANAFI_CALCUL_TOTAL_BILAN_SMT(iddossier, annee);
            si.PS_SCORE_ANAFI_CALCUL_TOTAL_BILAN_SA(iddossier, annee);
            si.PS_SCORE_ANAFI_CALCUL_TOTAL_BILAN_SN(iddossier, annee);

            si.PS_SCORE_ANAFI_CALCUL_TOTAL_COMPTEE_RES_SMT(iddossier, annee);
            si.PS_SCORE_ANAFI_CALCUL_TOTAL_COMPTE_RESUTAT_SA(iddossier, annee);
            si.PS_SCORE_ANAFI_CALCUL_TOTAL_COMPTE_RESUTAT_SN(iddossier, annee);


        }

        public static void RetranscriptionDonnee(string iddossier)
        {
            ScoringEntityDataContext si = new ScoringEntityDataContext();
            si.PS_SCOR_ANAFI_RETRANSCRIPTIONDONNEE(iddossier);
            si.PS_SCOR_ANAFI_CALC_BGM(iddossier);
            si.PS_SCOR_ANAFI_CALC_TSY(iddossier);
            si.PS_SCOR_ANAFI_CALC_TDR(iddossier);
            si.PS_SCOR_ANAFI_CALC_RAT(iddossier);
            si.PS_SCOR_ANAFI_CALC_AUT(iddossier);
            si.PS_SCOR_ANAFI_CALC_NOTE(iddossier, DateTime.UtcNow);

        }

        public static List<PS_VSCOR_ENCOURSResult> Liste_ENCOURS_N(int bloc, string dossier)
        {
            ScoringEntityDataContext so = new ScoringEntityDataContext();
            var Liste_encours = so.PS_VSCOR_ENCOURS(bloc, dossier,"").ToList();
            return Liste_encours;
        }

        public static void SUPP_HISTORIQUENOTATION(string id_scoring)
        {
            se.PS_VSCOR_SUPP_HISTORIQUENOTATION_T(0, id_scoring);
        }

        public static List<PS_SCOR_LIST_UTILResult> AfficheAdresseMail(string code_banque)
        {
            ScoringEntityDataContext si = new ScoringEntityDataContext();
            var AfficheAdresseMail = si.PS_SCOR_LIST_UTIL(0, code_banque).ToList();
            return AfficheAdresseMail;
        }
        public static List<PS_SCOR_AFFICHE_LOGO_BANKResult> AfficheLogoBank(string code_banque)
        {
            ScoringEntityDataContext si = new ScoringEntityDataContext();
            var AfficheLogoBank = si.PS_SCOR_AFFICHE_LOGO_BANK(code_banque).ToList();
            return AfficheLogoBank;
        }
        public static List<PS_VSCOR_VALIDATION_USERNAMEResult> ListeHistoriqueUserName(int bloc, string id_dossier)
        {
            ScoringEntityDataContext se = new ScoringEntityDataContext();
            var listUserName = se.PS_VSCOR_VALIDATION_USERNAME(bloc, id_dossier).ToList();
            return listUserName;
        }

        public static List<PS_VSCOR_CONTREPARTIEResult> AjouterFiliale(string Libelle)
        {
            ScoringEntityDataContext si = new ScoringEntityDataContext();
            var AjouterFilialeList = si.PS_VSCOR_CONTREPARTIE(13, "", Libelle, "", "").ToList();
            return AjouterFilialeList;
        }


        public static void InsertContrepartie(string iduser, string CODE_AGENCE, string MATRICULE, string NOM, string ADRESSE, string VILLE_RESIDENCE, string RCCM, string SEGMENT_CLIENT, string MODE_ANALYSE, string UNITE, string UNITEPRO, string DEVISE, decimal CA, string PAYS, string STATUT, string ACTIVITE_BCEAO, string SECTEUR_ACTIVITE, string GROUPE, string BRANCHE_ACTIV)
        {
            ScoringEntityDataContext si = new ScoringEntityDataContext();
            si.PS_VSCOR_CONTREPARTIE_INS(0, DateTime.UtcNow, iduser, CODE_AGENCE, MATRICULE, NOM, ADRESSE, VILLE_RESIDENCE, RCCM, SEGMENT_CLIENT, DateTime.UtcNow, MODE_ANALYSE, UNITE, UNITEPRO, DEVISE, CA, PAYS, STATUT, ACTIVITE_BCEAO, SECTEUR_ACTIVITE, GROUPE, BRANCHE_ACTIV);
            //si.PS_VSCOR_CONTREPARTIE_INS_WB();
        }

        public static void InsertContrepartieGroupModif(string iduser, string CODE_AGENCE, string MATRICULE, string NOM, string ADRESSE, string VILLE_RESIDENCE, string RCCM, string SEGMENT_CLIENT, string MODE_ANALYSE, string UNITE, string UNITEPRO, string DEVISE, decimal CA, string PAYS, string STATUT, string ACTIVITE_BCEAO, string SECTEUR_ACTIVITE, string GROUPE, string BRANCHE_ACTIV)
        {
            ScoringEntityDataContext si = new ScoringEntityDataContext();
            si.PS_VSCOR_CONTREPARTIE_INS(3, DateTime.UtcNow, iduser, CODE_AGENCE, MATRICULE, NOM, ADRESSE, VILLE_RESIDENCE, RCCM, SEGMENT_CLIENT, DateTime.UtcNow, MODE_ANALYSE, UNITE, UNITEPRO, DEVISE, CA, PAYS, STATUT, ACTIVITE_BCEAO, SECTEUR_ACTIVITE, GROUPE, BRANCHE_ACTIV);
        }


        public static void InsertContrepartieGroup(string iduser, string CODE_AGENCE, string MATRICULE, string NOM, string ADRESSE, string VILLE_RESIDENCE, string RCCM, string SEGMENT_CLIENT, string MODE_ANALYSE, string UNITE, string UNITEPRO, string DEVISE, decimal CA, string PAYS, string STATUT, string ACTIVITE_BCEAO, string SECTEUR_ACTIVITE, string GROUPE, string BRANCHE_ACTIV)
        {
            ScoringEntityDataContext si = new ScoringEntityDataContext();
            si.PS_VSCOR_CONTREPARTIE_INS(2, DateTime.UtcNow, iduser, CODE_AGENCE, MATRICULE, NOM, ADRESSE, VILLE_RESIDENCE, RCCM, SEGMENT_CLIENT, DateTime.UtcNow, MODE_ANALYSE, UNITE, UNITEPRO, DEVISE, CA, PAYS, STATUT, ACTIVITE_BCEAO, SECTEUR_ACTIVITE, GROUPE, BRANCHE_ACTIV);
        }

        public static void UpdateContrepartie(string iduser, string CODE_AGENCE, string MATRICULE, string NOM, string ADRESSE, string VILLE_RESIDENCE, string RCCM, string SEGMENT_CLIENT, DateTime MOIS_ARRETE, string MODE_ANALYSE, string UNITE, string UNITEPRO, string DEVISE, decimal CA, string PAYS, string STATUT, string ACTIVITE_BCEAO, string SECTEUR_ACTIVITE, string GROUPE, string BRANCHE_ACTIV)
        {
            ScoringEntityDataContext si = new ScoringEntityDataContext();
            si.PS_VSCOR_CONTREPARTIE_INS(1, DateTime.UtcNow, iduser, CODE_AGENCE, MATRICULE, NOM, ADRESSE, VILLE_RESIDENCE, RCCM, SEGMENT_CLIENT, MOIS_ARRETE, MODE_ANALYSE, UNITE, UNITEPRO, DEVISE, CA, PAYS, STATUT, ACTIVITE_BCEAO, SECTEUR_ACTIVITE, GROUPE, BRANCHE_ACTIV);
        }



        public static void InsertContrepartieGroupModif2(string iduser, string CODE_AGENCE, string MATRICULE, string NOM, string ADRESSE, string VILLE_RESIDENCE, string RCCM, string SEGMENT_CLIENT, string MODE_ANALYSE, string UNITE, string UNITEPRO, string DEVISE, decimal CA, string PAYS, string STATUT, string ACTIVITE_BCEAO, string SECTEUR_ACTIVITE, string GROUPE, string BRANCHE_ACTIV)
        {
            ScoringEntityDataContext si = new ScoringEntityDataContext();
            si.PS_VSCOR_CONTREPARTIE_INS(4, DateTime.UtcNow, iduser, CODE_AGENCE, MATRICULE, NOM, ADRESSE, VILLE_RESIDENCE, RCCM, SEGMENT_CLIENT, DateTime.UtcNow, MODE_ANALYSE, UNITE, UNITEPRO, DEVISE, CA, PAYS, STATUT, ACTIVITE_BCEAO, SECTEUR_ACTIVITE, GROUPE, BRANCHE_ACTIV);
        }

        public static List<PS_VSCOR_FICHESIGNALETIQUEResult> DetailsDossierContrepartieCodeG(string code_banque, string id_scoring)
        {
            //ScoringEntityDataContext se = new ScoringEntityDataContext();
            var listDetailsDossierContrepartieCodeG = se.PS_VSCOR_FICHESIGNALETIQUE(2, code_banque, id_scoring, DateTime.UtcNow).ToList();
            return listDetailsDossierContrepartieCodeG;
        }

        public static List<PS_VSCOR_FICHESIGNALETIQUEResult> DetailsDossierContrepartieFilialeDeja(string id_scoring)
        {
            //ScoringEntityDataContext se = new ScoringEntityDataContext();
            var listDetailsDossierContrepartieFilialeDeja = se.PS_VSCOR_FICHESIGNALETIQUE(3, "", id_scoring, DateTime.UtcNow).ToList();
            return listDetailsDossierContrepartieFilialeDeja;
        }

        //stephjh
        public static List<PS_SCOR_SELECTION_FILIALEResult> SelectvalFiliale(string iD_DOSSIER)
        {
            ScoringEntityDataContext si = new ScoringEntityDataContext();
            return si.PS_SCOR_SELECTION_FILIALE(0, iD_DOSSIER, "").ToList();
        }

        public static List<PS_SCOR_SELECTION_FILIALEResult> SelectvaldesFiliales(string gROUPE_DOSSIER)
        {
            ScoringEntityDataContext si = new ScoringEntityDataContext();
            return si.PS_SCOR_SELECTION_FILIALE(1, "", gROUPE_DOSSIER).ToList();
        }

        public static void InsertContrepartieGroupModifFS(string iduser, string CODE_AGENCE, string MATRICULE, string NOM, string ADRESSE, string VILLE_RESIDENCE, string RCCM, string SEGMENT_CLIENT, string MODE_ANALYSE, string UNITE, string UNITEPRO, string DEVISE, decimal CA, string PAYS, string STATUT, string ACTIVITE_BCEAO, string SECTEUR_ACTIVITE, string GROUPE, string BRANCHE_ACTIV)
        {
            ScoringEntityDataContext si = new ScoringEntityDataContext();
            si.PS_VSCOR_CONTREPARTIE_INS(5, DateTime.UtcNow, iduser, CODE_AGENCE, MATRICULE, NOM, ADRESSE, VILLE_RESIDENCE, RCCM, SEGMENT_CLIENT, DateTime.UtcNow, MODE_ANALYSE, UNITE, UNITEPRO, DEVISE, CA, PAYS, STATUT, ACTIVITE_BCEAO, SECTEUR_ACTIVITE, GROUPE, BRANCHE_ACTIV);
        }
        //Oscar 05042018
        public static List<PS_SCOR_LISTE_DOSSIERResult> LIST_DOSSIER(int Bloc, string id_scoring)
        {
            //ScoringEntityDataContext se = new ScoringEntityDataContext();
            var listqualitatif = se.PS_SCOR_LISTE_DOSSIER(Bloc, id_scoring).ToList();
            return listqualitatif;
        }
        /// <summary>
        /// //Steph & Oscar
        /// </summary>
        /// <returns></returns>
        public static List<PS_SCOR_SELECTION_STDPO_PAYSResult> LIST_STDOPAYS()
        {
            //ScoringEntityDataContext se = new ScoringEntityDataContext();
            var listqualitatif = se.PS_SCOR_SELECTION_STDPO_PAYS(0, "").ToList();
            return listqualitatif;
        }
        public static void INSERT_STDOPAYS(string pAYS_CODE, string nOTE_PAYS, string vALEUR_NOTE_PAYS, string pERSPECTIVE_PAYS)
        {
            se.PS_SCOR_INSERT_STDPO_PAYS(pAYS_CODE, nOTE_PAYS, Convert.ToDouble(vALEUR_NOTE_PAYS), pERSPECTIVE_PAYS, DateTime.UtcNow);
        }
        public static List<PS_SCOR_SELECTION_STDPO_PAYSResult> LIST_STDOPAYS2()
        {
            //ScoringEntityDataContext se = new ScoringEntityDataContext();
            var listqualitatif = se.PS_SCOR_SELECTION_STDPO_PAYS(2, "").ToList();
            return listqualitatif;
        }
        public static List<PS_SCOR_SELECTION_STDPO_PAYSResult> LIST_STDOPAYS3()
        {
            //ScoringEntityDataContext se = new ScoringEntityDataContext();
            var listqualitatif = se.PS_SCOR_SELECTION_STDPO_PAYS(3, "").ToList();
            return listqualitatif;
        }

        public static List<PS_SCOR_SELECTION_STDPO_PAYSResult> SelectionPaysParNom(string nompays, string structure)
        {
            if (structure == "STPO")
            {
                //ScoringEntityDataContext se = new ScoringEntityDataContext();
                var listqualitatif = se.PS_SCOR_SELECTION_STDPO_PAYS(1, nompays).ToList();
                return listqualitatif;
            }
            else
            {
                if (structure == "MOOD")
                {
                    //ScoringEntityDataContext se = new ScoringEntityDataContext();
                    var listqualitatif = se.PS_SCOR_SELECTION_STDPO_PAYS(1, nompays).ToList();
                    return listqualitatif;
                }
                else
                {
                    //ScoringEntityDataContext se = new ScoringEntityDataContext();
                    var listqualitatif = se.PS_SCOR_SELECTION_STDPO_PAYS(1, nompays).ToList();
                    return listqualitatif;
                }
            }
            
        }

        //blaise 10082018

        public static List<PS_VSCOR_VALIDATIONNOTEResult> DetailsNotesDossierPoint(int bloc, string id_dossier)
        {

            //ScoringEntityDataContext se = new ScoringEntityDataContext();
            var Pointlistqualitatif = se.PS_VSCOR_VALIDATIONNOTE(bloc, id_dossier, DateTime.UtcNow, "", "", "", "").ToList();
            return Pointlistqualitatif;
        }

        public static List<PS_SCOR_ETATBILAN_ACT_CIRCULResult> LIST_PS_SCOR_ETATBILAN_ACT_CIRCUL(string annee, string dossier)
        {
            //ScoringEntityDataContext se = new ScoringEntityDataContext();
            var listAnafi = se.PS_SCOR_ETATBILAN_ACT_CIRCUL(annee, dossier, 1).ToList();
            return listAnafi;
        }

        public static List<PS_SCOR_ETATBILAN_AMResult> LIST_PS_SCOR_ETATBILAN_AM(string annee, string dossier)
        {
            //ScoringEntityDataContext se = new ScoringEntityDataContext();
            var listAnafi = se.PS_SCOR_ETATBILAN_AM(annee, dossier, 1).ToList();
            return listAnafi;
        }

        public static List<PS_SCOR_ETATBILAN_CHARGE1Result> LIST_PS_SCOR_ETATBILAN_CHARGE1(string annee, string dossier)
        {
            //ScoringEntityDataContext se = new ScoringEntityDataContext();
            var listAnafi = se.PS_SCOR_ETATBILAN_CHARGE1(annee, dossier, 1).ToList();
            return listAnafi;
        }

        public static List<PS_SCOR_ETATBILAN_CHARGE2Result> LIST_SCOR_ETATBILAN_CHARGE2(string annee, string dossier)
        {
            //ScoringEntityDataContext se = new ScoringEntityDataContext();
            var listAnafi = se.PS_SCOR_ETATBILAN_CHARGE2(annee, dossier, 1).ToList();
            return listAnafi;
        }

        public static List<PS_SCOR_ETATBILAN_PCResult> LIST_PS_SCOR_ETATBILAN_PC(string annee, string dossier)
        {
            //ScoringEntityDataContext se = new ScoringEntityDataContext();
            var listAnafi = se.PS_SCOR_ETATBILAN_PC(annee, dossier, 1).ToList();
            return listAnafi;
        }

        public static List<PS_SCOR_ETATBILAN_PCIRCULResult> LIST_PS_SCOR_ETATBILAN_PCIRCUL(string annee, string dossier)
        {
            //ScoringEntityDataContext se = new ScoringEntityDataContext();
            var listAnafi = se.PS_SCOR_ETATBILAN_PCIRCUL(annee, dossier, 1).ToList();
            return listAnafi;
        }

        public static List<PS_SCOR_ETATBILAN_PRODUIT1Result> LIST_PS_SCOR_ETATBILAN_PRODUIT1(string annee, string dossier)
        {
            //ScoringEntityDataContext se = new ScoringEntityDataContext();
            var listAnafi = se.PS_SCOR_ETATBILAN_PRODUIT1(annee, dossier, 1).ToList();
            return listAnafi;
        }

        public static List<PS_SCOR_ETATBILAN_PRODUIT2Result> LIST_PS_SCOR_ETATBILAN_PRODUIT2(string annee, string dossier)
        {
            //ScoringEntityDataContext se = new ScoringEntityDataContext();
            var listAnafi = se.PS_SCOR_ETATBILAN_PRODUIT2(annee, dossier, 1).ToList();
            return listAnafi;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static List<PS_SCOR_Selection_List_SeuilResult> ListeSeuil(string cODE_BANQUE)
        {
            ScoringEntityDataContext so = new ScoringEntityDataContext();
            var ListeSeuil = so.PS_SCOR_Selection_List_Seuil(cODE_BANQUE).ToList();
            return ListeSeuil;
        }

        public static bool InsertSeuil(string cODE_BANQUE, string lIBELLE_SEUIL_DELEGUATION, Int64 mAX_SCOR_SEUIL_DELEGUATION, Int64 mIN_SCOR_SEUIL_DELEGUATION)
        {
            ScoringEntityDataContext so = new ScoringEntityDataContext();
            var LeSeuil = false;
            try
            {
                var CountListeSeuil = so.PS_SCOR_Selection_List_Seuil(cODE_BANQUE).ToList().Count;
                so.PS_SCOR_Insert_SchemaDelegataire_A(lIBELLE_SEUIL_DELEGUATION, mAX_SCOR_SEUIL_DELEGUATION, mIN_SCOR_SEUIL_DELEGUATION, cODE_BANQUE);
                LeSeuil = true;
            }
            catch
            {
                LeSeuil = false;
            }
            return LeSeuil;
        }
        public static bool suppValInt(string cODE_BANQUE)
        {
            ScoringEntityDataContext so = new ScoringEntityDataContext();
            var LeSeuil = false;
            try
            {
                var CountListeSeuil = so.PS_SCOR_Selection_List_Seuil(cODE_BANQUE).ToList().Count;
                if (CountListeSeuil != 0) so.PS_SCOR_Supp_SchemaDelegataire_D(cODE_BANQUE);
                LeSeuil = true;
            }
            catch
            {
                LeSeuil = false;
            }
            return LeSeuil;
        }

        public static List<PS_SCOR_Tableau_SchemaDelegataire_A1Result> ListeDeclaration(string cODE_BANQUE)
        {
            ScoringEntityDataContext so = new ScoringEntityDataContext();
            var ListeDeclaration = so.PS_SCOR_Tableau_SchemaDelegataire_A1(cODE_BANQUE)!=null?so.PS_SCOR_Tableau_SchemaDelegataire_A1(cODE_BANQUE).ToList():null;
            return ListeDeclaration;
        }

        public static List<PS_SCOR_Tableau_SchemaDelegataire_ListeResult> ListeUtilisateurDec(int iD_LIGNE, string cODE_BANQUE)
        {
            ScoringEntityDataContext so = new ScoringEntityDataContext();
            var ListeUtilisateurDec = so.PS_SCOR_Tableau_SchemaDelegataire_Liste(iD_LIGNE, cODE_BANQUE).ToList();
            return ListeUtilisateurDec;
        }

        public static List<PS_SCOR_Tableau_SchemaDelegataire_CResult> ListeAgenceDec(int iD_LIGNE, string cODE_BANQUE)
        {
            ScoringEntityDataContext so = new ScoringEntityDataContext();
            var ListeAgenceDec = so.PS_SCOR_Tableau_SchemaDelegataire_C(iD_LIGNE, cODE_BANQUE).ToList();
            return ListeAgenceDec;
        }

        public static bool InsertDeleguat(string lIBELLE_SCOR_DELEGATION,int iD_SCOR_SEUIL_DELEGUATION)
        {
            ScoringEntityDataContext so = new ScoringEntityDataContext();
            var LeSeuil = false;
            try
            {
                so.PS_SCOR_Insert_SchemaDelegataire_B(lIBELLE_SCOR_DELEGATION,iD_SCOR_SEUIL_DELEGUATION);
                LeSeuil = true;
            }
            catch
            {
                LeSeuil = false;
            }
            return LeSeuil;
        }

        public static bool InsertAjoutUTAGDeleguat(int iD_SCOR_DELEGATION, string iD_USER, string cODE_AGENCE)
        {
            ScoringEntityDataContext so = new ScoringEntityDataContext();
            var LeSeuil = false;
            try
            {
                so.PS_SCOR_Insert_SchemaDelegataire_C(iD_SCOR_DELEGATION,iD_USER,cODE_AGENCE);
                LeSeuil = true;
            }
            catch
            {
                LeSeuil = false;
            }
            return LeSeuil;
        }

        public static bool DeleteUTAGDeleguat(int iD_ligne)
        {
            ScoringEntityDataContext so = new ScoringEntityDataContext();
            var supp = false;
            try
            {
                so.PS_SCOR_delete_SchemaDelegataire_C(iD_ligne);
                supp = true;
            }
            catch
            {
                supp = false;
            }
            return supp;
        }

        public static List<PS_SCOR_Specif_SchemaDelegataire_AResult> ListeDecSpecif(int iD_SCOR_SEUIL_DELEGUATION, string lIBELLE_SCOR_DELEGATION)
        {
            ScoringEntityDataContext so = new ScoringEntityDataContext();
            var ListeDecSpecif = so.PS_SCOR_Specif_SchemaDelegataire_A(iD_SCOR_SEUIL_DELEGUATION,lIBELLE_SCOR_DELEGATION).ToList();
            return ListeDecSpecif;
        }

        public static List<PS_SCOR_Specif_SchemaDelegataire_BResult> ListeDecSpecif2(int bloc,int iD_SCOR_SEUIL_DELEGUATION, string id_dossier, string cODE_BANQUE)
        {
            ScoringEntityDataContext so = new ScoringEntityDataContext();
            var ListeDecSpecif2 = so.PS_SCOR_Specif_SchemaDelegataire_B( bloc, iD_SCOR_SEUIL_DELEGUATION,  id_dossier,  cODE_BANQUE).ToList();
            return ListeDecSpecif2;
        }
        public static bool Ps_scor_insert_credit_dossier(int iD_SCOR_SEUIL_DELEGUATION, string ID_DOSSIER)
        {
            ScoringEntityDataContext so = new ScoringEntityDataContext();
            var LeSeuil = false;
            try
            {
                so.PS_SCOR_INSERT_CREDIT_DOSSIER(iD_SCOR_SEUIL_DELEGUATION, ID_DOSSIER);
                LeSeuil = true;
            }
            catch
            {
                LeSeuil = false;
            }
            return LeSeuil;
        }
        public static List<PS_SCOR_GET_SEUIL_DOSSIERResult> Ps_scor_get_seuil_dossier(string ID_DOSSIER)
        {
            ScoringEntityDataContext so = new ScoringEntityDataContext();
            var ListeDecSpecif2 = so.PS_SCOR_GET_SEUIL_DOSSIER(ID_DOSSIER).ToList();
            return ListeDecSpecif2;
        }

        public static List<PS_SCOR_VERIF_SEUIL_UTIResult> Ps_scor_verifseuil_Uti(string iD_USER)
        {
            ScoringEntityDataContext so = new ScoringEntityDataContext();
            var ListeDecSpecif2 = so.PS_SCOR_VERIF_SEUIL_UTI(iD_USER).ToList();
            return ListeDecSpecif2;
        }

        public static List<PS_SCOR_Selection_List_Seuil_SpecifResult> Ps_scor_leseuil(int iD_SCOR_SEUIL_DELEGUATION)
        {
            ScoringEntityDataContext so = new ScoringEntityDataContext();
            var ListeDecSpecif2 = so.PS_SCOR_Selection_List_Seuil_Specif(iD_SCOR_SEUIL_DELEGUATION,null,null,null,null,null).ToList();
            return ListeDecSpecif2;
        }

        public static void ENREGISTREMENT_ENCOURS(string idDossier, string Numero)
        {
            ScoringEntityDataContext so = new ScoringEntityDataContext();
            so.PS_VSCOR_ENCOURS(1, idDossier, Numero);
        }

        public static List<PS_SELECT_DATE_COMPTABLEResult> SELECT_DATE_COMPTABLE(string ETATDOS, string ID_DOSSIER)
        {
            ScoringEntityDataContext so = new ScoringEntityDataContext();
            var ListeDecSpecif2 = so.PS_SELECT_DATE_COMPTABLE(1, ETATDOS,ID_DOSSIER).ToList();
            return ListeDecSpecif2;
        }

        public static List<PS_VSCOR_ENCOURSResult> Liste_ENCOURS(string idDossier)
        {
            ScoringEntityDataContext so = new ScoringEntityDataContext();
            var Liste_encours = so.PS_VSCOR_ENCOURS(0, "", idDossier).ToList();
            return Liste_encours;
        }

        public static List<PS_VSCOR_ENCOURSResult> Liste_ENCOURS_EDITION(string idDossier)
        {
            ScoringEntityDataContext so = new ScoringEntityDataContext();
            var Liste_encours = so.PS_VSCOR_ENCOURS(2, idDossier, "").ToList();
            return Liste_encours;
        }


        public static List<PS_VSCOR_CONTRO_CONTREPARTIEResult> CONTRO_CONTREPARTIE( string raisonSocial)
        {
            ScoringEntityDataContext so = new ScoringEntityDataContext();
            var Liste_PS_VSCOR_CONTRO_CONTREPARTIE = so.PS_VSCOR_CONTRO_CONTREPARTIE(0, raisonSocial).ToList();
            return Liste_PS_VSCOR_CONTRO_CONTREPARTIE;
        }

        public static List<PS_SCOR_MODELE_NOTATIONResult> MODELE_NOTATION(int bloc, string code_modele, string code_modele_param, string segment, decimal ca, string code_activite, string code_statut)
        {
            ScoringEntityDataContext context = new ScoringEntityDataContext();
            return context.PS_SCOR_MODELE_NOTATION(bloc, code_modele, code_modele_param, segment, ca, code_activite, code_statut).ToList();
        }

        public static void CONTREPARTIE(int bloc,string ID_SCORING, string CODE_AGENCE, string MATRICULE, string NOM, string ADRESSE, string VILLE_RESIDENCE, string RCCM, string SEGMENT_CLIENT, DateTime MOIS_ARRETE, string MODE_ANALYSE,
                                        string UNITE, string DEVISE, decimal CA, string PAYS, string STATUT, string ACTIVITE_BCEAO, string SECTEUR_ACTIVITE, string CODE_BANQUE)
        {
            ScoringEntityDataContext context = new ScoringEntityDataContext();
            context.PS_SCOR_CONTREPARTIE(bloc, ID_SCORING, CODE_AGENCE, MATRICULE, NOM, ADRESSE, VILLE_RESIDENCE, RCCM, SEGMENT_CLIENT, MOIS_ARRETE, MODE_ANALYSE, UNITE, DEVISE, CA, PAYS, STATUT, ACTIVITE_BCEAO, SECTEUR_ACTIVITE, CODE_BANQUE);
        }

        public static void MAJ_CA_MODELE_NOTATION_CONTREPARTIE (string ID_SCORING, string MODE_ANALYSE, decimal CA)
        {
            ScoringEntityDataContext context = new ScoringEntityDataContext();
            context.PS_SCOR_CONTREPARTIE(11, ID_SCORING, null, null, null, null, null, null, null, DateTime.Now, MODE_ANALYSE, null, null, CA, null, null, null, null, null);
        }

        public static void MAJ_MODELE_NOTATION_DOSSIER(string ID_DOSSIER, string MODELE_DOSSIER)
        {
            ScoringEntityDataContext context = new ScoringEntityDataContext();
            context.PS_SCOR_DOSSIER(10, ID_DOSSIER, null, DateTime.Now, null, null, null, null, null, null, null, null, null, null, MODELE_DOSSIER);
        }

        public static List<PS_SCOR_DOSSIERResult> DOSSIER(string ID_DOSSIER)
        {
            ScoringEntityDataContext context = new ScoringEntityDataContext();
            return context.PS_SCOR_DOSSIER(5, ID_DOSSIER, null, DateTime.Now, null, null, null, null, null, null, null, null, null, null, null).ToList();
        }
    }
}