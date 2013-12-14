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
        Form f;
        Graph theGraph;
        public Main()
        {
            theGraph = new Graph();

            theGraph.addVertex('A'); // 0 (start for mst)
            theGraph.addVertex('B'); // 1
            theGraph.addVertex('C'); // 2
            theGraph.addVertex('D'); // 3
            theGraph.addVertex('E'); // 4
            theGraph.addVertex('F'); // 5
            theGraph.addEdge(0, 1, 6); // AB 6
            theGraph.addEdge(0, 3, 4); // AD 4
            theGraph.addEdge(1, 2, 10); // BC 10
            theGraph.addEdge(1, 3, 7); // BD 7
            theGraph.addEdge(1, 4, 7); // BE 7
            theGraph.addEdge(2, 3, 8); // CD 8
            theGraph.addEdge(2, 5, 6); // CF 6
            theGraph.addEdge(3, 4, 12); // DE 12
            theGraph.addEdge(4, 5, 7); // EF 7
            InitializeComponent();

        }

        private void treeMenu_AfterSelect(object sender, TreeViewEventArgs e)
        {

            if (f != null)
            {
                f.Close();
                f.Dispose();
            }
            switch (e.Node.Name)
            {
                case "nodeGraph": f = new frmGraph(theGraph);
                    f.TopLevel = false;
                    f.Visible = true;
                    f.Dock = DockStyle.Fill;
                    pnlForms.Controls.Add(f);
                    this.Controls.Add(pnlForms);
                    f.Show();
                    break;
                case "nodeDSP":
                    f = new frmDSP(theGraph);
                    f.TopLevel = false;
                    f.Visible = true;
                    f.Dock = DockStyle.Fill;
                    pnlForms.Controls.Add(f);
                    this.Controls.Add(pnlForms);
                    f.Show();
                    break;
                case "nodeBFS":
                    f = new frmBFS(theGraph);
                    f.TopLevel = false;
                    f.Visible = true;
                    f.Dock = DockStyle.Fill;
                    pnlForms.Controls.Add(f);
                    this.Controls.Add(pnlForms);
                    f.Show();
                    break;
                case "nodeMST":
                    f = new frmMST(theGraph);
                    f.TopLevel = false;
                    f.Visible = true;
                    f.Dock = DockStyle.Fill;
                    pnlForms.Controls.Add(f);
                    this.Controls.Add(pnlForms);
                    f.Show();
                    break;
                case "nodeCS":
                        f = new frmCaseStudy();
                    f.TopLevel = false;
                    f.Visible = true;
                    f.Dock = DockStyle.Fill;
                    pnlForms.Controls.Add(f);
                    this.Controls.Add(pnlForms);
                    f.Show();
                    break;
            }
        }

    }
}
