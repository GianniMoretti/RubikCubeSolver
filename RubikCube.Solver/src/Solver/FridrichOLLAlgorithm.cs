using System;
using System.Collections.Generic;
using System.Linq;
using static RubikCube.Solver.Move;

namespace RubikCube.Solver
{
    public static class FridrichOLLAlgorithm
    {
        public static List<Algorithm> ListaAlgoritmi;
        static FridrichOLLAlgorithm()
        {
            ListaAlgoritmi = new List<Algorithm>();
            CaricaAlgoritmi();
        }

        public static string[] OLLConfiguration()
        {
            string[] conf = new string[58]
            {
                // Dot
                "010111010111000010000",
                "010110111011000010000",
                "110110010110000010001",
                "010011011011001010000",
                "011010010110100010001",
                "010010010010101010101",
                "010011010110101010000",
                "111010010010000010101",
                // Line
                "100111001010010010010",
                "000111000111010010010",
                "110101011000000111000",
                "010101010101000111000",
                // Cross
                "100101001000010111010",
                "000101000101010111010",
                "001000001001010111011",
                "100100000100010111011",
                "001000100000110111110",
                "000000101000111111010",
                "001000000100110111011",
                // 4 Corners
                "010010000000101110111",
                "010000010000101111101",
                // Shape _|
                "100110110000010110100",
                "000110011000110110001",
                "001010011001010110001",
                "101010010000010110101",
                "001010110101010110000",
                "101010111000010110000",
                // Shape |_
                "101000010010010011101",
                "000001011011011011000",
                "100001010010011011100",
                "100101011010010011000",
                "001000110111010011000",
                "101000111010010011000",
                // Shape ¯|
                "110010100100001110010",
                "011011001000100110010",
                "011010001001000110011",
                "010011000100101110010",
                // Shape |¯
                "011000100111000011010",
                "110100100010000011110",
                "010001000110101011010",
                "110100000110000011011",
                // C
                "000111000010110010110",
                "010100010001000111101",
                // L
                "011000011001000111001",
                "110100110000000111100",
                "110100010100000111001",
                "011001010001000111100",
                // P
                "000111010000110110100",
                "100000011010011011001",
                "001010110000110110100",
                "000000010111011011001",
                // T
                "010000010101001111001",
                "110000011000001111001",
                // W
                "010000100011001011110",
                "010110001000100110011",
                // Z
                "011000010100100111001",
                "110001010000001111100",
                // Full Yellow
                "000000000000111111111"
            };

            return conf;
        }



