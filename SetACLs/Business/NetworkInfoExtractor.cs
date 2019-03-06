using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;

namespace SetACLs.Business
{
    public class NetworkInfoExtractor
    {
        public static IEnumerable<string> GetLocalIpAddress()
        {
            return Dns.GetHostEntry(Dns.GetHostName()).AddressList
                .Where(a => a.AddressFamily == AddressFamily.InterNetwork)
                .Select(a => a.ToString());
        }
    }
}
