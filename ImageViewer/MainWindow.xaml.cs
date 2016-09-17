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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ImageViewer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ImageManager imageManager;

        public MainWindow()
        {
            InitializeComponent();

            try
            {             
                imageManager = this.FindResource("imageManager") as ImageManager;
            }
            catch(ResourceReferenceKeyNotFoundException e)
            {
                MessageBox.Show("Error: " + e.Message);
                Application.Current.Shutdown();
            }
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
                imageManager.LoadImage(openDialog.FileName);
            }
        }
    }
}
