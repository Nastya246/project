using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace taoOpenGLtest
{
    public partial class DataAl : Form
    {
        
        public DataAl()
        {
            InitializeComponent();
          
        }
       
        private void DataAl_Load(object sender, EventArgs e)
        {
        //    code.Text = Sinhr.Code;
       //     code.ForeColor = Sinhr.color;
        //    koord.Text=Sinhr.Value;
          code.Text = "1. double k = ((double)y22 - (double)y11) / ((double)x22 - (double)x11);\n 2. double b = y11 - k * x11;\n 3. double temp;\n 4. for (int i = x11; i <= x22; i++)\n5. {\n6. temp = Math.Round(k * i + b);\n7. Pixel(i,temp,1);\n8. }\n9. glControl1.SwapBuffers();\n";
           
           
          /*     if (Sinhr.color == 0)
               {
                   code.ForeColor = Color.Red;
               }
               else {
                   code.ForeColor = Color.Black;
               }
               */
        }
    }
}
