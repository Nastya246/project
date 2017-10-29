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
    
    public partial class VizBrOt : Form
    {
      
        private   DataAl D = new DataAl();

        bool loaded = false;
        double[,] ValuesArray;
        double[,] LineKoord;
        double[] intensiv;
        int x1=2, y1=1, x2=8, y2=3;
        int tempDraw = 0;// для анимации 
        int num = 0;
        double a=5, b=3;// для эллипса
        public VizBrOt()
        {
            InitializeComponent();
       
        }
        int prov = 0; // для проверки было ли что-нибудь нарисовано

        private void button1_Click(object sender, EventArgs e)
        {
            
            Draw();
         
                  timer1.Start();
       
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
        //    GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
         //   GL.ClearColor(0.0f, 0.0f, 0.0f, 0.0f);
            Bitmap text_bmp = new Bitmap(glControl1.Width, glControl1.Height);
            Graphics gfx = Graphics.FromImage(text_bmp); //поверхность для рис.
            gfx.Clear(Color.Black);
            Font font = new Font(FontFamily.GenericSerif, 500.0f);
            gfx.DrawString(text, font, Brushes.White, new PointF(30, -170)); 
            //Вытягивание данных из картинки
            BitmapData data = text_bmp.LockBits(new Rectangle(0, 0, text_bmp.Width, text_bmp.Height), ImageLockMode.ReadOnly,System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            GL.Enable(EnableCap.Texture2D);
            GL.GenTextures(1,out texture_text);
           GL.BindTexture(TextureTarget.Texture2D, texture_text);  //Текстура становится текущей
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Linear);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Linear);
            GL.TexEnv(TextureEnvTarget.TextureEnv, TextureEnvParameter.TextureEnvMode, (float)TextureEnvMode.Replace);
           //загрузка картинки в текстуру
            GL.TexImage2D(TextureTarget.Texture2D,0,PixelInternalFormat.Rgba,text_bmp.Width,text_bmp.Height,0,OpenTK.Graphics.OpenGL.PixelFormat.Bgra,PixelType.UnsignedByte, data.Scan0);
            text_bmp.UnlockBits(data);
            GL.Enable(EnableCap.Blend);
            GL.BlendFunc(BlendingFactorSrc.SrcAlpha, BlendingFactorDest.OneMinusSrcAlpha);
            GL.BindTexture(TextureTarget.Texture2D,texture_text);
            GL.Color3(0.0f, 0.0f, 0.0f);
            GL.Begin(PrimitiveType.Quads);

            GL.TexCoord2(0.0f, 1.0f); GL.Vertex2(x, y);
            GL.TexCoord2(1.0f, 1.0f); GL.Vertex2(x + 0.5f, y);
            GL.TexCoord2(1.0f, 0.0f); GL.Vertex2(x + 0.5f, y + 0.5f);
            GL.TexCoord2(0.0f, 0.0f); GL.Vertex2(x, y + 0.5f);
            GL.End();
        }
        private void setka(int x11,int y11, int x22, int y22)
        {

           
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
           
            GL.Color3(0, 0, 255);
        //    PrintText(14.3, 0.5, "x");
        //    PrintText(0.5, 14.5, "y");
        }
        private void ObResB(int x11, int y11, int x22, int y22 ) // построение линии по уравнению 8
        {
            ValuesArray = null;
            tempDraw = 0;
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
                        ValuesArray[count, 0] = i;
                        ValuesArray[count, 1] = ValuesArray[count - 1, 1];


                        count++;
                    }
                }
                Sinhr.Value = Sinhr.Value + "x = " + Convert.ToString(i) + " " + " y = " + Convert.ToString(temp) + "\n";
                ValuesArray[count, 0] = i;
                ValuesArray[count, 1] = temp;


                count++;

            }
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

            for (int i = 1; i <= dx + dy; i++)
            {

                ValuesArray[count, 0] = x11;
                ValuesArray[count, 1] = y11;
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
            }

            ValuesArray[count, 0] = x11;
            ValuesArray[count, 1] = y11;
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
                              x11 += sx;
                              d += dy << 1;
                              
                          }
                          else
                          {
                              y11 +=  sy;
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
                        y11 += sy;
                        d += dy << 1 ;
                       
                    }
                    else
                    {
                        x11 += sx;
                        d = d - (dx << 1);

                    }
                }
                ValuesArray[count, 0] = x11;
                ValuesArray[count, 1] = y11;

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

            ValuesArray[count, 0] = saveX1;
            ValuesArray[count, 1] = saveY1;
            count++;
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
                        ValuesArray[count, 0] = x11;
                        ValuesArray[count, 1] = y11;
                        count++;
                    }
                
           
         
        }
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
                            intensiv[count] = 1;
                            ValuesArray[count, 0] = x11;
                            ValuesArray[count, 1] = y11;
                            count++;
                        }
                       if (intens != 0)
                       {
                           intensiv[count] = intens;
                           ValuesArray[count, 0] = x11;
                           ValuesArray[count, 1] = y11;
                           count++;

                           intensiv[count] = 1 - intens;
                           ValuesArray[count, 0] = x11;
                           ValuesArray[count, 1] = y11 + 1;
                           count++;
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
                            intensiv[count] = 1;
                            ValuesArray[count, 0] = x;
                            ValuesArray[count, 1] = y;
                            count++;
                        }
                        if (intens != 0)
                        {
                            intensiv[count] =  intens;
                            ValuesArray[count, 0] = x;
                            ValuesArray[count, 1] = y;
                            count++;

                            intensiv[count] = 1 - intens;
                            ValuesArray[count, 0] = x;
                            ValuesArray[count, 1] = y + 1;
                            count++;
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
                        intensiv[count] = 1;
                        ValuesArray[count, 0] = x11;
                        ValuesArray[count, 1] = y11;
                        count++;
                    }
                    if (intens != 0)
                    {
                        intensiv[count] = intens;
                        ValuesArray[count, 0] = x11;
                        ValuesArray[count, 1] = y11 ;
                        count++;

                        intensiv[count] = 1 - intens;
                        ValuesArray[count, 0] = x11+1;
                        ValuesArray[count, 1] = y11 ;
                        count++;
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
                            intensiv[count] = 1;
                            ValuesArray[count, 0] = x;
                            ValuesArray[count, 1] = y;
                            count++;
                            cnt1++;
                        }
                        if (intens != 0)
                        {
                            intensiv[count] = intens;
                            ValuesArray[count, 0] = x;
                            ValuesArray[count, 1] = y;
                            count++;

                            intensiv[count] = 1 - intens;
                            ValuesArray[count, 0] = x+1;
                            ValuesArray[count, 1] = y;
                            count++;
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
                      
                        ValuesArray[count, 0] = x1;
                        ValuesArray[count, 1] = y;
                    }
                }

                if ((y1 == 0) && (y2 == 0))
                {
                    for (int x = x1; x <= x2; x++)
                    {
                        ValuesArray[count, 0] = x;
                        ValuesArray[count, 1] = y1;
                    }
                }

            }



        }
        private void ElUr(int x11, int y11, double a, double b)
        {
            tempDraw = 0;
            ValuesArray = null;
            int count = 0;
            double temp = 0;
            ValuesArray = new double[100, 2];
            for (int i = x1-((int)a); i <=x11+ (int)a; i++)
            {

                temp = Math.Abs(Math.Sqrt((a * a * b * b - b * b * (i - x11) * (i - x11)) / (a*a))) + y11;

                //Sinhr.Value = Sinhr.Value + "x = " + Convert.ToString(i) + " " + " y = " + Convert.ToString(temp) + "\n";
                ValuesArray[count, 0] = i;
                ValuesArray[count, 1] = temp;
                count++;
                ValuesArray[count, 0] = i;
                ValuesArray[count, 1] = -temp;

                count++;

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

                GL.Color3(0.0f, 0.0f, 1.0f);

                GL.Begin(PrimitiveType.QuadStrip);

                GL.Vertex2((double)ValuesArray[j, 0] - 0.5, ValuesArray[j, 1] - 0.5);
                GL.Vertex2((double)ValuesArray[j, 0] + 0.5, ValuesArray[j, 1] - 0.5);
                GL.Vertex2((double)ValuesArray[j, 0] - 0.5, ValuesArray[j, 1] + 0.5);
                GL.Vertex2((double)ValuesArray[j, 0] + 0.5, ValuesArray[j, 1] + 0.5);

                GL.End();
            }
        }
        private void drawPixel(int x11,int x22, double a, double b)
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
                            //  PrintText((double)ValuesArray[num, 0], -0.8, Convert.ToString((double)ValuesArray[num, 0]));

                            //  PrintText(-0.8, (double)ValuesArray[num, 1], Convert.ToString((double)ValuesArray[num, 1]));
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
                setka(x1, y1, x2, y2);

                glControl1.SwapBuffers();
            }
            catch (Exception)
            {
        TextData1.Clear();
        TextData1.Text = "Ошибка";
            }
        }
        private void Draw()
        {
            prov = 0;
            TextData1.Clear();
            TextData1.Text = "Задана прямая:( " + Convert.ToString(x1) + "; " + Convert.ToString(y1) + ") и (" + Convert.ToString(x2) + ", " + Convert.ToString(y2) + ")\n";
            TextData1.AppendText("Координаты вычисленных пикселей:\n");
            try
            {
                if (брензенхемДляОтрезкаToolStripMenuItem.Checked)
                {
                    if (urav.Checked)
                    {

                        ObRes4B(x1, y1, x2, y2);

                    }
                    if (chetv.Checked)
                    {

                        PervChet4B(x1, y1, x2, y2);
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

                        PervChetB(x1, y1, x2, y2);
                    }
                    if (resur8.Checked)
                    {

                        ObResB(x1, y1, x2, y2);
                    }

                }
                if (цДАToolStripMenuItem.Checked)
                {

                    if (resh.Checked)
                    {

                    }
                    if (ob8.Checked)
                    {
                        CDA8(x1, y1, x2, y2);
                    }


                }
                if (вуToolStripMenuItem.Checked)
                {
                    if (resh.Checked)
                    {

                    }
                    if (ob8.Checked)
                    {
                        VU8(x1, y1, x2, y2);
                    }
                }
                if (эллипсToolStripMenuItem.Checked)
                {
                    if (urav.Checked)
                    {

                      

                    }
                
                    if (resh.Checked)
                    {

                        
                    }
                    if (ob8.Checked)
                    {

                    }
                
                    if (resur8.Checked)
                    {
                        ElUr(x1, y1, a, b);
                        
                    }

                }
            }
            catch (Exception)
            {
                TextData1.Clear();
                TextData1.Text = "Ошибка";
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            drawPixel(x1,x2,a,b);
            
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
            
          
            if ((prov > 0)&& (timer1.Enabled==false))
            {
                Pereris(x1,x2,a,b);
            }
            setka(x1, y1, x2, y2);
          //  PrintText(14.3, 0.5, "x");
          //  PrintText(0.5, 14.5, "y");
            
       
            glControl1.SwapBuffers();

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
            брензенхемДляОтрезкаToolStripMenuItem.Checked = true;
            цДАToolStripMenuItem.Checked = false;
            вуToolStripMenuItem.Checked = false;
            эллипсToolStripMenuItem.Checked = false;
            окружностьToolStripMenuItem.Checked = false;
            chet8.Checked = false;  chet8.Enabled = true;
            chetv.Checked = false;  chetv.Enabled = true;
            urav.Checked = false;   urav.Enabled = true;
            resur8.Checked = false; resur8.Enabled = true;
            ob8.Checked = true;
            resh.Checked = false;
        }

        private void цДАToolStripMenuItem_Click(object sender, EventArgs e)
        {
            брензенхемДляОтрезкаToolStripMenuItem.Checked = false;
            цДАToolStripMenuItem.Checked = true;
            вуToolStripMenuItem.Checked = false;
            эллипсToolStripMenuItem.Checked = false;
            окружностьToolStripMenuItem.Checked = false;
            chet8.Checked = false;   chet8.Enabled = false;
            chetv.Checked = false;   chetv.Enabled = false;
            urav.Checked = false;    urav.Enabled = false;
            resur8.Checked = false;  resur8.Enabled = false;
            ob8.Checked = true;  ob8.Enabled = true;
            resh.Checked = false;  resh.Enabled = true;
        }

        private void вуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            брензенхемДляОтрезкаToolStripMenuItem.Checked = false;
            цДАToolStripMenuItem.Checked = false;
            вуToolStripMenuItem.Checked = true;
            эллипсToolStripMenuItem.Checked = false;
            окружностьToolStripMenuItem.Checked = false;

            chet8.Checked = false; chet8.Enabled = false;
            chetv.Checked = false; chetv.Enabled = false;
            urav.Checked = false; urav.Enabled = false;
            resur8.Checked = false; resur8.Enabled = false;
            ob8.Checked = true; ob8.Enabled = true;
            resh.Checked = false; resh.Enabled = true;
        }

        private void эллипсToolStripMenuItem_Click(object sender, EventArgs e)
        {
            брензенхемДляОтрезкаToolStripMenuItem.Checked = false;
            цДАToolStripMenuItem.Checked = false;
            вуToolStripMenuItem.Checked = false;
            эллипсToolStripMenuItem.Checked = true;
            окружностьToolStripMenuItem.Checked = false;

            chet8.Checked = false; chet8.Enabled = false;
            chetv.Checked = false; chetv.Enabled = false;
            urav.Checked = false; urav.Enabled = true;
            resur8.Checked = false; resur8.Enabled = true;
            ob8.Checked = true; ob8.Enabled = true;
            resh.Checked = false; resh.Enabled = true;
        }

        private void окружностьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            брензенхемДляОтрезкаToolStripMenuItem.Checked = false;
            цДАToolStripMenuItem.Checked = false;
            вуToolStripMenuItem.Checked = false;
            эллипсToolStripMenuItem.Checked = false;
            окружностьToolStripMenuItem.Checked = true;
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

       
    }
}
