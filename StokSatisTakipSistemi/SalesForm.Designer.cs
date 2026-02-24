namespace StokSatisTakipSistemi
{
    partial class SalesForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SalesForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbMusteri = new System.Windows.Forms.ComboBox();
            this.cmbUrun = new System.Windows.Forms.ComboBox();
            this.nmrcAdet = new System.Windows.Forms.NumericUpDown();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnEkle = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSatis = new System.Windows.Forms.Button();
            this.txtToplam = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.nmrcAdet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "Müşteri :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(43, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 37);
            this.label2.TabIndex = 1;
            this.label2.Text = "Ürün :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(45, 147);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 37);
            this.label3.TabIndex = 2;
            this.label3.Text = "Adet :";
            // 
            // cmbMusteri
            // 
            this.cmbMusteri.FormattingEnabled = true;
            this.cmbMusteri.Location = new System.Drawing.Point(157, 22);
            this.cmbMusteri.Name = "cmbMusteri";
            this.cmbMusteri.Size = new System.Drawing.Size(167, 45);
            this.cmbMusteri.TabIndex = 3;
            // 
            // cmbUrun
            // 
            this.cmbUrun.FormattingEnabled = true;
            this.cmbUrun.Location = new System.Drawing.Point(157, 84);
            this.cmbUrun.Name = "cmbUrun";
            this.cmbUrun.Size = new System.Drawing.Size(167, 45);
            this.cmbUrun.TabIndex = 4;
            // 
            // nmrcAdet
            // 
            this.nmrcAdet.Location = new System.Drawing.Point(157, 158);
            this.nmrcAdet.Name = "nmrcAdet";
            this.nmrcAdet.Size = new System.Drawing.Size(167, 43);
            this.nmrcAdet.TabIndex = 5;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(412, 22);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(431, 256);
            this.dataGridView1.TabIndex = 6;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // btnEkle
            // 
            this.btnEkle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEkle.Location = new System.Drawing.Point(69, 235);
            this.btnEkle.Name = "btnEkle";
            this.btnEkle.Size = new System.Drawing.Size(255, 43);
            this.btnEkle.TabIndex = 7;
            this.btnEkle.Text = "Sepete Ekle";
            this.btnEkle.UseVisualStyleBackColor = true;
            this.btnEkle.Click += new System.EventHandler(this.btnEkle_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 376);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(185, 37);
            this.label4.TabIndex = 8;
            this.label4.Text = "Toplam Tutar :";
            // 
            // btnSatis
            // 
            this.btnSatis.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSatis.Location = new System.Drawing.Point(69, 439);
            this.btnSatis.Name = "btnSatis";
            this.btnSatis.Size = new System.Drawing.Size(268, 49);
            this.btnSatis.TabIndex = 9;
            this.btnSatis.Text = "Satışı Tamamla";
            this.btnSatis.UseVisualStyleBackColor = true;
            this.btnSatis.Click += new System.EventHandler(this.btnSatis_Click);
            // 
            // txtToplam
            // 
            this.txtToplam.Location = new System.Drawing.Point(224, 376);
            this.txtToplam.Name = "txtToplam";
            this.txtToplam.Size = new System.Drawing.Size(147, 43);
            this.txtToplam.TabIndex = 10;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(460, 324);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(347, 178);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // SalesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 37F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Cyan;
            this.ClientSize = new System.Drawing.Size(844, 591);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txtToplam);
            this.Controls.Add(this.btnSatis);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnEkle);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.nmrcAdet);
            this.Controls.Add(this.cmbUrun);
            this.Controls.Add(this.cmbMusteri);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            this.Name = "SalesForm";
            this.Text = "SalesForm";
            this.Load += new System.EventHandler(this.SalesForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nmrcAdet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbMusteri;
        private System.Windows.Forms.ComboBox cmbUrun;
        private System.Windows.Forms.NumericUpDown nmrcAdet;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnEkle;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSatis;
        private System.Windows.Forms.TextBox txtToplam;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}