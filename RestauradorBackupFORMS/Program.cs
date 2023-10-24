using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestauradorBackupFORMS
{
    internal static class Program
    {
        
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new form());

            
        }
    }
}
