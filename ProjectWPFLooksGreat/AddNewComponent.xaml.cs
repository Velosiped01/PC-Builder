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

namespace ProjectWPFLooksGreat
{
   
    public partial class AddNewComponent : Window
    {
        
        private void SerializeXML(CpuModels CpuList)
        {
            XmlSerializer xml = new XmlSerializer(typeof(CpuModels));
            using (FileStream fs = new FileStream("CpuModels.xml", FileMode.OpenOrCreate))
            {
                xml.Serialize(fs, CpuList);

            }
        }
        private void SerializeXML(MotherBoardModels MbList)
        {
            XmlSerializer xml = new XmlSerializer(typeof(MotherBoardModels));
            using (FileStream fs = new FileStream("MotherBoardModels.xml", FileMode.OpenOrCreate))
            {
                xml.Serialize(fs, MbList);

            }
        }
        /*
        private CpuModels DeserializeXML(string filepath)
        {
            XmlSerializer xml = new XmlSerializer(typeof(CpuModels));
            using (FileStream fs = new FileStream(filepath, FileMode.OpenOrCreate))
            {
                if (filepath == "CpuModels.xml")
                {
                    CpuModels xmlcpu = (CpuModels)xml.Deserialize(fs);
                    return xmlcpu;
                }else if ("MotherBoardModels.xml" == filepath)
                {
                    CpuModels xmlmb = (CpuModels)xml.Deserialize(fs);
                    return xmlmb;

                }
                
            }
        } */
        private  UniModels DeserializeXML(string filepath)
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

        private void addComponentButton_Click(object sender, RoutedEventArgs e)
        {
            if (ModelNameTextBox.Text != null && TdpTextBox != null && FreqTextBox.Text != null && SocketTextBox.Text != null)
            {
                switch (componentCombobox.SelectedIndex)
                {

                    case 0:
                        
                        CpuModels cpuModels = new CpuModels();
                        UniModels cpudoc = DeserializeXML("CpuModels.xml");
                        foreach(UniModel uni in cpudoc.UniList)
                        {
                            CpuModel CPU = new CpuModel(uni.item1, Convert.ToInt32(uni.item2), Convert.ToInt32(uni.item3), uni.item4);
                            cpuModels.CpuList.Add(CPU);
                            SerializeXML(cpuModels);

                        }
                       /* CpuModels cpudoc = 
                        foreach (CpuModel cpu in cpudoc.CpuList)
                        {
                            cpuModels.CpuList.Add(cpu);
                        } */

                        try
                        {
                            CpuModel CPU = new CpuModel(ModelNameTextBox.Text, Convert.ToInt32(TdpTextBox.Text), Convert.ToInt32(FreqTextBox.Text), SocketTextBox.Text);
                            cpuModels.CpuList.Add(CPU);
                            SerializeXML(cpuModels);
                        }
                        catch { }
                        break;
                    case 1:
                        MotherBoardModels mbModels = new MotherBoardModels();
                        UniModels mbdoc = DeserializeXML("MotherBoardModels.xml");
                        foreach (UniModel uni in mbdoc.UniList)
                        {
                            MotherBoardModel MB = new MotherBoardModel(uni.item1, uni.item2, Convert.ToInt32(uni.item3), uni.item4);
                            mbModels.MbList.Add(MB);
                            SerializeXML(mbModels);

                        }

                        try
                        {
                            MotherBoardModel MB = new MotherBoardModel(ModelNameTextBox.Text, TdpTextBox.Text, Convert.ToInt32(FreqTextBox.Text), SocketTextBox.Text);
                            mbModels.MbList.Add(MB);
                            SerializeXML(mbModels);
                        }
                        catch { }

                        break;
                    case 2:
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
                            ModelNameTextBox.Text = "Cpu model";
                            SocketTextBox.Text = "Socket";
                            TdpTextBox.Text = "Tdp";
                            FreqTextBox.Text = "Frequency";
                            break;
                        case 1:
                            ModelNameTextBox.Text = "Mother board name";
                            SocketTextBox.Text = "Platform";
                            TdpTextBox.Text = "form";
                            FreqTextBox.Text = "Max cpu frequency"; 
                            break;
                        case 2: ModelNameTextBox.Text = "Gpu model";
                            SocketTextBox.Text = "GPU interface";
                            TdpTextBox.Text = "Width";
                            FreqTextBox.Text = "Height";
                                break;
                        default:
                            ModelNameTextBox.Text = "Cpu model";
                            SocketTextBox.Text = "Socket";
                            TdpTextBox.Text = "Tdp";
                            FreqTextBox.Text = "Frequency";
                            break;
                    }
                }
                catch { }
            }
            
        }
    }
}
