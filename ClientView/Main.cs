using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientView
{
    public partial class Main : Form
    {
        int move = 0;
        int left = 5;

        string cs = @"Data Source=D8672B6A3F8B574\LOCAL;Initial Catalog=sellDB;Integrated Security=True";
        string councs = @"Data Source=D8672B6A3F8B574\LOCAL;Initial Catalog=countDB;Integrated Security=True"; 
        SqlDataAdapter adapt;
        public Main()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
            Rectangle workingArea = Screen.GetWorkingArea(this);
            this.Location = new Point(workingArea.Right - Size.Width, workingArea.Bottom - Size.Height);
          
        }
        public void cellBal()
        {
            SqlConnection cellCon = new SqlConnection(cs);

            string ordId = gVBalDet.CurrentRow.Cells[0].Value.ToString();

            try
            {
                cellCon.Open();
                SqlCommand cmd = cellCon.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Select * from cusBalTB " +
                    "where ordId = '" + ordId + "'";
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    lblRecv.Text = (dr["ordRecv"].ToString());
                    lblDue.Text = (dr["ordDead"].ToString());
                }
                cellCon.Close();
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message, " Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                    paneID.Visible = true;
                    
                    tbID.Focus();
                }
            }
            catch (Exception f)
            {
                MessageBox.Show(f.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
            timer2.Start();
            paneID.Visible = false;
            paneDet.Visible = false;
      
        }
        public void cusDet()
        {
            SqlConnection detCon = new SqlConnection(cs);
            string cusId = tbID.Text;
           

            try
            {
                detCon.Open();
                DataTable dt = new DataTable();
                adapt = new SqlDataAdapter("Select ordId as OrdID, Qty, " +
                    "Distrib as Company, Name from ordTB where cusId = '" + cusId + "' " +
                    "and OrdStat = 'PENDING' order by ordId DESC", detCon);
                adapt.Fill(dt);
                gVPenOrd.DataSource = dt;
                
                DataTable dt2 = new DataTable();
                adapt = new SqlDataAdapter("Select ordId as OrdID, Qty, " +
                    "Distrib as Company, Name, Total from ordTB where cusId = '" + cusId + "' " +
                    "and OrdStat = 'RECEIVED' order by ordId DESC", detCon);
                adapt.Fill(dt2);
                gVBalDet.DataSource = dt2;

                DataTable dt3 = new DataTable();
                adapt = new SqlDataAdapter("Select prodBal As Balance from cusBalTB " +
                    "where cusId = '" + cusId + "' and prodBal !=0 order by ordId DESC", detCon);
                adapt.Fill(dt3);
                gVBal.DataSource = dt3;

                DataTable dt4 = new DataTable();
                adapt = new SqlDataAdapter("Select payId As PayID, prodId as ProdID, Date, Cash As Payment " +
                    "from cusPayTB where cusId = '" + cusId + "' Order By payId DESC", detCon);
                adapt.Fill(dt4);
                gVPay.DataSource = dt4;

                detCon.Close();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, " Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void cusId()
        {
            SqlConnection idCon = new SqlConnection(cs);
            SqlConnection totBalCon = new SqlConnection(cs);

            try
            {
                idCon.Open();
                SqlCommand idCmd = idCon.CreateCommand();
                idCmd.CommandType = CommandType.Text;
                idCmd.CommandText = "Select * from cusTB where cusId = '" + tbID.Text + "'";
                SqlDataReader dr = idCmd.ExecuteReader();

                if (dr.Read())
                {
                    string first = (dr["Firstname"].ToString());
                    string mid = (dr["Midname"].ToString());
                    string last = (dr["Lastname"].ToString());

                    MessageBox.Show("Customer ID Found!", " Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lblCusID.Text = tbID.Text;
                    lblCusName.Text = last + ", " + first + " " + mid;
                    cusDet();
                    totBalCon.Open();
                    SqlCommand totCmd = totBalCon.CreateCommand();
                    totCmd.CommandType = CommandType.Text;
                    totCmd.CommandText = "Select SUM(Cast(prodBal as float)) as prodBal from cusBalTB where cusId = '" + tbID.Text + "'";
                    SqlDataReader dr2 = totCmd.ExecuteReader();

                    if (dr2.Read())
                    {
                        lblCusBal.Text = (dr2["prodBal"].ToString());
                    }
                    paneDet.Visible = true;
                    paneID.Visible = false;
                    tbID.Text = "";
                }
                else
                {
                    MessageBox.Show("Customer ID Not Found!", " Invalid", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                idCon.Close();
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message, " Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tbID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                cusId();
            }
            else if (e.Handled = Char.IsWhiteSpace(e.KeyChar) ||
              Char.IsPunctuation(e.KeyChar) ||
              Char.IsSeparator(e.KeyChar))
            {
                return;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            paneDet.Visible = false;
            paneLogo.Visible = true;
            left = 5;
            timer1.Start();
            timer2.Start();
            tbID.Focus();
        }

        private void gVBalDet_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cellBal();
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

    }
}
