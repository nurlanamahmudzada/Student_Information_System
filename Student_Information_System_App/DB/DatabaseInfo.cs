using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Student_Information_System_App.DB
{
    public class DatabaseInfo
    {
        private OracleConnection connection;
        private DatabaseInfo() {
            string connnectionString = "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=orcl)));User Id=student_info_system_user;Password=112233;";
            connection = new OracleConnection(connnectionString);
            connection.Open();
        }
        private static DatabaseInfo instance;
        public static DatabaseInfo Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new DatabaseInfo();
                }
                return instance;
            }
        }

        public OracleCommand WriteQuery(string query, CommandType commandType)
        {           
            OracleCommand command = new OracleCommand(query, connection);
            command.CommandType = commandType;
            return command;
        }
        List<OracleParameter> Parameters = new List<OracleParameter>();
        public void AddInputParameter(string parameterName, OracleDbType oracleDbType, object parameterValue, ParameterDirection parameterDirection)
        {
            OracleParameter parameter = new OracleParameter();
            parameter.ParameterName = parameterName;
            parameter.OracleDbType = oracleDbType;
            parameter.Value = parameterValue;
            parameter.Direction = parameterDirection;
            Parameters.Add(parameter);         
        }

        public void AddOutputParameter(string parameterName, OracleDbType oracleDbType, ParameterDirection parameterDirection)
        {
            OracleParameter parameter = new OracleParameter();
            parameter.ParameterName = parameterName;
            parameter.OracleDbType = oracleDbType;
            parameter.Direction = parameterDirection;
            Parameters.Add(parameter);
        }

        public void AddParemeterToCommand(OracleCommand command)
        {
            command.Parameters.AddRange(Parameters.ToArray()); //addrange ile yoxla eger error varsa
            Parameters.Clear();
        }

        public void InsertParameter(string query, CommandType commandType)
        {
            OracleCommand command = WriteQuery(query, commandType);
            AddParemeterToCommand(command);
            command.ExecuteNonQuery();
        }
        public OracleDataReader GetDataFromDataReader(string query, CommandType commandType)
        {
            OracleCommand command = WriteQuery(query, commandType);
            AddParemeterToCommand(command); 
            OracleDataReader reader = command.ExecuteReader();
            return reader;
        }

        public DataTable GetDataFRomDataTable(string query, CommandType commandType)
        {
            OracleDataReader reader = GetDataFromDataReader(query, commandType);
            DataTable table = new DataTable();
            table.Load(reader);
            return table;
        }

        public void ConnectionClose()
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
        }
    }
}