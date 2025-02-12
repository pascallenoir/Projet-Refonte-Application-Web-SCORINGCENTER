USE [ScoringDB]
GO
/****** Object:  StoredProcedure [dbo].[PS_SCOR_Tableau_SchemaDelegataire_Liste]    Script Date: 14/03/2023 10:01:01 ******/
DROP PROCEDURE [dbo].[PS_SCOR_Tableau_SchemaDelegataire_Liste]
GO
/****** Object:  StoredProcedure [dbo].[PS_SCOR_Tableau_SchemaDelegataire_C]    Script Date: 14/03/2023 10:01:01 ******/
DROP PROCEDURE [dbo].[PS_SCOR_Tableau_SchemaDelegataire_C]
GO
/****** Object:  StoredProcedure [dbo].[PS_SCOR_Tableau_SchemaDelegataire_B]    Script Date: 14/03/2023 10:01:01 ******/
DROP PROCEDURE [dbo].[PS_SCOR_Tableau_SchemaDelegataire_B]
GO
/****** Object:  StoredProcedure [dbo].[PS_SCOR_Tableau_SchemaDelegataire_A1]    Script Date: 14/03/2023 10:01:01 ******/
DROP PROCEDURE [dbo].[PS_SCOR_Tableau_SchemaDelegataire_A1]
GO
/****** Object:  StoredProcedure [dbo].[PS_SCOR_Tableau_SchemaDelegataire_A]    Script Date: 14/03/2023 10:01:01 ******/
DROP PROCEDURE [dbo].[PS_SCOR_Tableau_SchemaDelegataire_A]
GO
/****** Object:  StoredProcedure [dbo].[PS_SCOR_Supp_SchemaDelegataire_D]    Script Date: 14/03/2023 10:01:01 ******/
DROP PROCEDURE [dbo].[PS_SCOR_Supp_SchemaDelegataire_D]
GO
/****** Object:  StoredProcedure [dbo].[PS_SCOR_Supp_SchemaDelegataire_C1]    Script Date: 14/03/2023 10:01:01 ******/
DROP PROCEDURE [dbo].[PS_SCOR_Supp_SchemaDelegataire_C1]
GO
/****** Object:  StoredProcedure [dbo].[PS_SCOR_Supp_SchemaDelegataire_B]    Script Date: 14/03/2023 10:01:01 ******/
DROP PROCEDURE [dbo].[PS_SCOR_Supp_SchemaDelegataire_B]
GO
/****** Object:  StoredProcedure [dbo].[PS_SCOR_Supp_SchemaDelegataire_A]    Script Date: 14/03/2023 10:01:01 ******/
DROP PROCEDURE [dbo].[PS_SCOR_Supp_SchemaDelegataire_A]
GO
/****** Object:  StoredProcedure [dbo].[PS_SCOR_Specif_SchemaDelegataire_B]    Script Date: 14/03/2023 10:01:01 ******/
DROP PROCEDURE [dbo].[PS_SCOR_Specif_SchemaDelegataire_B]
GO
/****** Object:  StoredProcedure [dbo].[PS_SCOR_Specif_SchemaDelegataire_A]    Script Date: 14/03/2023 10:01:01 ******/
DROP PROCEDURE [dbo].[PS_SCOR_Specif_SchemaDelegataire_A]
GO
/****** Object:  StoredProcedure [dbo].[PS_SCOR_Selection_List_Seuil_Specif]    Script Date: 14/03/2023 10:01:01 ******/
DROP PROCEDURE [dbo].[PS_SCOR_Selection_List_Seuil_Specif]
GO
/****** Object:  StoredProcedure [dbo].[PS_SCOR_Selection_List_Seuil]    Script Date: 14/03/2023 10:01:01 ******/
DROP PROCEDURE [dbo].[PS_SCOR_Selection_List_Seuil]
GO
/****** Object:  StoredProcedure [dbo].[PS_SCOR_Mod_SchemaDelegataire_A]    Script Date: 14/03/2023 10:01:01 ******/
DROP PROCEDURE [dbo].[PS_SCOR_Mod_SchemaDelegataire_A]
GO
/****** Object:  StoredProcedure [dbo].[PS_SCOR_Insert_SchemaDelegataire_C]    Script Date: 14/03/2023 10:01:01 ******/
DROP PROCEDURE [dbo].[PS_SCOR_Insert_SchemaDelegataire_C]
GO
/****** Object:  StoredProcedure [dbo].[PS_SCOR_Insert_SchemaDelegataire_B]    Script Date: 14/03/2023 10:01:01 ******/
DROP PROCEDURE [dbo].[PS_SCOR_Insert_SchemaDelegataire_B]
GO
/****** Object:  StoredProcedure [dbo].[PS_SCOR_Insert_SchemaDelegataire_A]    Script Date: 14/03/2023 10:01:01 ******/
DROP PROCEDURE [dbo].[PS_SCOR_Insert_SchemaDelegataire_A]
GO
/****** Object:  StoredProcedure [dbo].[PS_SCOR_Insert_SchemaDelegataire_A]    Script Date: 14/03/2023 10:01:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[PS_SCOR_Insert_SchemaDelegataire_A]
@LIBELLE_SEUIL_DELEGUATION varchar(100)
,@MAX_SCOR_SEUIL_DELEGUATION bigint
,@MIN_SCOR_SEUIL_DELEGUATION bigint
,@CODE_BANQUE varchar(50)
As
Begin
declare @ID_SCOR_SEUIL_DELEGUATION int =0
SELECT @ID_SCOR_SEUIL_DELEGUATION=MAX(ISNULL(ID_SCOR_SEUIL_DELEGUATION,0)) FROM SCOR_SEUIL_DELEGUATION 
SET @ID_SCOR_SEUIL_DELEGUATION=ISNULL(@ID_SCOR_SEUIL_DELEGUATION,0)+1

	if (select count(*) from SCOR_BANQUE where CODE_BANQUE = @CODE_BANQUE)>0
	Begin
		INSERT INTO SCOR_SEUIL_DELEGUATION
			   (ID_SCOR_SEUIL_DELEGUATION, LIBELLE_SEUIL_DELEGUATION
			   , MAX_SCOR_SEUIL_DELEGUATION, MIN_SCOR_SEUIL_DELEGUATION,CODE_BANQUE)
		 VALUES
			   (@ID_SCOR_SEUIL_DELEGUATION, @LIBELLE_SEUIL_DELEGUATION
			   ,@MAX_SCOR_SEUIL_DELEGUATION, @MIN_SCOR_SEUIL_DELEGUATION, @CODE_BANQUE)
	End
End

GO
/****** Object:  StoredProcedure [dbo].[PS_SCOR_Insert_SchemaDelegataire_B]    Script Date: 14/03/2023 10:01:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[PS_SCOR_Insert_SchemaDelegataire_B]
@LIBELLE_SCOR_DELEGATION varchar(50)
,@ID_SCOR_SEUIL_DELEGUATION int
As
Begin
declare @ID_SCOR_DELEGATION int =0
SELECT @ID_SCOR_DELEGATION=MAX(ISNULL(ID_SCOR_DELEGATION,0)) FROM SCOR_DELEGUER
SET @ID_SCOR_DELEGATION=ISNULL(@ID_SCOR_DELEGATION,0)+1

	INSERT INTO [dbo].[SCOR_DELEGATION]
           ([ID_SCOR_DELEGATION]
           ,[LIBELLE_SCOR_DELEGATION]
           ,[ID_SCOR_SEUIL_DELEGUATION])
     VALUES
           (@ID_SCOR_DELEGATION
           ,@LIBELLE_SCOR_DELEGATION
           ,@ID_SCOR_SEUIL_DELEGUATION)

	
End


GO
/****** Object:  StoredProcedure [dbo].[PS_SCOR_Insert_SchemaDelegataire_C]    Script Date: 14/03/2023 10:01:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[PS_SCOR_Insert_SchemaDelegataire_C]
@ID_SCOR_DELEGATION int
,@ID_USER char(6)
,@CODE_AGENCE char(10)
As
Begin
	INSERT INTO SCOR_DELEGUER
           (ID_SCOR_DELEGATION,ID_USER 
		    ,CODE_AGENCE, DATEDELEGUER)
     VALUES
           (@ID_SCOR_DELEGATION, @ID_USER
           ,@CODE_AGENCE, GETDATE())
End


GO
/****** Object:  StoredProcedure [dbo].[PS_SCOR_Mod_SchemaDelegataire_A]    Script Date: 14/03/2023 10:01:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[PS_SCOR_Mod_SchemaDelegataire_A]
@LIBELLE_SEUIL_DELEGUATION varchar(100)
,@MAX_SCOR_SEUIL_DELEGUATION bigint
,@MIN_SCOR_SEUIL_DELEGUATION bigint
,@ID_SCOR_SEUIL_DELEGUATION int
As
Begin
	UPDATE SCOR_SEUIL_DELEGUATION
   SET 
      LIBELLE_SEUIL_DELEGUATION = @LIBELLE_SEUIL_DELEGUATION
      ,MAX_SCOR_SEUIL_DELEGUATION = @MAX_SCOR_SEUIL_DELEGUATION
      ,MIN_SCOR_SEUIL_DELEGUATION = @MIN_SCOR_SEUIL_DELEGUATION
 WHERE ID_SCOR_SEUIL_DELEGUATION = @ID_SCOR_SEUIL_DELEGUATION
End


GO
/****** Object:  StoredProcedure [dbo].[PS_SCOR_Selection_List_Seuil]    Script Date: 14/03/2023 10:01:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[PS_SCOR_Selection_List_Seuil]
@CODE_BANQUE T_CODE_5 null
As
Begin
	if @CODE_BANQUE is null set @CODE_BANQUE='%'
	Select * from SCOR_SEUIL_DELEGUATION where CODE_BANQUE like @CODE_BANQUE order by MAX_SCOR_SEUIL_DELEGUATION
End


GO
/****** Object:  StoredProcedure [dbo].[PS_SCOR_Selection_List_Seuil_Specif]    Script Date: 14/03/2023 10:01:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[PS_SCOR_Selection_List_Seuil_Specif]
@ID_SCOR_SEUIL_DELEGUATION int null,
@LIBELLE_SEUIL_DELEGUATION varchar(50) null,
@MAX_SCOR_SEUIL_DELEGUATION bigint null,
@MIN_SCOR_SEUIL_DELEGUATION bigint null,
@ValeurComparaison bigint null,
@Intervalle varchar(50) null
As
Begin
	if @ID_SCOR_SEUIL_DELEGUATION is not null 

	BEGIN

	Select * from SCOR_SEUIL_DELEGUATION where ID_SCOR_SEUIL_DELEGUATION=@ID_SCOR_SEUIL_DELEGUATION 

	END

	if @LIBELLE_SEUIL_DELEGUATION is not null

	BEGIN

	Select * from SCOR_SEUIL_DELEGUATION where LIBELLE_SEUIL_DELEGUATION like '%'+@LIBELLE_SEUIL_DELEGUATION+'%' 

	END

	if @MAX_SCOR_SEUIL_DELEGUATION is not null

	BEGIN

	Select * from SCOR_SEUIL_DELEGUATION where MAX_SCOR_SEUIL_DELEGUATION = @MAX_SCOR_SEUIL_DELEGUATION

	END
 
	if @MIN_SCOR_SEUIL_DELEGUATION is not null

	BEGIN

	Select * from SCOR_SEUIL_DELEGUATION where MIN_SCOR_SEUIL_DELEGUATION = @MIN_SCOR_SEUIL_DELEGUATION  

	END

if @ValeurComparaison is not null
begin
	if @Intervalle = 'FF' 
	Select * from SCOR_SEUIL_DELEGUATION where MIN_SCOR_SEUIL_DELEGUATION <= @ValeurComparaison 
	And MAX_SCOR_SEUIL_DELEGUATION >= @ValeurComparaison 
	if @Intervalle = 'FO' 
	Select * from SCOR_SEUIL_DELEGUATION where MIN_SCOR_SEUIL_DELEGUATION <= @ValeurComparaison 
	And MAX_SCOR_SEUIL_DELEGUATION > @ValeurComparaison 
	if @Intervalle = 'OF' 
	Select * from SCOR_SEUIL_DELEGUATION where MIN_SCOR_SEUIL_DELEGUATION < @ValeurComparaison 
	And MAX_SCOR_SEUIL_DELEGUATION >= @ValeurComparaison
	if @Intervalle = 'OO' 
	Select * from SCOR_SEUIL_DELEGUATION where MIN_SCOR_SEUIL_DELEGUATION < @ValeurComparaison 
	And MAX_SCOR_SEUIL_DELEGUATION > @ValeurComparaison  
End

End

-----------------------------------------------------------------------------------------------------------
----------------------------------PS_SCOR_Tableau_SchemaDelegataire_A ALL DELEGATION BANQUE--------------------------------------
-----------------------------------------------------------------------------------------------------------


GO
/****** Object:  StoredProcedure [dbo].[PS_SCOR_Specif_SchemaDelegataire_A]    Script Date: 14/03/2023 10:01:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[PS_SCOR_Specif_SchemaDelegataire_A]
@ID_SCOR_SEUIL_DELEGUATION int,
@LIBELLE_SCOR_DELEGATION varchar(50)
As
Begin

	Select 
	DEL.ID_SCOR_DELEGATION ID_LIGNE
	,DEL.ID_SCOR_SEUIL_DELEGUATION
	,DEL.LIBELLE_SCOR_DELEGATION
	from SCOR_DELEGATION DEL, SCOR_SEUIL_DELEGUATION SEU--, SCOR_DELEGUER DER
	where 
	DEL.ID_SCOR_SEUIL_DELEGUATION = SEU.ID_SCOR_SEUIL_DELEGUATION
	AND DEL.ID_SCOR_SEUIL_DELEGUATION = @ID_SCOR_SEUIL_DELEGUATION
	AND DEL.LIBELLE_SCOR_DELEGATION= @LIBELLE_SCOR_DELEGATION
	--AND DER.CODE_AGENCE IN( SELECT CODE_AGENCE FROM SCOR_AGENCE WHERE CODE_BANQUE=@CODE_BANQUE)

End


GO
/****** Object:  StoredProcedure [dbo].[PS_SCOR_Specif_SchemaDelegataire_B]    Script Date: 14/03/2023 10:01:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create Procedure [dbo].[PS_SCOR_Specif_SchemaDelegataire_B]

@bloc int,
@ID_SCOR_SEUIL_DELEGUATION int,
@ID_Dossier varchar(10),
@CODE_BANQUE varchar(50)
As
Begin
IF @bloc = -1
	BEGIN
			SELECT * FROM SCOR_DELEGATION , SCOR_SEUIL_DELEGUATION
	END
	IF @bloc = 0
	BEGIN
			Select 
			DEL.ID_SCOR_DELEGATION 
			,DEL.ID_SCOR_SEUIL_DELEGUATION
			,DEL.LIBELLE_SCOR_DELEGATION
			from SCOR_DELEGATION DEL, SCOR_SEUIL_DELEGUATION SEU--, SCOR_DELEGUER DER
			where 
			DEL.ID_SCOR_SEUIL_DELEGUATION = SEU.ID_SCOR_SEUIL_DELEGUATION
			AND DEL.ID_SCOR_SEUIL_DELEGUATION = @ID_SCOR_SEUIL_DELEGUATION
			and DEL.ID_SCOR_DELEGATION in(select ID_SCOR_DELEGATION from SCOR_DELEGUER where CODE_AGENCE in ( SELECT CODE_AGENCE FROM SCOR_AGENCE WHERE CODE_BANQUE=@CODE_BANQUE))
			--AND DEL.LIBELLE_SCOR_DELEGATION= @LIBELLE_SCOR_DELEGATION
			--AND DER.CODE_AGENCE IN( SELECT CODE_AGENCE FROM SCOR_AGENCE WHERE CODE_BANQUE=@CODE_BANQUE)
	END
	IF @bloc = 1
	BEGIN
		Declare @id_scor_seul as int=0;

		select @id_scor_seul=ID_SCOR_SEUIL_DELEGUATION from SCOR_DOSSIER_SEUIL_CREDIT where Ltrim(Rtrim(ID_DOSSIER))=Ltrim(Rtrim(@ID_Dossier))

		Select 
		DEL.ID_SCOR_DELEGATION 
		,DEL.ID_SCOR_SEUIL_DELEGUATION
		,DEL.LIBELLE_SCOR_DELEGATION
		from SCOR_DELEGATION DEL, SCOR_SEUIL_DELEGUATION SEU--, SCOR_DELEGUER DER
		where 
		DEL.ID_SCOR_SEUIL_DELEGUATION = SEU.ID_SCOR_SEUIL_DELEGUATION
		AND DEL.ID_SCOR_SEUIL_DELEGUATION = @id_scor_seul
		and DEL.ID_SCOR_DELEGATION in(select ID_SCOR_DELEGATION from SCOR_DELEGUER where CODE_AGENCE in ( SELECT CODE_AGENCE FROM SCOR_AGENCE WHERE CODE_BANQUE=@CODE_BANQUE))
		--AND DEL.LIBELLE_SCOR_DELEGATION= @LIBELLE_SCOR_DELEGATION
		--AND DER.CODE_AGENCE IN( SELECT CODE_AGENCE FROM SCOR_AGENCE WHERE CODE_BANQUE=@CODE_BANQUE)

	END


	

End



GO
/****** Object:  StoredProcedure [dbo].[PS_SCOR_Supp_SchemaDelegataire_A]    Script Date: 14/03/2023 10:01:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[PS_SCOR_Supp_SchemaDelegataire_A]
@ID_SCOR_DELEGATION int
,@CODE_AGENCE char(10)
As
Begin
	DELETE FROM SCOR_DELEGUER
      WHERE 
	  ID_SCOR_DELEGATION=@ID_SCOR_DELEGATION
	  AND CODE_AGENCE=@CODE_AGENCE
End


GO
/****** Object:  StoredProcedure [dbo].[PS_SCOR_Supp_SchemaDelegataire_B]    Script Date: 14/03/2023 10:01:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[PS_SCOR_Supp_SchemaDelegataire_B]
@ID_SCOR_DELEGATION int
,@ID_USER char(6)
As
Begin
	DELETE FROM SCOR_DELEGUER
      WHERE 
	  ID_SCOR_DELEGATION=@ID_SCOR_DELEGATION
	  AND ID_USER=@ID_USER
End

-----------------------------------------------------------------------------------------------------------
----------------------------------PS_SCOR_Supp_SchemaDelegataire_C DELEGATION--------------------------------------
-----------------------------------------------------------------------------------------------------------


GO
/****** Object:  StoredProcedure [dbo].[PS_SCOR_Supp_SchemaDelegataire_C1]    Script Date: 14/03/2023 10:01:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[PS_SCOR_Supp_SchemaDelegataire_C1]
@ID_SCOR_DELEGATION int
As
Begin
	DELETE FROM SCOR_DELEGUER
      WHERE 
	  ID_SCOR_DELEGATION=@ID_SCOR_DELEGATION

	DELETE FROM SCOR_DELEGATION
      WHERE 
	  ID_SCOR_DELEGATION=@ID_SCOR_DELEGATION
	  
End


GO
/****** Object:  StoredProcedure [dbo].[PS_SCOR_Supp_SchemaDelegataire_D]    Script Date: 14/03/2023 10:01:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[PS_SCOR_Supp_SchemaDelegataire_D]
@CODE_BANQUE varchar(50)
As
Begin

--DECLARE @ID_SCOR_DELEGATION table
--( ID_SCOR_DELEGATION int )
SELECT ID_SCOR_DELEGATION into ##ID_SCOR_DELEGATION FROM SCOR_DELEGUER
WHERE CODE_AGENCE IN( SELECT CODE_AGENCE FROM SCOR_AGENCE WHERE CODE_BANQUE=@CODE_BANQUE)

	DELETE FROM SCOR_DELEGUER
      WHERE 
	  CODE_AGENCE IN( SELECT CODE_AGENCE FROM SCOR_AGENCE WHERE CODE_BANQUE=@CODE_BANQUE)

 SELECT ID_SCOR_SEUIL_DELEGUATION into ##ID_SCOR_SEUIL_DELEGUATION FROM SCOR_DELEGATION
WHERE ID_SCOR_DELEGATION in (SELECT ID_SCOR_DELEGATION from ##ID_SCOR_DELEGATION)

	DELETE FROM SCOR_DELEGATION
      WHERE 
	  ID_SCOR_DELEGATION in (SELECT ID_SCOR_DELEGATION from ##ID_SCOR_DELEGATION)


	DELETE FROM SCOR_DOSSIER_SEUIL_CREDIT


	  DELETE FROM SCOR_SEUIL_DELEGUATION
      WHERE 
	  ID_SCOR_SEUIL_DELEGUATION in (SELECT ID_SCOR_SEUIL_DELEGUATION from ##ID_SCOR_SEUIL_DELEGUATION)
	  BEGIN TRY
			DELETE FROM SCOR_SEUIL_DELEGUATION
		END TRY
		BEGIN CATCH
			 DECLARE @decideur int =1
		END CATCH;
	  
End


GO
/****** Object:  StoredProcedure [dbo].[PS_SCOR_Tableau_SchemaDelegataire_A]    Script Date: 14/03/2023 10:01:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[PS_SCOR_Tableau_SchemaDelegataire_A]
@CODE_BANQUE varchar(50)
As
Begin 

	Select 
	DEL.ID_SCOR_DELEGATION ID_LIGNE
	, DEL.LIBELLE_SCOR_DELEGATION NOM_DELEG
	, Convert(varchar(50),SEU.MIN_SCOR_SEUIL_DELEGUATION) + ' à ' + Convert(varchar(50),SEU.MAX_SCOR_SEUIL_DELEGUATION) SEUIL
	from SCOR_DELEGATION DEL, SCOR_SEUIL_DELEGUATION SEU, SCOR_DELEGUER DER
	where 
	DEL.ID_SCOR_SEUIL_DELEGUATION = SEU.ID_SCOR_SEUIL_DELEGUATION
	AND DER.CODE_AGENCE IN( SELECT CODE_AGENCE FROM SCOR_AGENCE WHERE CODE_BANQUE=@CODE_BANQUE)

End


GO
/****** Object:  StoredProcedure [dbo].[PS_SCOR_Tableau_SchemaDelegataire_A1]    Script Date: 14/03/2023 10:01:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[PS_SCOR_Tableau_SchemaDelegataire_A1]
@CODE_BANQUE varchar(50)
As
Begin

	Select 
	DEL.ID_SCOR_DELEGATION ID_LIGNE
	, DEL.LIBELLE_SCOR_DELEGATION NOM_DELEG
	, Convert(varchar(50),SEU.MIN_SCOR_SEUIL_DELEGUATION) + ' à ' + Convert(varchar(50),SEU.MAX_SCOR_SEUIL_DELEGUATION) SEUIL
	,SEU.MAX_SCOR_SEUIL_DELEGUATION MAXSEUIL
	,SEU.MIN_SCOR_SEUIL_DELEGUATION MINSEUIL
	--from SCOR_DELEGATION DEL, SCOR_SEUIL_DELEGUATION SEU, SCOR_DELEGUER DER
	--where 
	--DEL.ID_SCOR_SEUIL_DELEGUATION = SEU.ID_SCOR_SEUIL_DELEGUATION
	--AND DEL.ID_SCOR_DELEGATION = DER.ID_SCOR_DELEGATION
	--AND DER.CODE_AGENCE IN( SELECT CODE_AGENCE FROM SCOR_AGENCE WHERE CODE_BANQUE='BDU01')
	
from SCOR_DELEGATION DEL, SCOR_SEUIL_DELEGUATION SEU
	where 
	DEL.ID_SCOR_SEUIL_DELEGUATION = SEU.ID_SCOR_SEUIL_DELEGUATION
	AND DEL.ID_SCOR_DELEGATION in (select ID_SCOR_DELEGATION from SCOR_DELEGUER where
	 CODE_AGENCE IN( SELECT CODE_AGENCE FROM SCOR_AGENCE WHERE CODE_BANQUE=@CODE_BANQUE))

End


GO
/****** Object:  StoredProcedure [dbo].[PS_SCOR_Tableau_SchemaDelegataire_B]    Script Date: 14/03/2023 10:01:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[PS_SCOR_Tableau_SchemaDelegataire_B]
@ID_LIGNE int
,@CODE_BANQUE varchar(50)
As
Begin

	Select 
	UT.ID_USER ID_USER, UT.NOM_USER NOM_USER, UT.PRENOM_USER PRENOM_USER, UT.PRENOM_USER+' '+UT.NOM_USER NOMCOMPLET
	from SCOR_UTILISATEUR UT--, SCOR_DELEGUER DER
	where 
	
	 UT.CODE_AGENCE IN( SELECT CODE_AGENCE FROM SCOR_AGENCE WHERE CODE_BANQUE=@CODE_BANQUE)
	AND ID_USER in(select ID_USER from SCOR_DELEGUER where  ID_SCOR_DELEGATION=@ID_LIGNE and CODE_AGENCE in ( SELECT CODE_AGENCE FROM SCOR_AGENCE WHERE CODE_BANQUE=@CODE_BANQUE))


End


GO
/****** Object:  StoredProcedure [dbo].[PS_SCOR_Tableau_SchemaDelegataire_C]    Script Date: 14/03/2023 10:01:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[PS_SCOR_Tableau_SchemaDelegataire_C]
@ID_LIGNE int
,@CODE_BANQUE varchar(50)
As
Begin

	Select 
	AG.CODE_AGENCE CODE_AGENCE, AG.NOM_AGENCE NOMAGENCE, AG.GUICHET_AGENCE GUICHET_AGENCE, AG.CODE_BANQUE CODE_BANQUE
	from SCOR_AGENCE AG--, SCOR_DELEGUER DER
	where 
	CODE_AGENCE in(select  CODE_AGENCE from SCOR_DELEGUER where
	CODE_BANQUE= @CODE_BANQUE
	AND ID_SCOR_DELEGATION=@ID_LIGNE)

End


GO
/****** Object:  StoredProcedure [dbo].[PS_SCOR_Tableau_SchemaDelegataire_Liste]    Script Date: 14/03/2023 10:01:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create Procedure [dbo].[PS_SCOR_Tableau_SchemaDelegataire_Liste]
@ID_LIGNE int
,@CODE_BANQUE varchar(50)
As
Begin

	Select 
	UT.ID_USER ID_USER, UT.NOM_USER NOM_USER, UT.PRENOM_USER PRENOM_USER, UT.PRENOM_USER+' '+UT.NOM_USER NOMCOMPLET,UT.EMAIL_USER EMAIL_USER
	from SCOR_UTILISATEUR UT--, SCOR_DELEGUER DER0
	where 
	 UT.CODE_AGENCE IN( SELECT CODE_AGENCE FROM SCOR_AGENCE WHERE CODE_BANQUE=@CODE_BANQUE)
	AND ID_USER in(select ID_USER from SCOR_DELEGUER where  ID_SCOR_DELEGATION=@ID_LIGNE and CODE_AGENCE in ( SELECT CODE_AGENCE FROM SCOR_AGENCE WHERE CODE_BANQUE=@CODE_BANQUE))


End



GO











--USE [ScoringDB]
--GO
--/****** Object:  StoredProcedure [dbo].[PS_SCOR_Tableau_SchemaDelegataire_Liste]    Script Date: 14/03/2023 10:01:01 ******/
--DROP PROCEDURE [dbo].[PS_SCOR_Tableau_SchemaDelegataire_Liste]
--GO
--/****** Object:  StoredProcedure [dbo].[PS_SCOR_Tableau_SchemaDelegataire_C]    Script Date: 14/03/2023 10:01:01 ******/
--DROP PROCEDURE [dbo].[PS_SCOR_Tableau_SchemaDelegataire_C]
--GO
--/****** Object:  StoredProcedure [dbo].[PS_SCOR_Tableau_SchemaDelegataire_B]    Script Date: 14/03/2023 10:01:01 ******/
--DROP PROCEDURE [dbo].[PS_SCOR_Tableau_SchemaDelegataire_B]
--GO
--/****** Object:  StoredProcedure [dbo].[PS_SCOR_Tableau_SchemaDelegataire_A1]    Script Date: 14/03/2023 10:01:01 ******/
--DROP PROCEDURE [dbo].[PS_SCOR_Tableau_SchemaDelegataire_A1]
--GO
--/****** Object:  StoredProcedure [dbo].[PS_SCOR_Tableau_SchemaDelegataire_A]    Script Date: 14/03/2023 10:01:01 ******/
--DROP PROCEDURE [dbo].[PS_SCOR_Tableau_SchemaDelegataire_A]
--GO
--/****** Object:  StoredProcedure [dbo].[PS_SCOR_Supp_SchemaDelegataire_D]    Script Date: 14/03/2023 10:01:01 ******/
--DROP PROCEDURE [dbo].[PS_SCOR_Supp_SchemaDelegataire_D]
--GO
--/****** Object:  StoredProcedure [dbo].[PS_SCOR_Supp_SchemaDelegataire_C1]    Script Date: 14/03/2023 10:01:01 ******/
--DROP PROCEDURE [dbo].[PS_SCOR_Supp_SchemaDelegataire_C1]
--GO
--/****** Object:  StoredProcedure [dbo].[PS_SCOR_Supp_SchemaDelegataire_B]    Script Date: 14/03/2023 10:01:01 ******/
--DROP PROCEDURE [dbo].[PS_SCOR_Supp_SchemaDelegataire_B]
--GO
--/****** Object:  StoredProcedure [dbo].[PS_SCOR_Supp_SchemaDelegataire_A]    Script Date: 14/03/2023 10:01:01 ******/
--DROP PROCEDURE [dbo].[PS_SCOR_Supp_SchemaDelegataire_A]
--GO
--/****** Object:  StoredProcedure [dbo].[PS_SCOR_Specif_SchemaDelegataire_B]    Script Date: 14/03/2023 10:01:01 ******/
--DROP PROCEDURE [dbo].[PS_SCOR_Specif_SchemaDelegataire_B]
--GO
--/****** Object:  StoredProcedure [dbo].[PS_SCOR_Specif_SchemaDelegataire_A]    Script Date: 14/03/2023 10:01:01 ******/
--DROP PROCEDURE [dbo].[PS_SCOR_Specif_SchemaDelegataire_A]
--GO
--/****** Object:  StoredProcedure [dbo].[PS_SCOR_Selection_List_Seuil_Specif]    Script Date: 14/03/2023 10:01:01 ******/
--DROP PROCEDURE [dbo].[PS_SCOR_Selection_List_Seuil_Specif]
--GO
--/****** Object:  StoredProcedure [dbo].[PS_SCOR_Selection_List_Seuil]    Script Date: 14/03/2023 10:01:01 ******/
--DROP PROCEDURE [dbo].[PS_SCOR_Selection_List_Seuil]
--GO
--/****** Object:  StoredProcedure [dbo].[PS_SCOR_Mod_SchemaDelegataire_A]    Script Date: 14/03/2023 10:01:01 ******/
--DROP PROCEDURE [dbo].[PS_SCOR_Mod_SchemaDelegataire_A]
--GO
--/****** Object:  StoredProcedure [dbo].[PS_SCOR_Insert_SchemaDelegataire_C]    Script Date: 14/03/2023 10:01:01 ******/
--DROP PROCEDURE [dbo].[PS_SCOR_Insert_SchemaDelegataire_C]
--GO
--/****** Object:  StoredProcedure [dbo].[PS_SCOR_Insert_SchemaDelegataire_B]    Script Date: 14/03/2023 10:01:01 ******/
--DROP PROCEDURE [dbo].[PS_SCOR_Insert_SchemaDelegataire_B]
--GO
--/****** Object:  StoredProcedure [dbo].[PS_SCOR_Insert_SchemaDelegataire_A]    Script Date: 14/03/2023 10:01:01 ******/
--DROP PROCEDURE [dbo].[PS_SCOR_Insert_SchemaDelegataire_A]
--GO
--/****** Object:  StoredProcedure [dbo].[PS_SCOR_Insert_SchemaDelegataire_A]    Script Date: 14/03/2023 10:01:01 ******/
--SET ANSI_NULLS ON
--GO
--SET QUOTED_IDENTIFIER ON
--GO
--Create Procedure [dbo].[PS_SCOR_Insert_SchemaDelegataire_A]
--@LIBELLE_SEUIL_DELEGUATION varchar(100)
--,@MAX_SCOR_SEUIL_DELEGUATION bigint
--,@MIN_SCOR_SEUIL_DELEGUATION bigint
--,@CODE_BANQUE varchar(50)
--As
--Begin
--declare @ID_SCOR_SEUIL_DELEGUATION int =0
--SELECT @ID_SCOR_SEUIL_DELEGUATION=MAX(ISNULL(ID_SCOR_SEUIL_DELEGUATION,0)) FROM SCOR_SEUIL_DELEGUATION 
--SET @ID_SCOR_SEUIL_DELEGUATION=ISNULL(@ID_SCOR_SEUIL_DELEGUATION,0)+1

