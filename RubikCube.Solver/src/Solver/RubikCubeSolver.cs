using System;
using static RubikCube.Solver.Move;

namespace RubikCube.Solver
{
    public class RubikCubeSolver
    {
        private Cube cubo;
        private PositionResearcher PosResearcher;
        public RubikCubeSolver(Cube cubo)
        {
            this.cubo = cubo;
            PosResearcher = new PositionResearcher(cubo);
        }

        public string Cross()
        {
            string returningalg = "";
            string alg = "";
            EdgePosition position = EdgePosition.Unknown;

            for (int i = 0; i < 4; i++)
            {
                Edge sp = new Edge { primo = cubo.Down[1, 1], secondo = cubo.Front[1, 1] };
                if (PosResearcher.EdgeResearcher(sp, out position))
                {
                    switch (position)
                    {
                        case EdgePosition.UpFront:
                            if (cubo.Front[0, 1] == sp.secondo)
                                alg += "F,F,";
                            else
                                alg += "U1,R1,F,R,";
                            break;
                        case EdgePosition.UpRight:
                            if (cubo.Right[0, 1] == sp.secondo)
                                alg += "U,F,F,";
                            else
                                alg += "R1,F,R,";
                            break;
                        case EdgePosition.UpLeft:
                            if (cubo.Left[0, 1] == sp.secondo)
                                alg += "U1,F,F,";
                            else
                                alg += "L,F1,L1,";
                            break;
                        case EdgePosition.UpBack:
                            if (cubo.Back[0, 1] == sp.secondo)
                                alg += "U,U,F,F,";
                            else
                                alg += "U,R1,F,R,";
                            break;
                        case EdgePosition.MiddleFrontRight:
                            if (cubo.Front[1, 2] == sp.secondo)
                                alg += "F,";
                            else
                                alg += "R,U,R1,F,F,";
                            break;
                        case EdgePosition.MiddleFrontLeft:
                            if (cubo.Front[1, 0] == sp.secondo)
                                alg += "F1,";
                            else
                                alg += "L1,U1,L,F,F,";
                            break;
                        case EdgePosition.MiddleBackRight:
                            if (cubo.Right[1, 2] == sp.secondo)
                                alg += "B,U,B1,R1,F,R,";
                            else
                                alg += "B,U,U,B1,F,F,";
                            break;
                        case EdgePosition.MiddleBackLeft:
                            if (cubo.Left[1, 0] == sp.secondo)
                                alg += "L,U1,L1,F,F,";
                            else
                                alg += "B1,U,U,B,F,F,";
                            break;
                        case EdgePosition.DownFront:
                            if (cubo.Front[2, 1] == sp.secondo)
                                alg += "";
                            else
                                alg += "F1,R,U,R1,F,F,";
                            break;
                        case EdgePosition.DownRight:
                            if (cubo.Right[2, 1] == sp.secondo)
                                alg += "R1,R1,U,F,F,";
                            else
                                alg += "R,F,";
                            break;
                        case EdgePosition.DownLeft:
                            if (cubo.Left[2, 1] == sp.secondo)
                                alg += "L,L,U1,F,F,";
                            else
                                alg += "L1,F1,";
                            break;
                        case EdgePosition.DownBack:
                            if (cubo.Back[2, 1] == sp.secondo)
                                alg += "B,B,U,U,F,F,";
                            else
                                alg += "B,B,U,R1,F,R,";
                            break;
                        default:
                            break;
                    }
                }
                else throw new Exception("error 404: spigolo not found");
                cubo.ExecuteAlgorithm(alg);
                returningalg += alg;
                cubo.ExecuteAlgorithm("Y");
                returningalg += "Y,";
                alg = "";

            }
            return returningalg;
        }
        public string Face()
        {
            string returningalg = "";
            string alg = "";
            AnglePosition angoloPosition = AnglePosition.Unknown;
            for (int i = 0; i < 4; i++)
            {
                Angle a = new Angle { primo = cubo.Down[1, 1], secondo = cubo.Front[1, 1], terzo = cubo.Right[1, 1] };
                if (PosResearcher.AngleResearcher(a, out angoloPosition))
                {
                    switch (angoloPosition)
                    {
                        case AnglePosition.UpFrontRight:
                            if (cubo.Front[0, 2] == a.primo)
                                alg += "U,R,U1,R1,";
                            else if (cubo.Front[0, 2] == a.terzo)
                                alg += "R,U1,R1,U,F1,U,F,";
                            else
                                alg += "U1,F1,U,F,";
                            break;
                        case AnglePosition.UpFrontLeft:
                            if (cubo.Front[0, 0] == a.primo)
                                alg += "U1,U1,F1,U,F,";
                            else if (cubo.Front[0, 0] == a.terzo)
                                alg += "U1,U,R,U1,R1,";
                            else
                                alg += "U1,R,U1,R1,U,F1,U,F,";
                            break;
                        case AnglePosition.UpBackRight:
                            if (cubo.Right[0, 2] == a.primo)
                                alg += "U,U,R,U1,R1,";
                            else if (cubo.Right[0, 2] == a.terzo)
                                alg += "U,R,U1,R1,U,F1,U,F,";
                            else
                                alg += "U,U1,F1,U,F,";
                            break;
                        case AnglePosition.UpBackLeft:
                            if (cubo.Left[0, 0] == a.primo)
                                alg += "U1,U1,U1,F1,U,F,";
                            else if (cubo.Left[0, 0] == a.terzo)
                                alg += "U1,U1,U,R,U1,R1,";
                            else
                                alg += "U1,U1,R,U1,R1,U,F1,U,F,";
                            break;
                        case AnglePosition.DownFrontRight:
                            if (cubo.Front[2, 2] == a.primo)
                                alg += "R,U,R1,U1,R,U1,R1,U,F1,U,F,";
                            else if (cubo.Front[2, 2] == a.terzo)
                                alg += "R,U,R1,U1,U1,F1,U,F,";
                            else
                                alg += "";
                            break;
                        case AnglePosition.DownFrontLeft:
                            if (cubo.Front[2, 0] == a.primo)
                                alg += "F,U,F1,U1,U1,U1,F1,U,F,";
                            else if (cubo.Front[2, 0] == a.terzo)
                                alg += "F,U,F1,U1,U1,U,R,U1,R1,";
                            else
                                alg += "F,U,F1,U1,U1,R,U1,R1,U,F1,U,F,";
                            break;
                        case AnglePosition.DownBackRight:
                            if (cubo.Right[2, 2] == a.primo)
                                alg += "B,U,B1,R,U1,R1,U,F1,U,F,";
                            else if (cubo.Right[2, 2] == a.terzo)
                                alg += "B,U,B1,U1,F1,U,F,";
                            else
                                alg += "B,U,B1,U,R,U1,R1,";
                            break;
                        case AnglePosition.DownBackLeft:
                            if (cubo.Left[2, 0] == a.primo)
                                alg += "B1,U1,B,U1,R,U1,R1,U,F1,U,F,";
                            else if (cubo.Left[2, 0] == a.terzo)
                                alg += "B1,U1,B,U1,U1,F1,U,F,";
                            else
                                alg += "B1,U1,B,R,U1,R1,";
                            break;
                        case AnglePosition.Unknown:
                            break;
                        default:
                            break;
                    }
                }
                cubo.ExecuteAlgorithm(alg);
                returningalg += alg;
                cubo.ExecuteAlgorithm("Y");
                returningalg += "Y,";
                alg = "";
            }
            return returningalg;

        }

