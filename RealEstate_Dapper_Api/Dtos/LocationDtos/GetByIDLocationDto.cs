namespace RealEstate_Dapper_Api.Dtos.LocationDtos
{
    public class GetByIDLocationDto
    {
        public int LocationID { get; set; }
        public string City { get; set; }
        public string ImageUrl { get; set; }
        public int PropertyCount { get; set; }
        public bool PopularLocation { get; set; }
    }
}
