using System;
using System.Collections.Generic;
using System.Linq;
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

namespace AzureServiceBusQueueDemoServer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private AzureServiceBusServer _Server;
        public MainWindow()
        {
            InitializeComponent();
            _Server = new AzureServiceBusServer();
            lstBox1.DataContext = _Server.Messages;
        }

        private void CmdStart_Click(object sender, RoutedEventArgs e)
        {
            _Server.StartReceiving();
        }
    }
}
