using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DataTransferObjects
{
     public class GetActivitiesDTO
    {
        public required string Id { get; set; }
        public required string Description { get; set; }

        public DateTime Date { get; set; }

        public required string Title { get; set; }

        public required string CityName { get; set; }
        public required string CityId{ get; set; }

        public required string Venue { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public required string CategoryId { get; set; }

        public required string CategoryName { get; set; }

    
    }
}
