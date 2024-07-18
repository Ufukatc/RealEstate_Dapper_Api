using RealEstate_Dapper_Api.Dtos.AboutUsHomePageDtos;

namespace RealEstate_Dapper_Api.Repositories.AboutUsHomePageRepository
{
    public interface IAboutUsHomePageRepository
    {
        Task<List<ResultAboutUsHomePageDto>> GetAllAboutUsHomePage();

        Task CreateAboutUsHomePage(CreateAboutUsHomePageDto createAboutUsHomePageDto);
        Task DeleteAboutUsHomePage(int id);
        Task UpdateAboutUsHomePage(UpdateAboutUsHomePageDto updateAboutUsHomePageDto);
        Task<GetByIDAboutUsHomePageDto> GetAboutUsHomePage(int id);
    }
}
