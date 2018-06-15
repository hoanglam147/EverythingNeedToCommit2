namespace HMP_Automation_Test
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.cbxDevice = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtboxIPAdrr = new System.Windows.Forms.TextBox();
            this.txtboxExcelPath = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.openbut = new System.Windows.Forms.Button();
            this.startbut = new System.Windows.Forms.Button();
            this.exitbut = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(19, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Device: ";
            // 
            // cbxDevice
            // 
            this.cbxDevice.FormattingEnabled = true;
            this.cbxDevice.Items.AddRange(new object[] {
            "M300N",
            "M220"});
            this.cbxDevice.Location = new System.Drawing.Point(232, 32);
            this.cbxDevice.Name = "cbxDevice";
            this.cbxDevice.Size = new System.Drawing.Size(127, 21);
            this.cbxDevice.TabIndex = 1;
            this.cbxDevice.SelectedIndexChanged += new System.EventHandler(this.cbxDevice_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(19, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(184, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "Excel Template File Path: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(19, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 19);
            this.label3.TabIndex = 4;
            this.label3.Text = "IP Adress: ";
            // 
            // txtboxIPAdrr
            // 
            this.txtboxIPAdrr.Location = new System.Drawing.Point(232, 71);
            this.txtboxIPAdrr.Name = "txtboxIPAdrr";
            this.txtboxIPAdrr.Size = new System.Drawing.Size(127, 20);
            this.txtboxIPAdrr.TabIndex = 5;
            this.txtboxIPAdrr.Text = "192.168.1.xxx";
            // 
            // txtboxExcelPath
            // 
            this.txtboxExcelPath.Location = new System.Drawing.Point(232, 104);
            this.txtboxExcelPath.Name = "txtboxExcelPath";
            this.txtboxExcelPath.Size = new System.Drawing.Size(164, 20);
            this.txtboxExcelPath.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(399, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 19);
            this.label4.TabIndex = 7;
            this.label4.Text = "Port:";
            // 
            // textBox3
            // 
            this.textBox3.Enabled = false;
            this.textBox3.Location = new System.Drawing.Point(447, 73);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(43, 20);
            this.textBox3.TabIndex = 8;
            this.textBox3.Text = "1023";
            // 
            // openbut
            // 
            this.openbut.Location = new System.Drawing.Point(447, 104);
            this.openbut.Name = "openbut";
            this.openbut.Size = new System.Drawing.Size(57, 23);
            this.openbut.TabIndex = 9;
            this.openbut.Text = "Open";
            this.openbut.UseVisualStyleBackColor = true;
            this.openbut.Click += new System.EventHandler(this.openbut_Click);
            // 
            // startbut
            // 
            this.startbut.Location = new System.Drawing.Point(355, 155);
            this.startbut.Name = "startbut";
            this.startbut.Size = new System.Drawing.Size(57, 23);
            this.startbut.TabIndex = 10;
            this.startbut.Text = "Start";
            this.startbut.UseVisualStyleBackColor = true;
            this.startbut.Click += new System.EventHandler(this.startbut_Click);
            // 
            // exitbut
            // 
            this.exitbut.Location = new System.Drawing.Point(447, 155);
            this.exitbut.Name = "exitbut";
            this.exitbut.Size = new System.Drawing.Size(57, 23);
            this.exitbut.TabIndex = 12;
            this.exitbut.Text = "Exit";
            this.exitbut.UseVisualStyleBackColor = true;
            this.exitbut.Click += new System.EventHandler(this.exitbut_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(542, 210);
            this.Controls.Add(this.exitbut);
            this.Controls.Add(this.startbut);
            this.Controls.Add(this.openbut);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtboxExcelPath);
            this.Controls.Add(this.txtboxIPAdrr);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbxDevice);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "HMP Test";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxDevice;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtboxIPAdrr;
        private System.Windows.Forms.TextBox txtboxExcelPath;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button openbut;
        private System.Windows.Forms.Button startbut;
        private System.Windows.Forms.Button exitbut;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}

