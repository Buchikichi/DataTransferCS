using System.Data;
using System.Data.Common;

namespace DataTransfer.Data
{
    abstract class DbConnector<T> : IDbConnector where T : DbConnection
    {
        #region Methods
        protected virtual SchemaInfo CreateSchemaInfo()
        {
            return new SchemaInfo();
        }

        protected virtual string BuildColumnListQuery(EntityInfo entity)
        {
            var schema = entity.Schema.Name;
            var tableName = entity.Name;

            return "SELECT *, '' as description FROM information_schema.columns"
                + $" WHERE table_schema = '{schema}' AND table_name = '{tableName}'"
                + " ORDER BY table_name, ordinal_position";
        }

        /// <summary>
        /// カラム一覧を取得.
        /// </summary>
        /// <param name="entity">エンティティ情報</param>
        protected virtual void ListColumns(EntityInfo entity)
        {
            Command.CommandText = BuildColumnListQuery(entity);
            using (var reader = Command.ExecuteReader())
            {
                foreach (IDataRecord rec in reader)
                {
                    var nullable = rec["is_nullable"].ToString().ToUpper();

                    entity.Add(new AttributeInfo
                    {
                        Name = rec["column_name"].ToString(),
                        Type = rec["udt_name"].ToString(),
                        Size = rec["character_maximum_length"].ToString(),
                        NotNull = "NO" == nullable,
                        DefaultValue = rec["column_default"].ToString(),
                        Description = rec["description"].ToString(),
                    });
                }
            }
        }

        protected virtual string BuildTableListQuery(SchemaInfo schema)
        {
            return "SELECT table_name, '' as description FROM information_schema.tables"
                + $" WHERE table_schema = '{schema.Name}' AND table_type='BASE TABLE'"
                + " ORDER BY table_name";
        }

        /// <summary>
        /// テーブル一覧を取得
        /// </summary>
        /// <param name="schema">スキーマ情報</param>
        protected virtual void ListTables(SchemaInfo schema)
        {
            Command.CommandText = BuildTableListQuery(schema);
            using (var reader = Command.ExecuteReader())
            {
                foreach (IDataRecord rec in reader)
                {
                    schema.Add(new EntityInfo
                    {
                        Schema = schema,
                        Name = (string)rec["table_name"],
                        Description = (string)rec["description"],
                    });
                }
            }
        }

        public SchemaInfo LoadSchema()
        {
            var schema = CreateSchemaInfo();

            ListTables(schema);
            foreach (var entity in schema)
            {
                ListColumns(entity);
            }
            return schema;
        }
        #endregion

        #region Begin/End
        protected abstract T CreateDbConnection();

        protected abstract DbCommand CreateDbCommand();

        public void Dispose()
        {
            Connection.Dispose();
        }

        public DbConnector(ConnectionInfo info)
        {
            _info = info;
            Connection = CreateDbConnection();
            Command = CreateDbCommand();
            Connection.Open();
        }
        #endregion

        #region Attributes
        protected readonly ConnectionInfo _info;
        protected T Connection { get; set; }
        public DbCommand Command { get; set; }
        #endregion
    }
}