        public string SecondLayer()
        {
            string returningalg = "";
            string alg = "";
            EdgePosition position = EdgePosition.Unknown;

            for (int i = 0; i < 4; i++)
            {
                Edge sp = new Edge { primo = cubo.Front[1, 1], secondo = cubo.Right[1, 1] };
                if (PosResearcher.EdgeResearcher(sp, out position))
                {
                    switch (position)
                    {
                        case EdgePosition.UpFront:
                            if (cubo.Front[0, 1] == sp.secondo)
                                alg += "U1,U1,F1,U,F,U,R,U1,R1,";
                            else
                                alg += "U,R,U1,R1,U1,F1,U,F,";
                            break;
                        case EdgePosition.UpRight:
                            if (cubo.Right[0, 1] == sp.secondo)
                                alg += "U,U1,U1,F1,U,F,U,R,U1,R1,";
                            else
                                alg += "U,U,R,U1,R1,U1,F1,U,F,";
                            break;
                        case EdgePosition.UpLeft:
                            if (cubo.Left[0, 1] == sp.secondo)
                                alg += "U1,U1,U1,F1,U,F,U,R,U1,R1,";
                            else
                                alg += "U1,U,R,U1,R1,U1,F1,U,F,";
                            break;
                        case EdgePosition.UpBack:
                            if (cubo.Back[0, 1] == sp.secondo)
                                alg += "U,U,U1,U1,F1,U,F,U,R,U1,R1,";
                            else
                                alg += "U,U,U,R,U1,R1,U1,F1,U,F,";
                            break;
                        case EdgePosition.MiddleFrontRight:
                            if (cubo.Front[1, 2] == sp.secondo)
                                alg += "R,U1,R1,U1,F1,U,F,U,U,U,R,U1,R1,U1,F1,U,F,";
                            else
                                alg += "";
                            break;
                        case EdgePosition.MiddleFrontLeft:
                            if (cubo.Front[1, 0] == sp.secondo)
                                alg += "L1,U,L,U,F,U1,F1,U,U,U,R,U1,R1,U1,F1,U,F,";
                            else
                                alg += "L1,U,L,U,F,U1,F1,U,U,U1,U1,F1,U,F,U,R,U1,R1,";
                            break;
                        case EdgePosition.MiddleBackRight:
                            if (cubo.Right[1, 2] == sp.secondo)
                                alg += "R1,U,R,U,B,U1,B1,U1,U1,F1,U,F,U,R,U1,R1,";
                            else
                                alg += "R1,U,R,U,B,U1,B1,U,R,U1,R1,U1,F1,U,F,";
                            break;
                        case EdgePosition.MiddleBackLeft:
                            if (cubo.Left[1, 0] == sp.secondo)
                                alg += "L,U1,L1,U1,B1,U,B,U1,U1,F1,U,F,U,R,U1,R1,";
                            else
                                alg += "L,U1,L1,U1,B1,U,B,U,R,U1,R1,U1,F1,U,F,";
                            break;
                        default:
                            break;
                    }
                }
                cubo.ExecuteAlgorithm(alg);
                returningalg += alg;
                cubo.ExecuteAlgorithm("Y");
                returningalg += "Y,";
                alg = "";
            }
            return returningalg;

        }
        public string OLL()
        {
            //TODO: Da finire
            int countY = 0;
            string tmp = "";
            string[] OllConf = FridrichOLLAlgorithm.OLLConfiguration();

            for (int i = 0; i < 4; i++)
            {
                string conf = CheckSideLayer(cubo.Back) + CheckSideLayer(cubo.Right) + CheckSideLayer(cubo.Front) + CheckSideLayer(cubo.Left);

                for (int e = 0; e < 3; e++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (cubo.Up[e, j] == Color.Giallo) conf += "1";
                        else conf += "0";
                    }
                }
                for (int j = 0; j < OllConf.Length; j++)
                {
                    if (conf == OllConf[j])
                    {
                        cubo.ExecuteAlgorithm(FridrichOLLAlgorithm.ListaAlgoritmi[j].ToString());
                        if (countY != 0)
                        {
                            while (countY != 4)
                            {
                                cubo.ExecuteAlgorithm("Y");
                                countY++;
                            }
                        }
                        return tmp + FridrichOLLAlgorithm.ListaAlgoritmi[j].ToString() + ",";
                    }
                }
                cubo.ExecuteAlgorithm("Y");
                countY++;
                tmp += "Y,";
            }
            throw new Exception("Algoritm not found");
        }
        private string CheckSideLayer(Color[,] Mat)
        {
            string alg = "";

            for (int i = 2; i >= 0; i--)
            {
                if (Mat[0, i] == Color.Giallo) alg += "1";
                else alg += "0";
            }
            return alg;
        }

