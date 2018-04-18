using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AnyaTravel.DAL.Models
{
    public class Order
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public DateTime Date { get; set; }

        [Required]
        public int Price { get; set; }

        public virtual User User { get; set; }

        public virtual Tour Tour { get; set; }

        public virtual OrderStatus OrderStatus { get; set; }


    }
}
