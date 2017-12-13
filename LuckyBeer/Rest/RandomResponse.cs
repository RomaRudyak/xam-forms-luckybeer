namespace LuckyBeer
{
    using Newtonsoft.Json;
    public class RandomResponse
    {
        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("data")]
        public Beer Data { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }
    }
}