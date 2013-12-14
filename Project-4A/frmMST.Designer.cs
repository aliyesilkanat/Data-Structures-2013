namespace Project_4A
{
    partial class frmMST
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
            this.lblAgirlik = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblAgirlik
            // 
            this.lblAgirlik.AutoSize = true;
            this.lblAgirlik.Location = new System.Drawing.Point(12, 9);
            this.lblAgirlik.Name = "lblAgirlik";
            this.lblAgirlik.Size = new System.Drawing.Size(41, 13);
            this.lblAgirlik.TabIndex = 0;
            this.lblAgirlik.Text = "Ağırlık: ";
            // 
            // frmMST
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.lblAgirlik);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmMST";
            this.Text = "frmMST";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblAgirlik;
    }
}