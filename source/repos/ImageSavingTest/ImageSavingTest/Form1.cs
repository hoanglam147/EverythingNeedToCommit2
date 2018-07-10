using System;
using System.Windows.Forms;
using DeviceConnection;
using System.Threading;
namespace ImageSavingTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClientConnection x = new ClientConnection("192.168.1.145", 51236);
            x.Open();
            while(true)
            {
                x.SendString("T1");
                Thread.Sleep(200);
                x.SendString("T2");
                Thread.Sleep(200);
            }
        }
    }
}