--	if (select count(*) from SCOR_BANQUE where CODE_BANQUE = @CODE_BANQUE)>0
--	Begin
--		INSERT INTO SCOR_SEUIL_DELEGUATION
--			   (ID_SCOR_SEUIL_DELEGUATION, LIBELLE_SEUIL_DELEGUATION
--			   , MAX_SCOR_SEUIL_DELEGUATION, MIN_SCOR_SEUIL_DELEGUATION,CODE_BANQUE)
--		 VALUES
--			   (@ID_SCOR_SEUIL_DELEGUATION, @LIBELLE_SEUIL_DELEGUATION
--			   ,@MAX_SCOR_SEUIL_DELEGUATION, @MIN_SCOR_SEUIL_DELEGUATION, @CODE_BANQUE)
--	End
--End


--GO
--/****** Object:  StoredProcedure [dbo].[PS_SCOR_Insert_SchemaDelegataire_B]    Script Date: 14/03/2023 10:01:01 ******/
--SET ANSI_NULLS ON
--GO
--SET QUOTED_IDENTIFIER ON
--GO
--Create Procedure [dbo].[PS_SCOR_Insert_SchemaDelegataire_B]
--@LIBELLE_SCOR_DELEGATION varchar(50)
--,@ID_SCOR_SEUIL_DELEGUATION int
--As
--Begin
--declare @ID_SCOR_DELEGATION int =0
--SELECT @ID_SCOR_DELEGATION=MAX(ISNULL(ID_SCOR_DELEGATION,0)) FROM SCOR_DELEGUER
--SET @ID_SCOR_DELEGATION=ISNULL(@ID_SCOR_DELEGATION,0)+1

