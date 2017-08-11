using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TracertDemo
{
    /// <summary>
    /// An standard network device definition for reporting purpose.
    /// </summary>
    public interface INetworkDevice
    {

        /// <summary>
        /// The host name. This is de name stablished for the network administrator, if something.
        /// </summary>
        string HostName { get; set; }

        /// <summary>
        /// The IP for this device
        /// </summary>
        string IP { get; set; }

        /// <summary>
        /// The time taken to make a ping
        /// </summary>
        float Time { get; set; }
    }
}
