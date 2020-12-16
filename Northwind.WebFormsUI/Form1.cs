using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Northwind.Business.Abstract;
using Northwind.Business.Concrete;
using Northwind.DataAccess.Concrete.EntityFramework;
using Northwind.DataAccess.Concrete.NHibernate;
using Northwind.Entities.Concrete;

namespace Northwind.WebFormsUI
{
    public partial class Form1 : Form
    {
        private IProductService _productService;
        private ICategoryService _categoryService;
        public Form1()
        {
            InitializeComponent();
            _productService=new ProductManager(new EfProductDal());
            _categoryService=new CategoryManager(new  EfCategoryDal());
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadProducts();
            LoadCategories();
        }

        private void LoadCategories()
        {
            cbxCategory.DataSource = _categoryService.GetAll();
            cbxCategory.DisplayMember = "CategoryName";
            cbxCategory.ValueMember = "CategoryId";

            cbxCategoryId.DataSource = _categoryService.GetAll();
            cbxCategoryId.DisplayMember = "CategoryName";
            cbxCategoryId.ValueMember = "CategoryId";

            cbxCategoryUpdate.DataSource = _categoryService.GetAll();
            cbxCategoryUpdate.DisplayMember = "CategoryName";
            cbxCategoryUpdate.ValueMember = "CategoryId";

        }

        private void LoadProducts()
        {
            dgwProducts.DataSource = _productService.GetAll();
        }

        private void cbxCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                dgwProducts.DataSource = _productService.GetProductsByCategory(Convert.ToInt32(cbxCategory.SelectedValue));
            }
            catch 
            {
               
            }
        
        }

        private void tbxProductName_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(tbxProductName.Text))
            {
                dgwProducts.DataSource = _productService.GetProductsByProductName(tbxProductName.Text, Convert.ToInt32(cbxCategory.SelectedValue));
                // dgwProducts.DataSource = _productService.GetProductsByProductName(tbxProductName.Text);
            }
            else
            {
                dgwProducts.DataSource = _productService.GetProductsByCategory(Convert.ToInt32(cbxCategory.SelectedValue));
                // LoadProducts();
            }
            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                _productService.Add(new Product
                {
                    CategoryID = Convert.ToInt32(cbxCategoryId.SelectedValue),
                    ProductName = tbxProductName2.Text,
                    UnitPrice = Convert.ToDecimal(tbxUnitPrice.Text),
                    QuantityPerUnit = tbxQuantityPerUnit.Text,
                    UnitsInStock = Convert.ToInt16(tbxStockAmount.Text)
                });
                MessageBox.Show("Ürün Eklendi!");
                LoadProducts();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }

          
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                _productService.Update(new Product
                {
                    ProductID = Convert.ToInt32(dgwProducts.CurrentRow.Cells[0].Value),
                    CategoryID = Convert.ToInt32(cbxCategoryUpdate.SelectedValue),
                    ProductName = tbxProductNameUpdate.Text,
                    UnitPrice = Convert.ToDecimal(tbxUnitPriceUpdate.Text),
                    QuantityPerUnit = tbxQuantityPerUnitUpdate.Text,
                    UnitsInStock = Convert.ToInt16(tbxUnitsInStockUpdate.Text)
                });
                MessageBox.Show("Ürün Güncellendi!");
                LoadProducts();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
           
        }

        private void dgwProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var row = dgwProducts.CurrentRow;
            tbxProductNameUpdate.Text = row.Cells[2].Value.ToString();
            cbxCategoryUpdate.Text = row.Cells[1].Value.ToString();
            tbxUnitPriceUpdate.Text = row.Cells[4].Value.ToString();
            tbxQuantityPerUnitUpdate.Text = row.Cells[3].Value.ToString();
            tbxUnitsInStockUpdate.Text = row.Cells[5].Value.ToString();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgwProducts.CurrentRow != null)
                {
                    _productService.Delete(new Product
                    {
                        ProductID = Convert.ToInt32(dgwProducts.CurrentRow.Cells[0].Value),
                    });
                    MessageBox.Show("Ürün Silindi!");
                    LoadProducts();
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }

         
            
          
        }
    }
}
