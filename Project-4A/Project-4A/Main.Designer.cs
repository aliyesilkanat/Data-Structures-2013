namespace Project_4A
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Dijsktra\'s Shortest Path");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Breadth First Traverse");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Minimum Spanning Tree");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Case Study");
            this.grpMenu = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.treeMenu = new System.Windows.Forms.TreeView();
            this.grpMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpMenu
            // 
            this.grpMenu.Controls.Add(this.treeMenu);
            this.grpMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.grpMenu.Location = new System.Drawing.Point(0, 0);
            this.grpMenu.Name = "grpMenu";
            this.grpMenu.Size = new System.Drawing.Size(167, 333);
            this.grpMenu.TabIndex = 0;
            this.grpMenu.TabStop = false;
            this.grpMenu.Text = "Menü";
            // 
            // groupBox2
            // 
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox2.Location = new System.Drawing.Point(173, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(325, 333);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "groupBox2";
            // 
            // treeMenu
            // 
            this.treeMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeMenu.Location = new System.Drawing.Point(3, 16);
            this.treeMenu.Name = "treeMenu";
            treeNode1.Name = "Node0";
            treeNode1.Text = "Dijsktra\'s Shortest Path";
            treeNode2.Name = "Node1";
            treeNode2.Text = "Breadth First Traverse";
            treeNode3.Name = "Node2";
            treeNode3.Text = "Minimum Spanning Tree";
            treeNode4.Name = "Node3";
            treeNode4.Text = "Case Study";
            this.treeMenu.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4});
            this.treeMenu.Size = new System.Drawing.Size(161, 314);
            this.treeMenu.TabIndex = 0;
            this.treeMenu.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeMenu_AfterSelect);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(498, 333);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.grpMenu);
            this.Name = "Main";
            this.Text = "Main";
            this.grpMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpMenu;
        private System.Windows.Forms.TreeView treeMenu;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}

