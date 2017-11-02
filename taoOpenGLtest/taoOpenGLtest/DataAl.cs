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
            koord.Text=Sinhr.Value;
            code.Text = Sinhr.Code;
        }
    }
}
