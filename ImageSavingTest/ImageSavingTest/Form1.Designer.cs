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
            this.nextbut = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.textboxIP1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textboxIP2 = new System.Windows.Forms.TextBox();
            this.textboxIP3 = new System.Windows.Forms.TextBox();
            this.textboxIP4 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textboxport = new System.Windows.Forms.TextBox();
            this.radioContinous = new System.Windows.Forms.RadioButton();
            this.radioPhase = new System.Windows.Forms.RadioButton();
            this.radioOneShot = new System.Windows.Forms.RadioButton();
            this.checkPhaseDelay = new System.Windows.Forms.CheckBox();
            this.checkOneShotDelay = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pathTextbox = new ImageSavingTest.WaterMarkTextBox();
            this.radioPTL = new System.Windows.Forms.RadioButton();
            this.radioImageSaving = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.delayOneShot = new ImageSavingTest.WaterMarkTextBox();
            this.delaypOff = new ImageSavingTest.WaterMarkTextBox();
            this.delaypOn = new ImageSavingTest.WaterMarkTextBox();
            this.timingOneShottxt = new ImageSavingTest.WaterMarkTextBox();
            this.oneShotCmdtxt = new ImageSavingTest.WaterMarkTextBox();
            this.offPhaseTimetxt = new ImageSavingTest.WaterMarkTextBox();
            this.onPhaseTimetxt = new ImageSavingTest.WaterMarkTextBox();
            this.pOffCmdtxt = new ImageSavingTest.WaterMarkTextBox();
            this.pOnCmdtxt = new ImageSavingTest.WaterMarkTextBox();
            this.goodreadcheck = new System.Windows.Forms.CheckBox();
            this.noreadcheck = new System.Windows.Forms.CheckBox();
            this.goodreadtxt = new ImageSavingTest.WaterMarkTextBox();
            this.noreadtxt = new ImageSavingTest.WaterMarkTextBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // nextbut
            // 
            this.nextbut.Location = new System.Drawing.Point(325, 301);
            this.nextbut.Name = "nextbut";
            this.nextbut.Size = new System.Drawing.Size(109, 64);
            this.nextbut.TabIndex = 0;
            this.nextbut.Text = "Next";
            this.nextbut.UseVisualStyleBackColor = true;
            this.nextbut.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(452, 301);
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
            // radioContinous
            // 
            this.radioContinous.AutoSize = true;
            this.radioContinous.Checked = true;
            this.radioContinous.Location = new System.Drawing.Point(91, 179);
            this.radioContinous.Name = "radioContinous";
            this.radioContinous.Size = new System.Drawing.Size(78, 17);
            this.radioContinous.TabIndex = 9;
            this.radioContinous.TabStop = true;
            this.radioContinous.Text = "Continuous";
            this.radioContinous.UseVisualStyleBackColor = true;
            this.radioContinous.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioPhase
            // 
            this.radioPhase.AutoSize = true;
            this.radioPhase.Location = new System.Drawing.Point(91, 133);
            this.radioPhase.Name = "radioPhase";
            this.radioPhase.Size = new System.Drawing.Size(82, 17);
            this.radioPhase.TabIndex = 10;
            this.radioPhase.Text = "PhaseMode";
            this.radioPhase.UseVisualStyleBackColor = true;
            this.radioPhase.CheckedChanged += new System.EventHandler(this.radioPhase_CheckedChanged);
            // 
            // radioOneShot
            // 
            this.radioOneShot.AutoSize = true;
            this.radioOneShot.Location = new System.Drawing.Point(91, 156);
            this.radioOneShot.Name = "radioOneShot";
            this.radioOneShot.Size = new System.Drawing.Size(67, 17);
            this.radioOneShot.TabIndex = 11;
            this.radioOneShot.Text = "OneShot";
            this.radioOneShot.UseVisualStyleBackColor = true;
            this.radioOneShot.CheckedChanged += new System.EventHandler(this.radioOneShot_CheckedChanged);
            // 
            // checkPhaseDelay
            // 
            this.checkPhaseDelay.AutoSize = true;
            this.checkPhaseDelay.Location = new System.Drawing.Point(393, 135);
            this.checkPhaseDelay.Name = "checkPhaseDelay";
            this.checkPhaseDelay.Size = new System.Drawing.Size(92, 17);
            this.checkPhaseDelay.TabIndex = 22;
            this.checkPhaseDelay.Text = "External delay";
            this.checkPhaseDelay.UseVisualStyleBackColor = true;
            this.checkPhaseDelay.CheckedChanged += new System.EventHandler(this.checkPhaseDelay_CheckedChanged);
            // 
            // checkOneShotDelay
            // 
            this.checkOneShotDelay.AutoSize = true;
            this.checkOneShotDelay.Location = new System.Drawing.Point(393, 161);
            this.checkOneShotDelay.Name = "checkOneShotDelay";
            this.checkOneShotDelay.Size = new System.Drawing.Size(92, 17);
            this.checkOneShotDelay.TabIndex = 23;
            this.checkOneShotDelay.Text = "External delay";
            this.checkOneShotDelay.UseVisualStyleBackColor = true;
            this.checkOneShotDelay.CheckedChanged += new System.EventHandler(this.checkOneShotDelay_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.noreadtxt);
            this.groupBox1.Controls.Add(this.goodreadtxt);
            this.groupBox1.Controls.Add(this.noreadcheck);
            this.groupBox1.Controls.Add(this.goodreadcheck);
            this.groupBox1.Controls.Add(this.pathTextbox);
            this.groupBox1.Controls.Add(this.radioPTL);
            this.groupBox1.Controls.Add(this.radioImageSaving);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(1, 3);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(0);
            this.groupBox1.Size = new System.Drawing.Size(691, 261);
            this.groupBox1.TabIndex = 27;
            this.groupBox1.TabStop = false;
            this.groupBox1.Visible = false;
            // 
            // pathTextbox
            // 
            this.pathTextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.pathTextbox.Location = new System.Drawing.Point(146, 47);
            this.pathTextbox.Name = "pathTextbox";
            this.pathTextbox.Size = new System.Drawing.Size(301, 20);
            this.pathTextbox.TabIndex = 3;
            this.pathTextbox.WaterMarkColor = System.Drawing.Color.Gray;
            this.pathTextbox.WaterMarkText = "Specifiy the path of fodler need to check";
            // 
            // radioPTL
            // 
            this.radioPTL.AutoSize = true;
            this.radioPTL.Location = new System.Drawing.Point(50, 70);
            this.radioPTL.Name = "radioPTL";
            this.radioPTL.Size = new System.Drawing.Size(45, 17);
            this.radioPTL.TabIndex = 2;
            this.radioPTL.TabStop = true;
            this.radioPTL.Text = "PTL";
            this.radioPTL.UseVisualStyleBackColor = true;
            // 
            // radioImageSaving
            // 
            this.radioImageSaving.AutoSize = true;
            this.radioImageSaving.Location = new System.Drawing.Point(50, 47);
            this.radioImageSaving.Name = "radioImageSaving";
            this.radioImageSaving.Size = new System.Drawing.Size(90, 17);
            this.radioImageSaving.TabIndex = 1;
            this.radioImageSaving.TabStop = true;
            this.radioImageSaving.Text = "Image Saving";
            this.radioImageSaving.UseVisualStyleBackColor = true;
            this.radioImageSaving.CheckedChanged += new System.EventHandler(this.radioImageSaving_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(246, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(214, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "Select feature you want to verify";
            // 
            // delayOneShot
            // 
            this.delayOneShot.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.delayOneShot.Location = new System.Drawing.Point(491, 159);
            this.delayOneShot.Name = "delayOneShot";
            this.delayOneShot.Size = new System.Drawing.Size(124, 20);
            this.delayOneShot.TabIndex = 26;
            this.delayOneShot.WaterMarkColor = System.Drawing.Color.Gray;
            this.delayOneShot.WaterMarkText = "delay on external (ms)";
            // 
            // delaypOff
            // 
            this.delaypOff.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.delaypOff.Location = new System.Drawing.Point(491, 159);
            this.delaypOff.Name = "delaypOff";
            this.delaypOff.Size = new System.Drawing.Size(124, 20);
            this.delaypOff.TabIndex = 25;
            this.delaypOff.WaterMarkColor = System.Drawing.Color.Gray;
            this.delaypOff.WaterMarkText = "delay on phase off (ms)";
            // 
            // delaypOn
            // 
            this.delaypOn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.delaypOn.Location = new System.Drawing.Point(491, 133);
            this.delaypOn.Name = "delaypOn";
            this.delaypOn.Size = new System.Drawing.Size(124, 20);
            this.delaypOn.TabIndex = 24;
            this.delaypOn.WaterMarkColor = System.Drawing.Color.Gray;
            this.delaypOn.WaterMarkText = "delay on phase on (ms)";
            // 
            // timingOneShottxt
            // 
            this.timingOneShottxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.timingOneShottxt.Location = new System.Drawing.Point(293, 159);
            this.timingOneShottxt.Name = "timingOneShottxt";
            this.timingOneShottxt.Size = new System.Drawing.Size(77, 20);
            this.timingOneShottxt.TabIndex = 21;
            this.timingOneShottxt.WaterMarkColor = System.Drawing.Color.Gray;
            this.timingOneShottxt.WaterMarkText = "timing";
            // 
            // oneShotCmdtxt
            // 
            this.oneShotCmdtxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.oneShotCmdtxt.Location = new System.Drawing.Point(179, 159);
            this.oneShotCmdtxt.Name = "oneShotCmdtxt";
            this.oneShotCmdtxt.Size = new System.Drawing.Size(103, 20);
            this.oneShotCmdtxt.TabIndex = 20;
            this.oneShotCmdtxt.WaterMarkColor = System.Drawing.Color.Gray;
            this.oneShotCmdtxt.WaterMarkText = "one shot command";
            // 
            // offPhaseTimetxt
            // 
            this.offPhaseTimetxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.offPhaseTimetxt.Location = new System.Drawing.Point(293, 159);
            this.offPhaseTimetxt.Name = "offPhaseTimetxt";
            this.offPhaseTimetxt.Size = new System.Drawing.Size(77, 20);
            this.offPhaseTimetxt.TabIndex = 19;
            this.offPhaseTimetxt.WaterMarkColor = System.Drawing.Color.Gray;
            this.offPhaseTimetxt.WaterMarkText = "off phase time";
            // 
            // onPhaseTimetxt
            // 
            this.onPhaseTimetxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.onPhaseTimetxt.Location = new System.Drawing.Point(293, 133);
            this.onPhaseTimetxt.Name = "onPhaseTimetxt";
            this.onPhaseTimetxt.Size = new System.Drawing.Size(77, 20);
            this.onPhaseTimetxt.TabIndex = 18;
            this.onPhaseTimetxt.WaterMarkColor = System.Drawing.Color.Gray;
            this.onPhaseTimetxt.WaterMarkText = "on phase time";
            // 
            // pOffCmdtxt
            // 
            this.pOffCmdtxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.pOffCmdtxt.Location = new System.Drawing.Point(179, 159);
            this.pOffCmdtxt.Name = "pOffCmdtxt";
            this.pOffCmdtxt.Size = new System.Drawing.Size(104, 20);
            this.pOffCmdtxt.TabIndex = 17;
            this.pOffCmdtxt.WaterMarkColor = System.Drawing.Color.Gray;
            this.pOffCmdtxt.WaterMarkText = "phase off command";
            // 
            // pOnCmdtxt
            // 
            this.pOnCmdtxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.pOnCmdtxt.Location = new System.Drawing.Point(179, 133);
            this.pOnCmdtxt.Name = "pOnCmdtxt";
            this.pOnCmdtxt.Size = new System.Drawing.Size(103, 20);
            this.pOnCmdtxt.TabIndex = 16;
            this.pOnCmdtxt.WaterMarkColor = System.Drawing.Color.Gray;
            this.pOnCmdtxt.WaterMarkText = "phase on command";
            // 
            // goodreadcheck
            // 
            this.goodreadcheck.AutoSize = true;
            this.goodreadcheck.Location = new System.Drawing.Point(146, 73);
            this.goodreadcheck.Name = "goodreadcheck";
            this.goodreadcheck.Size = new System.Drawing.Size(81, 17);
            this.goodreadcheck.TabIndex = 4;
            this.goodreadcheck.Text = "Good Read";
            this.goodreadcheck.UseVisualStyleBackColor = true;
            this.goodreadcheck.CheckedChanged += new System.EventHandler(this.goodreadcheck_CheckedChanged);
            // 
            // noreadcheck
            // 
            this.noreadcheck.AutoSize = true;
            this.noreadcheck.Location = new System.Drawing.Point(146, 97);
            this.noreadcheck.Name = "noreadcheck";
            this.noreadcheck.Size = new System.Drawing.Size(69, 17);
            this.noreadcheck.TabIndex = 5;
            this.noreadcheck.Text = "No Read";
            this.noreadcheck.UseVisualStyleBackColor = true;
            this.noreadcheck.CheckedChanged += new System.EventHandler(this.noreadcheck_CheckedChanged);
            // 
            // goodreadtxt
            // 
            this.goodreadtxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.goodreadtxt.Location = new System.Drawing.Point(233, 70);
            this.goodreadtxt.Name = "goodreadtxt";
            this.goodreadtxt.Size = new System.Drawing.Size(136, 20);
            this.goodreadtxt.TabIndex = 6;
            this.goodreadtxt.WaterMarkColor = System.Drawing.Color.Gray;
            this.goodreadtxt.WaterMarkText = "good read pattern";
            // 
            // noreadtxt
            // 
            this.noreadtxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.noreadtxt.Location = new System.Drawing.Point(233, 94);
            this.noreadtxt.Name = "noreadtxt";
            this.noreadtxt.Size = new System.Drawing.Size(136, 20);
            this.noreadtxt.TabIndex = 7;
            this.noreadtxt.WaterMarkColor = System.Drawing.Color.Gray;
            this.noreadtxt.WaterMarkText = "no read pattern";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(693, 393);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.delayOneShot);
            this.Controls.Add(this.delaypOff);
            this.Controls.Add(this.delaypOn);
            this.Controls.Add(this.checkOneShotDelay);
            this.Controls.Add(this.checkPhaseDelay);
            this.Controls.Add(this.timingOneShottxt);
            this.Controls.Add(this.oneShotCmdtxt);
            this.Controls.Add(this.offPhaseTimetxt);
            this.Controls.Add(this.onPhaseTimetxt);
            this.Controls.Add(this.pOffCmdtxt);
            this.Controls.Add(this.pOnCmdtxt);
            this.Controls.Add(this.radioOneShot);
            this.Controls.Add(this.radioPhase);
            this.Controls.Add(this.radioContinous);
            this.Controls.Add(this.textboxport);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textboxIP4);
            this.Controls.Add(this.textboxIP3);
            this.Controls.Add(this.textboxIP2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textboxIP1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.nextbut);
            this.Name = "Form1";
            this.Text = "Ultilities";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button nextbut;
        private System.Windows.Forms.Button button2;
        private WaterMarkTextBox delaypOn;
        private WaterMarkTextBox delaypOff;
        private WaterMarkTextBox delayOneShot;
        private System.Windows.Forms.TextBox textboxIP1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textboxIP2;
        private System.Windows.Forms.TextBox textboxIP3;
        private System.Windows.Forms.TextBox textboxIP4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textboxport;
        private System.Windows.Forms.RadioButton radioContinous;
        private System.Windows.Forms.RadioButton radioPhase;
        private System.Windows.Forms.RadioButton radioOneShot;
        private WaterMarkTextBox pOnCmdtxt;
        private WaterMarkTextBox pOffCmdtxt;
        private WaterMarkTextBox onPhaseTimetxt;
        private WaterMarkTextBox offPhaseTimetxt;
        private WaterMarkTextBox oneShotCmdtxt;
        private WaterMarkTextBox timingOneShottxt;
        private System.Windows.Forms.CheckBox checkPhaseDelay;
        private System.Windows.Forms.CheckBox checkOneShotDelay;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private WaterMarkTextBox pathTextbox;
        private System.Windows.Forms.RadioButton radioPTL;
        private System.Windows.Forms.RadioButton radioImageSaving;
        private WaterMarkTextBox noreadtxt;
        private WaterMarkTextBox goodreadtxt;
        private System.Windows.Forms.CheckBox noreadcheck;
        private System.Windows.Forms.CheckBox goodreadcheck;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}

