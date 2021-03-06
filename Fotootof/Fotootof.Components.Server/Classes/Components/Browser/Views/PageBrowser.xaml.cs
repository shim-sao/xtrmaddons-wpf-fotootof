﻿using Fotootof.Collections;
using Fotootof.Layouts.Dialogs;
using Fotootof.Libraries.Components;
using Fotootof.Libraries.Enums;
using Fotootof.Libraries.Models.Systems;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using XtrmAddons.Net.Common.Extensions;

namespace Fotootof.Components.Server.Browser
{
    /// <summary>
    /// <para>Class XtrmAddons Fotootof Server Side Component Browser View.</para>
    /// <para>This page is design to display a simple file browser for media manangement.</para>
    /// </summary>
    public partial class PageBrowserLayout : ComponentView
    {
        #region Variables

        /// <summary>
        /// Variable logger.
        /// </summary>
        private static readonly log4net.ILog log =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #endregion



        #region Properties

        /// <summary>
        /// Property to access to the page browser model.
        /// </summary>
        internal PageBrowserModel Model { get; private set; }

        private TreeView TreeViewStorage
            => (FindName("UcTreeViewDirectories") as UserControl)
                ?.FindName("TreeViewDirectoryInfoName") as TreeView;


        #endregion



        #region Constructors


        /// <summary>
        /// Class XtrmAddons Fotootof Server Side Component Browser View.
        /// </summary>
        public PageBrowserLayout()
        {
            MessageBoxs.IsBusy = true;
            log.Warn(string.Format(CultureInfo.CurrentCulture, Local.Properties.Logs.InitializingPageWaiting, "Browser"));

            // Constuct page component.
            InitializeComponent();
            AfterInitializedComponent();

            log.Info(string.Format(CultureInfo.CurrentCulture, Local.Properties.Logs.InitializingPageDone, "Browser"));
            MessageBoxs.IsBusy = false;
        }

        #endregion



        #region Methods

        /// <summary>
        /// Method called on <see cref="FrameworkElement"/> loaded event.
        /// </summary>
        /// <param name="sender">The <see cref="object"/> sender of the event.</param>
        /// <param name="e">The routed event arguments <see cref="RoutedEventArgs"/></param>
        public override void Control_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext = Model;
        }
        
        /// <summary>
        /// Method to initialize page content.
        /// </summary>
        public override void InitializeModel()
        {
            // Initialize associated view model of the page.
            Model = new PageBrowserModel(this)
            {
                FilesCollection = new CollectionStorage()
            };

            // Add action to the tree view item event handler.
            TreeViewStorage.SelectedItemChanged += TreeViewDirectories_SelectedItemChanged;
            UcListViewStoragesServer.ImageSize_SelectionChanged += ImageSize_SelectionChanged;
        }

        [Obsolete("Use Model.GetInfoFiles()", true)]
        private FileInfo[] GetInfoFiles(DirectoryInfo dirInfo, SearchOption option = SearchOption.TopDirectoryOnly)
        {
            return Model.GetInfoFiles(dirInfo);
        }

        [Obsolete("Use Model.GetInfoDirectories(), true")]
        private DirectoryInfo[] GetDirectoriesInfos(DirectoryInfo dirInfo)
        {
            return Model.GetInfoDirectories(dirInfo);
        }

        /// <summary>
        /// Method to display header title of directory.
        /// </summary>
        /// <param name="dirInfo">A directory info.</param>
        private void DisplayHeaderDirectory(object dirInfo)
        {
            FindName<TextBox>("TextBox_Breadcrumbs_Name").Text = Model.GetText(dirInfo);
        }

