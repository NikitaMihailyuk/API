using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace Lesson18_api.Core
{
    internal class BaseApiClient
    {
        private RestClient restClient;
        protected Logger logger = LogManager.GetCurrentClassLogger();

        public BaseApiClient(string url)
        {
            var option = new RestClientOptions(url)
            {
                MaxTimeout = 10000,
                ThrowOnAnyError = false
            };

            restClient = new RestClient(option);
            restClient.AddDefaultHeader("Content-Type", "application/json");
        }

        public void AddToken(string token)
        {
            restClient.AddDefaultHeader("Token", token);
        }

        public RestResponse Execute(RestRequest request)
        {
            var response = restClient.Execute(request);
            return response;
        }

        public T Execute<T>(RestRequest request)
        {
            var response = restClient.Execute<T>(request);
            return response.Data;
        }
    }
}