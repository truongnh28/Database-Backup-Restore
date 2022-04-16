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
            SqlDataReader ans;
            con = new SqlConnection(connectionString);
            SqlCommand sqlcmd = new SqlCommand(command, con);
            sqlcmd.CommandType = CommandType.Text;
            sqlcmd.CommandTimeout = 300;
            if (con.State == ConnectionState.Closed) con.Open();
            try
            {
                ans = sqlcmd.ExecuteReader();
                return ans;
            }
            catch
            {
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
                return ex.State;
            }
        }
        //public static bool connectionDB(string serverName, string userName, string password)
        //{
        //    connectionString = "server=" + serverName;
        //    connectionString += ";uid=" + userName;
        //    connectionString += ";pwd=" + password;
        //    con = new SqlConnection();
        //    command = new SqlCommand();
        //    try
        //    {
        //        con.ConnectionString = connectionString;
        //        con.Open();
        //        command.Connection = con;
        //        con.Close();
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        return false;
        //    }
        //}

        //public static void taoDevice(string serverName)
        //{
        //    con.Open();
        //    string devicePath = $"D:\\TTCS_BACKUP\\DEVICE_{serverName}.bak";
        //    string query = $"EXEC SP_ADDUMPDEVICE 'DISK', 'DEVICE_{serverName}', '{devicePath}'";
        //    command.CommandText = query;
        //    command.ExecuteNonQuery();
        //    con.Close();
        //}
        //public static void phucHoi(string nameDB, bool isCheck, int position)
        //{
        //    con.Open();
        //    // Đóng kết nối của chính ta
        //    //if (con != null && con.State == ConnectionState.Open) con.Close();
        //    string query = $"ALTER DATABASE {nameDB} SET SINGLE_USER WITH ROLLBACK IMMEDIATE USE tempdb";
        //    command.CommandText = query;
        //    command.ExecuteNonQuery();
        //    //query += "";
        //    //command.CommandText = query;
        //    //command.ExecuteNonQuery();
        //    if (!isCheck)
        //    {
        //        query += $"RESTORE DATABASE {nameDB} FROM DEVICE_{nameDB} WITH FILE = {position.ToString()}, REPLACE ALTER DATABASE {nameDB} SET MULTI_USER";
        //        command.CommandText = query;
        //        command.ExecuteNonQuery();
        //        con.Close();
        //    }
        //    else
        //    {
        //        // thời gian sao lưu tối thiểu 3p
        //    }
        //}
    }
}
