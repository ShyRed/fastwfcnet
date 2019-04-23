using FastWfcDemoApp.Model;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace FastWfcDemoApp
{
    /// <summary>
    /// Demo application main form.
    /// </summary>
    public partial class MainForm : Form, ILogger
    {
        /// <summary>
        /// Creates a new <see cref="MainForm"/>.
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initializes the panels.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            overlappingWfcPanel1.Logger = this;
            tilingWfcPanel1.Logger = this;
        }

        /// <summary>
        /// Logs a neutral message.
        /// </summary>
        /// <param name="msg">The message to log.</param>
        public void LogNeutral(string msg)
        {
            toolStripStatusLabelStatus.ForeColor = ForeColor;
            toolStripStatusLabelStatus.Text = msg;
        }

        /// <summary>
        /// Logs a success message.
        /// </summary>
        /// <param name="msg">The message to log.</param>
        public void LogSuccess(string msg)
        {
            toolStripStatusLabelStatus.ForeColor = Color.DarkGreen;
            toolStripStatusLabelStatus.Text = msg;
        }

        /// <summary>
        /// Logs a failure message.
        /// </summary>
        /// <param name="msg">The message to log.</param>
        public void LogFailure(string msg)
        {
            toolStripStatusLabelStatus.ForeColor = Color.DarkRed;
            toolStripStatusLabelStatus.Text = msg;
        }


        /// <summary>
        /// Opens the "fastwfcnet" repository in a web browser.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripStatusLabelVisitGithub_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/ShyRed/fastwfcnet");
        }

        /// <summary>
        /// Runs the WFC algorithm of the selected tab.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void buttonStart_Click(object sender, EventArgs e)
        {
            var selectedPanel = tabControlModel.SelectedTab.Controls[0] as IWfcPanel;
            if (selectedPanel == null)
                return;

            buttonStart.Enabled = false;
            await selectedPanel.RunWfc();
            buttonStart.Enabled = true;
        }
    }
}
