using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml.Serialization;
using System.Xml;
using System.Xml.Linq;
using System.Diagnostics.Eventing.Reader;
using MaterialDesignThemes.Wpf;

namespace ProjectWPFLooksGreat
{
   
    public partial class AddNewComponent : Window
    {
        
        private void SerializeXML(UniModels List, string filepath) //Serializace či zapis componentu do xml
        {
            XmlSerializer xml = new XmlSerializer(typeof(UniModels));
            using (FileStream fs = new FileStream(filepath, FileMode.OpenOrCreate))
            {
                xml.Serialize(fs, List);

            }
        }
        private  UniModels DeserializeXML(string filepath) //Vyběr komponentu z xml
        {
           
            XmlSerializer xml = new XmlSerializer(typeof(UniModels));
            using (FileStream fs = new FileStream(filepath, FileMode.OpenOrCreate))
            { 
                
                    UniModels xmluni = (UniModels)xml.Deserialize(fs);
                
               return xmluni;
            }
        }
        



        public AddNewComponent()
        {
            InitializeComponent();
        }

        private void addComponentButton_Click(object sender, RoutedEventArgs e)//přidava komponenty
        {
            if (ModelNameTextBox.Text != null && TdpTextBox != null && FreqTextBox.Text != null && SocketTextBox.Text != null)
            {
                switch (componentCombobox.SelectedIndex)
                {

                    case 0://cpu
                        UniModels cpuModels = new UniModels();
                        if (File.Exists(@"CpuModels.xml"))//kontrola na existence xml
                        {
                            
                            UniModels doc = DeserializeXML("CpuModels.xml");
                            foreach (CpuModel cpu in doc.CpuList)//at´ nesmaže stare komponenty
                            {
                                cpuModels.CpuList.Add(cpu);
                            }
                        }
                        try//aby program nespadl, kdyz zadate spatny format, nic nezapise do xml
                        {
                            CpuModel CPU = new CpuModel(ModelNameTextBox.Text, Convert.ToInt32(TdpTextBox.Text), SocketTextBox.Text);
                            cpuModels.CpuList.Add(CPU);
                            SerializeXML(cpuModels, "CpuModels.xml");
                        }
                        catch { }
                        break;
                    case 1://motherboard
                        UniModels mbModels = new UniModels();
                        if (File.Exists(@"MotherBoardModels.xml"))
                        {
                            UniModels doc = DeserializeXML("MotherBoardModels.xml");

                            foreach (MotherBoardModel mb in doc.MbList)
                            {
                                mbModels.MbList.Add(mb);
                            }
                        }
                        try
                        {
                            MotherBoardModel MB = new MotherBoardModel(ModelNameTextBox.Text,TdpTextBox.Text , FreqTextBox.Text, SocketTextBox.Text);
                            mbModels.MbList.Add(MB);
                            SerializeXML(mbModels, "MotherBoardModels.xml");
                        }
                        catch { }

                        break;
                    case 2://GPU
                        UniModels gpuModels = new UniModels();
                        if (File.Exists(@"GpuModels.xml"))
                        {
                            UniModels doc = DeserializeXML("GpuModels.xml");

                            foreach (GpuModel gpu in doc.GpuList)
                            {
                                gpuModels.GpuList.Add(gpu);
                            }
                        }
                        try 
                        {
                            GpuModel GPU = new GpuModel(ModelNameTextBox.Text, Convert.ToInt32(TdpTextBox.Text),Convert.ToInt32(FreqTextBox.Text));
                            gpuModels.GpuList.Add(GPU);
                            SerializeXML(gpuModels, "GpuModels.xml");
                        }
                        catch { }

                        break;
                    case 3://RAM
                        UniModels ramModels = new UniModels();
                        if (File.Exists(@"RamModels.xml"))
                        {
                            UniModels doc = DeserializeXML("RamModels.xml");

                            foreach (RamModel ram in doc.RamList)
                            {
                                ramModels.RamList.Add(ram);
                            }
                        }
                        try
                        {
                            RamModel RAM = new RamModel(ModelNameTextBox.Text, TdpTextBox.Text);
                            ramModels.RamList.Add(RAM);
                            SerializeXML(ramModels, "RamModels.xml");
                        }
                        catch { }

                        break;
                    case 4://Cooler/HSF
                        UniModels hsfModels = new UniModels();
                        if (File.Exists(@"CoolerModels.xml"))
                        {
                            UniModels doc = DeserializeXML("CoolerModels.xml");

                            foreach (HsfModel hsf in doc.HsfList)
                            {
                                hsfModels.HsfList.Add(hsf);
                            }
                        }
                        try
                        {
                            HsfModel HSF = new HsfModel(ModelNameTextBox.Text, TdpTextBox.Text.Split(','), Convert.ToInt32(FreqTextBox.Text), Convert.ToInt32(SocketTextBox.Text));
                            hsfModels.HsfList.Add(HSF);
                            SerializeXML(hsfModels, "CoolerModels.xml");
                            
                        }
                        catch { }

                        break;
                    case 5://PSU/Zdroj
                        UniModels psuModels = new UniModels();
                        if (File.Exists(@"PsuModels.xml"))
                        {
                            UniModels doc = DeserializeXML("PsuModels.xml");

                            foreach (PsuModel psu in doc.PsuList)
                            {
                                psuModels.PsuList.Add(psu);
                            }
                        }
                        try
                        {
                            PsuModel PSU = new PsuModel(ModelNameTextBox.Text, TdpTextBox.Text, Convert.ToInt32(FreqTextBox.Text));
                            psuModels.PsuList.Add(PSU);
                            SerializeXML(psuModels, "PsuModels.xml");
                        }
                        catch { }

                        break;
                    case 6://Case
                        UniModels caseModels = new UniModels();
                        if (File.Exists(@"CaseModels.xml"))
                        {
                            UniModels doc = DeserializeXML("CaseModels.xml");

                            foreach (CaseModel Case in doc.CaseList)
                            {
                                caseModels.CaseList.Add(Case);
                            }
                        }
                        try
                        {
                            CaseModel cs = new CaseModel(ModelNameTextBox.Text, TdpTextBox.Text, Convert.ToInt32(FreqTextBox.Text), Convert.ToInt32(SocketTextBox.Text));
                            caseModels.CaseList.Add(cs);
                            SerializeXML(caseModels, "CaseModels.xml");
                        }
                        catch { }

                        break;
                    default:
                        //nic
                       
                        break;
                }
               
            

            }
            
        }

        

