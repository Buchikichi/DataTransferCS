using DataTransfer.Properties;
using DataTransfer.Util;
using Npgsql;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace DataTransfer
{
    public partial class MainForm : Form
    {
        #region Events
        private void SetStatusLabel(string text)
        {
            StatusLabel.Text = text;
            StatusBar.Invalidate();
        }

        private bool TestConnection(string connectionString)
        {
            SetStatusLabel("Connecting");
            using (var srcConn = new NpgsqlConnection(connectionString))
            {
                srcConn.Open();
                SetStatusLabel("Connected");

                var srcTables = PgUtils.ListTables(srcConn);

                foreach (var name in srcTables)
                {
                    Debug.Print("name:" + name);
                }
            }
            SetStatusLabel("Done.");
            return true;
        }

        private void TestSourceButton_Click(object sender, EventArgs e)
        {
            TestConnection(SourceConnectionString);
        }

        private void TestDestinationButton_Click(object sender, EventArgs e)
        {
            TestConnection(DestinationConnectionString);
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

        #region Attributes
        private string SourceConnectionString
        {
            get
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
                return builder.ToString();
            }
        }

        private string DestinationConnectionString
        {
            get
            {
                var builder = new NpgsqlConnectionStringBuilder
                {
                    Host = Settings.Default.DestinationHostName,
                    Port = (int)Settings.Default.DestinationPort,
                    Database = Settings.Default.DestinationSchema,
                    Username = Settings.Default.DestinationUser,
                    Password = Settings.Default.DestinationPassword,
                };
                if (DestinationTlsCheckBox.Checked)
                {
                    builder.SslMode = SslMode.Require;
                    builder.TrustServerCertificate = true;
                }
                return builder.ToString();
            }
        }
        #endregion
    }
}
