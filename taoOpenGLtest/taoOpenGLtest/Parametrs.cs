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
    public partial class Parametrs : Form
    {
        public Parametrs()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(ParamViz.Text) <= 600)
                {
                    Sinhr.point = Convert.ToInt32(ParamViz.Text);
                    this.Close();
                }
                else {
                    MessageBox.Show("Ошибка! Выход за границы.",
                "Сообщение об ошибке",
                MessageBoxButtons.OK);
 
                }
            }
            catch
            {
                MessageBox.Show("Ошибка! Проверьте введенные данные.",
                "Сообщение об ошибке",
                MessageBoxButtons.OK);
            }
        }
    }
}
