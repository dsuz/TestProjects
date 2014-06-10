namespace iTunesShortcuts
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmItemActivate = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.lblFwd5s = new System.Windows.Forms.Label();
            this.lblRwd5s = new System.Windows.Forms.Label();
            this.lblPrevTrk = new System.Windows.Forms.Label();
            this.lblNextTrk = new System.Windows.Forms.Label();
            this.lblFwd30s = new System.Windows.Forms.Label();
            this.lblRwd30s = new System.Windows.Forms.Label();
            this.lblVolUp = new System.Windows.Forms.Label();
            this.lblVolDown = new System.Windows.Forms.Label();
            this.lblPlayPause = new System.Windows.Forms.Label();
            this.lblActivateItunes = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblUpdatePodcasts = new System.Windows.Forms.Label();
            this.lblSyncIPods = new System.Windows.Forms.Label();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon1.BalloonTipText = "Press Ctrl + Alt + i to activate/deactivate";
            this.notifyIcon1.BalloonTipTitle = "iTunesShortcuts";
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "iTunesShortcuts";
            this.notifyIcon1.Visible = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmItemActivate,
            this.tsmItemExit});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(115, 48);
            // 
            // tsmItemActivate
            // 
            this.tsmItemActivate.Name = "tsmItemActivate";
            this.tsmItemActivate.Size = new System.Drawing.Size(114, 22);
            this.tsmItemActivate.Text = "Activate";
            this.tsmItemActivate.Click += new System.EventHandler(this.tsmItemActivate_Click);
            // 
            // tsmItemExit
            // 
            this.tsmItemExit.Name = "tsmItemExit";
            this.tsmItemExit.Size = new System.Drawing.Size(114, 22);
            this.tsmItemExit.Text = "Exit";
            this.tsmItemExit.Click += new System.EventHandler(this.tsmItemExit_Click);
            // 
            // lblFwd5s
            // 
            this.lblFwd5s.AutoSize = true;
            this.lblFwd5s.Location = new System.Drawing.Point(2, 44);
            this.lblFwd5s.Name = "lblFwd5s";
            this.lblFwd5s.Size = new System.Drawing.Size(133, 13);
            this.lblFwd5s.TabIndex = 1;
            this.lblFwd5s.Text = "Right : Forward 5 Seconds";
            // 
            // lblRwd5s
            // 
            this.lblRwd5s.AutoSize = true;
            this.lblRwd5s.Location = new System.Drawing.Point(2, 57);
            this.lblRwd5s.Name = "lblRwd5s";
            this.lblRwd5s.Size = new System.Drawing.Size(124, 13);
            this.lblRwd5s.TabIndex = 2;
            this.lblRwd5s.Text = "Left : Rewind 5 Seconds";
            // 
            // lblPrevTrk
            // 
            this.lblPrevTrk.AutoSize = true;
            this.lblPrevTrk.Location = new System.Drawing.Point(2, 96);
            this.lblPrevTrk.Name = "lblPrevTrk";
            this.lblPrevTrk.Size = new System.Drawing.Size(102, 13);
            this.lblPrevTrk.TabIndex = 3;
            this.lblPrevTrk.Text = "Up : Previous Track";
            // 
            // lblNextTrk
            // 
            this.lblNextTrk.AutoSize = true;
            this.lblNextTrk.Location = new System.Drawing.Point(2, 109);
            this.lblNextTrk.Name = "lblNextTrk";
            this.lblNextTrk.Size = new System.Drawing.Size(97, 13);
            this.lblNextTrk.TabIndex = 4;
            this.lblNextTrk.Text = "Down : Next Track";
            // 
            // lblFwd30s
            // 
            this.lblFwd30s.AutoSize = true;
            this.lblFwd30s.Location = new System.Drawing.Point(2, 70);
            this.lblFwd30s.Name = "lblFwd30s";
            this.lblFwd30s.Size = new System.Drawing.Size(239, 13);
            this.lblFwd30s.TabIndex = 5;
            this.lblFwd30s.Text = "Ctrl + Right / Wheel Down : Forward 30 Seconds";
            // 
            // lblRwd30s
            // 
            this.lblRwd30s.AutoSize = true;
            this.lblRwd30s.Location = new System.Drawing.Point(2, 83);
            this.lblRwd30s.Name = "lblRwd30s";
            this.lblRwd30s.Size = new System.Drawing.Size(216, 13);
            this.lblRwd30s.TabIndex = 6;
            this.lblRwd30s.Text = "Ctrl + Left / Wheel Up : Rewind 30 Seconds";
            // 
            // lblVolUp
            // 
            this.lblVolUp.AutoSize = true;
            this.lblVolUp.Location = new System.Drawing.Point(2, 122);
            this.lblVolUp.Name = "lblVolUp";
            this.lblVolUp.Size = new System.Drawing.Size(109, 13);
            this.lblVolUp.TabIndex = 7;
            this.lblVolUp.Text = "Ctrl + Up : Volume Up";
            // 
            // lblVolDown
            // 
            this.lblVolDown.AutoSize = true;
            this.lblVolDown.Location = new System.Drawing.Point(2, 135);
            this.lblVolDown.Name = "lblVolDown";
            this.lblVolDown.Size = new System.Drawing.Size(137, 13);
            this.lblVolDown.TabIndex = 8;
            this.lblVolDown.Text = "Ctrl + Down : Volume Down";
            // 
            // lblPlayPause
            // 
            this.lblPlayPause.AutoSize = true;
            this.lblPlayPause.Location = new System.Drawing.Point(2, 148);
            this.lblPlayPause.Name = "lblPlayPause";
            this.lblPlayPause.Size = new System.Drawing.Size(108, 13);
            this.lblPlayPause.TabIndex = 9;
            this.lblPlayPause.Text = "Space : Play / Pause";
            // 
            // lblActivateItunes
            // 
            this.lblActivateItunes.AutoSize = true;
            this.lblActivateItunes.Location = new System.Drawing.Point(2, 161);
            this.lblActivateItunes.Name = "lblActivateItunes";
            this.lblActivateItunes.Size = new System.Drawing.Size(149, 13);
            this.lblActivateItunes.TabIndex = 10;
            this.lblActivateItunes.Text = "I : Activate (bring front) iTunes";
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Location = new System.Drawing.Point(2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(239, 44);
            this.label1.TabIndex = 11;
            this.label1.Text = "To control iTunes by pressing the following keys while this window is active. Hit" +
                " Ctrl + Alt + i to activate/deactivate.";
            // 
            // lblUpdatePodcasts
            // 
            this.lblUpdatePodcasts.AutoSize = true;
            this.lblUpdatePodcasts.Location = new System.Drawing.Point(2, 174);
            this.lblUpdatePodcasts.Name = "lblUpdatePodcasts";
            this.lblUpdatePodcasts.Size = new System.Drawing.Size(106, 13);
            this.lblUpdatePodcasts.TabIndex = 12;
            this.lblUpdatePodcasts.Text = "U : Update Podcasts";
            // 
            // lblSyncIPods
            // 
            this.lblSyncIPods.AutoSize = true;
            this.lblSyncIPods.Location = new System.Drawing.Point(2, 187);
            this.lblSyncIPods.Name = "lblSyncIPods";
            this.lblSyncIPods.Size = new System.Drawing.Size(158, 13);
            this.lblSyncIPods.TabIndex = 13;
            this.lblSyncIPods.Text = "S : Sync all connected iDevices";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(245, 204);
            this.ControlBox = false;
            this.Controls.Add(this.lblSyncIPods);
            this.Controls.Add(this.lblUpdatePodcasts);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblRwd30s);
            this.Controls.Add(this.lblActivateItunes);
            this.Controls.Add(this.lblPlayPause);
            this.Controls.Add(this.lblVolDown);
            this.Controls.Add(this.lblVolUp);
            this.Controls.Add(this.lblFwd5s);
            this.Controls.Add(this.lblFwd30s);
            this.Controls.Add(this.lblNextTrk);
            this.Controls.Add(this.lblPrevTrk);
            this.Controls.Add(this.lblRwd5s);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Opacity = 0.9D;
            this.ShowInTaskbar = false;
            this.Text = "iTunesShortcuts";
            this.Deactivate += new System.EventHandler(this.Form1_Deactivate);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Scroll += new System.Windows.Forms.ScrollEventHandler(this.Form1_Scroll);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmItemActivate;
        private System.Windows.Forms.ToolStripMenuItem tsmItemExit;
        private System.Windows.Forms.Label lblFwd5s;
        private System.Windows.Forms.Label lblRwd5s;
        private System.Windows.Forms.Label lblPrevTrk;
        private System.Windows.Forms.Label lblNextTrk;
        private System.Windows.Forms.Label lblFwd30s;
        private System.Windows.Forms.Label lblRwd30s;
        private System.Windows.Forms.Label lblVolUp;
        private System.Windows.Forms.Label lblVolDown;
        private System.Windows.Forms.Label lblPlayPause;
        private System.Windows.Forms.Label lblActivateItunes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblUpdatePodcasts;
        private System.Windows.Forms.Label lblSyncIPods;
    }
}

