create database hotel
DROP TABLE h_roomcategory
use hotel
create table h_roomcategory
(
	id INT IDENTITY(1,1) PRIMARY KEY,			/*IDENTITY(STARTVALUE, INCREMENT)*/
	category_name NVARCHAR(20) NOT NULL,		/*BY DEFAULT IT IS NULL, NOT NULL TO BE SET*/
	category_price DECIMAL(10,2) NOT NULL		/*DECIMAL (BEFORE DECIMAL, AFTER DECIMAL)*/
)

ALTER table h_roomcategory
ALTER COLUMN category_name NVARCHAR(50) NOT NULL

INSERT INTO h_roomcategory values('AC Super Deluxe', 1800.50)
INSERT INTO h_roomcategory(category_name, category_price) values('AC Deluxe', 1500.50);
INSERT INTO h_roomcategory(category_name, category_price) values('AC Double Bed', 1300.50);

UPDATE h_roomcategory SET category_name = 'AC Double Bed South Face' WHERE  id=3

create table h_rooms
(
	id INT IDENTITY(1,1) PRIMARY KEY,
	room_no	NVARCHAR(20) UNIQUE,
	category_id INT,
	CONSTRAINT fk_room_category_gp FOREIGN KEY (category_id) 
    REFERENCES h_roomcategory(id) 
)

ALTER TABLE h_rooms
ADD description NVARCHAR(200) NOT NULL

select id as id_num, description as dscrp from h_rooms 

INSERT INTO h_rooms(room_no, category_id, description) values ('1/1', 1, 'Sea Facing');
INSERT INTO h_rooms(room_no, category_id, description) values ('1/2', 1, 'Sea Facing');
INSERT INTO h_rooms(room_no, category_id, description) values ('2/1', 2, 'East Facing');
INSERT INTO h_rooms(room_no, category_id, description) values ('2/2', 2, 'East Facing');
INSERT INTO h_rooms(room_no, category_id, description) values ('1/3', 1, 'Sea Facing');
INSERT INTO h_rooms(room_no, category_id, description) values ('1/4', 1, 'Sea Facing');
INSERT INTO h_rooms(room_no, category_id, description) values ('2/3', 2, 'East Facing');
INSERT INTO h_rooms(room_no, category_id, description) values ('2/5', 2, 'East Facing');
INSERT INTO h_rooms(room_no, category_id, description) values ('2/4', 2, 'East Facing');
INSERT INTO h_rooms(room_no, category_id, description) values ('3/1', 3, 'North Facing');

Select id, category_name, category_price from h_roomcategory;
Select id, room_no, category_id, description from h_rooms;