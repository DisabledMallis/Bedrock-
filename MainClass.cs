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

            //Optifine style zoom
            memlib.writeMemory("Minecraft.Windows.exe+9DEDDE", "bytes", "E9 00 3C 84 00 90 90 90 90 90 90 90 90 90 90 90 90 90 90 90 90 90 90 90");
            memlib.writeMemory("Minecraft.Windows.exe+12229E3", "bytes", "83 3D 92 84 CF 01 01 74 1D F3 0F 10 0D 35 00 00 00 F3 0F 10 B8 EC 00 00 00 F3 0F 10 80 E8 00 00 00 E9 EC C3 7B FF F3 0F 10 0D 1C 00 00 00 F3 0F 10 B8 EC 00 00 00 F3 0F 10 80 E8 00 00 00 E9 CF C3 7B FF CC CC CC 00 00 B4 42 00 00 F0 41 CC");

            //V toggle coords (WIP)
            memlib.writeMemory("Minecraft.Windows.exe+5D72CD", "bytes", "E9 9C B7 C4 00 90 90 90 90 90 90 90 C3");
            memlib.writeMemory("Minecraft.Windows.exe+1222A34", "bytes", "80 3D 36 87 CF 01 00 74 0B B0 01 48 83 C4 28 E9 90 48 3B FF E9 8D 48 3B FF 80 3D 1D 87 CF 01 00 75 0C C6 05 14 87 CF 01 01 90 90 90 EB D2 C6 05 08 87 CF 01 00 90 90 90 EB C6 80 3D 53 84 CF 01 01 75 11 FE 05 F3 86 CF 01 80 3D EC 86 CF 01 01 75 AE EB C5 C6 05 E1 86 CF 01 00 90 90 90 EB A0 90");
            memlib.writeMemory("Minecraft.Windows.exe+188ADF6", "bytes", "90 90 90 90 90 90 90 90");
            

            Console.WriteLine("Injected!");
            Thread.Sleep(2000);
        }
    }
}
