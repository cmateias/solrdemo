using System.Collections.Generic;

namespace SearchLibrary.Models
{
    public class MovieQuery
    {
        public MovieQuery()
        {
            Rows = 10;
            Start = 0;
            CastFilter = new List<string>();
            GenreFilter = new List<string>();
        }

        //Query object that holds parameters sent to the search library
        public string Query { get; set; }

        public int Start { get; set; }

        public int Rows { get; set; }

        public List<string> CastFilter { get; set; }

        public List<string> GenreFilter { get; set; }
    }
}
