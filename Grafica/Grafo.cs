using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafica
{
    internal class Grafo
    {
        
        List<Nodo> nodi;
        public Grafo(Nodo n)
        {
            nodi = new List<Nodo>();
            Add(n);            
        }

        internal List<Nodo> Nodi { get => nodi; set => nodi = value; }

        public void Add(Nodo n)
        {
            nodi.Add(n);
            for (int i = 0; i < nodi.Count; i++)
                foreach (Arco a in nodi[i].Archi)
                    if (nodi.Find(x => x.Nome.Equals(a.Destinazione.Nome)) is null)
                        nodi.Add(a.Destinazione);
        }
        public List<Riga> CamminoMinimo()
        {
            List<Riga> finale = new List<Riga>();
            List<Riga> indagine = new List<Riga>();            
            foreach (Nodo nodo in nodi)
                indagine.Add(new Riga(nodo.Nome, "", int.MaxValue));
            //indagine[0].Costo = 0;//da far uscire il costo
            do
            {
                for (int i = 0; i < length; i++)
                {

                }
            }
            while ();
            

            finale = indagine;
            return finale;
        }
    }
}
