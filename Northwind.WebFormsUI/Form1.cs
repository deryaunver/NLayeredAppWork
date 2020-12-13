using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Northwind.Business.Concrete;

namespace Northwind.WebFormsUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        ProductManager _productManager= new ProductManager();
        private void Form1_Load(object sender, EventArgs e)
        {
            dgwProducts.DataSource = _productManager.GetAll();
        }
    }
}
