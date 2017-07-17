namespace ModbusTCP_Master
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
            this.components = new System.ComponentModel.Container();
            this.AI3 = new System.Windows.Forms.TextBox();
            this.AI2 = new System.Windows.Forms.TextBox();
            this.AI1 = new System.Windows.Forms.TextBox();
            this.AI0 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btStop = new System.Windows.Forms.Button();
            this.btStart = new System.Windows.Forms.Button();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.AI4 = new System.Windows.Forms.TextBox();
            this.AI5 = new System.Windows.Forms.TextBox();
            this.AI6 = new System.Windows.Forms.TextBox();
            this.AI7 = new System.Windows.Forms.TextBox();
            this.AI8 = new System.Windows.Forms.TextBox();
            this.AI9 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // AI3
            // 
            this.AI3.BackColor = System.Drawing.Color.White;
            this.AI3.Location = new System.Drawing.Point(403, 129);
            this.AI3.Name = "AI3";
            this.AI3.ReadOnly = true;
            this.AI3.Size = new System.Drawing.Size(110, 31);
            this.AI3.TabIndex = 67;
            // 
            // AI2
            // 
            this.AI2.BackColor = System.Drawing.Color.White;
            this.AI2.Location = new System.Drawing.Point(287, 129);
            this.AI2.Name = "AI2";
            this.AI2.ReadOnly = true;
            this.AI2.Size = new System.Drawing.Size(110, 31);
            this.AI2.TabIndex = 66;
            // 
            // AI1
            // 
            this.AI1.BackColor = System.Drawing.Color.White;
            this.AI1.Location = new System.Drawing.Point(171, 129);
            this.AI1.Name = "AI1";
            this.AI1.ReadOnly = true;
            this.AI1.Size = new System.Drawing.Size(110, 31);
            this.AI1.TabIndex = 65;
            // 
            // AI0
            // 
            this.AI0.BackColor = System.Drawing.Color.White;
            this.AI0.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AI0.Location = new System.Drawing.Point(55, 129);
            this.AI0.Name = "AI0";
            this.AI0.ReadOnly = true;
            this.AI0.Size = new System.Drawing.Size(110, 31);
            this.AI0.TabIndex = 64;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 171);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 25);
            this.label4.TabIndex = 54;
            this.label4.Text = "AI";
            // 
            // btStop
            // 
            this.btStop.Location = new System.Drawing.Point(535, 22);
            this.btStop.Name = "btStop";
            this.btStop.Size = new System.Drawing.Size(96, 38);
            this.btStop.TabIndex = 51;
            this.btStop.Text = "Stop";
            this.btStop.UseVisualStyleBackColor = true;
            this.btStop.Click += new System.EventHandler(this.btStop_Click);
            // 
            // btStart
            // 
            this.btStart.Location = new System.Drawing.Point(397, 22);
            this.btStart.Name = "btStart";
            this.btStart.Size = new System.Drawing.Size(96, 38);
            this.btStart.TabIndex = 50;
            this.btStart.Text = "Start";
            this.btStart.UseVisualStyleBackColor = true;
            this.btStart.Click += new System.EventHandler(this.btStart_Click);
            // 
            // txtIP
            // 
            this.txtIP.Location = new System.Drawing.Point(144, 26);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(162, 31);
            this.txtIP.TabIndex = 49;
            this.txtIP.Text = "172.30.7.3";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 27);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 25);
            this.label1.TabIndex = 48;
            this.label1.Text = "IP Address:";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // AI4
            // 
            this.AI4.BackColor = System.Drawing.Color.White;
            this.AI4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AI4.Location = new System.Drawing.Point(519, 129);
            this.AI4.Name = "AI4";
            this.AI4.ReadOnly = true;
            this.AI4.Size = new System.Drawing.Size(110, 31);
            this.AI4.TabIndex = 72;
            // 
            // AI5
            // 
            this.AI5.BackColor = System.Drawing.Color.White;
            this.AI5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AI5.Location = new System.Drawing.Point(55, 211);
            this.AI5.Name = "AI5";
            this.AI5.ReadOnly = true;
            this.AI5.Size = new System.Drawing.Size(110, 31);
            this.AI5.TabIndex = 73;
            // 
            // AI6
            // 
            this.AI6.BackColor = System.Drawing.Color.White;
            this.AI6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AI6.Location = new System.Drawing.Point(171, 211);
            this.AI6.Name = "AI6";
            this.AI6.ReadOnly = true;
            this.AI6.Size = new System.Drawing.Size(110, 31);
            this.AI6.TabIndex = 74;
            // 
            // AI7
            // 
            this.AI7.BackColor = System.Drawing.Color.White;
            this.AI7.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AI7.Location = new System.Drawing.Point(287, 211);
            this.AI7.Name = "AI7";
            this.AI7.ReadOnly = true;
            this.AI7.Size = new System.Drawing.Size(110, 31);
            this.AI7.TabIndex = 75;
            // 
            // AI8
            // 
            this.AI8.BackColor = System.Drawing.Color.White;
            this.AI8.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AI8.Location = new System.Drawing.Point(403, 211);
            this.AI8.Name = "AI8";
            this.AI8.ReadOnly = true;
            this.AI8.Size = new System.Drawing.Size(110, 31);
            this.AI8.TabIndex = 76;
            // 
            // AI9
            // 
            this.AI9.BackColor = System.Drawing.Color.White;
            this.AI9.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AI9.Location = new System.Drawing.Point(519, 211);
            this.AI9.Name = "AI9";
            this.AI9.ReadOnly = true;
            this.AI9.Size = new System.Drawing.Size(110, 31);
            this.AI9.TabIndex = 77;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(52, 101);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(123, 25);
            this.label6.TabIndex = 78;
            this.label6.Text = "CO2(PPM)";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(179, 101);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(88, 25);
            this.label7.TabIndex = 79;
            this.label7.Text = "溫度(C)";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(285, 101);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(123, 25);
            this.label8.TabIndex = 80;
            this.label8.Text = "濕度(PH%)";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(527, 101);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(100, 25);
            this.label9.TabIndex = 81;
            this.label9.Text = "土壤濕度";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(59, 183);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(100, 25);
            this.label10.TabIndex = 82;
            this.label10.Text = "土壤溫度";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(169, 183);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(116, 25);
            this.label11.TabIndex = 83;
            this.label11.Text = "保留(忽略)";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(296, 183);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(88, 25);
            this.label12.TabIndex = 84;
            this.label12.Text = "溫度(C)";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(398, 183);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(123, 25);
            this.label13.TabIndex = 85;
            this.label13.Text = "濕度(PH%)";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(527, 183);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(100, 25);
            this.label14.TabIndex = 86;
            this.label14.Text = "電池電壓";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(429, 101);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(56, 25);
            this.label15.TabIndex = 87;
            this.label15.Text = "照度";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(59, 265);
            this.label16.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(0, 25);
            this.label16.TabIndex = 88;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(557, 278);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 25);
            this.label2.TabIndex = 89;
            this.label2.Text = "s";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(55, 318);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 25);
            this.label3.TabIndex = 90;
            this.label3.Text = "label3";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(666, 355);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.AI9);
            this.Controls.Add(this.AI8);
            this.Controls.Add(this.AI7);
            this.Controls.Add(this.AI6);
            this.Controls.Add(this.AI5);
            this.Controls.Add(this.AI4);
            this.Controls.Add(this.AI3);
            this.Controls.Add(this.AI2);
            this.Controls.Add(this.AI1);
            this.Controls.Add(this.AI0);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btStop);
            this.Controls.Add(this.btStart);
            this.Controls.Add(this.txtIP);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.Name = "Form1";
            this.Text = "溫室感測接值程式";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox AI3;
        private System.Windows.Forms.TextBox AI2;
        private System.Windows.Forms.TextBox AI1;
        private System.Windows.Forms.TextBox AI0;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btStop;
        private System.Windows.Forms.Button btStart;
        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox AI4;
        private System.Windows.Forms.TextBox AI5;
        private System.Windows.Forms.TextBox AI6;
        private System.Windows.Forms.TextBox AI7;
        private System.Windows.Forms.TextBox AI8;
        private System.Windows.Forms.TextBox AI9;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}

