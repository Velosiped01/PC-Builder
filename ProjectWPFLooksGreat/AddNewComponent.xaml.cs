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
using System.ComponentModel;

namespace ProjectWPFLooksGreat
{

    public partial class AddNewComponent : Window
    {
        public static void AddComponent(string filepath, IUniComponent component)
        {
            UniModels models = File.Exists(filepath) ? UniModels.DeserializeXML(filepath) : new UniModels();
            component.AddTo(models);
            UniModels.SerializeXML(models, filepath);
        }
    

        public AddNewComponent()
        {
            InitializeComponent();
        }

        private void addComponentButton_Click(object sender, RoutedEventArgs e)//přidava komponenty
        {
            if (ModelNameTextBox.Text != null && TdpTextBox != null && FreqTextBox.Text != null && SocketTextBox.Text != null)
            {
                int model;
                int tdp;
                int freq;
                int socket;
                switch (componentCombobox.SelectedIndex)
                {
                    case 0: //cpu
                        if (int.TryParse(TdpTextBox.Text, out tdp))
                        {
                            CpuModel CPU = new CpuModel(ModelNameTextBox.Text, tdp, SocketTextBox.Text);
                            AddComponent(@"CpuModels.xml", CPU);
                            resultLabel.Content = "Success";
                        }
                        else { resultLabel.Content = "Invalid TDP"; }
                        break;
                    case 1://motherboard
                        MotherBoardModel MB = new MotherBoardModel(ModelNameTextBox.Text, TdpTextBox.Text, FreqTextBox.Text, SocketTextBox.Text);
                        AddComponent(@"MotherBoardModels.xml", MB);
                        resultLabel.Content = "Success";
                        break;
                    case 2://GPU
                        if (int.TryParse(TdpTextBox.Text, out tdp) && int.TryParse(FreqTextBox.Text, out freq)){
                            GpuModel GPU = new GpuModel(ModelNameTextBox.Text, tdp , freq);
                            AddComponent(@"GpuModels.xml", GPU);
                            resultLabel.Content = "Success";
                        }
                        else { resultLabel.Content = "Invalid Length or Power comsumption"; }
                        break;
                    case 3://RAM
                        RamModel RAM = new RamModel(ModelNameTextBox.Text, TdpTextBox.Text);
                        AddComponent(@"RamModels.xml", RAM);
                        resultLabel.Content = "Success";
                        break;
                    case 4://Cooler/HSF
                        if (int.TryParse(SocketTextBox.Text, out socket) && int.TryParse(FreqTextBox.Text, out freq))
                        {
                            HsfModel HSF = new HsfModel(ModelNameTextBox.Text, TdpTextBox.Text.Split(','), freq, socket);
                            AddComponent(@"CoolerModels.xml", HSF);
                            resultLabel.Content = "Success";
                        } else { resultLabel.Content = "Invalid tdp or height"; }
                        break;
                    case 5://PSU/Zdroj
                        if (int.TryParse(FreqTextBox.Text, out freq))
                        {
                            PsuModel PSU = new PsuModel(ModelNameTextBox.Text, TdpTextBox.Text, freq);
                            AddComponent(@"PsuModels.xml", PSU);
                            resultLabel.Content = "Success";
                        } else { resultLabel.Content = "Invalid power of PSU"; }
                            break;
                    case 6://Case
                        if (int.TryParse(SocketTextBox.Text, out socket) && int.TryParse(FreqTextBox.Text, out freq))
                        {
                            CaseModel CASE = new CaseModel(ModelNameTextBox.Text, TdpTextBox.Text, freq , socket);
                            AddComponent(@"CaseModels.xml", CASE);
                            resultLabel.Content = "Success";
                        }
                        else { resultLabel.Content = "Invalid Max cooler height or Max GPU Length"; }
                        
                        break;
                    default: resultLabel.Content = "Choose the type of component"; break;
                }

            }
             else{ resultLabel.Content = "Failure"; }
            

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
                            AddNewComponentHelperTextBlock.Text = "Example( name:Amd Ryzen 7 3700X tdp:65 socket:AM4). Dont add spaces where they arent be and write in the same case as shown in the example";
                            break;
                        case 1:
                            ModelNameTextBox.Text = "Mother board name";
                            TdpTextBox.Text = "format<ATX...>"; ;
                            FreqTextBox.Text = "Socket<AM4..>";
                            SocketTextBox.Text = "Memory type<DDR4..>";
                            AddNewComponentHelperTextBlock.Text = "Example( name:GIGABYTE B550 Format:mATX... socket:AM4 Memory type:DDR4). Dont add spaces where they arent be and write in the same case as shown in the example";
                            break;
                        case 2: 
                            ModelNameTextBox.Text = "Gpu model";
                            TdpTextBox.Text = "Length";
                            FreqTextBox.Text = "Power comsumption";
                            SocketTextBox.Text = "-";
                            AddNewComponentHelperTextBlock.Text = "Example( name:GAINWARD GeForce RTX 3070 Length:310 Power Consumption:250). Dont add spaces where they arent be and write in the same case as shown in the example";
                            break;
                        case 3:
                            ModelNameTextBox.Text = "Ram model name";
                            TdpTextBox.Text = "Ram Type<DDR4..>";
                            FreqTextBox.Text = "-";
                            SocketTextBox.Text = "-";
                            AddNewComponentHelperTextBlock.Text = "Example( name:Kingston FURY 32GB KIT DDR4, Ram type:DDR4). Dont add spaces where they arent be and write in the same case as shown in the example";
                            break;
                        case 4:
                            ModelNameTextBox.Text = "Cooler name";
                            TdpTextBox.Text = "Cooler socket<AM4,AM5,...>";
                            FreqTextBox.Text = "Cooler max tdp";
                            SocketTextBox.Text = "Cooler height";
                            AddNewComponentHelperTextBlock.Text = "Example( name:Cooler Master HYPER 212 socket:AM4,AM5,1150,1151... TDP:120 Height:315). Dont add spaces where they arent be and write in the same case as shown in the example";
                            break;
                        case 5:
                            ModelNameTextBox.Text = "Psu name";
                            TdpTextBox.Text = "Psu form<ATX..>";
                            FreqTextBox.Text = "Psu power<800..>";
                            SocketTextBox.Text = "-";
                            AddNewComponentHelperTextBlock.Text = "Example( name:Corsair RM850x format:mATX power:750). Dont add spaces where they arent be and write in the same case as shown in the example";
                            break;
                        case 6:
                            ModelNameTextBox.Text = "Case model name";
                            TdpTextBox.Text = "Case form<ATX..>";
                            FreqTextBox.Text = "Max GPU Length";
                            SocketTextBox.Text = "Max cooler height";
                            AddNewComponentHelperTextBlock.Text = "Example( name:Montech X3 MESH form:ATX Max gpu length:370 Max cooler height:215). Dont add spaces where they arent be and write in the same case as shown in the example";
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
