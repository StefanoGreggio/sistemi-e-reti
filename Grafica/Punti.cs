using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafica
{
    class Punti
    {
        Point p1;
        Point p2;
        Riga riga;

        public Punti(Point p1, Point p2, Riga riga)
        {
            P1 = p1;
            P2 = p2;
            this.riga = riga;
        }

        public Point P1 { get => p1; set => p1 = value; }
        public Point P2 { get => p2; set => p2 = value; }
        internal Riga Riga { get => riga; set => riga = value; }
    }
}
