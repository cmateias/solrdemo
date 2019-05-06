using SearchLibrary.Models;
using System;
using System.Collections.Generic;

namespace DataConsoleTest
{
    internal static class PrettyPrintResults
    {
        internal static void PrintOut(QueryResponse queryResponse)
        {
            if (queryResponse.Results.Count == 0)
            {
                Console.WriteLine();
                Console.WriteLine("*** No results found: ***");
                if (queryResponse.DidYouMean.Count > 0)
                {
                    Console.WriteLine("Did you mean?: " + string.Join(" / ", queryResponse.DidYouMean) + Environment.NewLine);
                }

                return;
            }

            //Print out the results
            int i = 0;
            Console.WriteLine();
            Console.WriteLine("*** Results *** ");
            foreach (Movie movie in queryResponse.Results)
            {
                Console.WriteLine(i++ + ": " + movie.Title + " ");
                Console.Write("- by: " + string.Join(",", movie.Cast?.ToArray()) + " ");
                 Console.WriteLine("[" + string.Join(" ", movie.Genres?.ToString()) + "]");
                Console.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine("Facets");

            Console.WriteLine("- Cast");
            foreach (KeyValuePair<string, int> cast in queryResponse.CastFacet)
            {
                Console.WriteLine(" " + cast.Key + " (" + cast.Value + ")");
            }

            Console.WriteLine();

            Console.WriteLine("- Genre");
            foreach (KeyValuePair<string, int> genre in queryResponse.GenreFacet)
            {
                Console.WriteLine(" " + genre.Key + " (" + genre.Value + ")");
            }
            Console.WriteLine();
           
            Console.WriteLine("--- Results found: " + queryResponse.TotalHits);
        }
    }
}
