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
            try
            {
                XmlSerializer xml = new XmlSerializer(typeof(UniModels));
                using (FileStream fs = new FileStream(filepath, FileMode.Open))
                {

                    UniModels xmluni = (UniModels)xml.Deserialize(fs);

                    return xmluni;
                }
            }
            catch{ } return null;
        }
       
        

        public MainWindow()
        {
            InitializeComponent();
            
        }




        private void MainWindow1_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            
        }

        

        private void compareButton_Click(object sender, RoutedEventArgs e) //tlacitko na porovnani vsech komponent
        {
            
            
            string choosedCPU = cpuComboBox.Text;
            string choosedMB = mbComboBox.Text;
            string choosedGPU = gpuComboBox.Text;
            string choosedRAM = ramComboBox.Text;
            string choosedHSF = hsfComboBox.Text;
            string choosedPSU = psuComboBox.Text;
            string choosedCase = caseComboBox.Text;
            UniModels cpuActual = DeserializeXML("CpuModels.xml");
            UniModels MBActual = DeserializeXML("MotherBoardModels.xml");
            UniModels GpuActual = DeserializeXML("GpuModels.xml");
            UniModels RamActual = DeserializeXML("RamModels.xml");
            UniModels HsfActual = DeserializeXML("CoolerModels.xml");
            UniModels PsuActual = DeserializeXML("PsuModels.xml");
            UniModels CaseActual = DeserializeXML("CaseModels.xml");
            CPUErrorTextBlock.Text = Comparator.cpuCompare(choosedCPU, choosedMB, cpuActual, MBActual);
            MBErrorTextBlock.Text = Comparator.mbCompare(choosedCPU, choosedMB, cpuActual, MBActual);
            GPUErrorTextBlock.Text = Comparator.gpuCompare(choosedGPU, GpuActual);
            RAMErrorTextBlock.Text = Comparator.ramCompare(choosedRAM, choosedMB, RamActual, MBActual);
            HSFErrorTextBlock.Text = Comparator.hsfCompare(choosedHSF, choosedCPU, HsfActual, cpuActual);
            PSUErrorTextBlock.Text = Comparator.psuCompare(choosedPSU, choosedCPU, choosedGPU, PsuActual, GpuActual, cpuActual);
            CASEErrorTextBlock.Text = Comparator.caseCompare(choosedCase, choosedGPU, choosedPSU, choosedHSF, choosedMB, CaseActual, GpuActual, PsuActual, HsfActual, MBActual);




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

         private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            if (File.Exists(@"CpuModels.xml"))
            {
                cpuComboBox.Items.Clear();
                UniModels cpuActual = DeserializeXML("CpuModels.xml");
                foreach (CpuModel CPU in cpuActual.CpuList)
                {
                    cpuComboBox.Items.Add(CPU.cpu);
                }
            }
            if (File.Exists(@"MotherBoardModels.xml"))
            {
                mbComboBox.Items.Clear();
                UniModels mbActual = DeserializeXML("MotherBoardModels.xml");
                foreach (MotherBoardModel MB in mbActual.MbList)
                {
                    mbComboBox.Items.Add(MB.mbName);
                }
            }
            if (File.Exists(@"GpuModels.xml"))
            {
                gpuComboBox.Items.Clear();
                UniModels gpuActual = DeserializeXML("GpuModels.xml");
                foreach (GpuModel GPU in gpuActual.GpuList)
                {
                    gpuComboBox.Items.Add(GPU.gpuName);
                }
            }
            if (File.Exists(@"RamModels.xml"))
            {
                ramComboBox.Items.Clear();
                UniModels ramActual = DeserializeXML("RamModels.xml");
                foreach (RamModel RAM in ramActual.RamList)
                {
                    ramComboBox.Items.Add(RAM.ramName);
                }
            }
            if (File.Exists(@"CoolerModels.xml"))
            {
                hsfComboBox.Items.Clear();
                UniModels hsfActual = DeserializeXML("CoolerModels.xml");
                foreach (HsfModel hsf in hsfActual.HsfList)
                {
                    hsfComboBox.Items.Add(hsf.hsfName);
                }
            }
            if (File.Exists(@"PsuModels.xml"))
            {
                psuComboBox.Items.Clear();
                UniModels psuActual = DeserializeXML("PsuModels.xml");
                foreach (PsuModel psu in psuActual.PsuList)
                {
                    psuComboBox.Items.Add(psu.psuName);
                }
            }
            if (File.Exists(@"CaseModels.xml"))
            {
                caseComboBox.Items.Clear();
                UniModels caseActual = DeserializeXML("CaseModels.xml");
                foreach (CaseModel Case in caseActual.CaseList)
                {
                    caseComboBox.Items.Add(Case.caseName);
                }
            }
        }

        private void chooseTheCompLabel_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if(e.ButtonState == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }
    }
}