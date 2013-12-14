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
    public partial class frmBFS : Form
    {
        Graph theGraph;
        public frmBFS(Graph g)
        {
            theGraph = g;
            InitializeComponent();
        }

    }
}
