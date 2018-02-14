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

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void справкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Программа визуализирует растроыве алгоритмы, а также содержит теоретичский материал по ним.\nДля уравления программой используйте мышь.\nВ окне визуализации Вы можете задать параметры визуализации.",
                "Справка",
                MessageBoxButtons.OK);
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Программа написана студентом группы КЭ - 484 Козловой Анастасией.",
                "О программе",
                MessageBoxButtons.OK);
        }
    }
}
