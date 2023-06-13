﻿
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace BookingApi.Commands.AddNewReservation
{
    public sealed class AddNewReservationCommand:IRequest
    {
        public int? ReservedBy { get; set; }
        public string CustomerName { get; set; }
        public int? TripId { get; set; }
        public DateTime? ReservationDate { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string Notes { get; set; }
    }
}
