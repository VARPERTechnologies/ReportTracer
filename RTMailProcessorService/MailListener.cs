using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.ServiceProcess;
using System.Text;

namespace RTMailProcessorService
{
    public partial class MailListener : ServiceBase
    {
        public MailListener()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {

        }

        protected override void OnStop()
        {
        }

#if DEBUG
        private void OnDebugStart()
        {
            OnStart(null);
        }
#endif
    }
}
