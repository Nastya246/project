﻿namespace taoOpenGLtest
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.urav = new System.Windows.Forms.RadioButton();
            this.chetv = new System.Windows.Forms.RadioButton();
            this.resh = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.glControl1 = new OpenTK.GLControl();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ob8 = new System.Windows.Forms.RadioButton();
            this.resur8 = new System.Windows.Forms.RadioButton();
            this.chet8 = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(762, 291);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(91, 39);
            this.button1.TabIndex = 1;
            this.button1.Text = "Визуализация";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(762, 350);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(91, 37);
            this.button2.TabIndex = 2;
            this.button2.Text = "Пауза";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 2000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // urav
            // 
            this.urav.AutoSize = true;
            this.urav.Location = new System.Drawing.Point(6, 32);
            this.urav.Name = "urav";
            this.urav.Size = new System.Drawing.Size(126, 17);
            this.urav.TabIndex = 3;
            this.urav.TabStop = true;
            this.urav.Text = "Решение уравнения";
            this.urav.UseVisualStyleBackColor = true;
            // 
            // chetv
            // 
            this.chetv.AutoSize = true;
            this.chetv.Location = new System.Drawing.Point(6, 65);
            this.chetv.Name = "chetv";
            this.chetv.Size = new System.Drawing.Size(133, 17);
            this.chetv.TabIndex = 4;
            this.chetv.TabStop = true;
            this.chetv.Text = "Для первой четверти";
            this.chetv.UseVisualStyleBackColor = true;
            // 
            // resh
            // 
            this.resh.AutoSize = true;
            this.resh.Location = new System.Drawing.Point(6, 99);
            this.resh.Name = "resh";
            this.resh.Size = new System.Drawing.Size(107, 17);
            this.resh.TabIndex = 5;
            this.resh.TabStop = true;
            this.resh.Text = "Общее решение";
            this.resh.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.resh);
            this.groupBox1.Controls.Add(this.urav);
            this.groupBox1.Controls.Add(this.chetv);
            this.groupBox1.Location = new System.Drawing.Point(731, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(152, 122);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Четырехсвязные";
            // 
            // glControl1
            // 
            this.glControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.glControl1.BackColor = System.Drawing.Color.Black;
            this.glControl1.Location = new System.Drawing.Point(12, 12);
            this.glControl1.Name = "glControl1";
            this.glControl1.Size = new System.Drawing.Size(713, 449);
            this.glControl1.TabIndex = 7;
            this.glControl1.VSync = false;
            this.glControl1.Load += new System.EventHandler(this.glControl1_Load);
            this.glControl1.Paint += new System.Windows.Forms.PaintEventHandler(this.glControl1_Paint);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.ob8);
            this.groupBox2.Controls.Add(this.resur8);
            this.groupBox2.Controls.Add(this.chet8);
            this.groupBox2.Location = new System.Drawing.Point(731, 149);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(152, 122);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Восьмисвязные";
            // 
            // ob8
            // 
            this.ob8.AutoSize = true;
            this.ob8.Location = new System.Drawing.Point(6, 99);
            this.ob8.Name = "ob8";
            this.ob8.Size = new System.Drawing.Size(107, 17);
            this.ob8.TabIndex = 5;
            this.ob8.TabStop = true;
            this.ob8.Text = "Общее решение";
            this.ob8.UseVisualStyleBackColor = true;
            // 
            // resur8
            // 
            this.resur8.AutoSize = true;
            this.resur8.Location = new System.Drawing.Point(6, 32);
            this.resur8.Name = "resur8";
            this.resur8.Size = new System.Drawing.Size(126, 17);
            this.resur8.TabIndex = 3;
            this.resur8.TabStop = true;
            this.resur8.Text = "Решение уравнения";
            this.resur8.UseVisualStyleBackColor = true;
            // 
            // chet8
            // 
            this.chet8.AutoSize = true;
            this.chet8.Location = new System.Drawing.Point(6, 65);
            this.chet8.Name = "chet8";
            this.chet8.Size = new System.Drawing.Size(133, 17);
            this.chet8.TabIndex = 4;
            this.chet8.TabStop = true;
            this.chet8.Text = "Для первой четверти";
            this.chet8.UseVisualStyleBackColor = true;
            // 
            // VizBrOt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(895, 473);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.glControl1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Name = "VizBrOt";
            this.Text = "Form1";
            this.Resize += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.RadioButton urav;
        private System.Windows.Forms.RadioButton chetv;
        private System.Windows.Forms.RadioButton resh;
        private System.Windows.Forms.GroupBox groupBox1;
        private OpenTK.GLControl glControl1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton ob8;
        private System.Windows.Forms.RadioButton resur8;
        private System.Windows.Forms.RadioButton chet8;
    }
}

