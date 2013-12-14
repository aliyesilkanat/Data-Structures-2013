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
    public partial class frmGraph : Form
    {
        Graph theGraph;
        static Random r = new Random();
        static int INFINITY = 1000000;
        public frmGraph(Graph g)
        {
            theGraph = g;
            List<OvalShape> listOvalVertex = new List<OvalShape>();
            ShapeContainer canvas = new ShapeContainer();
            canvas.Parent = this;

            TepeleriYerlestir(listOvalVertex, g.vertexList, canvas);
            AyritlariYerlestir(listOvalVertex, g.adjMat, canvas);
            InitializeComponent();
        }

        private void TepeleriYerlestir(List<OvalShape> listVertex, Vertex[] vertex, ShapeContainer canvas)
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
                l.Text = vertex[i].label.ToString();
                l.Location = new System.Drawing.Point(o.Location.X + 15, o.Location.Y + 4);
                l.Size = new System.Drawing.Size(35, 13);
                l.AutoSize = true;
                this.Controls.Add(l);

            }
        }

        private  void AyritlariYerlestir(List<OvalShape> listVertex, int[,] adjacencyMatrix, ShapeContainer canvas)
        {
            bool[,] overdraw = new bool[adjacencyMatrix.GetLength(0), adjacencyMatrix.GetLength(1)];
            for (int i = 0; i < adjacencyMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < adjacencyMatrix.GetLength(1); j++)
                {
                    if (adjacencyMatrix[i, j] != INFINITY && overdraw[j,i]==false)
                    {
                        LineShape line = new LineShape();
                        line.StartPoint = new Point(listVertex[i].Location.X + 20, listVertex[i].Location.Y + 5);
                        line.EndPoint = new Point(listVertex[j].Location.X + 15, listVertex[j].Location.Y + 4);
                        line.Parent = canvas;
                        overdraw[i, j] = true;

                        Label l = new Label();
                        l.Text = adjacencyMatrix[i, j].ToString();
                        l.Location = new System.Drawing.Point((3*line.StartPoint.X + line.EndPoint.X) / 4, (3*line.StartPoint.Y + line.EndPoint.Y) / 4);
                        l.Size = new System.Drawing.Size(35, 13);
                        l.AutoSize = true;
                        this.Controls.Add(l);
               
                    }
                }
            }


            //for (int i = 0; i < listVertex.Count; i++)
            //{
            //    LineShape line = new LineShape();
            //    line.StartPoint = new Point(listVertex[i].Location.X + 20, listVertex[i].Location.Y + 5);
            //    line.EndPoint = new Point(listVertex[(i + 1) % listVertex.Count].Location.X + 15, listVertex[(i + 1) % listVertex.Count].Location.Y + 4);
            //    line.Parent = canvas;

            //}
        }





    }
}
