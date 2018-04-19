using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AnyaTravel.DAL.Models
{
    public class Tour
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public int Price { get; set; }

        [Required]
        public int CountOfTours { get; set; }
        [Required]
        public DateTime DateFrom { get; set; }

        [Required]
        public DateTime DateTo { get; set; }

        public virtual TourType TourType { get; set; }
        public virtual FoodType FoodType { get; set; }
        public virtual Hotel Hotel { get; set; }
        public virtual TransportType TransportType { get; set; }
        public virtual CityFrom CityFrom { get; set; }
        public virtual List<Order> Orders { get; set; }
    }
}
