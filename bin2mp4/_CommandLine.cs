using System;
using System.IO;

namespace bin2mp4
{
    class _CommandLine
    {
        public static string Init(string[] args, string[] targetVersions)
        {
            if (args.Length > 4)
            {
                Console.WriteLine("");
                Console.WriteLine(" Too many input variables!");
                Console.WriteLine(" Usage: bin2mp4.exe [version] [input_file] optional:[output]");
                Console.WriteLine(" Example: bin2mp4.exe 540 \"C:\\files\\pong.bin\" \"C:\\files\\pong.mp4\"");
                Environment.Exit(-4);
            }
            if (args.Length == 2)
            {
                Console.WriteLine("");
                Console.WriteLine(" Not enough input variables!");
                Console.WriteLine(" Usage: bin2mp4.exe [version] [input_file] optional:[output]");
                Console.WriteLine(" Example: bin2mp4.exe 540 \"C:\\files\\pong.bin\" \"C:\\files\\pong.mp4\"");
                Environment.Exit(-4);
            }
            string inPath = args[2].Trim('"');
            VerCheck(args[1], targetVersions);
            FileCheck(args[2]);
            OutputCheck(args[2],args[3],args.Length);
           
            Form1.cmdConvert = true;
            return inPath;
        }
        public static void VerCheck(string inputVer, string[] targetVersions)
        {
            inputVer = inputVer.Replace("-", "");
            bool matchingVer = false;
            foreach (string versions in targetVersions)
            {
                if (inputVer == versions.Replace(".", ""))
                {
                    matchingVer = true;
                    Form1.targetVer = inputVer;
                    break;
                }
            }
            if (matchingVer == false)
            {
                Console.WriteLine("");
                Console.WriteLine("Unsupported target version used.");
                Console.WriteLine("Supported: 532, 540, 550, 551");
                Console.WriteLine(" Usage: bin2mp4.exe [version] [input_file] optional:[output]");
                Console.WriteLine(" Example: bin2mp4.exe 540 \"C:\\files\\pong.bin\" \"C:\\files\\pong.mp4\"");
                Environment.Exit(-1);
            }
        }

        public static void FileCheck(string inputFile)
        {
            if (!File.Exists(inputFile))
            {
                Console.WriteLine("");
                Console.WriteLine(" Input file does not exist:");
                Console.WriteLine(" \"" + inputFile + "\"");
                Console.WriteLine(" Usage: bin2mp4.exe [version] [input_file] optional:[output]");
                Console.WriteLine(" Example: bin2mp4.exe 540 \"C:\\files\\pong.bin\" \"C:\\files\\pong.mp4\"");
                Environment.Exit(-2);
            }
        }

        public static void OutputCheck(string inPath, string outPath, int arguments)
        {
            inPath = inPath.Trim('"');
            outPath = outPath.Trim('"');
            string outDir;
            if (arguments == 4)
            {
                if (Path.HasExtension(outPath) == true)
                {
                    Form1.outMP4_name = Path.GetFileNameWithoutExtension(outPath);
                    outDir = Path.GetDirectoryName(outPath);
                }
                else
                {
                    outDir = Path.GetFullPath(outPath);
                    Form1.outMP4_name = Path.GetFileNameWithoutExtension(inPath);
                }
            }
            else
            {
                outDir = Path.GetDirectoryName(inPath);
                Form1.outMP4_name = Path.GetFileNameWithoutExtension(inPath);
            }
            
            if (!Directory.Exists(outDir))
            {
                Console.WriteLine("");
                Console.WriteLine("This output directory does not exist:");
                Console.WriteLine(" \"" + outDir + "\"");
                Console.WriteLine(" Usage: bin2mp4.exe [version] [input_file] optional:[output]");
                Console.WriteLine(" Example: bin2mp4.exe 540 \"C:\\files\\pong.bin\" \"C:\\files\\pong.mp4\"");
                Environment.Exit(-3);
            }
            Form1.outMP4_dir = outDir;
        }

    }
}
