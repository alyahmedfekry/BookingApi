using BookingApi.Commands.AddNewReservation;
using FluentValidation;

namespace BookingApi.Commands.UpdateReservation
{
    public class UpdateReservationCommandValidator : AbstractValidator<UpdateReservationCommand>
    {
        public UpdateReservationCommandValidator()
        {
            RuleFor(c => c.Id).NotNull();
            RuleFor(c => c.ReservedBy).NotNull();
            RuleFor(c => c.TripId).NotNull();
            RuleFor(c => c.CustomerName).NotEmpty();
            RuleFor(c => c.ReservationDate).NotNull();
        }
    }
}
