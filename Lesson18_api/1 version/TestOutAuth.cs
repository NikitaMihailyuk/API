using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson18_api
{
    internal class TestOutAuth
    {
        RestClient client;

        [SetUp]
        public void Setup()
        {
            client = new RestClient("https://reqres.in/api");
        }

        [Test]
        public void GetUserById()
        {
            var request = new RestRequest("/users/2", Method.Get);

            var response = client.Execute(request);

            if (response.IsSuccessful)
            {
                 Console.WriteLine(response.Content.ToString());



                var userRes = JsonConvert.DeserializeObject<CommonDataResponse<User>>(response.Content);
                var userRes2 = JsonConvert.DeserializeObject<CommonDataResponse<List<User>>>(response.Content);






                var jsonResponse = JObject.Parse(response.Content);
                var userResponseRoot = JsonConvert.DeserializeObject<User>(jsonResponse.SelectToken("$.data").ToString());
   
                Console.WriteLine(userResponseRoot.first_name);
            }
            else
            {
                Console.WriteLine("Failed: " + response.ErrorMessage);
            }
            
        }

        [Test]
        public void CreateUser_Hardcode()
        {
            var request = new RestRequest("/users", Method.Post);

         ///   var body = new User
       ///     {
        ///        Name = " ",
        ///        Password = " ",
        ///    };

          //  request.AddBody(body);

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

        [Test]
        public void CreateUser_Dictionary()
        {
            var request = new RestRequest("/users", Method.Post);

            var body = new Dictionary<string, object>()
            {
                { "Name", "Ivan"},
                { "Password", "QWERT12345" }
            };

            request.AddBody(body);

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

        [Test]
        public void CreateUser_Model()
        {
            var request = new RestRequest("/users", Method.Post);

            var user = new User
            {
                first_name = "Ivan",
                email = "123",
            };

            var body = JsonConvert.SerializeObject(user);

            request.AddBody(body);
            var response = client.Execute(request);

            if (response.IsSuccessful)
            {
                Console.WriteLine(response.Content.ToString());
            }
            else
            {
                Console.WriteLine("Failed: " + response.ErrorMessage);
            }
            User userResponseRoot = JsonConvert.DeserializeObject<User>(response.Content);
         ////   Assert.AreEqual(user.first_name, userResponseRoot.first_name);
            Assert.That(user, Is.EqualTo(userResponseRoot));
            
        }

        [Test]
        public void CreateUser_File()
        {
            var request = new RestRequest("/users", Method.Post);
            ////
            var body = File.ReadAllText(@"Userjs.json");

            request.AddBody(body);

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