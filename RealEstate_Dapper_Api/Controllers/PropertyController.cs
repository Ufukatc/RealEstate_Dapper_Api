using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Dtos.PropertyDtos;
using RealEstate_Dapper_Api.Repositories.PropertyRepositories;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyController : ControllerBase
    {
        private readonly IPropertyRepository _PropertyRepository;


        public PropertyController(IPropertyRepository PropertyRepository)
        {
            _PropertyRepository = PropertyRepository;
        }

        [HttpGet]
        public async Task<IActionResult> PropertyList()
        {
            var values = await _PropertyRepository.GetAllPropertyAsync();
            return Ok(values);
        }

        [HttpGet("PropertyListWithCategory")]
        public async Task<IActionResult> PropertyListWithCategory()
        {
            var values = await _PropertyRepository.GetAllPropertyWithCategoryAsync();
            return Ok(values);
        }

        [HttpGet("PropertyOpportunityOfTheDayStatusChangeToTrue/{id}")]
        public async Task<IActionResult> PropertyOpportunityOfTheDayStatusChangeToTrue(int id)
        {
            await _PropertyRepository.PropertyOpportunityOfTheDayStatusChangeToTrue(id);
            return Ok("İlan Günün Fırsatlarına Eklendi");
        }

        [HttpGet("PropertyOpportunityOfTheDayStatusChangeToFalse/{id}")]
        public async Task<IActionResult> PropertyOpportunityOfTheDayStatusChangeToFalse(int id)
        {
            await _PropertyRepository.PropertyOpportunityOfTheDayStatusChangeToFalse(id);
            return Ok("İlan Günün Fırsatlarından Çıkarıldı");
        }

        [HttpGet("Last5PropertyList")]
        public async Task<IActionResult> Last5PropertyList()
        {
            var values = await _PropertyRepository.GetLast5PropertyAsync();
            return Ok(values);
        }

        [HttpGet("GetPropertyAdvertListByEmployeeAsyncByTrue")]
        public async Task<IActionResult> GetPropertyAdvertListByEmployeeAsyncByTrue(int id)
        {
            var values = await _PropertyRepository.GetPropertyAdvertListByEmployeeAsyncByTrue(id);
            return Ok(values);
        }

        [HttpGet("GetPropertyAdvertListByEmployeeAsyncByFalse")]
        public async Task<IActionResult> GetPropertyAdvertListByEmployeeAsyncByFalse(int id)
        {
            var values = await _PropertyRepository.GetPropertyAdvertListByEmployeeAsyncByFalse(id);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProperty(CreatePropertyDto createPropertyDto)
        {
            await _PropertyRepository.CreateProperty(createPropertyDto);
            return Ok("İlan Başarıyla Eklendi.");
        }

        [HttpGet("GetPropertyByPropertyId")]
        public async Task<IActionResult> GetPropertyByPropertyId(int id)
        {
            var values = await _PropertyRepository.GetPropertyByPropertyId(id);
            return Ok(values);
        }

        [HttpGet("ResultPropertyWithSearchList")]
        public async Task<IActionResult> ResultPropertyWithSearchList(string searchKeyValue, int propertyCategoryId, string city)
        {
            var values = await _PropertyRepository.ResultPropertyWithSearchList(searchKeyValue, propertyCategoryId, city);
            return Ok(values);
        }

        [HttpGet("PropertyByOpportunityOfTheDayTrueWithCategoryList")]
        public async Task<IActionResult> PropertyByOpportunityOfTheDayTrueWithCategoryList()
        {
            var values = await _PropertyRepository.GetPropertyByOpportunityOfTheDayTrueWithCategoryAsync();
            return Ok(values);
        }

        [HttpGet("Last3PropertyList")]
        public async Task<IActionResult> Last3PropertyList()
        {
            var values = await _PropertyRepository.GetLast3PropertyAsync();
            return Ok(values);
        }
    }
}