        public string PLL()
        {
            Algorithm a = new Algorithm();

            for (int i = 0; i < 4; i++)  // Secondo me basta 3 volte?
            {
                for (int j = 0; j < 4; j++)
                {
                    Angle upfrontleft = new Angle() { primo = cubo.Up[1, 1], secondo = cubo.Left[1, 1], terzo = cubo.Front[1, 1] };
                    Angle upbackleft = new Angle() { primo = cubo.Up[1, 1], secondo = cubo.Left[1, 1], terzo = cubo.Back[1, 1] };
                    Angle upbackright = new Angle() { primo = cubo.Up[1, 1], secondo = cubo.Back[1, 1], terzo = cubo.Right[1, 1] };
                    Angle upfrontright = new Angle() { primo = cubo.Up[1, 1], secondo = cubo.Right[1, 1], terzo = cubo.Front[1, 1] };

                    // A1
                    if (cubo.Front[0, 1] == cubo.Front[1, 1] && cubo.Right[0, 1] == cubo.Right[1, 1] && cubo.Left[0, 1] == cubo.Left[1, 1] && cubo.Back[0, 1] == cubo.Back[1, 1] &&
                        cubo.UpFrontRight == upbackleft && cubo.UpFrontLeft == upfrontleft &&  cubo.UpBackRight == upfrontright && cubo.UpBackLeft == upbackright)
                    {
                        a.AddRange(X, R1, U, R1, D, D, R, U1, R1, D, D, R, R, X1);
                        cubo.ExecuteAlgorithm(a.ToString());
                        return a.ToString();
                    }
                    // A2
                    else if (cubo.Front[0, 1] == cubo.Front[1, 1] && cubo.Right[0, 1] == cubo.Right[1, 1] && cubo.Left[0, 1] == cubo.Left[1, 1] && cubo.Back[0, 1] == cubo.Back[1, 1] &&
                                upfrontleft == cubo.UpBackRight && upfrontright == cubo.UpFrontLeft && upbackright == cubo.UpFrontRight)
                    {
                        a.AddRange(X1, R, U1, R, D, D, R1, U, R, D, D, R, R, X);
                        cubo.ExecuteAlgorithm(a.ToString());
                        return a.ToString();
                    }
                    // U1
                    else if (cubo.Front[0, 1] == cubo.Left[1, 1] && cubo.Right[0, 1] == cubo.Front[1, 1] && cubo.Left[0, 1] == cubo.Right[1, 1] && cubo.Back[0, 1] == cubo.Back[1, 1] &&
                                upfrontleft == cubo.UpFrontLeft && upfrontright == cubo.UpFrontRight && upbackright == cubo.UpBackRight)
                    {
                        a.AddRange(R, R, U, R, U, R1, U1, R1, U1, R1, U, R1);
                        cubo.ExecuteAlgorithm(a.ToString());
                        return a.ToString();
                    }
                    // U2
                    else if (cubo.Front[0, 1] == cubo.Right[1, 1] && cubo.Right[0, 1] == cubo.Left[1, 1] && cubo.Left[0, 1] == cubo.Front[1, 1] && cubo.Back[0, 1] == cubo.Back[1, 1] &&
                                upfrontleft == cubo.UpFrontLeft && upfrontright == cubo.UpFrontRight && upbackright == cubo.UpBackRight)
                    {
                        a.AddRange(R, U1, R, U, R, U, R, U1, R1, U1, R, R);
                        cubo.ExecuteAlgorithm(a.ToString());
                        return a.ToString();
                    }
                    // H
                    else if (cubo.Front[0, 1] == cubo.Back[1, 1] && cubo.Right[0, 1] == cubo.Left[1, 1] &&
                                upfrontleft == cubo.UpFrontLeft && upfrontright == cubo.UpFrontRight && upbackright == cubo.UpBackRight)
                    {
                        a.AddRange(M, M, U, M, M, U, U, M, M, U, M, M);
                        cubo.ExecuteAlgorithm(a.ToString());
                        return a.ToString();
                    }
                    // T
                    else if (cubo.Front[0, 1] == cubo.Front[1, 1] && cubo.Right[0, 1] == cubo.Left[1, 1] && cubo.Back[0, 1] == cubo.Back[1, 1] &&
                                upfrontleft == cubo.UpFrontLeft && upfrontright == cubo.UpBackRight && upbackright == cubo.UpBackRight)
                    {
                        a.AddRange(R, U, R1, U1, R1, F, R, R, U1, R1, U1, R, U, R1, F1);
                        cubo.ExecuteAlgorithm(a.ToString());
                        return a.ToString();
                    }
                    // J1
                    else if (cubo.Front[0, 1] == cubo.Front[1, 1] && cubo.Right[0, 1] == cubo.Right[1, 1] && cubo.Left[0, 1] == cubo.Back[1, 1] && cubo.Back[0, 1] == cubo.Left[1, 1] &&
                                upfrontleft == cubo.UpFrontLeft && upfrontright == cubo.UpFrontRight && upbackright == cubo.UpBackLeft)
                    {
                        a.AddRange(R1, U, L1, U, U, R, U1, R1, U, U, R, L, U1);
                        cubo.ExecuteAlgorithm(a.ToString());
                        return a.ToString();
                    }
                    // J2
                    else if (cubo.Front[0, 1] == cubo.Right[1, 1] && cubo.Right[0, 1] == cubo.Front[1, 1] && cubo.Left[0, 1] == cubo.Left[1, 1] && cubo.Back[0, 1] == cubo.Back[1, 1] &&
                                upfrontleft == cubo.UpFrontLeft && upfrontright == cubo.UpBackRight && upbackright == cubo.UpFrontRight)
                    {
                        a.AddRange(R, U, R1, F1, R, U, R1, U1, R1, F, R, R, U1, R1, U1);
                        cubo.ExecuteAlgorithm(a.ToString());
                        return a.ToString();
                    }
                    // R1
                    else if (cubo.Front[0, 1] == cubo.Left[1, 1] && cubo.Right[0, 1] == cubo.Right[1, 1] && cubo.Back[0, 1] == cubo.Back[1, 1] && cubo.Left[0, 1] == cubo.Front[1, 1] &&
                                upfrontleft == cubo.UpFrontLeft && upfrontright == cubo.UpFrontRight && upbackright == cubo.UpBackLeft)
                    {
                        a.AddRange(L, U1, U1, L1, U1, U1, L, F1, L1, U1, L, U, L, F, L1, L1, U);
                        cubo.ExecuteAlgorithm(a.ToString());
                        return a.ToString();
                    }
                    // R2
                    else if (cubo.Front[0, 1] == cubo.Right[1, 1] && cubo.Right[0, 1] == cubo.Front[1, 1] && cubo.Left[0, 1] == cubo.Left[1, 1] && cubo.Back[0, 1] == cubo.Back[1, 1] &&
                                upfrontleft == cubo.UpFrontLeft && upfrontright == cubo.UpFrontRight && upbackright == cubo.UpBackLeft)
                    {
                        a.AddRange(R1, U, U, R, U, U, R1, F, R, U, R1, U1, R1, F1, R, R, U1);
                        cubo.ExecuteAlgorithm(a.ToString());
                        return a.ToString();
                    }
                    // V
                    else if (cubo.Front[0, 1] == cubo.Front[1, 1] && cubo.Right[0, 1] == cubo.Back[1, 1] && cubo.Left[0, 1] == cubo.Left[1, 1] && cubo.Back[0, 1] == cubo.Right[1, 1] &&
                                upfrontleft == cubo.UpFrontLeft && upfrontright == cubo.UpBackLeft && upbackright == cubo.UpBackRight)
                    {
                        a.AddRange(R1, U, R1, d1, R1, F1, R, R, U1, R1, U, R1, F, R, F);
                        cubo.ExecuteAlgorithm(a.ToString());
                        return a.ToString();
                    }
                    // G1
                    else if (cubo.Front[0, 1] == cubo.Front[1, 1] && cubo.Right[0, 1] == cubo.Back[1, 1] && cubo.Left[0, 1] == cubo.Right[1, 1] && cubo.Back[0, 1] == cubo.Left[1, 1] &&
                                upfrontleft == cubo.UpBackLeft && upfrontright == cubo.UpFrontRight && upbackleft == cubo.UpBackRight && upbackright == cubo.UpFrontLeft)
                    {
                        a.AddRange(R, R, u, R1, U, R1, U1, R, u1, R, R, Y1, R1, U, R, Y);
                        cubo.ExecuteAlgorithm(a.ToString());
                        return a.ToString();
                    }
                    // G2
                    else if (cubo.Front[0, 1] == cubo.Left[1, 1] && cubo.Right[0, 1] == cubo.Right[1, 1] && cubo.Left[0, 1] == cubo.Back[1, 1] && cubo.Back[0, 1] == cubo.Front[1, 1] &&
                                upfrontleft == cubo.UpFrontRight && upfrontright == cubo.UpBackLeft && upbackright == cubo.UpBackRight && upbackleft == cubo.UpFrontLeft)
                    {
                        a.AddRange(R1, U1, R, Y, R, R, u, R1, U, R, U1, R, u1, R, R, Y1);
                        cubo.ExecuteAlgorithm(a.ToString());
                        return a.ToString();
                    }
                    // G3
                    else if (cubo.Front[0, 1] == cubo.Left[1, 1] && cubo.Right[0, 1] == cubo.Front[1, 1] && cubo.Left[0, 1] == cubo.Right[1, 1] && cubo.Back[0, 1] == cubo.Back[1, 1] &&
                               cubo.UpBackLeft == upfrontleft &&  cubo.UpFrontLeft == upfrontright && cubo.UpFrontRight == upbackleft && cubo.UpBackRight == upbackright)
                    {
                        a.AddRange(R, R, u1, R, U1, R, U, R1, u, R, R, Y, R, U1, R1, Y1);
                        cubo.ExecuteAlgorithm(a.ToString());
                        return a.ToString();
                    }
                    // G4
                    else if (cubo.Front[0, 1] == cubo.Back[1, 1] && cubo.Right[0, 1] == cubo.Right[1, 1] && cubo.Left[0, 1] == cubo.Front[1, 1] && cubo.Back[0, 1] == cubo.Left[1, 1] &&
                                upfrontleft == cubo.UpBackLeft && upfrontright == cubo.UpFrontRight && upbackright == cubo.UpFrontLeft && upbackleft == cubo.UpBackRight)
                    {
                        a.AddRange(R, U, R1, Y1, R, R, u1, R, U1, R1, U, R1, U, R, R, Y);
                        cubo.ExecuteAlgorithm(a.ToString());
                        return a.ToString();
                    }
                    // F
                    else if (cubo.Front[0, 1] == cubo.Front[1, 1] && cubo.Right[0, 1] == cubo.Left[1, 1] && cubo.Left[0, 1] == cubo.Right[1, 1] && cubo.Back[0, 1] == cubo.Back[1, 1] &&
                                upfrontleft == cubo.UpFrontRight && upfrontright == cubo.UpFrontLeft && upbackright == cubo.UpBackRight)
                    {
                        a.AddRange(R1, U, U, R1, d1, R1, F1, R, R, U1, R1, U, R1, F, R, U1, F);
                        cubo.ExecuteAlgorithm(a.ToString());
                        return a.ToString();
                    }
                    // Z
                    else if (cubo.Front[0, 1] == cubo.Right[1, 1] && cubo.Right[0, 1] == cubo.Front[1, 1] && cubo.Left[0, 1] == cubo.Back[1, 1] && cubo.Back[0, 1] == cubo.Left[1, 1] &&
                                upfrontleft == cubo.UpFrontLeft && upfrontright == cubo.UpFrontRight && upbackright == cubo.UpBackRight)
                    {
                        a.AddRange(M, M, U, M, M, U, M1, U, U, M, M, U, U, M1, U, U);
                        cubo.ExecuteAlgorithm(a.ToString());
                        return a.ToString();
                    }
                    // Y
                    else if (cubo.Front[0, 1] == cubo.Front[1, 1] && cubo.Right[0, 1] == cubo.Right[1, 1] && cubo.Left[0, 1] == cubo.Back[1, 1] && cubo.Back[0, 1] == cubo.Left[1, 1] &&
                                upfrontleft == cubo.UpFrontLeft && upfrontright == cubo.UpBackLeft && upbackright == cubo.UpBackRight && upbackleft == cubo.UpFrontRight)
                    {
                        a.AddRange(F, R, U1, R1, U1, R, U, R1, F1, R, U, R1, U1, R1, F, R, F1);
                        cubo.ExecuteAlgorithm(a.ToString());
                        return a.ToString();
                    }
                    // N1
                    else if (cubo.Front[0, 1] == cubo.Back[1, 1] && cubo.Right[0, 1] == cubo.Right[1, 1] && cubo.Left[0, 1] == cubo.Left[1, 1] && cubo.Back[0, 1] == cubo.Front[1, 1] &&
                                upfrontleft == cubo.UpFrontLeft && upfrontright == cubo.UpBackLeft && upbackright == cubo.UpBackRight && upbackleft == cubo.UpFrontRight)
                    {
                        a.AddRange(L, U1, R, U, U, L1, U, R1, L, U1, R, U, U, L1, U, R1, U);
                        cubo.ExecuteAlgorithm(a.ToString());
                        return a.ToString();
                    }
                    // N2
                    else if (cubo.Front[0, 1] == cubo.Back[1, 1] && cubo.Right[0, 1] == cubo.Right[1, 1] && cubo.Left[0, 1] == cubo.Left[1, 1] && cubo.Back[0, 1] == cubo.Front[1, 1] &&
                                upfrontleft == cubo.UpBackRight && upfrontright == cubo.UpFrontRight && upbackright == cubo.UpFrontLeft)
                    {
                        a.AddRange(R1, U, L1, U, U, R, U1, L, R1, U, L1, U, U, R, U1, L, U1);
                        cubo.ExecuteAlgorithm(a.ToString());
                        return a.ToString();
                    }
                    // E
                    else if (cubo.Front[0, 1] == cubo.Front[1, 1] && cubo.Right[0, 1] == cubo.Right[1, 1] && cubo.Left[0, 1] == cubo.Left[1, 1] && cubo.Back[0, 1] == cubo.Back[1, 1] &&
                                upfrontleft == cubo.UpBackLeft && upfrontright == cubo.UpBackRight && upbackright == cubo.UpFrontRight)
                    {
                        a.AddRange(X1, R, U1, R1, D, R, U, R1, u, u, R1, U, R, D, R1, U1, R, X);
                        cubo.ExecuteAlgorithm(a.ToString());
                        return a.ToString();
                    }
                    else
                    {
                        cubo.ExecuteAlgorithm("Y");
                        a.Add(Move.Y);
                    }
                }

                cubo.ExecuteAlgorithm("U");
                a.Add(Move.U);
            }
            
            //Basta uno o più up
            for (int i = 0; i < 4; i++)
            {
                if (cubo.Front[0, 1] != cubo.Front[1, 1])
                {
                    cubo.ExecuteAlgorithm("U");
                    a.Add(Move.U);
                }
            }
            
            return a.ToString();
        }

        public string FinalAlgorithm()
        {
            /* 
             * Mosse da guardare
             * D L' F U' B F' R' F R' F' B' L' F' B' D' R D R L' F'
             * F' R B' D' B D' D B' F' D' R' U' U' D' L L U' U' L' B'
             * D' B L' B' U' L' D D' R R' U' B R D D' R' F R F' L
             * 
             */
            string FinalAlg = Cross() + Face() + SecondLayer() + OLL() + PLL();
            FinalAlg = FinalAlg.Substring(0 ,FinalAlg.Length);
            MovesSemplifier Sempli = new MovesSemplifier();
            string SemplifiedAlg = Sempli.DeleteUselessMoves(FinalAlg);
            //AlgorithmConverter Converter = new AlgorithmConverter(FinalAlg);
            //string NewAlg = Converter.Convert();
            //return NewAlg;
            return SemplifiedAlg;
        }

    }
}
