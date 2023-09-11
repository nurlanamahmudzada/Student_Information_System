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
    public partial class DeletedTeacherLogs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetDeletedTeachers();
            }
        }

        protected void GetDeletedTeachers()
        {
            string viewName = "vw_deleted_teachers";
            string query = $"select * from {viewName}";
            DatabaseInfo dbConnection = DatabaseInfo.Instance;
            OracleDataReader reader = dbConnection.GetDataFromDataReader(query, System.Data.CommandType.Text);
            try
            {
                rpt_deleted_teachers.DataSource = reader;
                rpt_deleted_teachers.DataBind();
            }
            catch(Exception ex)
            {
                
            }
            finally
            {
            reader.Close();
            }
        }
    }
}