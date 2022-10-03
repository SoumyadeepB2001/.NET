use testdb1

select * from student;
select * from room;

alter table student
add room varchar(10)

update student set room='R005' where roll = 6;

create table room (roomNum varchar(10) primary key, avail varchar(10));

insert into room values('R008', 'YES');


SELECT distinct roomNum FROM room r, student s where avail='YES' or r.roomNum = ( select room from student where roll=4);


create procedure selectRooms
@room varchar(30)
AS
BEGIN
	SELECT distinct roomNum FROM room r, student s where avail='YES' or r.roomNum = @room;
END

exec selectRooms @room='R004';


create procedure selectRooms2
@roll int
AS
BEGIN
	SELECT distinct roomNum FROM room r, student s where avail='YES' or r.roomNum = ( select room from student where roll=4);

END

exec selectRooms2 @roll = 4



create proc update_student
@name varchar(50),
@gender varchar(10),
@room varchar(10)
AS
BEGIN
UPDATE student SET name = @name, gender = @gender, room = @room FROM student 
UPDATE room SET avail='Unavailable' where roomNum=@room
END

