namespace ProyectoIA
{
    partial class RedNeuronal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RedNeuronal));
            this.labelIteration = new System.Windows.Forms.Label();
            this.labelTimer = new System.Windows.Forms.Label();
            this.labelError = new System.Windows.Forms.Label();
            this.buttonStop = new System.Windows.Forms.Button();
            this.groupBoxMatchedPattern = new System.Windows.Forms.GroupBox();
            this.labelMatchedLow = new System.Windows.Forms.Label();
            this.cmdentrenar = new System.Windows.Forms.Button();
            this.labelMatchedHigh = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBoxBajo = new System.Windows.Forms.PictureBox();
            this.cmdreconocer = new System.Windows.Forms.Button();
            this.pictureBoxAlto = new System.Windows.Forms.PictureBox();
            this.pictureBoxEntrada = new System.Windows.Forms.PictureBox();
            this.textBoxBrowse = new System.Windows.Forms.TextBox();
            this.buttonBrowse = new System.Windows.Forms.Button();
            this.grupoimagen = new System.Windows.Forms.GroupBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pictureBoxImgLocalizando = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.drawingPanel1 = new ProyectoIA.DrawingPanel();
            this.groupBoxMatchedPattern.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBajo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAlto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEntrada)).BeginInit();
            this.grupoimagen.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImgLocalizando)).BeginInit();
            this.SuspendLayout();
            // 
            // labelIteration
            // 
            this.labelIteration.AutoSize = true;
            this.labelIteration.Location = new System.Drawing.Point(120, 425);
            this.labelIteration.Name = "labelIteration";
            this.labelIteration.Size = new System.Drawing.Size(51, 13);
            this.labelIteration.TabIndex = 27;
            this.labelIteration.Text = "Iteracion:";
            // 
            // labelTimer
            // 
            this.labelTimer.AutoSize = true;
            this.labelTimer.Location = new System.Drawing.Point(203, 425);
            this.labelTimer.Name = "labelTimer";
            this.labelTimer.Size = new System.Drawing.Size(49, 13);
            this.labelTimer.TabIndex = 26;
            this.labelTimer.Text = "00:00:00";
            // 
            // labelError
            // 
            this.labelError.AutoSize = true;
            this.labelError.Location = new System.Drawing.Point(49, 425);
            this.labelError.Name = "labelError";
            this.labelError.Size = new System.Drawing.Size(32, 13);
            this.labelError.TabIndex = 25;
            this.labelError.Text = "Error:";
            // 
            // buttonStop
            // 
            this.buttonStop.Enabled = false;
            this.buttonStop.Location = new System.Drawing.Point(273, 420);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(86, 23);
            this.buttonStop.TabIndex = 24;
            this.buttonStop.Text = "Detener entrenamiento";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // groupBoxMatchedPattern
            // 
            this.groupBoxMatchedPattern.Controls.Add(this.labelMatchedLow);
            this.groupBoxMatchedPattern.Controls.Add(this.cmdentrenar);
            this.groupBoxMatchedPattern.Controls.Add(this.labelMatchedHigh);
            this.groupBoxMatchedPattern.Controls.Add(this.label2);
            this.groupBoxMatchedPattern.Controls.Add(this.pictureBoxBajo);
            this.groupBoxMatchedPattern.Controls.Add(this.cmdreconocer);
            this.groupBoxMatchedPattern.Controls.Add(this.pictureBoxAlto);
            this.groupBoxMatchedPattern.Controls.Add(this.pictureBoxEntrada);
            this.groupBoxMatchedPattern.Location = new System.Drawing.Point(16, 299);
            this.groupBoxMatchedPattern.Name = "groupBoxMatchedPattern";
            this.groupBoxMatchedPattern.Size = new System.Drawing.Size(383, 100);
            this.groupBoxMatchedPattern.TabIndex = 21;
            this.groupBoxMatchedPattern.TabStop = false;
            // 
            // labelMatchedLow
            // 
            this.labelMatchedLow.AutoSize = true;
            this.labelMatchedLow.Location = new System.Drawing.Point(192, 18);
            this.labelMatchedLow.Name = "labelMatchedLow";
            this.labelMatchedLow.Size = new System.Drawing.Size(65, 13);
            this.labelMatchedLow.TabIndex = 5;
            this.labelMatchedLow.Text = "Aproximado:";
            // 
            // cmdentrenar
            // 
            this.cmdentrenar.Location = new System.Drawing.Point(276, 19);
            this.cmdentrenar.Name = "cmdentrenar";
            this.cmdentrenar.Size = new System.Drawing.Size(90, 23);
            this.cmdentrenar.TabIndex = 16;
            this.cmdentrenar.Text = "Entrenar Red";
            this.cmdentrenar.UseVisualStyleBackColor = true;
            this.cmdentrenar.Click += new System.EventHandler(this.buttonTrain_Click);
            // 
            // labelMatchedHigh
            // 
            this.labelMatchedHigh.AutoSize = true;
            this.labelMatchedHigh.Location = new System.Drawing.Point(83, 18);
            this.labelMatchedHigh.Name = "labelMatchedHigh";
            this.labelMatchedHigh.Size = new System.Drawing.Size(65, 13);
            this.labelMatchedHigh.TabIndex = 4;
            this.labelMatchedHigh.Text = "Encontrado:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Entrada:";
            // 
            // pictureBoxBajo
            // 
            this.pictureBoxBajo.Location = new System.Drawing.Point(195, 35);
            this.pictureBoxBajo.Name = "pictureBoxBajo";
            this.pictureBoxBajo.Size = new System.Drawing.Size(30, 45);
            this.pictureBoxBajo.TabIndex = 2;
            this.pictureBoxBajo.TabStop = false;
            // 
            // cmdreconocer
            // 
            this.cmdreconocer.Enabled = false;
            this.cmdreconocer.Location = new System.Drawing.Point(276, 57);
            this.cmdreconocer.Name = "cmdreconocer";
            this.cmdreconocer.Size = new System.Drawing.Size(90, 23);
            this.cmdreconocer.TabIndex = 17;
            this.cmdreconocer.Text = "Reconocer patron";
            this.cmdreconocer.UseVisualStyleBackColor = true;
            this.cmdreconocer.Click += new System.EventHandler(this.buttonRecognize_Click);
            // 
            // pictureBoxAlto
            // 
            this.pictureBoxAlto.Location = new System.Drawing.Point(86, 35);
            this.pictureBoxAlto.Name = "pictureBoxAlto";
            this.pictureBoxAlto.Size = new System.Drawing.Size(30, 45);
            this.pictureBoxAlto.TabIndex = 1;
            this.pictureBoxAlto.TabStop = false;
            // 
            // pictureBoxEntrada
            // 
            this.pictureBoxEntrada.Location = new System.Drawing.Point(17, 35);
            this.pictureBoxEntrada.Name = "pictureBoxEntrada";
            this.pictureBoxEntrada.Size = new System.Drawing.Size(31, 45);
            this.pictureBoxEntrada.TabIndex = 0;
            this.pictureBoxEntrada.TabStop = false;
            // 
            // textBoxBrowse
            // 
            this.textBoxBrowse.Enabled = false;
            this.textBoxBrowse.Location = new System.Drawing.Point(51, 74);
            this.textBoxBrowse.Name = "textBoxBrowse";
            this.textBoxBrowse.Size = new System.Drawing.Size(248, 20);
            this.textBoxBrowse.TabIndex = 14;
            // 
            // buttonBrowse
            // 
            this.buttonBrowse.Enabled = false;
            this.buttonBrowse.Location = new System.Drawing.Point(306, 72);
            this.buttonBrowse.Name = "buttonBrowse";
            this.buttonBrowse.Size = new System.Drawing.Size(53, 23);
            this.buttonBrowse.TabIndex = 15;
            this.buttonBrowse.Text = "...";
            this.buttonBrowse.UseVisualStyleBackColor = true;
            this.buttonBrowse.Click += new System.EventHandler(this.buttonBrowse_Click);
            // 
            // grupoimagen
            // 
            this.grupoimagen.Controls.Add(this.drawingPanel1);
            this.grupoimagen.Location = new System.Drawing.Point(57, 114);
            this.grupoimagen.Name = "grupoimagen";
            this.grupoimagen.Size = new System.Drawing.Size(135, 179);
            this.grupoimagen.TabIndex = 10;
            this.grupoimagen.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pictureBoxImgLocalizando);
            this.groupBox1.Location = new System.Drawing.Point(211, 114);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(133, 179);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            // 
            // pictureBoxImgLocalizando
            // 
            this.pictureBoxImgLocalizando.BackColor = System.Drawing.Color.White;
            this.pictureBoxImgLocalizando.Location = new System.Drawing.Point(21, 31);
            this.pictureBoxImgLocalizando.Name = "pictureBoxImgLocalizando";
            this.pictureBoxImgLocalizando.Size = new System.Drawing.Size(86, 130);
            this.pictureBoxImgLocalizando.TabIndex = 0;
            this.pictureBoxImgLocalizando.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(56, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(330, 13);
            this.label1.TabIndex = 28;
            this.label1.Text = "DETECTOR DE PATRONES POR REDES NEURONALES";
            // 
            // drawingPanel1
            // 
            this.drawingPanel1.BackColor = System.Drawing.Color.White;
            this.drawingPanel1.ImageOnPanel = ((System.Drawing.Bitmap)(resources.GetObject("drawingPanel1.ImageOnPanel")));
            this.drawingPanel1.Location = new System.Drawing.Point(21, 31);
            this.drawingPanel1.Name = "drawingPanel1";
            this.drawingPanel1.PointSize = 18;
            this.drawingPanel1.Size = new System.Drawing.Size(86, 130);
            this.drawingPanel1.TabIndex = 0;
            // 
            // RedNeuronal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(436, 468);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.labelIteration);
            this.Controls.Add(this.labelTimer);
            this.Controls.Add(this.labelError);
            this.Controls.Add(this.grupoimagen);
            this.Controls.Add(this.buttonStop);
            this.Controls.Add(this.groupBoxMatchedPattern);
            this.Controls.Add(this.buttonBrowse);
            this.Controls.Add(this.textBoxBrowse);
            this.MaximizeBox = false;
            this.Name = "RedNeuronal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Neuronal";
            this.Load += new System.EventHandler(this.Neural_Load);
            this.groupBoxMatchedPattern.ResumeLayout(false);
            this.groupBoxMatchedPattern.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBajo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAlto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEntrada)).EndInit();
            this.grupoimagen.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImgLocalizando)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTimer;
        private System.Windows.Forms.Label labelError;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.GroupBox groupBoxMatchedPattern;
        private System.Windows.Forms.Label labelMatchedLow;
        private System.Windows.Forms.Label labelMatchedHigh;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBoxBajo;
        private System.Windows.Forms.PictureBox pictureBoxAlto;
        private System.Windows.Forms.PictureBox pictureBoxEntrada;
        private System.Windows.Forms.TextBox textBoxBrowse;
        private System.Windows.Forms.Button cmdreconocer;
        private System.Windows.Forms.Button cmdentrenar;
        private System.Windows.Forms.Button buttonBrowse;
        private System.Windows.Forms.GroupBox grupoimagen;
        private DrawingPanel drawingPanel1;
        private System.Windows.Forms.Label labelIteration;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pictureBoxImgLocalizando;
        private System.Windows.Forms.Label label1;

    }
}

