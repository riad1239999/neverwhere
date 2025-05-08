using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using EasyExploits;

namespace NeverwhereInjector1
{
    public partial class Form1 : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
            int nLeftRect,
            int nTopRect,
            int nRightRect,
            int nBottomRect,
            int nWidthEllipse,
            int nHeightEllipse
        );

        EasyExploits.Module NEVERWHERE = new EasyExploits.Module();

        public Form1()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));

            // Set background color to red
            this.BackColor = Color.Red;

            // Add "RiadExecuter" label at the top
            Label titleLabel = new Label();
            titleLabel.Text = "RiadExecuter";
            titleLabel.Font = new Font("Segoe UI", 18, FontStyle.Bold);
            titleLabel.ForeColor = Color.Red;
            titleLabel.BackColor = Color.Yellow;
            titleLabel.AutoSize = true;
            titleLabel.Location = new Point(10, 10);
            this.Controls.Add(titleLabel);

            // Update all buttons (if already added by InitializeComponent)
            foreach (Control control in this.Controls)
            {
                if (control is Button btn)
                {
                    btn.BackColor = Color.Yellow;
                    btn.ForeColor = Color.Red;
                    btn.FlatStyle = FlatStyle.Flat;
                }
            }
        }

        Point lastPoint;

        private void button1_Click(object sender, EventArgs e)
        {
            NEVERWHERE.ExecuteScript(scriptBox.Text);
            execButton.FlatStyle = FlatStyle.Flat;
            execButton.FlatAppearance.BorderSize = 0;
        }

        private void button5_Click(object sender, EventArgs e) { }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void minButton_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            scriptBox.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                openFileDialog1.Title = "Open";
                scriptBox.Text = File.ReadAllText(openFileDialog1.FileName);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ScriptHub openform = new ScriptHub();
            openform.Show();
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            Point lastPoint;
            lastPoint = new Point(e.X, e.Y);
        }

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void scriptList_SelectedIndexChanged(object sender, EventArgs e)
        {
            scriptBox.Text = File.ReadAllText($"./Scripts/{ScriptList.SelectedItem}");
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            ScriptList.Items.Clear();
            Functions.PopulateListBox(ScriptList, "./Scripts", "*.txt");
            Functions.PopulateListBox(ScriptList, "./Scripts", "*.lua");
        }

        public static void PopulateListBox(ListBox lsb, string Folder, string FileType)
        {
            DirectoryInfo dinfo = new DirectoryInfo(Folder);
            FileInfo[] Files = dinfo.GetFiles(FileType);
            foreach (FileInfo file in Files)
            {
                lsb.Items.Add(file.Name);
            }
        }

        private void Form1_Load(object sender, EventArgs e) { }

        private void button3_Click_1(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/WooxHimself/neverwhere/blob/main/README.md");
        }

        private void label5_Click(object sender, EventArgs e) { }

        class BorderlessButton : Button
        {
            protected override void OnPaint(PaintEventArgs pevent)
            {
                base.OnPaint(pevent);
                pevent.Graphics.DrawRectangle(new Pen(this.BackColor, 5), this.ClientRectangle);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e) { }

        private void button2_Click_1(object sender, EventArgs e)
        {
            NEVERWHERE.LaunchExploit();
        }

        private void killButton_Click(object sender, EventArgs e)
        {
            foreach (var process in Process.GetProcessesByName("RobloxPlayerBeta"))
            {
                process.Kill();
            }
        }

        private void supportButton_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://dsc.gg/neverwhere");
        }

        private void panel2_Paint(object sender, PaintEventArgs e) { }

        private void panel2_MouseEnter(object sender, EventArgs e) { }

        private void button3_Click_2(object sender, EventArgs e)
        {
            foreach (var process in Process.GetProcessesByName("RobloxPlayerBeta"))
            {
                process.Kill();
            }
        }
    }
}
