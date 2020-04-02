using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HomeDepotWebApp.Models
{
    public class CustomerWithLogin : Customer
    {
        [Required]
        public string Username { get; set; }
        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }

        public CustomerWithLogin()
        {

        }

        public CustomerWithLogin(int id, string name, string address, string email, string username, string password) : base(id, name, address, email)
        {
            this.Username = username;
            this.Password = password;
        }

        public override string ToString()
        {
            return base.ToString() + " - " + Username + " - " + Password;
        }
    }
}