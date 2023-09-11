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
    public partial class DeletionLogs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetDeletedStudents();
            }
        }

        protected void GetDeletedStudents()
        {
            string viewName = "vw_deleted_students";
            string query = $"select * from {viewName}";
            DatabaseInfo dbConnection = DatabaseInfo.Instance;
            OracleDataReader reader = dbConnection.GetDataFromDataReader(query, System.Data.CommandType.Text);
            try
            {
                rpt_deleted_students.DataSource = reader;
                rpt_deleted_students.DataBind();
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