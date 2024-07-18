using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.PropertyDetailDtos;
using RealEstate_Dapper_UI.Dtos.PropertyDtos;
using RealEstate_Dapper_UI.Models;

namespace RealEstate_Dapper_UI.Controllers
{
    public class PropertyController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ApiSettings _apiSettings;

        public PropertyController(IHttpClientFactory httpClientFactory, IOptions<ApiSettings> apiSettings)
        {
            _httpClientFactory = httpClientFactory;
            _apiSettings = apiSettings.Value;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_apiSettings.BaseUrl);
            var responseMessage = await client.GetAsync("Propertys/PropertyListWithCategory");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultPropertyDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        public async Task<IActionResult> PropertyListWithSearch(string searchKeyValue, int propertyCategoryId, string city)
        {
            searchKeyValue = TempData["searchKeyValue"].ToString();
            propertyCategoryId = int.Parse(TempData["propertyCategoryId"].ToString());
            city = TempData["city"].ToString();
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_apiSettings.BaseUrl);
            var responseMessage = await client.GetAsync($"Propertys/ResultPropertyWithSearchList?searchKeyValue={searchKeyValue}&propertyCategoryId={propertyCategoryId}&city={city}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultPropertyWithSearchListDto>>(jsonData);
                return View(values);
            }
            return View();
        }


        [HttpGet("property/{slug}/{id}")]
        public async Task<IActionResult> PropertySingle(string slug, int id)
        {
            ViewBag.i = id;
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_apiSettings.BaseUrl);
            var responseMessage = await client.GetAsync("Propertys/GetPropertyByPropertyId?id=" + id);
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<ResultPropertyDto>(jsonData);

            var client2 = _httpClientFactory.CreateClient();
            client2.BaseAddress = new Uri(_apiSettings.BaseUrl);
            var responseMessage2 = await client2.GetAsync("PropertyDetails/GetPropertyDetailByPropertyId?id=" + id);
            var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
            var values2 = JsonConvert.DeserializeObject<GetPropertyDetailByIdDto>(jsonData2);

            ViewBag.PropertyId = values.PropertyID;
            ViewBag.title1 = values.Title;
            ViewBag.price = values.Price;
            ViewBag.city = values.City;
            ViewBag.district = values.District;
            ViewBag.address = values.Address;
            ViewBag.type = values.Type;
            ViewBag.description = values.Description;
            ViewBag.date = values.AdvertisementDate;
            //ViewBag.slugUrl = values.SlugUrl;

            ViewBag.PropertySize = values2.PropertySize;
            ViewBag.bedRoomCount = values2.BedRoomCount;
            ViewBag.bathCount = values2.BathCount;
            ViewBag.livingRoomCount = values2.LivingRoomCount;
            ViewBag.roomCount = values2.RoomCount;
            ViewBag.garageSize = values2.GarageSize;
            ViewBag.buildYear = values2.BuildYear;
            ViewBag.location = values2.Location;
            ViewBag.videoUrl = values2.VideoUrl;
            ViewBag.buildingFloor = values2.BuildingFloor;
            ViewBag.propertyFloor = values2.PropertyFloor;

            DateTime date1 = DateTime.Now;
            DateTime date2 = values.AdvertisementDate;
            TimeSpan timeSpan = date1 - date2;
            int days = timeSpan.Days;

            ViewBag.datediff = days / 30;

            string slugFormTitle = CreateSlug(values.Title);
            ViewBag.slugUrl = slugFormTitle;

            return View();
        }
        private string CreateSlug(string title)
        {
            title = title.ToLowerInvariant();
            title = title.Replace(" ", "_");
            title = System.Text.RegularExpressions.Regex.Replace(title, @"[^a-z0-9\s-]", "");
            title = System.Text.RegularExpressions.Regex.Replace(title, @"\s+", " ").Trim();
            title = System.Text.RegularExpressions.Regex.Replace(title, @"\s", "-");
            return title;
        }
    }
}
