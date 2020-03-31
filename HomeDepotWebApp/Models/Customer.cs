using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HomeDepotWebApp.Models
{
    public class Customer
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }

        public Customer()
        {

        }

        public Customer(int id, string name, string address)
        {
            this.Id = id;
            this.Name = name;
            this.Address = address;
        }
        public override string ToString()
        {
            return Id + " - " + Name + " - " + Address;
        }
    }
}