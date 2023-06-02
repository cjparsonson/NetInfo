using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using NetworkInfo.Shared;

namespace NetworkInfoApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonPopulate_Click(object sender, RoutedEventArgs e)
        {
            NetInfoClass localInfo = new();
            List<string> ipv4 = localInfo.Ipv4List;
            foreach (string address in ipv4)
            {
                ipv4Addresses.Items.Add(address);
            }
            List<string> dnsServers = localInfo.DNSServerList;
            foreach (string dnsServer in dnsServers)
            {
                dnsServerAddresses.Items.Add(dnsServer);
            }
            
        }
    }
}
