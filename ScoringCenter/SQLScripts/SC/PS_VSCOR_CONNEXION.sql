USE [ScoringDB]
GO

/****** Object:  StoredProcedure [dbo].[PS_VSCOR_CONNEXION]    Script Date: 28/02/2023 21:06:44 ******/
DROP PROCEDURE [dbo].[PS_VSCOR_CONNEXION]
GO

/****** Object:  StoredProcedure [dbo].[PS_VSCOR_CONNEXION]    Script Date: 28/02/2023 21:06:44 ******/
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
				--declare @laledate varchar(20)
				--declare @Declenche varchar(20)
				--select @laledate=GETDATE()
				--SELECT @Declenche=DATEPART(hour,@laledate)
				--if Ltrim(rtrim(@Declenche))='16' or Ltrim(rtrim(@Declenche))='17' or Ltrim(rtrim(@Declenche))='18'
				--begin
				--EXEC	PS_CHARGEMENT_CSV_CONTREPARTIE
				--		@EmplacementFichier = N'C:\SCORING_REPRISE\SC_01.csv'
				--EXEC	[dbo].[PS_CHARGEMENT_CSV_TYPE_CREDIT]
				--		@EmplacementFichier = N'C:\SCORING_REPRISE\SC_TPCredit_03.csv'
				--EXEC	[dbo].[PS_CHARGEMENT_CSV_CMPT]
				--		@EmplacementFichier = N'C:\SCORING_REPRISE\SC_Compte_02.csv'
				--EXEC	[dbo].[PS_CHARGEMENT_CSV_SC_CREDIT]
				--		@EmplacementFichier = N'C:\SCORING_REPRISE\SC_Credit_05.csv'
				--EXEC	[dbo].[PS_CHARGEMENT_CSV_SC_DECOUVERT]
				--		@EmplacementFichier = N'C:\SCORING_REPRISE\SC_Decouvert_04.csv'

				--end

			--BEGIN TRY
			--	EXEC PS_CHARGEMENT_SANS_CSV_CONTREPARTIE
			--	--@EmplacementFichier = N'C:\SCORING_REPRISE\SC_01.csv'
			--	----GO
			--	--EXEC [dbo].[PS_CHARGEMENT_CSV_ENCOURSBMS]
			--	--@EmplacementFichier = N'C:\SCORING_REPRISE\Modèle encours données comptable 0309.csv'
			--	----GO
			--END TRY
			--BEGIN CATCH
			--	 --set @decideur =1
			--END CATCH;
				

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

