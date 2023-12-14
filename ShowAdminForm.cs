using Npgsql;
using System;
using System.Data;
using System.Windows.Forms;

namespace FireEquipment2
{
    public partial class ShowAdminForm : Form
    {
        public ShowAdminForm()
        {
            InitializeComponent();
        }

        public int colIndex;
        public string FuncName;
        private int CurId;

        private void ShowAdminForm_Load(object sender, EventArgs e)
        {
            SqlQuery.conn = new NpgsqlConnection(SqlQuery.connString);

            switch (colIndex)
            {
                case (1):
                    this.Text += " типов объектов.";
                    FuncName = "te_select()";
                    break;
                case (2):
                    this.Text += " подтипов объектов.";
                    FuncName = "mt_select()";
                    break;
                case (3):
                    this.Text += " типов проверок.";
                    FuncName = "ct_select()";
                    break;
                case (4):
                    this.Text += " отделов расположения.";
                    FuncName = "dp_select()";
                    break;
                case (5):
                    this.Text += " мест расположения.";
                    FuncName = "pl_select()";
                    break;
            }

            dgvAdmin.DataSource = Administrator.SelectFunc(FuncName);

            CurId = Administrator.GetLastId(FuncName) + 1;
        }
        

        private void ShowAdminForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainAdminForm mainAdmin = new MainAdminForm();
            mainAdmin.Show();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            AddAdminForm addAdmin = new AddAdminForm
            {
                colIndex = this.colIndex,
                isInsert = true,
            };

            addAdmin.textBox1.Text = CurId.ToString();

            Administrator.UpdateUI(addAdmin, colIndex);

            addAdmin.ShowDialog();
            CurId = Administrator.GetLastId(FuncName) + 1;
            
            CommonFunction.ClearDgv(dgvAdmin);
            dgvAdmin.DataSource = Administrator.SelectFunc(FuncName);
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            var index = dgvAdmin.CurrentCell.RowIndex;

            AddAdminForm addAdmin = new AddAdminForm
            {
                colIndex = this.colIndex,
                isInsert = false,
            };

            Administrator.UpdateUI(addAdmin, colIndex);

            try
            {
                switch (colIndex)
                {
                    default:
                        MessageBox.Show("Неизвестная операция");
                        break;
                    case (1):
                        addAdmin.textBox1.Text = dgvAdmin[0, index].Value.ToString();
                        addAdmin.textBox2.Text = dgvAdmin[1, index].Value.ToString();
                        addAdmin.textBox3.Text = dgvAdmin[2, index].Value.ToString();
                        addAdmin.textBox4.Text = dgvAdmin[3, index].Value.ToString();
                        addAdmin.textBox5.Text = dgvAdmin[4, index].Value.ToString();
                        addAdmin.textBox6.Text = dgvAdmin[5, index].Value.ToString();
                        break;
                    case (2):
                        addAdmin.textBox1.Text = dgvAdmin[0, index].Value.ToString();
                        addAdmin.textBox2.Text = dgvAdmin[1, index].Value.ToString();
                        addAdmin.textBox3.Text = dgvAdmin[2, index].Value.ToString();
                        break;
                    case (3):
                        addAdmin.textBox1.Text = dgvAdmin[0, index].Value.ToString();
                        addAdmin.textBox2.Text = dgvAdmin[1, index].Value.ToString();
                        addAdmin.textBox3.Text = dgvAdmin[2, index].Value.ToString();
                        break;
                    case (4):
                        addAdmin.textBox1.Text = dgvAdmin[0, index].Value.ToString();
                        addAdmin.textBox2.Text = dgvAdmin[1, index].Value.ToString();
                        break;
                    case (5):
                        addAdmin.textBox1.Text = dgvAdmin[0, index].Value.ToString();
                        addAdmin.textBox2.Text = dgvAdmin[1, index].Value.ToString();
                        addAdmin.textBox3.Text = dgvAdmin[2, index].Value.ToString();
                        break;
                    
                }
                addAdmin.ShowDialog();
                
                CommonFunction.ClearDgv(dgvAdmin);
                dgvAdmin.DataSource = Administrator.SelectFunc(FuncName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var index = dgvAdmin.CurrentCell.RowIndex;
            var number = int.Parse(dgvAdmin[0, index].Value.ToString());
            
            Administrator.DeleteFunc(number, colIndex);

            CommonFunction.ClearDgv(dgvAdmin);
            dgvAdmin.DataSource = Administrator.SelectFunc(FuncName);
            CurId = Administrator.GetLastId(FuncName);
        }
    }
}
