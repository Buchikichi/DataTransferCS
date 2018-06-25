using DataTransfer.Properties;
using DataTransfer.Util;
using Npgsql;
using System;
using System.Windows.Forms;

namespace DataTransfer
{
    public partial class MainForm : Form
    {
        #region Transfer
        private void Transfer()
        {
            SetStatusLabel("Connecting");
            ProgressBar.Value = 0;
            using (var srcConn = new NpgsqlConnection(SourceConnectionString))
            using (var srcCmd = new NpgsqlCommand { Connection = srcConn })
            using (var dstConn = new NpgsqlConnection(DestinationConnectionString))
            using (var dstCmd = new NpgsqlCommand { Connection = dstConn })
            {
                srcConn.Open();
                dstConn.Open();
                SetStatusLabel("Connected");
                var srcSchema = PgUtils.LoadSchema(srcCmd);
                var dstSchema = PgUtils.LoadSchema(dstCmd);

                ProgressBar.Maximum = dstSchema.NumOfEntity;
                foreach (var dstEntity in dstSchema)
                {
                    var srcEntity = srcSchema.GetEntity(dstEntity.Name);

                    ProgressBar.Value++;
                    if (srcEntity == null)
                    {
                        continue;
                    }
                    SetStatusLabel($"Transfer[{dstEntity.Name}]");
                    PgUtils.Transfer(dstCmd, dstEntity, srcCmd, srcEntity);
                }
            }
            SetStatusLabel("Done.");
        }

        private void TransferButton_Click(object sender, EventArgs e)
        {
            Transfer();
        }
        #endregion

        #region Events
        private void SetStatusLabel(string text)
        {
            StatusLabel.Text = text;
            StatusBar.Refresh();
        }

        private bool TestConnection(string connectionString)
        {
            try
            {
                using (var conn = new NpgsqlConnection(connectionString))
                using (var cmd = new NpgsqlCommand { Connection = conn })
                {
                    conn.Open();
                }
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        private void TestSourceButton_Click(object sender, EventArgs e)
        {
            SetStatusLabel("Connecting...");
            if (!TestConnection(SourceConnectionString))
            {
                SetStatusLabel("Failed.");
                return;
            }
            SetStatusLabel("Success.");
        }

        private void TestDestinationButton_Click(object sender, EventArgs e)
        {
            SetStatusLabel("Connecting...");
            if (!TestConnection(DestinationConnectionString))
            {
                SetStatusLabel("Failed.");
                return;
            }
            SetStatusLabel("Success.");
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
