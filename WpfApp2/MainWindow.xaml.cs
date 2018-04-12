using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
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
        System.Timers.Timer mTimer;
        Server2 mServer;
        Client2 mClient;
        bool toUpdateGUI;
        int mCount;
        TextBlock[] vReport;
        int iRoom;
        int nComp;
        int ipv4Start;

        public MainWindow()
        {
            InitializeComponent();
            mCount = 0;
            Closing += MainWindow_Closing;
            toUpdateGUI = true;
        }

        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            toUpdateGUI = false;
            mServer.Stop();
            mTh.Join();
            mTimer.Close();
            mTimer.Dispose();
        }

        public bool ServerReceiveMessge(byte[] msg, out byte[] outMsg)
        {
            Dispatcher.Invoke(new Action(
                        () =>
                        {
                        }));
            outMsg = null;
            return false;
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            mTh = new System.Threading.Thread(ServerStartListening);
            mTh.Start();
            // Create a timer with a two second interval.
            mTimer = new System.Timers.Timer(1000);
            // Hook up the Elapsed event for the timer. 
            mTimer.Elapsed += OnTimedEvent;
            mTimer.AutoReset = true;
            mTimer.Enabled = true;

            string[] s = System.IO.File.ReadAllLines("../../../dat/comp.txt");
            iRoom = int.Parse(s[0]);
            nComp = int.Parse(s[1]);
            ipv4Start = int.Parse(s[2]);
            vReport = new TextBlock[nComp];
            ReportDecor();
        }

        private void ReportDecor()
        {
            for(int i = 0; i < nComp;)
            {
                RowDefinition rd = new RowDefinition();
                rd.Height = new GridLength(24);
                grdReport.RowDefinitions.Add(rd);
                TextBlock t = new TextBlock();
                t.HorizontalAlignment = HorizontalAlignment.Center;
                Grid.SetRow(t, i);
                grdReport.Children.Add(t);
                vReport[i] = new TextBlock();
                Grid.SetRow(vReport[i], i);
                Grid.SetColumn(vReport[i], 1);
                grdReport.Children.Add(vReport[i]);
                ++i;
                t.Text = "MAY" + i.ToString("d2") + "PM" + iRoom;
            }
        }

        private void ServerStartListening()
        {
            mServer = new Server2(ServerReceiveMessge);
            mServer.Start();
        }

        private void OnTimedEvent(object sender, ElapsedEventArgs e)
        {
            ++mCount;
            Dispatcher.Invoke(new Action(
                        () =>
                        {
                            if(toUpdateGUI)
                                txtCount.Text = mCount.ToString();
                        }));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //for(int i = 92; i < 122; ++i)
            {
                //mClient = new Client2("192.168.1." + i, ClientBufHndl, ClientMsg, false);
                mClient = new Client2("127.0.0.1", ClientBufHndl, ClientMsg, false);
                mClient.ConnectWR();
            }
        }

        public bool ClientBufHndl(byte[] buf)
        {
            Dispatcher.Invoke(new Action(
                        () =>
                        {
                            
                        }));
            mClient.Close();
            mClient = null;
            return false;
        }

        public byte[] ClientMsg()
        {
            string msg = "server";
            return System.Text.UTF8Encoding.UTF8.GetBytes(msg);
        }
    }
}
