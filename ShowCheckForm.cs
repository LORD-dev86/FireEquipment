using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace FireEquipment2
{
    public partial class ShowCheckForm : Form
    {
        public int curDepartment;
        public bool isManager;
        public string desc;

        private int CurId;
        public ShowCheckForm()
        {
            InitializeComponent();
        }

        private void ShowCheckForm_Load(object sender, EventArgs e)
        {
            this.Text += curDepartment;

            CommonFunction.ClearDgv(dgvCheck);
            dgvCheck.DataSource = CommonFunction.SelectChechData(curDepartment);
            CurId = CommonFunction.GetLastIdCheck() + 1;

            if (isManager)
            {
                this.btnPrintDocument.Text = "Просмотр отчёта";
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddCheckForm addForm = new AddCheckForm
            {
                Text = "Добавление проверки к отделу №" + curDepartment,
                isInsert = true,
            };
            addForm.tbId.Text = CurId.ToString();
            addForm.tbDepartment.Text = curDepartment.ToString();
            addForm.ShowDialog();

            CommonFunction.ClearDgv(dgvCheck);
            CurId = CommonFunction.GetLastIdCheck() + 1;
            dgvCheck.DataSource = CommonFunction.SelectChechData(curDepartment);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var index = dgvCheck.CurrentCell.RowIndex;

            try
            {
                AddCheckForm addForm = new AddCheckForm
                {
                    Text = "Изменение проверки отдела №" + curDepartment,
                    isInsert = false,
                };

                addForm.tbId.Text = dgvCheck[0, index].Value.ToString();
                addForm._type = dgvCheck[1, index].Value.ToString();
                addForm.tbCheckDate.Text = DateTime.Parse(dgvCheck[2, index]
                                            .Value.ToString()).ToString("yyyy-MM-dd");
                addForm.tbDepartment.Text = dgvCheck[3, index].Value.ToString();
                addForm.tbResult.Text = dgvCheck[4, index].Value.ToString();
                addForm.tbDesc.Text = dgvCheck[5, index].Value.ToString();

                addForm.ShowDialog();

                CommonFunction.ClearDgv(dgvCheck);
                dgvCheck.DataSource = CommonFunction.SelectChechData(curDepartment);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ShowCheckForm_FormClosed(object sender, FormClosedEventArgs e)
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

        private void PrintDocument_Click(object sender, EventArgs e)
        {
            if (isManager)
            {
                try
                {
                    Process process = new Process();
                    process.StartInfo.FileName = Manager.GetCheckPath(curDepartment);
                    process.StartInfo.Verb = "open";
                    process.Start();
                }
                catch (Exception)
                {
                    MessageBox.Show("Документ не сформирован!");
                }

            }
            else
            {
                 Respondent.PrintCheckDocument(curDepartment, dgvCheck);
            }
            
        }
    }
    
}
