using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Collections.ObjectModel;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ImageViewer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ImageDisplayManager imageDisplayManager;

        public MainWindow()
        {
            InitializeComponent();

            this.SizeChanged += MainWindow_SizeChanged;
            
            try
            {
                imageDisplayManager = this.FindResource("imageDisplayManager") as ImageDisplayManager;
                canvasItemControl.ItemsSource = imageDisplayManager.DisplayImages;
            }
            catch(ResourceReferenceKeyNotFoundException e)
            {
                MessageBox.Show("Error: " + e.Message);
                Application.Current.Shutdown();
            }
        }

        private void MainWindow_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            imageDisplayManager.RefitWindow(displayGrid.ActualWidth, displayGrid.ActualHeight);
        }

        private void MenuItem_Open(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog();

            openDialog.Filter = ExtensionManager.GetExtensionFilters();
            openDialog.Title = "Select an Image File";
            openDialog.FilterIndex = 0;
            openDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);

            var result = openDialog.ShowDialog();
            if(result.GetValueOrDefault() == true)
            {
                imageDisplayManager.LoadNewImage(openDialog.FileName, displayGrid.ActualWidth, displayGrid.ActualHeight);
            }
        }
        
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Right)
            {
                imageDisplayManager.SetDisplayedImageNext(displayGrid.ActualWidth, displayGrid.ActualHeight);
            }
            else if (e.Key == Key.Left)
            {
                imageDisplayManager.SetDisplayedImagePrevious(displayGrid.ActualWidth, displayGrid.ActualHeight);
            }   
        }

        private void behindCanvasRectangle_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount > 1)
            {
                imageDisplayManager.SetNextDisplayMode(displayGrid.ActualWidth, displayGrid.ActualHeight);
                e.Handled = true;
            }
        }

        private void MenuItem_FitImage(object sender, RoutedEventArgs e)
        {
            imageDisplayManager.SetDisplayMode(ImageDisplayMode.Window, displayGrid.ActualWidth, displayGrid.ActualHeight);
        }

        private void MenuItem_ActualImageSize(object sender, RoutedEventArgs e)
        {
            imageDisplayManager.SetDisplayMode(ImageDisplayMode.Actual, displayGrid.ActualWidth, displayGrid.ActualHeight);
        }

        private void MenuItem_PreviousImage(object sender, RoutedEventArgs e)
        {
            imageDisplayManager.SetDisplayedImagePrevious(displayGrid.ActualWidth, displayGrid.ActualHeight);
        }

        private void MenuItem_NextImage(object sender, RoutedEventArgs e)
        {
            imageDisplayManager.SetDisplayedImageNext(displayGrid.ActualWidth, displayGrid.ActualHeight);
        }
    }
}
