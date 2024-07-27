USE [WEB_BILAN_DB]
GO

/****** Object:  StoredProcedure [dbo].[PS_SCOR_AGENCE]    Script Date: 03/03/2023 00:47:24 ******/
DROP PROCEDURE [dbo].[PS_SCOR_AGENCE]
GO

/****** Object:  StoredProcedure [dbo].[PS_SCOR_AGENCE]    Script Date: 03/03/2023 00:47:24 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[PS_SCOR_AGENCE]
@bloc AS INT,
@code_agence AS CHAR(10),
@code_banque AS CHAR(5),
@nom_agence  AS VARCHAR(60),
@guichet_agence AS CHAR(5)
AS
BEGIN

--INSERTION AGENCE--
IF @bloc=0
BEGIN
  INSERT INTO SCOR_AGENCE
           (CODE_AGENCE
           ,CODE_BANQUE
           ,NOM_AGENCE
		   ,GUICHET_AGENCE )
     VALUES
           (@code_agence
           ,@code_banque
           ,@nom_agence
		   ,@guichet_agence )
END
--MODIFICATION AGENCE--
IF @bloc=1
BEGIN
UPDATE SCOR_AGENCE
   SET
      CODE_BANQUE = @code_banque
      ,NOM_AGENCE = @nom_agence
	  ,GUICHET_AGENCE = @guichet_agence
 WHERE CODE_AGENCE = @code_agence
END
--SUPPRESSION AGENCE--
IF @bloc=2
BEGIN
DELETE FROM SCOR_AGENCE
WHERE CODE_AGENCE = @code_agence
END
--lISTE AGENCE--
IF @bloc=3
BEGIN
SELECT CODE_AGENCE
      ,CODE_BANQUE
      ,NOM_AGENCE
	  ,GUICHET_AGENCE
  FROM SCOR_AGENCE
END
--SELECTION AGENCE--
IF @bloc=4
BEGIN
SELECT CODE_AGENCE
      ,CODE_BANQUE
      ,NOM_AGENCE
	  ,GUICHET_AGENCE
  FROM SCOR_AGENCE
  WHERE CODE_AGENCE = @code_agence
END
--SELECTION MAX CODE AGENCE--
IF @bloc=5
BEGIN
SELECT MAX(CODE_AGENCE)
  FROM SCOR_AGENCE
END
IF @bloc=6
BEGIN
SELECT CODE_AGENCE
      ,CODE_BANQUE
      ,NOM_AGENCE
	  ,GUICHET_AGENCE
  FROM SCOR_AGENCE
  WHERE CODE_BANQUE = @code_banque
END
END






GO

