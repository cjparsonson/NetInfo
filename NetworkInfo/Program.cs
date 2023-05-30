﻿using System.Data.Common;
using System.Net;
using System.Net.NetworkInformation;

String hostname = Dns.GetHostName(); // Get device hostname
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
        WriteLine($"Name: {adapter.Description} \nIP: {properties.UnicastAddresses[1].Address}" +
            $" \nType: {adapter.NetworkInterfaceType} \nStatus: {adapter.OperationalStatus} \n DNS: {properties.DnsAddresses[0].ToString()}"); // UnicastAddresses[0] gets IPv6 [1] gets IPv4
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
WriteLine();






