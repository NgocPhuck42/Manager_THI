using ManagerCD.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Manager
{
    public partial class frmManager : Form
    {
        private Account loginAccount;

        public Account LoginAccount
        {
            get
            {
                return loginAccount;

            }
            set
            {
                loginAccount = value; ChangeAccount(loginAccount.Type);
            }


        }

        public frmManager(Account acc)
        {
            InitializeComponent();
            this.LoginAccount = acc;
        }

        void ChangeAccount(int type)
        {
            adminToolStripMenuItem.Enabled = type == 1;
          //  thốngKêToolStripMenuItem.Enabled = type == 1;
            hệThốngToolStripMenuItem.Text += " (" + LoginAccount.DisplayName + ")";
        }

        private void AddForm(Form f)
        {
            this.gbContent.Controls.Clear();

            f.TopLevel = false;
            f.AutoScroll = true;
            f.FormBorderStyle = FormBorderStyle.None;
            f.Dock = DockStyle.Fill;
            this.Text = f.Text;
            this.gbContent.Controls.Add(f);
            f.Show();
        }

        void f_UpdateAccount(object sender, AccountEvent e)
        {
            hệThốngToolStripMenuItem.Text = "Thông tin tài khoản (" + e.Acc.DisplayName + ")";
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void đổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var f = new frmAccountProfile(LoginAccount);
            f.UpdateAccount += f_UpdateAccount;
            AddForm(f);
        }

        private void loạiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCategory f = new frmCategory();
            f.ShowDialog();
        }

        private void cDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProduct f = new frmProduct();
            f.ShowDialog();
        }

        private void quảnLýTàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAdmin f = new frmAdmin();
            f.loginAccount = loginAccount;
            f.ShowDialog();
        }
    }
}
