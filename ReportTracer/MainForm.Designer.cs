

namespace ReportTracer
{
    partial class MainForm : DevExpress.XtraBars.TabForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.routeList = new System.Windows.Forms.ListView();
            this.hostIPHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.hopHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.hostNameHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.roundTripTimeHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.close = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnAddHost = new System.Windows.Forms.Button();
            this.btnDelHost = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tlDevicesToRoute = new DevExpress.XtraTreeList.TreeList();
            this.cName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.tlcIP = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn2 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.startTrace = new DevExpress.XtraEditors.DropDownButton();
            this.pmCommands = new DevExpress.XtraBars.PopupMenu(this.components);
            this.btnReport = new DevExpress.XtraBars.BarButtonItem();
            this.bmCommands = new DevExpress.XtraBars.BarManager(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.mMain = new DevExpress.XtraBars.BarSubItem();
            this.btnOptions = new DevExpress.XtraBars.BarButtonItem();
            this.mOptions = new DevExpress.XtraBars.BarSubItem();
            this.tabFormControl1 = new DevExpress.XtraBars.TabFormControl();
            this.btnAbout = new DevExpress.XtraBars.BarButtonItem();
            this.tabMain = new DevExpress.XtraBars.TabFormPage();
            this.tabFormContentContainer1 = new DevExpress.XtraBars.TabFormContentContainer();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tlDevicesToRoute)).BeginInit();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pmCommands)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bmCommands)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabFormControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // routeList
            // 
            this.routeList.AllowColumnReorder = true;
            this.routeList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.routeList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.hostIPHeader,
            this.hopHeader,
            this.hostNameHeader,
            this.roundTripTimeHeader});
            this.routeList.GridLines = true;
            this.routeList.Location = new System.Drawing.Point(4, 857);
            this.routeList.Margin = new System.Windows.Forms.Padding(4);
            this.routeList.Name = "routeList";
            this.routeList.Size = new System.Drawing.Size(747, 93);
            this.routeList.TabIndex = 3;
            this.routeList.UseCompatibleStateImageBehavior = false;
            this.routeList.View = System.Windows.Forms.View.Details;
            // 
            // hostIPHeader
            // 
            this.hostIPHeader.DisplayIndex = 1;
            this.hostIPHeader.Text = "Host";
            this.hostIPHeader.Width = 130;
            // 
            // hopHeader
            // 
            this.hopHeader.DisplayIndex = 0;
            this.hopHeader.Text = "Salto";
            this.hopHeader.Width = 58;
            // 
            // hostNameHeader
            // 
            this.hostNameHeader.Text = "Dirección IP";
            this.hostNameHeader.Width = 141;
            // 
            // roundTripTimeHeader
            // 
            this.roundTripTimeHeader.Text = "Tiempo";
            this.roundTripTimeHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.roundTripTimeHeader.Width = 62;
            // 
            // close
            // 
            this.close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.close.Location = new System.Drawing.Point(486, 660);
            this.close.Margin = new System.Windows.Forms.Padding(4);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(88, 28);
            this.close.TabIndex = 5;
            this.close.Text = "&Cerrar";
            this.close.UseVisualStyleBackColor = true;
            this.close.Click += new System.EventHandler(this.Close_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.pictureBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tlDevicesToRoute, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 27);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(588, 667);
            this.tableLayoutPanel1.TabIndex = 7;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 262F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.btnAddHost, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnDelHost, 3, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 123);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(322, 31);
            this.tableLayoutPanel2.TabIndex = 8;
            // 
            // btnAddHost
            // 
            this.btnAddHost.AutoSize = true;
            this.btnAddHost.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAddHost.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddHost.Location = new System.Drawing.Point(265, 3);
            this.btnAddHost.Name = "btnAddHost";
            this.btnAddHost.Size = new System.Drawing.Size(27, 25);
            this.btnAddHost.TabIndex = 3;
            this.btnAddHost.Text = "+";
            this.btnAddHost.UseVisualStyleBackColor = true;
            this.btnAddHost.Click += new System.EventHandler(this.OnAddHostClicked);
            // 
            // btnDelHost
            // 
            this.btnDelHost.AutoSize = true;
            this.btnDelHost.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnDelHost.Location = new System.Drawing.Point(298, 3);
            this.btnDelHost.Name = "btnDelHost";
            this.btnDelHost.Size = new System.Drawing.Size(21, 23);
            this.btnDelHost.TabIndex = 4;
            this.btnDelHost.Text = "-";
            this.btnDelHost.UseVisualStyleBackColor = true;
            this.btnDelHost.Click += new System.EventHandler(this.OnRemoveHostClicked);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::ReportTracer.Generic.banner;
            this.pictureBox1.Location = new System.Drawing.Point(4, 4);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(580, 112);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // tlDevicesToRoute
            // 
            this.tlDevicesToRoute.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.cName,
            this.tlcIP,
            this.treeListColumn1,
            this.treeListColumn2});
            this.tlDevicesToRoute.Cursor = System.Windows.Forms.Cursors.Default;
            this.tlDevicesToRoute.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlDevicesToRoute.Location = new System.Drawing.Point(3, 160);
            this.tlDevicesToRoute.Name = "tlDevicesToRoute";
            this.tlDevicesToRoute.OptionsBehavior.ImmediateEditor = false;
            this.tlDevicesToRoute.OptionsCustomization.AllowColumnMoving = false;
            this.tlDevicesToRoute.OptionsSelection.MultiSelect = true;
            this.tlDevicesToRoute.OptionsView.FocusRectStyle = DevExpress.XtraTreeList.DrawFocusRectStyle.RowFullFocus;
            this.tlDevicesToRoute.Size = new System.Drawing.Size(582, 454);
            this.tlDevicesToRoute.TabIndex = 14;
            this.tlDevicesToRoute.KeyUp += new System.Windows.Forms.KeyEventHandler(this.OnKeyUp);
            // 
            // cName
            // 
            this.cName.Caption = "Name";
            this.cName.FieldName = "cName";
            this.cName.Name = "cName";
            this.cName.OptionsColumn.AllowMove = false;
            this.cName.OptionsColumn.AllowSort = false;
            this.cName.OptionsFilter.AllowFilter = false;
            this.cName.Visible = true;
            this.cName.VisibleIndex = 0;
            this.cName.Width = 198;
            // 
            // tlcIP
            // 
            this.tlcIP.Caption = "IP";
            this.tlcIP.FieldName = "cIP";
            this.tlcIP.Name = "tlcIP";
            this.tlcIP.OptionsColumn.AllowMove = false;
            this.tlcIP.OptionsColumn.AllowSort = false;
            this.tlcIP.OptionsFilter.AllowFilter = false;
            this.tlcIP.Visible = true;
            this.tlcIP.VisibleIndex = 1;
            this.tlcIP.Width = 186;
            // 
            // treeListColumn1
            // 
            this.treeListColumn1.Caption = "Host name";
            this.treeListColumn1.FieldName = "tcHostName";
            this.treeListColumn1.Name = "treeListColumn1";
            this.treeListColumn1.OptionsColumn.AllowEdit = false;
            this.treeListColumn1.OptionsColumn.AllowSort = false;
            this.treeListColumn1.OptionsFilter.AllowFilter = false;
            this.treeListColumn1.Visible = true;
            this.treeListColumn1.VisibleIndex = 2;
            this.treeListColumn1.Width = 161;
            // 
            // treeListColumn2
            // 
            this.treeListColumn2.Caption = "Time (ms)";
            this.treeListColumn2.FieldName = "tcTime";
            this.treeListColumn2.Name = "treeListColumn2";
            this.treeListColumn2.OptionsColumn.AllowEdit = false;
            this.treeListColumn2.OptionsColumn.AllowSort = false;
            this.treeListColumn2.OptionsFilter.AllowFilter = false;
            this.treeListColumn2.Visible = true;
            this.treeListColumn2.VisibleIndex = 3;
            this.treeListColumn2.Width = 184;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 76.59574F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.40426F));
            this.tableLayoutPanel3.Controls.Add(this.startTrace, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 620);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(582, 44);
            this.tableLayoutPanel3.TabIndex = 15;
            // 
            // startTrace
            // 
            this.startTrace.AutoSize = true;
            this.startTrace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.startTrace.DropDownControl = this.pmCommands;
            this.startTrace.Location = new System.Drawing.Point(448, 3);
            this.startTrace.Name = "startTrace";
            this.startTrace.Size = new System.Drawing.Size(131, 38);
            this.startTrace.TabIndex = 0;
            this.startTrace.Text = "Test";
            this.startTrace.Click += new System.EventHandler(this.StartTrace_Click);
            // 
            // pmCommands
            // 
            this.pmCommands.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnReport)});
            this.pmCommands.Manager = this.bmCommands;
            this.pmCommands.Name = "pmCommands";
            // 
            // btnReport
            // 
            this.btnReport.Caption = "Send report";
            this.btnReport.Id = 0;
            this.btnReport.Name = "btnReport";
            this.btnReport.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BtnReport_ItemClick);
            // 
            // bmCommands
            // 
            this.bmCommands.DockControls.Add(this.barDockControlTop);
            this.bmCommands.DockControls.Add(this.barDockControlBottom);
            this.bmCommands.DockControls.Add(this.barDockControlLeft);
            this.bmCommands.DockControls.Add(this.barDockControlRight);
            this.bmCommands.Form = this;
            this.bmCommands.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnReport,
            this.mMain,
            this.mOptions,
            this.btnOptions});
            this.bmCommands.MaxItemId = 1;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.bmCommands;
            this.barDockControlTop.Size = new System.Drawing.Size(588, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 694);
            this.barDockControlBottom.Manager = this.bmCommands;
            this.barDockControlBottom.Size = new System.Drawing.Size(588, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Manager = this.bmCommands;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 694);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(588, 0);
            this.barDockControlRight.Manager = this.bmCommands;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 694);
            // 
            // mMain
            // 
            this.mMain.Caption = "File";
            this.mMain.Id = 0;
            this.mMain.ImageOptions.Image = global::ReportTracer.Generic.Error;
            this.mMain.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnOptions, DevExpress.XtraBars.BarItemPaintStyle.Standard)});
            this.mMain.Name = "mMain";
            // 
            // btnOptions
            // 
            this.btnOptions.Caption = "Options";
            this.btnOptions.Id = 0;
            this.btnOptions.Name = "btnOptions";
            this.btnOptions.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnOptions_ItemClick);
            // 
            // mOptions
            // 
            this.mOptions.Caption = "Options";
            this.mOptions.Id = 1;
            this.mOptions.Name = "mOptions";
            // 
            // tabFormControl1
            // 
            this.tabFormControl1.AllowMoveTabs = false;
            this.tabFormControl1.AllowMoveTabsToOuterForm = false;
            this.tabFormControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnAbout});
            this.tabFormControl1.Location = new System.Drawing.Point(0, 0);
            this.tabFormControl1.Name = "tabFormControl1";
            this.tabFormControl1.Pages.Add(this.tabMain);
            this.tabFormControl1.SelectedPage = this.tabMain;
            this.tabFormControl1.ShowAddPageButton = false;
            this.tabFormControl1.ShowTabsInTitleBar = DevExpress.XtraBars.ShowTabsInTitleBar.True;
            this.tabFormControl1.Size = new System.Drawing.Size(588, 27);
            this.tabFormControl1.TabForm = this;
            this.tabFormControl1.TabIndex = 8;
            this.tabFormControl1.TabRightItemLinks.Add(this.mMain);
            this.tabFormControl1.TabRightItemLinks.Add(this.btnAbout);
            this.tabFormControl1.TabStop = false;
            this.tabFormControl1.Click += new System.EventHandler(this.tabFormControl1_Click);
            // 
            // btnAbout
            // 
            this.btnAbout.Caption = "About...";
            this.btnAbout.Id = 4;
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAbout_ItemClick);
            // 
            // tabMain
            // 
            this.tabMain.ContentContainer = this.tabFormContentContainer1;
            this.tabMain.Image = global::ReportTracer.Generic.RT_X_64_PX;
            this.tabMain.Name = "tabMain";
            this.tabMain.ShowCloseButton = DevExpress.Utils.DefaultBoolean.False;
            this.tabMain.Text = "Report Tracer";
            // 
            // tabFormContentContainer1
            // 
            this.tabFormContentContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabFormContentContainer1.Location = new System.Drawing.Point(0, 27);
            this.tabFormContentContainer1.Name = "tabFormContentContainer1";
            this.tabFormContentContainer1.Size = new System.Drawing.Size(588, 667);
            this.tabFormContentContainer1.TabIndex = 9;
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(588, 694);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.close);
            this.Controls.Add(this.tabFormContentContainer1);
            this.Controls.Add(this.tabFormControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TabFormControl = this.tabFormControl1;
            this.Text = "Report Tracer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tlDevicesToRoute)).EndInit();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pmCommands)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bmCommands)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabFormControl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

        #endregion
		private System.Windows.Forms.ListView routeList;
		private System.Windows.Forms.Button close;
		private System.Windows.Forms.ColumnHeader hostIPHeader;
		private System.Windows.Forms.ColumnHeader hopHeader;
		private System.Windows.Forms.ColumnHeader hostNameHeader;
		private System.Windows.Forms.ColumnHeader roundTripTimeHeader;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button btnAddHost;
        private System.Windows.Forms.Button btnDelHost;
        private DevExpress.XtraTreeList.TreeList tlDevicesToRoute;
        private DevExpress.XtraTreeList.Columns.TreeListColumn cName;
        private DevExpress.XtraTreeList.Columns.TreeListColumn tlcIP;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private DevExpress.XtraEditors.DropDownButton startTrace;
        private DevExpress.XtraBars.TabFormControl tabFormControl1;
        private DevExpress.XtraBars.BarSubItem mMain;
        private DevExpress.XtraBars.TabFormPage tabMain;
        private DevExpress.XtraBars.TabFormContentContainer tabFormContentContainer1;
        private DevExpress.XtraBars.BarSubItem mOptions;
        private DevExpress.XtraBars.BarButtonItem btnOptions;
        private DevExpress.XtraBars.PopupMenu pmCommands;
        private DevExpress.XtraBars.BarButtonItem btnReport;
        private DevExpress.XtraBars.BarManager bmCommands;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private System.Windows.Forms.PictureBox pictureBox1;
        private DevExpress.XtraBars.BarButtonItem btnAbout;
    }
}

