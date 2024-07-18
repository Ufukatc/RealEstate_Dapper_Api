using RealEstate_Dapper_Api.Dtos.LocationDtos;

namespace RealEstate_Dapper_Api.Repositories.LocationRepositories
{
    public interface ILocationRepository
    {
        Task<List<ResultLocationDto>> GetAllLocation();

        Task CreateLocation(CreateLocationDto createLocationDto);
        Task DeleteLocation(int id);
        Task UpdateLocation(UpdateLocationDto updateLocationDto);
        Task<GetByIDLocationDto> GetLocation(int id);
    }
}
