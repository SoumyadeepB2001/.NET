use hotel;
/*INNER JOIN*/
Select a.id, a.category_name, a.category_price, b.id, b.room_no, b.category_id 
from h_roomcategory a
inner join
h_rooms b
on 
a.id = b.category_id
where
b.category_id = 2


/* LEFT join*/
Select a.id, a.category_name, a.category_price, b.id, b.room_no, b.category_id 
from h_roomcategory a
left join
h_rooms b
on 
a.id = b.category_id


/* RIGHT join*/
Select a.id, a.category_name, a.category_price, b.id, b.room_no, b.category_id 
from h_roomcategory a
right join
h_rooms b
on 
a.id = b.category_id


/*Full join*/
Select a.id, a.category_name, a.category_price, b.id, b.room_no, b.category_id 
from h_roomcategory a
full join
h_rooms b
on 
a.id = b.category_id

/*cross join*/
Select a.id, a.category_name, a.category_price, b.id, b.room_no, b.category_id 
from h_roomcategory a
cross join
h_rooms b
