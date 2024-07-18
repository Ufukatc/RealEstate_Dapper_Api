using Dapper;
using RealEstate_Dapper_Api.Dtos.PropertyImageDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.PropertyImageRepositories
{
    public class PropertyImageRepository : IPropertyImageRepository
    {
        private readonly Context _context;

        public PropertyImageRepository(Context context)
        {
            _context = context;
        }

        public async Task<List<GetPropertyImageByPropertyIdDto>> GetPropertyImageByPropertyId(int id)
        {
            string query = "Select * From PropertyImages Where PropertyID=@propertyID";
            var parameters = new DynamicParameters();
            parameters.Add("@propertyID", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<GetPropertyImageByPropertyIdDto>(query, parameters);
                return values.ToList();
            }
        }
    }
}
