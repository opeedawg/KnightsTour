using KnightsTour.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace KnightsTour.Logic
{
    public class Render
    {
        #region Constructors
        public Render(string outputFolder, bool debugging = true)
        {
            OutputFolder= outputFolder;
            Debugging = debugging;
            StartCellColor = "#64E986";
            EmptyCellColor= "#CECECE";
            EndCellColor= "#EB5406";
            TableBorderColor = "black";
            CellBorderColor = "#34282C";
            TableBackgroundColor = "#98AFC7";
            TableBorderRadius = 25;
            TableBorderThickness = 2;
            CellBorderThickness = 1;
        }
        #endregion

        #region Properties
        public string OutputFolder { get; set; }
        public bool Debugging { get; set; }
        public string StartCellColor { get; set; }
        public string EmptyCellColor { get; set; }
        public string EndCellColor { get; set; }
        public string TableBorderColor { get; set; }
        public string TableBackgroundColor { get; set; }
        public string CellBorderColor { get; set; }
        public int TableBorderRadius { get; set; }
        public int TableBorderThickness { get; set; }
        public int CellBorderThickness { get; set; }
        #endregion

        #region Methods
        public void RenderPuzzle(List<KnightTourBoard> boards, string name)
        {
            StringBuilder output = new StringBuilder();
            foreach (KnightTourBoard board in boards)
                output.AppendLine(GetPuzzleHtml(board));

            RenderPage(name, output.ToString(), GetCellSize(boards[0]));
        }
        public void RenderPuzzle(KnightTourBoard board, string name)
        {
            RenderPage(name, GetPuzzleHtml(board), GetCellSize(board));
        }
        int GetCellSize(KnightTourBoard board)
        {
            int cellSize = 50;
            if (board.Rows < 7) cellSize = 80;
            else if (board.Rows < 11) cellSize = 65;

            return cellSize;
        }
        void RenderPage(string pageName, string contents, int cellSize)
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine("<!doctype html>");
            output.AppendLine("<html>");
            output.AppendLine("  <head>");
            output.AppendLine($"    <title>Knight Tour Puzzle Render - {pageName}</title>");
            output.AppendLine("    <meta name=\"author\" content=\"Chris Chartrand\">");
            output.AppendLine($"    <meta name=\"description\" content=\"Knight's tour puzzle: {pageName} rendered on {DateTime.Now.ToString("yyyy-MM-dd")} at {DateTime.Now.ToString("HH-mm-ss")}\">");
            output.AppendLine("    <meta name=\"keywords\" content=\"Knight tour, puzzle, Chris Chartrand\">");
            output.AppendLine("    <style>");
            output.AppendLine($"      table {{border: {TableBorderThickness}px solid {TableBorderColor};border-radius: {TableBorderRadius}px;border-collapse: collapse;background-color: {TableBackgroundColor};}}");
            output.AppendLine($"      td {{border: {CellBorderThickness}px solid {CellBorderColor}; width: {cellSize}px; height: {cellSize}px; text-align: center; vertical-align: middle;}}");
            output.AppendLine($"      td.startCell {{background-color: {StartCellColor}}}");
            output.AppendLine($"      td.endCell {{background-color: {EndCellColor}}}");
            output.AppendLine($"      td.emptyCell {{background-color: {EmptyCellColor}");
            output.AppendLine("    </style>");
            output.AppendLine("  </head>");
            output.AppendLine("  <body>");
            output.Append(contents);
            output.AppendLine("  </body>");
            output.AppendLine("</html>");

            File.WriteAllText($"{OutputFolder}\\{pageName} ({DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss")}).html", output.ToString());
        }
        string GetPuzzleHtml(KnightTourBoard board)
        {
            StringBuilder html = new StringBuilder();
            string indent = "".PadLeft(4, ' ');
            int cellSize = 50;
            if (board != null && board.Squares != null)
            {
                if (board.Rows < 7) cellSize = 80;
                else if (board.Rows < 11) cellSize = 65;
                if (Debugging)
                {
                    html.AppendLine($"{indent}<!-- {board.Serialized} -->");
                    html.AppendLine($"{indent}<ul>");
                    html.AppendLine($"{indent}  <li>Created: {DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss")}</li>");
                    html.AppendLine($"{indent}  <li>Row count: {board.Rows}</li>");
                    html.AppendLine($"{indent}  <li>Col count: {board.Cols}</li>");
                    html.AppendLine($"{indent}  <li>Cell size: {cellSize}</li>");
                    html.AppendLine($"{indent}  <li>Iterations: {board.Iterations}</li>");
                    html.AppendLine($"{indent}</ul>");
                }
                html.AppendLine($"{indent}<table>");
                for (int row = 0; row < board.Rows; row++)
                {
                    html.AppendLine($"{indent}  <tr>");

                    for (int col = 0; col < board.Cols; col++)
                    {
                        KnightTourSquare square = board.Squares.Find(s => s.X == row && s.Y == col);
                        if (square != null)
                        {
                            string cssClass = "emptyCell";
                            if (square.Value == board.TotalSquares) cssClass = $"endCell";
                            else if (square.Value == 1) cssClass = $"startCell";

                            html.AppendLine($"{indent}    <td class=\"{cssClass}\">");
                            if (square.Value > 0)
                                html.AppendLine($"{indent}      {square.Value}");
                            html.AppendLine($"{indent}    </td>");
                        }
                    }
                    html.AppendLine($"{indent}  </tr>");
                }

                html.AppendLine($"{indent}</table>");
            }

            return html.ToString();
        }
        #endregion
    }
}
