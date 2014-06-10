using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using iTunesLib;
using System.Runtime.InteropServices;

/*
 * RegisterHotKey
 * http://www.pinvoke.net/default.aspx/user32.registerhotkey
 * http://www.atmarkit.co.jp/bbs/phpBB/viewtopic.php?topic=7531&forum=7
 * 
 * フォームをアクティブにする
 * http://dobon.net/vb/dotnet/form/activate.html
 * 
 * システムトレイ（タスクトレイ）にアイコンを表示するには？
 * http://www.atmarkit.co.jp/fdotnet/dotnettips/392notifyicon/notifyicon.html
*/
namespace iTunesShortcuts
{
    public partial class Form1 : Form
    {
        private iTunesApp iTunes;

        public Form1()
        {
            InitializeComponent();
        }

        // enable hotkey feature
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Keys k = Keys.I | Keys.Control | Keys.Alt;  // hotkey
            WindowsShell.RegisterHotKey(this, k);
        }

        // activate form on hotkey pressed
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == WindowsShell.WM_HOTKEY)
            {
                SwitchActiveState();
            }
        }

        // unregister hotkey feature
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            WindowsShell.UnregisterHotKey(this);

            notifyIcon1.Visible = false;
            notifyIcon1.Dispose();
        }

        private void SwitchActiveState()
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                if (this.Visible)
                    this.Visible = false;
                else
                {
                    this.Visible = true;
                    this.Activate();
                }
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
                this.Visible = true;
                this.Activate();
            }

            if (this.Visible)
                notifyIcon1.ShowBalloonTip(5, "iTunesShortCuts", "Activated", ToolTipIcon.Info);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            iTunes = new iTunesApp();

            // add mouse event handler to capture wheel up/down events
            this.MouseWheel += new MouseEventHandler(this.Form1_MouseWheel);

            notifyIcon1.ShowBalloonTip(30);
        }

        private void Form1_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                iTunes.PlayerPosition -= 30;
                FlashLabel(this.lblRwd30s);
            }
            else
            {
                iTunes.PlayerPosition += 30;
                FlashLabel(this.lblFwd30s);
            }
        }

        private void FlashLabel(Label obj)
        {
            Color buf = obj.ForeColor;
            Color buf2 = obj.BackColor;
            int cnt = 25;
            for (int i = 0; i < cnt; i++)
            {
                obj.ForeColor = Color.Crimson;
                obj.BackColor = Color.Yellow;
                obj.Refresh();
                obj.ForeColor = buf;
                obj.BackColor = buf2;
                obj.Refresh();
                System.Threading.Thread.Sleep(5);
            }
        }

        // update all iPods
        public static void SyncAlliPods()
        {
            iTunesApp iTunes = new iTunesApp();
            IITSourceCollection sources = iTunes.Sources;

            foreach (IITSource source in sources)
            {
                if (source.Kind == ITSourceKind.ITSourceKindIPod)
                {
                    ((IITIPodSource)source).UpdateIPod();
                }
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Right:
                    if (e.Control)
                    {
                        iTunes.PlayerPosition += 30;
                        FlashLabel(this.lblFwd30s);
                    }
                    else
                    {
                        iTunes.PlayerPosition += 5;
                        FlashLabel(this.lblFwd5s);
                    }
                    break;

                case Keys.Left:
                    if (e.Control)
                    {
                        iTunes.PlayerPosition -= 30;
                        FlashLabel(this.lblRwd30s);
                    }
                    else
                    {
                        iTunes.PlayerPosition -= 5;
                        FlashLabel(this.lblRwd5s);
                    }
                    break;

                case Keys.Up:
                    if (e.Control)
                    {
                        iTunes.SoundVolume = iTunes.SoundVolume + 4;
                        FlashLabel(this.lblVolUp);
                    }
                    else
                    {
                        iTunes.PreviousTrack();
                        FlashLabel(this.lblPrevTrk);
                    }
                    break;

                case Keys.Down:
                    if (e.Control)
                    {
                        iTunes.SoundVolume = iTunes.SoundVolume - 4;
                        FlashLabel(this.lblVolDown);
                    }
                    else
                    {
                        iTunes.NextTrack();
                        FlashLabel(this.lblNextTrk);
                    }
                    break;

                case Keys.Space:
                    iTunes.PlayPause();
                    FlashLabel(this.lblPlayPause);
                    break;

                case Keys.I:
                    WindowsShell.ActivateWindow("iTunes");
                    SwitchActiveState();
                    FlashLabel(this.lblActivateItunes);
                    break;

                case Keys.U:
                    iTunes.UpdatePodcastFeeds();
                    FlashLabel(this.lblUpdatePodcasts);
                    break;

                case Keys.S:
                    FlashLabel(this.lblSyncIPods);
                    SyncAlliPods();
                    break;
            }
        }

        private void tsmItemActivate_Click(object sender, EventArgs e)
        {
            SwitchActiveState();
        }

        private void tsmItemExit_Click(object sender, EventArgs e)
        {
            // exit = close form
            this.Close();
        }

        // junk
        private void Form1_Scroll(object sender, ScrollEventArgs e)
        {
            System.Diagnostics.Debug.Print("Old/New: " + e.OldValue.ToString() + "/" + e.NewValue.ToString());
        }

        private void Form1_Deactivate(object sender, EventArgs e)
        {
            //SwitchActiveState();
            this.Visible = false;
        }
    }

    class WindowsShell
    {
        #region fields
        public static int MOD_ALT = 0x1;
        public static int MOD_CONTROL = 0x2;
        public static int MOD_SHIFT = 0x4;
        public static int MOD_WIN = 0x8;
        public static int WM_HOTKEY = 0x312;
        #endregion

        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vlc);

        [DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        private static int keyId;
        
        public static void RegisterHotKey(Form f, Keys key)
        {
            int modifiers = 0;

            if ((key & Keys.Alt) == Keys.Alt)
                modifiers = modifiers | WindowsShell.MOD_ALT;

            if ((key & Keys.Control) == Keys.Control)
                modifiers = modifiers | WindowsShell.MOD_CONTROL;

            if ((key & Keys.Shift) == Keys.Shift)
                modifiers = modifiers | WindowsShell.MOD_SHIFT;

            Keys k = key & ~Keys.Control & ~Keys.Shift & ~Keys.Alt;

            Func ff = delegate()
            {
                keyId = f.GetHashCode(); // this should be a key unique ID, modify this if you want more than one hotkey
                RegisterHotKey((IntPtr)f.Handle, keyId, modifiers, (int)k);
            };

            f.Invoke(ff); // this should be checked if we really need it (InvokeRequired), but it's faster this way
        }

        private delegate void Func();

        public static void UnregisterHotKey(Form f)
        {
            try
            {
                Func ff = delegate()
                {
                    UnregisterHotKey(f.Handle, keyId); // modify this if you want more than one hotkey
                };

                f.Invoke(ff); // this should be checked if we really need it (InvokeRequired), but it's faster this way
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
            }
        }

        [DllImport("user32.dll",
            CharSet = System.Runtime.InteropServices.CharSet.Auto)]
        static extern IntPtr FindWindow(
            string lpClassName,
            string lpWindowName);

        [DllImport("user32.dll")]
        static extern bool SetForegroundWindow(IntPtr hWnd);

        /// <summary>
        /// 指定したウィンドウをアクティブにする
        /// </summary>
        /// <param name="winTitle">
        /// アクティブにするウィンドウのタイトル</param>
        public static void ActivateWindow(string winTitle)
        {
            IntPtr hWnd = FindWindow(null, winTitle);
            if (hWnd != IntPtr.Zero)
            {
                SetForegroundWindow(hWnd);
            }
        }
    }
}
