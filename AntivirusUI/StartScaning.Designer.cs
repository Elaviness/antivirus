namespace AntivirusUI
{
    partial class StartScaning
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
            this.StartScaningButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // StartScaningButton
            // 
            this.StartScaningButton.Location = new System.Drawing.Point(452, 118);
            this.StartScaningButton.Name = "StartScaningButton";
            this.StartScaningButton.Size = new System.Drawing.Size(75, 23);
            this.StartScaningButton.TabIndex = 0;
            this.StartScaningButton.Text = "OK";
            this.StartScaningButton.UseVisualStyleBackColor = true;
            this.StartScaningButton.Click += new System.EventHandler(this.StartScaningButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(270, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Введите путь к файлу или папке для сканирования:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 54);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(515, 20);
            this.textBox1.TabIndex = 2;
            // 
            // StartScaning
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(551, 162);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.StartScaningButton);
            this.Name = "StartScaning";
            this.Text = "StartScaning";
            this.Load += new System.EventHandler(this.StartScaning_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button StartScaningButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
    }
}