using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TestFSWatch2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            System.IO.FileSystemWatcher myWatcher = new System.IO.FileSystemWatcher();
            myWatcher.Path = @"E:\outgoing from Wabi\";
            //myWatcher.NotifyFilter = System.IO.NotifyFilters.LastWrite;
            myWatcher.Created += new System.IO.FileSystemEventHandler(this.myWatcher_Created);
            myWatcher.EnableRaisingEvents = true;

        }

        private void myWatcher_Created(object sender, System.IO.FileSystemEventArgs e)
        {
            string pathCreated = e.FullPath;
            //MessageBox.Show(pathCreated);

            this.notifyIcon1.BalloonTipTitle = "Title";
            this.notifyIcon1.BalloonTipText = pathCreated;
            this.notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;
            this.notifyIcon1.ShowBalloonTip(30000);
        }
    }
}
