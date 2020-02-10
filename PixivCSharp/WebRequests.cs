using System;
using System.Threading.Tasks;
using System.Net.Http;
using System.Runtime.CompilerServices;

namespace PixivCSharp
{
    static class WebRequests
    {
        private static HttpClient Client;

        //Initialises httpclient and adds default request headers
        public static void ClientInit()
        {
            Client = new HttpClient();
            Client.DefaultRequestHeaders.Add("User-Agent", "PixivAndroidApp/5.0.170");
            //Temporary X-Client headers, to be properly implemented in Request method
            Client.DefaultRequestHeaders.Add("X-Client-Time", "2020-02-10T08:30:22-05:00");
            Client.DefaultRequestHeaders.Add("X-Client-Hash", "90190ae71de847ef72b540ef0ade2868");
        }

        public static async Task<HttpResponseMessage> Request(URL url, FormUrlEncodedContent parameters = null, bool AuthRequired = false, bool multipart = false)
        {
            //Creates http request and uribuilder
            HttpResponseMessage response = null;
            UriBuilder address = new UriBuilder(url.Address);
            
            //Adds parameters to uri and sends get request
            if (url.Type == "GET")
            {
                if (parameters != null) address.Query = await parameters.ReadAsStringAsync();
                response = await Client.GetAsync(address.ToString());
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
                    response = await Client.PostAsync(address.ToString(), parameters);
                }
            }

            return response;
        }
    }
}