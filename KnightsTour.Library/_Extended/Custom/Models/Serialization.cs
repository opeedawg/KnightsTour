using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnightsTour.Models
{
  public class KTSerialization : KTSerializationKey
  {
    public KTSerialization(string author = "Unknown"):base()
    {
      Author = author;
      Discovery = DateTime.Now;
      Iterations = 0;
    }
    public DateTime Discovery { get; set; } // Create Time
    public string Author { get; set; } // Author
    public long Iterations { get; set; }
  }

  public class KTSerializationKey
  {
    public KTSerializationKey()
    {
      Path = new List<List<int>>();
    }
    public List<List<int>> Path { get; set; } // Columns
  }

}