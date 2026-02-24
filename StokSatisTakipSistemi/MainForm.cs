using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StokSatisTakipSistemi
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnUrun_Click(object sender, EventArgs e)
        {
            ProductForm fr = new ProductForm();
            fr.Show();
            this.Hide();
        }

        private void btnMusteri_Click(object sender, EventArgs e)
        {

            CustomerForm fr = new CustomerForm();
            fr.Show();
            this.Hide();
        }

        private void btnSatis_Click(object sender, EventArgs e)
        {
            SalesForm fr = new SalesForm();
            fr.Show();
            this.Hide();
        }

        private void btnRapor_Click(object sender, EventArgs e)
        {
            ReportForm fr = new ReportForm();
            fr.Show();
            this.Hide();
        }
    }
}
