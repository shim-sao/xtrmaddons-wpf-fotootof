﻿using System.Collections.Generic;
using XtrmAddons.Fotootof.Lib.SQLite.Database.Manager.Base;

namespace XtrmAddons.Fotootof.Lib.SQLite.Database.Manager
{
    /// <summary>
    /// Class XtrmAddons Fotootof Libraries SQLite Picture Entities List Options.
    /// </summary>
    public class PictureOptionsList : EntitiesOptionsList
    {
        #region Properties

        /// <summary>
        /// 
        /// </summary>
        public List<int> IncludeAlbumId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<int> ExcludeAlbumId { get; set; }

        #endregion
    }
}