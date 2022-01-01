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
    public partial class frmAdmin : Form
    {

        BindingSource account = new BindingSource();
        public Account loginAccount;

        public frmAdmin()
        {
            InitializeComponent();
            dtgvAccount.DataSource = account;
            LoadAccount();
            AddAccountBinding();
        }

        void LoadAccount()
        {
            account.DataSource = AccountDAO.Intansce.GetListAccount();
        }

        void AddAccountBinding()
        {
            txbAccountName.DataBindings.Add(new Binding("Text", dtgvAccount.DataSource, "username", true, DataSourceUpdateMode.Never));
            txbAccountDisplay.DataBindings.Add(new Binding("Text", dtgvAccount.DataSource, "displayname", true, DataSourceUpdateMode.Never));

            nmAccountType.DataBindings.Add(new Binding("Value", dtgvAccount.DataSource, "type", true, DataSourceUpdateMode.Never));
        }

        void AddAccount(string userName, string displayName, int type)
        {
            if (AccountDAO.Intansce.InsertAccount(userName, displayName, type))
            {
                MessageBox.Show("Thêm tài khoản thành công");
            }
            else
            {
                MessageBox.Show("Thêm tài khoản thất bại");
            }
            LoadAccount();
        }

        void EditAccount(string userName, string displayName, int type)
        {
            if (AccountDAO.Intansce.UpdateAccountByAdmin(userName, displayName, type))
            {
                MessageBox.Show("Sửa tài khoản thành công");
            }
            else
            {
                MessageBox.Show("Sửa tài khoản thất bại");
            }
            LoadAccount();
        }

        void DeleteAccount(string userName)
        {
            if (loginAccount.UserName.Equals(userName))
            {
                MessageBox.Show("Thất bại, không xóa tài khoản hiện tại đang dùng");
                return;
            }
            if (AccountDAO.Intansce.DeleteAccount(userName))
            {
                MessageBox.Show("Xóa tài khoản thành công");
            }
            else
            {
                MessageBox.Show("Xóa tài khoản thất bại");
            }
            LoadAccount();
        }

        void ResetPass(string userName)
        {
            if (AccountDAO.Intansce.ResetPassword(userName))
            {
                MessageBox.Show("Đặt lại mật khẩu thành công !");
            }
            else
            {
                MessageBox.Show("Thất bại !");
            }
            LoadAccount();
        }

        private void btnAddAccount_Click(object sender, EventArgs e)
        {
            string userName = txbAccountName.Text;
            string displayName = txbAccountDisplay.Text;
            int type = (int)nmAccountType.Value;

            AddAccount(userName, displayName, type);
        }

        private void btnDeleteAccount_Click(object sender, EventArgs e)
        {
            string userName = txbAccountName.Text;

            DeleteAccount(userName);
        }

        private void btnEditAccount_Click(object sender, EventArgs e)
        {
            string userName = txbAccountName.Text;
            string displayName = txbAccountDisplay.Text;
            int type = (int)nmAccountType.Value;

            EditAccount(userName, displayName, type);
        }

        private void btnViewaccount_Click(object sender, EventArgs e)
        {
            LoadAccount();
        }

        private void btnResetAccount_Click(object sender, EventArgs e)
        {
            string userName = txbAccountName.Text;

            ResetPass(userName);
        }
    }
}
