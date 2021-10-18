using System.Collections.Generic;
using DataObjects;
using System.Data;
using Framework.Transactions;

namespace Facade.Table
{
    public class TableFacade
    {
        private readonly ITableDao _tableDao = DataAccess.TableDao;

        public List<string> GetUserTableList()
        {
            List<string> resList;

            using (var transaction = new TransactionDecorator())
            {
                resList = _tableDao.GetUserTableList();
                transaction.Complete();
            }

            return resList;
        }

        public List<string> GetSystemTableList()
        {
            List<string> resList;

            using (var transaction = new TransactionDecorator())
            {
                resList = _tableDao.GetSystemTableList();
                transaction.Complete();
            }

            return resList;
        }

        public DataTable GetTableData(string tableName)
        {
            DataTable dt;

            using (var transaction = new TransactionDecorator())
            {
                dt = _tableDao.GetTableData(tableName);
                transaction.Complete();
            }

            return dt;
        }

        public bool DeleteRow(string tableName, string rowId)
        {
            var wasDeleted = false;

            using (var transaction = new TransactionDecorator())
            {
                wasDeleted = _tableDao.DeleteRow(tableName, rowId);
                transaction.Complete();
            }

            return wasDeleted;
        }

        public void AddFilePathColumn(string tableName, string columnName)
        {
            using (var transaction = new TransactionDecorator())
            {
                _tableDao.AddFilePathColumn(tableName, columnName);
                transaction.Complete();
            }
        }

        public int GetMaxId(string tableName)
        {
            var maxId = -1;

            using (var transaction = new TransactionDecorator())
            {
                maxId = _tableDao.GetMaxID(tableName);
                transaction.Complete();
            }


            return maxId;
        }

        public void ExecuteUpdate(string sql)
        {
            _tableDao.ExecuteUpdate(sql);
        }

        public int ExecuteInsert(string sql, bool getId)
        {
            return _tableDao.ExecuteInsert(sql, getId);
        }
    }
}
