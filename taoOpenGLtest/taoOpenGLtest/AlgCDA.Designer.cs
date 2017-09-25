namespace taoOpenGLtest
{
    partial class AlgCDA
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
            this.cda = new Tao.Platform.Windows.SimpleOpenGlControl();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cda
            // 
            this.cda.AccumBits = ((byte)(0));
            this.cda.AutoCheckErrors = false;
            this.cda.AutoFinish = false;
            this.cda.AutoMakeCurrent = true;
            this.cda.AutoSwapBuffers = true;
            this.cda.BackColor = System.Drawing.Color.Black;
            this.cda.ColorBits = ((byte)(32));
            this.cda.DepthBits = ((byte)(16));
            this.cda.Location = new System.Drawing.Point(12, 12);
            this.cda.Name = "cda";
            this.cda.Size = new System.Drawing.Size(618, 370);
            this.cda.StencilBits = ((byte)(0));
            this.cda.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(646, 37);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(91, 39);
            this.button1.TabIndex = 2;
            this.button1.Text = "Визуализация";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(646, 93);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(91, 37);
            this.button2.TabIndex = 3;
            this.button2.Text = "Пауза";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // AlgCDA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(749, 396);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cda);
            this.Name = "AlgCDA";
            this.Text = "AlgCDA";
            this.Load += new System.EventHandler(this.AlgCDA_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Tao.Platform.Windows.SimpleOpenGlControl cda;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}