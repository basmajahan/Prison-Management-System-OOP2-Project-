using System;
using System.Windows.Forms;

namespace Prison_Management_System
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // This line tells the app to start with your HomePage form
            Application.Run(new HomePage());
        }
    }
}
