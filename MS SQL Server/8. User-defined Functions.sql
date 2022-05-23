use hotel;

CREATE FUNCTION calc_age(@dob DATE)
RETURNS INT 
AS
BEGIN
	 return DATEDIFF(year, @dob, GETDATE()) 
END


CREATE FUNCTION calc_days(@frm DATE, @to DATE)
RETURNS INT 
AS
BEGIN
	 return DATEDIFF(DAY, @frm, @to) 
END



select dbo.calc_age('2001-10-04') /*dbo - DATABASE owner*/
select dbo.calc_days('2001-10-04','2015-06-09') /*dbo - DATABASE owner*/


