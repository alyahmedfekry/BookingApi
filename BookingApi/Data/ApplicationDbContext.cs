using Microsoft.EntityFrameworkCore;
using BookingApi.Models;
using BookingApi.Options;
using Microsoft.Extensions.Options;

namespace BookingApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        private readonly UserOptions _useroptions;
        public ApplicationDbContext()
        {
        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options,IOptions<UserOptions>useroptions)
            : base(options)
        {
            _useroptions = useroptions.Value;
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Trip> Trips { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(_useroptions.Accounts

                ) ;
            modelBuilder.Entity<Trip>().HasData(
                new Trip
                {
                    Id = 1,
                    CityName = "A",
                    Name = "Trip1",
                    Price = 200,
                    CreatedDate = DateTime.Now,
                    ImageUrl = "https://img.freepik.com/free-vector/road-trip-by-car-summer-vacation-travel-trip_107791-9489.jpg?w=2000",
                    Content = "<p>Time To Travel</p>"
                },
                new Trip
                {
                    Id = 2,
                    CityName = "A",
                    Name = "Trip1",
                    Price = 200,
                    CreatedDate = DateTime.Now,
                    ImageUrl = "https://img.freepik.com/free-vector/road-trip-by-car-summer-vacation-travel-trip_107791-9489.jpg?w=2000",
                    Content = "<p>Time To Travel</p>"
                });
            modelBuilder.Entity<Reservation>().HasData(
                new Reservation
                {
                    Id = 1,
                    CreatedDate = DateTime.Now,
                    CustomerName = "Aly",
                    Notes = "reservation",
                    ReservedBy = 1,
                    ReservationDate = DateTime.Now,
                    TripId = 1,
                },
                new Reservation
                {
                    Id = 2,
                    CreatedDate = DateTime.Now,
                    CustomerName = "Aly",
                    Notes = "reservation",
                    ReservedBy = 2,
                    ReservationDate = DateTime.Now,
                    TripId = 2,
                }
                );
        }
    }
}
