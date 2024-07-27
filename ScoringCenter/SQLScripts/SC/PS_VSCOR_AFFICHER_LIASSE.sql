USE [ScoringDB]
GO

/****** Object:  StoredProcedure [dbo].[PS_VSCOR_AFFICHER_LIASSE]    Script Date: 04/04/2023 01:08:52 ******/
DROP PROCEDURE [dbo].[PS_VSCOR_AFFICHER_LIASSE]
GO

/****** Object:  StoredProcedure [dbo].[PS_VSCOR_AFFICHER_LIASSE]    Script Date: 04/04/2023 01:08:52 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[PS_VSCOR_AFFICHER_LIASSE]
@bloc as int,
@id_dossier as varchar(10),
@code_poste as varchar(10),
@type_Anafi as varchar(10)
AS
BEGIN
IF @bloc=-1
BEGIN
		SELECT * FROM ANAFI_BILAN ,ANAFI_AUTRE_RATIO,ANAFI_AUTRE_RATIO_DETAIL,ANAFI_BILAN_DETAIL, ANFI_RUBRIQUE_ETAT , ANAFI_PARAMETRE_DETAIL, ANAFI_COMPTE_RESULTAT CR,ANAFI_COMPTE_RESULTAT_DETAIL, ANAFI_BILAN_GRANDE_MASSE ,ANAFI_BILAN_GRANDE_MASSE_DETAIL,ANAFI_TABLEAU_SYNTHETIQUE,ANAFI_TABLEAU_SYNTHETIQUE_DETAIL,ANAFI_RATIO ,ANAFI_RATIO_DETAIL,ANAFI_TDR ,ANAFI_TDR_DETAIL
		
END

IF @bloc=0
BEGIN

	SELECT RUBR_ETAT_CODE ,RUBR_ETAT_LIBELLE,RUBR_ETAT_TYPE,RUBR_TYPE_DETAIL_VALEUR,RUBR_ETAT_SENS,RUBR_ETAT_CR,RUBR_TYPE_DETAIL_VALEUR,MODE,RUBR_PERCENT
	FROM 
	ANFI_RUBRIQUE_ETAT 
	WHERE RUBR_ETAT_TYPE=@type_Anafi
	ORDER BY RUBR_PERCENT

END

IF @bloc=1
BEGIN
 --Afficher bilan SMT
		SELECT B.CODE_POSTE,RUBR_ETAT_LIBELLE,ANNEE_B_DETAIL,VALEUR_B_DETAIL,RUBR_ETAT_TYPE,RUBR_TYPE_DETAIL_VALEUR,RUBR_ETAT_SENS,RUBR_ETAT_CR,RUBR_TYPE_DETAIL_VALEUR,MODE,RUBR_PERCENT,TYPE_ANAFI_A
		FROM ANAFI_BILAN  B,ANAFI_BILAN_DETAIL DB, ANFI_RUBRIQUE_ETAT R, ANAFI_PARAMETRE_DETAIL P
		WHERE B.CODE_POSTE = R.RUBR_ETAT_CODE 
			AND DB.ID_BILAN= B.ID_BILAN
			AND B.ID_PARAMETRE_DETAIL= P.ID_PARAMETRE_DETAIL
			AND P.ID_PARAMETRE IN (SELECT [ID_PARAMETRE] FROM [ANAFI_PARAMETRE] where [ID_DOSSIER]=@id_dossier )
			AND B.CODE_POSTE=@code_poste  
			AND RUBR_ETAT_TYPE='BSM'
			AND TYPE_ANAFI_A=@type_Anafi
	--ORDER BY RUBR_PERCENT,DATE_CLOTURE
		ORDER BY RUBR_PERCENT,RIGHT(ANNEE_DETAIL, 4)

END

IF @bloc=2
BEGIN
 --Afficher compte resultat


		SELECT CR.CODE_POSTE,RUBR_ETAT_LIBELLE,ANNEE_CR_DETAIL,VALEUR_CR_DETAIL,RUBR_ETAT_TYPE,RUBR_TYPE_DETAIL_VALEUR,RUBR_ETAT_SENS,RUBR_ETAT_CR,RUBR_TYPE_DETAIL_VALEUR,MODE,RUBR_PERCENT,TYPE_ANAFI_A
		FROM ANAFI_COMPTE_RESULTAT CR,ANAFI_COMPTE_RESULTAT_DETAIL DCR, ANFI_RUBRIQUE_ETAT R, ANAFI_PARAMETRE_DETAIL P
		WHERE CR.CODE_POSTE = R.RUBR_ETAT_CODE 
			AND DCR.ID_COMPTE_RESULTAT= CR.ID_COMPTE_RESULTAT
			AND CR.ID_PARAMETRE_DETAIL= P.ID_PARAMETRE_DETAIL
			AND P.ID_PARAMETRE IN (SELECT [ID_PARAMETRE] FROM [ANAFI_PARAMETRE] where [ID_DOSSIER]=@id_dossier)
			AND CR.CODE_POSTE=@code_poste 
			AND RUBR_ETAT_TYPE='CSM'
			AND TYPE_ANAFI_A=@type_Anafi
		--ORDER BY RUBR_PERCENT,DATE_CLOTURE
		ORDER BY RUBR_PERCENT,RIGHT(ANNEE_DETAIL, 4)

END

IF @bloc=3
BEGIN
 --Afficher bilan grande masse
	SELECT BG.CODE_POSTE,RUBR_ETAT_LIBELLE,ANNEE_BGR_DETAIL,TAUX_BGR_DETAIL,VALEUR_BGR_DETAIL,RUBR_ETAT_TYPE,RUBR_TYPE_DETAIL_VALEUR,RUBR_ETAT_SENS,RUBR_ETAT_CR,RUBR_TYPE_DETAIL_VALEUR,MODE,RUBR_PERCENT,TYPE_ANAFI_A
		FROM ANAFI_BILAN_GRANDE_MASSE BG,ANAFI_BILAN_GRANDE_MASSE_DETAIL DBG, ANFI_RUBRIQUE_ETAT R, ANAFI_PARAMETRE_DETAIL P
		WHERE BG.CODE_POSTE = R.RUBR_ETAT_CODE 
			AND DBG.ID_BILAN_GRANDE_MASSE= BG.ID_BILAN_GRANDE_MASSE
			AND BG.ID_PARAMETRE_DETAIL= P.ID_PARAMETRE_DETAIL
			AND P.ID_PARAMETRE IN (SELECT [ID_PARAMETRE] FROM [ANAFI_PARAMETRE] where [ID_DOSSIER]=@id_dossier)
			AND BG.CODE_POSTE=@code_poste  
			AND RUBR_ETAT_TYPE='BIL'
			AND TYPE_ANAFI_A=@type_Anafi
	--ORDER BY RUBR_PERCENT,DATE_CLOTURE
		ORDER BY RUBR_PERCENT,RIGHT(ANNEE_DETAIL, 4)

END

IF @bloc=4
BEGIN
 --Afficher tableau synthetique
		SELECT TS.CODE_POSTE,RUBR_ETAT_LIBELLE,ANNEE_TS_DETAIL,TAUX_TS_DETAIL,VALEUR_TS_DETAIL,RUBR_ETAT_TYPE,RUBR_TYPE_DETAIL_VALEUR,RUBR_ETAT_SENS,RUBR_ETAT_CR,RUBR_TYPE_DETAIL_VALEUR,MODE,RUBR_PERCENT,TYPE_ANAFI_A
		FROM ANAFI_TABLEAU_SYNTHETIQUE TS,ANAFI_TABLEAU_SYNTHETIQUE_DETAIL DTS, ANFI_RUBRIQUE_ETAT R, ANAFI_PARAMETRE_DETAIL P
		WHERE TS.CODE_POSTE = R.RUBR_ETAT_CODE 
			AND DTS.ID_TABLEAU_SYNTHETIQUE= TS.ID_TABLEAU_SYNTHETIQUE
			AND TS.ID_PARAMETRE_DETAIL= P.ID_PARAMETRE_DETAIL
			AND P.ID_PARAMETRE IN (SELECT [ID_PARAMETRE] FROM [ANAFI_PARAMETRE] where [ID_DOSSIER]=@id_dossier)
			AND TS.CODE_POSTE=@code_poste
			AND RUBR_ETAT_TYPE='CR'
			AND TYPE_ANAFI_A=@type_Anafi  
		--ORDER BY RUBR_PERCENT,DATE_CLOTURE
		ORDER BY RUBR_PERCENT,RIGHT(ANNEE_DETAIL, 4)

END

IF @bloc=5
BEGIN
--Afficher TDR
		SELECT TDR.CODE_POSTE,RUBR_ETAT_LIBELLE,ANNEE_TDR_DETAIL,VALEUR_TDR_DETAIL,RUBR_ETAT_TYPE,RUBR_TYPE_DETAIL_VALEUR,RUBR_ETAT_SENS,RUBR_ETAT_CR,RUBR_TYPE_DETAIL_VALEUR,MODE,RUBR_PERCENT,TYPE_ANAFI_A
		FROM ANAFI_TDR TDR,ANAFI_TDR_DETAIL DTDR, ANFI_RUBRIQUE_ETAT R, ANAFI_PARAMETRE_DETAIL P
		WHERE TDR.CODE_POSTE = R.RUBR_ETAT_CODE 
			AND DTDR.ID_TDR =TDR.ID_TDR
			AND TDR.ID_PARAMETRE_DETAIL= P.ID_PARAMETRE_DETAIL
			AND P.ID_PARAMETRE IN (SELECT [ID_PARAMETRE] FROM [ANAFI_PARAMETRE] where [ID_DOSSIER]=@id_dossier)
			AND TDR.CODE_POSTE=@code_poste 
			AND RUBR_ETAT_TYPE='TDR'
			AND TYPE_ANAFI_A=@type_Anafi  
		--ORDER BY RUBR_PERCENT,DATE_CLOTURE
		ORDER BY RUBR_PERCENT,RIGHT(ANNEE_DETAIL, 4)

END

IF @bloc=6
BEGIN

 --Afficher RATIO
		SELECT RAT.CODE_POSTE,RUBR_ETAT_LIBELLE,ANNEE_RAT_DETAIL,VALEUR_RAT_DETAIL,RUBR_ETAT_TYPE,RUBR_TYPE_DETAIL_VALEUR,RUBR_ETAT_SENS,RUBR_ETAT_CR,RUBR_TYPE_DETAIL_VALEUR,MODE,RUBR_PERCENT,TYPE_ANAFI_A,VALEUR_RAT_AFF_DETAIL
		FROM ANAFI_RATIO RAT,ANAFI_RATIO_DETAIL DRAT, ANFI_RUBRIQUE_ETAT R, ANAFI_PARAMETRE_DETAIL P
		WHERE RAT.CODE_POSTE = R.RUBR_ETAT_CODE 
			AND DRAT.ID_RATIO= RAT.ID_RATIO
			AND RAT.ID_PARAMETRE_DETAIL= P.ID_PARAMETRE_DETAIL
			AND P.ID_PARAMETRE IN (SELECT [ID_PARAMETRE] FROM [ANAFI_PARAMETRE] where [ID_DOSSIER]=@id_dossier)
			AND RAT.CODE_POSTE=@code_poste  
			AND RUBR_ETAT_TYPE='RAT'
			AND TYPE_ANAFI_A=@type_Anafi  
	--ORDER BY RUBR_PERCENT,DATE_CLOTURE
		ORDER BY RUBR_PERCENT,RIGHT(ANNEE_DETAIL, 4)
 

END

IF @bloc=7
BEGIN
	-- Vérifier l'existance d'une noté validé pour savoir où récupérer les années de liasses
	if '' = (select ltrim(rtrim(NOTE_VAL)) from SCOR_DOSSIER where ID_DOSSIER = @id_dossier)
	begin
		SELECT [ID_PARAMETRE_DETAIL]
      ,[ID_PARAMETRE]
      ,[ANNEE_DETAIL]
      ,[DATE_CLOTURE]
      ,[DUREE_EXERCICE_MOIS]
      ,[TYPE_ANAFI_A]
      ,[NATURE_EXERCICE]
      ,[CERTIFICATION_COMPTES]
      ,[EFFECTIF]
      ,[DEVISE]
      ,[REGIME_FISCAL]
      ,[NUM_ID_FISC]
      ,[TYPE_DOC_CHARG]
      ,[NOM_DOC_CHARG]
      ,[CHEMIN_ACC1]
      ,[CHEMIN_ACC2]
      ,[COMMENTAIRE_CLIENT]
      ,[RECUP_LIASSE] FROM ANAFI_PARAMETRE_DETAIL
		WHERE ID_PARAMETRE IN (SELECT [ID_PARAMETRE] FROM [ANAFI_PARAMETRE] where [ID_DOSSIER] = @id_dossier)
		AND TYPE_ANAFI_A = @type_Anafi
		ORDER BY RIGHT(ANNEE_DETAIL, 4)
	end
	else
	begin
		SELECT [ID_PARAMETRE_DETAIL]
      ,[ID_PARAMETRE]
      ,[ANNEE_DETAIL]
      ,[DATE_CLOTURE]
      ,[DUREE_EXERCICE_MOIS]
      ,[TYPE_ANAFI_A]
      ,[NATURE_EXERCICE]
      ,[CERTIFICATION_COMPTES]
      ,[EFFECTIF]
      ,[DEVISE]
      ,[REGIME_FISCAL]
      ,[NUM_ID_FISC]
      ,[TYPE_DOC_CHARG]
      ,[NOM_DOC_CHARG]
      ,[CHEMIN_ACC1]
      ,[CHEMIN_ACC2]
      ,[COMMENTAIRE_CLIENT]
      ,[RECUP_LIASSE] FROM ANAFI_SAVE_PARAMETRE_DETAIL
		WHERE ID_PARAMETRE IN (SELECT [ID_PARAMETRE] FROM ANAFI_SAVE_PARAMETRE where [ID_DOSSIER] = @id_dossier)
		AND TYPE_ANAFI_A = @type_Anafi
		ORDER BY RIGHT(ANNEE_DETAIL, 4)
	end
END

IF @bloc=8
BEGIN

 --Afficher le nombre d'annees (pour poser une condition )
		SELECT count(distinct ANNEE_DETAIL) FROM ANAFI_PARAMETRE_DETAIL
		WHERE ID_PARAMETRE IN (SELECT [ID_PARAMETRE] FROM [ANAFI_PARAMETRE] where [ID_DOSSIER]=@id_dossier)
		AND TYPE_ANAFI_A =@type_Anafi

END

IF @bloc=9
BEGIN
 --Afficher bilan SMT
		SELECT B.CODE_POSTE,RUBR_ETAT_LIBELLE,ANNEE_B_DETAIL,VALEUR_B_DETAIL,RUBR_ETAT_TYPE,RUBR_TYPE_DETAIL_VALEUR,RUBR_ETAT_SENS,RUBR_ETAT_CR,RUBR_TYPE_DETAIL_VALEUR,MODE,RUBR_PERCENT,TYPE_ANAFI_A
		FROM ANAFI_BILAN  B,ANAFI_BILAN_DETAIL DB, ANFI_RUBRIQUE_ETAT R, ANAFI_PARAMETRE_DETAIL P
		WHERE B.CODE_POSTE = R.RUBR_ETAT_CODE 
			AND DB.ID_BILAN= B.ID_BILAN
			AND B.ID_PARAMETRE_DETAIL= P.ID_PARAMETRE_DETAIL
			AND P.ID_PARAMETRE IN (SELECT [ID_PARAMETRE] FROM [ANAFI_PARAMETRE] where [ID_DOSSIER]=@id_dossier )
			AND B.CODE_POSTE=@code_poste  
			AND RUBR_ETAT_TYPE='BIN'
			AND TYPE_ANAFI_A=@type_Anafi
	--ORDER BY RUBR_PERCENT,DATE_CLOTURE
		ORDER BY RUBR_PERCENT,RIGHT(ANNEE_DETAIL, 4)

END

IF @bloc=10
BEGIN
 --Afficher compte resultat


		SELECT CR.CODE_POSTE,RUBR_ETAT_LIBELLE,ANNEE_CR_DETAIL,VALEUR_CR_DETAIL,RUBR_ETAT_TYPE,RUBR_TYPE_DETAIL_VALEUR,RUBR_ETAT_SENS,RUBR_ETAT_CR,RUBR_TYPE_DETAIL_VALEUR,MODE,RUBR_PERCENT,TYPE_ANAFI_A
		FROM ANAFI_COMPTE_RESULTAT CR,ANAFI_COMPTE_RESULTAT_DETAIL DCR, ANFI_RUBRIQUE_ETAT R, ANAFI_PARAMETRE_DETAIL P
		WHERE CR.CODE_POSTE = R.RUBR_ETAT_CODE 
			AND DCR.ID_COMPTE_RESULTAT= CR.ID_COMPTE_RESULTAT
			AND CR.ID_PARAMETRE_DETAIL= P.ID_PARAMETRE_DETAIL
			AND P.ID_PARAMETRE IN (SELECT [ID_PARAMETRE] FROM [ANAFI_PARAMETRE] where [ID_DOSSIER]=@id_dossier)
			AND CR.CODE_POSTE=@code_poste 
			AND RUBR_ETAT_TYPE='CRN'
			AND TYPE_ANAFI_A=@type_Anafi
		--ORDER BY RUBR_PERCENT,DATE_CLOTURE
		ORDER BY RUBR_PERCENT,RIGHT(ANNEE_DETAIL, 4)

END

IF @bloc=11
BEGIN
 --Afficher bilan SMT
		SELECT B.CODE_POSTE,RUBR_ETAT_LIBELLE,ANNEE_B_DETAIL,VALEUR_B_DETAIL,RUBR_ETAT_TYPE,RUBR_TYPE_DETAIL_VALEUR,RUBR_ETAT_SENS,RUBR_ETAT_CR,RUBR_TYPE_DETAIL_VALEUR,MODE,RUBR_PERCENT,TYPE_ANAFI_A
		FROM ANAFI_BILAN  B,ANAFI_BILAN_DETAIL DB, ANFI_RUBRIQUE_ETAT R, ANAFI_PARAMETRE_DETAIL P
		WHERE B.CODE_POSTE = R.RUBR_ETAT_CODE 
			AND DB.ID_BILAN= B.ID_BILAN
			AND B.ID_PARAMETRE_DETAIL= P.ID_PARAMETRE_DETAIL
			AND P.ID_PARAMETRE IN (SELECT [ID_PARAMETRE] FROM [ANAFI_PARAMETRE] where [ID_DOSSIER]=@id_dossier )
			AND B.CODE_POSTE=@code_poste  
			AND RUBR_ETAT_TYPE='BIA'
			AND TYPE_ANAFI_A=@type_Anafi
		--ORDER BY RUBR_PERCENT,DATE_CLOTURE
		ORDER BY RUBR_PERCENT,RIGHT(ANNEE_DETAIL, 4)

END

IF @bloc=12
BEGIN
 --Afficher compte resultat


		SELECT CR.CODE_POSTE,RUBR_ETAT_LIBELLE,ANNEE_CR_DETAIL,VALEUR_CR_DETAIL,RUBR_ETAT_TYPE,RUBR_TYPE_DETAIL_VALEUR,RUBR_ETAT_SENS,RUBR_ETAT_CR,RUBR_TYPE_DETAIL_VALEUR,MODE,RUBR_PERCENT,TYPE_ANAFI_A
		FROM ANAFI_COMPTE_RESULTAT CR,ANAFI_COMPTE_RESULTAT_DETAIL DCR, ANFI_RUBRIQUE_ETAT R, ANAFI_PARAMETRE_DETAIL P
		WHERE CR.CODE_POSTE = R.RUBR_ETAT_CODE 
			AND DCR.ID_COMPTE_RESULTAT= CR.ID_COMPTE_RESULTAT
			AND CR.ID_PARAMETRE_DETAIL= P.ID_PARAMETRE_DETAIL
			AND P.ID_PARAMETRE IN (SELECT [ID_PARAMETRE] FROM [ANAFI_PARAMETRE] where [ID_DOSSIER]=@id_dossier)
			AND CR.CODE_POSTE=@code_poste 
			AND RUBR_ETAT_TYPE='CRA'
			AND TYPE_ANAFI_A=@type_Anafi
		--ORDER BY RUBR_PERCENT,DATE_CLOTURE
		ORDER BY RUBR_PERCENT,RIGHT(ANNEE_DETAIL, 4)

END

IF @bloc=13
BEGIN

 --Afficher autre RATIO
		SELECT AUT.CODE_POSTE_AUTRE_RATIO,RUBR_ETAT_LIBELLE,ANNEE_AUTRE_RAT_DETAIL,VALEUR_AUTRE_RAT_DETAIL,RUBR_ETAT_TYPE,RUBR_TYPE_DETAIL_VALEUR,RUBR_ETAT_SENS,RUBR_ETAT_CR,RUBR_TYPE_DETAIL_VALEUR,MODE,RUBR_PERCENT,TYPE_ANAFI_A,VALEUR_AUTRE_RAT_AFF_DETAIL
		FROM ANAFI_AUTRE_RATIO AUT,ANAFI_AUTRE_RATIO_DETAIL DRAT, ANFI_RUBRIQUE_ETAT R, ANAFI_PARAMETRE_DETAIL P
		WHERE AUT.CODE_POSTE_AUTRE_RATIO = R.RUBR_ETAT_CODE 
			AND DRAT.ID_AUTRE_RATIO= AUT.ID_AUTRE_RATIO
			AND AUT.ID_PARAMETRE_DETAIL= P.ID_PARAMETRE_DETAIL
			AND P.ID_PARAMETRE IN (SELECT [ID_PARAMETRE] FROM [ANAFI_PARAMETRE] where [ID_DOSSIER]=@id_dossier)
			AND AUT.CODE_POSTE_AUTRE_RATIO=@code_poste  
			AND RUBR_ETAT_TYPE='AUT'
			AND TYPE_ANAFI_A=@type_Anafi  
	--ORDER BY RUBR_PERCENT,DATE_CLOTURE
		ORDER BY RUBR_PERCENT,RIGHT(ANNEE_DETAIL, 4)
 

END
END













GO

