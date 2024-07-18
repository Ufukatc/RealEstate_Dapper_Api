namespace RealEstate_Dapper_UI.Dtos.SearchListDtos
{
    public class ResultSearchListViewModelDto
    {
        public List<ResultSearchCategoryDto> SearchCategories { get; set; }
        public List<ResultSearchWithCitiesDto> Cities { get; set; }
        public List<ResultMostSearchesDto> MostSearches { get; set; }
    }

    public class ResultSearchCategoryDto
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public bool CategoryStatus { get; set; }
    }

    public class ResultSearchWithCitiesDto
    {
        public string City { get; set; }
    }

    public class ResultMostSearchesDto
    {
        public string City { get; set; }
        public bool PopularLocation { get; set; }
    }
}
