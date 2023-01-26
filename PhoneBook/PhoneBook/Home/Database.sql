create table users(
	uid int identity(1,1), 
    name nvarchar(70) NOT NULL,  
    phone varchar(20) NOT NULL,
    email nvarchar(50) PRIMARY KEY,
    pass nvarchar(10) NOT NULL,
    table_name nvarchar(100)
);

----------------------------------

create proc validate_users
@email nvarchar(50),
@user_password nvarchar(10)
AS
BEGIN
	SET NOCOUNT ON
	select * from users where email = @email AND pass = @user_password
END

---------------------------------

create proc insert_users
@name nvarchar(70),
@phone varchar(20),
@email nvarchar(50),
@pass nvarchar(10),
@table_name nvarchar(100)

AS
BEGIN
	SET NOCOUNT ON
	insert into users ([name],[phone],[email],[pass],[table_name])
	values(@name, @phone, @email, @pass, @table_name)	
END

--------------------------------------
