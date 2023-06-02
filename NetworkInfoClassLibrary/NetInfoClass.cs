// Using Statments
using System.Data.Common;
using System.Net;
using System.Net.NetworkInformation;
using System.Security.Cryptography.X509Certificates;


// Namespace and Class definitions
namespace NetworkInfo.Shared;

public class NetInfoClass
{
    // local machine hostname field
    public readonly string hostname; 

    // all local NICs field
    public readonly NetworkInterface[] interfaces; 

    // current DNS entries for the local machine field
    public readonly IPAddress[] dnsAddresses; 

    // Constructors
    public NetInfoClass()
    {
        hostname = Dns.GetHostName();
        interfaces = NetworkInterface.GetAllNetworkInterfaces();
        dnsAddresses = Dns.GetHostAddresses(hostname);
    }

    private List<string> GetIPv4Addreses() 
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

    private List<string> GetDNSServers()
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
    
    // Properties
    public List<string> Ipv4List => GetIPv4Addreses();
    public List<string> DNSServerList => GetDNSServers();
    
}

    
