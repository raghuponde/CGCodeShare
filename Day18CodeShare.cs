
referential integrity constratint which is also called foreign key ...
---------------------------------------------------------------------
Definition : Two Tables are said to related to each other if they are having one common column between them and that common column should act as primary key in the master table and the   same column will be called foreign key in child .

The table which i create first is the master table  which is not depending on any table for is exsistence 
but the child table will depend on master table it should contain in the foreign key only the values of master table .

use CG;
create table dept(deptid int primary key,deptname varchar(40))
insert into dept values(10,'HR');
insert into dept values (20,'Sales')
insert into dept values (30,'Marketing');

create table emp(empid int  primary key, empname varchar(40),
worksin int foreign key references dept(deptid));--column level constraint

insert into emp values (101,'ravi',10);
insert into emp values (102,'sita',10);
insert into emp values(103,'suresh',20);
insert into emp values(104,'sanjay',null);
insert into emp values(105,'sunitha',40);--error



select * from dept;
select * from emp;
--another way of referring master table 

create table emp1(empid int  primary key, empname varchar(40),
deptid int,constraint forkey1 foreign key(deptid) references dept(deptid));--table level constraint



insert into emp1 values (101,'ravi',10);
insert into emp1 values (102,'sita',10);
insert into emp1 values(103,'suresh',20);
insert into emp1 values(104,'sanjay',null);
insert into emp1 values(105,'sunitha',40);--error

--create one table where doctor is there and pateint is there and treatment is going on
-- in treatment both doctor and patient is involved so now 
-- create three tables of doctor ,patient and treatment 

--you can decide any things in doctor or patient as master table but 
--treatemnt will be child of both doctor and pateinte so create tables for this scenario 

create table doctor(docid int primary key ,docname varchar(40))

create table patient(patid int primary key,patname varchar(40),treatedby int foreign key 
references doctor(docid));

create table treatement(treatid int primary key,treatedby int ,takenby int,
constraint dk22 foreign key (treatedby) references doctor(docid),
constraint pkk44 foreign key (takenby) references patient(patid));

where to keep foreign key 
-----------------------
when one to one realtinship is there you can keep foreign key anywhere in the tables here no master and no child table will be there 

when one to many is there put foreign key in the child table and which table u create after master is nothing but child table only 

when many to many relationship is there the table is splitted into two one to many relationships .slide 33 refere 

Aggregate Functions 
--------------------
sum ,avg ,min ,max,count are called aggregate functions 
-- aggrgate functions usage here set of rows will go and will give single value

create table empdetails(empid int primary key ,
empname varchar(30),empsal int);
insert into empdetails values(101,'ravi',34000)
insert into empdetails values(102,'sohan',30000);
insert into empdetails values(103,'sita',38000);



select sum(empsal) as "totalsal" ,
max(empsal) as "maxsal",min(empsal) as "minsal",avg(empsal) as "average",
count(*) as "totalemps" from empdetails;

--Group By 
------------
-- whatever columns are there in select clause that should be there in 
---group by clause also if not there then apply aggregate functions to the column of select clause 
 -- but when u dont hav much columns like single column only then u can use aggregate function as per the need of the qeustion 
 
-- when ever they are asking for each ,for every apply group by to column with repeated values 

-- in the below table give me count of duplicate values in the table .

create table ids(id int)
insert into ids values(1),(2),(1),(1),(1),(2),(3)


