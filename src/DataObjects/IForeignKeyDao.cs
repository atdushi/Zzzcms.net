using System.Collections.Generic;
using BusinessObjects.Table;

namespace DataObjects
{
    public interface IForeignKeyDao
    {
        /// <summary>
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns>foreign key list</returns>
        List<ForeignKey> GetForeignKeyList(string tableName);

        /// <summary>
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns>list of foreign key column names</returns>
        List<string> GetForeignKeyColumnNameList(string tableName);

        /// <summary>
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="columnName"></param>
        /// <returns>foreign key</returns>
        ForeignKey GetForeignKey(string tableName, string columnName);

        /// <summary>
        /// </summary>
        /// <param name="col">column to validate</param>
        /// <returns>true if column is foreign key</returns>
        bool IsForeignKey(Column col);
    }
}
