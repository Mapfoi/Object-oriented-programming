using System;
using System.Windows.Forms;

namespace Lab2_OOP
{
    /// <summary>
    /// Application entry point.
    /// </summary>
    internal static class Program
    {
        /// <summary>
        /// Starts the Windows Forms application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
