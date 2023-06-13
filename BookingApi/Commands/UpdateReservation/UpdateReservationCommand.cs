
using MediatR;

namespace BookingApi.Commands.UpdateReservation
{
    public sealed class UpdateReservationCommand:IRequest<bool>
    {
        public int? Id { get; set; }
        public int? ReservedBy { get; set; }
        public string CustomerName { get; set; }
        public int? TripId { get; set; }
        public DateTime? ReservationDate { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string Notes { get; set; }
    }
}
