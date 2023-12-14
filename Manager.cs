using Npgsql;
using System;
using System.Data;
using System.Windows.Forms;

namespace FireEquipment2
{
    static class Manager
    {
        public static DataTable SelectAllData(string postsql)
        {
            var dt = new DataTable();
            try
            {
                SqlQuery.conn.Open();

                SqlQuery.sql = @"select * from eq_select()";
                SqlQuery.sql += postsql;

                SqlQuery.cmd = new NpgsqlCommand(SqlQuery.sql, SqlQuery.conn);

                dt.Load(SqlQuery.cmd.ExecuteReader());

                SqlQuery.conn.Close();
            }
            catch (Exception ex)
            {
                SqlQuery.conn.Close();
                MessageBox.Show(ex.StackTrace);
            }
            return dt;
        }
        public static string GetCheckPath(int department)
        {
            var path = string.Empty;

            try
            {
                SqlQuery.conn.Open();
                SqlQuery.sql = @"SELECT * FROM get_chdoc(:_department)";
                SqlQuery.cmd = new NpgsqlCommand(SqlQuery.sql, SqlQuery.conn);
                SqlQuery.cmd.Parameters.AddWithValue
                    ("_department", department);

                SqlQuery.dr = SqlQuery.cmd.ExecuteReader();

                SqlQuery.dr.Read();
                path = SqlQuery.dr.GetString(0);

                SqlQuery.conn.Close();
            }
            catch (Exception)
            {
                SqlQuery.conn.Close();
            }

            return path;
        }
        public static string GetEqPath(int department)
        {
            var path = string.Empty;

            try
            {
                SqlQuery.conn.Open();
                SqlQuery.sql = @"SELECT * FROM get_eqdoc(:_department)";
                SqlQuery.cmd = new NpgsqlCommand(SqlQuery.sql, SqlQuery.conn);
                SqlQuery.cmd.Parameters.AddWithValue
                    ("_department", department);

                SqlQuery.dr = SqlQuery.cmd.ExecuteReader();

                SqlQuery.dr.Read();
                path = SqlQuery.dr.GetString(0);

                SqlQuery.conn.Close();
            }
            catch (Exception)
            {
                SqlQuery.conn.Close();
            }

            return path;
        }
    }
}
