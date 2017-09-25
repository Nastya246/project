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
        float[,] ValuesArray;
        float x1, y1, x2, y2;

        public VizBrOt()
        {
            InitializeComponent();
        
            anT.InitializeContexts();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
         
            Brezenhem(x1, y1, x2, y2);
          /*  timer1.Enabled = false;
            timer1.Start();*/
            

        }
        private void fuctionCalculation(float x11, float y11, float x22, float y22)
        {
            float res;
            int count = 0;
            int len =Math.Abs((int)x1 - (int)x2 - 1);
            ValuesArray = new float[len, 2];
            for (float i = x1; i <= x2; i++) 
            {
                res = ((i - x1) * (y2 - y1) / (x2 - x1)) + y1;
                ValuesArray[count, 0] = i;
                ValuesArray[count, 1] = res;
                count++;

            }

        }
        private void Brezenhem(float x11, float y11, float x22, float y22)
        {
            float k;
            float temp;
            k = (y22 - y11) / (x22 - x11); //угловой коэффициент
        /*   if (Math.Abs(k) > 1) //проверяем |k|>1
            {
                temp = y11;
                y11 = x11;
                x11 = temp;
                temp = y22;
                y22 = x22;
                x22 = temp;

            }*/
            // сохранение исходных начальных и конечных координат прямой
            float saveX1 = x11; 
            float saveY1 = y11;
            float saveX2 = x22;
            float saveY2 = y22;
          
            int el = 1; // счетчик элементов массива, который хранит координаты x и y с шагом x=1
            float d; // отклонение
            Gl.glPointSize(5);
            Gl.glColor3f(0, 0, 255);
            Gl.glBegin(Gl.GL_POINTS); // ставлю точку
            Gl.glVertex2d(saveX1, saveY1);
            Gl.glEnd();
            Gl.glColor3f(255, 255, 255);

           
            Gl.glFlush();
            anT.Invalidate();
            timer1.Start();
            
            fuctionCalculation(x11, y11, x22, y22); // заполнение массива координатами

            Gl.glBegin(Gl.GL_QUAD_STRIP); //рисую "пиксель"
            Gl.glVertex2d(x11, y11);
            Gl.glVertex2d(x11 + 1, y11);
            Gl.glVertex2d(x11, y11 + 1);
            Gl.glVertex2d(x11 + 1, y11 + 1);

            Gl.glEnd();

           
            Gl.glFlush();
            anT.Invalidate();
            timer1.Start();
           

            Gl.glPointSize(5);
            if (k < 0.5)
            {
                x11++;
                

            }
            else 
            {
                x11++;
                y11++;
                
            }
            Gl.glColor3f(255, 255, 255);
           Gl.glBegin(Gl.GL_QUAD_STRIP);
            Gl.glVertex2d(x11, y11);
            Gl.glVertex2d(x11 + 1, y11);
            Gl.glVertex2d(x11, y11 + 1);
            Gl.glVertex2d(x11 + 1, y11 + 1);

            Gl.glEnd();

            Gl.glColor3f(0, 0, 255);
            Gl.glBegin(Gl.GL_POINTS);
            Gl.glVertex2d(x11, y11);
            Gl.glEnd();
         //   for (float i = x11; i <= x22; i++)
       //     {
            // вычисление d по формуле d=(X2исх-X1исх)*(P2-P1), для данного отрезка X1исх=2, Y1исх=1, X2исх=8, Y2исх=3
                d = (saveX2 - saveX1) * ((ValuesArray[el, 1] - ValuesArray[el - 1, 1]) - (ValuesArray[el+1, 1] - ValuesArray[el, 1]));
                //теперь работа с формулами d=d+2*((Y2исх-Y1исх)-(X2-X1исх)) либо с d=2*(Y2исх-Y1исх),для данного отрезка X1исх=2, Y1исх=1, X2исх=8, Y2исх=3
             for (float i = x11; i < x22; i++)
            {
                if (d > 0)
                {

                    y11++;
                    x11++;

                    d = d + 2 * ((saveY2 - saveY1) - (saveX2 - saveX1));
                    Gl.glColor3f(0, 0, 255);
                    Gl.glBegin(Gl.GL_POINTS);
                    Gl.glVertex2d(x11, y11);
                    Gl.glEnd();
                    
                }
                else 
                {
                    d = 2 * (saveY2 - saveY1);
                   
                        x11++;

                    Gl.glColor3f(0, 0, 255);
                    Gl.glBegin(Gl.GL_POINTS);
                    Gl.glVertex2d(x11, y11);
                    Gl.glEnd();

                }
                Gl.glColor3f(255, 255, 255);
                Gl.glBegin(Gl.GL_QUAD_STRIP);
                Gl.glVertex2d(x11-1, y11-1);
                Gl.glVertex2d(x11 , y11-1);
                Gl.glVertex2d(x11-1, y11 );
                Gl.glVertex2d(x11 , y11 );

                Gl.glEnd();
                Gl.glColor3f(0, 255, 0);
                Gl.glBegin(Gl.GL_POINTS);
                Gl.glVertex2d(x11, y11);
                Gl.glEnd();
            
                el++;
            }
 
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //инициализация glut

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
        /*   Gl.glBegin(Gl.GL_QUAD_STRIP);
           Gl.glVertex2d(1, 1);
           Gl.glVertex2d(2, 1);
           Gl.glVertex2d(1, 2);
           Gl.glVertex2d(2, 2);
           
           Gl.glEnd();
         * */
       //    Gl.glPopMatrix();
           x1 = 2;
           y1 = 1;
           x2 = 8;
           y2 = 3;
           Gl.glColor3f(255, 0, 0);
           Gl.glBegin(Gl.GL_LINES);
           Gl.glVertex2d(x1, y1);
           Gl.glVertex2d(x2, y2);
           Gl.glEnd();
       // Brezenhem(x1,y1,x2,y2);
            
           Gl.glFlush();
           anT.Invalidate();

        //    Gl.glEnable(Gl.GL_DEPTH_TEST);

      //      timer1.Start();
        }

        private void Draw()
        {
        //    Brezenhem(x1, y1, x2, y2);
            
      //      Gl.glFlush();

     //       anT.Invalidate();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Draw();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true; 
        }
    }
}
