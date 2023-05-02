﻿using System;
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
        Label l;
        List<Point> centri;
        List<Punti> linee;
        List<Riga> righe;
        Point p1;
        Point p2;
        Grafo grafo;
        bool disegnaCerchio;
        bool buttonCerchio;
        bool buttonLinea;
        int raggio;
        int distanza;

        public Form1()
        {
            InitializeComponent();
            penna = new Pen(Color.Black, 1);
            disegnaCerchio = false;
            raggio = 10;
            distanza = 20;
            centri = new List<Point>();
            buttonCerchio = true;
            buttonLinea = false;
            linee = new List<Punti>();
            righe = new List<Riga>();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            foglio = e.Graphics;
            if (disegnaCerchio)
            {
                foreach (Point p in centri)
                {
                    foglio.DrawEllipse(penna, p.X, p.Y, 1, 1);
                    foglio.DrawEllipse(penna, p.X - raggio, p.Y - raggio, raggio * 2, raggio * 2);                    
                }
                for (int i = 0; i < linee.Count; i++)
                {
                    foglio.DrawLine(penna, linee[i].P1, linee[i].P2);
                }
            }
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            
            bool distanzaOK = true;
            if (buttonCerchio)
            {
                Nodo n;
                l = new Label();                
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
                        ScriviLabel(n, e);
                        grafo.Add(n);
                    }
                }
                else
                {
                    centri.Add(e.Location);
                    n = new Nodo(e.Location);
                    ScriviLabel(n, e);
                    grafo = new Grafo(n);
                   
                }
            }
            else if (buttonLinea == true)
            {
                if (p1 != p2)
                {
                    for (int i = 0; i < centri.Count; i++)
                    {
                        if (Math.Sqrt(Math.Pow(centri[i].X - e.X, 2) + Math.Pow(centri[i].Y - e.Y, 2)) < raggio)
                        {
                            p2.X = centri[i].X;
                            p2.Y = centri[i].Y;
                            linee.Add(new Punti(p1, p2, new Riga(new Nodo(p1).Nome, new Nodo(p2).Nome, (int)Math.Sqrt(Math.Pow(p2.X - p1.X, 2) + Math.Pow(p2.Y - p1.Y, 2)))));                            
                            p1 = p2;
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < centri.Count; i++)
                    {
                        if (Math.Sqrt(Math.Pow(centri[i].X - e.X, 2) + Math.Pow(centri[i].Y - e.Y, 2)) < raggio)
                        {
                            p1.X = centri[i].X;
                            p1.Y = centri[i].Y;
                        }
                    }
                }
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            disegnaCerchio = true;
            this.Invalidate();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (buttonCerchio == false)
            {
                btn_cerchio.Enabled = false;
                btn_linea.Enabled = true;
                buttonCerchio = true;
                buttonLinea = false;
            }
        }

        private void btn_linea_Click(object sender, EventArgs e)
        {
            if (buttonLinea == false)
            {
                btn_cerchio.Enabled = true;
                btn_linea.Enabled = false;
                buttonCerchio = false;
                buttonLinea = true;
            }
        }

        void ScriviLabel(Nodo n, MouseEventArgs e)
        {
            l.Text = n.Nome;
            l.Location = e.Location;
            l.AutoSize = true;
            l.Font = new Font("Calibri", 12);
            l.ForeColor = Color.Black;            
            this.Controls.Add(l);
        }
    }
}
