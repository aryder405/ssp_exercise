using Newtonsoft.Json;
using System.Collections.Generic;

namespace Exercise.Models
{
    public class SampleModel
    {
        public string Title { get; set; }

        public string Instructions { get; set; }

        public string Description { get; set; }

        public IEnumerable<FeatureData> FeatureData { get; set; }

    }

    public class FeatureData
    {
        [JsonProperty("geometry")]
        public Geometry Geometry { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("id")]
        public string ID { get; set; }

        [JsonProperty("properties")]
        public FeatureDataProperties Properties { get; set; }
    }

    public class Geometry
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("coordinates")]
        public IEnumerable<float> Coordinates { get; set; }
    }

    public class FeatureDataProperties
    {
        [JsonProperty("wikipedia")]
        public string Wikipedia { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }
    }
}
