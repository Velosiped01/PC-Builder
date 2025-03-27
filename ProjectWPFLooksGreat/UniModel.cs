using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectWPFLooksGreat
{
    [Serializable]
    public class UniModels
    {
        
        public List<CpuModel> CpuList { get; set; } = new List<CpuModel>();
        public List<MotherBoardModel> MbList { get; set; } = new List<MotherBoardModel>();


    }

    [Serializable]
    public class CpuModel
    {
        public string cpu { get; set; }
        public int tdp { get; set; }
        public int freq { get; set; }
        public string socket { get; set; }

        public CpuModel() { }

        public CpuModel(string cpu, int tdp, int freq, string socket)
        {
            this.cpu = cpu;
            this.tdp = tdp;
            this.freq = freq;
            this.socket = socket;

        }
    }
    [Serializable]
    public class MotherBoardModel
    {
        public string mbName { get; set; }
        public string mbplatform { get; set; }
        public int mbmaxcpufreq { get; set; }
        public string mbform { get; set; }

        public MotherBoardModel() { }

        public MotherBoardModel(string mbName, string mbplatform, int mbmaxcpufreq, string mbform)
        {
            this.mbName = mbName;
            this.mbplatform = mbplatform;
            this.mbmaxcpufreq = mbmaxcpufreq;
            this.mbform = mbform;

        }
    }
}
