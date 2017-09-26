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
    public partial class AlgCDA : Form
    {
        double x1, y1, x2, y2;
        public AlgCDA()
        {
            InitializeComponent();
            cda.InitializeContexts();
        }
        private void CDA(double x11, double y11, double x22, double y22)
        {
            double saveX1 = x11;
            double saveY1 = y11;
            double saveX2 = x22;
            double saveY2 = y22;
       /*     Gl.glPointSize(5);
            Gl.glColor3f(0, 0, 255);
            Gl.glBegin(Gl.GL_POINTS); 
            Gl.glVertex2d(saveX1, saveY1);
            Gl.glEnd();
        * */
            Gl.glColor3f(0, 0, 255);
            Gl.glBegin(Gl.GL_QUAD_STRIP); 
            Gl.glVertex2d(saveX1, saveY1);
            Gl.glVertex2d(saveX1 + 1, saveY1);
            Gl.glVertex2d(saveX1, saveY1 + 1);
            Gl.glVertex2d(saveX1 + 1, saveY1 + 1);

            Gl.glEnd();
           
           // x11++;
            double k = (y22 - y11) / (x22 - x11);
            if ((0 < k) && (k <= 1)) 
            {
                for (double i = x11; i < x22; i++)
                {
                    x11++;
                    y11 = y11 + k;
                    y11 = Math.Round(y11);
                    
               /*     Gl.glPointSize(5);
                    Gl.glColor3f(0, 0, 255);
                    Gl.glBegin(Gl.GL_POINTS);
                    Gl.glVertex2d(x11, y11);
                    Gl.glEnd();
*/
                    Gl.glBegin(Gl.GL_QUAD_STRIP);
                    Gl.glVertex2d(x11, y11);
                    Gl.glVertex2d(x11 + 1, y11);
                    Gl.glVertex2d(x11, y11 + 1);
                    Gl.glVertex2d(x11 + 1, y11 + 1);

                    Gl.glEnd();
                   
                }
            }
            if (Math.Abs(k) > 1)
            {
                for (double i = saveX1; i < saveX2; i++)
                {
                    y11++;
                    x11 = x11 +(1/ k);
                    x11 = Math.Round(x11);
                    
               /*     Gl.glPointSize(5);
                    Gl.glColor3f(0, 0, 255);
                    Gl.glBegin(Gl.GL_POINTS);
                    Gl.glVertex2d(x11, y11);
                    Gl.glEnd();
                * */

                    Gl.glColor3f(0, 0, 255);
                    Gl.glBegin(Gl.GL_QUAD_STRIP);
                    Gl.glVertex2d(x11, y11);
                    Gl.glVertex2d(x11 + 1, y11);
                    Gl.glVertex2d(x11, y11 + 1);
                    Gl.glVertex2d(x11 + 1, y11 + 1);

                    Gl.glEnd();
                  
                }
            }
        
        }
        private void AlgCDA_Load(object sender, EventArgs e)
        {
              Glut.glutInit();
            Glut.glutInitDisplayMode(Glut.GLUT_RGB | Glut.GLUT_DOUBLE | Glut.GLUT_DEPTH);
            Gl.glClearColor(255, 255, 255, 1);
        
            Gl.glViewport(0, 0, cda.Width, cda.Height);
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
           y2 = 9;
           
           Gl.glColor3f(255, 0, 0);
           Gl.glBegin(Gl.GL_LINES);
           Gl.glVertex2d(x1, y1);
           Gl.glVertex2d(x2, y2);
           Gl.glEnd();
           CDA(x1, y1, x2, y2);
            
           Gl.glFlush();
           cda.Invalidate();

      
        }
        }

    }

