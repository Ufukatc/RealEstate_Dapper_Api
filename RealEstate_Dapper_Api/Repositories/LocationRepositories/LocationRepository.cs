using Dapper;
using RealEstate_Dapper_Api.Dtos.LocationDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.LocationRepositories
{
    public class LocationRepository : ILocationRepository
    {
        private readonly Context _context;

        public LocationRepository(Context context) 
        {
            _context = context;
        }

        public async Task CreateLocation(CreateLocationDto createLocationDto)
        {
            string query = "insert into Locations (City, ImageUrl) values (@city,@imageUrl)";
            var parameters = new DynamicParameters();
            parameters.Add("@city", createLocationDto.City);
            parameters.Add("@imageUrl", createLocationDto.ImageUrl);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task DeleteLocation(int id)
        {
            string query = "Delete From Locations Where LocationID=@locationID";
            var parameters = new DynamicParameters();
            parameters.Add("@locationID", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultLocationDto>> GetAllLocation()
        {
            string query = "Select Top(4)* From Locations Order by PropertyCount Desc";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultLocationDto>(query);
                return values.ToList();
            }
        }

        public async Task<GetByIDLocationDto> GetLocation(int id)
        {
            string query = "Select * From Locations Where LocationID=@locationID";
            var parameters = new DynamicParameters();
            parameters.Add("@locationID", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetByIDLocationDto>(query, parameters);
                return values;
            }
        }

        public async Task UpdateLocation(UpdateLocationDto updateLocationDto)
        {
            string query = "Update Locations Set City=@city, ImageUrl=@imageUrl Where LocationID=@locationID";
            var parameters = new DynamicParameters();
            parameters.Add("@city", updateLocationDto.City);
            parameters.Add("@imageUrl", updateLocationDto.ImageUrl);
            parameters.Add("@locationID", updateLocationDto.LocationID);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
