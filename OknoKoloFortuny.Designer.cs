namespace Hipcio
{
    partial class OknoKoloFortuny
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
            this.saldo = new System.Windows.Forms.Label();
            this.infoSaldo = new System.Windows.Forms.Label();
            this.zaklad = new System.Windows.Forms.Label();
            this.infoZaklad = new System.Windows.Forms.Label();
            this.wygrana6 = new System.Windows.Forms.Label();
            this.wygrana5 = new System.Windows.Forms.Label();
            this.wygrana4 = new System.Windows.Forms.Label();
            this.wygrana3 = new System.Windows.Forms.Label();
            this.wygrana2 = new System.Windows.Forms.Label();
            this.wygrana1 = new System.Windows.Forms.Label();
            this.wygrana0 = new System.Windows.Forms.Label();
            this.wygrana7 = new System.Windows.Forms.Label();
            this.przyciskGraj = new System.Windows.Forms.Button();
            this.infoGra = new System.Windows.Forms.Label();
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
            this.tableLayoutPanel1.Controls.Add(this.saldo, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.infoSaldo, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.zaklad, 6, 6);
            this.tableLayoutPanel1.Controls.Add(this.infoZaklad, 6, 5);
            this.tableLayoutPanel1.Controls.Add(this.wygrana6, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.wygrana5, 3, 7);
            this.tableLayoutPanel1.Controls.Add(this.wygrana4, 5, 7);
            this.tableLayoutPanel1.Controls.Add(this.wygrana3, 5, 5);
            this.tableLayoutPanel1.Controls.Add(this.wygrana2, 5, 3);
            this.tableLayoutPanel1.Controls.Add(this.wygrana1, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.wygrana0, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.wygrana7, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.przyciskGraj, 3, 5);
            this.tableLayoutPanel1.Controls.Add(this.infoGra, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 9;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 450);
            this.tableLayoutPanel1.TabIndex = 2;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // saldo
            // 
            this.saldo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.saldo.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.saldo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(188)))), ((int)(((byte)(188)))));
            this.saldo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.saldo.Location = new System.Drawing.Point(3, 325);
            this.saldo.Name = "saldo";
            this.saldo.Size = new System.Drawing.Size(174, 56);
            this.saldo.TabIndex = 28;
            this.saldo.Text = "{saldo}";
            this.saldo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // infoSaldo
            // 
            this.infoSaldo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.infoSaldo.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.infoSaldo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(188)))), ((int)(((byte)(188)))));
            this.infoSaldo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.infoSaldo.Location = new System.Drawing.Point(3, 280);
            this.infoSaldo.Name = "infoSaldo";
            this.infoSaldo.Size = new System.Drawing.Size(174, 45);
            this.infoSaldo.TabIndex = 27;
            this.infoSaldo.Text = "Twoje saldo";
            this.infoSaldo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // zaklad
            // 
            this.zaklad.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zaklad.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.zaklad.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(188)))), ((int)(((byte)(188)))));
            this.zaklad.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.zaklad.Location = new System.Drawing.Point(623, 325);
            this.zaklad.Name = "zaklad";
            this.zaklad.Size = new System.Drawing.Size(174, 56);
            this.zaklad.TabIndex = 26;
            this.zaklad.Text = "{zakład}";
            this.zaklad.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // infoZaklad
            // 
            this.infoZaklad.Dock = System.Windows.Forms.DockStyle.Fill;
            this.infoZaklad.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.infoZaklad.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(188)))), ((int)(((byte)(188)))));
            this.infoZaklad.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.infoZaklad.Location = new System.Drawing.Point(623, 280);
            this.infoZaklad.Name = "infoZaklad";
            this.infoZaklad.Size = new System.Drawing.Size(174, 45);
            this.infoZaklad.TabIndex = 25;
            this.infoZaklad.Text = "Zakład";
            this.infoZaklad.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // wygrana6
            // 
            this.wygrana6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.wygrana6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wygrana6.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.wygrana6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(188)))), ((int)(((byte)(188)))));
            this.wygrana6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.wygrana6.Location = new System.Drawing.Point(183, 381);
            this.wygrana6.Name = "wygrana6";
            this.wygrana6.Size = new System.Drawing.Size(114, 45);
            this.wygrana6.TabIndex = 24;
            this.wygrana6.Text = "X0";
            this.wygrana6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // wygrana5
            // 
            this.wygrana5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.wygrana5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wygrana5.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.wygrana5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(188)))), ((int)(((byte)(188)))));
            this.wygrana5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.wygrana5.Location = new System.Drawing.Point(343, 381);
            this.wygrana5.Name = "wygrana5";
            this.wygrana5.Size = new System.Drawing.Size(114, 45);
            this.wygrana5.TabIndex = 23;
            this.wygrana5.Text = "X10";
            this.wygrana5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // wygrana4
            // 
            this.wygrana4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.wygrana4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wygrana4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.wygrana4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(188)))), ((int)(((byte)(188)))));
            this.wygrana4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.wygrana4.Location = new System.Drawing.Point(503, 381);
            this.wygrana4.Name = "wygrana4";
            this.wygrana4.Size = new System.Drawing.Size(114, 45);
            this.wygrana4.TabIndex = 22;
            this.wygrana4.Text = "X0";
            this.wygrana4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // wygrana3
            // 
            this.wygrana3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.wygrana3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wygrana3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.wygrana3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(188)))), ((int)(((byte)(188)))));
            this.wygrana3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.wygrana3.Location = new System.Drawing.Point(503, 280);
            this.wygrana3.Name = "wygrana3";
            this.wygrana3.Size = new System.Drawing.Size(114, 45);
            this.wygrana3.TabIndex = 21;
            this.wygrana3.Text = "X2";
            this.wygrana3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // wygrana2
            // 
            this.wygrana2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.wygrana2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wygrana2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.wygrana2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(188)))), ((int)(((byte)(188)))));
            this.wygrana2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.wygrana2.Location = new System.Drawing.Point(503, 179);
            this.wygrana2.Name = "wygrana2";
            this.wygrana2.Size = new System.Drawing.Size(114, 45);
            this.wygrana2.TabIndex = 20;
            this.wygrana2.Text = "X0";
            this.wygrana2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // wygrana1
            // 
            this.wygrana1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.wygrana1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wygrana1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.wygrana1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(188)))), ((int)(((byte)(188)))));
            this.wygrana1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.wygrana1.Location = new System.Drawing.Point(343, 179);
            this.wygrana1.Name = "wygrana1";
            this.wygrana1.Size = new System.Drawing.Size(114, 45);
            this.wygrana1.TabIndex = 19;
            this.wygrana1.Text = "X100";
            this.wygrana1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // wygrana0
            // 
            this.wygrana0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.wygrana0.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wygrana0.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.wygrana0.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(188)))), ((int)(((byte)(188)))));
            this.wygrana0.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.wygrana0.Location = new System.Drawing.Point(183, 179);
            this.wygrana0.Name = "wygrana0";
            this.wygrana0.Size = new System.Drawing.Size(114, 45);
            this.wygrana0.TabIndex = 18;
            this.wygrana0.Text = "X0";
            this.wygrana0.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // wygrana7
            // 
            this.wygrana7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.wygrana7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wygrana7.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.wygrana7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(188)))), ((int)(((byte)(188)))));
            this.wygrana7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.wygrana7.Location = new System.Drawing.Point(183, 280);
            this.wygrana7.Name = "wygrana7";
            this.wygrana7.Size = new System.Drawing.Size(114, 45);
            this.wygrana7.TabIndex = 17;
            this.wygrana7.Text = "X2";
            this.wygrana7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.przyciskGraj.Location = new System.Drawing.Point(343, 283);
            this.przyciskGraj.Name = "przyciskGraj";
            this.przyciskGraj.Size = new System.Drawing.Size(114, 39);
            this.przyciskGraj.TabIndex = 12;
            this.przyciskGraj.TabStop = false;
            this.przyciskGraj.Text = "Graj";
            this.przyciskGraj.UseVisualStyleBackColor = false;
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
            this.infoGra.Text = "Koło Fortuny";
            this.infoGra.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // OknoKoloFortuny
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(816, 489);
            this.MinimumSize = new System.Drawing.Size(816, 489);
            this.Name = "OknoKoloFortuny";
            this.ShowIcon = false;
            this.Text = "Koło Fortuny";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button przyciskGraj;
        private System.Windows.Forms.Label infoGra;
        private System.Windows.Forms.Label wygrana1;
        private System.Windows.Forms.Label wygrana0;
        private System.Windows.Forms.Label wygrana7;
        private System.Windows.Forms.Label wygrana4;
        private System.Windows.Forms.Label wygrana3;
        private System.Windows.Forms.Label wygrana2;
        private System.Windows.Forms.Label wygrana5;
        private System.Windows.Forms.Label wygrana6;
        private System.Windows.Forms.Label zaklad;
        private System.Windows.Forms.Label infoZaklad;
        private System.Windows.Forms.Label saldo;
        private System.Windows.Forms.Label infoSaldo;
    }
}