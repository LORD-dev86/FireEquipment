using Npgsql;
using System;
using System.Data;
using System.Windows.Forms;


namespace FireEquipment2
{
    static class CommonFunction
    {
        //Функции для работы со списком проверок
        public static DataTable SelectChechData(int department)
        {
            var dt = new DataTable();

            try
            {
                
                SqlQuery.conn.Open();

                SqlQuery.sql = @"select * from ch_select() 
                                 where Подразделение = :_department";

                SqlQuery.cmd = new NpgsqlCommand(SqlQuery.sql, SqlQuery.conn);
                SqlQuery.cmd.Parameters.AddWithValue
                    ("_department", department);
                dt.Load(SqlQuery.cmd.ExecuteReader());

                SqlQuery.conn.Close();
            }
            catch (Exception ex)
            {
                SqlQuery.conn.Close();
                MessageBox.Show(ex.Message);
            }
            return dt;
        }

        public static int GetLastIdCheck()
        {
            var id = 0;

            try
            {
                SqlQuery.conn.Open();
                SqlQuery.sql = @"SELECT count(ch_id) FROM Checking WHERE ch_id != 0";

                SqlQuery.cmd = new NpgsqlCommand(SqlQuery.sql, SqlQuery.conn);
                SqlQuery.dr = SqlQuery.cmd.ExecuteReader();

                SqlQuery.dr.Read();
                id = SqlQuery.dr.GetInt32(0);

                SqlQuery.conn.Close();
            }
            catch (Exception ex)
            {
                SqlQuery.conn.Close();
                MessageBox.Show(ex.Message);
            }

            return id;
        }

        public static void AddCheck(int id, string type,
            DateTime checkDate, int department,
            string result, string description)
        {
            try
            {
                SqlQuery.conn.Open();
                SqlQuery.sql = @"select * from ch_insert(
                :_ch_id, :_ch_type::varchar(255), 
                :_ch_checkdate::date, :_ch_department, 
                :_ch_checkresult::text,
                :_ch_desc::text)";

                SqlQuery.cmd = 
                new NpgsqlCommand(SqlQuery.sql, SqlQuery.conn);
                SqlQuery.cmd.Parameters.AddWithValue
                    ("_ch_id", id);
                SqlQuery.cmd.Parameters.AddWithValue
                    ("_ch_type", type);

                SqlQuery.cmd.Parameters.AddWithValue
                    ("_ch_checkdate",checkDate);
                SqlQuery.cmd.Parameters.AddWithValue
                    ("_ch_department",
                   department);
                SqlQuery.cmd.Parameters.AddWithValue
                    ("_ch_checkresult",
                    result);
                SqlQuery.cmd.Parameters.AddWithValue("_ch_desc",
                    description);
                SqlQuery.cmd.ExecuteScalar();

                SqlQuery.conn.Close();
            }
            catch (Exception ex)
            {
                SqlQuery.conn.Close();
                MessageBox.Show(ex.Message);
            }
        }

