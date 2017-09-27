using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Serialization;

namespace ReportTracer
{
    /// <summary>
    /// This class contains the report information about a device list routing process.
    /// </summary>
    public class JSONReport
    {
        /// <summary>
        /// Builds a standard report.
        /// </summary>
        public JSONReport()
        {
            ORIdentifier = "";
            Timestamp = new DateTime();
            Devices = new List<Host>();
        }

        /// <summary>
        /// Builds a standard report.
        /// </summary>
        /// <param name="or"></param>
        /// <param name="ts"></param>
        /// <param name="devs"></param>
        public JSONReport(string or, DateTime ts, List<Host> devs)
        {
            ORIdentifier = or;
            Timestamp = ts;
            Devices = devs;
        }

        /// <summary>
        /// The OR identifier
        /// </summary>
        public string ORIdentifier { get; set; }

        /// <summary>
        /// A timestamp when this report has been sent.
        /// </summary>
        public DateTime Timestamp { get; set; }

        /// <summary>
        /// The list of devices that involves this report. 
        /// </summary>
        public List<Host> Devices { get; set; }

    }

    /// <summary>
    /// This class defines the basic properties of a Host involved in a
    /// routing trace. 
    /// </summary>
    public class Host
    {
        /// <summary>
        /// The alias of this device
        /// </summary>
        public string Alias { get; set; }
        
        /// <summary>
        /// The hops given to arrive some host. 
        /// A hop is a list of Devices, which have the same Device properties.
        /// </summary>
        public List<Host> Hops { get; set; }
        
        /// <summary>
        /// The host name of a device. This is the name stablished by the network administrator.
        /// </summary>
        public string HostName { get; set; }

        /// <summary>
        /// The IP of this host.
        /// </summary>
        public string IP { get; set; }

        /// <summary>
        /// The time taken to make a ping to this host.
        /// </summary>
        public double Time { get; set; }
    }

    //class Hop : INetworkDevice
    //{
    //    /// <summary>
    //    /// An device alias stablished for this hop
    //    /// </summary>
    //    public string Alias { get; set; }

    //    /// <summary>
    //    /// <see cref="INetworkDevice"/>
    //    /// </summary>
    //    public string HostName { get; set; }

    //    /// <summary>
    //    /// <see cref="INetworkDevice"/>
    //    /// </summary>
    //    public string IP { get; set; }

    //    public float Time { get; set; }
    //}
}
