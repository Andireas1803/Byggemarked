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
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public Customer()
        {

        }

        public Customer(int id, string name, string address, string email)
        {
            this.Id = id;
            this.Name = name;
            this.Address = address;
            this.Email = email;
        }
        public override string ToString()
        {
            return Id + " - " + Name + " - " + Address + " - " + Email;
        }
    }
}