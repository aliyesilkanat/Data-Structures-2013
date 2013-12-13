using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Project_4A
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void treeMenu_AfterSelect(object sender, TreeViewEventArgs e)
        {
            switch (e.Node.Name)
            {
                case "Node0":
                    break;
                case "Node1":
                    break;
                case "Node2":
                    break;
                case "Node3":
                    break;
            }
        }
    }
}
