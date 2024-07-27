USE [WEB_BILAN_DB]
GO

/****** Object:  StoredProcedure [dbo].[PS_SCOR_UTILISATEUR]    Script Date: 03/03/2023 00:48:05 ******/
DROP PROCEDURE [dbo].[PS_SCOR_UTILISATEUR]
GO

/****** Object:  StoredProcedure [dbo].[PS_SCOR_UTILISATEUR]    Script Date: 03/03/2023 00:48:05 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[PS_SCOR_UTILISATEUR] 
@bloc INT,
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
@suphierarchique varchar(6)
AS
BEGIN
/* INSERTION */
	IF @bloc = 0
	BEGIN
		INSERT INTO SCOR_UTILISATEUR(ID_USER, ID_PROFIL, CODE_AGENCE, NOM_USER, PRENOM_USER, 
		EMAIL_USER, LOGIN_USER, PASSWORD_USER, DATE_USER, STATUT_USER,PARENT_SUPP)
		VALUES(@id_user, @id_profil, @code_agence, @nom_user, @prenom_user, @email_user, 
			@login_user, @password_user, @date_user, @statut_user,@suphierarchique)
	END
/* MODIFICATION */
	IF @bloc = 1
	BEGIN
		UPDATE SCOR_UTILISATEUR SET
			ID_PROFIL=@id_profil,
			NOM_USER=@nom_user,
			PRENOM_USER=@prenom_user,
			EMAIL_USER=@email_user,
			LOGIN_USER=@login_user,
			PASSWORD_USER=@password_user, 
			STATUT_USER = @statut_user,
			PCHNG ='XOX1649H',
			PARENT_SUPP=@suphierarchique
			WHERE ID_USER = @id_user;
	END
	IF @bloc = 2	/* Modification du mot de passe */
	BEGIN
		UPDATE SCOR_UTILISATEUR SET
			PASSWORD_USER=@password_user
			WHERE ID_USER = @id_user;
	END
	IF @bloc = 3	/* Modification de l'état(actif ou inactif) */
	BEGIN
		UPDATE SCOR_UTILISATEUR SET
			STATUT_USER=@statut_user
			WHERE ID_USER = @id_user;
	END
/* SUPPRESSION */
	IF @bloc = 4
	BEGIN
		DELETE FROM SCOR_UTILISATEUR WHERE ID_USER = @id_user
	END
/* SELECTION */
	IF @bloc = 5
	BEGIN
		SELECT * FROM SCOR_UTILISATEUR  WHERE ID_USER = @id_user
	END
	IF @bloc = 6 /* Authentification */
	BEGIN
		SELECT * FROM SCOR_UTILISATEUR
		WHERE LOGIN_USER=@login_user AND PASSWORD_USER=@password_user AND STATUT_USER=@statut_user 
	END
	/* LISTE */
	IF @bloc = 7
	BEGIN
		SELECT * FROM SCOR_UTILISATEUR
	END
END






GO

