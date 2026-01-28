
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




