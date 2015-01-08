using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Template
{

    public abstract class ComputerBuilder
    {
        public abstract void InstallMotherboard();
        public abstract void InstallPowerUnit();

        protected void InstallCPU()
        {
            Console.WriteLine("Installing CPU");
        }
        protected void InstallRam()
        {
            Console.WriteLine("Installing Ram");

        }
        protected void PrintSuccess()
        {
            Console.WriteLine("Completed build");

        }

        public void BuildComputer()
        {
            InstallMotherboard();
            InstallPowerUnit();
            InstallCPU();
            InstallRam();
            PrintSuccess();
        }

    }
    public class LaptopBuilder : ComputerBuilder
    {        
        public override void InstallPowerUnit()
        {
            Console.WriteLine("Installing Laptop Power unit");
        }
        public override void InstallMotherboard()
        {
            Console.WriteLine("Installing Laptop Motherboard");
        }       
    }
    public class DesktopBuilder :ComputerBuilder
    {
        public override void InstallPowerUnit()
        {
            Console.WriteLine("Installing Desktop Power unit");
        }
        public override void InstallMotherboard()
        {
            Console.WriteLine("Installing Desktop Motherboard");
        }    
    }    
}
