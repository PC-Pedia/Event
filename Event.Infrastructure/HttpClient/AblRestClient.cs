using System;
using System.Collections.Generic;
using System.Text;
using RestSharp;

namespace Event.Service.HttpClient
{
    public class AblRestClient : IAblRestClient
    {
        public AblRestClient(IRestClient client, IRestRequest request, IRestResponse response)
        {
            Client = client;
            Response = response;
            Request = request;
        }

        public IRestClient Client { get; set; }
        public IRestRequest Request { get; set; }
        public IRestResponse Response { get; set; }
    }
}
