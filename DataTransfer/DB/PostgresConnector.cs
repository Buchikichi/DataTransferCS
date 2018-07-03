using Npgsql;
using System.Data.Common;

namespace DataTransfer.DB
{
    public class PostgresConnector : DbConnector
    {
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

        #region Begin/End
        public PostgresConnector(ConnectionInfo info) : base(info) { }
        #endregion
    }
}
