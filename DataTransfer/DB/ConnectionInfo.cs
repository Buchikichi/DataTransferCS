namespace DataTransfer.DB
{
    public class ConnectionInfo
    {
        public ConnectionType Type { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
        public string Schema { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool Tls { get; set; }
    }
}
