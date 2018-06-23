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

        private static List<Dictionary<string, object>> SelectSource(DbCommand srcCmd, string tableName, List<Attribute> attrList)
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

        public static void Transfer(DbCommand dstCmd, Entity dstEntity, DbCommand srcCmd, Entity srcEntity)
        {
            var attrList = new List<Attribute>();

            foreach (var dstAttr in dstEntity)
            {
                var srcAttr = srcEntity.GetAttribute(dstAttr.Name);

                if (srcAttr != null)
                {
                    attrList.Add(srcAttr);
                }
            }
            var list = SelectSource(srcCmd, srcEntity.Name, attrList);

            foreach (var dict in list)
            {

            }
        }

        #region Information
        /// <summary>
        /// カラム一覧を取得.
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="tableName"></param>
        /// <param name="schema"></param>
        /// <returns></returns>
        private static List<Attribute> ListColumns(DbCommand cmd, string tableName, string schema = DEFAULT_SCHEMA)
        {
            var list = new List<Attribute>();
            var query = "SELECT * FROM information_schema.columns"
                + $" WHERE table_schema = '{schema}' AND table_name = '{tableName}'"
                + " ORDER BY table_name, ordinal_position";

            cmd.CommandText = query;
            using (var reader = cmd.ExecuteReader())
            {
                foreach (IDataRecord rec in reader)
                {
                    list.Add(new Attribute
                    {
                        Name = (string)rec["column_name"],
                    });
                }
            }
            return list;
        }

        /// <summary>
        /// テーブル一覧を取得.
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="schema"></param>
        /// <returns></returns>
        private static List<Entity> ListTables(DbCommand cmd, string schema = DEFAULT_SCHEMA)
        {
            var list = new List<Entity>();
            var query = "SELECT * FROM information_schema.tables"
                + $" WHERE table_schema = '{schema}' AND table_type='BASE TABLE'"
                + " ORDER BY table_name";

            cmd.CommandText = query;
            using (var reader = cmd.ExecuteReader())
            {
                foreach (IDataRecord rec in reader)
                {
                    list.Add(new Entity
                    {
                        Name = (string)rec["table_name"],
                    });
                }
            }
            return list;
        }

        public static Schema LoadSchema(DbCommand cmd)
        {
            var schema = new Schema();
            var entityList = ListTables(cmd);

            foreach (var entity in entityList)
            {
                var columnList = ListColumns(cmd, entity.Name);

                entity.AddRange(columnList);
                schema.Add(entity);
            }
            return schema;
        }
        #endregion

        private PgUtils() { }
    }
}
