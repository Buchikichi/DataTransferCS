using Npgsql;
using System.Data.Common;

namespace DataTransfer.Data
{
    class PostgresConnector : DbConnector<NpgsqlConnection>
    {
        public const string DEFAULT_SCHEMA = "public";

        #region Methods
        protected override SchemaInfo CreateSchemaInfo()
        {
            return new SchemaInfo { Name = DEFAULT_SCHEMA };
        }

        protected override string BuildTableListQuery(SchemaInfo schema)
        {
            return $@"
SELECT
  table_name,
  COALESCE(DSC.description, '') as description
FROM
  information_schema.tables TAB
INNER JOIN pg_class PGC ON
  TAB.table_name = PGC.relname
LEFT JOIN pg_description DSC ON
  PGC.oid = DSC.objoid
  AND DSC.objsubid = 0
WHERE
  table_schema = '{schema.Name}'
  AND table_type='BASE TABLE'
";
        }
        #endregion

        #region Begin/End
        protected override NpgsqlConnection CreateDbConnection()
        {
            var builder = new NpgsqlConnectionStringBuilder
            {
                Host = _info.Host,
                Port = _info.Port,
                Database = _info.Schema,
                Username = _info.Username,
                Password = _info.Password,
            };
            if (_info.Tls)
            {
                builder.SslMode = SslMode.Require;
                builder.TrustServerCertificate = true;
            }
            return new NpgsqlConnection(builder.ToString());
        }

        protected override DbCommand CreateDbCommand()
        {
            return new NpgsqlCommand { Connection = Connection };
        }

        public PostgresConnector(ConnectionInfo info) : base(info) { }
        #endregion
    }
}
