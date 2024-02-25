namespace RMays.InfiniteCraft
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            splitContainer1 = new SplitContainer();
            btnGo = new Button();
            btnEarth = new Button();
            btnWind = new Button();
            btnFire = new Button();
            btnWater = new Button();
            txtLog = new TextBox();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(btnGo);
            splitContainer1.Panel1.Controls.Add(btnEarth);
            splitContainer1.Panel1.Controls.Add(btnWind);
            splitContainer1.Panel1.Controls.Add(btnFire);
            splitContainer1.Panel1.Controls.Add(btnWater);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(txtLog);
            splitContainer1.Size = new Size(800, 450);
            splitContainer1.SplitterDistance = 266;
            splitContainer1.TabIndex = 0;
            // 
            // btnGo
            // 
            btnGo.Location = new Point(70, 130);
            btnGo.Name = "btnGo";
            btnGo.Size = new Size(75, 23);
            btnGo.TabIndex = 4;
            btnGo.Text = "GO";
            btnGo.UseVisualStyleBackColor = true;
            btnGo.Click += btnGo_Click;
            // 
            // btnEarth
            // 
            btnEarth.Location = new Point(93, 41);
            btnEarth.Name = "btnEarth";
            btnEarth.Size = new Size(75, 23);
            btnEarth.TabIndex = 3;
            btnEarth.Text = "Earth";
            btnEarth.UseVisualStyleBackColor = true;
            // 
            // btnWind
            // 
            btnWind.Location = new Point(12, 41);
            btnWind.Name = "btnWind";
            btnWind.Size = new Size(75, 23);
            btnWind.TabIndex = 2;
            btnWind.Text = "Wind";
            btnWind.UseVisualStyleBackColor = true;
            // 
            // btnFire
            // 
            btnFire.Location = new Point(93, 12);
            btnFire.Name = "btnFire";
            btnFire.Size = new Size(75, 23);
            btnFire.TabIndex = 1;
            btnFire.Text = "Fire";
            btnFire.UseVisualStyleBackColor = true;
            // 
            // btnWater
            // 
            btnWater.Location = new Point(12, 12);
            btnWater.Name = "btnWater";
            btnWater.Size = new Size(75, 23);
            btnWater.TabIndex = 0;
            btnWater.Text = "Water";
            btnWater.UseVisualStyleBackColor = true;
            btnWater.Click += button1_Click;
            // 
            // txtLog
            // 
            txtLog.Dock = DockStyle.Fill;
            txtLog.Location = new Point(0, 0);
            txtLog.Multiline = true;
            txtLog.Name = "txtLog";
            txtLog.Size = new Size(530, 450);
            txtLog.TabIndex = 0;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(splitContainer1);
            Name = "Form1";
            Text = "Form1";
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private Button btnEarth;
        private Button btnWind;
        private Button btnFire;
        private Button btnWater;
        private Button btnGo;
        private TextBox txtLog;
    }
}