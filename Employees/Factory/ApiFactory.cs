using Client;
using Employees.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading;
using System.Threading.Tasks;

namespace Employees.Factory
{
    internal static class ApiFactory
    {
        private static Uri apiUri;

        private static Lazy<apiHelper> restClient = new Lazy<apiHelper>(
            () => new apiHelper(apiUri),
            LazyThreadSafetyMode.ExecutionAndPublication);

        static ApiFactory()
        {
            apiUri = new Uri(ApplicationSettings.ApiEndPointUrl);
        }
          
        public static apiHelper Instance
        {
            get
            {
                return restClient.Value;
            }
        }
    }
}
