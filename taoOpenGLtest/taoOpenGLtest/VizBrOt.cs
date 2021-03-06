﻿using System;
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
using System.Threading;
namespace taoOpenGLtest
{
    // убрать промежуточные результаты кода, увеличить тестовую линию, предложить открыть код сразу, текст можно как кртинки, уменьшить шааг
    //примеры алгоритма как картинки
    public partial class VizBrOt : Form
    {
        DataAl dataF = new DataAl();
        static private bool Exit = false;
        private   DataAl D = new DataAl();
        bool loaded = false;
        double[,] ValuesArray;
        double[,] LineKoord;
        double[] intensiv;
        int x1, y1, x2, y2;
        double x1d, y1d, x2d, y2d;
        int r = 3;
        int tempDraw = 0;// для анимации 
        int num = 0;
        double a=5, b=3;// для эллипса
        int temp = 0;
        int formCode = 0;
       
        public VizBrOt()
        {
            InitializeComponent();
       
        }
      
        int prov = 0; // для проверки было ли что-нибудь нарисовано
        private void Wait(double seconds)
        {
            int ticks = System.Environment.TickCount + (int)Math.Round(seconds * 1000.0);
            while (System.Environment.TickCount < ticks)
            {
                Application.DoEvents();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            
            Draw();
         
          //        timer1.Start();
       
        }
        private void koordLine(int x1, int y1, int x2, int y2) //для алгоритма ву, чтобы рассчитывать ближний пиксель.
        {
            int num = 0;

            for (int i = x1; i <= x2; i++)
            {
                LineKoord[num, 0] = i;
                LineKoord[num, 1] = ((((double)i - (double)x1) * ((double)y2 - (double)y1)) / ((double)x2 - (double)x1)) + (double)y1;
                num++;

            }

        }
        private void PrintText(double x, double y, string text)
        {
            
            
                uint texture_text = 0;
               //   GL.Clear(ClearBufferMask.ColorBufferBit);
         //       GL.ClearColor(0.0f, 0.0f, 0.0f, 0.0f);
                Bitmap text_bmp = new Bitmap(glControl1.Width, glControl1.Height);
                Graphics gfx = Graphics.FromImage(text_bmp);
                //поверхность для рис.
                
                    gfx.Clear(Color.White);
                
     
                Font font = new Font(FontFamily.GenericSerif, 500.0f);
                gfx.DrawString(text, font, Brushes.Black, new PointF(30, -170));
                //Вытягивание данных из картинки
                BitmapData data = text_bmp.LockBits(new Rectangle(0, 0, text_bmp.Width, text_bmp.Height), ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                GL.Enable(EnableCap.Texture2D);
                GL.GenTextures(1, out texture_text);
                GL.BindTexture(TextureTarget.Texture2D, texture_text);  //Текстура становится текущей
                GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Linear);
                GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Linear);
                GL.TexEnv(TextureEnvTarget.TextureEnv, TextureEnvParameter.TextureEnvMode, (float)TextureEnvMode.Modulate);
                //загрузка картинки в текстуру
                GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, data.Width, data.Height, 0, OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, data.Scan0);
                text_bmp.UnlockBits(data);
                GL.Enable(EnableCap.Blend);
               GL.BlendFunc(BlendingFactorSrc.SrcAlpha, BlendingFactorDest.OneMinusSrcAlpha);
                GL.BindTexture(TextureTarget.Texture2D, texture_text);
                GL.Color4(1.0f, 1.0f, 1.0f, 1.0f);
             //   GL.Color3(Color.Black);
        //   GL.Color3(Color.White);
            GL.Begin(PrimitiveType.Quads);

            GL.TexCoord2(0.0f, 1.0f); GL.Vertex2(x, y);
            GL.TexCoord2(1.0f, 1.0f); GL.Vertex2(x + 0.5f, y);
            GL.TexCoord2(1.0f, 0.0f); GL.Vertex2(x + 0.5f, y + 0.5f);
            GL.TexCoord2(0.0f, 0.0f); GL.Vertex2(x, y + 0.5f);
            GL.End();

            temp++;
        }
        private void setka()
        {

            GL.Color3(Color.White);
            GL.PointSize(1);
            GL.Begin(PrimitiveType.Points);
            for (int ax = -300; ax < 300; ax++)
            {
                for (int bx = -300; bx < 300; bx++)
                {
                    GL.Vertex2(ax, bx);
                }

            }
            GL.End();
            GL.LineWidth(1);
            GL.Begin(PrimitiveType.Lines);
            GL.Vertex2(0, -(Sinhr.point/2));
            GL.Vertex2(0, (Sinhr.point / 2));
            GL.Vertex2(-(Sinhr.point / 2), 0);
            GL.Vertex2((Sinhr.point / 2), 0);

         /*   GL.Vertex2(0, (Sinhr.point / 3));
            GL.Vertex2(0.1, (Sinhr.point / 3)-0.5);
            GL.Vertex2(0, (Sinhr.point / 3) - 0.5);
            GL.Vertex2(-0.1, (Sinhr.point / 3) - 0.5);

            GL.Vertex2((Sinhr.point / 3), 0);
            GL.Vertex2((Sinhr.point / 3) - 0.5, 0.1);
            GL.Vertex2((Sinhr.point / 3), 0);
            GL.Vertex2((Sinhr.point / 3) - 0.5, -0.1);*/

            GL.End();
            
            
           /*     GL.Color3(1.0f, 0.0f, 0.0f);
                GL.Begin(PrimitiveType.Lines);
                GL.Vertex2(x1, y1);
                GL.Vertex2(x2, y2);
                GL.End();
                GL.Color3(255, 255, 255);

                GL.Color3(0, 0, 255);*/
      //      PrintText((Sinhr.point / 3) - 0.5, 0.5, "x");
         //   PrintText(0.5, (Sinhr.point / 3) - 0.5, "y");
            
        }
        private void Pixel1(double x11, double y11, double intns)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            if (вуToolStripMenuItem.Checked == false)
            {
                GL.Color3(0.0f, 0.0f, 1.0f);
            }
            else {
                GL.Color4(0.0f, 0.0f, 1.0f, intns);
            }

            GL.Begin(PrimitiveType.QuadStrip);

            GL.Vertex2(x11 - 0.5, y11 - 0.5);
            GL.Vertex2(x11 + 0.5, y11 - 0.5);
            GL.Vertex2(x11 - 0.5, y11 + 0.5);
            GL.Vertex2(x11 + 0.5, y11 + 0.5);

            GL.End();
         
