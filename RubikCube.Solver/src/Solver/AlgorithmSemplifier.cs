
using System.Collections.Generic;

namespace RubikCube.Solver
{
    public class MovesSemplifier
    {
        public bool IsChanged = false;
        public MovesSemplifier()
        {

        }

        public string DeleteUselessMoves(string moves)
        {
            string[] Moves = moves.Split(',');

            do
            {
                IsChanged = false;
                Moves = DeleteFourMoves(Moves);
                Moves = DeleteReverse(Moves);
                Moves = ReplaceThreeMoves(Moves);
            }
            while (IsChanged);
            return ArrayToString(Moves);
        }
        private string[] DeleteFourMoves(string[] moves)
        {
            for (int i = 0; i < moves.Length - 3; i++)
            {
                if (moves[i] == moves[i + 1] && moves[i] == moves[i + 2] && moves[i] == moves[i + 3])
                {
                    moves[i] = "";
                    moves[i + 1] = "";
                    moves[i + 2] = "";
                    moves[i + 3] = "";
                    IsChanged = true;
                }
            }

            return DeleteSpace(moves);
        }
        private string[] DeleteReverse(string[] moves)
        {
            for (int i = 0; i < moves.Length - 1; i++)
            {
                if (moves[i] == moves[i + 1] + "1" || moves[i] + "1" == moves[i + 1])
                {
                    moves[i] = "";
                    moves[i + 1] = "";
                    IsChanged = true;
                }
            }
            return DeleteSpace(moves);
        }
        private string[] ReplaceThreeMoves(string[] moves)
        {
            for (int i = 0; i < moves.Length - 2; i++)
            {
                if(moves[i] == moves[i + 1] && moves[i] == moves[i + 2])
                {
                    if (!moves[i].Contains("1"))
                    {
                        moves[i] = moves[i] + "1";
                        moves[i + 1] = "";
                        moves[i + 2] = "";
                        IsChanged = true;
                    }
                    else
                    {
                        moves[i] = moves[i][0].ToString();
                        moves[i + 1] = "";
                        moves[i + 2] = "";
                        IsChanged = true;
                    }
                }
            }
            return DeleteSpace(moves);
        }
        private string[] DeleteSpace(string[] moves)
        {
            List<string> tmp = new List<string>();
            for (int i = 0; i < moves.Length; i++)
            {
                if (moves[i] != "")
                {
                    tmp.Add(moves[i]);
                }
            }
            return tmp.ToArray();
        }
        private string ArrayToString(string[] moves)
        {
            string tmp = "";
            for (int i = 0; i < moves.Length; i++)
            {
                tmp += moves[i] + " ";
            }
            return tmp;
        }
    }
}
