using System;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StudentWebFinal
{

    public partial class WebForm1 : System.Web.UI.Page
    {
        public string currentQuery = "select * from student";
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                GridViewBind(currentQuery);
            }
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            //oldRoom=GridView1.Rows[e.NewEditIndex].Cells[3].Text.ToString();
            

            Session["room"]= GridView1.Rows[e.NewEditIndex].Cells[3].Text.ToString();


            GridViewBind(currentQuery);
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Class1 ob = new Class1();


            int roll = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value.ToString());
            GridViewRow row = GridView1.Rows[e.RowIndex];
            TextBox textName = (TextBox)row.Cells[0].Controls[0];
            DropDownList genderddl = (DropDownList)row.FindControl("DropDownList1");
            TextBox textRoom = (TextBox)row.Cells[3].Controls[0];
            string gender = genderddl.SelectedValue.ToString();
            string oldRoom = Session["room"] as string;
           
            //Response.Write(Session["room"] as string);


            try
            {
                ob.CreateConnection();
                ob.OpenConnection();

                ob._sqlCommand.CommandText = "update_student";
                ob._sqlCommand.CommandType = CommandType.StoredProcedure;

                ob._sqlCommand.Parameters.AddWithValue("@roll", roll);
                ob._sqlCommand.Parameters.AddWithValue("@name", textName.Text.ToString());
                ob._sqlCommand.Parameters.AddWithValue("@gender", gender);
                ob._sqlCommand.Parameters.AddWithValue("@newroom", textRoom.Text.ToString());
                ob._sqlCommand.Parameters.AddWithValue("@oldroom", oldRoom);

                //ob.ShowAlertMessage("Old room num bro" + oldRoom);

                int t=ob._sqlCommand.ExecuteNonQuery();

                if(t>0)               
                   Response.Write("QUERY EXECUTED "+t);
                
                else
                    Response.Write("QUERY NOT EXECUTED "+t);


                ob.CloseConnection();
                ob.DisposeConnection();


            }

            catch (Exception ex)
            {
                ob.ShowAlertMessage("Error: " + ex.ToString());
            }

            finally
            {
                GridView1.EditIndex = -1;
                GridViewBind(currentQuery);
                oldRoom = "";

                // Console.WriteLine("Hello finally");

            }


        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        public void GridViewBind(string query)
        {
            Class1 ob = new Class1();
            ob.CreateConnection();
            ob.OpenConnection();
            ob._sqlCommand.CommandText = query;
            ob._sqlCommand.CommandType = CommandType.Text;

            SqlDataAdapter sda = new SqlDataAdapter(ob._sqlCommand);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            GridView1.DataSource = ds;
            GridView1.DataBind();

            ob.CloseConnection();
            ob.DisposeConnection();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            GridViewBind(currentQuery);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string name = "%"+srchName.Text.ToString()+"%";
            string gender=GenderSrch.SelectedValue;
            string room=srchRoom.Text.ToString();
            string roll = srchRoll.Text.ToString();
            string search = "SELECT * FROM student where";

            int c = 0;


            if(name.Length>2)
            {
                search = search + " name like '" + name+ "'";
                c++;
            }

            if(!gender.Equals("Any"))
            {
                if(c==0)
                    search = search + " gender = '" + gender + "'";
                else
                    search = search + " and gender = '" + gender + "'";

                c++;

            }

            if(room.Length>0)
            {
                if(c==0)
                    search=search + " room = '" + room + "'";
                else
                    search = search + " and room = '" + room + "'";

                c++;
            }

            if(roll.Length>0)
            {
                if(c==0)
                    search = search + " roll = " + roll;
                else
                    search = search + " and roll = " + roll;

                c++;
            }

            Response.Write(search);
        }
    }
}