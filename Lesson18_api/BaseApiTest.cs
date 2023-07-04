using Lesson18_api.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Configuration;

namespace Lesson18_api
{

    internal class BaseApiTest

    {
        protected BaseApiClient apiClient;

        [OneTimeSetUp]
        public void InitApiClient()
        {
            ///   apiClient = new BaseApiClient(https://api.qase.io/v1);
            apiClient = new BaseApiClient("https://api.qase.io/v1");
            apiClient.AddToken("0f6b575dda888d5edb4b9ab4abf9352e7f29f71c20b81580de2724d3a27b9362");
        }

    }
}