using System;
using Newtonsoft;
using Newtonsoft.Json.Linq;

namespace PixivCSharp
{
    public class Pixiv
    {
        public Pixiv()
        {
            WebClient.ClientInit();
        }
        public static void WalkthoughIllusts()
        {
            string response = WebClient.Request(PixivUrls.WalkthroughIllusts).Result;
        }
    }
    
    class Auth
    {
        
    }
}