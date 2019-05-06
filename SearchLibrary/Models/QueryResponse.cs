using System.Collections.Generic;

namespace SearchLibrary.Models
{
    public class QueryResponse
    {
        public QueryResponse()
        {
            //Initialize properties
            CastFacet = new List<KeyValuePair<string, int>>();
            GenreFacet = new List<KeyValuePair<string, int>>();
        }

        //Expose properties that will be returned to from the search library
        public List<Movie> Results { get; set; }

        public int TotalHits { get; set; }

        public int QueryTime { get; set; }

        public int Status { get; set; }

        public MovieQuery OriginalQuery { get; set; }

        public List<string> DidYouMean { get; set; }

        public List<KeyValuePair<string, int>> CastFacet {get;set;}

        public List<KeyValuePair<string, int>> GenreFacet { get; set; }
    }
}