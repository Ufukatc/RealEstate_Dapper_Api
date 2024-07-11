using RealEstate_Dapper_Api.Dtos.SearchListDtos;

namespace RealEstate_Dapper_Api.Repositories.SearchListRepositories
{
    public interface ISearchListRepository
    {
        Task<List<ResultMostSearchesDto>> Get3MostSearches();
        Task<List<ResultSearchWithCitiesDto>> GetSearchWithCities();
        Task<List<ResultSearchCategoryDto>> GetSearchWithCategories();
    }
}
