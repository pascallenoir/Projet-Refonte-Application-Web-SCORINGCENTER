USE [ScoringDB]
GO
if Object_id('PS_CHARG_CONTREPARTIE_INS','P') is not null 
Drop PROCEDURE PS_CHARG_CONTREPARTIE_INS
GO
Create PROCEDURE PS_CHARG_CONTREPARTIE_INS
	@block as int,
	@datechargement as datetime,
	@iduser as varchar(50),
	@CODE_AGENCE varchar(10) ,
	@MATRICULE varchar(20) ,
	@NOM varchar(max) ,
	@ADRESSE varchar(max) ,
	@VILLE_RESIDENCE varchar(max)  ,
	@RCCM varchar(max) ,
	@SEGMENT_CLIENT varchar(max)  ,
	@MOIS_ARRETE datetime ,
	@MODE_ANALYSE varchar(max)  ,
	@TYPE_ANAFI varchar(15) ,
	@UNITE varchar(15) ,
	@DEVISE varchar(15) ,
	@CA numeric,
	@PAYS varchar(35),
	@STATUT varchar(120),
	@ACTIVITE_BCEAO varchar(max) ,
	@SECTEUR_ACTIVITE varchar(max) ,
	@GROUPE  varchar(max),
	@brancheActif varchar(max)
as

