using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectWPFLooksGreat
{
    [Serializable]
    class MotherBoardModels
    {
        public List<MotherBoardModel> MbList { get; set; } = new List<MotherBoardModel>();

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
