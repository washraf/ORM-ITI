using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Helpers
{
    public class SqlHelpers
    {
        public static SqlDataReader GetRow(SqlConnection connection, string command, params SqlParameter[] parameters)
        {
            SqlCommand cmd = new SqlCommand(command);
            cmd.Parameters.AddRange(parameters);
            cmd.Connection = connection;
            SqlDataReader r = cmd.ExecuteReader();
            if (r.HasRows)
            {
                r.Read();
                return r;
            }
            else
            {
                return null;
            }
        }

        public static DataTable GetDataTable(SqlConnection connection, string command, List<SqlParameter> parameters = null)
        {
            SqlCommand cmd = new SqlCommand(command);
            if (parameters != null)
                cmd.Parameters.AddRange(parameters.ToArray());
            cmd.Connection = connection;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public static int Insert(SqlConnection connection, string command, List<SqlParameter> parameters)
        {
            SqlCommand cmd = new SqlCommand(command);
            cmd.Parameters.AddRange(parameters.ToArray());
            cmd.Connection = connection;
            return cmd.ExecuteNonQuery();
        }

        public static int Update(SqlConnection connection, string command, List<SqlParameter> parameters)
        {
            SqlCommand cmd = new SqlCommand(command);
            cmd.Parameters.AddRange(parameters.ToArray());
            cmd.Connection = connection;
            return cmd.ExecuteNonQuery();
        }
    }
}
