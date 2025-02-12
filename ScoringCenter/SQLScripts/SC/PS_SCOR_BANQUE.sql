USE [ScoringDB]
GO
if Object_id('PS_SCOR_BANQUE','P') is not null 
Drop PROCEDURE PS_SCOR_BANQUE
GO
Create PROCEDURE PS_SCOR_BANQUE
@bloc AS INT,
@code_banque AS CHAR(5),
@nom_banque  AS VARCHAR(60),
@sigle_banque AS VARCHAR(25)
AS
BEGIN

--INSERTION BANQUE--
IF @bloc=0
BEGIN
  INSERT INTO SCOR_BANQUE
           (CODE_BANQUE
           ,NOM_BANQUE
           ,SIGLE_BANQUE)
     VALUES
           (@code_banque 
           ,@nom_banque
           ,@sigle_banque)
END
--MODIFICATION BANQUE--
IF @bloc=1
BEGIN
UPDATE SCOR_BANQUE
   SET
      NOM_BANQUE = @nom_banque
      ,SIGLE_BANQUE = @sigle_banque
 WHERE CODE_BANQUE = @code_banque
END
--SUPPRESSION BANQUE--
IF @bloc=2
BEGIN
DELETE FROM SCOR_BANQUE 
WHERE CODE_BANQUE = @code_banque 
END
--lISTE BANQUE--
IF @bloc=3
BEGIN
SELECT CODE_BANQUE
      ,NOM_BANQUE
      ,SIGLE_BANQUE
  FROM SCOR_BANQUE
END
--SELECTION BANQUE--
IF @bloc=4
BEGIN
SELECT CODE_BANQUE
      ,NOM_BANQUE
      ,SIGLE_BANQUE
	  ,IMG_BANQUE
	  ,PAYS_CODE
	  ,GROUPE_BANQUE
  FROM SCOR_BANQUE
  WHERE CODE_BANQUE = @code_banque
END
--SELECTION MAX CODE BANQUE--
IF @bloc=5
BEGIN
SELECT MAX(CODE_BANQUE)
  FROM SCOR_BANQUE
END
END