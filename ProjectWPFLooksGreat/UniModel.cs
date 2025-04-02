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
}
