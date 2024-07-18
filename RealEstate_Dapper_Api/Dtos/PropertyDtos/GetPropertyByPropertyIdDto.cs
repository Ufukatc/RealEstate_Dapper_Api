﻿namespace RealEstate_Dapper_Api.Dtos.PropertyDtos
{
    public class GetPropertyByPropertyIdDto
    {
        public int PropertyID { get; set; }

        public string Title { get; set; }

        public decimal Price { get; set; }

        public string CoverImage { get; set; }

        public string City { get; set; }

        public string District { get; set; }

        public string Address { get; set; }

        public string Description { get; set; }

        public int PropertyCategory { get; set; }

        public string CategoryName { get; set; }

        public int AdvisorID { get; set; }

        public string Type { get; set; }

        public bool OpportunityOfTheDay { get; set; }

        public bool PropertyStatus { get; set; }

        public string SlugUrl { get; set; }

        public DateTime AdvertisementDate { get; set; }
    }
}