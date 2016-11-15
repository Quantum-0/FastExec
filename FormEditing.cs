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
                if (Current.ExecPath == "explorer")
                {
                    textBoxFolder.Text = Current.ExecArgs;
                    radioButtonFolder.Checked = true;
                }
                else if (Current.ExecPath == "chrome.exe")
                {
                    textBoxLink.Text = Current.ExecArgs;
                    radioButtonLink.Checked = true;
                }

                ExecuteChanged(this, EventArgs.Empty);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Current = new Exec() { Name = textBox1.Text, ExecPath = textBox2.Text, Key = textBox3.Text.FirstOrDefault() };
            if (radioButtonFolder.Checked)
                Current.ExecArgs = textBoxFolder.Text;
            else if (radioButtonLink.Checked)
                Current.ExecArgs = textBoxLink.Text;
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
                textBox2.Text = "explorer ";// + "\"" + textBoxApplication.Text + "\"";
            else if (radioButtonApplication.Checked)
                textBox2.Text = "chrome.exe";// ExecPathFromLink(textBoxApplication.Text);
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

        private void ExecuteChanged(object sender, EventArgs e)
        {
            if (sender == textBoxApplication)
                textBox2.Text = textBoxApplication.Text;
            else if (sender == textBoxFolder)
                textBox2.Text = "explorer";// + "\"" + textBoxApplication.Text + "\"";
            else if (sender == textBoxLink)
                textBox2.Text = "chrome.exe"; // ExecPathFromLink(textBoxApplication.Text);
        }

        private string ExecPathFromLink(string Link)
        {
            var browser = "chrome.exe";// GetDefaultBrowserPath();
            if (string.IsNullOrWhiteSpace(browser))
                return Link;
            else
                return browser + " \"" + Link + "\"";
        }

        private static string GetSystemDefaultBrowser()
        {
            string name = string.Empty;
            RegistryKey regKey = null;

            try
            {
                regKey = Registry.ClassesRoot.OpenSubKey("HTTP\\shell\\open\\command", false);
                name = regKey.GetValue(null).ToString().ToLower().Replace("\"", "");
                if (!name.EndsWith("exe"))
                    name = name.Substring(0, name.LastIndexOf(".exe") + 4);
            }
            catch (Exception)
            {
                //name = string.Format("ERROR: An exception of type: {0} occurred in method: {1} in the following module: {2}", ex.GetType(), ex.TargetSite, this.GetType());
            }
            finally
            {
                if (regKey != null)
                    regKey.Close();
            }
            return name;
        }

        private static string GetDefaultBrowserPath()
        {
            string urlAssociation = @"Software\Microsoft\Windows\Shell\Associations\UrlAssociations\http";
            string browserPathKey = @"$BROWSER$\shell\open\command";

            RegistryKey userChoiceKey = null;
            string browserPath = "";

            try
            {
                //Read default browser path from userChoiceLKey
                userChoiceKey = Registry.CurrentUser.OpenSubKey(urlAssociation + @"\UserChoice", false);

                //If user choice was not found, try machine default
                if (userChoiceKey == null)
                {
                    //Read default browser path from Win XP registry key
                    var browserKey = Registry.ClassesRoot.OpenSubKey(@"HTTP\shell\open\command", false);

                    //If browser path wasn’t found, try Win Vista (and newer) registry key
                    if (browserKey == null)
                    {
                        browserKey =
                        Registry.CurrentUser.OpenSubKey(
                        urlAssociation, false);
                    }
                    var path = browserKey.GetValue(null) as string;
                    browserKey.Close();
                    return path;
                }
                else
                {
                    // user defined browser choice was found
                    string progId = (userChoiceKey.GetValue("ProgId").ToString());
                    userChoiceKey.Close();

                    // now look up the path of the executable
                    string concreteBrowserKey = browserPathKey.Replace("$BROWSER$", progId);
                    var kp = Registry.ClassesRoot.OpenSubKey(concreteBrowserKey, false);
                    browserPath = kp.GetValue(null) as string;
                    kp.Close();
                    return browserPath;
                }
            }
            catch (Exception)
            {
                return "";
            }
        }
    }
}
