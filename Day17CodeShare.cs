create database CG
use CG;
create table student(studid int primary key,studname varchar(30),
location varchar(50))

--normal insert 
insert into student values(101,'ravi','chennai');

select * from student

--inserting as per my order 
insert into student(location,studid,studname)values('bangalore',102,'mahesh')
--partial insert 
insert into student(studid,studname) values(103,'suresh')
--multiple insert 
insert into student values(104,'kiran','delhi'),(105,'sita','noida'),
(106,'shnathi','hyderabad')

--updating single column in a single row (cant update primary key)

update student set studname='joseph' where studid=102;

--updating multiple columns in a single row 
update student set studname='david',location='kanyakumari' where studid=104;

--updating multiple rows in a single column 
update student set location='calcutta' where studid in(102,104,105);

--updating multiple rows in multiple columsn is not possible 

--deleting single row 
delete from student where studid=105;
--deleting multiple rows
delete from student where studid in (102,104)
--deleting all rows 
delete from student;
--delete student ; thi is also okay 

--what is the differene between truncate and delete command 

create table empinfo(empid int identity(1,1) primary key ,empname varchar(40))

insert into empinfo values('ravi');
insert into empinfo values('sita');
insert into empinfo values('chandan')

select * from empinfo;

--first difference is u cannot use where clause with truncate and it is DDL command
--where as delete can be used with where and it is dml command 

--truncate empinfo where empname='sita';not possible

delete empinfo
insert into empinfo values('jagdish');
truncate table empinfo

insert into empinfo values('ayyapa');
-- so u can see log are mainted when u delete command is used but 
-- for truncate it is not maintained it starts from first 



