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
    public partial class VizBrOt : Form
    {
        double[,] ValuesArray;
        int x1, y1, x2, y2;
        int num = 0;

        public VizBrOt()
        {
            InitializeComponent();
        
            anT.InitializeContexts();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Draw();
                  timer1.Start();
           
                  Glut.glutSwapBuffers();

            anT.Invalidate();

        }
    /*    private void fuctionCalculation(int x11, int y11, int x22, int y22)
        {
            float res;
            int count = 0;
            int len =Math.Abs(x1 - x2 - 1);
            ValuesArray = new double[len, 2];
            for (int i = x1; i <= x2; i++) 
            {
                res = ((i - x1) * (y2 - y1) / (x2 - x1)) + y1;
                ValuesArray[count, 0] = i;
                ValuesArray[count, 1] = res;
                count++;

            }

        }*/
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
        
        }
        private void ObRes(int x11, int y11, int x22, int y22 )
        {
            
            Gl.glColor3f(255, 255, 0);
      //      Gl.glPointSize(25);
            double k = ((double)y22 - (double)y11) / ((double)x22 - (double)x11);
            double b = y11 - k * x11;
            double temp;
            int len = Math.Abs(x1 - x2 - 1);
            int count = 0;
            ValuesArray = new double[len, 2];
            for (int i = x11; i <= x22; i++)
            {

                temp = Math.Round(k * i + b);
               Gl.glColor3f(255, 255, 0);
      /*         Gl.glBegin(Gl.GL_POINTS);
                Gl.glVertex2d(i, temp);
                Gl.glEnd();*/

              
                   ValuesArray[count, 0] = i;
                   ValuesArray[count, 1] = temp;
                   count++;

               
       /*         
              Gl.glBegin(Gl.GL_QUAD_STRIP);
                Gl.glVertex2d((double)i-0.5, (double)temp-0.5);
                Gl.glVertex2d((double)i + 0.5, (double)temp - 0.5);
                Gl.glVertex2d((double)i - 0.5, (double)temp + 0.5);
                Gl.glVertex2d((double)i + 0.5, (double)temp + 0.5);

                Gl.glEnd();
              
        * */
            }
            setka(); 
        }
        private void PervChet(int x11, int y11, int x22, int y22)
        {

            int d = ((y22 - y11) << 1) - (x22 - x11);
            int d1 = (y22 - y11) << 1;
            int d2 = ((y22 - y11) - (x22 - x11)) << 1;
            Gl.glColor3f(0, 255, 255);
        /*    Gl.glPointSize(5);

               Gl.glBegin(Gl.GL_POINTS);
               Gl.glVertex2d(x11, y11);
               Gl.glEnd();*/
            Gl.glBegin(Gl.GL_QUAD_STRIP);
           

            Gl.glVertex2d((double)x11 - 0.5, (double)y11 - 0.5);
            Gl.glVertex2d((double)x11 + 0.5, (double)y11 - 0.5);
            Gl.glVertex2d((double)x11 - 0.5, (double)y11 + 0.5);
            Gl.glVertex2d((double)x11 + 0.5, (double)y11 + 0.5);
            Gl.glEnd();

               for (int x = x11 + 1, y = y11; x <= x22; x++)
               {
                   if (d > 0)
                   {
                       d += d2;
                       y += 1;
                   }
                   else
                   {
                       d += d1;
                   }

                  /* Gl.glBegin(Gl.GL_POINTS);
                   Gl.glVertex2d(x, y);
                   Gl.glEnd();
                   * */

                   Gl.glBegin(Gl.GL_QUAD_STRIP);


                   Gl.glVertex2d((double)x - 0.5, (double)y - 0.5);
                   Gl.glVertex2d((double)x + 0.5, (double)y - 0.5);
                   Gl.glVertex2d((double)x - 0.5, (double)y + 0.5);
                   Gl.glVertex2d((double)x + 0.5, (double)y + 0.5);
                   Gl.glEnd();
                   
               }
               setka();

        }
        private void Brezenhem(int x11, int y11, int x22, int y22)
        {
            int dx = Math.Abs(x22 - x11);
            int dy = Math.Abs(y22 - y11);
            double k = ((double)y22 - (double)y11) / ((double)x22 - (double)x11);
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

            if (k <= 1)
            {
                int d = (dy << 1) - dx;
                int d1 = dy << 1;
                int d2 = (dy - dx) << 1;

                Gl.glColor3f(0, 0, 255);
             
                Gl.glBegin(Gl.GL_QUAD_STRIP);


                Gl.glVertex2d((double)x11 - 0.5, (double)y11 - 0.5);
                Gl.glVertex2d((double)x11 + 0.5, (double)y11 - 0.5);
                Gl.glVertex2d((double)x11 - 0.5, (double)y11 + 0.5);
                Gl.glVertex2d((double)x11 + 0.5, (double)y11 + 0.5);
                Gl.glEnd();
                for (int x = x11 + sx, y = y11, i = 1; i <= dx; i++, x += sx)
                {
                    if (d > 0)
                    {
                        d += d2;
                        y += sy;
                    }
                    else
                        d += d1;


                    Gl.glBegin(Gl.GL_QUAD_STRIP);


                    Gl.glVertex2d((double)x - 0.5, (double)y - 0.5);
                    Gl.glVertex2d((double)x + 0.5, (double)y - 0.5);
                    Gl.glVertex2d((double)x - 0.5, (double)y + 0.5);
                    Gl.glVertex2d((double)x + 0.5, (double)y + 0.5);
                    Gl.glEnd();
               
                }

            }
            else 
            {
                int d = (dx << 2) - dy;
                int d1 = dx << 1;
                int d2 = (dx - dy) << 1;

                Gl.glColor3f(0, 0, 255);
          
                Gl.glBegin(Gl.GL_QUAD_STRIP);


                Gl.glVertex2d((double)x11 - 0.5, (double)y11 - 0.5);
                Gl.glVertex2d((double)x11 + 0.5, (double)y11 - 0.5);
                Gl.glVertex2d((double)x11 - 0.5, (double)y11 + 0.5);
                Gl.glVertex2d((double)x11 + 0.5, (double)y11 + 0.5);
                Gl.glEnd();
                for (int x = x11, y = y11 + sy, i = 1; i <= dy; i++, y += sy)
                {
                    if (d > 0)
                    {
                        d += d2;
                        x += sx;
                    }
                    else
                        d += d1;
                    Gl.glColor3f(0, 0, 255);
               
                    Gl.glBegin(Gl.GL_QUAD_STRIP);


                    Gl.glVertex2d((double)x - 0.5, (double)y - 0.5);
                    Gl.glVertex2d((double)x + 0.5, (double)y - 0.5);
                    Gl.glVertex2d((double)x - 0.5, (double)y + 0.5);
                    Gl.glVertex2d((double)x + 0.5, (double)y + 0.5);
                    Gl.glEnd();
               
                   
                }

            }


             setka(); 
 
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            groupBox1.Controls.Add(urav);
            groupBox1.Controls.Add(chetv);
            groupBox1.Controls.Add(resh);
            groupBox1.Controls.Add(urav);

            Glut.glutInit();
            Glut.glutInitDisplayMode(Glut.GLUT_RGB | Glut.GLUT_DOUBLE | Glut.GLUT_DEPTH);
            Gl.glClearColor(255, 255, 255, 1);
            //установка порта вывода
            Gl.glViewport(0, 0, anT.Width, anT.Height);
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();
           // настройка 2D ортогональной проекции
          
       /*     if ((float)anT.Width <= (float)anT.Height) 
            {
                Glu.gluOrtho2D(0.0, 30.0 * (float)anT.Height / (float)anT.Width, 0.0, 30.0); 
            }
            else {
                Glu.gluOrtho2D(0.0, 30.0 * (float)anT.Width / (float)anT.Height, 0.0, 30.0);
            } */
            Glu.gluOrtho2D(0.0, 25, 0.0, 25); 
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
         //  Gl.glLoadIdentity();
        //   Gl.glColor3f(0, 0, 0);
        //   Gl.glPushMatrix();
           Gl.glTranslated(10, 10, 0);
     
          
       //    Gl.glPopMatrix();
           x1 = 2;
           y1 = 1;
           x2 = 8;
           y2 = 3;
           setka();
      
         Gl.glFlush();
           anT.Invalidate();
           Gl.glPushMatrix();
        //    Gl.glEnable(Gl.GL_DEPTH_TEST);

      //      timer1.Start();
        }
        private void drawPixel(int x22)
        {
            if (ValuesArray[num, 0] < x22)
            {
                Gl.glBegin(Gl.GL_QUAD_STRIP);
                Gl.glVertex2d((double)ValuesArray[num, 0] - 0.5, ValuesArray[num, 1] - 0.5);
                Gl.glVertex2d((double)ValuesArray[num, 0] + 0.5, ValuesArray[num, 1] - 0.5);
                Gl.glVertex2d((double)ValuesArray[num, 0] - 0.5, ValuesArray[num, 1] + 0.5);
                Gl.glVertex2d((double)ValuesArray[num, 0] + 0.5, ValuesArray[num, 1] + 0.5);

                Gl.glEnd();

                num++;
            }
            else
            {
                num = 0;
                timer1.Stop();
            }
         //   Glut.glutSwapBuffers();
            anT.Invalidate();
        }
        private void Draw()
        {
            if (urav.Checked)
                {
                    ObRes(x1, y1, x2, y2);
                }
            if (chetv.Checked)
            {
                PervChet(x1, y1, x2, y2);
            }
            if (resh.Checked)
            {
                Brezenhem(x1, y1, x2, y2);
            }
          // Brezenhem(x1, y1, x2, y2);
            
       //     Gl.glFlush();

//           anT.Invalidate();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            drawPixel(x2);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Enabled=false; 
            
        }

       
    }
}
