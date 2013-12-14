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
        static int INFINITY = 1000000;
        Graph theGraph;
        public frmDSP(Graph g)
        {
            theGraph = g;
            g.path();
             List<OvalShape> listOvalVertex = new List<OvalShape>();
            ShapeContainer canvas = new ShapeContainer();
            canvas.Parent = this;

            TepeleriYerlestir(listOvalVertex, g.sPath, canvas,g.vertexList);
            AyritlariYerlestir(listOvalVertex, g.sPath, canvas);
            InitializeComponent();
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
                    o.Location = new System.Drawing.Point(180, 90);

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
           
                for (int i = 1; i < shortestPath.Count(); i++)
                {
       
                        LineShape line = new LineShape();
                        line.StartPoint = new Point(listVertex[shortestPath[i].parentVert].Location.X + 20, listVertex[shortestPath[i].parentVert].Location.Y + 5);
                        line.EndPoint = new Point(listVertex[i].Location.X + 15, listVertex[i].Location.Y + 4);
                        line.Parent = canvas;
                     

                        Label l = new Label();
                        l.Text = shortestPath[i].distance.ToString();
                        l.Location = new System.Drawing.Point((3 * line.StartPoint.X + line.EndPoint.X) / 4, (3 * line.StartPoint.Y + line.EndPoint.Y) / 4);
                        l.Size = new System.Drawing.Size(35, 13);
                        l.AutoSize = true;
                        this.Controls.Add(l);

                    
                }
            

        }

     
    }
}
