using BookingApi.Commands.UpdateReservation;
using BookingApi.Data;
using MediatR;

namespace BookingApi.Commands.DeleteReservation
{
    public class DeleteReservationCommandHandler : IRequestHandler<DeleteReservationCommand, bool>
    {
        private readonly ApplicationDbContext _context;
        public DeleteReservationCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> Handle(DeleteReservationCommand request, CancellationToken cancellationToken)
        {
            var reservation = _context.Reservations.Find(request.Id);
            if (reservation == null)
            {
                return false;
            }
            reservation.IsDeleted= true;
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
