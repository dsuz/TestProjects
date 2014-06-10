using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestFSWatch
{
    class Program
    {
        static void Main(string[] args)
        {
            System.IO.FileSystemWatcher myWatcher =   new System.IO.FileSystemWatcher();
            //myWatcher.Changed += new System.IO.FileSystemEventHandler(this.myWatcher_Changed);


        }

        private void myWatcher_Changed(object sender,
System.IO.FileSystemEventArgs e)
        {
            string pathChanged = e.FullPath;
        }

    }
}
