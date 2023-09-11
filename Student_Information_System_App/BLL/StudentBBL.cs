using Microsoft.Ajax.Utilities;
using Oracle.ManagedDataAccess.Client;
using Student_Information_System_App.DB;
using Student_Information_System_App.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;


namespace Student_Information_System_App.BLL
{
    public class StudentBBL
    {
        public void AddStudent(Student student)
        {           
                DatabaseInfo dbConnection = DatabaseInfo.Instance;
                dbConnection.AddInputParameter("name", OracleDbType.Varchar2, student.Name, System.Data.ParameterDirection.Input);
                dbConnection.AddInputParameter("surname", OracleDbType.Varchar2, student.Surname, System.Data.ParameterDirection.Input);
                dbConnection.AddInputParameter("phone", OracleDbType.Int32, student.PhoneNumber, System.Data.ParameterDirection.Input);
                dbConnection.AddInputParameter("email", OracleDbType.Varchar2, student.Email, System.Data.ParameterDirection.Input);
                dbConnection.AddInputParameter("entrance_point", OracleDbType.Int32, student.EntrancePoint, System.Data.ParameterDirection.Input);
                dbConnection.AddInputParameter("dept_id", OracleDbType.Int32, student.DepartmentId, System.Data.ParameterDirection.Input);
                dbConnection.AddInputParameter("entry_date", OracleDbType.Date, student.BeginDate, System.Data.ParameterDirection.Input);
                dbConnection.AddInputParameter("graduate_date", OracleDbType.Date, student.EndDate, System.Data.ParameterDirection.Input);
                dbConnection.InsertParameter("insert_student", CommandType.StoredProcedure);              
        } 
    }
}