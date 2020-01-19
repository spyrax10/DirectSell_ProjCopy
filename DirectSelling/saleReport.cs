using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DirectSelling
{
    public partial class saleReport : Form
    {
        public saleReport()
        {
            InitializeComponent();
        }

        private void saleReport_Load(object sender, EventArgs e)
        {
            saleRpt1.SetParameterValue("paramDate", DateTime.Now.ToLongDateString());
        }

        private void saleReport_FormClosing(object sender, FormClosingEventArgs e)
        {
            adminDash ad = new adminDash();
            ad.Visible = true;
            this.Visible = false;
        }
    }
}
