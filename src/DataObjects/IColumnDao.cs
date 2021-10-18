using System.Collections.Generic;
using BusinessObjects.Table;

namespace DataObjects
{
    public interface IColumnDao
    {
        /// <summary>
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns>column list</returns>
        List<Column> GetColumnList(string tableName);

        /// <summary>
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns>file path column name list</returns>
        List<string> GetFilePathColumnNameList(string tableName);

        /// <summary>
        /// </summary>
        /// <param name="col"></param>
        /// <param name="rowId"></param>
        /// <returns>cell value</returns>
        object GetCellValue(Column col, string rowId);

        /// <summary>
        /// </summary>
        /// <param name="col"></param>
        /// <param name="image"></param>
        void SaveImage(Column col, byte[] image);

        /// <summary>
        /// </summary>
        /// <param name="col">column to validate</param>
        /// <returns>true if column is for file path</returns>
        bool IsFilePath(Column col);
    }
}
