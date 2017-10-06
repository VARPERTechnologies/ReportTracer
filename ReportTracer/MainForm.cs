
//#define POST_PROCESSING_DEVICE_HOST_NAME

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Diagnostics;
using System.Net.NetworkInformation;
using System.Text.RegularExpressions;
using System.Net.Mail;
using Microsoft.VisualBasic;
using ReportTracer.Properties;
using System.IO;
using System.Threading;
using VRK.Net;

namespace ReportTracer
{
    /// <summary>
    /// The main form window.
    /// </summary>
    public partial class MainForm
    {

        /// <summary>
        /// The type of destination
        /// </summary>
        enum DestinationType 
        {
            ATM,
            BRANCH,
            IP,
            DNS,
            INVALID
        }

        /// <summary>
        /// The type of destination depending on the text inserted. 
        /// </summary>
        DestinationType destType;

        public DevExpress.XtraTreeList.TreeList TreeListControl
        {
            get
            {
                return tlDevicesToRoute;
            }
        }

        delegate void ThreadSwitch();

        /// <summary>
        /// The dynamic textbox.
        /// </summary>
        private DynamicTextFinder txtDestination;

        /// <summary>
        /// A list of tracert object that contents 
        /// </summary>
        private List<VRK.Net.Tracert> tracertList;

        /// <summary>
        /// This timers controls the caption of test button. Basicly controls the time interval the label updates its text
        /// </summary>
        private System.Windows.Forms.Timer tmrUpdateButton;

        /// <summary>
        /// Counts the amount of host found when routing. (Node children count)
        /// </summary>
        private int iAddedHosts;

        /// <summary>
        /// The amount of fields in the table. This constant is for testing purpose so far. I has not been normalized.
        /// </summary>
        private const int FIELDS = 4;

        /// <summary>
        /// The image, container for all icons
        /// </summary>
        ImageList imgList = new ImageList();

        /// <summary>
        /// The amount of routed decives when a trace has started.
        /// </summary>
        int routedDevices;

        /// <summary>
        /// The status of the current operation, true if programs is currently routing.
        /// </summary>
        private bool bRouting;

        /// <summary>
        /// The mail message to send the report.
        /// </summary>
        MailMessage mmReport;

        /// <summary>
        /// The mail client. 
        /// </summary>
        SmtpClient mailClient;

        //Some dialogs 
        OptionsForm of; //Options form
        SendingForm sf; //A form shown when report is sending

        /// <summary>
        /// Contains a list of all devices found in one ATM
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            InitializeCustomComponents();
        }

        /// <summary>
        /// Initializes all customized components inserted manually.
        /// 
        /// </summary>
        private void InitializeCustomComponents()
        {
            txtDestination = new DynamicTextFinder();
            tmrUpdateButton = new System.Windows.Forms.Timer();

            tmrUpdateButton.Interval = 1000;
            tmrUpdateButton.Tick += new EventHandler(UpdateBtnAnimationTick);

            tracertList = new System.Collections.Generic.List<VRK.Net.Tracert>();

            //Start adding images
            imgList.Images.Add(new Bitmap(ReportTracer.Generic.search)); //0
            imgList.Images.Add(new Bitmap(ReportTracer.Generic.Camara_domo)); //1
            imgList.Images.Add(new Bitmap(ReportTracer.Generic.Camara_frontal)); //2
            imgList.Images.Add(new Bitmap(ReportTracer.Generic.Check)); //3
            imgList.Images.Add(new Bitmap(ReportTracer.Generic.DMP)); //4
            imgList.Images.Add(new Bitmap(ReportTracer.Generic.DVR)); //5
            imgList.Images.Add(new Bitmap(ReportTracer.Generic.Gateway)); //6
            imgList.Images.Add(new Bitmap(ReportTracer.Generic.Host_correct)); //7
            imgList.Images.Add(new Bitmap(ReportTracer.Generic.Host_error)); //8
            imgList.Images.Add(new Bitmap(ReportTracer.Generic.Error)); //9
            imgList.Images.Add(new Bitmap(ReportTracer.Generic.add_icon)); //10
            imgList.Images.Add(new Bitmap(ReportTracer.Generic.del_icon)); //11
            
            btnAddHost.ImageList = imgList;
            btnAddHost.ImageIndex = 10;
            btnAddHost.FlatAppearance.BorderSize = 0;
            btnAddHost.FlatStyle = FlatStyle.Flat;
            btnAddHost.Margin = new Padding(0);
            btnAddHost.Padding = new Padding(0); 
            btnAddHost.Text = "";

            btnDelHost.ImageList = imgList;
            btnDelHost.ImageIndex = 11;
            btnDelHost.FlatAppearance.BorderSize = 0;
            btnDelHost.FlatStyle = FlatStyle.Flat;
            btnDelHost.Margin = new Padding(0);
            btnDelHost.Padding = new Padding(0);
            btnDelHost.Text = "";

            txtDestination.TextObj.Font = new Font(txtDestination.TextObj.Font.FontFamily, 8, txtDestination.TextObj.Font.Style);
            txtDestination.LabelObj.Text = "Type to search";
            txtDestination.EnableSearchButton = false;
            txtDestination.Dock = DockStyle.Fill;
            //txtDestination.StartSearch += new DynamicTextFinder.StartSearchHandler(SearchStarted);
            txtDestination.TextChangeEvent += new DynamicTextFinder.TextChangeHandler(OnDestinationChanged);
            txtDestination.TextObj.KeyUp += new KeyEventHandler(OnDestinationKeyUp);
            tableLayoutPanel2.Controls.Add(txtDestination, 0, 0);
            
            tlDevicesToRoute.ColumnsImageList = imgList;
            tlDevicesToRoute.SelectImageList = imgList;
            tlDevicesToRoute.StateImageList = imgList;

            Settings.Default.Reload();

            mmReport = new MailMessage(
                Settings.Default.ReceiverEmail, //It sends itself
                Settings.Default.ReceiverEmail, //It sends itself
                Settings.Default.Subject, 
                "");
            //mmReport.Sender.User = "developmentavant@gmail.com";
          
            mailClient = new SmtpClient(
                Settings.Default.ServerName,
                Settings.Default.Port);

            mailClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            mailClient.UseDefaultCredentials = false;
            mailClient.EnableSsl = Settings.Default.SmtpSecurity.ToLower() == "ssl/tls";
            mailClient.Credentials = new System.Net.NetworkCredential(
                Settings.Default.SmtpUser, Settings.Default.SmtpPass);

            mailClient.Timeout = Settings.Default.SmtpTimeout * 1000;

            startTrace.Enabled = false;
            btnReport.Enabled = false;

            destType = DestinationType.INVALID;
            bRouting = false;
            routedDevices = 0;
            iAddedHosts = 0;
        }

