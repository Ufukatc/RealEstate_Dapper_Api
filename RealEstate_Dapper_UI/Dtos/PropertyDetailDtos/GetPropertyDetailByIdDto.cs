namespace RealEstate_Dapper_UI.Dtos.PropertyDetailDtos
{
    public class GetPropertyDetailByIdDto
    {
        public int PropertyDetailID { get; set; }

        public int PropertySize { get; set; }

        public int BedRoomCount { get; set; }

        public int BathCount { get; set; }

        public int LivingRoomCount { get; set; }

        public int RoomCount { get; set; }

        public int GarageSize { get; set; }

        public string BuildYear { get; set; }

        public decimal Price { get; set; }

        public string Location { get; set; }

        public string VideoUrl { get; set; }

        public int ProductId { get; set; }

        public int BuildingFloor { get; set; }

        public int PropertyFloor { get; set; }
    }
}
