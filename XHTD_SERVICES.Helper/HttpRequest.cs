using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using XHTD_SERVICES.Helper.Models.Request;
using XHTD_SERVICES.Helper.Models.Response;
using RestSharp;

namespace XHTD_SERVICES.Helper
{
    public static class HttpRequest
    {
        public static IRestResponse GetPortalOrder(string token, int numberHoursSearchOrder)
        {
            var apiUrl = ConfigurationManager.GetSection("API_Portal/Url") as NameValueCollection;

            var requestData = new SearchOrderRequest
            {
                from = DateTime.Now.AddHours(-1 * numberHoursSearchOrder).ToString("dd/MM/yyyy"),
                to = DateTime.Now.ToString("dd/MM/yyyy"),
            };

            var client = new RestClient(apiUrl["SearchOrder"]);
            var request = new RestRequest();

            request.Method = Method.POST;
            request.AddJsonBody(requestData);
            request.AddHeader("Authorization", "Bearer " + token);
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-Type", "application/json");
            request.RequestFormat = DataFormat.Json;

            IRestResponse response = client.Execute(request);

            return response;
        }

        public static IRestResponse GetPortalToken()
        {
            var apiUrl = ConfigurationManager.GetSection("API_Portal/Url") as NameValueCollection;
            var account = ConfigurationManager.GetSection("API_Portal/Account") as NameValueCollection;

            var requestData = new GetDMSTokenRequest
            {
                grant_type = account["grant_type"].ToString(),
                username = account["username"].ToString(),
                password = account["password"].ToString(),
                environtment = 2
            };

            var client = new RestClient(apiUrl["GetToken"]);
            var request = new RestRequest();

            request.Method = Method.POST;

            request.AddJsonBody(requestData);
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-Type", "application/json");
            request.RequestFormat = DataFormat.Json;

            IRestResponse response = client.Execute(request);

            return response;
        }
    }
}