BEGIN
	if @block = 0
	BEGIN
	
		declare @inf as int=0
		--select @inf=count(*) from SCOR_CONTREPARTIE
		select @inf=Max(CONVERT(INT, RIGHT(ID_SCORING, 7))) from SCOR_CONTREPARTIE
		if @inf is null begin set @inf=0 end

		declare @doss as int=0
		select @doss=max(convert(int,Rtrim(Ltrim(ID_DOSSIER)))) from SCOR_DOSSIER 
		if @doss is null begin set @doss=0 end

		declare @note as int=0
		select @note=max(convert(int,Rtrim(Ltrim(ID_NOTE)))) from SCOR_NOTE_QUESTIONNAIRE
		if @note is null begin set @note=0 end       
  
		if @GROUPE is null begin set @GROUPE='' end 
		set @inf=@inf+1

		DECLARE  @CODE as VARCHAR(12)
	
		SELECT @CODE='SC0'+ REPLICATE('0',7 - LEN(@inf))+CAST(@inf AS VARCHAR(7))
		
		INSERT INTO [dbo].[SCOR_CONTREPARTIE]
			([ID_SCORING]
			,[CODE_AGENCE]
			,[ETCIV_MATRICULE]
			,[ETCIV_NOMREDUIT]
			,[ETCIV_ADRESSE]
			,[ETCIV_VILLE_RESIDENCE]
			,[RCCM]
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
			,BRANCHE_ACTIVITE
			,[IDGROUPE])
		 VALUES
			(@CODE 
			,@CODE_AGENCE
			,@MATRICULE
			,@NOM
			,@ADRESSE
			,@VILLE_RESIDENCE
			,@RCCM
			,@SEGMENT_CLIENT
			,@MOIS_ARRETE
			,@MODE_ANALYSE
			,@UNITE
			,@DEVISE
			,@CA
			,@PAYS
			,@STATUT
			,@ACTIVITE_BCEAO
			,@SECTEUR_ACTIVITE
			,@TYPE_ANAFI
			,'Reférencé'
			,@brancheActif
			,@GROUPE)
		set @doss = @doss +1


	declare @UpGroupeNom as varchar(max)=''
	set @UpGroupeNom=(	select LIBELLE_GROUPE from [SCOR_GROUPE] WHERE ID_GROUPE=@GROUPE)
	if @UpGroupeNom is null set @UpGroupeNom=''
		INSERT INTO [dbo].[SCOR_DOSSIER]
			([ID_DOSSIER]
			,[ID_SCORING]
			,[DATE_DOSSIER]
			,[GROUPE_DOSSIER]
			,[NOTE_GROUPE]
			,[NOTE_PAYS]
			,[NOTE_AF]
			,[NOTE_AQ]
			,[NOTE_IG]
			,[NOTE_RP]
			,[NOTE_SYN]
			,[NOTE_PROP]
			,[NOTE_VAL]
			,[MODELE_DOSSIER])
		 VALUES
			(Convert(varchar(8),@doss)
			,@CODE
			,@datechargement
			,@UpGroupeNom
			,''
			,''
			,''
			,''
			,''
			,''
			,''
			,''
			,''
			,@MODE_ANALYSE)

			--INSERT INTO [dbo].[SCOR_DOSSIER_FORMULE]
			--   ([ID_DOSSIER]
			--   ,[ID_FORMULE])
			--VALUES
			--   (Convert(varchar(8),@doss)+''
			--   ,'1')

		set @note=@note+1
		INSERT INTO [dbo].[SCOR_NOTE_QUESTIONNAIRE]
			([ID_NOTE]
			,[ID_DOSSIER]
			,[ID_USER]
			,[ID_TYPE_BAREME_QUESTIONNAIRE]
			,[VALEUR_NOTE]
			,[DATE_NOTE])
		 VALUES
			(Convert(varchar(6),@note)
			,@doss
			,@iduser
			,'N1'
			,''
			,@datechargement)
		INSERT INTO [dbo].[SCOR_NOTE_QUESTIONNAIRE]
			([ID_NOTE]
			,[ID_DOSSIER]
			,[ID_USER]
			,[ID_TYPE_BAREME_QUESTIONNAIRE]
			,[VALEUR_NOTE]
			,[DATE_NOTE])
		 VALUES
			(Convert(varchar(6),@note+1)
			,@doss
			,@iduser
			,'N2'
			,''
			,@datechargement)
		INSERT INTO [dbo].[SCOR_NOTE_QUESTIONNAIRE]
			([ID_NOTE]
			,[ID_DOSSIER]
			,[ID_USER]
			,[ID_TYPE_BAREME_QUESTIONNAIRE]
			,[VALEUR_NOTE]
			,[DATE_NOTE])
		 VALUES
			(Convert(varchar(6),@note+2)
			,@doss
			,@iduser
			,'N3'
			,''
			,@datechargement)
		INSERT INTO [dbo].[SCOR_NOTE_QUESTIONNAIRE]
			([ID_NOTE]
			,[ID_DOSSIER]
			,[ID_USER]
			,[ID_TYPE_BAREME_QUESTIONNAIRE]
			,[VALEUR_NOTE]
			,[DATE_NOTE])
		 VALUES
			(Convert(varchar(6),@note+3)
			,@doss
			,@iduser
			,'N4'
			,''
			,@datechargement)

		DECLARE @para as int=0
		select @para=max(convert(int,Rtrim(Ltrim(ID_PARAMETRE)))) from ANAFI_PARAMETRE
		if @para is null begin set @para=0 end

		DECLARE  @nbdoss as int=0
		select  @nbdoss=count(*) from ANAFI_PARAMETRE Where ID_DOSSIER=Convert(varchar(8),@doss)
		if @nbdoss=0 

		DECLARE @id_para as VARCHAR(8) set @id_para=convert(VARCHAR(8),@para+1)
		
		INSERT INTO [dbo].[ANAFI_PARAMETRE]
			([ID_PARAMETRE]
			,[ID_DOSSIER]
			,[DATE_NOTE_MODIF]
			,[TVA]
			,[NOMBRE_LIASSE])
		VALUES
			(@id_para
			,Convert(varchar(8),@doss)
			,@datechargement
			,0.18
			,0)

	declare @ID_PROP as int=0,
	@ID_PROPOSITION as varchar(100)
	select @ID_PROP=max(convert(int ,ID_PROPOSITION)) from SCOR_PROPOSITION
	if @ID_PROP is null begin set @ID_PROP=0 end
	set @ID_PROPOSITION=Convert(varchar(100),@ID_PROP+1)

	INSERT INTO [dbo].[SCOR_PROPOSITION]
        ([ID_PROPOSITION]
        ,[ID_DOSSIER]
        ,[ID_USER]
        ,[DATE_PROP]
        ,[NOTE_PROP]
        ,[COMMENTAIRE_PROP]
        ,[FICHIER_PROP]
		,DECISION_PROP
		,VALIDATIONS)
     VALUES
        (@ID_PROPOSITION
        ,Convert(varchar(8),@doss)
        ,@iduser
        ,@datechargement
        ,''
        ,''
        ,''
		,''
		,'0')

	declare @ID_VAL as int=0,
	@ID_VALIDATION as varchar(100)
	SELECT @ID_VAL=max(convert(int ,ID_VALIDATION)) FROM SCOR_VALIDATION
	if @ID_VAL is null begin set @ID_VAL=0 end
	set @ID_VALIDATION=Convert(varchar(100),@ID_VAL+1)

	INSERT INTO [dbo].[SCOR_VALIDATION]
        ([ID_VALIDATION]
        ,[ID_DOSSIER]
        ,[ID_USER]
        ,[DATE_VAL]
        ,[NOTE_VAL]
        ,[COMMENTAIRE_VAL]
        ,[FICHIER_VAL]
		,DECISION_VAL
		,VALIDATIONS)
     VALUES
        (@ID_VALIDATION
        ,Convert(varchar(8),@doss)
        ,@iduser
        ,@datechargement
        ,''
        ,''
        ,''
		,''
		,'0')

		EXEC [PS_SCOR_TRIG_INS_CONTREPARTIE]
		@ID_SCORING =@CODE,
		@ETCIV_MATRICULE =@MATRICULE,
		@ETCIV_NOMREDUIT =@NOM,
		@CA = @CA,
		@ACTIVITE_BCEAO =@ACTIVITE_BCEAO,
		@SectAct = @SECTEUR_ACTIVITE
	END
	
	if @block =1
	BEGIN
		UPDATE [dbo].[SCOR_CONTREPARTIE]
		SET
		[CODE_AGENCE]=@CODE_AGENCE
		,[ETCIV_NOMREDUIT]=@NOM
		,[ETCIV_ADRESSE]=@ADRESSE
		,[ETCIV_VILLE_RESIDENCE]=@VILLE_RESIDENCE
		,[RCCM]=@RCCM
		,[SEGMENT_CLIENT]=@SEGMENT_CLIENT
		,[MOIS_ARRETE]=@MOIS_ARRETE
		,[MODE_ANALYSE]=@MODE_ANALYSE
		,[CA]=@CA
		,[PAYS]=@PAYS
		,[STATUT]=@STATUT
		,[ACTIVITE_BCEAO]=@ACTIVITE_BCEAO
		,[SECTEUR_D_ACTIVITE]=@SECTEUR_ACTIVITE
		,[TYPE_ANAFI]=@TYPE_ANAFI
		,IDGROUPE=@GROUPE
		WHERE [ETCIV_MATRICULE] = @MATRICULE

		UPDATE [dbo].[SCOR_DOSSIER]
		set GROUPE_DOSSIER= ISNULL(LIBELLE_GROUPE, '') 
		from SCOR_GROUPE
		where ID_GROUPE=@GROUPE	
	END

	if @block = 2
	BEGIN
	
		--declare @inf as int=0
		select @inf=count(*) from SCOR_CONTREPARTIE
		if @inf is null begin set @inf=0 end

		--declare @doss as int=0
		select @doss=max(convert(int,Rtrim(Ltrim(ID_DOSSIER)))) from SCOR_DOSSIER 
		if @doss is null begin set @doss=0 end

		--declare @note as int=0
		select @note=max(convert(int,Rtrim(Ltrim(ID_NOTE)))) from SCOR_NOTE_QUESTIONNAIRE
		if @note is null begin set @note=0 end       
  
		if @GROUPE is null begin set @GROUPE='' end 
		set @inf=@inf+1

		--DECLARE  @CODE as VARCHAR(12)
	
		SELECT @CODE='SCG'+ REPLICATE('0',7 - LEN(@inf))+CAST(@inf AS VARCHAR(7))


		declare @nouG as int=0
		select @nouG=count(*) from [SCOR_GROUPE]
		if @nouG is null begin set @nouG=0 end
		set @nouG=@nouG+1

		DECLARE  @CODEG as VARCHAR(12)	
		SELECT @CODEG='SCG'+ REPLICATE('0',3 - LEN(@nouG))+CAST(@nouG AS VARCHAR(7))

		INSERT INTO [dbo].[SCOR_GROUPE]
           ([ID_GROUPE]
           ,[CODE_GROUPE]
           ,[LIBELLE_GROUPE])
		VALUES
           (
		    @CODEG
			,' '
			,@NOM
		    )
					
		INSERT INTO [dbo].[SCOR_CONTREPARTIE]
			([ID_SCORING]
			,[CODE_AGENCE]
			,[ETCIV_MATRICULE]
			,[ETCIV_NOMREDUIT]
			,[ETCIV_ADRESSE]
			,[ETCIV_VILLE_RESIDENCE]
			,[RCCM]
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
			,BRANCHE_ACTIVITE
			,[IDGROUPE])
		 VALUES
			(@CODE 
			,@CODE_AGENCE
			,' '
			,@NOM
			,@ADRESSE
			,@VILLE_RESIDENCE
			,@RCCM
			,@SEGMENT_CLIENT
			,@MOIS_ARRETE
			,@MODE_ANALYSE
			,@UNITE
			,@DEVISE
			,@CA
			,@PAYS
			,@STATUT
			,@ACTIVITE_BCEAO
			,@SECTEUR_ACTIVITE
			,@TYPE_ANAFI
			,'Prospect'
			,@brancheActif
			,@CODEG)

		set @doss = @doss +1
		INSERT INTO [dbo].[SCOR_DOSSIER]
			([ID_DOSSIER]
			,[ID_SCORING]
			,[DATE_DOSSIER]
			,[GROUPE_DOSSIER]
			,[NOTE_GROUPE]
			,[NOTE_PAYS]
			,[NOTE_AF]
			,[NOTE_AQ]
			,[NOTE_IG]
			,[NOTE_RP]
			,[NOTE_SYN]
			,[NOTE_PROP]
			,[NOTE_VAL]
			,[MODELE_DOSSIER])
		 VALUES
			(Convert(varchar(8),@doss)
			,@CODE
			,@datechargement
			,@NOM
			,''
			,''
			,''
			,''
			,''
			,''
			,''
			,''
			,''
			,@GROUPE)

			 --INSERT INTO [dbo].[SCOR_DOSSIER_FORMULE]
				--   ([ID_DOSSIER]
				--   ,[ID_FORMULE])
			 --VALUES
				--   (Convert(varchar(8),@doss)+''
				--   ,'1')

		set @note=@note+1

		IF NOT EXISTS (SELECT * FROM [SCOR_NOTE_QUESTIONNAIRE] WHERE ID_DOSSIER = @doss AND ID_TYPE_BAREME_QUESTIONNAIRE = 'N1')
			INSERT INTO [dbo].[SCOR_NOTE_QUESTIONNAIRE]
				([ID_NOTE]
				,[ID_DOSSIER]
				,[ID_USER]
				,[ID_TYPE_BAREME_QUESTIONNAIRE]
				,[VALEUR_NOTE]
				,[DATE_NOTE])
			 VALUES
				(Convert(varchar(6),@note)
				,@doss
				,@iduser
				,'N1'
				,''
				,@datechargement)
		
		IF NOT EXISTS (SELECT * FROM [SCOR_NOTE_QUESTIONNAIRE] WHERE ID_DOSSIER = @doss AND ID_TYPE_BAREME_QUESTIONNAIRE = 'N2')
			INSERT INTO [dbo].[SCOR_NOTE_QUESTIONNAIRE]
				([ID_NOTE]
				,[ID_DOSSIER]
				,[ID_USER]
				,[ID_TYPE_BAREME_QUESTIONNAIRE]
				,[VALEUR_NOTE]
				,[DATE_NOTE])
			 VALUES
				(Convert(varchar(6),@note+1)
				,@doss
				,@iduser
				,'N2'
				,''
				,@datechargement)

		IF NOT EXISTS (SELECT * FROM [SCOR_NOTE_QUESTIONNAIRE] WHERE ID_DOSSIER = @doss AND ID_TYPE_BAREME_QUESTIONNAIRE = 'N3')
			INSERT INTO [dbo].[SCOR_NOTE_QUESTIONNAIRE]
				([ID_NOTE]
				,[ID_DOSSIER]
				,[ID_USER]
				,[ID_TYPE_BAREME_QUESTIONNAIRE]
				,[VALEUR_NOTE]
				,[DATE_NOTE])
			 VALUES
				(Convert(varchar(6),@note+2)
				,@doss
				,@iduser
				,'N3'
				,''
				,@datechargement)

		IF NOT EXISTS (SELECT * FROM [SCOR_NOTE_QUESTIONNAIRE] WHERE ID_DOSSIER = @doss AND ID_TYPE_BAREME_QUESTIONNAIRE = 'N4')
			INSERT INTO [dbo].[SCOR_NOTE_QUESTIONNAIRE]
				([ID_NOTE]
				,[ID_DOSSIER]
				,[ID_USER]
				,[ID_TYPE_BAREME_QUESTIONNAIRE]
				,[VALEUR_NOTE]
				,[DATE_NOTE])
			 VALUES
				(Convert(varchar(6),@note+3)
				,@doss
				,@iduser
				,'N4'
				,''
				,@datechargement)

		--DECLARE @para as int=0
		select @para=max(convert(int,Rtrim(Ltrim(ID_PARAMETRE)))) from ANAFI_PARAMETRE
		if @para is null begin set @para=0 end

		--DECLARE  @nbdoss as int=0
		select  @nbdoss=count(*) from ANAFI_PARAMETRE Where ID_DOSSIER=Convert(varchar(8),@doss)
		if @nbdoss=0 

		--DECLARE @id_para as VARCHAR(8)
		 set @id_para=convert(VARCHAR(8),@para+1)
		
		INSERT INTO [dbo].[ANAFI_PARAMETRE]
			([ID_PARAMETRE]
			,[ID_DOSSIER]
			,[DATE_NOTE_MODIF]
			,[TVA]
			,[NOMBRE_LIASSE])
		VALUES
			(@id_para
			,Convert(varchar(8),@doss)
			,@datechargement
			,0.18
			,0)

	--declare @ID_PROP as int=0,
	--@ID_PROPOSITION as varchar(100)
	select @ID_PROP=max(convert(int ,ID_PROPOSITION)) from SCOR_PROPOSITION
	if @ID_PROP is null begin set @ID_PROP=0 end
	set @ID_PROPOSITION=Convert(varchar(100),@ID_PROP+1)

	INSERT INTO [dbo].[SCOR_PROPOSITION]
        ([ID_PROPOSITION]
        ,[ID_DOSSIER]
        ,[ID_USER]
        ,[DATE_PROP]
        ,[NOTE_PROP]
        ,[COMMENTAIRE_PROP]
        ,[FICHIER_PROP]
		,DECISION_PROP
		,VALIDATIONS)
     VALUES
        (@ID_PROPOSITION
        ,Convert(varchar(8),@doss)
        ,@iduser
        ,@datechargement
        ,''
        ,''
        ,''
		,''
		,'0')


	--declare @ID_VAL as int=0,
	--@ID_VALIDATION as varchar(100)
	SELECT @ID_VAL=max(convert(int ,ID_VALIDATION)) FROM SCOR_VALIDATION
	if @ID_VAL is null begin set @ID_VAL=0 end
	set @ID_VALIDATION=Convert(varchar(100),@ID_VAL+1)

	INSERT INTO [dbo].[SCOR_VALIDATION]
        ([ID_VALIDATION]
        ,[ID_DOSSIER]
        ,[ID_USER]
        ,[DATE_VAL]
        ,[NOTE_VAL]
        ,[COMMENTAIRE_VAL]
        ,[FICHIER_VAL]
		,DECISION_VAL
		,VALIDATIONS)
     VALUES
        (@ID_VALIDATION
        ,Convert(varchar(8),@doss)
        ,@iduser
        ,@datechargement
        ,''
        ,''
        ,''
		,''
		,'0')

		EXEC PS_SCOR_TRIG_INS_CONTREPARTIE
		@ID_SCORING =@CODE,
		@ETCIV_MATRICULE = @MATRICULE,
		@ETCIV_NOMREDUIT = @NOM,
		@CA = @CA,
		@ACTIVITE_BCEAO = @ACTIVITE_BCEAO,
		@SectAct = @SECTEUR_ACTIVITE

	END

	if @block =3
	BEGIN
		declare @UpdateGroupe as varchar(12)=''
		set @UpdateGroupe=(	select top 1 ID_GROUPE from [SCOR_GROUPE] ORDER BY [ID_GROUPE] DESC)
		if @UpdateGroupe is null set @UpdateGroupe=''

		UPDATE [dbo].[SCOR_CONTREPARTIE]
		SET [IDGROUPE]=@UpdateGroupe
		WHERE [ID_SCORING] = @GROUPE	
		 
		declare @UpdateGroupeNom as varchar(max)=''
		set @UpdateGroupeNom=(	select LIBELLE_GROUPE from [SCOR_GROUPE] WHERE ID_GROUPE=@UpdateGroupe)
		if @UpdateGroupeNom is null set @UpdateGroupeNom=''

		UPDATE [dbo].[SCOR_DOSSIER]
		SET [GROUPE_DOSSIER]=@UpdateGroupeNom
		WHERE [ID_SCORING] = @GROUPE
		 
		--EXEC [PS_SCOR_TRIG_INS_CONTREPARTIE]
		--@ID_SCORING =@CODE,
		--@ETCIV_MATRICULE =@MATRICULE,
		--@ETCIV_NOMREDUIT =@NOM,
		--@CA = @CA,
		--@ACTIVITE_BCEAO =@ACTIVITE_BCEAO,
		--@SectAct = @SECTEUR_ACTIVITE
	END

	if @block =4
	BEGIN
		declare @UpdateGroupe1 as varchar(12)=''
		set @UpdateGroupe1=(	select top 1 ID_GROUPE from [SCOR_GROUPE] ORDER BY [ID_GROUPE] DESC)
		if @UpdateGroupe1 is null set @UpdateGroupe1=''

		UPDATE [dbo].[SCOR_CONTREPARTIE]
		SET [IDGROUPE]=''
		WHERE [ID_SCORING] = @GROUPE	
		 
		declare @UpdateGroupeNom1 as varchar(max)=''
		set @UpdateGroupeNom1=(	select LIBELLE_GROUPE from [SCOR_GROUPE] WHERE ID_GROUPE=@UpdateGroupe)
		if @UpdateGroupeNom1 is null set @UpdateGroupeNom1=''

		UPDATE [dbo].[SCOR_DOSSIER]
		SET [GROUPE_DOSSIER]=''
		WHERE [ID_SCORING] = @GROUPE
		 
	END

	if @block =5
	BEGIN
		--declare @UpdateGroupe as varchar(12)=''
		--set @UpdateGroupe=(	select top 1 ID_GROUPE from [SCOR_GROUPE] WHERE )
		UPDATE [dbo].[SCOR_CONTREPARTIE]
		SET [IDGROUPE]=@brancheActif
		WHERE [ID_SCORING] = @GROUPE	
		 
		--	 --declare @UpdateGroupeNom as varchar(max)=''
		set @UpdateGroupeNom=(	select LIBELLE_GROUPE from [SCOR_GROUPE] WHERE ID_GROUPE=@brancheActif)
		if @UpdateGroupeNom is null set @UpdateGroupeNom=''

		UPDATE [dbo].[SCOR_DOSSIER]
		SET [GROUPE_DOSSIER]=@UpdateGroupeNom
		WHERE [ID_SCORING] = @GROUPE
	END
 END