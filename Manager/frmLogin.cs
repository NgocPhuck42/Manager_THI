using ManagerCD.DAO;
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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        bool Login(string username, string password)
        {
            return AccountDAO.Intansce.Login(username, password);
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txbUser.Text.Trim();
            string password = txbPass.Text.Trim();
            if (Login(username, password))
            {
                Account loginAccount = AccountDAO.Intansce.GetAccountByUserName(username);
                frmManager form = new frmManager(loginAccount);
                this.Hide();
                form.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Sai tên tài khoản hoặc mật khẩu!");
            }
        }
    }
}
