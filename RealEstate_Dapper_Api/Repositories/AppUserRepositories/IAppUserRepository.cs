using RealEstate_Dapper_Api.Dtos.EmployeeDtos;

namespace RealEstate_Dapper_Api.Repositories.AppUserRepositories
{
    public interface IAppUserRepository
    {
        Task<GetEmployeeByPropertyIdDto> GetEmployeeByPropertyId(int id);
    }
}
