USE hotel;
/*STORED PROCEDURE*/
CREATE PROC sp_customer_add
(
@cust_name as nvarchar(100)
)
AS
BEGIN
	DECLARE @currdt as DATE
	SET @currdt = CAST(GETDATE() AS DATE)		
	INSERT INTO h_customers (cust_name, chk_in) values(@cust_name, @currdt)
END

EXEC sp_customer_add @cust_name= 'Soumyadeep';
EXEC sp_customer_add @cust_name= 'Cristiano Ronaldo';
EXEC sp_customer_add @cust_name= 'Lionel';

select cust_name, chk_in from h_customers;


create proc sp_cust_service
(
	@cust_id INT,
	@serv_type nvarchar(20),
	@serv_desc nvarchar(200),
	@amount	decimal(10,2),
	@category_id int,
	@chk_out DATE	
)
AS
BEGIN

	DECLARE @currdt as DATE
	SET @currdt = CAST(GETDATE() AS DATE)	
	
	DECLARE @unitprice AS DECIMAL(10, 2)
	DECLARE @no_of_days INT
	DECLARE @chk_in DATE
		
	IF @serv_type = 'room'		
	BEGIN
		SELECT @chk_in = chk_in from h_customers where id = @cust_id
		SELECT @unitprice = category_price from h_roomcategory where id = @category_id
		SELECT @no_of_days = dbo.calc_days(@chk_in, @chk_out)
		SET @amount = @unitprice * @no_of_days
	END
	
	/*ROOM NO <ROOM _NO> FOR <DAYS> DAILY CHARGES <UNIT_PRICE>*/
	
	INSERT INTO cust_service(cust_id, serv_type, serv_desc, amount, serv_date) values(@cust_id, @serv_type, @serv_desc, @amount, @currdt)
	UPDATE h_customers SET chk_out = @chk_out where id= @cust_id
END

EXEC sp_cust_service @cust_id = 1, @serv_type = 'room', @serv_desc = 'description', @amount = 0, @category_id = 2, @chk_out = '2022-04-25' 

select * from h_customers;