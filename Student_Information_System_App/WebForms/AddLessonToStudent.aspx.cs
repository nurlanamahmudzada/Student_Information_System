using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using Student_Information_System_App.DB;
using Student_Information_System_App.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Input;

namespace Student_Information_System_App.WebForms
{
    public partial class AddLessonToStudent : System.Web.UI.Page
    {
        private const int itemsPerPage = 5;
        protected int CurrentPage
        {
            get { return ViewState["CurrentPage"] != null ? (int)ViewState["CurrentPage"] : 1; }
            set { ViewState["CurrentPage"] = value; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetStudentsWithTeachers();
                DropDownStudentsList();

            }
        }

        protected void GetStudentsWithTeachers()
        {
            int startRow = (CurrentPage - 1) * itemsPerPage + 1;
            int endRow = startRow + itemsPerPage - 1;
            string viewName = "vw_student_teacher_lesson";
            string query = $"SELECT * FROM (SELECT ROW_NUMBER() OVER (ORDER BY Id) row_num, Id, \"Student Id\", \"Student Name\", \"Teacher Name\", \"Lesson Name\" FROM {viewName}) WHERE row_num BETWEEN :startRow AND :endRow";
            DatabaseInfo dbConnection = DatabaseInfo.Instance;

            dbConnection.AddInputParameter("startRow", OracleDbType.Int32, startRow, ParameterDirection.Input);
            dbConnection.AddInputParameter("endRow", OracleDbType.Int32, endRow, ParameterDirection.Input);
            OracleDataReader reader = dbConnection.GetDataFromDataReader(query, CommandType.Text);

            try
            {
                rpt_student_teacher_lesson.DataSource = reader;
                rpt_student_teacher_lesson.DataBind();
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

        public void DropDownStudentsList()
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

        protected void DropDownTeacherLessonName()
        {
            ddl_teacher_lesson_name.ClearSelection();
            int id = Convert.ToInt32(ddl_select_student.SelectedValue);
            DatabaseInfo dbConnection = DatabaseInfo.Instance;
            dbConnection.AddInputParameter("s_id", OracleDbType.Int32, id, ParameterDirection.Input);
            dbConnection.AddOutputParameter("teacherLesson_name", OracleDbType.Varchar2, ParameterDirection.Output);
            dbConnection.AddOutputParameter("t_id", OracleDbType.Int32, ParameterDirection.Output);
            dbConnection.AddOutputParameter("t_l_cursor", OracleDbType.RefCursor, ParameterDirection.Output);
            OracleDataReader reader = dbConnection.GetDataFromDataReader("teacher_lesson_name", CommandType.StoredProcedure);
            try
            {
                ddl_teacher_lesson_name.DataSource = reader;
                ddl_teacher_lesson_name.DataTextField = "data";
                ddl_teacher_lesson_name.DataValueField = "t_id";
                ddl_teacher_lesson_name.DataBind();
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
            try
            {
                DropDownTeacherLessonName();
            }
            catch(Exception ex)
            {
                lbl_message.ForeColor = Color.Red;
                lbl_message.Text = "An error occurred. Check the entered data.";
            }
        }

        protected void btn_add_event(object sender, EventArgs e)
        {
            try
            {
                int t_id = Convert.ToInt32(ddl_teacher_lesson_name.SelectedValue);
                int s_id = Convert.ToInt32(ddl_select_student.SelectedValue);
                DatabaseInfo dbConnection = DatabaseInfo.Instance;
                dbConnection.AddInputParameter("s_id", OracleDbType.Int32, s_id, ParameterDirection.Input);
                dbConnection.AddInputParameter("t_id", OracleDbType.Int32, t_id, ParameterDirection.Input);
                dbConnection.InsertParameter("insert_lesson_to_student", CommandType.StoredProcedure);
                GetStudentsWithTeachers();
                DropDownTeacherLessonName();
                lbl_message.ForeColor = Color.Green;
                lbl_message.Text = $"{t_id} lesson was successfully added.";
            }
            catch(Exception ex)
            {
                lbl_message.ForeColor = Color.Red;
                lbl_message.Text = "An error occurred. Check the entered data.";
            }
        }

        protected void btn_delete(object sender, EventArgs e)
        {           
            try
            {
                Button btn = (Button)sender;
                string id = btn.CommandArgument;
                DatabaseInfo dbConnection = DatabaseInfo.Instance;
                dbConnection.AddInputParameter("t_id", OracleDbType.Varchar2, id, ParameterDirection.Input);
                dbConnection.InsertParameter("delete_lesson_from_student", CommandType.StoredProcedure);
                GetStudentsWithTeachers();
            }
            catch (Exception ex)
            {
                lbl_message.ForeColor = Color.Red;
                lbl_message.Text = "An error occured.";
            }

        }

        protected void PrevBtn_Click(object sender, EventArgs e)
        {
            nextBtn.Enabled = true;
            if (CurrentPage > 1)
            {
                CurrentPage--;
                GetStudentsWithTeachers();
            }
            if (CurrentPage == 1)
            {
                prevBtn.Enabled = false;
            }
        }

        protected void NextBtn_Click(object sender, EventArgs e)
        {
            prevBtn.Enabled = true;
            int totalPages = CalculateTotalPages();
            if (CurrentPage < totalPages)
            {
                CurrentPage++;
                GetStudentsWithTeachers();
            }
            if (CurrentPage == totalPages)
            {
                nextBtn.Enabled = false;
            }

        }

        private int CalculateTotalPages()
        {
            int totalRecords = GetTotalRows();
            int totalPages = (int)Math.Ceiling((double)totalRecords / itemsPerPage);
            return totalPages;

        }

        private int GetTotalRows()
        {
            string viewName = "vw_student_teacher_lesson";
            string query = $"select count(*) from {viewName}";
            DatabaseInfo dbConnection = DatabaseInfo.Instance;
            OracleCommand cmd = dbConnection.WriteQuery(query, CommandType.Text);
            object result = cmd.ExecuteScalar();
            int resultInt = Convert.ToInt32(result);
            return resultInt;
        }


    }
}

        


    
