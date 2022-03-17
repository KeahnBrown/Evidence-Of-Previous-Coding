namespace Collaboratibe_Project___new
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
            this.btnCloseForm = new System.Windows.Forms.Button();
            this.pnlInput = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.rbtPie = new System.Windows.Forms.RadioButton();
            this.rbtBar = new System.Windows.Forms.RadioButton();
            this.pnlOutput = new System.Windows.Forms.Panel();
            this.cmbInput = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlInput.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCloseForm
            // 
            this.btnCloseForm.Location = new System.Drawing.Point(58, 390);
            this.btnCloseForm.Name = "btnCloseForm";
            this.btnCloseForm.Size = new System.Drawing.Size(75, 23);
            this.btnCloseForm.TabIndex = 0;
            this.btnCloseForm.Text = "Close";
            this.btnCloseForm.UseVisualStyleBackColor = true;
            this.btnCloseForm.Click += new System.EventHandler(this.btnCloseForm_Click);
            // 
            // pnlInput
            // 
            this.pnlInput.Controls.Add(this.label1);
            this.pnlInput.Controls.Add(this.rbtPie);
            this.pnlInput.Controls.Add(this.rbtBar);
            this.pnlInput.Location = new System.Drawing.Point(23, 138);
            this.pnlInput.Margin = new System.Windows.Forms.Padding(2);
            this.pnlInput.Name = "pnlInput";
            this.pnlInput.Size = new System.Drawing.Size(150, 111);
            this.pnlInput.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Display Type:";
            // 
            // rbtPie
            // 
            this.rbtPie.AutoSize = true;
            this.rbtPie.Location = new System.Drawing.Point(21, 57);
            this.rbtPie.Margin = new System.Windows.Forms.Padding(2);
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
            this.rbtBar.Location = new System.Drawing.Point(21, 36);
            this.rbtBar.Margin = new System.Windows.Forms.Padding(2);
            this.rbtBar.Name = "rbtBar";
            this.rbtBar.Size = new System.Drawing.Size(69, 17);
            this.rbtBar.TabIndex = 1;
            this.rbtBar.Text = "Bar Chart";
            this.rbtBar.UseVisualStyleBackColor = true;
            this.rbtBar.CheckedChanged += new System.EventHandler(this.rbtBar_CheckedChanged);
            // 
            // pnlOutput
            // 
            this.pnlOutput.Location = new System.Drawing.Point(194, 26);
            this.pnlOutput.Margin = new System.Windows.Forms.Padding(2);
            this.pnlOutput.Name = "pnlOutput";
            this.pnlOutput.Size = new System.Drawing.Size(821, 443);
            this.pnlOutput.TabIndex = 4;
            // 
            // cmbInput
            // 
            this.cmbInput.FormattingEnabled = true;
            this.cmbInput.Location = new System.Drawing.Point(26, 76);
            this.cmbInput.Name = "cmbInput";
            this.cmbInput.Size = new System.Drawing.Size(121, 21);
            this.cmbInput.TabIndex = 5;
            this.cmbInput.SelectedIndexChanged += new System.EventHandler(this.cmbInput_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "LGA:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1035, 572);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbInput);
            this.Controls.Add(this.pnlOutput);
            this.Controls.Add(this.pnlInput);
            this.Controls.Add(this.btnCloseForm);
            this.Name = "Form1";
            this.Text = "Sum of Offence count per suburb in an LGA";
            this.pnlInput.ResumeLayout(false);
            this.pnlInput.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCloseForm;
        private System.Windows.Forms.Panel pnlInput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rbtPie;
        private System.Windows.Forms.RadioButton rbtBar;
        private System.Windows.Forms.Panel pnlOutput;
        private System.Windows.Forms.ComboBox cmbInput;
        private System.Windows.Forms.Label label2;
    }
}