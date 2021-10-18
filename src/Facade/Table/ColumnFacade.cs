using System.Collections.Generic;
using DataObjects;
using BusinessObjects.Table;
using Framework.Transactions;

namespace Facade.Table
{
    public class ColumnFacade
    {
        private readonly IColumnDao _columnDao = DataAccess.ColumnDao;

        public List<Column> GetColumnList(string tableName)
        {
            List<Column> colList;

            using (var transaction = new TransactionDecorator())
            {
                colList = _columnDao.GetColumnList(tableName);
                transaction.Complete();
            }

            return colList;
        }

        public List<string> GetFilePathColumnNameList(string tableName)
        {
            List<string> colList;

            using (var transaction = new TransactionDecorator())
            {
                colList = _columnDao.GetFilePathColumnNameList(tableName);
                transaction.Complete();
            }

            return colList;
        }

        public object GetCellValue(Column col, string rowId)
        {
            object res;

            using (var transaction = new TransactionDecorator())
            {
                res = _columnDao.GetCellValue(col, rowId);
                transaction.Complete();
            }

            return res;
        }

        public bool IsFilePath(Column col)
        {
            return _columnDao.IsFilePath(col);
        }
    }
}
