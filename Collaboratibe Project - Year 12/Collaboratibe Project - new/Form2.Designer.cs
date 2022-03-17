namespace Collaboratibe_Project___new
{
    partial class Form2
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
            this.cmbInput = new System.Windows.Forms.ComboBox();
            this.pnlOutput = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rbtPie = new System.Windows.Forms.RadioButton();
            this.rbtBar = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlOutput2 = new System.Windows.Forms.Panel();
            this.cmbInput2 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbInput
            // 
            this.cmbInput.FormattingEnabled = true;
            this.cmbInput.Location = new System.Drawing.Point(30, 47);
            this.cmbInput.Name = "cmbInput";
            this.cmbInput.Size = new System.Drawing.Size(121, 21);
            this.cmbInput.TabIndex = 1;
            this.cmbInput.SelectedIndexChanged += new System.EventHandler(this.cmbInput_SelectedIndexChanged);
            // 
            // pnlOutput
            // 
            this.pnlOutput.Location = new System.Drawing.Point(252, 22);
            this.pnlOutput.Name = "pnlOutput";
            this.pnlOutput.Size = new System.Drawing.Size(550, 567);
            this.pnlOutput.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.rbtPie);
            this.panel2.Controls.Add(this.rbtBar);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(12, 164);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 118);
            this.panel2.TabIndex = 3;
            // 
            // rbtPie
            // 
            this.rbtPie.AutoSize = true;
            this.rbtPie.Location = new System.Drawing.Point(18, 83);
            this.rbtPie.Name = "rbtPie";
            this.rbtPie.Size = new System.Drawing.Size(68, 17);
            this.rbtPie.TabIndex = 2;
            this.rbtPie.TabStop = true;
            this.rbtPie.Text = "Pie Chart";
            this.rbtPie.UseVisualStyleBackColor = true;
            this.rbtPie.CheckedChanged += new System.EventHandler(this.rbtPie_CheckedChanged);
            // 
            // rbtBar
            // 
            this.rbtBar.AutoSize = true;
            this.rbtBar.Location = new System.Drawing.Point(18, 46);
            this.rbtBar.Name = "rbtBar";
            this.rbtBar.Size = new System.Drawing.Size(88, 17);
            this.rbtBar.TabIndex = 1;
            this.rbtBar.TabStop = true;
            this.rbtBar.Text = "Column Chart";
            this.rbtBar.UseVisualStyleBackColor = true;
            this.rbtBar.CheckedChanged += new System.EventHandler(this.rbtBar_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Chart Display Type:";
            // 
            // pnlOutput2
            // 
            this.pnlOutput2.Location = new System.Drawing.Point(808, 22);
            this.pnlOutput2.Name = "pnlOutput2";
            this.pnlOutput2.Size = new System.Drawing.Size(564, 564);
            this.pnlOutput2.TabIndex = 4;
            // 
            // cmbInput2
            // 
            this.cmbInput2.FormattingEnabled = true;
            this.cmbInput2.Location = new System.Drawing.Point(30, 107);
            this.cmbInput2.Name = "cmbInput2";
            this.cmbInput2.Size = new System.Drawing.Size(121, 21);
            this.cmbInput2.TabIndex = 5;
            this.cmbInput2.SelectedIndexChanged += new System.EventHandler(this.cmbInput2_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "LGA 1:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "LGA 2:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(76, 435);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1406, 601);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbInput2);
            this.Controls.Add(this.pnlOutput2);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pnlOutput);
            this.Controls.Add(this.cmbInput);
            this.Name = "Form2";
            this.Text = "Compairing top 10 crimes of an LGA";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox cmbInput;
        private System.Windows.Forms.Panel pnlOutput;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton rbtPie;
        private System.Windows.Forms.RadioButton rbtBar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pnlOutput2;
        private System.Windows.Forms.ComboBox cmbInput2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
    }
}