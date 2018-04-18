using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AnyaTravel.DAL.Models
{
    public class Hotel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Stars { get; set; }

        public virtual City City { get; set; }
        public virtual PlacementType PlacementType { get; set; }
        public virtual List<Tour> Tours { get; set; }

    }
}
