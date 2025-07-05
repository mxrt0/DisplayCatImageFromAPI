using System.Text.Json.Serialization;

namespace BackendHandler.Models
{
    public class CatApiResponseItem
    {
        public string Id { get; set; } // unused
        [JsonPropertyName("url")] // force mapping to avoid mismatch of JSON and C# URL property
        public string Url { get; set; }
        public int Width { get; set; } // unused
        public int Height { get; set; } // unused

    }
}
