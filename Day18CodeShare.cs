
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
