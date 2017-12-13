namespace LuckyBeer
{
    using Newtonsoft.Json;
    public class Category
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("createDate")]
        public string CreateDate { get; set; }
    }
}