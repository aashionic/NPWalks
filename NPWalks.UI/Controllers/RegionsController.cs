using Microsoft.AspNetCore.Mvc;
using NPWalks.UI.Models.DTO;

namespace NPWalks.UI.Controllers
{
    public class RegionsController : Controller
    {
        private readonly IHttpClientFactory httpClientFactory;

        public RegionsController(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<RegionDto> response = new List<RegionDto>();
            try
            {
                //Get All Regions from web API
                var client = httpClientFactory.CreateClient();
                var httpResponseMessage = await client.GetAsync(
                    "https://localhost:7000/api/regions"
                );
                httpResponseMessage.EnsureSuccessStatusCode();
                response.AddRange(
                    await httpResponseMessage.Content.ReadFromJsonAsync<IEnumerable<RegionDto>>()
                );
            }
            catch (Exception ex)
            {
                //Log the exception
            }
            return View(response);
        }
    }
}
