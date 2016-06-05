using SearchLibrary.Models;
using SolrNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchLibrary.Implementation
{
    internal class FiltersFacets
    {
        internal ICollection<ISolrQuery> BuildFilterQueries(CourseQuery query)
        {
            ICollection<ISolrQuery> filters = new List<ISolrQuery>();

            List<SolrQueryByField> refinersAuthor = new List<SolrQueryByField>();
            List<SolrQueryByField> refinersTag = new List<SolrQueryByField>();

            foreach (string author in query.AuthorFilter)
            {
                refinersAuthor.Add(new SolrQueryByField("author", author));
            }

            foreach (string tag in query.TagFilter)
            {
                refinersTag.Add(new SolrQueryByField("tags", tag));
            }

            if (refinersAuthor.Count > 0)
            {
                filters.Add(new SolrMultipleCriteriaQuery(refinersAuthor, "OR")); //AND
            }

            if (refinersTag.Count > 0)
            {
                filters.Add(new SolrMultipleCriteriaQuery(refinersTag, "OR")); //AND
            }

            return filters; 
        }

    }
}
