namespace Hipcio
{
    partial class OknoMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OknoMenu));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.kolo = new System.Windows.Forms.Button();
            this.ruletka = new System.Windows.Forms.Button();
            this.bjack = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(6)))), ((int)(((byte)(43)))));
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(0, -7);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(801, 51);
            this.panel1.TabIndex = 1;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(6)))), ((int)(((byte)(43)))));
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.kolo);
            this.panel2.Controls.Add(this.ruletka);
            this.panel2.Controls.Add(this.bjack);
            this.panel2.Location = new System.Drawing.Point(8, 8);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(801, 37);
            this.panel2.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(6)))), ((int)(((byte)(43)))));
            this.panel3.Location = new System.Drawing.Point(675, 44);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(123, 407);
            this.panel3.TabIndex = 4;
            // 
            // button2
            // 
            this.button2.BackgroundImage = global::Hipcio.Properties.Resources.bandyta;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(610, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(180, 34);
            this.button2.TabIndex = 3;
            this.button2.UseVisualStyleBackColor = true;
            // 
            // kolo
            // 
            this.kolo.BackgroundImage = global::Hipcio.Properties.Resources.kolo;
            this.kolo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.kolo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.kolo.Location = new System.Drawing.Point(414, 3);
            this.kolo.Name = "kolo";
            this.kolo.Size = new System.Drawing.Size(169, 34);
            this.kolo.TabIndex = 2;
            this.kolo.UseVisualStyleBackColor = true;
            // 
            // ruletka
            // 
            this.ruletka.BackgroundImage = global::Hipcio.Properties.Resources.ruletka;
            this.ruletka.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ruletka.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ruletka.Location = new System.Drawing.Point(220, 3);
            this.ruletka.Name = "ruletka";
            this.ruletka.Size = new System.Drawing.Size(163, 34);
            this.ruletka.TabIndex = 1;
            this.ruletka.UseVisualStyleBackColor = true;
            // 
            // bjack
            // 
            this.bjack.BackgroundImage = global::Hipcio.Properties.Resources.bjack;
            this.bjack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bjack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bjack.Location = new System.Drawing.Point(-5, 3);
            this.bjack.Name = "bjack";
            this.bjack.Size = new System.Drawing.Size(198, 34);
            this.bjack.TabIndex = 0;
            this.bjack.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(-10, -7);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(811, 458);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // OknoMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "OknoMenu";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button kolo;
        private System.Windows.Forms.Button ruletka;
        private System.Windows.Forms.Button bjack;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panel3;
    }
}