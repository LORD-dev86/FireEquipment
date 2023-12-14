using Npgsql;
using System;
using System.Data;
using System.Windows.Forms;

namespace FireEquipment2
{
    static class Administrator
    {
        public static DataTable SelectFunc(string funcName)
        {
            var dt = new DataTable();
            try
            {
                SqlQuery.conn.Open();

                SqlQuery.sql = @"select * from ";
                SqlQuery.sql += funcName;
                SqlQuery.cmd = new NpgsqlCommand(SqlQuery.sql, SqlQuery.conn);

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
        public static void UpdateUI(AddAdminForm addAdmin, int colIndex)
        {
            switch (colIndex)
            {
                default:
                    MessageBox.Show("Неизвестная операция");
                    break;
                case (1):
                    addAdmin.label1.Text = "Номер";
                    addAdmin.label2.Text = "Название";
                    addAdmin.label3.Text = "Объём";
                    addAdmin.label4.Text = "Масса";
                    addAdmin.label5.Text = "Полезная месса";
                    addAdmin.label6.Text = "Описание";

                    addAdmin.textBox6.Multiline = true;

                    break;
                case (2):
                    addAdmin.label1.Text = "Номер";
                    addAdmin.label2.Text = "Название";
                    addAdmin.label3.Text = "Описание";

                    addAdmin.label4.Visible = false;
                    addAdmin.label5.Visible = false;
                    addAdmin.label6.Visible = false;
                   

                    addAdmin.textBox4.Visible = false;
                    addAdmin.textBox5.Visible = false;
                    addAdmin.textBox6.Visible = false;
                    

                    addAdmin.textBox3.Multiline = true;
                    break;
                case (3):
                    addAdmin.label1.Text = "Номер";
                    addAdmin.label2.Text = "Название";
                    addAdmin.label3.Text = "Описание";

                    addAdmin.label4.Visible = false;
                    addAdmin.label5.Visible = false;
                    addAdmin.label6.Visible = false;
                    

                    addAdmin.textBox4.Visible = false;
                    addAdmin.textBox5.Visible = false;
                    addAdmin.textBox6.Visible = false;
                    

                    addAdmin.textBox3.Multiline = true;
                    break;

                case (4):
                    addAdmin.label1.Text = "Номер";
                    addAdmin.label2.Text = "Название";

                    addAdmin.label3.Visible = false;
                    addAdmin.label4.Visible = false;
                    addAdmin.label5.Visible = false;
                    addAdmin.label6.Visible = false;
                    

                    addAdmin.textBox1.Enabled = true;
                    addAdmin.textBox3.Visible = false;
                    addAdmin.textBox4.Visible = false;
                    addAdmin.textBox5.Visible = false;
                    addAdmin.textBox6.Visible = false;
                    
                    break;

                case (5):
                    addAdmin.label1.Text = "Номер";
                    addAdmin.label2.Text = "Отдел";
                    addAdmin.label3.Text = "Описание";

                    addAdmin.label4.Visible = false;
                    addAdmin.label5.Visible = false;
                    addAdmin.label6.Visible = false;
                    

                    addAdmin.textBox4.Visible = false;
                    addAdmin.textBox5.Visible = false;
                    addAdmin.textBox6.Visible = false;
                    
                    break;
            }
        }

        public static int GetLastId(string FuncName)
        {
            var id = 0;

            try
            {
                SqlQuery.conn.Open();
                SqlQuery.sql = @"select count(*) from ";
                SqlQuery.sql += FuncName;

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

        public static void DeleteFunc(int index, int colIndex)
        {
            try
            {
                SqlQuery.conn.Open();

                switch (colIndex)
                {
                    case (1):
                        SqlQuery.sql = "DELETE FROM typeeq WHERE te_id = :_index";
                        break;
                    case (2):
                        SqlQuery.sql = "DELETE FROM Mtypeeq WHERE mt_id = :_index";
                        break;
                    case (3):
                        SqlQuery.sql = "DELETE FROM Checktype WHERE ct_id = :_index";
                        break;
                    case (4):
                        SqlQuery.sql = "DELETE FROM Department WHERE dp_id = :_index";
                        break;
                    case (5):
                        SqlQuery.sql = "DELETE FROM Placement WHERE pl_id = :_index";
                        break;
                }

                SqlQuery.cmd = new NpgsqlCommand(SqlQuery.sql, SqlQuery.conn);
                SqlQuery.cmd.Parameters.AddWithValue("_index", index);
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
