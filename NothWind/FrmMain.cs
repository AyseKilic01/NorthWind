using NothWind.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NothWind
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }
        void List()
        {
            using (NorthWindContext context = new NorthWindContext())
            {
                dgwProduct.DataSource = context.Products.ToList();
                dgwProduct.Columns[0].Visible = false;
                dgwProduct.Columns[1].Visible = false;
                dgwProduct.Columns[2].HeaderText = "Ürün Adı";

            }
        }
        void List(int categoryId)
        {
            using (NorthWindContext context = new NorthWindContext())
            {
                dgwProduct.DataSource = context.Products.Where(x=>x.CategoryID == categoryId).ToList();
                
            }
        }
        void List(string productName, int categoryID)
        {
            using (NorthWindContext context = new NorthWindContext())
            {
                //to avoid being affected by case sensitivity.
                dgwProduct.DataSource = context.Products.Where(x => x.ProductName.ToLower().Contains(productName.ToLower()) && x.CategoryID == categoryID).ToList();

            }
        }
        void ConfigureCombos()
        {
            using (NorthWindContext context = new NorthWindContext())
            {
                cmbCategory.DataSource = context.Categories.ToList();
                cmbCategory.DisplayMember = "CategoryName";
                cmbCategory.ValueMember = "CategoryID";

            }
        }
        private void FrmMain_Load(object sender, EventArgs e)
        {
            List();
            ConfigureCombos();
        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            try {
                List(Convert.ToInt32(cmbCategory.SelectedValue));
            }
            catch
            {

            }
            }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            // if(txtSearch.Text != "" && txtSearch.Text != null)
            //you can use the one below instead.
            string key = txtSearch.Text;
            if (string.IsNullOrEmpty(key))
            {
                List();
            }
            else
            {
                List(txtSearch.Text,Convert.ToInt32(cmbCategory.SelectedValue));
            }
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = new DialogResult();
            result = MessageBox.Show("Devam etmek istiyor musunuz ?", "Uyarı", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {
                e.Cancel = true;
            }
        }
    }
}
