using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DataTransferObjects.Activity
{
    public class CreateActivityDTO
    {
        //[Required]
        public string Description { get; set; } = "";

        public DateTime Date { get; set; }

        //[Required]
        //[StringLength(100,MinimumLength = 5)]
        public string Title { get; set; } = "";

        //[Required]
        public  Guid CityId { get; set; }

        //[Required]
        public string Venue { get; set; } = "";

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        //[Required]
        public Guid CategoryId { get; set; }
    }
}


