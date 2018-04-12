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
using System.Net;

namespace Client99
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        System.Threading.Thread mTh;
        Server3 mServer;
        Client2 mClient;

        public MainWindow()
        {
            InitializeComponent();
            Closing += MainWindow_Closing;
        }

        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            mServer.Stop();
            mTh.Join();
        }

        private void btnSend_Click(object sender, RoutedEventArgs e)
        {
            mClient = new Client2(SlaverBufHndl, ClientMsgPrep, false);
            mClient.ConnectWR();
        }

        public byte[] ClientMsgPrep()
        {
            string msg = "_client is answering...";
            return System.Text.UTF8Encoding.UTF8.GetBytes(msg);
        }

        public bool SlaverBufHndl(byte[] buf)
        {
            mClient.Close();
            mClient = null;
            return false;
        }

        private void btnPhung_Click(object sender, RoutedEventArgs e)
        {
            txtStatus.Text = PhungTest.TestAndReport();
        }

        private void btnMy_Click(object sender, RoutedEventArgs e)
        {
            txtStatus.Text = MyTest.TestAndReport();
        }

        private void SlaverStartListening()
        {
            mServer = new Server3(SlaverRecvMsg);
            mServer.Start();
        }

        public bool SlaverRecvMsg(byte[] msg, out byte[] outMsg)
        {
            Dispatcher.Invoke(new Action(
                        () =>
                        {
                            txtRecvMsg.Text += "Server asked";
                        }));
            outMsg = null;
            return false;//slaver not reply here
        }

        private void Main_Loaded(object sender, RoutedEventArgs e)
        {
            string hostname = "";
            System.Net.IPHostEntry ip = new IPHostEntry();
            hostname = System.Net.Dns.GetHostName();
            ip = System.Net.Dns.GetHostEntry(hostname);
            txtTitle.Text = ip.HostName;

            foreach (System.Net.IPAddress listip in ip.AddressList)
            {
                if(listip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                    txtTitle.Text += " - " + listip.MapToIPv4().ToString();
            }

            mTh = new System.Threading.Thread(SlaverStartListening);
            mTh.Start();
        }
    }
}
