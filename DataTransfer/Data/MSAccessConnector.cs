using System.Data.Common;
using System.Data.OleDb;

namespace DataTransfer.Data
{
    class MSAccessConnector : DbConnector<OleDbConnection>
    {
        private const string OLE_PROVIDER = "Microsoft.Ace.OLEDB.16.0";

        #region Methods
        protected override void ListColumns(EntityInfo entity)
        {
            var schema = entity.Schema.Name;
            var schemaTable = Connection.GetOleDbSchemaTable(OleDbSchemaGuid.Columns, new object[] { null, null, entity.Name, null });

            for (var rowNum = 0; rowNum < schemaTable.Rows.Count; rowNum++)
            {
                var row = schemaTable.Rows[rowNum];
                var items = schemaTable.Rows[rowNum].ItemArray;

                entity.Add(new AttributeInfo
                {
                    Name = row["COLUMN_NAME"].ToString(),
                });
            }
        }

        protected override void ListTables(SchemaInfo schema)
        {
            var schemaTable = Connection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });

            for (var rowNum = 0; rowNum < schemaTable.Rows.Count; rowNum++)
            {
                var row = schemaTable.Rows[rowNum];

                schema.Add(new EntityInfo
                {
                    Schema = schema,
                    Name = row["TABLE_NAME"].ToString(),
                    Comment = row["Description"].ToString(),
                });
            }
        }
        #endregion

        #region Begin/End
        protected override OleDbConnection CreateDbConnection()
        {
            var builder = new OleDbConnectionStringBuilder
            {
                DataSource = _info.Host,
                Provider = OLE_PROVIDER,
            };
            return new OleDbConnection(builder.ToString());
        }

        protected override DbCommand CreateDbCommand()
        {
            return new OleDbCommand { Connection = Connection };
        }

        public MSAccessConnector(ConnectionInfo info) : base(info) { }
        #endregion
    }
}
