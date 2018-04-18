using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AnyaTravel.DAL.Models
{
    public class CityFrom
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string City { get; set; }

        public virtual List<Tour> Tours { get; set; }
    }
}
