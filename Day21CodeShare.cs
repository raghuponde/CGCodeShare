
co related subquery 
----------------------
co related subquery means it will depend on parent query for its exsistence it cannot execute individually like a
 normal subquery some scenarios or some requirement will force us to implement co realted sub query and here 
the task which u are doing in co related subquery can also be done using joins it depends how much deep u can think 


check slide for syntax 


create table Products(productid int primary key ,prodname varchar(40),Description varchar(100))

insert into products values(1,'TV','52 inch black color lcd TV ');
insert into products values(2,'Laptop','very thin silver predator latop  ');
insert into products values(3,'Desktop','HP high performance dektop');

select * from products;

create table Productsales(salesid int primary key ,productid int ,UserPrice int ,quantitysold int ,
constraint ssk foreign key (productid) references Products(productid))

insert into Productsales values(1,3,450,5);
insert into Productsales values(2,2,250,7);
insert into Productsales values(3,3,450,4);
insert into Productsales values(4,3,450,9);

select * from Products;
select * from Productsales;

-- give me product which is not used in sales only 

select productid,prodname,Description from products where productid not in 
(select productid from productsales)

 
--give me name of products and its sum of products sold for each product 
--version 1

select sum(quantitysold) from Productsales where productid=2

select ps1.prodname ,(select sum(quantitysold) from Productsales where 
productid=ps1.productid) as QTYSold from products ps1



 
