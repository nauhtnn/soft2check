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

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        System.Threading.Thread mTh;
        Server2 mServer;
        public MainWindow()
        {
            InitializeComponent();
        }

        public bool ServerReceiveMessge(byte[] msg, out byte[] outMsg)
        {
            Dispatcher.Invoke(new Action(
                        () =>
                        {
                            txtMsgFromClient.Text += System.Text.UTF8Encoding.UTF8.GetString(msg) + "\n";
                        }));
            outMsg = null;
            return false;
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

        private void Grid_Unloaded(object sender, RoutedEventArgs e)
        {
            mTh.Abort();
        }
    }
}
