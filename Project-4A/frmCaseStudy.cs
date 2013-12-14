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
    public partial class frmCaseStudy : Form
    {
        Graph theGraph;
        static int INFINITY = 1000000;
        public frmCaseStudy()
        {
            theGraph = new Graph();
            List<OvalShape> listOvalVertex = new List<OvalShape>();
            ShapeContainer canvas = new ShapeContainer();
            canvas.Parent = this;
            theGraph.addVertex("John"); // 0 (start for mst)
            theGraph.addVertex("Olivia"); // 1
            theGraph.addVertex("Celine"); // 2
            theGraph.addVertex("Winston"); // 3
            theGraph.addVertex("Jack"); // 4
            theGraph.addVertex("Chloe"); // 5
            theGraph.addEdge(0, 1, 12); // John Olivia 12
            theGraph.addEdge(0, 5, 9); // John Chloe 9
            theGraph.addEdge(0, 4, 7); // John Jake 7
            theGraph.addEdge(1, 4, 8); // Olivia Jack 8
            theGraph.addEdge(1, 2, 5); // Olivia Celine 5
            theGraph.addEdge(2, 3, 10); // Celine Winston 10
            theGraph.addEdge(2, 4, 6); // Celine Jack 6
            theGraph.addEdge(3, 4, 16); // Winston Jack 16
            theGraph.addEdge(3, 5, 15); // Winston Chloe 15
            theGraph.addEdge(5, 4, 4); // Chloe Jack 4

            TepeleriYerlestir(listOvalVertex, theGraph.vertexList, canvas);
            AyritlariYerlestir(listOvalVertex, theGraph.adjMat, canvas);
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
                    o.Location = new System.Drawing.Point(250, 90);
                //else if(i==4)
                //    o.Location = new System.Drawing.Point(listVertex[i - 1].Location.X - sacilim, listVertex[i - 1].Location.Y + sacilim);
          
                else if (Convert.ToDouble(i) / Convert.ToDouble(vertex.Length) < 0.25)
                {
                    o.Location = new System.Drawing.Point(listVertex[i - 1].Location.X + sacilim, listVertex[i - 1].Location.Y + sacilim);
                }
                else if (Convert.ToDouble(i) / Convert.ToDouble(vertex.Length) < 0.50)
                    o.Location = new System.Drawing.Point(listVertex[i - 1].Location.X - sacilim, listVertex[i - 1].Location.Y + sacilim);
                else if (Convert.ToDouble(i) / Convert.ToDouble(vertex.Length) < 0.75)
                    o.Location = new System.Drawing.Point(listVertex[i - 1].Location.X - sacilim, listVertex[i - 1].Location.Y - sacilim);
                else
                    o.Location = new System.Drawing.Point(listVertex[i - 1].Location.X + sacilim, listVertex[i - 1].Location.Y - sacilim);
                o.Size = new System.Drawing.Size(50, 20);

                if (i == 3)//Winston için özel düzeltme (overlapping edge)
                    o.Location = new Point(o.Location.X - sacilim, o.Location.Y + sacilim);
                Label l = new Label();
                l.Text = vertex[i].label;
                l.Location = new System.Drawing.Point(o.Location.X + 10, o.Location.Y + 4);
                l.Size = new System.Drawing.Size(35, 13);
                l.AutoSize = true;
                this.Controls.Add(l);

            }
        }

        private void AyritlariYerlestir(List<OvalShape> listVertex, int[,] adjacencyMatrix, ShapeContainer canvas)
        {
            bool[,] overdraw = new bool[adjacencyMatrix.GetLength(0), adjacencyMatrix.GetLength(1)];
            for (int i = 0; i < adjacencyMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < adjacencyMatrix.GetLength(1); j++)
                {
                    if (adjacencyMatrix[i, j] != INFINITY && overdraw[j, i] == false)
                    {
                        LineShape line = new LineShape();
                        line.StartPoint = new Point(listVertex[i].Location.X + 20, listVertex[i].Location.Y + 5);
                        line.EndPoint = new Point(listVertex[j].Location.X + 15, listVertex[j].Location.Y + 4);
                        line.Parent = canvas;
                        overdraw[i, j] = true;

                        Label l = new Label();
                        l.Text = adjacencyMatrix[i, j].ToString();
                        l.Location = new System.Drawing.Point((3 * line.StartPoint.X + line.EndPoint.X) / 4, (3 * line.StartPoint.Y + line.EndPoint.Y) / 4);
                        l.Size = new System.Drawing.Size(35, 13);
                        l.AutoSize = true;
                        this.Controls.Add(l);

                    }
                }
            }

        }
    }
}
