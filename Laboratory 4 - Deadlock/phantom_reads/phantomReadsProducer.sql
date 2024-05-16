use KpopStore;

--Phantom Reads: Cand citesti ceva intr-o tranzactie si nu apare decat la sfarsit 
-- Gen ai doua selecturi : intr - un select ai 2 items si in al 3 lea 3

BEGIN TRAN
WAITFOR DELAY '00:00:05'
INSERT INTO Band(group_name,records_number,debut_date) VALUES ('TXT',30,'2019-03-04');
COMMIT TRAN
INSERT INTO LogTable (typeOp,tableOp,executionDate) VALUES ('Phantom Read- Victim','Band',CURRENT_TIMESTAMP);
