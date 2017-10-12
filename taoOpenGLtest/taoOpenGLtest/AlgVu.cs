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
        double[,] ValuesArray;
        double[,] LineKoord;
       
        public AlgVu()
        {
            InitializeComponent();
            vu.InitializeContexts();
        }
        private void PrintText(double x, double y, string text)
        {

            Gl.glRasterPos2d(x, y);
            foreach (char sign in text)
            {
                Glut.glutBitmapCharacter(Glut.GLUT_BITMAP_9_BY_15, sign);
            }

        }
        private void setka()
        {
            Gl.glColor3f(255, 255, 255);
            Gl.glPointSize(1);
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



            Gl.glColor3f(255, 0, 0);
            Gl.glBegin(Gl.GL_LINES);
            Gl.glVertex2d(x1, y1);
            Gl.glVertex2d(x2, y2);
            Gl.glEnd();
            Gl.glColor3f(255, 255, 255);
            PrintText(14.5, 0.5, "x");
            PrintText(0.5, 14.5, "y");
            Gl.glColor3f(0, 0, 255);
        }
        private void koordLine(int x1,int y1,int x2,int y2)
        {
            int num = 0;
            
            for (int i = x1; i <= x2; i++)
            {
                LineKoord[num, 0] = i;
                LineKoord[num, 1] = ((((double)i - (double)x1) * ((double)y2 - (double)y1)) / ((double)x2 - (double)x1)) + (double)y1;
                num++;

            }
            
        }
        
        private void VU(int x11, int y11,int  x22,int  y22)
        {
            

             ValuesArray = null;
             LineKoord = null;
            int len = Math.Abs(x1 - x2 - 1);
            ValuesArray = new double[len, 2];
            LineKoord = new double[len, 2];
            int count = 0;
            koordLine(x11, y11, x22, y22);

            if (((x1 != 0) && (x2 != 0)) || ((y1 != 0) && (y2 != 0)))
            {
                int dx = Math.Abs(x22 - x11);
                int dy = Math.Abs(y22 - y11);
                double k = ((double)y2 - (double)y1) / ((double)x2 - (double)x1);
                int sx, sy;

                if (x22 >= x11)
                {
                    sx = 1;
                }
                else
                {
                    sx = -1;
                }
                if (y22 >= y11)
                {
                    sy = 1;
                }
                else
                {
                    sy = -1;
                }

                if (k <= 1) // основная ось x
                {
                    int d = (dy << 1) - dx;
                    int d1 = dy << 1;
                    int d2 = (dy - dx) << 1;

                    double intens = Math.Abs(y11 - LineKoord[0, 1]); // разница между ординатой идеальной линии и пикселем растровой
                    if (intens == 0)
                    {
                        Gl.glColor4d(0, 0, 255, 1);


                        Gl.glBegin(Gl.GL_QUAD_STRIP);


                        Gl.glVertex2d((double)x11 - 0.5, (double)y11 - 0.5);
                        Gl.glVertex2d((double)x11 + 0.5, (double)y11 - 0.5);
                        Gl.glVertex2d((double)x11 - 0.5, (double)y11 + 0.5);
                        Gl.glVertex2d((double)x11 + 0.5, (double)y11 + 0.5);
                        Gl.glEnd();
                    }
                    else
                    {


                        Gl.glColor4d(0, 0, 255, intens);//выбор соответствующей интенсивности
                        Gl.glBegin(Gl.GL_QUAD_STRIP);


                        Gl.glVertex2d((double)x11 - 0.5, (double)y11 - 0.5);
                        Gl.glVertex2d((double)x11 + 0.5, (double)y11 - 0.5);
                        Gl.glVertex2d((double)x11 - 0.5, (double)y11 + 0.5);
                        Gl.glVertex2d((double)x11 + 0.5, (double)y11 + 0.5);
                        Gl.glEnd();



                        Gl.glColor4d(0, 0, 255, 1 - intens);
                        Gl.glBegin(Gl.GL_QUAD_STRIP);

                        Gl.glVertex2d((double)x11 - 0.5, (double)y11 - 0.5 + 1);
                        Gl.glVertex2d((double)x11 + 0.5, (double)y11 - 0.5 + 1);
                        Gl.glVertex2d((double)x11 - 0.5, (double)y11 + 0.5 + 1);
                        Gl.glVertex2d((double)x11 + 0.5, (double)y11 + 0.5 + 1);
                        Gl.glEnd();

                    }
                    ValuesArray[count, 0] = x11;
                    ValuesArray[count, 1] = y11;


                    count++;
                    for (int x = x11 + sx, y = y11, i = 1; i <= dx; i++, x += sx)
                    {
                        if (d > 0)
                        {
                            d += d2;
                            y += sy;
                        }
                        else
                            d += d1;

                        intens = Math.Abs(y - LineKoord[count, 1]); // разница между ординатой идеальной линии и пикселем растровой

                        if (intens == 0)
                        {
                            Gl.glColor4d(0, 0, 255, 1);

                            Gl.glBegin(Gl.GL_QUAD_STRIP);


                            Gl.glVertex2d((double)x - 0.5, (double)y - 0.5);
                            Gl.glVertex2d((double)x + 0.5, (double)y - 0.5);
                            Gl.glVertex2d((double)x - 0.5, (double)y + 0.5);
                            Gl.glVertex2d((double)x + 0.5, (double)y + 0.5);
                            Gl.glEnd();
                        }
                        else
                        {

                            Gl.glColor4d(0, 0, 255, intens);

                            Gl.glBegin(Gl.GL_QUAD_STRIP);

                            Gl.glVertex2d((double)x - 0.5, (double)y - 0.5);
                            Gl.glVertex2d((double)x + 0.5, (double)y - 0.5);
                            Gl.glVertex2d((double)x - 0.5, (double)y + 0.5);
                            Gl.glVertex2d((double)x + 0.5, (double)y + 0.5);
                            Gl.glEnd();


                            Gl.glColor4d(0, 0, 255, 1 - intens);
                            Gl.glBegin(Gl.GL_QUAD_STRIP);

                            Gl.glVertex2d((double)x - 0.5, (double)y - 0.5 + 1);
                            Gl.glVertex2d((double)x + 0.5, (double)y - 0.5 + 1);
                            Gl.glVertex2d((double)x - 0.5, (double)y + 0.5 + 1);
                            Gl.glVertex2d((double)x + 0.5, (double)y + 0.5 + 1);
                            Gl.glEnd();

                        }
                        ValuesArray[count, 0] = x;
                        ValuesArray[count, 1] = y;


                        count++;
                    }

                }
                else //основная ось y
                {
                    int d = (dx << 2) - dy;
                    int d1 = dx << 1;
                    int d2 = (dx - dy) << 1;


                    double intens = Math.Abs(y11 - LineKoord[0, 1]); // разница между ординатой идеальной линии и пикселем растровой
                    if (intens == 0)
                    {
                        Gl.glColor4d(0, 0, 255, 1);

                        Gl.glBegin(Gl.GL_QUAD_STRIP);


                        Gl.glVertex2d((double)x11 - 0.5, (double)y11 - 0.5);
                        Gl.glVertex2d((double)x11 + 0.5, (double)y11 - 0.5);
                        Gl.glVertex2d((double)x11 - 0.5, (double)y11 + 0.5);
                        Gl.glVertex2d((double)x11 + 0.5, (double)y11 + 0.5);
                        Gl.glEnd();
                    }
                    else
                    {


                        Gl.glColor4d(0, 0, 255, intens); ; //выбор соответствующей интенсивности


                        Gl.glBegin(Gl.GL_QUAD_STRIP);


                        Gl.glVertex2d((double)x11 - 0.5, (double)y11 - 0.5);
                        Gl.glVertex2d((double)x11 + 0.5, (double)y11 - 0.5);
                        Gl.glVertex2d((double)x11 - 0.5, (double)y11 + 0.5);
                        Gl.glVertex2d((double)x11 + 0.5, (double)y11 + 0.5);
                        Gl.glEnd();



                        Gl.glColor4d(0, 0, 255, 1 - intens); ;
                        Gl.glBegin(Gl.GL_QUAD_STRIP);

                        Gl.glVertex2d((double)x11 - 0.5 + 1, (double)y11 - 0.5);
                        Gl.glVertex2d((double)x11 + 0.5 + 1, (double)y11 - 0.5);
                        Gl.glVertex2d((double)x11 - 0.5 + 1, (double)y11 + 0.5);
                        Gl.glVertex2d((double)x11 + 0.5 + 1, (double)y11 + 0.5);
                        Gl.glEnd();


                    }
                    ValuesArray[count, 0] = x11;
                    ValuesArray[count, 1] = y11;


                    count++;

                    for (int x = x11, y = y11 + sy, i = 1; i <= dy; i++, y += sy)
                    {
                        if (d > 0)
                        {
                            d += d2;
                            x += sx;
                        }
                        else
                            d += d1;

                        intens = Math.Abs(y1 - LineKoord[count, 1]);
                        if (intens == 0)
                        {
                            Gl.glColor4d(0, 0, 255, 1);

                            Gl.glBegin(Gl.GL_QUAD_STRIP);


                            Gl.glVertex2d((double)x - 0.5, (double)y - 0.5);
                            Gl.glVertex2d((double)x + 0.5, (double)y - 0.5);
                            Gl.glVertex2d((double)x - 0.5, (double)y + 0.5);
                            Gl.glVertex2d((double)x + 0.5, (double)y + 0.5);
                            Gl.glEnd();
                        }
                        else
                        {

                            Gl.glColor4d(0, 0, 255, intens);

                            Gl.glBegin(Gl.GL_QUAD_STRIP);


                            Gl.glVertex2d((double)x - 0.5, (double)y - 0.5);
                            Gl.glVertex2d((double)x + 0.5, (double)y - 0.5);
                            Gl.glVertex2d((double)x - 0.5, (double)y + 0.5);
                            Gl.glVertex2d((double)x + 0.5, (double)y + 0.5);
                            Gl.glEnd();

                            Gl.glColor4d(0, 0, 255, 1 - intens);
                            Gl.glBegin(Gl.GL_QUAD_STRIP);

                            Gl.glVertex2d((double)x - 0.5 + 1, (double)y - 0.5);
                            Gl.glVertex2d((double)x + 0.5 + 1, (double)y - 0.5);
                            Gl.glVertex2d((double)x - 0.5 + 1, (double)y + 0.5);
                            Gl.glVertex2d((double)x + 0.5 + 1, (double)y + 0.5);
                            Gl.glEnd();
                        }
                        ValuesArray[count, 0] = x;
                        ValuesArray[count, 1] = y;


                        count++;


                    }

                }

            }
            else
            {
                if ((x1 == 0) && (x2 == 0))
                {
                    for (int y = y1; y<=y2; y ++)
                    {
                        Gl.glBegin(Gl.GL_QUAD_STRIP);


                        Gl.glVertex2d((double)x1 - 0.5, (double)y - 0.5);
                        Gl.glVertex2d((double)x1 + 0.5, (double)y - 0.5);
                        Gl.glVertex2d((double)x1 - 0.5, (double)y + 0.5);
                        Gl.glVertex2d((double)x1 + 0.5, (double)y + 0.5);
                        Gl.glEnd();

                        ValuesArray[count, 0] = x1;
                        ValuesArray[count, 1] = y;
                    }
                }

                if ((y1 == 0) && (y2 == 0))
                {
                    for (int x = x1; x <= x2; x++)
                    {
                        Gl.glBegin(Gl.GL_QUAD_STRIP);


                        Gl.glVertex2d((double)x - 0.5, (double)y1 - 0.5);
                        Gl.glVertex2d((double)x + 0.5, (double)y1 - 0.5);
                        Gl.glVertex2d((double)x - 0.5, (double)y1+ 0.5);
                        Gl.glVertex2d((double)x + 0.5, (double)y1 + 0.5);
                        Gl.glEnd();

                        ValuesArray[count, 0] = x;
                        ValuesArray[count, 1] = y1;
                    }
                }

            }

             setka(); 
 
        

        }
        private void AlgVu_Load(object sender, EventArgs e)
        {

            Glut.glutInit();
            Glut.glutInitDisplayMode(Glut.GLUT_RGBA | Glut.GLUT_DOUBLE | Glut.GLUT_DEPTH);
            Gl.glEnable(Gl.GL_BLEND);
            Gl.glBlendFunc(Gl.GL_SRC_ALPHA, Gl.GL_ONE_MINUS_SRC_ALPHA);
         //   Gl.glEnable(Glut.GL);
          //  Gl.glBlendFunc(Glut.GL_SRC_ALPHA, GL_ONE_MINUS_SRC_ALPHA);
            Gl.glClearColor(255, 255, 255, 1);

            Gl.glViewport(0, 0, vu.Width, vu.Height);
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();

            Glu.gluOrtho2D(0.0, 25, 0.0, 25);
            Gl.glMatrixMode(Gl.GL_MODELVIEW);

            Gl.glPushMatrix();
            Gl.glTranslated(10, 10, 0);
         

            x1 = 2;
            y1 = 1;
            x2 = 8;
            y2 = 3;

            setka();
            VU(x1, y1, x2, y2);

            Gl.glFlush();
            vu.Invalidate();
        }
    }
}