        private static void CaricaAlgoritmi()
        {
            //TODO: da finire
            // Dot
            Add(R, U, B1, l, U, l1, l1, X1, U1, R1, F, R, F1);   //Potrebbe mancare una x?
            Add(R1, F, R, F1, U, U, R1, F, R, Y1, R, R, U, U, R);
            Add(Y, L1, R, R, B, R1, B, L, U1, U1, L1, B, M1);
            Add(R1, U, U, X, R1, U, R, U1, Y, R1, U1, R1, U, R1, F, Y1, X1);
            Add(R, U, R1, U, R1, F, R, F1, U, U, R1, F, R, F1);
            Add(M1, U, U, M, U, U, M1, U, M, U, U, M1, U, U, M);
            Add(R1, U, U, F, R, U, R1, U1, Y1, R, R, U, U, X1, R, U, X);
            Add(F, R, U, R1, U, Y1, R1, U, U, R1, F, R, F1);

            //Line
            Add(R1, U1, Y, L1, U, L1, Y1, L, F, L1, F, R);
            Add(R, U1, Y, R, R, D, R1, U, U, R, D1, R, R, d, R1);
            Add(F, U, R, U1, R1, U, R, U1, R1, F1);
            Add(L1, B1, L, U1, R1, U, R, U1, R1, U, R, L1, B, L);

            // Cross
            Add(L, U1, R1, U, L1, U, R, U, R1, U, R);
            Add(R, U, R1, U, R, U1, R1, U, R, U, U, R1);
            Add(L1, U, R, U1, L, U, R1);
            Add(R1, U, U, R, U, R1, U, R);
            Add(R1, F1, L, F, R, F1, L1, F);
            Add(R, R, D, R1, U, U, R, D1, R1, U, U, R1);
            Add(R1, F1, L1, F, R, F1, L, F);

            // 4 Corners
            Add(M1, U1, M, U1, U1, M1, U1, M);
            Add(L1, R, U, R1, U1, L, R1, F, R, F1);

            // Shape _|
            Add(L, F, R1, F, R, F, F, L1);
            Add(F, R1, F1, R, U, R, U1, R1);
            Add(R1, U1, R, Y1, X1, R, U1, R1, F, R, U, R1, X);
            Add(U1, R, U1, U1, R1, U1, R, U1, R, R, Y1, R1, U1, R, U, B);
            Add(F, R, U, R1, U1, R, U, R1, U1, F1);
            Add(L, F1, L1, F, U, U, L, L, Y1, L, F, L1, F);

            //Shape |_
            Add(U1, R1, U, U, R, U, R1, U, R, R, Y, R, U, R1, U1, F1);
            Add(r, U, U, R1, U1, R, U1, r1);
            Add(R1, U, U, l, R, U1, R1, U, l1, U, U, R);
            Add(F1, L1, U1, L, U, L1, U1, L, U, F);
            Add(R1, F, R1, F1, R, R, U, U, X1, U1, R, U, R1, X);
            Add(R1, F, R, F1, U, U, R, R, Y, R1, F1, R, F1);

            // Shape _|
            Add(R, U, R1, Y, R1, F, R, U1, R1, F1, R);
            Add(L1, B1, L, U1, R1, U, R, L1, B, L);
            Add(U, U, r, R1, R1, U1, R, U1, R1, U, U, R, U1, M);
            Add(X1, U1, R, U1, R1, R1, F, X, R, U, R1, U1, R, B, B);

            // Shape |_
            Add(L, U1, Y1, R1, U1, U1, R1, U, R, U1, R, U, U, R, d1, L1);
            Add(U, U, l1, L, L, U, L1, U, L, U, U, L1, U, M);
            Add(R1, R1, U, R1, B1, R, U1, R1, R1, U, l, U, l);
            Add(r1, U, U, R, U, R1, U, r);

            // C
            Add(R, U, X1, R, U1, R1, U, X, U1, R1);
            Add(R, U, R1, U1, X, D1, R1, U, R, E1, X1);

            // L
            Add(R1, F, R, U, R1, F1, R, Y, L, U1, L1);
            Add(L, F1, L1, U1, L, F, L1, Y1, R1, U, R);
            Add(L1, B1, L, R1, U1, R, U, L1, B, L);
            Add(R, B, R1, L, U, L1, U1, R, B1, R1);

            // P
            Add(F, U, R, U1, R1, F1);
            Add(R1, d1, L, d, R, U1, R1, F1, R);
            Add(L, d, R1, d1, L1, U, L, F, L1);
            Add(F1, U1, L1, U, L, F);

            // T
            Add(F, R, U, R1, U1, F1);
            Add(R, U, R1, U1, R1, F, R, F1);

            // W
            Add(L, U, L1, U, L, U1, L1, U1, Y1, Y1, R1, F, R, F1);
            Add(R1, U1, R, U1, R1, U, R, U, Y, F, R1, F1, R);

            // Z
            Add(R1, F, R, U, R1, U1, Y, L1, d, R);
            Add(L, F1, L1, U1, L, U, Y1, R, d1, L1);

            // All done
            Add();
        }

        static void Add(params Move[] mosse)
        {
            Algorithm A = new Algorithm();
            A.AddRange(mosse);
            ListaAlgoritmi.Add(A);
        }
    }
}
