using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace TTCS_backup_restore
{
    public partial class loginForm : DevExpress.XtraEditors.XtraForm
    {
        public static string connectionString = "server=";
        public loginForm()
        {
            InitializeComponent();
        }

        private void loginOkBtnClicked(object sender, EventArgs e)
        {
            connectionString = "server=";
            connectionString += ";uid=" + loginNameTxt.Text;
            connectionString += ";pwd=" + passwordTxt.Text;
            bool isConnection = false;
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = connectionString;
                con.Open();
                isConnection = true;
                con.Close();
            }
            catch (Exception ex)
            {
                passwordTxt.Text = "";
                loginNameTxt.Focus();
                MessageBox.Show(ex.Message);
            }
            if(isConnection)
            {
                mainForm form = new mainForm();
                this.Hide();
                form.ShowDialog();
            }
        }

        private void loginCancelBtn_Clicked(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void loginNameTxtKeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 13)
            {
                passwordTxt.Focus();
            }
        }

        private void passwordTxtKeyPress(object sender, KeyPressEventArgs e)
        { 
            if(e.KeyChar == 13)
            {
                loginOkBtnClicked(sender, e);
            }
        }
    }
}