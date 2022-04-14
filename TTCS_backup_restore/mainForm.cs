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
        private static string connectionString;
        private static SqlConnection con;
        private static SqlCommand command;
        private int rowSelected = -1;
        public mainForm()
        {
            InitializeComponent();
            connectionString = loginForm.connectionString;
            con = new SqlConnection();
            con.ConnectionString = connectionString;
            command = new SqlCommand();
            command.Connection = con;
            tabPageTest();
            nameServerListTabcontrol.SelectedIndexChanged += new EventHandler(Tabs_SelectedIndexChanged);
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
        public static ArrayList GetDatabaseNames()
        {
            con.Open();
            command.CommandText = "SELECT name FROM sys.databases WHERE(database_id >= 5) AND(NOT(name LIKE N'ReportServer%')) ORDER BY NAME";
            var reader = command.ExecuteReader();
            ArrayList ans = new ArrayList();
            while(reader.Read())
            {
                ans.Add(reader["name"].ToString());
            }
            con.Close();
            return ans;
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
            con.Open();
            string query = $"BACKUP DATABASE {nameServerListTabcontrol.SelectedTab.Text} TO DEVICE_{nameServerListTabcontrol.SelectedTab.Text}";
            if(delAllBackupsCheckBox.Checked && MessageBox.Show("Bạn có thật sự muốn xóa các bản sao lưu cũ.", "Xác nhận", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                query += " WITH INIT";
            }
            command.CommandText = query;
            command.ExecuteNonQuery();
            con.Close();
            mainProcess();
        }

        private void Tabs_SelectedIndexChanged(object sender, EventArgs e)
        {
            rowSelected = -1;
            mainProcess();
        }

        private void mainProcess()
        {
            con.Open();
            nameDBTxt.Text = nameServerListTabcontrol.SelectedTab.Text;
            string query = "SELECT name FROM sys.sysdevices";
            command.CommandText = query;
            var reader = command.ExecuteReader();
            bool haveDevice = false;
            if(reader.HasRows)
            {
                while(reader.Read())
                {
                    if (reader["name"].ToString().Equals($"DEVICE_{nameServerListTabcontrol.SelectedTab.Text}"))
                    {
                        haveDevice = true;
                        break;
                    }
                }
            }
            taoDeviceBtn.Enabled = !haveDevice;
            saoLuuBtn.Enabled = haveDevice;
            phucHoiBtn.Enabled = (rowSelected > -1);
            thamSoPhucHoiBtn.Enabled = haveDevice;
            delBackupSetItemBtn.Enabled = (rowSelected > -1);
            query = $@"SELECT position AS 'Bản sao lưu thứ', name AS 'Diễn giải', backup_start_date AS 'Ngày giờ sao lưu', user_name AS 'User sao lưu'
                                FROM  msdb.dbo.backupset 
                                WHERE     database_name = '{nameServerListTabcontrol.SelectedTab.Text}' AND type='D' AND 
                                    backup_set_id >= 
                                    (SELECT backup_set_id FROM 	msdb.dbo.backupset
                                        WHERE position=1 AND database_name = '{nameServerListTabcontrol.SelectedTab.Text}' AND type='D'
                                            AND backup_finish_date = 
		                                (SELECT  MAX(backup_finish_date ) 
			                                FROM msdb.dbo.backupset  
                                                WHERE database_name = '{nameServerListTabcontrol.SelectedTab.Text}' AND type='D' AND position=1
                                                ) 
                                        ) 
                                ORDER BY position DESC";
            command.CommandText = query;
            DataTable table = new DataTable();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(command);
            con.Close();
            sqlDataAdapter.Fill(table);
            dataBackupSetTable.DataSource = table;
            if(dataBackupSetTable.Rows.GetRowCount(DataGridViewElementStates.None) > 0)
            {
                dataBackupSetTable.Rows[0].Selected = false;
            }
            if(rowSelected != -1)
            {
                nameDBTxt.Text = rowSelected.ToString();
            } else
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
            con.Open();
            string devicePath = $"D:\\TTCS_BACKUP\\DEVICE_{nameServerListTabcontrol.SelectedTab.Text}.bak";
            string query = $"EXEC SP_ADDUMPDEVICE 'DISK', 'DEVICE_{nameServerListTabcontrol.SelectedTab.Text}', '{devicePath}'";
            command.CommandText = query;
            command.ExecuteNonQuery();
            con.Close();
            mainProcess();
        }

        private void thamSoPhucHoiBtn_Click(object sender, EventArgs e)
        {
            thamSoPhucHoiCheckbox.Checked = !thamSoPhucHoiCheckbox.Checked;
        }

        private void phucHoiBtn_Click(object sender, EventArgs e)
        {
            // Đóng kết nối của chính ta
            if (con != null && con.State == ConnectionState.Open) con.Close();
            string restoreQuery = $"ALTER DATABASE {nameDBTxt} SET SINGLE_USER WITH ROLLBACK IMMEDIATE USE tempdb";
            if(!thamSoPhucHoiCheckbox.Checked)
            {
                restoreQuery += $"RESTORE DATABASE {nameDBTxt} FROM DEVICE_{nameDBTxt} WITH FILE = {rowSelected}, REPLACE ALTER DATABASE {nameDBTxt} SET MULTI_USER";
            }
            else
            {
                // thời gian sao lưu tối thiểu 3p

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
    }
}