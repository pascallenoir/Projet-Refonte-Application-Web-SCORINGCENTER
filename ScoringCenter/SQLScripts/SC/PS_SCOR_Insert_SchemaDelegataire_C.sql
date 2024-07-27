USE [ScoringDB]
GO

/****** Object:  StoredProcedure [dbo].[PS_SCOR_Insert_SchemaDelegataire_C]    Script Date: 28/02/2023 21:24:20 ******/
DROP PROCEDURE [dbo].[PS_SCOR_Insert_SchemaDelegataire_C]
GO

/****** Object:  StoredProcedure [dbo].[PS_SCOR_Insert_SchemaDelegataire_C]    Script Date: 28/02/2023 21:24:20 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE Procedure [dbo].[PS_SCOR_Insert_SchemaDelegataire_C]
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

