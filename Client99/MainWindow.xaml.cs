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
        Client2 mClient;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            byte[] msg = ClientMsg();
            mClient = new Client2(ClientBufHndl, ClientMsg, false);
            mClient.ConnectWR();
        }

        public byte[] ClientMsg()
        {
            return System.Text.UTF8Encoding.UTF8.GetBytes("_" + tbxMsg.Text + "_");
        }

        public bool ClientBufHndl(byte[] buf)
        {
            mClient.Close();
            mClient = null;
            return false;
        }
    }
}
