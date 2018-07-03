using DataTransfer.Data;
using DataTransfer.IO;
using DataTransfer.Properties;
using DataTransfer.Util;
using System;
using System.Diagnostics;
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
            using (var srcDb = DbConnectorFactory.Create(SourceConnectionInfo))
            using (var dstDb = DbConnectorFactory.Create(SourceConnectionInfo))
            {
                SetStatusLabel("Connected");
                var srcSchema = srcDb.LoadSchema();
                var dstSchema = dstDb.LoadSchema();

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
                    PgUtils.Transfer(dstDb.Command, dstEntity, srcDb.Command, srcEntity);
                }
            }
            SetStatusLabel("Done.");
        }

        private void TransferButton_Click(object sender, EventArgs e)
        {
            Transfer();
        }
        #endregion

        #region DDL
        private void SaveDDL(ConnectionInfo info)
        {
            SetStatusLabel("Connecting...");
            try
            {
                using (var db = DbConnectorFactory.Create(info))
                {
                    var schema = db.LoadSchema();
                    var writer = new DDLWriter();

                    writer.Save(Settings.Default.WorkingDirectory, schema);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            SetStatusLabel("Success.");
        }

        private void SourceDdlButton_Click(object sender, EventArgs e)
        {
            SaveDDL(SourceConnectionInfo);
        }

        private void DestinationDdlButton_Click(object sender, EventArgs e)
        {
            SaveDDL(DestinationConnectionInfo);
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
                    var schema = db.LoadSchema();

                    foreach (var entity in schema)
                    {
                        Debug.Print(entity.Name + ":" + entity.Comment);
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        #endregion
    }
}
