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
            // Get the item from the collection.
            TabPage _tabPage = nameServerListTabcontrol.TabPages[e.Index];
            // Get the real bounds for the tab rectangle.
            Rectangle _tabBounds = nameServerListTabcontrol.GetTabRect(e.Index);
            if (e.State == DrawItemState.Selected)
            {
                // Draw a different background color, and don't paint a focus rectangle.
                _textBrush = new System.Drawing.SolidBrush(e.ForeColor);
                g.FillRectangle(Brushes.Gray, e.Bounds);
            }
            else
            {
                _textBrush = new System.Drawing.SolidBrush(e.ForeColor);
                e.DrawBackground();
            }
            // Use our own font.
            Font _tabFont = new Font("Arial", (float)12.0, FontStyle.Bold);
            // Draw string. Center the text.
            StringFormat _stringFlags = new StringFormat();
            _stringFlags.Alignment = StringAlignment.Center;
            _stringFlags.LineAlignment = StringAlignment.Center;
            g.DrawString(_tabPage.Text, _tabFont, _textBrush, _tabBounds, new StringFormat(_stringFlags));
        }

        private void saoLuuClicked(object sender, MouseEventArgs e)
        {
            string query = $"BACKUP DATABASE {nameServerListTabcontrol.SelectedTab.Text} TO DEVICE_{nameServerListTabcontrol.SelectedTab.Text}";
            if (delAllBackupsCheckBox.Checked && MessageBox.Show("Bạn có thật sự muốn xóa các bản sao lưu cũ.", "Xác nhận", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                query += " WITH INIT"; 
            }
            int err = DAO.execSqlNonQuery(query, DAO.connectionString);
            if (err != 0)
            {
                MessageBox.Show("Backup không thành công");
            }
            else
            {
                MessageBox.Show("Backup thành công");
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
            phucHoiBtn.Enabled = (rowSelected > -1);
            thamSoPhucHoiBtn.Enabled = haveDevice;
            delBackupSetItemBtn.Enabled = (rowSelected > -1);
            dataBackupSetTable.DataSource = backupSetTableAdapter.GetBackupSetTable(nameServerListTabcontrol.SelectedTab.Text);
            //dataBackupSetTable.DataSource = DS.(nameServerListTabcontrol.SelectedTab.Text);
            if (dataBackupSetTable.Rows.GetRowCount(DataGridViewElementStates.None) > 0)
            {
                dataBackupSetTable.Rows[0].Selected = false;
            }
            if(rowSelected != -1)
            {
                nameDBTxt.Text = rowSelected.ToString();
            } 
            else
            {
                nameDBTxt.Text = nameServerListTabcontrol.SelectedTab.Text;
            }
        }

        private void cancelBtnClicked(object sender, EventArgs e)
        { 
            Application.Exit();
        }

        private void taoDeviceBtn_Click(object sender, EventArgs e)
        {
            //DAO.taoDevice(nameServerListTabcontrol.SelectedTab.Text);
            string devicePath = $"D:\\TTCS_BACKUP\\DEVICE_{nameServerListTabcontrol.SelectedTab.Text}.bak";
            string query = $"EXEC SP_ADDUMPDEVICE 'DISK', 'DEVICE_{nameServerListTabcontrol.SelectedTab.Text}', '{devicePath}'";
            int err = DAO.execSqlNonQuery(query, DAO.connectionString);
            if(err == 0)
            {
                MessageBox.Show("Tạo device thành công");
            }
            else
            {
                MessageBox.Show("Tạo device không thành công");
            }
            mainProcess();
        }

        private void thamSoPhucHoiBtn_Click(object sender, EventArgs e)
        {
            thamSoPhucHoiCheckbox.Checked = !thamSoPhucHoiCheckbox.Checked;
        }

        private void phucHoiBtn_Click(object sender, EventArgs e)
        {
            // Đóng kết nối của chính ta
            if (DAO.con != null && DAO.con.State == ConnectionState.Open) DAO.con.Close();
            string query = $@"ALTER DATABASE {nameServerListTabcontrol.SelectedTab.Text} SET SINGLE_USER WITH ROLLBACK IMMEDIATE 
                                USE tempdb ";
            if (thamSoPhucHoiCheckbox.Checked == false)
            {
                query += $@"
                            RESTORE DATABASE {nameServerListTabcontrol.SelectedTab.Text} FROM DEVICE_{nameServerListTabcontrol.SelectedTab.Text} WITH FILE = 2, REPLACE
                            ALTER DATABASE {nameServerListTabcontrol.SelectedTab.Text} SET MULTI_USER";
                int err = DAO.execSqlNonQuery(query, DAO.connectionString);
                if(err == 0)
                {
                    MessageBox.Show("Phục hồi thành công");
                }
                else
                {
                    MessageBox.Show("Phục hồi thất bại");
                }
            }
            else
            {
                // thời gian sao lưu tối thiểu 3p
                nameDBTxt.Text = chonNgay.Value.ToString("yyyy-MM-dd");
                nameDBTxt.Text = chonGio.Value.ToString("HH:mm:ss");
            }
        }

        private void dataBackupSetTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //MessageBox.Show("Mouse clicked in the datagridview!");
            rowSelected = e.RowIndex > -1 ? e.RowIndex : -1;
            mainProcess();
            if(e.RowIndex != -1)
            {
                dataBackupSetTable.Rows[e.RowIndex].Selected = true;
            }
        }

        private void dataBackupSetTable_CellClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            
        }

        private void dataBackupSetTable_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            e.Column.SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dS.nameDatabaseTable' table. You can move, or remove it, as needed.
            this.nameDatabaseTableAdapter.Fill(this.dS.nameDatabaseTable);

        }
    }
}