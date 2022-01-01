
namespace Manager
{
    partial class frmAdmin
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
            this.panel24 = new System.Windows.Forms.Panel();
            this.panel27 = new System.Windows.Forms.Panel();
            this.nmAccountType = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.panel26 = new System.Windows.Forms.Panel();
            this.txbAccountDisplay = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.panel25 = new System.Windows.Forms.Panel();
            this.txbAccountName = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btnResetAccount = new System.Windows.Forms.Button();
            this.dtgvAccount = new System.Windows.Forms.DataGridView();
            this.panel22 = new System.Windows.Forms.Panel();
            this.btnViewaccount = new System.Windows.Forms.Button();
            this.btnEditAccount = new System.Windows.Forms.Button();
            this.btnDeleteAccount = new System.Windows.Forms.Button();
            this.btnAddAccount = new System.Windows.Forms.Button();
            this.panel24.SuspendLayout();
            this.panel27.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmAccountType)).BeginInit();
            this.panel26.SuspendLayout();
            this.panel25.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvAccount)).BeginInit();
            this.panel22.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel24
            // 
            this.panel24.Controls.Add(this.panel27);
            this.panel24.Controls.Add(this.panel26);
            this.panel24.Controls.Add(this.panel25);
            this.panel24.Controls.Add(this.btnResetAccount);
            this.panel24.Location = new System.Drawing.Point(437, 79);
            this.panel24.Name = "panel24";
            this.panel24.Size = new System.Drawing.Size(351, 296);
            this.panel24.TabIndex = 8;
            // 
            // panel27
            // 
            this.panel27.Controls.Add(this.nmAccountType);
            this.panel27.Controls.Add(this.label12);
            this.panel27.Location = new System.Drawing.Point(5, 93);
            this.panel27.Name = "panel27";
            this.panel27.Size = new System.Drawing.Size(343, 39);
            this.panel27.TabIndex = 7;
            // 
            // nmAccountType
            // 
            this.nmAccountType.Location = new System.Drawing.Point(136, 9);
            this.nmAccountType.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmAccountType.Name = "nmAccountType";
            this.nmAccountType.Size = new System.Drawing.Size(32, 20);
            this.nmAccountType.TabIndex = 1;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(3, 9);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(127, 20);
            this.label12.TabIndex = 0;
            this.label12.Text = "Loại tài khoản:";
            // 
            // panel26
            // 
            this.panel26.Controls.Add(this.txbAccountDisplay);
            this.panel26.Controls.Add(this.label11);
            this.panel26.Location = new System.Drawing.Point(5, 48);
            this.panel26.Name = "panel26";
            this.panel26.Size = new System.Drawing.Size(343, 39);
            this.panel26.TabIndex = 6;
            // 
            // txbAccountDisplay
            // 
            this.txbAccountDisplay.Location = new System.Drawing.Point(137, 9);
            this.txbAccountDisplay.Name = "txbAccountDisplay";
            this.txbAccountDisplay.Size = new System.Drawing.Size(203, 20);
            this.txbAccountDisplay.TabIndex = 1;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(3, 9);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(108, 20);
            this.label11.TabIndex = 0;
            this.label11.Text = "Tên hiển thị:";
            // 
            // panel25
            // 
            this.panel25.Controls.Add(this.txbAccountName);
            this.panel25.Controls.Add(this.label10);
            this.panel25.Location = new System.Drawing.Point(5, 3);
            this.panel25.Name = "panel25";
            this.panel25.Size = new System.Drawing.Size(343, 39);
            this.panel25.TabIndex = 5;
            // 
            // txbAccountName
            // 
            this.txbAccountName.Location = new System.Drawing.Point(137, 9);
            this.txbAccountName.Name = "txbAccountName";
            this.txbAccountName.Size = new System.Drawing.Size(203, 20);
            this.txbAccountName.TabIndex = 1;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(3, 9);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(123, 20);
            this.label10.TabIndex = 0;
            this.label10.Text = "Tên tài khoản:";
            // 
            // btnResetAccount
            // 
            this.btnResetAccount.Location = new System.Drawing.Point(270, 138);
            this.btnResetAccount.Name = "btnResetAccount";
            this.btnResetAccount.Size = new System.Drawing.Size(75, 49);
            this.btnResetAccount.TabIndex = 4;
            this.btnResetAccount.Text = " Đặt lại mật khẩu";
            this.btnResetAccount.UseVisualStyleBackColor = true;
            this.btnResetAccount.Click += new System.EventHandler(this.btnResetAccount_Click);
            // 
            // dtgvAccount
            // 
            this.dtgvAccount.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgvAccount.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvAccount.Location = new System.Drawing.Point(12, 79);
            this.dtgvAccount.Name = "dtgvAccount";
            this.dtgvAccount.Size = new System.Drawing.Size(398, 296);
            this.dtgvAccount.TabIndex = 6;
            // 
            // panel22
            // 
            this.panel22.Controls.Add(this.btnViewaccount);
            this.panel22.Controls.Add(this.btnEditAccount);
            this.panel22.Controls.Add(this.btnDeleteAccount);
            this.panel22.Controls.Add(this.btnAddAccount);
            this.panel22.Location = new System.Drawing.Point(12, 18);
            this.panel22.Name = "panel22";
            this.panel22.Size = new System.Drawing.Size(351, 55);
            this.panel22.TabIndex = 7;
            // 
            // btnViewaccount
            // 
            this.btnViewaccount.Location = new System.Drawing.Point(246, 3);
            this.btnViewaccount.Name = "btnViewaccount";
            this.btnViewaccount.Size = new System.Drawing.Size(75, 49);
            this.btnViewaccount.TabIndex = 3;
            this.btnViewaccount.Text = "Xem";
            this.btnViewaccount.UseVisualStyleBackColor = true;
            this.btnViewaccount.Click += new System.EventHandler(this.btnViewaccount_Click);
            // 
            // btnEditAccount
            // 
            this.btnEditAccount.Location = new System.Drawing.Point(165, 3);
            this.btnEditAccount.Name = "btnEditAccount";
            this.btnEditAccount.Size = new System.Drawing.Size(75, 49);
            this.btnEditAccount.TabIndex = 2;
            this.btnEditAccount.Text = "Sửa";
            this.btnEditAccount.UseVisualStyleBackColor = true;
            this.btnEditAccount.Click += new System.EventHandler(this.btnEditAccount_Click);
            // 
            // btnDeleteAccount
            // 
            this.btnDeleteAccount.Location = new System.Drawing.Point(84, 3);
            this.btnDeleteAccount.Name = "btnDeleteAccount";
            this.btnDeleteAccount.Size = new System.Drawing.Size(75, 49);
            this.btnDeleteAccount.TabIndex = 1;
            this.btnDeleteAccount.Text = "Xóa";
            this.btnDeleteAccount.UseVisualStyleBackColor = true;
            this.btnDeleteAccount.Click += new System.EventHandler(this.btnDeleteAccount_Click);
            // 
            // btnAddAccount
            // 
            this.btnAddAccount.Location = new System.Drawing.Point(3, 3);
            this.btnAddAccount.Name = "btnAddAccount";
            this.btnAddAccount.Size = new System.Drawing.Size(75, 49);
            this.btnAddAccount.TabIndex = 0;
            this.btnAddAccount.Text = "Thêm";
            this.btnAddAccount.UseVisualStyleBackColor = true;
            this.btnAddAccount.Click += new System.EventHandler(this.btnAddAccount_Click);
            // 
            // frmAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 392);
            this.Controls.Add(this.panel24);
            this.Controls.Add(this.dtgvAccount);
            this.Controls.Add(this.panel22);
            this.Name = "frmAdmin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmAdmin";
            this.panel24.ResumeLayout(false);
            this.panel27.ResumeLayout(false);
            this.panel27.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmAccountType)).EndInit();
            this.panel26.ResumeLayout(false);
            this.panel26.PerformLayout();
            this.panel25.ResumeLayout(false);
            this.panel25.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvAccount)).EndInit();
            this.panel22.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel24;
        private System.Windows.Forms.Panel panel27;
        private System.Windows.Forms.NumericUpDown nmAccountType;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Panel panel26;
        private System.Windows.Forms.TextBox txbAccountDisplay;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel panel25;
        private System.Windows.Forms.TextBox txbAccountName;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnResetAccount;
        private System.Windows.Forms.DataGridView dtgvAccount;
        private System.Windows.Forms.Panel panel22;
        private System.Windows.Forms.Button btnViewaccount;
        private System.Windows.Forms.Button btnEditAccount;
        private System.Windows.Forms.Button btnDeleteAccount;
        private System.Windows.Forms.Button btnAddAccount;
    }
}