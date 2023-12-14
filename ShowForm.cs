using Npgsql;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace FireEquipment2
{
    public partial class ShowForm : Form
    {
        public ShowForm()
        {
            InitializeComponent();
        }

        public int colIndex;
        public int curDepartment;
        public string desc;
        public bool isManager;
        

        private int CurId;

        private string postsql;

        private void ShowForm_Load(object sender, EventArgs e)
        {
            SqlQuery.conn = new NpgsqlConnection(SqlQuery.connString);

            SelectAllDataMark();

            CurId = CommonFunction.GetLastIdEq() + 1;
            cbShowMark.CheckState = CheckState.Unchecked;

            try
            {
                switch (colIndex)
                {
                    default:
                        MessageBox.Show("Неизвестная команда");
                        break;
                    case (1):
                        this.Text = "Требуют проверки, отдел №" + curDepartment;
                        postsql += " and \"Следующая проверка\" <= now()";
                        SelectDataArgMark();
                        break;
                    case (2):
                        this.Text = "Проверка через 3 дня, отдел №" + curDepartment;
                        postsql += " and \"Следующая проверка\" <= now() + interval '3 days'" +
                            " and \"Следующая проверка\" > now()";
                        SelectDataArgMark();
                        break;
                    case (3):
                        this.Text = "Проверка через 7 дней, отдел №" + curDepartment;
                        postsql += " and \"Следующая проверка\" <= now() + interval '7 days' " +
                            "and \"Следующая проверка\" > now() + interval '3 days'";
                        SelectDataArgMark();
                        break;
                    case (4):
                        this.Text = "Полный список, отдел №" + curDepartment;
                        btnAdd.Visible = true; btnAdd.Enabled = true;
                        btnPrintDoc.Visible = true; btnPrintDoc.Enabled = true;
                        cbShowMark.Visible = true; cbShowMark.Enabled = true;
                        postsql = "";
                        SelectDataArgMark();
                        break;
                    case (0):
                        this.Text = "Полный список по всем отделам";
                        btnAdd.Visible = true; btnAdd.Enabled = true;
                        btnPrintDoc.Visible = true; btnPrintDoc.Enabled = true;
                        cbShowMark.Visible = true; cbShowMark.Enabled = true;
                        postsql = "";
                        SelectAllDataMark();
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                SqlQuery.conn.Close();
            }

            if (isManager)
                this.btnPrintDoc.Text = "Просмотр отчета";
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            AddForm addForm = new AddForm();
            addForm.Text = "Добавление к списку отдела №" + curDepartment;

            addForm.isInsert = true;
            addForm.tbId.Text = CurId.ToString();
            addForm.tbDepartment.Text = curDepartment.ToString();

            addForm.ShowDialog();

            CommonFunction.ClearDgv(dgvData);
            
            if (colIndex == 0)
                SelectAllDataMark();
            else
                SelectDataArgMark();
        }
        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            var index = dgvData.CurrentCell.RowIndex;

            try
            {
                AddForm addForm = new AddForm();
                addForm.isInsert = false;
                addForm.tbId.Text = dgvData[0, index].Value.ToString();
                addForm._type = dgvData[1, index].Value.ToString();
                addForm._mtype = dgvData[2, index].Value.ToString();
                addForm.tbReleaser.Text = dgvData[3, index].Value.ToString();
                addForm.tbReleaseDate.Text = DateTime.Parse(dgvData[4, index]
                                            .Value.ToString()).ToString("yyyy-MM-dd");
                addForm.tbCheckDate.Text = DateTime.Parse(dgvData[5, index]
                                            .Value.ToString()).ToString("yyyy-MM-dd");
                addForm.tbBCheckDate.Text = DateTime.Parse(dgvData[6, index]
                                            .Value.ToString()).ToString("yyyy-MM-dd");
                addForm.tbReloadDate.Text = DateTime.Parse(dgvData[7, index]
                                            .Value.ToString()).ToString("yyyy-MM-dd");
                addForm.tbBReloadDate.Text = DateTime.Parse(dgvData[8, index]
                                            .Value.ToString()).ToString("yyyy-MM-dd");
                addForm.tbDepartment.Text = dgvData[9, index].Value.ToString();
                addForm._place = dgvData[10, index].Value.ToString();
                addForm.cbMark.Checked = bool.Parse(dgvData[11, index].Value.ToString());
                addForm.ShowDialog();

                CommonFunction.ClearDgv(dgvData);
                if (colIndex == 0)
                    SelectAllDataMark();
                else
                    SelectDataArgMark();
            }
            catch (Exception ex)
            {
                 MessageBox.Show(ex.Message);
            }    
        }

       private void ShowForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (isManager)
            {
                MainManagerForm mainAdmin = new MainManagerForm();
                mainAdmin.Show();
            }
            else
            {
                MainUserForm mainUser = new MainUserForm()
                {
                    department = curDepartment,
                    Desc = desc,
                };

                mainUser.Show();
            }

        }
       private void CbShowMark_CheckedChanged(object sender, EventArgs e)
        {
            CommonFunction.ClearDgv(dgvData);
            if (colIndex == 0)
                SelectAllDataMark();
            else
                SelectDataArgMark();
        }

        private void SelectDataArgMark()
        {
            CommonFunction.ClearDgv(dgvData);
            
            if (cbShowMark.CheckState == CheckState.Checked)
                postsql = postsql.Substring(0, 
                    postsql.IndexOf("С") - 5);
            else
                postsql += @" and Списан = false";
            
            dgvData.DataSource = CommonFunction.
                SelectDataArg(postsql, curDepartment);
                
        }

        private void SelectAllDataMark()
        {
           CommonFunction.ClearDgv(dgvData);

           if (cbShowMark.CheckState == CheckState.Checked)
               dgvData.DataSource = Manager.SelectAllData("");
           else
                dgvData.DataSource = Manager.SelectAllData(" where Списан = false");
        }

        private void btnPrintDoc_Click(object sender, EventArgs e)
        {
            if (isManager)
            {
                try
                {
                    Process process = new Process();
                    process.StartInfo.FileName = Manager.GetEqPath(curDepartment);
                    process.StartInfo.Verb = "open";
                    process.Start();
                }
                catch (Exception)
                {
                    MessageBox.Show("Документ не сформирован!");
                }
            } else {
                Respondent.PrintEqDocument(curDepartment, dgvData);
            }
        }

    }
}
