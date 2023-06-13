using BookingApi.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BookingApi.Queries
{
    public class GetReservationByIdQueryHandler : IRequestHandler<GetReservationByIdQuery, DisplayReservation>
    {
        private readonly ApplicationDbContext _context;

        public GetReservationByIdQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<DisplayReservation> Handle(GetReservationByIdQuery request, CancellationToken cancellationToken)
        {
            return await _context.Reservations.Where(r => r.Id == request.Id)
                .Select(r => new DisplayReservation
                {
                    Id = r.Id,
                    CreatedDate = r.CreatedDate,
                    CustomerName = r.CustomerName,
                    ReservationDate = r.ReservationDate,
                    TripImgUrl = r._Trip.ImageUrl,
                    TripName = r._Trip.Name,
                    UserName = r._User.Email
                }).FirstOrDefaultAsync();
        }
    }
}
