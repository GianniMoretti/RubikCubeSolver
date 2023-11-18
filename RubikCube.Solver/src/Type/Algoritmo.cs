using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RubikCube.Core.Library
{
    public class Algoritmo
    {
        private List<Mossa> listaMosse;
        public Algoritmo()
        {
            listaMosse = new List<Mossa>();
        }
        public void Add(Mossa item)
        {
            listaMosse.Add(item);
        }

        public void Add(params Mossa[] items)
        {
            listaMosse.AddRange(items);
        }
        public override string ToString()
        {
            string Alg = "";

            for (int i = 0; i < listaMosse.Count; i++)
            {
                if (i == 0)
                    Alg += listaMosse[0].ToString();
                else
                    Alg += "," + listaMosse[i].ToString();
            }

            return Alg;
        }
        public static Algoritmo operator + (Algoritmo left, Algoritmo right)
        {
            foreach (var mossa in right.listaMosse)
            {
                left.Add(mossa);
            }
            return left;
        } 
    }
}
