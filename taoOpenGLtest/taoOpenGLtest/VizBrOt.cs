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
namespace taoOpenGLtest
{
    public partial class VizBrOt : Form
    {
        #region +++ GLOBAL +++
        //флаг полноэкранного режима
        private bool FS;
        #endregion

        private   DataAl D = new DataAl();

        bool loaded = false;
        double[,] ValuesArray;
        int x1, y1, x2, y2;
        int num = 0;

 #region CONSTRUCTORS

        public VizBrOt()
        {
            InitializeComponent();
        
         //   anT.InitializeContexts();
           // Iniz();
            //ResizeGlScene();
            //drawSc();
        }
        public VizBrOt(bool fullscreen)
        {
            InitializeComponent();
            //anT.InitializeContexts();
         //   Iniz();
         //   ResizeGlScene();
        //    drawSc();
        }
 #endregion
    /*    private void Iniz()
        {
            Glut.glutInit();
            Glut.glutInitDisplayMode(Glut.GLUT_RGB | Glut.GLUT_DOUBLE | Glut.GLUT_DEPTH);
            Gl.glClearColor(255, 255, 255, 1);
        
        }*/
      /*  void ResizeGlScene()
        {
            if (anT.Height == 0)
            {
                anT.Height = 1;
            }

            Gl.glViewport(0, 0, anT.Width, anT.Height);
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();

            Glu.gluOrtho2D(0.0, 25, 0.0, 25);
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();
        }
        private void drawSc()
        {
            Gl.glTranslated(10, 10, 0);
           


            Gl.glPushMatrix();
            x1 = 2;
            y1 = 1;
            x2 = 8;
            y2 = 3;
            setka();


            Gl.glPushMatrix();
          /*  Glu.GLUquadric disk = Glu.gluNewQuadric();
            Glu.gluQuadricDrawStyle(disk, Glu.GLU_FILL); 
            Gl.glColor3ub(255, 0, 150);
            Glu.gluDisk(disk, 0.5, 1.0, 30, 1);
            */
        //    Gl.glPopMatrix();
       //     Gl.glFlush();
       //     anT.Invalidate();
           
      //  }
        private void button1_Click(object sender, EventArgs e)
        {
            
            Draw();
          //  D.Show();
          
                  timer1.Start();
       
        }
 
  /*      private void PrintText(double x, double y, string text)
        {

            Gl.glRasterPos2d(x, y);
            foreach (char sign in text)
            {
                Glut.glutBitmapCharacter(Glut.GLUT_BITMAP_9_BY_15, sign);
            }

        }*/
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



