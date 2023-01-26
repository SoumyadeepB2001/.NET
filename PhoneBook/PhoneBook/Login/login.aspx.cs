using System;
using System.Data.SqlClient;
using System.Data;

namespace PhoneBook.Login
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.Cookies["userPassword"] != null && Request.Cookies["userEmail"] != null)
                {
                    txtEmail.Text = Request.Cookies["userEmail"].Value;
                    txtPassword.Text = Request.Cookies["userPassword"].Value;
                    btnLogIn_Click(null, null);
                }
            }
        }
        private static void ShowAlertMessage(string error)
        {
            System.Web.UI.Page page = System.Web.HttpContext.Current.Handler as System.Web.UI.Page;
            if (page != null)
            {
                error = error.Replace("'", "\'");
                System.Web.UI.ScriptManager.RegisterStartupScript(page, page.GetType(), "err_msg", "alert('" + error + "');", true);
            }
        }

        protected void btnLogIn_Click(object sender, EventArgs e)
        {
            ConnectionClass con = new ConnectionClass();
            int flag = 0;
            String table_name = "";

            if (cbRemember.Checked)
            {
                Response.Cookies["userEmail"].Value = txtEmail.Text.Trim();
                Response.Cookies["userPassword"].Value = txtPassword.Text.Trim();

                Response.Cookies["userPassword"].Expires = DateTime.Now.AddDays(60);
                Response.Cookies["userEmail"].Expires = DateTime.Now.AddDays(60);
            }

            try
            {
                con.CreateConnection();
                con.OpenConnection();
                con._sqlCommand.CommandText = "validate_users";
                con._sqlCommand.CommandType = CommandType.StoredProcedure;

                con._sqlCommand.Parameters.AddWithValue("@email", Convert.ToString(txtEmail.Text.Trim()));
                con._sqlCommand.Parameters.AddWithValue("@user_password", Convert.ToString(txtPassword.Text.Trim()));

                SqlDataReader sdr = con._sqlCommand.ExecuteReader();
                while (sdr.Read())
                {
                    flag++;
                    table_name = sdr["table_name"].ToString();
                }

                if (flag == 1)
                {
                    ClearControls();
                    Session["table_name"] = table_name;

                    if (string.IsNullOrEmpty(Session["link"] as string))
                    {
                        Response.Redirect("/Home/Home.aspx");
                    }
                    else
                    {
                        string link = Session["link"].ToString();
                        Response.Redirect(link);
                    }

                }

                else
                    ShowAlertMessage("Invalid Credentials");

            }

            catch (Exception ex)
            {
                ShowAlertMessage("An error occured");
            }

            finally
            {
                con.CloseConnection();
                con.DisposeConnection();
            }
        }

        public void ClearControls()
        {
            txtEmail.Text = "";
            txtPassword.Text = "";
        }
    }
}