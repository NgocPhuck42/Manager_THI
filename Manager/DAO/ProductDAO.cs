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
    public class ProductDAO
    {
        private static ProductDAO instance;

        public static ProductDAO Instance
        {
            get
            {
                if (instance == null) instance = new ProductDAO();
                return ProductDAO.instance;
            }
            private set
            {
                ProductDAO.instance = value;
            }
        }
        private ProductDAO()
        {
        }

        public List<Product> GetProductByCategoryID(int id)
        {
            List<Product> list = new List<Product>();

            string query = "select * from Product where idCategory=" + id;
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                Product food = new Product(item);
                list.Add(food);
            }
            return list;
        }

        public List<Product> GetListProduct()
        {
            List<Product> list = new List<Product>();

            string query = "select * from Product";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                Product food = new Product(item);
                list.Add(food);
            }
            return list;

        }

        public List<Product> SearchProductByName(string name)
        {
            List<Product> list= new List<Product>();

            string query = string.Format("select * from Product where dbo.ufn_removeMark(Name) LIKE N'%' + dbo.ufn_removeMark(N'{0}') + '%' ", name);
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                Product food = new Product(item);
                list.Add(food);
            }
            return list;
        }



        public bool InsertProduct(string name, int id, int price)
        {
            string query = string.Format("INSERT dbo.Product (name, idCategory, price) values (N'{0}' , {1}, {2})", name, id, price);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool UpdateProduct(int idProduct, string name, int id, int price)
        {
            string query = string.Format("update dbo.Product set name = N'{0}' , idCategory = {1} , price = {2} where id = {3}", name, id, price, idProduct);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool DeleteProduct(int id)
        {
           // BillInfoDAO.Instance.DeleteBillInfoByFoodID(idFood);
            string query = string.Format("delete Product where id = {0} ", id);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
    }
}
