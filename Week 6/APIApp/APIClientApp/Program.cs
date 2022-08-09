using RestSharp;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
namespace APIClientApp
{
    public class Program
    {
        static Controller _controller;
        static async Task Main(string[] args)
        {
            //await LessonContents();
            _controller = new Controller();
            while (true) 
            {
                await Menu();
            }
        }
        public static async Task Menu()
        {
            Console.WriteLine("Postcode, Bulk Postcode, or Outcode?");
            string input = Console.ReadLine();
            if (input.Contains("b")) await LookupBulkPostcodes();
            else if (input.Contains("p")) await LookupPostcode();
            else if (input.Contains("o")) await LookupOutcode();
        }
            public static async Task LookupPostcode() 
        {
            Console.WriteLine("Input a postcode");
            string input = Console.ReadLine();
            var lookUpPostCode = _controller.LookupPostcode(input);
            await lookUpPostCode;
            var lines = lookUpPostCode.Result;
            foreach (string line in lines) 
            {
                Console.WriteLine(line);
            }
        }
        public static async Task LookupOutcode()
        {
            Console.WriteLine("Input an outcode");
            string input = Console.ReadLine();
            var lookUpPostCode = _controller.LookupOutcode(input);
            await lookUpPostCode;
            var lines = lookUpPostCode.Result;
            foreach (string line in lines)
            {
                Console.WriteLine(line);
            }
        }
        public static async Task LookupBulkPostcodes()
        {
            string input = "";
            List<string> bulkPostcodeInputs = new List<string>();
            while (input != "x") 
            {
                Console.WriteLine("Input a postcode or 'x' to finish bulk lookup");
                input = Console.ReadLine();
                if (input != "x") bulkPostcodeInputs.Add(input);
            }
            var lookUpPostCodes = _controller.LookupBulkPostcodes(bulkPostcodeInputs);
            await lookUpPostCodes;
            var lines = lookUpPostCodes.Result;
            foreach (string line in lines)
            {
                Console.WriteLine(line);
            }
        }



























        private static async Task LessonContents()
        {
            // Encapsulate the information we need to make the api call
            //We can make authneticated HTTP requests
            var restClient = new RestClient("https://api.postcodes.io/");

            //Set up the request. Create a request object
            var restRequest = new RestRequest();
            restRequest.Method = Method.Get;
            restRequest.AddHeader("Content-Type", "application/json");
            var postcode = "EC2Y 5AS";
            restRequest.Resource = $"postcodes/{postcode.ToLower().Replace(" ","")}";

            //Execute request
            RestResponse singlePostcodeResponse = await restClient.ExecuteAsync(restRequest);
            //Console.WriteLine("Response content (string)");
            //Console.WriteLine(singlePostcodeResponse.Content);
            //Console.WriteLine("Response code (enum)");
            //Console.WriteLine(singlePostcodeResponse.StatusCode);
            //Console.WriteLine("Response code (int)");
            //Console.WriteLine((int)singlePostcodeResponse.StatusCode);
            //Console.WriteLine("Headers");
            //foreach (var item in singlePostcodeResponse.Headers)
            //{
            //    Console.WriteLine(item);
            //}

            var responseContentType = singlePostcodeResponse.Headers.Where(x => x.Name == "Date")
                .Select(h => h.Value.ToString()).FirstOrDefault();

            //Console.WriteLine(responseContentType);

            var client = new RestClient();
            var request = new RestRequest("https://api.postcodes.io/postcodes/", Method.Post);
            request.AddHeader("Content-Type", "application/json");

            // request.AddStringBody("{\r\n\"postcodes\" : [\"OX49 5NU\", \"M32 0JG\", \"NE30 1DP\"]\r\n}\r\n", DataFormat.Json);

            var postcodes = new
            {
                Postcodes = new string[] { "PR3 0SG", "M45 6GN", "EX165BL" }
            };
            request.AddJsonBody(postcodes);
            RestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);

            var singlePostcodeJsonResponse = JObject.Parse(singlePostcodeResponse.Content);
            Console.WriteLine(singlePostcodeResponse);

