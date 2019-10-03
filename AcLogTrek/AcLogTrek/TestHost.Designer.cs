namespace AclTrek
{
	partial class TestHost
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tcOutput = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.rtxtLog = new System.Windows.Forms.RichTextBox();
            this.btnNewLogFile = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnCopyLog = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.nUpDnSubTable = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.lblTableName = new System.Windows.Forms.Label();
            this.nUpDnTable = new System.Windows.Forms.NumericUpDown();
            this.lblTable = new System.Windows.Forms.Label();
            this.btnToExcel = new System.Windows.Forms.Button();
            this.dgProgramData = new System.Windows.Forms.DataGridView();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.txtAccessUsrPword = new System.Windows.Forms.TextBox();
            this.txtAccessUname = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnAccessGetLastModified = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.cboAccessTable = new System.Windows.Forms.ComboBox();
            this.btnGetFields = new System.Windows.Forms.Button();
            this.btnReadAccessTable = new System.Windows.Forms.Button();
            this.cboAccessFilePath = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtSqlUname = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbWinSecurity = new System.Windows.Forms.RadioButton();
            this.btnSqlGetLastModified = new System.Windows.Forms.Button();
            this.txtSqlUsrPword = new System.Windows.Forms.TextBox();
            this.cboSqlDb = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.btnClearSqlRows = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cboTableSqlSvr = new System.Windows.Forms.ComboBox();
            this.btnGetSqlSvrFields = new System.Windows.Forms.Button();
            this.cboSqlServer = new System.Windows.Forms.ComboBox();
            this.btnReadSqlSvrTable = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnUpdateAllTables = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.txtWinUsrPwd = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtWinUname = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.tcOutput.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUpDnSubTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUpDnTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgProgramData)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tcOutput);
            this.groupBox2.ForeColor = System.Drawing.Color.RoyalBlue;
            this.groupBox2.Location = new System.Drawing.Point(11, 213);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(854, 271);
            this.groupBox2.TabIndex = 37;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Logging and Data";
            // 
            // tcOutput
            // 
            this.tcOutput.Controls.Add(this.tabPage1);
            this.tcOutput.Controls.Add(this.tabPage3);
            this.tcOutput.Location = new System.Drawing.Point(7, 20);
            this.tcOutput.Name = "tcOutput";
            this.tcOutput.SelectedIndex = 0;
            this.tcOutput.Size = new System.Drawing.Size(840, 241);
            this.tcOutput.TabIndex = 28;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.rtxtLog);
            this.tabPage1.Controls.Add(this.btnNewLogFile);
            this.tabPage1.Controls.Add(this.btnClear);
            this.tabPage1.Controls.Add(this.btnCopyLog);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(832, 215);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Output Log";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // rtxtLog
            // 
            this.rtxtLog.Location = new System.Drawing.Point(3, 6);
            this.rtxtLog.Name = "rtxtLog";
            this.rtxtLog.Size = new System.Drawing.Size(754, 203);
            this.rtxtLog.TabIndex = 32;
            this.rtxtLog.Text = "";
            this.rtxtLog.WordWrap = false;
            // 
            // btnNewLogFile
            // 
            this.btnNewLogFile.Location = new System.Drawing.Point(766, 72);
            this.btnNewLogFile.Name = "btnNewLogFile";
            this.btnNewLogFile.Size = new System.Drawing.Size(60, 27);
            this.btnNewLogFile.TabIndex = 31;
            this.btnNewLogFile.Text = "New File";
            this.btnNewLogFile.UseVisualStyleBackColor = true;
            this.btnNewLogFile.Visible = false;
            this.btnNewLogFile.Click += new System.EventHandler(this.btnNewLogFile_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(766, 6);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(60, 27);
            this.btnClear.TabIndex = 29;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnCopyLog
            // 
            this.btnCopyLog.Location = new System.Drawing.Point(766, 39);
            this.btnCopyLog.Name = "btnCopyLog";
            this.btnCopyLog.Size = new System.Drawing.Size(60, 27);
            this.btnCopyLog.TabIndex = 30;
            this.btnCopyLog.Text = "Copy";
            this.btnCopyLog.UseVisualStyleBackColor = true;
            this.btnCopyLog.Click += new System.EventHandler(this.btnCopyLog_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.label4);
            this.tabPage3.Controls.Add(this.nUpDnSubTable);
            this.tabPage3.Controls.Add(this.label5);
            this.tabPage3.Controls.Add(this.lblTableName);
            this.tabPage3.Controls.Add(this.nUpDnTable);
            this.tabPage3.Controls.Add(this.lblTable);
            this.tabPage3.Controls.Add(this.btnToExcel);
            this.tabPage3.Controls.Add(this.dgProgramData);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(832, 215);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Program DS";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(756, 166);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 40;
            this.label4.Text = "Table Name";
            this.label4.Visible = false;
            // 
            // nUpDnSubTable
            // 
            this.nUpDnSubTable.Location = new System.Drawing.Point(776, 142);
            this.nUpDnSubTable.Name = "nUpDnSubTable";
            this.nUpDnSubTable.Size = new System.Drawing.Size(38, 20);
            this.nUpDnSubTable.TabIndex = 39;
            this.nUpDnSubTable.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(767, 126);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 38;
            this.label5.Text = "Sub-Table";
            this.label5.Visible = false;
            // 
            // lblTableName
            // 
            this.lblTableName.Location = new System.Drawing.Point(770, 73);
            this.lblTableName.Name = "lblTableName";
            this.lblTableName.Size = new System.Drawing.Size(40, 23);
            this.lblTableName.TabIndex = 41;
            this.lblTableName.Visible = false;
            // 
            // nUpDnTable
            // 
            this.nUpDnTable.Location = new System.Drawing.Point(770, 73);
            this.nUpDnTable.Name = "nUpDnTable";
            this.nUpDnTable.Size = new System.Drawing.Size(60, 20);
            this.nUpDnTable.TabIndex = 42;
            this.nUpDnTable.Visible = false;
            // 
            // lblTable
            // 
            this.lblTable.AutoSize = true;
            this.lblTable.Location = new System.Drawing.Point(776, 50);
            this.lblTable.Name = "lblTable";
            this.lblTable.Size = new System.Drawing.Size(34, 13);
            this.lblTable.TabIndex = 35;
            this.lblTable.Text = "Table";
            this.lblTable.Visible = false;
            // 
            // btnToExcel
            // 
            this.btnToExcel.Location = new System.Drawing.Point(759, 6);
            this.btnToExcel.Name = "btnToExcel";
            this.btnToExcel.Size = new System.Drawing.Size(68, 27);
            this.btnToExcel.TabIndex = 33;
            this.btnToExcel.Text = "To Excel";
            this.btnToExcel.UseVisualStyleBackColor = true;
            this.btnToExcel.Visible = false;
            this.btnToExcel.Click += new System.EventHandler(this.btnToExcel_Click);
            // 
            // dgProgramData
            // 
            this.dgProgramData.AllowUserToAddRows = false;
            this.dgProgramData.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgProgramData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgProgramData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.RoyalBlue;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgProgramData.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgProgramData.Location = new System.Drawing.Point(4, 3);
            this.dgProgramData.Name = "dgProgramData";
            this.dgProgramData.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgProgramData.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgProgramData.Size = new System.Drawing.Size(826, 209);
            this.dgProgramData.TabIndex = 0;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnBrowse);
            this.groupBox3.Controls.Add(this.txtAccessUsrPword);
            this.groupBox3.Controls.Add(this.txtAccessUname);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.btnAccessGetLastModified);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.cboAccessTable);
            this.groupBox3.Controls.Add(this.btnGetFields);
            this.groupBox3.Controls.Add(this.btnReadAccessTable);
            this.groupBox3.Controls.Add(this.cboAccessFilePath);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.ForeColor = System.Drawing.Color.RoyalBlue;
            this.groupBox3.Location = new System.Drawing.Point(9, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(561, 104);
            this.groupBox3.TabIndex = 73;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Access File";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(483, 16);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(72, 23);
            this.btnBrowse.TabIndex = 88;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // txtAccessUsrPword
            // 
            this.txtAccessUsrPword.Location = new System.Drawing.Point(230, 45);
            this.txtAccessUsrPword.Name = "txtAccessUsrPword";
            this.txtAccessUsrPword.Size = new System.Drawing.Size(132, 20);
            this.txtAccessUsrPword.TabIndex = 87;
            this.txtAccessUsrPword.Text = "COIsys*acc";
            this.txtAccessUsrPword.UseSystemPasswordChar = true;
            this.txtAccessUsrPword.TextChanged += new System.EventHandler(this.txtAccessUsrPword_TextChanged);
            // 
            // txtAccessUname
            // 
            this.txtAccessUname.Location = new System.Drawing.Point(49, 46);
            this.txtAccessUname.Name = "txtAccessUname";
            this.txtAccessUname.Size = new System.Drawing.Size(132, 20);
            this.txtAccessUname.TabIndex = 84;
            this.txtAccessUname.Text = "slamdata";
            this.txtAccessUname.TextChanged += new System.EventHandler(this.txtAccessUname_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(186, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 86;
            this.label1.Text = "Pword";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 85;
            this.label3.Text = "Uname";
            // 
            // btnAccessGetLastModified
            // 
            this.btnAccessGetLastModified.Location = new System.Drawing.Point(374, 44);
            this.btnAccessGetLastModified.Name = "btnAccessGetLastModified";
            this.btnAccessGetLastModified.Size = new System.Drawing.Size(100, 23);
            this.btnAccessGetLastModified.TabIndex = 83;
            this.btnAccessGetLastModified.Text = "Last Mod Date";
            this.btnAccessGetLastModified.UseVisualStyleBackColor = true;
            this.btnAccessGetLastModified.Visible = false;
            this.btnAccessGetLastModified.Click += new System.EventHandler(this.btnAccessGetLastModified_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 76);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(34, 13);
            this.label9.TabIndex = 74;
            this.label9.Text = "Table";
            // 
            // cboAccessTable
            // 
            this.cboAccessTable.FormattingEnabled = true;
            this.cboAccessTable.Location = new System.Drawing.Point(49, 74);
            this.cboAccessTable.Name = "cboAccessTable";
            this.cboAccessTable.Size = new System.Drawing.Size(274, 21);
            this.cboAccessTable.TabIndex = 73;
            // 
            // btnGetFields
            // 
            this.btnGetFields.Location = new System.Drawing.Point(374, 74);
            this.btnGetFields.Name = "btnGetFields";
            this.btnGetFields.Size = new System.Drawing.Size(100, 23);
            this.btnGetFields.TabIndex = 72;
            this.btnGetFields.Text = "Get Fields";
            this.btnGetFields.UseVisualStyleBackColor = true;
            this.btnGetFields.Click += new System.EventHandler(this.btnGetFields_Click);
            // 
            // btnReadAccessTable
            // 
            this.btnReadAccessTable.Location = new System.Drawing.Point(329, 74);
            this.btnReadAccessTable.Name = "btnReadAccessTable";
            this.btnReadAccessTable.Size = new System.Drawing.Size(43, 23);
            this.btnReadAccessTable.TabIndex = 70;
            this.btnReadAccessTable.Text = "Read";
            this.btnReadAccessTable.UseVisualStyleBackColor = true;
            this.btnReadAccessTable.Click += new System.EventHandler(this.btnReadAccessTable_Click);
            // 
            // cboAccessFilePath
            // 
            this.cboAccessFilePath.FormattingEnabled = true;
            this.cboAccessFilePath.Location = new System.Drawing.Point(49, 16);
            this.cboAccessFilePath.Name = "cboAccessFilePath";
            this.cboAccessFilePath.Size = new System.Drawing.Size(425, 21);
            this.cboAccessFilePath.TabIndex = 49;
            this.cboAccessFilePath.SelectedIndexChanged += new System.EventHandler(this.cboAccessFilePath_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 18);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "Path";
            // 
            // txtSqlUname
            // 
            this.txtSqlUname.Location = new System.Drawing.Point(526, 17);
            this.txtSqlUname.Name = "txtSqlUname";
            this.txtSqlUname.Size = new System.Drawing.Size(132, 20);
            this.txtSqlUname.TabIndex = 13;
            this.txtSqlUname.Text = "slamdata";
            this.txtSqlUname.TextChanged += new System.EventHandler(this.txtSqlUname_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbWinSecurity);
            this.groupBox1.Controls.Add(this.btnSqlGetLastModified);
            this.groupBox1.Controls.Add(this.txtSqlUsrPword);
            this.groupBox1.Controls.Add(this.cboSqlDb);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.btnClearSqlRows);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cboTableSqlSvr);
            this.groupBox1.Controls.Add(this.btnGetSqlSvrFields);
            this.groupBox1.Controls.Add(this.cboSqlServer);
            this.groupBox1.Controls.Add(this.txtSqlUname);
            this.groupBox1.Controls.Add(this.btnReadSqlSvrTable);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.groupBox1.Location = new System.Drawing.Point(10, 122);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(854, 85);
            this.groupBox1.TabIndex = 75;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "SQL Server";
            // 
            // rbWinSecurity
            // 
            this.rbWinSecurity.AutoSize = true;
            this.rbWinSecurity.Checked = true;
            this.rbWinSecurity.Location = new System.Drawing.Point(485, 48);
            this.rbWinSecurity.Name = "rbWinSecurity";
            this.rbWinSecurity.Size = new System.Drawing.Size(132, 17);
            this.rbWinSecurity.TabIndex = 90;
            this.rbWinSecurity.TabStop = true;
            this.rbWinSecurity.Text = "Use Windows Security";
            this.rbWinSecurity.UseVisualStyleBackColor = true;
            // 
            // btnSqlGetLastModified
            // 
            this.btnSqlGetLastModified.Location = new System.Drawing.Point(623, 47);
            this.btnSqlGetLastModified.Name = "btnSqlGetLastModified";
            this.btnSqlGetLastModified.Size = new System.Drawing.Size(91, 23);
            this.btnSqlGetLastModified.TabIndex = 82;
            this.btnSqlGetLastModified.Text = "Import SIC";
            this.btnSqlGetLastModified.UseVisualStyleBackColor = true;
            this.btnSqlGetLastModified.Click += new System.EventHandler(this.btnSqlGetLastModified_Click);
            // 
            // txtSqlUsrPword
            // 
            this.txtSqlUsrPword.Location = new System.Drawing.Point(707, 16);
            this.txtSqlUsrPword.Name = "txtSqlUsrPword";
            this.txtSqlUsrPword.Size = new System.Drawing.Size(132, 20);
            this.txtSqlUsrPword.TabIndex = 81;
            this.txtSqlUsrPword.Text = "COIsys*acc";
            this.txtSqlUsrPword.UseSystemPasswordChar = true;
            this.txtSqlUsrPword.TextChanged += new System.EventHandler(this.txtSqlUsrPword_TextChanged);
            // 
            // cboSqlDb
            // 
            this.cboSqlDb.FormattingEnabled = true;
            this.cboSqlDb.Location = new System.Drawing.Point(288, 16);
            this.cboSqlDb.Name = "cboSqlDb";
            this.cboSqlDb.Size = new System.Drawing.Size(183, 21);
            this.cboSqlDb.TabIndex = 80;
            this.cboSqlDb.SelectedIndexChanged += new System.EventHandler(this.cboSqlDb_SelectedIndexChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(231, 19);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(53, 13);
            this.label13.TabIndex = 79;
            this.label13.Text = "Database";
            // 
            // btnClearSqlRows
            // 
            this.btnClearSqlRows.Location = new System.Drawing.Point(720, 47);
            this.btnClearSqlRows.Name = "btnClearSqlRows";
            this.btnClearSqlRows.Size = new System.Drawing.Size(119, 23);
            this.btnClearSqlRows.TabIndex = 76;
            this.btnClearSqlRows.Text = "Delete All Rows in Table";
            this.btnClearSqlRows.UseVisualStyleBackColor = true;
            this.btnClearSqlRows.Visible = false;
            this.btnClearSqlRows.Click += new System.EventHandler(this.btnClearSqlRows_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 74;
            this.label2.Text = "Table";
            // 
            // cboTableSqlSvr
            // 
            this.cboTableSqlSvr.FormattingEnabled = true;
            this.cboTableSqlSvr.Location = new System.Drawing.Point(48, 47);
            this.cboTableSqlSvr.Name = "cboTableSqlSvr";
            this.cboTableSqlSvr.Size = new System.Drawing.Size(274, 21);
            this.cboTableSqlSvr.TabIndex = 78;
            // 
            // btnGetSqlSvrFields
            // 
            this.btnGetSqlSvrFields.Location = new System.Drawing.Point(393, 47);
            this.btnGetSqlSvrFields.Name = "btnGetSqlSvrFields";
            this.btnGetSqlSvrFields.Size = new System.Drawing.Size(80, 23);
            this.btnGetSqlSvrFields.TabIndex = 77;
            this.btnGetSqlSvrFields.Text = "Get Fields";
            this.btnGetSqlSvrFields.UseVisualStyleBackColor = true;
            this.btnGetSqlSvrFields.Click += new System.EventHandler(this.btnGetSqlSvrFields_Click);
            // 
            // cboSqlServer
            // 
            this.cboSqlServer.FormattingEnabled = true;
            this.cboSqlServer.Location = new System.Drawing.Point(48, 16);
            this.cboSqlServer.Name = "cboSqlServer";
            this.cboSqlServer.Size = new System.Drawing.Size(177, 21);
            this.cboSqlServer.TabIndex = 49;
            this.cboSqlServer.SelectedIndexChanged += new System.EventHandler(this.cboSqlServer_SelectedIndexChanged);
            // 
            // btnReadSqlSvrTable
            // 
            this.btnReadSqlSvrTable.Location = new System.Drawing.Point(328, 47);
            this.btnReadSqlSvrTable.Name = "btnReadSqlSvrTable";
            this.btnReadSqlSvrTable.Size = new System.Drawing.Size(59, 23);
            this.btnReadSqlSvrTable.TabIndex = 75;
            this.btnReadSqlSvrTable.Text = "Read";
            this.btnReadSqlSvrTable.UseVisualStyleBackColor = true;
            this.btnReadSqlSvrTable.Click += new System.EventHandler(this.btnReadSqlSvrTable_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(663, 18);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(37, 13);
            this.label10.TabIndex = 53;
            this.label10.Text = "Pword";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(479, 19);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(41, 13);
            this.label11.TabIndex = 50;
            this.label11.Text = "Uname";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(7, 18);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(38, 13);
            this.label12.TabIndex = 17;
            this.label12.Text = "Server";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnUpdateAllTables);
            this.groupBox4.ForeColor = System.Drawing.Color.RoyalBlue;
            this.groupBox4.Location = new System.Drawing.Point(757, 25);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(105, 82);
            this.groupBox4.TabIndex = 83;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Mirror Update";
            // 
            // btnUpdateAllTables
            // 
            this.btnUpdateAllTables.Location = new System.Drawing.Point(12, 25);
            this.btnUpdateAllTables.Name = "btnUpdateAllTables";
            this.btnUpdateAllTables.Size = new System.Drawing.Size(79, 23);
            this.btnUpdateAllTables.TabIndex = 83;
            this.btnUpdateAllTables.Text = "Update All Mirror Tables";
            this.btnUpdateAllTables.UseVisualStyleBackColor = true;
            this.btnUpdateAllTables.Click += new System.EventHandler(this.btnUpdateAllTables_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.txtWinUsrPwd);
            this.groupBox5.Controls.Add(this.label7);
            this.groupBox5.Controls.Add(this.txtWinUname);
            this.groupBox5.Controls.Add(this.label6);
            this.groupBox5.ForeColor = System.Drawing.Color.RoyalBlue;
            this.groupBox5.Location = new System.Drawing.Point(576, 12);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(175, 104);
            this.groupBox5.TabIndex = 84;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Windows Account";
            // 
            // txtWinUsrPwd
            // 
            this.txtWinUsrPwd.Location = new System.Drawing.Point(47, 52);
            this.txtWinUsrPwd.Name = "txtWinUsrPwd";
            this.txtWinUsrPwd.Size = new System.Drawing.Size(122, 20);
            this.txtWinUsrPwd.TabIndex = 89;
            this.txtWinUsrPwd.Text = "Password3";
            this.txtWinUsrPwd.UseSystemPasswordChar = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(5, 54);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 13);
            this.label7.TabIndex = 88;
            this.label7.Text = "Pword";
            // 
            // txtWinUname
            // 
            this.txtWinUname.Location = new System.Drawing.Point(47, 22);
            this.txtWinUname.Name = "txtWinUname";
            this.txtWinUname.Size = new System.Drawing.Size(122, 20);
            this.txtWinUname.TabIndex = 88;
            this.txtWinUname.Text = "slamdata";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(4, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 13);
            this.label6.TabIndex = 89;
            this.label6.Text = "Uname";
            // 
            // TestHost
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(877, 476);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Name = "TestHost";
            this.Text = "N3FJP Amateur Contact Log";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TestHost_FormClosing);
            this.Load += new System.EventHandler(this.TestHost_Load);
            this.groupBox2.ResumeLayout(false);
            this.tcOutput.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUpDnSubTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUpDnTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgProgramData)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.TabControl tcOutput;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.Button btnNewLogFile;
		private System.Windows.Forms.Button btnClear;
		private System.Windows.Forms.Button btnCopyLog;
		private System.Windows.Forms.TabPage tabPage3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.NumericUpDown nUpDnSubTable;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label lblTableName;
		private System.Windows.Forms.NumericUpDown nUpDnTable;
		private System.Windows.Forms.Label lblTable;
		private System.Windows.Forms.Button btnToExcel;
		private System.Windows.Forms.DataGridView dgProgramData;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.RichTextBox rtxtLog;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.ComboBox cboAccessTable;
		private System.Windows.Forms.Button btnGetFields;
		private System.Windows.Forms.Button btnReadAccessTable;
		private System.Windows.Forms.ComboBox cboAccessFilePath;
		private System.Windows.Forms.TextBox txtSqlUname;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.ComboBox cboSqlDb;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Button btnClearSqlRows;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox cboTableSqlSvr;
		private System.Windows.Forms.Button btnGetSqlSvrFields;
		private System.Windows.Forms.ComboBox cboSqlServer;
		private System.Windows.Forms.Button btnReadSqlSvrTable;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.TextBox txtSqlUsrPword;
		private System.Windows.Forms.Button btnAccessGetLastModified;
		private System.Windows.Forms.Button btnSqlGetLastModified;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.Button btnUpdateAllTables;
		private System.Windows.Forms.TextBox txtAccessUsrPword;
		private System.Windows.Forms.TextBox txtAccessUname;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.GroupBox groupBox5;
		private System.Windows.Forms.TextBox txtWinUsrPwd;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox txtWinUname;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.RadioButton rbWinSecurity;
		private System.Windows.Forms.Button btnBrowse;
	}
}

