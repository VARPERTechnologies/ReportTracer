using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Text.RegularExpressions;

namespace ReportTracer
{
    public partial class OptionsForm : Form
    {
        public OptionsForm()
        {
            InitializeComponent();
            InitializeCustomComponent();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            //Email tab
            Properties.Settings.Default.ServerName = txtServerName.Text;
            Properties.Settings.Default.Port = (int) sePort.Value;
            Properties.Settings.Default.SmtpSecurity = cbSecurity.Text;
            Properties.Settings.Default.SmtpUser = txtUser.Text;
            Properties.Settings.Default.SmtpPass = txtPassword.Text;
            Properties.Settings.Default.ReceiverEmail = txtEmailReceiver.Text;
            Properties.Settings.Default.Subject = txtSubject.Text;
            Properties.Settings.Default.SmtpTimeout = (int) seSMTPTimeout.Value;

            //Route tab
            Properties.Settings.Default.Timeout = (int) seTimeout.Value;
            Properties.Settings.Default.Hops = (int) seHops.Value;

            //The current tab
            Properties.Settings.Default.CurrentTab = tabMain.SelectedIndex;

            Properties.Settings.Default.Save();

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void InitializeCustomComponent()
        {
            Properties.Settings.Default.Reload();

            //Email tab
            txtServerName.Text = Properties.Settings.Default.ServerName;
            sePort.Value = Properties.Settings.Default.Port;
            cbSecurity.Text = Properties.Settings.Default.SmtpSecurity;
            txtUser.Text = Properties.Settings.Default.SmtpUser;
            txtPassword.Text = Properties.Settings.Default.SmtpPass;
            txtEmailReceiver.Text = Properties.Settings.Default.ReceiverEmail;
            txtSubject.Text = Properties.Settings.Default.Subject;
            seSMTPTimeout.Value = Properties.Settings.Default.SmtpTimeout;

            //Route tab
            seTimeout.Value = Properties.Settings.Default.Timeout;
            seHops.Value = Properties.Settings.Default.Hops;

            //The current tab
            tabMain.SelectedIndex = Properties.Settings.Default.CurrentTab;
        }
    }
}
