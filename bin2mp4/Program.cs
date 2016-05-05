using System;
#if !CONSOLE
using System.Windows.Forms;
#endif

namespace bin2mp4
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
#if CONSOLE
        static void Main()
        {
            new Form1();
        }
#else
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
#endif
    }
}
