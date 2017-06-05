using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Linq;
using Newtonsoft.Json;
using UILibrary;

namespace TestApp
{
    /// <summary>
    /// Summary description for Form1.
    /// </summary>
    public class Form1 : System.Windows.Forms.Form
    {
        private UILibrary.ShellControl shellControl1;
        private string helpText;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem settingsToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem aboutRPCConsoleToolStripMenuItem;
        private TextBox textBox1;
        private TextBox textBox2;
        private Button button1;

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        public Form1()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            shellControl1.CommandEntered += new UILibrary.EventCommandEntered(shellControl1_CommandEntered);

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("RPCommandLine");
            stringBuilder.Append(System.Environment.NewLine);
            stringBuilder.Append("*******************************************");
            stringBuilder.Append(System.Environment.NewLine);
            
            helpText = stringBuilder.ToString();
            shellControl1.Prompt = "RPC:";
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
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
            this.shellControl1 = new UILibrary.ShellControl();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutRPCConsoleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // shellControl1
            // 
            this.shellControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.shellControl1.Location = new System.Drawing.Point(0, 24);
            this.shellControl1.Name = "shellControl1";
            this.shellControl1.Prompt = ">>>";
            this.shellControl1.ShellTextBackColor = System.Drawing.Color.Black;
            this.shellControl1.ShellTextFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.shellControl1.ShellTextForeColor = System.Drawing.Color.LimeGreen;
            this.shellControl1.Size = new System.Drawing.Size(634, 939);
            this.shellControl1.TabIndex = 0;
            this.shellControl1.Load += new System.EventHandler(this.shellControl1_Load);
            this.shellControl1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.shellControl1_KeyPress);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1107, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutRPCConsoleToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutRPCConsoleToolStripMenuItem
            // 
            this.aboutRPCConsoleToolStripMenuItem.Name = "aboutRPCConsoleToolStripMenuItem";
            this.aboutRPCConsoleToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.aboutRPCConsoleToolStripMenuItem.Text = "About RPCConsole";
            this.aboutRPCConsoleToolStripMenuItem.Click += new System.EventHandler(this.aboutRPCConsoleToolStripMenuItem_Click);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(640, 32);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(445, 20);
            this.textBox1.TabIndex = 2;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // textBox2
            // 
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox2.Location = new System.Drawing.Point(640, 58);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(445, 857);
            this.textBox2.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(641, 922);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(444, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Execute";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(1107, 963);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.shellControl1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "RPConsole";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.Run(new Form1());
        }

        void shellControl1_CommandEntered(object sender, UILibrary.CommandEnteredEventArgs e)
        {
            string command = e.Command;

            ProcessInternalCommand(command);
        }

        private bool ProcessInternalCommand(string command)
        {
            textBox1.Text = command;
            string[] parts = command.Split(new char[] { ' ' });
            string cmd = parts[0];
            List<string> prms = parts.ToList();
            prms.RemoveAt(0);

            string json = Helpers.MakeJson(cmd, prms);

                string output = Helpers.RequestServer(Solids.Settings.DaemonIp, Solids.Settings.DaemonPort, "", "",json);
            shellControl1.WriteText(output);

            return true;
        }

        private string GetHelpText()
        {
            return helpText;
        }

        private void shellControl1_Load(object sender, EventArgs e)
        {
            try
            {
                string json = File.ReadAllText("Rpcommand.settings");
                Solids.Settings = JsonConvert.DeserializeObject<Settings>(json);
            } catch{}
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string inp = textBox1.Text;

            string[] parts = inp.Split(new char[] { ' ' });
            string cmd = parts[0];
            List<string> prms = parts.ToList();
            prms.RemoveAt(0);

            textBox2.Text = Helpers.MakeJson(cmd, prms);

        }

        private void shellControl1_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBox1.Text = shellControl1.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string output = Helpers.RequestServer(Solids.Settings.DaemonIp, Solids.Settings.DaemonPort, "", "", textBox2.Text);
            shellControl1.WriteText(output);
        }

        private SettingsForm settings;
        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                settings.Close();
            }
            catch
            {
            }

            settings=new SettingsForm();

            settings.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                settings.Close();
            }
            catch
            {
            }

            this.Close();
        }

        private void manualToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private AboutScreen about;
        private void aboutRPCConsoleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                about.Close();
            }
            catch
            {
            }

            about=new AboutScreen();
            about.Show();
        }
    }
}
