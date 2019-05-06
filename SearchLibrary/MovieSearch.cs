using SearchLibrary.Implementation;
using SearchLibrary.Models;
using SolrNet;
using SolrNet.Commands.Parameters;

namespace SearchLibrary
{
    public class MovieSearch
    {
        private Connection connection;

        public MovieSearch()
        {
            //Initialize connection
            //Connection can be initialized once and then retrieved via ServiceLocator.GetInstance
            //But we are creating it for every search library instantiation for demo purposes            
            connection = new Connection("https://localhost:9000/solr/movies_list");
        }

        public QueryResponse DoSearch(MovieQuery query)
        {
            //Create an object to hold results
            FiltersFacets filtersFacets = new FiltersFacets();
            Highlights highlights = new Highlights();
            ExtraParameters extraParameters = new ExtraParameters();

            SolrQueryResults<Movie> solrResults;
            QueryResponse queryResponse = new QueryResponse
            {

                //Echo back the original query 
                OriginalQuery = query
            };

            //Get a connection
            ISolrOperations<Movie> solr = connection.GetSolrInstance();
            QueryOptions queryOptions = new QueryOptions
            {
                Rows = query.Rows,
                StartOrCursor = new StartOrCursor.Start(query.Start),
                FilterQueries = filtersFacets.BuildFilterQueries(query),
                Facet = filtersFacets.BuildFacets(),
                Highlight = highlights.BuildHighlightParameters(),
                ExtraParams = extraParameters.BuildExtraParameters()
            };

            //Execute the query
            ISolrQuery solrQuery = new SolrQuery(query.Query);

            solrResults = solr.Query(solrQuery, queryOptions);

            //Set response
            ResponseExtraction extractResponse = new ResponseExtraction();

            extractResponse.SetHeader(queryResponse, solrResults);
            extractResponse.SetBody(queryResponse, solrResults);
            extractResponse.SetSpellcheck(queryResponse, solrResults);
            extractResponse.SetFacets(queryResponse, solrResults);

            //Return response;
            return queryResponse;
        }
    }
}
