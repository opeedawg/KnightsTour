using KnightsTour;
using KnightsTour.CoreLibrary;

namespace Utility
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BoardLogic bLogic = new BoardLogic("Utility");

            bLogic.OnUpdate += BLogic_OnUpdate;
            foreach (Board board in bLogic.GetAll())
            {
                bLogic.CreatePuzzles(board.BoardId.Value, 10, true);
            }
        }

        private static void BLogic_OnUpdate(object sender, BoardLogic.LogicEventArgs args)
        {
            Console.WriteLine($"[{args.Message.Type}] {args.Message.Content}");
        }
    }
}