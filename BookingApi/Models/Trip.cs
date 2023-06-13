using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingApi.Models
{
    [Table("Trip")]
    public class Trip
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }    
        public string CityName { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; } 
        public string ImageUrl { get; set; } 
        public string Content { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreatedDate { get; set; }
        [InverseProperty(nameof(Reservation._Trip))]
        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
