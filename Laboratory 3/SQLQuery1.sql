use KpopStore;

--TABLES USED---
--CREATE TABLE Artist
--(
--	id_artist INT PRIMARY KEY IDENTITY,
--	first_name VARCHAR(100),
--	last_name VARCHAR(100),
--	stage_name VARCHAR(100),
--);

--CREATE TABLE Band
--(
--	id_group INT PRIMARY KEY IDENTITY,
--	group_name VARCHAR(200) NOT NULL,
--	debut_date DATE,
--	records_number INT
--);

--CREATE TABLE GroupMembersInfo
--(
--	id_artist INT FOREIGN KEY REFERENCES Artist(id_artist),
--	id_group INT FOREIGN KEY REFERENCES Band(id_group),
--	CONSTRAINT pk_MemInfo PRIMARY KEY (id_artist,id_group)


--);


-----validations------
--verify string is null--

create function dbo.validate_if_empty (@word varchar(100))
returns bit
as
begin
	declare @flag bit;
	set @flag = 1 --we set as true;
	if @word is null or @word =''
		set @flag=0;
	return @flag;
end
go;
CREATE OR ALTER FUNCTION dbo.validate_name (@name VARCHAR(100))
RETURNS BIT
AS 
BEGIN
    DECLARE @flag BIT;
    SET @flag = 0; -- Default to false

    -- Check if the name starts with an uppercase letter, contains only letters, is more than 2 characters long
    IF @name LIKE '[A-Z]%' AND @name NOT LIKE '%[^a-zA-Z]%' AND LEN(@name) > 2
        SET @flag = 1; -- Set true if all conditions are met

    RETURN @flag;
END

go;


create or alter function dbo.validate_number (@nr int)
returns bit
as
begin
	declare @flag bit
	set @flag=1
	if @nr<0
		set @flag=0
	return @flag;
end
go;

create or alter function dbo.validate_artist (@first_name varchar(100),
@last_name varchar(100),@stage_name varchar(100))
returns varchar (200)
as
begin
	declare @errors varchar(200)=''
	if dbo.validate_name(@first_name) <> 1
	begin
		set @errors = @errors + 'First name is not valid ,'
	end
	if dbo.validate_name(@last_name) <> 1
	begin
		set @errors= @errors + 'Last name is not valid, '
	end
	if dbo.validate_if_empty(@stage_name) <> 1
	begin
		set @errors = @errors + 'Stage name is not valid!'
	end
	return @errors
end


create or alter function dbo.validate_band(@group_name varchar(200), @records_nr int)
returns varchar(200)
as
begin
	declare @errors varchar(200)=''
	if dbo.validate_if_empty(@group_name) <> 1
	begin
		set @errors= @errors + 'Band name is not valid , '
	end
	if dbo.validate_number(@records_nr) <> 1
	begin
		set @errors= @errors + 'Number must be positive!'
	end
	return @errors
end



CREATE TABLE LogTable(
	logId int identity primary key,
	typeOp varchar(50),
	tableOp varchar(100),
	executionDate DATETIME);

CREATE PROCEDURE AddGroupMembersInfo
	@firstName varchar(100), @lastName varchar(100), @StageName varchar(100),
	@groupName varchar(200), @debut_date date, 
	@recordsNumber int
	AS
	begin
		declare @id_artist int;
		declare @id_band int;
		--artist--
		begin tran
			begin try
				declare @errors varchar(200);

				--artist--
				set @errors= dbo.validate_artist(@firstName, @lastName, @StageName);
				if len(@errors)<> 0
				begin
					insert into LogTable(typeOp,tableOp,executionDate) values ('ERROR','Artist',GETDATE());
					raiserror(@errors,14,1);
				end
				insert into Artist (first_name,last_name,stage_name) values
							(@firstName,@lastName,@StageName);
				insert into LogTable(typeOp,tableOp,executionDate) values ('Inserted for now ','Artist',GETDATE());
			

				--band--
				set @errors=dbo.validate_band(@groupName,@recordsNumber);
				if len(@errors)<>0
				begin
					insert into LogTable(typeOp,tableOp,executionDate) values ('ERROR','BAND',GETDATE());
					raiserror(@errors,14,1);
				end
				insert into Band(group_name,records_number,debut_date) values (@groupName,@recordsNumber,@debut_date);
				insert into LogTable(typeOp,tableOp,executionDate) values ('Inserted for now','Band',GETDATE());
				--group members info--
				set @id_artist=(select max(id_artist) from Artist);
				set @id_band=(select max(id_group) from Band);
				insert into GroupMembersInfo(id_artist,id_group) values (@id_artist,@id_band);
				commit tran
				print ' Everything went well'
				insert into LogTable (typeOp,tableOp,executionDate) values ('Finalized insertion','GroupMembersInfo',GETDATE());
			end try
		begin catch
			rollback tran;
			print ERROR_MESSAGE();
			insert into LogTable(typeOp,tableOp,executionDate) values ('RolledBack','GroupMemberInfo',GETDATE());
			return 0;
		end catch
		return 1
end
		





