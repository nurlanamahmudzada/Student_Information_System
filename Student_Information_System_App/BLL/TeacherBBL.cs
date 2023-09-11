using Oracle.ManagedDataAccess.Client;
using Student_Information_System_App.DB;
using Student_Information_System_App.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Student_Information_System_App.BLL
{
    public class TeacherBBL
    {
        public void AddTeacher(Teacher teacher)
        {
            DatabaseInfo dbConnection = DatabaseInfo.Instance;
            dbConnection.AddInputParameter("name", OracleDbType.Varchar2, teacher.Name, System.Data.ParameterDirection.InputOutput);
            dbConnection.AddInputParameter("surname", OracleDbType.Varchar2, teacher.Surname, System.Data.ParameterDirection.InputOutput);
            dbConnection.AddInputParameter("phoneNumber", OracleDbType.Int32, teacher.PhoneNumber, System.Data.ParameterDirection.InputOutput);
            dbConnection.AddInputParameter("email", OracleDbType.Varchar2, teacher.Email, System.Data.ParameterDirection.InputOutput);
            dbConnection.AddInputParameter("employmentDate", OracleDbType.Date, teacher.BeginDate, System.Data.ParameterDirection.InputOutput);
            dbConnection.AddInputParameter("quitingDate", OracleDbType.Date, teacher.EndDate, System.Data.ParameterDirection.InputOutput);
            dbConnection.AddInputParameter("lessonName", OracleDbType.Varchar2, teacher.LessonName, System.Data.ParameterDirection.Input);
            dbConnection.InsertParameter("insert_teacher", System.Data.CommandType.StoredProcedure);
        }
    }
}