using Oracle.ManagedDataAccess.Client;
using Student_Information_System_App.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Student_Information_System_App.WebForms
{
    public partial class Dashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FormData();
                StaffCount();
            }
        }

        protected void btn_logout(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            Response.Redirect("~/WebForms/LogIn");
        }

        protected void FormData()
        {
            string query = $"select name, surname, email, phone, image from admin where email = '{Session["email"]}'";
            DatabaseInfo dbConnection = DatabaseInfo.Instance;
            OracleDataReader reader = dbConnection.GetDataFromDataReader(query, System.Data.CommandType.Text);
            if(reader.Read())
            {
                string name = reader["name"].ToString();
                string surname = reader["surname"].ToString();
                lbl_admin.Text = "Welcome" + " " + name + " " + surname;
                lbl_name.Text = name;
                lbl_surname.Text = surname;
                lbl_email.Text = reader["email"].ToString();
                lbl_phone.Text = reader["phone"].ToString();
                admin_image.ImageUrl = reader["image"].ToString();
            }
        }

        protected void StaffCount()
        {
            string viewName = "vw_staff_count";
            string query = $"select * from {viewName}";
            DatabaseInfo dbConnection = DatabaseInfo.Instance;
            OracleDataReader reader = dbConnection.GetDataFromDataReader(query, System.Data.CommandType.Text);
            if (reader.Read())
            {
                lbl_s_count.Text = reader["s_count"].ToString();
                lbl_l_count.Text = reader["l_count"].ToString();
                lbl_t_count.Text = reader["t_count"].ToString();
                lbl_d_count.Text = reader["d_count"].ToString();
            }
        }
    }
}