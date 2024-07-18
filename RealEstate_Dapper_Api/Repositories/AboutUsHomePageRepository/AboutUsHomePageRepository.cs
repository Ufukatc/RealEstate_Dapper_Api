using Dapper;
using RealEstate_Dapper_Api.Dtos.AboutUsHomePageDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.AboutUsHomePageRepository
{
    public class AboutUsHomePageRepository : IAboutUsHomePageRepository
    {
        private readonly Context _context;

        public AboutUsHomePageRepository(Context context)
        {
            _context = context;
        }
        
        public async Task CreateAboutUsHomePage(CreateAboutUsHomePageDto createAboutUsHomePageDto)
        {
            string query = "insert into AboutUsHomePage (TopTitle, Title, Description1, Description2) values (@topTitle,@title,@description1,@description2 )";
            var parameters = new DynamicParameters();
            parameters.Add("@topTitle", createAboutUsHomePageDto.TopTitle);
            parameters.Add("@title", createAboutUsHomePageDto.Title);
            parameters.Add("@description1", createAboutUsHomePageDto.Description1);
            parameters.Add("@description2", createAboutUsHomePageDto.Description2);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task DeleteAboutUsHomePage(int id)
        {
            string query = "Delete From AboutUsHomePage Where AboutUsID=@aboutUsID";
            var parameters = new DynamicParameters();
            parameters.Add("@aboutUsID", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultAboutUsHomePageDto>> GetAllAboutUsHomePage()
        {
            string query = "Select * From AboutUsHomePage";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultAboutUsHomePageDto>(query);
                return values.ToList();
            }
        }

        public async Task<GetByIDAboutUsHomePageDto> GetAboutUsHomePage(int id)
        {
            string query = "Select * From AboutUsHomePage Where AboutUsID=@aboutUsID";
            var parameters = new DynamicParameters();
            parameters.Add("@aboutUsID", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetByIDAboutUsHomePageDto>(query, parameters);
                return values;
            }
        }

        public async Task UpdateAboutUsHomePage(UpdateAboutUsHomePageDto updateAboutUsHomePageDto)
        {
            string query = "Update AboutUsHomePage Set TopTitle=@topTitle, Title=@title, Description1=@description1, Description2=@description2 Where AboutUsID=@aboutUsID";
            var parameters = new DynamicParameters();
            parameters.Add("@topTitle", updateAboutUsHomePageDto.TopTitle);
            parameters.Add("@title", updateAboutUsHomePageDto.Title);
            parameters.Add("@description1", updateAboutUsHomePageDto.Description1);
            parameters.Add("@description2", updateAboutUsHomePageDto.Description2);
            parameters.Add("@aboutUsID", updateAboutUsHomePageDto.AboutUsID);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
