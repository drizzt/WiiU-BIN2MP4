using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.IO;

namespace bin2mp4
{
    public partial class Form1 : Form
    {
        string[] args = Environment.GetCommandLineArgs();
        public byte[] inBIN;
        public byte[] inBIN_size;
        public byte[] outMP4 = ByteData.mp4Base;
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
            InitializeComponent();
            AttachConsole(ATTACH_PARENT_PROCESS);

            //Check if command line arguments were given and do those instead of launching Windows form
            if (args.Length > 1)
            { 
                _OpenFile(_CommandLine.Init(args, targetVersionBox.Items));
                Environment.Exit(0);
            }
            targetVersionBox.SelectedIndex = 1; //Set default version to 5.4
        }
        public void _OpenFile(string fileName)
        {
            inBIN = File.ReadAllBytes(fileName);
            if (!cmdConvert)
            { 
                outMP4_name = Path.GetFileNameWithoutExtension(fileName);
            }

            if (inBIN.Length > 26548)
            {
                label1.Text = "Input file exceeds 26.54kb size limit!";
                if (cmdConvert)
                {
                    Console.WriteLine("");
                    Console.WriteLine( "Input File exceeds 26.54kb size limit!");
                    Environment.Exit(-5);
                }
            }
            else
            {
                _InjectBin(targetVer);
            }
        }

        public void _InjectBin(string inVer)
        {
            outMP4 = ByteData.mp4Base;
            
            _WriteBinData();
            _WriteBinSize();
            if(inVer == "532")
            {
                _VersionPatch(ByteData.v532);
            }
            _Save2File();
        }

        private void _WriteBinData()
        {
            for (int i = 0; i < inBIN.Length; i++)
            {
                outMP4[i + injectOffset] = inBIN[i];
            }
        }

        private void _WriteBinSize()
        {
            inBIN_size = BitConverter.GetBytes(inBIN.Length);
            for (int i = 0; i < 4; i++)
            {
                outMP4[injectOffset - i - 1] = inBIN_size[i];
            }
        }

        private void _VersionPatch(byte[] versionBytes)
        {
            for (int i = 0; i < versionBytes.Length; i++)
            {
                outMP4[i] = versionBytes[i];
            }
        }

        public void _Save2File()
        {
            if (!cmdConvert)
            {
                using (SaveFileDialog saveFileDialog1 = new SaveFileDialog())
                {
                    saveFileDialog1.FileName = outMP4_name;
                    saveFileDialog1.Filter = "MP4 File | *.mp4";
                    if (DialogResult.OK != saveFileDialog1.ShowDialog())
                    {
                        return;
                    }
                    File.WriteAllBytes(saveFileDialog1.FileName, outMP4);
                }
            }
            else
            {
                string tempDir = outMP4_dir + "\\" + outMP4_name + ".mp4";
                File.WriteAllBytes(tempDir, outMP4);
                Console.WriteLine("");
                Console.WriteLine(" File saved to: \"" + tempDir + "\"");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog1 = new OpenFileDialog())
            {
                openFileDialog1.Filter = "Binary File | *.bin";

                if (DialogResult.OK != openFileDialog1.ShowDialog())
                {
                    return;
                }
                _OpenFile(openFileDialog1.FileName);
            }
        }

        private void dropZone_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void dropZone_DragDrop(object sender, DragEventArgs e)
        {
            int binsFound = 0;
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            for (int i = 0; i < files.Length; i++ )
            {
                if(Path.GetExtension(files[i]) == ".bin")
                {
                    _OpenFile(files[i]);
                    binsFound += 1;
                }
            }
            if(binsFound == 0)
            {
                label1.Text = "No .bin files found!";
            }
            else if(binsFound == 1)
            {
                label1.Text = "1 .bin file converted.";
            }
            else
            {
                label1.Text = binsFound.ToString() + " .bin files converted.";
            }
        }

        private void targetVersionBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            targetVer = targetVersionBox.Text.Replace(".","");
            Console.WriteLine(targetVer);
        }
    }
}
