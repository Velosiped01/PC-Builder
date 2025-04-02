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
using System.Xml.Serialization;
using System.Xml;
using System.Xml.Linq;
using System.Diagnostics.Eventing.Reader;
using System.IO;


namespace ProjectWPFLooksGreat
{
    
    
    public partial class MainWindow : Window
    {
        public static AddNewComponent AddNewComponentWindow;
        
        private UniModels DeserializeXML(string filepath)
        {

            XmlSerializer xml = new XmlSerializer(typeof(UniModels));
            using (FileStream fs = new FileStream(filepath, FileMode.OpenOrCreate))
            {

                UniModels xmluni = (UniModels)xml.Deserialize(fs);

                return xmluni;
            }
        }
       
        

        public MainWindow()
        {
            InitializeComponent();
            if (File.Exists(@"CpuModels.xml"))
            {
                UniModels cpuActual = DeserializeXML("CpuModels.xml");
                foreach (CpuModel CPU in cpuActual.CpuList)
                {
                    cpuComboBox.Items.Add(CPU.cpu);
                }
            }
            if (File.Exists(@"MotherBoardModels.xml"))
            {
                UniModels mbActual = DeserializeXML("MotherBoardModels.xml");
                foreach (MotherBoardModel MB in mbActual.MbList)
                {
                    mbComboBox.Items.Add(MB.mbName);
                }
            }
        }




        private void MainWindow1_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            
        }

        

        private void compareButton_Click(object sender, RoutedEventArgs e)
        {
            CPUErrorTextBlock.Width = errorBorder.Width -20;
            cpuErrorStackPanel.Width = errorBorder.Width -20;
            string choosedCPU = cpuComboBox.Text;
            string choosedMB = mbComboBox.Text;
            string choosedGPU = gpuComboBox.Text;
            string choosedRAM = ramComboBox.Text;
            string choosedHSF = hsfComboBox.Text;
            string choosedPSU = psuComboBox.Text;
            string choosedCase = caseComboBox.Text;
            UniModels cpuActual = DeserializeXML("CpuModels.xml");
            UniModels MBActual = DeserializeXML("MotherBoardModels.xml");
            CPUErrorTextBlock.Text = Comparator.cpuCompare(choosedCPU, choosedMB, cpuActual, MBActual) ? "CPU is supported by mother board": "CPU isn't supported by mother board, change mb or cpu";
            




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