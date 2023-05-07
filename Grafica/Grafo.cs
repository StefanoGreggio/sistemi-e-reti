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
        public Grafo()
        {
            nodi = new List<Nodo>();            
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


        /// <summary>
        /// metodo che calcola il cammino minimo secondo il metodo di dijkstra
        /// </summary>
        /// <param name="nodoIniziale"></param>
        /// <returns>
        ///  ritorna il cammino minimo da il nodo di partenza a tutti gli altri
        /// </returns>
        public List<Riga> CamminoMinimo(Nodo nodoIniziale)
        {
            List<Riga> finale = new List<Riga>();
            List<Riga> indagine = new List<Riga>();
            bool[] visitati = new bool[nodi.Count];
            
            //inizializzazione dei nodi a infinito
            foreach (Nodo nodo in nodi)
            {
                indagine.Add(new Riga(nodo.Nome, nodo.Nome, int.MaxValue));
            }

            for (int i = 0; i < visitati.Length; i++)
            {
                visitati[i] = false;
            }

            //inizializzo il nodo iniziale a 0
            int index = indagine.FindIndex(x => x.Da == nodoIniziale.Nome);
            if (index != -1)
            {
                indagine[index].Costo = 0;
            }

            //inizio ciclo per il calcolo del cammino minimo
            for (int i = 0; i < nodi.Count; i++)
            {
                int u = distanzaMinima(indagine, visitati);
                visitati[u] = true;

                Dictionary<string, int> mappaValori = CollezioneCosti(nodi);
                for (int v = 0; v < nodi.Count; v++)
                {
                    if (!visitati[v] && mappaValori.TryGetValue(u + "_" + v, out int t) && t != 0  && (indagine[u].Costo + t < indagine[v].Costo))
                    {
                        indagine[v].Costo = indagine[u].Costo + t;
                    }
                    else if (!visitati[v] && mappaValori.TryGetValue(v + "_" + u, out int h) && h != 0 && (indagine[u].Costo + h < indagine[v].Costo))
                    {
                        indagine[v].Costo = indagine[u].Costo + h;
                    }
                }
            }
            finale = indagine.ToList();           
            
            return finale;
        }

        //calcolo della distanza minima dei punti nei nodi che si stanno controllando
        private int distanzaMinima(List<Riga> indagine, bool[] visitati)
        {
            int minDistanza = int.MaxValue;
            int nodoMinimaDistanza = -1;

            for (int i = 0; i < indagine.Count; i++)
            {
                if (!visitati[i] && indagine[i].Costo <= minDistanza)
                {
                    minDistanza = indagine[i].Costo;
                    nodoMinimaDistanza = i;
                }
            }

            return nodoMinimaDistanza;
        }

        //tracciamento delle vie tra i nodi in modo univoco
        private static Dictionary<string, int> CollezioneCosti(List<Nodo> nodi)
        {
            Dictionary<string, int> mappaValori = new Dictionary<string, int>();
            foreach (Nodo n in nodi)
            {
                if (n.ListaRighe != null && n.ListaRighe.Count != 0)
                {
                    foreach (Riga r in n.ListaRighe)
                    {
                        mappaValori.Add(r.Da + "_" + r.A, r.Costo);
                    }
                }
            }

            return mappaValori;
        }
    }
}
