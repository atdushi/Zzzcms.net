using System;
using System.Text;
using System.Configuration;
using System.Data.Common;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace DataObjects
{
    /// <summary>
    /// Class that manages all lower level ADO.NET data base access.
    /// </summary>
    /// <remarks>
    /// This class is a 'swiss army knife' of data access. It handles all the 
    /// database access details and shields its complexity from its clients.
    /// 
    /// The Factory Design pattern is used to create database specific instances
    /// of Connection objects, Command objects, etc.
    /// 
    /// This class is like a Singleton -- it is a static class (Shared in VB) and 
    /// therefore only one 'instance' ever will exist.
    /// 
    /// This class is a Proxy in that it 'stands in' for the actual DbProviderFactory.
    /// </remarks>
    public static class Db
    {
        // Note: Static initializers are thread safe.
        // If this class had a static constructor then these initialized 
        // would need to be initialized there.
        private static readonly string dataProvider = ConfigurationManager.AppSettings.Get("DataProvider");
        private static readonly DbProviderFactory factory = DbProviderFactories.GetFactory(dataProvider);
        private static readonly string connectionString = ConfigurationManager.ConnectionStrings[dataProvider].ConnectionString;

        /// <summary>
        /// Executes Update statements in the database.
        /// </summary>
        /// <param name="sql">Sql statement.</param>
        /// <returns>Number of rows affected.</returns>
        public static int Update(string sql)
        {
            using (DbConnection connection = factory.CreateConnection())
            {
                connection.ConnectionString = connectionString;

                using (DbCommand command = factory.CreateCommand())
                {
                    command.Connection = connection;
                    command.CommandText = sql;

                    connection.Open();
                    return command.ExecuteNonQuery();
                }
            }
        }


        /// <summary>
        /// Executes Insert statements in the database. Optionally returns new identifier.
        /// </summary>
        /// <param name="sql">Sql statement.</param>
        /// <param name="getId">Value indicating whether newly generated identity is returned.</param>
        /// <returns>Newly generated identity value (autonumber value).</returns>
        public static int Insert(string sql, bool getId)
        {
            using (DbConnection connection = factory.CreateConnection())
            {
                connection.ConnectionString = connectionString;

                using (DbCommand command = factory.CreateCommand())
                {
                    command.Connection = connection;
                    command.CommandText = sql;

                    connection.Open();
                    command.ExecuteNonQuery();

                    int id = -1;

                    // Check if new identity is needed.
                    if (getId)
                    {
                        // Execute db specific autonumber or identity retrieval code
                        string identitySelect;
                        switch (dataProvider)
                        {
                            // Access
                            case "System.Data.OleDb":
                                identitySelect = "SELECT @@IDENTITY";
                                break;
                            // SQLite
                            case "System.Data.SQLite":
                                identitySelect = "SELECT LAST_INSERT_ROWID()";
                                break;
                            // Sql Server
                            case "System.Data.SqlClient":
                                identitySelect = "SELECT SCOPE_IDENTITY()";
                                break;
                            // Oracle
                            case "System.Data.OracleClient":
                                identitySelect = "SELECT MySequence.NEXTVAL FROM DUAL";
                                break;
                            default:
                                identitySelect = "SELECT LAST_INSERT_ROWID()";
                                break;
                        }
                        command.CommandText = identitySelect;
                        id = int.Parse(command.ExecuteScalar().ToString());
                    }
                    return id;
                }
            }
        }

        /// <summary>
        /// Executes Insert statements in the database.
        /// </summary>
        /// <param name="sql">Sql statement.</param>
        public static void Insert(string sql)
        {
            Insert(sql, false);
        }

        /// <summary>
        /// Populates a DataSet according to a Sql statement.
        /// </summary>
        /// <param name="sql">Sql statement.</param>
        /// <returns>Populated DataSet.</returns>
        public static DataSet GetDataSet(string sql)
        {
            using (DbConnection connection = factory.CreateConnection())
            {
                connection.ConnectionString = connectionString;

                using (DbCommand command = factory.CreateCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText = sql;

                    using (DbDataAdapter adapter = factory.CreateDataAdapter())
                    {
                        adapter.SelectCommand = command;

                        DataSet ds = new DataSet();
                        adapter.Fill(ds);

                        return ds;
                    }
                }
            }
        }

        /// <summary>
        /// Populates a DataTable according to a Sql statement.
        /// </summary>
        /// <param name="sql">Sql statement.</param>
        /// <returns>Populated DataTable.</returns>
        public static DataTable GetDataTable(string sql)
        {
            DataTable dt;

            try
            {
                dt = GetDataSet(sql).Tables[0];
            }
            catch (Exception ex)
            {
                dt = null;
            }

            return dt;
        }

        /// <summary>
        /// Populates a DataRow according to a Sql statement.
        /// </summary>
        /// <param name="sql">Sql statement.</param>
        /// <returns>Populated DataRow.</returns>
        public static DataRow GetDataRow(string sql)
        {
            DataRow row = null;

            DataTable dt = GetDataTable(sql);
            if (dt.Rows.Count > 0)
            {
                row = dt.Rows[0];
            }

            return row;
        }

        /// <summary>
        /// Executes a Sql statement and returns a scalar value.
        /// </summary>
        /// <param name="sql">Sql statement.</param>
        /// <returns>Scalar value.</returns>
        public static object GetScalar(string sql)
        {
            using (DbConnection connection = factory.CreateConnection())
            {
                connection.ConnectionString = connectionString;

                using (DbCommand command = factory.CreateCommand())
                {
                    command.Connection = connection;
                    command.CommandText = sql;

                    connection.Open();
                    return command.ExecuteScalar();
                }
            }
        }

        /// <summary>
        /// Escapes an input string for database processing, that is, 
        /// surround it with quotes and change any quote in the string to 
        /// two adjacent quotes (i.e. escape it). 
        /// If input string is null or empty a NULL string is returned.
        /// </summary>
        /// <param name="s">Input string.</param>
        /// <returns>Escaped output string.</returns>
        public static string Escape(string s)
        {
            if (String.IsNullOrEmpty(s))
                return "NULL";
            else
                return "'" + s.Trim().Replace("'", "''") + "'";
        }

        /// <summary>
        /// Escapes an input string for database processing, that is, 
        /// surround it with quotes and change any quote in the string to 
        /// two adjacent quotes (i.e. escape it). 
        /// Also trims string at a given maximum length.
        /// If input string is null or empty a NULL string is returned.
        /// </summary>
        /// <param name="s">Input string.</param>
        /// <param name="maxLength">Maximum length of output string.</param>
        /// <returns>Escaped output string.</returns>
        public static string Escape(string s, int maxLength)
        {
            if (String.IsNullOrEmpty(s))
                return "NULL";
            else
            {
                s = s.Trim();
                if (s.Length > maxLength) s = s.Substring(0, maxLength - 1);
                return "'" + s.Trim().Replace("'", "''") + "'";
            }
        }

        /*---------------------------------------------------------------------------------------------*/
        public static bool DatabaseHelperCanCreateTemporaryTables()
        {
            bool result = false;

            StringBuilder sqlCommand = new StringBuilder();
            sqlCommand.Append(
                @"SET ANSI_NULLS ON
                GO
                SET QUOTED_IDENTIFIER ON
                GO
                CREATE TABLE #Test 
                (
                  IndexID int IDENTITY (1, 1) NOT NULL,
                  UserName nvarchar(50),
                  LoginName nvarchar(50)
                )
                DROP TABLE #Test
                GO
                  
                ");

            try
            {
                DatabaseHelperRunScript(sqlCommand.ToString());
                result = true;
            }
            catch
            {
                result = false;
            }

            return result;
        }

        public static bool DatabaseHelperRunScript(FileInfo scriptFile)
        {
            if (scriptFile == null) return false;

            string script = File.ReadAllText(scriptFile.FullName);

            if ((script == null) || (script.Length == 0)) return true;

            return DatabaseHelperRunScript(script);

        }


        public static bool DatabaseHelperRunScript(String script)
        {
            bool result = false;

            using (DbConnection connection = factory.CreateConnection())
            {
                connection.ConnectionString = connectionString;


                string[] delimiter = new string[] { "GO\r\n" };

                //script = script.Replace("GO", "GO\r\n");

                string[] arrSqlStatements = script.Split(delimiter, StringSplitOptions.RemoveEmptyEntries);

                connection.Open();

                DbTransaction transaction = connection.BeginTransaction();
                string currentStatement = string.Empty;

                try
                {
                    foreach (String sqlStatement in arrSqlStatements)
                    {
                        if (sqlStatement.Trim().Length > 0)
                        {
                            currentStatement = sqlStatement;

                            DbCommand command = factory.CreateCommand();

                            command.Connection = connection;
                            command.Transaction = transaction;
                            command.CommandType = CommandType.Text;
                            command.CommandText = sqlStatement;
                            command.ExecuteNonQuery();
                        }
                    }


                    transaction.Commit();
                    result = true;

                }
                catch (SqlException ex)
                {
                    transaction.Rollback();
                    throw;
                }
                finally
                {
                    connection.Close();
                }
            }

            return result;
        }
    }
}
