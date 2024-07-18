using Dapper;
using RealEstate_Dapper_Api.Dtos.PropertyDetailDtos;
using RealEstate_Dapper_Api.Dtos.PropertyDtos;
using RealEstate_Dapper_Api.Models.DapperContext;
using System.Text;

namespace RealEstate_Dapper_Api.Repositories.PropertyRepositories
{
    public class PropertyRepository : IPropertyRepository
    {
        private readonly Context _context;

        public PropertyRepository(Context context)
        {
            _context = context;
        }

        public async Task CreateProperty(CreatePropertyDto createPropertyDto)
        {
            string query = "insert into Properties (Title,Price,CoverImage,City,District,Address,Description,PropertyCategory,AdvisorID,Type,OpportunityOfTheDay,PropertyStatus,AdvertisementDate) values " +
                "(@title,@price,@coverImage,@city,@district,@address,@description,@propertyCategory,@advisorID,@type,@opportunityOfTheDay,@propertyStatus,@advertisementDate)";
            var parameters = new DynamicParameters();
            parameters.Add("@title", createPropertyDto.Title);
            parameters.Add("@price", createPropertyDto.Price);
            parameters.Add("@coverImage", createPropertyDto.CoverImage);
            parameters.Add("@city", createPropertyDto.City);
            parameters.Add("@district", createPropertyDto.District);
            parameters.Add("@address", createPropertyDto.Address);
            parameters.Add("@description", createPropertyDto.Description);
            parameters.Add("@propertyCategory", createPropertyDto.PropertyCategory);
            parameters.Add("@advisorID", createPropertyDto.AdvisorID);
            parameters.Add("@type", createPropertyDto.Type);
            parameters.Add("@opportunityOfTheDay", createPropertyDto.OpportunityOfTheDay);
            parameters.Add("@propertyStatus", createPropertyDto.PropertyStatus);
            parameters.Add("@advertisementDate", createPropertyDto.AdvertisementDate);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultPropertyDto>> GetAllPropertyAsync()
        {
            string query = "Select * From Properties";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultPropertyDto>(query);
                return values.ToList();
            }
        }

        public async Task<List<ResultPropertyWithCategoryDto>> GetAllPropertyWithCategoryAsync()
        {
            string query = "Select PropertyID,Title,Price,City,District,CategoryName,CoverImage,Type,Address,OpportunityOfTheDay,SlugUrl From Properties inner join Categories on Properties.PropertyCategory = Categories.CategoryID";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultPropertyWithCategoryDto>(query);
                return values.ToList();
            }
        }

