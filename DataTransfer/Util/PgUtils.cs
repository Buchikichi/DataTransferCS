using DataTransfer.Data;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;

namespace DataTransfer.Util
{
    class PgUtils
    {
        private const string DEFAULT_SCHEMA = "public";

        private static List<Dictionary<string, object>> SelectSource(DbCommand srcCmd, string tableName, List<AttributeInfo> attrList)
        {
            var list = new List<Dictionary<string, object>>();
            var columnList = attrList.Select(attr => attr.Name);
            var columns = string.Join(",", columnList);

            srcCmd.CommandText = $"SELECT {columns} FROM {tableName}";
            using (var reader = srcCmd.ExecuteReader())
            {
                foreach (IDataRecord rec in reader)
                {
                    var dict = new Dictionary<string, object>();

                    foreach (var column in columnList)
                    {
                        var value = rec[column];

                        dict.Add(column, value);
                    }
                    list.Add(dict);
                }
            }
            return list;
        }

        private static string BuildValues(Dictionary<string, object> dict)
        {
            var list = new List<string>();

            foreach (var key in dict.Keys)
            {
                var value = dict[key];

                if (value is int i)
                {
                    list.Add(i.ToString());
                }
                else
                {
                    list.Add($"'{value}'");
                }
            }
            return string.Join(",", list);
        }

        private static bool Insert(DbCommand cmd, EntityInfo entity, Dictionary<string, object> dict)
        {
            var table = entity.Name;
            var columns = string.Join(",", dict.Keys);
            var values = BuildValues(dict);
            var query = $"INSERT INTO {table}({columns}) values({values})";

            cmd.CommandText = query;
            if (cmd.ExecuteNonQuery() <= 0)
            {
                return false;
            }
            return true;
        }

        public static void Transfer(DbCommand dstCmd, EntityInfo dstEntity, DbCommand srcCmd, EntityInfo srcEntity)
        {
            var attrList = new List<AttributeInfo>();

            foreach (var dstAttr in dstEntity)
            {
                var srcAttr = srcEntity.GetAttribute(dstAttr.Name);

                if (srcAttr != null)
                {
                    attrList.Add(srcAttr);
                }
            }
            var list = SelectSource(srcCmd, srcEntity.Name, attrList);

            if (list.Count == 0)
            {
                return;
            }
            foreach (var dict in list)
            {
                Insert(dstCmd, dstEntity, dict);
            }
        }

        private PgUtils() { }
    }
}
