using BackendHandler.Models;
using Microsoft.AspNetCore.Mvc;

namespace BackendHandler.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CatController : ControllerBase
    {
        private readonly HttpClient _httpClient;
        private Uri apiURL = new Uri("https://api.thecatapi.com/v1/images/search");

        public CatController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
        }

        [HttpGet("image")]

        public async Task<IActionResult> GetCatImage()
        {
            var requestResult = await _httpClient.GetAsync(apiURL);

            if (!requestResult.IsSuccessStatusCode)
            {
                return StatusCode((int)requestResult.StatusCode, "Failed to get cat image.");
            }
            var responseStringJSON = await requestResult.Content.ReadAsStringAsync();

            var catApiService = new CatApiService(responseStringJSON);
            var catImageURL = catApiService.GetImageURL();

            return Ok(new { imageUrl = catImageURL });
        }
        
    }
}
