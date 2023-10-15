using KnightsTour.Models;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KnightsTour.Logic
{
    public enum DifficultyLevel
    {
        Easy,
        Medium,
        Hard,
        Insane
    }
    public class Solver
    {
        #region Constructors
        public Solver(long updateFrquency = 1000000, long maxIterationsMultiplier = 1000000)
        {
            UpdateFrequency = updateFrquency;
            MaxIterationsMultiplier= maxIterationsMultiplier;
        }
        #endregion

        #region Properties
        public string MAX_ITERATIONS_MESSAGE = "Maximum Iterations Reached";
        public long UpdateFrequency { get; set; }
        public long MaxIterationsMultiplier { get; set; }
        public int InitialX { get; set; }
        public int InitialY { get; set; }
        public long Iterations { get; set; }
        public long MinDepth { get; set; }
        public long MaxDepth { get; set; }
        public KnightTourBoard Board { get; set; }
        public long SolutionsFound { get; set; }
        public long SolutionsRequested { get; set; }
        public long RandomLimiter { get; set; }
        public string ExceptionMessage { get; set; }
        #endregion

        #region Methods
        Random rand = new Random();
        public void Solve(KnightTourBoard board, long uniqueSolutions = 1)
        {
            List<string> startingSquares = new List<string>();
            SolutionsFound = 0;
            SolutionsRequested = Math.Min(uniqueSolutions, board.TotalSquares);
            while (SolutionsFound < SolutionsRequested)
            {
                InitialX = rand.Next(0, int.Parse(board.Rows.ToString()));
                InitialY = rand.Next(0, int.Parse(board.Cols.ToString()));
                string initialIndex = $"{InitialX},{InitialY}";
                if (!startingSquares.Contains($"{InitialX},{InitialY}"))
                {
                    RandomLimiter = Math.Min(board.TotalSquares / 2, 20);
                    startingSquares.Add(initialIndex);
                    while (RandomLimiter >= 0)
                    {
                        try
                        {
                            ExceptionMessage = string.Empty;
                            Iterations = 0;
                            MaxDepth = -1;
                            MinDepth = board.TotalSquares + 1;
                            board.ClearValues();
                            RaiseOnSolveStart();
                            KnightTourBoard boardClone = board.Clone();
                            boardClone.Squares.First(b => b.X == InitialX && b.Y == InitialY).Value = KnightTourSquare.AVAILABLE_SQUARE + 1;
                            FindRoute(InitialX, InitialY, KnightTourSquare.AVAILABLE_SQUARE + 1, boardClone);
                            Board = boardClone;
                            board.Iterations = Iterations;
                            RaiseComplete(boardClone);
                            SolutionsFound++;
                            RandomLimiter = -1;
                        }
                        catch (Exception exception)
                        {
                            if (exception.Message == MAX_ITERATIONS_MESSAGE)
                                RandomLimiter = RandomLimiter - 2;
                            else
                                throw;
                        }
                    }
                }
                else if (startingSquares.Count == board.TotalSquares)
                {
                    RaiseException("All possible starting squares with all random limiters exhausted.");
                }
                else
                {
                    Thread.Sleep(10);
                }
            }
        }
        private bool FindRoute(long currentX, long currentY, int times, KnightTourBoard board)
        {
            #region Logging related
            if (times > MaxDepth) MaxDepth = times;
            if (times < MinDepth) MinDepth = times;

            if (Iterations % UpdateFrequency == 0)
            {
                RaiseUpdate();
                MaxDepth = 0;
                MinDepth = board.TotalSquares + 1;

                if (Iterations > board.TotalSquares * MaxIterationsMultiplier)
                {
                    throw new Exception(MAX_ITERATIONS_MESSAGE);
                }
            }

            Iterations++;
            #endregion

            if (times == board.TotalSquares + KnightTourSquare.AVAILABLE_SQUARE)
                return true;

            foreach (long[] destination in board.Squares.First(b => b.X == currentX && b.Y == currentY).GetMoves(times > RandomLimiter))
            {
                KnightTourSquare square = board.Squares.First(b => b.X == destination[KnightTourSquare.POSITION_X] && b.Y == destination[KnightTourSquare.POSITION_Y]);

                if (square.Value != KnightTourSquare.AVAILABLE_SQUARE) continue;

                square.Value = times + 1;

                if (FindRoute(destination[KnightTourSquare.POSITION_X], destination[KnightTourSquare.POSITION_Y], times + 1, board))
                {
                    return true;
                }
                else
                {
                    // Revert the move and try the next path.
                    square.Value = KnightTourSquare.AVAILABLE_SQUARE;
                }
            }

            // This means no paths are available, revert!
            return false;
        }
        public KnightTourBoard MakePuzzle(KnightTourBoard solvedBoard, DifficultyLevel level)
        {
            long squaresToRemove = 0;
            int maximumGap = 0;
            switch (level)
            {
                case DifficultyLevel.Easy:
                    squaresToRemove = solvedBoard.TotalSquares - (int)((double)0.5 * solvedBoard.TotalSquares);
                    maximumGap = 5;
                    break;
                case DifficultyLevel.Medium:
                    squaresToRemove = solvedBoard.TotalSquares - (int)((double)0.47 * solvedBoard.TotalSquares);
                    maximumGap = 5;
                    break;
                case DifficultyLevel.Hard:
                    squaresToRemove = solvedBoard.TotalSquares - (int)((double)0.44 * solvedBoard.TotalSquares);
                    maximumGap = 6;
                    break;
                case DifficultyLevel.Insane:
                    squaresToRemove = solvedBoard.TotalSquares - (int)((double)0.41 * solvedBoard.TotalSquares);
                    maximumGap = 6;
                    break;
                default:
                    break;
            }

            return RemoveSquares(solvedBoard, squaresToRemove, maximumGap);
        }
        KnightTourBoard RemoveSquares(KnightTourBoard sourceBoard, long squaresToRemove, int maximumGap)
        {
            List<KnightTourSquareBase> baseSquares = GetValidPuzzleBoardBase(sourceBoard, squaresToRemove, maximumGap);

            foreach(KnightTourSquareBase baseSquare in baseSquares)
            {
                sourceBoard.Squares.First(s => s.X == baseSquare.X && s.Y == baseSquare.Y).Value = baseSquare.Value;
            }

            return sourceBoard;

        }
        List<KnightTourSquareBase> GetValidPuzzleBoardBase(KnightTourBoard sourceBoard, long squaresToRemove, int maximumGap)
        {
            int currentMaxGap = -1;
            int currentIteration = 0;
            int maximumIterations = 100;
            while (currentIteration < maximumIterations)
            {
                List<KnightTourSquareBase> baseSquares = sourceBoard.CreateSquareBaseCopy();

                int totalSquaresRemoved = 0;
                while (totalSquaresRemoved < squaresToRemove - 1)
                {
                    int index = rand.Next(baseSquares.Count);
                    if (
                        baseSquares[index].Value != KnightTourSquare.AVAILABLE_SQUARE &&
                        baseSquares[index].Value != KnightTourSquare.AVAILABLE_SQUARE + 1 &&
                        baseSquares[index].Value != baseSquares.Count)
                    {
                        baseSquares[index].Value = KnightTourSquare.AVAILABLE_SQUARE;
                        totalSquaresRemoved++;
                    }
                }

                currentMaxGap = GetMaximumGap(baseSquares);

                if (currentMaxGap <= maximumGap)
                    return baseSquares;

                currentIteration++;
            }

            throw new Exception("Maximum iterations reached - check for bugs or increase iterations.");
        }
        int GetMaximumGap(List<KnightTourSquareBase> baseSquares)
        {
            List<int> distinctValues = baseSquares.Select(x => x.Value).Distinct().OrderBy(v => v).ToList();

            int maxGap = 0;
            for (int i = 0; i < distinctValues.Count - 1; i++)
            {
                int gap = distinctValues[i + 1] - distinctValues[i];
                if (gap > maxGap)
                    maxGap = gap;
            }

            return maxGap;
        }
        #endregion

        #region Events
        public event EventHandler OnSolveStart;
        public event EventHandler OnUpdate;
        public event EventHandler OnException;
        public event EventHandler OnComplete;
        protected virtual void RaiseUpdate()
        {
            OnUpdate?.Invoke(this, new EventArgs());
        }
        protected virtual void RaiseComplete(KnightTourBoard board)
        {
            board.Iterations = Iterations;
            OnComplete?.Invoke(this, new EventArgs());
        }
        protected virtual void RaiseException(string exceptionMessage)
        {
            ExceptionMessage = exceptionMessage;
            OnException?.Invoke(this, new EventArgs());
        }
        protected virtual void RaiseOnSolveStart()
        {
            OnSolveStart?.Invoke(this, new EventArgs());
        }
        #endregion
    }
}