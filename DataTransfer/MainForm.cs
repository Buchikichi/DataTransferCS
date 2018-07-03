using DataTransfer.DB;
using DataTransfer.Properties;
using DataTransfer.Util;
using Npgsql;
using System;
using System.Data.OleDb;
using System.Diagnostics;
using System.Windows.Forms;

namespace DataTransfer
{
    public partial class MainForm : Form
    {
        #region Transfer
        private void Transfer()
        {
            var cn = new OleDbConnection();
            var comm = new OleDbCommand();

            PgUtils.LoadSchema(comm);
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

        private bool TestConnection(ConnectionInfo info)
        {
            try
            {
                using (var db = DbConnectorFactory.Create(info))
                {
                    var schema = PgUtils.LoadSchema(db.Command);

                    Debug.Print(SourceConnectionInfo.Type.ToString());
                    foreach (var entity in schema)
                    {
                        Debug.Print(entity.Name);
                    }
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
            if (!TestConnection(SourceConnectionInfo))
            {
                SetStatusLabel("Failed.");
                return;
            }
            SetStatusLabel("Success.");
        }

        private void TestDestinationButton_Click(object sender, EventArgs e)
        {
            SetStatusLabel("Connecting...");
            if (!TestConnection(DestinationConnectionInfo))
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
            ConnectionTypeUtil.SetupComboBox(SourceTypeComboBox);
            ConnectionTypeUtil.SetupComboBox(DestinationTypeComboBox);
            FormClosing += (sender, e) => Settings.Default.Save();
        }

        public MainForm()
        {
            InitializeComponent();
            Load += (sender, e) => Initialize();
        }
        #endregion

        #region Attributes
        private ConnectionInfo SourceConnectionInfo
        {
            get
            {
                return new ConnectionInfo
                {
                    Type = (ConnectionType)SourceTypeComboBox.SelectedItem,
                    Host = Settings.Default.SourceHostName,
                    Port = (int)Settings.Default.SourcePort,
                    Schema = Settings.Default.SourceSchema,
                    Username = Settings.Default.SourceUser,
                    Password = Settings.Default.SourcePassword,
                    Tls = SourceTlsCheckBox.Checked,
                };
            }
        }

        private ConnectionInfo DestinationConnectionInfo
        {
            get
            {
                return new ConnectionInfo
                {
                    Type = (ConnectionType)DestinationTypeComboBox.SelectedItem,
                    Host = Settings.Default.DestinationHostName,
                    Port = (int)Settings.Default.DestinationPort,
                    Schema = Settings.Default.DestinationSchema,
                    Username = Settings.Default.DestinationUser,
                    Password = Settings.Default.DestinationPassword,
                    Tls = DestinationTlsCheckBox.Checked,
                };
            }
        }

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