        /// <summary>
        /// When user press enter on the Destination box.
        /// </summary>
        /// <param name="sender">The sender object.</param>
        /// <param name="e">The event arguments.</param>
        private void OnDestinationKeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.Enter:
                    OnAddHostClicked(sender, null);
                    break;
            }
        }

        /// <summary>
        /// When report has been sent.
        /// </summary>
        /// <param name="sender">The sender object.</param>
        /// <param name="e">The event argument.</param>
        private void OnReportSent(object sender, AsyncCompletedEventArgs e)
        {
            if(e.Error != null)
            {
#if DEBUG
                MessageBox.Show("Source: " + e.Error.Source + "\n\rStack trace: " + e.Error.StackTrace + "\n\rMessage: " + e.Error.Message + "\n\rData: " + e.Error.Data.ToString(), "Error");
#else
                LogError(e.Error);
                MessageBox.Show("There were problems sending the report. \r\nContact administrator for support.", "Error sending report");
#endif
            }

            if (sf != null)
            {
                //sf.lblText.Text = "Sent sucessfully";
                //System.Threading.Thread.Sleep(1000);
                sf.Close();
            }
        }

        /// <summary>
        /// When destination text has changed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="str"></param>
        private void OnDestinationChanged(TextBox sender, string str)
        {
            try
            {
                if (str.Length != 0)
                {

                    string
                        //strDNSRegex = "\\b((?=[a-z0-9-]{1,63}\\.)[a-z0-9]+(-[a-z0-9]+)*\\.)+[a-z]{2,63}\\b", //Domain name RegEx
                        strDNSRegex = "\\b^((?=[a-z0-9-]{1,63}\\.)[a-z0-9]+(-[a-z0-9]+)*\\.)+[a-z]{2,63}$\\b", //Domain name RegEx

                        //This regular expressions only validate IPv4
                        //strIPRegex = "\\b(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\\.){3}(?:25[0 - 5] | 2[0 - 4][0 - 9] |[01]?[0 - 9][0 - 9] ?)\\b";
                        //strIPRegex = "\\b(?:(?:25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9]?[0-9])\\.){3}(?:25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9]?[0-9])\\b";
                        strIPRegex = "\\b^(25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9]?[0-9])\\.(25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9]?[0-9])\\.(25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9]?[0-9])\\.(25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9]?[0-9])$\\b";

                    Regex
                        DNSReg = new Regex(strDNSRegex, RegexOptions.IgnoreCase),
                        IPReg = new Regex(strIPRegex, RegexOptions.IgnoreCase);

                    txtDestination.LabelObj.ForeColor = Color.Black;
                    if (DNSReg.IsMatch(str)) //Check for DNS
                    {
                        destType = DestinationType.DNS;
                        txtDestination.LabelObj.Text = "Domain name";
                    }
                    else if (IPReg.IsMatch(str)) //Check for IP
                    {
                        destType = DestinationType.IP;
                        txtDestination.LabelObj.Text = "IP";
                    }
                    else
                    {
                        txtDestination.LabelObj.ForeColor = Color.Red;
                        txtDestination.LabelObj.Text = "Invalid";
                    }
                }
                else
                {
                    txtDestination.LabelObj.Text = "Type to search";
                }
            }
            catch (Exception e)
            {
                //System.Diagnostics.Debug.WriteLine(e.Message);
                LogError(e);
            }
        }
        
        /// <summary>
        /// Just close the application.
        /// </summary>
        /// <param name="sender">The sender object.</param>
        /// <param name="e">The event arguments.</param>
        private void Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Thrown when user has started the tracing process.
        /// </summary>
        /// <param name="sender">The sender object.</param>
        /// <param name="e">The event arguments</param>
        private void StartTrace_Click(object sender, EventArgs e)
        {
            //Reload settings in case some change
            Settings.Default.Reload();

            int devices = tlDevicesToRoute.Nodes.Count;

            if (devices < 1) return; //Nothing to do with no devices.

            if(bRouting)
            {
                //foreach(Tracert t in tracertList) //Stops and remove each event handler. 
                //{
                //    t.Stop();
                //    t.Done -= tracert_Done;
                //    t.HostNotFound -= OnHostNotFound;
                //    t.RouteNodeFound -= tracert_RouteNodeFound;
                //}
                //tmrUpdateButton.Stop();
                //UpdateOnDone();

                StopTrace();

                return;
            }

            bRouting = true;
            tmrUpdateButton.Start();
            btnAddHost.Enabled = false;
            btnDelHost.Enabled = false;
            startTrace.Text = "Routing";
            txtDestination.Enabled = false;
            btnReport.Enabled = false;
            routeList.Items.Clear();

            for (int i = 0; i < devices; i++)
            {
                //Initializes each Tracert object and attach the associated event handlers.
                try
                {
                    tracertList.Add(new VRK.Net.Tracert());
                    tracertList[i].DeviceAlias = tlDevicesToRoute.Nodes[i].GetValue(0).ToString();
                    tracertList[i].MaxHops = Settings.Default.Hops;
                    tracertList[i].TimeOut = Settings.Default.Timeout * 1000;
                    tracertList[i].Done += new System.EventHandler(this.tracert_Done);
                    tracertList[i].HostNotFound += new VRK.Net.Tracert.HostNotFoundHandler(OnHostNotFound);
                    tracertList[i].RouteNodeFound += new System.EventHandler<VRK.Net.RouteNodeFoundEventArgs>(this.tracert_RouteNodeFound);

                    if(tlDevicesToRoute.Nodes[i].GetValue(1).ToString() == "")
                    {
                        tracertList[i].HostNameOrAddress = tlDevicesToRoute.Nodes[i].GetValue(2).ToString();
                    }
                    else
                    {
                        tracertList[i].HostNameOrAddress = tlDevicesToRoute.Nodes[i].GetValue(1).ToString();
                    }


                    tlDevicesToRoute.Nodes[i].SetValue(0, tlDevicesToRoute.Nodes[i].GetValue(0).ToString());
                    tlDevicesToRoute.Nodes[i].SetValue(1, tlDevicesToRoute.Nodes[i].GetValue(1).ToString());
                    tlDevicesToRoute.Nodes[i].Nodes.Clear();
                    
                    tracertList[i].Trace();
                }
                catch (SocketException ex)
                {
                    //MessageBox.Show(ex.Message, "Trama de ping");
                    //tlRoutes.Nodes[i].SetValue(0, tlRoutes.Nodes[i].GetDisplayText(0) + " (Unreachable)");
                    tlDevicesToRoute.Nodes[i].SetValue(0, tlDevicesToRoute.Nodes[i].GetValue(1).ToString() + " (Unreachable)");

                    if (i == devices - 1)
                    {
                        tracert_Done(null, null); 
                    }

                    LogError(ex);
                }
            }
        }

        /// <summary>
        /// Thrown when a device can't be reached when pinging it.
        /// </summary>
        /// <param name="element">The routed element.</param>
        private void OnHostNotFound(Tracert element)
        {
            //Update the device label to an unreachable state.
            UpdateHostLabelCaption(element);

            //Check if all devices has been routed.
            if (++routedDevices == tracertList.Count)
            {
                tracert_Done(null, null);
            }
        }

        /// <summary>
        /// The related delegate that updates the label of a device. A delegate must be used because
        /// the event signaled to update the label because it is thrown from a different thread.
        /// </summary>
        /// <param name="element">The source Tracert element.</param>
        delegate void UpdateLabelCallback(Tracert element);

        /// <summary>
        /// Updates each host label. This is called as an assyncronous functions. 
        /// <see cref="UpdateLabelCallback"/>
        /// </summary>
        /// <param name="element">The associated routed element. </param>
        private void UpdateHostLabelCaption(Tracert element)
        {
            int devices = tracertList.Count;
            for (int i = 0; i < devices; i++)
            {
                if (element == tracertList[i])
                {
                    if(tlDevicesToRoute.InvokeRequired)
                    {
                        UpdateLabelCallback ulc = new UpdateLabelCallback(UpdateHostLabelCaption);
                        this.Invoke(ulc, new object[] { element });
                    }else
                    {
                        tlDevicesToRoute.Nodes[i].SetValue(0, tlDevicesToRoute.Nodes[i].GetValue(0).ToString() + " (Unreachable)");
                    }
                    break;
                }
            }
        }


        /// <summary>
        /// Thrown when user is trying to add a device to route.
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e">The event arguments</param>
        private void OnAddHostClicked(object sender, EventArgs e)
        {
            try
            {
                string
                    strHost = "Host" + Convert.ToString(iAddedHosts),
                    strDNS = txtDestination.Text.ToLower();

                switch (destType)
                {
                    case DestinationType.DNS:
                        {
                            object[] hostItem = new object[FIELDS]
                            {
                                strHost, "", strDNS, ""
                            };

                            tlDevicesToRoute.AppendNode(hostItem, -1, 0, 0, -1);

                            //object[] columnStrings = new object[FIELDS];
                            //columnStrings[0] = strHost;
                            //columnStrings[1] = "";
                            //columnStrings[2] = strDNS;
                            //columnStrings[3] = "-";

                            //tlRoutes.AppendNode(columnStrings, -1, 0, 0, -1);

                            iAddedHosts++;
                            break;
                        }
                    case DestinationType.IP:
                        {
                            string strIP = txtDestination.Text;
                            
                            //string strHost = "Host" + Convert.ToString(iAddedHosts);
                            
                            object[] columnStrings = new object[FIELDS];
                            columnStrings[0] = strHost;
                            columnStrings[1] = strIP;
                            columnStrings[2] = "-";

                            tlDevicesToRoute.AppendNode(columnStrings, -1, 0, 0, -1);

                            iAddedHosts++;
                            break;
                        }
                    case DestinationType.INVALID:
                    default:
                        throw new FormatException();
                }


                if(tlDevicesToRoute.Nodes.Count > 0)
                {
                    startTrace.Enabled = true;
                }

            }
            catch (FormatException /*e*/)
            {
                MessageBox.Show("Must insert a valid host destination", "Format error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Parses a determined string with an IP format.
        /// Note: the IPAddress.TryParse or IPAddress.Parse function is really weak to parse strings with an IP format.
        /// Because of it, decided to implement my own function.
        /// </summary>
        /// <param name="strIP">The string that contains the IP.</param>
        /// <returns>True in case <paramref name="strIP"/> is a corret IPv4 format.</returns>
        private bool ParseIP(string strIP)
        {
            string[] segments = strIP.Split('.');
            //bool checkResult = false;
            if (segments.Length != 4) return false;

            foreach(string segment in segments)
            {
                try
                {
                    Convert.ToByte(segment);
                    //return true;
                }
                catch (Exception e)
                {
                    LogError(e);
                    return false;
                }
            }
            //When end of for loop is reached the validation is done
            return true;
        }

        /// <summary>
        /// Thrown when user has tried to remove a device.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnRemoveHostClicked(object sender, EventArgs e)
        {
            DevExpress.XtraTreeList.Nodes.TreeListNode item;

            for(int i = 0; i < tlDevicesToRoute.Selection.Count; i++)
            {
                item = tlDevicesToRoute.Selection[i];
                if (item.Level == 0) //So far, only root items can be droped
                {
                    tlDevicesToRoute.DeleteNode(item);
                }
            }

            if (tlDevicesToRoute.Nodes.Count == 0)
            {
                btnReport.Enabled = false;
                startTrace.Enabled = false;
            }
        }

        /// <summary>
        /// Updates the routed-devices list. This is done based on the devices-to-route list. Basicly a copy of it.
        /// </summary>
        //private void UpdateRoutedDevicesList()
        //{
        //    tlDevicesToRoute.Nodes.Clear();
        //    int devices = tlDevicesToRoute.Nodes.Count;
        //    for (int i = 0; i < devices; i++)
        //    {
        //        object[] columnStrings = new object[FIELDS];
        //        columnStrings[0] = tlDevicesToRoute.Nodes[i].GetValue(0);
        //        columnStrings[1] = tlDevicesToRoute.Nodes[i].GetValue(1);
        //        columnStrings[2] = "-";

        //        int img = tlDevicesToRoute.Nodes[i].ImageIndex;
        //        tlDevicesToRoute.AppendNode(columnStrings, -1, img, img, -1);
        //    }
        //}

        /// <summary>
        /// Thrown when an intermediate host has been found. This is interpreted as a HOP.
        /// </summary>
        /// <param name="ar">The result of the routing operation</param>
        private void OnGetHostEntry(IAsyncResult ar)
        {
            try
            {
                ListViewItem.ListViewSubItem hostNameItem = ar.AsyncState as ListViewItem.ListViewSubItem;
                ThreadSwitch delg = delegate
                {
                    hostNameItem.Text = Dns.EndGetHostEntry(ar).HostName;
                };

                this.Invoke(delg);
            }
            catch (SocketException ex)
            {
                //Trace.WriteLine(ex.ToString());
                LogError(ex);
            }
        }
        //static int requestCounter = 0;

        /// <summary>
        /// This slot catch when a node has found. This can be iterpreted as a HOP.
        /// </summary>
        /// <param name="sender">The sender element. This is a Tracert object, so must be explcitly converted before operate it.</param>
        /// <param name="e">The event arguments.</param>
        private void tracert_RouteNodeFound(object sender, VRK.Net.RouteNodeFoundEventArgs e)
        {
            VRK.Net.Tracert tSender = (VRK.Net.Tracert)sender;
            
            int devices = tlDevicesToRoute.Nodes.Count;
            //int hostCounter = 0;

            //DevExpress.XtraTreeList.Nodes.TreeListNode addedNode;

            for (int i = 0; i < devices; i++)
            {

                if(tracertList[i] == tSender)
                {

                    object[] columnStrings = new object[FIELDS];
                    columnStrings[0] = "Host " + Convert.ToString(tlDevicesToRoute.Nodes[i].Nodes.Count + 1);

                    int nodeID = tlDevicesToRoute.Nodes[i].Id;
                    if (e.Node.Status == IPStatus.Success)
                    {
                        columnStrings[1] = e.Node.Address.ToString();
                        columnStrings[2] = ""; //todo: replace this with the correct host name of the respective ip
                        columnStrings[3] = e.Node.RoundTripTime;

#if POST_PROCESSING_DEVICE_HOST_NAME

                        try
                        {
                            addedNode = tlDevicesToRoute.AppendNode(columnStrings, nodeID, 7, 7, -1); //Sometimes throws an exception. This to avoid it
                        }
                        catch (Exception)
                        {
                            addedNode = null;
                        }

                        //Begins the postprocessing for Host name
                        
                        Dns.BeginGetHostEntry(e.Node.Address, delegate (IAsyncResult ar)
                            {
                                if (ar.IsCompleted)
                                {
                                    DevExpress.XtraTreeList.Nodes.TreeListNode pNode = ar.AsyncState as DevExpress.XtraTreeList.Nodes.TreeListNode;

                                    if(pNode != null)
                                    {
                                        try
                                        {
                                            pNode.SetValue(2, Dns.EndGetHostEntry(ar).HostName);
                                        }
                                        catch (Exception)
                                        {
                                            try //Sometimes throws NullPointerException when a task is running and press "Test" again
                                            {
                                                pNode.SetValue(2, "-");
                                            }
                                            catch (Exception)
                                            {

                                            }
                                        }
                                    }
                                }

                                Interlocked.Decrement(ref requestCounter);
                            }, addedNode);
#else
                        tlDevicesToRoute.AppendNode(columnStrings, nodeID, 7, 7, -1); //Sometimes throws an exception. This to avoid it
#endif
                    }
                    else
                    {
                        columnStrings[1] = "*";
                        columnStrings[2] = "";
                        columnStrings[3] = "Time out";

                        try
                        {
                            tlDevicesToRoute.AppendNode(columnStrings, nodeID, 8, 8, -1); //Sometimes throw exception when running a background delegate
                        }
                        catch (Exception)
                        {

                        }
                    }
                }
            }
        }
        
        /// <summary>
        /// Thrown when a device routing has been finished.
        /// </summary>
        /// <param name="sender">The device sender.</param>
        /// <param name="e">The associated event arguments</param>
        private void tracert_Done(object sender, EventArgs e)
        {
            //Checks if all devices has been routed
            if (++routedDevices >= tracertList.Count)
            {
                UpdateOnDone();
            }
        }

        /// <summary>
        /// Updates the form status when routing has been finished. This means the labels,
        /// and variable's status.
        /// </summary>
        private void UpdateOnDone()
        {
            ThreadSwitch delg = delegate
            {
                //startTrace.Enabled = true;
                tmrUpdateButton.Enabled = false;
                startTrace.Text = "Test";
                txtDestination.Enabled = true;
                routedDevices = 0;
                tracertList.Clear();
                bRouting = false;
                btnReport.Enabled = true;
            };

            this.Invoke(delg);
        }

        /// <summary>
        /// Generate the device list associated to a ATM number. 
        /// </summary>
        /// <param name="n">The ATM number.</param>
        private void GenerateATMDeviceList(int n)
        {
            //Start generating Device IP list

            /*
             * IP Format consist in following rules
             * Remote ATM Number: ABCD (Where each character represents a digit)
             * 
             * 10.1AB.CD.222 -> Gateway
             * 10.1AB.CD.197 -> Site Cam
             * 10.1AB.CD.198 -> Facial Cam
             * 10.1AB.CD.199 -> NVR
             * 10.1AB.CD.200 -> Alarm
             * 
             */

            /*
             * Digits
             * To obtain digits we first convert the current number to an string to split it by characters
             */
            String
                strNumber = Convert.ToString(n),
                strGatewayIP,
                strSiteCamIP,
                strFascialCamIP,
                strNVRIP,
                strAlarmIP,
                A = "",
                B = "",
                C = "",
                D = "";
            
            //Get each digit
            try
            {
                A = strNumber.ToCharArray()[0].ToString();
                B = strNumber.ToCharArray()[1].ToString();
                C = strNumber.ToCharArray()[2].ToString();
                D = strNumber.ToCharArray()[3].ToString();
            }
            catch (IndexOutOfRangeException /*e*/)
            {
                //A = "";
                B = strNumber.ToCharArray()[0].ToString();
                C = strNumber.ToCharArray()[1].ToString();
                D = strNumber.ToCharArray()[2].ToString();
            }
            catch(Exception e)
            {
                MessageBox.Show("Ocurrió un problema desconocido al generar la lista de IPs.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError(e);
            }

            //After getting each digit and forming the IP Address
            //We should confirm the IP is in the correct format
            //This means a valid IP Range 
            strGatewayIP = "10.1" + A + B + "." + C + D + ".222";
            strSiteCamIP = "10.1" + A + B + "." + C + D + ".197";
            strFascialCamIP = "10.1" + A + B + "." + C + D + ".198";
            strNVRIP = "10.1" + A + B + "." + C + D + ".199";
            strAlarmIP = "10.1" + A + B + "." + C + D + ".200";

            //Due the IP format is the same for all IPs and only varies in the last segment (which is constant)
            //We can just check one of the IPs

            //NOTE: After all I just noticed IPs will always be correct.
            //I left it for information purposes only
            //if (!IPAddress.TryParse(strGatewayIP, out GatewayIP))
            //{
            //    MessageBox.Show("Inserte rangos de números correctos, la generacion de las IPs falló.", "Error en formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}

            //tlDevicesToRoute.Nodes.Clear();
            const int TO_ROUTE_DEVICES = 2;
            object[]
                gwData = new object[TO_ROUTE_DEVICES]
                {
                    "Gateway", strGatewayIP
                },
                scData = new object[TO_ROUTE_DEVICES]
                {
                    "Site camera", strSiteCamIP
                },
                fcData = new object[TO_ROUTE_DEVICES]
                {
                    "Facial camera", strFascialCamIP
                },
                nvrData = new object[TO_ROUTE_DEVICES]
                {
                    "NVR", strNVRIP
                },
                alarmData = new object[TO_ROUTE_DEVICES]
                {
                    "Alarm", strAlarmIP
                };

            tlDevicesToRoute.AppendNode(gwData, - 1, 6, 6, -1);
            tlDevicesToRoute.AppendNode(scData, -1, 1, 1, -1);
            tlDevicesToRoute.AppendNode(fcData, -1, 2, 2, -1);
            tlDevicesToRoute.AppendNode(nvrData, -1, 5, 5, -1);
            tlDevicesToRoute.AppendNode(alarmData, -1, 4, 4, -1);
        }

        /// <summary>
        /// Generate the device list associated to a ATM number. 
        /// </summary>
        /// <param name="n">The ATM number.</param>
        private void GenerateBranchDeviceList(int n)
        {
            //Start generating Device IP list

            /*
             * IP Format consist in following rules
             * Branch Number: ABC (Where each character represents a digit)
             * 
             * 10.1AB.1C2.222 -> Gateway
             * 10.1AB.1C2.197 -> Site Cam
             * 10.1AB.1C2.198 -> Facial Cam
             * 10.1AB.1C2.199 -> NVR
             * 10.1AB.1C2.200 -> Alarm
             * 
             */

            /*
             * Digits
             * To obtain digits we first convert the current number to an string to split it by characters
             */
            String
                strNumber = Convert.ToString(n),
                strGatewayIP,
                strSiteCamIP,
                strFascialCamIP,
                strNVRIP,
                strAlarmIP,
                A = "",
                B = "",
                C = "";

            //Get each digit
            try
            {
                A = strNumber.ToCharArray()[0].ToString();
                B = strNumber.ToCharArray()[1].ToString();
                C = strNumber.ToCharArray()[2].ToString();
            }
            catch (Exception e)
            {
                MessageBox.Show("Ocurrió un problema desconocido al generar la lista de IPs.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError(e);
            }

            //After getting each digit and forming the IP Address
            //We should confirm the IP is in the correct format
            //This means a valid IP Range 
            strGatewayIP = "10.1" + A + B + ".1" + C + "2.190";
            strSiteCamIP = "10.1" + A + B + ".1" + C + "2.160";
            strFascialCamIP = "10.1" + A + B + ".1" + C + "2.150";
            strNVRIP = "10.1" + A + B + ".1" + C + "2.140";
            strAlarmIP = "10.1" + A + B + ".1" + C + "2.130";

            //Due the IP format is the same for all IPs and only varies in the last segment (which is constant)
            //We can just check one of the IPs

            //NOTE: After all I just noticed IPs will always be correct.
            //I left it for information purposes only
            //if (!IPAddress.TryParse(strGatewayIP, out GatewayIP))
            //{
            //    MessageBox.Show("Inserte rangos de números correctos, la generacion de las IPs falló.", "Error en formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}

            //tlDevicesToRoute.Nodes.Clear();
            const int TO_ROUTE_DEVICES = 2;
            object[]
                gwData = new object[TO_ROUTE_DEVICES]
                {
                    "Gateway", strGatewayIP
                },
                scData = new object[TO_ROUTE_DEVICES]
                {
                    "Site camera", strSiteCamIP
                },
                fcData = new object[TO_ROUTE_DEVICES]
                {
                    "Facial camera", strFascialCamIP
                },
                nvrData = new object[TO_ROUTE_DEVICES]
                {
                    "NVR", strNVRIP
                },
                alarmData = new object[TO_ROUTE_DEVICES]
                {
                    "Alarm", strAlarmIP
                };

            tlDevicesToRoute.AppendNode(gwData, -1, 6, 6, -1);
            tlDevicesToRoute.AppendNode(scData, -1, 1, 1, -1);
            tlDevicesToRoute.AppendNode(fcData, -1, 2, 2, -1);
            tlDevicesToRoute.AppendNode(nvrData, -1, 5, 5, -1);
            tlDevicesToRoute.AppendNode(alarmData, -1, 4, 4, -1);
        }

        /// <summary>
        /// The timer who controls the animation of the test button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateBtnAnimationTick(object sender, EventArgs e)
        {
            int ellipsisCount = startTrace.Text.Split('.').Length - 1;
            if (ellipsisCount < 3)
            {
                startTrace.Text += ".";
            }
            else
            {
                startTrace.Text = "Routing";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnReport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            JSONReport report = new JSONReport()
            {
                Devices = new List<Host>()
            };

            foreach (DevExpress.XtraTreeList.Nodes.TreeListNode n in tlDevicesToRoute.Nodes)
            {
#pragma warning disable IDE0017 // Simplify object initialization
                Host h = new Host();
#pragma warning restore IDE0017 // Simplify object initialization

                //string 
                //    strAlias = n.GetValue(0) != null ? n.GetValue(0).ToString() : "",
                //    strIP = n.GetValue(1) != null ? n.GetValue(1).ToString() : "",
                //    strHName = n.GetValue(2) != null ? n.GetValue(2).ToString() : "",
                //    strTime = n.GetValue(3) != null ? n.GetValue(3).ToString() : "";
                //double dTime = strTime != null ? Convert.ToDouble(strTime) : -1;

                //Sometimes throw NullPointerException, depending on the TreeList initialization
                h.Alias = n.GetValue(0) != null ? n.GetValue(0).ToString() : "";
                h.IP = n.GetValue(1) != null ? n.GetValue(1).ToString() : "";
                h.HostName = n.GetValue(2) != null ? n.GetValue(2).ToString() : "";
                try
                {
                    h.Time = n.GetValue(3) != null ? Convert.ToDouble(n.GetValue(3).ToString()) : -1;
                }
                catch (FormatException /*fe*/)
                {
                    h.Time = -1;
                }

                if (n.Nodes.Count > 0)
                {
                    h.Hops = new List<Host>();
                    foreach (DevExpress.XtraTreeList.Nodes.TreeListNode hnode in n.Nodes)
                    {
                        Host hop = new Host();
                        hop.Alias = hnode.GetValue(0) != null ? hnode.GetValue(0).ToString() : "";
                        hop.IP = hnode.GetValue(1) != null ? hnode.GetValue(1).ToString() : "";
                        hop.HostName = hnode.GetValue(2) != null ? hnode.GetValue(2).ToString() : "";
                        try
                        {
                            hop.Time = hnode.GetValue(3) != null ? Convert.ToDouble(hnode.GetValue(3).ToString()) : -1;
                        }
                        catch (FormatException /*fe*/)
                        {
                            hop.Time = -1;
                        }

                        h.Hops.Add(hop);
                    }
                    
                }
                report.Devices.Add(h);

            }

            report.Timestamp = DateTime.Now;
           
            string serialized = Newtonsoft.Json.JsonConvert.SerializeObject(report);
            StartSend(serialized);
        }

        /// <summary>
        /// Send this report to the default configuration receiver.
        /// </summary>
        /// <param name="body">The body of the email.</param>
        public void StartSend(string body)
        {
            Settings.Default.Reload();

            mailClient.Host = Settings.Default.ServerName;
            mailClient.Port = Settings.Default.Port;
            mailClient.EnableSsl = Settings.Default.SmtpSecurity.ToLower() == "ssl/tls";
            mailClient.Credentials = new System.Net.NetworkCredential(
                Settings.Default.SmtpUser,
                Settings.Default.SmtpPass);

            mailClient.Timeout = Settings.Default.SmtpTimeout * 1000;
            mailClient.SendCompleted += new SendCompletedEventHandler(OnReportSent);
            mmReport.Body = body;

            try
            {
                mailClient.SendAsync(mmReport, null);

                if (sf == null) sf = new SendingForm();

                sf.lblText.Text = Settings.Default.ReceiverEmail;
                sf.ShowDialog();
            }
            catch(System.Net.Mail.SmtpException e)
            {
                MessageBox.Show("Can not find the email server", "Mail error");
                LogError(e);
            }
            catch (Exception e)
            {
                LogError(e);
            }

        }

        private static void LogError(Exception e)
        {
            string logFile = "";
            //Try to create a log file to report the errors.
            try
            {
                logFile = Directory.GetCurrentDirectory() + "\\log.txt";
                if (!File.Exists(logFile))
                {
                    FileStream fs = File.Create(logFile);
                    fs.Close();
                }

                File.AppendAllText(logFile, DateTime.Now.ToString() + ":\r\n" + e.Message);
                Console.Error.WriteLine(DateTime.Now.ToString() + ":\r\n" + e.Message);
                Debug.WriteLine(e.Message);
            }
            catch (UnauthorizedAccessException /*ex*/)
            {
                logFile = Environment.GetEnvironmentVariable("USERPROFILE") + "\\AppData\\Roaming\\ReportTracer\\log.txt";

                if(!Directory.Exists(Path.GetDirectoryName(logFile)))
                {

                    Directory.CreateDirectory(Path.GetDirectoryName(logFile));
                    FileStream fs = File.Create(logFile);
                    fs.Close();

                }else if (!File.Exists(logFile))
                {

                    FileStream fs = File.Create(logFile);
                    fs.Close();

                }

                File.AppendAllText(logFile, DateTime.Now.ToString() + ":\r\n" + e.Message);
                Console.Error.WriteLine(DateTime.Now.ToString() + ":\r\n" + e.Message);
                Debug.WriteLine(e.Message);

                //If can not create the log file the applications must be stopped.
                //Console.Error.WriteLine("Can not create the log file: " + logFile);
                //Console.Error.WriteLine(ex.Message);
                //Debug.WriteLine(ex.Message);
                //LogError(e);
            }
            finally
            {
                MessageBox.Show("A unexpected error has ocurred", "Critical error");
                Console.Error.WriteLine(DateTime.Now.ToString() + ":\r\n" + e.Message);
                Debug.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// Log string in all possible outputs. 
        /// This means the error stream, the common console and debug console if Debugging, and finally the log file.
        /// </summary>
        /// <param name="e">String to log</param>
        private static void LogError(string e)
        {
            string logFile = "";

            //Try to create a log file to report the errors.
            try
            {
                logFile = Environment.GetEnvironmentVariable("USERPROFILE") + "\\AppData\\Roaming\\ReportTracer\\log.txt";
                if (!File.Exists(logFile))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(logFile));
                    FileStream fs = File.Create(logFile);
                    fs.Close();
                }

                File.AppendAllText(logFile, "\r\n" + DateTime.Now.ToString() + ":\r\n" + e);
                Console.WriteLine("\r\n" + DateTime.Now.ToString() + ":\r\n" + e);
                Console.Error.WriteLine("\r\n" + DateTime.Now.ToString() + ":\r\n" + e);
                Debug.WriteLine(e);
            }
            catch (Exception /*ex*/)
            {
                //If can not create the log file the applications must be stopped.
                //EventLog el = new EventLog("MailParserEventLog");

                //Console.WriteLine("Can not create the log file: " + logFile);
                //Console.Error.WriteLine("Can not create the log file: " + logFile);
                //Console.Error.WriteLine(ex.Message);
                //Debug.WriteLine(ex.Message);
                //LogError(ex);
            }
        }

        /// <summary>
        /// When user request for Options form.
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e">The event arguments</param>
        private void btnOptions_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            of = new OptionsForm();

            if(of.ShowDialog() == DialogResult.OK)
            {
                Properties.Settings.Default.Reload();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnKeyUp(object sender, KeyEventArgs e)
        {
            switch(e.KeyData)
            {
                case Keys.Delete:
                    OnRemoveHostClicked(sender, null);
                    break;
            }
        }

        /// <summary>
        /// Stops tracing process
        /// </summary>
        private void StopTrace()
        {
            foreach (Tracert t in tracertList) //Stops and remove each event handler. 
            {
                t.Stop();
                t.Done -= tracert_Done;
                t.HostNotFound -= OnHostNotFound;
                t.RouteNodeFound -= tracert_RouteNodeFound;
            }
            
            //foreach(AsyncCallback a in acbList)
            //{
                
            //}

            //acbList.Clear();

            tmrUpdateButton.Stop();
            UpdateOnDone();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            StopTrace();
        }

        private void tabFormControl1_Click(object sender, EventArgs e)
        {

        }

        private void btnAbout_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            AboutBox ab = new AboutBox();

            ab.ShowDialog();
        }
    }   
}