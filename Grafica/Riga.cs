﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafica
{
    internal class Riga
    {
        
        string da, a;
        int costo;
        public Riga(string da, string a, int costo)
        {
            this.da = da;
            this.a = a;
            this.costo = costo;
        }

        public string Da { get => da; set => da = value; }
        public string A { get => a; set => a = value; }
        public int Costo { get => costo; set => costo = value; }
    }
}
