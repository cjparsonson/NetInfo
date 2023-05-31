using System.Data.Common;
using System.Net;
using System.Net.NetworkInformation;
using NetworkInfo.Shared;

/*String hostname = Dns.GetHostName(); // Get device hostname
IPAddress[] addresses = Dns.GetHostAddresses(hostname); // Get all DNS entries for this hostname
NetworkInterface[] interfaces = NetworkInterface.GetAllNetworkInterfaces(); // Get local device NICs


WriteLine($"Hostname: {hostname}");
WriteLine();
foreach (NetworkInterface adapter in interfaces)
{
    IPInterfaceProperties properties = adapter.GetIPProperties();
    if (adapter.NetworkInterfaceType == NetworkInterfaceType.Ethernet || adapter.NetworkInterfaceType == NetworkInterfaceType.Wireless80211 && adapter.OperationalStatus == OperationalStatus.Up)
    {
        IPv4InterfaceProperties IPv4 = properties.GetIPv4Properties();
        WriteLine($"Name: {adapter.Description} \nIP: {properties.UnicastAddresses[1].Address}" + // UnicastAddresses[0] gets IPv6 [1] gets IPv4
            $" \nType: {adapter.NetworkInterfaceType} \nStatus: {adapter.OperationalStatus} \nDNS: {properties.DnsAddresses[0].ToString()}"); 
        WriteLine();
    }
    
}
WriteLine();
foreach (IPAddress address in addresses)
{
    switch (address.AddressFamily)
    {
        case System.Net.Sockets.AddressFamily.InterNetwork:
            WriteLine($"IPv4: {address} {address.MapToIPv4()}");
            break;
        case System.Net.Sockets.AddressFamily.InterNetworkV6:
            // WriteLine($"IPv6: {address}");
            break; // We are skipping IPv6 Here
        default:
            WriteLine($"Unknown: {address}");
            break;
            
    }
    
}
WriteLine();*/

NetInfoClass localInfo = new();
List<string> ipv4List = localInfo.GetIPv4Addreses();
foreach (string ipv4 in ipv4List)
{
    WriteLine(ipv4);
}

List<string> dnsList = localInfo.GetDNSServers();
WriteLine("DNS Servers:");
foreach (string dns in dnsList)
{
    WriteLine(dns);
}






