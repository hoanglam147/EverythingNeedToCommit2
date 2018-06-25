using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
namespace TestFocusCalibration_GUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void startbut_Click(object sender, EventArgs e)
        {
            startbut.Enabled = false;
            stopbut.Enabled = false;
            if(iptxtbox.Text.Length == 0 || cfg1nametxt.Text.Length ==0 || cfg2nametxt.Text.Length == 0 || pon1txt.Text.Length == 0 || poff1txt.Text.Length == 0 || poff2txt.Text.Length == 0 || runtimetxt.Text.Length == 0)
            {
                MessageBox.Show("Plesae input right data");
            }
            else
            {
                System.Diagnostics.Process.Start(@"TestFocusAutolearn.exe", iptxtbox.Text + " " + cfg1nametxt.Text + " " + cfg2nametxt.Text + " " + pon1txt.Text + " " + poff1txt.Text + " " + pon2txt.Text + " " + poff2txt.Text + " " + runtimetxt.Text);
                Process[] current_GET = Process.GetProcessesByName("TestFocusAutolearn");
                while (current_GET.Length > 0)
                {
                    current_GET = Process.GetProcessesByName("TestFocusAutolearn");
                }
            }
            startbut.Enabled = true;
            stopbut.Enabled = true;
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void stopbut_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
