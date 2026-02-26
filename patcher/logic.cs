using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace patcher
{
    internal class Logic

    {
        private string inputfile = "HTTPDebuggerUI.exe";
        private string outputFile = "HTTPDebuggerUIPatched.exe";


        private long offset1 = 0x355E1;
        private long offset2 = 0x60FCD;
        private long offset3 = 0x7C68F;

        private byte[] data;

        public Logic(string inputfile, string outputFile)
        {
            this.inputfile = inputfile;
            this.outputFile = outputFile;
            data = File.ReadAllBytes(inputfile);
        }

        public void Patch1()
        {
  
            if (data[offset1] == 0x7F)
            {
                data[offset1] = 0xEB;
                Console.WriteLine("Patch 1 success (short jump).");
            }
            else
            {
                Console.WriteLine("Patch 1 failed.");
            }

        }
        public void Patch2()
        {
            
            if (data[offset2] == 0x0F && data[offset2 + 1] == 0x8F)
            {
                
                data[offset2] = 0x90;     
                data[offset2 + 1] = 0xE9; 


                Console.WriteLine("Patch 2 success.");
            }
            else
            {
                Console.WriteLine("Patch 2 failed: Byte mismatch at offset.");
            }
        }

        public void Patch3()
        {

            if (data[offset3] == 0xE8)
            {
                data[offset3] = 0xB8; 
                data[offset3 + 1] = 0x0F;
                data[offset3 + 2] = 0x27;
                data[offset3 + 3] = 0x00;
                data[offset3 + 4] = 0x00;

                Console.WriteLine("Patch 3 success (mov eax, 270Fh).");
            }
            else
            {
                Console.WriteLine("Patch 3 failed.");
            }

        }

        public void Save()
        {
            File.WriteAllBytes(outputFile, data);
            Console.WriteLine("All done. Patched file saved.");
        }

    }
}
