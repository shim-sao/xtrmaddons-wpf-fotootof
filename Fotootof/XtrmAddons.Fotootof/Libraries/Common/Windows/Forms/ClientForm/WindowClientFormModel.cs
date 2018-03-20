﻿using XtrmAddons.Fotootof.Lib.Base.Classes.Windows;
using XtrmAddons.Net.Application.Serializable.Elements.XmlRemote;

namespace XtrmAddons.Fotootof.Libraries.Common.Windows.Forms
{
    /// <summary>
    /// Class XtrmAddons Fotootof Server Window Client Form Model.
    /// </summary>
    public class WindowClientFormModel<WindowClientForm> : WindowBaseFormModel<WindowClientForm>
    {
        #region Variables

        /// <summary>
        /// Variable Client.
        /// </summary>
        public Client client;

        #endregion



        #region Properties

        /// <summary>
        /// Property to access to the Client.
        /// </summary>
        public Client Client
        {
            get { return client; }
            set
            {
                client = value;
                RaisePropertyChanged("Client");
            }
        }

        #endregion



        #region Constructor

        /// <summary>
        /// Class XtrmAddons Fotootof Server Window Client Form Model Constructor.
        /// </summary>
        /// <param name="pBase"></param>
        public WindowClientFormModel(WindowClientForm pBase) : base(pBase) { }

        #endregion
    }
}