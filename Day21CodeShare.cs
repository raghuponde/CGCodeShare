
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
--version 2 
select p1.prodname ,(select sum(quantitysold) from Productsales where 
productid=p1.productid) as QTYSold from products p1 

SELECT p1.prodname,
       (SELECT SUM(quantitysold) 
        FROM Productsales 
        WHERE productid = p1.productid) AS QTYSold
FROM products p1
WHERE EXISTS (SELECT 1 FROM Productsales WHERE productid = p1.productid);

---other way 
SELECT 
    ps1.prodname,
    (SELECT SUM(quantitysold)
     FROM ProductSales
     WHERE productid = ps1.productid) AS QTYSold
FROM products ps1
WHERE
    (SELECT SUM(quantitysold)
     FROM ProductSales
     WHERE productid = ps1.productid) IS NOT NULL;
--using joins 
select p1.prodname,sum(ps1.quantitysold) from products p1 inner join productSales ps1 on
ps1.productid=p1.productid group by p1.prodname

--Scenario: Find employees earning more than their department's average salary.

CREATE TABLE Employees (
    empid INT PRIMARY KEY,
    empname VARCHAR(50),
    salary INT,
    dept_id INT
);

-- Create Departments table
CREATE TABLE Departments (
    dept_id INT PRIMARY KEY,
    dept_name VARCHAR(50)
);

-- Insert into Employees
INSERT INTO Employees VALUES (101, 'Ravi', 1200, 1);
INSERT INTO Employees VALUES (102, 'Mohan', 2500, 2);
INSERT INTO Employees VALUES (103, 'Kumar', 1400, 1);
INSERT INTO Employees VALUES (104, 'Senthil', 800, 1);
INSERT INTO Employees VALUES (105, 'Manju', 2000, 2);

-- Insert into Departments
INSERT INTO Departments VALUES (1, 'IT');
INSERT INTO Departments VALUES (2, 'HR');

-- Verify data
SELECT * FROM Employees;
SELECT * FROM Departments;

-- for the above situation use co related subquery or joins with group by 

--version 1 
select avg(salary) from  Employees where dept_id=2-- here 2 will get from outer table

select e.empid,e.empname,e.salary,d.dept_name from Employees e join departments d on 
d.dept_id=e.dept_id where e.salary>
(select avg(salary) from  Employees where dept_id=e.dept_id)

---using joins
SELECT e.empid, e.empname, e.salary, d.dept_name
FROM Employees e
JOIN Departments d ON e.dept_id = d.dept_id
JOIN (
    SELECT dept_id, AVG(salary) AS dept_avg
    FROM Employees
    GROUP BY dept_id
) dept_avg ON e.dept_id = dept_avg.dept_id
WHERE e.salary > dept_avg.dept_avg;

another sceanrio 

CREATE TABLE Products (
    product_id INT PRIMARY KEY,
    product_name VARCHAR(50),
    category_id INT,
    price INT
);

-- Insert data into Products
INSERT INTO Products VALUES (1, 'Laptop', 1, 1200);
INSERT INTO Products VALUES (2, 'Mouse', 1, 25);
INSERT INTO Products VALUES (3, 'DeskJet', 2, 150);
INSERT INTO Products VALUES (4, 'LaserJet', 2, 800);
INSERT INTO Products VALUES (5, 'Keyboard', 1, 75);
INSERT INTO Products VALUES (6, 'Monitor', 1, 300);

-- Verify data
SELECT * FROM Products;
 
Scenario: Find the highest priced product in each category using correlated subquery.
