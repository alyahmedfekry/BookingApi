using FluentValidation;

namespace BookingApi.Commands.AddNewReservation
{
    public class AddNewReservationCommandValidator:AbstractValidator<AddNewReservationCommand>
    {
        public AddNewReservationCommandValidator()
        {
            RuleFor(c => c.ReservedBy).NotNull();
            RuleFor(c => c.TripId).NotNull();
            RuleFor(c => c.CustomerName).NotEmpty();
            RuleFor(c => c.ReservationDate).NotNull();
        }
    }
}
