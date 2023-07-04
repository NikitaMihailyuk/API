using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RichardSzalay.MockHttp;
using System.Net;

namespace Lesson18_api
{
    internal class GetMockProjectTests
    {
        [Test]
        public void GetMockProject()
        {
            var mock = new MockHttpMessageHandler();
            mock.When("http://qaseio/api/v8/project/*").Respond( new HttpResponseMessage() { Content = "'Title':'TESTM'", StatusCode=HttpStatusCode.Accepted });

            var client = new RestClient(new RestClientOptions { ConfigureMessageHandler = _ => mock });

            var request = new RestRequest("http/requst");
            var response = client.Get(request);
            Console.WriteLine(response.Content);
        }
    }
}
