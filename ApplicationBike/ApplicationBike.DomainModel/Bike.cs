using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationBike.DomainModel
{
    public class Bike
    {
        [Key]
        public int BikeId { get; set; }

        [Required]
        [Display(Name="Register Number")]
        public string RegNumber { get; set; }

        public string Producer { get; set; }

        public string Model { get; set; }

        public string Colour { get; set; }
    }
}
