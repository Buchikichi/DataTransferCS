namespace DataTransfer.DB
{
    class DbConnectorFactory
    {
        public static DbConnector Create(ConnectionInfo info)
        {
            var type = info.Type;

            if (type == ConnectionType.MSAccess)
            {
                return new MSAccessConnector(info);
            }
            if (type == ConnectionType.PostgreSQL)
            {
                return new PostgresConnector(info);
            }
            return null;
        }

        private DbConnectorFactory() { }
    }
}
