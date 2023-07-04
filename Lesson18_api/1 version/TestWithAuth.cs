using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson18_api
{
    internal class WithAuth
    {
        RestClient client;

        [SetUp]
        public void Setup()
        {
            client = new RestClient("https://api.qase.io/v1");
        }

        [Test]
        public void GetProjects()
        {
            var request = new RestRequest("/project", Method.Get);

            request.AddHeader("Token", "139648cd7fae0460f1e38bd794aaf54a22505db0680705fabe0efeb918d968c2");

            var response = client.Execute(request);

            if (response.IsSuccessful)
            {
                Console.WriteLine(response.Content.ToString());
            }
            else
            {
                Console.WriteLine("Failed: " + response.ErrorMessage);
            }

        }
    }
}