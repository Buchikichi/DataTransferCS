namespace DataTransfer.DB
{
    class DbConnectorFactory
    {
        public static DbConnector Create(ConnectionInfo info)
        {
            var type = info.Type;

            if (type == ConnectionType.MSAccess)
            {

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
