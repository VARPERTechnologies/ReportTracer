namespace ReportTracer
{
    partial class DynamicTextFinder
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tb = new System.Windows.Forms.TextBox();
            this.tlpText = new System.Windows.Forms.TableLayoutPanel();
            this.lblNro = new System.Windows.Forms.Label();
            this.pbSearchControl = new System.Windows.Forms.PictureBox();
            this.tlpText.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSearchControl)).BeginInit();
            this.SuspendLayout();
            // 
            // tb
            // 
            this.tb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb.Location = new System.Drawing.Point(130, 3);
            this.tb.MinimumSize = new System.Drawing.Size(30, 23);
            this.tb.Name = "tb";
            this.tb.Size = new System.Drawing.Size(405, 23);
            this.tb.TabIndex = 0;
            this.tb.TextChanged += new System.EventHandler(this.OnTextChanged);
            // 
            // tlpText
            // 
            this.tlpText.AutoSize = true;
            this.tlpText.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tlpText.ColumnCount = 3;
            this.tlpText.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpText.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpText.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tlpText.Controls.Add(this.lblNro, 0, 0);
            this.tlpText.Controls.Add(this.tb, 1, 0);
            this.tlpText.Controls.Add(this.pbSearchControl, 2, 0);
            this.tlpText.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlpText.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tlpText.Location = new System.Drawing.Point(0, 0);
            this.tlpText.Margin = new System.Windows.Forms.Padding(0);
            this.tlpText.Name = "tlpText";
            this.tlpText.RowCount = 1;
            this.tlpText.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpText.Size = new System.Drawing.Size(561, 29);
            this.tlpText.TabIndex = 2;
            // 
            // lblNro
            // 
            this.lblNro.BackColor = System.Drawing.SystemColors.Window;
            this.lblNro.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.lblNro.Location = new System.Drawing.Point(0, 0);
            this.lblNro.Margin = new System.Windows.Forms.Padding(0);
            this.lblNro.Name = "lblNro";
            this.lblNro.Padding = new System.Windows.Forms.Padding(3);
            this.lblNro.Size = new System.Drawing.Size(127, 23);
            this.lblNro.TabIndex = 3;
            this.lblNro.Text = "Text";
            // 
            // pbSearchControl
            // 
            this.pbSearchControl.BackColor = System.Drawing.SystemColors.Window;
            this.pbSearchControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.pbSearchControl.Image = global::ReportTracer.Generic.search;
            this.pbSearchControl.Location = new System.Drawing.Point(538, 0);
            this.pbSearchControl.Margin = new System.Windows.Forms.Padding(0);
            this.pbSearchControl.Name = "pbSearchControl";
            this.pbSearchControl.Size = new System.Drawing.Size(23, 23);
            this.pbSearchControl.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbSearchControl.TabIndex = 1;
            this.pbSearchControl.TabStop = false;
            this.pbSearchControl.Click += new System.EventHandler(this.OnMagnifyingGlassClicked);
            this.pbSearchControl.MouseEnter += new System.EventHandler(this.onMagnifyingGlassEntered);
            this.pbSearchControl.MouseLeave += new System.EventHandler(this.OnMagnifyingGlassLeft);
            // 
            // DynamicTextFinder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.tlpText);
            this.MinimumSize = new System.Drawing.Size(80, 23);
            this.Name = "DynamicTextFinder";
            this.Size = new System.Drawing.Size(561, 42);
            this.Load += new System.EventHandler(this.DynamicTextFinder_Load);
            this.tlpText.ResumeLayout(false);
            this.tlpText.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSearchControl)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb;
        private System.Windows.Forms.TableLayoutPanel tlpText;
        private System.Windows.Forms.PictureBox pbSearchControl;
        private System.Windows.Forms.Label lblNro;
    }
}
