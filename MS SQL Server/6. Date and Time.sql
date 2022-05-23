select GETDATE(); /*2022-05-24 02:10:05.437*/

select CAST(GETDATE() AS DATE); /*2022-05-24*/

select CAST(GETDATE() AS TIME); /*02:10:05.437*/

SELECT DATEDIFF(year, '2001-10-04', GETDATE()) AS DateDiff /*21 Here DateDiff is the column name*/

SELECT DATEDIFF(day, '2001-10-04', GETDATE()) /*7537*/



