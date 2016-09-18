using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
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

            openDialog.Filter = "Image Files (.jpg)|*.jpg";
            openDialog.Title = "Select an Image File";
            openDialog.FilterIndex = 0;
            openDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);

            var result = openDialog.ShowDialog();
            if(result.GetValueOrDefault() == true)
            {
                imageDisplayManager.SetSingleImage(openDialog.FileName, displayGrid.ActualWidth, displayGrid.ActualHeight);
            }
        }

        private void canvasItemControl_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            imageDisplayManager.ChangeDisplayMode(displayGrid.ActualWidth, displayGrid.ActualHeight);
        }
    }
}
