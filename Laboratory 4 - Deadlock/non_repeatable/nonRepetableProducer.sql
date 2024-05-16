use KpopStore;
--Non Repetable Reads: in a query one/or more have different values 
BEGIN TRAN
WAITFOR DELAY '00:00:03'
UPDATE Artist set first_name='Changed' where id_artist=17
COMMIT TRAN;
select * from Artist
INSERT INTO LogTable(typeOp,tableOp,executionDate) VALUES ('Read COM Prod','Artist',CURRENT_TIMESTAMP);
