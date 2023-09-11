using Oracle.ManagedDataAccess.Client;
using Student_Information_System_App.BLL;
using Student_Information_System_App.DB;
using Student_Information_System_App.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading.Tasks;

namespace Student_Information_System_App.WebForms
{
    public partial class AddTeacher : System.Web.UI.Page
    {
        TeacherBBL teacherBBL = new TeacherBBL();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_add(Object sender, EventArgs e)
        {
            try
            {
                lbl_error_message.Text = "";
                Teacher teacher = new Teacher()
                {
                    Name = tb_name.Text,
                    Surname = tb_surname.Text,
                    PhoneNumber = tb_phone.Text,
                    Email = tb_email.Text,
                    BeginDate = calendar_employment_date.SelectedDate,
                    EndDate = calendar_quiting_date.SelectedDate,
                    LessonName = tb_lesson_name.Text
                };
                teacherBBL.AddTeacher(teacher);
                lbl_error_message.ForeColor = Color.Green;
                lbl_error_message.Text = $"Teacher {tb_name.Text} was succesfully added.";
                
            }
            catch(Exception ex)
            {
                lbl_error_message.ForeColor = Color.Red;
                lbl_error_message.Text = "An error occurred. Check the entered data.";
            }
        }
        protected void c_emp_date_SelectionChanged(object sender, EventArgs e)
        {
            DateTime selectedDate = calendar_employment_date.SelectedDate;
            tb_employment_date.Text = selectedDate.ToString("M/dd/yyyy");
        }

        protected void c_quit_date_SelectionChanged(Object sender, EventArgs e)
        {
            DateTime selectedDate = calendar_quiting_date.SelectedDate;
            tb_quiting_date.Text = selectedDate.ToString("M/dd/yyyy");
        }
    }
}