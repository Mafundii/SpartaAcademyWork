using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIClientApp.PostcodesIOService.HTTPManager
{
    public class CallManager
    {
        private readonly RestClient _client;
        public RestResponse Response { get; set; }

        public CallManager()
        {
            _client = new RestClient(AppConfigReader.BaseUrl);
        }
        public async Task<string> MakePostcodeRequestAsync(string postcode)
        {
            var request = new RestRequest();
            request.AddHeader("Content-type", "application/json");
            request.Resource = $"postcodes/{postcode.ToLower().Replace(" ", "")}";
            Response = await _client.ExecuteAsync(request);
            return Response.Content;
        }


    }
}
