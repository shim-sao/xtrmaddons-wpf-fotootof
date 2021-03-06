﻿using Newtonsoft.Json;
using System.Collections.Generic;
using Fotootof.SQLite.EntityManager.Data.Base;

namespace Fotootof.SQLite.EntityManager.Data.Tables.Dependencies.Observables
{
    /// <summary>
    /// Class Fotootof.SQLite.EntityManager Data Tables Dependencies Observable Albums In Sections.
    /// </summary>
    /// <typeparam name="O">The Type of the entity item to observe.</typeparam>
    /// <typeparam name="E">The Type of the entity items destination of the dependency.</typeparam>
    [JsonArray(Title = "Albums_Sections")]
    public class ObservableAlbumsInSections<O, E> : ObservableDependencyBase<AlbumsInSections, O, E> where O : class where E : class
    {
        /// <summary>
        /// Class Fotootof.SQLite.EntityManager Data Tables Dependencies Observable Albums In Sections Constructor.
        /// </summary>
        public ObservableAlbumsInSections() : base() { }

        /// <summary>
        /// Class Fotootof.SQLite.EntityManager Data Tables Dependencies Observable Albums In Sections Constructor.
        /// </summary>
        /// <param name="list">A list of items to add at the collection initialization. </param>
        public ObservableAlbumsInSections(List<AlbumsInSections> list) : base(list) { }

        /// <summary>
        /// Class Fotootof.SQLite.EntityManager Data Tables Dependencies Observable Albums In Sections Constructor.
        /// </summary>
        /// <param name="collection">A enumerable collection of items to add at the collection initialization.</param>
        public ObservableAlbumsInSections(IEnumerable<AlbumsInSections> collection) : base(collection) { }
    }
}
