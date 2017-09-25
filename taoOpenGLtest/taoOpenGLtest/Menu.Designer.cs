namespace taoOpenGLtest
{
    partial class Menu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.brOtr = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // brOtr
            // 
            this.brOtr.Location = new System.Drawing.Point(12, 53);
            this.brOtr.Name = "brOtr";
            this.brOtr.Size = new System.Drawing.Size(137, 58);
            this.brOtr.TabIndex = 0;
            this.brOtr.Text = "Алгоритм Брехенхема (отрезок)";
            this.brOtr.UseVisualStyleBackColor = true;
            this.brOtr.Click += new System.EventHandler(this.brOtr_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 126);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(137, 58);
            this.button1.TabIndex = 1;
            this.button1.Text = "Алгоритм ЦДА";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(322, 290);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.brOtr);
            this.Name = "Menu";
            this.Text = "Menu";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button brOtr;
        private System.Windows.Forms.Button button1;

    }
}