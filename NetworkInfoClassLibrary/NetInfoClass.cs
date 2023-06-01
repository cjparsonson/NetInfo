// Using Statments
using System.Data.Common;
using System.Net;
using System.Net.NetworkInformation;


// Namespace and Class definitions
namespace NetworkInfo.Shared;

public class NetInfoClass
{
    // Get local machine hostname
    public static readonly string hostname = Dns.GetHostName();
        
    // Get all local NICs
    public static readonly NetworkInterface[] interfaces = NetworkInterface.GetAllNetworkInterfaces();

    // Get current DNS entries for the local machine
    public readonly IPAddress[] dnsAddresses = Dns.GetHostAddresses(hostname);

    internal List<string> GetIPv4Addreses() 
    {
        List<string> IPv4Addresses = new List<string>();
        foreach (NetworkInterface iface in interfaces)
        {
            if (iface.NetworkInterfaceType == NetworkInterfaceType.Ethernet || iface.NetworkInterfaceType == NetworkInterfaceType.Wireless80211) // Select only ethernet and WiFi
            {
                IPInterfaceProperties properties = iface.GetIPProperties();
                IPv4Addresses.Add($"Adapter Name: {iface.Description} \nIPv4 Address: {properties.UnicastAddresses[1].Address}\n"); // [1] gets IPv4 [0] Gets IPv6
            }
        }
        return IPv4Addresses;
    }

    internal List<string> GetDNSServers()
    {
        List<string> dnsServers = new List<string>();
        foreach(NetworkInterface iface in interfaces)
        {
            if (iface.NetworkInterfaceType == NetworkInterfaceType.Ethernet || iface.NetworkInterfaceType == NetworkInterfaceType.Wireless80211)
            {
                IPInterfaceProperties properties = iface.GetIPProperties();
                IPAddressCollection dnsServerAddresses = properties.DnsAddresses;
                foreach (IPAddress address in dnsServerAddresses)
                {
                    if (address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                    {
                        dnsServers.Add(address.ToString());
                    }
                    
                }
            }
        }
       // Remove duplicates
       return dnsServers.Distinct().ToList();
    }
}

    
