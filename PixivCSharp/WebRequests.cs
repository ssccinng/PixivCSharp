using System;
using System.Threading.Tasks;
using System.Net.Http;

namespace PixivCSharp
{
    static class WebRequests
    {
        private static HttpClient Client;

        //Initialises httpclient and adds default request headers
        public static void ClientInit()
        {
            Client = new HttpClient();
            Client.DefaultRequestHeaders.Add("Host", "app-api.pixiv.net");
            Client.DefaultRequestHeaders.Add("Connection", "close");
        }

        public static async Task<string> Request(URL url, string parameters = null, bool multipart = false )
        {
            //Creates http request and uribuilder
            string responseString = "";
            UriBuilder address = new UriBuilder(url.Address);
            
            //Adds parameters to uri and sends get request
            if (url.Type == "GET")
            {
                address.Query = parameters;
                HttpResponseMessage response = await Client.GetAsync(address.ToString());
                responseString = await response.Content.ReadAsStringAsync();
            }
            //Adds parameters to body and sends post request
            else if (url.Type == "POST")
            {
                //Adds parameters in the correct Content-Type header
                if (multipart)
                {
                    //multipart code
                }
                else
                {
                    //x-www-form-urlencoded code
                }
            }

            return responseString;
        }
    }
}