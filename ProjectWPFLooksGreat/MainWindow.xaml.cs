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
        public MainWindow()
        {
            InitializeComponent();
            
        }




        private void MainWindow1_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            
        }

        

        private void compareButton_Click(object sender, RoutedEventArgs e) //tlacitko na porovnani vsech komponent
        { // vytahuje objekt z comboboxu, zapisuje ten objekt do promenny 
            //zavola metody z comparator.cs pro kazdou componentu pc a vraci string s vysledkem do textblocku 
            CpuModel choosedCPU = (CpuModel) cpuComboBox.SelectedItem;
            MotherBoardModel choosedMB = (MotherBoardModel) mbComboBox.SelectedItem;
            GpuModel choosedGPU = (GpuModel) gpuComboBox.SelectedItem;
            RamModel choosedRAM = (RamModel) ramComboBox.SelectedItem;
            HsfModel choosedHSF = (HsfModel) hsfComboBox.SelectedItem;
            PsuModel choosedPSU = (PsuModel) psuComboBox.SelectedItem;
            CaseModel choosedCase = (CaseModel) caseComboBox.SelectedItem;
            CPUErrorTextBlock.Text = Comparator.cpuCompare(choosedCPU, choosedMB);
            MBErrorTextBlock.Text = Comparator.cpuCompare(choosedCPU, choosedMB);
            GPUErrorTextBlock.Text = Comparator.gpuCompare(choosedGPU);
            RAMErrorTextBlock.Text = Comparator.ramCompare(choosedRAM, choosedMB);
            HSFErrorTextBlock.Text = Comparator.hsfCompare(choosedHSF, choosedCPU);
            PSUErrorTextBlock.Text = Comparator.psuCompare(choosedPSU, choosedCPU, choosedGPU);
            CASEErrorTextBlock.Text = Comparator.caseCompare(choosedCase, choosedGPU, choosedPSU, choosedHSF, choosedMB);
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
                UniModels cpuActual = UniModels.DeserializeXML("CpuModels.xml");
                foreach (CpuModel CPU in cpuActual.CpuList)
                {
                    cpuComboBox.Items.Add(CPU);
                }
            }
            if (File.Exists(@"MotherBoardModels.xml"))
            {
                mbComboBox.Items.Clear();
                UniModels mbActual = UniModels.DeserializeXML("MotherBoardModels.xml");
                foreach (MotherBoardModel MB in mbActual.MbList)
                {
                    mbComboBox.Items.Add(MB);
                }
            }
            if (File.Exists(@"GpuModels.xml"))
            {
                gpuComboBox.Items.Clear();
                UniModels gpuActual = UniModels.DeserializeXML("GpuModels.xml");
                foreach (GpuModel GPU in gpuActual.GpuList)
                {
                    gpuComboBox.Items.Add(GPU);
                }
            }
            if (File.Exists(@"RamModels.xml"))
            {
                ramComboBox.Items.Clear();
                UniModels ramActual = UniModels.DeserializeXML("RamModels.xml");
                foreach (RamModel RAM in ramActual.RamList)
                {
                    ramComboBox.Items.Add(RAM);
                }
            }
            if (File.Exists(@"CoolerModels.xml"))
            {
                hsfComboBox.Items.Clear();
                UniModels hsfActual = UniModels.DeserializeXML("CoolerModels.xml");
                foreach (HsfModel hsf in hsfActual.HsfList)
                {
                    hsfComboBox.Items.Add(hsf);
                }
            }
            if (File.Exists(@"PsuModels.xml"))
            {
                psuComboBox.Items.Clear();
                UniModels psuActual = UniModels.DeserializeXML("PsuModels.xml");
                foreach (PsuModel psu in psuActual.PsuList)
                {
                    psuComboBox.Items.Add(psu);
                }
            }
            if (File.Exists(@"CaseModels.xml"))
            {
                caseComboBox.Items.Clear();
                UniModels caseActual = UniModels.DeserializeXML("CaseModels.xml");
                foreach (CaseModel Case in caseActual.CaseList)
                {
                    caseComboBox.Items.Add(Case);
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