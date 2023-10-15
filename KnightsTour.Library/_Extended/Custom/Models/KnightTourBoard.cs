using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace KnightsTour.Models
{
    [Serializable]
    public class KnightTourBoard
    {
        #region Constructor
        public KnightTourBoard(long rows, long cols)
        {
            Rows = rows;
            Cols = cols;

            if (Rows % 2 == 1 && Cols % 2 == 1)
                throw new ArgumentException($"Both rows and cols cannot be odd.  See rule 1 (Schwenk) from https://en.wikipedia.org/wiki/Knight%27s_tour#Existence");
            else if (Rows == 1 || Rows == 2 || Rows == 4)
                throw new ArgumentException($"Rows cannot be 1, 2 or 4.  See rule 2 (Schwenk) from https://en.wikipedia.org/wiki/Knight%27s_tour#Existence");
            else if (Rows == 3 && (Cols == 4 || Cols == 6 || Cols == 8))
                throw new ArgumentException($"Cols cannot be 4, 6 or 8 when Rows equals 3. See rule 3 (Schwenk) from https://en.wikipedia.org/wiki/Knight%27s_tour#Existence");

            Squares = InitializeSquares();
        }
        #endregion

        #region Properties
        public long TotalSquares
        {
            get
            {
                return Cols * Rows;
            }
        }
        public long Cols { get; set; }
        public long Rows { get; set; }
        public long Iterations { get; set; }
        public List<KnightTourSquare> Squares { get; set; }
        public string Serialized
        {
            get
            {
                KTSerialization serialization = new KTSerialization("Christoper Zee Chartrand");

                for (long row = 0; row < Rows; row++)
                {
                    List<int> rowValues = new List<int>();
                    for (long col = 0; col < Cols; col++)
                    {
                        rowValues.Add(Squares.First(s => s.X == row && s.Y == col).Value);
                    }
                    serialization.Path.Add(rowValues);
                }

                serialization.Iterations = Iterations;
                return JsonConvert.SerializeObject(serialization);
            }
        }
        public string SerializedKey
        {
            get
            {
                KTSerializationKey serialization = new KTSerializationKey();

                for (long row = 0; row < Rows; row++)
                {
                    List<int> rowValues = new List<int>();
                    for (long col = 0; col < Cols; col++)
                    {
                        rowValues.Add(Squares.First(s => s.X == row && s.Y == col).Value);
                    }
                    serialization.Path.Add(rowValues);
                }

                return JsonConvert.SerializeObject(serialization);
            }
        }
        #endregion

        #region Methods
        public KnightTourBoard Clone()
        {
            using (var ms = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(ms, this);
                ms.Position = 0;

                return (KnightTourBoard)formatter.Deserialize(ms);
            }
        }
        List<KnightTourSquare> InitializeSquares()
        {
            List<KnightTourSquare> newBoard = new List<KnightTourSquare>();
            for (long i = 0; i < Rows; i++)
                for (long j = 0; j < Cols; j++)
                    newBoard.Add(new KnightTourSquare(i, j, Rows, Cols));

            return newBoard;
        }
        public List<KnightTourSquareBase> CreateSquareBaseCopy()
        {
            List<KnightTourSquareBase> squares = new List<KnightTourSquareBase>();

            foreach (KnightTourSquare square in Squares)
            {
                squares.Add(new KnightTourSquareBase(square.X, square.Y, square.Value));
            }

            return squares;
        }
        public void ClearValues()
        {
            foreach(KnightTourSquare square in Squares)
                square.Value = KnightTourSquare.AVAILABLE_SQUARE;
        }
        #endregion
    }
}