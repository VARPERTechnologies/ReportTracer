using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ReportTracer
{
    public partial class GenerateReportForm : Form
    {
        public GenerateReportForm()
        {
            InitializeComponent();
        }
        
        private void btnAccept_Click(object sender, EventArgs e)
        {

            DialogResult = DialogResult.OK;

            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        public static string GetTextValue()
        {
            GenerateReportForm grf = new GenerateReportForm();

            if(grf.ShowDialog() == DialogResult.OK)
            {
                return grf.txtOR.Text;
            }

            return null;
        }
    }
}
