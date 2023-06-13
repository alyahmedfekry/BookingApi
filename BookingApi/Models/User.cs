using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingApi.Models
{
    [Table("User")]
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Email { get; set; }   
        public string Password { get; set; }
        [InverseProperty(nameof(Reservation._User))]
        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
