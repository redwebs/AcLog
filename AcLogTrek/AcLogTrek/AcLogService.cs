using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Text;
using System.IO;

namespace AcLogServices
{
	/// <summary>
	/// Interface to retrieve Sharepoint Data
	/// </summary>
	/// 
	public class AcLogService
	{
		#region Member Variables

		private string _ConnectionStringAccess = string.Empty;
		private string _SqlUserName = string.Empty;
		private string _SqlUserPword = string.Empty;
		private string _LastError = string.Empty;
		private Exception _LastException = null;
		private bool _WindowsSecurity = false;

		#endregion

		#region Constants

		private const string _LastUpdStoredProcName = "SetLastTableUpdate";

		#endregion Constants

		#region Public Properties

		public string LastError
		{
			get { return _LastError; }
		}
		public Exception LastException
		{
			get { return _LastException; }
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
			string windowsUserName, 
			string windowsUserPword,
			bool windowsSecurity)
		{
			_ConnectionStringAccess = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\"" + accessFilePath + "\"; Persist Security Info=True"; 
			_SqlUserName = sqlUserName;
			_SqlUserPword = sqlUserPword;
			_WindowsSecurity = windowsSecurity;
		}

		#endregion

		#region Public Functions

		public DataTable GetAccessTable(string accessFilePath, string tableName)
		{
			return AccessQuery(accessFilePath, "Select * from [" + tableName + "]");
		}

		public List<DataColumn> GetAccessTableColumnNames(string accessFilePath, string tableName)
		{
			DataTable dataTable = AccessQuery(accessFilePath, "Select * from [" + tableName + "]");

			int colCnt = dataTable.Columns.Count;
			var colList = new List<DataColumn>(colCnt);

			for (int colIdx = 0; colIdx < colCnt; colIdx++)
			{
				colList.Add(dataTable.Columns[colIdx]);
			}

			return colList;
		}

		public DateTime GetAccessTableLastModified(string accessFilePath, string tableName)
		{
			Object obj = AccessExecuteScalar(accessFilePath, "Select Max(Modified) as LastMod from [" + tableName + "]");
			if (obj == DBNull.Value)
			{
				return DateTime.MinValue;
			}
			else
			{
				return Convert.ToDateTime(obj);
			}
		}

		private string BuildSSConnString(string sqlServer, string sqlDb)
		{
			if (_WindowsSecurity)
			{
				return "Data Source=" + sqlServer + ";Initial Catalog=" + sqlDb + ";Integrated Security=SSPI;";
			}
			else
			{
				return "Data Source=" + sqlServer + ";Initial Catalog=" + sqlDb + ";User Id=" + _SqlUserName + ";Password=" + _SqlUserPword + ";";
			}
		}

		public DataTable GetSqlTable(string sqlServer, string sqlDb, string tableName)
		{
			string connectionString = BuildSSConnString(sqlServer, sqlDb);
			return SqlQuery(connectionString, "Select * from [" + tableName + "]");
		}

		public List<DataColumn> GetSqlTableFields(string sqlServer, string sqlDb, string tableName)
		{
			string connectionString = BuildSSConnString(sqlServer, sqlDb);
			DataTable dataTable = SqlQuery(connectionString, "Select top 1 * from [" + tableName + "]");

			int colCnt = dataTable.Columns.Count;
			var colList = new List<DataColumn>(colCnt);

			for (int colIdx = 0; colIdx < colCnt; colIdx++)
			{
				colList.Add(dataTable.Columns[colIdx]);
			}

			return colList;
		}

		public void SetLastTableUpdDateTime(string sqlServer, string sqlDb, string tableName)
		{
			string connectionString = BuildSSConnString(sqlServer, sqlDb);
			SqlConnection sqlConn = null;
			int retVal = 0;

			try
			{
				using (sqlConn = new SqlConnection(connectionString))
				{
					sqlConn.Open();
					var SQLQuery = new SqlCommand();
					SQLQuery.CommandType = CommandType.StoredProcedure;
					SQLQuery.CommandText = _LastUpdStoredProcName;
					SQLQuery.Connection = sqlConn;
					var param = new SqlParameter("@Name", tableName);
					SQLQuery.Parameters.Add(param);

					retVal = SQLQuery.ExecuteNonQuery();
				}
			}
			catch (Exception ex)
			{
				string msg = "Error in AcLogServices.SetLastTableUpdDateTime\r\n\tConn String: " + 
					connectionString + "\r\n\t" + "Table Name: " +
					tableName + "\r\n\tMessage:" + ex.Message;
				throw (new Exception(msg, ex));
			}
		}

		public int ClearSqlTable(string sqlServer, string sqlDb, string tableName)
		{
			string connectionString = BuildSSConnString(sqlServer, sqlDb);
			return SqlExecuteNonQuery(connectionString, "Delete from [" + tableName + "]");
		}

