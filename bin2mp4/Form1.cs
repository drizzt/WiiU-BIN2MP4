using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.IO;

namespace bin2mp4
{
    public partial class Form1
    {
        string[] args = Environment.GetCommandLineArgs();
        public byte[] inBIN;
        public byte[] outMP4 = new Byte[_MP4.ArraySize];
        public static string outMP4_name;
        public static string outMP4_dir;
        public static string targetVer = "540";
        public static int injectOffset = 4424;
        public static bool cmdConvert = false;

        //Attach to console so we can output info during command line usage
        [DllImport("kernel32.dll")]
        static extern bool AttachConsole(int dwProcessId);
        private const int ATTACH_PARENT_PROCESS = -1;

        public Form1()
        {
            //AttachConsole doesn't exists nor is needed on Mono
            if (Type.GetType ("Mono.Runtime") == null)
                AttachConsole(ATTACH_PARENT_PROCESS);

            //Check if command line arguments were given and do those instead of launching Windows form
            if (args.Length > 1)
            { 
                string[] targetVers = {"5.3.2", "5.4.0", "5.5.0", "5.5.1"};
                _OpenFile(_CommandLine.Init(args, targetVers));
                Environment.Exit(0);
            }
        }
        public void _OpenFile(string fileName)
        {
            inBIN = File.ReadAllBytes(fileName);
            if (!cmdConvert)
            { 
                outMP4_name = Path.GetFileNameWithoutExtension(fileName);
            }

            if (inBIN.Length > 29832)
            {
                if (cmdConvert)
                {
                    Console.WriteLine("");
                    Console.WriteLine(" Input file exceeds 29.1KB (29832 bytes) size limit!");
                    Environment.Exit(-5);
                }
            }
            else
            {
                _GenerateMP4(targetVer);
                _Save2File();
            }
        }

        public void _GenerateMP4(string inVer)
        {
            _WriteBytes(_MP4.headerBytes, 0);
            _FillBytes(_MP4.Header_Pattern.offset, _MP4.Header_Pattern.length, _MP4.Header_Pattern.spacing, _MP4.Header_Pattern.value);
            _WriteBytes(_MP4.BinLeadInBytes, _MP4.BinLeadInOffset);
            _FillBytes(_MP4.Bin_Fill.offset, _MP4.Bin_Fill.length, _MP4.Bin_Fill.spacing, _MP4.Bin_Fill.value);

            //Start of version specific code
            if (inVer == "532" || inVer == "540")
            {
                _PatternBytes(_MP4.v532_Pattern.offset, _MP4.v532_Pattern.length, _MP4.v532_Pattern.spacing, _MP4.v532_Pattern.value); 
                _WriteBytes(_MP4.v532_Footer, _MP4.v532_FooterOffset);
                if(inVer == "532") //Patch header for 5.3.2
                {
                    for(int i = 0; i <_MP4.v532_Header_Patch.offsets.Length; i++)
                    {
                        outMP4[ _MP4.v532_Header_Patch.offsets[i] ] = _MP4.v532_Header_Patch.values[i];
                    }
                }
            }
            else if (inVer == "550" || inVer == "551")
            {
                _PatternBytes(_MP4.v550_Pattern.offset, _MP4.v550_Pattern.length, _MP4.v550_Pattern.spacing, _MP4.v550_Pattern.value);
                _WriteBytes(_MP4.v550_Footer, _MP4.v550_FooterOffset); 
            }

            _FillBytes(_MP4.Footer_Fill.offset, _MP4.Footer_Fill.length, _MP4.Footer_Fill.spacing, _MP4.Footer_Fill.value);
            _WriteBytes(_MP4.Footer_Magic, _MP4.Footer_Magic_Offset);
           // _PatternBytes(_MP4.Footer_Pattern.offset, _MP4.Footer_Pattern.length, _MP4.Footer_Pattern.spacing, _MP4.Footer_Pattern.values);

            _WriteBytes(inBIN, _MP4.BinLeadInOffset + _MP4.BinLeadInBytes.Length - 2); //Write our input .bin file to the required position in the file
            _WriteBinSize(); //Write the hex length of our bin file to the appropriate location
        }

        private void _WriteBytes(byte[] inBytes, int offset)
        {
            for (int i = 0; i < inBytes.Length; i++)
            {
                outMP4[i + offset] = inBytes[i];
            }
        }

        private void _WriteBinSize()
        {
            byte[] inBIN_size = BitConverter.GetBytes(inBIN.Length);
            for (int i = 0; i < 4; i++)
            {
                outMP4[_MP4.BinLeadInOffset + _MP4.BinLeadInBytes.Length - 3 - i] = inBIN_size[i];
            }
        }

        private void _FillBytes(int offset, int size, int spacing, byte byteVal)
        {
            for (int i = 0; i < size; i += spacing)
            {
                outMP4[i + offset] = byteVal;
            }
        }
        private void _PatternBytes(int offset, int size, int spacing, byte[] byteVal)
        {
            int byteChoice = 0;
            for (int i = 0; i < size; i += spacing)
            {
                outMP4[i + offset] = byteVal[byteChoice];
                byteChoice += 1;
                if(byteChoice == byteVal.Length)
                {
                    byteChoice = 0;
                }
            }
        }

        public void _Save2File()
        {
            string tempDir = Path.Combine(outMP4_dir, outMP4_name + ".mp4");
            File.WriteAllBytes(tempDir, outMP4);
            Console.WriteLine("");
            Console.WriteLine(" File saved to: \"" + tempDir + "\"");
        }
    }
}
