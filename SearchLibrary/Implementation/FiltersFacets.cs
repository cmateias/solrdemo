using SearchLibrary.Models;
using SolrNet;
using SolrNet.Commands.Parameters;
using System.Collections.Generic;

namespace SearchLibrary.Implementation
{
    internal class FiltersFacets
    {
        internal ICollection<ISolrQuery> BuildFilterQueries(MovieQuery query)
        {
            ICollection<ISolrQuery> filters = new List<ISolrQuery>();

            List<SolrQueryByField> refinersCast = new List<SolrQueryByField>();
            List<SolrQueryByField> refinersGenre = new List<SolrQueryByField>();

            foreach (string cast in query.CastFilter)
            {
                refinersCast.Add(new SolrQueryByField("cast", cast));
            }

            foreach (string genre in query.GenreFilter)
            {
                refinersGenre.Add(new SolrQueryByField("genres", genre));
            }

            if (refinersCast.Count > 0)
            {
                filters.Add(new SolrMultipleCriteriaQuery(refinersCast, "OR")); //AND
            }

            if (refinersGenre.Count > 0)
            {
                filters.Add(new SolrMultipleCriteriaQuery(refinersGenre, "OR")); //AND
            }

            return filters;
        }

        internal FacetParameters BuildFacets()
        {
            return new FacetParameters
            {
                Queries = new List<ISolrFacetQuery>{
        new SolrFacetFieldQuery("cast"){MinCount = 1},
        new SolrFacetFieldQuery("genres"){MinCount = 1},
        //new SolrFacetDateQuery("releasedate",DateTime.Now.AddYears(-10),DateTime.Now,"+1YEAR")
        }
            };
        }

    }
}
