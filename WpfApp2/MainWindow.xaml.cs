﻿using System;
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
        bool toUpdateGUI;
        int mCount;

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
                            if(toUpdateGUI)
                                txtMsgFromClient.Text += System.Text.UTF8Encoding.UTF8.GetString(msg) + "\n";
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
    }
}
