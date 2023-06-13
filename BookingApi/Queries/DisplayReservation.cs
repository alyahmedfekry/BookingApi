using MediatR;

namespace BookingApi.Queries
{
    public sealed class DisplayReservation:IRequest
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public DateTime ReservationDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public string TripName { get; set; }
        public string TripImgUrl { get; set; }
        public string CustomerName { get; set; }
    }
}
