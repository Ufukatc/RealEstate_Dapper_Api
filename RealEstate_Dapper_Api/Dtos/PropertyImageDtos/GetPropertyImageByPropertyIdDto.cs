namespace RealEstate_Dapper_Api.Dtos.PropertyImageDtos
{
    public class GetPropertyImageByPropertyIdDto
    {
        public int PropertyImageID { get; set; }

        public string ImageUrl { get; set; }

        public int PropertyID { get; set; }
    }
}
