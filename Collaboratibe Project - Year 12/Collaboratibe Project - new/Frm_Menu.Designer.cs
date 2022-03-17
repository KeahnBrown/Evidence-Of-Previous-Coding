namespace Collaboratibe_Project___new
{
    partial class Frm_Menu
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
            this.btnOpenFrm1 = new System.Windows.Forms.Button();
            this.btnOpenFrm2 = new System.Windows.Forms.Button();
            this.btnOpenFrm3 = new System.Windows.Forms.Button();
            this.btnOpenFrm4 = new System.Windows.Forms.Button();
            this.btnOpenFrm5 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnOpenFrm1
            // 
            this.btnOpenFrm1.Location = new System.Drawing.Point(63, 88);
            this.btnOpenFrm1.Name = "btnOpenFrm1";
            this.btnOpenFrm1.Size = new System.Drawing.Size(144, 53);
            this.btnOpenFrm1.TabIndex = 0;
            this.btnOpenFrm1.Text = "Crimes per suburb in LGA";
            this.btnOpenFrm1.UseVisualStyleBackColor = true;
            this.btnOpenFrm1.Click += new System.EventHandler(this.btnOpenFrm1_Click);
            // 
            // btnOpenFrm2
            // 
            this.btnOpenFrm2.Location = new System.Drawing.Point(270, 88);
            this.btnOpenFrm2.Name = "btnOpenFrm2";
            this.btnOpenFrm2.Size = new System.Drawing.Size(144, 53);
            this.btnOpenFrm2.TabIndex = 1;
            this.btnOpenFrm2.Text = "Top ten level three crimes for an LGA";
            this.btnOpenFrm2.UseVisualStyleBackColor = true;
            this.btnOpenFrm2.Click += new System.EventHandler(this.btnOpenFrm2_Click);
            // 
            // btnOpenFrm3
            // 
            this.btnOpenFrm3.Location = new System.Drawing.Point(63, 170);
            this.btnOpenFrm3.Name = "btnOpenFrm3";
            this.btnOpenFrm3.Size = new System.Drawing.Size(144, 53);
            this.btnOpenFrm3.TabIndex = 2;
            this.btnOpenFrm3.Text = "Offence level 2 by LGA";
            this.btnOpenFrm3.UseVisualStyleBackColor = true;
            this.btnOpenFrm3.Click += new System.EventHandler(this.btnOpenFrm3_Click);
            // 
            // btnOpenFrm4
            // 
            this.btnOpenFrm4.Location = new System.Drawing.Point(270, 170);
            this.btnOpenFrm4.Name = "btnOpenFrm4";
            this.btnOpenFrm4.Size = new System.Drawing.Size(144, 53);
            this.btnOpenFrm4.TabIndex = 3;
            this.btnOpenFrm4.Text = "Top 10 dates with the most crimes";
            this.btnOpenFrm4.UseVisualStyleBackColor = true;
            this.btnOpenFrm4.Click += new System.EventHandler(this.btnOpenFrm4_Click);
            // 
            // btnOpenFrm5
            // 
            this.btnOpenFrm5.Location = new System.Drawing.Point(63, 258);
            this.btnOpenFrm5.Name = "btnOpenFrm5";
            this.btnOpenFrm5.Size = new System.Drawing.Size(351, 53);
            this.btnOpenFrm5.TabIndex = 4;
            this.btnOpenFrm5.Text = "Offence Level 2 by suburbs";
            this.btnOpenFrm5.UseVisualStyleBackColor = true;
            this.btnOpenFrm5.Click += new System.EventHandler(this.btnOpenFrm5_Click);
            // 
            // Frm_Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(479, 364);
            this.Controls.Add(this.btnOpenFrm5);
            this.Controls.Add(this.btnOpenFrm4);
            this.Controls.Add(this.btnOpenFrm3);
            this.Controls.Add(this.btnOpenFrm2);
            this.Controls.Add(this.btnOpenFrm1);
            this.Name = "Frm_Menu";
            this.Text = "Menu";
            this.Load += new System.EventHandler(this.Frm_Menu_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOpenFrm1;
        private System.Windows.Forms.Button btnOpenFrm2;
        private System.Windows.Forms.Button btnOpenFrm3;
        private System.Windows.Forms.Button btnOpenFrm4;
        private System.Windows.Forms.Button btnOpenFrm5;
    }
}

