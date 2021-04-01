using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }

    static class Data
    {
        public static string Directory { get; set; } = @"c:\temp\";
        public static bool EmotionPanelCheckBoxChecked { get; set; } = true;
        public static bool TweetPointsCheckBoxChecked { get; set; } = true;

        public static string CurrentCultureName { get; set; }
    }
}
