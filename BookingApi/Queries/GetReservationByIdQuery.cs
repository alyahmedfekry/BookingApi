using MediatR;

namespace BookingApi.Queries
{
    public class GetReservationByIdQuery:IRequest<DisplayReservation>
    {
        public int Id { get; }
        public GetReservationByIdQuery(int id)
        {
            Id = id;
        }
    }
}
