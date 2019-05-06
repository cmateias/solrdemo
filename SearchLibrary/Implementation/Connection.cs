using Microsoft.Practices.ServiceLocation;
using SearchLibrary.Models;
using SolrNet;

namespace SearchLibrary.Implementation
{
    internal class Connection
    {
        //Initialize the connection and provide it to the search library    
        internal Connection(string coreUrl)
        {
            InitializeConnection(coreUrl);
        }

        private void InitializeConnection(string coreUrl)
        {
            System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;
            Startup.Init<Movie>(coreUrl);
        }

        internal ISolrOperations<Movie> GetSolrInstance()
        {
            return ServiceLocator.Current.GetInstance<ISolrOperations<Movie>>();
        }
    }
}
