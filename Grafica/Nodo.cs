using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafica
{
    internal class Nodo
    {        
        static int index;
        string nome;
        List<Arco> archi;
        List<Riga> camminominimo;
        Point centro;
        public Nodo(Point centro)
        {
            this.centro = centro;
            archi = new List<Arco>();
            index++;
            nome = index.ToString();
        }
        /*public Nodo(string nome) : this()
        {
            this.nome += nome;
        }*/

        public string Nome { get => nome; }
        internal List<Arco> Archi { get => archi; }
        internal List<Riga> CamminoMinimo()
        {
            Grafo g = new Grafo(this);

            return camminominimo;
        }
    }
}
