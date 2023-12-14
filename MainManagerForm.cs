using System;
using Npgsql;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace FireEquipment2
{
    public partial class MainManagerForm : Form
    {
        public MainManagerForm()
        {
            InitializeComponent();
        }

        private List<Button> NowBtnList = new List<Button>();
        private List<Button> ThreeBtnList = new List<Button>();
        private List<Button> SevenBtnList = new List<Button>();
        private List<Button> AllBtnList = new List<Button>();
        private List<Button> CheckBtnList = new List<Button>();

        private List<int> NumbList = new List<int>();
        private List<string> DescList = new List<string>();
        private List<string> postsql = new List<string>();

        private void Form1_Load(object sender, EventArgs e)
        {
            SqlQuery.conn = new NpgsqlConnection(SqlQuery.connString);
            var conn2 = new NpgsqlConnection(SqlQuery.connString);

            postsql.Add(" and \"Следующая проверка\" <= now()");
            postsql.Add(" and \"Следующая проверка\" <= now() + interval '3 days'" +
                         "and \"Следующая проверка\" > now()");
            postsql.Add(" and \"Следующая проверка\" <= now() + interval '7 days'" +
                            "and \"Следующая проверка\" > now() + interval '3 days'");
            postsql.Add("");

            //make manager interface
            try
            {
                SqlQuery.conn.Open();

                SqlQuery.sql = @"select * from department order by dp_id";
                SqlQuery.cmd = new NpgsqlCommand(SqlQuery.sql, SqlQuery.conn);
                SqlQuery.dr = SqlQuery.cmd.ExecuteReader();

                var count = 0;

                var locX = 15;
                var locY = 60;

                var lnSize = new Size(120, 15);
                var ldSize = new Size(300, 15);
                var btnSize = new Size(150, 30);

                var beginText = "Подразделение №";

                while (SqlQuery.dr.Read())
                {
                    NumbList.Add(SqlQuery.dr.GetInt32(0));
                    DescList.Add(SqlQuery.dr.GetString(1));

                    var lName = new Label()
                    {
                        Location = new Point(locX + 235, locY),
                        Text = beginText + NumbList[count].ToString(),
                        Size = lnSize,
                    };
                    Controls.Add(lName);

                    var locXdesc = locX + lName.Bounds.Width + 255;

                    var lDesc = new Label()
                    {
                        Location = new Point(locXdesc, locY),
                        Text = DescList[count],
                        Size = ldSize,
                    };
                    Controls.Add(lDesc);

                    locY += 20;

                    var countList = new List<int>();

                    for (int i = 0; i < 4; i++)
                    {
                        conn2.Open();

                        var sql2 = @"select count (*) from eq_select() 
                        where Подразделение = :_department" + postsql[i];

                        var cmd2 = new NpgsqlCommand(sql2, conn2);
                        cmd2.Parameters.AddWithValue("_department", NumbList[count]);

                        var dr2 = cmd2.ExecuteReader();
                        dr2.Read();
                        countList.Add(dr2.GetInt32(0));

                        conn2.Close();
                    }

                    var locXbtn = locX;
                    var nowCheck = new Button()
                    {
                        Location = new Point(locXbtn, locY),
                        Text = "Требуют проверки" + " (" + countList[0] + ")",
                        Size = btnSize,
                    };
                    nowCheck.Click += NowCheck_Click;

                    Controls.Add(nowCheck);
                    NowBtnList.Add(nowCheck);

                    locXbtn += 170;
                    var threeCheck = new Button()
                    {
                        Location = new Point(locXbtn, locY),
                        Text = "Проверка через 3 дня" + " (" + countList[1] + ")",
                        Size = btnSize,
                    };
                    threeCheck.Click += ThreeCheck_Click;

                    Controls.Add(threeCheck);
                    ThreeBtnList.Add(threeCheck);

                    locXbtn += 170;
                    var sevenCheck = new Button()
                    {
                        Location = new Point(locXbtn, locY),
                        Text = "Проверка через 7 дней" + " (" + countList[2] + ")",
                        Size = btnSize,
                    };
                    sevenCheck.Click += SevenCheck_Click;
                    Controls.Add(sevenCheck);
                    SevenBtnList.Add(sevenCheck);

                    locXbtn += 170;
                    var AllEq = new Button()
                    {
                        Location = new Point(locXbtn, locY),
                        Text = "Полный список" + " (" + countList[3] + ")",
                        Size = btnSize,
                    };
                    AllEq.Click += AllEq_Click;
                    Controls.Add(AllEq);
                    AllBtnList.Add(AllEq);

                    locXbtn += 170;
                    var Check = new Button()
                    {
                        Location = new Point(locXbtn, locY),
                        Text = "Список проверок",
                        Size = btnSize,
                    };
                    Check.Click += Check_Click;
                    Controls.Add(Check);
                    CheckBtnList.Add(Check);

                    locY += 60;
                    count++;
                }

                SqlQuery.conn.Close();
            }
            catch (Exception ex)
            {
                SqlQuery.conn.Close();
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnAllShow_Click(object sender, EventArgs e)
        { 
            ShowForm f2 = new ShowForm
            {
                colIndex = 0,
                isManager = true,
            };
            this.Hide(); f2.Show();
        }

        private void NowCheck_Click(object sender, EventArgs e)
        {
            var index = GiveBtnNum(sender, NowBtnList);
            ShowForm f2 = new ShowForm
            {
                colIndex = 1,
                curDepartment = NumbList[index - 1],
                isManager = true,
            };
            this.Hide(); f2.Show();
        }

        private void ThreeCheck_Click(object sender, EventArgs e)
        {
            var index = GiveBtnNum(sender, ThreeBtnList);
            ShowForm f2 = new ShowForm
            {
                colIndex = 2,
                curDepartment = NumbList[index - 1],
                isManager = true,
            };
            this.Hide(); f2.Show();
        }

        private void SevenCheck_Click(object sender, EventArgs e)
        {
            var index = GiveBtnNum(sender, SevenBtnList);
            ShowForm f2 = new ShowForm
            {
                colIndex = 3,
                curDepartment = NumbList[index - 1],
                isManager = true,
            };
            this.Hide(); f2.Show();
        }
    
        private void AllEq_Click(object sender, EventArgs e)
        {
            var index = GiveBtnNum(sender, AllBtnList);
            ShowForm f2 = new ShowForm
            {
                colIndex = 4,
                curDepartment = NumbList[index - 1],
                isManager = true,
            };

            this.Hide(); f2.Show();
        }

        private void Check_Click(object sender, EventArgs e)
        {
            var index = GiveBtnNum(sender, CheckBtnList);
            ShowCheckForm f2 = new ShowCheckForm
            {
                curDepartment = NumbList[index - 1],
                isManager = true,
            };

            this.Hide(); f2.Show();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            LoginForm login = new LoginForm();
            login.Show();
        }

        private int GiveBtnNum(object btn, List<Button> buttons)
        {
            var check = false;
            var i = 0;

            while (check != true)
            {
                check = btn.Equals(buttons[i]);
                i++;
            }
            return i;
        }
    }
}
