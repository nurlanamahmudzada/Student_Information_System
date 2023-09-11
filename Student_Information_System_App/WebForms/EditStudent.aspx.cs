using Oracle.ManagedDataAccess.Client;
using Student_Information_System_App.DB;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.DynamicData;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Student_Information_System_App.WebForms
{
    public partial class EditStudent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetStudents();
            }
        }

        protected void GetStudents()
        {
            string viewName = "vw_students";
            string query = $"select ID from {viewName}";
            DatabaseInfo dbConnection = DatabaseInfo.Instance;
            OracleDataReader reader = dbConnection.GetDataFromDataReader(query, System.Data.CommandType.Text);
            try
            {
                ddl_select_student.DataSource = reader;
                ddl_select_student.DataTextField = "ID";
                ddl_select_student.DataValueField = "ID";
                ddl_select_student.DataBind();
            }
            catch
            {
                lbl_message.ForeColor = Color.Red;
                lbl_message.Text = "An error occured.";
            }
            finally
            {
                reader.Close();
            }
        }

        protected void btn_select (object sender, EventArgs e)
        {
            int id = Convert.ToInt32(ddl_select_student.SelectedValue);
            DatabaseInfo dbConnection = DatabaseInfo.Instance;
            dbConnection.AddInputParameter("s_id", OracleDbType.Int32, id, System.Data.ParameterDirection.Input);
            dbConnection.AddOutputParameter("s_name", OracleDbType.Varchar2, System.Data.ParameterDirection.Output);
            dbConnection.AddOutputParameter("s_surname", OracleDbType.Varchar2, System.Data.ParameterDirection.Output);
            dbConnection.AddOutputParameter("phone", OracleDbType.Int32, System.Data.ParameterDirection.Output);
            dbConnection.AddOutputParameter("email", OracleDbType.Varchar2, System.Data.ParameterDirection.Output);
            dbConnection.AddOutputParameter("entrance_point", OracleDbType.Int32, System.Data.ParameterDirection.Output);
            dbConnection.AddOutputParameter("dept_id", OracleDbType.Int32, System.Data.ParameterDirection.Output);
            dbConnection.AddOutputParameter("e_date", OracleDbType.Date, System.Data.ParameterDirection.Output);
            dbConnection.AddOutputParameter("g_date", OracleDbType.Date, System.Data.ParameterDirection.Output);
            dbConnection.AddOutputParameter("student_cursor", OracleDbType.RefCursor, System.Data.ParameterDirection.Output);

            OracleDataReader rd = dbConnection.GetDataFromDataReader("get_student_data", System.Data.CommandType.StoredProcedure);
            try
            {
                if (rd.Read())
                {
                    tb_name.Text = rd["name"].ToString();
                    tb_surname.Text = rd["surname"].ToString();
                    tb_email.Text = rd["email"].ToString();
                    tb_phone.Text = rd["phone"].ToString();
                    tb_point.Text = rd["entrance_point"].ToString();
                    tb_dept_id.Text = rd["department_id"].ToString();
                    tb_entry_date.Text = rd["entry_date"].ToString();
                    tb_graduate_date.Text = rd["graduate_date"].ToString();
                }
            }
            catch(Exception ex)
            {
                lbl_message.ForeColor = Color.Red;
                lbl_message.Text = "An error occured.";
            }
            finally
            {
            rd.Close();
            }

        }

        protected void btn_update(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(ddl_select_student.SelectedValue);
                int phone = Convert.ToInt32(tb_phone.Text);
                int point = Convert.ToInt32(tb_point.Text);
                int dept_id = Convert.ToInt32(tb_dept_id.Text);
                DateTime entry_date = Convert.ToDateTime(tb_entry_date.Text);
                DateTime graduate_date = Convert.ToDateTime(tb_graduate_date.Text);
                DatabaseInfo dbConnection = DatabaseInfo.Instance;
                dbConnection.AddInputParameter("s_id", OracleDbType.Int32, id, System.Data.ParameterDirection.Input);
                dbConnection.AddInputParameter("s_name", OracleDbType.Varchar2, tb_name.Text, System.Data.ParameterDirection.Input);
                dbConnection.AddInputParameter("s_surname", OracleDbType.Varchar2, tb_surname.Text, System.Data.ParameterDirection.Input);
                dbConnection.AddInputParameter("phone", OracleDbType.Int32, phone, System.Data.ParameterDirection.Input);
                dbConnection.AddInputParameter("email", OracleDbType.Varchar2, tb_email.Text, System.Data.ParameterDirection.Input);
                dbConnection.AddInputParameter("e_point", OracleDbType.Int32, point, System.Data.ParameterDirection.Input);
                dbConnection.AddInputParameter("dept_id", OracleDbType.Int32, dept_id, System.Data.ParameterDirection.Input);
                dbConnection.AddInputParameter("e_date", OracleDbType.Date, entry_date, System.Data.ParameterDirection.Input);
                dbConnection.AddInputParameter("g_date", OracleDbType.Date, graduate_date, System.Data.ParameterDirection.Input);
                dbConnection.InsertParameter("update_student", System.Data.CommandType.StoredProcedure);
                lbl_message.ForeColor = Color.Green;
                lbl_message.Text = $"The {id} student was successfully updated.";
            }
            catch(Exception ex) {
                lbl_message.ForeColor = Color.Red;
                lbl_message.Text = "An error occurred. Check the entered data.";
            }
        }

        protected void c_graduate_date_SelectionChanged(Object o,  EventArgs e)
        {
            DateTime selectedDate = c_graduate_date.SelectedDate;
            tb_graduate_date.Text = selectedDate.ToString();
        }

        protected void c_entry_date_SelectionChanged(Object o, EventArgs e)
        {
            DateTime selectedDate = c_entry_date.SelectedDate;
            tb_entry_date.Text = selectedDate.ToString();
        }
    }
}