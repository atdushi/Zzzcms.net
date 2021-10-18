using System.Collections.Generic;
using BusinessObjects.Table;
using System.Data;

namespace DataObjects
{
    public interface IMany2ManyLinkDao
    {
        /// <summary>
        /// Returns many to many link list from zzz_RelationsIDs.
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        List<Many2ManyLink> GetMany2ManyLinkList(string tableName);

        /// <summary>
        /// If table has at least one record in zzz_RelationsIDs.
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        bool HasMany2ManyLink(string tableName);
        
        /// <summary>
        /// Create record in zzz_RelationsIDS
        /// </summary>
        /// <param name="tableName1"></param>
        /// <param name="tableName2"></param>
        /// <returns></returns>
        int CreateMany2ManyLink(string tableName1, string tableName2);

        /// <summary>
        /// Gets string of linked item "Id"s separated by commas.
        /// </summary>
        /// <param name="mk"></param>
        /// <param name="itemId"></param>
        /// <returns></returns>
        string GetMany2ManyFilter(Many2ManyLink mk, string itemId);

        /// <summary>
        /// Gets linked table data.
        /// </summary>
        /// <param name="mk">link</param>
        /// <param name="itemId">item id</param>
        /// <param name="filter">many to many filter</param>
        /// <returns>linked table data</returns>
        DataTable GetLinkedTableData(Many2ManyLink mk, string itemId, string filter);

        /// <summary>
        /// Adds record to zzz_Relations
        /// </summary>
        /// <param name="relation"></param>
        void AddRelation(Many2ManyRelation relation);

        /// <summary>
        /// Deletes record from zzz_Relations
        /// </summary>
        /// <param name="relation"></param>
        void DeleteRelation(Many2ManyRelation relation);
    }
}
