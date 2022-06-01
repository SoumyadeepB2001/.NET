using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace StudentForm
{
    public partial class StudentForm : Form
    {
        public StudentForm()
        {
            InitializeComponent();
        }

        public SqlConnection conn;
        public SqlCommand comm;
        String action;

        public void setdefault()
        {
            this.txtID.Clear();
            this.txtRoll.Clear();
            this.txtName.Clear();
            this.txtSearch.Clear();
            action = "A";
            this.lblMessage.Text = "Enter the student details and click Save to insert new record";
            this.cancelBtn.Visible = false;
            this.delBtn.Visible = false;
        }

        private void StudentForm_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection("Server=DESKTOP-TJNFESQ;Database=testdb1;Trusted_Connection=true");
            this.setdefault();
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            if (action == "A")
            {
                conn.Open();
                try
                {
                    string insertquery = "insert into student(name, roll) values('" + this.txtName.Text + "', '" + this.txtRoll.Text + "')";
                    comm = new SqlCommand(insertquery, conn);
                    comm.ExecuteNonQuery();
                    MessageBox.Show("Record Inserted");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                conn.Close();
            }


            if(action == "U")
            {
                conn.Open();
                try
                {
                    string updatequery = "update student set roll='"+ this.txtRoll.Text +"', name='" + this.txtName.Text + "' where id= " + this.txtID.Text;
                    comm = new SqlCommand(updatequery, conn);
                    comm.ExecuteNonQuery();
                    MessageBox.Show("Record Updated");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                conn.Close();
            }

            this.setdefault();    
        }

        private void delBtn_Click(object sender, EventArgs e)
        {
            conn.Open();
            try
            {
                string deletequery = "delete from student where id= " + this.txtID.Text;
                comm = new SqlCommand(deletequery, conn);
                comm.ExecuteNonQuery();
                MessageBox.Show("Record Deleted");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            conn.Close();

            this.setdefault();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.setdefault();
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            conn.Open();
            int flag = 0;
            try
            {
                string searchquery = "select id, name, roll from student where roll= '" + this.txtSearch.Text + "'";
                comm = new SqlCommand(searchquery, conn);
                SqlDataReader sdr = comm.ExecuteReader();
                while (sdr.Read())
                {
                    this.txtID.Text = sdr["id"].ToString();
                    this.txtRoll.Text = sdr["roll"].ToString();
                    this.txtName.Text = sdr["name"].ToString();
                    flag=1;
                }

                if (flag == 1)
                {
                    this.lblMessage.Text = "Change Data To Update";
                    action = "U";
                    this.cancelBtn.Visible = true;
                    this.delBtn.Visible = true;
                    this.txtSearch.Clear();
                }
                else
                {
                    MessageBox.Show("No data found");
                    this.txtSearch.Clear();
                }
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            conn.Close();
        }

    }
}
