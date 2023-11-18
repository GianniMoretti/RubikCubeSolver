using System.Collections.Generic;

namespace RubikCube.Solver
{
    public class Algorithm
    {
        private List<Move> listaMosse;
        public Algorithm()
        {
            listaMosse = new List<Move>();
        }
        public void Add(Move item)
        {
            listaMosse.Add(item);
        }
        public void AddRange(params Move[] mosse)
        {
            listaMosse.AddRange(mosse);
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
        public static Algorithm operator + (Algorithm left, Algorithm right)
        {
            foreach (var mossa in right.listaMosse)
            {
                left.Add(mossa);
            }
            return left;
        } 
    }
}