--	INSERT INTO [dbo].[SCOR_DELEGATION]
--           ([ID_SCOR_DELEGATION]
--           ,[LIBELLE_SCOR_DELEGATION]
--           ,[ID_SCOR_SEUIL_DELEGUATION])
--     VALUES
--           (@ID_SCOR_DELEGATION
--           ,@LIBELLE_SCOR_DELEGATION
--           ,@ID_SCOR_SEUIL_DELEGUATION)

	
--End


--GO
--/****** Object:  StoredProcedure [dbo].[PS_SCOR_Insert_SchemaDelegataire_C]    Script Date: 14/03/2023 10:01:01 ******/
--SET ANSI_NULLS ON
--GO
--SET QUOTED_IDENTIFIER ON
--GO
--Create Procedure [dbo].[PS_SCOR_Insert_SchemaDelegataire_C]
--@ID_SCOR_DELEGATION int
--,@ID_USER char(6)
--,@CODE_AGENCE char(5)
--As
--Begin
--	INSERT INTO SCOR_DELEGUER
--           (ID_SCOR_DELEGATION,ID_USER 
--		    ,CODE_AGENCE, DATEDELEGUER)
--     VALUES
--           (@ID_SCOR_DELEGATION, @ID_USER
--           ,@CODE_AGENCE, GETDATE())
--End