CREATE PROCEDURE AddGroupMembersInfo2
	@firstName varchar(100), @lastName varchar(100), @StageName varchar(100),
	@groupName varchar(200), @debut_date date, 
	@recordsNumber int
	AS
	begin
		declare @id_artist int;
		declare @id_band int;
		--artist--
		begin tran
			begin try
				declare @errors varchar(200);

				--artist--
				set @errors= dbo.validate_artist(@firstName, @lastName, @StageName);
				if len(@errors)<> 0
				begin
					insert into LogTable(typeOp,tableOp,executionDate) values ('ERROR','Artist',GETDATE());
					raiserror(@errors,14,1);
				end
				insert into Artist (first_name,last_name,stage_name) values
							(@firstName,@lastName,@StageName);
				insert into LogTable(typeOp,tableOp,executionDate) values ('Inserted for now ','Artist',GETDATE());
			

				--band--
				set @errors=dbo.validate_band(@groupName,@recordsNumber);
				if len(@errors)<>0
				begin
					insert into LogTable(typeOp,tableOp,executionDate) values ('ERROR','BAND',GETDATE());
					raiserror(@errors,14,1);
				end
				insert into Band(group_name,records_number,debut_date) values (@groupName,@recordsNumber,@debut_date);
				insert into LogTable(typeOp,tableOp,executionDate) values ('Inserted for now','Band',GETDATE());
				--group members info--
				set @id_artist=(select max(id_artist) from Artist);
				set @id_band=(select max(id_group) from Band);
				insert into GroupMembersInfo(id_artist,id_group) values (@id_artist,@id_band);
				commit tran
				print ' Everything went well'
				insert into LogTable (typeOp,tableOp,executionDate) values ('Finalized insertion','GroupMembersInfo',GETDATE());
			end try
		begin catch
			rollback tran;
			print ERROR_MESSAGE();
			insert into LogTable(typeOp,tableOp,executionDate) values ('RolledBack','GroupMemberInfo',GETDATE());
			return 0;
		end catch
		return 1
end


drop procedure AddGroupMembersInfo2
CREATE PROCEDURE AddGroupMembersInfo2
	@firstName varchar(100), @lastName varchar(100), @StageName varchar(100),
	@groupName varchar(200), @debut_date date, 
	@recordsNumber int
AS
begin
	declare @id_artist int;
	declare @id_band int;
	declare @errors varchar(200);
	
	--artist--
	begin tran
		begin try
			set @errors= dbo.validate_artist(@firstName, @lastName, @StageName);
			if len(@errors)<> 0
			begin
				insert into LogTable(typeOp,tableOp,executionDate) values ('ERROR','Artist',GETDATE());
				raiserror(@errors,14,1);
			end
			insert into Artist (first_name,last_name,stage_name) values
							(@firstName,@lastName,@StageName);
			insert into LogTable(typeOp,tableOp,executionDate) values ('Inserted','Artist',GETDATE());
	commit tran
		end try
	begin catch
		rollback tran
		print ERROR_MESSAGE();
		print 'Transaction rollbacked!'
		insert into LogTable(typeOp,tableOp,executionDate) values ('Rolledback transation','Arist',CURRENT_TIMESTAMP);
		
	end catch


	--band--
	begin tran 
		begin try
			set @errors= dbo.validate_band(@groupName,@recordsNumber);
			if len(@errors)<>0
			begin
				insert into LogTable(typeOp,tableOp,executionDate) values ('ERROR','BAND',GETDATE());
				raiserror(@errors,14,1);
			end
			insert into Band(group_name,records_number,debut_date) values (@groupName,@recordsNumber,@debut_date);
			insert into LogTable(typeOp,tableOp,executionDate) values ('Inserted for now','Band',GETDATE());		
	commit tran
			print ' Everything went well'
			insert into LogTable (typeOp,tableOp,executionDate) values ('Finalized insertion','Band',GETDATE());
		end try
	begin catch
		rollback tran;
		print ERROR_MESSAGE();
		insert into LogTable(typeOp,tableOp,executionDate) values ('RolledBack','Band',GETDATE());
	end catch


	--group members info--
	begin tran 
	begin try
		set @id_artist=(select max(id_artist) from Artist);
		set @id_band=(select max(id_group) from Band);
		insert into GroupMembersInfo(id_artist,id_group) values (@id_artist,@id_band);
		commit tran
		print ' Everything went well'
		insert into LogTable (typeOp,tableOp,executionDate) values ('Finalized insertion','GroupMembersInfo',GETDATE());
	end try
		begin catch
			rollback tran;
			print ERROR_MESSAGE();
			insert into LogTable(typeOp,tableOp,executionDate) values ('RolledBack','Band',GETDATE());
			return 0;
		end catch
		return 1
end



execute AddGroupMembersInfo 'Marrr','Aaaaa','Aaaaa','Aaaaaaaaaaa','2023-10-20',12
select * from LogTable

execute AddGroupMembersInfo '','Aaaaa','Aaaaa','Aaaaaaaaaaa','2023-10-20',12
select * from LogTable

execute AddGroupMembersInfo2 'Marrr','Aaaaa','Aaaaa','Aaaaaaaaaaa','2023-10-20',12
select * from LogTable
execute AddGroupMembersInfo2 '','Aaaaa','Aaaaa','Aaaaaaaaaaa','2023-10-20',12
select * from LogTable


delete from LogTable