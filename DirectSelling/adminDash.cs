using DGVPrinterHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace DirectSelling
{
    public partial class adminDash : Form
    {
        string prodcs = @"Data Source=D8672B6A3F8B574\LOCAL;Initial Catalog=sellDB;Integrated Security=True";
        string councs = @"Data Source=D8672B6A3F8B574\LOCAL;Initial Catalog=countDB;Integrated Security=True";

        SqlDataAdapter adapt;
       
        public static string cusId;

        DataGridViewCell ActiveCell = null;


        public adminDash()
        {
            InitializeComponent();
            panelSlide.Height = btnHome.Height;
            panelSlide.Top = btnHome.Top;
           
        }
        public void loadSet()
        {
            SqlConnection loadCon = new SqlConnection(prodcs);

            try
            {
                loadCon.Open();
                SqlCommand setCmd = loadCon.CreateCommand();
                setCmd.CommandType = CommandType.Text;
                setCmd.CommandText = "Select * from setTB";
                SqlDataReader dr = setCmd.ExecuteReader();

                if (dr.Read())
                {
                    tbPCost.Text = (dr["penalCost"].ToString());
                    tbSetUser.Text = (dr["username"].ToString());
                    tbSetPass.Text = (dr["password"].ToString());                 
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, " Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void upSet()
        {
            SqlConnection upCon = new SqlConnection(prodcs);
            string cost = tbPCost.Text;
            string user = tbSetUser.Text;
            string pass = tbSetPass.Text;
            try
            {
                upCon.Open();
                SqlCommand upCmd = upCon.CreateCommand();
                upCmd.CommandType = CommandType.Text;
                upCmd.CommandText = "Update setTB set penalCost = '" + cost + "', " +
                    "username = '" + user + "', " +
                    "password = '" + pass + "'";
                upCmd.ExecuteNonQuery();
                upCon.Close();
                MessageBox.Show("Changes will take affect in the next session..", " Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                paneSet.Visible = false;

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, " Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void orderPrint()
        {
            string date = DateTime.Now.ToLongDateString();
            string time = DateTime.Now.ToLongTimeString();
            try
            {
                if (gVOrdDet.Rows.Count != 0)
                {

                    DGVPrinter printer = new DGVPrinter();
                    printer.Title = "Order List" + Environment.NewLine;
                    printer.SubTitle = "Date Printed: " + date + Environment.NewLine + Environment.NewLine + Environment.NewLine;
                    printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
                    printer.PageNumbers = true;
                    printer.PageNumberInHeader = false;
                    printer.HeaderCellAlignment = StringAlignment.Near;
                    printer.PorportionalColumns = true;
                    printer.Footer = "Time Printed: " + time;
                    printer.PageSettings.Landscape = true;
                    printer.FooterSpacing = 15;
                    printer.PrintSettings.PrintToFile = true;
                    printer.PrintDataGridView(gVOrdDet);

                }
                else
                {
                    return;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, " Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void salePrint()
        {
            string date = DateTime.Now.ToLongDateString();
            string time = DateTime.Now.ToLongTimeString();
            try
            {
                if (gVSales.Rows.Count != 0)
                {

                    DGVPrinter printer = new DGVPrinter();
                    printer.Title = "Sales Report" + Environment.NewLine;
                    printer.SubTitle = "Date Printed: " + date + Environment.NewLine + Environment.NewLine + Environment.NewLine +
                        "Total Sales: " + tbSaleTot.Text + Environment.NewLine + Environment.NewLine + Environment.NewLine;
                    printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
                    printer.PageNumbers = true;
                    printer.PageNumberInHeader = false;
                    printer.PorportionalColumns = true;
                    printer.HeaderCellAlignment = StringAlignment.Near;
                    printer.Footer = "Time Printed: " + time;
                    printer.PageSettings.Landscape = true;
                    printer.FooterSpacing = 15;
                    printer.PrintSettings.PrintToFile = true;
                    printer.PrintDataGridView(gVSales);
                }
                else
                {
                    return;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, " Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void penaltyPrint()
        {
            string date = DateTime.Now.ToLongDateString();
            string time = DateTime.Now.ToLongTimeString();
            try
            {
                if (gVPenal.Rows.Count != 0)
                {

                    DGVPrinter printer = new DGVPrinter();
                    printer.Title = "Penalty Report" + Environment.NewLine;
                    printer.SubTitle = "Date Printed: " + date + Environment.NewLine + Environment.NewLine + Environment.NewLine +
                        "Total Penalty: " + tbPenalTot.Text + Environment.NewLine + Environment.NewLine + Environment.NewLine;
                    printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
                    printer.PageNumbers = true;
                    printer.PageNumberInHeader = false;
                    printer.PorportionalColumns = true;
                    printer.HeaderCellAlignment = StringAlignment.Near;
                    printer.Footer = "Time Printed: " + time;
                    printer.PageSettings.Landscape = true;
                    printer.FooterSpacing = 15;
                    printer.PrintSettings.PrintToFile = true;
                    printer.PrintDataGridView(gVPenal);

                }
                else
                {
                    return;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, " Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void cbSale()
        {
            string month = cbSaleMonth.Text;
            string year = cbSaleYear.Text;
            SqlConnection saleCon = new SqlConnection(prodcs);
            SqlConnection penalCon = new SqlConnection(prodcs);

            try
            {
                saleCon.Open();
                DataTable dt = new DataTable();
                adapt = new SqlDataAdapter("Select Month, cusId as CusID, proId as ProdID, " +
                    "Qty, Comp as Company, Name, Profit from saleTB where Month = '" + month + "' and saleYear = '" + year + "' " +
                    "order by DATEPART(mm,CAST([Month]+ ' 1900' AS DATETIME)) asc", saleCon);
                adapt.Fill(dt);
                gVSales.DataSource = dt;
                saleCon.Close();

                penalCon.Open();
                DataTable dt2 = new DataTable();
                adapt = new SqlDataAdapter("Select ordId as OrdID, cusId as CusID, DateOrd as DateOrdered, DateRecv as DateReceived, DateDead, curBal as CurrentBal, penalDate as DatePenal, penalty as Penalty, newBal as NewBal from penaltyTB " +
                    "where month = '" + month + "' and penalty != 0 order by ordId ASC, Cast (penalDate as DATETIME)", penalCon);
                adapt.Fill(dt2);
                gVPenal.DataSource = dt2;
                penalCon.Close();

                double balTot = gVSales.Rows.Cast<DataGridViewRow>().Sum(t => Convert.ToDouble(t.Cells[6].Value));
                double penalTot = gVPenal.Rows.Cast<DataGridViewRow>().Sum(t => Convert.ToDouble(t.Cells[7].Value));
                tbSaleTot.Text = balTot.ToString();
                tbPenalTot.Text = penalTot.ToString();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, " Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
         public void saleRep()
        {
            SqlConnection saleCon = new SqlConnection(prodcs);
            SqlConnection penalCon = new SqlConnection(prodcs);

            try
            {
                saleCon.Open();
                DataTable dt = new DataTable();
                adapt = new SqlDataAdapter("Select Month, cusId as CusID, proId as ProdID, " +
                    "Qty, Comp as Company, Name, Profit from saleTB order by DATEPART(mm,CAST([Month]+ ' 1900' AS DATETIME)) asc ", saleCon);          
                adapt.Fill(dt);
                gVSales.DataSource = dt;            
                saleCon.Close();
              
                penalCon.Open();
                DataTable dt2 = new DataTable();
                adapt = new SqlDataAdapter("Select ordId as OrdID, cusId as CusID, " +
                    "DateOrd as DateOrdered, DateRecv as DateReceived, DateDead as DueDate, curBal as CurrentBal, penalDate as DatePenal, " +
                    "penalty as Penalty, newBal as NewBal from penaltyTB where penalty != 0 order by ordId ASC, Cast (penalDate as DATETIME) ", penalCon);
                adapt.Fill(dt2);
                gVPenal.DataSource = dt2;
                penalCon.Close();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, " Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }
        public void homeStock()
        {
            SqlConnection homeCon = new SqlConnection(prodcs);

            try
            {
                homeCon.Open();
                DataTable dt = new DataTable();
                adapt = new SqlDataAdapter("Select Qty, Brand as Company, Name as Brand, Info as Name, Cat as Category from newprodTB " +
                    "where Qty != 0 order by prodId ASC", homeCon);
                adapt.Fill(dt);
                gVHomeStock.DataSource = dt;
                homeCon.Close();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, " Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void homeCusInfo()
        {
            SqlConnection cusCon = new SqlConnection(prodcs);
            
            try
            {
                cusCon.Open();
                DataTable dt = new DataTable();
                adapt = new SqlDataAdapter("Select cusId as CusID, SUM(Cast(prodBal as float)) as Balance " +
                    "from cusBalTB group by cusId order by cusId ASC", cusCon);
                adapt.Fill(dt);
                gVHomeCusInfo.DataSource = dt;
                cusCon.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, " Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void homeSale()
        {
            SqlConnection saleCon = new SqlConnection(prodcs);

            try
            {
                saleCon.Open();
                DataTable dt = new DataTable();
                adapt = new SqlDataAdapter("Select Month, SUM(Cast(Profit as float)) as Profit, saleYear as Year from saleTB group by Month, saleYear " +
                    "order by DATEPART(mm,CAST([Month]+ ' 1900' AS DATETIME)) asc", saleCon);
                adapt.Fill(dt);
                gVHomeSale.DataSource = dt;
                saleCon.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, " Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void delZero()
        {
            SqlConnection delCon = new SqlConnection(prodcs);

            try
            {
                delCon.Open();
                SqlCommand cmd = delCon.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Delete from penaltyTB where penalty = 0";
                cmd.ExecuteNonQuery();
                delCon.Close();
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message, " Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void penalty()
        {
            SqlConnection penalCon = new SqlConnection(prodcs);
            SqlConnection insCon = new SqlConnection(prodcs);
            SqlConnection upCon = new SqlConnection(prodcs);
            SqlConnection chkCon = new SqlConnection(prodcs);
            SqlConnection costCon = new SqlConnection(prodcs);
            SqlConnection insert = new SqlConnection(prodcs);
            SqlConnection update = new SqlConnection(prodcs);
            SqlConnection chk = new SqlConnection(prodcs);
            SqlConnection chk2 = new SqlConnection(prodcs);
            SqlConnection chk3 = new SqlConnection(prodcs);
            SqlConnection check2 = new SqlConnection(prodcs);

            string date = DateTime.Now.ToShortDateString();
            int nmonth = DateTime.Now.Month;
            string month = new DateTimeFormatInfo().GetMonthName(nmonth);
            string year = DateTime.Now.Year.ToString();

            try
            {

                costCon.Open();
                SqlCommand costCmd = costCon.CreateCommand();
                costCmd.CommandType = CommandType.Text;
                costCmd.CommandText = "Select * from setTB";
                SqlDataReader dr2 = costCmd.ExecuteReader();

                if (dr2.Read())
                {
                    string pcost = (dr2["penalCost"].ToString());
                    double cost = Double.Parse(pcost);

                    penalCon.Open();
                    DataTable dt = new DataTable();
                    adapt = new SqlDataAdapter("Select * from cusBalTB " +
                        "where ordDead < GETDATE() and prodBal != 0", penalCon);
                    adapt.Fill(dt);

                    foreach (DataRow dr in dt.Rows)
                    {
                        string ordId = (dr["ordId"].ToString());
                        string cusId = (dr["cusId"].ToString());
                        string dueDate = (dr["ordDead"].ToString());
                        string curBal = (dr["prodBal"].ToString());
                        string dateOrd = (dr["DateOrd"].ToString());
                        string dateRecv = (dr["ordRecv"].ToString());


                        chkCon.Open();
                        SqlCommand chkCmd = chkCon.CreateCommand();
                        chkCmd.CommandType = CommandType.Text;
                        chkCmd.CommandText = "Select * from penaltyTB " +
                            "where ordId = '" + ordId + "' and penalty != 0 " +
                            "and penalDate != '" + date + "' " +
                           "and newBal = (Select MAX (CAST(newBal as INT)) from penaltyTB) " +
                           "and curBal = (Select MAX(CAST(curBal as INT)) from penaltyTB)";

                        SqlDataReader cDr = chkCmd.ExecuteReader();

                        if (!cDr.Read())
                        {
                            // new credit:
                            check2.Open();
                            SqlCommand cmd = check2.CreateCommand();
                            cmd.CommandType = CommandType.Text;
                            cmd.CommandText = "Select * from penaltyTB where ordId = '" + ordId + "' ";

                            SqlDataReader drc = cmd.ExecuteReader();

                            if (!drc.Read())
                            {
                                string pen = (cDr["penalDate"].ToString());
                                DateTime due = DateTime.Parse(dueDate);
                                DateTime Ddate = DateTime.Parse(date);
                                double num = (Ddate - due).TotalDays;
                                double penalty = cost * num;
                                double newBal = Double.Parse(curBal) + penalty;
                                string bal = newBal.ToString();


                                chk2.Open();
                                SqlCommand chkmd2 = chk2.CreateCommand();
                                chkmd2.CommandType = CommandType.Text;
                                chkmd2.CommandText = "Select * from penaltyTB where ordId = '" + ordId + "' " +
                                    "and penalDate = '" + date + "' ";

                                SqlDataReader drchk2 = chkmd2.ExecuteReader();

                                if (!drchk2.Read())
                                {
                                    insCon.Open();
                                    SqlCommand insCmd = insCon.CreateCommand();
                                    insCmd.CommandType = CommandType.Text;
                                    insCmd.CommandText = "Insert into penaltyTB Values ('" + month + "', " +
                                        "'" + ordId + "', " +
                                        "'" + cusId + "', " +
                                        "'" + dateOrd + "', " +
                                        "'" + dateRecv + "', " +
                                        "'" + dueDate + "', " +
                                        "'" + curBal + "', " +
                                        "'" + date + "', " +
                                        "'" + penalty.ToString() + "', " +
                                        "'" + bal + "', " +
                                        "'" + year + "')";
                                    insCmd.ExecuteNonQuery();
                                    insCon.Close();

                                    upCon.Open();
                                    SqlCommand upCmd = upCon.CreateCommand();
                                    upCmd.CommandType = CommandType.Text;
                                    upCmd.CommandText = "Update cusBalTB set prodBal = '" + bal + "' " +
                                        "where ordId = '" + ordId + "'";
                                    upCmd.ExecuteNonQuery();
                                    upCon.Close();
                                }
                                chk2.Close();

                            }
                            else
                            {
                                // if ordId is already penalized and app is open in succeding days
                                string dPenal = (drc["penalDate"].ToString());
                                DateTime due = DateTime.Parse(dPenal);
                                DateTime Ddate = DateTime.Parse(date);
                                double num3 = (Ddate - due).TotalDays;

                                double newBal2 = Double.Parse(curBal) + cost;
                                string bal2 = newBal2.ToString();

                                chk3.Open();
                                SqlCommand chkmd3 = chk3.CreateCommand();
                                chkmd3.CommandType = CommandType.Text;
                                chkmd3.CommandText = "Select * from penaltyTB where ordId = '" + ordId + "' " +
                                    "and penalDate = '" + date + "'";
                                SqlDataReader drchk3 = chkmd3.ExecuteReader();

                                if (!drchk3.Read())
                                {
                                    insCon.Open();
                                    SqlCommand insCmd2 = insCon.CreateCommand();
                                    insCmd2.CommandType = CommandType.Text;
                                    insCmd2.CommandText = "Insert into penaltyTB Values ('" + month + "', " +
                                        "'" + ordId + "', " +
                                        "'" + cusId + "', " +
                                        "'" + dateOrd + "', " +
                                        "'" + dateRecv + "', " +
                                        "'" + dueDate + "', " +
                                        "'" + curBal + "', " +
                                        "'" + date + "', " +
                                        "'" + cost.ToString() + "', " +
                                        "'" + bal2 + "', " +
                                        "'" + year + "')";
                                    insCmd2.ExecuteNonQuery();
                                    insCon.Close();

                                    upCon.Open();
                                    SqlCommand upCmd2 = upCon.CreateCommand();
                                    upCmd2.CommandType = CommandType.Text;
                                    upCmd2.CommandText = "Update cusBalTB set prodBal = '" + bal2 + "' " +
                                        "where ordId = '" + ordId + "'";
                                    upCmd2.ExecuteNonQuery();
                                    upCon.Close();
                                }
                                chk3.Close();
                            }
                            check2.Close();
                        }
                        else
                        {
                            // if ordId is already penalized and the app is not open for more than one day
                            string cus = (cDr["cusId"].ToString());
                            string ord = (cDr["ordId"].ToString());
                            string dOrd = (cDr["DateOrd"].ToString());
                            string dRecv = (cDr["DateRecv"].ToString());
                            string ordDue = (cDr["DateDead"].ToString());
                            string dPenal = (cDr["penalDate"].ToString());

                            DateTime datePenal = DateTime.Parse(dPenal);
                            DateTime Ddate = DateTime.Parse(date);
                            double num2 = (Ddate - datePenal).TotalDays;
                            double fpenalty = cost * num2;
                            double newBal2 = Double.Parse(curBal) + fpenalty;
                            string Fres = newBal2.ToString();

                            chk.Open();
                            SqlCommand chkmd = chk.CreateCommand();
                            chkmd.CommandType = CommandType.Text;
                            chkmd.CommandText = "Select * from penaltyTB where ordId = '" + ordId + "' " +
                                "and penalDate = '" + date + "'";
                            SqlDataReader drchk = chkmd.ExecuteReader();

                            if (!drchk.Read())
                            {
                                insert.Open();
                                SqlCommand insCmd = insert.CreateCommand();
                                insCmd.CommandType = CommandType.Text;
                                insCmd.CommandText = "Insert into penaltyTB Values ('" + month + "', " +
                                    "'" + ord + "', " +
                                    "'" + cusId + "', " +
                                    "'" + dOrd + "', " +
                                    "'" + dRecv + "', " +
                                    "'" + ordDue + "', " +
                                    "'" + curBal + "', " +
                                    "'" + date + "', " +
                                    "'" + fpenalty.ToString() + "', " +
                                    "'" + Fres + "', " +
                                    "'" + year + "')";
                                insCmd.ExecuteNonQuery();
                                insert.Close();

                                update.Open();
                                SqlCommand upCmd2 = update.CreateCommand();
                                upCmd2.CommandType = CommandType.Text;
                                upCmd2.CommandText = "Update cusBalTB set prodBal = '" + Fres + "' " +
                                    "where ordId = '" + ord + "'";
                                upCmd2.ExecuteNonQuery();
                                update.Close();
                            }
                            chk.Close();
                        }
                        chkCon.Close();
                    }
                    penalCon.Close();
                    delZero();
                }
                costCon.Close();
            }
            catch (Exception e)
            {
                if (e.Message != "Invalid attempt to read when no data is present.")
                {
                    MessageBox.Show(e.Message, " Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        public void payCusId()
        {
            SqlConnection cusCon = new SqlConnection(prodcs);
            SqlConnection balCon = new SqlConnection(prodcs);

            try
            {
                cusCon.Open();
                SqlCommand cusCmd = cusCon.CreateCommand();
                cusCmd.CommandType = CommandType.Text;
                cusCmd.CommandText = "Select * from cusTB where cusId = '" + tbPayCusId.Text + "'";
                SqlDataReader dr = cusCmd.ExecuteReader();

                if (dr.Read())
                {
                    string first = (dr["Firstname"].ToString());
                    string mid = (dr["Midname"].ToString());
                    string last = (dr["Lastname"].ToString());

                    balCon.Open();
                    SqlCommand balCmd = balCon.CreateCommand();
                    balCmd.CommandType = CommandType.Text;
                    balCmd.CommandText = "Select cusId from cusBalTB where cusId = '" + tbPayCusId.Text + "' and prodBal != 0";
                    SqlDataReader dr2 = balCmd.ExecuteReader();

                    if (dr2.Read())
                    {
                       
                        MessageBox.Show("Customer Found!", " Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (MessageBox.Show("Customer Name: " + last + ", " + first + " " + mid + " ... Continue?", " Verify",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            viewPayBalDet();
                            lblPayBalCus.Text = tbPayCusId.Text;
                            lblPayCusId.Text = tbPayCusId.Text;
                            paneBalBreak.Visible = true;
                            panePayCusId.Visible = false;
                            btnPayClose.Visible = true;
                        }
                        else
                        {
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Customer don't have any balance...", " No Debt",  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Customer Not Found!", " Invalid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                cusCon.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, " Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public void loadMonth()
        {
            SqlConnection loadMonth = new SqlConnection(prodcs);
            SqlConnection loadCon = new SqlConnection(prodcs);

            try
            {
                loadMonth.Open();
                SqlCommand monthCmd = loadMonth.CreateCommand();
                monthCmd.CommandType = CommandType.Text;
                monthCmd.CommandText = "Select Month from saleTB";
                SqlDataReader monthDr = monthCmd.ExecuteReader();

                while (monthDr.Read())
                {
                    string month = monthDr["Month"].ToString();

                    if (!cbSaleMonth.Items.Contains(month))
                    {
                        cbSaleMonth.Items.Add(month);
                    }
                   
                }
                loadMonth.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, " Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void loadCount()
        {
            SqlConnection loadCount = new SqlConnection(councs);

            try
            {
                loadCount.Open();
                SqlCommand countCmd = loadCount.CreateCommand();
                countCmd.CommandType = CommandType.Text;
                countCmd.CommandText = "Select Country from countTB";
                SqlDataReader countDr = countCmd.ExecuteReader();

                while (countDr.Read())
                {
                    string count = countDr["Country"].ToString();

                    if (!cbNewCusCount.Items.Contains(count))
                    {
                        cbNewCusCount.Items.Add(count);
                    }
                    if (!cbUpCusCoun.Items.Contains(count))
                    {
                        cbUpCusCoun.Items.Add(count);
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, " Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            loadCount.Close();
        }
        public void printOrd()
        {
            try
            {
                PrintDocument printDocument2 = new PrintDocument();
                printDocument2.PrintPage += new PrintPageEventHandler(printOrder_PrintPage);
                printDocument2.Print();
                this.BringToFront();
                enCusInfo();
                clrOrder();
                paneOrder.Visible = true;
                paneNewCus.Visible = true;
                gbNewOrdInfo.Visible = false;
                paneReceipt.Visible = false;
                
            }
            catch (Exception f)
            {
                MessageBox.Show(f.Message, " Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void clrOrderBr()
        {
            foreach (Control c in gbOrderBr.Controls)
            {
                if (c is TextBox)
                {
                    c.Text = "";
                }
            }
        }

        public void clrOrder()
        {
            foreach (Control c in gbNewOrdInfo.Controls)
            {
                if (c is TextBox)
                {
                    c.Text = "";
                }
            }
            gVOrdRec.Rows.Clear();
            tbOrdId.Text = "";
            lblRecCusID.Text = "";
            lblOrdItem.Text = "0";
        }
        public void enCusInfo()
        {
            foreach (Control c in paneNewCus.Controls)
            {
                if (c is GroupBox)
                {
                    foreach (Control d in c.Controls)
                    {
                        if (d is TextBox)
                        {
                            d.Enabled = true;
                        }
                        if (d is ComboBox)
                        {
                            d.Enabled = true;
                        }
                    }
                }
            }
            clrCusInfo();
            lblOrdId.Text = "00-0000-00";
        }
        public void clrPay()
        {
            foreach (Control c in panePayNow.Controls)
            {
                if (c is TextBox)
                {
                    c.Text = "";
                }
            }
            lblSlipId.Text = "00-00-0000";
            lblPayOrdDue.Text = "00-00-0000";
            lblPayOrdRev.Text = "00-00-0000";
            lblPayCusId.Text = "00000000";
            tbPayTransId.Text = "";
            tbPayCusBal.Text = "";
            tbPayTot.Text = "";
            btnPayPrint.Visible = true;
            gVPaySlip.Rows.Clear();
        }
        public void disCusInfo()
        {
            foreach (Control c in paneNewCus.Controls)
            {
                if (c is GroupBox)
                {
                    foreach (Control d in c.Controls)
                    {
                        if (d is TextBox)
                        {
                            d.Enabled = false;
                        }
                        if (d is ComboBox)
                        {
                            d.Enabled = false;
                        }
                    }
                }
            }
        }
        public void clrCusInfo()
        {
            foreach (Control c in paneNewCus.Controls)
            {
                if (c is GroupBox)
                {
                    foreach (Control d in c.Controls)
                    {
                        if (d is TextBox)
                        {
                            d.Text = "";
                        }
                        if (d is ComboBox)
                        {
                            d.Text = null;
                        }
                    }
                }
            }
            btnAddCus.Text = "ADD";
            tbNewCusId.Text = "";
        }
        public void clrNewPro()
        {
            foreach(Control c in gBNewProd.Controls)
            {
                if (c is TextBox)
                {
                    c.Text = "";
                }
                else if (c is ComboBox)
                {
                    c.Text = "";
                }
               
            }
            btnNewProdAdd.Text = "ADD";
            lblNewProdID.ResetText();
            cbNewProdBrand.Enabled = true;
            btnDelProd.Visible = false;
            numPro.Value = 20;
            tbSerProd.Text = "Search Here";
            tbSerProd.ForeColor = Color.Gray;
        }
        public void clrOrdInfo()
        {
            foreach (Control c in gbNewOrdInfo.Controls)
            {
                if (c is TextBox)
                {
                    c.Text = "";
                }
                else if (c is ComboBox)
                {
                    c.Text = null;
                }
               
            }
            numRate.Value = 20;
        }
        public void printPaySlip()
        {
            try
            {
                PrintDocument printDocument2 = new PrintDocument();
                printDocument2.PrintPage += new PrintPageEventHandler(printBalPay_PrintPage);
                printDocument2.Print();
                this.BringToFront();
               
            }
            catch (Exception f)
            {
                MessageBox.Show(f.Message, " Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void payTrans()
        {
            SqlConnection payCon = new SqlConnection(prodcs);
            
            try
            {
                string pre = "PAYTR";
                string cusId = lblPayCusId.Text;
                string date = lblDate.Text;
                string time = lblTime.Text;
                string cash = tbPayTot.Text;

               
                if (gVPaySlip.Rows.Count != 0)
                {
                    payCon.Open();
                    SqlCommand payCmd = payCon.CreateCommand();
                    payCmd.CommandType = CommandType.Text;
                    payCmd.CommandText = "Insert into transPayTB Values ('" + pre + "', " +
                        "'" + cusId + "', " +                 
                        "'" + cash + "', " +               
                        "'" + date + "', " +
                        "'" + time + "')";
                    payCmd.ExecuteNonQuery();

                    payCmd.CommandText = "Select TOP 1 * from transPayTB Order By transPayId Desc";
                    SqlDataReader dr = payCmd.ExecuteReader();
                    if (dr.Read())
                    {
                        tbPayTransId.Text = (dr["transPayId"].ToString());
                    }
                    btnPayPrint.Visible = false;
                    printPaySlip();
                    MessageBox.Show("Transaction Complete!", " Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    adminDash ad = new adminDash();
                    this.BringToFront();
                    clrPay();
                    panePaySlip.Visible = false;
                    panePayNow.Visible = false;
                    
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, " Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
         public void minusBal()
        {
            SqlConnection minCon = new SqlConnection(prodcs);
            SqlConnection upCon = new SqlConnection(prodcs);
            SqlConnection delCon = new SqlConnection(prodcs);
            SqlConnection dispCon = new SqlConnection(prodcs);
            SqlConnection con = new SqlConnection(prodcs);
           
            try
            {
                minCon.Open();
                SqlCommand minCmd = minCon.CreateCommand();
                minCmd.CommandType = CommandType.Text;
                minCmd.CommandText = "Select * from cusBalTB " +
                    "where cusId = '" + lblPayCusId.Text + "' and ordId = '" + tbPayOrdId.Text + "'";
                SqlDataReader dr = minCmd.ExecuteReader();

                if (dr.Read())
                {
                    string bal = (dr["prodBal"].ToString());
                    double cash = Double.Parse(tbPayAmount.Text);
                    double curBal = Double.Parse(bal);
                    double newBal = curBal - cash;

                    upCon.Open();
                    SqlCommand upCmd = upCon.CreateCommand();
                    upCmd.CommandType = CommandType.Text;
                    upCmd.CommandText = "Update cusBalTB Set prodBal = '" + newBal.ToString() + "' " +
                        "where cusId = '" + lblPayCusId.Text + "' and ordId = '" + tbPayOrdId.Text + "'";
                    upCmd.ExecuteNonQuery();

                    if (newBal == 0)
                    {
                        delCon.Open();
                        SqlCommand cmd = delCon.CreateCommand();
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "Delete from ordTB where ordId = '" + tbPayOrdId.Text + "' " +
                            "and cusId = '" + lblPayCusId.Text + "'";
                        cmd.ExecuteNonQuery();
                        delCon.Close();

                        con.Open();
                        SqlCommand cmd2 = con.CreateCommand();
                        cmd2.CommandType = CommandType.Text;
                        cmd2.CommandText = "Delete from cusBalTB where ordId = '" + tbPayOrdId.Text + "' " +
                            "and cusId = '" + lblPayCusId.Text + "'";
                        cmd2.ExecuteNonQuery();
                        con.Close();
                    }

                    dispCon.Open();
                    DataTable dt = new DataTable();
                    adapt = new SqlDataAdapter("Select ordId as OrdID, Distrib as Company, Brand, Name, Qty, SRP, Total from ordTB " +
                        "where cusId = '" + lblPayBalCus.Text + "'  and OrdStat = 'RECEIVED' " +
                        "order by ordId DESC", dispCon);
                    adapt.Fill(dt);
                    gVPayBalDet.DataSource = dt;
                    
                    DataTable dt2 = new DataTable();
                    adapt = new SqlDataAdapter("Select prodBal As Balance from cusBalTB " +
                        "where cusId = '" + lblPayBalCus.Text + "' and prodBal != 0 order by ordId DESC", dispCon);
                    adapt.Fill(dt2);
                    gVPayBal.DataSource = dt2;
                    dispCon.Close();

                    double totCash = gVPayBal.Rows.Cast<DataGridViewRow>().Sum(t => Convert.ToDouble(t.Cells[0].Value));
                    tbPayCusBal.Text = totCash.ToString();
                }
                minCon.Close();
                upCon.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, " Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void slipPay()
        {
            SqlConnection payCon = new SqlConnection(prodcs);
            SqlConnection upCon = new SqlConnection(prodcs);
            SqlConnection delCon = new SqlConnection(prodcs);


            string pre = "PAY";
            string cusId = tbPayCusId.Text;
            string prodId = tbPayOrdId.Text;
            string cash = tbPayAmount.Text;
            string date = lblDate.Text;
            string time = lblTime.Text;
            string balance = tbPayOrdBal.Text;
      
            try
            {
                int bal = Int32.Parse(tbPayOrdBal.Text);
                int csh = Int32.Parse(cash);

                if (tbPayAmount.Text == "")
                {
                    MessageBox.Show("Insert Some Cash!!!", " Empty", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tbPayAmount.Focus();
                }
                else
                {
                    if (csh > bal)
                    {
                        MessageBox.Show("Overpaying!!!", " Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        payCon.Open();
                        SqlCommand payCmd = payCon.CreateCommand();
                        payCmd.CommandType = CommandType.Text;
                        payCmd.CommandText = "Insert into cusPayTB Values ('" + pre + "', " +
                            "'" + cusId + "', " +
                            "'" + prodId + "', " +
                            "'" + cash + "', " +
                            "'" + date + "', " +
                            "'" + time + "')";
                        payCmd.ExecuteNonQuery();

                        payCmd.CommandText = "Select TOP 1 * from cusPayTB Order By payId Desc";
                        SqlDataReader dr = payCmd.ExecuteReader();

                        if (dr.Read())
                        {
                            string slip = (dr["payId"].ToString());
                            lblSlipId.Text = slip;
                        }
                        int sukli = bal - csh;
                        tbPayChange.Text = sukli.ToString();
                        gVPaySlip.Rows.Add(lblSlipId.Text, prodId, balance, cash, tbPayChange.Text);
                        double totCash = gVPaySlip.Rows.Cast<DataGridViewRow>().Sum(t => Convert.ToDouble(t.Cells[3].Value));
                        tbPayTot.Text = totCash.ToString();
                        minusBal();
                        payCon.Close();

                        upCon.Open();
                        SqlCommand upCmd = upCon.CreateCommand();
                        upCmd.CommandType = CommandType.Text;
                        upCmd.CommandText = "Update cusBalTB Set latPayId = '" + lblSlipId.Text + "' where cusId = '" + cusId + "'";
                        upCmd.ExecuteNonQuery();
                        tbPayAmount.Text = "";
                        tbPayChange.Text = "";
                        tbPayOrdId.Text = "";
                        tbPayOrdBal.Text = "";
                        lblPayOrdRev.Text = "00-00-0000";
                        lblPayOrdDue.Text = "00-00-0000";
                    }

                }
               
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message, " Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
       

        public void cellPay()
        {
            panePayNow.Visible = true;
            panePaySlip.Visible = true;

            SqlConnection payCon = new SqlConnection(prodcs);

            string value = gVPayBalDet.CurrentRow.Cells[0].Value.ToString();
            try
            {
                payCon.Open();
                SqlCommand payCmd = payCon.CreateCommand();
                payCmd.CommandType = CommandType.Text;
                payCmd.CommandText = "Select * from cusBalTB where ordId = '" + value + "'";
                SqlDataReader dr = payCmd.ExecuteReader();

                if (dr.Read())
                {
                    tbPayOrdId.Text = value;
                    tbPayOrdBal.Text = (dr["prodBal"].ToString());
                    lblPayOrdRev.Text = (dr["ordRecv"].ToString());
                    lblPayOrdDue.Text = (dr["ordDead"].ToString());
                   
                    lblPayCusId.Text = lblPayBalCus.Text;
                    tbPayAmount.Text = "";
                    tbPayChange.Text = "";
                    tbPayAmount.Focus();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, " Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        public void addOrdPro()
        {
            SqlConnection proCon = new SqlConnection(prodcs);
            SqlConnection rateCon = new SqlConnection(prodcs);


            string pre = "SLE";          
            string ordId = gVOrdDet.CurrentRow.Cells[0].Value.ToString();           
            string date = DateTime.Now.ToShortDateString();
            int nmonth = DateTime.Now.Month;
            string month = new DateTimeFormatInfo().GetMonthName(nmonth);
            string year = DateTime.Now.Year.ToString();

            try
            {

                rateCon.Open();
                SqlCommand rateCmd = rateCon.CreateCommand();
                rateCmd.CommandType = CommandType.Text;
                rateCmd.CommandText = "Select * from ordTB where ordId = '" + ordId + "'";
                SqlDataReader dr = rateCmd.ExecuteReader();

                if (dr.Read())
                {
                    string rate = (dr["Rate"].ToString());
                    string cusId = (dr["cusId"].ToString());
                    string comp = (dr["Distrib"].ToString());
                    string name = (dr["Name"].ToString());
                    string price = (dr["SRP"].ToString());
                    string quan = (dr["Qty"].ToString());

                    double profit = Double.Parse(rate) * Double.Parse(price) * Double.Parse(quan);
                    string pro = profit.ToString();

                    proCon.Open();
                    SqlCommand proCmd = proCon.CreateCommand();
                    proCmd.CommandType = CommandType.Text;
                    proCmd.CommandText = "Insert into saleTB Values ('" + pre + "', " +
                        "'" + cusId + "', " +
                        "'" + ordId + "', " +
                        "'" + quan + "', " +
                        "'" + comp + "', " +
                        "'" + name + "', " +
                        "'" + date + "', " +
                        "'" + month + "', " +
                        "'" + pro + "', " +
                        "'" + year + "')";
                    proCmd.ExecuteNonQuery();

                }
                rateCon.Close();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, " Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void viewPayBalDet()
        {
            SqlConnection dispCon = new SqlConnection(prodcs);
            SqlConnection balCon = new SqlConnection(prodcs);
            SqlConnection viewCon = new SqlConnection(prodcs);

            string cusId = tbPayCusId.Text;

            try
            {
                viewCon.Open();
                SqlCommand viewCmd = viewCon.CreateCommand();
                viewCmd.CommandType = CommandType.Text;
                viewCmd.CommandText = "Select * from cusBalTB where cusId = '" + cusId + "' and prodBal != 0";
                SqlDataReader dr = viewCmd.ExecuteReader();

                if (dr.Read())
                {
                   
                    
                    dispCon.Open();
                    DataTable dt = new DataTable();
                    adapt = new SqlDataAdapter("Select ordId as OrdID, Distrib as Company, Brand, Name, Qty, SRP, Total from ordTB " +
                        "where cusId = '" + cusId + "'  and OrdStat = 'RECEIVED' " +
                        "order by ordId ASC", dispCon);
                    adapt.Fill(dt);
                    gVPayBalDet.DataSource = dt;
                    dispCon.Close();

                    balCon.Open();
                    DataTable dt2 = new DataTable();
                    adapt = new SqlDataAdapter("Select prodBal As Balance from cusBalTB " +
                        "where cusId = '" + cusId + "' order by ordId ASC", balCon);
                    adapt.Fill(dt2);
                    gVPayBal.DataSource = dt2;
                    balCon.Close();

                    double balTot = gVPayBal.Rows.Cast<DataGridViewRow>().Sum(t => Convert.ToDouble(t.Cells[0].Value));
                    tbPayCusBal.Text = balTot.ToString();
                }
                viewCon.Close();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, " Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
       
        public void viewBalDet()
        {
            SqlConnection dispCon = new SqlConnection(prodcs);
            SqlConnection balCon = new SqlConnection(prodcs);

            try
            {
                string cusId = gVCusInfo.CurrentRow.Cells[0].Value.ToString();
                dispCon.Open();
                DataTable dt = new DataTable();
                adapt = new SqlDataAdapter("Select ordId as OrdID, Distrib as Company, Brand, Name, Qty, SRP, Total from ordTB " +
                    "where cusId = '" + cusId + "' and OrdStat = 'RECEIVED' order by ordId DESC", dispCon);
                adapt.Fill(dt);
                gVBalDet.DataSource = dt;
                dispCon.Close();

                balCon.Open();
                DataTable dt2 = new DataTable();
                adapt = new SqlDataAdapter("Select prodBal As Balance from cusBalTB " +
                    "where cusId = '" + cusId + "' and prodBal != 0 order by ordId DESC", balCon);
                adapt.Fill(dt2);
                gVBal.DataSource = dt2;
                balCon.Close();

                double balTot = gVBal.Rows.Cast<DataGridViewRow>().Sum(t => Convert.ToDouble(t.Cells[0].Value));
                tbCusBal.Text = balTot.ToString();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, " Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void viewOrderDet()
        {
            SqlConnection detCon = new SqlConnection(prodcs);

            try
            {
                detCon.Open();
                DataTable dt = new DataTable();
                adapt = new SqlDataAdapter("Select ordId as OrdID, Qty, Distrib as Company, Cat as Category, Month, Page, Brand, Name, Color, Size, SRP, Total from ordTB where OrdStat = 'PENDING' Order By ordId DESC", detCon);
                adapt.Fill(dt);
                gVOrdDet.DataSource = dt;
                detCon.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, " Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void viewHomeOrder()
        {
            SqlConnection verCon = new SqlConnection(prodcs);

            try
            {
                verCon.Open();
                DataTable dt = new DataTable();
                adapt = new SqlDataAdapter("Select ordId as OrdID, cusId as CusID, " +
                    "DateOrd as DateOrdered, OrdStat as OrdStatus from ordTB where OrdStat = 'PENDING' Order By DateOrd DESC ", verCon);
                adapt.Fill(dt);
                gVHomePenOrd.DataSource = dt;
                verCon.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, " Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void viewOrder()
        {
            SqlConnection verCon = new SqlConnection(prodcs);

            try
            {
                verCon.Open();
                DataTable dt = new DataTable();
                adapt = new SqlDataAdapter("Select ordId as OrdID, cusId as CusID, " +
                    "DateOrd as DateOrdered, OrdStat as OrdStatus from ordTB Order By OrdStat ASC, DateOrd DESC ", verCon);
                adapt.Fill(dt);
                gVOrder.DataSource = dt;
               
                verCon.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, " Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void searchProd()
        {
            SqlConnection serCon = new SqlConnection(prodcs);
            string value = tbSerProd.Text;

            try
            {
                serCon.Open();
                DataTable dt = new DataTable();
                adapt = new SqlDataAdapter("Select prodId as ProdID, Qty, Brand As Distributor, Name As Brand, Info as Name, Size, Cor as Info, SRP, Date as LastUpdate " +
                    "from newprodTB where prodId LIKE '" + value + "' OR Info LIKE '" + value + "' Order By prodId ASC", serCon);
                adapt.Fill(dt);
                gVNewProd.DataSource = dt;
                serCon.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, " Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void searchCus()
        {
            SqlConnection serCon = new SqlConnection(prodcs);
            string value = tbSerCus.Text;
            
            try
            {
                serCon.Open();
                DataTable dt = new DataTable();
                adapt = new SqlDataAdapter("Select cusId AS CusID, Firstname, Midname, Lastname from cusTB where cusId LIKE '%" + value + "%' " +
                    "OR Lastname Like '%" + value + "%' order by cusID ASC", serCon);
                adapt.Fill(dt);
                gVCusInfo.DataSource = dt;
                serCon.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, " Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void wDrawOrd()
        {
            SqlConnection withOrd = new SqlConnection(prodcs);

            try
            {
                string ordId = gVPenOrd.CurrentRow.Cells[0].Value.ToString();

                if (MessageBox.Show("Are you sure to withdraw this '" + ordId + "' order?", " Confirmation",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    withOrd.Open();
                    SqlCommand withCmd = withOrd.CreateCommand();
                    withCmd.CommandType = CommandType.Text;
                    withCmd.CommandText = "Delete from ordTB where ordId = '" + ordId + "'";
                    withCmd.ExecuteNonQuery();
                    withOrd.Close();
                    MessageBox.Show("Order Withdrawn", " Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadPenOrd();
                }
                else
                {
                    return;
                }
                           
            }
            catch (Exception e)
            {
                MessageBox.Show("No Selection!", " Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void loadPenOrd()
        {
            SqlConnection loadPen = new SqlConnection(prodcs);

            try
            {
                string cusId = gVCusInfo.CurrentRow.Cells[0].Value.ToString();

                loadPen.Open();
                DataTable dt = new DataTable();
                adapt = new SqlDataAdapter("Select ordId as OrdID, DateOrd as DateOrdered, Distrib as Company, Brand, Name, Qty, SRP, Total from ordTB where cusId = '" + cusId + "' " +
                    "and OrdStat = 'PENDING'", loadPen);
                adapt.Fill(dt);
                gVPenOrd.DataSource = dt;
                loadPen.Close();

                double balTot = gVPenOrd.Rows.Cast<DataGridViewRow>().Sum(t => Convert.ToDouble(t.Cells[7].Value));
                tbPenBal.Text = balTot.ToString();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, " Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void paySlip()
        {
            SqlConnection serCon = new SqlConnection(prodcs);
            string value = tbPaySlip.Text;

            try
            {
                serCon.Open();
                DataTable dt = new DataTable();
                adapt = new SqlDataAdapter("Select payId As PayID, cusId As CusID, prodId as OrdID, Date, Time, Cash from cusPayTB " +
                    "where payId LIKE '%" + value + "%' OR cusId LIKE '%" + value + "%'  Order by payId ASC", serCon);
                adapt.Fill(dt);
                gVPResc.DataSource = dt;
                serCon.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, " Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void orderSlip()
        {
            SqlConnection serCon = new SqlConnection(prodcs);
            string value = tbOrdSlip.Text;

            try
            {
                serCon.Open();
                DataTable dt = new DataTable();
                adapt = new SqlDataAdapter("Select transOrdId As TransID, cusId As CusID, Date, Time, Items, Total from transOrdTB " +
                    "where transOrdId LIKE '%" + value + "%' OR cusId LIKE '%" + value + "%'  Order by transOrdId ASC", serCon);
                adapt.Fill(dt);
                gVOResc.DataSource = dt;
                serCon.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, " Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void penalRep()
        {
            SqlConnection con = new SqlConnection(prodcs);
            string value = tbPenalCus.Text;

            try
            {
                con.Open();
                DataTable dt = new DataTable();
                adapt = new SqlDataAdapter("Select ordId as OrdID, cusId as CusID, " +
                    "DateOrd as DateOrdered, DateRecv as DateReceived, DateDead as DueDate, curBal as CurrentBal, penalDate as DatePenal, " +
                    "penalty as Penalty, newBal as NewBal from penaltyTB where ordId LIKE '%" + value + "%' OR cusId LIKE '%" + value + "%' " +
                    "penalty != 0 order by ordId ASC, Cast (penalDate as DATETIME)", con);
                adapt.Fill(dt);
                gVPenal.DataSource = dt;
                con.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, " Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void cashSlip()
        {
            SqlConnection serCon = new SqlConnection(prodcs);
            string value = tbCashSlip.Text;

            try
            {
                serCon.Open();
                DataTable dt = new DataTable();
                adapt = new SqlDataAdapter("Select transCashId As TransID, cusId As CusID, Date, Time, Items, Total, Cash, Change from transCashTB " +
                    "where transCashId LIKE '%" + value + "%' OR cusId LIKE '%" + value + "%' Order by transCashId  ASC", serCon);
                adapt.Fill(dt);
                gVResc.DataSource = dt;
                serCon.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, " Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void loadOReceipt()
        {
            SqlConnection resCon = new SqlConnection(prodcs);

            try
            {

                resCon.Open();
                DataTable dt = new DataTable();
                adapt = new SqlDataAdapter("Select transOrdId As TransID, cusId As CusID, Date, Time, Items, Total from transOrdTB Order By transOrdId ASC", resCon);
                adapt.Fill(dt);
                gVOResc.DataSource = dt;
                resCon.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, " Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void loadPReceipt()
        {
            SqlConnection resCon = new SqlConnection(prodcs);

            try
            {

                resCon.Open();
                DataTable dt = new DataTable();
                adapt = new SqlDataAdapter("Select payId As PayID, cusId As CusID, prodId as ProdID, Date, Time, Cash from cusPayTB Order By payId ASC", resCon);
                adapt.Fill(dt);
                gVPResc.DataSource = dt;
                resCon.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, " Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void loadCReceipt()
        {
            SqlConnection resCon = new SqlConnection(prodcs);

            try
            {
               
                resCon.Open();
                DataTable dt = new DataTable();
                adapt = new SqlDataAdapter("Select transCashId As TransID, cusId As CusID, Date, Time, Items, Total, Cash, Change from transCashTB Order By transCashId ASC", resCon);
                adapt.Fill(dt);
                gVResc.DataSource = dt;
                resCon.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, " Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }         
        }
        public void cellBalDet()
        {
            SqlConnection balCon = new SqlConnection(prodcs);

            string ordId = gVBalDet.CurrentRow.Cells[0].Value.ToString();

            try
            {
                balCon.Open();
                SqlCommand balCmd = balCon.CreateCommand();
                balCmd.CommandType = CommandType.Text;
                balCmd.CommandText = "Select * from cusBalTB where ordId = '" + ordId + "' ";
                SqlDataReader dr = balCmd.ExecuteReader();

                if (dr.Read())
                {
                    lblOrdRecv.Text = (dr["DateOrd"].ToString());
                    lblOrdDue.Text = (dr["ordDead"].ToString());
                }
                balCon.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, " Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void cellOrderBr()
        {
            SqlConnection cellCon = new SqlConnection(prodcs);

            string ordId = gVOrder.CurrentRow.Cells[0].Value.ToString();

            try
            {
                cellCon.Open();
                SqlCommand cellCmd = cellCon.CreateCommand();
                cellCmd.CommandType = CommandType.Text;
                cellCmd.CommandText = "Select * from cusBalTB where ordId = '" + ordId + "'";
                SqlDataReader dr = cellCmd.ExecuteReader();

                if (dr.Read())
                {
                    tbBrCusId.Text = (dr["cusId"].ToString());
                    tbBrOrdId.Text = (dr["ordId"].ToString());
                    tbBrDateOrd.Text = (dr["DateOrd"].ToString());
                    tbBrDateRecv.Text = (dr["ordRecv"].ToString());
                    tbBrDateDue.Text = (dr["ordDead"].ToString());
                    tbBrTotal.Text = (dr["prodBal"].ToString());
                }
                else
                {
                    tbBrCusId.Text = "";
                    tbBrOrdId.Text = "";
                    tbBrDateOrd.Text = "";
                    tbBrDateRecv.Text = "";
                    tbBrDateDue.Text = "";
                    tbBrTotal.Text = "";
                }
                cellCon.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, " Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void cellCus()
        {
            SqlConnection cusCon = new SqlConnection(prodcs);

            string cusId = gVCusInfo.CurrentRow.Cells[0].Value.ToString();
            
            try
            {
                cusCon.Open();
                SqlCommand cusCmd = cusCon.CreateCommand();
                cusCmd.CommandType = CommandType.Text;
                cusCmd.CommandText = "Select * from cusTB where cusId = '" + cusId + "' ";
                SqlDataReader dr = cusCmd.ExecuteReader();

                if (dr.Read())
                {
                    tbUpCusFirst.Text = (dr["Firstname"].ToString());
                    tbUpCusMid.Text = (dr["Midname"].ToString());
                    tbUpCusLast.Text = (dr["Lastname"].ToString());
                    cbUpCusSex.Text = (dr["Sex"].ToString());
                    cbUpCusStat.Text = (dr["Status"].ToString());
                    tbUpCusMob.Text = (dr["Mobile"].ToString());
                    cbUpCusCoun.Text = (dr["Country"].ToString());
                    cbUpCusPro.Text = (dr["Province"].ToString());
                    cbUpCusMun.Text = (dr["Municipality"].ToString());
                    cbUpCusBar.Text = (dr["Barangay"].ToString());
                    tbUpCusHou.Text = (dr["Purok"].ToString());
                    tbUpCusId.Text = cusId;
                    paneUpCus.Visible = true;
                    paneUpCus.BringToFront();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, " Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void dispCusInfo()
        {
            SqlConnection dispCon = new SqlConnection(prodcs);

            try
            {
                dispCon.Open();
                DataTable dt = new DataTable();
                adapt = new SqlDataAdapter("Select cusId AS CusID, Firstname, Midname, Lastname from cusTB order by cusID ASC", dispCon);
                adapt.Fill(dt);
                gVCusInfo.DataSource = dt;
                dispCon.Close();
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message, " Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void upCusInfo()
        {
            SqlConnection upCon = new SqlConnection(prodcs);
         
            try
            {
                string first = tbUpCusFirst.Text;           string coun = cbUpCusCoun.Text;
                string mid = tbUpCusMid.Text;               string pro = cbUpCusPro.Text;
                string last = tbUpCusLast.Text;             string mun = cbUpCusMun.Text;
                string sex = cbUpCusSex.Text;               string bar = cbUpCusBar.Text;
                string stat = cbUpCusStat.Text;             string hou = tbUpCusHou.Text;
                string mob = tbUpCusMob.Text;

                string cusId = tbUpCusId.Text;

                if (first == "" || mid == "" || last == "" || sex == "" ||
                   stat == "" || mob == "" || coun == "" || mun == "" ||
                   bar == "" || hou == "")
                {
                    MessageBox.Show("Input Missing Fields!", " Incomplete", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    upCon.Open();
                    SqlCommand upCmd = upCon.CreateCommand();
                    upCmd.CommandType = CommandType.Text;
                    upCmd.CommandText = "Update cusTB Set Firstname = '" + first + "', " +
                                                         "Midname = '" + mid + "', " +
                                                         "Lastname = '" + last + "', " +
                                                         "Sex = '" + sex + "', " +
                                                         "Status = '" + stat + "', " +
                                                         "Mobile = '" + mob + "', " +
                                                         "Country = '" + coun + "', " +
                                                         "Province = '" + pro + "', " +
                                                         "Municipality = '" + mun + "', " +
                                                         "Barangay = '" + bar + "', " +
                                                         "Purok = '" + hou + "' where cusId = '" + cusId + "'";
                    upCmd.ExecuteNonQuery();
                    MessageBox.Show("Customer Updated!", " Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    paneUpCus.Visible = false;
                    dispCusInfo();
                }              
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, " Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void addCusInfo()
        {
            SqlConnection cusCon = new SqlConnection(prodcs);
            SqlConnection verCon = new SqlConnection(prodcs);

            try
            {
                string first = tbNewCusFirst.Text;          string coun = cbNewCusCount.Text;
                string mid = tbNewCusMid.Text;              string pro = cbNewCusPro.Text;
                string last = tbNewCusLast.Text;            string mun = cbNewCusMun.Text;
                string sex = cbNewCusSex.Text;              string bar = cbNewCusBar.Text;
                string stat = cbNewCusStat.Text;            string hou = tbNewCusHou.Text;
                string mob = tbNewCusMob.Text;
                string pre = "CS";


                if (first == "" || mid == "" || last == "" || sex == "" ||
                    stat == "" || mob == "" || coun == "" || mun == "" || 
                    bar == "" || hou == "")
                {
                    MessageBox.Show("Input Missing Fields!", " Incomplete", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    verCon.Open();
                    SqlCommand verCmd = verCon.CreateCommand();
                    verCmd.CommandType = CommandType.Text;
                    verCmd.CommandText = "Select * from cusTB where Firstname = '" + first + "' " +
                                                               "and Midname = '" + mid + "' " +
                                                               "and Lastname = '" + last + "'";
                    SqlDataReader dr = verCmd.ExecuteReader();

                    if (dr.Read())
                    {
                        MessageBox.Show("Customer has already a Record!", " Existed", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        tbNewCusId.Text = (dr["cusId"].ToString());
                        tbNewCusFirst.Text = (dr["Firstname"].ToString());
                        tbNewCusMid.Text = (dr["Midname"].ToString());
                        tbNewCusLast.Text = (dr["Lastname"].ToString());
                        cbNewCusSex.Text = (dr["Sex"].ToString());
                        cbNewCusStat.Text = (dr["Status"].ToString());
                        tbNewCusMob.Text = (dr["Mobile"].ToString());
                        cbNewCusCount.Text = (dr["Country"].ToString());
                        cbNewCusPro.Text = (dr["Province"].ToString());
                        cbNewCusMun.Text = (dr["Municipality"].ToString());
                        cbNewCusBar.Text = (dr["Barangay"].ToString());
                        tbNewCusHou.Text = (dr["Purok"].ToString());
                        disCusInfo();
                        btnAddCus.Text = "CLEAR";
                    }
                    else
                    {
                        cusCon.Open();
                        SqlCommand cusCmd = cusCon.CreateCommand();
                        cusCmd.CommandType = CommandType.Text;
                        cusCmd.CommandText = "Insert into cusTB Values ('" + pre + "', " +
                                                                         "'" + first + "', " +
                                                                         "'" + mid + "', " +
                                                                         "'" + last + "', " +
                                                                         "'" + sex + "', " +
                                                                         "'" + stat + "', " +
                                                                         "'" + mob + "', " +
                                                                         "'" + coun + "', " +
                                                                         "'" + pro + "', " +
                                                                         "'" + mun + "', " +
                                                                         "'" + bar + "', " +
                                                                         "'" + hou + "')";
                        cusCmd.ExecuteNonQuery();
                        

                        cusCmd.CommandText = "Select cusId from cusTB where Firstname = '" + first + "' " +
                                                                       "and Midname = '" + mid + "' " +
                                                                       "and Lastname = '" + last + "'";
                        SqlDataReader idDr = cusCmd.ExecuteReader();

                        if (idDr.Read())
                        {
                            tbNewCusId.Text = (idDr["cusId"].ToString());
                        }
                        cusCon.Close();

                        if (MessageBox.Show("New Customer Added, Do you want to place an order?", " Confirm", 
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            lblRecCusID.Text = tbNewCusId.Text;
                            paneOrder.Visible = true;
                            paneNewCus.Visible = false;
                            gbNewOrdInfo.Visible = true;
                            paneReceipt.Visible = true;
                        }
                        else
                        {
                            enCusInfo();
                            clrOrder();
                            paneOrder.Visible = true;
                            gbNewOrdInfo.Visible = false;
                            paneReceipt.Visible = false;
                            btnOrdDel.Visible = false;
                            paneNewCus.Visible = true;
                        }
                            
                    }
                    verCon.Close();
                }
                                          
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, " Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void delProd()
        {
            SqlConnection delCon = new SqlConnection(prodcs);

            try
            {
                delCon.Open();
                SqlCommand delCmd = delCon.CreateCommand();
                delCmd.CommandType = CommandType.Text;
                delCmd.CommandText = "Delete from newProdTB where prodId = '" + lblNewProdID.Text + "'";
                delCmd.ExecuteNonQuery();
                delCon.Close();
                MessageBox.Show("Product Deleted!", " Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                viewProd();
                clrNewPro();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, " Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        public void upPro()
        {
            SqlConnection upProd = new SqlConnection(prodcs);
           
            try
            {
                string brand = cbNewProdBrand.Text;
                string cat = cbNewProdCat.Text;
                string name = tbNewProdName.Text;
                string info = tbNewProdInfo.Text;
                string color = tbNewProdCor.Text;
                string qty = tbNewProdQty.Text;
                string size = tbNewProdSize.Text;
                string srp = tbNewProdSRP.Text;
                string prodId = lblNewProdID.Text;
                string pre = numPro.Value.ToString();
                double profit = Double.Parse(pre) / 100;
               
                string date = DateTime.Now.ToShortDateString();

                upProd.Open();
                SqlCommand upCmd = upProd.CreateCommand();
                upCmd.CommandType = CommandType.Text;
                upCmd.CommandText = "Update newprodTB set Brand = '" + brand + "', " +
                                                         "Cat = '" + cat + "', " +
                                                         "Name = '" + name + "', " +
                                                         "Info = '" + info + "', " +
                                                         "Cor = '" + color + "', " +
                                                         "Qty = '" + qty + "', " +
                                                         "Size = '" + size + "', " +
                                                         "SRP = '" + srp + "', " +
                                                         "Rate = '" + profit + "', " +
                                                         "Date = '" + date + "' where prodId = '" + prodId + "'";
                upCmd.ExecuteNonQuery();
                upProd.Close();
                MessageBox.Show("Product Updated!", " Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                viewProd();
                clrNewPro();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, " Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        public void cellProd()
        {
            SqlConnection cellProd = new SqlConnection(prodcs);
            string prodId = gVNewProd.CurrentRow.Cells[0].Value.ToString();

            try
            {
                cellProd.Open();

                SqlCommand cellCmd = cellProd.CreateCommand();
                cellCmd.CommandType = CommandType.Text;
                cellCmd.CommandText = "Select * from newprodTB where prodId = '" + prodId + "'";
                SqlDataReader dr = cellCmd.ExecuteReader();
                if (dr.Read())
                {
                    lblNewProdID.Text = prodId;
                    cbNewProdBrand.Text = (dr["Brand"].ToString());
                    cbNewProdCat.Text = (dr["Cat"].ToString());
                    tbNewProdName.Text = (dr["Name"].ToString());
                    tbNewProdInfo.Text = (dr["Info"].ToString());
                    tbNewProdCor.Text = (dr["Cor"].ToString());
                    tbNewProdQty.Text = (dr["Qty"].ToString());
                    tbNewProdSize.Text = (dr["Size"].ToString());
                    tbNewProdSRP.Text = (dr["SRP"].ToString());
                    string rate = (dr["Rate"].ToString());
                    numPro.Value = Decimal.Parse(rate) * 100;
                    btnNewProdAdd.Text = "UPDATE";
                    cbNewProdBrand.Enabled = false;
                    btnDelProd.Visible = true;
                   
                }
            }
            catch (Exception e)
            {
               MessageBox.Show(e.Message, " Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void viewProd()
        {
            SqlConnection viewProd = new SqlConnection(prodcs);

            try
            {
                viewProd.Open();
                DataTable dt = new DataTable();
                adapt = new SqlDataAdapter("Select prodId as ProdID, Qty, Brand As Distributor, Name As Brand, Info as Name, Size, Cor as Info, SRP, Date as LastUpdate from newprodTB Order By prodId ASC, Qty DESC", viewProd);
                adapt.Fill(dt);
                gVNewProd.DataSource = dt;
                viewProd.Close();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, " Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void ordTrans()
        {
            SqlConnection ordTrans = new SqlConnection(prodcs);

            try
            {
                string pre = "ORDTRAN";
                string date = lblNewODate.Text;
                string time = lblNewOTime.Text;
                string cusId = lblRecCusID.Text;
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
                MessageBox.Show(e.Message, " Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void revet()
        {
            SqlConnection upordCon = new SqlConnection(prodcs);
            string value = gVOrder.CurrentRow.Cells[0].Value.ToString();
            
            try
            {
                upordCon.Open();
                SqlCommand upCmd = upordCon.CreateCommand();
                upCmd.CommandType = CommandType.Text;
                upCmd.CommandText = "Update ordTB Set OrdStat = 'PENDING', " +
                    "RevOrd = '-----' where ordId = '" + value + "'";
                upCmd.ExecuteNonQuery();
                MessageBox.Show(" '" + value + "' has been Reverted!", " Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                viewOrder();
                viewOrderDet();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, " Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
      
        public void ordRecv()
        {
            SqlConnection upordCon = new SqlConnection(prodcs);
            SqlConnection balCon = new SqlConnection(prodcs);
            SqlConnection inCon = new SqlConnection(prodcs);

            string ordId = gVOrdDet.CurrentRow.Cells[0].Value.ToString();
            string dateRecv = DateTime.Now.ToShortDateString();
            DateTime newDate = DateTime.Parse(dateRecv);
            string deadline = newDate.AddMonths(1).ToShortDateString();
            string payId = "00000";

            try
            {
                upordCon.Open();
                SqlCommand upCmd = upordCon.CreateCommand();
                upCmd.CommandType = CommandType.Text;
                upCmd.CommandText = "Update ordTB Set OrdStat = 'RECEIVED', " +
                    "RevOrd = '" + dateRecv + "' where ordId = '" + ordId + "'";
                upCmd.ExecuteNonQuery();
                upordCon.Close();


                balCon.Open();
                SqlCommand balCmd = balCon.CreateCommand();
                balCmd.CommandType = CommandType.Text;
                balCmd.CommandText = "Select * from ordTB where ordId = '" + ordId + "'";
                SqlDataReader dr = balCmd.ExecuteReader();
                
                if (dr.Read())
                {
                    string cusId = (dr["cusId"].ToString());
                    string ordDate = (dr["DateOrd"].ToString());                
                    string total = (dr["Total"].ToString());

                    inCon.Open();
                    SqlCommand inCmd = inCon.CreateCommand();
                    inCmd.CommandType = CommandType.Text;
                    inCmd.CommandText = "Insert into cusBalTB Values ('" + cusId + "', " +
                        "'" + ordId + "', " +
                        "'" + ordDate + "', " +
                        "'" + dateRecv + "', " +
                        "'" + deadline + "', " +
                        "'" + total + "', " +
                        "'" + payId + "')";
                    inCmd.ExecuteNonQuery();

                    tbBrCusId.Text = cusId;
                    tbBrOrdId.Text = ordId;
                    tbBrDateOrd.Text = ordDate;
                    tbBrDateRecv.Text = dateRecv;
                    tbBrDateDue.Text = deadline;
                    tbBrTotal.Text = total;
                    inCon.Close();
                }
                balCon.Close();

                MessageBox.Show(" '" + ordId + "' has been Recevied!", " Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                addOrdPro();
                viewOrder();
                viewOrderDet();
                
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, " Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void newOrder()
        {
            SqlConnection ordNew = new SqlConnection(prodcs);

            try
            {
                string distrib = cbOrdComp.Text;      string name = tbOrdName.Text;
                string cat = cbOrdCat.Text;           string col = tbOrdInfo.Text;
                string month = cbOrdMonth.Text;       string size = tbOrdSize.Text;
                string page = tbOrdPage.Text;         string qty = tbOrdQty.Text;
                string brand = tbOrdBrand.Text;       string srp = tbOrdSrp.Text;

                string ordStat = "PENDING";
                string recv = "-----";
                string cusId = lblRecCusID.Text;
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
                    tbOrdSize.Text = "";
                    tbOrdSrp.Text = "";
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, " Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void addProd()
        {
            SqlConnection addProd = new SqlConnection(prodcs);
            SqlConnection verProd = new SqlConnection(prodcs);

            try
            {
                string brand = cbNewProdBrand.Text;
                string cat = cbNewProdCat.Text;
                string name = tbNewProdName.Text;
                string info = tbNewProdInfo.Text;
                string color = tbNewProdCor.Text;
                string qty = tbNewProdQty.Text;
                string size = tbNewProdSize.Text;
                string srp = tbNewProdSRP.Text;
                string profit = numPro.Value.ToString();
                double pro = Double.Parse(profit) / 100;
                string pre = cbNewProdBrand.Text.ToUpper();
                string prodId = "NW";//pre.Substring(0, 3);
                string date = DateTime.Now.ToShortDateString();


                if (brand == "" || cat == "" || name == "" || info == "" || color == "" ||
                    qty == "" || size == "" || srp == "")
                {
                    MessageBox.Show("Input Missing Boxes!", " Incomplete", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    verProd.Open();
                    SqlCommand verCmd = verProd.CreateCommand();
                    verCmd.CommandType = CommandType.Text;
                    verCmd.CommandText = "Select * from newprodTB where Brand = '" + brand + "' " +
                        "and Cat = '" + cat + "' " +
                        "and Name = '" + name + "' " +
                        "and Info = '" + info + "' " +
                        "and Cor = '" + color + "' " +
                        "and Size = '" + size + "' " +
                        "and SRP = '" + srp + "' " +
                        "and Rate = '" + pro + "'";
                    SqlDataReader verDr = verCmd.ExecuteReader();
                    
                    if (verDr.Read())
                    {
                        MessageBox.Show("Product Already Listed!", " Update", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        lblNewProdID.Text = (verDr["prodId"].ToString());
                        cbNewProdBrand.Text = (verDr["Brand"].ToString());
                        cbNewProdCat.Text = (verDr["Cat"].ToString());
                        tbNewProdName.Text = (verDr["Name"].ToString());
                        tbNewProdInfo.Text = (verDr["Info"].ToString());
                        tbNewProdCor.Text = (verDr["Cor"].ToString());
                        tbNewProdQty.Text = (verDr["Qty"].ToString());
                        tbNewProdSize.Text = (verDr["Size"].ToString());
                        tbNewProdSRP.Text = (verDr["SRP"].ToString());
                        string rate = (verDr["Rate"].ToString());
                        numPro.Value = Decimal.Parse(rate) * 100;
                        btnNewProdAdd.Text = "UPDATE";
                        cbNewProdBrand.Enabled = false;
                        btnDelProd.Visible = true;

                    }
                    else
                    {
                        addProd.Open();
                        SqlCommand prodCmd = addProd.CreateCommand();
                        prodCmd.CommandType = CommandType.Text;
                        prodCmd.CommandText = "Insert into newprodTB Values ('" + prodId + "', " +
                                                                            "'" + brand + "', " +
                                                                            "'" + cat + "', " +
                                                                            "'" + name + "', " +
                                                                            "'" + info + "', " +
                                                                            "'" + color + "', " +
                                                                            "'" + qty + "', " +
                                                                            "'" + size + "', " +
                                                                            "'" + srp + "', " +
                                                                            "'" + pro + "', " +
                                                                            "'" + date + "')";
                        prodCmd.ExecuteNonQuery();
                        prodCmd.CommandText = "Select prodId from newprodTB where Brand = '" + brand + "' " +
                                                                             "and Cat = '" + cat + "' " +
                                                                             "and Name = '" + name + "' " +
                                                                             "and Info = '" + info + "'" +
                                                                             "and Size = '" + size + "' " +
                                                                             "and SRP = '" + srp + "' " +
                                                                             "and Date = '" + date + "'";
                        SqlDataReader dr = prodCmd.ExecuteReader();

                        if (dr.Read())
                        {
                            lblNewProdID.Text = (dr["prodId"].ToString());
                        }
                        addProd.Close();
                        MessageBox.Show("Product Added!", " Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        tbNewProdSRP.Text = "";
                        tbNewProdQty.Text = "";
                        viewProd();
                    }
                    verProd.Close();                  
                }             
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, " Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void adminDash_Load(object sender, EventArgs e)
        {
            tabControl1.TabPages.Clear();
            lblNewODate.Text = DateTime.Now.ToShortDateString();
            lblDate.Text = DateTime.Now.ToLongDateString();
            paneOrder.Visible = false;
            paneSet.Visible = false;
            penalty();
            loadCount();
            viewHomeOrder();
            homeSale();
            homeCusInfo();
            homeStock();
            loadMonth();
            loadSet();
            tabControl1.TabPages.Insert(0, tabHome);

        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            panelSlide.Height = btnHome.Height;
            panelSlide.Top = btnHome.Top;
            tabControl1.TabPages.Clear();
            viewHomeOrder();
            homeSale();
            homeCusInfo();
            loadSet();
            homeStock();
            tabControl1.TabPages.Insert(0, tabHome);
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            panelSlide.Height = btnOrder.Height;
            panelSlide.Top = btnOrder.Top;
            tabControl1.TabPages.Clear();
            viewOrder();
            viewOrderDet();
            clrOrderBr();
            tabControl1.TabPages.Insert(7, tabOrder);
        }

        private void btnCusList_Click(object sender, EventArgs e)
        {
            panelSlide.Height = btnNewProd.Height;
            panelSlide.Top = btnNewProd.Top;
            tabControl1.TabPages.Clear();
            viewProd();
            clrNewPro();
            tabControl1.TabPages.Insert(0, tabNewPro);
        }

        private void btnSales_Click(object sender, EventArgs e)
        {
            panelSlide.Height = btnSales.Height;
            panelSlide.Top = btnSales.Top;
            tabControl1.TabPages.Clear();
            cbSaleMonth.Text = null;
            saleRep();         
            tabControl1.TabPages.Insert(6, tabSales);
            double balTot = gVSales.Rows.Cast<DataGridViewRow>().Sum(t => Convert.ToDouble(t.Cells[6].Value));
            double penalTot = gVPenal.Rows.Cast<DataGridViewRow>().Sum(t => Convert.ToDouble(t.Cells[7].Value));
            tbSaleTot.Text = balTot.ToString();
            tbPenalTot.Text = penalTot.ToString();
        }

        private void btnCusInfo_Click(object sender, EventArgs e)
        {
            panelSlide.Height = btnCusInfo.Height;
            panelSlide.Top = btnCusInfo.Top;
            paneUpCus.Visible = false;
            tabControl1.TabPages.Clear();
            dispCusInfo();
            gVBalDet.DataSource = null;
            gVBal.DataSource = null;
            gVPenOrd.DataSource = null;
            tbCusBal.Text = "";
            lblOrdDue.Text = "00 000 00";
            lblOrdRecv.Text = "00 000 00";          
            tabControl1.TabPages.Insert(4, tabCusInfo);
        }

        private void btnCusAdd_Click(object sender, EventArgs e)
        {
            panelSlide.Height = btnCusAdd.Height;
            panelSlide.Top = btnCusAdd.Top;
            tabControl1.TabPages.Clear();
            paneOrder.Visible = true;
            gbNewOrdInfo.Visible = false; 
            paneReceipt.Visible = false;
            btnOrdDel.Visible = false;
            paneNewCus.Visible = true;
            enCusInfo();
            clrOrder();
            tabControl1.TabPages.Insert(1, tabNewCus);
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            panelSlide.Height = btnPay.Height;
            panelSlide.Top = btnPay.Top;
            tabControl1.TabPages.Clear();
            paneBalBreak.Visible = false;
            panePayNow.Visible = false;
            panePaySlip.Visible = false;
            panePayCusId.Visible = true;
            btnPayClose.Visible = false;
          
            tbPayCusId.Text = "";
            clrPay();
            tabControl1.TabPages.Insert(7, tabPay);
        }
        private void btnRes_Click(object sender, EventArgs e)
        {
            panelSlide.Height = btnRes.Height;
            panelSlide.Top = btnRes.Top;
            tabControl1.TabPages.Clear();
            loadCReceipt();
            loadOReceipt();
            loadPReceipt();
            tbCashSlip.Text = "Search Here";
            tbCashSlip.ForeColor = Color.Gray;
            tbOrdSlip.Text = "Search Here";
            tbOrdSlip.ForeColor = Color.Gray;
            tbPaySlip.Text = "Search Here";
            tbPaySlip.ForeColor = Color.Gray;
            tabControl1.TabPages.Insert(5, tabReceipt);
        }
        private void adminDash_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("This would make application close, Continue?", " Confirm",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                this.FormClosing -= adminDash_FormClosing;
                Application.Exit();
            }
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            lblNewOTime.Text = DateTime.Now.ToLongTimeString();
            lblTime.Text = DateTime.Now.ToLongTimeString();
        }

        private void btnClr_Click(object sender, EventArgs e)
        {
            clrOrdInfo();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Logout?", " Confirm", MessageBoxButtons.YesNo, 
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Login log = new Login();
                log.Show();
                this.Visible = false;
            }
            else
            {
                return;
            }
        }


        private void btnAddCus_Click(object sender, EventArgs e)
        {
            if (btnAddCus.Text == "ADD")
            {
                addCusInfo();
            }
            else if (btnAddCus.Text == "CLEAR")
            {
                enCusInfo();
            }
        }

        private void btnOrdCon_Click(object sender, EventArgs e)
        {
            ordTrans();
        }

        private void btnNewAdd_Click(object sender, EventArgs e)
        {
            if (btnNewProdAdd.Text == "ADD")
            {
                addProd();
            }
            else if (btnNewProdAdd.Text == "UPDATE")
            {
                upPro();
            }
        }

        private void gVNewProd_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (gVNewProd.Rows.Count == 0)
            {
                MessageBox.Show ("Data Empty!", " Empty", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                cellProd();
            }
        }

        private void btnNewProdClr_Click(object sender, EventArgs e)
        {
            clrNewPro();
        }

        private void btnAddOrd_Click(object sender, EventArgs e)
        {            
            newOrder();
        }

        private void btnDelProd_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show ("Do you want to delete this product?", " Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                delProd();
            }
            else
            {
                return;
            }
            
        }

        private void gVCusInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            paneUpCus.Visible = false;
            tbCusBal.Text = "";
            lblOrdDue.Text = "00 000 00";
            lblOrdRecv.Text = "00 000 00";           
            loadPenOrd();
            viewBalDet();
        }

        private void btnUpCus_Click(object sender, EventArgs e)
        {
            cellCus();
        }

        private void cbNewCusCount_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbNewCusPro.Text = "";
            cbNewCusPro.Items.Clear();
            cbNewCusMun.Text = "";
            cbNewCusMun.Items.Clear();
            cbNewCusBar.Text = "";
            cbNewCusBar.Items.Clear();


            SqlConnection loadPro = new SqlConnection(councs);
            string count = cbNewCusCount.Text;


            try
            {
                loadPro.Open();
                SqlCommand proCmd = loadPro.CreateCommand();
                proCmd.CommandType = CommandType.Text;
                proCmd.CommandText = "Select Province from countTB where Country = '" + count + "'";
                SqlDataReader proDr = proCmd.ExecuteReader();

                while (proDr.Read())
                {
                    string pro = proDr["Province"].ToString();

                    while (!cbNewCusPro.Items.Contains(pro))
                    {
                        cbNewCusPro.Items.Add(pro);
                    }
                }
            }
            catch (Exception f)
            {
                MessageBox.Show(f.Message, " Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            loadPro.Close();
        }

        private void cbNewCusPro_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbNewCusMun.Text = "";
            cbNewCusMun.Items.Clear();

            SqlConnection loadMun = new SqlConnection(councs);

            string count = cbNewCusCount.Text;
            string pro = cbNewCusPro.Text;
            
            try
            {
                loadMun.Open();
                SqlCommand munCmd = loadMun.CreateCommand();
                munCmd.CommandType = CommandType.Text;
                munCmd.CommandText = "Select Municipality from countTB where Country = '" + count + "' " +
                                                                         "and Province = '" + pro + "' Order By Municipality ASC";
                SqlDataReader munDr = munCmd.ExecuteReader();

                while (munDr.Read())
                {
                    string mun = munDr["Municipality"].ToString();

                    while (!cbNewCusMun.Items.Contains(mun))
                    {
                        cbNewCusMun.Items.Add(mun);
                    }
                }

            }
            catch (Exception f)
            {
                MessageBox.Show(f.Message, " Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            loadMun.Close();
        }

        private void cbNewCusMun_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbNewCusBar.Text = "";
            cbNewCusBar.Items.Clear();

            SqlConnection loadMun = new SqlConnection(councs);

            string count = cbNewCusCount.Text;
            string pro = cbNewCusPro.Text;
            string mun = cbNewCusMun.Text;

            try
            {
                loadMun.Open();
                SqlCommand munCmd = loadMun.CreateCommand();
                munCmd.CommandType = CommandType.Text;
                munCmd.CommandText = "Select Barangay from countTB where Country = '" + count + "' " +
                                                                         "and Province = '" + pro + "' " +
                                                                         "and Municipality = '" + mun + "' Order By Municipality ASC";
                SqlDataReader munDr = munCmd.ExecuteReader();

                while (munDr.Read())
                {
                    string bar = munDr["Barangay"].ToString();

                    while (!cbNewCusBar.Items.Contains(bar))
                    {
                        cbNewCusBar.Items.Add(bar);
                    }
                }

            }
            catch (Exception f)
            {
                MessageBox.Show(f.Message, " Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            loadMun.Close();
        }

        private void cbUpCusCoun_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbUpCusPro.Text = "";
            cbUpCusPro.Items.Clear();
            cbUpCusMun.Text = "";
            cbUpCusMun.Items.Clear();
            cbUpCusBar.Text = "";
            cbUpCusBar.Items.Clear();
            tbUpCusHou.Text = "";


            SqlConnection loadPro = new SqlConnection(councs);
            string count = cbUpCusCoun.Text;


            try
            {
                loadPro.Open();
                SqlCommand proCmd = loadPro.CreateCommand();
                proCmd.CommandType = CommandType.Text;
                proCmd.CommandText = "Select Province from countTB where Country = '" + count + "'";
                SqlDataReader proDr = proCmd.ExecuteReader();

                while (proDr.Read())
                {
                    string pro = proDr["Province"].ToString();

                    while (!cbUpCusPro.Items.Contains(pro))
                    {
                        cbUpCusPro.Items.Add(pro);
                    }
                }
            }
            catch (Exception f)
            {
                MessageBox.Show(f.Message, " Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            loadPro.Close();
        }

        private void cbUpCusPro_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbUpCusMun.Text = "";
            cbUpCusMun.Items.Clear();

            SqlConnection loadMun = new SqlConnection(councs);

            string count = cbUpCusCoun.Text;
            string pro = cbUpCusPro.Text;

            try
            {
                loadMun.Open();
                SqlCommand munCmd = loadMun.CreateCommand();
                munCmd.CommandType = CommandType.Text;
                munCmd.CommandText = "Select Municipality from countTB where Country = '" + count + "' " +
                                                                         "and Province = '" + pro + "' Order By Municipality ASC";
                SqlDataReader munDr = munCmd.ExecuteReader();

                while (munDr.Read())
                {
                    string mun = munDr["Municipality"].ToString();

                    while (!cbUpCusMun.Items.Contains(mun))
                    {
                        cbUpCusMun.Items.Add(mun);
                    }
                }

            }
            catch (Exception f)
            {
                MessageBox.Show(f.Message, " Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            loadMun.Close();

        }

        private void cbUpCusMun_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbUpCusBar.Text = "";
            cbUpCusBar.Items.Clear();

            SqlConnection loadMun = new SqlConnection(councs);

            string count = cbUpCusCoun.Text;
            string pro = cbUpCusPro.Text;
            string mun = cbUpCusMun.Text;

            try
            {
                loadMun.Open();
                SqlCommand munCmd = loadMun.CreateCommand();
                munCmd.CommandType = CommandType.Text;
                munCmd.CommandText = "Select Barangay from countTB where Country = '" + count + "' " +
                                                                         "and Province = '" + pro + "' " +
                                                                         "and Municipality = '" + mun + "' Order By Municipality ASC";
                SqlDataReader munDr = munCmd.ExecuteReader();

                while (munDr.Read())
                {
                    string bar = munDr["Barangay"].ToString();

                    while (!cbUpCusBar.Items.Contains(bar))
                    {
                        cbUpCusBar.Items.Add(bar);
                    }
                }

            }
            catch (Exception f)
            {
                MessageBox.Show(f.Message, " Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            loadMun.Close();
        }

        private void btnCusUpd_Click(object sender, EventArgs e)
        {
            upCusInfo();
        }

        private void btnCusMin_Click(object sender, EventArgs e)
        {
            paneUpCus.Visible = false;
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

        private void btnOrdDel_Click(object sender, EventArgs e)
        {
            delNewOrd();
        }

        private void btnWDraw_Click(object sender, EventArgs e)
        {
            wDrawOrd();
        }

        private void tbSerCus_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                searchCus();
            }
        }

        private void tbSerCus_MouseClick(object sender, MouseEventArgs e)
        {
            tbSerCus.Text = "";
            tbSerCus.ForeColor = Color.Black;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dispCusInfo();
            tbSerCus.Text = "Search Here";
            tbSerCus.ForeColor = Color.Gray;
        }

        private void tbSerProd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                searchProd();
            }
        }

        private void tbSerProd_MouseClick(object sender, MouseEventArgs e)
        {
            tbSerProd.Text = "";
            tbSerProd.ForeColor = Color.Black;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            viewProd();
            tbSerProd.Text = "Search Here";
            tbSerProd.ForeColor = Color.Gray;
        }

        private void btnOrdRecv_Click(object sender, EventArgs e)
        {
            ordRecv();
        }


        private void gVOrder_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cellOrderBr();
        }

        private void gVBalDet_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cellBalDet();
        }

        private void btnCusAddOrd_Click(object sender, EventArgs e)
        {
            string value = gVCusInfo.CurrentRow.Cells[0].Value.ToString();
            cusId = value;

            OrderForm ord = new OrderForm();
            ord.ShowDialog();
        }

        private void tbCashSlip_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                cashSlip();
            }
        }

        private void tbOrdSlip_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                orderSlip();
            }
        }

        private void tbCashSlip_MouseClick(object sender, MouseEventArgs e)
        {
            tbCashSlip.Text = "";
            tbCashSlip.ForeColor = Color.Black;
        }

        private void tbOrdSlip_MouseClick(object sender, MouseEventArgs e)
        {
            tbOrdSlip.Text = "";
            tbOrdSlip.ForeColor = Color.Black;
        }

        private void btnCashRe_Click(object sender, EventArgs e)
        {
            loadCReceipt();          
            tbCashSlip.Text = "Search Here";
            tbCashSlip.ForeColor = Color.Gray;
        }

        private void btnOrdRe_Click(object sender, EventArgs e)
        {
            loadOReceipt();
            tbOrdSlip.Text = "Search Here";
            tbOrdSlip.ForeColor = Color.Gray;
        }

        private void tbPayCusId_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            if (e.KeyChar == (char)Keys.Enter)
            {
                payCusId();
            }
        }

        private void gVPayBalDet_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cellPay();
        }


        private void printBalPay_PrintPage(object sender, PrintPageEventArgs e)
        {
            try
            {
                Bitmap bmp = new Bitmap(panePaySlip.Width, panePaySlip.Height);
                Rectangle rect = new Rectangle(0, 0, panePaySlip.Width, panePaySlip.Height);
                panePaySlip.DrawToBitmap(bmp, rect);
                Clipboard.SetImage(bmp);
                e.Graphics.DrawImage(bmp, 150, 15);

            }
            catch (Exception f)
            {
                MessageBox.Show(f.Message, " Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tbNewCusFirst_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.Handled = Char.IsPunctuation(e.KeyChar) ||
                Char.IsSeparator(e.KeyChar) ||
                Char.IsSymbol(e.KeyChar))

            {
                MessageBox.Show("Invalid Character!", " Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (e.Handled = Char.IsNumber(e.KeyChar))
            {
                MessageBox.Show("Can't contain numbers!", " Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void tbNewCusFirst_Leave(object sender, EventArgs e)
        {
            var tb = (TextBox)sender;
            if (tb.Text.Length > 0)
            {
                tb.Text = Char.ToUpper(tb.Text[0]) + tb.Text.Substring(1);
            }
        }

        private void cbSaleMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbSaleYear.Text = "";
            
            SqlConnection con = new SqlConnection(prodcs);
            string month = cbSaleMonth.Text;
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Select * from saleTB where Month = '" + month + "'";
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    string year = (dr["saleYear"].ToString());

                    if (!cbSaleYear.Items.Contains(year))
                    {
                        cbSaleYear.Items.Add(year);
                    }
                }
            }
            catch(Exception f)
            {
                MessageBox.Show(f.Message, " Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRe_Click(object sender, EventArgs e)
        {
            saleRep();
            cbSaleMonth.Text = "";
            cbSaleYear.Text = "";
            tbPenalCus.Text = "Search Here";
            tbPenalCus.ForeColor = Color.Gray;
        }

        private void btnSalePrint_Click(object sender, EventArgs e)
        {
           salePrint();
        }

        private void btnPenalPrint_Click(object sender, EventArgs e)
        {
            penaltyPrint();
        }

        private void tbNewCusMid_Leave(object sender, EventArgs e)
        {
            var tb = (ComboBox)sender;
            if (tb.Text.Length > 0)
            {
                tb.Text = Char.ToUpper(tb.Text[0]) + tb.Text.Substring(1);
            }
        }

        private void btnSetSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Save?", " Confirm", 
                MessageBoxButtons.YesNo, 
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                upSet();
            }
            else
            {
                loadSet();
            }
        }

        private void btnSet_Click(object sender, EventArgs e)
        {
            if (paneSet.Visible == false)
            {
                paneSet.Visible = true;
                paneSet.BringToFront();
            }
            else
                paneSet.Visible = false;
            loadSet();
        }

        private void btnFB_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.facebook.com/messages/t/spyrax192");
        }

        private void btnTwit_Click(object sender, EventArgs e)
        {
            Process.Start("https://twitter.com/spyrax10");
        }

        private void btnLink_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.linkedin.com/in/emmanuel-rebaño/");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            orderPrint();
        }

        private void tbPaySlip_MouseClick(object sender, MouseEventArgs e)
        {
            tbPaySlip.Text = "";
            tbPaySlip.ForeColor = Color.Black;
        }

        private void tbPaySlip_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                paySlip();
            }
        }

        private void btnPayRe_Click(object sender, EventArgs e)
        {
            loadPReceipt();
            tbPaySlip.Text = "Search Here";
            tbPaySlip.ForeColor = Color.Gray;
        }

        private void btnCusPay_Click(object sender, EventArgs e)
        {
            slipPay();
        }

        private void btnPayPrint_Click(object sender, EventArgs e)
        {
            payTrans();
        }


        private void copyCusIdToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (ActiveCell != null && ActiveCell.Value != null)
                    Clipboard.SetText(ActiveCell.Value.ToString());
            }
            catch (Exception f)
            {
                MessageBox.Show(f.Message, " Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void gVCusInfo_MouseDown(object sender, MouseEventArgs e)
        {
          
            if (e.Button == MouseButtons.Right)
            {
                DataGridView.HitTestInfo hittestinfo = gVCusInfo.HitTest(e.X, e.Y);


                if (hittestinfo != null && hittestinfo.Type == DataGridViewHitTestType.Cell && hittestinfo.ColumnIndex == 0)
                {
                    ActiveCell = gVCusInfo[hittestinfo.ColumnIndex, hittestinfo.RowIndex];
                    ActiveCell.Selected = true;
                    contextMenuStrip1.Show(gVCusInfo, new Point(e.X, e.Y));
                }
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("This will bring you to the Screen page, Continue?", " Verify", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Screen sc = new Screen();
                sc.Show();
                this.Visible = false;
            }
            else
            {
                return;
            }
        }

        private void cbNewCusCount_KeyPress(object sender, KeyPressEventArgs e)
        {
            MessageBox.Show("Please select from Selection!", " Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
            e.Handled = true;
        }

        private void cbNewProdBrand_KeyPress(object sender, KeyPressEventArgs e)
        {
            MessageBox.Show("Please select from Selection!", " Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
            e.Handled = true;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void btnPayClose_Click(object sender, EventArgs e)
        {
            paneBalBreak.Visible = false;
            panePayNow.Visible = false;
            panePaySlip.Visible = false;
            panePayCusId.Visible = true;
            btnPayClose.Visible = false;

            tbPayCusId.Text = "";
            clrPay();
        }

        private void tbPenalCus_MouseClick(object sender, MouseEventArgs e)
        {
            tbPenalCus.Text = "";
            tbPenalCus.ForeColor = Color.Black;
        }

        private void tbPenalCus_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)Keys.Enter)
            {
                if(tbPenalCus.Text != "")
                {
                    penalRep();
                }
            }
        }

        private void cbSaleYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbSaleMonth.Text == "")
            {
                MessageBox.Show("Select Month!", " Invalid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                cbSale();
            }
        }
    }
}
