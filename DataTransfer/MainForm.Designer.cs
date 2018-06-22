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
            this.sourceGroupBox = new System.Windows.Forms.GroupBox();
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
            this.StatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.StatusBar.SuspendLayout();
            this.sourceGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SourcePort)).BeginInit();
            this.SuspendLayout();
            // 
            // StatusBar
            // 
            this.StatusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusLabel,
            this.toolStripStatusLabel1,
            this.toolStripProgressBar1});
            this.StatusBar.Location = new System.Drawing.Point(0, 539);
            this.StatusBar.Name = "StatusBar";
            this.StatusBar.Size = new System.Drawing.Size(784, 22);
            this.StatusBar.TabIndex = 0;
            this.StatusBar.Text = "statusStrip1";
            // 
            // sourceGroupBox
            // 
            this.sourceGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
            // SourceSchemaTextBox
            // 
            this.SourceSchemaTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::DataTransfer.Properties.Settings.Default, "SourceSchema", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.SourceSchemaTextBox.Location = new System.Drawing.Point(80, 57);
            this.SourceSchemaTextBox.Name = "SourceSchemaTextBox";
            this.SourceSchemaTextBox.Size = new System.Drawing.Size(180, 26);
            this.SourceSchemaTextBox.TabIndex = 9;
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
            this.SourceTlsCheckBox.TabIndex = 7;
            this.SourceTlsCheckBox.Text = "TLS";
            this.SourceTlsCheckBox.UseVisualStyleBackColor = true;
            // 
            // SourcePasswordTextBox
            // 
            this.SourcePasswordTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::DataTransfer.Properties.Settings.Default, "SourcePassword", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.SourcePasswordTextBox.Location = new System.Drawing.Point(266, 89);
            this.SourcePasswordTextBox.Name = "SourcePasswordTextBox";
            this.SourcePasswordTextBox.Size = new System.Drawing.Size(402, 26);
            this.SourcePasswordTextBox.TabIndex = 6;
            this.SourcePasswordTextBox.Text = global::DataTransfer.Properties.Settings.Default.SourcePassword;
            // 
            // SourceUserTextBox
            // 
            this.SourceUserTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::DataTransfer.Properties.Settings.Default, "SourceUser", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.SourceUserTextBox.Location = new System.Drawing.Point(80, 89);
            this.SourceUserTextBox.Name = "SourceUserTextBox";
            this.SourceUserTextBox.Size = new System.Drawing.Size(180, 26);
            this.SourceUserTextBox.TabIndex = 5;
            this.SourceUserTextBox.Text = global::DataTransfer.Properties.Settings.Default.SourceUser;
            // 
            // TestSourceButton
            // 
            this.TestSourceButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TestSourceButton.Location = new System.Drawing.Point(674, 89);
            this.TestSourceButton.Name = "TestSourceButton";
            this.TestSourceButton.Size = new System.Drawing.Size(80, 26);
            this.TestSourceButton.TabIndex = 4;
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
            this.SourcePort.TabIndex = 3;
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
            this.SourceHostTextBox.TabIndex = 2;
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
            // StatusLabel
            // 
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(636, 17);
            this.toolStripStatusLabel1.Spring = true;
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 16);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
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
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
    }
}

