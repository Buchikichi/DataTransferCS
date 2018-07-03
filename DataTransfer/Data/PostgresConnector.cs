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
