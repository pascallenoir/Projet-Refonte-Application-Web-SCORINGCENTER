USE [WEB_BILAN_DB]
GO

/****** Object:  StoredProcedure [dbo].[PS_VSCOR_CONNEXION]    Script Date: 03/03/2023 00:48:37 ******/
DROP PROCEDURE [dbo].[PS_VSCOR_CONNEXION]
GO

/****** Object:  StoredProcedure [dbo].[PS_VSCOR_CONNEXION]    Script Date: 03/03/2023 00:48:37 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[PS_VSCOR_CONNEXION]
@bloc INT,
@login_user as varchar(35),
@password_user as varchar(35),
@date_user as datetime,
@code_agence as CHAR(10)

AS
BEGIN
IF @bloc=-1
	BEGIN
	select * from
	SCOR_AGENCE,
	SCOR_UTILISATEUR
	END
IF @bloc=0
	BEGIN
		EXEC PS_SCOR_UTILISATEUR
		@bloc = 6,
		@id_user='',
		@id_profil='',
		@code_agence = '',
		@nom_user = '',
		@prenom_user = '',
		@email_user = '',
		@login_user = @login_user,
		@password_user = @password_user,
		@date_user = @date_user,
		@statut_user = 1,
		@suphierarchique = ''
	END
	IF @bloc=1
	BEGIN
		EXEC PS_SCOR_AGENCE
		@bloc = 4,
		@code_agence = @code_agence,
		@code_banque = N'1',
		@nom_agence = N'1',
		@guichet_agence=N'1'
	END

END






GO

