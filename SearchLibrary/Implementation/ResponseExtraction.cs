using SearchLibrary.Models;
using SolrNet;
using SolrNet.Impl;
using System.Collections.Generic;
using System.Linq;

namespace SearchLibrary.Implementation
{
    internal class ResponseExtraction
    {
        //Extract parts of the SolrNet response and set them in QueryResponse class
        internal void SetHeader(QueryResponse queryResponse, SolrQueryResults<Movie> solrResults)
        {
            queryResponse.QueryTime = solrResults.Header.QTime;
            queryResponse.Status = solrResults.Header.Status;
            queryResponse.TotalHits = solrResults.NumFound;
        }

        internal void SetBody(QueryResponse queryResponse, SolrQueryResults<Movie> solrResults)
        {
            queryResponse.Results = (List<Movie>)solrResults;

            foreach (Movie movie in queryResponse.Results)
            {
                if (solrResults.Highlights.ContainsKey(movie.MovieId))
                {
                    HighlightedSnippets snippets = solrResults.Highlights[movie.MovieId];

                    if (snippets.ContainsKey("title"))
                    {
                        movie.Title = snippets["title"].FirstOrDefault();
                    }
                }
            }
        }

        internal void SetSpellcheck(QueryResponse queryResponse, SolrQueryResults<Movie> solrResults)
        {
            List<string> spellSuggestions = new List<string>();

            foreach (SpellCheckResult spellResult in solrResults.SpellChecking)
            {
                foreach (string suggestion in spellResult.Suggestions)
                {
                    spellSuggestions.Add(suggestion);
                }
            }

            queryResponse.DidYouMean = spellSuggestions;
        }

        internal void SetFacets(QueryResponse queryResponse, SolrQueryResults<Movie> solrResults)
        {
            //Cast
            if (solrResults.FacetFields.ContainsKey("cast"))
            {
                queryResponse.CastFacet = solrResults.FacetFields["cast"].Select(facet => new KeyValuePair<string, int>(facet.Key, facet.Value)).ToList();
            }

            //
            if (solrResults.FacetFields.ContainsKey("genres"))
            {
                queryResponse.GenreFacet = solrResults.FacetFields["genres"].Select(facet => new KeyValuePair<string, int>(facet.Key, facet.Value)).ToList();
            }
        }
    }
}
