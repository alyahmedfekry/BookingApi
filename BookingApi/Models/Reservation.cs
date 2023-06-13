using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingApi.Models
{
    [Table("Reservation")]
    public class Reservation
    {
        [Key]
        public int Id { get; set; } 
        public int ReservedBy { get; set; }
        public string CustomerName { get; set; }
        public int TripId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime ReservationDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreatedDate { get; set; }
        public string Notes { get; set; }
        public bool? IsDeleted { get; set; }
        [ForeignKey(nameof(TripId))]
        [InverseProperty(nameof(Trip.Reservations))]
        public virtual Trip _Trip { get; set; }
        [ForeignKey(nameof(ReservedBy))]
        [InverseProperty(nameof(User.Reservations))]
        public virtual User _User { get; set; }
    }
}
