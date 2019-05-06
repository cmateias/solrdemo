using SearchLibrary;
using SearchLibrary.Models;
using System;

namespace DataConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //create a search library instance
            MovieSearch searchLibrary = new MovieSearch();

            MovieQuery query = new MovieQuery();

            query = QueryReader.ReadQuery();

            while (query.Query != Environment.NewLine)
            {
                QueryResponse response = searchLibrary.DoSearch(query);

                PrettyPrintResults.PrintOut(response);

                query = QueryReader.ReadQuery();
            }
        }
    }
}
