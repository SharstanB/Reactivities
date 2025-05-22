namespace Application.DataTransferObjects.Activity
{
    public class BaseActivityDTO
    {
        //[Required]
        public string Description { get; set; } = "";
        public DateTime Date { get; set; }
        
        //[Required]
        //[StringLength(100,MinimumLength = 5)]
        public string Title { get; set; } = "";

        //[Required]
        public Guid CityId { get; set; }

        //[Required]
        public string Venue { get; set; } = "";

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        //[Required]
        public Guid CategoryId { get; set; }
    }
}
