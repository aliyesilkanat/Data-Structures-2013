namespace Project_4A
{
    partial class frmBFS
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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnBFS = new System.Windows.Forms.Button();
            this.cmbVertices = new System.Windows.Forms.ComboBox();
            this.grpBFS = new System.Windows.Forms.GroupBox();
            this.grpBFS.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btnBFS
            // 
            this.btnBFS.Location = new System.Drawing.Point(5, 49);
            this.btnBFS.Name = "btnBFS";
            this.btnBFS.Size = new System.Drawing.Size(83, 23);
            this.btnBFS.TabIndex = 0;
            this.btnBFS.Text = "BFS Başlat";
            this.btnBFS.UseVisualStyleBackColor = true;
            this.btnBFS.Click += new System.EventHandler(this.btnBFS_Click);
            // 
            // cmbVertices
            // 
            this.cmbVertices.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbVertices.FormattingEnabled = true;
            this.cmbVertices.Location = new System.Drawing.Point(6, 19);
            this.cmbVertices.Name = "cmbVertices";
            this.cmbVertices.Size = new System.Drawing.Size(82, 21);
            this.cmbVertices.TabIndex = 1;
            this.cmbVertices.SelectedIndexChanged += new System.EventHandler(this.cmbVertices_SelectedIndexChanged);
            // 
            // grpBFS
            // 
            this.grpBFS.Controls.Add(this.cmbVertices);
            this.grpBFS.Controls.Add(this.btnBFS);
            this.grpBFS.Location = new System.Drawing.Point(12, 12);
            this.grpBFS.Name = "grpBFS";
            this.grpBFS.Size = new System.Drawing.Size(94, 78);
            this.grpBFS.TabIndex = 2;
            this.grpBFS.TabStop = false;
            this.grpBFS.Text = "İlk tepeyi seçin";
            // 
            // frmBFS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(332, 262);
            this.Controls.Add(this.grpBFS);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmBFS";
            this.Text = "frmBFS";
            this.grpBFS.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnBFS;
        private System.Windows.Forms.ComboBox cmbVertices;
        private System.Windows.Forms.GroupBox grpBFS;


    }
}