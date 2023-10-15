using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace KnightsTour.Models
{
    [Serializable]
    public class KnightTourSquareBase
    {
        #region Constructor
        public KnightTourSquareBase(long x, long y, int value)
        {
            X = x;
            Y = y;
            Value = value;
        }
        #endregion

        #region Constants
        #endregion

        #region Properties
        public long X { get; set; }
        public long Y { get; set; }
        public int Value { get; set; }
        #endregion
    }
}
