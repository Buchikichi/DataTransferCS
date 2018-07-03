using System;
using System.Data.Common;

namespace DataTransfer.DB
{
    public abstract class DbConnector : IDisposable
    {
        #region Begin/End
        protected abstract DbConnection CreateDbConnection();

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
        protected DbConnection Connection { get; set; }
        public DbCommand Command { get; set; }
        #endregion
    }
}
