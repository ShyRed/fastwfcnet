namespace FastWfcDemoApp
{
    partial class MainForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pixelartBoxInput = new FastWfcDemoApp.PixelartBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.pixelartBoxOutput = new FastWfcDemoApp.PixelartBox();
            this.openFileDialogInput = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialogOutput = new System.Windows.Forms.SaveFileDialog();
            this.groupBoxSettings = new System.Windows.Forms.GroupBox();
            this.numericUpDownSeed = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.numericUpDownPatternSize = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDownSymmetry = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownHeight = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDownWidth = new System.Windows.Forms.NumericUpDown();
            this.checkBoxGround = new System.Windows.Forms.CheckBox();
            this.labelSize = new System.Windows.Forms.Label();
            this.checkBoxPeriodicOutput = new System.Windows.Forms.CheckBox();
            this.checkBoxPeriodicInput = new System.Windows.Forms.CheckBox();
            this.buttonStart = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBoxSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPatternSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSymmetry)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWidth)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pixelartBoxInput);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(354, 343);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Input";
            // 
            // pixelartBoxInput
            // 
            this.pixelartBoxInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pixelartBoxInput.Image = null;
            this.pixelartBoxInput.Location = new System.Drawing.Point(3, 16);
            this.pixelartBoxInput.Name = "pixelartBoxInput";
            this.pixelartBoxInput.Size = new System.Drawing.Size(348, 324);
            this.pixelartBoxInput.TabIndex = 0;
            this.pixelartBoxInput.Text = "pixelartBox1";
            this.pixelartBoxInput.Click += new System.EventHandler(this.pixelartBoxInput_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.pixelartBoxOutput);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(355, 343);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Output";
            // 
            // pixelartBoxOutput
            // 
            this.pixelartBoxOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pixelartBoxOutput.Image = null;
            this.pixelartBoxOutput.Location = new System.Drawing.Point(3, 16);
            this.pixelartBoxOutput.Name = "pixelartBoxOutput";
            this.pixelartBoxOutput.Size = new System.Drawing.Size(349, 324);
            this.pixelartBoxOutput.TabIndex = 0;
            this.pixelartBoxOutput.Text = "pixelartBox1";
            this.pixelartBoxOutput.Click += new System.EventHandler(this.pixelartBoxOutput_Click);
            // 
            // openFileDialogInput
            // 
            this.openFileDialogInput.DefaultExt = "png";
            this.openFileDialogInput.FileName = "openFileDialogInput";
            this.openFileDialogInput.Filter = "PNG files|*.png";
            this.openFileDialogInput.Title = "Select input image";
            // 
            // saveFileDialogOutput
            // 
            this.saveFileDialogOutput.DefaultExt = "png";
            this.saveFileDialogOutput.Filter = "PNG files|*.png";
            this.saveFileDialogOutput.Title = "Select output image";
            // 
            // groupBoxSettings
            // 
            this.groupBoxSettings.Controls.Add(this.numericUpDownSeed);
            this.groupBoxSettings.Controls.Add(this.label4);
            this.groupBoxSettings.Controls.Add(this.label3);
            this.groupBoxSettings.Controls.Add(this.numericUpDownPatternSize);
            this.groupBoxSettings.Controls.Add(this.label2);
            this.groupBoxSettings.Controls.Add(this.numericUpDownSymmetry);
            this.groupBoxSettings.Controls.Add(this.numericUpDownHeight);
            this.groupBoxSettings.Controls.Add(this.label1);
            this.groupBoxSettings.Controls.Add(this.numericUpDownWidth);
            this.groupBoxSettings.Controls.Add(this.checkBoxGround);
            this.groupBoxSettings.Controls.Add(this.labelSize);
            this.groupBoxSettings.Controls.Add(this.checkBoxPeriodicOutput);
            this.groupBoxSettings.Controls.Add(this.checkBoxPeriodicInput);
            this.groupBoxSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxSettings.Location = new System.Drawing.Point(3, 3);
            this.groupBoxSettings.Name = "groupBoxSettings";
            this.groupBoxSettings.Size = new System.Drawing.Size(707, 145);
            this.groupBoxSettings.TabIndex = 3;
            this.groupBoxSettings.TabStop = false;
            this.groupBoxSettings.Text = "Settings";
            // 
            // numericUpDownSeed
            // 
            this.numericUpDownSeed.Location = new System.Drawing.Point(347, 96);
            this.numericUpDownSeed.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.numericUpDownSeed.Name = "numericUpDownSeed";
            this.numericUpDownSeed.Size = new System.Drawing.Size(168, 20);
            this.numericUpDownSeed.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(279, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "RNG Seed";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(279, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Pattern Size";
            // 
            // numericUpDownPatternSize
            // 
            this.numericUpDownPatternSize.Location = new System.Drawing.Point(347, 44);
            this.numericUpDownPatternSize.Maximum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.numericUpDownPatternSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownPatternSize.Name = "numericUpDownPatternSize";
            this.numericUpDownPatternSize.Size = new System.Drawing.Size(71, 20);
            this.numericUpDownPatternSize.TabIndex = 9;
            this.numericUpDownPatternSize.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(279, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Symmetry";
            // 
            // numericUpDownSymmetry
            // 
            this.numericUpDownSymmetry.Location = new System.Drawing.Point(347, 70);
            this.numericUpDownSymmetry.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.numericUpDownSymmetry.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownSymmetry.Name = "numericUpDownSymmetry";
            this.numericUpDownSymmetry.Size = new System.Drawing.Size(71, 20);
            this.numericUpDownSymmetry.TabIndex = 7;
            this.numericUpDownSymmetry.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numericUpDownHeight
            // 
            this.numericUpDownHeight.Location = new System.Drawing.Point(444, 18);
            this.numericUpDownHeight.Maximum = new decimal(new int[] {
            512,
            0,
            0,
            0});
            this.numericUpDownHeight.Minimum = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.numericUpDownHeight.Name = "numericUpDownHeight";
            this.numericUpDownHeight.Size = new System.Drawing.Size(71, 20);
            this.numericUpDownHeight.TabIndex = 6;
            this.numericUpDownHeight.Value = new decimal(new int[] {
            32,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(424, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "X";
            // 
            // numericUpDownWidth
            // 
            this.numericUpDownWidth.Location = new System.Drawing.Point(347, 18);
            this.numericUpDownWidth.Maximum = new decimal(new int[] {
            512,
            0,
            0,
            0});
            this.numericUpDownWidth.Minimum = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.numericUpDownWidth.Name = "numericUpDownWidth";
            this.numericUpDownWidth.Size = new System.Drawing.Size(71, 20);
            this.numericUpDownWidth.TabIndex = 4;
            this.numericUpDownWidth.Value = new decimal(new int[] {
            32,
            0,
            0,
            0});
            // 
            // checkBoxGround
            // 
            this.checkBoxGround.AutoSize = true;
            this.checkBoxGround.Location = new System.Drawing.Point(6, 65);
            this.checkBoxGround.Name = "checkBoxGround";
            this.checkBoxGround.Size = new System.Drawing.Size(83, 17);
            this.checkBoxGround.TabIndex = 3;
            this.checkBoxGround.Text = "Use Ground";
            this.checkBoxGround.UseVisualStyleBackColor = true;
            // 
            // labelSize
            // 
            this.labelSize.AutoSize = true;
            this.labelSize.Location = new System.Drawing.Point(279, 20);
            this.labelSize.Name = "labelSize";
            this.labelSize.Size = new System.Drawing.Size(62, 13);
            this.labelSize.TabIndex = 2;
            this.labelSize.Text = "Output Size";
            // 
            // checkBoxPeriodicOutput
            // 
            this.checkBoxPeriodicOutput.AutoSize = true;
            this.checkBoxPeriodicOutput.Location = new System.Drawing.Point(6, 42);
            this.checkBoxPeriodicOutput.Name = "checkBoxPeriodicOutput";
            this.checkBoxPeriodicOutput.Size = new System.Drawing.Size(99, 17);
            this.checkBoxPeriodicOutput.TabIndex = 1;
            this.checkBoxPeriodicOutput.Text = "Periodic Output";
            this.checkBoxPeriodicOutput.UseVisualStyleBackColor = true;
            // 
            // checkBoxPeriodicInput
            // 
            this.checkBoxPeriodicInput.AutoSize = true;
            this.checkBoxPeriodicInput.Location = new System.Drawing.Point(6, 19);
            this.checkBoxPeriodicInput.Name = "checkBoxPeriodicInput";
            this.checkBoxPeriodicInput.Size = new System.Drawing.Size(91, 17);
            this.checkBoxPeriodicInput.TabIndex = 0;
            this.checkBoxPeriodicInput.Text = "Periodic Input";
            this.checkBoxPeriodicInput.UseVisualStyleBackColor = true;
            // 
            // buttonStart
            // 
            this.buttonStart.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonStart.Enabled = false;
            this.buttonStart.Location = new System.Drawing.Point(3, 148);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(707, 23);
            this.buttonStart.TabIndex = 4;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBoxSettings);
            this.panel1.Controls.Add(this.buttonStart);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(3, 346);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(3);
            this.panel1.Size = new System.Drawing.Size(713, 174);
            this.panel1.TabIndex = 5;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer1.Size = new System.Drawing.Size(713, 343);
            this.splitContainer1.SplitterDistance = 354;
            this.splitContainer1.TabIndex = 6;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(719, 523);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel1);
            this.Name = "MainForm";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Text = "Fast Wfc Demo App";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBoxSettings.ResumeLayout(false);
            this.groupBoxSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPatternSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSymmetry)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWidth)).EndInit();
            this.panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.OpenFileDialog openFileDialogInput;
        private System.Windows.Forms.SaveFileDialog saveFileDialogOutput;
        private System.Windows.Forms.GroupBox groupBoxSettings;
        private System.Windows.Forms.CheckBox checkBoxPeriodicOutput;
        private System.Windows.Forms.CheckBox checkBoxPeriodicInput;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDownSymmetry;
        private System.Windows.Forms.NumericUpDown numericUpDownHeight;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDownWidth;
        private System.Windows.Forms.CheckBox checkBoxGround;
        private System.Windows.Forms.Label labelSize;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericUpDownPatternSize;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.NumericUpDown numericUpDownSeed;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private PixelartBox pixelartBoxInput;
        private PixelartBox pixelartBoxOutput;
    }
}

