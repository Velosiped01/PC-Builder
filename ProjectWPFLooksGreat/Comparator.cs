using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectWPFLooksGreat
{
    class Comparator
    {
        public static bool cpuCompare(string choosedCpu, string choosedMB, UniModels cpuActual, UniModels MBActual)
        {
            foreach (CpuModel CPU in cpuActual.CpuList)
            {
                if (CPU.cpu == choosedCpu)
                {
                    foreach (MotherBoardModel MB in MBActual.MbList)
                    {
                        if (MB.mbName == choosedMB)
                        {
                            if (CPU.socket == MB.mbsocket)
                            {
                                return true;
                            }
                            else { return false; }
                        }
                        else { return false; }
                    }
                }
            }
            return false;
        }
    }
}
