using System;
using System.Windows.Forms;

namespace FireEquipment2
{
    public partial class MainAdminForm : Form
    {
       
        public MainAdminForm()
        {
            InitializeComponent();
        }

        private void BtnType_Click(object sender, EventArgs e)
        {
            ShowAdminForm showAdmin = new ShowAdminForm()
            {
                colIndex = 1,
            };
            showAdmin.Show(); this.Hide();
        }

        private void BtnMType_Click(object sender, EventArgs e)
        {
            ShowAdminForm showAdmin = new ShowAdminForm()
            {
                colIndex = 2,
            };
            showAdmin.Show(); this.Hide();
        }

        private void BtnCheck_Click(object sender, EventArgs e)
        {
            ShowAdminForm showAdmin = new ShowAdminForm()
            {
                colIndex = 3,
            };
            showAdmin.Show(); this.Hide();
        }

        private void Btndepartment_Click(object sender, EventArgs e)
        {
            ShowAdminForm showAdmin = new ShowAdminForm()
            {
                colIndex = 4,
            };
            showAdmin.Show(); this.Hide();
        }

        private void BtnPlacement_Click(object sender, EventArgs e)
        {
            ShowAdminForm showAdmin = new ShowAdminForm()
            {
                colIndex = 5,
            };
            showAdmin.Show(); this.Hide();
        }
        private void MainAdminForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            LoginForm login = new LoginForm();
            login.Show();
        }
    }
}
