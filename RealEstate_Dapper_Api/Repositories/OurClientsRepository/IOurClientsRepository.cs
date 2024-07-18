using RealEstate_Dapper_Api.Dtos.OurClientsDtos;

namespace RealEstate_Dapper_Api.Repositories.OurClientsRepository
{
    public interface IOurClientsRepository
    {
        Task<List<ResultOurClientsDto>> GetAllOurClientsAsync();
    }
}
