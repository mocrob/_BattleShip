using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace battkeship
{
    static class Program
    {
        public static Battleship menu;
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            /*
             * Интерфейс
             * Tool bar
             * Организовать выход
             */
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(menu = new Battleship());
        }
    }
}
