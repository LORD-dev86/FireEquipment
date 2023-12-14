using System;
using System.Windows.Forms;
using Npgsql;

namespace FireEquipment2
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }


        private void BtnEnter_Click(object sender, EventArgs e)
        {
            SqlQuery.conn = new NpgsqlConnection(SqlQuery.connString);
            try
            {
                var login = tbLogin.Text;
                var pass = tbPass.Text;

                var department = int.Parse(login.Substring(0, 3));

                if (department == 0)
                {
                    MainAdminForm mainAdmin = new MainAdminForm();
                    mainAdmin.Show();
                    this.Hide();
                    return;
                }

                SqlQuery.conn.Open();

                SqlQuery.sql = @"select * from department where dp_id = :_dp_id";
                SqlQuery.cmd = new NpgsqlCommand(SqlQuery.sql, SqlQuery.conn);

                SqlQuery.cmd.Parameters.AddWithValue("_dp_id", department);
                SqlQuery.dr = SqlQuery.cmd.ExecuteReader();

                if (!SqlQuery.dr.Read())
                {
                    MessageBox.Show("Неверный логин или пароль");
                    return;
                }

                var name = SqlQuery.dr.GetInt32(0);
                var desc = SqlQuery.dr.GetString(1);

                SqlQuery.conn.Close();

                if (department == 4)
                {
                    MainManagerForm mainManager = new MainManagerForm();
                    mainManager.Show();
                    this.Hide();
                }
                else
                {
                    MainUserForm mainUser = new MainUserForm
                    {
                        department = name,
                        Desc = desc,
                    };
                    mainUser.Show();
                    this.Hide();
                }
            }
            catch (Exception ex)
            {
                SqlQuery.conn.Close();
                MessageBox.Show(ex.Message);
            }
        }

        private void LoginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            tbLogin.Select();
        }
    }
}
