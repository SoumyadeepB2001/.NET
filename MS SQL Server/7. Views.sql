use hotel;

create table h_customers(
id INT IDENTITY(1,1) PRIMARY KEY,
cust_name NVARCHAR(50)NOT NULL,
chk_in DATE,
chk_out DATE
);

create table cust_service(
cust_id INT,
serv_type NVARCHAR(50),
serv_desc NVARCHAR(60),
amount INT,
serv_date DATE
);

create view customer_view
as 
SELECT a.id, a.cust_name, a.chk_in, a.chk_out, b.serv_desc, b.amount, b.serv_date 
FROM h_customers as a
inner join
cust_service as b
on
a.id = b.cust_id;

SELECT * FROM customer_view;