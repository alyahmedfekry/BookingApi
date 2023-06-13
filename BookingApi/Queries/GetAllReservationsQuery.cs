using BookingApi.Data;
using BookingApi.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BookingApi.Queries
{
    public class GetAllReservationsQuery : IRequest<List<DisplayReservation>>
    {
    }
}
