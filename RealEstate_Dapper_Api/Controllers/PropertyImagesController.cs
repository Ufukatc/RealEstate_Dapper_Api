using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Repositories.PropertyImageRepositories;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyImagesController : ControllerBase
    {
        private readonly IPropertyImageRepository _PropertyImageRepository;

        public PropertyImagesController(IPropertyImageRepository PropertyImageRepository)
        {
            _PropertyImageRepository = PropertyImageRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetPropertyImageById(int id)
        {
            var values = await _PropertyImageRepository.GetPropertyImageByPropertyId(id);
            return Ok(values);
        }
    }
}