		public DateTime GetSqlTableLastModified(string sqlServer, string sqlDb, string tableName)
		{
			string connectionString = BuildSSConnString(sqlServer, sqlDb);
			Object obj = SqlExecuteScalar(connectionString, "Select Max(Modified) from [" + tableName + "]");
			if (obj == DBNull.Value)
			{
				return DateTime.MinValue;
			}
			else
			{
				return Convert.ToDateTime(obj);
			}
		}

		public int UpdateSqlTable(string sqlServer, string sqlDb, string tableNameSql, string csvFilePath, string tableNameAccess)
		{
			StringBuilder lastRow = new StringBuilder();
			string connectionString = BuildSSConnString(sqlServer, sqlDb);
			var dtSource = AccessQuery(csvFilePath, "Select * from [" + tableNameAccess + "]");
			string sqlQueryString = "Select * from [" + tableNameSql + "]";
			int rowCntSource = dtSource.Rows.Count;
			int rowsCopied = 0;

			var dtTarget = new DataTable();
			SqlConnection sqlConn = null;
			SqlDataAdapter dataAdapter = null;

			try
			{
				using (sqlConn = new SqlConnection(connectionString))
				{
					sqlConn.Open();
					dataAdapter = new SqlDataAdapter();
					dataAdapter.SelectCommand = new SqlCommand(sqlQueryString, sqlConn);
					dataAdapter.Fill(dtTarget);
					var builder = new SqlCommandBuilder(dataAdapter);

					int cntTargetCols = dtTarget.Columns.Count - 1;
					lastRow.Clear();

					for (int row = 0; row < rowCntSource; row++)
					{
						lastRow.Append(row.ToString());
						lastRow.Append(",");

						var newRow = dtTarget.NewRow();

						for (int column = 0; column < cntTargetCols; column++)
						{
							lastRow.Append(row.ToString());
							lastRow.Append(",");

							newRow[column + 1] = dtSource.Rows[row][column];
						}
						dtTarget.Rows.Add(newRow);
						rowsCopied++;
					}
					DataRow[] updateRows = dtTarget.Select(
									null, null, DataViewRowState.Added);
					dataAdapter.UpdateCommand = builder.GetUpdateCommand();
					dataAdapter.Update(updateRows);
				}
			}
			catch (Exception ex)
			{
				StringBuilder msg = new StringBuilder();
				msg.Append("Error in AcLogServices.UpdateSqlTable\r\n\tConn String: ");
				msg.AppendLine(connectionString);
				msg.Append("\tQuery SQL Svr: ");
				msg.AppendLine(sqlQueryString);
				msg.Append("\tSourceRows = ");
				msg.AppendLine(rowCntSource.ToString());
				msg.Append("\tData In Row: ");
				msg.AppendLine(lastRow.ToString()); 
				msg.Append("\tMessage:");
				msg.AppendLine(ex.Message);
				throw (new Exception(msg.ToString(), ex));
			}
			return rowsCopied;
		}

		public int CopyCSVToSqlTable(string sqlServer, string sqlDb, string tableNameSql, string csvFilePath)
		{
			string lastRow = string.Empty;
			string connectionString = BuildSSConnString(sqlServer, sqlDb);
			string sqlQueryString = "Select * from [" + tableNameSql + "]";

			var fileRows = GetFileRows(csvFilePath);

			int rowCntSource = fileRows.Count;
			int rowsCopied = 0;

			var dtTarget = new DataTable();
			SqlConnection sqlConn = null;
			SqlDataAdapter dataAdapter = null;

			try
			{
				using (sqlConn = new SqlConnection(connectionString))
				{
					sqlConn.Open();
					dataAdapter = new SqlDataAdapter();
					dataAdapter.SelectCommand = new SqlCommand(sqlQueryString, sqlConn);
					dataAdapter.Fill(dtTarget);
					var builder = new SqlCommandBuilder(dataAdapter);

					int cntTargetCols = dtTarget.Columns.Count - 1;

					foreach (string row in fileRows)
					{
						lastRow = row;
						var newRow = dtTarget.NewRow();
						string[] rowItems = row.Split(',');

						for (int column = 0; column < cntTargetCols; column++)
						{
							newRow[column + 1] = rowItems[column].Replace("\"", "");
						}
						dtTarget.Rows.Add(newRow);
						rowsCopied++;
					}
					DataRow[] updateRows = dtTarget.Select(
									null, null, DataViewRowState.Added);
					dataAdapter.UpdateCommand = builder.GetUpdateCommand();
					dataAdapter.Update(updateRows);
				}
			}
			catch (Exception ex)
			{
				StringBuilder msg = new StringBuilder();
				msg.Append("Error in AcLogServices.CopyCSVToSqlTable\r\n\tConn String: ");
				msg.AppendLine(connectionString);
				msg.Append("\tQuery SQL Svr: ");
				msg.AppendLine(sqlQueryString);
				msg.Append("\tSourceRows = ");
				msg.AppendLine(rowCntSource.ToString());
				msg.Append("\tData In Row: ");
				msg.AppendLine(lastRow);
				msg.Append("\tMessage:");
				msg.AppendLine(ex.Message);
				throw (new Exception(msg.ToString(), ex));
			}
			return rowsCopied;
		}