            GL.Color3(1.0f,0.0f,0.0f);
            GL.Begin(PrimitiveType.Lines);
            GL.Vertex2(x1, y1);
            GL.Vertex2(x2, y2);
            GL.End();
            GL.Color3(255, 255, 255);
        //    PrintText(14.5, 0.5, "x");
          //  PrintText(0.5, 14.5, "y");
            GL.Color3(0, 0, 255);
        }
        private void ObRes(int x11, int y11, int x22, int y22 )
        {
            ValuesArray = null;
            
       //     Gl.glColor3f(255, 255, 0);
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
       //        Gl.glColor3f(255, 255, 0);
      /*         Gl.glBegin(Gl.GL_POINTS);
                Gl.glVertex2d(i, temp);
                Gl.glEnd();*/

             Sinhr.Value=Sinhr.Value+ "x = " + Convert.ToString(i)+" "+ " y = "+Convert.ToString(temp)+"\n";
                   ValuesArray[count, 0] = i;
                   ValuesArray[count, 1] = temp;
                   
                
                   count++;

               
      
            }
          
         
        }
        private void PervChet(int x11, int y11, int x22, int y22)
        {
            ValuesArray = null;
            int len = Math.Abs(x1 - x2 - 1);
            ValuesArray = new double[len, 2];
            int count = 0;
            int d = ((y22 - y11) << 1) - (x22 - x11);
            int d1 = (y22 - y11) << 1;
            int d2 = ((y22 - y11) - (x22 - x11)) << 1;
       //     Gl.glColor3f(0, 255, 255);
        /*    Gl.glPointSize(5);

               Gl.glBegin(Gl.GL_POINTS);
               Gl.glVertex2d(x11, y11);
               Gl.glEnd();*/

            ValuesArray[count, 0] = x11;
            ValuesArray[count, 1] = y11;


            count++;

       /*     Gl.glBegin(Gl.GL_QUAD_STRIP);
           

            Gl.glVertex2d((double)x11 - 0.5, (double)y11 - 0.5);
            Gl.glVertex2d((double)x11 + 0.5, (double)y11 - 0.5);
            Gl.glVertex2d((double)x11 - 0.5, (double)y11 + 0.5);
            Gl.glVertex2d((double)x11 + 0.5, (double)y11 + 0.5);
            Gl.glEnd();
            */
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


                   ValuesArray[count, 0] = x;
                   ValuesArray[count, 1] = y;


                   count++;


              /*     Gl.glBegin(Gl.GL_QUAD_STRIP);



                   Gl.glVertex2d((double)x - 0.5, (double)y - 0.5);
                   Gl.glVertex2d((double)x + 0.5, (double)y - 0.5);
                   Gl.glVertex2d((double)x - 0.5, (double)y + 0.5);
                   Gl.glVertex2d((double)x + 0.5, (double)y + 0.5);
                   Gl.glEnd();*/
                   
               }
         //      setka();

        }
        private void Brezenhem(int x11, int y11, int x22, int y22)
        {
            ValuesArray = null;
            int len = Math.Abs(x11 - x22 - 1);
            ValuesArray = new double[len, 2];
            int count = 0;

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

               /* Gl.glColor3f(0, 0, 255);
             
                
                Gl.glBegin(Gl.GL_QUAD_STRIP);


                Gl.glVertex2d((double)x11 - 0.5, (double)y11 - 0.5);
                Gl.glVertex2d((double)x11 + 0.5, (double)y11 - 0.5);
                Gl.glVertex2d((double)x11 - 0.5, (double)y11 + 0.5);
                Gl.glVertex2d((double)x11 + 0.5, (double)y11 + 0.5);
                Gl.glEnd();
                * */

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


                    /*
                    Gl.glBegin(Gl.GL_QUAD_STRIP);


                    Gl.glVertex2d((double)x - 0.5, (double)y - 0.5);
                    Gl.glVertex2d((double)x + 0.5, (double)y - 0.5);
                    Gl.glVertex2d((double)x - 0.5, (double)y + 0.5);
                    Gl.glVertex2d((double)x + 0.5, (double)y + 0.5);
                    Gl.glEnd();
               */
                    ValuesArray[count, 0] = x;
                    ValuesArray[count, 1] = y;


                    count++;
                }

            }
            else 
            {
                int d = (dx << 2) - dy;
                int d1 = dx << 1;
                int d2 = (dx - dy) << 1;

             /*   Gl.glColor3f(0, 0, 255);
          
                Gl.glBegin(Gl.GL_QUAD_STRIP);


                Gl.glVertex2d((double)x11 - 0.5, (double)y11 - 0.5);
                Gl.glVertex2d((double)x11 + 0.5, (double)y11 - 0.5);
                Gl.glVertex2d((double)x11 - 0.5, (double)y11 + 0.5);
                Gl.glVertex2d((double)x11 + 0.5, (double)y11 + 0.5);
                Gl.glEnd();
              * */
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
                    /*
                    Gl.glColor3f(0, 0, 255);
               
                    Gl.glBegin(Gl.GL_QUAD_STRIP);


                    Gl.glVertex2d((double)x - 0.5, (double)y - 0.5);
                    Gl.glVertex2d((double)x + 0.5, (double)y - 0.5);
                    Gl.glVertex2d((double)x - 0.5, (double)y + 0.5);
                    Gl.glVertex2d((double)x + 0.5, (double)y + 0.5);
                    Gl.glEnd();*/
                    ValuesArray[count, 0] = x;
                    ValuesArray[count, 1] = y;


                    count++;
               
                   
                }

            }


      //       setka(); 
 
        }
    /*    private void Iniz()
        {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
            Gl.glClearColor(255, 255, 255, 1);

            setka();

          


            x1 = 2;
            y1 = 1;
            x2 = 8;
            y2 = 3;
            

            Gl.glFlush();
            anT.Invalidate();
        }*/

        private void Form1_Load(object sender, EventArgs e)
        {
            
            groupBox1.Controls.Add(urav);
            groupBox1.Controls.Add(chetv);
            groupBox1.Controls.Add(resh);
            groupBox1.Controls.Add(urav);

         /*   Glut.glutInit();
            Glut.glutInitDisplayMode(Glut.GLUT_RGB | Glut.GLUT_DOUBLE | Glut.GLUT_DEPTH);
            Gl.glClearColor(255, 255, 255, 1);
        */
           /* Gl.glViewport(0, 0, anT.Width, anT.Height);
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();
            Glu.gluOrtho2D(0.0, 25, 0.0, 25); 
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity(); */
         /*   Gl.glPushMatrix();
           Gl.glTranslated(10, 10, 0);
     
       
           x1 = 2;
           y1 = 1;
           x2 = 8;
           y2 = 3;
           setka();
         
         Gl.glFlush();
           anT.Invalidate();
           
     */
        }
        private void drawPixel(int x22)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            if (ValuesArray[num, 0] <= x22)
            {

                GL.Color3(1.0f, 1.0f, 1.0f);
          //  PrintText((double)ValuesArray[num, 0], -0.8, Convert.ToString((double)ValuesArray[num, 0]));

           //  PrintText(-0.8, (double)ValuesArray[num, 1], Convert.ToString((double)ValuesArray[num, 1]));
                GL.Color3(0.0f, 0.0f, 1.0f);
                GL.Begin(PrimitiveType.QuadStrip);
                //GL.glBegin(Gl.GL_QUAD_STRIP);
                GL.Vertex2((double)ValuesArray[num, 0] - 0.5, ValuesArray[num, 1] - 0.5);
                GL.Vertex2((double)ValuesArray[num, 0] + 0.5, ValuesArray[num, 1] - 0.5);
                GL.Vertex2((double)ValuesArray[num, 0] - 0.5, ValuesArray[num, 1] + 0.5);
                GL.Vertex2((double)ValuesArray[num, 0] + 0.5, ValuesArray[num, 1] + 0.5);

                GL.End();
                if (ValuesArray[num, 0] == x22)
                { num = 0;
                timer1.Stop();
                }
                else
                {

                    num++;
                }
            }
            else
            {
                num = 0;
               timer1.Stop();
            }
            setka();
            glControl1.SwapBuffers();
          //  Glut.glutPostRedisplay();
        //   Glut.glutSwapBuffers();
            
         //Gl.glFlush();
         //   anT.Invalidate();
        }
        private void Draw()
        {

          
            if (urav.Checked)
                {
                   // Iniz();

                    ObRes(x1, y1, x2, y2);
                    
                }
            if (chetv.Checked)
            {
             //   Iniz();
                PervChet(x1, y1, x2, y2);
            }
            if (resh.Checked)
            {
            //    Iniz();
                Brezenhem(x1, y1, x2, y2);
            }


        //    setka();
            
      
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            drawPixel(x2);
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Enabled=false; 
            
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
         //   ResizeGlScene();
           // drawSc();
        }

        private void glControl1_Paint(object sender, PaintEventArgs e)
        {
            if (!loaded)
                return;
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
      
            //код с tao
            if (glControl1.Height == 0)
            {
                glControl1.Height = 1;
            }

            GL.Viewport(0, 0, glControl1.Width, glControl1.Height);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();

           // GL.Ortho(-1, 1, -1, 1, -1, 1);
            Glu.gluOrtho2D(0.0, 25, 0.0, 25);
           
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();

            GL.Translate(10, 10, 0);
            setka();
            
           
        /*    Gl.glBegin(Gl.GL_LINES);
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
            */
            glControl1.SwapBuffers();

        }

        private void glControl1_Load(object sender, EventArgs e)
        {
            loaded = true;
            GL.ClearColor(Color.Black);

        }

       
    }
}