--GO
--/****** Object:  StoredProcedure [dbo].[PS_SCOR_Mod_SchemaDelegataire_A]    Script Date: 14/03/2023 10:01:01 ******/
--SET ANSI_NULLS ON
--GO
--SET QUOTED_IDENTIFIER ON
--GO
--Create Procedure [dbo].[PS_SCOR_Mod_SchemaDelegataire_A]
--@LIBELLE_SEUIL_DELEGUATION varchar(100)
--,@MAX_SCOR_SEUIL_DELEGUATION bigint
--,@MIN_SCOR_SEUIL_DELEGUATION bigint
--,@ID_SCOR_SEUIL_DELEGUATION int
--As
--Begin
--	UPDATE SCOR_SEUIL_DELEGUATION
--   SET 
--      LIBELLE_SEUIL_DELEGUATION = @LIBELLE_SEUIL_DELEGUATION
--      ,MAX_SCOR_SEUIL_DELEGUATION = @MAX_SCOR_SEUIL_DELEGUATION
--      ,MIN_SCOR_SEUIL_DELEGUATION = @MIN_SCOR_SEUIL_DELEGUATION
-- WHERE ID_SCOR_SEUIL_DELEGUATION = @ID_SCOR_SEUIL_DELEGUATION
--End


--GO
--/****** Object:  StoredProcedure [dbo].[PS_SCOR_Selection_List_Seuil]    Script Date: 14/03/2023 10:01:01 ******/
--SET ANSI_NULLS ON
--GO
--SET QUOTED_IDENTIFIER ON
--GO
--Create Procedure [dbo].[PS_SCOR_Selection_List_Seuil]
--@CODE_BANQUE T_CODE_5 null
--As
--Begin
--	if @CODE_BANQUE is null set @CODE_BANQUE='%'
--	Select * from SCOR_SEUIL_DELEGUATION where CODE_BANQUE like @CODE_BANQUE order by MAX_SCOR_SEUIL_DELEGUATION
--End


