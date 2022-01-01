using Manager.DTO;
using ManagerCD.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.DAO
{
    public class CategoryDAO
    {
        private static CategoryDAO instance;

        public static CategoryDAO Instance
        {
            get
            {
                if (instance == null) instance = new CategoryDAO();
                return CategoryDAO.instance;
            }

            private set => CategoryDAO.instance = value;
        }

        private CategoryDAO() { }

        public List<Category> SearchCategoryByName(string name)
        {
            List<Category> categories = new List<Category>();
            string query = string.Format("select * from Category where dbo.ufn_removeMark(Name) LIKE N'%' + dbo.ufn_removeMark(N'{0}') + '%' ", name);
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                Category category = new Category(item);
                categories.Add(category);
            }
            return categories;
        }

        public List<Category> GetListCategoryInCB()
        {
            List<Category> list = new List<Category>();

            string query = "select * from Category";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                Category category = new Category(item);
                list.Add(category);
            }

            return list;
        }

        public Category GetCategoryByID(int id)
        {
            Category category = null;
            string query = "select * from Category where id = " + id;

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                category = new Category(item);
                return category;
            }
            return category;
        }

        public DataTable GetListCategory()
        {
            return DataProvider.Instance.ExecuteQuery("select * from category ");
        }
        public bool InsertCategory(string name)
        {
            string query = string.Format("insert dbo.Category (Name) values (N'{0}')", name);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool UpdateCategory(int id, string name)
        {
            string query = string.Format("update Category set name = N'{1}' where id = {0}", id, name);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool DeleteCategory(int id)
        {
            string query = string.Format("delete dbo.Category where id = {0}", id);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

    }
}
