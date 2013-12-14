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
        public Main()
        {
            InitializeComponent();

        }

        private void treeMenu_AfterSelect(object sender, TreeViewEventArgs e)
        {

            if (f != null)
                f.Close();
            switch (e.Node.Name)
            {
                case "nodeGraph": f = new frmGraph();
                    f.TopLevel = false;
                    f.Visible = true;
                    f.Dock = DockStyle.Fill;
                    pnlForms.Controls.Add(f);
                    this.Controls.Add(pnlForms);
                    f.Show();
                    break;
                case "nodeDSP":
                    f = new frmDSP();
                    f.TopLevel = false;
                    f.Visible = true;
                    f.Dock = DockStyle.Fill;
                    pnlForms.Controls.Add(f);
                    this.Controls.Add(pnlForms);
                    f.Show();
                    break;
                case "nodeBFS":
                    f = new frmBFS();
                    f.TopLevel = false;
                    f.Visible = true;
                    f.Dock = DockStyle.Fill;
                    pnlForms.Controls.Add(f);
                    this.Controls.Add(pnlForms);
                    f.Show();
                    break;
                case "nodeMST":
                      f = new frmMST();
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
