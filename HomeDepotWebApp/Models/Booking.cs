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
        public int Id { get; set; }
        [Required]
        public Customer Customer { get; set; }
        [Required]
        public BookingState State { get; set; }
        [Required]
        public DateTime PickupTime { get; set; }
        [Required]
        public Tool Tool { get; set; }
        [Required]
        public int Days { get; set; }

        public Booking(int id, Customer customer, BookingState state, DateTime pickuptime, int days)
        {
            this.Id = id;
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