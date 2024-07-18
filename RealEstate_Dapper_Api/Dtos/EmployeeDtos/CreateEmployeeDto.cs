namespace RealEstate_Dapper_Api.Dtos.EmployeeDtos
{
    public class CreateEmployeeDto
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public int RoleID { get; set; }

        public string ImageUrl { get; set; }

        public string PhoneNumber { get; set; }

        public bool Status { get; set; }
    }
}
