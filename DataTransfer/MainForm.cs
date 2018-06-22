using DataTransfer.Properties;
using Npgsql;
using System;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;

namespace DataTransfer
{
    public partial class MainForm : Form
    {
        #region Events
        private void TestSourceButton_Click(object sender, EventArgs e)
        {
            var builder = new NpgsqlConnectionStringBuilder
            {
                Host = Settings.Default.SourceHostName,
                Port = (int)Settings.Default.SourcePort,
                Database = Settings.Default.SourceSchema,
                Username = Settings.Default.SourceUser,
                Password = Settings.Default.SourcePassword,
            };
            if (SourceTlsCheckBox.Checked)
            {
                builder.SslMode = SslMode.Require;
                builder.TrustServerCertificate = true;
            }
            var query = "SELECT * FROM pg_tables WHERE tableowner = CURRENT_USER";

            using (var con = new NpgsqlConnection(builder.ToString()))
            {
                con.Open();
                Debug.Print("connected.");

                var cmd = new NpgsqlCommand(query, con);
                var dataReader = cmd.ExecuteReader();

                foreach (IDataRecord row in dataReader)
                {
                    var name = row[1];

                    Debug.Print("name:" + name);
                }
            }
        }
        #endregion

        #region Begin/End
        private void Initialize()
        {
            FormClosing += (sender, e) => Settings.Default.Save();
        }

        public MainForm()
        {
            InitializeComponent();
            Initialize();
        }
        #endregion
    }
}
