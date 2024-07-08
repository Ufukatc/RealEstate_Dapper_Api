using System.Reflection.Metadata.Ecma335;

namespace RealEstate_Dapper_Api.Tools
{
    public class GetCheckAppUserViewModel
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public string Role { get; set; }

        public bool IsExist { get; set; }
    }
}
