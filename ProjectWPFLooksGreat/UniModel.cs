using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectWPFLooksGreat
{
   public class UniModels
    {
        public List<UniModel> UniList { get; set; } = new List<UniModel>();
        public List<CpuModel> CpuList { get; set; } = new List<CpuModel>();


    }
    
    
    public class UniModel
    {
        public string item1 { get; set; }
        public string item2 { get; set; }
        public string item3 { get; set; }
        public string item4 { get; set; }

        public UniModel() { }

        public UniModel(string item1, string item2, string item3, string item4)
        {
            this.item1 = item1;
            this.item2 = item2;
            this.item3 = item3;
            this.item4 = item4;

        }
    }
}
