using DataTransfer.Properties;
using Npgsql;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace DataTransfer
{
    public partial class MainForm : Form
    {
        #region Events
        private void TestSourceButton_Click(object sender, EventArgs e)
        {
            var host = Settings.Default.SourceHostName;
            var port = (int)Settings.Default.SourcePort;
            var catalog = Settings.Default.SourceSchema;
            var user = Settings.Default.SourceUser;
            var password = Settings.Default.SourcePassword;
            var connString = $"Server={host};Port={port};Database={catalog};User Id={user};Password={password};SSL Mode=Require;Trust Server Certificate=true";

            using (var con = new NpgsqlConnection(connString))
            {
                con.Open();
            }
            Debug.Print("connected.");
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
