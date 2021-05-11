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
    }
}
