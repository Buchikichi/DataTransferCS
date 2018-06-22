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

        private void TestSourceButton_Click(object sender, EventArgs e)
        {
            SetStatusLabel("Connect:" + SourceHostTextBox.Text);
            using (var srcConn = new NpgsqlConnection(SourceConnectionString))
            {
                srcConn.Open();
                SetStatusLabel("Connected:" + SourceHostTextBox.Text);

                var srcTables = PgUtils.ListTables(srcConn);

                foreach (var name in srcTables)
                {
                    Debug.Print("name:" + name);
                }
            }
            SetStatusLabel("Done.");
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
        #endregion
    }
}
