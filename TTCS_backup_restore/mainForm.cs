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
using Microsoft.SqlServer.Management.Smo;
using System.IO;
using System.Data.SqlClient;
using System.Collections;

namespace TTCS_backup_restore
{
    public partial class mainForm : DevExpress.XtraEditors.XtraForm
    {
        private int rowSelected = -1;
        public mainForm()
        {
            InitializeComponent();
            tabPageTest();
            chonGio.Value = DateTime.Today;
            chonNgay.Value = DateTime.Today;
            chooseTimePanel.Visible = false;
            nameServerListTabcontrol.SelectedIndexChanged += new EventHandler(Tabs_SelectedIndexChanged);
        }

        public static ArrayList GetDatabaseNames()
        {
            string query = "SELECT name FROM sys.databases WHERE(database_id >= 5) AND(NOT(name LIKE N'ReportServer%')) ORDER BY NAME";
            var reader = DAO.execSqlDataReader(query, DAO.connectionString);
            ArrayList ans = new ArrayList();
            while (reader.Read())
            {
                ans.Add(reader["name"].ToString());
            }
            return ans;
        }

        public void tabPageTest()
        {
            var serverNameList = GetDatabaseNames();
            foreach (string it in serverNameList)
            {
                TabPage tabPage = new TabPage(it);
                nameServerListTabcontrol.TabPages.Add(tabPage);
            }
            nameDBTxt.Text = nameServerListTabcontrol.SelectedTab.Text;
            mainProcess();
        }
      

        private void tabControl_DrawItem(object sender, DrawItemEventArgs e)
        {
            Graphics g = e.Graphics;
            Brush _textBrush;
            TabPage _tabPage = nameServerListTabcontrol.TabPages[e.Index];
            Rectangle _tabBounds = nameServerListTabcontrol.GetTabRect(e.Index);
            if (e.State == DrawItemState.Selected)
            {
                _textBrush = new System.Drawing.SolidBrush(e.ForeColor);
                g.FillRectangle(Brushes.Gray, e.Bounds);
            }
            else
            {
                _textBrush = new System.Drawing.SolidBrush(e.ForeColor);
                e.DrawBackground();
            }
            Font _tabFont = new Font("Arial", (float)12.0, FontStyle.Bold);
            StringFormat _stringFlags = new StringFormat();
            _stringFlags.Alignment = StringAlignment.Center;
            _stringFlags.LineAlignment = StringAlignment.Center;
            g.DrawString(_tabPage.Text, _tabFont, _textBrush, _tabBounds, new StringFormat(_stringFlags));
        }

