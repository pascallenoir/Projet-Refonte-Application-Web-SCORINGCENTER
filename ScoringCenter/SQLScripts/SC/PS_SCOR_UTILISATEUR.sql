USE [ScoringDB]
GO

/****** Object:  StoredProcedure [dbo].[PS_SCOR_UTILISATEUR]    Script Date: 28/02/2023 21:11:01 ******/
DROP PROCEDURE [dbo].[PS_SCOR_UTILISATEUR]
GO

/****** Object:  StoredProcedure [dbo].[PS_SCOR_UTILISATEUR]    Script Date: 28/02/2023 21:11:01 ******/
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
		EMAIL_USER, LOGIN_USER, PASSWORD_USER, PCHNG, DATE_USER, STATUT_USER,PARENT_SUPP)
		VALUES(@id_user, @id_profil, @code_agence, @nom_user, @prenom_user, @email_user, 
			@login_user, @password_user, 'XOX1649H', @date_user, @statut_user,@suphierarchique)
	END
/* MODIFICATION */
	IF @bloc = 1
	BEGIN
		declare @pchng varchar(50) = ''
		if @password_user <> '' 
		begin
			update SCOR_UTILISATEUR set PASSWORD_USER = @password_user where ID_USER = @id_user
			set @pchng = 'XOX1649H'
		end
		else begin set @pchng = 'XOX1656H' end

		UPDATE SCOR_UTILISATEUR SET
			ID_PROFIL = @id_profil,
			CODE_AGENCE = @code_agence,
			NOM_USER = @nom_user,
			PRENOM_USER = @prenom_user,
			EMAIL_USER = @email_user,
			LOGIN_USER = @login_user,
			STATUT_USER = @statut_user,
			PCHNG = @pchng,
			PARENT_SUPP = @suphierarchique
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
		SELECT [ID_USER]
      ,[ID_PROFIL]
      ,U.[CODE_AGENCE]
      ,[NOM_USER]
      ,[PRENOM_USER]
      ,[EMAIL_USER]
      ,[LOGIN_USER]
      ,[PASSWORD_USER]
      ,[DATE_USER]
      ,[STATUT_USER]
      ,[PARENT_SUPP]
      ,[PCHNG]
	  ,[CODE_BANQUE]
      ,[NOM_AGENCE]
      ,[GUICHET_AGENCE]
	   FROM SCOR_UTILISATEUR U,SCOR_AGENCE A  WHERE LTRIM(RTRIM(U.CODE_AGENCE))=LTRIM(RTRIM(A.CODE_AGENCE)) AND ID_USER = @id_user
	END
	IF @bloc = 6 /* Authentification */
	BEGIN
		SELECT * FROM SCOR_UTILISATEUR
		WHERE LOGIN_USER=@login_user 
		AND PASSWORD_USER=@password_user 
		AND STATUT_USER=@statut_user 
	END
	/* LISTE */
	IF @bloc = 7
	BEGIN
		SELECT * FROM SCOR_UTILISATEUR
	END
END







GO

