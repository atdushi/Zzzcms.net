namespace DataObjects
{
    public class DaoFactories
    {
        /// <summary>
        /// Gets a provider specific factory 
        /// </summary>
        /// <param name="dataProvider">Database provider.</param>
        /// <returns>Data access object factory.</returns>
        public static DaoFactory GetFactory(string dataProvider)
        {
            switch (dataProvider)
            {
                case "System.Data.SqlClient": return new SqlServer.SqlServerDaoFactory();
                case "System.Data.SQLite": return new SQLite.SqLiteDaoFactory();
                default: return new SqlServer.SqlServerDaoFactory();
            }
        }
    }
}
