using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson18_api.Core
{
    internal class BaseService
    {
        protected BaseApiClient apiClient;
        
        public BaseService(BaseApiClient apiClient)
        { this.apiClient = apiClient; }


    }
}
