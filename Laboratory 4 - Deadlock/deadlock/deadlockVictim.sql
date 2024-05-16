begin tran
update Band set records_number=52 where id_group=1
waitfor delay '00:00:07'
update Artist set first_name='JisungD2' where  id_artist=19

commit tran
update Artist set first_name='Jisung' where  id_artist=19
