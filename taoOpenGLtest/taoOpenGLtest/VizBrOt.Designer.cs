namespace taoOpenGLtest
{
    partial class VizBrOt
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.anT = new Tao.Platform.Windows.SimpleOpenGlControl();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // anT
            // 
            this.anT.AccumBits = ((byte)(0));
            this.anT.AutoCheckErrors = false;
            this.anT.AutoFinish = false;
            this.anT.AutoMakeCurrent = true;
            this.anT.AutoSwapBuffers = true;
            this.anT.BackColor = System.Drawing.Color.Black;
            this.anT.ColorBits = ((byte)(32));
            this.anT.DepthBits = ((byte)(16));
            this.anT.Location = new System.Drawing.Point(12, 12);
            this.anT.Name = "anT";
            this.anT.Size = new System.Drawing.Size(618, 370);
            this.anT.StencilBits = ((byte)(0));
            this.anT.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(644, 28);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(91, 39);
            this.button1.TabIndex = 1;
            this.button1.Text = "Визуализация";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(644, 85);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(91, 37);
            this.button2.TabIndex = 2;
            this.button2.Text = "Пауза";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 5000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // VizBrOt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(763, 394);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.anT);
            this.Name = "VizBrOt";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Tao.Platform.Windows.SimpleOpenGlControl anT;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Timer timer1;
    }
}

