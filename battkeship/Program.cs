using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace battkeship
{
    static class Program
    {
        public static Form1 menu;
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(menu = new Form1());
        }
    }
}
