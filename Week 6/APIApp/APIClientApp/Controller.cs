using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
namespace APIClientApp;

public class Controller
{
    public async Task<List<string>> LookupPostcode(string input) 
    {
        var singlePostcodeService = new SinglePostcodeService("https://api.postcodes.io");
        await singlePostcodeService.MakesRequestAsync(input);

        List<string> list = new List<string>();
        foreach (JToken token in singlePostcodeService.ResponseContent.PropertyValues())
        {
            list.Add(token.ToString());
        }
        return list;
    }
    public async Task<List<string>> LookupOutcode(string input)
    {
        var singleOutcodeService = new SingleOutcodeService("https://api.postcodes.io");
        await singleOutcodeService.MakesRequestAsync(input);

        List<string> list = new List<string>();
        foreach (JToken token in singleOutcodeService.ResponseContent.PropertyValues())
        {
            list.Add(token.ToString());
        }
        return list;
    }

    public async Task<List<string>> LookupBulkPostcodes(List<string> inputs)
    {
        var bulkPostcodeService = new BulkPostcodeService("https://api.postcodes.io");
        await bulkPostcodeService.MakesRequestAsync(inputs.ToArray());

        List<string> list = new List<string>();
        foreach (JToken token in bulkPostcodeService.ResponseContent.PropertyValues())
        {
            list.Add(token.ToString());
        }
        return list;
    }
}
