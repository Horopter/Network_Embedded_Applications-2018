namespace EmotivApI
{
    partial class Main
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
            this.AuthButton = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.SessionButton = new System.Windows.Forms.Button();
            this.Subscriber = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.OpenButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // AuthButton
            // 
            this.AuthButton.Location = new System.Drawing.Point(72, 26);
            this.AuthButton.Name = "AuthButton";
            this.AuthButton.Size = new System.Drawing.Size(127, 23);
            this.AuthButton.TabIndex = 3;
            this.AuthButton.Text = "Authorize";
            this.AuthButton.UseVisualStyleBackColor = true;
            this.AuthButton.Click += new System.EventHandler(this.OnAuth);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(72, 55);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(533, 20);
            this.textBox3.TabIndex = 4;
            // 
            // SessionButton
            // 
            this.SessionButton.Location = new System.Drawing.Point(72, 81);
            this.SessionButton.Name = "SessionButton";
            this.SessionButton.Size = new System.Drawing.Size(127, 23);
            this.SessionButton.TabIndex = 5;
            this.SessionButton.Text = "Create Session";
            this.SessionButton.UseVisualStyleBackColor = true;
            this.SessionButton.Click += new System.EventHandler(this.OnSessionRequest);
            // 
            // Subscriber
            // 
            this.Subscriber.Location = new System.Drawing.Point(72, 110);
            this.Subscriber.Name = "Subscriber";
            this.Subscriber.Size = new System.Drawing.Size(127, 23);
            this.Subscriber.TabIndex = 6;
            this.Subscriber.Text = "Subscribe";
            this.Subscriber.UseVisualStyleBackColor = true;
            this.Subscriber.Click += new System.EventHandler(this.OnSubscribeRequest);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(60, 244);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(498, 188);
            this.textBox2.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(57, 201);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "COM PORT";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(127, 198);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 10;
            this.textBox1.Text = "COM6";
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // OpenButton
            // 
            this.OpenButton.Location = new System.Drawing.Point(233, 190);
            this.OpenButton.Name = "OpenButton";
            this.OpenButton.Size = new System.Drawing.Size(136, 34);
            this.OpenButton.TabIndex = 9;
            this.OpenButton.Text = "OPEN";
            this.OpenButton.UseVisualStyleBackColor = true;
            this.OpenButton.Click += new System.EventHandler(this.OpenConnection);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(654, 555);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.OpenButton);
            this.Controls.Add(this.Subscriber);
            this.Controls.Add(this.SessionButton);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.AuthButton);
            this.Name = "Main";
            this.Text = "BCI Project GUI";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button AuthButton;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button SessionButton;
        private System.Windows.Forms.Button Subscriber;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button OpenButton;
    }
}