        private void saoLuuClicked(object sender, MouseEventArgs e)
        {
            string descriptionStr = ""; 
            string query = $@"BACKUP DATABASE {nameServerListTabcontrol.SelectedTab.Text} TO DEVICE_{nameServerListTabcontrol.SelectedTab.Text}";
            if (delAllBackupsCheckBox.Checked && MessageBox.Show("Bạn có thật sự muốn xóa các bản sao lưu cũ.", "Xác nhận", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                Exten.ShowInputDialogBox(ref descriptionStr, "Hãy nhập vào mô tả của bản sao lưu (không dấu)", "Mô tả", 410, 120);
                descriptionStr = Exten.ConvertVN(descriptionStr);
                query += $@" WITH INIT, DESCRIPTION = '{descriptionStr}'";
            }
            else
            {
                Exten.ShowInputDialogBox(ref descriptionStr, "Hãy nhập vào mô tả của bản sao lưu (không dấu)", "Mô tả", 410, 120);
                descriptionStr = Exten.ConvertVN(descriptionStr);
                query += $@" WITH DESCRIPTION = '{descriptionStr}'";
            }
            int err = DAO.execSqlNonQuery(query, DAO.connectionString);
            delAllBackupsCheckBox.Checked = false;
            if (err == 0)
            {
                MessageBox.Show("Sao lưu thành công");
            }
            else
            {
                MessageBox.Show(DAO.errstr);
            }
            mainProcess();
        }

        private void Tabs_SelectedIndexChanged(object sender, EventArgs e)
        {
            rowSelected = -1;
            mainProcess();
        }

        public static bool haveDevices(string serverName)
        {
            string query = "SELECT name FROM sys.sysdevices";
            var reader = DAO.execSqlDataReader(query, DAO.connectionString);
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    if (reader["name"].ToString().Equals($"DEVICE_{serverName}"))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private void mainProcess()
        {
            nameDBTxt.Text = nameServerListTabcontrol.SelectedTab.Text;
            bool haveDevice = haveDevices(nameServerListTabcontrol.SelectedTab.Text);
            taoDeviceBtn.Enabled = !haveDevice;
            saoLuuBtn.Enabled = haveDevice;
            thamSoPhucHoiBtn.Enabled = haveDevice;
            phucHoiBtn.Enabled = rowSelected > -1 || (rowSelected == -1 && thamSoPhucHoiCheckbox.Checked == true);
            delBackupSetItemBtn.Enabled = (rowSelected > -1);
            dataBackupSetTable.DataSource = backupSetTableAdapter.GetBackupSetTable(nameServerListTabcontrol.SelectedTab.Text);
            if (dataBackupSetTable.Rows.GetRowCount(DataGridViewElementStates.None) > 0)
            {
                dataBackupSetTable.Rows[0].Selected = false;
            }
        }

        private void cancelBtnClicked(object sender, EventArgs e)
        {
            if(MessageBox.Show("Bạn có thật sự muốn thoát.", "Xác nhận", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void taoDeviceBtn_Click(object sender, EventArgs e)
        {
            string query = $@"EXEC SP_ADDUMPDEVICE 'DISK', 'DEVICE_{nameServerListTabcontrol.SelectedTab.Text}', 'D:\\TTCS_BACKUP\\DEVICE_{nameServerListTabcontrol.SelectedTab.Text}'";
            int err = DAO.execSqlNonQuery(query, DAO.connectionString);
            if(err == 0)
            {
                MessageBox.Show("Tạo Device thành công");
            }
            else
            {
                MessageBox.Show(DAO.errstr);
            }
            mainProcess();
        }

        private void thamSoPhucHoiBtn_Click(object sender, EventArgs e)
        {
            thamSoPhucHoiCheckbox.Checked = !thamSoPhucHoiCheckbox.Checked;
            chooseTimePanel.Visible = thamSoPhucHoiCheckbox.Checked;
            mainProcess();
        }

        private bool checkDate(DateTime backupDate, DateTime restoreDate)
        {
            return backupDate <= restoreDate;
        }
        private void phucHoiBtn_Click(object sender, EventArgs e)
        {
            // Ngắt kết nối của chính ta
            if (DAO.con != null && DAO.con.State == ConnectionState.Open) DAO.con.Close();
            string query = $@"ALTER DATABASE {nameServerListTabcontrol.SelectedTab.Text} SET SINGLE_USER WITH ROLLBACK IMMEDIATE 
                                USE tempdb ";
            if (thamSoPhucHoiCheckbox.Checked == false)
            {
                query += $@"
                            RESTORE DATABASE {nameServerListTabcontrol.SelectedTab.Text} FROM DEVICE_{nameServerListTabcontrol.SelectedTab.Text} WITH FILE = {dataBackupSetTable.Rows[rowSelected].Cells[0].Value}, REPLACE, RECOVERY 
                            ALTER DATABASE {nameServerListTabcontrol.SelectedTab.Text} SET MULTI_USER";
                int err = DAO.execSqlNonQuery(query, DAO.connectionString);
                if(err == 0)
                {
                    MessageBox.Show("Phục hồi thành công");
                }
                else
                {
                    MessageBox.Show(DAO.errstr);
                }
            }
            else
            {
                // thời gian sao lưu tối thiếu 3 phút sau khi backup và 1 phút trước khi sự cố xảy ra
                var backupFullMaxPosition = dataBackupSetTable.Rows[0].Cells[0].Value;
                DateTime dayTmp = DateTime.ParseExact(dataBackupSetTable.Rows[0].Cells[2].Value.ToString(), "dd-MM-yyyy HH:mm:ss", null);
                string restoreDateStr = chonNgay.Value.ToString("dd'-'MM'-'yyyy") + ' ' + chonGio.Value.ToString("HH:mm:ss");
                DateTime backupDate = DateTime.ParseExact(dayTmp.ToString("dd'-'MM'-'yyyy HH:mm:ss"), "dd'-'MM'-'yyyy HH:mm:ss", null);
                DateTime restoreDate = DateTime.ParseExact(restoreDateStr, "dd'-'MM'-'yyyy HH:mm:ss", null);
                string restoreDateParameter = restoreDate.ToString("yyyy'-'MM'-'dd HH:mm:ss");
                if (checkDate(backupDate, restoreDate))
                {
                    query += $@"
                                BACKUP LOG {nameServerListTabcontrol.SelectedTab.Text} TO DEVICE_LOG WITH INIT, NORECOVERY
                                RESTORE DATABASE {nameServerListTabcontrol.SelectedTab.Text} FROM DEVICE_{nameServerListTabcontrol.SelectedTab.Text} WITH FILE = {backupFullMaxPosition}, NORECOVERY 
                                RESTORE DATABASE {nameServerListTabcontrol.SelectedTab.Text} FROM DEVICE_LOG WITH FILE = 1, STOPAT = '{restoreDateParameter}', RECOVERY
                                ALTER DATABASE {nameServerListTabcontrol.SelectedTab.Text} SET MULTI_USER";
                    int err = DAO.execSqlNonQuery(query, DAO.connectionString);
                    if (err == 0)
                    {
                        MessageBox.Show("Phục hồi thành công");
                    }
                    else
                    {
                        MessageBox.Show(DAO.errstr);
                    }
                }
                else
                {
                    MessageBox.Show("Chọn mốc thời gian phục hồi không thích hợp. Hãy chọn lại");
                }
            }
        }

        private void dataBackupSetTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            rowSelected = e.RowIndex > -1 ? e.RowIndex : -1;
            mainProcess();
            if(e.RowIndex != -1)
            {
                dataBackupSetTable.Rows[e.RowIndex].Selected = true;
            }
        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            //this.nameDatabaseTableAdapter.Fill(this.dS.nameDatabaseTable);
        }

        private void delBackupSetItemBtn_Click(object sender, EventArgs e)
        {
            if (rowSelected > -1)
            {
                if (MessageBox.Show("Bạn có thật sự muốn xóa bản sao lưu.", "Xác nhận", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    if (rowSelected == dataBackupSetTable.Rows.Count - 1)
                    {
                        MessageBox.Show("Không thể xóa bản sao lưu gốc");
                    } 
                    else
                    {
                        var backupsetidPosition = backupSetTableAdapter.GetBackupSetTable(nameServerListTabcontrol.SelectedTab.Text).Rows[rowSelected]["id"];
                        //nameDBTxt.Text = backupsetidPosition.ToString();
                        string query = $@"UPDATE msdb.dbo.backupset SET position = 0 WHERE backup_set_id = '{backupsetidPosition}'";
                        //MessageBox.Show(query);
                        int err = DAO.execSqlNonQuery(query, DAO.connectionString);
                        if (err == 0)
                        {
                            MessageBox.Show("Xóa thành công");
                            mainProcess();
                        }
                        else
                        {
                            MessageBox.Show(DAO.errstr);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Hãy chọn bản sao lưu!");
            }
        }
    }
}   