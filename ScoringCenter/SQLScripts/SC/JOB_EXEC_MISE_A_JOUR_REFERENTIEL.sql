--USE [msdb]
--GO

--/****** Object:  Job [JOB_EXEC_MISE_A_JOUR_REFERENTIEL]    Script Date: 08/02/2023 17:47:13 ******/
--EXEC msdb.dbo.sp_delete_job @job_id=N'38a40873-445e-4aba-840c-71a198561c2b', @delete_unused_schedule=1
--GO

--/****** Object:  Job [JOB_EXEC_MISE_A_JOUR_REFERENTIEL]    Script Date: 08/02/2023 17:47:13 ******/
--BEGIN TRANSACTION
--DECLARE @ReturnCode INT
--SELECT @ReturnCode = 0
--/****** Object:  JobCategory [[Uncategorized (Local)]]    Script Date: 08/02/2023 17:47:13 ******/
--IF NOT EXISTS (SELECT name FROM msdb.dbo.syscategories WHERE name=N'[Uncategorized (Local)]' AND category_class=1)
--BEGIN
--EXEC @ReturnCode = msdb.dbo.sp_add_category @class=N'JOB', @type=N'LOCAL', @name=N'[Uncategorized (Local)]'
--IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback

--END

--DECLARE @jobId BINARY(16)
--EXEC @ReturnCode =  msdb.dbo.sp_add_job @job_name=N'JOB_EXEC_MISE_A_JOUR_REFERENTIEL', 
--		@enabled=1, 
--		@notify_level_eventlog=0, 
--		@notify_level_email=0, 
--		@notify_level_netsend=0, 
--		@notify_level_page=0, 
--		@delete_level=0, 
--		@description=N'Job dont le rôle est d''exécuter la procédure stockée de mise à jour du referentiel entreprise', 
--		@category_name=N'[Uncategorized (Local)]',
--		@owner_login_name=N'sa', @job_id = @jobId OUTPUT
--IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
--/****** Object:  Step [Mise à jour reférentiel entreprise]    Script Date: 08/02/2023 17:47:13 ******/
--EXEC @ReturnCode = msdb.dbo.sp_add_jobstep @job_id=@jobId, @step_name=N'Mise à jour reférentiel entreprise', 
--		@step_id=1, 
--		@cmdexec_success_code=0, 
--		@on_success_action=1, 
--		@on_success_step_id=0, 
--		@on_fail_action=2, 
--		@on_fail_step_id=0, 
--		@retry_attempts=0, 
--		@retry_interval=0, 
--		@os_run_priority=0, @subsystem=N'TSQL', 
--		@command=N'EXEC PS_SCOR_MAJ_AUTO_REF_ENTREP', 
--		@database_name=N'ScoringDB', 
--		@flags=0
--IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
--EXEC @ReturnCode = msdb.dbo.sp_update_job @job_id = @jobId, @start_step_id = 1
--IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
--EXEC @ReturnCode = msdb.dbo.sp_add_jobschedule @job_id=@jobId, @name=N'quotidiennement chaque 5 heures', 
--		@enabled=1, 
--		@freq_type=4, 
--		@freq_interval=1, 
--		@freq_subday_type=8, 
--		@freq_subday_interval=5, 
--		@freq_relative_interval=0, 
--		@freq_recurrence_factor=0, 
--		@active_start_date=20230208, 
--		@active_end_date=99991231, 
--		@active_start_time=0, 
--		@active_end_time=235959, 
--		@schedule_uid=N'29ea5c80-71ff-4712-8486-9011acc09b03'
--IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
--EXEC @ReturnCode = msdb.dbo.sp_add_jobserver @job_id = @jobId, @server_name = N'(local)'
--IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
--COMMIT TRANSACTION
--GOTO EndSave
--QuitWithRollback:
--    IF (@@TRANCOUNT > 0) ROLLBACK TRANSACTION
--EndSave:

--GO

USE [msdb]
GO