--GO
--/****** Object:  StoredProcedure [dbo].[PS_SCOR_Selection_List_Seuil_Specif]    Script Date: 14/03/2023 10:01:01 ******/
--SET ANSI_NULLS ON
--GO
--SET QUOTED_IDENTIFIER ON
--GO
--Create Procedure [dbo].[PS_SCOR_Selection_List_Seuil_Specif]
--@ID_SCOR_SEUIL_DELEGUATION int null,
--@LIBELLE_SEUIL_DELEGUATION varchar(50) null,
--@MAX_SCOR_SEUIL_DELEGUATION bigint null,
--@MIN_SCOR_SEUIL_DELEGUATION bigint null,
--@ValeurComparaison bigint null,
--@Intervalle varchar(50) null
--As
--Begin
--	if @ID_SCOR_SEUIL_DELEGUATION is not null 

--	BEGIN

--	Select * from SCOR_SEUIL_DELEGUATION where ID_SCOR_SEUIL_DELEGUATION=@ID_SCOR_SEUIL_DELEGUATION 

--	END

--	if @LIBELLE_SEUIL_DELEGUATION is not null

--	BEGIN

--	Select * from SCOR_SEUIL_DELEGUATION where LIBELLE_SEUIL_DELEGUATION like '%'+@LIBELLE_SEUIL_DELEGUATION+'%' 

