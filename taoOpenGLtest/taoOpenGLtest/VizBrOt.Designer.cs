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
            this.dan = new System.Windows.Forms.Label();
            this.TextData1 = new System.Windows.Forms.RichTextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxX1 = new System.Windows.Forms.TextBox();
            this.textBoxY1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxX2 = new System.Windows.Forms.TextBox();
            this.textBoxY2 = new System.Windows.Forms.TextBox();
            this.textBoxA = new System.Windows.Forms.TextBox();
            this.textBoxB = new System.Windows.Forms.TextBox();
            this.textBoxR = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.выборАлгоритмаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.брезенхемДляОтрезкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.цДАToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.вуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.эллипсToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.окружностьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.справкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.оПрограммеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.назадToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Control;
            this.button1.Location = new System.Drawing.Point(12, 35);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(89, 32);
            this.button1.TabIndex = 1;
            this.button1.Text = "Визуализация";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.Control;
            this.button2.Location = new System.Drawing.Point(123, 35);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(91, 31);
            this.button2.TabIndex = 2;
            this.button2.Text = "Пауза";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 600;
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
            this.urav.CheckedChanged += new System.EventHandler(this.urav_CheckedChanged);
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
            this.chetv.CheckedChanged += new System.EventHandler(this.chetv_CheckedChanged);
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
            this.resh.CheckedChanged += new System.EventHandler(this.resh_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.resh);
            this.groupBox1.Controls.Add(this.urav);
            this.groupBox1.Controls.Add(this.chetv);
            this.groupBox1.Location = new System.Drawing.Point(761, 40);
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
            this.glControl1.Location = new System.Drawing.Point(12, 83);
            this.glControl1.Name = "glControl1";
            this.glControl1.Size = new System.Drawing.Size(732, 453);
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
            this.groupBox2.Location = new System.Drawing.Point(761, 177);
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
            this.ob8.CheckedChanged += new System.EventHandler(this.ob8_CheckedChanged);
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
            this.resur8.CheckedChanged += new System.EventHandler(this.resur8_CheckedChanged);
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
            this.chet8.CheckedChanged += new System.EventHandler(this.chet8_CheckedChanged);
            // 
            // dan
            // 
            this.dan.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dan.AutoSize = true;
            this.dan.Location = new System.Drawing.Point(758, 312);
            this.dan.Name = "dan";
            this.dan.Size = new System.Drawing.Size(48, 13);
            this.dan.TabIndex = 8;
            this.dan.Text = "Данные";
            // 
            // TextData1
            // 
            this.TextData1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextData1.Location = new System.Drawing.Point(750, 328);
            this.TextData1.Name = "TextData1";
            this.TextData1.ReadOnly = true;
            this.TextData1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.TextData1.Size = new System.Drawing.Size(184, 208);
            this.TextData1.TabIndex = 10;
            this.TextData1.Text = "";
            // 
            // checkBox1
            // 
            this.checkBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(639, 44);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(91, 17);
            this.checkBox1.TabIndex = 11;
            this.checkBox1.Text = "Открыть код";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(256, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "X1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(256, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Y1";
            // 
            // textBoxX1
            // 
            this.textBoxX1.Location = new System.Drawing.Point(281, 32);
            this.textBoxX1.Name = "textBoxX1";
            this.textBoxX1.Size = new System.Drawing.Size(35, 20);
            this.textBoxX1.TabIndex = 15;
            // 
            // textBoxY1
            // 
            this.textBoxY1.Location = new System.Drawing.Point(281, 58);
            this.textBoxY1.Name = "textBoxY1";
            this.textBoxY1.Size = new System.Drawing.Size(35, 20);
            this.textBoxY1.TabIndex = 16;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(332, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "X2";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(332, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(20, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Y2";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(409, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(13, 13);
            this.label5.TabIndex = 21;
            this.label5.Text = "a";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(409, 61);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(13, 13);
            this.label6.TabIndex = 22;
            this.label6.Text = "b";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(479, 35);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(15, 13);
            this.label7.TabIndex = 26;
            this.label7.Text = "R";
            // 
            // textBoxX2
            // 
            this.textBoxX2.Location = new System.Drawing.Point(357, 32);
            this.textBoxX2.Name = "textBoxX2";
            this.textBoxX2.Size = new System.Drawing.Size(35, 20);
            this.textBoxX2.TabIndex = 27;
            // 
            // textBoxY2
            // 
            this.textBoxY2.Location = new System.Drawing.Point(357, 58);
            this.textBoxY2.Name = "textBoxY2";
            this.textBoxY2.Size = new System.Drawing.Size(35, 20);
            this.textBoxY2.TabIndex = 28;
            // 
            // textBoxA
            // 
            this.textBoxA.Location = new System.Drawing.Point(427, 32);
            this.textBoxA.Name = "textBoxA";
            this.textBoxA.Size = new System.Drawing.Size(35, 20);
            this.textBoxA.TabIndex = 29;
            // 
            // textBoxB
            // 
            this.textBoxB.Location = new System.Drawing.Point(427, 58);
            this.textBoxB.Name = "textBoxB";
            this.textBoxB.Size = new System.Drawing.Size(35, 20);
            this.textBoxB.TabIndex = 30;
            // 
            // textBoxR
            // 
            this.textBoxR.Location = new System.Drawing.Point(499, 32);
            this.textBoxR.Name = "textBoxR";
            this.textBoxR.Size = new System.Drawing.Size(35, 20);
            this.textBoxR.TabIndex = 31;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.выборАлгоритмаToolStripMenuItem,
            this.toolStripMenuItem1,
            this.справкаToolStripMenuItem,
            this.оПрограммеToolStripMenuItem,
            this.назадToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(938, 24);
            this.menuStrip1.TabIndex = 32;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // выборАлгоритмаToolStripMenuItem
            // 
            this.выборАлгоритмаToolStripMenuItem.Checked = true;
            this.выборАлгоритмаToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.выборАлгоритмаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.брезенхемДляОтрезкаToolStripMenuItem,
            this.цДАToolStripMenuItem,
            this.вуToolStripMenuItem,
            this.эллипсToolStripMenuItem,
            this.окружностьToolStripMenuItem});
            this.выборАлгоритмаToolStripMenuItem.Name = "выборАлгоритмаToolStripMenuItem";
            this.выборАлгоритмаToolStripMenuItem.Size = new System.Drawing.Size(118, 20);
            this.выборАлгоритмаToolStripMenuItem.Text = "Выбор алгоритма";
            // 
            // брезенхемДляОтрезкаToolStripMenuItem
            // 
            this.брезенхемДляОтрезкаToolStripMenuItem.CheckOnClick = true;
            this.брезенхемДляОтрезкаToolStripMenuItem.Name = "брезенхемДляОтрезкаToolStripMenuItem";
            this.брезенхемДляОтрезкаToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.брезенхемДляОтрезкаToolStripMenuItem.Text = "Брезенхем для отрезка";
            // 
            // цДАToolStripMenuItem
            // 
            this.цДАToolStripMenuItem.Name = "цДАToolStripMenuItem";
            this.цДАToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.цДАToolStripMenuItem.Text = "ЦДА";
            // 
            // вуToolStripMenuItem
            // 
            this.вуToolStripMenuItem.Name = "вуToolStripMenuItem";
            this.вуToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.вуToolStripMenuItem.Text = "Ву";
            // 
            // эллипсToolStripMenuItem
            // 
            this.эллипсToolStripMenuItem.Name = "эллипсToolStripMenuItem";
            this.эллипсToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.эллипсToolStripMenuItem.Text = "Эллипс";
            // 
            // окружностьToolStripMenuItem
            // 
            this.окружностьToolStripMenuItem.Name = "окружностьToolStripMenuItem";
            this.окружностьToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.окружностьToolStripMenuItem.Text = "Окружность";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(95, 20);
            this.toolStripMenuItem1.Text = "Визуализация";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // справкаToolStripMenuItem
            // 
            this.справкаToolStripMenuItem.Name = "справкаToolStripMenuItem";
            this.справкаToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.справкаToolStripMenuItem.Text = "Справка";
            this.справкаToolStripMenuItem.Click += new System.EventHandler(this.справкаToolStripMenuItem_Click_1);
            // 
            // оПрограммеToolStripMenuItem
            // 
            this.оПрограммеToolStripMenuItem.Name = "оПрограммеToolStripMenuItem";
            this.оПрограммеToolStripMenuItem.Size = new System.Drawing.Size(94, 20);
            this.оПрограммеToolStripMenuItem.Text = "О программе";
            this.оПрограммеToolStripMenuItem.Click += new System.EventHandler(this.оПрограммеToolStripMenuItem_Click_1);
            // 
            // назадToolStripMenuItem
            // 
            this.назадToolStripMenuItem.Name = "назадToolStripMenuItem";
            this.назадToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.назадToolStripMenuItem.Text = "Назад";
            // 
            // VizBrOt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(938, 548);
            this.Controls.Add(this.textBoxR);
            this.Controls.Add(this.textBoxB);
            this.Controls.Add(this.textBoxA);
            this.Controls.Add(this.textBoxY2);
            this.Controls.Add(this.textBoxX2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxY1);
            this.Controls.Add(this.textBoxX1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.TextData1);
            this.Controls.Add(this.dan);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.glControl1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "VizBrOt";
            this.Text = "Визуализация";
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.VizBrOt_MouseClick);
            this.Resize += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.Label dan;
        private System.Windows.Forms.RichTextBox TextData1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxX1;
        private System.Windows.Forms.TextBox textBoxY1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxX2;
        private System.Windows.Forms.TextBox textBoxY2;
        private System.Windows.Forms.TextBox textBoxA;
        private System.Windows.Forms.TextBox textBoxB;
        private System.Windows.Forms.TextBox textBoxR;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem выборАлгоритмаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem брезенхемДляОтрезкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem цДАToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem вуToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem эллипсToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem окружностьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem справкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem оПрограммеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem назадToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
    }
}

