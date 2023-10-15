using KnightsTour.CoreLibrary;
using KnightsTour;
using KnightsTour.Logic;
using KnightsTour.Models;

namespace BoardDiscovery
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 3)
                Console.WriteLine("Error: Exactly 3 parameters expected (rowDimmension, colDimmension, iterations)");
            else
            {
                KnightTourBoard board = new KnightTourBoard(int.Parse(args[0]), int.Parse(args[1]));
                Solver solver = new Solver();
                solver.OnSolveStart += Solver_OnSolveStart;
                solver.OnUpdate += Solver_OnUpdate;
                solver.OnComplete += Solver_OnComplete;
                solver.OnException += Solver_OnException;
                solver.Solve(board, int.Parse(args[2]));
            }
        }

        private static void Solver_OnSolveStart(object? sender, EventArgs e)
        {
            Solver solver = (Solver)sender;

            Console.WriteLine($"Discovering solution {solver.SolutionsFound + 1} of {solver.SolutionsRequested}");
            Console.WriteLine($"  Start square = {solver.InitialX}, {solver.InitialY}");
            Console.WriteLine($"  Random Limiter = {solver.RandomLimiter}");
        }

        private static void Solver_OnException(object? sender, EventArgs e)
        {
            Solver solver = (Solver)sender;

            Console.WriteLine($"  ***EXCEPTION*** {solver.ExceptionMessage}");
        }

        private static void Solver_OnComplete(object? sender, EventArgs e)
        {
            Solver solver = (Solver)sender;

            // Add this board to the database!
            string path = solver.Board.SerializedKey;
            BoardLogic logic = new BoardLogic("System");
            if (!logic.PathExists(path))
            {
                Board board = new Board();
                board.SourceBoardId = null;
                board.BoardCode = Guid.NewGuid();
                board.RowDimension = int.Parse(solver.Board.Rows.ToString());
                board.ColDimension = int.Parse(solver.Board.Cols.ToString());
                board.DiscoveryDate = DateTime.Now;
                board.Author = "Christopher Zee Chartrand";
                board.DiscoveryIterationCount = solver.Iterations;
                board.DiscoveryRandomness = int.Parse(solver.RandomLimiter.ToString());
                board.Path = path;

                IActionResponse response = logic.Insert(board);
                if (response.IsValid)
                {
                    Console.WriteLine("Board inserted to DB");
                    Console.WriteLine($"  Creating puzzles for board {board.BoardId.Value}...");
                    logic.CreatePuzzles(board.BoardId.Value, 10, true);
                }
                else
                {
                    Console.WriteLine($"Board insert error: {response.Messages[response.Messages.Count - 1].Content}");
                }
            }
        }

        private static void Solver_OnUpdate(object? sender, EventArgs e)
        {
            Solver solver = (Solver)sender;

            Console.WriteLine($"    {solver.Iterations:n0} [{solver.MinDepth} - {solver.MaxDepth}]");
        }
    }
}