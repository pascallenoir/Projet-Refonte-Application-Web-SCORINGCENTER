USE [WEB_BILAN_DB]
GO

/****** Object:  StoredProcedure [dbo].[PS_BIL_RECHERCHE_CONTREPARTIE]    Script Date: 21/03/2023 11:24:25 ******/
DROP PROCEDURE [dbo].[PS_BIL_RECHERCHE_CONTREPARTIE]
GO

/****** Object:  StoredProcedure [dbo].[PS_BIL_RECHERCHE_CONTREPARTIE]    Script Date: 21/03/2023 11:24:25 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE procedure [dbo].[PS_BIL_RECHERCHE_CONTREPARTIE]
@BLOC INT,
@idFiscal varchar(15),
@RaisonSocial varchar(15),
@idBank varchar(15) 
AS 
BEGIN
	IF @BLOC = 0
	begin 
		select c.*, b.SIGLE_BANQUE, b.NOM_BANQUE ,'' IDENTIFIANTFISCAL_HANNA  from [dbo].[SCOR_CONTREPARTIE] c, [dbo].[SCOR_BANQUE] b
		where c.CODE_BANQUE=@idBank and c.CODE_BANQUE = b.CODE_BANQUE
	end
	IF @BLOC = 1
	begin
		select sc.[IDWEBBILAN]
      ,[ID_SCORING]
      ,[CODE_AGENCE]
      ,[ETCIV_MATRICULE]
      ,[ETCIV_NOMREDUIT]
      ,[ETCIV_ADRESSE]
      ,[ETCIV_VILLE_RESIDENCE]
      ,[RCCM]
      ,[ETCIV_MATRICULE] IDENTIFIANTFISCAL_HANNA
      ,[SEGMENT_CLIENT]
      ,[MOIS_ARRETE]
      ,[MODE_ANALYSE]
      ,[UNITE]
      ,[DEVISE]
      ,[CA]
      ,[PAYS]
      ,[STATUT]
      ,[ACTIVITE_BCEAO]
      ,[SECTEUR_D_ACTIVITE]
      ,[TYPE_ANAFI]
      ,[TYPE_PROSPECT]
      ,[BRANCHE_ACTIVITE]
      ,[CODE_BANQUE]
	   from SCOR_CONTREPARTIE sc   where ETCIV_NOMREDUIT like '%'+@RaisonSocial+'%'
		AND [ETCIV_MATRICULE] LIKE '%'+@idFiscal+'%'
		AND CODE_BANQUE=@idBank

	end
	IF @BLOC = 2
	--si le blok est trois on cherche l'id  de la contrepartie
	begin
		select sc.[IDWEBBILAN]
      ,[ID_SCORING]
      ,[CODE_AGENCE]
      ,[ETCIV_MATRICULE]
      ,[ETCIV_NOMREDUIT]
      ,[ETCIV_ADRESSE]
      ,[ETCIV_VILLE_RESIDENCE]
      ,EN.[RCCM]
      ,en.IDENTIFICATIONFISCALE 'IDENTIFIANTFISCAL_HANNA'
      ,[SEGMENT_CLIENT]
      ,[MOIS_ARRETE]
      ,[MODE_ANALYSE]
      ,[UNITE]
      ,[DEVISE]
      ,[CA]
      ,[PAYS]
      ,[STATUT]
      ,[ACTIVITE_BCEAO]
      ,[SECTEUR_D_ACTIVITE]
      ,[TYPE_ANAFI]
      ,[TYPE_PROSPECT]
      ,[BRANCHE_ACTIVITE]
      ,[CODE_BANQUE]
	   from SCOR_CONTREPARTIE sc join ENTREPRISE en
	   on SC.IDWEBBILAN=en.IDWEBBILAN   where  SC.[IDWEBBILAN]= @idFiscal
		--AND CODE_BANQUE=@idBank
	end

	-- récupérer les contreparties de toutes les banques 
	if @BLOC = 3
	begin
		select sc.[IDWEBBILAN]
      ,[ID_SCORING]
      ,[CODE_AGENCE]
      ,[ETCIV_MATRICULE]
      ,[ETCIV_NOMREDUIT]
      ,[ETCIV_ADRESSE]
      ,[ETCIV_VILLE_RESIDENCE]
      ,[RCCM]
      ,[ETCIV_MATRICULE] IDENTIFIANTFISCAL_HANNA
      ,[SEGMENT_CLIENT]
      ,[MOIS_ARRETE]
      ,[MODE_ANALYSE]
      ,[UNITE]
      ,[DEVISE]
      ,[CA]
      ,[PAYS]
      ,[STATUT]
      ,[ACTIVITE_BCEAO]
      ,[SECTEUR_D_ACTIVITE]
      ,[TYPE_ANAFI]
      ,[TYPE_PROSPECT]
      ,[BRANCHE_ACTIVITE]
      ,sc.[CODE_BANQUE]
	  ,b.SIGLE_BANQUE
	  ,b.NOM_BANQUE
	   from SCOR_CONTREPARTIE sc, SCOR_BANQUE b where ETCIV_NOMREDUIT like '%'+@RaisonSocial+'%'
		and [ETCIV_MATRICULE] LIKE '%'+@idFiscal+'%'
		and sc.CODE_BANQUE = b.CODE_BANQUE
	end
END

GO

