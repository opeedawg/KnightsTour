using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace KnightsTour
{
    public class PuzzleSearch
    {
        public int MemberId { get; set; }
        public bool NewPuzzlesOnly { get; set; }
        public int DifficultyLevelId { get; set; }
        public string Size { get; set; }
        public string PuzzleCode { get; set; }
        public int RowDimension 
        {
            get 
            {
                int rowDimension = 0;
                if (!string.IsNullOrEmpty(Size))
                {
                    string[] sizeParts = Size.Split('x');
                    if (sizeParts.Length == 2)
                    {
                        rowDimension = int.Parse(sizeParts[1].Trim());
                    }
                }

                return rowDimension;
            }
        }
        public int ColDimension
        {
            get
            {
                int colDimension = 0;
                if (!string.IsNullOrEmpty(Size))
                {
                    string[] sizeParts = Size.Split('x');
                    if (sizeParts.Length == 2)
                    {
                        colDimension = int.Parse(sizeParts[0].Trim());
                    }
                }

                return colDimension;
            }
        }
    }
}
