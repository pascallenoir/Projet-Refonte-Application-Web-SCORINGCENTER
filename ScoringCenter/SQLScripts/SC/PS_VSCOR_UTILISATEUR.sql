USE [ScoringDB]
GO

/****** Object:  StoredProcedure [dbo].[PS_VSCOR_UTILISATEUR]    Script Date: 28/02/2023 21:09:18 ******/
DROP PROCEDURE [dbo].[PS_VSCOR_UTILISATEUR]
GO

/****** Object:  StoredProcedure [dbo].[PS_VSCOR_UTILISATEUR]    Script Date: 28/02/2023 21:09:18 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[PS_VSCOR_UTILISATEUR]
@bloc int,
@id_user as char(6),
@id_profil as char(8),
@code_agence as char(10),
@nom_user as varchar(35),
@prenom_user as varchar(60),
@email_user as varchar(60),
@login_user as varchar(35),
@password_user as varchar(35),
@date_user as datetime,
@statut_user as bit,
@code_banque as char(5),
@nom_agence as varchar(60),
@suphierarchique as varchar(6)
AS
BEGIN
	IF @bloc = -1
	BEGIN
		SELECT * FROM SCOR_UTILISATEUR, SCOR_AGENCE, SCOR_PROFIL, SCOR_BANQUE
	END
	--SELECTION UTILISATEUR SELON LE CODE BANQUE--
	IF @bloc = 0
	BEGIN
		SELECT SU.NOM_USER, SU.PRENOM_USER, SU.LOGIN_USER, SU.PASSWORD_USER, SU.STATUT_USER, 
		SP.LIBELLE_PROFIL,SP.ID_PROFIL, SU.EMAIL_USER, SA.NOM_AGENCE, SU.ID_USER,SP.CODE_BANQUE, SU.PARENT_SUPP
		FROM SCOR_UTILISATEUR SU, SCOR_PROFIL SP, SCOR_AGENCE SA
		WHERE SU.CODE_AGENCE = SA.CODE_AGENCE AND SU.ID_PROFIL = SP.ID_PROFIL and SP.LIBELLE_PROFIL NOT LIKE '%20CBS08%'
		AND SP.CODE_BANQUE = @code_banque ORDER BY SU.NOM_USER ASC
	END
	--RECHERCHE AGENCE--
	IF @bloc = 1
	BEGIN
		SELECT CODE_AGENCE, NOM_AGENCE FROM SCOR_AGENCE WHERE NOM_AGENCE LIKE '%'+@nom_agence+'%'
		AND CODE_BANQUE = @code_banque
	END
	--RECHERCHE PROFIL--
	IF @bloc = 2
	BEGIN
		SELECT ID_PROFIL, LIBELLE_PROFIL FROM SCOR_PROFIL WHERE CODE_BANQUE = @code_banque
	END
	--SELECTION MAX ID UTILISATEUR--
	IF @bloc = 3
	BEGIN
		SELECT ISNULL(MAX(ID_USER), 0) ID_USER FROM SCOR_UTILISATEUR
	END
	--INSERTION UTILISATEUR--
	IF @bloc = 4
	BEGIN
	declare @id_usera int =0
	SELECT @id_usera= MAX(CONVERT(bigint,ID_USER)) FROM SCOR_UTILISATEUR
	if @id_usera is null begin set @id_usera=0 end
	set @id_usera=@id_usera+1
	--select @id_usera
		EXEC PS_SCOR_UTILISATEUR
		@bloc = 0, @id_user = @id_usera, @id_profil = @id_profil,
		@code_agence = @code_agence, @nom_user = @nom_user,
		@prenom_user = @prenom_user, @email_user = @email_user,
		@login_user = @login_user, @password_user = @password_user,
		@date_user = @date_user, @statut_user = @statut_user,
		@suphierarchique = @suphierarchique
	END
	--MODIFICATION UTILISATEUR--
	IF @bloc = 5
	BEGIN
		EXEC PS_SCOR_UTILISATEUR
		@bloc = 1, @id_user = @id_user, @id_profil = @id_profil,
		@code_agence = @code_agence, @nom_user = @nom_user,
		@prenom_user = @prenom_user, @email_user = @email_user,
		@login_user = @login_user, @password_user = @password_user,
		@date_user = @date_user, @statut_user = @statut_user,
		@suphierarchique = @suphierarchique
	END
	--SUPPRESSION UTILISATEUR--
	IF @bloc = 6
	BEGIN
		EXEC PS_SCOR_UTILISATEUR
		@bloc = 4, @id_user = @id_user, @id_profil = @id_profil,
		@code_agence = '', @nom_user = '', @prenom_user = '', @email_user = '',
		@login_user = '', @password_user = '', @date_user = @date_user, @statut_user = '',
		@suphierarchique = @suphierarchique
	END
	--SELECTION UTILISATEUR PAR RAPPORT AU LOGIN, ID ET AU CODE BANQUE--
	IF @bloc=7
	BEGIN
		SELECT SU.ID_USER, SU.NOM_USER, SU.EMAIL_USER
		FROM SCOR_UTILISATEUR SU, SCOR_AGENCE SA WHERE SU.CODE_AGENCE = SA.CODE_AGENCE
		AND SU.LOGIN_USER = @login_user AND SA.CODE_BANQUE = @code_banque
	END
	--SELECTION CODE AGENCE SELON LE NOM--
	IF @bloc=8
	BEGIN
		SELECT CODE_AGENCE
		FROM SCOR_AGENCE WHERE NOM_AGENCE = @nom_agence
	END

	IF @bloc = 9	/* Modification du mot de passe */
	BEGIN
		UPDATE SCOR_UTILISATEUR SET
			PASSWORD_USER=@password_user
			,PCHNG='XOX1656H'
			WHERE LOGIN_USER = @login_user
	END
	if @bloc=10
	begin
		EXEC PS_SCOR_UTILISATEUR
		@bloc = 5, @id_user = @id_user, @id_profil = '',
		@code_agence = '', @nom_user = '', @prenom_user = '', @email_user = '',
		@login_user = '', @password_user = '', @date_user = @date_user, @statut_user = '',
		@suphierarchique = ''
	end

	--SELECTION UTILISATEURS ACTIFS  SELON LE CODE BANQUE--
	IF @bloc = 11
	BEGIN
		SELECT SU.NOM_USER, SU.PRENOM_USER, SU.LOGIN_USER, SU.STATUT_USER,
		SP.LIBELLE_PROFIL,SP.ID_PROFIL, SU.EMAIL_USER, SA.NOM_AGENCE, SU.ID_USER,SP.CODE_BANQUE,SA.CODE_AGENCE, SU.PARENT_SUPP,
		SB.NOM_BANQUE, SB.SIGLE_BANQUE, SB.PAYS_CODE
		FROM SCOR_UTILISATEUR SU, SCOR_PROFIL SP, SCOR_AGENCE SA, SCOR_BANQUE SB
		WHERE SU.CODE_AGENCE = SA.CODE_AGENCE AND SU.ID_PROFIL = SP.ID_PROFIL and SP.LIBELLE_PROFIL NOT LIKE '%20CBS08%'
		AND SP.CODE_BANQUE = SA.CODE_BANQUE AND SB.CODE_BANQUE = SA.CODE_BANQUE
		AND SU.STATUT_USER='1' ORDER BY SU.NOM_USER ASC
	END

	--SELECTION UTILISATEURS DESACTIFS  SELON LE CODE BANQUE--
	IF @bloc = 12
	BEGIN
		SELECT SU.NOM_USER, SU.PRENOM_USER, SU.LOGIN_USER, SU.STATUT_USER, 
		SP.LIBELLE_PROFIL,SP.ID_PROFIL, SU.EMAIL_USER, SA.NOM_AGENCE, SU.ID_USER,SP.CODE_BANQUE,SA.CODE_AGENCE, SU.PARENT_SUPP,
		SB.NOM_BANQUE, SB.SIGLE_BANQUE, SB.PAYS_CODE
		FROM SCOR_UTILISATEUR SU, SCOR_PROFIL SP, SCOR_AGENCE SA, SCOR_BANQUE SB
		WHERE SU.CODE_AGENCE = SA.CODE_AGENCE AND SU.ID_PROFIL = SP.ID_PROFIL and SP.LIBELLE_PROFIL NOT LIKE '%20CBS08%'
		AND SP.CODE_BANQUE = SA.CODE_BANQUE AND SB.CODE_BANQUE = SA.CODE_BANQUE
		AND SU.STATUT_USER='0' ORDER BY SU.NOM_USER ASC
	END

	--SELECTION UTILISATEUR PAR RAPPORT AU LOGIN--
	IF @bloc=13
	BEGIN
		SELECT * FROM SCOR_UTILISATEUR WHERE LOGIN_USER = @login_user
	END
END





GO

