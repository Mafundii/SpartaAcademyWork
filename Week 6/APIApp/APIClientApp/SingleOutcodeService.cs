using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
namespace APIClientApp;

public class SingleOutcodeService
{
    #region Properties
    //Restsharp object which handles comms with the API
    public RestClient Client { get; set; }
    //Captures the response
    public RestResponse Response { get; set; }

    //Capture the response body JSON
    public JObject ResponseContent { get; set; }

    public SingleOutcodeResponse ResponseObject { get; set; }


    #endregion
    public SingleOutcodeService()
    {
        Client = new RestClient(AppConfigReader.BaseUrl);
    }
    public SingleOutcodeService(string url)
    {
        Client = new RestClient(url);
    }
    public async Task MakesRequestAsync(string outcode)
    {
        //set up the request
        var request = new RestRequest($"https://api.postcodes.io/outcodes/{outcode}",Method.Get);
        request.AddHeader("Content-Type", "application/json");

        Response = await Client.ExecuteAsync(request);

        ResponseContent = JObject.Parse(Response.Content);

        //an object model of the response
        ResponseObject = JsonConvert.DeserializeObject<SingleOutcodeResponse>(Response.Content);
    }

    public int GetStatusCode()
    {
        return (int)Response.StatusCode;
    }


}
