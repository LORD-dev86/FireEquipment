using Npgsql;
using System;
using System.Windows.Forms;

namespace FireEquipment2
{
    public partial class AddForm : Form
    {

        public AddForm()
        {
            InitializeComponent();
        }
        
        public bool isInsert;
        public string _type, _mtype, _place;

        private void AddForm_Load(object sender, EventArgs e)
        {
            SqlQuery.conn = new NpgsqlConnection(SqlQuery.connString);
            try
            {
                SqlQuery.conn.Open();
                SqlQuery.sql = @"select te_name from typeeq order by te_id";
                SqlQuery.cmd = new NpgsqlCommand(SqlQuery.sql, SqlQuery.conn);

                SqlQuery.dr = SqlQuery.cmd.ExecuteReader();

                while (SqlQuery.dr.Read())
                {
                    var str = SqlQuery.dr.GetString(0);
                    cbType.Items.Add(str);
                }
                SqlQuery.conn.Close();

                SqlQuery.conn.Open();
                SqlQuery.sql = @"select mt_name from mtypeeq order by mt_id";
                SqlQuery.cmd = new NpgsqlCommand(SqlQuery.sql, SqlQuery.conn);

                SqlQuery.dr = SqlQuery.cmd.ExecuteReader();

                while (SqlQuery.dr.Read())
                {
                    var str = SqlQuery.dr.GetString(0);
                    cbMtype.Items.Add(str);
                }
                SqlQuery.conn.Close();

                SqlQuery.conn.Open();
                SqlQuery.sql = @"select pl_desc from placement where pl_iddep = :_pl_iddep order by pl_id";
                SqlQuery.cmd = new NpgsqlCommand(SqlQuery.sql, SqlQuery.conn);
                SqlQuery.cmd.Parameters.AddWithValue("_pl_iddep", int.Parse(tbDepartment.Text));

                SqlQuery.dr = SqlQuery.cmd.ExecuteReader();

                while (SqlQuery.dr.Read())
                {
                    var str = SqlQuery.dr.GetString(0);
                    cbPlacement.Items.Add(str);
                }
                SqlQuery.conn.Close();

                if (isInsert) {
                    cbType.SelectedIndex = 0;
                    cbMtype.SelectedIndex = 0;
                    cbPlacement.SelectedIndex = 0;
                } else {
                    cbType.SelectedIndex = cbType.Items.IndexOf(_type);
                    cbMtype.SelectedIndex = cbMtype.Items.IndexOf(_mtype);
                    cbPlacement.SelectedIndex = cbPlacement.Items.IndexOf(_place);
                }
                    
                SqlQuery.conn.Close();
            }
            catch (Exception ex)
            {
                SqlQuery.conn.Close();
                MessageBox.Show(ex.Message);
            }
            
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                var id = int.Parse(tbId.Text);
                var type = cbType.SelectedItem.ToString();
                var mtype = cbMtype.SelectedItem.ToString();
                var releaser = tbReleaser.Text;
                var releaseDate = DateTime.Parse(tbReleaseDate.Text);
                var checkDate = DateTime.Parse(tbCheckDate.Text);
                var bCheckDate = DateTime.Parse(tbBCheckDate.Text);
                var reloadDate = DateTime.Parse(tbReloadDate.Text);
                var bReloadDate = DateTime.Parse(tbBReloadDate.Text);
                var department = int.Parse(tbDepartment.Text);
                var placement = cbPlacement.SelectedItem.ToString();
                var mark = cbMark.CheckState == CheckState.Checked;

                if (isInsert)
                {
                    CommonFunction.AddEq(id, type, mtype, releaser,
                        releaseDate, checkDate, bCheckDate, reloadDate,
                        bReloadDate, department, placement, mark);
                }
                else
                {
                    CommonFunction.UpdateEq(id, type, mtype, releaser,
                        releaseDate, checkDate, bCheckDate, reloadDate,
                        bReloadDate, department, placement, mark);
                }
                this.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Проверьте корректность введенных данных.");
            }

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
