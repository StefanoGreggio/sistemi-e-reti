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
        List<Riga> listaRighe;
        Point centro;
        public Nodo(Point centro)
        {
            this.centro = centro;
            listaRighe = new List<Riga>();            
            archi = new List<Arco>();
            nome = index.ToString();
            index++;
            
        }

        public Nodo()
        {
            listaRighe = new List<Riga>();
        }

        public string Nome { get => nome; }
        internal List<Arco> Archi { get => archi; }
        internal List<Riga> ListaRighe { get => listaRighe; set => listaRighe = value; }
        public Point Centro { get => centro; set => centro = value; }
    }
}
