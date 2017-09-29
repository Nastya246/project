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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void brOtr_Click(object sender, EventArgs e)
        {
            Slaid slBr = new Slaid();
            slBr.Show();
        }

        private void algVu_Click(object sender, EventArgs e)
        {

        }
    }
}
