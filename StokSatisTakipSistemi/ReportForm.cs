using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LogicLayer;
namespace StokSatisTakipSistemi
{
    public partial class ReportForm : Form
    {
        LogicOrder logicOrder = new LogicOrder();
        public ReportForm()
        {
            InitializeComponent();
        }

        private void ReportForm_Load(object sender, EventArgs e)
        {
            lbltotal.Text = logicOrder.GetToplamCiro().ToString("C2");
            lblgunluk.Text = logicOrder.GetGunlukCiro().ToString("C2");
            lblurun.Text = logicOrder.GetEnCokSatilanUrun();

            dataGridView4.DataSource = logicOrder.GetAll();
            dataGridView4.ReadOnly = true;
            dataGridView4.AllowUserToAddRows = false;
        }
    }
}
