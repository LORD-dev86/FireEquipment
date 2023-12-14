using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace FireEquipment2
{
    public partial class MainUserForm : Form
    {
        public MainUserForm()
        {
            InitializeComponent();
        }

        public int department;
        public string Desc;

        private List<string> postsql = new List<string>();

        private void MainUserForm_Load(object sender, EventArgs e)
        {
            lName.Text += department.ToString();
            lDesc.Text = Desc;

            postsql.Add(" and \"Следующая проверка\" <= now()");
            postsql.Add(" and \"Следующая проверка\" <= now() + interval '3 days' " +
                         "and \"Следующая проверка\" > now()");
            postsql.Add(" and \"Следующая проверка\" <= now() + interval '7 days' " +
                            "and \"Следующая проверка\" > now() + interval '3 days'");
            postsql.Add("");

            SqlQuery.conn = new NpgsqlConnection(SqlQuery.connString);

            try
            {   
                var countList = new List<int>(); 
                for (int i = 0; i < 4; i++)
                {
                    SqlQuery.conn.Open();

                    SqlQuery.sql = @"select count (*) from eq_select() 
                        where Подразделение = :_department" + postsql[i];

                    SqlQuery.cmd = new NpgsqlCommand(SqlQuery.sql, SqlQuery.conn);
                    SqlQuery.cmd.Parameters.AddWithValue("_department", department);

                    SqlQuery.dr = SqlQuery.cmd.ExecuteReader();
                    SqlQuery.dr.Read();
                    countList.Add (SqlQuery.dr.GetInt32(0));

                    SqlQuery.conn.Close();
                }

                NowCheck.Text += " (" + countList[0] + ")";
                ThreeCheck.Text += " (" + countList[1] + ")";
                SevenCheck.Text += " (" + countList[2] + ")";
                AllEq.Text += " (" + countList[3] + ")";
            }
            catch (Exception ex)
            {
                SqlQuery.conn.Close();
                MessageBox.Show(ex.Message);
            }
        }


        private void NowCheck_Click(object sender, EventArgs e)
        {
            ShowForm f2 = new ShowForm
            {
                colIndex = 1,
                curDepartment = department,
                isManager = false,
                desc = Desc,
            };
            this.Hide(); f2.Show();
        }

        private void ThreeCheck_Click(object sender, EventArgs e)
        {
            ShowForm f2 = new ShowForm
            {
                colIndex = 2,
                curDepartment = department,
                isManager = false,
                desc = Desc,
            };
            this.Hide(); f2.Show();
        }

        private void SevenCheck_Click(object sender, EventArgs e)
        {
            ShowForm f2 = new ShowForm
            {
                colIndex = 3,
                curDepartment = department,
                isManager = false,
                desc = Desc,
            };
            this.Hide(); f2.Show();
        }

        private void AllEq_Click(object sender, EventArgs e)
        {
            ShowForm f2 = new ShowForm
            {
                colIndex = 4,
                curDepartment = department,
                isManager = false,
                desc = Desc,
            };
            this.Hide(); f2.Show();
        }
        private void MainUserForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            LoginForm login = new LoginForm();
            login.Show();
        }

        private void Checking_Click(object sender, EventArgs e)
        {
            ShowCheckForm f2 = new ShowCheckForm
            {
                curDepartment = department,
                isManager = false,
                desc = Desc,
            };
            this.Hide(); f2.Show();
        }
    }
}
