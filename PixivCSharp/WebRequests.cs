using System;
using System.Threading.Tasks;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;

namespace PixivCSharp
{
    static class WebRequests
    {
        private static HttpClient Client;
        private static MD5 md5;

        //Initialises httpclient and adds default request headers
        public static void ClientInit()
        {
            Client = new HttpClient();
            Client.DefaultRequestHeaders.Add("User-Agent", "PixivAndroidApp/5.0.170 (Android 5.1; Google Nexus 5)");
            Client.DefaultRequestHeaders.Add("Accept-Language", "en_US");
            Client.DefaultRequestHeaders.Add("App-OS", "android");
            Client.DefaultRequestHeaders.Add("App-OS-Version", "5.1");
            Client.DefaultRequestHeaders.Add("Connection", "close");
            md5 = MD5.Create();
            
        }

        public static async Task<HttpResponseMessage> Request(URL url, FormUrlEncodedContent parameters = null, bool AuthRequired = false, bool multipart = false)
        {
            //Creates http request and uribuilder
            HttpResponseMessage response = null;
            HttpRequestMessage request = new HttpRequestMessage();
            UriBuilder address = new UriBuilder(url.Address);

            //Creates and adds X-Client headers
            string time = DateTime.UtcNow.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:sszzz");
            byte[] hashBytes = md5.ComputeHash(Encoding.UTF8.GetBytes(time + "28c1fdd170a5204386cb1313c7077b34f83e4aaf4aa829ce78c231e05b0bae2c"));
            StringBuilder sb = new StringBuilder();
            foreach (byte b in hashBytes)
            {
                sb.Append(b.ToString("x2"));
            }
            request.Headers.Add("X-Client-Time", time);
            request.Headers.Add("X-Client-Hash", sb.ToString());
            

            //Adds parameters to uri and sends get request
            if (url.Type == "GET")
            {
                if (parameters != null) address.Query = await parameters.ReadAsStringAsync().ConfigureAwait(false);
                request.RequestUri = new Uri(address.ToString());
                request.Method = HttpMethod.Get;
                response = await Client.SendAsync(request).ConfigureAwait(false);
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
                    request.RequestUri = new Uri(address.ToString());
                    request.Method = HttpMethod.Post;
                    request.Content = parameters;
                    response = await Client.SendAsync(request).ConfigureAwait(false);
                }
            }

            response.EnsureSuccessStatusCode();
            return response;
        }
    }
}