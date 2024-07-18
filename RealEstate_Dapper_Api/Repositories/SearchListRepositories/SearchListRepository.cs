using RealEstate_Dapper_Api.Dtos.SearchListDtos;
using RealEstate_Dapper_Api.Models.DapperContext;
using Dapper;

namespace RealEstate_Dapper_Api.Repositories.SearchListRepositories
{
    public class SearchListRepository : ISearchListRepository
    {
        private readonly Context _context;

        public SearchListRepository(Context context)
        {
            _context = context;
        }

        public async Task<List<ResultMostSearchesDto>> Get3MostSearches()
        {
            string query = "Select Top(3) City From Locations Order by PropertyCount desc";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultMostSearchesDto>(query);
                return values.ToList();
            }
        }

        public async Task<List<ResultSearchWithCitiesDto>> GetSearchWithCities()
        {
            string query = "SELECT DISTINCT City FROM Locations;";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultSearchWithCitiesDto>(query);
                return values.ToList();
            }
        }

        public async Task<List<ResultSearchCategoryDto>> GetSearchWithCategories()
        {
            string query = "Select * From Categories Where CategoryStatus = 1 Order by CategoryName asc";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultSearchCategoryDto>(query);
                return values.ToList();
            }
        }
    }
}
