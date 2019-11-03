using Memory;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bedrock_
{
    public class MainClass
    {
        public static void Main(String[] args)
        {
            //Credit memory.dll for their amazing asf work
            Console.WriteLine("This is powered by Memory.dll");
            Console.WriteLine("Github: https://github.com/erfg12/memory.dll");

            //load program
            Console.WriteLine("(64 bit ONLY) Bedrock+ Mod is loading...");

            //Make mem.dll instance & scan shit
            Mem memlib = new Mem();
            Process proc;
            try
            {
                proc = Process.GetProcessesByName("Minecraft.Windows")[0];
            } catch (IndexOutOfRangeException)
            {
                MessageBox.Show("Game not found running. exiting.");
                return;
            }
            if (!memlib.OpenProcess(proc.Id))
            {
                MessageBox.Show("Failed to hook: " + proc.Id.ToString("X"));
                return;
            }

            Console.WriteLine("Injecting...");
            memlib.writeMemory("Minecraft.Windows.exe+9DEDDE", "bytes", "FF 25 00 00 00 00 45 D1 FB 30 F8 7F 00 00 90 90 90 90 90 90 90 90 90 90");
            memlib.writeMemory("nvldumdx.dll+D145", "bytes", "83 3D 30 DD DF CE 01 74 1D F3 0F 10 0D 35 00 00 00 F3 0F 10 B8 EC 00 00 00 F3 0F 10 80 E8 00 00 00 E9 8A 1C 8C CC F3 0F 10 0D 1C 00 00 00 F3 0F 10 B8 EC 00 00 00 F3 0F 10 80 E8 00 00 00 E9 6D 1C 8C CC CC CC CC 00 00 B4 42 00 00 F0 41 CC");
            Console.WriteLine("Injected!");
            Thread.Sleep(2000);
        }
    }
}
