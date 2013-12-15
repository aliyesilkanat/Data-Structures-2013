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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Graph");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Dijsktra\'s Shortest Path");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Breadth First Traverse");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Minimum Spanning Tree");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Case Study");
            this.grpMenu = new System.Windows.Forms.GroupBox();
            this.treeMenu = new System.Windows.Forms.TreeView();
            this.pnlForms = new System.Windows.Forms.Panel();
            this.grpMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpMenu
            // 
            this.grpMenu.Controls.Add(this.treeMenu);
            this.grpMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.grpMenu.Location = new System.Drawing.Point(0, 0);
            this.grpMenu.Name = "grpMenu";
            this.grpMenu.Size = new System.Drawing.Size(170, 362);
            this.grpMenu.TabIndex = 0;
            this.grpMenu.TabStop = false;
            this.grpMenu.Text = "Menü";
            // 
            // treeMenu
            // 
            this.treeMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeMenu.Location = new System.Drawing.Point(3, 16);
            this.treeMenu.Name = "treeMenu";
            treeNode1.Name = "nodeGraph";
            treeNode1.Text = "Graph";
            treeNode2.Name = "nodeDSP";
            treeNode2.Text = "Dijsktra\'s Shortest Path";
            treeNode3.Name = "nodeBFS";
            treeNode3.Text = "Breadth First Traverse";
            treeNode4.Name = "nodeMST";
            treeNode4.Text = "Minimum Spanning Tree";
            treeNode5.Name = "nodeCS";
            treeNode5.Text = "Case Study";
            this.treeMenu.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4,
            treeNode5});
            this.treeMenu.Size = new System.Drawing.Size(164, 343);
            this.treeMenu.TabIndex = 0;
            this.treeMenu.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeMenu_AfterSelect);
            // 
            // pnlForms
            // 
            this.pnlForms.Location = new System.Drawing.Point(176, 12);
            this.pnlForms.Name = "pnlForms";
            this.pnlForms.Size = new System.Drawing.Size(452, 347);
            this.pnlForms.TabIndex = 0;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 362);
            this.Controls.Add(this.pnlForms);
            this.Controls.Add(this.grpMenu);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Main";
            this.Text = "Main";
            this.grpMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpMenu;
        private System.Windows.Forms.TreeView treeMenu;
        private System.Windows.Forms.Panel pnlForms;
    }
}

