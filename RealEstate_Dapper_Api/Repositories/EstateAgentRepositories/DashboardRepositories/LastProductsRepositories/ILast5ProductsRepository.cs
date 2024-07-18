using RealEstate_Dapper_Api.Dtos.PropertyDtos;

namespace RealEstate_Dapper_Api.Repositories.EstateAgentRepositories.DashboardRepositories.LastProductsRepositories
{
    public interface ILast5ProductsRepository
    {
        Task<List<ResultLast5PropertyWithCategoryDto>> GetLast5ProductAsync(int id);
    }
}
