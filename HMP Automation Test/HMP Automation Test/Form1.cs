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
namespace HMP_Automation_Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void exitbut_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void startbut_Click(object sender, EventArgs e)
        {
            exitbut.Enabled = false;
            startbut.Enabled = false;
            string sheet_index;
            if(cbxDevice.Text =="M300N")
            {
                sheet_index = "1";
            }
            else if (cbxDevice.Text == "M220")
            {
                sheet_index = "2";
            }
            else
            {
                sheet_index = "2";
            }
            if(txtboxExcelPath.Text.Length == 0 || txtboxIPAdrr.Text.Length ==0)
            {
                MessageBox.Show("Plesae input right data");
            }
            else
            {
                System.Diagnostics.Process.Start(@"HMPAuto1.exe", txtboxExcelPath.Text + " " +  txtboxIPAdrr.Text + " " + sheet_index);
                Process[] current_GET = Process.GetProcessesByName("HMPAuto1");
                while (current_GET.Length > 0)
                {
                    current_GET = Process.GetProcessesByName("HMPAuto1");                   
                }
            }
            Process[] excel_GET = Process.GetProcessesByName("Excel");
            if(excel_GET.Length > 0)
            {
                for(int k = 0;k< excel_GET.Length;k++)
                {
                    excel_GET[k].Kill();
                }

            }
            exitbut.Enabled = true;
            startbut.Enabled = true;

        }

        private void cbxDevice_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void openbut_Click(object sender, EventArgs e)
        {

            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.ShowDialog();
            txtboxExcelPath.Text = openFileDialog1.FileName;
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }
    }
}
