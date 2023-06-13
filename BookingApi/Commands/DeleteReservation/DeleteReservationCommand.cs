using MediatR;

namespace BookingApi.Commands.DeleteReservation
{
    public class DeleteReservationCommand : IRequest<bool>
    {
        public int Id { get; }
        public DeleteReservationCommand(int id)
        {
            Id = id;
        }
    }
}
