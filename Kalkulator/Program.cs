﻿using System;
using System.Windows.Forms;

namespace Kalkulator
{
    static class Program
    {
        /// <summary>
        /// The main entry point to the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Kalkulator());
        }
    }
}
