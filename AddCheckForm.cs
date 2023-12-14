using Npgsql;
using System;
using System.Windows.Forms;

namespace FireEquipment2
{
    public partial class AddCheckForm : Form
    {
        public bool isInsert;
        public string _type;

        public AddCheckForm()
        {
            InitializeComponent();
        }

        private void AddCheckForm_Load(object sender, EventArgs e)
        {
            SqlQuery.conn = new NpgsqlConnection(SqlQuery.connString);
            try
            {
                SqlQuery.conn.Open();
                SqlQuery.sql = @"select ct_name from checktype order by ct_id";
                SqlQuery.cmd = new NpgsqlCommand(SqlQuery.sql, SqlQuery.conn);

                SqlQuery.dr = SqlQuery.cmd.ExecuteReader();

                while (SqlQuery.dr.Read())
                {
                    var str = SqlQuery.dr.GetString(0);

                    cbType.Items.Add(str);
                }

                if (isInsert)
                    cbType.SelectedIndex = 0;
                else 
                    cbType.SelectedIndex = cbType.Items.IndexOf(_type);
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
                var CheckDate = DateTime.Parse(tbCheckDate.Text);
                var department = int.Parse(tbDepartment.Text);
                var res = tbResult.Text;
                var desc = tbDesc.Text;

                if (isInsert)
                {
                    CommonFunction.AddCheck(id, type,
                    CheckDate, department, res, desc);
                }
                else
                {
                    CommonFunction.UpdateCheck(id, type,
                    CheckDate, department, res, desc);
                }
                this.Close();
            } catch (Exception)
            {
                MessageBox.Show("Проверьте корректность введенных данных.");
            }
            
           

            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
