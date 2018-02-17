using System;
using System.Collections.Generic;
using System.Text;
using RestSharp;
namespace Event.Service.HttpClient
{
    public interface IAblRestClient
    {
        IRestClient Client { get; set; }
        IRestRequest Request{ get; set; }
        IRestResponse Response { get; set; }
    }





}
