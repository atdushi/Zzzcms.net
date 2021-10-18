using System;
using System.IO;

namespace Facade
{
    public sealed class DatabaseHelper
    {
        public static bool DatabaseHelperCanCreateTemporaryTables()
        {
            return DataObjects.Db.DatabaseHelperCanCreateTemporaryTables();
        }

        public static bool DatabaseHelperRunScript(FileInfo scriptFile)
        {
            return DataObjects.Db.DatabaseHelperRunScript(scriptFile);
        }

        public static bool DatabaseHelperRunScript(String script)
        {
            return DataObjects.Db.DatabaseHelperRunScript(script);
        }
    }
}
