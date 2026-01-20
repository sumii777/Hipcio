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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.bandyta = new System.Windows.Forms.Button();
            this.kolo = new System.Windows.Forms.Button();
            this.ruletka = new System.Windows.Forms.Button();
            this.bjack = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.doladuj = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.autorzy = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
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
            this.panel2.Controls.Add(this.bandyta);
            this.panel2.Controls.Add(this.kolo);
            this.panel2.Controls.Add(this.ruletka);
            this.panel2.Controls.Add(this.bjack);
            this.panel2.Location = new System.Drawing.Point(8, 8);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(801, 43);
            this.panel2.TabIndex = 2;
            // 
            // bandyta
            // 
            this.bandyta.BackgroundImage = global::Hipcio.Properties.Resources.bandyta;
            this.bandyta.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bandyta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bandyta.Location = new System.Drawing.Point(610, 3);
            this.bandyta.Name = "bandyta";
            this.bandyta.Size = new System.Drawing.Size(180, 34);
            this.bandyta.TabIndex = 3;
            this.bandyta.UseVisualStyleBackColor = true;
            this.bandyta.Click += new System.EventHandler(this.bandyta_Click);
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
            this.kolo.Click += new System.EventHandler(this.kolo_Click);
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
            this.ruletka.Click += new System.EventHandler(this.ruletka_Click);
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
            this.bjack.Click += new System.EventHandler(this.bjack_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(6)))), ((int)(((byte)(38)))));
            this.panel3.Controls.Add(this.doladuj);
            this.panel3.Controls.Add(this.pictureBox2);
            this.panel3.Controls.Add(this.autorzy);
            this.panel3.Location = new System.Drawing.Point(665, 44);
            this.panel3.MaximumSize = new System.Drawing.Size(136, 407);
            this.panel3.MinimumSize = new System.Drawing.Size(136, 407);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(136, 407);
            this.panel3.TabIndex = 4;
            // 
            // doladuj
            // 
            this.doladuj.BackgroundImage = global::Hipcio.Properties.Resources.doladuj;
            this.doladuj.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.doladuj.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.doladuj.Location = new System.Drawing.Point(15, 103);
            this.doladuj.Name = "doladuj";
            this.doladuj.Size = new System.Drawing.Size(118, 28);
            this.doladuj.TabIndex = 4;
            this.doladuj.UseVisualStyleBackColor = true;
            this.doladuj.Click += new System.EventHandler(this.doladuj_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Hipcio.Properties.Resources.saldo1;
            this.pictureBox2.Location = new System.Drawing.Point(15, 21);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(118, 33);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 5;
            this.pictureBox2.TabStop = false;
            // 
            // autorzy
            // 
            this.autorzy.BackgroundImage = global::Hipcio.Properties.Resources.autorzy1;
            this.autorzy.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.autorzy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.autorzy.Location = new System.Drawing.Point(15, 363);
            this.autorzy.Name = "autorzy";
            this.autorzy.Size = new System.Drawing.Size(118, 31);
            this.autorzy.TabIndex = 4;
            this.autorzy.UseVisualStyleBackColor = true;
            this.autorzy.Click += new System.EventHandler(this.autorzy_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Hipcio.Properties.Resources.menu1;
            this.pictureBox1.Location = new System.Drawing.Point(-66, 44);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(752, 408);
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
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(816, 489);
            this.MinimumSize = new System.Drawing.Size(816, 489);
            this.Name = "OknoMenu";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu";
            this.Load += new System.EventHandler(this.OknoMenu_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
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
        private System.Windows.Forms.Button bandyta;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button autorzy;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button doladuj;
    }
}