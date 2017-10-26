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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.выборАлгоритмаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.брензенхемДляОтрезкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.цДАToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.вуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.эллипсToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.окружностьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.назадToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.назадToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(358, 30);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(89, 32);
            this.button1.TabIndex = 1;
            this.button1.Text = "Визуализация";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(480, 30);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(91, 31);
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
            this.glControl1.Location = new System.Drawing.Point(12, 67);
            this.glControl1.Name = "glControl1";
            this.glControl1.Size = new System.Drawing.Size(732, 469);
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
            this.TextData1.Enabled = false;
            this.TextData1.Location = new System.Drawing.Point(750, 328);
            this.TextData1.Name = "TextData1";
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
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.выборАлгоритмаToolStripMenuItem,
            this.назадToolStripMenuItem,
            this.назадToolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(938, 24);
            this.menuStrip1.TabIndex = 12;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // выборАлгоритмаToolStripMenuItem
            // 
            this.выборАлгоритмаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.брензенхемДляОтрезкаToolStripMenuItem,
            this.цДАToolStripMenuItem,
            this.вуToolStripMenuItem,
            this.эллипсToolStripMenuItem,
            this.окружностьToolStripMenuItem});
            this.выборАлгоритмаToolStripMenuItem.Name = "выборАлгоритмаToolStripMenuItem";
            this.выборАлгоритмаToolStripMenuItem.Size = new System.Drawing.Size(118, 20);
            this.выборАлгоритмаToolStripMenuItem.Text = "Выбор алгоритма";
            // 
            // брензенхемДляОтрезкаToolStripMenuItem
            // 
            this.брензенхемДляОтрезкаToolStripMenuItem.Name = "брензенхемДляОтрезкаToolStripMenuItem";
            this.брензенхемДляОтрезкаToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.брензенхемДляОтрезкаToolStripMenuItem.Text = "Брензенхем для отрезка";
            this.брензенхемДляОтрезкаToolStripMenuItem.Click += new System.EventHandler(this.брензенхемДляОтрезкаToolStripMenuItem_Click);
            // 
            // цДАToolStripMenuItem
            // 
            this.цДАToolStripMenuItem.Name = "цДАToolStripMenuItem";
            this.цДАToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.цДАToolStripMenuItem.Text = "ЦДА";
            this.цДАToolStripMenuItem.Click += new System.EventHandler(this.цДАToolStripMenuItem_Click);
            // 
            // вуToolStripMenuItem
            // 
            this.вуToolStripMenuItem.Name = "вуToolStripMenuItem";
            this.вуToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.вуToolStripMenuItem.Text = "Ву";
            this.вуToolStripMenuItem.Click += new System.EventHandler(this.вуToolStripMenuItem_Click);
            // 
            // эллипсToolStripMenuItem
            // 
            this.эллипсToolStripMenuItem.Name = "эллипсToolStripMenuItem";
            this.эллипсToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.эллипсToolStripMenuItem.Text = "Эллипс";
            this.эллипсToolStripMenuItem.Click += new System.EventHandler(this.эллипсToolStripMenuItem_Click);
            // 
            // окружностьToolStripMenuItem
            // 
            this.окружностьToolStripMenuItem.Name = "окружностьToolStripMenuItem";
            this.окружностьToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.окружностьToolStripMenuItem.Text = "Окружность";
            this.окружностьToolStripMenuItem.Click += new System.EventHandler(this.окружностьToolStripMenuItem_Click);
            // 
            // назадToolStripMenuItem
            // 
            this.назадToolStripMenuItem.Name = "назадToolStripMenuItem";
            this.назадToolStripMenuItem.Size = new System.Drawing.Size(95, 20);
            this.назадToolStripMenuItem.Text = "Визуализация";
            // 
            // назадToolStripMenuItem1
            // 
            this.назадToolStripMenuItem1.Name = "назадToolStripMenuItem1";
            this.назадToolStripMenuItem1.Size = new System.Drawing.Size(51, 20);
            this.назадToolStripMenuItem1.Text = "Назад";
            // 
            // VizBrOt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(938, 548);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.TextData1);
            this.Controls.Add(this.dan);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.glControl1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "VizBrOt";
            this.Text = "Form1";
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
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem выборАлгоритмаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem брензенхемДляОтрезкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem цДАToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem вуToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem эллипсToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem окружностьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem назадToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem назадToolStripMenuItem1;
    }
}

