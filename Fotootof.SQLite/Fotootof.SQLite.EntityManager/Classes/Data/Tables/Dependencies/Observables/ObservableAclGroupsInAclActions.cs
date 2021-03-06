﻿using Newtonsoft.Json;
using System.Collections.Generic;
using Fotootof.SQLite.EntityManager.Data.Base;

namespace Fotootof.SQLite.EntityManager.Data.Tables.Dependencies.Observables
{
    /// <summary>
    /// Class Fotootof.SQLite.EntityManager Data Tables Dependencies Observable AclGroups In AclActions.
    /// </summary>
    /// <typeparam name="O">The Type of the entity item to observe.</typeparam>
    /// <typeparam name="E">The Type of the entity items destination of the dependency.</typeparam>
    [JsonArray(Title = "AclGroups_AclActions")]
    public class ObservableAclGroupsInAclActions<O, E> : ObservableDependencyBase<AclGroupsInAclActions, O, E> where O : class where E : class
    {
        /// <summary>
        /// Class Fotootof.SQLite.EntityManager Data Tables Dependencies Observable AclGroups In AclActions Constructor.
        /// </summary>
        public ObservableAclGroupsInAclActions() : base() { }

        /// <summary>
        /// Class Fotootof.SQLite.EntityManager Data Tables Dependencies Observable AclGroups In AclActions Constructor.
        /// </summary>
        /// <param name="list">A list of items to add at the collection initialization. </param>
        public ObservableAclGroupsInAclActions(List<AclGroupsInAclActions> list) : base(list) { }

        /// <summary>
        /// Class Fotootof.SQLite.EntityManager Data Tables Dependencies Observable AclGroups In AclActions Constructor.
        /// </summary>
        /// <param name="collection">A enumerable collection of items to add at the collection initialization.</param>
        public ObservableAclGroupsInAclActions(IEnumerable<AclGroupsInAclActions> collection) : base(collection) { }
    }
}