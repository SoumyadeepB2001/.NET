/*Group by*/
use hotel;

Select id, room_no, category_id, description from h_rooms group by category_id, id, room_no, description;

select category_id, room_no from h_rooms group by category_id, room_no;

