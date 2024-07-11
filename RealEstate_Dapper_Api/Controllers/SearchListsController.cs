using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Repositories.SearchListRepositories;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchListsController : ControllerBase
    {
        private readonly ISearchListRepository _searchListRepository;

        public SearchListsController(ISearchListRepository searchListRepository)
        {
            _searchListRepository = searchListRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Most3SearchList()
        {
            var values = await _searchListRepository.Get3MostSearches();
            return Ok(values);
        }

        [HttpGet("SearchWithCities")]
        public async Task<IActionResult> SearchWithCities()
        {
            var values = await _searchListRepository.GetSearchWithCities();
            return Ok(values);
        }

        [HttpGet("SearchWithCategories")]
        public async Task<IActionResult> SearchWithCategories()
        {
            var values = await _searchListRepository.GetSearchWithCategories();
            return Ok(values);
        }
    }
}
