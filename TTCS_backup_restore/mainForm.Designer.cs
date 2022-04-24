
namespace TTCS_backup_restore
{
    partial class mainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.delBackupSetItemBtn = new System.Windows.Forms.Button();
            this.thoatBtn = new System.Windows.Forms.Button();
            this.taoDeviceBtn = new System.Windows.Forms.Button();
            this.thamSoPhucHoiCheckbox = new System.Windows.Forms.CheckBox();
            this.phucHoiBtn = new System.Windows.Forms.Button();
            this.saoLuuBtn = new System.Windows.Forms.Button();
            this.thamSoPhucHoiBtn = new System.Windows.Forms.Button();
            this.nameServerListTabcontrol = new System.Windows.Forms.TabControl();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.chooseTimePanel = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.chonNgay = new System.Windows.Forms.DateTimePicker();
            this.chonGio = new System.Windows.Forms.DateTimePicker();
            this.dataBackupSetTable = new System.Windows.Forms.DataGridView();
            this.thứTựBảnSaoLưuDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.môTảDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.thờiGianSaoLưuDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tàiKhoảnSaoLưuDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.backupSetTableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dS1 = new TTCS_backup_restore.DS();
            this.label1 = new System.Windows.Forms.Label();
            this.nameDBTxt = new System.Windows.Forms.TextBox();
            this.delAllBackupsCheckBox = new System.Windows.Forms.CheckBox();
            this.dS = new TTCS_backup_restore.DS();
            this.backupSetTableAdapter = new TTCS_backup_restore.DSTableAdapters.backupSetTableAdapter();
            this.thứTựBảnSaoLưuDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.môTảDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.thờiGianSaoLưuDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.mainPanel.SuspendLayout();
            this.chooseTimePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataBackupSetTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.backupSetTableBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dS1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dS)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.delBackupSetItemBtn);
            this.panel1.Controls.Add(this.thoatBtn);
            this.panel1.Controls.Add(this.taoDeviceBtn);
            this.panel1.Controls.Add(this.thamSoPhucHoiCheckbox);
            this.panel1.Controls.Add(this.phucHoiBtn);
            this.panel1.Controls.Add(this.saoLuuBtn);
            this.panel1.Controls.Add(this.thamSoPhucHoiBtn);
            this.panel1.Location = new System.Drawing.Point(12, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1268, 60);
            this.panel1.TabIndex = 0;
            // 
            // delBackupSetItemBtn
            // 
            this.delBackupSetItemBtn.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.delBackupSetItemBtn.Image = ((System.Drawing.Image)(resources.GetObject("delBackupSetItemBtn.Image")));
            this.delBackupSetItemBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.delBackupSetItemBtn.Location = new System.Drawing.Point(962, -1);
            this.delBackupSetItemBtn.Name = "delBackupSetItemBtn";
            this.delBackupSetItemBtn.Size = new System.Drawing.Size(170, 60);
            this.delBackupSetItemBtn.TabIndex = 10;
            this.delBackupSetItemBtn.Text = "XÓA BACKUP";
            this.delBackupSetItemBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.delBackupSetItemBtn.UseVisualStyleBackColor = true;
            this.delBackupSetItemBtn.Click += new System.EventHandler(this.delBackupSetItemBtn_Click);
            // 
            // thoatBtn
            // 
            this.thoatBtn.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.thoatBtn.Image = ((System.Drawing.Image)(resources.GetObject("thoatBtn.Image")));
            this.thoatBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.thoatBtn.Location = new System.Drawing.Point(1138, 0);
            this.thoatBtn.Name = "thoatBtn";
            this.thoatBtn.Size = new System.Drawing.Size(127, 60);
            this.thoatBtn.TabIndex = 1;
            this.thoatBtn.Text = "THOÁT";
            this.thoatBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.thoatBtn.UseVisualStyleBackColor = true;
            this.thoatBtn.Click += new System.EventHandler(this.cancelBtnClicked);
            // 
            // taoDeviceBtn
            // 
            this.taoDeviceBtn.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.taoDeviceBtn.Image = ((System.Drawing.Image)(resources.GetObject("taoDeviceBtn.Image")));
            this.taoDeviceBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.taoDeviceBtn.Location = new System.Drawing.Point(710, -1);
            this.taoDeviceBtn.Name = "taoDeviceBtn";
            this.taoDeviceBtn.Size = new System.Drawing.Size(246, 60);
            this.taoDeviceBtn.TabIndex = 1;
            this.taoDeviceBtn.Text = "TẠO DEVICE SAO LƯU";
            this.taoDeviceBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.taoDeviceBtn.UseVisualStyleBackColor = true;
            this.taoDeviceBtn.Click += new System.EventHandler(this.taoDeviceBtn_Click);
            // 
            // thamSoPhucHoiCheckbox
            // 
            this.thamSoPhucHoiCheckbox.AutoCheck = false;
            this.thamSoPhucHoiCheckbox.AutoSize = true;
            this.thamSoPhucHoiCheckbox.Location = new System.Drawing.Point(302, 24);
            this.thamSoPhucHoiCheckbox.Name = "thamSoPhucHoiCheckbox";
            this.thamSoPhucHoiCheckbox.Size = new System.Drawing.Size(15, 14);
            this.thamSoPhucHoiCheckbox.TabIndex = 10;
            this.thamSoPhucHoiCheckbox.UseVisualStyleBackColor = true;
            // 
            // phucHoiBtn
            // 
            this.phucHoiBtn.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phucHoiBtn.Image = ((System.Drawing.Image)(resources.GetObject("phucHoiBtn.Image")));
            this.phucHoiBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.phucHoiBtn.Location = new System.Drawing.Point(143, 0);
            this.phucHoiBtn.Name = "phucHoiBtn";
            this.phucHoiBtn.Size = new System.Drawing.Size(144, 60);
            this.phucHoiBtn.TabIndex = 1;
            this.phucHoiBtn.Text = "PHỤC HỒI";
            this.phucHoiBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.phucHoiBtn.UseVisualStyleBackColor = true;
            this.phucHoiBtn.Click += new System.EventHandler(this.phucHoiBtn_Click);
            // 
            // saoLuuBtn
            // 
            this.saoLuuBtn.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saoLuuBtn.Image = ((System.Drawing.Image)(resources.GetObject("saoLuuBtn.Image")));
            this.saoLuuBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.saoLuuBtn.Location = new System.Drawing.Point(0, 0);
            this.saoLuuBtn.Name = "saoLuuBtn";
            this.saoLuuBtn.Size = new System.Drawing.Size(137, 60);
            this.saoLuuBtn.TabIndex = 1;
            this.saoLuuBtn.Text = "SAO LƯU";
            this.saoLuuBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.saoLuuBtn.UseVisualStyleBackColor = true;
            this.saoLuuBtn.MouseClick += new System.Windows.Forms.MouseEventHandler(this.saoLuuClicked);
            // 
            // thamSoPhucHoiBtn
            // 
            this.thamSoPhucHoiBtn.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.thamSoPhucHoiBtn.Image = ((System.Drawing.Image)(resources.GetObject("thamSoPhucHoiBtn.Image")));
            this.thamSoPhucHoiBtn.Location = new System.Drawing.Point(293, 0);
            this.thamSoPhucHoiBtn.Name = "thamSoPhucHoiBtn";
            this.thamSoPhucHoiBtn.Size = new System.Drawing.Size(411, 60);
            this.thamSoPhucHoiBtn.TabIndex = 1;
            this.thamSoPhucHoiBtn.Text = "THAM SỐ PHỤC HỒI THEO THỜI GIAN";
            this.thamSoPhucHoiBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.thamSoPhucHoiBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.thamSoPhucHoiBtn.UseVisualStyleBackColor = true;
            this.thamSoPhucHoiBtn.Click += new System.EventHandler(this.thamSoPhucHoiBtn_Click);
            // 
            // nameServerListTabcontrol
            // 
            this.nameServerListTabcontrol.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.nameServerListTabcontrol.AllowDrop = true;
            this.nameServerListTabcontrol.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.nameServerListTabcontrol.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameServerListTabcontrol.HotTrack = true;
            this.nameServerListTabcontrol.ItemSize = new System.Drawing.Size(30, 200);
            this.nameServerListTabcontrol.Location = new System.Drawing.Point(12, 66);
            this.nameServerListTabcontrol.Multiline = true;
            this.nameServerListTabcontrol.Name = "nameServerListTabcontrol";
            this.nameServerListTabcontrol.SelectedIndex = 0;
            this.nameServerListTabcontrol.Size = new System.Drawing.Size(207, 642);
            this.nameServerListTabcontrol.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.nameServerListTabcontrol.TabIndex = 1;
            this.nameServerListTabcontrol.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.tabControl_DrawItem);
            this.nameServerListTabcontrol.SelectedIndexChanged += new System.EventHandler(this.Tabs_SelectedIndexChanged);
            // 
            // mainPanel
            // 
            this.mainPanel.BackColor = System.Drawing.Color.White;
            this.mainPanel.Controls.Add(this.chooseTimePanel);
            this.mainPanel.Controls.Add(this.dataBackupSetTable);
            this.mainPanel.Controls.Add(this.label1);
            this.mainPanel.Controls.Add(this.nameDBTxt);
            this.mainPanel.Controls.Add(this.delAllBackupsCheckBox);
            this.mainPanel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainPanel.Location = new System.Drawing.Point(216, 66);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(1064, 642);
            this.mainPanel.TabIndex = 10;
            // 
            // chooseTimePanel
            // 
            this.chooseTimePanel.Controls.Add(this.label3);
            this.chooseTimePanel.Controls.Add(this.label2);
            this.chooseTimePanel.Controls.Add(this.chonNgay);
            this.chooseTimePanel.Controls.Add(this.chonGio);
            this.chooseTimePanel.Location = new System.Drawing.Point(50, 486);
            this.chooseTimePanel.Name = "chooseTimePanel";
            this.chooseTimePanel.Size = new System.Drawing.Size(956, 139);
            this.chooseTimePanel.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(44, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(295, 19);
            this.label3.TabIndex = 4;
            this.label3.Text = "Ngày giờ để phục hồi tới thời điểm đó";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(44, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(841, 44);
            this.label2.TabIndex = 10;
            this.label2.Text = resources.GetString("label2.Text");
            // 
            // chonNgay
            // 
            this.chonNgay.CustomFormat = "dd-MM-yyyy";
            this.chonNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.chonNgay.Location = new System.Drawing.Point(429, 18);
            this.chonNgay.MaxDate = new System.DateTime(2029, 12, 31, 0, 0, 0, 0);
            this.chonNgay.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.chonNgay.Name = "chonNgay";
            this.chonNgay.Size = new System.Drawing.Size(121, 26);
            this.chonNgay.TabIndex = 5;
            this.chonNgay.Value = new System.DateTime(2022, 4, 17, 0, 0, 0, 0);
            // 
            // chonGio
            // 
            this.chonGio.CustomFormat = "HH:mm:ss";
            this.chonGio.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.chonGio.Location = new System.Drawing.Point(646, 18);
            this.chonGio.MaxDate = new System.DateTime(2200, 4, 16, 0, 0, 0, 0);
            this.chonGio.Name = "chonGio";
            this.chonGio.ShowUpDown = true;
            this.chonGio.Size = new System.Drawing.Size(126, 26);
            this.chonGio.TabIndex = 6;
            this.chonGio.Value = new System.DateTime(2022, 4, 19, 0, 0, 0, 0);
            // 
            // dataBackupSetTable
            // 
            this.dataBackupSetTable.AllowUserToAddRows = false;
            this.dataBackupSetTable.AllowUserToDeleteRows = false;
            this.dataBackupSetTable.AllowUserToOrderColumns = true;
            this.dataBackupSetTable.AllowUserToResizeColumns = false;
            this.dataBackupSetTable.AllowUserToResizeRows = false;
            this.dataBackupSetTable.AutoGenerateColumns = false;
            this.dataBackupSetTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataBackupSetTable.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataBackupSetTable.BackgroundColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataBackupSetTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataBackupSetTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataBackupSetTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.thứTựBảnSaoLưuDataGridViewTextBoxColumn1,
            this.môTảDataGridViewTextBoxColumn1,
            this.thờiGianSaoLưuDataGridViewTextBoxColumn1,
            this.tàiKhoảnSaoLưuDataGridViewTextBoxColumn});
            this.dataBackupSetTable.DataSource = this.backupSetTableBindingSource;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.MenuHighlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataBackupSetTable.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataBackupSetTable.EnableHeadersVisualStyles = false;
            this.dataBackupSetTable.Location = new System.Drawing.Point(50, 57);
            this.dataBackupSetTable.MultiSelect = false;
            this.dataBackupSetTable.Name = "dataBackupSetTable";
            this.dataBackupSetTable.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataBackupSetTable.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataBackupSetTable.RowHeadersVisible = false;
            this.dataBackupSetTable.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.Window;
            this.dataBackupSetTable.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dataBackupSetTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataBackupSetTable.Size = new System.Drawing.Size(956, 394);
            this.dataBackupSetTable.StandardTab = true;
            this.dataBackupSetTable.TabIndex = 9;
            this.dataBackupSetTable.TabStop = false;
            this.dataBackupSetTable.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataBackupSetTable_CellClick);
            // 
            // thứTựBảnSaoLưuDataGridViewTextBoxColumn1
            // 
            this.thứTựBảnSaoLưuDataGridViewTextBoxColumn1.DataPropertyName = "Thứ tự bản sao lưu";
            this.thứTựBảnSaoLưuDataGridViewTextBoxColumn1.HeaderText = "Thứ tự bản sao lưu";
            this.thứTựBảnSaoLưuDataGridViewTextBoxColumn1.Name = "thứTựBảnSaoLưuDataGridViewTextBoxColumn1";
            this.thứTựBảnSaoLưuDataGridViewTextBoxColumn1.ReadOnly = true;
            this.thứTựBảnSaoLưuDataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // môTảDataGridViewTextBoxColumn1
            // 
            this.môTảDataGridViewTextBoxColumn1.DataPropertyName = "Mô tả";
            this.môTảDataGridViewTextBoxColumn1.HeaderText = "Mô tả";
            this.môTảDataGridViewTextBoxColumn1.Name = "môTảDataGridViewTextBoxColumn1";
            this.môTảDataGridViewTextBoxColumn1.ReadOnly = true;
            this.môTảDataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // thờiGianSaoLưuDataGridViewTextBoxColumn1
            // 
            this.thờiGianSaoLưuDataGridViewTextBoxColumn1.DataPropertyName = "Thời gian sao lưu";
            this.thờiGianSaoLưuDataGridViewTextBoxColumn1.HeaderText = "Thời gian sao lưu";
            this.thờiGianSaoLưuDataGridViewTextBoxColumn1.Name = "thờiGianSaoLưuDataGridViewTextBoxColumn1";
            this.thờiGianSaoLưuDataGridViewTextBoxColumn1.ReadOnly = true;
            this.thờiGianSaoLưuDataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // tàiKhoảnSaoLưuDataGridViewTextBoxColumn
            // 
            this.tàiKhoảnSaoLưuDataGridViewTextBoxColumn.DataPropertyName = "Tài khoản sao lưu";
            this.tàiKhoảnSaoLưuDataGridViewTextBoxColumn.HeaderText = "Tài khoản sao lưu";
            this.tàiKhoảnSaoLưuDataGridViewTextBoxColumn.Name = "tàiKhoảnSaoLưuDataGridViewTextBoxColumn";
            this.tàiKhoảnSaoLưuDataGridViewTextBoxColumn.ReadOnly = true;
            this.tàiKhoảnSaoLưuDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // backupSetTableBindingSource
            // 
            this.backupSetTableBindingSource.DataMember = "backupSetTable";
            this.backupSetTableBindingSource.DataSource = this.dS1;
            // 
            // dS1
            // 
            this.dS1.DataSetName = "DS";
            this.dS1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(69, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên cơ sở dữ liệu";
            // 
            // nameDBTxt
            // 
            this.nameDBTxt.Location = new System.Drawing.Point(236, 15);
            this.nameDBTxt.Name = "nameDBTxt";
            this.nameDBTxt.Size = new System.Drawing.Size(308, 26);
            this.nameDBTxt.TabIndex = 1;
            // 
            // delAllBackupsCheckBox
            // 
            this.delAllBackupsCheckBox.AutoSize = true;
            this.delAllBackupsCheckBox.Location = new System.Drawing.Point(298, 457);
            this.delAllBackupsCheckBox.Name = "delAllBackupsCheckBox";
            this.delAllBackupsCheckBox.Size = new System.Drawing.Size(497, 23);
            this.delAllBackupsCheckBox.TabIndex = 3;
            this.delAllBackupsCheckBox.Text = "Xóa tất cả các bản sao lưu trong file trước khi tạo sao lưu mới";
            this.delAllBackupsCheckBox.UseVisualStyleBackColor = true;
            // 
            // dS
            // 
            this.dS.DataSetName = "DS";
            this.dS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // backupSetTableAdapter
            // 
            this.backupSetTableAdapter.ClearBeforeFill = true;
            // 
            // thứTựBảnSaoLưuDataGridViewTextBoxColumn
            // 
            this.thứTựBảnSaoLưuDataGridViewTextBoxColumn.DataPropertyName = "Thứ tự bản sao lưu";
            this.thứTựBảnSaoLưuDataGridViewTextBoxColumn.HeaderText = "Thứ tự bản sao lưu";
            this.thứTựBảnSaoLưuDataGridViewTextBoxColumn.Name = "thứTựBảnSaoLưuDataGridViewTextBoxColumn";
            this.thứTựBảnSaoLưuDataGridViewTextBoxColumn.Width = 318;
            // 
            // môTảDataGridViewTextBoxColumn
            // 
            this.môTảDataGridViewTextBoxColumn.DataPropertyName = "Mô tả";
            this.môTảDataGridViewTextBoxColumn.HeaderText = "Mô tả";
            this.môTảDataGridViewTextBoxColumn.Name = "môTảDataGridViewTextBoxColumn";
            this.môTảDataGridViewTextBoxColumn.Width = 317;
            // 
            // thờiGianSaoLưuDataGridViewTextBoxColumn
            // 
            this.thờiGianSaoLưuDataGridViewTextBoxColumn.DataPropertyName = "Thời gian sao lưu";
            this.thờiGianSaoLưuDataGridViewTextBoxColumn.HeaderText = "Thời gian sao lưu";
            this.thờiGianSaoLưuDataGridViewTextBoxColumn.Name = "thờiGianSaoLưuDataGridViewTextBoxColumn";
            this.thờiGianSaoLưuDataGridViewTextBoxColumn.Width = 318;
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1292, 720);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.nameServerListTabcontrol);
            this.Controls.Add(this.panel1);
            this.Name = "mainForm";
            this.Text = "XtraForm1";
            this.Load += new System.EventHandler(this.mainForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.chooseTimePanel.ResumeLayout(false);
            this.chooseTimePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataBackupSetTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.backupSetTableBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dS1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dS)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button saoLuuBtn;
        private System.Windows.Forms.Button phucHoiBtn;
        private System.Windows.Forms.Button thamSoPhucHoiBtn;
        private System.Windows.Forms.Button taoDeviceBtn;
        private System.Windows.Forms.Button thoatBtn;
        private System.Windows.Forms.TabControl nameServerListTabcontrol;
        private System.Windows.Forms.TextBox nameDBTxt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox delAllBackupsCheckBox;
        private System.Windows.Forms.DateTimePicker chonNgay;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker chonGio;
        private System.Windows.Forms.DataGridView dataBackupSetTable;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.CheckBox thamSoPhucHoiCheckbox;
        private System.Windows.Forms.Button delBackupSetItemBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn positionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn backupstartdateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn usernameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn databasenameDataGridViewTextBoxColumn;
        private DS dS;
        private DSTableAdapters.backupSetTableAdapter backupSetTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn userSaoLưuDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn thứTựBảnSaoLưuDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn môTảDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn thờiGianSaoLưuDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource backupSetTableBindingSource;
        private DS dS1;
        private System.Windows.Forms.DataGridViewTextBoxColumn thứTựBảnSaoLưuDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn môTảDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn thờiGianSaoLưuDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn tàiKhoảnSaoLưuDataGridViewTextBoxColumn;
        private System.Windows.Forms.Panel chooseTimePanel;
    }
}