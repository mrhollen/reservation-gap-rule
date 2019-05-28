using Newtonsoft.Json;

namespace CodingChallenge.Models {
    public class Campsite {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}