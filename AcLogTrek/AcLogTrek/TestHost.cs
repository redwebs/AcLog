using System;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace AclTrek
{

    public partial class TestHost : Form
    {
        #region Member Variables

        public Log4Form Log = null;

        private readonly DataSet _displayDataSet = null;
        private AcLogService _acLogService;
        private bool _externalSvcConnected = false;
        private bool _loadingDefaultData = false;

        public AcLogSettings AclSettings;

        #endregion Member Vars

        #region Member Constants

        private const string AppLogName = "AcLogServices";
        private const string StdDateDispFmt = "yy-MM-dd hh:mm tt";
        private const string AcLogSettingsEnvVar = "AcLogSettingsPath";

        #endregion

        #region Properties

        public AcLogService AcLogSvcs => _acLogService ?? CreateAcLogServices();

        #endregion Properties

        #region Constructors

        public TestHost()
        {
            InitializeComponent();
        }

        #endregion 

        #region Form loading and events

        private AcLogService CreateAcLogServices()
        {
            if (!_loadingDefaultData)
            {
                _acLogService = new AcLogService(
                    cboAccessFilePath.Text,
                    txtSqlUname.Text,
                    txtSqlUsrPword.Text,
                    txtAccessUname.Text,
                    txtAccessUsrPword.Text,
                    rbWinSecurity.Checked);
            }
            return _acLogService;
        }

        private void ClearCboAndLoad(ComboBox cbo, string text)
        {
            cbo.Items.Clear();
            CtrlListItem uri = new CtrlListItem(text);
            cbo.Items.Add(uri);
            cbo.SelectedIndex = 0;
        }

        private void ClearCboAndLoad(ComboBox cbo, string text, int data)
        {
            cbo.Items.Clear();
            CtrlListItem uri = new CtrlListItem(text, data);
            cbo.Items.Add(uri);
            cbo.SelectedIndex = 0;
        }

        private void LoadDefaultData()
        {
            _loadingDefaultData = true;

            // If Env Var is not found, default to file in executing folder
            var settingsPath = FormHelper.GetEnvironmentVar(AcLogSettingsEnvVar) ?? $"{FormHelper.GetExecutingDirectory()}\\AcLogSettings.json";

            AclSettings = FormHelper.ReadSettingsJson(settingsPath);

            // Access Database 
            foreach (var setting in AclSettings.AccessMdbs)
            {
                cboAccessFilePath.Items.Add(new CtrlListItem(setting.FilePath));
            }

            if (cboAccessFilePath.Items.Count > 0)
            {
                cboAccessFilePath.SelectedIndex = 0;
            }

            // SQL Database 
            foreach (var setting in AclSettings.SqlServers)
            {
                cboSqlServer.Items.Add(new CtrlListItem(setting.ServerName));
            }

            if (cboSqlServer.Items.Count > 0)
            {
                cboSqlServer.SelectedIndex = 0;
            }

            _loadingDefaultData = false;
        }
        
        

        #endregion Form Loading 

        #region Utilities
        
        /*
            var timer = Stopwatch.StartNew();
            SomeCodeToTime();
            timer.Stop();
            Console.WriteLine("Method took {0} ms", timer.ElapsedMilliseconds);
        */

        private string DateTimeMinOrMax(DateTime dateTime, string subValue, string format)
        {
            if (dateTime.Equals(DateTime.MinValue) || dateTime.Equals(DateTime.MaxValue))
            {
                return subValue;
            }
            else
            {
                return (dateTime.ToString(format));
            }
        }

        private void DisplayDataSet(string dataSetName)
        {
            if (_displayDataSet == null)
            {
                Log.Warn("The Dataset " + dataSetName + " is null.");
                return;
            }

            if (_displayDataSet.Tables.Count.Equals(0))
            {
                Log.Warn("The Dataset " + dataSetName + " has no tables.");
                return;
            }

            try
            {
                nUpDnTable.Value = 1;
                dgProgramData.DataSource = _displayDataSet.Tables[0];
                lblTableName.Text = _displayDataSet.Tables[0].TableName;
            }
            catch (Exception ex)
            {
                Log.Info("Error binding the " + dataSetName + " DataSet to the datagrid: /r/n" + ex.Message);
            }
        }

        #endregion Utilities

        #region Logging

        // Todo: put these in the custom logger

        private void LogException(Exception ex, string prefix)
        {
            Log.Error(prefix + ": Exception\r\n\t" + ex.Message);
            LogInnerExceptions(ex);
        }

        private void LogInnerExceptions(Exception ex)
        {
            Exception exInner = ex;

            while (exInner.InnerException != null && exInner.Data.Count == 0)
            {
                exInner = exInner.InnerException;
            }
            if (exInner != ex)
            {
                Log.Error("Inner Exception: " + exInner.Message);
            }
        }

        private void LogException(Exception ex)
        {
            Log.Error("Exception: " + ex.Message);
            LogInnerExceptions(ex);
        }

        #endregion Logging

        #region Sql Server

        private void GetSqlTable(string sqlServer, string sqlDb, string tableName)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(" SQL Server: ");
                sb.Append(sqlServer);
                sb.Append(" Database: ");
                sb.Append(sqlDb);
                sb.Append(" TableName: ");
                sb.AppendLine(tableName);
                Log.Info(sb.ToString());
                this.Cursor = Cursors.WaitCursor;
                Application.DoEvents();
                sb.Clear();

                DataTable tbl = _acLogService.GetSqlTable(sqlServer, sqlDb, tableName);
                dgProgramData.DataSource = tbl;
                Log.Info("GetSqlTable: Read " + tbl.Rows.Count.ToString() + " Rows.");
            }
            catch (Exception ex)
            {
                Log.Error("GetSqlTable: " + ex.Message);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void GetSqlTableFields(string sqlServer, string sqlDb, string tableName)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("GetSqlTableFields Begin:");
                sb.Append(" SQL Server: ");
                sb.Append(sqlServer);
                sb.Append(" Database: ");
                sb.Append(sqlDb);
                sb.Append(" TableName: ");
                sb.AppendLine(tableName);
                Log.Info(sb.ToString());
                this.Cursor = Cursors.WaitCursor;
                Application.DoEvents();
                sb.Clear();

                var colList = _acLogService.GetSqlTableFields(sqlServer, sqlDb, tableName);
                sb.AppendLine($"GetAccessTableFields: Read {colList.Count} Columns.");
                int colCntr = 0;

                foreach (DataColumn column in colList)
                {
                    sb.Append(colCntr.ToString());
                    sb.Append("\t");
                    sb.Append(column.ColumnName);
                    sb.Append("\t");
                    sb.AppendLine(column.DataType.Name);
                    colCntr++;
                }
                Log.Info(sb.ToString());
            }
            catch (Exception ex)
            {
                Log.Error("GetSqlTable: " + ex.Message);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }

        }


        private void GetSqlTableLastMod(string sqlServer, string sqlDb, string tableName)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("GetSqlTableLastMod Begin:");
                sb.Append(" SQL Server: ");
                sb.Append(sqlServer);
                sb.Append(" Database: ");
                sb.Append(sqlDb);
                sb.Append(" TableName: ");
                sb.AppendLine(tableName);
                Log.Info(sb.ToString());
                this.Cursor = Cursors.WaitCursor;
                Application.DoEvents();
                sb.Clear();

                var lastMod = _acLogService.GetSqlTableLastModified(sqlServer, sqlDb, tableName);
                sb.AppendLine("GetSqlTableLastMod: Date " + lastMod.ToString(StdDateDispFmt));
                Log.Info(sb.ToString());
            }
            catch (Exception ex)
            {
                Log.Error("GetSqlTableLastMod: " + ex.Message);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }

        }

        private void FillTableFromCSV(string sqlServer, string sqlDb, string tableName, string filePath)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("FillTableFromCSV Begin:");
                sb.Append(" SQL Server: ");
                sb.Append(sqlServer);
                sb.Append(" Database: ");
                sb.Append(sqlDb);
                sb.Append(" TableName: ");
                sb.AppendLine(tableName);
                sb.Append("FilePath: ");
                sb.AppendLine(filePath);
                Log.Info(sb.ToString());
                this.Cursor = Cursors.WaitCursor;
                Application.DoEvents();
                sb.Clear();

                var rowCnt = _acLogService.CopyCsvToSqlTable(sqlServer, sqlDb, tableName, filePath);
                sb.AppendLine("FillTableFromCSV: Rows copied " + rowCnt.ToString());
                Log.Info(sb.ToString());
            }
            catch (Exception ex)
            {
                Log.Error("FillTableFromCSV: " + ex.Message);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void ClearSqlTable(string sqlServer, string sqlDb, string tableName)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("ClearSqlTable Begin:");
                sb.Append(" SQL Server: ");
                sb.Append(sqlServer);
                sb.Append(" Database: ");
                sb.Append(sqlDb);
                sb.Append(" TableName: ");
                sb.AppendLine(tableName);
                Log.Info(sb.ToString());
                this.Cursor = Cursors.WaitCursor;
                Application.DoEvents();
                sb.Clear();

                var lastMod = _acLogService.ClearSqlTable(sqlServer, sqlDb, tableName);
                sb.AppendLine("ClearSqlTable: rows " + lastMod.ToString());
                Log.Info(sb.ToString());
            }
            catch (Exception ex)
            {
                Log.Error("ClearSqlTable: " + ex.Message);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }

        }

        private void UpdateSqlTable(string sqlServer, string sqlDb, string tableNameSql, string accessFilePath, string tableNameAccess)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("UpdateSqlTable Begin:");
                sb.Append(" SQL Server: ");
                sb.Append(sqlServer);
                sb.Append(" Database: ");
                sb.Append(sqlDb);
                sb.Append(" TableName: ");
                sb.AppendLine(tableNameSql);
                sb.Append(" FilePath: ");
                sb.AppendLine(accessFilePath);
                sb.Append(" TableName: ");
                sb.AppendLine(tableNameAccess);
                Log.Info(sb.ToString());
                this.Cursor = Cursors.WaitCursor;
                Application.DoEvents();
                sb.Clear();

                var rowsCopied = _acLogService.UpdateSqlTable(sqlServer, sqlDb, tableNameSql, accessFilePath, tableNameAccess);
                sb.AppendLine("UpdateSqlTable: rows " + rowsCopied.ToString());
                Log.Info(sb.ToString());
            }
            catch (Exception ex)
            {
                Log.Error("ClearSqlTable: " + ex.Message);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void UpdateAllSqlTable(string sqlServer, string sqlDb, string accessFilePath, ComboBox tableNames)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("UpdateAllSqlTable Begin:");
                sb.Append(" SQL Server: ");
                sb.Append(sqlServer);
                sb.Append(" Database: ");
                sb.Append(sqlDb);
                sb.Append(" FilePath: ");
                sb.AppendLine(accessFilePath);
                Log.Info(sb.ToString());
                this.Cursor = Cursors.WaitCursor;
                Application.DoEvents();

                int tableCnt = tableNames.Items.Count;

                for (int tableIdx = 0; tableIdx < tableCnt; tableIdx++)
                {
                    var ctrlItem = (CtrlListItem)tableNames.Items[tableIdx];
                    sb.Clear();
                    sb.Append(" Access Table: ");
                    sb.Append(ctrlItem.ToString());
                    sb.Append(" -- SQL Table: ");
                    sb.Append(ctrlItem.ItemDataString);
                    Log.Info(sb.ToString());
                    Application.DoEvents();

                    var rowsDel = _acLogService.ClearSqlTable(sqlServer, sqlDb, ctrlItem.ItemDataString);
                    sb.Clear();
                    sb.Append("ClearSqlTable: Rows ");
                    sb.Append(rowsDel.ToString());
                    Log.Info(sb.ToString());
                    Application.DoEvents();

                    var rowsCopied = _acLogService.UpdateSqlTable(sqlServer, sqlDb, ctrlItem.ItemDataString, accessFilePath, ctrlItem.ToString());
                    sb.Clear();
                    sb.Append("UpdateSqlTable: Rows: ");
                    sb.Append(rowsCopied.ToString());
                    _acLogService.SetLastTableUpdDateTime(sqlServer, sqlDb, ctrlItem.ItemDataString);
                    sb.AppendLine(", LastUpdate DateTime set.");
                    Log.Info(sb.ToString());
                    Application.DoEvents();
                }
                Log.Info("Update All SQL Tables was successful!");
            }
            catch (Exception ex)
            {
                Log.Error("Update All SQL Tables encountered an error: " + ex.Message);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        #endregion  Sql Server

        #region Access

        private void GetAccessTable(string accessFilePath, string tableName)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("GetAccessTable Begin:");
                sb.Append(" FilePath: ");
                sb.AppendLine(accessFilePath);
                sb.Append(" TableName: ");
                sb.AppendLine(tableName);
                Log.Info(sb.ToString());
                this.Cursor = Cursors.WaitCursor;
                Application.DoEvents();
                sb.Clear();

                DataTable tbl = _acLogService.GetAccessTable(accessFilePath, tableName);
                dgProgramData.DataSource = tbl;
                Log.Info("GetAccessTable: Read " +  tbl.Rows.Count.ToString() + " Rows.");
            }
            catch (Exception ex)
            {
                Log.Error("GetAccessTable: " + ex.Message);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }

        }

        private void GetAccessTableFields(string accessFilePath, string tableName)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("GetAccessTableFields Begin:");
                sb.Append(" FilePath: ");
                sb.AppendLine(accessFilePath);
                sb.Append(" TableName: ");
                sb.AppendLine(tableName);
                Log.Info(sb.ToString());
                this.Cursor = Cursors.WaitCursor;
                Application.DoEvents();
                sb.Clear();

                var colList = _acLogService.GetAccessTableColumnNames(accessFilePath, tableName);
                sb.AppendLine("GetAccessTableFields: Read " + colList.Count + " Columns.");
                int colCntr = 1;

                foreach (DataColumn column in colList)
                {
                    sb.Append(colCntr.ToString());
                    sb.Append("\t");
                    sb.Append(column.ColumnName);
                    sb.Append("\t");
                    sb.AppendLine(column.DataType.Name);
                    colCntr++;
                }
                Log.Info(sb.ToString());
            }
            catch (Exception ex)
            {
                Log.Error("GetAccessTableFields: " + ex.Message);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }

        }

        private void GetAccessTableLastMod(string accessFilePath, string tableName)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("GetAccessTableLastMod Begin:");
                sb.Append(" FilePath: ");
                sb.AppendLine(accessFilePath);
                sb.Append(" TableName: ");
                sb.AppendLine(tableName);
                Log.Info(sb.ToString());
                this.Cursor = Cursors.WaitCursor;
                Application.DoEvents();
                sb.Clear();

                var lastMod = _acLogService.GetAccessTableLastModified(accessFilePath, tableName);
                sb.Append("GetAccessTableLastMod: ");
                sb.Append(lastMod.ToString(StdDateDispFmt));
                Log.Info(sb.ToString());
            }
            catch (Exception ex)
            {
                Log.Error("GetAccessTableLastMod: " + ex.Message);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }

        }


        #endregion Exchange 2

        #region Events

        #region Form

        private void TestHost_Load(object sender, EventArgs e)
        {
            Properties.Settings settings = Properties.Settings.Default;
            Log = new Log4Form(typeof(TestHost).ToString(), rtxtLog);
            Log.Info("*****************************************************************");
            Log.Info(AppLogName + ": Application Started.");

            LoadDefaultData();
        }

        private void TestHost_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_externalSvcConnected)
            {
            }
        }

        #endregion Form

        #region Buttons

        private void btnReadAccessTable_Click(object sender, EventArgs e)
        {
            GetAccessTable(cboAccessFilePath.Text, cboAccessTable.Text);
        }

        private void btnGetFields_Click(object sender, EventArgs e)
        {
            GetAccessTableFields(cboAccessFilePath.Text, cboAccessTable.Text);
        }

        private void btnAccessGetLastModified_Click(object sender, EventArgs e)
        {
            GetAccessTableLastMod(cboAccessFilePath.Text, cboAccessTable.Text);
        }

        private void btnReadSqlSvrTable_Click(object sender, EventArgs e)
        {
            GetSqlTable(cboSqlServer.Text, cboSqlDb.Text, cboTableSqlSvr.Text);
        }

        private void btnGetSqlSvrFields_Click(object sender, EventArgs e)
        {
            GetSqlTableFields(cboSqlServer.Text, cboSqlDb.Text, cboTableSqlSvr.Text);
        }

        private void btnSqlGetLastModified_Click(object sender, EventArgs e)
        {
            FillTableFromCSV(cboSqlServer.Text, cboSqlDb.Text, cboTableSqlSvr.Text, cboAccessFilePath.Text);
        }

        private void btnClearSqlRows_Click(object sender, EventArgs e)
        {
            ClearSqlTable(cboSqlServer.Text, cboSqlDb.Text, cboTableSqlSvr.Text);
        }

        private void btnUpdSqlSvr_Click(object sender, EventArgs e)
        {
            var ctrlItem = (CtrlListItem)cboAccessTable.SelectedItem;
            UpdateSqlTable(cboSqlServer.Text, cboSqlDb.Text, ctrlItem.ItemDataString, cboAccessFilePath.Text, ctrlItem.ToString());
        }

        private void btnUpdateAllTables_Click(object sender, EventArgs e)
        {
            UpdateAllSqlTable(cboSqlServer.Text, cboSqlDb.Text, cboAccessFilePath.Text, cboAccessTable);
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {

        }

        #endregion Buttons

        #region Text and CBO

        private void txtAccessUname_TextChanged(object sender, EventArgs e)
        {
            CreateAcLogServices();
        }

        private void txtAccessUsrPword_TextChanged(object sender, EventArgs e)
        {
            CreateAcLogServices();
        }


        private void txtSqlUname_TextChanged(object sender, EventArgs e)
        {
            CreateAcLogServices();
        }

        private void txtSqlUsrPword_TextChanged(object sender, EventArgs e)
        {
            CreateAcLogServices();
        }

        private void cboAccessFilePath_SelectedIndexChanged(object sender, EventArgs e)
        {
            var target = cboAccessFilePath.SelectedIndex;
            var setting = AclSettings.AccessMdbs[target];
            txtAccessUname.Text = setting.UserName;
            txtAccessUsrPword.Text = setting.PassWord;
            cboAccessTable.Items.Clear();

            foreach (var table in setting.Tables)
            {
                cboAccessTable.Items.Add(new CtrlListItem(table));
            }

            if (cboAccessTable.Items.Count > 0)
            {
                cboAccessTable.SelectedIndex = 0;
            }
        }

        private void cboSqlServer_SelectedIndexChanged(object sender, EventArgs e)
        {
            var target = cboSqlServer.SelectedIndex;
            var setting = AclSettings.SqlServers[target];
            cboSqlDb.Items.Clear();

            foreach (var server in setting.SqlServerDbs)
            {
                cboSqlDb.Items.Add(new CtrlListItem(server.DatabaseName));
            }

            if (cboSqlDb.Items.Count > 0)
            {
                cboSqlDb.SelectedIndex = 0;
            }
        }

        private void cboSqlDb_SelectedIndexChanged(object sender, EventArgs e)
        {
            var server = cboSqlServer.SelectedIndex;
            var target = cboSqlDb.SelectedIndex;
            var setting = AclSettings.SqlServers[server].SqlServerDbs[target];

            txtSqlUname.Text = setting.UserName;
            txtSqlUsrPword.Text = setting.PassWord;
            cboTableSqlSvr.Items.Clear();

            foreach (var table in setting.Tables)
            {
                cboTableSqlSvr.Items.Add(new CtrlListItem(table));
            }

            if (cboTableSqlSvr.Items.Count > 0)
            {
                cboTableSqlSvr.SelectedIndex = 0;
            }
        }


        #endregion

        #region Log/Output Buttons

        private void btnClear_Click(object sender, EventArgs e)
        {
            rtxtLog.Text = string.Empty;
        }

        private void btnCopyLog_Click(object sender, EventArgs e)
        {
            FormHelper.CopyToClipboard(rtxtLog.Text);
        }

        private void btnNewLogFile_Click(object sender, EventArgs e)
        {
            
        }

        private void btnToExcel_Click(object sender, EventArgs e)
        {
            if (_displayDataSet != null)
            {
            }
        }

        #endregion Log/Output Buttons

        #region Other Ctrls

        #endregion Other Ctrls

        #endregion Events
    }

    #region Helper Classes

    public class CtrlListItem
    {
        protected string text = string.Empty;
        protected int itemData = 0;
        protected string itemDataString = string.Empty;

        public CtrlListItem(string Text)
        {
            text = Text;
            itemData = 0;
        }

        public CtrlListItem(string Text, int ItemData)
        {
            text = Text;
            itemData = ItemData;
        }

        public CtrlListItem(string Text, string ItemDataString)
        {
            text = Text;
            itemDataString = ItemDataString;
        }

        public int ItemData
        {
            get { return itemData; }
            set { itemData = value; }
        }

        public string ItemDataString
        {
            get { return itemDataString; }
            set { itemDataString = value; }
        }

        public override string ToString()
        {
            return text;
        }
    }

    public class CtrlListObjItem
    {
        protected Enum itemData;

        public CtrlListObjItem(Enum enumVal)
        {
            itemData = enumVal;
        }

        public Enum ItemData
        {
            get { return itemData; }
            set { itemData = value; }
        }

        public override string ToString()
        {
            return itemData.ToString();
        }
    }

    #endregion Helper Classes
}

