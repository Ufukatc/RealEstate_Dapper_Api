using RealEstate_Dapper_Api.Dtos.PropertyImageDtos;

namespace RealEstate_Dapper_Api.Repositories.PropertyImageRepositories
{
    public interface IPropertyImageRepository
    {
        Task<List<GetPropertyImageByPropertyIdDto>> GetPropertyImageByPropertyId(int id);
    }
}
