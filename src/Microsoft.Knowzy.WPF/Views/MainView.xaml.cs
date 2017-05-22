//*********************************************************
//
// Copyright (c) Microsoft. All rights reserved.
// This code is licensed under the MIT License (MIT).
// THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
// ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
// IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
// PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.
//
//*********************************************************

using Microsoft.Knowzy.Common.Helpers;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace Microsoft.Knowzy.WPF.Views
{
    public partial class MainView
    {
        AppService _appService = null;

        public MainView()
        {
            InitializeComponent();

            if (ExecutionMode.IsRunningAsUwp())
            {
                try
                {
                    // get the path to the App folder (WPF or UWP).
                    var path = AppFolders.Local;
                    FileSystemWatcher watcher = new FileSystemWatcher(path);
                    watcher.EnableRaisingEvents = true;
                    watcher.Changed += Watcher_Changed;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("FileSystemWatcher Error:" + ex.Message);
                }
            }
        }

        private async void Login_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (ExecutionMode.IsRunningAsUwp())
            {
                await WindowsHello.Login();
            }
            else
            {
                MessageBox.Show("Login not implemented in WPF version", "Microsoft.Knowzy.WPF");
            }
        }

        private async void View_Click(object sender, EventArgs e)
        {
            if (ExecutionMode.IsRunningAsUwp())
            {
                Uri uri = new Uri("com.microsoft.knowzy.protocol.3d://" + "message?nose=" + "https://www.remix3d.com/details/G009SXPQ5S3P");
                await UriProtocol.SendUri(uri);
            }
            else
            {
                MessageBox.Show("View not implemented in WPF version", "Microsoft.Knowzy.WPF");
            }
        }

        private async void Help_Click(object sender, EventArgs e)
        {
            if (ExecutionMode.IsRunningAsUwp())
            {
                if(_appService == null)
                {
                    // start the app service
                    _appService = new AppService();
                    var result = await _appService.StartAppServiceConnection("com.microsoft.knowzy.appservice.test");
                }

                // start the XAML UI that will communicate with the App Service
                Uri uri = new Uri("com.microsoft.knowzy.protocol.test://" + "message?appserviceid=" + "com.microsoft.knowzy.appservice.test");
                await UriProtocol.SendUri(uri);
            }
        }

        private void Watcher_Changed(object sender, FileSystemEventArgs e)
        {
            if (ExecutionMode.IsRunningAsUwp())
            {
                if (File.Exists(e.FullPath))
                {
                    String xml = "<toast><visual><binding template='ToastGeneric'><image src='" + e.FullPath + "'/><text hint-maxLines='1'>Microsoft.Knowzy.WPF received a new image</text></binding></visual></toast>";
                    Toast.CreateToast(xml);
                }
            }
        }
    }
}
