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
        static Random r = new Random();
        public frmGraph()
        {
            List<OvalShape> listVertex = new List<OvalShape>();
            string[] vertex = { "A", "B", "C", "D", "E" ,"F,","G"};
            ShapeContainer canvas = new ShapeContainer();
            canvas.Parent = this;
            
            TepeleriYerlestir(listVertex, vertex, canvas);
            AyritlariYerlestir(listVertex, vertex, canvas);
            InitializeComponent();
        }

        private void TepeleriYerlestir(List<OvalShape> listVertex, string[] vertex, ShapeContainer canvas)
        {
            int sacilim = 50;
            for (int i = 0; i < vertex.Length; i++)
            {
                OvalShape o = new OvalShape();
                o.Parent = canvas;
                listVertex.Add(o);
                if (i == 0)
                    o.Location = new System.Drawing.Point(180, 24);

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
                l.Text = vertex[i];
                l.Location = new System.Drawing.Point(o.Location.X + 15, o.Location.Y + 4);
                l.Size = new System.Drawing.Size(35, 13);
                l.AutoSize = true;
                this.Controls.Add(l);

            }
        }

        private static void AyritlariYerlestir(List<OvalShape> listVertex, string[] vertex, ShapeContainer canvas)
        {
            for (int i = 0; i < vertex.Length; i++)
            {
                LineShape line = new LineShape();
                line.StartPoint = new Point(listVertex[i].Location.X + 20, listVertex[i].Location.Y + 5);
                line.EndPoint = new Point(listVertex[(i + 1) % vertex.Length].Location.X + 15, listVertex[(i + 1) % vertex.Length].Location.Y + 4);
                line.Parent = canvas;

            }
        }

       



    }
}
