using System.Text;
using Newtonsoft.Json;

namespace PixivCSharp
{
    /// <summary>
    /// The URLs to an illust's thumbnail.
    /// </summary>
    public class IllustImageUrls : ImageUrls
    {
        private string _SquareMedium;
        
        /// <summary>
        /// The square thumbnail of the illust.
        /// </summary>
        /// <remarks>
        /// The android API provides the thumbnail in the WEBP format, to provided proper compatability with all
        /// platforms the URL to changed to one provided by the public API.
        /// </remarks>
        [JsonProperty("square_medium")]
        public string SquareMedium
        {
            get => _SquareMedium;
            set
            {
                StringBuilder urlBuilder = new StringBuilder(value);
                urlBuilder.Replace("540x540_10_webp", "600x600");
                _SquareMedium = urlBuilder.ToString();
            }
        }
        
        /// <summary>
        /// The large thumbnail of an illust.
        /// </summary>
        /// <remarks>
        /// The large thumbnail is provided in the WEBP format, there is currently no way to replace the link.
        /// </remarks>
        [JsonProperty("large")]
        public string large { get; set; }
    }
}