using System.Collections.Generic;
using SolrNet.Attributes;

namespace SearchLibrary.Models
{
    public class Movie
    {

        [SolrUniqueKey("movieid")]
        public string MovieId { get; set; }

        [SolrField("title")]
        public string Title { get; set; }

        [SolrField("year")]
        public int Year { get; set; }

        [SolrField("month")]
        public string Month { get; set; }

        [SolrField("rating")]
        public int Rating { get; set; }

        [SolrField("cast")]
        public List<string> Cast { get; set; }

        [SolrField("genres")]
        public List<string> Genres { get; set; }
    }
}
