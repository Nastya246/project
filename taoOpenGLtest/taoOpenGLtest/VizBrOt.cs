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
    //сделать восьмисвязность,подписать отрезки
    public partial class VizBrOt : Form
    {
      

        private   DataAl D = new DataAl();

        bool loaded = false;
        double[,] ValuesArray;
        int x1, y1, x2, y2;
        int tempDraw = 0;
        int num = 0;
      
        public VizBrOt()
        {
            InitializeComponent();
       
        }


        private void button1_Click(object sender, EventArgs e)
        {
            
            Draw();
         
                  timer1.Start();
       
        }
 
     /*   private void PrintText(double x, double y, string text)
        {
            uint texture_text = 0;
            Bitmap text_bmp = new Bitmap(glControl1.Width, glControl1.Height);
            Graphics gfx = Graphics.FromImage(text_bmp);
            gfx.Clear(Color.Beige);
            Font font = new Font(FontFamily.GenericSerif, 7.0f);
            gfx.DrawString(text, font, Brushes.Gold, new PointF((float)x, (float)y));
            BitmapData data = text_bmp.LockBits(new Rectangle(0, 0, text_bmp.Width, text_bmp.Height), ImageLockMode.ReadOnly,System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            GL.Enable(EnableCap.Texture2D);
            GL.GenTextures(1,out texture_text);
            GL.BindTexture(TextureTarget.Texture2D, texture_text);
            GL.TexParameterI(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, ui)
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
           //PrintText(14.5, 0.5, "x");
           // PrintText(0.5, 14.5, "y");
            GL.Color3(0, 0, 255);
        }
        private void ObRes(int x11, int y11, int x22, int y22 )
        {
            ValuesArray = null;
            
            double k = ((double)y22 - (double)y11) / ((double)x22 - (double)x11);
            double b = y11 - k * x11;
            double temp;
            int len = Math.Abs(x1 - x2 - 1);
            int count = 0;
            ValuesArray = new double[len, 2];
            for (int i = x11; i <= x22; i++)
            {

                temp = Math.Round(k * i + b);

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
      

            ValuesArray[count, 0] = x11;
            ValuesArray[count, 1] = y11;


            count++;

   
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



                   ValuesArray[count, 0] = x;
                   ValuesArray[count, 1] = y;


                   count++;


                   
               }
         

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
                  
                    ValuesArray[count, 0] = x;
                    ValuesArray[count, 1] = y;


                    count++;
               
                   
                }

            }
 
        }
        private void Brezenhem4(int x11, int y11, int x22, int y22)
        {
            ValuesArray = null;
            int len = Math.Abs(x11 - x22 - 1);
            ValuesArray = new double[len*2, 2];
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
                for (int i = 1; i <= dx+dy; i++)
                {
                  
                          ValuesArray[count, 0] = x11;
                          ValuesArray[count, 1] = y11;
                          count++;
                     
                          if (d <dx)
                          {
                              x11 = x11 + sx;
                              d = d + (dy << 1);
                              
                          }
                          else
                          {
                              y11 = y11 + sy;
                              d = d - (dx << 1);
                              
                          }
                }

                ValuesArray[count, 0] = x11;
                ValuesArray[count, 1] = y11;

            }
            else
            {
                int z = dx;
                dx = dy;
                dy = z;
                int d = (dy << 1) - dx;
                for (int i = 1; i <= dx+dy; i++)
                {

                    ValuesArray[count, 0] = x11;
                    ValuesArray[count, 1] = y11;
                    count++;
                
                    if (d < dx)
                    {
                        y11 = y11 + sy;
                        d = d + (dy << 1) ;
                       
                    }
                    else
                    {
                        x11 = x11 + sx;
                        d = d - (dx << 1);

                    }
                }
                ValuesArray[count, 0] = x11;
                ValuesArray[count, 1] = y11;

            }

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            
            groupBox1.Controls.Add(urav);
            groupBox1.Controls.Add(chetv);
            groupBox1.Controls.Add(resh);
            groupBox1.Controls.Add(urav);
            groupBox2.Controls.Add(ob8);
            groupBox2.Controls.Add(resur8);
            groupBox2.Controls.Add(chet8);

          
        }
        private void drawPixel(int x11,int x22)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            if (ValuesArray[num, 0] <= x22)
            {

                GL.Color3(1.0f, 1.0f, 1.0f);
          //  PrintText((double)ValuesArray[num, 0], -0.8, Convert.ToString((double)ValuesArray[num, 0]));

           //  PrintText(-0.8, (double)ValuesArray[num, 1], Convert.ToString((double)ValuesArray[num, 1]));
                GL.Color3(0.0f, 0.0f, 1.0f);
                GL.Begin(PrimitiveType.QuadStrip);
                
                GL.Vertex2((double)ValuesArray[num, 0] - 0.5, ValuesArray[num, 1] - 0.5);
                GL.Vertex2((double)ValuesArray[num, 0] + 0.5, ValuesArray[num, 1] - 0.5);
                GL.Vertex2((double)ValuesArray[num, 0] - 0.5, ValuesArray[num, 1] + 0.5);
                GL.Vertex2((double)ValuesArray[num, 0] + 0.5, ValuesArray[num, 1] + 0.5);

                GL.End();
                tempDraw++;
          
                for (int j = 0; j < tempDraw; j++)
                {
                    GL.Color3(0.0f, 0.0f, 1.0f);
                    GL.Begin(PrimitiveType.QuadStrip);

                    GL.Vertex2((double)ValuesArray[j, 0] - 0.5, ValuesArray[j, 1] - 0.5);
                    GL.Vertex2((double)ValuesArray[j, 0] + 0.5, ValuesArray[j, 1] - 0.5);
                    GL.Vertex2((double)ValuesArray[j, 0] - 0.5, ValuesArray[j, 1] + 0.5);
                    GL.Vertex2((double)ValuesArray[j, 0] + 0.5, ValuesArray[j, 1] + 0.5);

                    GL.End();
                }
      
                if (ValuesArray[num, 0] == x22)
                {
                    tempDraw = 0;
                    num = 0;
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
        
        }
        private void Draw()
        {

          
            if (urav.Checked)
                {
                   

              //      ObRes(x1, y1, x2, y2);
                    
                }
            if (chetv.Checked)
            {
             
            //    PervChet(x1, y1, x2, y2);
            }
            if (resh.Checked)
            {
            
                Brezenhem4(x1, y1, x2, y2);
            }
            if (ob8.Checked)
            {

                Brezenhem(x1, y1, x2, y2);
            }
            if (chet8.Checked)
            {

                PervChet(x1, y1, x2, y2);
            }
            if (resur8.Checked)
            {

                ObRes(x1, y1, x2, y2);
            }
   
      
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            drawPixel(x1,x2);
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Enabled=false; 
            
        }

       

        private void glControl1_Paint(object sender, PaintEventArgs e)
        {
            if (!loaded)
                return;
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
      
            
            if (glControl1.Height == 0)
            {
                glControl1.Height = 1;
            }

            GL.Viewport(0, 0, glControl1.Width, glControl1.Height);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();

           
            Glu.gluOrtho2D(0.0, 25, 0.0, 25);
           
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();

            GL.Translate(10, 10, 0);
            setka();
            
           
      
            glControl1.SwapBuffers();

        }

        private void glControl1_Load(object sender, EventArgs e)
        {
            loaded = true;
            GL.ClearColor(Color.Black);

        }

       
    }
}
