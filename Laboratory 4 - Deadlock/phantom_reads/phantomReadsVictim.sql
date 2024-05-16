select * from Band;
SET TRANSACTION ISOLATION LEVEL REPEATABLE READ;
BEGIN TRAN;
SELECT * FROM Band where records_number>29;
WAITFOR DELAY '00:00:09';
SELECT * FROM Band where records_number>29;
COMMIT TRAN;
INSERT INTO LogTable (typeOp,tableOp,executionDate) VALUES ('Phantom Read- Victim','Band',CURRENT_TIMESTAMP);
