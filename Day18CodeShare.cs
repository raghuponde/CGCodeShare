
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

create table empdetails(empid int primary key ,
empname varchar(30),empsal int);

insert into empdetails values(101,'ravi',34000)
insert into empdetails values(102,'sohan',30000);
insert into empdetails values(103,'sita',38000);

select sum(empsal) as "totalsal" ,
max(empsal) as "maxsal",min(empsal) as "minsal",avg(empsal) as "average",
count(*) as "totalemps" from empdetails;

create table ids(id int)
insert into ids values(1),(2),(1),(1),(1),(2),(3)
select * from ids;
--version 1
select id from ids group by id;-- it tells me how many groups are there 

select id ,count(id) from ids group by id ;

create table dept1(
  deptno int ,
  dname  varchar(14),
  loc    varchar(13),
  constraint pkk1 primary key(deptno)
);

 create table emp3(
  empno    int primary key,
  ename    varchar(10),
  job      varchar(9),
  mgr      int,
  hiredate date,
  sal      int,
  comm     int,
  deptno   int  foreign key  references dept1 (deptno)
);

insert into dept1 values(10, 'ACCOUNTING', 'NEW YORK');
insert into dept1 values(20, 'RESEARCH', 'DALLAS');
insert into dept1
values(30, 'SALES', 'CHICAGO');
insert into dept1
values(40, 'OPERATIONS', 'BOSTON'); 

 insert into emp3 values( 7839, 'KING', 'PRESIDENT', null,'1981-11-17' , 5000, null, 10);
insert into emp3 values( 7698, 'BLAKE', 'MANAGER', 7839,'1981-05-01',2850, null, 30);
insert into emp3 values( 7782, 'CLARK', 'MANAGER', 7839,'1981-06-09', 2450, null, 10);
insert into emp3 values( 7566, 'JONES', 'MANAGER', 7839,'1981-04-02', 2975, null, 20);
insert into emp3 values( 7788, 'SCOTT', 'ANALYST', 7566,'1987-04-19', 3000, null, 20);
insert into emp3 values( 7902, 'FORD', 'ANALYST', 7566, '1981-12-03', 3000, null, 20);
insert into emp3 values( 7369, 'SMITH', 'CLERK', 7902,'1980-12-17', 800, null, 20);
insert into emp3 values( 7499, 'ALLEN', 'SALESMAN', 7698, '1981-02-20', 1600, 300, 30);
insert into emp3 values(  7521, 'WARD', 'SALESMAN', 7698, '1981-02-22', 1250, 500, 30);
insert into emp3 values( 7654, 'MARTIN', 'SALESMAN', 7698, '1981-09-28', 1250, 1400, 30);
insert into emp3 values(  7844, 'TURNER', 'SALESMAN', 7698, '1981-09-08', 1500, 0, 30);
insert into emp3 values( 7876, 'ADAMS', 'CLERK', 7788, '1987-05-23', 1100, null, 20);
insert into emp3 values( 7900, 'JAMES', 'CLERK', 7698, '1981-12-03', 950, null, 30);
insert into emp3 values( 7934, 'MILLER', 'CLERK', 7782, '1982-01-23', 1300, null, 10);

select * from dept1;
select * from empl;

-- give me count of employees in each dept use child table only ..
--version 1 
select deptno from empl group by deptno;
--version 2 
select deptno,count(ename) from empl group by deptno;

-- give me max and min salary in each category of jobs 
select job from empl group by job
select job ,max(sal),min(sal)  from empl group by job;

-- give me sum of salaries in each job and filter whoes sum is > 5000

select job from empl group by job;--version 
select job,sum(sal) as "totalsal" from empl group by job ;--version 2
select job,sum(sal) as "totalsal" from empl group by 
job having sum(sal) > 5000;--version 3
Joins
---------

 create table dept3(deptid int primary key ,deptname varchar(30));
insert into dept3 values(10,'sales'),(20,'Marketing'),
(30,'Software'),(40,'HR');
create table emp3(empid int primary key ,empname varchar(30),
worksin int foreign key 
references dept3(deptid));
insert into emp3 values(101,'ravi',10),
(102,'kiran',20),(103,'mahesh',30),(104,'suresh',20),
(105,'satish',null);

select * from dept3;
select * from emp3;


--give me all the employees who have got dept;

--version 1
select e1.empname ,d1.deptname from emp3 e1 inner join dept3 d1 on e1.worksin=d1.deptid;
--version 2
select e1.empname + ' is working in '+ d1.deptname from emp3 e1 inner join 
dept3 d1 on e1.worksin=d1.deptid;
version 3 
select e1.empname  from emp3 e1 inner join dept3 d1 on e1.worksin=d1.deptid;

-- give me all the emploayees who have not got dept ;;
--version 1
select e1.empname ,d1.deptname from emp3 e1 left join dept3 d1 on e1.worksin=d1.deptid;

-- version 2 
select e1.empname ,d1.deptname from emp3 e1 left join dept3 d1 on e1.worksin=d1.deptid
where d1.deptname is null;

-- version 3 
select e1.empname  from emp3 e1 left join dept3 d1 on e1.worksin=d1.deptid
where d1.deptname is null;




