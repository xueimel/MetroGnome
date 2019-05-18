namespace cShrp1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnUp = new System.Windows.Forms.Button();
            this.btnDown = new System.Windows.Forms.Button();
            this.flashy = new System.Windows.Forms.Label();
            this.clock = new System.Windows.Forms.Timer(this.components);
            this.BtnTap = new System.Windows.Forms.Button();
            this.BtnStrStp = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnUp
            // 
            this.btnUp.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnUp.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.btnUp.FlatAppearance.BorderSize = 100;
            this.btnUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 32F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUp.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnUp.Location = new System.Drawing.Point(100, 60);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(347, 146);
            this.btnUp.TabIndex = 0;
            this.btnUp.Text = "Presto";
            this.btnUp.UseVisualStyleBackColor = false;
            this.btnUp.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BtnUp_MouseDown);
            this.btnUp.MouseUp += new System.Windows.Forms.MouseEventHandler(this.BtnUp_MouseUp);
            // 
            // btnDown
            // 
            this.btnDown.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnDown.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.btnDown.FlatAppearance.BorderSize = 100;
            this.btnDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 32F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDown.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnDown.Location = new System.Drawing.Point(100, 315);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(347, 146);
            this.btnDown.TabIndex = 1;
            this.btnDown.Text = "Dismal";
            this.btnDown.UseVisualStyleBackColor = false;
            this.btnDown.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BtnDown_MouseDown);
            this.btnDown.MouseUp += new System.Windows.Forms.MouseEventHandler(this.BtnDown_MouseUp);
            // 
            // flashy
            // 
            this.flashy.AutoSize = true;
            this.flashy.BackColor = System.Drawing.SystemColors.ControlDark;
            this.flashy.Font = new System.Drawing.Font("Snap ITC", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flashy.Location = new System.Drawing.Point(211, 236);
            this.flashy.Name = "flashy";
            this.flashy.Size = new System.Drawing.Size(117, 27);
            this.flashy.TabIndex = 2;
            this.flashy.Text = "BPM: 90";
            // 
            // clock
            // 
            //this.clock.Enabled = true;
            //this.clock.Interval = 1000;
            //this.clock.Tick += new System.EventHandler(this.Clock_Tick);
            // 
            // BtnTap
            // 
            this.BtnTap.Location = new System.Drawing.Point(216, 503);
            this.BtnTap.Name = "BtnTap";
            this.BtnTap.Size = new System.Drawing.Size(75, 23);
            this.BtnTap.TabIndex = 3;
            this.BtnTap.Text = "Tap It";
            this.BtnTap.UseVisualStyleBackColor = true;
            this.BtnTap.Click += new System.EventHandler(this.BtnTap_Click);
            // 
            // BtnStrStp
            // 
            this.BtnStrStp.Location = new System.Drawing.Point(453, 12);
            this.BtnStrStp.Name = "BtnStrStp";
            this.BtnStrStp.Size = new System.Drawing.Size(94, 75);
            this.BtnStrStp.TabIndex = 4;
            this.BtnStrStp.Text = "Start/Stop";
            this.BtnStrStp.UseVisualStyleBackColor = true;
            this.BtnStrStp.Click += new System.EventHandler(this.BtnStrStp_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(559, 570);
            this.Controls.Add(this.BtnStrStp);
            this.Controls.Add(this.BtnTap);
            this.Controls.Add(this.flashy);
            this.Controls.Add(this.btnDown);
            this.Controls.Add(this.btnUp);
            this.ForeColor = System.Drawing.SystemColors.Desktop;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "Form1";
            this.Text = "MetroGnome";
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.Label flashy;
        private System.Windows.Forms.Timer clock;
        private System.Windows.Forms.Button BtnTap;
        private System.Windows.Forms.Button BtnStrStp;
    }
}

