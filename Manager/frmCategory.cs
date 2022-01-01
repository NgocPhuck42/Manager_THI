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
    public partial class frmCategory : Form
    {
        BindingSource category = new BindingSource();

        public frmCategory()
        {
            InitializeComponent();
            dtgvCategory.DataSource = category;
            LoadListCategory();
            AddCategoryBinding();
            dtgvCategory.Columns[0].HeaderText = "Mã loại";
            dtgvCategory.Columns[1].HeaderText = "Tên loại";
        }

        void LoadListCategory()
        {
            category.DataSource = CategoryDAO.Instance.GetListCategory();
            
        }

        void AddCategoryBinding()
        {
            txbID.DataBindings.Add(new Binding("Text", dtgvCategory.DataSource, "id", true, DataSourceUpdateMode.Never));
            txbName.DataBindings.Add(new Binding("Text", dtgvCategory.DataSource, "name", true, DataSourceUpdateMode.Never));
        }

        void AddCategory(string name)
        {
            if (CategoryDAO.Instance.InsertCategory(name))
            {
                MessageBox.Show("Thêm loại thành công");
            }
            else
            {
                MessageBox.Show("Thêm loại thất bại");
            }
            LoadListCategory();
        }

        void UpdateCategory(int id, string name)
        {
            if (CategoryDAO.Instance.UpdateCategory(id, name))
            {
                MessageBox.Show("Cập nhật loại thành công");
            }
            else
            {
                MessageBox.Show("Cập nhật loại thất bại");
            }
            LoadListCategory();
        }

        void DeleteCategory(int id)
        {
            if (CategoryDAO.Instance.DeleteCategory(id))
            {
                MessageBox.Show("Xóa loại thành công");
            }
            else
            {
                MessageBox.Show("Xóa loại thất bại");
            }
            LoadListCategory();
        }

        List<Category> SearchCategoryByName(string namecc)
        {
            List<Category> list = CategoryDAO.Instance.SearchCategoryByName(namecc);

            return list;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var name = txbName.Text.Trim();

            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Vui lòng nhập tên loại sản phẩm cần thêm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;

            }
            AddCategory(name);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txbID.Text);
            var name = txbName.Text.Trim();

            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Vui lòng nhập tên loại sản phẩm cần cập nhật", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;

            }
            UpdateCategory(id,name);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txbID.Text);
            DeleteCategory(id);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var tenloai = txbName.Text.Trim();


            if (string.IsNullOrEmpty(tenloai))
            {
                MessageBox.Show("Vui lòng nhập tên loại CD cần tìm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                LoadListCategory();
                return;

            }
            dtgvCategory.DataSource = SearchCategoryByName(tenloai);
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            LoadListCategory();
           // AddCategoryBinding();
        }
    }
}
