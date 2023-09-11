using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using Student_Information_System_App.BLL;
using Student_Information_System_App.DB;
using Student_Information_System_App.Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Student_Information_System_App.WebForms
{
    public partial class AddStudent : System.Web.UI.Page
    {
        StudentBBL studentBBL = new StudentBBL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DepartmentsDropDown();
            }
        }
        protected void btn_submit(object sender, EventArgs e)
        {
            try
            {
                Student student = new Student()
                {
                    Name = tb_name.Text,
                    Surname = tb_surname.Text,
                    PhoneNumber = tb_phone.Text,
                    Email = tb_email.Text,
                    EntrancePoint = Convert.ToInt32(tb_entrance_point.Text),
                    DepartmentId = Convert.ToInt32(ddl_departments.SelectedValue),
                    //EntryDate = DateTime.ParseExact(tb_entry_date.Text, "M/dd/yyyy", CultureInfo.InvariantCulture),
                    BeginDate = calendar_entry_date.SelectedDate,
                    EndDate = calendar_graduate_date.SelectedDate
                };
                studentBBL.AddStudent(student);
                lbl_message.ForeColor = Color.Green;
                lbl_message.Text = $"Student {tb_name.Text} was succesfully added.";
            }
            catch (Exception ex)
            {
                lbl_message.ForeColor = Color.Red;
                lbl_message.Text = "An error occurred. Check the entered data.";
            }
        }
        private void DepartmentsDropDown()
        {
            string viewName = "vw_show_departments";
            string query = $"select * from {viewName}";
            DatabaseInfo dbConnection = DatabaseInfo.Instance;
            OracleDataReader reader = dbConnection.GetDataFromDataReader(query, CommandType.Text);
            ddl_departments.DataSource = reader;
            try
            {
                ddl_departments.DataTextField = "Department Name";
                ddl_departments.DataValueField = "Department Id";
                ddl_departments.DataBind();
            }
            catch
            {
                lbl_message.ForeColor = Color.Red;
                lbl_message.Text = "An error occurred.";
            }
            finally
            {
            reader.Close();
            }
        }

        protected void c_entry_date_SelectionChanged(object sender, EventArgs e)
        {
                DateTime selectedDate = calendar_entry_date.SelectedDate;
                tb_entry_date.Text = selectedDate.ToString("M/dd/yyyy");          
        }

        protected void c_graduate_date_SelectionChanged(object sender, EventArgs e)
        {
            DateTime selectedDate = calendar_graduate_date.SelectedDate;
            tb_graduate_date.Text = selectedDate.ToString("M/dd/yyyy");         
        }

    }
}