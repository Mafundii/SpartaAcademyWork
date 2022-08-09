using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
namespace APIClientApp;

public class SinglePostcodeService
{
    #region Properties
    //Restsharp object which handles comms with the API
    public RestClient Client { get; set; }
    //Captures the response
    public RestResponse Response { get; set; }
    
    //Capture the response body JSON
    public JObject ResponseContent { get; set; }

    public SinglePostcodeResponse ResponseObject { get; set; }


    #endregion
    public SinglePostcodeService()
    {
        Client = new RestClient(AppConfigReader.BaseUrl);
    }
    public SinglePostcodeService(string url)
    {
        Client = new RestClient(url);
    }
    public async Task MakesRequestAsync(string postcode) 
    {
        //set up the request
        var request =  new RestRequest();
        request.AddHeader("Content-Type", "application/json");
        request.Resource = ($"postcodes/{postcode.ToLower().Replace(" ", "")}");

        Response = await Client.ExecuteAsync(request);

        ResponseContent = JObject.Parse(Response.Content);

        //an object model of the response
        ResponseObject = JsonConvert.DeserializeObject<SinglePostcodeResponse>(Response.Content);
    }

    public int GetStatusCode() 
    {
        return (int)Response.StatusCode;
    }
}
