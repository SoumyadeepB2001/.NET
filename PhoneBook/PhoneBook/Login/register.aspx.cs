using System;
using System.Data;
using System.Web.UI;

namespace PhoneBook.Login
{
    public partial class register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            ConnectionClass con = new ConnectionClass();
            try
            {
                con.CreateConnection();
                con.OpenConnection();
                con._sqlCommand.CommandText = "insert_users";
                con._sqlCommand.CommandType = CommandType.StoredProcedure;

                con._sqlCommand.Parameters.AddWithValue("@name", Convert.ToString(txtNameReg.Text.Trim()));
                con._sqlCommand.Parameters.AddWithValue("@phone", Convert.ToString(txtPhoneReg.Text.Trim()));
                con._sqlCommand.Parameters.AddWithValue("@email", Convert.ToString(txtEmailReg.Text.Trim()));
                con._sqlCommand.Parameters.AddWithValue("@pass", Convert.ToString(txtPasswordReg.Text.Trim()));
                con._sqlCommand.Parameters.AddWithValue("@table_name", Convert.ToString(txtEmailReg.Text.Trim()) + "_table");
                con._sqlCommand.ExecuteNonQuery();
                ShowAlertMessage("Record inserted successfully");
                ClearControls();
                Page.ClientScript.RegisterStartupScript(this.GetType(), "OpenWindow", "window.open('/Login/login.aspx');", true);


            }
            catch (Exception ex)
            {
                ShowAlertMessage("Record insertion failed\nCheck your input data");
            }

            finally
            {
                con.CloseConnection();
                con.DisposeConnection();
            }
        }

        public void ClearControls()
        {
            txtNameReg.Text = "";
            txtPhoneReg.Text = "";
            txtEmailReg.Text = "";
            txtPasswordReg.Text = "";
        }
    }
}