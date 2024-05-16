use KpopStore;
--Dirty reads only happens on the isolation level read uncommitted
SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED
BEGIN TRAN
SELECT * FROM Artist
WAITFOR DELAY '00:00:08'
SELECT * FROM Artist
COMMIT TRAN