
-- Identifier les objets de BD (tables, procédures stockées, déclencheurs) à mettre à jour

--select * from SCOR_PAYS_NATIONAL  where PAYS_NOM like '%CO%'
--select * from SCOR_BANQUE 
--select * from SCOR_AGENCE 

--Ajout de la colonne PAYS_CODE

use ScoringDB
go
IF NOT EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = N'PAYS_CODE'
          AND Object_ID = Object_ID(N'dbo.SCOR_BANQUE'))
BEGIN
    ALTER TABLE SCOR_BANQUE ADD PAYS_CODE T_CODE_4 null 
END
go

IF NOT EXISTS (SELECT * 
           FROM sys.foreign_keys 
           WHERE object_id = OBJECT_ID(N'dbo.FK_BANQUE_PAYS_NATIONAL') 
             AND parent_object_id = OBJECT_ID(N'dbo.SCOR_BANQUE'))
BEGIN
    ALTER TABLE SCOR_BANQUE ADD CONSTRAINT FK_BANQUE_PAYS_NATIONAL Foreign key (PAYS_CODE) references SCOR_PAYS_NATIONAL(PAYS_CODE)
END
go

--Ajout de la colonne GROUPE_BANQUE

IF NOT EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = N'GROUPE_BANQUE'
          AND Object_ID = Object_ID(N'dbo.SCOR_BANQUE'))
BEGIN
	ALTER TABLE SCOR_BANQUE ADD GROUPE_BANQUE T_CODE_5 NULL 
END
GO

--Ajout de la colonne REPERTOIRE_DONNEES

IF NOT EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = N'REPERTOIRE_DONNEES'
          AND Object_ID = Object_ID(N'dbo.SCOR_BANQUE'))
BEGIN
	ALTER TABLE SCOR_BANQUE ADD REPERTOIRE_DONNEES VARCHAR(MAX)
END
GO
 
use WEB_BILAN_DB
go
IF NOT EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = N'PAYS_CODE'
          AND Object_ID = Object_ID(N'dbo.SCOR_BANQUE'))
BEGIN
    ALTER TABLE SCOR_BANQUE ADD PAYS_CODE varchar(4) null 
	
END

go
--Ajout de la colonne GROUPE_BANQUE

IF NOT EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = N'GROUPE_BANQUE'
          AND Object_ID = Object_ID(N'dbo.SCOR_BANQUE'))
BEGIN
	ALTER TABLE SCOR_BANQUE ADD GROUPE_BANQUE varchar(10) NULL 
END
GO

--Ajout de la colonne REPERTOIRE_DONNEES

IF NOT EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = N'REPERTOIRE_DONNEES'
          AND Object_ID = Object_ID(N'dbo.SCOR_BANQUE'))
BEGIN
	ALTER TABLE SCOR_BANQUE ADD REPERTOIRE_DONNEES VARCHAR(MAX)
END
GO
