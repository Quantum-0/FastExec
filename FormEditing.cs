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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Current = new Exec() { Name = textBox1.Text, ExecPath = textBox2.Text, Key = textBox3.Text.FirstOrDefault() };
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
