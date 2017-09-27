namespace ReportTracer
{
    partial class OptionsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnAccept = new DevExpress.XtraEditors.SimpleButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabEmail = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.gcSender = new DevExpress.XtraEditors.GroupControl();
            this.labelControl12 = new DevExpress.XtraEditors.LabelControl();
            this.seSMTPTimeout = new DevExpress.XtraEditors.SpinEdit();
            this.labelControl13 = new DevExpress.XtraEditors.LabelControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.txtPassword = new DevExpress.XtraEditors.TextEdit();
            this.cbSecurity = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.txtUser = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.sePort = new DevExpress.XtraEditors.SpinEdit();
            this.txtServerName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.gcReceiver = new DevExpress.XtraEditors.GroupControl();
            this.txtSubject = new DevExpress.XtraEditors.TextEdit();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.txtEmailReceiver = new DevExpress.XtraEditors.TextEdit();
            this.tabTrace = new System.Windows.Forms.TabPage();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.seTimeout = new DevExpress.XtraEditors.SpinEdit();
            this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl11 = new DevExpress.XtraEditors.LabelControl();
            this.seHops = new DevExpress.XtraEditors.SpinEdit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tabMain.SuspendLayout();
            this.tabEmail.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcSender)).BeginInit();
            this.gcSender.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.seSMTPTimeout.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbSecurity.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUser.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sePort.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtServerName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcReceiver)).BeginInit();
            this.gcReceiver.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubject.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmailReceiver.Properties)).BeginInit();
            this.tabTrace.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.seTimeout.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seHops.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.AutoSize = true;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(166, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(157, 27);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnAccept
            // 
            this.btnAccept.Location = new System.Drawing.Point(3, 3);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(157, 27);
            this.btnAccept.TabIndex = 1;
            this.btnAccept.Text = "Accept";
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.btnAccept, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnCancel, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(187, 509);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(326, 33);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel1, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.tabMain, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(519, 547);
            this.tableLayoutPanel2.TabIndex = 3;
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tabEmail);
            this.tabMain.Controls.Add(this.tabTrace);
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Location = new System.Drawing.Point(3, 3);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(513, 498);
            this.tabMain.TabIndex = 3;
            // 
            // tabEmail
            // 
            this.tabEmail.Controls.Add(this.tableLayoutPanel3);
            this.tabEmail.Location = new System.Drawing.Point(4, 25);
            this.tabEmail.Name = "tabEmail";
            this.tabEmail.Padding = new System.Windows.Forms.Padding(3);
            this.tabEmail.Size = new System.Drawing.Size(505, 469);
            this.tabEmail.TabIndex = 0;
            this.tabEmail.Text = "Email";
            this.tabEmail.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.gcSender, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.gcReceiver, 0, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 296F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(499, 463);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // gcSender
            // 
            this.gcSender.Controls.Add(this.labelControl12);
            this.gcSender.Controls.Add(this.seSMTPTimeout);
            this.gcSender.Controls.Add(this.labelControl13);
            this.gcSender.Controls.Add(this.groupControl1);
            this.gcSender.Controls.Add(this.sePort);
            this.gcSender.Controls.Add(this.txtServerName);
            this.gcSender.Controls.Add(this.labelControl5);
            this.gcSender.Controls.Add(this.labelControl1);
            this.gcSender.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcSender.Location = new System.Drawing.Point(3, 3);
            this.gcSender.Name = "gcSender";
            this.gcSender.Size = new System.Drawing.Size(493, 290);
            this.gcSender.TabIndex = 0;
            this.gcSender.Text = "Sender";
            // 
            // labelControl12
            // 
            this.labelControl12.Location = new System.Drawing.Point(5, 85);
            this.labelControl12.Name = "labelControl12";
            this.labelControl12.Size = new System.Drawing.Size(47, 16);
            this.labelControl12.TabIndex = 14;
            this.labelControl12.Text = "Timeout";
            // 
            // seSMTPTimeout
            // 
            this.seSMTPTimeout.EditValue = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.seSMTPTimeout.Location = new System.Drawing.Point(158, 82);
            this.seSMTPTimeout.Name = "seSMTPTimeout";
            this.seSMTPTimeout.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.seSMTPTimeout.Properties.IsFloatValue = false;
            this.seSMTPTimeout.Properties.Mask.EditMask = "N00";
            this.seSMTPTimeout.Properties.MaxValue = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.seSMTPTimeout.Properties.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.seSMTPTimeout.Size = new System.Drawing.Size(100, 22);
            this.seSMTPTimeout.TabIndex = 13;
            // 
            // labelControl13
            // 
            this.labelControl13.Location = new System.Drawing.Point(264, 85);
            this.labelControl13.Name = "labelControl13";
            this.labelControl13.Size = new System.Drawing.Size(46, 16);
            this.labelControl13.TabIndex = 15;
            this.labelControl13.Text = "seconds";
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.txtPassword);
            this.groupControl1.Controls.Add(this.cbSecurity);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.labelControl6);
            this.groupControl1.Controls.Add(this.txtUser);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Location = new System.Drawing.Point(5, 126);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(374, 125);
            this.groupControl1.TabIndex = 11;
            this.groupControl1.Text = "Security";
            // 
            // txtPassword
            // 
            this.txtPassword.EditValue = "Informatica53.,";
            this.txtPassword.Location = new System.Drawing.Point(152, 84);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Properties.UseSystemPasswordChar = true;
            this.txtPassword.Size = new System.Drawing.Size(208, 22);
            this.txtPassword.TabIndex = 10;
            // 
            // cbSecurity
            // 
            this.cbSecurity.EditValue = "SSL/TLS";
            this.cbSecurity.Location = new System.Drawing.Point(152, 28);
            this.cbSecurity.Name = "cbSecurity";
            this.cbSecurity.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbSecurity.Properties.Items.AddRange(new object[] {
            "None",
            "SSL/TLS"});
            this.cbSecurity.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbSecurity.Size = new System.Drawing.Size(207, 22);
            this.cbSecurity.TabIndex = 9;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(5, 59);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(26, 16);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "User";
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(7, 29);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(46, 16);
            this.labelControl6.TabIndex = 8;
            this.labelControl6.Text = "Security";
            // 
            // txtUser
            // 
            this.txtUser.EditValue = "developmentavant@gmail.com";
            this.txtUser.Location = new System.Drawing.Point(152, 56);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(207, 22);
            this.txtUser.TabIndex = 7;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(5, 87);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(55, 16);
            this.labelControl3.TabIndex = 2;
            this.labelControl3.Text = "Password";
            // 
            // sePort
            // 
            this.sePort.EditValue = new decimal(new int[] {
            587,
            0,
            0,
            0});
            this.sePort.Location = new System.Drawing.Point(158, 54);
            this.sePort.Name = "sePort";
            this.sePort.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.sePort.Properties.IsFloatValue = false;
            this.sePort.Properties.Mask.EditMask = "N00";
            this.sePort.Size = new System.Drawing.Size(101, 22);
            this.sePort.TabIndex = 10;
            // 
            // txtServerName
            // 
            this.txtServerName.EditValue = "smtp.gmail.com";
            this.txtServerName.Location = new System.Drawing.Point(158, 26);
            this.txtServerName.Name = "txtServerName";
            this.txtServerName.Size = new System.Drawing.Size(207, 22);
            this.txtServerName.TabIndex = 5;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(6, 57);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(23, 16);
            this.labelControl5.TabIndex = 4;
            this.labelControl5.Text = "Port";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(7, 29);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(74, 16);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Server name";
            // 
            // gcReceiver
            // 
            this.gcReceiver.Controls.Add(this.txtSubject);
            this.gcReceiver.Controls.Add(this.labelControl8);
            this.gcReceiver.Controls.Add(this.labelControl7);
            this.gcReceiver.Controls.Add(this.txtEmailReceiver);
            this.gcReceiver.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcReceiver.Location = new System.Drawing.Point(3, 299);
            this.gcReceiver.Name = "gcReceiver";
            this.gcReceiver.Size = new System.Drawing.Size(493, 161);
            this.gcReceiver.TabIndex = 1;
            this.gcReceiver.Text = "Receiver";
            // 
            // txtSubject
            // 
            this.txtSubject.EditValue = "[ReportTracer]JSONReport";
            this.txtSubject.Location = new System.Drawing.Point(157, 56);
            this.txtSubject.Name = "txtSubject";
            this.txtSubject.Size = new System.Drawing.Size(208, 22);
            this.txtSubject.TabIndex = 3;
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(5, 59);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(43, 16);
            this.labelControl8.TabIndex = 2;
            this.labelControl8.Text = "Subject";
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(5, 31);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(31, 16);
            this.labelControl7.TabIndex = 1;
            this.labelControl7.Text = "Email";
            // 
            // txtEmailReceiver
            // 
            this.txtEmailReceiver.EditValue = "developmentavant@gmail.com";
            this.txtEmailReceiver.Location = new System.Drawing.Point(157, 28);
            this.txtEmailReceiver.Name = "txtEmailReceiver";
            this.txtEmailReceiver.Size = new System.Drawing.Size(208, 22);
            this.txtEmailReceiver.TabIndex = 0;
            // 
            // tabTrace
            // 
            this.tabTrace.Controls.Add(this.groupControl2);
            this.tabTrace.Location = new System.Drawing.Point(4, 25);
            this.tabTrace.Name = "tabTrace";
            this.tabTrace.Padding = new System.Windows.Forms.Padding(3);
            this.tabTrace.Size = new System.Drawing.Size(505, 469);
            this.tabTrace.TabIndex = 1;
            this.tabTrace.Text = "Route";
            this.tabTrace.UseVisualStyleBackColor = true;
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.labelControl9);
            this.groupControl2.Controls.Add(this.seTimeout);
            this.groupControl2.Controls.Add(this.labelControl10);
            this.groupControl2.Controls.Add(this.labelControl11);
            this.groupControl2.Controls.Add(this.seHops);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl2.Location = new System.Drawing.Point(3, 3);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(499, 463);
            this.groupControl2.TabIndex = 7;
            this.groupControl2.Text = "Trace";
            // 
            // labelControl9
            // 
            this.labelControl9.Location = new System.Drawing.Point(5, 28);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(47, 16);
            this.labelControl9.TabIndex = 1;
            this.labelControl9.Text = "Timeout";
            // 
            // seTimeout
            // 
            this.seTimeout.EditValue = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.seTimeout.Location = new System.Drawing.Point(160, 25);
            this.seTimeout.Name = "seTimeout";
            this.seTimeout.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.seTimeout.Properties.IsFloatValue = false;
            this.seTimeout.Properties.Mask.EditMask = "N00";
            this.seTimeout.Properties.MaxValue = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.seTimeout.Properties.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.seTimeout.Size = new System.Drawing.Size(100, 22);
            this.seTimeout.TabIndex = 0;
            // 
            // labelControl10
            // 
            this.labelControl10.Location = new System.Drawing.Point(266, 28);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Size = new System.Drawing.Size(46, 16);
            this.labelControl10.TabIndex = 2;
            this.labelControl10.Text = "seconds";
            // 
            // labelControl11
            // 
            this.labelControl11.Location = new System.Drawing.Point(5, 56);
            this.labelControl11.Name = "labelControl11";
            this.labelControl11.Size = new System.Drawing.Size(28, 16);
            this.labelControl11.TabIndex = 4;
            this.labelControl11.Text = "Hops";
            // 
            // seHops
            // 
            this.seHops.EditValue = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.seHops.Location = new System.Drawing.Point(160, 53);
            this.seHops.Name = "seHops";
            this.seHops.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.seHops.Properties.IsFloatValue = false;
            this.seHops.Properties.Mask.EditMask = "N00";
            this.seHops.Properties.MaxValue = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.seHops.Properties.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.seHops.Size = new System.Drawing.Size(100, 22);
            this.seHops.TabIndex = 3;
            // 
            // OptionsForm
            // 
            this.AcceptButton = this.btnAccept;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(519, 547);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Name = "OptionsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Options";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tabMain.ResumeLayout(false);
            this.tabEmail.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcSender)).EndInit();
            this.gcSender.ResumeLayout(false);
            this.gcSender.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.seSMTPTimeout.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbSecurity.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUser.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sePort.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtServerName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcReceiver)).EndInit();
            this.gcReceiver.ResumeLayout(false);
            this.gcReceiver.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubject.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmailReceiver.Properties)).EndInit();
            this.tabTrace.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.seTimeout.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seHops.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnAccept;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        public System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tabEmail;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private DevExpress.XtraEditors.GroupControl gcSender;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.GroupControl gcReceiver;
        private System.Windows.Forms.TabPage tabTrace;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.ComboBoxEdit cbSecurity;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.SpinEdit sePort;
        private DevExpress.XtraEditors.TextEdit txtUser;
        private DevExpress.XtraEditors.TextEdit txtServerName;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.TextEdit txtPassword;
        private DevExpress.XtraEditors.TextEdit txtSubject;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.TextEdit txtEmailReceiver;
        private DevExpress.XtraEditors.LabelControl labelControl10;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.SpinEdit seTimeout;
        private DevExpress.XtraEditors.LabelControl labelControl11;
        private DevExpress.XtraEditors.SpinEdit seHops;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.LabelControl labelControl12;
        private DevExpress.XtraEditors.SpinEdit seSMTPTimeout;
        private DevExpress.XtraEditors.LabelControl labelControl13;
    }
}