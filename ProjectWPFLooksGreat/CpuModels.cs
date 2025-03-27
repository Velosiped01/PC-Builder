using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectWPFLooksGreat
{
    [Serializable]
    public class CpuModels
    {
        public List<CpuModel> CpuList { get; set; } = new List<CpuModel>();


    }
    [Serializable]
    public class CpuModel 
    {
        public string cpu { get; set; }
        public int tdp { get; set; }
        public int freq { get; set; }
        public string socket { get; set; }

        public CpuModel(){}

        public CpuModel(string cpu, int tdp, int freq, string socket)
        {
            this.cpu = cpu;
            this.tdp = tdp;
            this.freq = freq;
            this.socket = socket; 

        }
    }
}
