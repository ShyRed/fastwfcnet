namespace FastWfcDemoApp
{
    partial class TilingWfcPanel
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBoxSettings = new System.Windows.Forms.GroupBox();
            this.buttonLoadTileset = new System.Windows.Forms.Button();
            this.labelRetries = new System.Windows.Forms.Label();
            this.numericUpDownRetries = new System.Windows.Forms.NumericUpDown();
            this.buttonRandom = new System.Windows.Forms.Button();
            this.numericUpDownSeed = new System.Windows.Forms.NumericUpDown();
            this.labelRngSeed = new System.Windows.Forms.Label();
            this.numericUpDownHeight = new System.Windows.Forms.NumericUpDown();
            this.labelX = new System.Windows.Forms.Label();
            this.numericUpDownWidth = new System.Windows.Forms.NumericUpDown();
            this.labelSize = new System.Windows.Forms.Label();
            this.checkBoxPeriodicOutput = new System.Windows.Forms.CheckBox();
            this.groupBoxOutput = new System.Windows.Forms.GroupBox();
            this.pixelartBoxOutput = new FastWfcDemoApp.Controls.PixelartBox();
            this.openFileDialogTileset = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialogOutput = new System.Windows.Forms.SaveFileDialog();
            this.groupBoxSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRetries)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWidth)).BeginInit();
            this.groupBoxOutput.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxSettings
            // 
            this.groupBoxSettings.Controls.Add(this.buttonLoadTileset);
            this.groupBoxSettings.Controls.Add(this.labelRetries);
            this.groupBoxSettings.Controls.Add(this.numericUpDownRetries);
            this.groupBoxSettings.Controls.Add(this.buttonRandom);
            this.groupBoxSettings.Controls.Add(this.numericUpDownSeed);
            this.groupBoxSettings.Controls.Add(this.labelRngSeed);
            this.groupBoxSettings.Controls.Add(this.numericUpDownHeight);
            this.groupBoxSettings.Controls.Add(this.labelX);
            this.groupBoxSettings.Controls.Add(this.numericUpDownWidth);
            this.groupBoxSettings.Controls.Add(this.labelSize);
            this.groupBoxSettings.Controls.Add(this.checkBoxPeriodicOutput);
            this.groupBoxSettings.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBoxSettings.Location = new System.Drawing.Point(0, 349);
            this.groupBoxSettings.Name = "groupBoxSettings";
            this.groupBoxSettings.Size = new System.Drawing.Size(686, 78);
            this.groupBoxSettings.TabIndex = 0;
            this.groupBoxSettings.TabStop = false;
            this.groupBoxSettings.Text = "Settings";
            // 
            // buttonLoadTileset
            // 
            this.buttonLoadTileset.Location = new System.Drawing.Point(543, 15);
            this.buttonLoadTileset.Name = "buttonLoadTileset";
            this.buttonLoadTileset.Size = new System.Drawing.Size(125, 50);
            this.buttonLoadTileset.TabIndex = 26;
            this.buttonLoadTileset.Text = "Load Tileset";
            this.buttonLoadTileset.UseVisualStyleBackColor = true;
            this.buttonLoadTileset.Click += new System.EventHandler(this.buttonLoadTileset_Click);
            // 
            // labelRetries
            // 
            this.labelRetries.AutoSize = true;
            this.labelRetries.Location = new System.Drawing.Point(271, 47);
            this.labelRetries.Name = "labelRetries";
            this.labelRetries.Size = new System.Drawing.Size(40, 13);
            this.labelRetries.TabIndex = 25;
            this.labelRetries.Text = "Retries";
            // 
            // numericUpDownRetries
            // 
            this.numericUpDownRetries.Location = new System.Drawing.Point(336, 45);
            this.numericUpDownRetries.Maximum = new decimal(new int[] {
            40,
            0,
            0,
            0});
            this.numericUpDownRetries.Name = "numericUpDownRetries";
            this.numericUpDownRetries.Size = new System.Drawing.Size(71, 20);
            this.numericUpDownRetries.TabIndex = 24;
            this.numericUpDownRetries.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // buttonRandom
            // 
            this.buttonRandom.Location = new System.Drawing.Point(481, 16);
            this.buttonRandom.Name = "buttonRandom";
            this.buttonRandom.Size = new System.Drawing.Size(56, 23);
            this.buttonRandom.TabIndex = 23;
            this.buttonRandom.Text = "Random";
            this.buttonRandom.UseVisualStyleBackColor = true;
            this.buttonRandom.Click += new System.EventHandler(this.buttonRandom_Click);
            // 
            // numericUpDownSeed
            // 
            this.numericUpDownSeed.Location = new System.Drawing.Point(336, 19);
            this.numericUpDownSeed.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.numericUpDownSeed.Name = "numericUpDownSeed";
            this.numericUpDownSeed.Size = new System.Drawing.Size(139, 20);
            this.numericUpDownSeed.TabIndex = 22;
            // 
            // labelRngSeed
            // 
            this.labelRngSeed.AutoSize = true;
            this.labelRngSeed.Location = new System.Drawing.Point(271, 21);
            this.labelRngSeed.Name = "labelRngSeed";
            this.labelRngSeed.Size = new System.Drawing.Size(59, 13);
            this.labelRngSeed.TabIndex = 21;
            this.labelRngSeed.Text = "RNG Seed";
            // 
            // numericUpDownHeight
            // 
            this.numericUpDownHeight.Location = new System.Drawing.Point(168, 19);
            this.numericUpDownHeight.Maximum = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.numericUpDownHeight.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numericUpDownHeight.Name = "numericUpDownHeight";
            this.numericUpDownHeight.Size = new System.Drawing.Size(71, 20);
            this.numericUpDownHeight.TabIndex = 20;
            this.numericUpDownHeight.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // labelX
            // 
            this.labelX.AutoSize = true;
            this.labelX.Location = new System.Drawing.Point(150, 21);
            this.labelX.Name = "labelX";
            this.labelX.Size = new System.Drawing.Size(12, 13);
            this.labelX.TabIndex = 19;
            this.labelX.Text = "x";
            // 
            // numericUpDownWidth
            // 
            this.numericUpDownWidth.Location = new System.Drawing.Point(73, 19);
            this.numericUpDownWidth.Maximum = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.numericUpDownWidth.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numericUpDownWidth.Name = "numericUpDownWidth";
            this.numericUpDownWidth.Size = new System.Drawing.Size(71, 20);
            this.numericUpDownWidth.TabIndex = 18;
            this.numericUpDownWidth.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // labelSize
            // 
            this.labelSize.AutoSize = true;
            this.labelSize.Location = new System.Drawing.Point(5, 21);
            this.labelSize.Name = "labelSize";
            this.labelSize.Size = new System.Drawing.Size(62, 13);
            this.labelSize.TabIndex = 17;
            this.labelSize.Text = "Output Size";
            // 
            // checkBoxPeriodicOutput
            // 
            this.checkBoxPeriodicOutput.AutoSize = true;
            this.checkBoxPeriodicOutput.Checked = true;
            this.checkBoxPeriodicOutput.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxPeriodicOutput.Location = new System.Drawing.Point(8, 45);
            this.checkBoxPeriodicOutput.Name = "checkBoxPeriodicOutput";
            this.checkBoxPeriodicOutput.Size = new System.Drawing.Size(99, 17);
            this.checkBoxPeriodicOutput.TabIndex = 16;
            this.checkBoxPeriodicOutput.Text = "Periodic Output";
            this.checkBoxPeriodicOutput.UseVisualStyleBackColor = true;
            // 
            // groupBoxOutput
            // 
            this.groupBoxOutput.Controls.Add(this.pixelartBoxOutput);
            this.groupBoxOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxOutput.Location = new System.Drawing.Point(0, 0);
            this.groupBoxOutput.Name = "groupBoxOutput";
            this.groupBoxOutput.Size = new System.Drawing.Size(686, 349);
            this.groupBoxOutput.TabIndex = 1;
            this.groupBoxOutput.TabStop = false;
            this.groupBoxOutput.Text = "Output";
            // 
            // pixelartBoxOutput
            // 
            this.pixelartBoxOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pixelartBoxOutput.Image = null;
            this.pixelartBoxOutput.Location = new System.Drawing.Point(3, 16);
            this.pixelartBoxOutput.Name = "pixelartBoxOutput";
            this.pixelartBoxOutput.Size = new System.Drawing.Size(680, 330);
            this.pixelartBoxOutput.TabIndex = 0;
            this.pixelartBoxOutput.Text = "Click here to save output image once it is generated!";
            this.pixelartBoxOutput.Click += new System.EventHandler(this.pixelartBoxOutput_Click);
            // 
            // openFileDialogTileset
            // 
            this.openFileDialogTileset.DefaultExt = "xml";
            this.openFileDialogTileset.FileName = "data.xml";
            this.openFileDialogTileset.Filter = "XML files|*.xml";
            this.openFileDialogTileset.Title = "Select the tileset\'s data.xml file!";
            // 
            // saveFileDialogOutput
            // 
            this.saveFileDialogOutput.DefaultExt = "png";
            this.saveFileDialogOutput.Filter = "PNG files|*.png";
            this.saveFileDialogOutput.Title = "Select output image";
            // 
            // TilingWfcPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBoxOutput);
            this.Controls.Add(this.groupBoxSettings);
            this.Name = "TilingWfcPanel";
            this.Size = new System.Drawing.Size(686, 427);
            this.groupBoxSettings.ResumeLayout(false);
            this.groupBoxSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRetries)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWidth)).EndInit();
            this.groupBoxOutput.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxSettings;
        private System.Windows.Forms.Label labelRetries;
        private System.Windows.Forms.NumericUpDown numericUpDownRetries;
        private System.Windows.Forms.Button buttonRandom;
        private System.Windows.Forms.NumericUpDown numericUpDownSeed;
        private System.Windows.Forms.Label labelRngSeed;
        private System.Windows.Forms.NumericUpDown numericUpDownHeight;
        private System.Windows.Forms.Label labelX;
        private System.Windows.Forms.NumericUpDown numericUpDownWidth;
        private System.Windows.Forms.Label labelSize;
        private System.Windows.Forms.CheckBox checkBoxPeriodicOutput;
        private System.Windows.Forms.GroupBox groupBoxOutput;
        private Controls.PixelartBox pixelartBoxOutput;
        private System.Windows.Forms.Button buttonLoadTileset;
        private System.Windows.Forms.OpenFileDialog openFileDialogTileset;
        private System.Windows.Forms.SaveFileDialog saveFileDialogOutput;
    }
}
