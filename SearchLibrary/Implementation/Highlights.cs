using SolrNet.Commands.Parameters;
using System.Collections.Generic;

namespace SearchLibrary.Implementation
{
    internal class Highlights
    {
        internal HighlightingParameters BuildHighlightParameters()
        {
            HighlightingParameters parameters = new HighlightingParameters()
            {
                Fields = new List<string>() { "title" },
                Fragsize = 200
            };

            return parameters;
        }
    }
}
