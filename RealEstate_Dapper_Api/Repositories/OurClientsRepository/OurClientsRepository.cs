using Dapper;
using RealEstate_Dapper_Api.Dtos.OurClientsDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.OurClientsRepository
{
    public class OurClientsRepository : IOurClientsRepository
    {
        private readonly Context _context;

        public OurClientsRepository(Context context)
        {
            _context = context;
        }

        public async Task<List<ResultOurClientsDto>> GetAllOurClientsAsync()
        {
            string query = "Select * From OurClientsHomePage";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultOurClientsDto>(query);
                return values.ToList();
            }
        }
    }
}
