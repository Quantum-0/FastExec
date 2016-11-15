using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fast_Exec
{
    static class Program
    {
        internal static List<Exec> Execs;
        static NotifyIcon notifyIcon;
        static ContextMenuStrip contextMenuStrip;
        public static bool Working;
        private static KeyboardHooker kh;
        static Pixel KeyBlocker;

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Init();
            kh = new KeyboardHooker();
            kh.ExecuteListening += (s, e) =>
            {
                if (e)
                {
                    notifyIcon.ShowBalloonTip(1500, "Fast Exec", "Ожидание нажатия клавиши быстрого запуска", ToolTipIcon.Info);
                    KeyBlocker.Visible = true;
                    KeyBlocker.Activate();
                }
                else
                {
                    notifyIcon.ShowBalloonTip(500, "Fast Exec", "Быстрый запуск отменён", ToolTipIcon.Info);
                    KeyBlocker.Visible = false;
                }
            };
            kh.ExecuteButtonPressed += Kh_ExecuteButtonPressed;

            Application.Run();
            Application.ApplicationExit += (s, e) =>
            {
                notifyIcon.Dispose();
            };
        }

        private static void Kh_ExecuteButtonPressed(object sender, char e)
        {

            var Ex = Execs.Find(ex => ex.Key == e);
            if (Ex != null)
            {
                Process.Start(Ex.ExecPath);
                notifyIcon.ShowBalloonTip(500, "Запуск", "Запускается " + Ex.Name, ToolTipIcon.None);
            }
        }

        static void Init()
        {
            KeyBlocker = new Pixel();
            KeyBlocker.Show();
            KeyBlocker.Visible = false;

            if (File.Exists("config.cfg"))
                Load();
            else
                Execs = new List<Exec>();

            notifyIcon = new NotifyIcon();
            contextMenuStrip = new ContextMenuStrip();
            contextMenuStrip.SuspendLayout();

            notifyIcon.ContextMenuStrip = contextMenuStrip;
            Icon ico = Icon.ExtractAssociatedIcon(Assembly.GetExecutingAssembly().Location);
            notifyIcon.Icon = (ico);
            notifyIcon.Text = "Fast Exec";
            notifyIcon.Visible = true;
            notifyIcon.ShowBalloonTip(3000, "Fast Exec", "Fast Exec запущен", ToolTipIcon.Info);

            var toolStripMenuItem1 = new ToolStripMenuItem();
            var toolStripMenuItem2 = new ToolStripMenuItem();
            var toolStripMenuItem3 = new ToolStripMenuItem();
            contextMenuStrip.Items.AddRange(new ToolStripItem[] {
            toolStripMenuItem1,
            toolStripMenuItem2,
            toolStripMenuItem3});
            contextMenuStrip.Size = new System.Drawing.Size(160, 70);
            toolStripMenuItem1.Size = new System.Drawing.Size(159, 22);
            toolStripMenuItem1.Text = "Приостановить";
            toolStripMenuItem1.Click += StopOrResume;
            toolStripMenuItem2.Size = new System.Drawing.Size(159, 22);
            toolStripMenuItem2.Text = "Настройки";
            toolStripMenuItem2.Click += ToolStripMenuItem2_Click;
            toolStripMenuItem3.Size = new System.Drawing.Size(159, 22);
            toolStripMenuItem3.Text = "Выход";
            toolStripMenuItem3.Click += (s, e) =>
            {
                Save();
                Application.Exit();
            };
            contextMenuStrip.ResumeLayout(false);

            Working = true;
        }

        private static void StopOrResume(object sender, EventArgs e)
        {
            if (Working)
            {
                contextMenuStrip.Items[0].Text = "Возобновить";
                Working = false;
                kh.Pause();
            }
            else
            {
                contextMenuStrip.Items[0].Text = "Приостановить";
                Working = true;
                kh.Resume();
            }
        }

        private static void ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            (new Form1()).Show();
        }

        internal static void Save()
        {
            using (StreamWriter sw = new StreamWriter("config.cfg"))
            {
                foreach (var e in Execs)
                {
                    sw.WriteLine(e.Name);
                    sw.WriteLine(e.ExecPath);
                    sw.WriteLine(e.Key);
                }
            }
        }

        private static void Load()
        {
            using (StreamReader sr = new StreamReader("config.cfg"))
            {
                Execs = new List<Exec>();
                while (true)
                {
                    var Name = sr.ReadLine();
                    var ExecPath = sr.ReadLine();
                    var Key = sr.ReadLine();
                    if (Name == null || ExecPath == null || string.IsNullOrEmpty(Key))
                        break;
                    else
                        Execs.Add(new Exec() { Name = Name, ExecPath = ExecPath, Key = Key.FirstOrDefault() });
                }
            }
        }
    }
}
