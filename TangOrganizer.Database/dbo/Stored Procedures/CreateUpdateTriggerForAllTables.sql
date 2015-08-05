-- =============================================
-- Author:		Michele Caggiano
-- Create date: 05/08/2015
-- Description:	Crea i Trigger di Update per il campo BaseInfo_DataUltimaModifica
-- =============================================
CREATE PROCEDURE [dbo].[CreateUpdateTriggerForAllTables]
AS
BEGIN
	
	DECLARE @TABLE_NAME nvarchar(100);

	-- Recupero tutte le tabelle
	DECLARE Cur_AllTables CURSOR 
		LOCAL STATIC READ_ONLY FORWARD_ONLY
	FOR 
		select TABLE_NAME from INFORMATION_SCHEMA.Tables 
		where TABLE_SCHEMA = 'dbo' and 
		TABLE_NAME not in ('__RefactorLog', 'sysdiagrams')
		ORDER BY TABLE_NAME

	OPEN Cur_AllTables
	FETCH NEXT FROM Cur_AllTables INTO @TABLE_NAME
	-- Per tutte le tabelle credo il trigger
	WHILE @@FETCH_STATUS = 0
	BEGIN 
			
			PRINT '-----> ' + @TABLE_NAME;
		-- controllo che il trigger non esiste
		IF EXISTS (
			SELECT *
			FROM sys.objects
			WHERE [type] = 'TR' AND [name] = @TABLE_NAME + '_After_Update'
			)
			BEGIN
					 DROP TRIGGER After_Update;
					 PRINT 'Old Trigger Dropped for ' + @TABLE_NAME;
			END

			-- Controllo che il campo BaseInfo_DataUltimaModifica esista
			IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.COLUMNS 
								WHERE TABLE_NAME = @TABLE_NAME 
								AND COLUMN_NAME = 'BaseInfo_DataUltimaModifica') 
			BEGIN
					
						-- Recupero il nome del campo id della tabella
						declare @TableIDColumnName as nvarchar(100);
						SELECT @TableIDColumnName = ccu.COLUMN_NAME
						FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS tc
								JOIN INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE ccu ON tc.CONSTRAINT_NAME = ccu.Constraint_name
						WHERE tc.CONSTRAINT_TYPE = 'Primary Key'
						AND ccu.TABLE_NAME = @TABLE_NAME

						-- Recupero il TIPO del campo id della tabella
						declare @TableIDColumnType as nvarchar(100);
						SELECT @TableIDColumnType = DATA_TYPE 
						FROM INFORMATION_SCHEMA.COLUMNS
						WHERE TABLE_NAME = @TABLE_NAME AND COLUMN_NAME = @TableIDColumnName


					-- Creo UPDATE Trigger
					DECLARE @triggerProcedure as nvarchar(MAX) = 
					'CREATE TRIGGER [dbo].[' + @TABLE_NAME + '_After_Update] ON ' + @TABLE_NAME + '	AFTER Update AS 
					 BEGIN
						-- Recupero l''Id dell''ultima riga inserita
						declare @rowId as ' + @TableIDColumnType + ';
						select @rowId= i.' + @TableIDColumnName + ' from inserted i; 
	
						-- Salvo data ultima modifica
						update '+ @TABLE_NAME +'
						set BaseInfo_DataUltimaModifica = GETDATE()
						where ' + @TableIDColumnName + ' in (select ' + @TableIDColumnName + ' from inserted i);    
						 END'
 
					PRINT @triggerProcedure
					EXEC (@triggerProcedure)
					PRINT 'Trigger Created for ' + @TABLE_NAME;
			END
			ELSE 
			    PRINT 'Il campo ''BaseInfo_DataUltimaModifica'' non esiste per la tabella ' + @TABLE_NAME

		PRINT ''

	FETCH NEXT FROM Cur_AllTables INTO @TABLE_NAME
	END
	CLOSE Cur_AllTables
	DEALLOCATE Cur_AllTables

  
END