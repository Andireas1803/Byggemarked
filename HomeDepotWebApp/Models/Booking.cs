using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HomeDepotWebApp.Models
{
    public class Booking
    {
        [Required]
        public Customer Customer { get; set; }
        [Required]
        public BookingState State { get; set; }
        [Required]
        public DateTime PickupTime { get; set; }
        [Required]
        public int Days { get; set; }

        public Booking(Customer customer, BookingState state, DateTime pickuptime, int days)
        {
            this.Customer = customer;
            this.State = state;
            this.PickupTime = pickuptime;
            this.Days = days;
        }
    }

    public enum BookingState
    {
        RESERVED, EXTRADITED, RETURNED
    }
}