using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace KnightsTour.Models
{
    [Serializable]
    public class KnightTourSquare : KnightTourSquareBase
    {
        #region Constructor
        public KnightTourSquare(long x, long y, long dimX, long dimY) : base(x, y, AVAILABLE_SQUARE)
        {
            DimX = dimX;
            DimY = dimY;
            PopulateMoveCounts();

            PopulateMoves(X, Y);
            Count = MovesOptimized.Count;
        }
        #endregion

        #region Constants
        public const int AVAILABLE_SQUARE = 0;
        public const long POSITION_X = 0;
        public const long POSITION_Y = 1;
        public const int POSITION_MOVES_1 = 2;
        public const int POSITION_MOVES_2 = 3;
        public const int POSITION_MOVES_3 = 4;
        long[,] KNIGHT_MOVES = new long[,] { { 2, 1 }, { 1, 2 }, { -1, 2 }, { -2, 1 }, { -2, -1 }, { -1, -2 }, { 1, -2 }, { 2, -1 } };
        private static Random rng = new Random();
        #endregion

        #region Properties
        public long DimX { get; set; }
        public long DimY { get; set; }
        public int Count { get; set; }
        List<long[]> MovesOptimized { get; set; }
        List<long[]> MovesRandom { get; set; }
        public Dictionary<string, int> MoveCounts { get; set; }
        #endregion

        #region Methods
        public List<long[]> GetMoves(bool optimized)
        {
            return optimized ? MovesOptimized : MovesRandom;
        }

        void PopulateMoveCounts()
        {
            MoveCounts = new Dictionary<string, int>();
            for (long x = 0; x < DimX; x++)
            {
                for (long y = 0; y < DimY; y++)
                {
                    string key = $"{x},{y}";

                    int count = 0;
                    for (int i = 0; i < KNIGHT_MOVES.GetLength(0); i++)
                    {
                        long moveToX = x + KNIGHT_MOVES[i, 0];
                        long moveToY = y + KNIGHT_MOVES[i, 1];
                        if (moveToX >= 0 && moveToX < DimX && moveToY >= 0 && moveToY < DimY)
                        {
                            count++;
                        }
                    }

                    MoveCounts.Add(key, count);
                }
            }
        }

        void Shuffle<T>(IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        List<long[]> PopulateMoves(long x, long y, bool populateDepth = true)
        {
            List<long[]> moves = new List<long[]>();

            for (int i = 0; i < KNIGHT_MOVES.GetLength(0); i++)
            {
                long moveToX = x + KNIGHT_MOVES[i, 0];
                long moveToY = y + KNIGHT_MOVES[i, 1];
                if (moveToX >= 0 && moveToX < DimX && moveToY >= 0 && moveToY < DimY)
                {
                    string key = $"{moveToX},{moveToY}";
                    moves.Add(new long[] { moveToX, moveToY, MoveCounts[key], 0, 0 });
                }
            }


            // For each tie move, sum the number of moves available to it at the next level and pick the one yielding a minimum
            // Source: Ira Pohl
            // https://dl.acm.org/doi/10.1145/363427.363463

            // Set depth moves
            if (populateDepth)
            {
                Shuffle<long[]>(moves);
                MovesRandom = new List<long[]>();
                MovesRandom.AddRange(moves);

                foreach (long[] move in moves)
                {
                    string moveDepth2Key = $"{move[POSITION_X]},{POSITION_Y}";
                    move[POSITION_MOVES_2] = MoveCounts[moveDepth2Key];

                    int minMoves = int.MaxValue;
                    foreach (long[] moveDepth3 in PopulateMoves(move[POSITION_X], move[POSITION_Y], false))
                    {
                        string moveDepth3Key = $"{moveDepth3[POSITION_X]},{POSITION_Y}";
                        if (MoveCounts[moveDepth3Key] < minMoves)
                            minMoves = MoveCounts[moveDepth3Key];
                    }

                    move[POSITION_MOVES_3] = minMoves;
                }

                moves = moves.OrderBy(m => m[POSITION_MOVES_1]).ThenBy(m => m[POSITION_MOVES_2]).ThenBy(m => m[POSITION_MOVES_3]).ToList();
                MovesOptimized = new List<long[]>();
                MovesOptimized.AddRange(moves);
            }


            return moves;
        }
        #endregion
    }
}