using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace TestApp
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            try
            {
                textBox1.Text = Solids.Settings.DaemonIp;
                textBox2.Text = Solids.Settings.DaemonPort.ToString();
            } catch{}

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBox1.Text)) Solids.Settings.DaemonIp = textBox1.Text;
            if (!string.IsNullOrWhiteSpace(textBox2.Text)) Solids.Settings.DaemonPort = int.Parse(textBox2.Text);

            string json = JsonConvert.SerializeObject(Solids.Settings);
            File.WriteAllText("Rpcommand.settings",json);
        }
    }
}
