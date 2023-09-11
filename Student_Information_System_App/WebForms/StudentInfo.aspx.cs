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
    public partial class StudentInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetStudentsInfo();
            }
        }

        protected void GetStudentsInfo()
        {
            string viewName = "student_description";
            string query = $"select * from {viewName}";
            DatabaseInfo dbConnection = DatabaseInfo.Instance;
            OracleDataReader reader = dbConnection.GetDataFromDataReader(query, System.Data.CommandType.Text);
            
            try
            {
                rpt_students_info.DataSource = reader;
                rpt_students_info.DataBind();
                reader.Close();
            }
            catch
            {
   
            }
            finally
            {
                reader.Close();
            }
        }
    }
}