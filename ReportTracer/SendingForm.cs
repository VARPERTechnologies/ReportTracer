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
    public partial class SendingForm : Form
    {
        public SendingForm()
        {
            InitializeComponent();
        }
        
        /// <summary>
        /// 
        /// </summary>
        public SendingForm(string text)
        {
            InitializeComponent();

            lblText.Text = text;
        }
    }
}
