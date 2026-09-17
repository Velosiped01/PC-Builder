using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.TextFormatting;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace ProjectWPFLooksGreat
{
    public interface IUniComponent
    {
        void AddTo(UniModels models);
    }
    [Serializable]
    public class UniModels
    {
        public static UniModels DeserializeXML(string filepath)
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
            catch { }
            return null;
        }
        public static void SerializeXML(UniModels List, string filepath) //Serializace či zapis componentu do xml
        {
            XmlSerializer xml = new XmlSerializer(typeof(UniModels));
            using (FileStream fs = new FileStream(filepath, FileMode.OpenOrCreate))
            {
                xml.Serialize(fs, List);

            }
        }
       
        public List<CpuModel> CpuList { get; set; } = new List<CpuModel>();
        public List<MotherBoardModel> MbList { get; set; } = new List<MotherBoardModel>();
        public List<GpuModel> GpuList { get; set; } = new List<GpuModel>();
        public List<RamModel> RamList { get; set; } = new List<RamModel>();
        public List<HsfModel> HsfList { get; set; } = new List<HsfModel>();
        public List<PsuModel> PsuList { get; set; } = new List<PsuModel>();
        public List<CaseModel> CaseList { get; set; } = new List<CaseModel>();
    }

    [Serializable]
    public class CpuModel: IUniComponent{
        public string cpu { get; set; }
        public int tdp { get; set; }
        public string socket { get; set; }
        
        public void AddTo(UniModels models)
        {
            models.CpuList.Add(this);
        }
        
        public override string ToString()
        {
            return cpu;
        }
       
        
        public CpuModel() { }
        public CpuModel(string cpu, int tdp, string socket)
        {
            this.cpu = cpu;
            this.tdp = tdp;
            this.socket = socket;

        }
    }
    [Serializable]
    public class MotherBoardModel:IUniComponent
    {
        public string mbName { get; set; }
        public string mbsocket { get; set; }
        public string mbform { get; set; }
        public string supportedram { get; set; }
        public void AddTo(UniModels models)
        {
            models.MbList.Add(this);
        }
        public override string ToString()
        {
            return mbName;
        }
        public MotherBoardModel() { }

        public MotherBoardModel(string mbName, string mbform, string mbsocket, string supportedram)
        {
            this.mbName = mbName;
            this.mbsocket = mbsocket;
            this.mbform = mbform;
            this.supportedram = supportedram;

        }
    }
    [Serializable]
    public class GpuModel:IUniComponent
    {
        public string gpuName { get; set; }
        public int gpuLenght { get; set; }
        public int gpuPowerComs { get; set; }
        public override string ToString()
        {
            return gpuName;
        }
        public void AddTo(UniModels models)
        {
            models.GpuList.Add(this);
        }
        public GpuModel() { }

        public GpuModel(string gpuName, int gpuLenght, int gpuPowerComs)
        {
            this.gpuName = gpuName;
            this.gpuLenght = gpuLenght;
            this.gpuPowerComs = gpuPowerComs;
        }
    }
    [Serializable]
    public class RamModel:IUniComponent
    {
        public string ramName { get; set; }
        public string ramType { get; set; }

        public override string ToString()
        {
            return ramName;
        }
        public void AddTo(UniModels models)
        {
            models.RamList.Add(this);
        }
        public RamModel() { }

        public RamModel(string ramName, string ramType)
        {
            this.ramName = ramName;
            this.ramType = ramType;
        }
    }
    [Serializable]
    public class HsfModel:IUniComponent
    {
        public string hsfName { get; set; }
        public string [] hsfSocket { get; set; }
        public int hsfTdp { get; set; }
        public int hsfHeight { get; set; }
        public void AddTo(UniModels models)
        {
            models.HsfList.Add(this);
        }
        public override string ToString()
        {
            return hsfName;
        }
        public HsfModel() { }

        public HsfModel(string hsfName, string [] hsfSocket, int hsfTdp, int hsfHeight)
        {
            this.hsfName = hsfName;
            this.hsfSocket = hsfSocket;
            this.hsfTdp = hsfTdp;
            this.hsfHeight = hsfHeight;
        }
    }
    [Serializable]
    public class PsuModel:IUniComponent
    {
        public string psuName { get; set; }
        public string psuForm { get; set; }
        public int psuPower { get; set; }

        public override string ToString()
        {
            return psuName;
        }
        public void AddTo(UniModels models)
        {
            models.PsuList.Add(this);
        }
        public PsuModel() { }

        public PsuModel(string psuName, string psuForm, int psuPower)
        {
            this.psuName = psuName;
            this.psuForm = psuForm;
            this.psuPower = psuPower;
        }
    }
    [Serializable]
    public class CaseModel:IUniComponent
    {
        public string caseName { get; set; }
        public string caseForm { get; set; }
        public int maxGpuLength { get; set; }
        public int maxHsfHeight { get; set; }

        public override string ToString()
        {
            return caseName;
        }
        public void AddTo(UniModels models)
        {
            models.CaseList.Add(this);
        }
        public CaseModel() { }

        public CaseModel(string caseName, string caseForm, int maxGpuLength, int maxHsfHeight)
        {
            this.caseName = caseName;
            this.caseForm = caseForm;
            this.maxGpuLength = maxGpuLength;
            this.maxHsfHeight = maxHsfHeight;
        }
    }
}
