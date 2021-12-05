using Microsoft.Extensions.Configuration;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballApi.Services
{
    public class BaseService
    {
        private readonly string _apiUrl;

        public BaseService(IConfiguration configuration)
        {
            _apiUrl = configuration.GetConnectionString("ApiUrl");
        }

        protected RestClient Client
        {
            get
            {
                return new RestClient(_apiUrl);
            }
        }
    }
}
