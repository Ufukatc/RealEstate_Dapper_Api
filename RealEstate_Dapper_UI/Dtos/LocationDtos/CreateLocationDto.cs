namespace RealEstate_Dapper_UI.Dtos.LocationDtos
{
    public class CreateLocationDto
    {
        public string City { get; set; }
        public string ImageUrl { get; set; }
        public int PropertyCount { get; set; }
        public bool PopularLocation { get; set; }
    }
}