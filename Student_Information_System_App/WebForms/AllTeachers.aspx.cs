using Oracle.ManagedDataAccess.Client;
using Student_Information_System_App.DB;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Student_Information_System_App.WebForms
{
    public partial class AllTeachers : System.Web.UI.Page
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
                LoadData();
            }
        }

        protected void LoadData()
        {
            string viewName = "vw_teachers";
            string query = $"SELECT row_num, t.* FROM (SELECT ROW_NUMBER() OVER (ORDER BY ID) AS row_num, {viewName}.* FROM {viewName}) t WHERE row_num BETWEEN :StartRow AND :EndRow";
            int startRow = (CurrentPage - 1) * itemsPerPage + 1;
            int endRow = startRow + itemsPerPage - 1;
            DatabaseInfo dbConnection = DatabaseInfo.Instance;
            dbConnection.AddInputParameter("StartRow", OracleDbType.Int32, startRow, ParameterDirection.Input);
            dbConnection.AddInputParameter("EndRow", OracleDbType.Int32, endRow, ParameterDirection.Input);
            OracleDataReader reader = dbConnection.GetDataFromDataReader(query, CommandType.Text);
            try
            {
                rpt_all_teachers.DataSource = reader;
                rpt_all_teachers.DataBind();
            }
            catch
            {

            }
            finally
            {
            reader.Close();
            }
            
        }
        protected void PrevBtn_Click(object sender, EventArgs e)
        {
            nextBtn.Enabled = true;
            if (CurrentPage > 1)
            {
                CurrentPage--;
                LoadData();
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
                LoadData();
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
            string query = "select count(*) from teacher";
            DatabaseInfo dbConnection = DatabaseInfo.Instance;
            OracleCommand cmd = dbConnection.WriteQuery(query, CommandType.Text);
            object result = cmd.ExecuteScalar();
            int resultInt = Convert.ToInt32(result);
            return resultInt;
        }

        protected void btn_delete(object sender, EventArgs e)
        {
            try
            {
                Button btn = (Button)sender;
                string id = btn.CommandArgument;
                DatabaseInfo dbConnection = DatabaseInfo.Instance;
                dbConnection.AddInputParameter("t_id", OracleDbType.Varchar2, id, ParameterDirection.Input);
                dbConnection.InsertParameter("delete_teacher", CommandType.StoredProcedure);
                LoadData();
            }
            catch
            {
              
            }
        }
    }
}