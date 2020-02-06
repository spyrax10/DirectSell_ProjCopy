using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DirectSelling
{
    public partial class OrderForm : Form
    {
        //string prodcs = @"Data Source=LOCALHOST192\SQL2019;Initial Catalog=sellDB;Integrated Security=True";
        string prodcs = @"Data Source=D8672B6A3F8B574\LOCAL;Initial Catalog=sellDB;Integrated Security=True";
        string councs = @"Data Source=D8672B6A3F8B574\LOCAL;Initial Catalog=countDB;Integrated Security=True";

        string adId = adminDash.cusId;
        SqlDataAdapter adapt;

        public OrderForm()
        {
            InitializeComponent();
        }
        public void clrOrder()
        {
            foreach (Control c in gbNewOrdInfo.Controls)
            {
                if (c is TextBox)
                {
                    c.Text = "";
                }
                if (c is ComboBox)
                {
                    c.Text = null;
                }
            }

            tbOrdId.Text = "";
            tbOrdTot.Text = "";
            lblOrdItem.Text = "0";
            lblOrdId.Text = "00-0000-000";
            numRate.Value = 20;
            gVOrdRec.Rows.Clear();

        }
       
        public void printOrd()
        {
            try
            {
                PrintDocument printDocument2 = new PrintDocument();
                printDocument2.PrintPage += new PrintPageEventHandler(printOrder_PrintPage);
                printDocument2.Print();
                this.BringToFront();
                clrOrder();
            }
            catch (Exception f)
            {
                MessageBox.Show(f.Message, " Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void ordTrans()
        {
            SqlConnection ordTrans = new SqlConnection(prodcs);

            try
            {
                string pre = "ORDTRAN";
                string date = lblOrdDate.Text;
                string time = lblOrdTime.Text;
                string cusId = lblOrdCusID.Text;
                string item = lblOrdItem.Text;
                string total = tbOrdTot.Text;

                if (item == "0" || total == "")
                {
                    return;
                }
                else
                {
                    ordTrans.Open();
                    SqlCommand ord = ordTrans.CreateCommand();
                    ord.CommandType = CommandType.Text;
                    ord.CommandText = "Insert into transOrdTB Values ('" + pre + "', " +
                        "'" + cusId + "', " +
                        "'" + item + "', " +
                        "'" + total + "', " +
                        "'" + date + "', " +
                        "'" + time + "')";
                    ord.ExecuteNonQuery();

                    ord.CommandText = "Select TOP 1 * from transOrdTB Order By transOrdId Desc";
                    SqlDataReader dr = ord.ExecuteReader();

                    if (dr.Read())
                    {
                        tbOrdId.Text = (dr["transOrdId"].ToString());
                    }
                    printOrd();
                    MessageBox.Show("Transaction Complete!", " Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.BringToFront();

                    this.Close();
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, " Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void delNewOrd()
        {
            SqlConnection delCon = new SqlConnection(prodcs);

            try
            {
                string ordId = gVOrdRec.CurrentRow.Cells[0].Value.ToString();

                if (gVOrdRec.Rows.Count != 0)
                {
                    delCon.Open();
                    SqlCommand delCmd = delCon.CreateCommand();
                    delCmd.CommandType = CommandType.Text;
                    delCmd.CommandText = "Delete from ordTB where ordId = '" + ordId + "'";
                    delCmd.ExecuteNonQuery();
                    gVOrdRec.Rows.RemoveAt(this.gVOrdRec.SelectedRows[0].Index);
                    double ordTot = gVOrdRec.Rows.Cast<DataGridViewRow>().Sum(t => Convert.ToDouble(t.Cells[5].Value));
                    int item = gVOrdRec.Rows.Cast<DataGridViewRow>().Sum(t => Convert.ToInt32(t.Cells[1].Value));
                    tbOrdTot.Text = ordTot.ToString();
                    lblOrdItem.Text = item.ToString();

                }
                else
                {
                    lblOrdItem.Text = "0";
                    tbOrdTot.Text = "";
                    MessageBox.Show("Data Empty!", " Empty", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            catch (Exception e)
            {
                MessageBox.Show("Missing Data!", " Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void newOrder()
        {
            SqlConnection ordNew = new SqlConnection(prodcs);

            try
            {
                string distrib = cbOrdComp.Text; string name = tbOrdName.Text;
                string cat = cbOrdCat.Text; string col = tbOrdInfo.Text;
                string month = cbOrdMonth.Text; string size = tbOrdSize.Text;
                string page = tbOrdPage.Text; string qty = tbOrdQty.Text;
                string brand = tbOrdBrand.Text; string srp = tbOrdSrp.Text;

                string ordStat = "PENDING";
                string recv = "-----";
                string cusId = lblOrdCusID.Text;
                string pre = "ORD";
                string date = DateTime.Now.ToShortDateString();
                string profit = numRate.Value.ToString();
                double pro = Double.Parse(profit) / 100;
                double tot = Double.Parse(qty) * Double.Parse(srp);
                string total = tot.ToString();

                if (distrib == "" || cat == "" || month == "" || page == "" || brand == "" ||
                    name == "" || col == "" || size == "" || qty == "" || srp == "")
                {
                    MessageBox.Show("Input Missing Boxes!", " Incomplete", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    ordNew.Open();
                    SqlCommand ordCmd = ordNew.CreateCommand();
                    ordCmd.CommandType = CommandType.Text;
                    ordCmd.CommandText = "Insert into ordTB Values ('" + pre + "', " +
                        "'" + cusId + "', " +
                        "'" + distrib + "', " +
                        "'" + cat + "', " +
                        "'" + month + "', " +
                        "'" + page + "', " +
                        "'" + brand + "', " +
                        "'" + name + "', " +
                        "'" + col + "', " +
                        "'" + size + "', " +
                        "'" + qty + "', " +
                        "'" + srp + "', " +
                        "'" + pro + "', " +
                        "'" + total + "', " +
                        "'" + date + "', " +
                        "'" + recv + "', " +
                        "'" + ordStat + "')";
                    ordCmd.ExecuteNonQuery();

                    ordCmd.CommandText = "Select TOP 1 * from ordTB Order By ordId Desc";
                    SqlDataReader dr = ordCmd.ExecuteReader();

                    if (dr.Read())
                    {
                        lblOrdId.Text = (dr["ordId"].ToString());
                    }
                    ordNew.Close();

                    gVOrdRec.Rows.Add(lblOrdId.Text, qty, brand, name, srp, total);
                    double ordTot = gVOrdRec.Rows.Cast<DataGridViewRow>().Sum(t => Convert.ToDouble(t.Cells[5].Value));
                    int item = gVOrdRec.Rows.Cast<DataGridViewRow>().Sum(t => Convert.ToInt32(t.Cells[1].Value));
                    tbOrdTot.Text = ordTot.ToString();
                    lblOrdItem.Text = item.ToString();

                    btnOrdDel.Visible = true;
                    tbOrdQty.Text = "";
                    lblOrdId.Text = "00-0000-000";
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, " Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void printOrder_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            try
            {
                Bitmap bmp = new Bitmap(paneReceipt.Width, paneReceipt.Height);
                Rectangle rect = new Rectangle(0, 0, paneReceipt.Width, paneReceipt.Height);
                paneReceipt.DrawToBitmap(bmp, rect);
                Clipboard.SetImage(bmp);
                e.Graphics.DrawImage(bmp, 150, 15);

            }
            catch (Exception f)
            {
                MessageBox.Show(f.Message, " Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OrderForm_Load(object sender, EventArgs e)
        {
            clrOrder();
            lblOrdDate.Text = DateTime.Now.ToShortDateString();
            lblOrdTime.Text = DateTime.Now.ToLongTimeString();
            lblOrdCusID.Text = adId;
        }

        private void btnAddOrd_Click(object sender, EventArgs e)
        {
            newOrder();
        }

        private void btnOrdDel_Click(object sender, EventArgs e)
        {
            delNewOrd();
        }

        private void btnOrdCon_Click(object sender, EventArgs e)
        {
            ordTrans();
        }

        private void btnCashBack_Click(object sender, EventArgs e)
        {
            adminDash ad = new adminDash();
            ad.gVBal.Refresh();
            ad.gVBalDet.Refresh();
            ad.gVPenOrd.Refresh();
            this.Close();
        }

        private void tbOrdBrand_Leave(object sender, EventArgs e)
        {
            var tb = (TextBox)sender;
            if (tb.Text.Length > 0)
            {
                tb.Text = Char.ToUpper(tb.Text[0]) + tb.Text.Substring(1);
            }
        }

        private void cbOrdComp_KeyPress(object sender, KeyPressEventArgs e)
        {
            MessageBox.Show("Please select from Selection!", " Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
            e.Handled = true;
        }
    }
}
