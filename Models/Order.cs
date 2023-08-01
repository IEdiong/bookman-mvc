using System;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace Bookman.Models
{
	public class Order
	{
        public Order()
        {
            UserId = string.Empty;
            Address = string.Empty;
            Email = string.Empty;
            PhoneNumber = string.Empty;
        }

        public Order(string userId, string address
            , string email, string phoneNumber)
        {
            UserId = userId;
            Address = address;
            Email = email;
            PhoneNumber = phoneNumber;
        }

        [Key]
		public int Id { get; set; }

		public DateTime Date { get; set; }

		public int BookId { get; set; }

		public string UserId { get; set; }

		public double Price { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

    }
}