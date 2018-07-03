namespace DataTransfer
{
    partial class MainForm
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.StatusBar = new System.Windows.Forms.StatusStrip();
            this.StatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.ProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.sourceGroupBox = new System.Windows.Forms.GroupBox();
            this.SourceTypeComboBox = new System.Windows.Forms.ComboBox();
            this.SourceSchemaTextBox = new System.Windows.Forms.TextBox();
            this.SourceTlsCheckBox = new System.Windows.Forms.CheckBox();
            this.SourcePasswordTextBox = new System.Windows.Forms.TextBox();
            this.SourceUserTextBox = new System.Windows.Forms.TextBox();
            this.TestSourceButton = new System.Windows.Forms.Button();
            this.SourcePort = new System.Windows.Forms.NumericUpDown();
            this.SourceHostTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.DestinationGroupBox = new System.Windows.Forms.GroupBox();
            this.TestDestinationButton = new System.Windows.Forms.Button();
            this.DestinationSchemaTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.DestinationTlsCheckBox = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.DestinationPasswordTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.DestinationUserTextBox = new System.Windows.Forms.TextBox();
            this.DestinationHostTextBox = new System.Windows.Forms.TextBox();
            this.DestinationPort = new System.Windows.Forms.NumericUpDown();
            this.TransferButton = new System.Windows.Forms.Button();
            this.DestinationTypeComboBox = new System.Windows.Forms.ComboBox();
            this.StatusBar.SuspendLayout();
            this.sourceGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SourcePort)).BeginInit();
            this.DestinationGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DestinationPort)).BeginInit();
            this.SuspendLayout();
            // 
            // StatusBar
            // 
            this.StatusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusLabel,
            this.toolStripStatusLabel1,
            this.ProgressBar});
            this.StatusBar.Location = new System.Drawing.Point(0, 539);
            this.StatusBar.Name = "StatusBar";
            this.StatusBar.Size = new System.Drawing.Size(784, 22);
            this.StatusBar.TabIndex = 0;
            this.StatusBar.Text = "statusStrip1";
            // 
            // StatusLabel
            // 
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(667, 17);
            this.toolStripStatusLabel1.Spring = true;
            // 
            // ProgressBar
            // 
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.Size = new System.Drawing.Size(100, 16);
            // 
            // sourceGroupBox
            // 
            this.sourceGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sourceGroupBox.Controls.Add(this.SourceTypeComboBox);
            this.sourceGroupBox.Controls.Add(this.SourceSchemaTextBox);
            this.sourceGroupBox.Controls.Add(this.SourceTlsCheckBox);
            this.sourceGroupBox.Controls.Add(this.SourcePasswordTextBox);
            this.sourceGroupBox.Controls.Add(this.SourceUserTextBox);
            this.sourceGroupBox.Controls.Add(this.TestSourceButton);
            this.sourceGroupBox.Controls.Add(this.SourcePort);
            this.sourceGroupBox.Controls.Add(this.SourceHostTextBox);
            this.sourceGroupBox.Controls.Add(this.label2);
            this.sourceGroupBox.Controls.Add(this.label3);
            this.sourceGroupBox.Controls.Add(this.label1);
            this.sourceGroupBox.Location = new System.Drawing.Point(12, 12);
            this.sourceGroupBox.Name = "sourceGroupBox";
            this.sourceGroupBox.Size = new System.Drawing.Size(760, 125);
            this.sourceGroupBox.TabIndex = 1;
            this.sourceGroupBox.TabStop = false;
            this.sourceGroupBox.Text = "Source";
            // 
            // SourceTypeComboBox
            // 
            this.SourceTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SourceTypeComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SourceTypeComboBox.FormattingEnabled = true;
            this.SourceTypeComboBox.Location = new System.Drawing.Point(608, 56);
            this.SourceTypeComboBox.Name = "SourceTypeComboBox";
            this.SourceTypeComboBox.Size = new System.Drawing.Size(146, 27);
            this.SourceTypeComboBox.TabIndex = 5;
            // 
            // SourceSchemaTextBox
            // 
            this.SourceSchemaTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::DataTransfer.Properties.Settings.Default, "SourceSchema", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.SourceSchemaTextBox.Location = new System.Drawing.Point(80, 57);
            this.SourceSchemaTextBox.Name = "SourceSchemaTextBox";
            this.SourceSchemaTextBox.Size = new System.Drawing.Size(180, 26);
            this.SourceSchemaTextBox.TabIndex = 4;
            this.SourceSchemaTextBox.Text = global::DataTransfer.Properties.Settings.Default.SourceSchema;
            // 
            // SourceTlsCheckBox
            // 
            this.SourceTlsCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SourceTlsCheckBox.AutoSize = true;
            this.SourceTlsCheckBox.Checked = global::DataTransfer.Properties.Settings.Default.SourceTls;
            this.SourceTlsCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::DataTransfer.Properties.Settings.Default, "SourceTls", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.SourceTlsCheckBox.Location = new System.Drawing.Point(694, 27);
            this.SourceTlsCheckBox.Name = "SourceTlsCheckBox";
            this.SourceTlsCheckBox.Size = new System.Drawing.Size(60, 23);
            this.SourceTlsCheckBox.TabIndex = 3;
            this.SourceTlsCheckBox.Text = "TLS";
            this.SourceTlsCheckBox.UseVisualStyleBackColor = true;
            // 
            // SourcePasswordTextBox
            // 
            this.SourcePasswordTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::DataTransfer.Properties.Settings.Default, "SourcePassword", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.SourcePasswordTextBox.Location = new System.Drawing.Point(266, 89);
            this.SourcePasswordTextBox.Name = "SourcePasswordTextBox";
            this.SourcePasswordTextBox.Size = new System.Drawing.Size(402, 26);
            this.SourcePasswordTextBox.TabIndex = 7;
            this.SourcePasswordTextBox.Text = global::DataTransfer.Properties.Settings.Default.SourcePassword;
            // 
            // SourceUserTextBox
            // 
            this.SourceUserTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::DataTransfer.Properties.Settings.Default, "SourceUser", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.SourceUserTextBox.Location = new System.Drawing.Point(80, 89);
            this.SourceUserTextBox.Name = "SourceUserTextBox";
            this.SourceUserTextBox.Size = new System.Drawing.Size(180, 26);
            this.SourceUserTextBox.TabIndex = 6;
            this.SourceUserTextBox.Text = global::DataTransfer.Properties.Settings.Default.SourceUser;
            // 
            // TestSourceButton
            // 
            this.TestSourceButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TestSourceButton.Location = new System.Drawing.Point(674, 89);
            this.TestSourceButton.Name = "TestSourceButton";
            this.TestSourceButton.Size = new System.Drawing.Size(80, 26);
            this.TestSourceButton.TabIndex = 8;
            this.TestSourceButton.Text = "Test";
            this.TestSourceButton.UseVisualStyleBackColor = true;
            this.TestSourceButton.Click += new System.EventHandler(this.TestSourceButton_Click);
            // 
            // SourcePort
            // 
            this.SourcePort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SourcePort.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::DataTransfer.Properties.Settings.Default, "SourcePort", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.SourcePort.Location = new System.Drawing.Point(608, 25);
            this.SourcePort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.SourcePort.Minimum = new decimal(new int[] {
            22,
            0,
            0,
            0});
            this.SourcePort.Name = "SourcePort";
            this.SourcePort.Size = new System.Drawing.Size(80, 26);
            this.SourcePort.TabIndex = 2;
            this.SourcePort.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.SourcePort.Value = global::DataTransfer.Properties.Settings.Default.SourcePort;
            // 
            // SourceHostTextBox
            // 
            this.SourceHostTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SourceHostTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::DataTransfer.Properties.Settings.Default, "SourceHostName", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.SourceHostTextBox.Location = new System.Drawing.Point(80, 25);
            this.SourceHostTextBox.Name = "SourceHostTextBox";
            this.SourceHostTextBox.Size = new System.Drawing.Size(522, 26);
            this.SourceHostTextBox.TabIndex = 1;
            this.SourceHostTextBox.Text = global::DataTransfer.Properties.Settings.Default.SourceHostName;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 19);
            this.label2.TabIndex = 8;
            this.label2.Text = "User:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 19);
            this.label3.TabIndex = 8;
            this.label3.Text = "Schema:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 19);
            this.label1.TabIndex = 8;
            this.label1.Text = "Host:";
            // 
            // DestinationGroupBox
            // 
            this.DestinationGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DestinationGroupBox.Controls.Add(this.DestinationTypeComboBox);
            this.DestinationGroupBox.Controls.Add(this.TestDestinationButton);
            this.DestinationGroupBox.Controls.Add(this.DestinationSchemaTextBox);
            this.DestinationGroupBox.Controls.Add(this.label4);
            this.DestinationGroupBox.Controls.Add(this.DestinationTlsCheckBox);
            this.DestinationGroupBox.Controls.Add(this.label5);
            this.DestinationGroupBox.Controls.Add(this.DestinationPasswordTextBox);
            this.DestinationGroupBox.Controls.Add(this.label6);
            this.DestinationGroupBox.Controls.Add(this.DestinationUserTextBox);
            this.DestinationGroupBox.Controls.Add(this.DestinationHostTextBox);
            this.DestinationGroupBox.Controls.Add(this.DestinationPort);
            this.DestinationGroupBox.Location = new System.Drawing.Point(12, 143);
            this.DestinationGroupBox.Name = "DestinationGroupBox";
            this.DestinationGroupBox.Size = new System.Drawing.Size(760, 151);
            this.DestinationGroupBox.TabIndex = 2;
            this.DestinationGroupBox.TabStop = false;
            this.DestinationGroupBox.Text = "Destination";
            // 
            // TestDestinationButton
            // 
            this.TestDestinationButton.Location = new System.Drawing.Point(674, 88);
            this.TestDestinationButton.Name = "TestDestinationButton";
            this.TestDestinationButton.Size = new System.Drawing.Size(80, 26);
            this.TestDestinationButton.TabIndex = 8;
            this.TestDestinationButton.Text = "Test";
            this.TestDestinationButton.UseVisualStyleBackColor = true;
            this.TestDestinationButton.Click += new System.EventHandler(this.TestDestinationButton_Click);
            // 
            // DestinationSchemaTextBox
            // 
            this.DestinationSchemaTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::DataTransfer.Properties.Settings.Default, "DestinationSchema", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.DestinationSchemaTextBox.Location = new System.Drawing.Point(80, 57);
            this.DestinationSchemaTextBox.Name = "DestinationSchemaTextBox";
            this.DestinationSchemaTextBox.Size = new System.Drawing.Size(180, 26);
            this.DestinationSchemaTextBox.TabIndex = 4;
            this.DestinationSchemaTextBox.Text = global::DataTransfer.Properties.Settings.Default.DestinationSchema;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 19);
            this.label4.TabIndex = 8;
            this.label4.Text = "Host:";
            // 
            // DestinationTlsCheckBox
            // 
            this.DestinationTlsCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DestinationTlsCheckBox.AutoSize = true;
            this.DestinationTlsCheckBox.Checked = global::DataTransfer.Properties.Settings.Default.DestinationTls;
            this.DestinationTlsCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::DataTransfer.Properties.Settings.Default, "DestinationTls", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.DestinationTlsCheckBox.Location = new System.Drawing.Point(694, 27);
            this.DestinationTlsCheckBox.Name = "DestinationTlsCheckBox";
            this.DestinationTlsCheckBox.Size = new System.Drawing.Size(60, 23);
            this.DestinationTlsCheckBox.TabIndex = 3;
            this.DestinationTlsCheckBox.Text = "TLS";
            this.DestinationTlsCheckBox.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 19);
            this.label5.TabIndex = 8;
            this.label5.Text = "Schema:";
            // 
            // DestinationPasswordTextBox
            // 
            this.DestinationPasswordTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::DataTransfer.Properties.Settings.Default, "DestinationPassword", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.DestinationPasswordTextBox.Location = new System.Drawing.Point(266, 89);
            this.DestinationPasswordTextBox.Name = "DestinationPasswordTextBox";
            this.DestinationPasswordTextBox.Size = new System.Drawing.Size(402, 26);
            this.DestinationPasswordTextBox.TabIndex = 7;
            this.DestinationPasswordTextBox.Text = global::DataTransfer.Properties.Settings.Default.DestinationPassword;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 93);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 19);
            this.label6.TabIndex = 8;
            this.label6.Text = "User:";
            // 
            // DestinationUserTextBox
            // 
            this.DestinationUserTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::DataTransfer.Properties.Settings.Default, "DestinationUser", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.DestinationUserTextBox.Location = new System.Drawing.Point(80, 89);
            this.DestinationUserTextBox.Name = "DestinationUserTextBox";
            this.DestinationUserTextBox.Size = new System.Drawing.Size(180, 26);
            this.DestinationUserTextBox.TabIndex = 6;
            this.DestinationUserTextBox.Text = global::DataTransfer.Properties.Settings.Default.DestinationUser;
            // 
            // DestinationHostTextBox
            // 
            this.DestinationHostTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DestinationHostTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::DataTransfer.Properties.Settings.Default, "DestinationHostName", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.DestinationHostTextBox.Location = new System.Drawing.Point(80, 25);
            this.DestinationHostTextBox.Name = "DestinationHostTextBox";
            this.DestinationHostTextBox.Size = new System.Drawing.Size(522, 26);
            this.DestinationHostTextBox.TabIndex = 1;
            this.DestinationHostTextBox.Text = global::DataTransfer.Properties.Settings.Default.DestinationHostName;
            // 
            // DestinationPort
            // 
            this.DestinationPort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DestinationPort.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::DataTransfer.Properties.Settings.Default, "DestinationPort", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.DestinationPort.Location = new System.Drawing.Point(608, 25);
            this.DestinationPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.DestinationPort.Minimum = new decimal(new int[] {
            22,
            0,
            0,
            0});
            this.DestinationPort.Name = "DestinationPort";
            this.DestinationPort.Size = new System.Drawing.Size(80, 26);
            this.DestinationPort.TabIndex = 2;
            this.DestinationPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.DestinationPort.Value = global::DataTransfer.Properties.Settings.Default.DestinationPort;
            // 
            // TransferButton
            // 
            this.TransferButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.TransferButton.BackColor = System.Drawing.Color.PaleGreen;
            this.TransferButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TransferButton.Location = new System.Drawing.Point(676, 510);
            this.TransferButton.Name = "TransferButton";
            this.TransferButton.Size = new System.Drawing.Size(96, 26);
            this.TransferButton.TabIndex = 3;
            this.TransferButton.Text = "Transfer";
            this.TransferButton.UseVisualStyleBackColor = false;
            this.TransferButton.Click += new System.EventHandler(this.TransferButton_Click);
            // 
            // DestinationTypeComboBox
            // 
            this.DestinationTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DestinationTypeComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DestinationTypeComboBox.FormattingEnabled = true;
            this.DestinationTypeComboBox.Location = new System.Drawing.Point(608, 57);
            this.DestinationTypeComboBox.Name = "DestinationTypeComboBox";
            this.DestinationTypeComboBox.Size = new System.Drawing.Size(146, 27);
            this.DestinationTypeComboBox.TabIndex = 5;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.TransferButton);
            this.Controls.Add(this.DestinationGroupBox);
            this.Controls.Add(this.sourceGroupBox);
            this.Controls.Add(this.StatusBar);
            this.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.StatusBar.ResumeLayout(false);
            this.StatusBar.PerformLayout();
            this.sourceGroupBox.ResumeLayout(false);
            this.sourceGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SourcePort)).EndInit();
            this.DestinationGroupBox.ResumeLayout(false);
            this.DestinationGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DestinationPort)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip StatusBar;
        private System.Windows.Forms.GroupBox sourceGroupBox;
        private System.Windows.Forms.TextBox SourceHostTextBox;
        private System.Windows.Forms.NumericUpDown SourcePort;
        private System.Windows.Forms.Button TestSourceButton;
        private System.Windows.Forms.TextBox SourceUserTextBox;
        private System.Windows.Forms.TextBox SourcePasswordTextBox;
        private System.Windows.Forms.CheckBox SourceTlsCheckBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox SourceSchemaTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStripStatusLabel StatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripProgressBar ProgressBar;
        private System.Windows.Forms.GroupBox DestinationGroupBox;
        private System.Windows.Forms.Button TestDestinationButton;
        private System.Windows.Forms.TextBox DestinationSchemaTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox DestinationTlsCheckBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox DestinationPasswordTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox DestinationUserTextBox;
        private System.Windows.Forms.TextBox DestinationHostTextBox;
        private System.Windows.Forms.NumericUpDown DestinationPort;
        private System.Windows.Forms.Button TransferButton;
        private System.Windows.Forms.ComboBox SourceTypeComboBox;
        private System.Windows.Forms.ComboBox DestinationTypeComboBox;
    }
}

