using Manager.DAO;
using Manager.DTO;
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
    public partial class frmProduct : Form
    {

        BindingSource list = new BindingSource();
        public frmProduct()
        {
            InitializeComponent();
            dtgvProduct.DataSource = list;
            LoadListProduct();
            AddProductBinding();
            LoadCategoryIntoCombobox(cbxcategory);
        }

        void AddProductBinding()
        {
            txtname.DataBindings.Add(new Binding("Text", dtgvProduct.DataSource, "Name", true, DataSourceUpdateMode.Never));
            txtid.DataBindings.Add(new Binding("Text", dtgvProduct.DataSource, "id", true, DataSourceUpdateMode.Never));
            nmPrice.DataBindings.Add(new Binding("Value", dtgvProduct.DataSource, "Price", true, DataSourceUpdateMode.Never));

        }

        List<Product> SearchProductByName(String name)
        {
            List<Product> listfood = ProductDAO.Instance.SearchProductByName(name);



            return listfood;
        }

        void LoadCategoryIntoCombobox(ComboBox cb)
        {
            cb.DataSource = CategoryDAO.Instance.GetListCategoryInCB();
            cb.DisplayMember = "Name";
        }

        void LoadListProduct()
        {
            list.DataSource = ProductDAO.Instance.GetListProduct();
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            string name = txtname.Text;
            int categoryID = (cbxcategory.SelectedItem as Category).ID;
            int price = (int)nmPrice.Value;

            if (ProductDAO.Instance.InsertProduct(name, categoryID, price))
            {
                MessageBox.Show("Thêm món thành công !");
                LoadListProduct();
                //if (inser != null)
                //    insertFood(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Thêm công thành công !");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtid.Text);
            if (ProductDAO.Instance.DeleteProduct(id))
            {
                MessageBox.Show("Xóa món thành công !");
                LoadListProduct();
                //if (deleteFood != null)
                //    deleteFood(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Xóa công thành công !");
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            string name = txtname.Text;
            int categoryID = (cbxcategory.SelectedItem as Category).ID;
            int price = (int)nmPrice.Value;

            int id = Convert.ToInt32(txtid.Text);
            if (ProductDAO.Instance.UpdateProduct(id, name, categoryID, price))
            {
                MessageBox.Show("Sửa món thành công !");
                LoadListProduct();
                //if (updateFood != null)
                //    updateFood(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Sửa công thành công !");
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            LoadListProduct();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            list.DataSource = SearchProductByName(txtSearch.Text);
        }

        private void txtid_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (dtgvProduct.SelectedCells.Count > 0)
                {
                    int id = (int)dtgvProduct.SelectedCells[0].OwningRow.Cells["CategoryID"].Value;


                    Category category = CategoryDAO.Instance.GetCategoryByID(id);

                    cbxcategory.SelectedItem = category;
                    int index = -1;
                    int i = 0;
                    foreach (Category item in cbxcategory.Items)
                    {
                        if (item.ID == category.ID)
                        {
                            index = i;
                            break;
                        }
                        i++;
                    }
                    cbxcategory.SelectedIndex = index;
                }
            }
            catch
            {

            }
        }
    }
}
