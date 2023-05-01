using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Grafica
{
    public partial class Form1 : Form
    {
        Graphics foglio;
        Pen penna;
        List<Point> centri;
        Grafo grafo;
        bool disegnaVertice;
        int raggio;
        int distanza;

        public Form1()
        {
            InitializeComponent();
            penna = new Pen(Color.Black, 1);
            disegnaVertice = false;
            raggio = 10;
            distanza = 20;
            centri = new List<Point>();
            
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            foglio = e.Graphics;
            if (disegnaVertice)
            {
                foreach (Point p in centri)
                {
                    foglio.DrawEllipse(penna, p.X, p.Y, 1, 1);
                    foglio.DrawEllipse(penna, p.X - raggio, p.Y - raggio, raggio * 2, raggio * 2);

                }
            }
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            Nodo n;
            bool distanzaOK = true;
            if (centri.Count != 0 && !centri.Contains(e.Location))
            {
                for (int i = 0; i < centri.Count; i++)
                {                    
                    if (Math.Sqrt(Math.Pow(centri[i].X - e.X, 2) + Math.Pow(centri[i].Y - e.Y, 2)) < (raggio * 2 + distanza))
                    {
                        distanzaOK = false;
                    }
                }
                if (distanzaOK)
                {
                    centri.Add(e.Location);
                    n = new Nodo(e.Location);                    
                    grafo.Add(n);
                }
            }
            else
            {
                centri.Add(e.Location);
                n = new Nodo(e.Location);
                grafo = new Grafo(n);
                
            }


        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            disegnaVertice = true;
            this.Invalidate();
        }
    }
}
