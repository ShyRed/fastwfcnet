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
            this.statusStripMain = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelVisitGithub = new System.Windows.Forms.ToolStripStatusLabel();
            this.buttonStart = new System.Windows.Forms.Button();
            this.tabControlModel = new System.Windows.Forms.TabControl();
            this.tabPageOverlappingModel = new System.Windows.Forms.TabPage();
            this.overlappingWfcPanel1 = new FastWfcDemoApp.OverlappingWfcPanel();
            this.tabPageTilingModel = new System.Windows.Forms.TabPage();
            this.tilingWfcPanel1 = new FastWfcDemoApp.TilingWfcPanel();
            this.statusStripMain.SuspendLayout();
            this.tabControlModel.SuspendLayout();
            this.tabPageOverlappingModel.SuspendLayout();
            this.tabPageTilingModel.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStripMain
            // 
            this.statusStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelStatus,
            this.toolStripStatusLabelVisitGithub});
            this.statusStripMain.Location = new System.Drawing.Point(0, 479);
            this.statusStripMain.Name = "statusStripMain";
            this.statusStripMain.Size = new System.Drawing.Size(719, 22);
            this.statusStripMain.TabIndex = 9;
            this.statusStripMain.Text = "statusStrip1";
            // 
            // toolStripStatusLabelStatus
            // 
            this.toolStripStatusLabelStatus.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatusLabelStatus.Name = "toolStripStatusLabelStatus";
            this.toolStripStatusLabelStatus.Size = new System.Drawing.Size(63, 17);
            this.toolStripStatusLabelStatus.Text = "Ready...";
            // 
            // toolStripStatusLabelVisitGithub
            // 
            this.toolStripStatusLabelVisitGithub.IsLink = true;
            this.toolStripStatusLabelVisitGithub.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.toolStripStatusLabelVisitGithub.Name = "toolStripStatusLabelVisitGithub";
            this.toolStripStatusLabelVisitGithub.Size = new System.Drawing.Size(641, 17);
            this.toolStripStatusLabelVisitGithub.Spring = true;
            this.toolStripStatusLabelVisitGithub.Text = "Visit this project on GitHub";
            this.toolStripStatusLabelVisitGithub.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // buttonStart
            // 
            this.buttonStart.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonStart.Location = new System.Drawing.Point(0, 444);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(719, 35);
            this.buttonStart.TabIndex = 10;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // tabControlModel
            // 
            this.tabControlModel.Controls.Add(this.tabPageOverlappingModel);
            this.tabControlModel.Controls.Add(this.tabPageTilingModel);
            this.tabControlModel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlModel.Location = new System.Drawing.Point(0, 0);
            this.tabControlModel.Name = "tabControlModel";
            this.tabControlModel.SelectedIndex = 0;
            this.tabControlModel.Size = new System.Drawing.Size(719, 444);
            this.tabControlModel.TabIndex = 11;
            // 
            // tabPageOverlappingModel
            // 
            this.tabPageOverlappingModel.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageOverlappingModel.Controls.Add(this.overlappingWfcPanel1);
            this.tabPageOverlappingModel.Location = new System.Drawing.Point(4, 22);
            this.tabPageOverlappingModel.Name = "tabPageOverlappingModel";
            this.tabPageOverlappingModel.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageOverlappingModel.Size = new System.Drawing.Size(711, 418);
            this.tabPageOverlappingModel.TabIndex = 0;
            this.tabPageOverlappingModel.Text = "Overlapping Model";
            // 
            // overlappingWfcPanel1
            // 
            this.overlappingWfcPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.overlappingWfcPanel1.Location = new System.Drawing.Point(3, 3);
            this.overlappingWfcPanel1.Name = "overlappingWfcPanel1";
            this.overlappingWfcPanel1.Size = new System.Drawing.Size(705, 412);
            this.overlappingWfcPanel1.TabIndex = 0;
            // 
            // tabPageTilingModel
            // 
            this.tabPageTilingModel.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageTilingModel.Controls.Add(this.tilingWfcPanel1);
            this.tabPageTilingModel.Location = new System.Drawing.Point(4, 22);
            this.tabPageTilingModel.Name = "tabPageTilingModel";
            this.tabPageTilingModel.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageTilingModel.Size = new System.Drawing.Size(711, 418);
            this.tabPageTilingModel.TabIndex = 1;
            this.tabPageTilingModel.Text = "Tiling Model";
            // 
            // tilingWfcPanel1
            // 
            this.tilingWfcPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tilingWfcPanel1.Location = new System.Drawing.Point(3, 3);
            this.tilingWfcPanel1.Name = "tilingWfcPanel1";
            this.tilingWfcPanel1.Size = new System.Drawing.Size(705, 412);
            this.tilingWfcPanel1.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(719, 501);
            this.Controls.Add(this.tabControlModel);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.statusStripMain);
            this.MinimumSize = new System.Drawing.Size(735, 518);
            this.Name = "MainForm";
            this.Text = "Fast Wfc Demo App";
            this.statusStripMain.ResumeLayout(false);
            this.statusStripMain.PerformLayout();
            this.tabControlModel.ResumeLayout(false);
            this.tabPageOverlappingModel.ResumeLayout(false);
            this.tabPageTilingModel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStripMain;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelStatus;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelVisitGithub;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.TabControl tabControlModel;
        private System.Windows.Forms.TabPage tabPageOverlappingModel;
        private System.Windows.Forms.TabPage tabPageTilingModel;
        private OverlappingWfcPanel overlappingWfcPanel1;
        private TilingWfcPanel tilingWfcPanel1;
    }
}

