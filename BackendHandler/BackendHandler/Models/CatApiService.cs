using BackendHandler.Models.Interfaces;
using System.Text.Json;

namespace BackendHandler.Models
{
    public class CatApiService : IApiService
    {
        public CatApiService(string jsonResponse) 
        {
            JsonResponse = jsonResponse;
        }
        public string JsonResponse { get; private set; }
        public string GetImageURL()
        {
            var catResponse = JsonSerializer.Deserialize<CatApiResponseItem[]>(JsonResponse); // response returns array
            if (catResponse is null || catResponse.Length == 0)
            {
                throw new Exception("No cat images found in the response.");
            }

            var catImageURL = catResponse?[0]?.Url; // we only need the URL of the (only) array object
            if (string.IsNullOrEmpty(catImageURL))
            {
                throw new Exception("Cat image URL is empty.");

            }
            return catImageURL;

        }
    }
}
