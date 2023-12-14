namespace FireEquipment2
{
    partial class MainUserForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lName = new System.Windows.Forms.Label();
            this.lDesc = new System.Windows.Forms.Label();
            this.NowCheck = new System.Windows.Forms.Button();
            this.ThreeCheck = new System.Windows.Forms.Button();
            this.SevenCheck = new System.Windows.Forms.Button();
            this.AllEq = new System.Windows.Forms.Button();
            this.Checking = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lName
            // 
            this.lName.AutoSize = true;
            this.lName.Location = new System.Drawing.Point(15, 10);
            this.lName.Name = "lName";
            this.lName.Size = new System.Drawing.Size(52, 13);
            this.lName.TabIndex = 0;
            this.lName.Text = "Отдел №";
            // 
            // lDesc
            // 
            this.lDesc.AutoSize = true;
            this.lDesc.Location = new System.Drawing.Point(83, 9);
            this.lDesc.Name = "lDesc";
            this.lDesc.Size = new System.Drawing.Size(0, 13);
            this.lDesc.TabIndex = 1;
            // 
            // NowCheck
            // 
            this.NowCheck.Location = new System.Drawing.Point(12, 38);
            this.NowCheck.Name = "NowCheck";
            this.NowCheck.Size = new System.Drawing.Size(178, 30);
            this.NowCheck.TabIndex = 2;
            this.NowCheck.Text = "СПЗ Требуют проверки";
            this.NowCheck.UseVisualStyleBackColor = true;
            this.NowCheck.Click += new System.EventHandler(this.NowCheck_Click);
            // 
            // ThreeCheck
            // 
            this.ThreeCheck.Location = new System.Drawing.Point(196, 38);
            this.ThreeCheck.Name = "ThreeCheck";
            this.ThreeCheck.Size = new System.Drawing.Size(178, 30);
            this.ThreeCheck.TabIndex = 3;
            this.ThreeCheck.Text = "СПЗ Проверка через 3 дня";
            this.ThreeCheck.UseVisualStyleBackColor = true;
            this.ThreeCheck.Click += new System.EventHandler(this.ThreeCheck_Click);
            // 
            // SevenCheck
            // 
            this.SevenCheck.Location = new System.Drawing.Point(12, 85);
            this.SevenCheck.Name = "SevenCheck";
            this.SevenCheck.Size = new System.Drawing.Size(178, 30);
            this.SevenCheck.TabIndex = 4;
            this.SevenCheck.Text = "СПЗ Проверка через 7 дней";
            this.SevenCheck.UseVisualStyleBackColor = true;
            this.SevenCheck.Click += new System.EventHandler(this.SevenCheck_Click);
            // 
            // AllEq
            // 
            this.AllEq.Location = new System.Drawing.Point(196, 85);
            this.AllEq.Name = "AllEq";
            this.AllEq.Size = new System.Drawing.Size(178, 30);
            this.AllEq.TabIndex = 5;
            this.AllEq.Text = "Полный список СПЗ";
            this.AllEq.UseVisualStyleBackColor = true;
            this.AllEq.Click += new System.EventHandler(this.AllEq_Click);
            // 
            // Checking
            // 
            this.Checking.Location = new System.Drawing.Point(111, 133);
            this.Checking.Name = "Checking";
            this.Checking.Size = new System.Drawing.Size(156, 30);
            this.Checking.TabIndex = 6;
            this.Checking.Text = "Список проверок";
            this.Checking.UseVisualStyleBackColor = true;
            this.Checking.Click += new System.EventHandler(this.Checking_Click);
            // 
            // MainUserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 185);
            this.Controls.Add(this.Checking);
            this.Controls.Add(this.AllEq);
            this.Controls.Add(this.SevenCheck);
            this.Controls.Add(this.ThreeCheck);
            this.Controls.Add(this.NowCheck);
            this.Controls.Add(this.lDesc);
            this.Controls.Add(this.lName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainUserForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Учёт средств пожаротушения - Главная";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainUserForm_FormClosed);
            this.Load += new System.EventHandler(this.MainUserForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button NowCheck;
        private System.Windows.Forms.Button ThreeCheck;
        private System.Windows.Forms.Button SevenCheck;
        private System.Windows.Forms.Button AllEq;
        private System.Windows.Forms.Label lName;
        private System.Windows.Forms.Label lDesc;
        private System.Windows.Forms.Button Checking;
    }
}