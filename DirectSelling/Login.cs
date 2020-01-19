using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DirectSelling
{
    public partial class Login : Form
    {
        
        string prodcs = @"Data Source=D8672B6A3F8B574\LOCAL;Initial Catalog=sellDB;Integrated Security=True";
       
        [DllImport("wininet.dll")]
        private extern static bool InternetGetConnectedState(out int Description, int ReservedValue);

        public Login()
        {
            InitializeComponent();
        }
        private static string RandomString(int length)
        {
            Random random = new Random();
            const string pool = "abcdefghijklmnopqrstuvwxyz0123456789";
            var builder = new StringBuilder();

            for (var i = 0; i < length; i++)
            {
                var c = pool[random.Next(0, pool.Length)];
                builder.Append(c);
            }

            return builder.ToString();
        }
        public void chk()
        {
            int Desc;
            String chk = InternetGetConnectedState(out Desc, 0).ToString();
           
            if (chk == "True")
            {
                codeReq();
            }
            else if (chk == "False")
            {
                MessageBox.Show("Please check your network and try again.. ", " No Connection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                MessageBox.Show("Fatal Error!", " Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        public void log()
        {
            SqlConnection logCon = new SqlConnection(prodcs);

            string user = tbUser.Text;
            string pass = tbPass.Text;

            try
            {
                logCon.Open();
                SqlCommand cmd = logCon.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Select * from setTB where username = '" + user + "' " +
                    "and password = '" + pass + "'";
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    MessageBox.Show("Login Successful!", " Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tbUser.Text = "";
                    tbPass.Text = "";
                    Screen sc = new Screen();
                    sc.Show();
                    this.Visible = false;
                }
                else
                {
                    MessageBox.Show("Incorrect Combination!", " Invalid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, " Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void codeLog()
        {
            SqlConnection verCon = new SqlConnection(prodcs);
            SqlConnection upCon = new SqlConnection(prodcs);

            string code = tbCode.Text;
            string date = DateTime.Now.ToShortDateString();
            string user = tbUser.Text;
            string time = DateTime.Now.ToShortTimeString();
            string stat = "USED";

            try
            {
                verCon.Open();
                SqlCommand verCmd = verCon.CreateCommand();
                verCmd.CommandType = CommandType.Text;
                verCmd.CommandText = "Select * from codeTB where code = '" + code + "' " +
                    "and DateReq = '" + date + "' " +
                   // "and user = '" + user + "' " +
                    "and status = 'ACTIVE'";
                SqlDataReader dr = verCmd.ExecuteReader();

                if (dr.Read())
                {
                    upCon.Open();
                    SqlCommand upCmd = upCon.CreateCommand();
                    upCmd.CommandType = CommandType.Text;
                    upCmd.CommandText = "Update codeTB set TimeLog = '" + time + "', " +
                        "status = '" + stat + "'" +
                        "where code = '" + code + "' " +
                        "and DateReq = '" + date + "'";
                       
                    upCmd.ExecuteNonQuery();
                    upCon.Close();

                    MessageBox.Show("Login Successful!", " Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Screen sc = new Screen();
                    sc.Show();
                    this.Visible = false;
                }
                else
                {
                    MessageBox.Show("Code Error!", " Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                verCon.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, " Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void codeReq()
        {
            SqlConnection codeCon = new SqlConnection(prodcs);

            string code = RandomString(5);
            string user = tbUser.Text;
            string date = DateTime.Now.ToShortDateString();
            string time = "-----";
            string stat = "ACTIVE";
            string email = "smarteman10@gmail.com";

            try
            {
                if (tbUser.Text == "")
                {
                    MessageBox.Show("Username required...", " Invalid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tbUser.Focus();
                }
                else
                {
                    gBLog.Visible = false;
                    panePass.Visible = true;


                    codeCon.Open();
                    SqlCommand cmd = codeCon.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "Insert into codeTB Values('" + code + "', " +
                        "'" + stat + "', " +
                        "'" + date + "', " +
                        "'" + time + "', " +
                        "'" + user + "')";
                    cmd.ExecuteNonQuery();
                    codeCon.Close();

                    // Sending Email
                    SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                    MailMessage mail = new MailMessage();
                    mail.From = new MailAddress("sistemoquizo@gmail.com");
                    mail.To.Add(email);
                    mail.Subject = "Recovery Code: " + date + "";
                    mail.Body = "Username: " + user + "" + Environment.NewLine + "Code: " + code + "";

                    SmtpServer.Port = 587;
                    SmtpServer.Credentials = new System.Net.NetworkCredential("sistemoquizo@gmail.com", "qUizandexamsystem101");
                    SmtpServer.EnableSsl = true;
                    SmtpServer.Send(mail);

                    tbCode.Focus();
                }
        
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, " Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
            panePass.Visible = false;
        }

        private void btnLog_Click(object sender, EventArgs e)
        {
            if (tbUser.Text == "" || tbPass.Text == "")
            {
                MessageBox.Show("Empty Fields!", " Invalid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                log();
            }
        }

        private void lblCode_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            chk();
        }

        private void btnCode_Click(object sender, EventArgs e)
        {
            if (tbCode.Text == "")
            {
               MessageBox.Show("Code needed...", " Empty", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbCode.Focus();
            }
            else
            {
                codeLog();
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            tbCode.Text = "";
            gBLog.Visible = true;
            gBCode.Visible = false;
            panePass.Visible = false;
        }

        private void btnFB_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.facebook.com/messages/t/spyrax192");
        }
    }
}
