using System.Collections.Generic;
using BusinessObjects.Table;
using DataObjects;
using Framework.Transactions;

namespace Facade.Table
{
    public class ForeignKeyFacade
    {
        private readonly IForeignKeyDao _fkDao = DataAccess.ForeignKeyDao;

        public List<ForeignKey> GetForeignKeyList(string tableName)
        {
            List<ForeignKey> fkList;

            using (var transaction = new TransactionDecorator())
            {
                fkList = _fkDao.GetForeignKeyList(tableName);
                transaction.Complete();
            }

            return fkList;
        }

        public List<string> GetForeignKeyColumnNameList(string tableName)
        {
            List<string> fkList;

            using (var transaction = new TransactionDecorator())
            {
                fkList = _fkDao.GetForeignKeyColumnNameList(tableName);
                transaction.Complete();
            }

            return fkList;
        }

        public ForeignKey GetForeignKey(string tableName, string columnName)
        {
            return _fkDao.GetForeignKey(tableName, columnName);
        }

        public bool IsForeignKey(Column col)
        {
            return _fkDao.IsForeignKey(col);
        }
    }
}
