﻿using BookingApi.Models;
namespace BookingApi.Options
{
    public class UserOptions
    {
        public const string Users = "Users";
        public IList<User> Accounts { get; set; }
    }
}
