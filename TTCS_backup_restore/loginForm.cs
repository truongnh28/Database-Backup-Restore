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
        public loginForm()
        {
            InitializeComponent();
        }

        private void loginOkBtnClicked(object sender, EventArgs e)
        {
            DAO.serverName = serverNameTxt.Text;
            DAO.userName = loginNameTxt.Text;
            DAO.password = passwordTxt.Text;
            int isConnection = DAO.connectionDB();
            if (isConnection == 0)
            {
                mainForm form = new mainForm();
                this.Hide();
                form.ShowDialog();
            }
            else
            {
                passwordTxt.Text = "";
                loginNameTxt.Focus();
                MessageBox.Show("Đăng nhập thất bại");
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