namespace ImageSavingTest
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.textboxIP1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textboxIP2 = new System.Windows.Forms.TextBox();
            this.textboxIP3 = new System.Windows.Forms.TextBox();
            this.textboxIP4 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textboxport = new System.Windows.Forms.TextBox();
            this.radioPhase = new System.Windows.Forms.RadioButton();
            this.radioOneShot = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.waterMarkTextBox4 = new ImageSavingTest.WaterMarkTextBox();
            this.waterMarkTextBox3 = new ImageSavingTest.WaterMarkTextBox();
            this.waterMarkTextBox2 = new ImageSavingTest.WaterMarkTextBox();
            this.waterMarkTextBox1 = new ImageSavingTest.WaterMarkTextBox();
            this.waterMarkTextBox5 = new ImageSavingTest.WaterMarkTextBox();
            this.waterMarkTextBox6 = new ImageSavingTest.WaterMarkTextBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(460, 243);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(109, 68);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(587, 243);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(97, 64);
            this.button2.TabIndex = 1;
            this.button2.Text = "Stop";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textboxIP1
            // 
            this.textboxIP1.Location = new System.Drawing.Point(172, 66);
            this.textboxIP1.Name = "textboxIP1";
            this.textboxIP1.Size = new System.Drawing.Size(45, 20);
            this.textboxIP1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(88, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "IP Address";
            // 
            // textboxIP2
            // 
            this.textboxIP2.Location = new System.Drawing.Point(223, 66);
            this.textboxIP2.Name = "textboxIP2";
            this.textboxIP2.Size = new System.Drawing.Size(45, 20);
            this.textboxIP2.TabIndex = 4;
            // 
            // textboxIP3
            // 
            this.textboxIP3.Location = new System.Drawing.Point(274, 66);
            this.textboxIP3.Name = "textboxIP3";
            this.textboxIP3.Size = new System.Drawing.Size(45, 20);
            this.textboxIP3.TabIndex = 5;
            // 
            // textboxIP4
            // 
            this.textboxIP4.Location = new System.Drawing.Point(325, 66);
            this.textboxIP4.Name = "textboxIP4";
            this.textboxIP4.Size = new System.Drawing.Size(45, 20);
            this.textboxIP4.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(88, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Port";
            // 
            // textboxport
            // 
            this.textboxport.Location = new System.Drawing.Point(172, 92);
            this.textboxport.Name = "textboxport";
            this.textboxport.Size = new System.Drawing.Size(45, 20);
            this.textboxport.TabIndex = 8;
            // 
            // radioPhase
            // 
            this.radioPhase.AutoSize = true;
            this.radioPhase.Location = new System.Drawing.Point(91, 133);
            this.radioPhase.Name = "radioPhase";
            this.radioPhase.Size = new System.Drawing.Size(82, 17);
            this.radioPhase.TabIndex = 10;
            this.radioPhase.TabStop = true;
            this.radioPhase.Text = "PhaseMode";
            this.radioPhase.UseVisualStyleBackColor = true;
            // 
            // radioOneShot
            // 
            this.radioOneShot.AutoSize = true;
            this.radioOneShot.Location = new System.Drawing.Point(91, 156);
            this.radioOneShot.Name = "radioOneShot";
            this.radioOneShot.Size = new System.Drawing.Size(67, 17);
            this.radioOneShot.TabIndex = 11;
            this.radioOneShot.TabStop = true;
            this.radioOneShot.Text = "OneShot";
            this.radioOneShot.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(91, 179);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(78, 17);
            this.radioButton1.TabIndex = 9;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Continuous";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // waterMarkTextBox4
            // 
            this.waterMarkTextBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.waterMarkTextBox4.Location = new System.Drawing.Point(496, 133);
            this.waterMarkTextBox4.Name = "waterMarkTextBox4";
            this.waterMarkTextBox4.Size = new System.Drawing.Size(83, 20);
            this.waterMarkTextBox4.TabIndex = 19;
            this.waterMarkTextBox4.WaterMarkColor = System.Drawing.Color.Gray;
            this.waterMarkTextBox4.WaterMarkText = "off phase time";
            // 
            // waterMarkTextBox3
            // 
            this.waterMarkTextBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.waterMarkTextBox3.Location = new System.Drawing.Point(413, 133);
            this.waterMarkTextBox3.Name = "waterMarkTextBox3";
            this.waterMarkTextBox3.Size = new System.Drawing.Size(77, 20);
            this.waterMarkTextBox3.TabIndex = 18;
            this.waterMarkTextBox3.WaterMarkColor = System.Drawing.Color.Gray;
            this.waterMarkTextBox3.WaterMarkText = "on phase time";
            // 
            // waterMarkTextBox2
            // 
            this.waterMarkTextBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.waterMarkTextBox2.Location = new System.Drawing.Point(296, 133);
            this.waterMarkTextBox2.Name = "waterMarkTextBox2";
            this.waterMarkTextBox2.Size = new System.Drawing.Size(104, 20);
            this.waterMarkTextBox2.TabIndex = 17;
            this.waterMarkTextBox2.WaterMarkColor = System.Drawing.Color.Gray;
            this.waterMarkTextBox2.WaterMarkText = "phase off command";
            // 
            // waterMarkTextBox1
            // 
            this.waterMarkTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.waterMarkTextBox1.Location = new System.Drawing.Point(179, 133);
            this.waterMarkTextBox1.Name = "waterMarkTextBox1";
            this.waterMarkTextBox1.Size = new System.Drawing.Size(103, 20);
            this.waterMarkTextBox1.TabIndex = 16;
            this.waterMarkTextBox1.WaterMarkColor = System.Drawing.Color.Gray;
            this.waterMarkTextBox1.WaterMarkText = "phase on command";
            // 
            // waterMarkTextBox5
            // 
            this.waterMarkTextBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.waterMarkTextBox5.Location = new System.Drawing.Point(179, 159);
            this.waterMarkTextBox5.Name = "waterMarkTextBox5";
            this.waterMarkTextBox5.Size = new System.Drawing.Size(103, 20);
            this.waterMarkTextBox5.TabIndex = 20;
            this.waterMarkTextBox5.WaterMarkColor = System.Drawing.Color.Gray;
            this.waterMarkTextBox5.WaterMarkText = "one shot command";
            // 
            // waterMarkTextBox6
            // 
            this.waterMarkTextBox6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.waterMarkTextBox6.Location = new System.Drawing.Point(296, 159);
            this.waterMarkTextBox6.Name = "waterMarkTextBox6";
            this.waterMarkTextBox6.Size = new System.Drawing.Size(103, 20);
            this.waterMarkTextBox6.TabIndex = 21;
            this.waterMarkTextBox6.WaterMarkColor = System.Drawing.Color.Gray;
            this.waterMarkTextBox6.WaterMarkText = "timing";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.waterMarkTextBox6);
            this.Controls.Add(this.waterMarkTextBox5);
            this.Controls.Add(this.waterMarkTextBox4);
            this.Controls.Add(this.waterMarkTextBox3);
            this.Controls.Add(this.waterMarkTextBox2);
            this.Controls.Add(this.waterMarkTextBox1);
            this.Controls.Add(this.radioOneShot);
            this.Controls.Add(this.radioPhase);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.textboxport);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textboxIP4);
            this.Controls.Add(this.textboxIP3);
            this.Controls.Add(this.textboxIP2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textboxIP1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Ultilities";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textboxIP1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textboxIP2;
        private System.Windows.Forms.TextBox textboxIP3;
        private System.Windows.Forms.TextBox textboxIP4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textboxport;
        private System.Windows.Forms.RadioButton radioPhase;
        private System.Windows.Forms.RadioButton radioOneShot;
        private System.Windows.Forms.RadioButton radioButton1;
        private WaterMarkTextBox waterMarkTextBox1;
        private WaterMarkTextBox waterMarkTextBox2;
        private WaterMarkTextBox waterMarkTextBox3;
        private WaterMarkTextBox waterMarkTextBox4;
        private WaterMarkTextBox waterMarkTextBox5;
        private WaterMarkTextBox waterMarkTextBox6;
    }
}

