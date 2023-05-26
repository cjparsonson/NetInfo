using System.Data.Common;
using System.Net;
using System.Net.NetworkInformation;

String hostname = Dns.GetHostName();
IPAddress[] addresses = Dns.GetHostAddresses(hostname);
NetworkInterface[] interfaces = NetworkInterface.GetAllNetworkInterfaces();


WriteLine($"Hostname: {hostname}");
foreach (NetworkInterface adapter in interfaces)
{
    IPv4InterfaceProperties properties = adapter.IPv4InterfaceProperties();
    WriteLine($"{ adapter.Description}: {properties.}");
}
WriteLine();
foreach (IPAddress address in addresses)
{
    switch (address.AddressFamily)
    {
        case System.Net.Sockets.AddressFamily.InterNetwork:
            WriteLine($"IPv4: {address}");
            WriteLine(address);
            break;
        case System.Net.Sockets.AddressFamily.InterNetworkV6:
            WriteLine($"IPv6: {address}");
            break;
        default:
            WriteLine($"Unknown: {address}");
            break;
            
    }
    
}
WriteLine();