		#region Private Functions

		private List<string> GetFileRows(string csvFilePath)
		{
			var listOutput = new List<string>();

			if (File.Exists(csvFilePath))
			{
				using (StreamReader reader = new StreamReader(csvFilePath))
				{
					string line = null;

					while ((line = reader.ReadLine()) != null)
					{
						listOutput.Add(line); // Add to list.
					}
				}
			}
			return listOutput;
		}


		private Object SqlExecuteScalar(string connString, string sqlQueryString)
		{
			var dataTable = new DataTable();
			SqlConnection sqlConn = null;
			Object returnObj = null;

			try
			{
				using (sqlConn = new SqlConnection(connString))
				{
					sqlConn.Open();
					var SQLQuery = new SqlCommand();

					SQLQuery.CommandText = sqlQueryString;
					SQLQuery.Connection = sqlConn;

					returnObj = SQLQuery.ExecuteScalar();
				}
			}
			catch (Exception ex)
			{
				string msg = "Error in AcLogServices.SqlExecuteScalar\r\n\tConn String: " + connString + "\r\n\t" + "Query SQL: " +
					sqlQueryString + "\r\n\tMessage:" + ex.Message;
				throw (new Exception(msg, ex));
			}
			return returnObj;
		}

		private int SqlExecuteNonQuery(string connString, string sqlQueryString)
		{
			SqlConnection sqlConn = null;
			int retVal = 0;

			try
			{
				using (sqlConn = new SqlConnection(connString))
				{
					sqlConn.Open();
					var SQLQuery = new SqlCommand();

					SQLQuery.CommandText = sqlQueryString;
					SQLQuery.Connection = sqlConn;

					retVal = SQLQuery.ExecuteNonQuery();
				}
			}
			catch (Exception ex)
			{
				string msg = "Error in AcLogServices.SqlExecuteNonQuery\r\n\tConn String: " + connString + "\r\n\t" + "Query SQL: " +
					sqlQueryString + "\r\n\tMessage:" + ex.Message;
				throw (new Exception(msg, ex));
			}
			return retVal;
		}

		private DataTable SqlQuery(string connString, string sqlQueryString)
		{
			var dataTable = new DataTable();
			SqlConnection sqlConn = null;
			SqlDataAdapter dataAdapter = null;

			try
			{
				using (sqlConn = new SqlConnection(connString))
				{
					sqlConn.Open();
					var SQLQuery = new SqlCommand();

					SQLQuery.CommandText = sqlQueryString;
					SQLQuery.Connection = sqlConn;

					dataAdapter = new SqlDataAdapter(SQLQuery);
					dataAdapter.Fill(dataTable);
				}
			}
			catch (Exception ex)
			{
				string msg = "Error in AcLogServices.SqlQuery\r\n\tConn String: " + connString + "\r\n\t" + "Query SQL: " +
					sqlQueryString + "\r\n\tMessage:" + ex.Message;
				throw (new Exception(msg, ex));
			}
			return dataTable;
		}

		private DataTable AccessQuery(string accessFilePath, string sqlQueryString)
		{
			var dataTable = new DataTable();
			OleDbConnection oleDbConn = null;
			OleDbDataAdapter dataAdapter = null;

			try
			{
				using (oleDbConn = new OleDbConnection(_ConnectionStringAccess))
				{
					oleDbConn.Open();
					var SQLQuery = new OleDbCommand();

					SQLQuery.CommandText = sqlQueryString;
					SQLQuery.Connection = oleDbConn;

					dataAdapter = new OleDbDataAdapter(SQLQuery);
					dataAdapter.Fill(dataTable);
				}
			}
			catch (Exception ex)
			{
				string msg = "Error in AcLogServices.AccessQuery\r\n\tConn String: " + _ConnectionStringAccess + "\r\n\t" + "Query SQL: " +
					sqlQueryString + "\r\n\tMessage:" + ex.Message;
				throw (new Exception(msg, ex));
			}
			return dataTable;
		}

		private Object AccessExecuteScalar(string accessFilePath, string sqlQueryString)
		{
			var dataTable = new DataTable();
			OleDbConnection oleDbConn = null;
			Object returnObj = null;

			try
			{
				using (oleDbConn = new OleDbConnection(_ConnectionStringAccess))
				{
					oleDbConn.Open();
					var SQLQuery = new OleDbCommand();

					SQLQuery.CommandText = sqlQueryString;
					SQLQuery.Connection = oleDbConn;

					returnObj = SQLQuery.ExecuteScalar();
				}
			}
			catch (Exception ex)
			{
				string msg = "Error in AcLogServices.AccessExecuteScalar\r\n\tConn String: " + _ConnectionStringAccess + "\r\n\t" + "Query SQL: " +
					sqlQueryString + "\r\n\tMessage:" + ex.Message;
				throw (new Exception(msg, ex));
			}
			return returnObj;
		}

		#endregion

		#endregion Private Functions
	}
}