        /// <summary>
        /// Method to clear the <see cref="CollectionStorage"/> of files displayed in the view.
        /// </summary>
        [Obsolete("use Model.ClearFilesCollection(), true")]
        private void ClearFilesCollection()
        {
            Model.ClearFilesCollection();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender">The object sender of the event.</param>
        /// <param name="e"></param>
        private void TreeViewDirectories_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            FindName<Button>("Button_Forward_Name").IsEnabled = false;

            Model.ChangeCurrentItem(((e.NewValue) as TreeViewItem)?.Tag);
            if (Model.PreviewStack.Count > 1)
            {
                FindName<Button>("Button_Back_Name").IsEnabled = true;
            }
            
            Refresh_UcListViewStoragesServer();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender">The object sender of the event.</param>
        /// <param name="e"></param>
        private void OnBack_Click(object sender, RoutedEventArgs e)
        {
            Model.NextStack.Push(Model.CurrentItem);
            FindName<Button>("Button_Forward_Name").IsEnabled = true;

            Model.CurrentItem = Model.PreviewStack.Pop();
            Refresh_UcListViewStoragesServer();

            if (Model.PreviewStack.Count <= 1)
            {
                FindName<Button>("Button_Back_Name").IsEnabled = false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender">The object sender of the event.</param>
        /// <param name="e"></param>
        private void OnForward_Click(object sender, RoutedEventArgs e)
        {
            Model.PreviewStack.Push(Model.CurrentItem);
            FindName<Button>("Button_Back_Name").IsEnabled = true;

            Model.CurrentItem = Model.NextStack.Pop();
            Refresh_UcListViewStoragesServer();

            if (Model.NextStack.Count == 0)
            {
                FindName<Button>("Button_Forward_Name").IsEnabled = false;
            }
        }

        /// <summary>
        /// Method called on upward click event.
        /// </summary>
        /// <param name="sender">The <see cref="object"/> sender of the event.</param>
        /// <param name="e">The routed event arguments <see cref="RoutedEventArgs"/></param>
        private void OnUpward_Click(object sender, RoutedEventArgs e)
        {
            DirectoryInfo di = Model.GetCurrentDirectoryInfo();

            if (di != null)
            {
                if(di.Parent != null)
                {
                    Model.PreviewStack.Push(Model.CurrentItem);
                    (FindName("Button_Back_Name") as Button).IsEnabled = true;

                    Model.NextStack.Clear();
                    (FindName("Button_Forward_Name") as Button).IsEnabled = false;

                    Model.CurrentItem = new DirectoryInfo(di.Parent.FullName);
                    Refresh_UcListViewStoragesServer();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void Refresh_UcListViewStoragesServer()
        {
            UcListViewStoragesServer?.Items?.Clear();
            Model.ClearFilesCollection();

            if (Model.CurrentItem != null)
            {
                DisplayHeaderDirectory(Model.CurrentItem);

                Model.LoadInfos();

                UcListViewStoragesServer.Visibility = Visibility.Visible;
            }
            else
            {
                UcListViewStoragesServer.Visibility = Visibility.Hidden;
            }

            UcListViewStoragesServer.CounterTotalImages.Text = Model.FilesCollection.ImagesCount.ToString();
            UcListViewStoragesServer.CounterTotalDirectories.Text = Model.FilesCollection.DirectoriesCount.ToString();

            //((TextBlock)UcListViewStoragesServer.GetPropertyValue("CounterTotalImages")).Text = Model.FilesCollection.ImagesCount.ToString();
            //((TextBlock)UcListViewStoragesServer.GetPropertyValue("CounterTotalDirectories")).Text = Model.FilesCollection.DirectoriesCount.ToString();

            UpdateLayout();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender">The object sender of the event.</param>
        /// <param name="e"></param>
        private void ImageSize_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                Model.ImageSize = ImageSizeExtensions.Index(((ComboBox)sender).SelectedIndex).ToSize();
                Refresh_UcListViewStoragesServer();
            }
            catch (Exception ex)
            {
                log.Error(ex.Output(), ex);
                MessageBoxs.Error(ex);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender">The object sender of the event.</param>
        /// <param name="e"></param>
        private void UcListViewStoragesServer_ItemsCollection_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            ListView list = sender as ListView;

            if (list.SelectedItem is StorageInfoModel item)
            {
                if (item.IsPicture)
                {

                }
                else if (item.DirectoryInfo != null)
                {
                    Model.NextStack.Clear();
                    (FindName("Button_Forward_Name") as Button).IsEnabled = false;

                    Model.PreviewStack.Push(Model.CurrentItem);
                    if (Model.PreviewStack.Count > 1)
                    {
                        (FindName("Button_Back_Name") as Button).IsEnabled = true;
                    }

                    Model.CurrentItem = item.DirectoryInfo;
                    Refresh_UcListViewStoragesServer();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender">The object sender of the event.</param>
        /// <param name="e"></param>
        private void UcListViewStoragesServer_Loaded(object sender, RoutedEventArgs e)
        {

        }


        #endregion



        #region Methods : Layout Size Changed

        /// <summary>
        /// Method called on <see cref="FrameworkElement"/> size changed event.
        /// </summary>
        /// <param name="sender">The <see cref="object"/> sender of the event.</param>
        /// <param name="e">The size changed event arguments <see cref="SizeChangedEventArgs"/>.</param>
        public override void Layout_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            try
            {
                // Initialize some variables
                var blockContent = FindName<FrameworkElement>("BlockMiddleContentName");
                var topContent = FindName<FrameworkElement>("BlockTopControlsName");
                var tabContentW = ((Frame)MainBlockContentTabs.SelectedContent).ActualWidth;
                var tabContentH = ((Frame)MainBlockContentTabs.SelectedContent).ActualHeight;

                // Arrange this height & width
                Width = Math.Max(tabContentW, 0);
                Height = Math.Max(tabContentH, 0);

                blockContent.Width = Width;
                blockContent.Height =
                    UcTreeViewDirectories.Height =
                    UcListViewStoragesServer.Height =
                Math.Max(Height - topContent.RenderSize.Height, 0);

                TraceSize(MainBlockContent);
                TraceSize(this);
                TraceSize(topContent);
                TraceSize(blockContent);
                TraceSize(UcTreeViewDirectories);
                TraceSize(UcListViewStoragesServer);
            }

            catch (Exception ex)
            {
                log.Error(ex.Output(), ex);
                MessageBoxs.Error(ex);
            }
        }

        #endregion
    }
}
