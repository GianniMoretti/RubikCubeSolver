namespace RubikCube.UI
{
    partial class frmColorDetector
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
            this.components = new System.ComponentModel.Container();
            this.imgWebCam = new Emgu.CV.UI.ImageBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbColore = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.trk_Hue_Low = new System.Windows.Forms.TrackBar();
            this.trk_Staturation_Low = new System.Windows.Forms.TrackBar();
            this.trk_Value_Low = new System.Windows.Forms.TrackBar();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.trk_Hue_High = new System.Windows.Forms.TrackBar();
            this.trk_Saturation_High = new System.Windows.Forms.TrackBar();
            this.trk_Value_High = new System.Windows.Forms.TrackBar();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lbl_Hue_Low = new System.Windows.Forms.Label();
            this.lbl_Staturation_Low = new System.Windows.Forms.Label();
            this.lbl_Value_Low = new System.Windows.Forms.Label();
            this.lbl_Hue_High = new System.Windows.Forms.Label();
            this.lbl_Saturation_High = new System.Windows.Forms.Label();
            this.lbl_Value_High = new System.Windows.Forms.Label();
            this.btnSalvaValore = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.imgWebCam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trk_Hue_Low)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trk_Staturation_Low)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trk_Value_Low)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trk_Hue_High)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trk_Saturation_High)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trk_Value_High)).BeginInit();
            this.SuspendLayout();
            // 
            // imgWebCam
            // 
            this.imgWebCam.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.imgWebCam.Location = new System.Drawing.Point(12, 49);
            this.imgWebCam.Name = "imgWebCam";
            this.imgWebCam.Size = new System.Drawing.Size(395, 401);
            this.imgWebCam.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgWebCam.TabIndex = 3;
            this.imgWebCam.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 24);
            this.label1.TabIndex = 4;
            this.label1.Text = "ColorDetector";
            // 
            // cmbColore
            // 
            this.cmbColore.FormattingEnabled = true;
            this.cmbColore.Items.AddRange(new object[] {
            "Rosso",
            "Giallo",
            "Verde",
            "Blu",
            "Bianco",
            "Arancione"});
            this.cmbColore.Location = new System.Drawing.Point(434, 78);
            this.cmbColore.Name = "cmbColore";
            this.cmbColore.Size = new System.Drawing.Size(199, 21);
            this.cmbColore.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(430, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 24);
            this.label2.TabIndex = 6;
            this.label2.Text = "Scegli Colore";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(415, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 24);
            this.label3.TabIndex = 7;
            this.label3.Text = "Low";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(413, 277);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 24);
            this.label4.TabIndex = 8;
            this.label4.Text = "High";
            // 
            // trk_Hue_Low
            // 
            this.trk_Hue_Low.Location = new System.Drawing.Point(466, 164);
            this.trk_Hue_Low.Name = "trk_Hue_Low";
            this.trk_Hue_Low.Size = new System.Drawing.Size(301, 45);
            this.trk_Hue_Low.TabIndex = 9;
            // 
            // trk_Staturation_Low
            // 
            this.trk_Staturation_Low.Location = new System.Drawing.Point(466, 200);
            this.trk_Staturation_Low.Name = "trk_Staturation_Low";
            this.trk_Staturation_Low.Size = new System.Drawing.Size(301, 45);
            this.trk_Staturation_Low.TabIndex = 10;
            // 
            // trk_Value_Low
            // 
            this.trk_Value_Low.Location = new System.Drawing.Point(466, 238);
            this.trk_Value_Low.Name = "trk_Value_Low";
            this.trk_Value_Low.Size = new System.Drawing.Size(301, 45);
            this.trk_Value_Low.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(416, 164);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(27, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Hue";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(415, 200);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Saturation";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(414, 238);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Value";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(421, 324);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(27, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Hue";
            // 
            // trk_Hue_High
            // 
            this.trk_Hue_High.Location = new System.Drawing.Point(466, 324);
            this.trk_Hue_High.Name = "trk_Hue_High";
            this.trk_Hue_High.Size = new System.Drawing.Size(301, 45);
            this.trk_Hue_High.TabIndex = 16;
            // 
            // trk_Saturation_High
            // 
            this.trk_Saturation_High.Location = new System.Drawing.Point(466, 364);
            this.trk_Saturation_High.Name = "trk_Saturation_High";
            this.trk_Saturation_High.Size = new System.Drawing.Size(301, 45);
            this.trk_Saturation_High.TabIndex = 17;
            // 
            // trk_Value_High
            // 
            this.trk_Value_High.Location = new System.Drawing.Point(466, 405);
            this.trk_Value_High.Name = "trk_Value_High";
            this.trk_Value_High.Size = new System.Drawing.Size(301, 45);
            this.trk_Value_High.TabIndex = 18;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(416, 364);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(55, 13);
            this.label9.TabIndex = 19;
            this.label9.Text = "Saturation";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(416, 405);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(34, 13);
            this.label10.TabIndex = 20;
            this.label10.Text = "Value";
            // 
            // lbl_Hue_Low
            // 
            this.lbl_Hue_Low.AutoSize = true;
            this.lbl_Hue_Low.Location = new System.Drawing.Point(782, 164);
            this.lbl_Hue_Low.Name = "lbl_Hue_Low";
            this.lbl_Hue_Low.Size = new System.Drawing.Size(13, 13);
            this.lbl_Hue_Low.TabIndex = 21;
            this.lbl_Hue_Low.Text = "0";
            // 
            // lbl_Staturation_Low
            // 
            this.lbl_Staturation_Low.AutoSize = true;
            this.lbl_Staturation_Low.Location = new System.Drawing.Point(782, 200);
            this.lbl_Staturation_Low.Name = "lbl_Staturation_Low";
            this.lbl_Staturation_Low.Size = new System.Drawing.Size(13, 13);
            this.lbl_Staturation_Low.TabIndex = 22;
            this.lbl_Staturation_Low.Text = "0";
            // 
            // lbl_Value_Low
            // 
            this.lbl_Value_Low.AutoSize = true;
            this.lbl_Value_Low.Location = new System.Drawing.Point(782, 238);
            this.lbl_Value_Low.Name = "lbl_Value_Low";
            this.lbl_Value_Low.Size = new System.Drawing.Size(13, 13);
            this.lbl_Value_Low.TabIndex = 23;
            this.lbl_Value_Low.Text = "0";
            // 
            // lbl_Hue_High
            // 
            this.lbl_Hue_High.AutoSize = true;
            this.lbl_Hue_High.Location = new System.Drawing.Point(782, 324);
            this.lbl_Hue_High.Name = "lbl_Hue_High";
            this.lbl_Hue_High.Size = new System.Drawing.Size(13, 13);
            this.lbl_Hue_High.TabIndex = 24;
            this.lbl_Hue_High.Text = "0";
            // 
            // lbl_Saturation_High
            // 
            this.lbl_Saturation_High.AutoSize = true;
            this.lbl_Saturation_High.Location = new System.Drawing.Point(782, 364);
            this.lbl_Saturation_High.Name = "lbl_Saturation_High";
            this.lbl_Saturation_High.Size = new System.Drawing.Size(13, 13);
            this.lbl_Saturation_High.TabIndex = 25;
            this.lbl_Saturation_High.Text = "0";
            // 
            // lbl_Value_High
            // 
            this.lbl_Value_High.AutoSize = true;
            this.lbl_Value_High.Location = new System.Drawing.Point(782, 405);
            this.lbl_Value_High.Name = "lbl_Value_High";
            this.lbl_Value_High.Size = new System.Drawing.Size(13, 13);
            this.lbl_Value_High.TabIndex = 26;
            this.lbl_Value_High.Text = "0";
            // 
            // btnSalvaValore
            // 
            this.btnSalvaValore.Location = new System.Drawing.Point(424, 456);
            this.btnSalvaValore.Name = "btnSalvaValore";
            this.btnSalvaValore.Size = new System.Drawing.Size(371, 23);
            this.btnSalvaValore.TabIndex = 27;
            this.btnSalvaValore.Text = "Salva Valore";
            this.btnSalvaValore.UseVisualStyleBackColor = true;
            // 
            // frmColorDetector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(830, 490);
            this.Controls.Add(this.btnSalvaValore);
            this.Controls.Add(this.lbl_Value_High);
            this.Controls.Add(this.lbl_Saturation_High);
            this.Controls.Add(this.lbl_Hue_High);
            this.Controls.Add(this.lbl_Value_Low);
            this.Controls.Add(this.lbl_Staturation_Low);
            this.Controls.Add(this.lbl_Hue_Low);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.trk_Value_High);
            this.Controls.Add(this.trk_Saturation_High);
            this.Controls.Add(this.trk_Hue_High);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.trk_Value_Low);
            this.Controls.Add(this.trk_Staturation_Low);
            this.Controls.Add(this.trk_Hue_Low);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbColore);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.imgWebCam);
            this.Name = "frmColorDetector";
            this.Text = "frmColorDetector";
            ((System.ComponentModel.ISupportInitialize)(this.imgWebCam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trk_Hue_Low)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trk_Staturation_Low)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trk_Value_Low)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trk_Hue_High)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trk_Saturation_High)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trk_Value_High)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Emgu.CV.UI.ImageBox imgWebCam;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbColore;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TrackBar trk_Hue_Low;
        private System.Windows.Forms.TrackBar trk_Staturation_Low;
        private System.Windows.Forms.TrackBar trk_Value_Low;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TrackBar trk_Hue_High;
        private System.Windows.Forms.TrackBar trk_Saturation_High;
        private System.Windows.Forms.TrackBar trk_Value_High;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lbl_Hue_Low;
        private System.Windows.Forms.Label lbl_Staturation_Low;
        private System.Windows.Forms.Label lbl_Value_Low;
        private System.Windows.Forms.Label lbl_Hue_High;
        private System.Windows.Forms.Label lbl_Saturation_High;
        private System.Windows.Forms.Label lbl_Value_High;
        private System.Windows.Forms.Button btnSalvaValore;
    }
}