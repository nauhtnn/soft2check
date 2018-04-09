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

namespace Client99
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        System.Threading.Thread mTh;
        Server2 mServer;
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
            mClient = new Client2(ClientBufHndl, ClientMsg, false);
            mClient.ConnectWR();
        }

        public byte[] ClientMsg()
        {
            string msg = "_client is answering...";
            Dispatcher.Invoke(new Action(
                        () =>
                        {
                            msg = "_" + tbxMsg.Text + "_";
                            tbxMsg.Text = "";
                        }));
            return System.Text.UTF8Encoding.UTF8.GetBytes(msg);
        }

        public bool ClientBufHndl(byte[] buf)
        {
            mClient.Close();
            mClient = null;
            return false;
        }

        private void btnPhung_Click(object sender, RoutedEventArgs e)
        {
            tbxMsg.Text = PhungTest.TestAndReport();
        }

        private void btnMy_Click(object sender, RoutedEventArgs e)
        {
           tbxMsg.Text = MyTest.TestAndReport();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            mTh = new System.Threading.Thread(ServerStartListening);
            mTh.Start();
        }

        private void ServerStartListening()
        {
            mServer = new Server2(ServerReceiveMessge);
            mServer.Start();
        }

        public bool ServerReceiveMessge(byte[] msg, out byte[] outMsg)
        {
            bool bWaiting = true;
            string tMsg = "abc";
            Dispatcher.Invoke(new Action(
                        () =>
                        {
                            tbxMsg.Text += "Server asked";
                            tMsg = "_" + tbxMsg.Text + "_";
                            bWaiting = false;
                        }));
            while (bWaiting)
                System.Threading.Thread.Sleep(888);
            outMsg = System.Text.UTF8Encoding.UTF8.GetBytes(tMsg);
            return false;
        }
    }
}
