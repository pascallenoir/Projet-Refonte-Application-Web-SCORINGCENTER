USE [ScoringDB]
GO

/****** Object:  StoredProcedure [dbo].[PS_VSCOR_AUTREDOSSIER]    Script Date: 13/03/2023 03:16:58 ******/
DROP PROCEDURE [dbo].[PS_VSCOR_AUTREDOSSIER]
GO

/****** Object:  StoredProcedure [dbo].[PS_VSCOR_AUTREDOSSIER]    Script Date: 13/03/2023 03:16:58 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[PS_VSCOR_AUTREDOSSIER]
@bloc INT,
@code_banque as CHAR(5),
@code_agence as CHAR(10),
@id_scoring as varchar(12),
@etciv_nomreduit as varchar(60),
@mois_arrete as datetime,
@etciv_matricule as varchar(12)
AS
BEGIN
	IF @bloc=-1
	BEGIN
		Select * from
		SCOR_BANQUE,
		SCOR_AGENCE,
		SCOR_CONTREPARTIE,
		SCOR_DOSSIER
	END

	IF @bloc=0
	BEGIN
		EXEC PS_SCOR_AGENCE
		@bloc = 6,
		@code_agence = N'1',
		@code_banque = @code_banque,
		@nom_agence = N'1',
		@guichet_agence=N'1'
	END

	IF @bloc=1
	BEGIN
	IF @etciv_nomreduit<>''
		begin
		EXEC PS_SCOR_CONTREPARTIE
		@Bloc = 6,
		@id_scoring = N'1',
		@code_agence = @code_agence,
		@etciv_matricule = N'1',
		@etciv_nomreduit = @etciv_nomreduit,
		@etciv_adresse = N'1',
		@etciv_ville_residence = N'1',
		@rccm = N'1',
		@segment_client = N'1',
		@mois_arrete = @mois_arrete,
		@mode_analyse = N'1',
		@unite = N'1',
		@devise = N'1',
		@ca = 1,
		@pays= N'1',
		@statut= N'1',
		@activite_bceao= N'1',
		@secteur_d_activite= N'1',
		@code_banque = @code_banque
		end
	IF @id_scoring<>'' or @etciv_matricule<>''
		begin
		EXEC PS_SCOR_CONTREPARTIE
		@Bloc = 7,
		@id_scoring = @id_scoring,
		@code_agence = @code_agence,
		@etciv_matricule = @etciv_matricule,
		@etciv_nomreduit = N'1',
		@etciv_adresse = N'1',
		@etciv_ville_residence = N'1',
		@rccm = N'1',
		@segment_client = N'1',
		@mois_arrete = @mois_arrete,
		@mode_analyse = N'1',
		@unite = N'1',
		@devise = N'1',
		@ca = 1,
		@pays= N'1',
		@statut= N'1',
		@activite_bceao= N'1',
		@secteur_d_activite= N'1',
		@code_banque = @code_banque
		end
	IF @id_scoring='' AND @etciv_nomreduit=''
		begin
		EXEC PS_SCOR_CONTREPARTIE
		@Bloc = 8,
		@id_scoring =  N'1',
		@code_agence = @code_agence,
		@etciv_matricule = N'1',
		@etciv_nomreduit = N'1',
		@etciv_adresse = N'1',
		@etciv_ville_residence = N'1',
		@rccm = N'1',
		@segment_client = N'1',
		@mois_arrete = @mois_arrete,
		@mode_analyse = N'1',
		@unite = N'1',
		@devise = N'1',
		@ca = 1,
		@pays= N'1',
		@statut= N'1',
		@activite_bceao= N'1',
		@secteur_d_activite= N'1',
		@code_banque = @code_banque
		end

	END

	if @bloc=2
	begin
		EXEC PS_SCOR_AGENCE
		@bloc = 7,
		@code_agence = N'1',
		@code_banque = @code_banque,
		@nom_agence = N'1',
		@guichet_agence=N'1'
	end

	if @bloc=3
	begin
		EXEC PS_SCOR_BANQUE
		@bloc = 4,
		@code_banque = @code_banque,
		@nom_banque = N'1',
		@sigle_banque=N'1'
	end
END
GO

