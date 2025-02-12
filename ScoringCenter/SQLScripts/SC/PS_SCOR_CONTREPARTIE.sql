USE [ScoringDB]
GO

/****** Object:  StoredProcedure [dbo].[PS_SCOR_CONTREPARTIE]    Script Date: 13/03/2023 03:16:02 ******/
DROP PROCEDURE [dbo].[PS_SCOR_CONTREPARTIE]
GO

/****** Object:  StoredProcedure [dbo].[PS_SCOR_CONTREPARTIE]    Script Date: 13/03/2023 03:16:02 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[PS_SCOR_CONTREPARTIE]
@Bloc int,
@id_scoring as varchar(12),
@code_agence as char(10),
@etciv_matricule as varchar(12),
@etciv_nomreduit as varchar(60),
@etciv_adresse as varchar(35),
@etciv_ville_residence as varchar(35),
@rccm as char(15),
@segment_client as varchar(35),
@mois_arrete datetime,
@mode_analyse as varchar(35),
@unite as char(15),
@devise as char(15),
@ca decimal,
@pays as varchar(35),
@statut as varchar(120),
@activite_bceao as  varchar(45),
@secteur_d_activite as   varchar(45),
@code_banque AS CHAR(5) = ''
      
AS
BEGIN

	--INSERTION CONTREPARTIE--
	IF @bloc=0
	BEGIN
	 INSERT INTO SCOR_CONTREPARTIE
			   (ID_SCORING
			   ,CODE_AGENCE
			   ,ETCIV_MATRICULE
			   ,ETCIV_NOMREDUIT
			   ,ETCIV_ADRESSE
			   ,ETCIV_VILLE_RESIDENCE
			   ,RCCM
			   ,SEGMENT_CLIENT
			   ,MOIS_ARRETE
			   ,MODE_ANALYSE
			   ,UNITE
			   ,DEVISE
			   ,CA
			   ,PAYS
			   ,STATUT
			   ,ACTIVITE_BCEAO
			   ,SECTEUR_D_ACTIVITE)
		 VALUES
			   (@id_scoring,
				@code_agence,
				@etciv_matricule,
				@etciv_nomreduit,
				@etciv_adresse,
				@etciv_ville_residence,
				@rccm,
				@segment_client,
				@mois_arrete,
				@mode_analyse,
				@unite,
				@devise,
				@ca,
				@pays,
				@statut,
				@activite_bceao,
				@secteur_d_activite)

	END
	--MODIFICATION CONTREPARTIE--
	IF @bloc=1
	BEGIN
	UPDATE SCOR_CONTREPARTIE  
	SET
				CODE_AGENCE=@code_agence
			   ,ETCIV_MATRICULE=@etciv_matricule
			   ,ETCIV_NOMREDUIT=@etciv_nomreduit
			   ,ETCIV_ADRESSE=@etciv_adresse
			   ,ETCIV_VILLE_RESIDENCE=@etciv_ville_residence
			   ,RCCM=@rccm
			   ,SEGMENT_CLIENT=@segment_client
			   ,MOIS_ARRETE=@mois_arrete
			   ,MODE_ANALYSE=@mode_analyse
			   ,UNITE=@unite
			   ,DEVISE=@devise
			   ,CA=ca
			   ,PAYS=@pays
			   ,STATUT=@statut
			   ,ACTIVITE_BCEAO=@activite_bceao
			   ,SECTEUR_D_ACTIVITE=@secteur_d_activite
			WHERE ID_SCORING  = @id_scoring   
	END
	--SUPPRESSION CONTREPARTIE--
	IF @bloc=2
	BEGIN
	DELETE FROM SCOR_CONTREPARTIE  
	WHERE ID_SCORING  = @id_scoring  
	END
	--lISTE CONTREPARTIE--
	IF @bloc=3
	BEGIN
	SELECT ID_SCORING
		  ,CODE_AGENCE
		  ,ETCIV_MATRICULE
		  ,ETCIV_NOMREDUIT
		  ,ETCIV_ADRESSE
		  ,ETCIV_VILLE_RESIDENCE
		  ,RCCM
		  ,SEGMENT_CLIENT
		  ,MOIS_ARRETE
		  ,MODE_ANALYSE
		  ,UNITE
		  ,DEVISE
		  ,CA
		  ,PAYS
		  ,STATUT
		  ,ACTIVITE_BCEAO
		  ,SECTEUR_D_ACTIVITE
	  FROM SCOR_CONTREPARTIE
	END
	--SELECTION CONTREPARTIE--
	IF @bloc=4
	BEGIN
	SELECT ID_SCORING
		  ,CODE_AGENCE
		  ,ETCIV_MATRICULE
		  ,ETCIV_NOMREDUIT
		  ,ETCIV_ADRESSE
		  ,ETCIV_VILLE_RESIDENCE
		  ,RCCM
		  ,SEGMENT_CLIENT
		  ,MOIS_ARRETE
		  ,MODE_ANALYSE
		  ,UNITE
		  ,DEVISE
		  ,CA
		  ,PAYS
		  ,STATUT
		  ,ACTIVITE_BCEAO
		  ,SECTEUR_D_ACTIVITE
	  FROM SCOR_CONTREPARTIE
	WHERE ID_SCORING  = @id_scoring  
	END
	--SELECTION MAX CODE CONTREPARTIE--
	IF @bloc=5
	BEGIN
	SELECT MAX(ID_SCORING)
	  FROM SCOR_CONTREPARTIE
	END

	--SELECTION lISTE SPECIFIQUE CONTREPARTIE TRIE PAR CODE_AGENCE/ETCIV_NOMREDUIT--
	IF @bloc=6
	BEGIN
  
	  IF rtrim(ltrim(@code_agence))<>'Tous'
	  BEGIN
	  SELECT DISTINCT sc.ID_SCORING as ID_SCORING
		  ,CODE_AGENCE
		  ,ETCIV_MATRICULE
		  ,ETCIV_NOMREDUIT
		  ,ETCIV_ADRESSE
		  ,ETCIV_VILLE_RESIDENCE
		  ,RCCM
		  ,SEGMENT_CLIENT
		  ,MOIS_ARRETE
		  ,MODE_ANALYSE
		  ,UNITE
		  ,DEVISE
		  ,CA
		  ,PAYS
		  ,STATUT
		  ,ACTIVITE_BCEAO
		  ,SECTEUR_D_ACTIVITE
		  ,TYPE_ANAFI 
		  ,TYPE_PROSPECT
		  ,d.GROUPE_DOSSIER
	FROM SCOR_CONTREPARTIE sc, SCOR_DOSSIER d
	WHERE ETCIV_NOMREDUIT   LIKE '%' + @etciv_nomreduit + '%'  
	AND CODE_AGENCE   LIKE '%' + @code_agence + '%'  
	and d.ID_SCORING = sc.ID_SCORING
	--le dernier dossier uniquement
	and d.DATE_DOSSIER=(
			select top 1 SCOR_DOSSIER.DATE_DOSSIER
			from SCOR_DOSSIER
			where ID_SCORING=sc.ID_SCORING 
			order by SCOR_DOSSIER.DATE_DOSSIER desc)
	  END
	  ELSE
	  BEGIN
	  SELECT DISTINCT sc.ID_SCORING as ID_SCORING
		  ,sc.CODE_AGENCE
		  ,ETCIV_MATRICULE
		  ,ETCIV_NOMREDUIT
		  ,ETCIV_ADRESSE
		  ,ETCIV_VILLE_RESIDENCE
		  ,RCCM
		  ,SEGMENT_CLIENT
		  ,MOIS_ARRETE
		  ,MODE_ANALYSE
		  ,UNITE
		  ,DEVISE
		  ,CA
		  ,PAYS
		  ,STATUT
		  ,ACTIVITE_BCEAO
		  ,SECTEUR_D_ACTIVITE
		  ,TYPE_ANAFI 
		  ,TYPE_PROSPECT
		  ,d.GROUPE_DOSSIER
	FROM SCOR_CONTREPARTIE sc, SCOR_DOSSIER d, SCOR_AGENCE a
	WHERE ETCIV_NOMREDUIT   LIKE '%' + @etciv_nomreduit + '%'  
	and d.ID_SCORING = sc.ID_SCORING
	--le dernier dossier uniquement
	and d.DATE_DOSSIER=(
			select top 1 SCOR_DOSSIER.DATE_DOSSIER
			from SCOR_DOSSIER
			where ID_SCORING=sc.ID_SCORING 
			order by SCOR_DOSSIER.DATE_DOSSIER desc)
	and sc.CODE_AGENCE = a.CODE_AGENCE
	and a.CODE_BANQUE = @code_banque
	  END

	END
	--SELECTION lISTE SPECIFIQUE CONTREPARTIE TRIE PAR CODE_AGENCE/ID_SCORING--
	IF @bloc=7
	BEGIN
		
	IF rtrim(ltrim(@code_agence))<>'Tous'
	  BEGIN
		SELECT DISTINCT sc.ID_SCORING as ID_SCORING
		  ,CODE_AGENCE
		  ,ETCIV_MATRICULE
		  ,ETCIV_NOMREDUIT
		  ,ETCIV_ADRESSE
		  ,ETCIV_VILLE_RESIDENCE
		  ,RCCM
		  ,SEGMENT_CLIENT
		  ,MOIS_ARRETE
		  ,MODE_ANALYSE
		  ,UNITE
		  ,DEVISE
		  ,CA
		  ,PAYS
		  ,STATUT
		  ,ACTIVITE_BCEAO
		  ,SECTEUR_D_ACTIVITE
		  ,TYPE_ANAFI 
		  ,TYPE_PROSPECT
		  ,d.GROUPE_DOSSIER
	  FROM SCOR_CONTREPARTIE sc, SCOR_DOSSIER d
		WHERE (
		sc.ID_SCORING   LIKE '%' + Ltrim(Rtrim(@id_scoring)) + '%'
			AND CODE_AGENCE   LIKE '%' + Ltrim(Rtrim(@code_agence)) + '%' 
			and d.ID_SCORING = sc.ID_SCORING)
		or 
			(
			ETCIV_MATRICULE   LIKE '%' + Ltrim(Rtrim(@etciv_matricule)) + '%'
			AND CODE_AGENCE   LIKE '%' + Ltrim(Rtrim(@code_agence)) + '%' 
			and d.ID_SCORING = sc.ID_SCORING)
		--le dernier dossier uniquement
			and d.DATE_DOSSIER=(
			select top 1 SCOR_DOSSIER.DATE_DOSSIER
			from SCOR_DOSSIER
			where ID_SCORING=sc.ID_SCORING 
			order by SCOR_DOSSIER.DATE_DOSSIER desc)
	  END
	  ELSE
	  BEGIN
	  SELECT DISTINCT sc.ID_SCORING as ID_SCORING
		  ,sc.CODE_AGENCE
		  ,ETCIV_MATRICULE
		  ,ETCIV_NOMREDUIT
		  ,ETCIV_ADRESSE
		  ,ETCIV_VILLE_RESIDENCE
		  ,RCCM
		  ,SEGMENT_CLIENT
		  ,MOIS_ARRETE
		  ,MODE_ANALYSE
		  ,UNITE
		  ,DEVISE
		  ,CA
		  ,PAYS
		  ,STATUT
		  ,ACTIVITE_BCEAO
		  ,SECTEUR_D_ACTIVITE
		  ,TYPE_ANAFI 
		  ,TYPE_PROSPECT
		  ,d.GROUPE_DOSSIER
	  FROM SCOR_CONTREPARTIE sc, SCOR_DOSSIER d, SCOR_AGENCE a
		WHERE ((
		sc.ID_SCORING   LIKE '%' + Ltrim(Rtrim(@id_scoring)) + '%'
			and d.ID_SCORING = sc.ID_SCORING)
		or 
			(
			ETCIV_MATRICULE   LIKE '%' + Ltrim(Rtrim(@etciv_matricule)) + '%'
			and d.ID_SCORING = sc.ID_SCORING)
		--le dernier dossier uniquement
			and d.DATE_DOSSIER=(
			select top 1 SCOR_DOSSIER.DATE_DOSSIER
			from SCOR_DOSSIER
			where ID_SCORING=sc.ID_SCORING 
			order by SCOR_DOSSIER.DATE_DOSSIER desc))
		and sc.CODE_AGENCE = a.CODE_AGENCE
		and a.CODE_BANQUE = @code_banque
	  END

	END
	--SELECTION lISTE SPECIFIQUE CONTREPARTIE TRIE PAR CODE_AGENCE--
	IF @bloc=8
	BEGIN

	   IF rtrim(ltrim(@code_agence))<>'Tous'
	  BEGIN
	  SELECT DISTINCT sc.ID_SCORING as ID_SCORING
		  ,CODE_AGENCE
		  ,ETCIV_MATRICULE
		  ,ETCIV_NOMREDUIT
		  ,ETCIV_ADRESSE
		  ,ETCIV_VILLE_RESIDENCE
		  ,RCCM
		  ,SEGMENT_CLIENT
		  ,MOIS_ARRETE
		  ,MODE_ANALYSE
		  ,UNITE
		  ,DEVISE
		  ,CA
		  ,PAYS
		  ,STATUT
		  ,ACTIVITE_BCEAO
		  ,SECTEUR_D_ACTIVITE
		  ,TYPE_ANAFI 
		  ,TYPE_PROSPECT
		  ,d.GROUPE_DOSSIER
	  FROM SCOR_CONTREPARTIE sc, SCOR_DOSSIER d
	WHERE CODE_AGENCE   LIKE '%' + @code_agence + '%' 
	and sc.ID_SCORING = d.ID_SCORING
	 --le dernier dossier uniquement
	and d.DATE_DOSSIER=(
			select top 1 SCOR_DOSSIER.DATE_DOSSIER
			from SCOR_DOSSIER
			where ID_SCORING=sc.ID_SCORING 
			order by SCOR_DOSSIER.DATE_DOSSIER desc)
	  END
	  ELSE
	  BEGIN
	  SELECT DISTINCT sc.ID_SCORING as ID_SCORING
		  ,sc.CODE_AGENCE
		  ,ETCIV_MATRICULE
		  ,ETCIV_NOMREDUIT
		  ,ETCIV_ADRESSE
		  ,ETCIV_VILLE_RESIDENCE
		  ,RCCM
		  ,SEGMENT_CLIENT
		  ,MOIS_ARRETE
		  ,MODE_ANALYSE
		  ,UNITE
		  ,DEVISE
		  ,CA
		  ,PAYS
		  ,STATUT
		  ,ACTIVITE_BCEAO
		  ,SECTEUR_D_ACTIVITE
		  ,TYPE_ANAFI 
		  ,TYPE_PROSPECT
		  ,d.GROUPE_DOSSIER
	  FROM SCOR_CONTREPARTIE sc, SCOR_DOSSIER d, SCOR_AGENCE a
	WHERE sc.ID_SCORING = d.ID_SCORING
	 --le dernier dossier uniquement
	and d.DATE_DOSSIER=(
			select top 1 SCOR_DOSSIER.DATE_DOSSIER
			from SCOR_DOSSIER
			where ID_SCORING=sc.ID_SCORING 
			order by SCOR_DOSSIER.DATE_DOSSIER desc)
		and sc.CODE_AGENCE = a.CODE_AGENCE
		and a.CODE_BANQUE = @code_banque
	  END

	END

	if @bloc=9
			BEGIN
				SELECT S.ID_SCORING, S.ETCIV_MATRICULE, S.PAYS,
				 S.ETCIV_NOMREDUIT, S.ETCIV_ADRESSE ,S.ACTIVITE_BCEAO, SE.SECTACT_LIBELLE,
				S.ETCIV_VILLE_RESIDENCE, S.RCCM, SA.STATUT_LIBELLE, S.SEGMENT_CLIENT,
				A.NOM_AGENCE, SE.SECTACT_LIBELLE, SAB.ACTBCEAO_LIBELLE, S.MOIS_ARRETE, S.MODE_ANALYSE, MM.LIBELLE_MODELE,
				S.UNITE, S.DEVISE,S.CA,D.GROUPE_DOSSIER, D.ID_DOSSIER, D.NOTE_GROUPE, D.NOTE_PAYS, S.TYPE_ANAFI,S.TYPE_PROSPECT,SBA.BRANCH_ACT_LIBELLE
				,SBA.BRANCH_ACT_CODE,SAB.ACTBCEAO_CODE
				FROM SCOR_CONTREPARTIE S, SCOR_AGENCE A , SCOR_DOSSIER D,SCOR_SECTEUR_ACTIV SE, SCOR_STATUT SA,SCOR_ACTIVITE_BCEAO SAB, SCOR_BRANCHE_ACTIV SBA, SCOR_MODELE MM
				WHERE S.ID_SCORING = @id_scoring
				AND  ltrim(rtrim(S.CODE_AGENCE)) =  ltrim(rtrim(A.CODE_AGENCE))
				AND  ltrim(rtrim(S.ID_SCORING ))=  ltrim(rtrim(D.ID_SCORING))
				AND  ltrim(rtrim(S.STATUT))= ltrim(rtrim(SA.STATUT_CODE))
				AND ltrim(rtrim( S.SECTEUR_D_ACTIVITE))= ltrim(rtrim(SE.SECTACT_CODE))
				AND  ltrim(rtrim(S.ACTIVITE_BCEAO))= ltrim(rtrim(SAB.ACTBCEAO_CODE))
				and ltrim(rtrim( SE.BRANCH_ACT_CODE))= ltrim(rtrim(SBA.BRANCH_ACT_CODE))
				and  ltrim(rtrim(MM.CODE_MODELE))= ltrim(rtrim(S.MODE_ANALYSE))
			END
	if @bloc=10
			BEGIN
				--SELECT TOP 1 S.ID_SCORING, S.ETCIV_MATRICULE, S.PAYS,
				-- S.ETCIV_NOMREDUIT, S.ETCIV_ADRESSE ,S.ACTIVITE_BCEAO, SE.SECTACT_CODE,
				--S.ETCIV_VILLE_RESIDENCE, S.RCCM, SA.STATUT_LIBELLE, S.SEGMENT_CLIENT,
				--A.NOM_AGENCE, SE.SECTACT_LIBELLE,
				-- --SAB.ACTBCEAO_LIBELLE,
				-- S.SECTEUR_D_ACTIVITE ACTBCEAO_LIBELLE, S.MOIS_ARRETE, S.MODE_ANALYSE, MM.LIBELLE_MODELE,
				--S.UNITE, S.DEVISE,S.CA,D.GROUPE_DOSSIER, D.ID_DOSSIER, D.NOTE_GROUPE, D.NOTE_PAYS, S.TYPE_ANAFI,S.TYPE_PROSPECT,SBA.BRANCH_ACT_LIBELLE
				--,S.BRANCHE_ACTIVITE,SAB.ACTBCEAO_CODE
				--FROM SCOR_CONTREPARTIE S, SCOR_AGENCE A , SCOR_DOSSIER D,SCOR_SECTEUR_ACTIV SE, SCOR_STATUT SA,SCOR_ACTIVITE_BCEAO SAB, SCOR_BRANCHE_ACTIV SBA, SCOR_MODELE MM
				--WHERE S.ID_SCORING =@id_scoring
				--AND ltrim(rtrim(S.CODE_AGENCE)) = ltrim(rtrim(A.CODE_AGENCE))
				--AND ltrim(rtrim(S.ID_SCORING)) = ltrim(rtrim(D.ID_SCORING))
				--AND ltrim(rtrim(S.STATUT))=ltrim(rtrim(SA.STATUT_CODE))
				----AND ltrim(rtrim(S.SECTEUR_D_ACTIVITE))=ltrim(rtrim(SE.SECTACT_CODE))
				--AND ltrim(rtrim(S.ACTIVITE_BCEAO))=ltrim(rtrim(SAB.ACTBCEAO_CODE))
				--and ltrim(rtrim(SE.BRANCH_ACT_CODE))=ltrim(rtrim(SBA.BRANCH_ACT_CODE))
				--and ltrim(rtrim(MM.CODE_MODELE))=ltrim(rtrim(S.MODE_ANALYSE))
				--order by DATE_DOSSIER desc

				SELECT TOP 1 S.ID_SCORING, S.ETCIV_MATRICULE, S.PAYS,
				S.ETCIV_NOMREDUIT, S.ETCIV_ADRESSE, S.ACTIVITE_BCEAO, SE.SECTACT_CODE SECTACT_CODE, S.ETCIV_VILLE_RESIDENCE, 
				S.RCCM, SA.STATUT_LIBELLE, S.SEGMENT_CLIENT, A.CODE_AGENCE, A.CODE_BANQUE, A.NOM_AGENCE, SE.SECTACT_LIBELLE SECTACT_LIBELLE, 
				SAB.ACTBCEAO_LIBELLE, S.MOIS_ARRETE, S.MODE_ANALYSE, MM.LIBELLE_MODELE, S.UNITE, S.DEVISE,S.CA,D.GROUPE_DOSSIER, 
				D.ID_DOSSIER, D.NOTE_GROUPE, D.NOTE_PAYS, S.TYPE_ANAFI, S.TYPE_PROSPECT,SBA.BRANCH_ACT_LIBELLE, S.BRANCHE_ACTIVITE,SAB.ACTBCEAO_CODE
				FROM SCOR_CONTREPARTIE S, SCOR_AGENCE A, SCOR_DOSSIER D, SCOR_SECTEUR_ACTIV SE, 
				SCOR_STATUT SA, SCOR_ACTIVITE_BCEAO SAB, SCOR_BRANCHE_ACTIV SBA, SCOR_MODELE MM
				WHERE S.ID_SCORING = @id_scoring
				AND ltrim(rtrim(S.CODE_AGENCE)) = ltrim(rtrim(A.CODE_AGENCE))
				AND ltrim(rtrim(S.ID_SCORING)) = ltrim(rtrim(D.ID_SCORING))
				AND ltrim(rtrim(S.STATUT))=ltrim(rtrim(SA.STATUT_CODE))
				AND ltrim(rtrim(S.SECTEUR_D_ACTIVITE))=ltrim(rtrim(SE.SECTACT_CODE))
				AND ltrim(rtrim(S.ACTIVITE_BCEAO))=ltrim(rtrim(SAB.ACTBCEAO_CODE))
				and ltrim(rtrim(SE.BRANCH_ACT_CODE))=ltrim(rtrim(SBA.BRANCH_ACT_CODE))
				and ltrim(rtrim(MM.CODE_MODELE))=ltrim(rtrim(S.MODE_ANALYSE))
				order by DATE_DOSSIER desc

			END
	END

GO

