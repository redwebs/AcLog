using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Text;
using System.IO;

namespace AclTrek
{
    /// <summary>
    /// Interface to retrieve / store Access and SQL Server Data
    /// </summary>
    /// 
    public class AcLogService
    {
        #region Member Variables
        private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private readonly string _connectionStringAccess = string.Empty;
        private readonly string _sqlUserName = string.Empty;
        private readonly string _sqlUserPword = string.Empty;
        private readonly string _lastError = string.Empty;
        private readonly Exception _lastException = null;
        private readonly bool _windowsSecurity = false;

        #endregion

        #region Constants

        private const string LastUpdStoredProcName = "SetLastTableUpdate";

        #endregion Constants

        #region Public Properties

        public string LastError
        {
            get { return _lastError; }
        }
        public Exception LastException
        {
            get { return _lastException; }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Get Sharepoint List data and Update Sql Server Tables using an intermediate Access Database with linked tables
        /// </summary>
        /// <param name="accessFilePath">Full pathname to the Access Database with linked tables.</param>
        /// <param name="sqlUserName">Username of the SQL Server user.</param>
        /// <param name="sqlUserPword">Password of the SWL Server user.</param>
        /// 
        public AcLogService(
            string accessFilePath, 
            string sqlUserName, 
            string sqlUserPword,
            string accessUserName, 
            string accessUserPword,
            bool windowsSecurity)
        {
            _connectionStringAccess = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\"" + accessFilePath + "\"; Persist Security Info=True"; 
            _sqlUserName = sqlUserName;
            _sqlUserPword = sqlUserPword;
            _windowsSecurity = windowsSecurity;
        }

        #endregion

        #region Public Functions

        public DataTable GetAccessTable(string accessFilePath, string tableName)
        {
            return AccessQuery(accessFilePath, $"Select * from [{tableName}]");
        }

        public List<DataColumn> GetAccessTableColumnNames(string accessFilePath, string tableName)
        {
            var dataTable = AccessQuery(accessFilePath, $"Select * from [{tableName}]");

            var colCnt = dataTable.Columns.Count;
            var colList = new List<DataColumn>(colCnt);

            for (var colIdx = 0; colIdx < colCnt; colIdx++)
            {
                colList.Add(dataTable.Columns[colIdx]);
            }
            return colList;
        }

        public DateTime GetAccessTableLastModified(string accessFilePath, string tableName)
        {
            var obj = AccessExecuteScalar(accessFilePath, "Select Max(Modified) as LastMod from [" + tableName + "]");

            return obj == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(obj);
        }

        private string BuildSsConnString(string sqlServer, string sqlDb)
        {
            if (_windowsSecurity)
            {
                return $"Data Source={sqlServer};Initial Catalog={sqlDb};Integrated Security=SSPI;";
            }
            return $"Data Source={sqlServer};Initial Catalog={sqlDb};User Id={_sqlUserName};Password={_sqlUserPword};";
        }

        public DataTable GetSqlTable(string sqlServer, string sqlDb, string tableName)
        {
            string connectionString = BuildSsConnString(sqlServer, sqlDb);
            return SqlQuery(connectionString, $"Select * from [{tableName}]");
        }

        public List<DataColumn> GetSqlTableFields(string sqlServer, string sqlDb, string tableName)
        {
            var connectionString = BuildSsConnString(sqlServer, sqlDb);
            var dataTable = SqlQuery(connectionString, $"Select top 1 * from [{tableName}]");

            var colCnt = dataTable.Columns.Count;
            var colList = new List<DataColumn>(colCnt);

            for (var colIdx = 0; colIdx < colCnt; colIdx++)
            {
                colList.Add(dataTable.Columns[colIdx]);
            }
            return colList;
        }

        public int SetLastTableUpdDateTime(string sqlServer, string sqlDb, string tableName)
        {
            var connectionString = BuildSsConnString(sqlServer, sqlDb);

            try
            {
                using (var sqlConn = new SqlConnection(connectionString))
                {
                    sqlConn.Open();
                    var sqlCmd = new SqlCommand
                    {
                        CommandType = CommandType.StoredProcedure,
                        CommandText = LastUpdStoredProcName,
                        Connection = sqlConn
                    };
                    var param = new SqlParameter("@Name", tableName);
                    sqlCmd.Parameters.Add(param);

                    return sqlCmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                var msg = FormatAndLogException("SetLastTableUpdDateTime", connectionString, tableName, ex);
                throw (new Exception(msg, ex));
            }
        }

        public int ClearSqlTable(string sqlServer, string sqlDb, string tableName)
        {
            var connectionString = BuildSsConnString(sqlServer, sqlDb);
            return SqlExecuteNonQuery(connectionString, $"Delete from [{tableName}]");
        }

        public DateTime GetSqlTableLastModified(string sqlServer, string sqlDb, string tableName)
        {
            var connectionString = BuildSsConnString(sqlServer, sqlDb);
            var obj = SqlExecuteScalar(connectionString, $"Select Max(Modified) from [{tableName}]");
            return obj == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(obj);
        }

        public int UpdateSqlTable(string sqlServer, string sqlDb, string tableNameSql, string csvFilePath, string tableNameAccess)
        {
            var connectionString = BuildSsConnString(sqlServer, sqlDb);
            var sqlQueryString = $"Select * from [{tableNameSql}]";
            var dtSource = AccessQuery(csvFilePath, $"Select * from [{tableNameAccess}");
            var rowCntSource = dtSource.Rows.Count;

            try
            {
                var lastRow = new StringBuilder();

                using (var sqlConn = new SqlConnection(connectionString))
                {
                    sqlConn.Open();
                    var dataAdapter = new SqlDataAdapter {SelectCommand = new SqlCommand(sqlQueryString, sqlConn)};
                    var dtTarget = new DataTable();
                    dataAdapter.Fill(dtTarget);

                    var cntTargetCols = dtTarget.Columns.Count - 1;
                    lastRow.Clear();
                    var rowsCopied = 0;

                    for (var row = 0; row < rowCntSource; row++)
                    {
                        lastRow.Append(row.ToString());
                        lastRow.Append(",");

                        var newRow = dtTarget.NewRow();

                        for (var column = 0; column < cntTargetCols; column++)
                        {
                            lastRow.Append(row.ToString());
                            lastRow.Append(",");

                            newRow[column + 1] = dtSource.Rows[row][column];
                        }
                        dtTarget.Rows.Add(newRow);
                        rowsCopied++;
                    }
                    var updateRows = dtTarget.Select(null, null, DataViewRowState.Added);

                    var builder = new SqlCommandBuilder(dataAdapter);
                    dataAdapter.UpdateCommand = builder.GetUpdateCommand();
                    dataAdapter.Update(updateRows);
                    return rowsCopied;
                }
            }
            catch (Exception ex)
            {
                var msg = new StringBuilder();
                msg.AppendLine("Error in UpdateSqlTable");
                msg.Append("\tConn String: ");
                msg.AppendLine(connectionString);
                msg.Append("\tQuery SQL Svr: ");
                msg.AppendLine(sqlQueryString);
                msg.Append("\tSourceRows = ");
                msg.AppendLine(rowCntSource.ToString());
                msg.Append("\tMessage:");
                msg.AppendLine(ex.Message);

                Log.Error(msg);
                throw (new Exception(msg.ToString(), ex));
            }
        }

        public int CopyCsvToSqlTable(string sqlServer, string sqlDb, string tableNameSql, string csvFilePath)
        {
            var lastRow = string.Empty;
            var connectionString = BuildSsConnString(sqlServer, sqlDb);
            var sqlQueryString = $"Select * from [{tableNameSql}]";

            var fileRows = GetFileRows(csvFilePath);

            var rowCntSource = fileRows.Count;

            var dtTarget = new DataTable();

            try
            {
                using (var sqlConn = new SqlConnection(connectionString))
                {
                    sqlConn.Open();
                    var dataAdapter = new SqlDataAdapter {SelectCommand = new SqlCommand(sqlQueryString, sqlConn)};
                    dataAdapter.Fill(dtTarget);
                    var builder = new SqlCommandBuilder(dataAdapter);

                    var cntTargetCols = dtTarget.Columns.Count - 1;
                    var rowsCopied = 0;

                    foreach (var row in fileRows)
                    {
                        lastRow = row;
                        var newRow = dtTarget.NewRow();
                        var rowItems = row.Split(',');

                        for (var column = 0; column < cntTargetCols; column++)
                        {
                            newRow[column + 1] = rowItems[column].Replace("\"", "");
                        }
                        dtTarget.Rows.Add(newRow);
                        rowsCopied++;
                    }
                    var updateRows = dtTarget.Select(
                                    null, null, DataViewRowState.Added);
                    dataAdapter.UpdateCommand = builder.GetUpdateCommand();
                    dataAdapter.Update(updateRows);
                    return rowsCopied;
                }
            }
            catch (Exception ex)
            {
                var msg = new StringBuilder();
                msg.AppendLine("Error in CopyCSVToSqlTable");
                msg.Append("\tConn String: ");
                msg.AppendLine(connectionString);
                msg.Append("\tQuery SQL Svr: ");
                msg.AppendLine(sqlQueryString);
                msg.Append("\tSourceRows = ");
                msg.AppendLine(rowCntSource.ToString());
                msg.Append("\tData In Row: ");
                msg.AppendLine(lastRow);
                msg.Append("\tMessage:");
                msg.AppendLine(ex.Message);

                Log.Error(msg);
                throw (new Exception(msg.ToString(), ex));
            }
        }

        #endregion Public Functions

        #region Private Functions

        private static List<string> GetFileRows(string csvFilePath)
        {
            var listOutput = new List<string>();

            if (!File.Exists(csvFilePath))
            {
                return listOutput;
            }

            using (var reader = new StreamReader(csvFilePath))
            {
                string line;

                while ((line = reader.ReadLine()) != null)
                {
                    listOutput.Add(line); // Add to list.
                }
            }
            return listOutput;
        }


        private static Object SqlExecuteScalar(string connString, string sqlQueryString)
        {
            try
            {
                using (var sqlConn = new SqlConnection(connString))
                {
                    sqlConn.Open();
                    var sqlCmd = new SqlCommand {CommandText = sqlQueryString, Connection = sqlConn};
                    return sqlCmd.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {
                var msg = FormatAndLogException("SqlExecuteScalar", connString, sqlQueryString, ex);
                throw (new Exception(msg, ex));
            }
        }

        private int SqlExecuteNonQuery(string connString, string sqlQueryString)
        {
            try
            {
                using (var sqlConn = new SqlConnection(connString))
                {
                    sqlConn.Open();
                    var sqlCmd = new SqlCommand {CommandText = sqlQueryString, Connection = sqlConn};
                    return sqlCmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                var msg = FormatAndLogException("SqlExecuteNonQuery", connString, sqlQueryString, ex);
                throw (new Exception(msg, ex));
            }
        }

        private DataTable SqlQuery(string connString, string sqlQueryString)
        {
            try
            {
                using (var sqlConn = new SqlConnection(connString))
                {
                    sqlConn.Open();
                    var sqlCmd = new SqlCommand();

                    sqlCmd.CommandText = sqlQueryString;
                    sqlCmd.Connection = sqlConn;

                    var dataAdapter = new SqlDataAdapter(sqlCmd);
                    var dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);
                    return dataTable;
                }
            }
            catch (Exception ex)
            {
                var msg = FormatAndLogException("SqlQuery", connString, sqlQueryString, ex);
                throw (new Exception(msg, ex));
            }
        }

        private DataTable AccessQuery(string accessFilePath, string sqlQueryString)
        {
            try
            {
                using (var oleDbConn = new OleDbConnection(_connectionStringAccess))
                {
                    oleDbConn.Open();
                    var sqlCmd = new OleDbCommand {CommandText = sqlQueryString, Connection = oleDbConn};

                    var dataAdapter = new OleDbDataAdapter(sqlCmd);
                    var dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);
                    return dataTable;
                }
            }
            catch (Exception ex)
            {
                var msg = FormatAndLogException("AccessQuery", _connectionStringAccess, sqlQueryString, ex);
                throw (new Exception(msg, ex));
            }
        }

        private Object AccessExecuteScalar(string accessFilePath, string sqlQueryString)
        {
            try
            {
                using (var oleDbConn = new OleDbConnection(_connectionStringAccess))
                {
                    oleDbConn.Open();
                    var sqlCmd = new OleDbCommand();

                    sqlCmd.CommandText = sqlQueryString;
                    sqlCmd.Connection = oleDbConn;

                    return sqlCmd.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {
                var msg = FormatAndLogException("AccessExecuteScalar", _connectionStringAccess, sqlQueryString, ex);
                throw (new Exception(msg, ex));
            }
        }

        private static string FormatAndLogException(string function, string connString, string query, Exception ex)
        {
            var sb = new StringBuilder();
            sb.Append("Error in ");
            sb.AppendLine(function);
            sb.Append("\tConn String: ");
            sb.AppendLine(connString);
            sb.Append("\tQuery SQL:");
            sb.AppendLine(query);
            sb.Append("\tMessage:");
            sb.Append(ex.Message);

            Log.Error(sb.ToString());

            return sb.ToString();

        }

        #endregion Private Functions
    }
}

