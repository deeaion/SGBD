use KpopStore;
--dirty reads: Reads something that got rollbacked
select * from Artist;
select * from LogTable;
BEGIN TRANSACTION
Insert into Artist(first_name,last_name,stage_name) values ('Christopher','Bhang','Bang Chan')
WAITFOR DELAY '00:00:05'
ROLLBACK TRANSACTION
insert into LogTable (typeOp,tableOp,executionDate) values ('DirtyReads Producer','Artist',CURRENT_TIMESTAMP);