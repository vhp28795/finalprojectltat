namespace P2Pchat
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
            this.ipclient1 = new System.Windows.Forms.TextBox();
            this.port1 = new System.Windows.Forms.TextBox();
            this.ipclient2 = new System.Windows.Forms.TextBox();
            this.port2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.sendmsg = new System.Windows.Forms.Button();
            this.connect = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.keybox = new System.Windows.Forms.TextBox();
            this.process1 = new System.Diagnostics.Process();
            this.encryptbox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.seckey = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.sendnoise = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ipclient1
            // 
            this.ipclient1.Location = new System.Drawing.Point(76, 46);
            this.ipclient1.Margin = new System.Windows.Forms.Padding(4);
            this.ipclient1.Name = "ipclient1";
            this.ipclient1.Size = new System.Drawing.Size(168, 22);
            this.ipclient1.TabIndex = 0;
            // 
            // port1
            // 
            this.port1.Location = new System.Drawing.Point(76, 92);
            this.port1.Margin = new System.Windows.Forms.Padding(4);
            this.port1.Name = "port1";
            this.port1.Size = new System.Drawing.Size(132, 22);
            this.port1.TabIndex = 1;
            // 
            // ipclient2
            // 
            this.ipclient2.Location = new System.Drawing.Point(349, 46);
            this.ipclient2.Margin = new System.Windows.Forms.Padding(4);
            this.ipclient2.Name = "ipclient2";
            this.ipclient2.Size = new System.Drawing.Size(169, 22);
            this.ipclient2.TabIndex = 2;
            // 
            // port2
            // 
            this.port2.Location = new System.Drawing.Point(349, 92);
            this.port2.Margin = new System.Windows.Forms.Padding(4);
            this.port2.Name = "port2";
            this.port2.Size = new System.Drawing.Size(132, 22);
            this.port2.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 49);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "IP 1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 96);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Port";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(295, 49);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "IP 2";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(295, 100);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Port";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(76, 16);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 17);
            this.label5.TabIndex = 8;
            this.label5.Text = "Client 1";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(349, 16);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 17);
            this.label6.TabIndex = 9;
            this.label6.Text = "Client 2";
            // 
            // sendmsg
            // 
            this.sendmsg.Location = new System.Drawing.Point(541, 339);
            this.sendmsg.Margin = new System.Windows.Forms.Padding(4);
            this.sendmsg.Name = "sendmsg";
            this.sendmsg.Size = new System.Drawing.Size(102, 48);
            this.sendmsg.TabIndex = 12;
            this.sendmsg.Text = "Send";
            this.sendmsg.UseVisualStyleBackColor = true;
            this.sendmsg.Click += new System.EventHandler(this.sendmsg_Click);
            // 
            // connect
            // 
            this.connect.Location = new System.Drawing.Point(549, 46);
            this.connect.Margin = new System.Windows.Forms.Padding(4);
            this.connect.Name = "connect";
            this.connect.Size = new System.Drawing.Size(93, 71);
            this.connect.TabIndex = 13;
            this.connect.Text = "Connect";
            this.connect.UseVisualStyleBackColor = true;
            this.connect.Click += new System.EventHandler(this.connect_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.HorizontalScrollbar = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(25, 143);
            this.listBox1.Margin = new System.Windows.Forms.Padding(4);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(616, 180);
            this.listBox1.TabIndex = 5;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(24, 339);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(509, 22);
            this.textBox1.TabIndex = 15;
            // 
            // keybox
            // 
            this.keybox.Location = new System.Drawing.Point(84, 365);
            this.keybox.Name = "keybox";
            this.keybox.ReadOnly = true;
            this.keybox.Size = new System.Drawing.Size(449, 22);
            this.keybox.TabIndex = 17;
            // 
            // process1
            // 
            this.process1.StartInfo.Domain = "";
            this.process1.StartInfo.LoadUserProfile = false;
            this.process1.StartInfo.Password = null;
            this.process1.StartInfo.StandardErrorEncoding = null;
            this.process1.StartInfo.StandardOutputEncoding = null;
            this.process1.StartInfo.UserName = "";
            this.process1.SynchronizingObject = this;
            // 
            // encryptbox
            // 
            this.encryptbox.Location = new System.Drawing.Point(84, 421);
            this.encryptbox.Name = "encryptbox";
            this.encryptbox.ReadOnly = true;
            this.encryptbox.Size = new System.Drawing.Size(449, 22);
            this.encryptbox.TabIndex = 18;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(22, 365);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 17);
            this.label7.TabIndex = 19;
            this.label7.Text = "Key pub";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(22, 421);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 17);
            this.label8.TabIndex = 19;
            this.label8.Text = "Encrypt";
            // 
            // seckey
            // 
            this.seckey.Location = new System.Drawing.Point(84, 393);
            this.seckey.Name = "seckey";
            this.seckey.ReadOnly = true;
            this.seckey.Size = new System.Drawing.Size(449, 22);
            this.seckey.TabIndex = 17;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(22, 393);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(60, 17);
            this.label9.TabIndex = 19;
            this.label9.Text = "Key Sec";
            // 
            // sendnoise
            // 
            this.sendnoise.Location = new System.Drawing.Point(539, 395);
            this.sendnoise.Name = "sendnoise";
            this.sendnoise.Size = new System.Drawing.Size(104, 48);
            this.sendnoise.TabIndex = 20;
            this.sendnoise.Text = "Send Noise";
            this.sendnoise.UseVisualStyleBackColor = true;
            this.sendnoise.Click += new System.EventHandler(this.sendnoise_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(675, 453);
            this.Controls.Add(this.sendnoise);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.encryptbox);
            this.Controls.Add(this.seckey);
            this.Controls.Add(this.keybox);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.connect);
            this.Controls.Add(this.sendmsg);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.port2);
            this.Controls.Add(this.ipclient2);
            this.Controls.Add(this.port1);
            this.Controls.Add(this.ipclient1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ipclient1;
        private System.Windows.Forms.TextBox port1;
        private System.Windows.Forms.TextBox ipclient2;
        private System.Windows.Forms.TextBox port2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button sendmsg;
        private System.Windows.Forms.Button connect;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox keybox;
        private System.Diagnostics.Process process1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox encryptbox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox seckey;
        private System.Windows.Forms.Button sendnoise;
    }
}

