using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace APIClientApp;
public class BulkPostcodeService
{
    #region Properties
    //Restsharp object which handles comms with the API
    public RestClient Client { get; set; }
    //Captures the response
    public RestResponse Response { get; set; }

    //Capture the response body JSON
    public JObject ResponseContent { get; set; }

    public BulkPostcodeResponse ResponseObject { get; set; }


    #endregion
    public BulkPostcodeService()
    {
        Client = new RestClient(AppConfigReader.BaseUrl);
    }
    public BulkPostcodeService(string url)
    {
        Client = new RestClient(url);
    }

    public async Task MakesRequestAsync(string[] postcodes)
    {
        //set up the request
        var request = new RestRequest("postcodes?={}",Method.Post);
        request.AddHeader("Content-Type", "application/json");
        var bulkPostcodes = new
        {
            Postcodes = postcodes
        };
        request.AddJsonBody(bulkPostcodes);

        Response = await Client.ExecuteAsync(request);
        ResponseContent = JObject.Parse(Response.Content);
        ResponseObject = JsonConvert.DeserializeObject<BulkPostcodeResponse>(Response.Content); 
    }

    public int GetStatusCode()
    {
        return (int)Response.StatusCode;
    }


}
