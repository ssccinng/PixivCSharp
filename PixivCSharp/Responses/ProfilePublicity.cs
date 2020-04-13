using Newtonsoft.Json;

namespace PixivCSharp
{
    /// <summary>
    /// Information about what details the user has made public.
    /// </summary>
    public class ProfilePublicity
    {
        /// <summary>
        /// Information about if the user's gender is public.
        /// </summary>
        [JsonProperty("gender")]
        public string Gender { get; set; }
        
        /// <summary>
        /// Information about if the user's region is public.
        /// </summary>
        [JsonProperty("region")]
        public string Region { get; set; }
        
        /// <summary>
        /// Information about if the user's birthday is public.
        /// </summary>
        [JsonProperty("birth_day")]
        public string BirthDay { get; set; }
        
        /// <summary>
        /// Information about if the user's birth year is public.
        /// </summary>
        [JsonProperty("birth_year")]
        public string BirthYear { get; set; }
        
        /// <summary>
        /// Information about if the user's job is public.
        /// </summary>
        [JsonProperty("job")]
        public string Job { get; set; }
        
        /// <summary>
        /// Information about if the user's pawoo account is public.
        /// </summary>
        [JsonProperty("pawoo")]
        public string Pawoo { get; set; }
    }
}