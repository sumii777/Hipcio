namespace Hipcio
{
    partial class OknoBlackJack
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.zaklad = new System.Windows.Forms.Label();
            this.infoZaklad = new System.Windows.Forms.Label();
            this.saldo = new System.Windows.Forms.Label();
            this.infoSaldo = new System.Windows.Forms.Label();
            this.przyciskGraj = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.infoWynik = new System.Windows.Forms.Label();
            this.infoGra = new System.Windows.Forms.Label();
            this.labelGracz = new System.Windows.Forms.Label();
            this.labelKrupier = new System.Windows.Forms.Label();
            this.dobierz = new System.Windows.Forms.Button();
            this.hold = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.tableLayoutPanel1.ColumnCount = 7;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.5F));
            this.tableLayoutPanel1.Controls.Add(this.zaklad, 4, 8);
            this.tableLayoutPanel1.Controls.Add(this.infoZaklad, 4, 7);
            this.tableLayoutPanel1.Controls.Add(this.saldo, 1, 8);
            this.tableLayoutPanel1.Controls.Add(this.infoSaldo, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.przyciskGraj, 3, 4);
            this.tableLayoutPanel1.Controls.Add(this.label2, 4, 2);
            this.tableLayoutPanel1.Controls.Add(this.label1, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.infoWynik, 3, 7);
            this.tableLayoutPanel1.Controls.Add(this.infoGra, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelGracz, 5, 3);
            this.tableLayoutPanel1.Controls.Add(this.labelKrupier, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.dobierz, 5, 4);
            this.tableLayoutPanel1.Controls.Add(this.hold, 1, 4);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 10;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.57884F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.381238F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 450);
            this.tableLayoutPanel1.TabIndex = 1;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // zaklad
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.zaklad, 2);
            this.zaklad.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zaklad.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.zaklad.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(188)))), ((int)(((byte)(188)))));
            this.zaklad.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.zaklad.Location = new System.Drawing.Point(463, 402);
            this.zaklad.Name = "zaklad";
            this.zaklad.Size = new System.Drawing.Size(154, 22);
            this.zaklad.TabIndex = 16;
            this.zaklad.Text = "{zakład}";
            this.zaklad.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // infoZaklad
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.infoZaklad, 2);
            this.infoZaklad.Dock = System.Windows.Forms.DockStyle.Fill;
            this.infoZaklad.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.infoZaklad.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(188)))), ((int)(((byte)(188)))));
            this.infoZaklad.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.infoZaklad.Location = new System.Drawing.Point(463, 380);
            this.infoZaklad.Name = "infoZaklad";
            this.infoZaklad.Size = new System.Drawing.Size(154, 22);
            this.infoZaklad.TabIndex = 15;
            this.infoZaklad.Text = "Zakład";
            this.infoZaklad.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // saldo
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.saldo, 2);
            this.saldo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.saldo.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.saldo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(188)))), ((int)(((byte)(188)))));
            this.saldo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.saldo.Location = new System.Drawing.Point(183, 402);
            this.saldo.Name = "saldo";
            this.saldo.Size = new System.Drawing.Size(154, 22);
            this.saldo.TabIndex = 14;
            this.saldo.Text = "{saldo}";
            this.saldo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // infoSaldo
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.infoSaldo, 2);
            this.infoSaldo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.infoSaldo.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.infoSaldo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(188)))), ((int)(((byte)(188)))));
            this.infoSaldo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.infoSaldo.Location = new System.Drawing.Point(183, 380);
            this.infoSaldo.Name = "infoSaldo";
            this.infoSaldo.Size = new System.Drawing.Size(154, 22);
            this.infoSaldo.TabIndex = 13;
            this.infoSaldo.Text = "Twoje saldo";
            this.infoSaldo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // przyciskGraj
            // 
            this.przyciskGraj.BackColor = System.Drawing.Color.Black;
            this.przyciskGraj.Dock = System.Windows.Forms.DockStyle.Fill;
            this.przyciskGraj.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(74)))), ((int)(((byte)(28)))));
            this.przyciskGraj.FlatAppearance.BorderSize = 2;
            this.przyciskGraj.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.przyciskGraj.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.przyciskGraj.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.przyciskGraj.ForeColor = System.Drawing.Color.White;
            this.przyciskGraj.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.przyciskGraj.Location = new System.Drawing.Point(343, 272);
            this.przyciskGraj.Name = "przyciskGraj";
            this.przyciskGraj.Size = new System.Drawing.Size(114, 41);
            this.przyciskGraj.TabIndex = 12;
            this.przyciskGraj.TabStop = false;
            this.przyciskGraj.Text = "Graj";
            this.przyciskGraj.UseVisualStyleBackColor = false;
            this.przyciskGraj.Click += new System.EventHandler(this.przyciskGraj_Click);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tableLayoutPanel1.SetColumnSpan(this.label2, 2);
            this.label2.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(188)))), ((int)(((byte)(188)))));
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(463, 157);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(154, 45);
            this.label2.TabIndex = 11;
            this.label2.Text = "Gracz";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tableLayoutPanel1.SetColumnSpan(this.label1, 2);
            this.label1.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(188)))), ((int)(((byte)(188)))));
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(183, 157);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 45);
            this.label1.TabIndex = 10;
            this.label1.Text = "Krupier";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // infoWynik
            // 
            this.infoWynik.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.infoWynik.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.infoWynik.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(188)))), ((int)(((byte)(188)))));
            this.infoWynik.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.infoWynik.Location = new System.Drawing.Point(343, 381);
            this.infoWynik.Name = "infoWynik";
            this.infoWynik.Size = new System.Drawing.Size(114, 19);
            this.infoWynik.TabIndex = 9;
            this.infoWynik.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // infoGra
            // 
            this.infoGra.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLayoutPanel1.SetColumnSpan(this.infoGra, 5);
            this.infoGra.Font = new System.Drawing.Font("Arial", 36F, System.Drawing.FontStyle.Bold);
            this.infoGra.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(188)))), ((int)(((byte)(188)))));
            this.infoGra.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.infoGra.Location = new System.Drawing.Point(183, 67);
            this.infoGra.Name = "infoGra";
            this.infoGra.Size = new System.Drawing.Size(434, 90);
            this.infoGra.TabIndex = 3;
            this.infoGra.Text = "Black Jack";
            this.infoGra.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelGracz
            // 
            this.labelGracz.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelGracz.AutoSize = true;
            this.labelGracz.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.labelGracz.Location = new System.Drawing.Point(542, 229);
            this.labelGracz.Name = "labelGracz";
            this.labelGracz.Size = new System.Drawing.Size(35, 13);
            this.labelGracz.TabIndex = 17;
            this.labelGracz.Text = "label3";
            // 
            // labelKrupier
            // 
            this.labelKrupier.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelKrupier.AutoSize = true;
            this.labelKrupier.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelKrupier.Location = new System.Drawing.Point(222, 229);
            this.labelKrupier.Name = "labelKrupier";
            this.labelKrupier.Size = new System.Drawing.Size(35, 13);
            this.labelKrupier.TabIndex = 18;
            this.labelKrupier.Text = "label3";
            // 
            // dobierz
            // 
            this.dobierz.BackColor = System.Drawing.Color.Black;
            this.dobierz.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dobierz.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dobierz.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.dobierz.ForeColor = System.Drawing.Color.White;
            this.dobierz.Location = new System.Drawing.Point(503, 272);
            this.dobierz.Name = "dobierz";
            this.dobierz.Size = new System.Drawing.Size(114, 41);
            this.dobierz.TabIndex = 19;
            this.dobierz.Text = "dobierz";
            this.dobierz.UseVisualStyleBackColor = false;
            this.dobierz.Visible = false;
            this.dobierz.Click += new System.EventHandler(this.dobierz_Click);
            // 
            // hold
            // 
            this.hold.BackColor = System.Drawing.Color.Black;
            this.hold.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hold.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.hold.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.hold.ForeColor = System.Drawing.Color.White;
            this.hold.Location = new System.Drawing.Point(183, 272);
            this.hold.Name = "hold";
            this.hold.Size = new System.Drawing.Size(114, 41);
            this.hold.TabIndex = 22;
            this.hold.Text = "hold";
            this.hold.UseVisualStyleBackColor = false;
            this.hold.Click += new System.EventHandler(this.hold_Click);
            // 
            // OknoBlackJack
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(816, 489);
            this.MinimumSize = new System.Drawing.Size(816, 489);
            this.Name = "OknoBlackJack";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Black Jack";
            this.Load += new System.EventHandler(this.OknoBlackJack_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label infoWynik;
        private System.Windows.Forms.Label infoGra;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button przyciskGraj;
        private System.Windows.Forms.Label infoSaldo;
        private System.Windows.Forms.Label saldo;
        private System.Windows.Forms.Label infoZaklad;
        private System.Windows.Forms.Label zaklad;
        private System.Windows.Forms.Label labelGracz;
        private System.Windows.Forms.Label labelKrupier;
        private System.Windows.Forms.Button dobierz;
        private System.Windows.Forms.Button hold;
    }
}