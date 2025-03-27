using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProjectWPFLooksGreat
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    
    public partial class MainWindow : Window
    {
        public static AddNewComponent AddNewComponentWindow;

        public MainWindow()
        {
            InitializeComponent();
            
        }



        private void MainWindow1_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            
        }

        

        private void compareButton_Click(object sender, RoutedEventArgs e)
        {
            cpuError.Width = errorBorder.Width -20;
            cpuErrorStackPanel.Width = errorBorder.Width -20;
        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void scaleButton_Click(object sender, RoutedEventArgs e)
        {
            if(WindowState == WindowState.Normal)
            {
                WindowState = WindowState.Maximized;
            }
            else
            {
                WindowState = WindowState.Normal;
            }
        }

        private void minimalizeButton_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void addNewComponentButton_Click(object sender, RoutedEventArgs e)
        { 
            if (AddNewComponentWindow == null || AddNewComponentWindow.IsVisible == false)
            {
                AddNewComponentWindow = new AddNewComponent();
                AddNewComponentWindow.Show();
            }
            else
            {
                
             AddNewComponentWindow.Activate();
            }
           
        }
    }
}