/****** Object:  Job [JOB_EXEC_MAJ_REFERENTIEL]    Script Date: 17/02/2023 10:19:54 ******/
EXEC msdb.dbo.sp_delete_job @job_id=N'70f9a01b-efa5-48ce-990f-051e4404f39d', @delete_unused_schedule=1
EXEC msdb.dbo.sp_delete_job @job_name=N'JOB_EXEC_MAJ_REFERENTIEL', @delete_unused_schedule=1
GO

/****** Object:  Job [JOB_EXEC_MAJ_REFERENTIEL]    Script Date: 17/02/2023 10:19:54 ******/
BEGIN TRANSACTION
DECLARE @ReturnCode INT
SELECT @ReturnCode = 0
/****** Object:  JobCategory [[Uncategorized (Local)]]    Script Date: 17/02/2023 10:19:54 ******/
IF NOT EXISTS (SELECT name FROM msdb.dbo.syscategories WHERE name=N'[Uncategorized (Local)]' AND category_class=1)
BEGIN
EXEC @ReturnCode = msdb.dbo.sp_add_category @class=N'JOB', @type=N'LOCAL', @name=N'[Uncategorized (Local)]'
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback

END

DECLARE @jobId BINARY(16)
EXEC @ReturnCode =  msdb.dbo.sp_add_job @job_name=N'JOB_EXEC_MAJ_REFERENTIEL', 
		@enabled=1, 
		@notify_level_eventlog=0, 
		@notify_level_email=0, 
		@notify_level_netsend=0, 
		@notify_level_page=0, 
		@delete_level=0, 
		@description=N'Job d''exécution de la procédure stockée de mise à jour du referentiel entreprise', 
		@category_name=N'[Uncategorized (Local)]', 
		@owner_login_name=N'IT-PC\itsogbetse', @job_id = @jobId OUTPUT
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
/****** Object:  Step [Etape mise à jour reférentiel entreprise]    Script Date: 17/02/2023 10:19:54 ******/

--
--DECLARE @CODE_BANQUE CHAR(5), @REPERTOIRE_DONNEES NVARCHAR(MAX), @COMMAND VARCHAR(MAX)
--SELECT @CODE_BANQUE = CODE_BANQUE, @REPERTOIRE_DONNEES = RTRIM(REPERTOIRE_DONNEES) FROM ScoringDB..SCOR_BANQUE WHERE ACTIVE_BANQUE = '1'
--SET @COMMAND = CONCAT(N'EXEC PS_SCOR_MAJ_AUTO_REF_ENTREP ''', @CODE_BANQUE, ''', ''',  @REPERTOIRE_DONNEES, '''')

EXEC @ReturnCode = msdb.dbo.sp_add_jobstep @job_id=@jobId, @step_name=N'Etape mise à jour reférentiel entreprise', 
		@step_id=1, 
		@cmdexec_success_code=0, 
		@on_success_action=1, 
		@on_success_step_id=0, 
		@on_fail_action=2, 
		@on_fail_step_id=0, 
		@retry_attempts=0, 
		@retry_interval=0, 
		@os_run_priority=0, @subsystem=N'TSQL', 
		@command=N'EXEC PS_SCOR_MAJ_AUTO_REF_BANQUES',
		--@command=@COMMAND,
		@database_name=N'ScoringDB', 
		@flags=0
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
EXEC @ReturnCode = msdb.dbo.sp_update_job @job_id = @jobId, @start_step_id = 1
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
EXEC @ReturnCode = msdb.dbo.sp_add_jobschedule @job_id=@jobId, @name=N'Quotidiennement chaque 24 heures', 
		@enabled=1, 
		@freq_type=4, 
		@freq_interval=1, 
		@freq_subday_type=8, 
		@freq_subday_interval=24,
		@freq_relative_interval=0, 
		@freq_recurrence_factor=0, 
		@active_start_date=20230217, 
		@active_end_date=99991231, 
		@active_start_time=0, 
		@active_end_time=235959, 
		@schedule_uid=N'1d72f146-1894-4b63-95c3-f64f8e074fa4'
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
EXEC @ReturnCode = msdb.dbo.sp_add_jobserver @job_id = @jobId, @server_name = N'(local)'
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
COMMIT TRANSACTION
GOTO EndSave
QuitWithRollback:
    IF (@@TRANCOUNT > 0) ROLLBACK TRANSACTION
EndSave:

GO