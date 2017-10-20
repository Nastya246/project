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
using OpenTK;
using OpenTK.Graphics.OpenGL;
using System.Drawing.Imaging;

namespace taoOpenGLtest
{
    public partial class AlgCDA : Form
    {
        double x1, y1, x2, y2;
        double[,] ValuesArray;
        int tempDraw = 0;
        int num = 0;
        public AlgCDA()
        {
            InitializeComponent();
          
        }
        private void setka()
        {
            x1 = 2;
            y1 = 1;
            x2 = 8;
            y2 = 3;
            GL.Color3(Color.White);
            GL.PointSize(1);
            GL.Begin(PrimitiveType.Points);
            for (int ax = -100; ax < 100; ax++)
            {
                for (int bx = -100; bx < 100; bx++)
                {
                    GL.Vertex2(ax, bx);
                }

            }
            GL.End();

            GL.Begin(PrimitiveType.Lines);
            GL.Vertex2(0, -25);
            GL.Vertex2(0, 25);
            GL.Vertex2(-25, 0);
            GL.Vertex2(25, 0);

            GL.Vertex2(0, 15);
            GL.Vertex2(0.1, 14.5);
            GL.Vertex2(0, 14.5);
            GL.Vertex2(-0.1, 14.5);

            GL.Vertex2(15, 0);
            GL.Vertex2(14.5, 0.1);
            GL.Vertex2(15, 0);
            GL.Vertex2(14.5, -0.1);

            GL.End();



            GL.Color3(1.0f, 0.0f, 0.0f);
            GL.Begin(PrimitiveType.Lines);
            GL.Vertex2(x1, y1);
            GL.Vertex2(x2, y2);
            GL.End();
            GL.Color3(255, 255, 255);
            //PrintText(14.5, 0.5, "x");
            // PrintText(0.5, 14.5, "y");
            GL.Color3(0, 0, 255);
        }
        private void CDA(double x11, double y11, double x22, double y22)
        {
            ValuesArray = null;
            int len = Math.Abs((int)x1 - (int)x2) - 1;
            int count = 0;
            ValuesArray = new double[len, 2];
            double saveX1 = x11;
            double saveY1 = y11;
            double saveX2 = x22;
            double saveY2 = y22;
     
       /*     Gl.glColor3f(0, 0, 255);
            Gl.glBegin(Gl.GL_QUAD_STRIP); 
            Gl.glVertex2d(saveX1, saveY1);
            Gl.glVertex2d(saveX1 + 1, saveY1);
            Gl.glVertex2d(saveX1, saveY1 + 1);
            Gl.glVertex2d(saveX1 + 1, saveY1 + 1);

            Gl.glEnd();*/
           ValuesArray[count,0]=saveX1;
           ValuesArray[count, 1] = saveY1;
           count++;
            double k = (y22 - y11) / (x22 - x11);
            if ((0 < k) && (k <= 1)) 
            {
                for (double i = x11; i < x22; i++)
                {
                    x11++;
                    y11 = y11 + k;
                    y11 = Math.Round(y11);
                    ValuesArray[count, 0] = x11;
                    ValuesArray[count, 1] = y11;
                    count++;
                  /*  Gl.glBegin(Gl.GL_QUAD_STRIP);
                    Gl.glVertex2d(x11, y11);
                    Gl.glVertex2d(x11 + 1, y11);
                    Gl.glVertex2d(x11, y11 + 1);
                    Gl.glVertex2d(x11 + 1, y11 + 1);

                    Gl.glEnd();*/

                   
                }
            }
            if (Math.Abs(k) > 1)
            {
                for (double i = saveX1; i < saveX2; i++)
                {
                    y11++;
                    x11 = x11 +(1/ k);
                    x11 = Math.Round(x11);
                    ValuesArray[count, 0] = x11;
                    ValuesArray[count, 1] = y11;
                    count++;
         /*
                    Gl.glColor3f(0, 0, 255);
                    Gl.glBegin(Gl.GL_QUAD_STRIP);
                    Gl.glVertex2d(x11, y11);
                    Gl.glVertex2d(x11 + 1, y11);
                    Gl.glVertex2d(x11, y11 + 1);
                    Gl.glVertex2d(x11 + 1, y11 + 1);

                    Gl.glEnd();
            */      
                }
            }
        
        }
        private void AlgCDA_Load(object sender, EventArgs e)
        {
              Glut.glutInit();
            Glut.glutInitDisplayMode(Glut.GLUT_RGB | Glut.GLUT_DOUBLE | Glut.GLUT_DEPTH);
            Gl.glClearColor(255, 255, 255, 1);
        
        //    Gl.glViewport(0, 0, cda.Width, cda.Height);
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

           Gl.glVertex2d(15,0);
           Gl.glVertex2d(14.5, 0.1);
           Gl.glVertex2d(15, 0);
           Gl.glVertex2d(14.5, -0.1);

           Gl.glEnd();
       
           x1 = 2;
           y1 = 1;
           x2 = 8;
           y2 = 3;
           
           Gl.glColor3f(255, 0, 0);
           Gl.glBegin(Gl.GL_LINES);
           Gl.glVertex2d(x1, y1);
           Gl.glVertex2d(x2, y2);
           Gl.glEnd();
           CDA(x1, y1, x2, y2);
            
           Gl.glFlush();
           //cda.Invalidate();

      
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Draw();
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }
        }

    }

