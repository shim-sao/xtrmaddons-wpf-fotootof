﻿using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace XtrmAddons.Fotootof.Lib.SQLite.Database.Data.Base.Interfaces
{
    /// <summary>
    /// Class XtrmAddons Fotootof Libraries SQLite Database Data Interface for Base Entity.
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public interface IEntityBase
    {
        #region Proprerties

        /// <summary>
        /// Property alias to access to the primary key of the entity.
        /// </summary>
        [NotMapped]
        [JsonProperty]
        int PrimaryKey { get; set; }

        #endregion
    }
}