using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Repositories.OurClientsRepository;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OurClientsController : ControllerBase
    {
        private readonly IOurClientsRepository _OurClientsRepository;

        public OurClientsController(IOurClientsRepository OurClientsRepository)
        {
            _OurClientsRepository = OurClientsRepository;
        }
        [HttpGet]
        public async Task<IActionResult> OurClientsList()
        {
            var value = await _OurClientsRepository.GetAllOurClientsAsync();
            return Ok(value);
        }
    }
}
