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
    internal partial class FormEditing : Form
    {
        public Exec Current;

        public FormEditing(Exec Current = null)
        {
            InitializeComponent();
            this.Current = Current;
            if (Current != null)
            {
                textBox1.Text = Current.Name;
                textBox2.Text = Current.ExecPath;
                textBox3.Text = Current.Key.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Current = new Exec() { Name = textBox1.Text, ExecPath = textBox2.Text, Key = textBox3.Text.FirstOrDefault() };
            DialogResult = DialogResult.OK;
            Close();
        }

        private void radioButton_Click(object sender, EventArgs e)
        {
            textBoxApplication.Enabled = radioButtonApplication.Checked;
            textBoxFolder.Enabled = radioButtonFolder.Checked;
            textBoxLink.Enabled = radioButtonLink.Checked;

            if (radioButtonApplication.Checked)
                textBox2.Text = textBoxApplication.Text;
            else if (radioButtonFolder.Checked)
                textBox2.Text = "explorer " + "\"" + textBoxApplication.Text + "\"";
            else if (radioButtonApplication.Checked)
                textBox2.Text = textBoxApplication.Text; // сделать чтоб браузером открывалось
        }

        private void buttonChooseFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
                textBoxApplication.Text = openFileDialog.FileName;
        }

        private void buttonChooseFolder_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                textBoxFolder.Text = folderBrowserDialog.SelectedPath;
        }
    }
}
