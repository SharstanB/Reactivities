﻿namespace Application.DataTransferObjects.Activity
{
    public class BaseActivityDTO
    {
        public string Description { get; set; } = "";
        public DateTime Date { get; set; }
        
        public string Title { get; set; } = "";

        public string City { get; set; }

        public string Venue { get; set; } = "";

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public Guid CategoryId { get; set; }
    }
}
