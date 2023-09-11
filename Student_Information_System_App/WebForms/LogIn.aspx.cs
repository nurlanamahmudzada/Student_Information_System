using Student_Information_System_App.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Student_Information_System_App.DB;
using Oracle.ManagedDataAccess.Client;
using System.Drawing;
using Microsoft.Ajax.Utilities;

namespace Student_Information_System_App.WebForms
{
    public partial class LogIn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btn_login(object sender, EventArgs e)
        {
            LoginSystem();
        }

        protected void LoginSystem()
        {
            string email = tb_email.Text;
            string password = tb_password.Text;
            //string viewName = "vw_admin_login";
            DatabaseInfo dbConnection = DatabaseInfo.Instance;
            string query = "select email, password from admin";
            OracleDataReader reader = dbConnection.GetDataFromDataReader(query, System.Data.CommandType.Text);
            try
            {              
                    while(reader.Read())
                    {
                        if (reader["email"].ToString() == email && reader["password"].ToString() == password)
                        {
                            Session["email"] = email;
                            break;
                        }
                    }
                    
                
            }
            catch (Exception ex)
            {
                lbl_message.Text = "An error occured.";
                lbl_message.ForeColor = Color.Red;
            }
            finally
            {
                reader.Close();
            }
            if (Session["email"] != null)
            {
                Response.Redirect("~/WebForms/Dashboard");
            }
            else
            {
                lbl_message.Text = "Email or password is wrong.";
            }
        }
    }
}