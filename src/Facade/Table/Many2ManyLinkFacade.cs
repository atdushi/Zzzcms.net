using System;
using System.Collections.Generic;
using DataObjects;
using BusinessObjects.Table;
using Framework.Transactions;
using System.Data;
using Framework.Log;

namespace Facade.Table
{
    public class Many2ManyLinkFacade
    {
        private readonly IMany2ManyLinkDao _m2mDao = DataAccess.Many2ManyLinkDao;

        public List<Many2ManyLink> GetMany2ManyLinkList(string tableName)
        {
            List<Many2ManyLink> m2mList;

            using (var transaction = new TransactionDecorator())
            {
                m2mList = _m2mDao.GetMany2ManyLinkList(tableName);
                transaction.Complete();
            }

            return m2mList;
        }

        public bool HasMany2ManyLink(string tableName)
        {
            return _m2mDao.HasMany2ManyLink(tableName);
        }

        public int CreateMany2ManyLink(string tableName1, string tableName2)
        {
            var linkId = -1;

            using (var transaction = new TransactionDecorator())
            {
                linkId = _m2mDao.CreateMany2ManyLink(tableName1, tableName2);
                transaction.Complete();
            }

            return linkId;
        }

        public string GetMany2ManyFilter(Many2ManyLink mk, string itemId)
        {
            string filter;

            using (var transaction = new TransactionDecorator())
            {
                filter = _m2mDao.GetMany2ManyFilter(mk, itemId);
                transaction.Complete();
            }

            return filter;
        }

        public DataTable GetLinkedTableData(Many2ManyLink mk)
        {
            return GetLinkedTableData(mk, string.Empty);
        }

        public DataTable GetLinkedTableData(Many2ManyLink mk, string itemId)
        {
            DataTable dt;
            string filter;

            using (var transaction = new TransactionDecorator())
            {
                filter = GetMany2ManyFilter(mk, itemId);
                transaction.Complete();
            }

            using (var transaction = new TransactionDecorator())
            {
                dt = _m2mDao.GetLinkedTableData(mk, itemId, filter);
                transaction.Complete();
            }

            return dt ?? new DataTable();
        }

        public void AddRelation(Many2ManyRelation relation)
        {
            using (var transaction = new TransactionDecorator())
            {
                try
                {
                    _m2mDao.AddRelation(relation);
                }
                catch (Exception ex)
                {
                    Logger.WriteToLog(ToString() + ": " + ex.Message, Severity.Debug);
                }
                transaction.Complete();
            }
        }

        public void DeleteRelation(Many2ManyRelation relation)
        {
            using (var transaction = new TransactionDecorator())
            {
                _m2mDao.DeleteRelation(relation);
                transaction.Complete();
            }
        }
    }
}
