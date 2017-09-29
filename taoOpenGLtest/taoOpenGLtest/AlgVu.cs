using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Tao.OpenGl;
using Tao.FreeGlut;
using Tao.Platform.Windows;

namespace taoOpenGLtest
{
    public partial class AlgVu : Form
    {
        int x1, y1, x2, y2;
        public AlgVu()
        {
            InitializeComponent();
            vu.InitializeContexts();
        }
        private void VU(int x11, int y11,int  x22,int  y22)
        {

        }
        private void AlgVu_Load(object sender, EventArgs e)
        {

            Glut.glutInit();
            Glut.glutInitDisplayMode(Glut.GLUT_RGB | Glut.GLUT_DOUBLE | Glut.GLUT_DEPTH);
            Gl.glClearColor(255, 255, 255, 1);

            Gl.glViewport(0, 0, vu.Width, vu.Height);
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();

            Glu.gluOrtho2D(0.0, 25, 0.0, 25);
            Gl.glMatrixMode(Gl.GL_MODELVIEW);

            Gl.glPushMatrix();
            Gl.glTranslated(10, 10, 0);
            Gl.glBegin(Gl.GL_POINTS);
            for (int ax = -15; ax < 15; ax++)
            {
                for (int bx = -15; bx < 15; bx++)
                {
                    Gl.glVertex2d(ax, bx);
                }


            }
            Gl.glEnd();
            Gl.glBegin(Gl.GL_LINES);
            Gl.glVertex2d(0, -25);
            Gl.glVertex2d(0, 25);
            Gl.glVertex2d(-25, 0);
            Gl.glVertex2d(25, 0);

            Gl.glVertex2d(0, 15);
            Gl.glVertex2d(0.1, 14.5);
            Gl.glVertex2d(0, 14.5);
            Gl.glVertex2d(-0.1, 14.5);

            Gl.glVertex2d(15, 0);
            Gl.glVertex2d(14.5, 0.1);
            Gl.glVertex2d(15, 0);
            Gl.glVertex2d(14.5, -0.1);

            Gl.glEnd();

            x1 = 2;
            y1 = 1;
            x2 = 8;
            y2 = 9;

            Gl.glColor3f(255, 0, 0);
            Gl.glBegin(Gl.GL_LINES);
            Gl.glVertex2d(x1, y1);
            Gl.glVertex2d(x2, y2);
            Gl.glEnd();
            VU(x1, y1, x2, y2);

            Gl.glFlush();
            vu.Invalidate();
        }
    }
}
