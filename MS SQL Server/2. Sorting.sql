
use hotel;

Select id, category_name, category_price from h_roomcategory;
Select id, room_no, category_id, description from h_rooms;

Select id, room_no, category_id, description from h_rooms order by category_id;
Select id, room_no, category_id, description from h_rooms order by category_id, room_no;
Select id, room_no, category_id, description from h_rooms order by 3, 2;
Select id, room_no, category_id, description from h_rooms order by category_id DESC; /*DESC = Descending order*/
Select id, room_no, category_id, description from h_rooms order by category_id;


