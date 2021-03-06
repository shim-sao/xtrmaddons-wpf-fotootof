﻿using Newtonsoft.Json;
using System;
using System.Reflection;
using System.Windows;
using Fotootof.SQLite.EntityManager.Data.Base;
using XtrmAddons.Net.Common.Extensions;

namespace Fotootof.SQLite.EntityManager.Data.Tables.Entities
{
    /// <summary>
    /// Class XtrmAddons Fotootof Libraries SQLite Common Entity.
    /// </summary>
    [Serializable]
    [JsonObject(MemberSerialization.OptIn)]
    [System.Obsolete("use EntityBase", true)]
    public partial class CommonEntity : EntityBase
    {
        #region Variables
        
        /// <summary>
        /// Variable logger.
        /// </summary>
        private static readonly log4net.ILog log =
        	log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        
        #endregion
    }
}