            var adminDistrict = singlePostcodeJsonResponse["result"]["admin_district"];
            Console.WriteLine(adminDistrict);


            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Bulk request stuff:");
            var bulkRestClient = new RestClient("https://api.postcodes.io/");
            var bulkRestRequest = new RestRequest("postcodes?={}");
            bulkRestRequest.Method = Method.Post;
            bulkRestRequest.AddHeader("Content-Type", "application/json");
            var bulkpostcodes = new
            {
                Postcodes = new string[] { "PR3 0SG", "M45 6GN", "EX165BL" }
            };
            bulkRestRequest.AddJsonBody(bulkpostcodes);
            RestResponse bulkResponse = bulkRestClient.Execute(bulkRestRequest);

            var bulkJObject = JObject.Parse(bulkResponse.Content);

            foreach (JToken jToken in bulkJObject.PropertyValues())
            {
                if (Int32.Parse(bulkJObject["status"].ToString()) == 200 && jToken.Type == JTokenType.Integer) Console.ForegroundColor = ConsoleColor.Green;
                else if ((bulkJObject["status"].ToString().Contains("4") && jToken.Type == JTokenType.Integer)) Console.ForegroundColor = ConsoleColor.Red;
                else Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine(jToken);
            }
            Console.WriteLine(bulkJObject["result"][1]["result"]["codes"]["admin_district"]);

            var list = bulkJObject["result"].ToList();
            var bulkPostcodeObjectResponse = JsonConvert.DeserializeObject<BulkPostcodeResponse>(bulkResponse.Content);

            Console.WriteLine("Bulk postcode response:\n");

            foreach (var p in bulkPostcodeObjectResponse.result)
            {
                Console.WriteLine(p.query);
                Console.WriteLine($"{p.result.admin_ward}\n");
            }

            var selectedAdminCounty = bulkPostcodeObjectResponse.result.Where(q => q.query == "PR3 0SG")
                .FirstOrDefault().result.codes.admin_county;

            var selectedAdminCountyAlt = bulkPostcodeObjectResponse.result[0].result.codes.admin_county;

            while (true)
            {
                Console.WriteLine("Input an outcode");

                string input = Console.ReadLine();
                var outcodeJObject = LookupOutcodeJ(input);

                foreach (JToken token in outcodeJObject.PropertyValues())
                {
                    Console.WriteLine(token);
                }

                if ((int)outcodeJObject["status"] != 200) continue;

                Console.WriteLine();
                var outcodeClass = LookupOutcode(input);

                foreach (var o in outcodeClass.result.admin_county)
                {
                    Console.WriteLine(o);
                }
            }
        }

        public static JObject LookupOutcodeJ(string outCodeInput) 
        {
            var singleOutcodeRestClient = new RestClient($"https://api.postcodes.io/outcodes/{outCodeInput}");
            var singleOutcodeRestRequest = new RestRequest();
            singleOutcodeRestRequest.Method = Method.Get;
            singleOutcodeRestRequest.AddHeader("Content-Type", "application/json");
            RestResponse singleOutcodeResponse = singleOutcodeRestClient.Execute(singleOutcodeRestRequest);

            var singleOutcodeJObject = JObject.Parse(singleOutcodeResponse.Content);
            return singleOutcodeJObject;
        }

        public static SingleOutcodeResponse LookupOutcode(string outCodeInput)
        {
            var singleOutcodeRestClient = new RestClient($"https://api.postcodes.io/outcodes/{outCodeInput}");
            var singleOutcodeRestRequest = new RestRequest();
            singleOutcodeRestRequest.Method = Method.Get;
            singleOutcodeRestRequest.AddHeader("Content-Type", "application/json");
            RestResponse singleOutcodeResponse = singleOutcodeRestClient.Execute(singleOutcodeRestRequest);

            var singleOutcodeObjectResponse = JsonConvert.DeserializeObject<SingleOutcodeResponse>(singleOutcodeResponse.Content);
            return singleOutcodeObjectResponse;
        }
    }
}