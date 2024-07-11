using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.SearchListDtos;
using RealEstate_Dapper_UI.Models;

namespace RealEstate_Dapper_UI.Controllers
{
    public class SearchListController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ApiSettings _apiSettings;

        public SearchListController(IHttpClientFactory httpClientFactory, ApiSettings apiSettings)
        {
            _httpClientFactory = httpClientFactory;
            _apiSettings = apiSettings;
        }

        public async Task<IActionResult> SearchWithCategory()
        {


            // Kategorileri al
            var client1 = _httpClientFactory.CreateClient();
            client1.BaseAddress = new Uri(_apiSettings.BaseUrl);
            var responseCategories = await client1.GetAsync("SearchLists/SearchWithCategories");
            var categories = new List<ResultSearchCategoryDto>();
            if (responseCategories.IsSuccessStatusCode)
            {
                var jsonData1 = await responseCategories.Content.ReadAsStringAsync();
                categories = JsonConvert.DeserializeObject<List<ResultSearchCategoryDto>>(jsonData1);
            }

            // Şehirleri al
            var client2 = _httpClientFactory.CreateClient();
            client2.BaseAddress = new Uri(_apiSettings.BaseUrl);
            var responseCities = await client2.GetAsync("SearchLists/SearchWithCities");
            var cities = new List<ResultSearchWithCitiesDto>();
            if (responseCities.IsSuccessStatusCode)
            {
                var jsonData2 = await responseCities.Content.ReadAsStringAsync();
                cities = JsonConvert.DeserializeObject<List<ResultSearchWithCitiesDto>>(jsonData2);
            }

            // En çok arananları al
            var client3 = _httpClientFactory.CreateClient();
            client3.BaseAddress = new Uri(_apiSettings.BaseUrl);
            var responseMostSearches = await client3.GetAsync("SearchLists");
            var mostSearches = new List<ResultMostSearchesDto>();
            if (responseMostSearches.IsSuccessStatusCode)
            {
                var jsonData3 = await responseMostSearches.Content.ReadAsStringAsync();
                mostSearches = JsonConvert.DeserializeObject<List<ResultMostSearchesDto>>(jsonData3);
            }

            // ViewModel oluştur
            var viewModel = new ResultSearchListViewModelDto
            {
                SearchCategories = categories,
                Cities = cities,
                MostSearches = mostSearches
            };

            return View(viewModel);
        }

    }
}
