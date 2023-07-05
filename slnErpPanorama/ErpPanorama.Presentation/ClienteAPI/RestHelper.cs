
 
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ErpPanorama.Presentation.ClienteAPI
{
    public static class RestHelper<TRequest, TResponse>
        where TRequest : class
        where TResponse : class, new()
    {
        public static TResponse Execute(string metodo, TRequest request)
        {
            var client = new RestClient("http://172.16.0.151/PanoramaUBL21/api");
            //var client = new RestClient("http://localhost/PanoramaUBL21/api");

            var restRequest = new RestRequest(metodo, Method.POST)
            {
                RequestFormat = DataFormat.Json
            };

            restRequest.AddBody(request);

            var restResponse = client.Execute<TResponse>(restRequest);
            return restResponse.Data;
        }

    }
}
