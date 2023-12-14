using System;
using System.Windows.Forms;

namespace FireEquipment2
{
    public partial class AddAdminForm : Form
    {
        public AddAdminForm()
        {
            InitializeComponent();
        }

        public int colIndex;
        public bool isInsert;

        private void AddAdminForm_Load(object sender, EventArgs e)
        {
            SqlQuery.conn = new Npgsql.NpgsqlConnection(SqlQuery.connString);
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            switch (colIndex)
            {
                default:
                    MessageBox.Show("Неизвестная операция");
                    break;
                case (1):
                    if (isInsert)
                    {
                        try
                        {
                            SqlQuery.conn.Open();

                            SqlQuery.sql = @"select * from te_insert(:_te_id, :_te_name::varchar(255), 
                            :_te_size, :_te_weight, :_te_rweight, :_te_desc::text)";

                            SqlQuery.cmd = new Npgsql.NpgsqlCommand(SqlQuery.sql, SqlQuery.conn);

                            SqlQuery.cmd.Parameters.AddWithValue("_te_id", int.Parse(textBox1.Text));
                            SqlQuery.cmd.Parameters.AddWithValue("_te_name", textBox2.Text);
                            SqlQuery.cmd.Parameters.AddWithValue("_te_size", int.Parse(textBox3.Text));
                            SqlQuery.cmd.Parameters.AddWithValue("_te_weight", int.Parse(textBox4.Text));
                            SqlQuery.cmd.Parameters.AddWithValue("_te_rweight", int.Parse(textBox5.Text));
                            SqlQuery.cmd.Parameters.AddWithValue("_te_desc", textBox6.Text);
                            SqlQuery.cmd.ExecuteScalar();

                            SqlQuery.conn.Close();
                        }
                        catch (Exception ex)
                        {   
                            SqlQuery.conn.Close();
                            MessageBox.Show(ex.Message);
                        }
                    }
                    else
                    {
                        try
                        {
                            SqlQuery.conn.Open();

                            SqlQuery.sql = @"select * from te_update(:_te_id, :_te_name::varchar(255), 
                            :_te_size, :_te_weight, :_te_rweight, :_te_desc::text)";

                            SqlQuery.cmd = new Npgsql.NpgsqlCommand(SqlQuery.sql, SqlQuery.conn);

                            SqlQuery.cmd.Parameters.AddWithValue("_te_id", int.Parse(textBox1.Text));
                            SqlQuery.cmd.Parameters.AddWithValue("_te_name", textBox2.Text);
                            SqlQuery.cmd.Parameters.AddWithValue("_te_size", int.Parse(textBox3.Text));
                            SqlQuery.cmd.Parameters.AddWithValue("_te_weight", int.Parse(textBox4.Text));
                            SqlQuery.cmd.Parameters.AddWithValue("_te_rweight", int.Parse(textBox5.Text));
                            SqlQuery.cmd.Parameters.AddWithValue("_te_desc", textBox6.Text);
                            SqlQuery.cmd.ExecuteScalar();

                            SqlQuery.conn.Close();
                        }
                        catch (Exception ex)
                        {
                            SqlQuery.conn.Close();
                            MessageBox.Show(ex.StackTrace);
                        }
                    }
                    break;
                case (2):
                    if (isInsert)
                    {
                        try
                        {
                            SqlQuery.conn.Open();

                            SqlQuery.sql = @"select * from mt_insert(:_mt_id, :_mv_name::varchar(255), 
                                           :_mt_desc::text)";

                            SqlQuery.cmd = new Npgsql.NpgsqlCommand(SqlQuery.sql, SqlQuery.conn);

                            SqlQuery.cmd.Parameters.AddWithValue("_mt_id", int.Parse(textBox1.Text));
                            SqlQuery.cmd.Parameters.AddWithValue("_mt_name", textBox2.Text);
                            SqlQuery.cmd.Parameters.AddWithValue("_mt_desc", textBox3.Text);
                            SqlQuery.cmd.ExecuteScalar();

                            SqlQuery.conn.Close();
                        }
                        catch (Exception ex)
                        {
                            SqlQuery.conn.Close();
                            MessageBox.Show(ex.Message);
                        }
                    }
                    else
                    {
                        try
                        {
                            SqlQuery.conn.Open();

                            SqlQuery.sql = @"select * from mt_update(:_mt_id, :_mt_name::varchar(255), 
                                           :_mt_desc::text)";

                            SqlQuery.cmd = new Npgsql.NpgsqlCommand(SqlQuery.sql, SqlQuery.conn);

                            SqlQuery.cmd.Parameters.AddWithValue("_mt_id", int.Parse(textBox1.Text));
                            SqlQuery.cmd.Parameters.AddWithValue("_mt_name", textBox2.Text);
                            SqlQuery.cmd.Parameters.AddWithValue("_mt_desc", textBox3.Text);
                            SqlQuery.cmd.ExecuteScalar();

                            SqlQuery.conn.Close();
                        }
                        catch (Exception ex)
                        {
                            SqlQuery.conn.Close();
                            MessageBox.Show(ex.Message);
                        }
                    }
                    break;
                case (3):
                    if (isInsert)
                    {
                        try
                        {
                            SqlQuery.conn.Open();

                            SqlQuery.sql = @"select * from ct_insert(:_ct_id, :_ct_name::varchar(255), 
                            :_ct_desc::text)";

                            SqlQuery.cmd = new Npgsql.NpgsqlCommand(SqlQuery.sql, SqlQuery.conn);

                            SqlQuery.cmd.Parameters.AddWithValue("_ct_id", int.Parse(textBox1.Text));
                            SqlQuery.cmd.Parameters.AddWithValue("_ct_name", textBox2.Text);
                            SqlQuery.cmd.Parameters.AddWithValue("_ct_desc", textBox3.Text);
                            SqlQuery.cmd.ExecuteScalar();

                            SqlQuery.conn.Close();
                        }
                        catch (Exception ex)
                        {
                            SqlQuery.conn.Close();
                            MessageBox.Show(ex.Message);
                        }
                    }
                    else
                    {
                        try
                        {
                            SqlQuery.conn.Open();

                            SqlQuery.sql = @"select * from ct_update(:_ct_id, :_ct_name::varchar(255), 
                                           :_ct_desc::text)";

                            SqlQuery.cmd = new Npgsql.NpgsqlCommand(SqlQuery.sql, SqlQuery.conn);

                            SqlQuery.cmd.Parameters.AddWithValue("_ct_id", int.Parse(textBox1.Text));
                            SqlQuery.cmd.Parameters.AddWithValue("_ct_name", textBox2.Text);
                            SqlQuery.cmd.Parameters.AddWithValue("_ct_desc", textBox3.Text);
                            SqlQuery.cmd.ExecuteScalar();

                            SqlQuery.conn.Close();
                        }
                        catch (Exception ex)
                        {
                            SqlQuery.conn.Close();
                            MessageBox.Show(ex.Message);
                        }
                    }
                    break;
                case (4):
                    if (isInsert)
                    {
                        try
                        {
                            SqlQuery.conn.Open();

                            SqlQuery.sql = @"select * from dp_insert(:_dp_id, :_dp_desc::text)";

                            SqlQuery.cmd = new Npgsql.NpgsqlCommand(SqlQuery.sql, SqlQuery.conn);

                            SqlQuery.cmd.Parameters.AddWithValue("_dp_id", int.Parse(textBox1.Text));
                            SqlQuery.cmd.Parameters.AddWithValue("_dp_desc", textBox2.Text);
                            SqlQuery.cmd.ExecuteScalar();

                            SqlQuery.conn.Close();
                        }
                        catch (Exception ex)
                        {
                            SqlQuery.conn.Close();
                            MessageBox.Show(ex.Message);
                        }
                    }
                    else
                    {
                        try
                        {
                            SqlQuery.conn.Open();

                            SqlQuery.sql = @"select * from dp_update(:_dp_id, :_dp_desc::text)";

                            SqlQuery.cmd = new Npgsql.NpgsqlCommand(SqlQuery.sql, SqlQuery.conn);

                            SqlQuery.cmd.Parameters.AddWithValue("_dp_id", int.Parse(textBox1.Text));
                            SqlQuery.cmd.Parameters.AddWithValue("_dp_desc", textBox2.Text);
                            SqlQuery.cmd.ExecuteScalar();

                            SqlQuery.conn.Close();
                        }
                        catch (Exception ex)
                        {
                            SqlQuery.conn.Close();
                            MessageBox.Show(ex.Message);
                        }
                    }
                    break;
                case (5):
                    if (isInsert)
                    {
                        try
                        {
                            SqlQuery.conn.Open();

                            SqlQuery.sql = @"select * from pl_insert(:_pl_id, :_pl_iddep, :_pl_desc::text)";

                            SqlQuery.cmd = new Npgsql.NpgsqlCommand(SqlQuery.sql, SqlQuery.conn);

                            SqlQuery.cmd.Parameters.AddWithValue("_pl_id", int.Parse(textBox1.Text));
                            SqlQuery.cmd.Parameters.AddWithValue("_pl_iddep", int.Parse(textBox2.Text));
                            SqlQuery.cmd.Parameters.AddWithValue("_pl_desc", textBox3.Text);
                            SqlQuery.cmd.ExecuteScalar();

                            SqlQuery.conn.Close();
                        }
                        catch (Exception ex)
                        {
                            SqlQuery.conn.Close();
                            MessageBox.Show(ex.Message);
                        }
                    }
                    else
                    {
                        try
                        {
                            SqlQuery.conn.Open();

                            SqlQuery.sql = @"select * from pl_update(:_pl_id, :_pl_iddep, :_pl_desc::text)";

                            SqlQuery.cmd = new Npgsql.NpgsqlCommand(SqlQuery.sql, SqlQuery.conn);

                            SqlQuery.cmd.Parameters.AddWithValue("_pl_id", int.Parse(textBox1.Text));
                            SqlQuery.cmd.Parameters.AddWithValue("_pl_iddep", int.Parse(textBox2.Text));
                            SqlQuery.cmd.Parameters.AddWithValue("_pl_desc", textBox3.Text);
                            SqlQuery.cmd.ExecuteScalar();

                            SqlQuery.conn.Close();
                        }
                        catch (Exception ex)
                        {
                            SqlQuery.conn.Close();
                            MessageBox.Show(ex.Message);
                        }
                    }
                    break;
            }
            this.Close();
        }
        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
   
    }
}