--	END

--	if @MAX_SCOR_SEUIL_DELEGUATION is not null

--	BEGIN

--	Select * from SCOR_SEUIL_DELEGUATION where MAX_SCOR_SEUIL_DELEGUATION = @MAX_SCOR_SEUIL_DELEGUATION

--	END
 
--	if @MIN_SCOR_SEUIL_DELEGUATION is not null

--	BEGIN

--	Select * from SCOR_SEUIL_DELEGUATION where MIN_SCOR_SEUIL_DELEGUATION = @MIN_SCOR_SEUIL_DELEGUATION  

--	END

--if @ValeurComparaison is not null
--begin
--	if @Intervalle = 'FF' 
--	Select * from SCOR_SEUIL_DELEGUATION where MIN_SCOR_SEUIL_DELEGUATION <= @ValeurComparaison 
--	And MAX_SCOR_SEUIL_DELEGUATION >= @ValeurComparaison 
--	if @Intervalle = 'FO' 
--	Select * from SCOR_SEUIL_DELEGUATION where MIN_SCOR_SEUIL_DELEGUATION <= @ValeurComparaison 
--	And MAX_SCOR_SEUIL_DELEGUATION > @ValeurComparaison 
--	if @Intervalle = 'OF' 
--	Select * from SCOR_SEUIL_DELEGUATION where MIN_SCOR_SEUIL_DELEGUATION < @ValeurComparaison 
--	And MAX_SCOR_SEUIL_DELEGUATION >= @ValeurComparaison
--	if @Intervalle = 'OO' 
--	Select * from SCOR_SEUIL_DELEGUATION where MIN_SCOR_SEUIL_DELEGUATION < @ValeurComparaison 
--	And MAX_SCOR_SEUIL_DELEGUATION > @ValeurComparaison  
--End

--End

-------------------------------------------------------------------------------------------------------------
------------------------------------PS_SCOR_Tableau_SchemaDelegataire_A ALL DELEGATION BANQUE--------------------------------------
-------------------------------------------------------------------------------------------------------------


--GO
--/****** Object:  StoredProcedure [dbo].[PS_SCOR_Specif_SchemaDelegataire_A]    Script Date: 14/03/2023 10:01:01 ******/
--SET ANSI_NULLS ON
--GO
--SET QUOTED_IDENTIFIER ON
--GO
--Create Procedure [dbo].[PS_SCOR_Specif_SchemaDelegataire_A]
--@ID_SCOR_SEUIL_DELEGUATION int,
--@LIBELLE_SCOR_DELEGATION varchar(50)
--As
--Begin

--	Select 
--	DEL.ID_SCOR_DELEGATION ID_LIGNE
--	,DEL.ID_SCOR_SEUIL_DELEGUATION
--	,DEL.LIBELLE_SCOR_DELEGATION
--	from SCOR_DELEGATION DEL, SCOR_SEUIL_DELEGUATION SEU--, SCOR_DELEGUER DER
--	where 
--	DEL.ID_SCOR_SEUIL_DELEGUATION = SEU.ID_SCOR_SEUIL_DELEGUATION
--	AND DEL.ID_SCOR_SEUIL_DELEGUATION = @ID_SCOR_SEUIL_DELEGUATION
--	AND DEL.LIBELLE_SCOR_DELEGATION= @LIBELLE_SCOR_DELEGATION
--	--AND DER.CODE_AGENCE IN( SELECT CODE_AGENCE FROM SCOR_AGENCE WHERE CODE_BANQUE=@CODE_BANQUE)

--End


--GO
--/****** Object:  StoredProcedure [dbo].[PS_SCOR_Specif_SchemaDelegataire_B]    Script Date: 14/03/2023 10:01:01 ******/
--SET ANSI_NULLS ON
--GO
--SET QUOTED_IDENTIFIER ON
--GO

--Create Procedure [dbo].[PS_SCOR_Specif_SchemaDelegataire_B]

