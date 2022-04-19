using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Data.SqlClient;
using System.Collections;
using System.Data;

namespace TTCS_backup_restore
{
    public static class DAO
    {
        public static string connectionString;
        public static SqlConnection con = new SqlConnection();
        public static SqlDataAdapter dataAdapter;
        public static string errstr = "";

        public static string serverName = "NHTRUONG";
        public static string userName = "";
        public static string password = "";
        public static string database = "tempdb";

        public static int connectionDB()
        {
            if (con != null && con.State == ConnectionState.Open) con.Close();
            try
            {
                connectionString = $"Data Source = {serverName}; Initial Catalog = {database};Persist Security Info=True; User ID = {userName}; password = {password}";
                con.ConnectionString = connectionString;
                con.Open();
                return 0;
            }
            catch
            {
                return 1;
            }
        }

        public static SqlDataReader execSqlDataReader(string command, string connectionString)
        {
            if (con != null && con.State == ConnectionState.Open) con.Close();
            con = new SqlConnection(connectionString);
            SqlCommand sqlcmd = new SqlCommand(command, con);
            sqlcmd.CommandType = CommandType.Text;
            sqlcmd.CommandTimeout = 300;
            if (con.State == ConnectionState.Closed) con.Open();
            try
            {
                return sqlcmd.ExecuteReader();
            }
            catch(SqlException ex)
            {
                errstr = ex.Message.ToString();
                con.Close();
                return null;
            }
        }
        public static DataTable execSqlDataTable(string command, string connectionString)
        {
            if (con != null && con.State == ConnectionState.Open) con.Close();
            DataTable dt = new DataTable();
            con = new SqlConnection(connectionString);
            SqlCommand sqlcmd = new SqlCommand(command, con);
            sqlcmd.CommandType = CommandType.Text;
            dataAdapter = new SqlDataAdapter(sqlcmd);
            con.Close();
            dataAdapter.Fill(dt);
            return dt;
        }

        public static int execSqlNonQuery(string command, string connectionString)
        {
            if (con != null && con.State == ConnectionState.Open) con.Close();
            con = new SqlConnection(connectionString);
            SqlCommand sqlcmd = new SqlCommand(command, con);
            sqlcmd.CommandType = CommandType.Text;
            sqlcmd.CommandTimeout = 600;
            if (con.State == ConnectionState.Closed) con.Open();
            try
            {
                int err = sqlcmd.ExecuteNonQuery();
                con.Close();
                return 0;
            }
            catch (SqlException ex)
            {
                errstr = ex.Message.ToString();
                return ex.State;
            }
        }
    }
}
