using Oracle.ManagedDataAccess.Client;
using Student_Information_System_App.DB;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Student_Information_System_App.WebForms
{
    public partial class EditTeacher : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetTeachersId();
            }
        }

        protected void GetTeachersId()
        {
            string viewName = "vw_teachers";
            string query = $"select ID from {viewName}";
            DatabaseInfo dbConnection = DatabaseInfo.Instance;
            OracleDataReader reader = dbConnection.GetDataFromDataReader(query, System.Data.CommandType.Text);
            
            try
            {
                ddl_select_teachers.DataSource = reader;
                ddl_select_teachers.DataTextField = "ID";
                ddl_select_teachers.DataValueField = "ID";
                ddl_select_teachers.DataBind();
            }
            catch (Exception ex)
            {
                lbl_message.ForeColor = Color.Red;
                lbl_message.Text = "An error occured.";
            }
            finally
            {
                reader.Close();
            }
        }

        protected void btn_select(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(ddl_select_teachers.SelectedValue);
            DatabaseInfo dbConnection = DatabaseInfo.Instance;
            dbConnection.AddInputParameter("t_id", OracleDbType.Int32, id, System.Data.ParameterDirection.Input);
            dbConnection.AddOutputParameter("t_name", OracleDbType.Varchar2, System.Data.ParameterDirection.Output);
            dbConnection.AddOutputParameter("t_surname", OracleDbType.Varchar2, System.Data.ParameterDirection.Output);
            dbConnection.AddOutputParameter("phone", OracleDbType.Int32, System.Data.ParameterDirection.Output);
            dbConnection.AddOutputParameter("email", OracleDbType.Varchar2, System.Data.ParameterDirection.Output);
            dbConnection.AddOutputParameter("lesson_name", OracleDbType.Varchar2, System.Data.ParameterDirection.Output);
            dbConnection.AddOutputParameter("e_date", OracleDbType.Date, System.Data.ParameterDirection.Output);
            dbConnection.AddOutputParameter("q_date", OracleDbType.Date, System.Data.ParameterDirection.Output);
            dbConnection.AddOutputParameter("teacher_cursor", OracleDbType.RefCursor, System.Data.ParameterDirection.Output);
            OracleDataReader rd = dbConnection.GetDataFromDataReader("get_teacher_data", System.Data.CommandType.StoredProcedure);
            
            try
            {
                if (rd.Read())
                {
                    tb_name.Text = rd["name"].ToString();
                    tb_surname.Text = rd["surname"].ToString();
                    tb_email.Text = rd["email"].ToString();
                    tb_phone.Text = rd["phone"].ToString();
                    tb_l_name.Text = rd["l_name"].ToString();
                    tb_employment_date.Text = rd["employment_date"].ToString();
                    tb_quiting_date.Text = rd["quiting_date"].ToString();
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
                int id = Convert.ToInt32(ddl_select_teachers.SelectedValue);
                int phone = Convert.ToInt32(tb_phone.Text);
                DateTime employment_date = Convert.ToDateTime(tb_employment_date.Text);
                DateTime quiting_date = Convert.ToDateTime(tb_quiting_date.Text);
                DatabaseInfo dbConnection = DatabaseInfo.Instance;
                dbConnection.AddInputParameter("t_id", OracleDbType.Int32, id, System.Data.ParameterDirection.Input);
                dbConnection.AddInputParameter("t_name", OracleDbType.Varchar2, tb_name.Text, System.Data.ParameterDirection.Input);
                dbConnection.AddInputParameter("t_surname", OracleDbType.Varchar2, tb_surname.Text, System.Data.ParameterDirection.Input);
                dbConnection.AddInputParameter("phone", OracleDbType.Int32, phone, System.Data.ParameterDirection.Input);
                dbConnection.AddInputParameter("email", OracleDbType.Varchar2, tb_email.Text, System.Data.ParameterDirection.Input);
                dbConnection.AddInputParameter("lesson_name", OracleDbType.Varchar2, tb_l_name.Text, System.Data.ParameterDirection.Input);
                dbConnection.AddInputParameter("e_date", OracleDbType.Date, employment_date, System.Data.ParameterDirection.Input);
                dbConnection.AddInputParameter("q_date", OracleDbType.Date, quiting_date, System.Data.ParameterDirection.Input);
                dbConnection.InsertParameter("update_teacher", System.Data.CommandType.StoredProcedure);
                lbl_message.ForeColor = Color.Green;
                lbl_message.Text = $"The {id} teacher was successfully updated.";
            }
            catch (Exception ex)
            {
                lbl_message.ForeColor = Color.Red;
                lbl_message.Text = "An error occurred. Check the entered data.";
            }          
        }

        protected void c_employment_date_SelectionChanged(Object o, EventArgs e)
        {
            DateTime selectedDate = c_employment_date.SelectedDate;
            tb_employment_date.Text = selectedDate.ToString();
        }

        protected void c_quiting_date_SelectionChanged(Object o, EventArgs e)
        {
            DateTime selectedDate = c_quiting_date.SelectedDate;
            tb_quiting_date.Text = selectedDate.ToString();
        }

    }
}