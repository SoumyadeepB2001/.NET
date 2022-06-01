CREATE DATABASE testdb1;
USE testdb1;
CREATE TABLE student(
id INT IDENTITY(1,1),
name VARCHAR (50) NOT NULL,
roll INT PRIMARY KEY
);

CREATE PROC addName(
@name NVARCHAR(50),
@roll INT)
AS
BEGIN
INSERT INTO student(name, roll) VALUES (@name, @roll)
END

exec addName @name="Toni Kroos", @roll=8;
