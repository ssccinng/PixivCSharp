using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace PixivCSharp.Tests
{
    public partial class Tests
    {
        public static async Task ViewGenericRequest()
        {
            IllustSeriesInfo result;
            
            // Error handling
            try
            {
                result = await Client.RequestAsync<IllustSeriesInfo>(
                    "https://app-api.pixiv.net/v1/illust/series?illust_series_id=21859&filter=for_android&offset=30");
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine(e.Message);
                return;
            }
            
            Console.WriteLine("Illust series info:");
            Console.WriteLine("-------------------------------------------------------------------------------");
            Output.TestIllustSeries(result.SeriesDetail);
            Console.WriteLine("First illust:");
            Console.WriteLine("-------------------------------------------------------------------------------");
            Output.TestIllust(result.FirstIllust);
            Console.WriteLine("Illusts:");
            Console.WriteLine("-------------------------------------------------------------------------------");

            foreach (Illust illust in result.Illusts)
            {
                Output.TestIllust(illust);
            }
            
            Console.WriteLine("Next URL: {0}", result.NextUrl);
        }
    }
}