--DEADLOCK
--Ca sa se produca avem in fiecare trans 2 event a si b
-- daca in tran 1 eventuriile se petrec a b si dupa b si a -> deadlock


--solutie setting DEADLOCK_PRIORITY .
-- HOW IS IT CHOSEN: the one less expensive to rollback or at random if the expense is equil

--I will use the tables Band and Artist
--SET DEADLOCK_PRIORITY HIGH
select * from Artist
begin tran
update Artist set first_name='JisungD1' where id_artist=19
waitfor delay '00:00:07'
update Band set records_number=51 where id_group=1
commit tran