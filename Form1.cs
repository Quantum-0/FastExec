using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fast_Exec
{
    public partial class Form1 : Form
    {
        const string AutoRunName = "FastExec";
        RegistryKey rkAutorun = Registry.CurrentUser
            .OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
        public Form1()
        {
            InitializeComponent();
            UpdateList();

            if (rkAutorun.GetValue(AutoRunName) == null)
                buttonAddToAutorun.Text = "Добавить в автозагрузку";
            else
                buttonAddToAutorun.Text = "Удалить из автозагрузки";

        }

        private void UpdateList()
        {
            listBox.Items.Clear();
            foreach (var item in Program.Execs)
            {
                listBox.Items.Add(item);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var fe = new FormEditing();
            if (fe.ShowDialog() == DialogResult.OK)
            {
                Program.Execs.Add(fe.Current);
                UpdateList();                
            }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Program.Save();
            Application.Exit();
        }

        private void buttonAddToAutorun_Click(object sender, EventArgs e)
        {
            if (rkAutorun.GetValue(AutoRunName) == null)
            {
                buttonAddToAutorun.Text = "Удалить из автозагрузки";
                rkAutorun.SetValue(AutoRunName, Application.ExecutablePath.ToString());
            }
            else
            {
                rkAutorun.DeleteValue(AutoRunName, false);
                buttonAddToAutorun.Text = "Добавить в автозагрузку";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox.SelectedItem != null)
                Program.Execs.RemoveAt(listBox.SelectedIndex);

            UpdateList();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listBox.SelectedItem != null)
                return;

            var index = listBox.SelectedIndex;
            var fe = new FormEditing((Exec)listBox.SelectedItem);
            if (fe.ShowDialog() == DialogResult.OK)
            {
                Program.Execs[index] = fe.Current;
                UpdateList();
            }
        }
    }
}