--@bloc int,
--@ID_SCOR_SEUIL_DELEGUATION int,
--@ID_Dossier varchar(10),
--@CODE_BANQUE varchar(50)
--As
--Begin
--IF @bloc = -1
--	BEGIN
--			SELECT * FROM SCOR_DELEGATION , SCOR_SEUIL_DELEGUATION
--	END
--	IF @bloc = 0
--	BEGIN
--			Select 
--			DEL.ID_SCOR_DELEGATION 
--			,DEL.ID_SCOR_SEUIL_DELEGUATION
--			,DEL.LIBELLE_SCOR_DELEGATION
--			from SCOR_DELEGATION DEL, SCOR_SEUIL_DELEGUATION SEU--, SCOR_DELEGUER DER
--			where 
--			DEL.ID_SCOR_SEUIL_DELEGUATION = SEU.ID_SCOR_SEUIL_DELEGUATION
--			AND DEL.ID_SCOR_SEUIL_DELEGUATION = @ID_SCOR_SEUIL_DELEGUATION
--			and DEL.ID_SCOR_DELEGATION in(select ID_SCOR_DELEGATION from SCOR_DELEGUER where CODE_AGENCE in ( SELECT CODE_AGENCE FROM SCOR_AGENCE WHERE CODE_BANQUE=@CODE_BANQUE))
--			--AND DEL.LIBELLE_SCOR_DELEGATION= @LIBELLE_SCOR_DELEGATION
--			--AND DER.CODE_AGENCE IN( SELECT CODE_AGENCE FROM SCOR_AGENCE WHERE CODE_BANQUE=@CODE_BANQUE)
--	END
--	IF @bloc = 1
--	BEGIN
--		Declare @id_scor_seul as int=0;

--		select @id_scor_seul=ID_SCOR_SEUIL_DELEGUATION from SCOR_DOSSIER_SEUIL_CREDIT where Ltrim(Rtrim(ID_DOSSIER))=Ltrim(Rtrim(@ID_Dossier))

--		Select 
--		DEL.ID_SCOR_DELEGATION 
--		,DEL.ID_SCOR_SEUIL_DELEGUATION
--		,DEL.LIBELLE_SCOR_DELEGATION
--		from SCOR_DELEGATION DEL, SCOR_SEUIL_DELEGUATION SEU--, SCOR_DELEGUER DER
--		where 
--		DEL.ID_SCOR_SEUIL_DELEGUATION = SEU.ID_SCOR_SEUIL_DELEGUATION
--		AND DEL.ID_SCOR_SEUIL_DELEGUATION = @id_scor_seul
--		and DEL.ID_SCOR_DELEGATION in(select ID_SCOR_DELEGATION from SCOR_DELEGUER where CODE_AGENCE in ( SELECT CODE_AGENCE FROM SCOR_AGENCE WHERE CODE_BANQUE=@CODE_BANQUE))
--		--AND DEL.LIBELLE_SCOR_DELEGATION= @LIBELLE_SCOR_DELEGATION
--		--AND DER.CODE_AGENCE IN( SELECT CODE_AGENCE FROM SCOR_AGENCE WHERE CODE_BANQUE=@CODE_BANQUE)

--	END


	

--End



--GO
--/****** Object:  StoredProcedure [dbo].[PS_SCOR_Supp_SchemaDelegataire_A]    Script Date: 14/03/2023 10:01:01 ******/
--SET ANSI_NULLS ON
--GO
--SET QUOTED_IDENTIFIER ON
--GO
--Create Procedure [dbo].[PS_SCOR_Supp_SchemaDelegataire_A]
--@ID_SCOR_DELEGATION int
--,@CODE_AGENCE char(5)
--As
--Begin
--	DELETE FROM SCOR_DELEGUER
--      WHERE 
--	  ID_SCOR_DELEGATION=@ID_SCOR_DELEGATION
--	  AND CODE_AGENCE=@CODE_AGENCE
--End


--GO
--/****** Object:  StoredProcedure [dbo].[PS_SCOR_Supp_SchemaDelegataire_B]    Script Date: 14/03/2023 10:01:01 ******/
--SET ANSI_NULLS ON
--GO
--SET QUOTED_IDENTIFIER ON
--GO
--Create Procedure [dbo].[PS_SCOR_Supp_SchemaDelegataire_B]
--@ID_SCOR_DELEGATION int
--,@ID_USER char(6)
--As
--Begin
--	DELETE FROM SCOR_DELEGUER
--      WHERE 
--	  ID_SCOR_DELEGATION=@ID_SCOR_DELEGATION
--	  AND ID_USER=@ID_USER
--End

-------------------------------------------------------------------------------------------------------------
------------------------------------PS_SCOR_Supp_SchemaDelegataire_C DELEGATION--------------------------------------
-------------------------------------------------------------------------------------------------------------


--GO
--/****** Object:  StoredProcedure [dbo].[PS_SCOR_Supp_SchemaDelegataire_C1]    Script Date: 14/03/2023 10:01:01 ******/
--SET ANSI_NULLS ON
--GO
--SET QUOTED_IDENTIFIER ON
--GO
--Create Procedure [dbo].[PS_SCOR_Supp_SchemaDelegataire_C1]
--@ID_SCOR_DELEGATION int
--As
--Begin
--	DELETE FROM SCOR_DELEGUER
--      WHERE 
--	  ID_SCOR_DELEGATION=@ID_SCOR_DELEGATION

--	DELETE FROM SCOR_DELEGATION
--      WHERE 
--	  ID_SCOR_DELEGATION=@ID_SCOR_DELEGATION
	  
--End


--GO
--/****** Object:  StoredProcedure [dbo].[PS_SCOR_Supp_SchemaDelegataire_D]    Script Date: 14/03/2023 10:01:01 ******/
--SET ANSI_NULLS ON
--GO
--SET QUOTED_IDENTIFIER ON
--GO
--Create Procedure [dbo].[PS_SCOR_Supp_SchemaDelegataire_D]
--@CODE_BANQUE varchar(50)
--As
--Begin

----DECLARE @ID_SCOR_DELEGATION table
----( ID_SCOR_DELEGATION int )
--SELECT ID_SCOR_DELEGATION into ##ID_SCOR_DELEGATION FROM SCOR_DELEGUER
--WHERE CODE_AGENCE IN( SELECT CODE_AGENCE FROM SCOR_AGENCE WHERE CODE_BANQUE=@CODE_BANQUE)

--	DELETE FROM SCOR_DELEGUER
--      WHERE 
--	  CODE_AGENCE IN( SELECT CODE_AGENCE FROM SCOR_AGENCE WHERE CODE_BANQUE=@CODE_BANQUE)