        private void componentCombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ModelNameTextBox != null && componentCombobox != null)
            {
                try
                {
                    switch (componentCombobox.SelectedIndex)
                    {

                        case 0:
                            ModelNameTextBox.Text = "Cpu model Name";
                            TdpTextBox.Text = "Tdp<65>";
                            FreqTextBox.Text = "-";
                            SocketTextBox.Text = "Socket<AM4..>";
                            break;
                        case 1:
                            ModelNameTextBox.Text = "Mother board name";
                            TdpTextBox.Text = "format<ATX...>"; ;
                            FreqTextBox.Text = "Socket<AM4..>";
                            SocketTextBox.Text = "Memory type<DDR4..>";
                            break;
                        case 2: 
                            ModelNameTextBox.Text = "Gpu model";
                            TdpTextBox.Text = "Length";
                            FreqTextBox.Text = "Power comsumption";
                            SocketTextBox.Text = "-";
                            break;
                        case 3:
                            ModelNameTextBox.Text = "Ram model name";
                            TdpTextBox.Text = "Ram Type<DDR4..>";
                            FreqTextBox.Text = "-";
                            SocketTextBox.Text = "-";
                            break;
                        case 4:
                            ModelNameTextBox.Text = "Cooler name";
                            TdpTextBox.Text = "Cooler socket<AM4,AM5,...>";
                            FreqTextBox.Text = "Cooler max tdp";
                            SocketTextBox.Text = "Cooler height";
                            break;
                        case 5:
                            ModelNameTextBox.Text = "Psu name";
                            TdpTextBox.Text = "Psu form<ATX..>";
                            FreqTextBox.Text = "Psu power<800..>";
                            SocketTextBox.Text = "-";
                            break;
                        case 6:
                            ModelNameTextBox.Text = "Case model name";
                            TdpTextBox.Text = "Case form<ATX..>";
                            FreqTextBox.Text = "Max GPU Length";
                            SocketTextBox.Text = "Max cooler height";
                            break;
                        default:
                            ModelNameTextBox.Text = "Cpu model";
                            TdpTextBox.Text = "Tdp";
                            FreqTextBox.Text = "Frequency";
                            SocketTextBox.Text = "Socket";
                            break;
                    }
                }
                catch { }
            }
            
        }
    }
}
