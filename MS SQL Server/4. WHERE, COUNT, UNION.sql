use hotel;
/*Where Clause*/
Select id, room_no, category_id, description from h_rooms where id > 0 order by category_id

/*order by and group by never used together*/
/*Select id, room_no, category_id, description from h_rooms where id > 0 order by category_id group by category_id, id, room_no, description*/

Select id, room_no, category_id, description from h_rooms category_id where id > 2 group by category_id, room_no, description, id

/*counting the number of records*/
select COUNT(*) from h_rooms

/*duplicate value*/
select category_id, COUNT(category_id) as category from h_rooms group by category_id having COUNT(category_id) > 3



union
Select id, category_name, category_price from h_roomcategory
UNION ALL
Select id, room_no, category_id from h_rooms

delete from h_rooms where category_id = 3
