using ManagerCD.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerCD.DAO
{
    public class AccountDAO
    {
        private static AccountDAO intansce;

        public static AccountDAO Intansce
        {
            get
            {
                if (intansce == null) intansce = new AccountDAO();
                return AccountDAO.intansce;
            }
            private set => AccountDAO.intansce = value;
        }

        private AccountDAO()
        {
        }

        public DataTable GetListAccount()
        {
            return DataProvider.Instance.ExecuteQuery("select username, displayname, type from Account");
        }

        public bool Login(string username, string password)
        {
            string query = "USP_Login @username , @password";
            DataTable result = DataProvider.Instance.ExecuteQuery(query, new object[] { username, password });
            return result.Rows.Count > 0;
        }

        public Account GetAccountByUserName(string userName)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("Select * from dbo.Account where username = '" + userName + "'");

            foreach (DataRow item in data.Rows)
            {
                return new Account(item);

            }
            return null;
        }

        public bool UpdateAccount(string userName, string displayName, string pass, string newPass)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("USP_UpdateAccount @username , @displayname , @password , @newpassword ", new object[] { userName, displayName, pass, newPass });
            return result > 0;
        }

        public bool InsertAccount(string name, string displayName, int type)
        {
            string query = string.Format("INSERT Account(username, password ,displayname, Type) values (N'{0}', N'0' , N'{1}', {2})", name, displayName, type);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool UpdateAccountByAdmin(string name, string displayName, int type)
        {
            string query = string.Format("update dbo.Account set DisplayName = N'{1}' , Type = {2} where UserName = N'{0}'", name, displayName, type);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool DeleteAccount(string name)
        {

            string query = string.Format("delete Account where UserName = N'{0}' ", name);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        public bool ResetPassword(string name)
        {
            string query = string.Format("update Account set password = N'0' where UserName = N'{0}' ", name);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
    }
}
