using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RubikCube.Core.Library
{
    public class Mossa
    {
        //Senso orario
        public static readonly Mossa U = new Mossa("U");
        public static readonly Mossa F = new Mossa("F");
        public static readonly Mossa L = new Mossa("L");
        public static readonly Mossa R = new Mossa("R");
        public static readonly Mossa B = new Mossa("B");
        public static readonly Mossa D = new Mossa("D");
        public static readonly Mossa u = new Mossa("u");
        public static readonly Mossa f = new Mossa("f");
        public static readonly Mossa l = new Mossa("l");
        public static readonly Mossa r = new Mossa("r");
        public static readonly Mossa b = new Mossa("b");
        public static readonly Mossa d = new Mossa("d");
        public static readonly Mossa x = new Mossa("x");
        public static readonly Mossa y = new Mossa("y");
        public static readonly Mossa z = new Mossa("z");
        public static readonly Mossa M = new Mossa("M");
        public static readonly Mossa E = new Mossa("E");
        public static readonly Mossa S = new Mossa("S");
        //Senso antiorario
        public static readonly Mossa U1 = new Mossa("U1");
        public static readonly Mossa F1 = new Mossa("F1");
        public static readonly Mossa L1 = new Mossa("L1");
        public static readonly Mossa R1 = new Mossa("R1");
        public static readonly Mossa B1 = new Mossa("B1");
        public static readonly Mossa D1 = new Mossa("D1");
        public static readonly Mossa u1 = new Mossa("u1");
        public static readonly Mossa f1 = new Mossa("f1");
        public static readonly Mossa l1 = new Mossa("l1");
        public static readonly Mossa r1 = new Mossa("r1");
        public static readonly Mossa b1 = new Mossa("b1");
        public static readonly Mossa d1 = new Mossa("d1");
        public static readonly Mossa x1 = new Mossa("x1");
        public static readonly Mossa y1 = new Mossa("y1");
        public static readonly Mossa z1 = new Mossa("z1");
        public static readonly Mossa M1 = new Mossa("M1");
        public static readonly Mossa E1 = new Mossa("E1");
        public static readonly Mossa S1 = new Mossa("S1");

        private readonly string _mossa;
        private Mossa(string mossa)
        {
            _mossa = mossa;
        }
        public override string ToString()
        {
            return _mossa;
        }
    }
}
