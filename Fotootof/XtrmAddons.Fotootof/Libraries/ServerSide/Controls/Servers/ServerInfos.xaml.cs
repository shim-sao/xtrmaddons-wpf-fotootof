﻿using System.Windows;
using XtrmAddons.Fotootof.Lib.Base.Classes.Controls;
using XtrmAddons.Fotootof.Lib.HttpServer;
using XtrmAddons.Fotootof.Libraries.Common.HttpHelpers.HttpServer;
using XtrmAddons.Fotootof.Libraries.Common.Tools;
using XtrmAddons.Net.Application;

namespace XtrmAddons.Fotootof.Libraries.ServerSide.Controls.Servers
{
    /// <summary>
    /// Class XtrmAddons Fotootof Server UI Control Server Infos User Control.
    /// </summary>
    public partial class ServerInfos : ControlBase
    {
        #region Properties

        /// <summary>
        /// Accessors to Window AclGroup Form model.
        /// </summary>
        public ServerInfosModel<ServerInfos> Model { get; private set; }

        #endregion



        #region Constructor

        /// <summary>
        /// Class XtrmAddons Fotootof Server UI Control Server Server Infos User Control Constructor.
        /// </summary>
        public ServerInfos()
        {
            InitializeComponent();

            Model = new ServerInfosModel<ServerInfos>(this);
            DataContext = Model;
        }

        #endregion



        #region Methods

        /// <summary>
        /// Method to refresh custom control data. 
        /// </summary>
        public void RefreshServerData()
        {
            // Try to get server informations
            Model.Server = ApplicationBase.Options.Remote.Servers.FindDefault();

            if (Model.server != null)
            {
                InputHost.Text = Model.server.Host;
                InputPort.Text = Model.server.Port;
            }

            RefreshServerMenu();
        }

        /// <summary>
        /// Method to refresh custom control data. 
        /// </summary>
        public void RefreshServerMenu()
        {
            if (HttpWebServerApplication.IsStarted)
            {
                Button_Start.IsEnabled = false;
                Button_Stop.IsEnabled = true;
                Button_Restart.IsEnabled = true;
            }
            else
            {
                Button_Start.IsEnabled = true;
                Button_Stop.IsEnabled = false;
                Button_Restart.IsEnabled = false;
            }
        }

        /// <summary>
        /// Method called on server start click.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The routed event arguments.</param>
        private void OnServerStart_Click(object sender, RoutedEventArgs e)
        {
            HttpServerBase.Start();
        }

        /// <summary>
        /// Method called on server stop click.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The routed event arguments.</param>
        private void OnServerStop_Click(object sender, RoutedEventArgs e)
        {
            HttpServerBase.Stop();
        }

        /// <summary>
        /// Method called on server restart click.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The routed event arguments.</param>
        private void OnServerRestart_Click(object sender, RoutedEventArgs e)
        {
            //Overwork.IsBusy = true;
            OnServerStop_Click(sender, e);
            OnServerStart_Click(sender, e);
            //Overwork.IsBusy = false;
        }

        public override void Control_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            throw new System.NotImplementedException();
        }
    }

    #endregion
}
