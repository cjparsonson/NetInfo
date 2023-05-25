using System.Net;

String hostname = Dns.GetHostName();
IPAddress[] addresses = Dns.GetHostAddresses(hostname);
WriteLine($"Hostname: {hostname}");
foreach (IPAddress address in addresses)
{
    switch (address.AddressFamily)
    {
        case System.Net.Sockets.AddressFamily.InterNetwork:
            WriteLine($"IPv4: {address}");
            break;
        case System.Net.Sockets.AddressFamily.InterNetworkV6:
            WriteLine($"IPv6: {address}");
            break;
        default:
            WriteLine($"Unknown: {address}");
            break;
            
    }
    
}