        public async Task<List<ResultLast3PropertyWithCategoryDto>> GetLast3PropertyAsync()
        {
            string query = "Select Top(3) PropertyID,Title,Price,City,District,CoverImage,PropertyCategory,CategoryName,AdvertisementDate From Properties Inner Join Categories On Properties.PropertyCategory=Categories.CategoryID Order By PropertyID Desc";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultLast3PropertyWithCategoryDto>(query);
                return values.ToList();
            }
        }

        public async Task<List<ResultLast5PropertyWithCategoryDto>> GetLast5PropertyAsync()
        {
            string query = "Select Top(5) PropertyID,Title,Price,City,District,CoverImage,PropertyCategory,CategoryName,AdvertisementDate From Properties Inner Join Categories On Properties.PropertyCategory=Categories.CategoryID Where Type='Kiralık' Order By PropertyID Desc";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultLast5PropertyWithCategoryDto>(query);
                return values.ToList();
            }
        }

        public async Task<List<ResultPropertyAdvertListWithCategoryByEmployeeDto>> GetPropertyAdvertListByEmployeeAsyncByFalse(int id)
        {
            string query = "Select PropertyID,Title,Price,CoverImage,City,District,Address,CategoryName,Type,OpportunityOfTheDay From Properties inner join Categories on Properties.PropertyCategory = Categories.CategoryID Where AdvisorID=@advisorID and PropertyStatus = 0";
            var parameters = new DynamicParameters();
            parameters.Add("@advisorID", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultPropertyAdvertListWithCategoryByEmployeeDto>(query, parameters);
                return values.ToList();
            }
        }

        public async Task<List<ResultPropertyAdvertListWithCategoryByEmployeeDto>> GetPropertyAdvertListByEmployeeAsyncByTrue(int id)
        {
            string query = "Select PropertyID,Title,Price,CoverImage,City,District,Address,CategoryName,Type,OpportunityOfTheDay From Properties inner join Categories on Properties.PropertyCategory = Categories.CategoryID Where AdvisorID=@advisorID and PropertyStatus = 1";
            var parameters = new DynamicParameters();
            parameters.Add("@advisorID", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultPropertyAdvertListWithCategoryByEmployeeDto>(query, parameters);
                return values.ToList();
            }
        }

        public async Task<List<ResultPropertyWithCategoryDto>> GetPropertyByOpportunityOfTheDayTrueWithCategoryAsync()
        {
            string query = "Select PropertyID,Title,Price,CoverImage,City,District,Address,CategoryName,Type,OpportunityOfTheDay From Properties inner join Categories on Properties.PropertyCategory = Categories.CategoryID Where OpportunityOfTheDay = 1";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultPropertyWithCategoryDto>(query);
                return values.ToList();
            }
        }

        public async Task<GetPropertyByPropertyIdDto> GetPropertyByPropertyId(int id)
        {
            string query = "Select PropertyID,Title,Price,CoverImage,City,District,Address,Description,CategoryName,Type,OpportunityOfTheDay,AdvertisementDate,SlugUrl From Properties inner join Categories on Properties.PropertyCategory = Categories.CategoryID where PropertyID=@propertyID";
            var parameters = new DynamicParameters();
            parameters.Add("@propertyID", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<GetPropertyByPropertyIdDto>(query,parameters);
                return values.FirstOrDefault();
            }
        }

        public async Task<GetPropertyDetailByIdDto> GetPropertyDetailByPropertyId(int id)
        {
            string query = "Select * From PropertyDetail where PropertyID=@propertyID";
            var parameters = new DynamicParameters();
            parameters.Add("@propertyID", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<GetPropertyDetailByIdDto>(query, parameters);
                return values.FirstOrDefault();
            }
        }

        public async Task PropertyOpportunityOfTheDayStatusChangeToFalse(int id)
        {
            string query = "Update Properties set OpportunityOfTheDay=0 Where PropertyID=@propertyID";
            var parameters = new DynamicParameters();
            parameters.Add("@propertyID", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task PropertyOpportunityOfTheDayStatusChangeToTrue(int id)
        {
            string query = "Update Properties set OpportunityOfTheDay=1 Where PropertyID=@propertyID";
            var parameters = new DynamicParameters();
            parameters.Add("@propertyID", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultPropertyWithSearchListDto>> ResultPropertyWithSearchList(string searchKeyValue, int propertyCategoryId, string city)
        {
            var queryBuilder = new StringBuilder("Select * From Properties Where 1=1");
            var parameters = new DynamicParameters();

            if (!string.IsNullOrEmpty(searchKeyValue))
            {
                queryBuilder.Append(" and Title like @searchKeyValue");
                parameters.Add("@searchKeyValue", "%" + searchKeyValue + "%");
            }

            if (propertyCategoryId > 0)
            {
                queryBuilder.Append(" and PropertyCategory=@propertyCategoryId");
                parameters.Add("@propertyCategoryId", propertyCategoryId);
            }

            if (!string.IsNullOrEmpty(city))
            {
                queryBuilder.Append(" and City=@city");
                parameters.Add("@city", city);
            }

            string query = queryBuilder.ToString();

            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultPropertyWithSearchListDto>(query, parameters);
                return values.ToList();
            } 
        }
    }
}

