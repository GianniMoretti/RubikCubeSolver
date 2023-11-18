
using System.Collections.Generic;


namespace RubikCube.Solver
{
    public class AlgorithmConverter
    {
        string Alg;
        private string ChangeX = "FUBD";
        private string ChangeY = "FLBR";

        private string ChangedAfterX = "FUBD";
        private string ChangedAfterY = "FLBR";
        
        private string[] SingleMovements;
        public AlgorithmConverter(string alg)
        {
            Alg = alg;
        }
        public string Convert()
        {
            SingleMovements = Alg.Split(',');

            
            List<string> Cambi = new List<string>();
            for (int i = 0; i < SingleMovements.Length; i++)
            {
                switch (SingleMovements[i])
                {
                    case "X":
                        X(i);
                        break;
                    case "X1":
                        X1(i);
                        break;
                    case "Y":
                        Y(i);
                        break;
                    case "Y1":
                        Y1(i);
                        break;
                }

            }
            Alg = "";
            foreach (var x in SingleMovements)
            {
                if (x.StartsWith("X") || x.StartsWith("Y")) continue;
                Alg = Alg + x + ',';
            }
            return Alg;
        }
        void X(int i)
        {
            ChangeXRecord(1);
            for (int index = i + 1; index < SingleMovements.Length; index++)
            {
                //Indice del movimento
                int IndexOfMovement = ChangedAfterX.IndexOf(SingleMovements[index][0]);

                //Se è una X
                if (IndexOfMovement == -1 && SingleMovements[index][0] == 'X') return;
                //Se non è nè X nè FUBD
                else if (IndexOfMovement == -1) continue;

                //Controllo se il numero è Inverso
                if (SingleMovements[index].Length == 2)
                    SingleMovements[index] = ChangeX[IndexOfMovement].ToString() + "1";
                else
                    SingleMovements[index] = ChangeX[IndexOfMovement].ToString();
            }
        }
        void X1(int i)
        {
            ChangeXRecord(-1);
            for (int index = i + 1; index < SingleMovements.Length; index++)
            {
                //Indice del movimento
                int IndexOfMovement = ChangeX.IndexOf(SingleMovements[index][0]);

                //Se è una X
                if (IndexOfMovement == -1 && SingleMovements[index][0] == 'X') return;
                //Se non è nè X nè FUBD
                else if (IndexOfMovement == -1) continue;

                //Controllo se il numero è Inverso
                if (SingleMovements[index].Length == 2)
                    SingleMovements[index] = ChangedAfterX[IndexOfMovement].ToString() + "1";
                else
                    SingleMovements[index] = ChangedAfterX[IndexOfMovement].ToString();
            }
        }
        void Y(int i)
        {
            ChangeYRecord(1);
            for (int index = i+1; index < SingleMovements.Length; index++)
            {
                //Indice del movimento
                int IndexOfMovement = ChangeY.IndexOf(SingleMovements[index][0]);

                //Se è una Y
                if (IndexOfMovement == -1 && SingleMovements[index][0] == 'Y') return;
                //Se non è ne Y ne FLBR
                else if (IndexOfMovement == -1) continue;

                //Controllo se il numero è Inverso
                if (SingleMovements[index].Length == 2)
                    SingleMovements[index] = ChangedAfterY[IndexOfMovement].ToString() + "1";
                else
                    SingleMovements[index] = ChangedAfterY[IndexOfMovement].ToString();
            }
        }
        void Y1(int i)
        {
            ChangeYRecord(-1);
            for (int index = i + 1; index < SingleMovements.Length; index++)
            {
                //Indice del movimento
                 int IndexOfMovement = ChangedAfterY.IndexOf(SingleMovements[index][0]);

                //Se è una Y
                if (IndexOfMovement == -1 && SingleMovements[index][0] == 'Y') return;
                //Se non è ne Y ne FLBR
                else if (IndexOfMovement == -1) continue;

                //Controllo se il numero è Inverso
                if (SingleMovements[index].Length == 2)
                    SingleMovements[index] = ChangeY[IndexOfMovement].ToString() + "1";
                else
                    SingleMovements[index] = ChangeY[IndexOfMovement].ToString();
            }
        }
        void ChangeYRecord(int n)
        {
            string newRecord = "";
            for (int i = 0; i < ChangedAfterY.Length; i++)
            {
                if (n == -1 && i == 3)
                {
                    newRecord += ChangedAfterY[0];
                    continue;
                }
                if (n == 1 && i == 0)
                {
                    newRecord += ChangedAfterY[3];
                    continue;
                }
                newRecord += ChangedAfterY[i - n];
            }
            ChangedAfterX = ChangedAfterX.Replace(ChangedAfterX[0], ChangedAfterY[0]);
            ChangedAfterX = ChangedAfterX.Replace(ChangedAfterX[3], ChangedAfterY[3]);
            ChangedAfterY = newRecord;
        }
        void ChangeXRecord(int n)
        {
            string newRecord = "";
            for (int i = 0; i < ChangedAfterX.Length; i++)
            {
                if (n == -1 && i == 3)
                {
                    newRecord += ChangedAfterX[0];
                    continue;
                }
                if (n == 1 && i == 0)
                {
                    newRecord += ChangedAfterX[3];
                    continue;
                }
                newRecord += ChangedAfterX[i - n];
            }
            ChangedAfterY = ChangedAfterY.Replace(ChangedAfterY[0], ChangedAfterX[0]);
            ChangedAfterY = ChangedAfterY.Replace(ChangedAfterY[3], ChangedAfterX[3]);
            ChangedAfterX = newRecord;
        }
    }
}
