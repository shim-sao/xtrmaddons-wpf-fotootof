﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Fotootof.SQLite.EntityManager.Properties {
    using System;
    
    
    /// <summary>
    ///   Une classe de ressource fortement typée destinée, entre autres, à la consultation des chaînes localisées.
    /// </summary>
    // Cette classe a été générée automatiquement par la classe StronglyTypedResourceBuilder
    // à l'aide d'un outil, tel que ResGen ou Visual Studio.
    // Pour ajouter ou supprimer un membre, modifiez votre fichier .ResX, puis réexécutez ResGen
    // avec l'option /str ou régénérez votre projet VS.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class Database {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Database() {
        }
        
        /// <summary>
        ///   Retourne l'instance ResourceManager mise en cache utilisée par cette classe.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Fotootof.SQLite.EntityManager.Properties.Database", typeof(Database).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Remplace la propriété CurrentUICulture du thread actuel pour toutes
        ///   les recherches de ressources à l'aide de cette classe de ressource fortement typée.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Recherche une chaîne localisée semblable à BEGIN TRANSACTION;
        ///CREATE TABLE IF NOT EXISTS `Versions` (
        ///	`VersionId`	INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
        ///	`AssemblyVersionMin`	TEXT,
        ///	`AssemblyVersionMax`	TEXT,
        ///	`Comment`	TEXT
        ///);
        ///CREATE TABLE IF NOT EXISTS `UsersInAclGroups` (
        ///	`UserId`	INTEGER NOT NULL,
        ///	`AclGroupId`	INTEGER NOT NULL,
        ///	CONSTRAINT `PK_UsersInAclGroups` PRIMARY KEY(`UserId`,`AclGroupId`),
        ///	CONSTRAINT `FK_UsersInAclGroups_AclGroups_AclGroupId` FOREIGN KEY(`AclGroupId`) REFERENCES `AclGroups`(`AclGroupId`) ON DELETE CASCADE,
        ///	CONST [le reste de la chaîne a été tronqué]&quot;;.
        /// </summary>
        public static string SrcSQLiteDatabaseSchema {
            get {
                return ResourceManager.GetString("SrcSQLiteDatabaseSchema", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Recherche une chaîne localisée semblable à PRAGMA foreign_keys=off;
        ///PRAGMA temp_store = 2;
        ///
        ////** ********************************************************************
        /// * SECTIONS TABLE CHANGED
        /// */
        ///DROP TABLE IF EXISTS [Sections_Temp];
        /// 
        ///ALTER TABLE [Sections] RENAME TO [Sections_Temp];
        ///
        ///CREATE TABLE IF NOT EXISTS [Sections] (
        ///	[SectionId] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,
        ///
        ///	[Name] VARCHAR(64)  NOT NULL DEFAULT &apos;&apos; NOT NULL,
        ///	[Alias] VARCHAR(64) DEFAULT &apos;&apos; NOT NULL,
        ///	[Description] TEXT DEFAULT &apos;&apos; NOT NULL,
        ///
        ///	[IsDefault] BOOLEA [le reste de la chaîne a été tronqué]&quot;;.
        /// </summary>
        public static string SrcSQLiteDatabaseUpdate_1_0_18123_2149 {
            get {
                return ResourceManager.GetString("SrcSQLiteDatabaseUpdate_1_0_18123_2149", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Recherche une chaîne localisée semblable à PRAGMA foreign_keys=off;
        ///PRAGMA temp_store = 2;
        ///
        ////** ********************************************************************
        /// * ALBUMS TABLE CHANGED
        /// */
        ///DROP TABLE IF EXISTS [Albums_Temp];
        /// 
        ///ALTER TABLE [Albums] RENAME TO [Albums_Temp];
        ///
        ///CREATE TABLE IF NOT EXISTS [Albums] (
        ///	[AlbumId] integer PRIMARY KEY AUTOINCREMENT NOT NULL,
        ///
        ///	[Name] VARCHAR(64) DEFAULT &apos;&apos; NOT NULL,
        ///	[Alias] VARCHAR(64) DEFAULT &apos;&apos; NOT NULL,
        ///	[Description] TEXT DEFAULT &apos;&apos; NOT NULL,
        ///
        ///	[Ordering] INTEGER DEFAULT &apos;0&apos; NOT NULL, [le reste de la chaîne a été tronqué]&quot;;.
        /// </summary>
        public static string SrcSQLiteDatabaseUpdate_1_0_18134_1044 {
            get {
                return ResourceManager.GetString("SrcSQLiteDatabaseUpdate_1_0_18134_1044", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Recherche une chaîne localisée semblable à PRAGMA foreign_keys=off;
        ///PRAGMA temp_store = 2;
        ///
        ///REPLACE INTO [Infos] (InfoId, InfoTypeId, Name, Alias, Description, IsDefault, Ordering)
        ///VALUES
        ///(1, 1, &apos;High&apos;, &apos;high&apos;, &apos;Defines High Quality pictures.&apos;, 1, 0),
        ///(2, 1, &apos;Medium&apos;, &apos;medium&apos;, &apos;Defines Medium Quality pictures.&apos;, 0, 1),
        ///(3, 1, &apos;Low&apos;, &apos;low&apos;, &apos;Defines Low Quality pictures.&apos;, 0, 2),
        ///(4, 1, &apos;Various&apos;, &apos;various&apos;, &apos;Defines High Quality pictures.&apos;, 0, 3);
        ///
        ///REPLACE INTO [Infos] (InfoId, InfoTypeId, Name, Alias, Description, IsDefault, Ordering)
        ///V [le reste de la chaîne a été tronqué]&quot;;.
        /// </summary>
        public static string SrcSQLiteDatabaseUpdate_1_0_18137_1050 {
            get {
                return ResourceManager.GetString("SrcSQLiteDatabaseUpdate_1_0_18137_1050", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Recherche une chaîne localisée semblable à PRAGMA foreign_keys=off;
        ///PRAGMA temp_store = 2;
        ///
        ///CREATE TABLE IF NOT EXISTS `Storages` (
        ///	`StorageId`	INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
        ///	`Name`	TEXT,
        ///	`FullName`	TEXT
        ///);
        ///
        ///CREATE TABLE IF NOT EXISTS `StoragesInAlbums` (
        ///	`StorageId`	INTEGER NOT NULL,
        ///	`AlbumId`	INTEGER NOT NULL,
        ///	CONSTRAINT `FK_StoragesInAlbums_Storages_StorageId` FOREIGN KEY(`StorageId`) REFERENCES `Storages`(`StorageId`) ON DELETE CASCADE,
        ///	CONSTRAINT `PK_StoragesInAlbums` PRIMARY KEY(`StorageId`,`AlBumId`),
        ///	CONSTRAINT `F [le reste de la chaîne a été tronqué]&quot;;.
        /// </summary>
        public static string SrcSQLiteDatabaseUpdate_1_0_18210_1228 {
            get {
                return ResourceManager.GetString("SrcSQLiteDatabaseUpdate_1_0_18210_1228", resourceCulture);
            }
        }
    }
}
