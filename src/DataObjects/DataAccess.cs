using System.Configuration;

namespace DataObjects
{
    /// <summary>
    /// This class shields the client from the details of database specific 
    /// data-access objects. It returns the appropriate data-access objects 
    /// according to the configuration in web.config.
    /// </summary>
    public static class DataAccess
    {
        // The static field initializers below are thread safe.
        private static readonly string dataProvider = ConfigurationManager.AppSettings.Get("DataProvider");
        private static readonly DaoFactory factory = DaoFactories.GetFactory(dataProvider);

        /// <summary>
        /// Gets a provider specific column data access object.
        /// </summary>
        public static IColumnDao ColumnDao
        {
            get { return factory.ColumnDao; }
        }

        /// <summary>
        /// Gets a provider specific foreign key data access object.
        /// </summary>
        public static IForeignKeyDao ForeignKeyDao
        {
            get { return factory.ForeignKeyDao; }
        }

        /// <summary>
        /// Gets a provider specific many to many data access object.
        /// </summary>
        public static IMany2ManyLinkDao Many2ManyLinkDao
        {
            get { return factory.Many2ManyLinkDao; }
        }

        /// <summary>
        /// Gets a provider specific table data access object.
        /// </summary>
        public static ITableDao TableDao
        {
            get { return factory.TableDao; }
        }
    }
}
