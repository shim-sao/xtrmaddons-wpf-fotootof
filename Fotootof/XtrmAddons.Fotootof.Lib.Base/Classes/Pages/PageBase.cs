﻿using Microsoft.Win32;
using System.Drawing.Imaging;
using System.Windows;
using System.Windows.Controls;
using XtrmAddons.Fotootof.Lib.Base.Interfaces;
using XtrmAddons.Net.Application;

namespace XtrmAddons.Fotootof.Lib.Base.Classes.Pages
{
    /// <summary>
    /// Class XtrmAddons Fotootof Server Libraries Base Page.
    /// </summary>
    public abstract partial class PageBase : Page, IContentInit, ISizeChanged
    {
        #region Variables

        /// <summary>
        /// Variable logger.
        /// </summary>
        protected static readonly log4net.ILog log =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// Variable page width marging for content adjustement on size changed.
        /// </summary>
        protected double MargingWidth = SystemParameters.VerticalScrollBarWidth + 20;

        /// <summary>
        /// Variable page height marging for content adjustement on size changed.
        /// </summary>
        protected double MargingHeight = SystemParameters.HorizontalScrollBarHeight + 215;
        
        /// <summary>
        /// 
        /// </summary>
        public static Window AppWindow = (Window)ApplicationSession.Properties.MainWindow;

        #endregion



        #region Methods

        /// <summary>
        /// Method called after required component initialized.
        /// </summary>
        public void AfterInitializedComponent()
        {
            Loaded += (s, e) => InitializeContent();

            // Initialize on window size event changes.
            SizeChanged += Window_SizeChanged;
            AppWindow.SizeChanged += Window_SizeChanged;

            // Merge main resources.
            Resources.MergedDictionaries.Add(AppWindow.Resources);
        }

        /// <summary>
        /// Method to initialize and display data context.
        /// </summary>
        public abstract void InitializeContent();

        /// <summary>
        /// Method to initialize and display data context.
        /// </summary>
        public abstract void InitializeContentAsync();

        /// <summary>
        /// Method called on window sized changed.
        /// </summary>
        /// <param name="sender">The object sender of the event.</param>
        /// <param name="e">Size changed event arguments.</param>
        protected void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {       
            if (AppWindow.ActualWidth > MargingWidth && (AppWindow.ActualWidth - MargingWidth) > 0)
            {
                Width = AppWindow.ActualWidth - MargingWidth;
            }

            if (AppWindow.ActualHeight > MargingHeight && (AppWindow.ActualHeight - MargingHeight) > 0)
            {
                Height = AppWindow.ActualHeight - MargingHeight;
            }
        }

        /// <summary>
        /// Method to display picture file dialog box selector.
        /// </summary>
        /// <param name="multiselect">Multiple selection enabled ?. False by default. Optional.</param>
        /// <returns>A picture file dialog box selector, null if canceled.</returns>
        protected OpenFileDialog PictureFileDialogBox(bool multiselect = false)
        {
            // Configure open file dialog box 
            OpenFileDialog dlg = new OpenFileDialog
            {
                Filter = ""
            };

            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();
            string sep = string.Empty;

            foreach (var c in codecs)
            {
                string codecName = c.CodecName.Substring(8).Replace("Codec", "Files").Trim();
                dlg.Filter = string.Format("{0}{1}{2} ({3})|{3}", dlg.Filter, sep, codecName, c.FilenameExtension);
                sep = "|";
            }
            var a = Resources;
            dlg.Filter = string.Format("{0}{1}{2} ({3})|{3}", dlg.Filter, sep, "All Files", "*.*");
            dlg.DefaultExt = ".JPG"; // Default file extension 
            dlg.FilterIndex = 2;
            dlg.Multiselect = multiselect;
            dlg.Title = Culture.Translation.DWords.DialogBoxTitle_PictureFileSelector;
            
            // Show open file dialog box 
            bool? result = dlg.ShowDialog();

            // Process open file dialog box results 
            if (result == true)
            {
                return dlg;
            }

            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <param name="destination"></param>
        /// <param name="margin"></param>
        public void StretchHeight(FrameworkElement source, FrameworkElement destination, double margin = 0)
        {
            /*destination.MinHeight = source.ActualHeight - margin;
            destination.MaxHeight = source.ActualHeight - margin;*/
            destination.Height = source.ActualHeight - margin;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <param name="destination"></param>
        /// <param name="margin"></param>
        public void StretchWidth(FrameworkElement source, FrameworkElement destination, double margin = 0)
        {
            /*destination.MinWidth = source.ActualWidth - margin;
            destination.MaxWidth = source.ActualWidth - margin;*/
            destination.Width = source.ActualWidth - margin;
        }

        /// <summary>
        /// Method called on page size changed event.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">Size changed event arguments.</param>
        public abstract void Control_SizeChanged(object sender, SizeChangedEventArgs e);

        #endregion
    }
}
