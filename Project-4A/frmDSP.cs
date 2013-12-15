using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic.PowerPacks;

namespace Project_4A
{
    public partial class frmDSP : Form
    {
        Graph theGraph;
        List<OvalShape> listOvalVertex = new List<OvalShape>();
        List<LineShape> listLines = new List<LineShape>();
        List<Label> listAgirliklar = new List<Label>();
        ShapeContainer canvas = new ShapeContainer();
        
        public frmDSP(Graph g)
        {
            InitializeComponent();
            theGraph = g;
            canvas.Parent = this;
            TepeleriYerlestir(listOvalVertex, theGraph.sPath, canvas, theGraph.vertexList);
            btnDSP.Enabled = false;
            for (int i = 0; i < theGraph.vertexList.Length; i++)
            {
                cmbIlkTepe.Items.Add(theGraph.vertexList[i].label);
                cmbIkinciTepe.Items.Add(theGraph.vertexList[i].label);
            }
        }

        private void TepeleriYerlestir(List<OvalShape> listVertex, DistPar[] vertex, ShapeContainer canvas, Vertex[] vertexList)
        {
            int sacilim = 80;
            for (int i = 0; i < vertex.Length; i++)
            {
                OvalShape o = new OvalShape();
                o.Parent = canvas;
                listVertex.Add(o);
                if (i == 0)
                    o.Location = new System.Drawing.Point(300, 140);

                else if (Convert.ToDouble(i) / Convert.ToDouble(vertex.Length) < 0.25)
                {
                    o.Location = new System.Drawing.Point(listVertex[i - 1].Location.X + sacilim, listVertex[i - 1].Location.Y + sacilim);
                }
                else if (Convert.ToDouble(i) / Convert.ToDouble(vertex.Length) < 0.5)
                    o.Location = new System.Drawing.Point(listVertex[i - 1].Location.X - sacilim, listVertex[i - 1].Location.Y + sacilim);
                else if (Convert.ToDouble(i) / Convert.ToDouble(vertex.Length) < 0.75)
                    o.Location = new System.Drawing.Point(listVertex[i - 1].Location.X - sacilim, listVertex[i - 1].Location.Y - sacilim);
                else
                    o.Location = new System.Drawing.Point(listVertex[i - 1].Location.X + sacilim, listVertex[i - 1].Location.Y - sacilim);
                o.Size = new System.Drawing.Size(50, 20);


                Label l = new Label();
                l.Text = vertexList[i].label.ToString();
                l.Location = new System.Drawing.Point(o.Location.X + 15, o.Location.Y + 4);
                l.Size = new System.Drawing.Size(35, 13);
                l.AutoSize = true;
                this.Controls.Add(l);
               
            }
        }
        private void AyritlariYerlestir(List<OvalShape> listVertex, DistPar[] shortestPath, ShapeContainer canvas)
        {
            for (int i = 0; i < listLines.Count; i++)
            {
                listLines[i].Dispose();
                listAgirliklar[i].Dispose();
            }
            listAgirliklar.Clear();
            listLines.Clear();

            List<Vertex> ugranilanTepeler = new List<Vertex>();
            ugranilanTepeler.Add(theGraph.vertexList[cmbIkinciTepe.SelectedIndex]);
            while (cmbIlkTepe.SelectedIndex != Array.IndexOf(theGraph.vertexList, ugranilanTepeler.Last()) ) 
                ugranilanTepeler.Add(theGraph.vertexList[shortestPath[Array.IndexOf(theGraph.vertexList, ugranilanTepeler.Last())].parentVert]);
           

            for (int i = 0; i < ugranilanTepeler.Count-1; i++)
            {

                LineShape line = new LineShape();
                line.BorderColor = Color.Red;
                line.StartPoint = new Point(listVertex[Array.IndexOf(theGraph.vertexList, ugranilanTepeler[i])].Location.X + 20, listVertex[Array.IndexOf(theGraph.vertexList, ugranilanTepeler[i])].Location.Y + 5);
                line.EndPoint = new Point(listVertex[Array.IndexOf(theGraph.vertexList, ugranilanTepeler[i+1])].Location.X + 15, listVertex[Array.IndexOf(theGraph.vertexList, ugranilanTepeler[i+1])].Location.Y + 4);
                line.Parent = canvas;
                listLines.Add(line);

                Label l = new Label();
                l.Text = theGraph.adjMat[Array.IndexOf(theGraph.vertexList, ugranilanTepeler[i]), Array.IndexOf(theGraph.vertexList, ugranilanTepeler[i + 1])].ToString();
                l.Location = new System.Drawing.Point((3 * line.StartPoint.X + line.EndPoint.X) / 4, (3 * line.StartPoint.Y + line.EndPoint.Y) / 4);
                l.Size = new System.Drawing.Size(35, 13);
                l.AutoSize = true;
                this.Controls.Add(l);
                listAgirliklar.Add(l);
            }
        }

        private void cmbIlkTepe_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((cmbIlkTepe.SelectedIndex == cmbIkinciTepe.SelectedIndex) || cmbIkinciTepe.SelectedIndex == -1)
                btnDSP.Enabled = false;
            else btnDSP.Enabled = true;
        }

        private void cmbIkinciTepe_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((cmbIlkTepe.SelectedIndex == cmbIkinciTepe.SelectedIndex) || cmbIlkTepe.SelectedIndex == -1)
                btnDSP.Enabled = false;
            else btnDSP.Enabled = true;
        }

        private void btnDSP_Click(object sender, EventArgs e)
        {
            theGraph.path(cmbIlkTepe.SelectedIndex);
            AyritlariYerlestir(listOvalVertex, theGraph.sPath, canvas);
        }
    }
}
