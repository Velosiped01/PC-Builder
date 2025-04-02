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
                        if (File.Exists(@"CpuModels.xml"))//kontrola na nenulovy stav xml
                        {
                            
                            UniModels cpudoc = DeserializeXML("CpuModels.xml");
                            foreach (CpuModel cpu in cpudoc.CpuList)//at´ nesmaže stare komponenty
                            {
                                cpuModels.CpuList.Add(cpu);
                            }
                        }
                        try
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
                            UniModels mbdoc = DeserializeXML("MotherBoardModels.xml");

                            foreach (MotherBoardModel mb in mbdoc.MbList)
                            {
                                mbModels.MbList.Add(mb);
                            }
                        }
                        try
                        {
                            MotherBoardModel MB = new MotherBoardModel(ModelNameTextBox.Text, FreqTextBox.Text, SocketTextBox.Text, ramtextbox.Text);
                            mbModels.MbList.Add(MB);
                            SerializeXML(mbModels, "MotherBoardModels.xml");
                        }
                        catch { }

                        break;
                    case 2://GPU
                       //"Gpu model";
                        
                        break;
                    default:
                        //furt nic
                       
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
                            FreqTextBox.Text = "EMPTY SPACE";
                            SocketTextBox.Text = "Socket<AM4..>";
                            ramtextbox.Text = "EMPTY SPACE";
                            break;
                        case 1:
                            ModelNameTextBox.Text = "Mother board name";
                            TdpTextBox.Text = "EMPTY SPACE";
                            FreqTextBox.Text = "format<ATX...>";
                            SocketTextBox.Text = "Socket<AM4..>";
                            ramtextbox.Text = "Memory type<DDR4..>";
                            break;
                        case 2: 
                            ModelNameTextBox.Text = "Gpu model";
                            TdpTextBox.Text = "Width";
                            FreqTextBox.Text = "Height";
                            SocketTextBox.Text = "GPU interface";
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
