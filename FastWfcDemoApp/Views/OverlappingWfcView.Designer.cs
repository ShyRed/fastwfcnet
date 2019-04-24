using FastWfcDemoApp.Controls;

namespace FastWfcDemoApp.Views
{
    partial class OverlappingWfcView
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
            this.splitContainerInputOutput = new System.Windows.Forms.SplitContainer();
            this.groupBoxInput = new System.Windows.Forms.GroupBox();
            this.pixelartBoxInput = new FastWfcDemoApp.Controls.PixelartBox();
            this.groupBoxOutput = new System.Windows.Forms.GroupBox();
            this.pixelartBoxOutput = new FastWfcDemoApp.Controls.PixelartBox();
            this.panelSettingsAndStartButton = new System.Windows.Forms.Panel();
            this.groupBoxSettings = new System.Windows.Forms.GroupBox();
            this.labelRetries = new System.Windows.Forms.Label();
            this.numericUpDownRetries = new System.Windows.Forms.NumericUpDown();
            this.buttonRandom = new System.Windows.Forms.Button();
            this.numericUpDownSeed = new System.Windows.Forms.NumericUpDown();
            this.labelRngSeed = new System.Windows.Forms.Label();
            this.labelPatternSize = new System.Windows.Forms.Label();
            this.numericUpDownPatternSize = new System.Windows.Forms.NumericUpDown();
            this.labelSymmetry = new System.Windows.Forms.Label();
            this.numericUpDownSymmetry = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownHeight = new System.Windows.Forms.NumericUpDown();
            this.labelX = new System.Windows.Forms.Label();
            this.numericUpDownWidth = new System.Windows.Forms.NumericUpDown();
            this.checkBoxGround = new System.Windows.Forms.CheckBox();
            this.labelSize = new System.Windows.Forms.Label();
            this.checkBoxPeriodicOutput = new System.Windows.Forms.CheckBox();
            this.checkBoxPeriodicInput = new System.Windows.Forms.CheckBox();
            this.saveFileDialogOutput = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialogInput = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerInputOutput)).BeginInit();
            this.splitContainerInputOutput.Panel1.SuspendLayout();
            this.splitContainerInputOutput.Panel2.SuspendLayout();
            this.splitContainerInputOutput.SuspendLayout();
            this.groupBoxInput.SuspendLayout();
            this.groupBoxOutput.SuspendLayout();
            this.panelSettingsAndStartButton.SuspendLayout();
            this.groupBoxSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRetries)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPatternSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSymmetry)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWidth)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerInputOutput
            // 
            this.splitContainerInputOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerInputOutput.Location = new System.Drawing.Point(0, 0);
            this.splitContainerInputOutput.Name = "splitContainerInputOutput";
            // 
            // splitContainerInputOutput.Panel1
            // 
            this.splitContainerInputOutput.Panel1.Controls.Add(this.groupBoxInput);
            // 
            // splitContainerInputOutput.Panel2
            // 
            this.splitContainerInputOutput.Panel2.Controls.Add(this.groupBoxOutput);
            this.splitContainerInputOutput.Size = new System.Drawing.Size(687, 445);
            this.splitContainerInputOutput.SplitterDistance = 339;
            this.splitContainerInputOutput.TabIndex = 9;
            // 
            // groupBoxInput
            // 
            this.groupBoxInput.Controls.Add(this.pixelartBoxInput);
            this.groupBoxInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxInput.Location = new System.Drawing.Point(0, 0);
            this.groupBoxInput.Name = "groupBoxInput";
            this.groupBoxInput.Size = new System.Drawing.Size(339, 445);
            this.groupBoxInput.TabIndex = 1;
            this.groupBoxInput.TabStop = false;
            this.groupBoxInput.Text = "Input";
            // 
            // pixelartBoxInput
            // 
            this.pixelartBoxInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pixelartBoxInput.Image = null;
            this.pixelartBoxInput.Location = new System.Drawing.Point(3, 16);
            this.pixelartBoxInput.Name = "pixelartBoxInput";
            this.pixelartBoxInput.Size = new System.Drawing.Size(333, 426);
            this.pixelartBoxInput.TabIndex = 0;
            this.pixelartBoxInput.Text = "Click here to select input image!";
            this.pixelartBoxInput.Click += new System.EventHandler(this.pixelartBoxInput_Click);
            // 
            // groupBoxOutput
            // 
            this.groupBoxOutput.Controls.Add(this.pixelartBoxOutput);
            this.groupBoxOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxOutput.Location = new System.Drawing.Point(0, 0);
            this.groupBoxOutput.Name = "groupBoxOutput";
            this.groupBoxOutput.Size = new System.Drawing.Size(344, 445);
            this.groupBoxOutput.TabIndex = 2;
            this.groupBoxOutput.TabStop = false;
            this.groupBoxOutput.Text = "Output";
            // 
            // pixelartBoxOutput
            // 
            this.pixelartBoxOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pixelartBoxOutput.Image = null;
            this.pixelartBoxOutput.Location = new System.Drawing.Point(3, 16);
            this.pixelartBoxOutput.Name = "pixelartBoxOutput";
            this.pixelartBoxOutput.Size = new System.Drawing.Size(338, 426);
            this.pixelartBoxOutput.TabIndex = 0;
            this.pixelartBoxOutput.Text = "Click here to save output image once it is generated!";
            this.pixelartBoxOutput.Click += new System.EventHandler(this.pixelartBoxOutput_Click);
            // 
            // panelSettingsAndStartButton
            // 
            this.panelSettingsAndStartButton.Controls.Add(this.groupBoxSettings);
            this.panelSettingsAndStartButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelSettingsAndStartButton.Location = new System.Drawing.Point(0, 445);
            this.panelSettingsAndStartButton.Name = "panelSettingsAndStartButton";
            this.panelSettingsAndStartButton.Padding = new System.Windows.Forms.Padding(3);
            this.panelSettingsAndStartButton.Size = new System.Drawing.Size(687, 103);
            this.panelSettingsAndStartButton.TabIndex = 7;
            // 
            // groupBoxSettings
            // 
            this.groupBoxSettings.Controls.Add(this.labelRetries);
            this.groupBoxSettings.Controls.Add(this.numericUpDownRetries);
            this.groupBoxSettings.Controls.Add(this.buttonRandom);
            this.groupBoxSettings.Controls.Add(this.numericUpDownSeed);
            this.groupBoxSettings.Controls.Add(this.labelRngSeed);
            this.groupBoxSettings.Controls.Add(this.labelPatternSize);
            this.groupBoxSettings.Controls.Add(this.numericUpDownPatternSize);
            this.groupBoxSettings.Controls.Add(this.labelSymmetry);
            this.groupBoxSettings.Controls.Add(this.numericUpDownSymmetry);
            this.groupBoxSettings.Controls.Add(this.numericUpDownHeight);
            this.groupBoxSettings.Controls.Add(this.labelX);
            this.groupBoxSettings.Controls.Add(this.numericUpDownWidth);
            this.groupBoxSettings.Controls.Add(this.checkBoxGround);
            this.groupBoxSettings.Controls.Add(this.labelSize);
            this.groupBoxSettings.Controls.Add(this.checkBoxPeriodicOutput);
            this.groupBoxSettings.Controls.Add(this.checkBoxPeriodicInput);
            this.groupBoxSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxSettings.Location = new System.Drawing.Point(3, 3);
            this.groupBoxSettings.Name = "groupBoxSettings";
            this.groupBoxSettings.Size = new System.Drawing.Size(681, 97);
            this.groupBoxSettings.TabIndex = 3;
            this.groupBoxSettings.TabStop = false;
            this.groupBoxSettings.Text = "Settings";
            // 
            // labelRetries
            // 
            this.labelRetries.AutoSize = true;
            this.labelRetries.Location = new System.Drawing.Point(402, 46);
            this.labelRetries.Name = "labelRetries";
            this.labelRetries.Size = new System.Drawing.Size(40, 13);
            this.labelRetries.TabIndex = 15;
            this.labelRetries.Text = "Retries";
            // 
            // numericUpDownRetries
            // 
            this.numericUpDownRetries.Location = new System.Drawing.Point(467, 44);
            this.numericUpDownRetries.Maximum = new decimal(new int[] {
            40,
            0,
            0,
            0});
            this.numericUpDownRetries.Name = "numericUpDownRetries";
            this.numericUpDownRetries.Size = new System.Drawing.Size(71, 20);
            this.numericUpDownRetries.TabIndex = 14;
            this.numericUpDownRetries.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // buttonRandom
            // 
            this.buttonRandom.Location = new System.Drawing.Point(612, 15);
            this.buttonRandom.Name = "buttonRandom";
            this.buttonRandom.Size = new System.Drawing.Size(56, 23);
            this.buttonRandom.TabIndex = 13;
            this.buttonRandom.Text = "Random";
            this.buttonRandom.UseVisualStyleBackColor = true;
            this.buttonRandom.Click += new System.EventHandler(this.buttonRandom_Click);
            // 
            // numericUpDownSeed
            // 
            this.numericUpDownSeed.Location = new System.Drawing.Point(467, 18);
            this.numericUpDownSeed.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.numericUpDownSeed.Name = "numericUpDownSeed";
            this.numericUpDownSeed.Size = new System.Drawing.Size(139, 20);
            this.numericUpDownSeed.TabIndex = 12;
            // 
            // labelRngSeed
            // 
            this.labelRngSeed.AutoSize = true;
            this.labelRngSeed.Location = new System.Drawing.Point(402, 20);
            this.labelRngSeed.Name = "labelRngSeed";
            this.labelRngSeed.Size = new System.Drawing.Size(59, 13);
            this.labelRngSeed.TabIndex = 11;
            this.labelRngSeed.Text = "RNG Seed";
            // 
            // labelPatternSize
            // 
            this.labelPatternSize.AutoSize = true;
            this.labelPatternSize.Location = new System.Drawing.Point(130, 46);
            this.labelPatternSize.Name = "labelPatternSize";
            this.labelPatternSize.Size = new System.Drawing.Size(64, 13);
            this.labelPatternSize.TabIndex = 10;
            this.labelPatternSize.Text = "Pattern Size";
            // 
            // numericUpDownPatternSize
            // 
            this.numericUpDownPatternSize.Location = new System.Drawing.Point(198, 44);
            this.numericUpDownPatternSize.Maximum = new decimal(new int[] {
            5,
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
            // labelSymmetry
            // 
            this.labelSymmetry.AutoSize = true;
            this.labelSymmetry.Location = new System.Drawing.Point(130, 72);
            this.labelSymmetry.Name = "labelSymmetry";
            this.labelSymmetry.Size = new System.Drawing.Size(52, 13);
            this.labelSymmetry.TabIndex = 8;
            this.labelSymmetry.Text = "Symmetry";
            // 
            // numericUpDownSymmetry
            // 
            this.numericUpDownSymmetry.Location = new System.Drawing.Point(198, 70);
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
            this.numericUpDownHeight.Location = new System.Drawing.Point(293, 18);
            this.numericUpDownHeight.Maximum = new decimal(new int[] {
            128,
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
            // labelX
            // 
            this.labelX.AutoSize = true;
            this.labelX.Location = new System.Drawing.Point(275, 20);
            this.labelX.Name = "labelX";
            this.labelX.Size = new System.Drawing.Size(12, 13);
            this.labelX.TabIndex = 5;
            this.labelX.Text = "x";
            // 
            // numericUpDownWidth
            // 
            this.numericUpDownWidth.Location = new System.Drawing.Point(198, 18);
            this.numericUpDownWidth.Maximum = new decimal(new int[] {
            128,
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
            this.checkBoxGround.Location = new System.Drawing.Point(6, 71);
            this.checkBoxGround.Name = "checkBoxGround";
            this.checkBoxGround.Size = new System.Drawing.Size(83, 17);
            this.checkBoxGround.TabIndex = 3;
            this.checkBoxGround.Text = "Use Ground";
            this.checkBoxGround.UseVisualStyleBackColor = true;
            // 
            // labelSize
            // 
            this.labelSize.AutoSize = true;
            this.labelSize.Location = new System.Drawing.Point(130, 20);
            this.labelSize.Name = "labelSize";
            this.labelSize.Size = new System.Drawing.Size(62, 13);
            this.labelSize.TabIndex = 2;
            this.labelSize.Text = "Output Size";
            // 
            // checkBoxPeriodicOutput
            // 
            this.checkBoxPeriodicOutput.AutoSize = true;
            this.checkBoxPeriodicOutput.Checked = true;
            this.checkBoxPeriodicOutput.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxPeriodicOutput.Location = new System.Drawing.Point(6, 45);
            this.checkBoxPeriodicOutput.Name = "checkBoxPeriodicOutput";
            this.checkBoxPeriodicOutput.Size = new System.Drawing.Size(99, 17);
            this.checkBoxPeriodicOutput.TabIndex = 1;
            this.checkBoxPeriodicOutput.Text = "Periodic Output";
            this.checkBoxPeriodicOutput.UseVisualStyleBackColor = true;
            // 
            // checkBoxPeriodicInput
            // 
            this.checkBoxPeriodicInput.AutoSize = true;
            this.checkBoxPeriodicInput.Checked = true;
            this.checkBoxPeriodicInput.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxPeriodicInput.Location = new System.Drawing.Point(6, 19);
            this.checkBoxPeriodicInput.Name = "checkBoxPeriodicInput";
            this.checkBoxPeriodicInput.Size = new System.Drawing.Size(91, 17);
            this.checkBoxPeriodicInput.TabIndex = 0;
            this.checkBoxPeriodicInput.Text = "Periodic Input";
            this.checkBoxPeriodicInput.UseVisualStyleBackColor = true;
            // 
            // saveFileDialogOutput
            // 
            this.saveFileDialogOutput.DefaultExt = "png";
            this.saveFileDialogOutput.Filter = "PNG files|*.png";
            this.saveFileDialogOutput.Title = "Select output image";
            // 
            // openFileDialogInput
            // 
            this.openFileDialogInput.DefaultExt = "png";
            this.openFileDialogInput.FileName = "openFileDialogInput";
            this.openFileDialogInput.Filter = "PNG files|*.png";
            this.openFileDialogInput.Title = "Select input image";
            // 
            // OverlappingWfcPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainerInputOutput);
            this.Controls.Add(this.panelSettingsAndStartButton);
            this.Name = "OverlappingWfcPanel";
            this.Size = new System.Drawing.Size(687, 548);
            this.splitContainerInputOutput.Panel1.ResumeLayout(false);
            this.splitContainerInputOutput.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerInputOutput)).EndInit();
            this.splitContainerInputOutput.ResumeLayout(false);
            this.groupBoxInput.ResumeLayout(false);
            this.groupBoxOutput.ResumeLayout(false);
            this.panelSettingsAndStartButton.ResumeLayout(false);
            this.groupBoxSettings.ResumeLayout(false);
            this.groupBoxSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRetries)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPatternSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSymmetry)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWidth)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.SplitContainer splitContainerInputOutput;
        private System.Windows.Forms.GroupBox groupBoxInput;
        private PixelartBox pixelartBoxInput;
        private System.Windows.Forms.GroupBox groupBoxOutput;
        private PixelartBox pixelartBoxOutput;
        private System.Windows.Forms.Panel panelSettingsAndStartButton;
        private System.Windows.Forms.GroupBox groupBoxSettings;
        private System.Windows.Forms.Label labelRetries;
        private System.Windows.Forms.NumericUpDown numericUpDownRetries;
        private System.Windows.Forms.Button buttonRandom;
        private System.Windows.Forms.NumericUpDown numericUpDownSeed;
        private System.Windows.Forms.Label labelRngSeed;
        private System.Windows.Forms.Label labelPatternSize;
        private System.Windows.Forms.NumericUpDown numericUpDownPatternSize;
        private System.Windows.Forms.Label labelSymmetry;
        private System.Windows.Forms.NumericUpDown numericUpDownSymmetry;
        private System.Windows.Forms.NumericUpDown numericUpDownHeight;
        private System.Windows.Forms.Label labelX;
        private System.Windows.Forms.NumericUpDown numericUpDownWidth;
        private System.Windows.Forms.CheckBox checkBoxGround;
        private System.Windows.Forms.Label labelSize;
        private System.Windows.Forms.CheckBox checkBoxPeriodicOutput;
        private System.Windows.Forms.CheckBox checkBoxPeriodicInput;
        private System.Windows.Forms.SaveFileDialog saveFileDialogOutput;
        private System.Windows.Forms.OpenFileDialog openFileDialogInput;
    }
}
