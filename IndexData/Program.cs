using Microsoft.Practices.ServiceLocation;
using Newtonsoft.Json;
using SolrNet;
using System.Collections.Generic;
using System.IO;
using IndexData.Models;

namespace IndexData
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;

            //deleting the core contents if needed
            //http://localhost:9000/solr/movies_list/update?stream.body=<delete><query>*:*</query></delete>&commit=true

            //Read file and deserialize using Json.Net 
            List<Movies> allMovies = JsonConvert.DeserializeObject<List<Movies>>(File.ReadAllText(@"..\..\movies_list.json"));
            Startup.Init<Movies>("https://localhost:9000/solr/movies_list");

            ISolrOperations<Movies> solr = ServiceLocator.Current.GetInstance<ISolrOperations<Movies>>();
            
            foreach (Movies movie in allMovies)
            {
                solr.Add(movie);

            }

            solr.Commit();
        }


    }
}
