namespace Project_4A
{
    partial class frmDSP
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
            this.grpDSP = new System.Windows.Forms.GroupBox();
            this.cmbIlkTepe = new System.Windows.Forms.ComboBox();
            this.cmbIkinciTepe = new System.Windows.Forms.ComboBox();
            this.lblIlkTepe = new System.Windows.Forms.Label();
            this.lblIkinciTepe = new System.Windows.Forms.Label();
            this.btnDSP = new System.Windows.Forms.Button();
            this.grpDSP.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpDSP
            // 
            this.grpDSP.Controls.Add(this.btnDSP);
            this.grpDSP.Controls.Add(this.lblIkinciTepe);
            this.grpDSP.Controls.Add(this.lblIlkTepe);
            this.grpDSP.Controls.Add(this.cmbIkinciTepe);
            this.grpDSP.Controls.Add(this.cmbIlkTepe);
            this.grpDSP.Location = new System.Drawing.Point(12, 12);
            this.grpDSP.Name = "grpDSP";
            this.grpDSP.Size = new System.Drawing.Size(156, 100);
            this.grpDSP.TabIndex = 0;
            this.grpDSP.TabStop = false;
            this.grpDSP.Text = "2 tepe arasındaki en kısa yol";
            // 
            // cmbIlkTepe
            // 
            this.cmbIlkTepe.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbIlkTepe.FormattingEnabled = true;
            this.cmbIlkTepe.Location = new System.Drawing.Point(19, 43);
            this.cmbIlkTepe.Name = "cmbIlkTepe";
            this.cmbIlkTepe.Size = new System.Drawing.Size(55, 21);
            this.cmbIlkTepe.TabIndex = 0;
            this.cmbIlkTepe.SelectedIndexChanged += new System.EventHandler(this.cmbIlkTepe_SelectedIndexChanged);
            // 
            // cmbIkinciTepe
            // 
            this.cmbIkinciTepe.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbIkinciTepe.FormattingEnabled = true;
            this.cmbIkinciTepe.Location = new System.Drawing.Point(80, 43);
            this.cmbIkinciTepe.Name = "cmbIkinciTepe";
            this.cmbIkinciTepe.Size = new System.Drawing.Size(55, 21);
            this.cmbIkinciTepe.TabIndex = 0;
            this.cmbIkinciTepe.SelectedIndexChanged += new System.EventHandler(this.cmbIkinciTepe_SelectedIndexChanged);
            // 
            // lblIlkTepe
            // 
            this.lblIlkTepe.AutoSize = true;
            this.lblIlkTepe.Location = new System.Drawing.Point(16, 27);
            this.lblIlkTepe.Name = "lblIlkTepe";
            this.lblIlkTepe.Size = new System.Drawing.Size(46, 13);
            this.lblIlkTepe.TabIndex = 1;
            this.lblIlkTepe.Text = "İlk Tepe";
            // 
            // lblIkinciTepe
            // 
            this.lblIkinciTepe.AutoSize = true;
            this.lblIkinciTepe.Location = new System.Drawing.Point(77, 27);
            this.lblIkinciTepe.Name = "lblIkinciTepe";
            this.lblIkinciTepe.Size = new System.Drawing.Size(60, 13);
            this.lblIkinciTepe.TabIndex = 1;
            this.lblIkinciTepe.Text = "İkinci Tepe";
            // 
            // btnDSP
            // 
            this.btnDSP.Location = new System.Drawing.Point(20, 71);
            this.btnDSP.Name = "btnDSP";
            this.btnDSP.Size = new System.Drawing.Size(115, 23);
            this.btnDSP.TabIndex = 2;
            this.btnDSP.Text = "En Kısa Yol";
            this.btnDSP.UseVisualStyleBackColor = true;
            this.btnDSP.Click += new System.EventHandler(this.btnDSP_Click);
            // 
            // frmDSP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 368);
            this.Controls.Add(this.grpDSP);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmDSP";
            this.Text = "frmDSP";
            this.grpDSP.ResumeLayout(false);
            this.grpDSP.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpDSP;
        private System.Windows.Forms.Button btnDSP;
        private System.Windows.Forms.Label lblIkinciTepe;
        private System.Windows.Forms.Label lblIlkTepe;
        private System.Windows.Forms.ComboBox cmbIkinciTepe;
        private System.Windows.Forms.ComboBox cmbIlkTepe;


    }
}