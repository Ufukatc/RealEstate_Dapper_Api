namespace RealEstate_Dapper_Api.Dtos.OurClientsDtos
{
    public class ResultOurClientsDto
    {
        public int OurClientsID { get; set; }

        public string NameSurname { get; set; }

        public string Title { get; set; }

        public string Comment { get; set; }

        public bool Status { get; set; }
    }
}
