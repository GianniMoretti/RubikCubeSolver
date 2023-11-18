

namespace RubikCube.Solver
{
    public class Move
    {
        //Senso orario
        public static readonly Move U = new Move("U");
        public static readonly Move F = new Move("F");
        public static readonly Move L = new Move("L");
        public static readonly Move R = new Move("R");
        public static readonly Move B = new Move("B");
        public static readonly Move D = new Move("D");
        public static readonly Move u = new Move("u");
        public static readonly Move f = new Move("f");
        public static readonly Move l = new Move("l");
        public static readonly Move r = new Move("r");
        public static readonly Move b = new Move("b");
        public static readonly Move d = new Move("d");
        public static readonly Move X = new Move("X");
        public static readonly Move Y = new Move("Y");
        public static readonly Move Z = new Move("Z");
        public static readonly Move M = new Move("M");
        public static readonly Move E = new Move("E");
        public static readonly Move S = new Move("S");
        //Senso antiorario
        public static readonly Move U1 = new Move("U1");
        public static readonly Move F1 = new Move("F1");
        public static readonly Move L1 = new Move("L1");
        public static readonly Move R1 = new Move("R1");
        public static readonly Move B1 = new Move("B1");
        public static readonly Move D1 = new Move("D1");
        public static readonly Move u1 = new Move("u1");
        public static readonly Move f1 = new Move("f1");
        public static readonly Move l1 = new Move("l1");
        public static readonly Move r1 = new Move("r1");
        public static readonly Move b1 = new Move("b1");
        public static readonly Move d1 = new Move("d1");
        public static readonly Move X1 = new Move("X1");
        public static readonly Move Y1 = new Move("Y1");
        public static readonly Move Z1 = new Move("Z1");
        public static readonly Move M1 = new Move("M1");
        public static readonly Move E1 = new Move("E1");
        public static readonly Move S1 = new Move("S1");

        private readonly string _mossa;
        private Move(string mossa)
        {
            _mossa = mossa;
        }
        public override string ToString()
        {
            return _mossa;
        }
    }
}
