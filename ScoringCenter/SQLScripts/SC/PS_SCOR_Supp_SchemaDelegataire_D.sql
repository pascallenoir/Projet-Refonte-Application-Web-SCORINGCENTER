﻿USE [ScoringDB]
GO
DROP procedure PS_SCOR_Supp_SchemaDelegataire_D
GO
CREATE Procedure [dbo].[PS_SCOR_Supp_SchemaDelegataire_D]
@CODE_BANQUE varchar(50)
As
Begin

	--DECLARE @ID_SCOR_DELEGATION table
	--( ID_SCOR_DELEGATION int )
	SELECT ID_SCOR_DELEGATION into ##ID_SCOR_DELEGATION FROM SCOR_DELEGUER
	WHERE CODE_AGENCE IN( SELECT CODE_AGENCE FROM SCOR_AGENCE WHERE CODE_BANQUE=LTRIM(RTRIM(@CODE_BANQUE)))

	--DELETE FROM SCOR_DELEGUER
	--WHERE CODE_AGENCE IN( SELECT CODE_AGENCE FROM SCOR_AGENCE WHERE CODE_BANQUE=@CODE_BANQUE)

	UPDATE SCOR_DELEGUER 
	SET ACTIF = 'I' 
	WHERE CODE_AGENCE IN( SELECT CODE_AGENCE FROM SCOR_AGENCE WHERE CODE_BANQUE=@CODE_BANQUE)

	SELECT ID_SCOR_SEUIL_DELEGUATION into ##ID_SCOR_SEUIL_DELEGUATION FROM SCOR_DELEGATION
	WHERE ID_SCOR_DELEGATION in (SELECT ID_SCOR_DELEGATION from ##ID_SCOR_DELEGATION)

	--DELETE FROM SCOR_DELEGATION
	--WHERE ID_SCOR_DELEGATION in (SELECT ID_SCOR_DELEGATION from ##ID_SCOR_DELEGATION)

	UPDATE SCOR_DELEGATION 
	SET ACTIF = 'I' 
	WHERE ID_SCOR_DELEGATION in (SELECT ID_SCOR_DELEGATION from ##ID_SCOR_DELEGATION)

	--DELETE FROM SCOR_DOSSIER_SEUIL_CREDIT

	UPDATE SCOR_DOSSIER_SEUIL_CREDIT
	SET ACTIF = 'I'
	WHERE ID_SCOR_SEUIL_DELEGUATION in (SELECT ID_SCOR_SEUIL_DELEGUATION from ##ID_SCOR_SEUIL_DELEGUATION)

	--DELETE FROM SCOR_SEUIL_DELEGUATION
	--WHERE ID_SCOR_SEUIL_DELEGUATION in (SELECT ID_SCOR_SEUIL_DELEGUATION from ##ID_SCOR_SEUIL_DELEGUATION)
	
	UPDATE SCOR_SEUIL_DELEGUATION
	SET ACTIF = 'I'
	--WHERE ID_SCOR_SEUIL_DELEGUATION in (SELECT ID_SCOR_SEUIL_DELEGUATION from ##ID_SCOR_SEUIL_DELEGUATION)
	WHERE CODE_BANQUE = LTRIM(RTRIM(@CODE_BANQUE))
	
	--BEGIN TRY
	--	DELETE FROM SCOR_SEUIL_DELEGUATION
	--END TRY
	--BEGIN CATCH
	--		DECLARE @decideur int =1
	--END CATCH;
	  
	
	--BEGIN TRY
	--	DELETE FROM SCOR_SEUIL_DELEGUATION
	--END TRY
	--BEGIN CATCH
	--		DECLARE @decideur int =1
	--END CATCH;

	----DECLARE @ID_SCOR_DELEGATION table
	----( ID_SCOR_DELEGATION int )
	--SELECT ID_SCOR_DELEGATION into ##ID_SCOR_DELEGATION FROM SCOR_DELEGUER
	--WHERE CODE_AGENCE IN( SELECT CODE_AGENCE FROM SCOR_AGENCE WHERE CODE_BANQUE=@CODE_BANQUE)

	--DELETE FROM SCOR_DELEGUER
 --   WHERE CODE_AGENCE IN( SELECT CODE_AGENCE FROM SCOR_AGENCE WHERE CODE_BANQUE=@CODE_BANQUE)

	--SELECT ID_SCOR_SEUIL_DELEGUATION into ##ID_SCOR_SEUIL_DELEGUATION FROM SCOR_DELEGATION
	--WHERE ID_SCOR_DELEGATION in (SELECT ID_SCOR_DELEGATION from ##ID_SCOR_DELEGATION)

	--DELETE FROM SCOR_DELEGATION
	--WHERE ID_SCOR_DELEGATION in (SELECT ID_SCOR_DELEGATION from ##ID_SCOR_DELEGATION)

	--DELETE FROM SCOR_DOSSIER_SEUIL_CREDIT

	----DELETE FROM SCOR_SEUIL_DELEGUATION
 --   --WHERE 
	----ID_SCOR_SEUIL_DELEGUATION in (SELECT ID_SCOR_SEUIL_DELEGUATION from ##ID_SCOR_SEUIL_DELEGUATION)

	--BEGIN TRY
	--	--DELETE FROM SCOR_SEUIL_DELEGUATION
	--	DELETE FROM SCOR_SEUIL_DELEGUATION
	--	--WHERE ID_SCOR_SEUIL_DELEGUATION in (SELECT ID_SCOR_SEUIL_DELEGUATION from ##ID_SCOR_SEUIL_DELEGUATION)
	--	WHERE CODE_BANQUE = RTRIM(LTRIM(@CODE_BANQUE))
	--END TRY
	--BEGIN CATCH
	--	DECLARE @decideur int =1
	--END CATCH;  

End
