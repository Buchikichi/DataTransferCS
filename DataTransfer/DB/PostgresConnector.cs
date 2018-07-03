using DataTransfer.Data;
using Npgsql;
using System.Data.Common;

namespace DataTransfer.DB
{
    public class PostgresConnector : DbConnector
    {
        public const string DEFAULT_SCHEMA = "public";

        #region Methods
        protected override SchemaInfo CreateSchemaInfo()
        {
            return new SchemaInfo { Name = DEFAULT_SCHEMA };
        }
        #endregion

        #region Begin/End
        protected override DbConnection CreateDbConnection()
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
            return new NpgsqlCommand { Connection = (NpgsqlConnection)Connection };
        }

        public PostgresConnector(ConnectionInfo info) : base(info) { }
        #endregion
    }
}
