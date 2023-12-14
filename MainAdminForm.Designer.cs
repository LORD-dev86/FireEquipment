namespace FireEquipment2
{
    partial class MainAdminForm
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
            this.btnType = new System.Windows.Forms.Button();
            this.btnCheck = new System.Windows.Forms.Button();
            this.btnMType = new System.Windows.Forms.Button();
            this.btndepartment = new System.Windows.Forms.Button();
            this.btnPlacement = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnType
            // 
            this.btnType.Location = new System.Drawing.Point(18, 12);
            this.btnType.Name = "btnType";
            this.btnType.Size = new System.Drawing.Size(150, 30);
            this.btnType.TabIndex = 0;
            this.btnType.Text = "Типы объектов";
            this.btnType.UseVisualStyleBackColor = true;
            this.btnType.Click += new System.EventHandler(this.BtnType_Click);
            // 
            // btnCheck
            // 
            this.btnCheck.Location = new System.Drawing.Point(18, 62);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(150, 30);
            this.btnCheck.TabIndex = 2;
            this.btnCheck.Text = "Типы проверок";
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Click += new System.EventHandler(this.BtnCheck_Click);
            // 
            // btnMType
            // 
            this.btnMType.Location = new System.Drawing.Point(182, 12);
            this.btnMType.Name = "btnMType";
            this.btnMType.Size = new System.Drawing.Size(150, 30);
            this.btnMType.TabIndex = 3;
            this.btnMType.Text = "Подтипы объектов";
            this.btnMType.UseVisualStyleBackColor = true;
            this.btnMType.Click += new System.EventHandler(this.BtnMType_Click);
            // 
            // btndepartment
            // 
            this.btndepartment.Location = new System.Drawing.Point(182, 62);
            this.btndepartment.Name = "btndepartment";
            this.btndepartment.Size = new System.Drawing.Size(150, 30);
            this.btndepartment.TabIndex = 4;
            this.btndepartment.Text = "Отделы расположения";
            this.btndepartment.UseVisualStyleBackColor = true;
            this.btndepartment.Click += new System.EventHandler(this.Btndepartment_Click);
            // 
            // btnPlacement
            // 
            this.btnPlacement.Location = new System.Drawing.Point(18, 109);
            this.btnPlacement.Name = "btnPlacement";
            this.btnPlacement.Size = new System.Drawing.Size(150, 30);
            this.btnPlacement.TabIndex = 5;
            this.btnPlacement.Text = "Места расположения";
            this.btnPlacement.UseVisualStyleBackColor = true;
            this.btnPlacement.Click += new System.EventHandler(this.BtnPlacement_Click);
            // 
            // MainAdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(340, 151);
            this.Controls.Add(this.btnPlacement);
            this.Controls.Add(this.btndepartment);
            this.Controls.Add(this.btnMType);
            this.Controls.Add(this.btnCheck);
            this.Controls.Add(this.btnType);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainAdminForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Режим администрирования";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainAdminForm_FormClosed);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnType;
        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.Button btnMType;
        private System.Windows.Forms.Button btndepartment;
        private System.Windows.Forms.Button btnPlacement;
    }
}