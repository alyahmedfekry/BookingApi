using BookingApi.Data;
using BookingApi.Models;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using System.Text;

namespace BookingApi.Commands.AddNewReservation
{
    public class AddNewReservationCommandHandler : IRequestHandler<AddNewReservationCommand>
    {
        private readonly ApplicationDbContext _context;
        public AddNewReservationCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task Handle(AddNewReservationCommand request,CancellationToken cancellationToken)
        {
            
            var reservation = new Reservation
            {
                CreatedDate = DateTime.Now,
                CustomerName = request.CustomerName,
                Notes = request.Notes,
                ReservationDate = request.ReservationDate.Value,
                ReservedBy = request.ReservedBy.Value,
                TripId = request.TripId.Value,
            };

            _context.Reservations.Add(reservation);
           await  _context.SaveChangesAsync();
        }

    }
}

