using BookingApi.Commands.AddNewReservation;
using BookingApi.Data;
using BookingApi.Models;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using System.Text;

namespace BookingApi.Commands.UpdateReservation
{
    public class UpdateReservationCommandHandler : IRequestHandler<UpdateReservationCommand,bool>
    {
        private readonly ApplicationDbContext _context;
        public UpdateReservationCommandHandler(ApplicationDbContext context) 
        {
            _context = context;
        }
        public async Task<bool> Handle(UpdateReservationCommand request,CancellationToken cancellationToken)
        {
            var validator = new UpdateReservationCommandValidator();
            ValidationResult results = validator.Validate(request);
            bool validationSucceeded = results.IsValid;
            if (!validationSucceeded)
            {
                var failures = results.Errors.ToList();
                var message = new StringBuilder();
                failures.ForEach(f => { message.Append(f.ErrorMessage + Environment.NewLine); });
                throw new ValidationException(message.ToString());
            }
            var reservation = _context.Reservations.Find(request.Id);
            if (reservation == null) 
            {
                return false;
            }
            reservation.ReservationDate = request.ReservationDate.Value;
            reservation.Notes = request.Notes;
            reservation.CustomerName = request.CustomerName;
            reservation.ReservedBy = request.ReservedBy.Value;
            reservation.TripId = request.TripId.Value;
           await  _context.SaveChangesAsync();

            return true;
        }
    }
}