            TextData1.AppendText("(" + Convert.ToString((double)x11) + "; " + Convert.ToString((double)y11) + ")\n");
            Wait(0.5);
        }
        private void Pixel(double x11, double y11, double intns)
        {

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            for (int u = 0; u < tempDraw; u++)
            {
                GL.Color3(0.0f, 0.0f, 1.0f);

                GL.Begin(PrimitiveType.QuadStrip);

                GL.Vertex2(ValuesArray[u, 0] - 0.5, ValuesArray[u, 1] - 0.5);
                GL.Vertex2(ValuesArray[u, 0] + 0.5, ValuesArray[u, 1] - 0.5);
                GL.Vertex2(ValuesArray[u, 0] - 0.5, ValuesArray[u, 1] + 0.5);
                GL.Vertex2(ValuesArray[u, 0] + 0.5, ValuesArray[u, 1] + 0.5);

                GL.End();
                if (!окружностьToolStripMenuItem.Checked)
                {
                    PrintText(ValuesArray[u, 0], -0.8, Convert.ToString((double)ValuesArray[u, 0]));

                    PrintText(-0.8, ValuesArray[u, 1], Convert.ToString((double)ValuesArray[u, 1]));
                }

            }

            baseEl(x1, y1, x2, y2);
            setka();

            glControl1.SwapBuffers();
        }
        private void PixelVu(double x11, double y11, double intns)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            for (int j = 0; j < tempDraw; j++)
            {

                GL.Color3(0.0f, 0.0f, intensiv[j]);

                GL.Begin(PrimitiveType.QuadStrip);

                GL.Vertex2((double)ValuesArray[j, 0] - 0.5, ValuesArray[j, 1] - 0.5);
                GL.Vertex2((double)ValuesArray[j, 0] + 0.5, ValuesArray[j, 1] - 0.5);
                GL.Vertex2((double)ValuesArray[j, 0] - 0.5, ValuesArray[j, 1] + 0.5);
                GL.Vertex2((double)ValuesArray[j, 0] + 0.5, ValuesArray[j, 1] + 0.5);

                GL.End();
                PrintText((double)ValuesArray[j, 0], -0.8, Convert.ToString((double)ValuesArray[j, 0]));

                PrintText(-0.8, (double)ValuesArray[j, 1], Convert.ToString((double)ValuesArray[j, 1]));
            }
           baseEl(x1, y1, x2, y2);
            setka();

            glControl1.SwapBuffers();

        }

        private void ObResB(int x11, int y11, int x22, int y22) // построение линии по уравнению 8
        {
            int num = 0;
            dataF.code.Text = "";
            dataF.code.Text = (num++) + ". int count = 0; \n";

            int count = 0;


            ValuesArray = null;
            tempDraw = 0;

            dataF.code.AppendText((num++) + ". double k = ((double)y22 - (double)y11) / ((double)x22 - (double)x11); \n");
            double k = ((double)y22 - (double)y11) / ((double)x22 - (double)x11);
            dataF.code.AppendText((num++) + ".  if ((k <= 1) && (k >= 0)) {\n");
            dataF.code.AppendText((num++) + ". double b = y11 - k * x11, temp;\n");
           
            if ((k <= 1) && (k >= 0))
            {
                double b = y11 - k * x11;
                double temp;

                int len = Math.Abs(x1 - x2 - 1);
                ValuesArray = new double[len, 2];
                TextData1.Text = "Задана прямая:( " + Convert.ToString(x1) + "; " + Convert.ToString(y1) + ") и (" + Convert.ToString(x2) + ", " + Convert.ToString(y2) + ")\n";
                TextData1.AppendText("Координаты вычисленных пикселей:\n");

                dataF.code.AppendText((num++) + ". for (int i = x11; i<= x22; i++) {\n");

                dataF.code.AppendText((num++) + ". temp = Math.Round(k*i + b);\n");
                dataF.code.AppendText((num++) + ". GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);");
                dataF.code.AppendText((num++) + ". Pixel(i, temp, 1);} }\n");
                for (int i = x11; i <= x22; i++)
                {
                   
                    temp = Math.Round(k * i + b);

                  
                    GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
                    //   Pixel(i,temp,1);


                    ValuesArray[count, 0] = i;
                    ValuesArray[count, 1] = temp;
                    tempDraw++;
                    count++;

                    TextData1.AppendText("("+i+" ; " + temp+")\n");
                    Pixel(i, temp, 1);

                }
            }

            else
            {
                dataF.code.AppendText((num++) + ".  else {\n");
                dataF.code.AppendText((num++) + ". double b = y11 - k * x11, temp;\n");
                double b = y11 - k * x11;
                double temp;

                int len = (Math.Abs(x1 - x2))*2+5;
                ValuesArray = new double[len, 2];
                TextData1.Text = "Задана прямая:( " + Convert.ToString(x1) + "; " + Convert.ToString(y1) + ") и (" + Convert.ToString(x2) + ", " + Convert.ToString(y2) + ")\n";
                TextData1.AppendText("Координаты вычисленных пикселей:\n");

                dataF.code.AppendText((num++) + ". for (int i = x11; i<= x22; i++) {\n");

                dataF.code.AppendText((num++) + ". temp = Math.Round(k*i + b);\n");

                dataF.code.AppendText((num++) + ". GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);");
                dataF.code.AppendText((num++) + ". Pixel(i, temp, 1);} }\n");
                for (double i = x11; i <= x22; i=i+0.6)
                {
                  
                    temp = Math.Round(k * i + b);

                    GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
                    //   Pixel(i,temp,1);


                    ValuesArray[count, 0] = i;
                    ValuesArray[count, 1] = temp;
                    tempDraw++;
                    count++;
                    TextData1.AppendText("(" + i + " ; " + temp + ")\n");
                    Pixel(i, temp, 1);
                }
                dataF.code.AppendText((num++) + ". glControl1.SwapBuffers();\n");
                glControl1.SwapBuffers();
                glControl1.SwapBuffers();
                prov++;
            }
        }
        private void PervChetB(int x11, int y11, int x22, int y22)
        {
            tempDraw = 0;
            ValuesArray = null;
            int len = Math.Abs(x1 - x2 - 1);
            ValuesArray = new double[len, 2];
            int count = 0;
            int d = ((y22 - y11) << 1) - (x22 - x11);
            int d1 = (y22 - y11) << 1;
            int d2 = ((y22 - y11) - (x22 - x11)) << 1;
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
          //  Pixel(x11, y11,1);
            ValuesArray[count, 0] = x11;
            ValuesArray[count, 1] = y11;
            PrintText(x11, -0.8, Convert.ToString((double)x11));

            PrintText(-0.8, y11, Convert.ToString((double)y11));

            baseEl(x1, y1, x2, y2);
            setka();
            glControl1.SwapBuffers();
            tempDraw++;
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

                   Sinhr.Value = Sinhr.Value + "x = " + Convert.ToString(x) + " " + " y = " + Convert.ToString(y) + "\n";
                   GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
              //     Pixel(x,y,1);
                   ValuesArray[count, 0] = x;
                   ValuesArray[count, 1] = y;

                   tempDraw++;
                   count++;
                   Pixel(x,y,1);

                   
               }
               glControl1.SwapBuffers();
               glControl1.SwapBuffers();
               prov++;
         

        } // для построения в первой четверти 8
        private void Brezenhem(int x11, int y11, int x22, int y22)
        {
            tempDraw = 0;
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
                Sinhr.Value = Sinhr.Value + "x = " + Convert.ToString(x11) + " " + " y = " + Convert.ToString(y11) + "\n";
                GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
               
                TextData1.Text = "Задана прямая:( " + Convert.ToString(x1) + "; " + Convert.ToString(y1) + ") и (" + Convert.ToString(x2) + ", " + Convert.ToString(y2) + ")\n";
                TextData1.AppendText("Координаты вычисленных пикселей:\n");
             //   Pixel(x11,y11,1);
             
                ValuesArray[count, 0] = x11;
                ValuesArray[count, 1] = y11;

                PrintText(x11, -0.8, Convert.ToString((double)x11));

                PrintText(-0.8, y11, Convert.ToString((double)y11));

                baseEl(x1, y1, x2, y2);
                setka();
                glControl1.SwapBuffers();
                tempDraw++;
                
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
                    Sinhr.Value = Sinhr.Value + "x = " + Convert.ToString(x) + " " + " y = " + Convert.ToString(y) + "\n";
                    GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
                //   Pixel(x, y,1);
       
                    ValuesArray[count, 0] = x;
                    ValuesArray[count, 1] = y;
                    tempDraw++;

                    count++;
                   Pixel(x,y,1);//параметры
                    
                }
               
                glControl1.SwapBuffers();
                glControl1.SwapBuffers();
                prov++;

            }
            else 
            {
                int d = (dx << 2) - dy;
                int d1 = dx << 1;
                int d2 = (dx - dy) << 1;

                Sinhr.Value = Sinhr.Value + "x = " + Convert.ToString(x11) + " " + " y = " + Convert.ToString(y11) + "\n";
                GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
                
                TextData1.Text = "Задана прямая:( " + Convert.ToString(x1) + "; " + Convert.ToString(y1) + ") и (" + Convert.ToString(x2) + ", " + Convert.ToString(y2) + ")\n";
                TextData1.AppendText("Координаты вычисленных пикселей:\n");
           //     Pixel(x11,y11,1);
                ValuesArray[count, 0] = x11;
                ValuesArray[count, 1] = y11;
                PrintText(x11, -0.8, Convert.ToString((double)x11));

                PrintText(-0.8, y11, Convert.ToString((double)y11));

                baseEl(x1, y1, x2, y2);
                setka();
                glControl1.SwapBuffers();
                tempDraw++;
                

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
                    Sinhr.Value = Sinhr.Value + "x = " + Convert.ToString(x) + " " + " y = " + Convert.ToString(y) + "\n";
                    GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
                //    Pixel(x, y,1);
                    ValuesArray[count, 0] = x;
                    ValuesArray[count, 1] = y;
                    tempDraw++;

                    count++;
                    Pixel(x, y, 1);
                             
                }
               glControl1.SwapBuffers();
               glControl1.SwapBuffers();
                prov++;

            }
 
        }
        private void ObRes4B(int x11, int y11, int x22, int y22)
        {
            tempDraw = 0;
            ValuesArray = null;

            double k = ((double)y22 - (double)y11) / ((double)x22 - (double)x11);
            double b = y11 - k * x11;
            double temp;
            int len = 2*Math.Abs(x1 - x2 - 1);
            int count = 0;
            ValuesArray = new double[len, 2];
            for (int i = x11; i <= x22; i++)
            {

                temp = Math.Round(k * i + b);
                if (temp > y1)
                {
                    if (((temp - ValuesArray[count - 1, 1]) == 1) && (i - ValuesArray[count - 1, 0]==1))
                    {
                        GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
                    //    Pixel(i, ValuesArray[count - 1, 1],1);
                      
                        ValuesArray[count, 0] = i;
                        ValuesArray[count, 1] = ValuesArray[count - 1, 1];
                       
                        tempDraw++;
                        count++;
                        Pixel(i, ValuesArray[count - 1, 1], 1);
                    }
                }
                Sinhr.Value = Sinhr.Value + "x = " + Convert.ToString(i) + " " + " y = " + Convert.ToString(temp) + "\n";
                GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
              //  Pixel(i,temp,1);
                

                ValuesArray[count, 0] = i;
                ValuesArray[count, 1] = temp;

               
                tempDraw++;
                count++;
                Pixel(i, temp, 1);

            }
            glControl1.SwapBuffers();
            glControl1.SwapBuffers();
            prov++;
        }// построение линии по уравнению 4
        private void PervChet4B(int x11, int y11, int x22, int y22)
        {
            tempDraw = 0;
            ValuesArray = null;
            int len = Math.Abs(x11 - x22 - 1);
            ValuesArray = new double[len * 2, 2];
            int count = 0;
            int dx = Math.Abs(x22 - x11);
            int dy = Math.Abs(y22 - y11);
            int d = (dy << 1) - dx;
            int d1 = dy << 1;
            int d2 = (dy - dx) << 1;
            TextData1.AppendText("Координаты вычисленных пикселей:\n");
            for (int i = 1; i <= dx + dy; i++)
            {
                
                GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
             //   Pixel(x11, y11,1);

                ValuesArray[count, 0] = x11;
                ValuesArray[count, 1] = y11;
                PrintText(x11, -0.8, Convert.ToString((double)x11));

                PrintText(-0.8, y11, Convert.ToString((double)y11));

               
                tempDraw++;
                count++;

                
                if (d < dx)
                {
                    x11 += 1;
                    d += dy << 1;

                }
                else
                {
                    y11 += 1;
                    d = d - (dx << 1);

                }
                Pixel(x11, y11, 1);
            }

           
           // Pixel(x11,y11,1);
            ValuesArray[count, 0] = x11;
            ValuesArray[count, 1] = y11;
            PrintText(x11, -0.8, Convert.ToString((double)x11));

            PrintText(-0.8, y11, Convert.ToString((double)y11));


            tempDraw++;
            count++;
            Pixel(x11, y11, 1);
            prov++;

        }// для построения в первой четверти 4
        private void Brezenhem4(int x11, int y11, int x22, int y22)
        {
            tempDraw = 0;
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
            TextData1.AppendText("Координаты вычисленных пикселей:\n");
            if (k <= 1)
            {
                int d = (dy << 1) - dx;
                for (int i = 1; i <= dx+dy; i++)
                {
                    GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
                //    Pixel(x11,y11,1);
                    PrintText(x11, -0.8, Convert.ToString((double)x11));

                    PrintText(-0.8, y11, Convert.ToString((double)y11));

                          ValuesArray[count, 0] = x11;
                          ValuesArray[count, 1] = y11;

                          tempDraw++;
                          count++;
                        
                          if (d <dx)
                          {
                              x11 += sx;
                              d += dy << 1;
                              
                          }
                          else
                          {
                              y11 +=  sy;
                              d = d - (dx << 1);
                              
                          }
                          Pixel(x11, y11, 1);
                }
              //  Pixel(x11,y11,1);

                ValuesArray[count, 0] = x11;
                ValuesArray[count, 1] = y11;
                PrintText(x11, -0.8, Convert.ToString((double)x11));

                PrintText(-0.8, y11, Convert.ToString((double)y11));


                tempDraw++;
                count++;
                Pixel(x11, y11, 1);
                prov++;

            }
            else
            {
                int z = dx;
                dx = dy;
                dy = z;
                int d = (dy << 1) - dx;
                for (int i = 1; i <= dx+dy; i++)
                {
                    GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
                  //  Pixel(x11, y11,1);
                    PrintText(x11, -0.8, Convert.ToString((double)x11));

                    PrintText(-0.8, y11, Convert.ToString((double)y11));

                    ValuesArray[count, 0] = x11;
                    ValuesArray[count, 1] = y11;
                    count++;
                    tempDraw++;
                    if (d < dx)
                    {
                        y11 += sy;
                        d += dy << 1 ;
                       
                    }
                    else
                    {
                        x11 += sx;
                        d = d - (dx << 1);

                    }
                    Pixel(x11, y11, 1);
                }
             //   Pixel(x11, y11,1);
                ValuesArray[count, 0] = x11;
                ValuesArray[count, 1] = y11;
                PrintText(x11, -0.8, Convert.ToString((double)x11));

                PrintText(-0.8, y11, Convert.ToString((double)y11));


                tempDraw++;
                count++;
                Pixel(x11, y11, 1);
                prov++;
            }

        }
        private void CDA8(double x11, double y11, double x22, double y22)
        {
            tempDraw = 0;
            ValuesArray = null;
            int len = Math.Abs((int)x22 - (int)x11) ;
            int count = 0;
            ValuesArray = new double[len+2, 2];
            double saveX1 = x11;
            double saveY1 = y11;
            double saveX2 = x22;
            double saveY2 = y22;
            int sx, sy;
            if (x22 >= x11)
            {
                sx = 1;
            }
            else {
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
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
          //  Pixel(saveX1,saveY1,1);
            ValuesArray[count, 0] = saveX1;
            ValuesArray[count, 1] = saveY1;
            count++;
            tempDraw++;
            Pixel(saveX1, saveY1, 1);
            double k = (y22 - y11) / (x22 - x11);

            if (k > 1)
            {
                double temp=x11;
                x11 = y11;
                y11 = temp;
                temp = x22;
                x22 = y22;
                y22 = temp;
                temp = sx;
                sx = sy;
               
            }
                    while (x11 < x22)
                    {
                        x11=x11+sx;
                        y11 = Math.Round(y11 + k);
                      //  Pixel(x11,y11,1);
                        tempDraw++;
                        ValuesArray[count, 0] = x11;
                        ValuesArray[count, 1] = y11;
                        count++;
                        Pixel(x11, y11, 1);
                    }


                    prov++;
        } //исправить ошибки
        
        private void VU8(int x11, int y11, int x22, int y22)
        {

            tempDraw = 0;
            ValuesArray = null;
            LineKoord = null;
            intensiv = null;
            int len = Math.Abs(x1 - x2 - 1);
            ValuesArray = new double[2*len, 2];
            LineKoord = new double[2*len, 2];
            intensiv = new double[2 * len];
            int count = 0;
            int cnt1 = 0;
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

                    double intens = Math.Abs((double)y11 - LineKoord[0, 1]); // разница между ординатой идеальной линии и пикселем растровой
                    cnt1++;
                   
                        if (intens == 0)
                        {
                            
                         //   Pixel(x11,y11,1);
                            intensiv[count] = 1;
                            ValuesArray[count, 0] = x11;
                            ValuesArray[count, 1] = y11;
                            count++;
                            tempDraw++;
                            PixelVu(x11, y11, 1);
                        }
                       if (intens != 0)
                       {
                        //   Pixel(x11,y11,intens);
                           intensiv[count] = intens;
                           ValuesArray[count, 0] = x11;
                           ValuesArray[count, 1] = y11;
                           count++;
                           tempDraw++;
                           PixelVu(x11, y11, intens);

                         //  Pixel(x11,y11+1,1-intens);
                           intensiv[count] = 1 - intens;
                           ValuesArray[count, 0] = x11;
                           ValuesArray[count, 1] = y11 + 1;
                           count++;
                           tempDraw++;
                           PixelVu(x11, y11 + 1, 1 - intens);
                       }
                      
                   
                    for (int x = x11 + sx, y = y11, i = 1; i <= dx; i++, x += sx)
                    {
                        if (d > 0)
                        {
                            d += d2;
                            y += sy;
                        }
                        else
                            d += d1;

                        intens = Math.Abs((double)y - LineKoord[cnt1, 1]); // разница между ординатой идеальной линии и пикселем растровой
                        cnt1++;
                        if (intens == 0)
                        {
                          //  Pixel(x,y,1);
                            intensiv[count] = 1;
                            ValuesArray[count, 0] = x;
                            ValuesArray[count, 1] = y;
                            count++;
                            tempDraw++;
                            PixelVu(x, y, 1);
                        }
                        if (intens != 0)
                        {
                           // Pixel(x,y,intens);
                            intensiv[count] =  intens;
                            ValuesArray[count, 0] = x;
                            ValuesArray[count, 1] = y;
                            count++;
                            tempDraw++;
                            PixelVu(x, y, intens);

                            //Pixel(x,y+1,1-intens);
                            intensiv[count] = 1 - intens;
                            ValuesArray[count, 0] = x;
                            ValuesArray[count, 1] = y + 1;
                            count++;
                            tempDraw++;
                            PixelVu(x, y + 1, 1 - intens);
                        }
                   
                    }

                }
                else //основная ось y
                {
                    int d = (dx << 2) - dy;
                    int d1 = dx << 1;
                    int d2 = (dx - dy) << 1;


                    double intens = Math.Abs((double)y11 - LineKoord[0, 1]); // разница между ординатой идеальной линии и пикселем растровой
                    cnt1++;
                    if (intens == 0)
                    {
                       // Pixel(x11,y11,1);
                        intensiv[count] = 1;
                        ValuesArray[count, 0] = x11;
                        ValuesArray[count, 1] = y11;
                        count++;
                        tempDraw++;
                        PixelVu(x11, y11, 1);
                    }
                    if (intens != 0)
                    {
                      //  Pixel(x11,y11,intens);
                        intensiv[count] = intens;
                        ValuesArray[count, 0] = x11;
                        ValuesArray[count, 1] = y11 ;
                        count++;
                        tempDraw++;
                        PixelVu(x11, y11, intens);

                     //   Pixel(x11 + 1, y11, 1 - intens);
                        intensiv[count] = 1 - intens;
                        ValuesArray[count, 0] = x11+1;
                        ValuesArray[count, 1] = y11 ;
                        count++;
                        tempDraw++;
                        PixelVu(x11 + 1, y11, 1 - intens);
                    }

                    for (int x = x11, y = y11 + sy, i = 1; i <= dy; i++, y += sy)
                    {
                        if (d > 0)
                        {
                            d += d2;
                            x += sx;
                        }
                        else
                            d += d1;

                        intens = Math.Abs((double)y - LineKoord[cnt1, 1]);
                        cnt1++;
                        if (intens == 0)
                        {
                          //  Pixel(x,y,1);
                            intensiv[count] = 1;
                            ValuesArray[count, 0] = x;
                            ValuesArray[count, 1] = y;
                            count++;
                            tempDraw++;
                            cnt1++;
                            PixelVu(x, y, 1);
                        }
                        if (intens != 0)
                        {
                          //  Pixel(x,y,intens);
                            intensiv[count] = intens;
                            ValuesArray[count, 0] = x;
                            ValuesArray[count, 1] = y;
                            count++;
                            tempDraw++;
                            PixelVu(x, y, intens);

                            //Pixel(x + 1, y, 1 - intens);
                            intensiv[count] = 1 - intens;
                            ValuesArray[count, 0] = x+1;
                            ValuesArray[count, 1] = y;
                            count++;
                            tempDraw++;
                            PixelVu(x + 1, y, 1 - intens);
                        }


                    }

                }

            }
            else
            {
                if ((x1 == 0) && (x2 == 0))
                {
                    for (int y = y1; y <= y2; y++)
                    {
                     //   Pixel(x1, y, 1);
                        ValuesArray[count, 0] = x1;
                        ValuesArray[count, 1] = y;
                        count++;
                        tempDraw++;
                        PixelVu(x1, y, 1);
                    }
                }

                if ((y1 == 0) && (y2 == 0))
                {
                    for (int x = x1; x <= x2; x++)
                    {
                     //   Pixel(x,y1,1);
                        ValuesArray[count, 0] = x;
                        ValuesArray[count, 1] = y1;
                        count++;
                        tempDraw++;
                        PixelVu(x, y1, 1);
                    }
                }

            }


            prov++;
        }
        private void CircleB(int x11, int y11, int r) 
        {
           
            int count = 0;
            ValuesArray = null;
            tempDraw = 0;
            int x = 0;
            int y = r;
            int d = 3 - 2 * r;
            int len = Math.Abs(500);

            ValuesArray = new double[len, 2];
            TextData1.Text = "Задана окружность:( " + Convert.ToString(x1) + "; " + Convert.ToString(y1) + ")"  + ", радиусом "+ Convert.ToString(r)+"\n";
            TextData1.AppendText("Координаты вычисленных пикселей:\n");
            while (y >= x)
            {
                GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
               
             //   Pixel(x+x11, y+y11, 1);
                ValuesArray[count, 0] = x + x11;
                ValuesArray[count, 1] = y + y11;
                tempDraw++;
                count++;
                Pixel(x + x11, y + y11, 1);
                
            //  Pixel(x + x11, -y + y11, 1);
                ValuesArray[count, 0] = x + x11;
                ValuesArray[count, 1] = -y + y11;
                tempDraw++;
                count++;
                Pixel(x + x11, -y + y11, 1);
              
              // Pixel(-x + x11, y + y11, 1);
                ValuesArray[count, 0] = -x + x11;
                ValuesArray[count, 1] = y + y11;
                tempDraw++;
                count++;
                Pixel(-x + x11, y + y11, 1);

               // Pixel(-x + x11, -y + y11, 1);
                ValuesArray[count, 0] = -x + x11;
                ValuesArray[count, 1] = -y + y11;
                tempDraw++;
                count++;
                Pixel(-x + x11, -y + y11, 1);

               // Pixel(y + x11, x + y11, 1);
                ValuesArray[count, 0] = y + x11;
                ValuesArray[count, 1] = x + y11;
                tempDraw++;
                count++;
                Pixel(y + x11, x + y11, 1);

              //  Pixel(y + x11, -x + y11, 1);
                ValuesArray[count, 0] = y + x11;
                ValuesArray[count, 1] = -x + y11;
                tempDraw++;
                count++;
                Pixel(y + x11, -x + y11, 1);

              //  Pixel(-y + x11, x + y11, 1);
                ValuesArray[count, 0] = -y + x11;
                ValuesArray[count, 1] = x + y11;
                tempDraw++;
                count++;
                Pixel(-y + x11, x + y11, 1);

              //  Pixel(-y + x11, -x + y11, 1);
                
                ValuesArray[count, 0] = -y + x11;
                ValuesArray[count, 1] = -x + y11;
                tempDraw++;
                count++;
                Pixel(-y + x11, -x + y11, 1);

                if (d < 0)
                {
                    d = d + 4 * x + 6;
                }
                else 
                {
                    d = d + 4 * (x - y) + 10;
                        y--;
                }
                x++;
            }
            glControl1.SwapBuffers();
            glControl1.SwapBuffers();
            prov++;
        }
      
        private void ElB(double x11, double y11, double a, double b)
        {
            int count = 0;

            ValuesArray = null;
            tempDraw = 0;
            double srPx, srPy;
            double isX = 0; double isY = b;
            double d=0;
            int len = Math.Abs(500);
            ValuesArray = new double[len, 2];
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

           // Pixel(isX+x11, isY+y11, 1);
            ValuesArray[count, 0] = isX+x11;
            ValuesArray[count, 1] = isY+y11;
            tempDraw++;
            count++;
            Pixel(isX + x11, isY + y11, 1);

           // Pixel(isX+x11, -isY+y11, 1);
            ValuesArray[count, 0] = isX+x11;
            ValuesArray[count, 1] = -isY+y11;
            tempDraw++;
            count++;
            Pixel(isX + x11, -isY + y11, 1);

            int p = 0;
            for (int xx = 0; xx < a; xx++)
            {
                if (((2 * b * b * xx)/(2 * a * a * isY))>-1)
              {
                    srPx = xx + 1;
                    srPy = isY - 0.5;
               }
                else
                {
                    srPx = xx + 0.5;
                    srPy = isY - 1;
               }
              
                if (p == 0)
                {
                    d = b * b * srPx * srPx + a * a * srPy * srPy - a * a * b * b;
                    p++;
                }
                    if (d < 0)
                    {
                        isX = xx + 1;
                      
                        d = d + b * b * (2 * xx + 3);
                    }
                    else
                    {
                         isX = xx + 1;
                        isY = isY-1;
                        d = d + b * b * (2 * xx + 3)+a*a*(2-2*isY);
                    }

               //     GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

                 //   Pixel(isX+x11, isY+y11, 1);
                    ValuesArray[count, 0] = isX+x11;
                    ValuesArray[count, 1] = isY+y11;
                    tempDraw++;
                    count++;
                    Pixel(isX + x11, isY + y11, 1);

                  //  Pixel(isX+x11, -isY+y11, 1);
                    ValuesArray[count, 0] = isX+x11;
                    ValuesArray[count, 1] = -isY+y11;
                    tempDraw++;
                    count++;
                    Pixel(isX + x11, -isY + y11, 1);

                 //   Pixel(-isX+x11, -isY+y11, 1);
                    ValuesArray[count, 0] = -isX+x11;
                    ValuesArray[count, 1] = -isY+y11;
                    tempDraw++;
                    count++;
                    Pixel(-isX + x11, -isY + y11, 1);

                 //   Pixel(-isX+x11, isY+y11, 1);
                    ValuesArray[count, 0] = -isX+x11;
                    ValuesArray[count, 1] = isY+y11;
                    tempDraw++;
                    count++;
                    Pixel(-isX + x11, isY + y11, 1);
              
            }
          //  GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

         //   Pixel(a+x11, 0+y11, 1);
            ValuesArray[count, 0] = a+x11;
            ValuesArray[count, 1] = 0+y11;
            tempDraw++;
            count++;
            Pixel(a + x11, 0 + y11, 1);

           // Pixel(-a+x11, 0+y11, 1);
            ValuesArray[count, 0] = -a+x11;
            ValuesArray[count, 1] = 0+y11;
            tempDraw++;
            count++;
            Pixel(-a + x11, 0 + y11, 1);

            glControl1.SwapBuffers();
            glControl1.SwapBuffers();
            prov++;

            glControl1.SwapBuffers();
            glControl1.SwapBuffers();
            prov++;


        }
        private void ReadTextBoxLine()
        {
            int temp; double temp1;
            string inputx1 = textBoxX1.Text;
            string inputx2 = textBoxX2.Text;
            string inputy1 = textBoxY1.Text;
            string inputy2 = textBoxY2.Text;
            try
            {
                if ((брезенхемДляОтрезкаToolStripMenuItem.Checked) || (вуToolStripMenuItem.Checked))
                {
                    x1 = Convert.ToInt32(inputx1);
                    y1 = Convert.ToInt32(inputy1);
                    x2 = Convert.ToInt32(inputx2);
                    y2 = Convert.ToInt32(inputy2);
                    if (y2<y1)
                    {
                         temp = x2;
                        x2 = x1;
                        x1 = temp;
                        temp = y2;
                        y2 = y1;
                        y1 = temp;
                    }
                   
                }
                else {
                 
                    x1d = double.Parse(inputx1.Replace(".", ","));
                    x2d = double.Parse(inputx2.Replace(".", ","));
                    y1d = double.Parse(inputy1.Replace(".", ","));
                    y2d = double.Parse(inputy2.Replace(".", ","));

                    if (y2d<y1d)
                    {
                        temp1 = x2d;
                        x2d = x1d;
                        x1d = temp1;
                        temp1 = y2d;
                        y2d = y1d;
                        y1d = temp1;
                    }
                   
                }

            }
            catch
            {
                TextData1.Clear();
                TextData1.Text = "Ошибка при вводе значений.";
                x1 = 0; y1 = 0; x2 = 0; y2 = 0;
                x2d = 0; x1d = 0; y1d = 0; y2d = 0;
                return;
            }
        }
       
        private void Form1_Load(object sender, EventArgs e)
        {
            GL.Enable(EnableCap.Blend);
            GL.BlendFunc(BlendingFactorSrc.SrcAlpha, BlendingFactorDest.OneMinusSrcAlpha);
            groupBox1.Controls.Add(urav);
            groupBox1.Controls.Add(chetv);
            groupBox1.Controls.Add(resh);
            groupBox1.Controls.Add(urav);
            groupBox2.Controls.Add(ob8);
            groupBox2.Controls.Add(resur8);
            groupBox2.Controls.Add(chet8);

        }
        private void Pereris(int x11, int x22, double a, double b) // для корректного отображения рисунка после изменения размеров окна
        {
           
            GL.Color3(1.0f, 1.0f, 1.0f);
            GL.Color3(0.0f, 0.0f, 1.0f);
            
                for (int j = 0; j < tempDraw; j++)
                {
                     if (вуToolStripMenuItem.Checked == false)
                     {
                    GL.Color3(0.0f, 0.0f, 1.0f);
                     }
                     else
                     {
                          GL.Color4(0.0f, 0.0f,1.0f, intensiv[j]);
                     }
                    GL.Begin(PrimitiveType.QuadStrip);

                    GL.Vertex2((double)ValuesArray[j, 0] - 0.5, ValuesArray[j, 1] - 0.5);
                    GL.Vertex2((double)ValuesArray[j, 0] + 0.5, ValuesArray[j, 1] - 0.5);
                    GL.Vertex2((double)ValuesArray[j, 0] - 0.5, ValuesArray[j, 1] + 0.5);
                    GL.Vertex2((double)ValuesArray[j, 0] + 0.5, ValuesArray[j, 1] + 0.5);

                    GL.End();
                    if (!окружностьToolStripMenuItem.Checked)
                    {
                        PrintText((double)ValuesArray[j, 0], -0.8, Convert.ToString((double)ValuesArray[j, 0]));

                        PrintText(-0.8, (double)ValuesArray[j, 1], Convert.ToString((double)ValuesArray[j, 1]));
                    }
                }
            
           

            
            if ((брезенхемДляОтрезкаToolStripMenuItem.Checked)||(вуToolStripMenuItem.Checked)||(цДАToolStripMenuItem.Checked))
            {
            baseEl(x1, y1, x2, y2);
            }
        }
    /*    private void drawPixel(int x11,int x22, double a, double b)
        {
            try
            {

                GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
                if ((эллипсToolStripMenuItem.Checked == true) || (окружностьToolStripMenuItem.Checked == true))
                {
                    if ((ValuesArray[num, 0] <= x1+a))
                    {
                        GL.Color3(1.0f, 1.0f, 1.0f);

                        GL.Color3(0.0f, 0.0f, 1.0f);
                        GL.Begin(PrimitiveType.QuadStrip);

                        GL.Vertex2((double)ValuesArray[num, 0] - 0.5, ValuesArray[num, 1] - 0.5);
                        GL.Vertex2((double)ValuesArray[num, 0] + 0.5, ValuesArray[num, 1] - 0.5);
                        GL.Vertex2((double)ValuesArray[num, 0] - 0.5, ValuesArray[num, 1] + 0.5);
                        GL.Vertex2((double)ValuesArray[num, 0] + 0.5, ValuesArray[num, 1] + 0.5);

                        GL.End();
                        TextData1.AppendText("(" + Convert.ToString((double)ValuesArray[num, 0]) + "; " + Convert.ToString((double)ValuesArray[num, 1]) + ")\n");
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
                        if ((ValuesArray[num, 0] == x1+a)&&(ValuesArray[num,1]<0))
                        {
                            GL.Color3(0.0f, 0.0f, 1.0f);

                            GL.Begin(PrimitiveType.QuadStrip);

                            GL.Vertex2((double)ValuesArray[num, 0] - 0.5, ValuesArray[num, 1] - 0.5);
                            GL.Vertex2((double)ValuesArray[num, 0] + 0.5, ValuesArray[num, 1] - 0.5);
                            GL.Vertex2((double)ValuesArray[num, 0] - 0.5, ValuesArray[num, 1] + 0.5);
                            GL.Vertex2((double)ValuesArray[num, 0] + 0.5, ValuesArray[num, 1] + 0.5);

                            GL.End();
                         //   tempDraw = 0;
                            num = 0;
                            timer1.Stop();
                            prov++;
                        }
                     
                        else
                        {

                            num++;
                        }
                    }
                    else {
 
                    }


                }
                else
                {
                    if (ValuesArray[num, 0] <= x22)
                    {
                        if (вуToolStripMenuItem.Checked == false)
                        {
                            GL.Color3(1.0f, 1.0f, 1.0f);
                              PrintText((double)ValuesArray[num, 0], -0.8, Convert.ToString((double)ValuesArray[num, 0]));

                              PrintText(-0.8, (double)ValuesArray[num, 1], Convert.ToString((double)ValuesArray[num, 1]));
                            GL.Color3(0.0f, 0.0f, 1.0f);
                        }
                        else
                        {
                            GL.Color4(1.0f, 1.0, 1.0f, 1.0f);
                            GL.Color4(0.0f, 0.0f, 1.0f, intensiv[num]);

                        }
                        
                        GL.Begin(PrimitiveType.QuadStrip);

                        GL.Vertex2((double)ValuesArray[num, 0] - 0.5, ValuesArray[num, 1] - 0.5);
                        GL.Vertex2((double)ValuesArray[num, 0] + 0.5, ValuesArray[num, 1] - 0.5);
                        GL.Vertex2((double)ValuesArray[num, 0] - 0.5, ValuesArray[num, 1] + 0.5);
                        GL.Vertex2((double)ValuesArray[num, 0] + 0.5, ValuesArray[num, 1] + 0.5);

                        GL.End();
                        TextData1.AppendText("(" + Convert.ToString((double)ValuesArray[num, 0]) + "; " + Convert.ToString((double)ValuesArray[num, 1]) + ")\n");
                        tempDraw++;
                        if (вуToolStripMenuItem.Checked == false)
                        {
                            for (int j = 0; j < tempDraw; j++)
                            {

                                GL.Color3(0.0f, 0.0f, 1.0f);

                                GL.Begin(PrimitiveType.QuadStrip);

                                GL.Vertex2((double)ValuesArray[j, 0] - 0.5, ValuesArray[j, 1] - 0.5);
                                GL.Vertex2((double)ValuesArray[j, 0] + 0.5, ValuesArray[j, 1] - 0.5);
                                GL.Vertex2((double)ValuesArray[j, 0] - 0.5, ValuesArray[j, 1] + 0.5);
                                GL.Vertex2((double)ValuesArray[j, 0] + 0.5, ValuesArray[j, 1] + 0.5);

                                GL.End();
                                PrintText((double)ValuesArray[j, 0], -0.8, Convert.ToString((double)ValuesArray[j, 0]));

                                PrintText(-0.8, (double)ValuesArray[j, 1], Convert.ToString((double)ValuesArray[j, 1]));
                            }
                        }
                        else
                        {

                            for (int j = 0; j < tempDraw; j++)
                            {

                                GL.Color3(0.0f, 0.0f, intensiv[j]);

                                GL.Begin(PrimitiveType.QuadStrip);

                                GL.Vertex2((double)ValuesArray[j, 0] - 0.5, ValuesArray[j, 1] - 0.5);
                                GL.Vertex2((double)ValuesArray[j, 0] + 0.5, ValuesArray[j, 1] - 0.5);
                                GL.Vertex2((double)ValuesArray[j, 0] - 0.5, ValuesArray[j, 1] + 0.5);
                                GL.Vertex2((double)ValuesArray[j, 0] + 0.5, ValuesArray[j, 1] + 0.5);

                                GL.End();
                                PrintText((double)ValuesArray[j, 0], -0.8, Convert.ToString((double)ValuesArray[j, 0]));

                                PrintText(-0.8, (double)ValuesArray[j, 1], Convert.ToString((double)ValuesArray[j, 1]));
                            }

                        }


                        if (ValuesArray[num, 0] == x22)
                        {
                        //    tempDraw = 0;
                            num = 0;
                            timer1.Stop();
                            prov++;
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
                }
                setka();
                baseEl(x1,y1,x2,y2);
                glControl1.SwapBuffers();
            }
            catch (Exception)
            {
        TextData1.Clear();
        TextData1.Text = "Ошибка";
            }
        }*/
        private void Draw()
        {
         //   ObResB(1, 1, 7, 10);
           // prov = 0;
                prov = 0;
            TextData1.Clear();
            TextData1.Text = "Задана прямая:( " + Convert.ToString(x1) + "; " + Convert.ToString(y1) + ") и (" + Convert.ToString(x2) + ", " + Convert.ToString(y2) + ")\n";
            TextData1.AppendText("Координаты вычисленных пикселей:\n");
            try
            {

               
                if (брезенхемДляОтрезкаToolStripMenuItem.Checked)
                {
                    ReadTextBoxLine();
                    if ((x1 != 0) || (y1 != 0) || (x2 != 0) || (y2 != 0))
                    {

                        if (urav.Checked)
                        {

                            ObRes4B(x1, y1, x2, y2);

                        }
                        if (chetv.Checked)
                        {
                            if ((x1 >= 0) && (x2 >= 0) && (y1 >= 0) && (y2 >= 0))
                            {
                                PervChet4B(x1, y1, x2, y2);
                            }
                            else {
                                TextData1.Clear();
                                TextData1.Text = "Данный метод только для первой четверти, проверьте значения координат. ";
 
                            }
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
                            if ((x1 >= 0) && (x2 >= 0) && (y1 >= 0) && (y2 >= 0))
                            {
                                PervChetB(x1, y1, x2, y2);
                            }
                            else
                            {
                                TextData1.Clear();
                                TextData1.Text = "Данный метод только для первой четверти, проверьте значения координат. ";

                            }

                        }
                        if (resur8.Checked)
                        {

                            ObResB(x1, y1, x2, y2);
                        }
                    }
                    
                }
                if (цДАToolStripMenuItem.Checked)
                {
                    ReadTextBoxLine();
                    if ((x1d != 0) || (y1d != 0) || (x2d != 0) || (y2d != 0))
                    {
                        if (ob8.Checked)
                        {
                            CDA8(x1d, y1d, x2d, y2d);
                        }

                    }
                }
                if (вуToolStripMenuItem.Checked)
                {
                    ReadTextBoxLine();
                    if ((x1 != 0) || (y1 != 0) || (x2 != 0) || (y2 != 0))
                    {
                        if (ob8.Checked)
                        {
                            VU8(x1, y1, x2, y2);
                        }
                    }
                }
                if (эллипсToolStripMenuItem.Checked)
                {
                    
                    if (ob8.Checked)
                    {
                        ElB(2,-2, 6, 4);
                    }
                
                   

                }
                if (окружностьToolStripMenuItem.Checked)
                {
                    CircleB(x1,y1,r);
                }
            }
            catch (Exception)
            {
                TextData1.Clear();
                TextData1.Text = "Ошибка";
            }
        }
        
     /*   private void timer1_Tick(object sender, EventArgs e)
        {
            drawPixel(x1,x2,a,b);
            
        }
        */
            
        
        private void button2_Click(object sender, EventArgs e)
        {
          
            while (Exit==false) 
            {
                Application.DoEvents();
         
            }
            Exit = false;
            
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


            Glu.gluOrtho2D(0.0, (Sinhr.point / 2), 0.0, (Sinhr.point / 2)); //Подредактировать сетку
           
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();

            GL.Translate(10, 10, 0);
            
          
            if ((prov > 0)&& (timer1.Enabled==false))
            {
                Pereris(x1,x2,a,b);
            }
       
          
            setka();
           
          

          baseEl(x1, y1, x2, y2);
          
         
          glControl1.SwapBuffers();

        }
        private void baseEl(int x1,int y1,int x2,int y2)
        {
            if ((брезенхемДляОтрезкаToolStripMenuItem.Checked) || (цДАToolStripMenuItem.Checked) || (вуToolStripMenuItem.Checked))
            {
                GL.Color3(1.0f, 0.0f, 0.0f);
            }
            else {
                GL.Color4(0.0f, 0.0f, 0.0f,0.0f);
            }

            GL.LineWidth(30);
            GL.Begin(PrimitiveType.Lines);
        
            GL.Vertex2(x1, y1);
            GL.Vertex2(x2, y2);
            GL.End();
            GL.Color3(255, 255, 255);

            GL.Color3(0, 0, 255);
            
        }
        
        private void glControl1_Load(object sender, EventArgs e)
        {
            loaded = true;
            GL.ClearColor(Color.Black);
            TextData1.Text = "Задана прямая:( " + Convert.ToString(x1) + "; " + Convert.ToString(y1) + ") и (" + Convert.ToString(x2) + ", " + Convert.ToString(y2)+")\n";
            TextData1.AppendText("Координаты вычисленных пикселей:\n");
            GL.Enable(EnableCap.Blend);
            GL.BlendFunc(BlendingFactorSrc.SrcAlpha, BlendingFactorDest.OneMinusSrcAlpha);
            
        }

        private void брензенхемДляОтрезкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            prov = 0;
            брезенхемДляОтрезкаToolStripMenuItem.Checked = true;
            цДАToolStripMenuItem.Checked = false;
            вуToolStripMenuItem.Checked = false;
            эллипсToolStripMenuItem.Checked = false;
            окружностьToolStripMenuItem.Checked = false;
            chet8.Checked = false;  chet8.Enabled = true;
            chetv.Checked = false;  chetv.Enabled = true;
            urav.Checked = false;   urav.Enabled = true;
            resur8.Checked = false; resur8.Enabled = true;
            ob8.Checked = true;
            resh.Checked = true;
            ob8.Text = "Общее решение";
            resh.Text = "Общее решение";
           GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            baseEl(x1, y1, x2, y2);
            setka();
            glControl1.SwapBuffers();
        }

        private void цДАToolStripMenuItem_Click(object sender, EventArgs e)
        {
            prov = 0;
            брезенхемДляОтрезкаToolStripMenuItem.Checked = false;
            цДАToolStripMenuItem.Checked = true;
            вуToolStripMenuItem.Checked = false;
            эллипсToolStripMenuItem.Checked = false;
            окружностьToolStripMenuItem.Checked = false;
            chet8.Checked = false;   chet8.Enabled = false;
            chetv.Checked = false;   chetv.Enabled = false;
            urav.Checked = false;    urav.Enabled = false;
            resur8.Checked = false;  resur8.Enabled = false;
            ob8.Checked = true;  ob8.Enabled = true;
            resh.Checked = false;  resh.Enabled = false;
            ob8.Text = "Общее решение";
            resh.Text = "Общее решение";
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            baseEl(x1, y1, x2, y2);
            setka();
            glControl1.SwapBuffers();
        }

        private void вуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            prov = 0;
            брезенхемДляОтрезкаToolStripMenuItem.Checked = false;
            цДАToolStripMenuItem.Checked = false;
            вуToolStripMenuItem.Checked = true;
            эллипсToolStripMenuItem.Checked = false;
            окружностьToolStripMenuItem.Checked = false;

            chet8.Checked = false; chet8.Enabled = false;
            chetv.Checked = false; chetv.Enabled = false;
            urav.Checked = false; urav.Enabled = false;
            resur8.Checked = false; resur8.Enabled = false;
            ob8.Checked = true; ob8.Enabled = true;
            resh.Checked = false; resh.Enabled = false;
            ob8.Text = "Общее решение";
            resh.Text = "Общее решение";
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            baseEl(x1, y1, x2, y2);
            setka();
            glControl1.SwapBuffers();
        }

        private void эллипсToolStripMenuItem_Click(object sender, EventArgs e)
        {
            prov = 0;
            брезенхемДляОтрезкаToolStripMenuItem.Checked = false;
            цДАToolStripMenuItem.Checked = false;
            вуToolStripMenuItem.Checked = false;
            эллипсToolStripMenuItem.Checked = true;
            окружностьToolStripMenuItem.Checked = false;

            chet8.Checked = false; chet8.Enabled = false;
            chetv.Checked = false; chetv.Enabled = false;
            urav.Checked = false; urav.Enabled = false;
            resur8.Checked = false; resur8.Enabled = false;
            ob8.Checked = true; ob8.Enabled = true;
            resh.Checked = false; resh.Enabled = false;
            ob8.Text = "Алгоритм средней точки";
            resh.Text = "Алгоритм средней точки";
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            baseEl(x1, y1, x2, y2);
            setka();
            glControl1.SwapBuffers();
           
        }

        private void окружностьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            prov = 0;
            брезенхемДляОтрезкаToolStripMenuItem.Checked = false;
            цДАToolStripMenuItem.Checked = false;
            вуToolStripMenuItem.Checked = false;
            эллипсToolStripMenuItem.Checked = false;
            окружностьToolStripMenuItem.Checked = true;
            chet8.Checked = false; chet8.Enabled = false;
            chetv.Checked = false; chetv.Enabled = false;
            urav.Checked = false; urav.Enabled = false;
            resur8.Checked = false; resur8.Enabled = false;
            ob8.Checked = true; ob8.Enabled = true;
            resh.Checked = false; resh.Enabled = false;
            ob8.Text = "Алгоритм средней точки";
            resh.Text = "Алгоритм средней точки";
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            baseEl(x1, y1, x2, y2);
            setka();
            glControl1.SwapBuffers();
        }

        private void resur8_CheckedChanged(object sender, EventArgs e)
        {
            resh.Checked = false;
            urav.Checked = false;
            chetv.Checked = false;
        }

        private void chet8_CheckedChanged(object sender, EventArgs e)
        {
            resh.Checked = false;
            urav.Checked = false;
            chetv.Checked = false;
        }

        private void ob8_CheckedChanged(object sender, EventArgs e)
        {
            resh.Checked = false;
            urav.Checked = false;
            chetv.Checked = false;
           
        }

        private void urav_CheckedChanged(object sender, EventArgs e)
        {
            resur8.Checked = false;
            chet8.Checked = false;
            ob8.Checked = false;
        }

        private void chetv_CheckedChanged(object sender, EventArgs e)
        {
            resur8.Checked = false;
            chet8.Checked = false;
            ob8.Checked = false;
        }

        private void resh_CheckedChanged(object sender, EventArgs e)
        {
            resur8.Checked = false;
            chet8.Checked = false;
            ob8.Checked = false;
           
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
           
            if (checkBox1.Checked == true)
            {
                if (formCode == 0)
                {
                    dataF.Show();
                }
                else {
                    DataAl dataF = new DataAl();
                    dataF.Show();
                }
            }
            else {
               
                dataF.Close();
                formCode++;
            }
        }

        private void VizBrOt_MouseClick(object sender, MouseEventArgs e)
        {
            Exit = true;
        }

     

     

      

        private void справкаToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Программа визуализирует растроыве алгоритмы, а также содержит теоретичский материал по ним.\nДля уравления программой используйте мышь.\nВ окне визуализации Вы можете задать параметры визуализации.",
                "Справка",
                MessageBoxButtons.OK);
        }

        private void оПрограммеToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Программа написана студентом группы КЭ - 484 Козловой Анастасией.",
               "О программе",
               MessageBoxButtons.OK);
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Parametrs f = new Parametrs();
            f.Show();
        }

        
      
       
    }
}
