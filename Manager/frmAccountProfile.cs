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
    public partial class frmAccountProfile : Form
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
                loginAccount = value; ChangeAccount(loginAccount);
            }


        }

        public frmAccountProfile(Account acc)
        {
            InitializeComponent();
            LoginAccount = acc;
        }

        void ChangeAccount(Account acc)
        {
            txbUser.Text = LoginAccount.UserName;
            txbDisplayName.Text = LoginAccount.DisplayName;
        }

        void UpdateAccountInfo()
        {
            string displayname = txbDisplayName.Text;
            string pass = txbPass.Text;
            string newpass = txbNewPass.Text;
            string repass = txbRePass.Text;
            string username = txbUser.Text;

            if (!newpass.Equals(repass))
            {
                MessageBox.Show("Vui lòng nhập lại mật khẩu đúng với mật khẩu mới!");
            }
            else
            {
                if (AccountDAO.Intansce.UpdateAccount(username, displayname, pass, newpass))
                {

                    MessageBox.Show("Đổi mật khẩu thành công");
                    if (updateAccount != null)
                        updateAccount(this, new AccountEvent(AccountDAO.Intansce.GetAccountByUserName(username)));
                }
                else
                {
                    MessageBox.Show("Đổi mật khẩu thất bại");
                }
            }
        }

        private event EventHandler<AccountEvent> updateAccount;
        public event EventHandler<AccountEvent> UpdateAccount
        {
            add
            {
                updateAccount += value;
            }
            remove
            {
                updateAccount -= value;
            }
        }

        private void btnUpdatePass_Click(object sender, EventArgs e)
        {
            UpdateAccountInfo();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
    public class AccountEvent : EventArgs
    {
        private Account acc;

        public Account Acc { get => acc; set { acc = value; } }

        public AccountEvent(Account acc)
        {
            this.Acc = acc;
        }
    }
}
