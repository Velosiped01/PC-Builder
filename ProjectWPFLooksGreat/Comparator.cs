using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectWPFLooksGreat
{
    class Comparator
    {
        public static string cpuCompare(string choosedCpu, string choosedMB, UniModels cpuActual, UniModels MBActual)
        {
            if (cpuActual != null && MBActual != null)
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
                                    return "CPU looks good.";
                                }
                                else { return "The CPU is not compatible with the selected motherboard socket, change cpu or mb. MB socket<" + MB.mbsocket + ">."; }
                            }

                        }
                        return "CPU cannot be without a motherboard.";
                    }
                }
            }
            return "Required CPU.";
        }
        public static string mbCompare(string choosedCpu, string choosedMB, UniModels cpuActual, UniModels MBActual)
        {
            if (MBActual != null && cpuActual != null)
            {
                foreach (MotherBoardModel mb in MBActual.MbList)
                {
                    if (mb.mbName == choosedMB)
                    {
                        foreach (CpuModel cpu in cpuActual.CpuList)
                        {
                            if (cpu.cpu == choosedCpu)
                            {
                                if (cpu.socket == mb.mbsocket)
                                {
                                    return "MB looks good.";
                                }
                                else { return "The Mother board socket is not compatible with the selected CPU, change cpu or mb. Cpu Socket<" + cpu.socket + ">."; }
                            }
                            else { return "Everything looks good."; }
                        }
                    }
                }
            }
            return "Required MB.";
        }
        public static string gpuCompare(string choosedGpu, UniModels gpuActual)
        {
            if (gpuActual != null)
            {
                foreach (GpuModel gpu in gpuActual.GpuList)
                {
                    if (gpu.gpuName == choosedGpu)
                    {
                        return "GPU looks good.";
                    }
                }
            }
            return "Required MB.";
        }
        public static string ramCompare(string choosedRAM, string choosedMB, UniModels ramActual, UniModels mbActual)
        { if (ramActual != null && mbActual != null)
            {
                foreach (RamModel ram in ramActual.RamList)
                {
                    if (ram.ramName == choosedRAM)
                    {
                        foreach (MotherBoardModel MB in mbActual.MbList)
                        {
                            if (MB.mbName == choosedMB)
                            {
                                if (ram.ramType == MB.supportedram)
                                {
                                    return "RAM looks good.";
                                }
                                else{ return "The RAM is not compatible with the selected Mother board. You need RAM<"+ MB.supportedram +">."; }
                            }
                        }
                    }
                }
            }
            return "Required RAM.";
        }
        public static string hsfCompare(string choosedHSF, string choosedCPU, UniModels hsfActual, UniModels cpuActual)
        {
            if(hsfActual != null && cpuActual != null)
            {
                foreach(HsfModel hsf in hsfActual.HsfList)
                {
                    if(hsf.hsfName == choosedHSF)
                    {
                        foreach(CpuModel cpu in cpuActual.CpuList)
                        {
                            if(cpu.cpu == choosedCPU)
                            {
                                foreach(string socket in hsf.hsfSocket)
                                {
                                    if(socket == cpu.socket)
                                    {
                                        if(hsf.hsfTdp > cpu.tdp)
                                        {
                                            return "Cooler looks good.";
                                        }
                                        else
                                        {
                                            return "Your cpu is hotter than your cooler can handle. Min<" + (cpu.tdp + 30) +">.";
                                        }
                                    }
                                }
                                return "The cooler's socket is not compatible with your CPU.";
                            }
                            
                        }
                        return "Required CPU.";
                    }
                }
            }
            return "Required Cooler.";
        }
        public static string psuCompare(string choosedpsu, string choosedcpu, string choosedgpu, UniModels PsuActual, UniModels GpuActual, UniModels CpuActual)
        {
            if (PsuActual != null && GpuActual != null && CpuActual != null)
            {
                foreach (PsuModel psu in PsuActual.PsuList)
                {
                    if (psu.psuName == choosedpsu)
                    {
                        foreach (GpuModel gpu in GpuActual.GpuList)
                        {
                            if (gpu.gpuName == choosedgpu)
                            {
                                foreach (CpuModel cpu in CpuActual.CpuList)
                                {
                                    if (cpu.cpu == choosedcpu)
                                    {
                                        if (psu.psuPower > cpu.tdp + gpu.gpuPowerComs + 250)
                                        {
                                            return "Psu looks good.";
                                        }
                                        else
                                        {
                                            return "The power of your PSU in lower than your pc requires. Min<" +( cpu.tdp + gpu.gpuPowerComs + 250)+ ">.";
                                        }
                                    }
                                }
                                return "Choose CPU first, then you can check, if PSU is sufficient.";
                            }
                        }
                        return "Choose GPU first, then you can check if PSU is sufficient.";
                    }
                }
            }
            return "Required PSU.";
        }
        public static string caseCompare(string choosedcase, string choosedgpu, string choosedpsu, string choosedhsf, string choosedmb, UniModels caseActual, UniModels gpuActual, UniModels psuActual, UniModels hsfActual, UniModels mbActual)
        {
            if(caseActual!= null && gpuActual != null && psuActual != null && hsfActual != null && mbActual != null)
            {
                foreach(CaseModel Case in caseActual.CaseList)
                {
                    if(Case.caseName == choosedcase)
                    {
                        foreach (GpuModel gpu in gpuActual.GpuList)
                        {
                            if(gpu.gpuName == choosedgpu)
                            {
                                if(Case.maxGpuLength > gpu.gpuLenght)
                                {
                                    foreach (MotherBoardModel mb in mbActual.MbList)
                                    {
                                        if(mb.mbName == choosedmb)
                                        {
                                            if(mb.mbform == Case.caseForm)
                                            {
                                                foreach (PsuModel psu in psuActual.PsuList)
                                                {
                                                    if (psu.psuName == choosedpsu)
                                                    {
                                                        if (psu.psuForm == Case.caseForm)
                                                        {
                                                            foreach(HsfModel hsf in hsfActual.HsfList)
                                                            {
                                                                if(hsf.hsfName == choosedhsf)
                                                                {
                                                                    if(Case.maxHsfHeight > hsf.hsfHeight)
                                                                    {
                                                                        return "Case looks good";
                                                                    }
                                                                    else
                                                                    {
                                                                        return "Cooler is too tall, choose another.";
                                                                    }
                                                                }
                                                            }return "Required Cooler";
                                                        }
                                                        else
                                                        {
                                                            return "The form of your PSU <" +psu.psuForm + "> is different from case <" + Case.caseForm + ">.";
                                                        }
                                                    }
                                                }
                                                return "Required PSU";
                                            }
                                            else
                                            {
                                                return "The form of your Motherd board <" + mb.mbform + "> is different from case <" + Case.caseForm + ">.";
                                            }
                                        }
                                    }
                                    return "Required Mother board.";
                                }
                                else
                                {
                                    return "The length of GPU is too large, choose another case.";
                                }
                            }
                        }
                        return "Required GPU.";
                    }
                }
            }
            return "Required Case.";
        }
    }
}
