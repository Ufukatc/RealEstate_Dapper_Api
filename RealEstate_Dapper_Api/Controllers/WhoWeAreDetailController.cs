using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Dtos.AboutUsHomePageDtos;
using RealEstate_Dapper_Api.Repositories.AboutUsHomePageRepository;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutUsHomePageController : ControllerBase
    {
        private readonly IAboutUsHomePageRepository _AboutUsHomePageRepository;

        public AboutUsHomePageController(IAboutUsHomePageRepository AboutUsHomePageRepository)
        {
            _AboutUsHomePageRepository = AboutUsHomePageRepository;
        }

        [HttpGet]
        public async Task<IActionResult> AboutUsHomePageList()
        {
            var values = await _AboutUsHomePageRepository.GetAllAboutUsHomePage();
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAboutUsHomePage(CreateAboutUsHomePageDto createAboutUsHomePageDto)
        {
            await _AboutUsHomePageRepository.CreateAboutUsHomePage(createAboutUsHomePageDto);
            return Ok("Hakkımızda Kısmı Başarılı Bir Şekilde Eklendi");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAboutUsHomePage(int id)
        {
            await _AboutUsHomePageRepository.DeleteAboutUsHomePage(id);
            return Ok("Hakkımızda Kısmı Başarılı Bir Şekilde Silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAboutUsHomePage(UpdateAboutUsHomePageDto updateAboutUsHomePageDto)
        {
            await _AboutUsHomePageRepository.UpdateAboutUsHomePage(updateAboutUsHomePageDto);
            return Ok("Hakkımızda Kısmı Başarıyla Güncellendi");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAboutUsHomePage(int id)
        {
            var value = await _AboutUsHomePageRepository.GetAboutUsHomePage(id);
            return Ok(value);
        }
    }
}
