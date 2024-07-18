using RealEstate_Dapper_Api.Dtos.PropertyDetailDtos;
using RealEstate_Dapper_Api.Dtos.PropertyDtos;

namespace RealEstate_Dapper_Api.Repositories.PropertyRepositories
{
    public interface IPropertyRepository
    {
        Task<List<ResultPropertyDto>> GetAllPropertyAsync();

        Task<List<ResultPropertyAdvertListWithCategoryByEmployeeDto>> GetPropertyAdvertListByEmployeeAsyncByTrue(int id);
        
        Task<List<ResultPropertyAdvertListWithCategoryByEmployeeDto>> GetPropertyAdvertListByEmployeeAsyncByFalse(int id);

        Task<List<ResultPropertyWithCategoryDto>> GetAllPropertyWithCategoryAsync();

        Task PropertyOpportunityOfTheDayStatusChangeToTrue(int id);

        Task PropertyOpportunityOfTheDayStatusChangeToFalse(int id);

        Task<List<ResultLast5PropertyWithCategoryDto>> GetLast5PropertyAsync();

        Task<List<ResultLast3PropertyWithCategoryDto>> GetLast3PropertyAsync();

        Task CreateProperty(CreatePropertyDto createPropertyDto);

        Task<GetPropertyByPropertyIdDto> GetPropertyByPropertyId(int id);

        Task<GetPropertyDetailByIdDto> GetPropertyDetailByPropertyId(int id);

        Task<List<ResultPropertyWithSearchListDto>> ResultPropertyWithSearchList(string searchKeyValue, int propertyCategoryId, string city);

        Task<List<ResultPropertyWithCategoryDto>> GetPropertyByOpportunityOfTheDayTrueWithCategoryAsync();


    }
}
