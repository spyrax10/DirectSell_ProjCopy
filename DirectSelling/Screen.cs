using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DirectSelling
{
    
    public partial class Screen : Form
    {
        int move = 0;
        int left = 5;
        double x = 0;
        int y = 0;

        SqlDataAdapter adapt;
        public static string Id;

        string prodcs = @"Data Source=D8672B6A3F8B574\LOCAL;Initial Catalog=sellDB;Integrated Security=True";
        string councs = @"Data Source=D8672B6A3F8B574\LOCAL;Initial Catalog=countDB;Integrated Security=True";


        public Screen()
        {
            InitializeComponent();
            
        }
        public void clrCash()
        {
            foreach (Control c  in paneRec.Controls)
            {
                if (c is TextBox)
                {
                    c.Text = "";
                }
            }
         
            foreach (Control d in gbCashOrdInfo.Controls)
            {
                if (d is TextBox)
                {
                    d.Text = "";
                }
            }
            lblCashItems.Text = "0";
            
            gVRec.Update();
            gVRec.Refresh();
            gVRec.Rows.Clear();
            tbSerCash.Text = "Search Here";
            tbSerCash.ForeColor = Color.Gray;
        }
        public void cusOrdId()
        {
            SqlConnection cusCon = new SqlConnection(prodcs);

            try
            {
                cusCon.Open();
                SqlCommand cusCmd = cusCon.CreateCommand();
                cusCmd.CommandType = CommandType.Text;
                cusCmd.CommandText = "Select * from cusTB where cusId = '" + tbOrdCusID.Text + "'";
                SqlDataReader dr = cusCmd.ExecuteReader();

                if (dr.Read())
                {
                    Id = tbOrdCusID.Text;

                    string first = (dr["Firstname"].ToString());
                    string mid = (dr["Midname"].ToString());
                    string last = (dr["Lastname"].ToString());
                    MessageBox.Show("Customer Found!", " Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (MessageBox.Show("Customer Name: " + last + ", " + first + " " + mid + " ... Continue?", " Verify", 
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        Order ord = new Order();
                        ord.ShowDialog();
                        tbOrdCusID.Text = "";
                    }
                    else
                    {
                        return;
                    }               
                }
                else
                {
                    MessageBox.Show("Customer not Found!", " Invalid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, " Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void searchCash()
        {
            SqlConnection serCon = new SqlConnection(prodcs);
            string value = tbSerCash.Text;

            try
            {
                serCon.Open();
                DataTable dt = new DataTable();
                adapt = new SqlDataAdapter("Select prodId as ProdID, Brand as Distributor, Name as Brand, Info as Name, Qty As Remaining from newprodTB " +
                    "where prodId LIKE '%" + value + "%' OR Info LIKE '%" + value + "%' and  Qty != '0' Order by prodId ASC", serCon);
                adapt.Fill(dt);
                gVCash.DataSource = dt;
                serCon.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, " Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        public void printOrdCash()
        {
            try
            {
                PrintDocument printDocument2 = new PrintDocument();
                printDocument2.PrintPage += new PrintPageEventHandler(printCash_PrintPage);
                printDocument2.Print();
                this.BringToFront();
                tbOrdId.Text = "";
                lblResCusID.Text = "00000";
                gVRec.Rows.Clear();
                lblCashItems.Text = "0";
                tbOrdCash.Text = "";
                tbOrdChange.Text = "";
                tbOrdTot.Text = "";

            }
            catch (Exception f)
            {
                MessageBox.Show(f.Message, " Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }      
     
        public void credit()
        {
            SqlConnection findCon = new SqlConnection(prodcs);
            SqlConnection ordCon = new SqlConnection(prodcs);
            SqlConnection balCon = new SqlConnection(prodcs);
            SqlConnection saleCon = new SqlConnection(prodcs);
            SqlConnection delCon = new SqlConnection(prodcs);

            try
            {
                string pre = "ORD";
                string spre = "SLE";
                string prodId = lblCusProdID.Text;
                string cusId = lblCusID.Text;
                string distrib = tbCusDistrib.Text;
                string cat = tbCusCat.Text;
                int nmonth = DateTime.Now.Month;
                string month = new DateTimeFormatInfo().GetMonthName(nmonth);
                string page = "-----";
                string brand = tbCusBrand.Text;
                string name = tbCusName.Text;
                string color = tbCusInfo.Text;
                string size = tbCusSize.Text;
                string srp = tbCusSRP.Text;
                string qty = tbCusQty.Text;
                string date = DateTime.Now.ToShortDateString();
                DateTime newDate = DateTime.Parse(date);
                string deadline = newDate.AddMonths(1).ToShortDateString();
                string ordStat = "RECEIVED";
                string payId = "-----";

                double zQty = Double.Parse(lblCusRem.Text) - Double.Parse(tbCusQty.Text);
                string upQty = zQty.ToString();

                findCon.Open();
                SqlCommand findCmd = findCon.CreateCommand();
                findCmd.CommandType = CommandType.Text;
                findCmd.CommandText = "Select * from newprodTB where prodId = '" + prodId + "'";
                SqlDataReader dr = findCmd.ExecuteReader();

                if (dr.Read())
                {
                    string rate = (dr["Rate"].ToString());

                    double tot = Double.Parse(qty) * Double.Parse(srp);
                    string total = tot.ToString();

                   
                    ordCon.Open();
                    SqlCommand ordCmd = ordCon.CreateCommand();
                    ordCmd.CommandType = CommandType.Text;
                    ordCmd.CommandText = "Insert into ordTB Values ('" + pre + "', " +
                        "'" + cusId + "', " +
                        "'" + distrib + "', " +
                        "'" + cat + "', " +
                        "'" + month + "', " +
                        "'" + page + "', " +
                        "'" + brand + "', " +
                        "'" + name + "', " +
                        "'" + color + "', " +
                        "'" + size + "', " +
                        "'" + qty + "', " +
                        "'" + srp + "', " +
                        "'" + rate + "', " +
                        "'" + total + "', " +
                        "'" + date + "', " +
                        "'" + date + "', " +
                        "'" + ordStat + "')";
                    ordCmd.ExecuteNonQuery();
                    ordCmd.CommandText = "Select TOP 1 * from ordTB Order By ordId Desc";
                    SqlDataReader ordDr = ordCmd.ExecuteReader();
                    
                    if(ordDr.Read())
                    {
                        string ordId = (ordDr["ordId"].ToString());

                        balCon.Open();
                        SqlCommand balCmd = balCon.CreateCommand();
                        balCmd.CommandType = CommandType.Text;
                        balCmd.CommandText = "Insert into cusBalTB Values ('" + cusId + "', " +
                            "'" + ordId + "', " +
                            "'" + date + "', " +
                            "'" + date + "', " +
                            "'" + deadline + "', " +
                            "'" + total + "', " +
                            "'" + payId + "')";
                        balCmd.ExecuteNonQuery();
                        balCon.Close();

                        double sprofit = Double.Parse(rate) * Double.Parse(srp) * Double.Parse(qty);
                        string spro = sprofit.ToString();

                        saleCon.Open();
                        SqlCommand saleCmd = saleCon.CreateCommand();
                        saleCmd.CommandType = CommandType.Text;
                        saleCmd.CommandText = "Insert into saleTB Values ('" + spre + "', " +
                            "'" + cusId + "', " +
                            "'" + ordId + "', " +
                            "'" + qty + "', " +
                            "'" + distrib + "', " +
                            "'" + name + "', " +
                            "'" + date + "', " +
                            "'" + month + "', " +
                            "'" + spro + "')";
                        saleCmd.ExecuteNonQuery();
                        saleCon.Close();

                        delCon.Open();
                        SqlCommand delCmd = delCon.CreateCommand();
                        delCmd.CommandType = CommandType.Text;
                        delCmd.CommandText = "Update newprodTB Set Qty = '" + upQty + "' where prodId = '" + prodId + "'";
                        delCmd.ExecuteNonQuery();


                        if ( MessageBox.Show("Credit Added!, Add more?", " Success", 
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            tbCusQty.Text = "";
                            tbCusQty.Focus();
                        }
                        else
                        {
                            gbCashCusCre.Visible = false;
                            gBCusID.Visible = false;
                            btnCre.Visible = false;
                            gbCashOrdInfo.Visible = true;
                        }

                        viewProd();

                    }
                    ordCon.Close();
                }               
                findCon.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, " Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void cashTrans()
        {
            SqlConnection cashCon = new SqlConnection(prodcs);

            string cusId = lblResCusID.Text;
            string item = lblCashItems.Text;
            string ord = tbOrdTot.Text;
            string cash = tbOrdCash.Text;
            string change = tbOrdChange.Text;
            string date = DateTime.Now.ToShortDateString();
            string time = DateTime.Now.ToShortTimeString();
            string pre = "CSH";

            try
            {
                cashCon.Open();
                SqlCommand cashCmd = cashCon.CreateCommand();
                cashCmd.CommandType = CommandType.Text;
                cashCmd.CommandText = "Insert into transCashTB Values ('" + pre + "', " +
                    "'" + cusId + "', " +
                    "'" + item + "', " +
                    "'" + ord + "', " +
                    "'" + cash + "', " +
                    "'" + change + "', " +
                    "'" + date + "', " +
                    "'" + time + "')";
                cashCmd.ExecuteNonQuery();

                cashCmd.CommandText = "Select transCashId from transCashTB where Total = '" + ord + "' " +
                    "and cusId = '" + cusId + "' " +
                    "and Cash = '" + cash + "' " +
                    "and Change = '" + change + "' " +
                    "and Date = '" + date + "'";
                SqlDataReader dr = cashCmd.ExecuteReader();

                if (dr.Read())
                {
                    tbOrdId.Text = (dr["transCashId"].ToString());
                    tbOrdCash.Enabled = false;
                }
                cashCon.Close();
                printOrdCash();
                MessageBox.Show("Print Complete!", " Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.BringToFront();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, " Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void delCashPro()
        {
            SqlConnection delCon = new SqlConnection(prodcs);

            string cusId = lblResCusID.Text;
            string proId = gVRec.CurrentRow.Cells[2].Value.ToString();
            string qty = gVRec.CurrentRow.Cells[1].Value.ToString();
            string name = gVRec.CurrentRow.Cells[3].Value.ToString();
            string date = DateTime.Now.ToShortDateString();
            string saleId = gVRec.CurrentRow.Cells[0].Value.ToString();
            
            try
            {
                delCon.Open();
                SqlCommand delCmd = delCon.CreateCommand();
                delCmd.CommandType = CommandType.Text;
                delCmd.CommandText = "Delete from saleTB where saleId = '" + saleId + "' " +
                    "and cusId = '" + cusId + "' " +
                    "and proId = '" + proId + "' " +
                    "and Qty = '" + qty + "' " +
                    "and Name = '" + name + "' " +
                    "and Date = '" + date + "'";
                   
                delCmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, " Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void addCashPro()
        {
            SqlConnection proCon = new SqlConnection(prodcs);
            SqlConnection rateCon = new SqlConnection(prodcs);


            string pre = "SLE";
            string cusId = lblResCusID.Text;
            string proId = lblCashProdId.Text;
            string comp = tbCashDis.Text;
            string name = tbCashName.Text;
            string date = DateTime.Now.ToShortDateString();

            int nmonth = DateTime.Now.Month;
            string month = new DateTimeFormatInfo().GetMonthName(nmonth);
            string price = tbCashSRP.Text;
            string quan = tbCashQty.Text;


            try
            {
               
                    rateCon.Open();
                    SqlCommand rateCmd = rateCon.CreateCommand();
                    rateCmd.CommandType = CommandType.Text;
                    rateCmd.CommandText = "Select Rate from newprodTB where prodId = '" + proId + "'";
                    SqlDataReader dr = rateCmd.ExecuteReader();

                    if (dr.Read())
                    {
                        string rate = (dr["Rate"].ToString());
                        double profit = Double.Parse(rate) * Double.Parse(price) * Double.Parse(quan);
                        string pro = profit.ToString();

                        proCon.Open();
                        SqlCommand proCmd = proCon.CreateCommand();
                        proCmd.CommandType = CommandType.Text;
                        proCmd.CommandText = "Insert into saleTB Values ('" + pre + "', " +
                            "'" + cusId + "', " +
                            "'" + proId + "', " +
                            "'" + quan + "', " +
                            "'" + comp + "', " +
                            "'" + name + "', " +
                            "'" + date + "', " +
                            "'" + month + "', " +
                            "'" + pro + "')";
                        proCmd.ExecuteNonQuery();

                    
                        proCmd.CommandText = "Select TOP 1 * from saleTB Order By saleId Desc";
                        SqlDataReader dr2 = proCmd.ExecuteReader();

                        if (dr2.Read())
                        {
                            lblSaleID.Text = (dr2["saleId"].ToString());
                        }

                    }
                    rateCon.Close();
                              
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, " Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void addProdQty()
        {
            SqlConnection delCon = new SqlConnection(prodcs);
            SqlConnection serCon = new SqlConnection(prodcs);

            try
            {
                string prodId = gVRec.CurrentRow.Cells[2].Value.ToString();
                string qty = gVRec.CurrentRow.Cells[1].Value.ToString();
                
                serCon.Open();
                SqlCommand serCmd = serCon.CreateCommand();
                serCmd.CommandType = CommandType.Text;
                serCmd.CommandText = "Select Qty from newprodTB where prodId = '" + prodId + "'";
                SqlDataReader dr = serCmd.ExecuteReader();

                if (dr.Read())
                {
                    string rem = (dr["Qty"].ToString());
                    double upQty = Double.Parse(rem) + Double.Parse(qty);

                    delCon.Open();
                    SqlCommand delCmd = delCon.CreateCommand();
                    delCmd.CommandType = CommandType.Text;
                    delCmd.CommandText = "Update newprodTB Set Qty = '" + upQty + "' where prodId = '" + prodId + "'";
                    delCmd.ExecuteNonQuery();
                    delCon.Close();
                    viewProd();

                    foreach (Control d in gbCashOrdInfo.Controls)
                    {
                        if (d is TextBox)
                        {
                            d.Text = "";
                        }
                    }
                    lblCashProdId.Text = "00-0000-000";
                    lblQtyRem.Text = "0";
                }
                serCon.Close();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, " Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void delProdQty()
        {
            SqlConnection delCon = new SqlConnection(prodcs);
            SqlConnection verCon = new SqlConnection(prodcs);

            string prodId = lblCashProdId.Text;
            double ty = Double.Parse(lblQtyRem.Text) - Double.Parse(tbCashQty.Text);
            string upQty = ty.ToString();

            try
            {
                
                delCon.Open();
                SqlCommand delCmd = delCon.CreateCommand();
                delCmd.CommandType = CommandType.Text;
                delCmd.CommandText = "Update newprodTB Set Qty = '" + upQty + "' where prodId = '" + prodId + "'";
                delCmd.ExecuteNonQuery();
                delCon.Close();
                viewProd();

                verCon.Open();
                SqlCommand verCmd = verCon.CreateCommand();
                verCmd.CommandType = CommandType.Text;
                verCmd.CommandText = "Select Qty from newprodTB where prodId = '" + lblCashProdId.Text + "'";
                SqlDataReader dr = verCmd.ExecuteReader();

                if (dr.Read())
                {
                    lblQtyRem.Text = (dr["Qty"].ToString());
                }
                verCon.Close();               
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, " Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        public void cusId()
        {
            SqlConnection cusCon = new SqlConnection(prodcs);

            try
            {
                cusCon.Open();
                SqlCommand cusCmd = cusCon.CreateCommand();
                cusCmd.CommandType = CommandType.Text;
                cusCmd.CommandText = "Select * from cusTB where cusId = '" + tbCusID.Text + "'";
                SqlDataReader dr = cusCmd.ExecuteReader();

                if (dr.Read())
                {
                    string first = (dr["Firstname"].ToString());
                    string mid = (dr["Midname"].ToString());
                    string last = (dr["Lastname"].ToString());

                    MessageBox.Show("Customer Found!", " Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (MessageBox.Show("Customer Name: " + last + ", " + first + " " + mid + " ... Continue?", " Verify",
                       MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        lblCusID.Text = tbCusID.Text;
                        gBCusID.Visible = false;
                        gbCashCusCre.Visible = true;
                    }
                    else
                    {
                        return;
                    }
          
                }
                else
                {
                    if (MessageBox.Show("ID Not Found, Add New Customer? ",
                         "Warning",
                          MessageBoxButtons.YesNo,
                          MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        lblResCusID.Text = tbCusID.Text;
                        tbCusID.Text = "";
                        adminDash ad = new adminDash();
                        ad.Show();
                        this.Visible = false;
                    }
                    else
                    {
                        return;
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, " Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void removeProd()
        {
            if (gVRec.Rows.Count != 0)
            {
                addProdQty();
                delCashPro();
                gVRec.Rows.RemoveAt(this.gVRec.SelectedRows[0].Index);
                int itemTot = gVRec.Rows.Cast<DataGridViewRow>().Sum(t => Convert.ToInt32(t.Cells[1].Value));
                double priceTot = gVRec.Rows.Cast<DataGridViewRow>().Sum(t => Convert.ToDouble(t.Cells[5].Value));
                lblCashItems.Text = itemTot.ToString();
                tbOrdTot.Text = priceTot.ToString();
            }
           
            else
            {
                lblCashItems.Text = "0";
                tbOrdTot.Text = "";
                MessageBox.Show("Data Empty!", " Empty", MessageBoxButtons.OK, MessageBoxIcon.Warning);              
            }
        }
          
        public void addCart()
        {
           
            try
            {
                string prodId = lblCashProdId.Text;
                string name = tbCashName.Text;
                string qty = tbCashQty.Text;
                string srp = tbCashSRP.Text;
                string pqty = gVCash.CurrentRow.Cells[4].Value.ToString();
                string saleId = lblSaleID.Text;

                if (tbCashQty.Text == "" || name == "")
                {
                    MessageBox.Show("Missing Data!", " Empty", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    int cqty = Int32.Parse(qty);
                    int cpqty = Int32.Parse(pqty);
                    double total = double.Parse(qty) * double.Parse(srp);

                    if (cqty > cpqty)
                    {
                        MessageBox.Show("Not enough stocks!", " Invalid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        tbCashQty.Text = "";
                        tbCashQty.Focus();
                    }
                    else
                    {
                        addCashPro();
                        gVRec.Rows.Add(lblSaleID.Text, cqty, prodId, name, srp, total);
                        int itemTot = gVRec.Rows.Cast<DataGridViewRow>().Sum(t => Convert.ToInt32(t.Cells[1].Value));
                        double priceTot = gVRec.Rows.Cast<DataGridViewRow>().Sum(t => Convert.ToDouble(t.Cells[5].Value));
                        lblCashItems.Text = itemTot.ToString();
                        tbOrdTot.Text = priceTot.ToString();
                        delProdQty();       
                        btnDel.Visible = true;
                        tbCashQty.Text = "";
                        lblSaleID.Text = "";
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Missing Data!!!", " Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbCashQty.Text = "";
            }
        }
        public void cellCash()
        {
            SqlConnection cellCon = new SqlConnection(prodcs);
            string prodId = gVCash.CurrentRow.Cells[0].Value.ToString();
            
            try
            {
                if (gVCash.Rows.Count == 0)
                {
                    MessageBox.Show("Data Empty", " Empty", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    cellCon.Open();
                    SqlCommand cellcmd = cellCon.CreateCommand();
                    cellcmd.CommandType = CommandType.Text;
                    cellcmd.CommandText = "Select * from newprodTB where prodId = '" + prodId + "'";
                    SqlDataReader dr = cellcmd.ExecuteReader();

                    if (dr.Read())
                    {
                        lblCashProdId.Text = prodId;
                        tbCashDis.Text = (dr["Brand"].ToString());
                        tbCashCat.Text = (dr["Cat"].ToString());
                        tbCashBrand.Text = (dr["Name"].ToString());
                        tbCashName.Text = (dr["Info"].ToString());
                        tbCashInfo.Text = (dr["Cor"].ToString());
                        lblQtyRem.Text = (dr["Qty"].ToString());
                        tbCashSize.Text = (dr["Size"].ToString());
                        tbCashSRP.Text = (dr["SRP"].ToString());

                        lblCusProdID.Text = prodId;
                        tbCusDistrib.Text = (dr["Brand"].ToString());
                        tbCusCat.Text = (dr["Cat"].ToString());
                        tbCusBrand.Text = (dr["Name"].ToString());
                        tbCusName.Text = (dr["Info"].ToString());
                        tbCusInfo.Text = (dr["Cor"].ToString());
                        lblCusRem.Text = (dr["Qty"].ToString());
                        tbCusSize.Text = (dr["Size"].ToString());
                        tbCusSRP.Text = (dr["SRP"].ToString());

                        tbCashQty.Text = "";
                        tbCashQty.Focus();
                        tbCusQty.Text = "";
                        tbCusQty.Focus();

                    }
                }
                cellCon.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, " Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
      
        public void viewProd()
        {
            SqlConnection viewCon = new SqlConnection(prodcs);

            try
            {
                viewCon.Open();
                DataTable dt = new DataTable();
                adapt = new SqlDataAdapter("Select prodId as ProdID, Brand as Distributor, Name as Brand, Info as Name, Qty As Remaining from newprodTB where Qty != '0' Order by prodId ASC", viewCon);
                adapt.Fill(dt);
                gVCash.DataSource = dt;
                viewCon.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, " Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Screen_Load(object sender, EventArgs e)
        {
            timer1.Start();
            timer2.Start();
            lblDateCash.Text = DateTime.Now.ToShortDateString();
            gBTrans.Visible = false;
            paneCash.Visible = false;
            btnShut.Visible = false;
            gbOrdCusId.Visible = false;
            viewProd();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            paneSlide.Left += 2;

            if (paneSlide.Left > 390)
            {
                paneSlide.Left = 0;
            }
            if (paneSlide.Left < 0)
            {
                move = 2;
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            try
            {
                left--;

                if (left == 0)
                {
                    timer1.Stop();
                    timer2.Stop();
                    paneLogo.Visible = false;
                    gbOrdCusId.Visible = false;
                    gBTrans.Visible = true;
                    btnShut.Visible = true;
                            
                }
            }
            catch (Exception f)
            {
                MessageBox.Show(f.Message);
            }
        }

        private void btnHome_Click(object sender, EventArgs e)
        {     
             adminDash ad = new adminDash();
             ad.Show();
             this.Visible = false;
        }

        private void btnCash_Click(object sender, EventArgs e)
        {
            btnShut.Visible = false;
            gBTrans.Visible = false;
            gBCusID.Visible = false;
            gbCashCusCre.Visible = false;

            gbCashOrdInfo.Visible = true;
            btnDel.Visible = false;        
            btnCre.Visible = false;
            tbCusID.Text = "";
            clrCash();
            paneCash.Visible = true;    
        }

        private void btnShut_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("This would make application close, Continue?", " Confirm", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
               
                Application.Exit();
            }
            else
            {
                return;
            }
        }
        private void btnCashBack_Click(object sender, EventArgs e)
        {
            paneCash.Visible = false;
            paneLogo.Visible = true;
            left = 5;
            timer1.Start();
            timer2.Start();
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            lblTimeCash.Text = DateTime.Now.ToLongTimeString();
        }

        private void gVCash_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cellCash();
           
            if (gBCusID.Visible == true || gbCashCusCre.Visible == true)
            {
                gbCashOrdInfo.Visible = false;
                btnCre.Visible = false;
            }
            else
            {
                gbCashOrdInfo.Visible = true;
                btnCre.Visible = true;
            }       
        }
        private void btnCashAddOrd_Click(object sender, EventArgs e)
        {
            addCart();
          
        }

        private void btnCusIDCont_Click(object sender, EventArgs e)
        {
            if (tbCusID.Text == "")
            {
                MessageBox.Show("ID Empty!", " Empty", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                cusId();
            }          
        }
        private void btnDel_Click(object sender, EventArgs e)
        {
            removeProd();
        }

        private void tbCashQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.Handled = Char.IsWhiteSpace(e.KeyChar) ||
                Char.IsLetter(e.KeyChar) ||
                Char.IsSymbol(e.KeyChar) ||
                Char.IsPunctuation(e.KeyChar) ||
                Char.IsSeparator(e.KeyChar))
            {
                MessageBox.Show("Invalid Character!", " Numbers Only", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void tbOrdCash_KeyPress(object sender, KeyPressEventArgs e)
        {
                   
            if (e.KeyChar == (char)Keys.Enter)
            {
                double tot = Double.Parse(tbOrdTot.Text);
                double cash = Double.Parse(tbOrdCash.Text);

                if (cash < tot)
                {
                   MessageBox.Show("Not Enough Money!", " Insufficient Cash", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (tbOrdCash.Text == "0")
                {
                    MessageBox.Show("Input Cash!", " Insufficient Cash", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    double dif = cash - tot;
                    tbOrdChange.Text = dif.ToString();

                    foreach (Control d in gbCashOrdInfo.Controls)
                    {
                        if (d is TextBox)
                        {
                            d.Text = "";
                        }
                    }
                    lblCashProdId.Text = "00-0000-000";
                    lblQtyRem.Text = "0";
                    tbOrdCash.Enabled = false;
                    if (MessageBox.Show("Transaction Complete, Do you want to print copy?", " Verify", 
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        cashTrans();
                    }
                    else
                    {
                        tbOrdId.Text = "";
                        lblResCusID.Text = "00000";
                        gVRec.Rows.Clear();
                        lblCashItems.Text = "0";
                        tbOrdCash.Text = "";
                        tbOrdChange.Text = "";
                        tbOrdTot.Text = "";
                    }
                }
            }
            else if (e.Handled = Char.IsWhiteSpace(e.KeyChar) ||
                                 Char.IsLetter(e.KeyChar) ||
                                 Char.IsSymbol(e.KeyChar) ||
                                 Char.IsPunctuation(e.KeyChar))        
            {   
                MessageBox.Show("Invalid Character!", " Numbers Only", MessageBoxButtons.OK, MessageBoxIcon.Warning); 
            }
        }
         
        private void printCash_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            
            try
            {                 
                Bitmap bmp = new Bitmap(paneRec.Width, paneRec.Height);
                Rectangle rect = new Rectangle(0, 0, paneRec.Width, paneRec.Height);
                paneRec.DrawToBitmap(bmp, rect);
                Clipboard.SetImage(bmp);
                e.Graphics.DrawImage(bmp, 150, 15);
               
            }
            catch (Exception f)
            {
                MessageBox.Show(f.Message, " Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void tbSerCash_Click(object sender, EventArgs e)
        {
            tbSerCash.Text = "";
            tbSerCash.ForeColor = Color.Black;
            
        }

        private void tbSerCash_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                searchCash();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            viewProd();
            tbSerCash.Text = "Search Here";
            tbSerCash.ForeColor = Color.Gray;
            clrCash();
        }

        private void btnoOd_Click(object sender, EventArgs e)
        {          
            gBTrans.Visible = false;
            btnCashBack.Visible = false;
            lblAvail.Visible = false;
            tbSerCash.Visible = false;
            gVCash.Visible = false;
            paneRec.Visible = false;
            gBCusID.Visible = false;
            gbCashCusCre.Visible = false;
            gbCashOrdInfo.Visible = false;
            btnDel.Visible = false;
            btnRe.Visible = false;
            btnCre.Visible = false;
            paneCash.Visible = true;
            gbOrdCusId.Visible = true;
        }
  

        private void btnOrdHome_Click_1(object sender, EventArgs e)
        {     
            adminDash ad = new adminDash();
            ad.Show();
            this.Visible = false;
        }

        private void tbOrdCusID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {            
                cusOrdId();      
            }
        }

        private void btnCre_Click(object sender, EventArgs e)
        {
            btnShut.Visible = false;
            gBTrans.Visible = false;
            gBCusID.Visible = true;
            gbCashCusCre.Visible = false;
            gbCashOrdInfo.Visible = false;
            btnCre.Visible = false;
        }

        private void btnCusCon_Click(object sender, EventArgs e)
        {
            int rem = Int32.Parse(lblCusRem.Text);
            int qty = Int32.Parse(tbCusQty.Text);

            if (tbCusQty.Text == "")
            {
                MessageBox.Show("Missing Data!", " Empty", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (qty > rem)
                {
                    MessageBox.Show("Not enough stocks!", " Invalid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tbCashQty.Text = "";
                    tbCashQty.Focus();
                }
                else
                {
                    credit();
                }
            }      
        }

        private void button1_Click(object sender, EventArgs e)
        {
            gbCashOrdInfo.Visible = true;
            gBCusID.Visible = false;
        }

        private void tbCusID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                cusId();
            }
        }
    }
}
