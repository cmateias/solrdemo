using System.Collections.Generic;

namespace SearchLibrary.Implementation
{
    internal class ExtraParameters
    {
        internal List<KeyValuePair<string, string>> BuildExtraParameters()
        {
            List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("hl.simple.pre", "<b>"),
                new KeyValuePair<string, string>("hl.simple.post", "</b>"),

                new KeyValuePair<string, string>("defType", "edismax"),
                new KeyValuePair<string, string>("qf", "title^10.0 _text_")
            };

            return parameters;
        }
    }
}
