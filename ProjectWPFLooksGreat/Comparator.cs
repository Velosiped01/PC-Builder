using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;

namespace ProjectWPFLooksGreat
{
    class Comparator//porovnava veskery komponenty a vraci string s vysledkem porovnani
    {
        public static string cpuCompare(CpuModel choosedCpu, MotherBoardModel choosedMB)
        { 
            if(choosedCpu != null)
            { 
                if(choosedMB != null)
                {
                    if (choosedCpu.socket == choosedMB.mbsocket)
                    {
                        return "CPU looks good.";
                    }
                    else { return "The CPU is not compatible with the selected motherboard socket, change cpu or mb. MB socket<" + choosedMB.mbsocket + "> not equal to CPU socket<" + choosedCpu.socket + ">."; }
                }  return "CPU looks good";
            }
            return "Required CPU.";
        }
       public static string gpuCompare(GpuModel choosedGpu)
        {
            if (choosedGpu != null)
            {
                return "GPU looks good.";
            }
            return "Required GPU.";
        }
        public static string ramCompare(RamModel choosedRAM, MotherBoardModel choosedMB)
        {
            if (choosedRAM != null)
            {
                if (choosedMB != null)
                {
                    if (choosedRAM.ramType == choosedMB.supportedram)
                    {
                        return "RAM looks good.";
                    }
                    else { return "The RAM is not compatible with the selected Mother board. You need RAM<" + choosedMB.supportedram + ">."; }
                }
                return "Required MB to compare RAM.";
            }
            return "Required RAM.";
         }
        public static string hsfCompare(HsfModel choosedHSF, CpuModel choosedCPU)
        {
            if (choosedHSF != null)
            {
                if (choosedCPU != null)
                {
                    foreach (string socket in choosedHSF.hsfSocket)
                    {
                        if (socket == choosedCPU.socket)
                        {
                            if (choosedHSF.hsfTdp > choosedCPU.tdp)
                            {

                                return "Cooler looks good.";
                            }
                            else
                            {
                                return "Your cpu is hotter than your cooler can handle. Min<" + (choosedCPU.tdp + 30) + "> tdp.";
                            }
                        }
                    }return "Socket of your Hsf isnt working with your cpu"; 
                }return "Required CPU.";
            } return "Required Cooler.";
        }
        public static string psuCompare(PsuModel choosedpsu, CpuModel choosedcpu, GpuModel choosedgpu)
        {
            if (choosedpsu != null)
            {
                if (choosedgpu != null)
                {
                    if (choosedcpu != null)
                    {
                        if (choosedpsu.psuPower > choosedcpu.tdp + choosedgpu.gpuPowerComs + 250)
                        {
                            return "Psu looks good.";
                        }
                        else
                        {
                            return "The power of your PSU in lower than your pc requires. Min<" + (choosedcpu.tdp + choosedgpu.gpuPowerComs + 250) + ">.";
                        }
                    }
                    return "Choose CPU first, then you can check, if PSU is sufficient.";
                }
                return "Choose GPU first, then you can check if PSU is sufficient.";
            }
            return "Required PSU.";
         }
        public static string caseCompare(CaseModel choosedcase, GpuModel choosedgpu, PsuModel choosedpsu, HsfModel choosedhsf, MotherBoardModel choosedmb)
        {
           if(choosedcase != null && choosedgpu != null && choosedpsu != null && choosedhsf != null && choosedmb != null)
            {
                if (choosedcase.maxGpuLength > choosedgpu.gpuLenght)
                {
                    if (choosedpsu.psuForm == choosedcase.caseForm)
                    {
                        if (choosedmb.mbform == choosedcase.caseForm)
                        {
                            if (choosedcase.maxHsfHeight > choosedhsf.hsfHeight)
                            {
                                return "Case looks good";
                            }
                        }
                        return "The form of your Motherd board <" + choosedmb.mbform + "> is different from case <" + choosedcase.caseForm + ">.";
                    }
                    return "The form of your PSU <" + choosedpsu.psuForm + "> is different from case <" + choosedcase.caseForm + ">.";
                }
                else
                {
                    return "The length of GPU is too big, choose another case.";
                }
            }
            return "Choose other components, case is a final part";
        }
    }
}
