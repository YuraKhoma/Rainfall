using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Rainfall.Models;
using System.Diagnostics;

namespace Rainfall.Controllers
{
    public class RainfallController : Controller
    {
        private readonly HttpClient _httpClient;

        public RainfallController()
        {
            _httpClient = new HttpClient();
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetDataById()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> GetDataById(string id)
        {
            var apiUrl = $"http://environment.data.gov.uk/flood-monitoring//id/stations/{id}";

            HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                string data = await response.Content.ReadAsStringAsync();

                RootObject rootObject = JsonConvert.DeserializeObject<RootObject>(data);

                Measures measures = rootObject.Items.Measures;

                Items items = rootObject.Items;
                return View(items);
            }
            else 
            {
                string errorMessage = $"{(int)response.StatusCode} {response.ReasonPhrase}";
                ViewBag.ErrorMessage = errorMessage;
                return View("Error");
            }
        }
    }
}

