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
    public partial class frmMST : Form
    {
        Graph theGraph;
        public frmMST(Graph g)
        {
            theGraph = g;
            InitializeComponent();
        }
    }
}
