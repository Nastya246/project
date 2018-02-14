using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Tao.OpenGl;
using Tao.FreeGlut;
using Tao.Platform.Windows;
namespace taoOpenGLtest
{
    static class Sinhr
    {
        public static int n = 0;
        public static int point = 50;
        public static string Value { get; set; }
        public static string Code { get; set; }
        public static Color color = Color.Black;
       
    }
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
          //Application.Run(new Menu());
          //  Application.Run(new AlgCDA());
          Application.Run(new VizBrOt());
       // Application.Run(new AlgVu());
        //    Application.Run(new Menu());
     
             
        }
    }
}
