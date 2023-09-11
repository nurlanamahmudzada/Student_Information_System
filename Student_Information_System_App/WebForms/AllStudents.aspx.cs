using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Principal;
using System.Web;
using System.Web.DynamicData;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
using OfficeOpenXml;
using Oracle.ManagedDataAccess;
using Oracle.ManagedDataAccess.Client;
using Student_Information_System_App.DB;
using Student_Information_System_App.Entity;

namespace Student_Information_System_App.WebForms
{
    public partial class WebForm1 : System.Web.UI.Page
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
            if(GetTotalRows() == 0)
            {
                nextBtn.Enabled = false;
            }
                       
        }

        protected void LoadData()
        {
            int startRow = (CurrentPage - 1) * itemsPerPage + 1; 
            int endRow = startRow + itemsPerPage - 1;
            string viewName = "vw_students";
            string query = $"SELECT row_num, t.* FROM (SELECT ROW_NUMBER() OVER (ORDER BY ID) AS row_num, {viewName}.* FROM vw_students) t WHERE row_num BETWEEN :StartRow AND :EndRow";
            DatabaseInfo dbConnection = DatabaseInfo.Instance;
            dbConnection.AddInputParameter("StartRow", OracleDbType.Int32, startRow, ParameterDirection.Input);
            dbConnection.AddInputParameter("EndRow", OracleDbType.Int32, endRow, ParameterDirection.Input);
            OracleDataReader reader = dbConnection.GetDataFromDataReader(query, CommandType.Text);
            try { 
            rpt_students.DataSource = reader;
            rpt_students.DataBind();           
            }
            catch(Exception ex)
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
            if(CurrentPage == 1)
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
            if(CurrentPage == totalPages)
            {
                nextBtn.Enabled=false;
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
            string viewName = "vw_students";
            string query = $"select count(*) from {viewName}";
            DatabaseInfo dbConnection = DatabaseInfo.Instance;
            OracleCommand cmd = dbConnection.WriteQuery(query, CommandType.Text);
            object result = cmd.ExecuteScalar();
            int resultInt = Convert.ToInt32(result);
            return resultInt;
        }

        protected void btn_delete (object sender, EventArgs e)
        {
            try
            {
                Button btn = (Button)sender;
                string id = btn.CommandArgument;
                DatabaseInfo dbConnection = DatabaseInfo.Instance;
                dbConnection.AddInputParameter("s_id", OracleDbType.Varchar2, id, ParameterDirection.Input);
                dbConnection.InsertParameter("delete_student", CommandType.StoredProcedure);
                LoadData();
            }
            catch
            {

            }
        }

        protected void Btn_export(object sender, EventArgs e)
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("AllStudents");

                int rowIndex = 1;
                worksheet.Cell(rowIndex, 1).Value = "Ad";
                worksheet.Cell(rowIndex, 2).Value = "Soyad";
                worksheet.Cell(rowIndex, 3).Value = "Telefon Nomresi";
                worksheet.Cell(rowIndex, 4).Value = "Email";
                worksheet.Cell(rowIndex, 5).Value = "Giris Bali";
                worksheet.Cell(rowIndex, 6).Value = "Department ID";
                worksheet.Cell(rowIndex, 7).Value = "Giris tarixi";
                worksheet.Cell(rowIndex, 8).Value = "Mezun tarixi";
                var cellRange = worksheet.Range(worksheet.Cell(rowIndex, 1), worksheet.Cell(rowIndex, 8));
                var cellStyle = cellRange.Style;
                cellStyle.Fill.BackgroundColor = XLColor.Blue;
                cellStyle.Font.Bold = true;

                int row = 2;
                foreach (var student in GetStudentList())
                {
                    worksheet.Cell(row, 1).Value = student.Name;
                    worksheet.Cell(row, 2).Value = student.Surname;
                    worksheet.Cell(row, 3).Value = student.PhoneNumber;
                    worksheet.Cell(row, 4).Value = student.Email;
                    worksheet.Cell(row, 5).Value = student.EntrancePoint;
                    worksheet.Cell(row, 6).Value = student.DepartmentId;
                    worksheet.Cell(row, 7).Value = student.BeginDate.ToString();
                    worksheet.Cell(row, 8).Value = student.EndDate.ToString();
                    row++;
                }

                worksheet.Column(1).Width=15;
                worksheet.Column(2).Width=15;
                worksheet.Column(3).Width=17;
                worksheet.Column(4).Width=20;
                worksheet.Column(5).Width=10;
                worksheet.Column(6).Width=15;
                worksheet.Column(7).Width=30;
                worksheet.Column(8).Width=30;



                var range = worksheet.Range(worksheet.Cell(1, 1), worksheet.Cell(GetStudentList().Count + 1, 8));
                var table = range.CreateTable();
                table.Name = "AllStudentsTable";
                table.Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                table.Style.Border.OutsideBorder = XLBorderStyleValues.Thick;
                table.Style.Border.InsideBorder = XLBorderStyleValues.Thin;
                table.Style.Border.TopBorder = XLBorderStyleValues.Thin;
                table.Style.Border.OutsideBorderColor = XLColor.Black;
                table.Style.Border.InsideBorderColor = XLColor.Black;
                table.Style.Border.BottomBorderColor = XLColor.Black;
                table.Style.Border.TopBorderColor = XLColor.Black;
                workbook.SaveAs("D:\\C#Projects\\Student_Information_System\\Excel\\AllStudents.xlsx");
            }
        }
       

        public List<Student> GetStudentList()
        {
            List<Student> allStudents = new List<Student>();
            string viewName = "vw_students";
            string query = $"SELECT * from {viewName}";
            DatabaseInfo dbConnection = DatabaseInfo.Instance;
            OracleDataReader reader = dbConnection.GetDataFromDataReader(query, CommandType.Text);
            try
            {
                while (reader.Read())
                {
                    allStudents.Add(new Student
                    {
                        Id = Convert.ToInt32(reader["ID"]),
                        Name = reader["Name"].ToString(),
                        Surname = reader["Surname"].ToString(),
                        PhoneNumber = reader["PhoneNumber"].ToString(),
                        Email = reader["Email"].ToString(),
                        EntrancePoint = Convert.ToInt32(reader["Entrance Point"]),
                        DepartmentId = Convert.ToInt32(reader["Department Name"]),
                        BeginDate = Convert.ToDateTime(reader["Entry Date"]),
                        EndDate = Convert.ToDateTime(reader["Graduate Date"])
                    });
                }
            }
            catch
            {

            }
            finally
            {
                reader.Close();
            }
            return allStudents;
        }
    }
}