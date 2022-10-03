using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace StudentWebFinal
{
    public class Class1
    {
        public void ShowAlertMessage(string error)
        {
            System.Web.UI.Page page = System.Web.HttpContext.Current.Handler as Page;
            if (page != null)
            {
                error = error.Replace("'", "\'");
                ScriptManager.RegisterStartupScript(page, page.GetType(), "err_msg", "alert('" + error + "');", true);
            }
        }


        public string strConnectionString;
        public SqlCommand _sqlCommand;

        public void CreateConnection()
        {
            strConnectionString = ConfigurationManager.ConnectionStrings["connection1"].ConnectionString;
            SqlConnection _sqlConnection = new SqlConnection(strConnectionString);
            _sqlCommand = new SqlCommand();
            _sqlCommand.Connection = _sqlConnection;
        }

        public void OpenConnection()
        {
            _sqlCommand.Connection.Open();
        }

        public void CloseConnection()
        {
            _sqlCommand.Connection.Close();
        }

        public void DisposeConnection()
        {
            _sqlCommand.Connection.Dispose();
        }
    }
}