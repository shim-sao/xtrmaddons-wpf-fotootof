﻿using Fotootof.SQLite.Services;
using System.Windows;
using XtrmAddons.Net.Common.Extensions;
using XtrmAddons.Net.Common.Objects;

namespace Fotootof.Libraries.Models
{
    /// <summary>
    /// Class Fotootof Libraries Model Base.
    /// </summary>
    public class ModelBase : ObjectBaseNotifier
    {
        #region Variable

        /// <summary>
        /// Variable logger.
        /// </summary>
        private static readonly log4net.ILog log =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #endregion



        #region Properties

        /// <summary>
        /// Property alias to access to the main database connector.
        /// </summary>
        public static SQLiteSvc Db
            => SQLiteSvc.GetInstance();

        #endregion



        #region Constructor

        /// <summary>
        /// Class XtrmAddons Fotootof Server Libraries Base Model Constructor.
        /// </summary>
        public ModelBase() { }

        #endregion
    }
}
