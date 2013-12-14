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
    public partial class frmMST : Form
    {
        static Random r = new Random();
        public frmMST()
        {
            List<OvalShape> listVertex = new List<OvalShape>();
            string[] vertex = { "A", "B", "C", "D", "E" };
            ShapeContainer canvas = new ShapeContainer(); 
                canvas.Parent = this;
                for (int i = 0; i < vertex.Length; i++)
            {

      
                OvalShape o = new OvalShape();
               
                o.Parent = canvas;
                o.Location = new System.Drawing.Point(r.Next(20,200),r.Next(20,200));
                o.Size = new System.Drawing.Size(50, 20);
                listVertex.Add(o); 
               

                Label l = new Label();
                l.Text = vertex[i];
                l.Location = new System.Drawing.Point(o.Location.X + 10, o.Location.Y + 4);
                l.Size = new System.Drawing.Size(35, 13);
                l.Name = "lbl";
                l.AutoSize = true;
                this.Controls.Add(l); 
            }
            for (int i = 0; i < vertex.Length; i++)
            {
                LineShape line = new LineShape();
                line.StartPoint = new Point(listVertex[i].Location.X+5, listVertex[i].Location.Y+3);
                line.EndPoint = new Point(listVertex[(i + 1) % vertex.Length].Location.X+5, listVertex[(i + 1) % vertex.Length].Location.Y+3);
                line.Parent = canvas;
              
            }

            //ShapeContainer canvas = new ShapeContainer();
            //// To draw an oval, substitute  
            //// OvalShape for RectangleShape.
            //Label l = new Label();

            //RectangleShape theShape = new RectangleShape();
            //// Set the form as the parent of the ShapeContainer.
            //canvas.Parent = this;
            //// Set the ShapeContainer as the parent of the Shape.
            //theShape.Parent = canvas;
            //// Set the size of the shape.
            //theShape.Size = new System.Drawing.Size(200, 300);
            //// Set the location of the shape.
            //theShape.Location = new System.Drawing.Point(100, 100);
            //// To draw a rounded rectangle, add the following code:
            //theShape.CornerRadius = 12;
            InitializeComponent();
        }



    }
}