        public static void UpdateCheck(int id, string type,
            DateTime checkDate, int department,
            string result, string description)
        {
            try
            {
                SqlQuery.conn.Open();
                SqlQuery.sql = @"select * from ch_update(
                :_ch_id, :_ch_type::varchar(255), 
                :_ch_checkdate::date, :_ch_department, 
                :_ch_checkresult::text,
                :_ch_desc::text)";

                SqlQuery.cmd = new NpgsqlCommand(SqlQuery.sql, SqlQuery.conn);
                SqlQuery.cmd.Parameters.AddWithValue
                    ("_ch_id", id);
                SqlQuery.cmd.Parameters.AddWithValue
                    ("_ch_type", type);

                SqlQuery.cmd.Parameters.AddWithValue
                    ("_ch_checkdate", checkDate);
                SqlQuery.cmd.Parameters.AddWithValue
                    ("_ch_department",
                   department);
                SqlQuery.cmd.Parameters.AddWithValue
                    ("_ch_checkresult", result);
                SqlQuery.cmd.Parameters.AddWithValue
                    ("_ch_desc", description);
                SqlQuery.cmd.ExecuteScalar();

                SqlQuery.conn.Close();
            }
            catch (Exception ex)
            {
                SqlQuery.conn.Close();
                MessageBox.Show(ex.Message);
            }
        }


        public static void ClearDgv(DataGridView dataGridView)
        {
            while (dataGridView.Rows.Count > 1)
                for (int i = 0; i < dataGridView.Rows.Count - 1; i++)
                    dataGridView.Rows.Remove(dataGridView.Rows[i]);
        }

        // Функции для работы со списком
        // противопожарного оборудования
        public static int GetLastIdEq()
        {
            var id = 0;

            try
            {
                SqlQuery.conn.Open();
                SqlQuery.sql = @"SELECT count(eq_id) FROM Equipment WHERE eq_id != 0";

                SqlQuery.cmd = 
                    new NpgsqlCommand(SqlQuery.sql, SqlQuery.conn);
                SqlQuery.dr = SqlQuery.cmd.ExecuteReader();

                SqlQuery.dr.Read();
                id = SqlQuery.dr.GetInt32(0);

                SqlQuery.conn.Close();
            }
            catch (Exception ex)
            {
                SqlQuery.conn.Close();
                MessageBox.Show(ex.Message);
            }

            return id;
        }

        public static DataTable SelectDataArg(string postsql, int department)
        {
            var dt = new DataTable();
            try
            {
                SqlQuery.conn.Open();
                SqlQuery.sql = @"select * from eq_select() where Подразделение = :_department";
                SqlQuery.sql += postsql;
                SqlQuery.cmd = new NpgsqlCommand(SqlQuery.sql, SqlQuery.conn);
                SqlQuery.cmd.Parameters.AddWithValue("_department", department);

                dt.Load(SqlQuery.cmd.ExecuteReader());

                SqlQuery.conn.Close();
            }
            catch (Exception ex)
            {
                SqlQuery.conn.Close();
                MessageBox.Show(ex.Message);
            }
            return dt;
        }

        public static void AddEq(int id, string type, string mtype,
            string releaser, DateTime releaseDate, DateTime checkDate,
            DateTime bCheckDate, DateTime reloadDate,
            DateTime bReloadDate, int department, string placement, bool mark)
        {
            try
            {
                SqlQuery.conn.Open();

                SqlQuery.sql = @"select * from eq_insert(:_eq_id, :_eq_type::varchar(255), 
                        :_eq_mtype::varchar(255), :_eq_releaser::varchar(255), :_eq_releasedate::date,
                        :_eq_checkdate::date, :_eq_begincheckdate::date, :_eq_reloaddate::date, 
                        :_eq_beginreloaddate::date, :_eq_department, :_eq_placement, :_eq_mark)";

                SqlQuery.cmd = new NpgsqlCommand(SqlQuery.sql, SqlQuery.conn);
                SqlQuery.cmd.Parameters.AddWithValue("_eq_id", id);
                SqlQuery.cmd.Parameters.AddWithValue("_eq_type", type);
                SqlQuery.cmd.Parameters.AddWithValue("_eq_mtype", mtype);
                SqlQuery.cmd.Parameters.AddWithValue("_eq_releaser", releaser);
                SqlQuery.cmd.Parameters.AddWithValue("_eq_releasedate", releaseDate);
                SqlQuery.cmd.Parameters.AddWithValue("_eq_checkdate", checkDate);
                SqlQuery.cmd.Parameters.AddWithValue("_eq_begincheckdate", bCheckDate);
                SqlQuery.cmd.Parameters.AddWithValue("_eq_reloaddate", reloadDate);
                SqlQuery.cmd.Parameters.AddWithValue("_eq_beginreloaddate", bReloadDate);
                SqlQuery.cmd.Parameters.AddWithValue("_eq_department", department);
                SqlQuery.cmd.Parameters.AddWithValue("_eq_placement", placement);
                SqlQuery.cmd.Parameters.AddWithValue("_eq_mark", mark);
                SqlQuery.cmd.ExecuteScalar();

                SqlQuery.conn.Close();

            }
            catch (Exception ex)
            {
                SqlQuery.conn.Close();
                MessageBox.Show(ex.Message);
            }
        }
            public static void UpdateEq(int id, string type, string mtype,
            string releaser, DateTime releaseDate, DateTime checkDate,
            DateTime bCheckDate, DateTime reloadDate,
            DateTime bReloadDate, int department, string placement, bool mark)
            {
                try
                {
                    SqlQuery.conn.Open();

                    SqlQuery.sql = @"select * from eq_update(:_eq_id, :_eq_type::varchar(255), 
                        :_eq_mtype::varchar(255), :_eq_releaser::varchar(255), :_eq_releasedate::date,
                        :_eq_checkdate::date, :_eq_begincheckdate::date, :_eq_reloaddate::date, 
                        :_eq_beginreloaddate::date, :_eq_department, :_eq_placement, :_eq_mark)";

                    SqlQuery.cmd = new NpgsqlCommand(SqlQuery.sql, SqlQuery.conn);
                    SqlQuery.cmd.Parameters.AddWithValue("_eq_id", id);
                    SqlQuery.cmd.Parameters.AddWithValue("_eq_type", type);
                    SqlQuery.cmd.Parameters.AddWithValue("_eq_mtype", mtype);
                    SqlQuery.cmd.Parameters.AddWithValue("_eq_releaser", releaser);
                    SqlQuery.cmd.Parameters.AddWithValue("_eq_releasedate", releaseDate);
                    SqlQuery.cmd.Parameters.AddWithValue("_eq_checkdate", checkDate);
                    SqlQuery.cmd.Parameters.AddWithValue("_eq_begincheckdate", bCheckDate);
                    SqlQuery.cmd.Parameters.AddWithValue("_eq_reloaddate", reloadDate);
                    SqlQuery.cmd.Parameters.AddWithValue("_eq_beginreloaddate", bReloadDate);
                    SqlQuery.cmd.Parameters.AddWithValue("_eq_department", department);
                    SqlQuery.cmd.Parameters.AddWithValue("_eq_placement", placement);
                    SqlQuery.cmd.Parameters.AddWithValue("_eq_mark", mark);
                    SqlQuery.cmd.ExecuteScalar();

                    SqlQuery.conn.Close();

                }
                catch (Exception ex)
                {
                    SqlQuery.conn.Close();
                    MessageBox.Show(ex.Message);
                }
            }
    }
}
