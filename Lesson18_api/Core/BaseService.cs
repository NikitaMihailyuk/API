using NUnit.Framework.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace Lesson18_api.Core
{
    internal class BaseService
    {
        protected BaseApiClient apiClient;
        protected static NLog.Logger logger = LogManager.GetCurrentClassLogger();
        //add config

        public BaseService(string url)
        {
            this.apiClient = new BaseApiClient(url);
        }
    }
}
