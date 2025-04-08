using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.TextFormatting;

namespace ProjectWPFLooksGreat
{
    [Serializable]
    public class UniModels
    {
        
        public List<CpuModel> CpuList { get; set; } = new List<CpuModel>();
        public List<MotherBoardModel> MbList { get; set; } = new List<MotherBoardModel>();
        public List<GpuModel> GpuList { get; set; } = new List<GpuModel>();
        public List<RamModel> RamList { get; set; } = new List<RamModel>();
        public List<HsfModel> HsfList { get; set; } = new List<HsfModel>();
        public List<PsuModel> PsuList { get; set; } = new List<PsuModel>();
        public List<CaseModel> CaseList { get; set; } = new List<CaseModel>();
    }

    [Serializable]
    public class CpuModel
    {
        public string cpu { get; set; }
        public int tdp { get; set; }
        public string socket { get; set; }

        public CpuModel() { }

        public CpuModel(string cpu, int tdp, string socket)
        {
            this.cpu = cpu;
            this.tdp = tdp;
            this.socket = socket;

        }
    }
    [Serializable]
    public class MotherBoardModel
    {
        public string mbName { get; set; }
        public string mbsocket { get; set; }
        public string mbform { get; set; }
        public string supportedram { get; set; }

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
    public class GpuModel
    {
        public string gpuName { get; set; }
        public int gpuLenght { get; set; }
        public int gpuPowerComs { get; set; }
        

        public GpuModel() { }

        public GpuModel(string gpuName, int gpuLenght, int gpuPowerComs)
        {
            this.gpuName = gpuName;
            this.gpuLenght = gpuLenght;
            this.gpuPowerComs = gpuPowerComs;
        }
    }
    public class RamModel
    {
        public string ramName { get; set; }
        public string ramType { get; set; }
        

        public RamModel() { }

        public RamModel(string ramName, string ramType)
        {
            this.ramName = ramName;
            this.ramType = ramType;
        }
    }
    public class HsfModel
    {
        public string hsfName { get; set; }
        public string [] hsfSocket { get; set; }
        public int hsfTdp { get; set; }
        public int hsfHeight { get; set; }


        public HsfModel() { }

        public HsfModel(string hsfName, string [] hsfSocket, int hsfTdp, int hsfHeight)
        {
            this.hsfName = hsfName;
            this.hsfSocket = hsfSocket;
            this.hsfTdp = hsfTdp;
            this.hsfHeight = hsfHeight;
        }
    }
    public class PsuModel
    {
        public string psuName { get; set; }
        public string psuForm { get; set; }
        public int psuPower { get; set; }


        public PsuModel() { }

        public PsuModel(string psuName, string psuForm, int psuPower)
        {
            this.psuName = psuName;
            this.psuForm = psuForm;
            this.psuPower = psuPower;
        }
    }
    public class CaseModel
    {
        public string caseName { get; set; }
        public string caseForm { get; set; }
        public int maxGpuLength { get; set; }
        public int maxHsfHeight { get; set; }


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
