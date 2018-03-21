﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using XtrmAddons.Fotootof.Lib.Base.Classes.Windows;
using XtrmAddons.Fotootof.Lib.SQLite.Database.Data.Tables.Entities;
using XtrmAddons.Fotootof.Lib.SQLite.Event;
using XtrmAddons.Fotootof.Libraries.Common.Collections;
using XtrmAddons.Fotootof.Libraries.Common.Tools;

namespace XtrmAddons.Fotootof.Libraries.Common.Windows.DataGrids.AlbumsDataGrid
{
    /// <summary>
    /// Class XtrmAddons Fotootof Server Component Browser Window Albums.
    /// </summary>
    public partial class WindowDataGridAlbums : WindowBaseForm
    {
        #region Variables

        /// <summary>
        /// Variable Window Albums model.
        /// </summary>
        private WindowDataGridAlbumsModel<WindowDataGridAlbums> model;

        #endregion



        #region Properties

        /// <summary>
        /// Proper to get selected Albums.
        /// </summary>
        public ObservableCollection<AlbumEntity> SelectedAlbums => UCAlbumsContainer.SelectedAlbums;

        /// <summary>
        /// Variable old Album informations backup.
        /// </summary>
        public AlbumEntityCollection OldForm { get; set; }

        /// <summary>
        /// Variable old Album informations backup.
        /// </summary>
        public AlbumEntityCollection NewForm
        {
            get => model.Albums;
            set => model.Albums = value;
        }

        #endregion



        #region Constructor

        public WindowDataGridAlbums() : base()
        {
            InitializeComponent();
            Loaded += (s, e) => Window_Loaded();
        }

        #endregion



        #region Methods

        /// <summary>
        /// 
        /// </summary>
        public void Window_Loaded()
        {
            // Assign closing event.
            Closing += Window_Closing;

            // Assign list of AclGroup to the model.
            model = new WindowDataGridAlbumsModel<WindowDataGridAlbums>(this);
            LoadAlbums();

            UCAlbumsContainer.OnAdd += UCAlbumsContainer_OnAdd;
            UCAlbumsContainer.OnCancel += UCAlbumsContainer_OnCancel;
            UCAlbumsContainer.OnChange += UCAlbumsContainer_OnChange;
            UCAlbumsContainer.OnDelete += UCAlbumsContainer_OnDelete;

            DataContext = model;

            SelectedAlbums.CollectionChanged += SelectedAlbums_CollectionChanged;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectedAlbums_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (SelectedAlbums.Count > 0)
            {
                ButtonSave.IsEnabled = true;
            }
            else
            {
                ButtonSave.IsEnabled = false;
            }
        }

        /// <summary>
        /// Method to load the list of Album from database.
        /// </summary>
        private void LoadAlbums()
        {
            try
            {
                AppLogger.Info("Loading Albums list. Please wait...");
                model.Albums = new AlbumEntityCollection(true);
                AppLogger.Info("Loading Albums list. Done.");
            }
            catch (Exception e)
            {
                AppLogger.Fatal("Loading Albums list failed : " + e.Message, e);
            }
        }

        /// <summary>
        /// Method called on Album view cancel event.
        /// </summary>
        /// <param name="sender">The object sender of the event.</param>
        /// <param name="e">Entity changes event arguments.</param>
        private void UCAlbumsContainer_OnCancel(object sender, EntityChangesEventArgs e)
        {
            AppLogger.Info("Adding or editing Album operation canceled. Please wait...");
            AppLogger.Info("Adding or editing Album operation canceled. Done.");
        }

        /// <summary>
        /// Method called on Album add event.
        /// </summary>
        /// <param name="sender">The object sender of the event.</param>
        /// <param name="e">Event arguments.</param>
        private void UCAlbumsContainer_OnAdd(object sender, EntityChangesEventArgs e)
        {
            AppLogger.Info("Saving new Album informations. Please wait...");

            AlbumEntity item = (AlbumEntity)e.NewEntity;
            model.Albums.Add(item);
            AlbumEntityCollection.DbInsert(new List<AlbumEntity> { item });

            AppLogger.Info("Saving new Album informations. Done.");
        }

        /// <summary>
        /// Method called on Album change event.
        /// </summary>
        /// <param name="sender">The object sender of the event.</param>
        /// <param name="e">Event arguments.</param>
        private void UCAlbumsContainer_OnChange(object sender, EntityChangesEventArgs e)
        {
            AppLogger.Info("Saving Album informations. Please wait...");

            AlbumEntity newEntity = (AlbumEntity)e.NewEntity;
            AlbumEntity old = model.Albums.Single(x => x.PrimaryKey == newEntity.PrimaryKey);
            int index = model.Albums.IndexOf(old);
            model.Albums[index] = newEntity;
            AlbumEntityCollection.DbUpdateAsync(new List<AlbumEntity> { newEntity }, new List<AlbumEntity> { old });

            AppLogger.Info("Saving Album informations. Done.");

        }

        /// <summary>
        /// Method called on Album delete event.
        /// </summary>
        /// <param name="sender">The object sender of the event.</param>
        /// <param name="e">Event arguments.</param>
        private void UCAlbumsContainer_OnDelete(object sender, EntityChangesEventArgs e)
        {
            AppLogger.Info("Deleting Album(s). Please wait...");

            AlbumEntity item = (AlbumEntity)e.NewEntity;

            // Remove item from list.
            model.Albums.Remove(item);

            // Delete item from database.
            AlbumEntityCollection.DbDelete(new List<AlbumEntity> { item });

            AppLogger.Info("Deleting Album(s). Done.");
        }

        #endregion
    }
}
