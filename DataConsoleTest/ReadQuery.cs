using SearchLibrary.Models;
using System;

namespace DataConsoleTest
{
    internal static class QueryReader
    {
        internal static MovieQuery ReadQuery()
        {
            //Create a query object
            MovieQuery query = new MovieQuery();

            Console.WriteLine("Please enter your query");

            //Read the query
            query.Query = Console.ReadLine();

            Console.WriteLine("Do you want to specify an cast?");
            string cast = Console.ReadLine();

            while (!string.IsNullOrEmpty(cast))
            {
                query.CastFilter.Add(cast);

                Console.WriteLine("Add another cast?");
                cast = Console.ReadLine();
            }

            Console.WriteLine("Do you want to specify a genre?");
            string genre = Console.ReadLine();
            while (!string.IsNullOrEmpty(genre))
            {
                query.GenreFilter.Add(genre);

                Console.WriteLine("Add another genre?");
                genre = Console.ReadLine();
            }

            //return the query object 
            return query;
        }
    }
}