-- SELECT ID_SCOR_SEUIL_DELEGUATION into ##ID_SCOR_SEUIL_DELEGUATION FROM SCOR_DELEGATION
--WHERE ID_SCOR_DELEGATION in (SELECT ID_SCOR_DELEGATION from ##ID_SCOR_DELEGATION)

--	DELETE FROM SCOR_DELEGATION
--      WHERE 
--	  ID_SCOR_DELEGATION in (SELECT ID_SCOR_DELEGATION from ##ID_SCOR_DELEGATION)


--	DELETE FROM SCOR_DOSSIER_SEUIL_CREDIT


--	  DELETE FROM SCOR_SEUIL_DELEGUATION
--      WHERE 
--	  ID_SCOR_SEUIL_DELEGUATION in (SELECT ID_SCOR_SEUIL_DELEGUATION from ##ID_SCOR_SEUIL_DELEGUATION)
--	  BEGIN TRY
--			DELETE FROM SCOR_SEUIL_DELEGUATION
--		END TRY
--		BEGIN CATCH
--			 DECLARE @decideur int =1
--		END CATCH;
	  
--End


--GO
--/****** Object:  StoredProcedure [dbo].[PS_SCOR_Tableau_SchemaDelegataire_A]    Script Date: 14/03/2023 10:01:01 ******/
--SET ANSI_NULLS ON
--GO
--SET QUOTED_IDENTIFIER ON
--GO
--Create Procedure [dbo].[PS_SCOR_Tableau_SchemaDelegataire_A]
--@CODE_BANQUE varchar(50)
--As
--Begin

--	Select 
--	DEL.ID_SCOR_DELEGATION ID_LIGNE
--	, DEL.LIBELLE_SCOR_DELEGATION NOM_DELEG
--	, Convert(varchar(50),SEU.MIN_SCOR_SEUIL_DELEGUATION) + ' à ' + Convert(varchar(50),SEU.MAX_SCOR_SEUIL_DELEGUATION) SEUIL
--	from SCOR_DELEGATION DEL, SCOR_SEUIL_DELEGUATION SEU, SCOR_DELEGUER DER
--	where 
--	DEL.ID_SCOR_SEUIL_DELEGUATION = SEU.ID_SCOR_SEUIL_DELEGUATION
--	AND DER.CODE_AGENCE IN( SELECT CODE_AGENCE FROM SCOR_AGENCE WHERE CODE_BANQUE=@CODE_BANQUE)

--End


--GO
--/****** Object:  StoredProcedure [dbo].[PS_SCOR_Tableau_SchemaDelegataire_A1]    Script Date: 14/03/2023 10:01:01 ******/
--SET ANSI_NULLS ON
--GO
--SET QUOTED_IDENTIFIER ON
--GO
--Create Procedure [dbo].[PS_SCOR_Tableau_SchemaDelegataire_A1]
--@CODE_BANQUE varchar(50)
--As
--Begin

--	Select 
--	DEL.ID_SCOR_DELEGATION ID_LIGNE
--	, DEL.LIBELLE_SCOR_DELEGATION NOM_DELEG
--	, Convert(varchar(50),SEU.MIN_SCOR_SEUIL_DELEGUATION) + ' à ' + Convert(varchar(50),SEU.MAX_SCOR_SEUIL_DELEGUATION) SEUIL
--	,SEU.MAX_SCOR_SEUIL_DELEGUATION MAXSEUIL
--	,SEU.MIN_SCOR_SEUIL_DELEGUATION MINSEUIL
--	--from SCOR_DELEGATION DEL, SCOR_SEUIL_DELEGUATION SEU, SCOR_DELEGUER DER
--	--where 
--	--DEL.ID_SCOR_SEUIL_DELEGUATION = SEU.ID_SCOR_SEUIL_DELEGUATION
--	--AND DEL.ID_SCOR_DELEGATION = DER.ID_SCOR_DELEGATION
--	--AND DER.CODE_AGENCE IN( SELECT CODE_AGENCE FROM SCOR_AGENCE WHERE CODE_BANQUE='BDU01')
	
--from SCOR_DELEGATION DEL, SCOR_SEUIL_DELEGUATION SEU
--	where 
--	DEL.ID_SCOR_SEUIL_DELEGUATION = SEU.ID_SCOR_SEUIL_DELEGUATION
--	AND DEL.ID_SCOR_DELEGATION in (select ID_SCOR_DELEGATION from SCOR_DELEGUER where
--	 CODE_AGENCE IN( SELECT CODE_AGENCE FROM SCOR_AGENCE WHERE CODE_BANQUE=@CODE_BANQUE))

--End


--GO
--/****** Object:  StoredProcedure [dbo].[PS_SCOR_Tableau_SchemaDelegataire_B]    Script Date: 14/03/2023 10:01:01 ******/
--SET ANSI_NULLS ON
--GO
--SET QUOTED_IDENTIFIER ON
--GO
--Create Procedure [dbo].[PS_SCOR_Tableau_SchemaDelegataire_B]
--@ID_LIGNE int
--,@CODE_BANQUE varchar(50)
--As
--Begin

--	Select 
--	UT.ID_USER ID_USER, UT.NOM_USER NOM_USER, UT.PRENOM_USER PRENOM_USER, UT.PRENOM_USER+' '+UT.NOM_USER NOMCOMPLET
--	from SCOR_UTILISATEUR UT--, SCOR_DELEGUER DER
--	where 
	
--	 UT.CODE_AGENCE IN( SELECT CODE_AGENCE FROM SCOR_AGENCE WHERE CODE_BANQUE=@CODE_BANQUE)
--	AND ID_USER in(select ID_USER from SCOR_DELEGUER where  ID_SCOR_DELEGATION=@ID_LIGNE and CODE_AGENCE in ( SELECT CODE_AGENCE FROM SCOR_AGENCE WHERE CODE_BANQUE=@CODE_BANQUE))


--End


--GO
--/****** Object:  StoredProcedure [dbo].[PS_SCOR_Tableau_SchemaDelegataire_C]    Script Date: 14/03/2023 10:01:01 ******/
--SET ANSI_NULLS ON
--GO
--SET QUOTED_IDENTIFIER ON
--GO
--Create Procedure [dbo].[PS_SCOR_Tableau_SchemaDelegataire_C]
--@ID_LIGNE int
--,@CODE_BANQUE varchar(50)
--As
--Begin

--	Select 
--	AG.CODE_AGENCE CODE_AGENCE, AG.NOM_AGENCE NOMAGENCE, AG.GUICHET_AGENCE GUICHET_AGENCE, AG.CODE_BANQUE CODE_BANQUE
--	from SCOR_AGENCE AG--, SCOR_DELEGUER DER
--	where 
--	CODE_AGENCE in(select  CODE_AGENCE from SCOR_DELEGUER where
--	CODE_BANQUE= @CODE_BANQUE
--	AND ID_SCOR_DELEGATION=@ID_LIGNE)

--End


--GO
--/****** Object:  StoredProcedure [dbo].[PS_SCOR_Tableau_SchemaDelegataire_Liste]    Script Date: 14/03/2023 10:01:01 ******/
--SET ANSI_NULLS ON
--GO
--SET QUOTED_IDENTIFIER ON
--GO

--Create Procedure [dbo].[PS_SCOR_Tableau_SchemaDelegataire_Liste]
--@ID_LIGNE int
--,@CODE_BANQUE varchar(50)
--As
--Begin

--	Select 
--	UT.ID_USER ID_USER, UT.NOM_USER NOM_USER, UT.PRENOM_USER PRENOM_USER, UT.PRENOM_USER+' '+UT.NOM_USER NOMCOMPLET,UT.EMAIL_USER EMAIL_USER
--	from SCOR_UTILISATEUR UT--, SCOR_DELEGUER DER0
--	where 
--	 UT.CODE_AGENCE IN( SELECT CODE_AGENCE FROM SCOR_AGENCE WHERE CODE_BANQUE=@CODE_BANQUE)
--	AND ID_USER in(select ID_USER from SCOR_DELEGUER where  ID_SCOR_DELEGATION=@ID_LIGNE and CODE_AGENCE in ( SELECT CODE_AGENCE FROM SCOR_AGENCE WHERE CODE_BANQUE=@CODE_BANQUE))


--End



--GO
