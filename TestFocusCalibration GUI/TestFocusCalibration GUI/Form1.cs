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
            string agrument;
            if (iptxtbox.Text.Length == 0 || 
                cfg1nametxt.Text.Length ==0 || 
                cfg2nametxt.Text.Length == 0 ||
                pon1txt.Text.Length == 0 || 
                poff1txt.Text.Length == 0 || 
                poff2txt.Text.Length == 0 || 
                runtimetxt.Text.Length == 0 || 
                txtpOn.Text.Length == 0 || 
                txtpOff.Text.Length == 0)
            {
                MessageBox.Show("Plesae input right data");
            }
            else
            {
                agrument = iptxtbox.Text + " ";
                agrument += cfg1nametxt.Text + " ";
                agrument += cfg2nametxt.Text + " ";
                agrument += pon1txt.Text + " ";
                agrument += poff1txt.Text + " ";
                agrument += pon2txt.Text + " ";
                agrument += poff2txt.Text + " ";
                agrument += runtimetxt.Text + " ";
                agrument += txtpOn.Text + " ";
                agrument += txtpOff.Text;
                System.Diagnostics.Process.Start(@"TestFocusAutolearn.exe", agrument);
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
