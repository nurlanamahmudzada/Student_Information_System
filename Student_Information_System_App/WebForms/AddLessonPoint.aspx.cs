using Oracle.ManagedDataAccess.Client;
using Student_Information_System_App.DB;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Student_Information_System_App.WebForms
{
    public partial class AddLessonPoint : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
            DropDownStudentsList();
            LessonPoints();
            }
        }

        protected void DropDownStudentsList()
        {
            string viewName = "vw_student_id_name";
            string query = $"select * from {viewName}";
            DatabaseInfo dbConnection = DatabaseInfo.Instance;
            OracleDataReader reader = dbConnection.GetDataFromDataReader(query, CommandType.Text);
            try
            {
                ddl_select_student.DataSource = reader;
                ddl_select_student.DataTextField = "Student Id and Name";
                ddl_select_student.DataValueField = "Student Id";
                ddl_select_student.DataBind();
            }
            catch(Exception ex) 
            {
                lbl_message.ForeColor = Color.Red;
                lbl_message.Text = "An error occured.";
            }
            finally
            {
            reader.Close();
            }
        }

        protected void btn_search(object sender, EventArgs e)
        {

            LessonPoints();
            GetLessons();
        }

        protected void GetLessons()
        {
            int id = Convert.ToInt32(ddl_select_student.SelectedValue);
            string viewName = "VW_STUDENT_TEACHER_LESSON";
            string query = $"select \"Lesson Id\", \"Lesson Name\" from {viewName} where \"Student Id\" = {id}";
            DatabaseInfo dbConnection = DatabaseInfo.Instance;
            OracleDataReader reader = dbConnection.GetDataFromDataReader(query, CommandType.Text);
            try
            {
                ddl_lesson_names.DataSource = reader;
                ddl_lesson_names.DataTextField = "Lesson Name";
                ddl_lesson_names.DataValueField = "Lesson Id";
                ddl_lesson_names.DataBind();
            }
            catch (Exception ex)
            {
                lbl_message.ForeColor = Color.Red;
                lbl_message.Text = "An error occurred. Check the entered data.";
            }
            finally
            {
                reader.Close();
            }
        }

        protected void btn_add_point(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(ddl_select_student.SelectedValue);
                int lesson_id = Convert.ToInt32(ddl_lesson_names.SelectedValue);
                int point = Convert.ToInt32(tb_point.Text);
                DatabaseInfo dbConnection = DatabaseInfo.Instance;
                dbConnection.AddInputParameter("s_id", OracleDbType.Int32, id, ParameterDirection.Input);
                dbConnection.AddInputParameter("l_id", OracleDbType.Int32, lesson_id, ParameterDirection.Input);
                dbConnection.AddInputParameter("point", OracleDbType.Int32, point, ParameterDirection.Input);
                dbConnection.InsertParameter("procedure_insert_gpa", CommandType.StoredProcedure);
                lbl_message.ForeColor = Color.Green;
                lbl_message.Text = $"Score {point} was successfully added.";              
                LessonPoints();
            }
            catch(Exception ex)
            {
                lbl_message.ForeColor = Color.Red;
                lbl_message.Text = "An error occurred. Check the entered data.";
            }
        }

        protected void LessonPoints()
        {
            int id = Convert.ToInt32(ddl_select_student.SelectedValue);
            DatabaseInfo dbConnection = DatabaseInfo.Instance;
            dbConnection.AddInputParameter("s_id", OracleDbType.Int32, id, ParameterDirection.InputOutput);
            dbConnection.AddOutputParameter("\"Lesson Name\"", OracleDbType.Varchar2, ParameterDirection.Output);
            dbConnection.AddOutputParameter("\"Point\"", OracleDbType.Int32, ParameterDirection.Output);
            dbConnection.AddOutputParameter("lesson_point_cursor", OracleDbType.RefCursor, ParameterDirection.Output);
            OracleDataReader reader = dbConnection.GetDataFromDataReader("procedure_lesson_points", CommandType.StoredProcedure);
            try
            {
                rpt_lesson_points.DataSource = reader;
                rpt_lesson_points.DataBind();
            }
            catch(Exception ex)
            {
                lbl_message.ForeColor = Color.Red;
                lbl_message.Text = "An error occured.";
            }
            finally { 
            reader.Close();
            }
        }

    }
}