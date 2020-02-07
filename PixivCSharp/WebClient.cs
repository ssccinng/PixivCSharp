using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;

namespace PixivCSharp
{
    static class WebClient
    {
        public static HttpClient Client;

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
            HttpRequestMessage request = new HttpRequestMessage();
            UriBuilder address = new UriBuilder(url.Address);
            
            //Adds parameters to uri and sends get request
            if (url.Type == "GET")
            {
                address.Query = parameters;
                request.Method = HttpMethod.Get;
                request.RequestUri = new Uri(address.ToString());
                HttpResponseMessage response = await Client.SendAsync(request);
                responseString = await response.Content.ReadAsStringAsync();
            }
            //Adds parameters to body and sends post request
            else if (url.Type == "POST")
            {
                //Adds parameters in the correct Content-Type header
                if (multipart == true)
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