namespace RealEstate_Dapper_Api.Dtos.EmployeeDtos
{
    public class GetEmployeeByPropertyIdDto
    {
        public int EmployeeID { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string ImageUrl { get; set; }

        public int RoleID { get; set; }
    }
}
