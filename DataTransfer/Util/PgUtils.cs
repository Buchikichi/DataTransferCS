using Npgsql;
using System.Collections.Generic;
using System.Data;

namespace DataTransfer.Util
{
    class PgUtils
    {
        public static List<string> ListTables(NpgsqlConnection conn)
        {
            var list = new List<string>();
            var query = "SELECT * FROM pg_tables WHERE tableowner = CURRENT_USER";
            var cmd = new NpgsqlCommand(query, conn);

            foreach (IDataRecord row in cmd.ExecuteReader())
            {
                var name = row[1];

                list.Add((string)row[1]);
            }
            return list;
        }

        private PgUtils() { }
    }
}
