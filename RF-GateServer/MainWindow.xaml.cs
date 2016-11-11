﻿using RF_GateServer.Core;
using RF_GateServer.Gate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace RF_GateServer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            this.AddHandler(Window.PreviewKeyDownEvent, new KeyEventHandler(WindowKeyDown));
        }

        private void WindowKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F2)
            {
                ServerListWindow server = new RF_GateServer.ServerListWindow();
                server.Show();
            }
        }

        private void btnConnectReader_Click(object sender, RoutedEventArgs e)
        {
            ConnectReader();
            ((FrameworkElement)sender).IsEnabled = false;
        }

        private void ConnectReader()
        {
            new ComServerController().Run();
        }
    }
}
