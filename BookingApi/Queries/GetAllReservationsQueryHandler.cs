using BookingApi.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BookingApi.Queries
{
    public class GetAllReservationsQueryHandler:IRequestHandler<GetAllReservationsQuery, List<DisplayReservation>>
    {
        private readonly ApplicationDbContext _context;
        public GetAllReservationsQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<DisplayReservation>> Handle(GetAllReservationsQuery request, CancellationToken cancellationToken)
        {
            //_context.Database.EnsureCreated();
            var result = await _context.Reservations.Select(r => new DisplayReservation
            {
                CreatedDate = r.CreatedDate,
                CustomerName = r.CustomerName,
                Id = r.Id,
                ReservationDate = r.ReservationDate,
                TripImgUrl = r._Trip.ImageUrl,
                TripName = r._Trip.Name,
                UserName = r._User.Email
            }).ToListAsync();

            return result;
        }
    }
}
