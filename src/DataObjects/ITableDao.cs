using System.Collections.Generic;
using System.Data;

namespace DataObjects
{
    public interface ITableDao
    {
        /// <summary>
        /// Gets user table names.
        /// </summary>
        /// <returns></returns>
        List<string> GetUserTableList();

        /// <summary>
        /// Gets table names started with "zzz".
        /// </summary>
        /// <returns></returns>
        List<string> GetSystemTableList();

        /// <summary>
        /// Low level select operation.
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns>table data</returns>
        DataTable GetTableData(string tableName);

        /// <summary>
        /// Deletes row.
        /// </summary>
        /// <param name="tableName">table to delete from</param>
        /// <param name="rowId">row Id to delete</param>
        /// <returns></returns>
        bool DeleteRow(string tableName, string rowId);

        /// <summary>
        /// Executes Update statements in the database.
        /// </summary>
        /// <param name="sql"></param>
        void ExecuteUpdate(string sql);

        /// <summary>
        /// Executes Insert statements in the database.
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="getId"></param>
        /// <returns></returns>
        int ExecuteInsert(string sql, bool getId);

        /// <summary>
        /// Adds column contains file path.
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="columnName"></param>
        void AddFilePathColumn(string tableName, string columnName);

        /// <summary>
        /// Gets max(Id).
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns>max(Id)</returns>
        int GetMaxID(string tableName);
    }
}
