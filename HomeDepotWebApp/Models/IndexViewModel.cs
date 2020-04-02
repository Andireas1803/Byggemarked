using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeDepotWebApp.Models
{
    public class IndexViewModel
    {
        public CustomerWithLogin Customer { get; set; }
        public Booking Booking { get; set; }
    }
}