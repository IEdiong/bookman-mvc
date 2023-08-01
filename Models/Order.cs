using System;
using System.ComponentModel.DataAnnotations;

namespace Bookman.Models
{
	public class Order
	{
        public Order()
        {
        }

        public Order(Book book, string userId, string address
            , string email, string phoneNumber)
        {
            Book = book;
            UserId = userId;
            Address = address;
            Email = email;
            PhoneNumber = phoneNumber;
        }

        [Key]
		public int Id { get; set; }

		public DateTime Date { get; set; }

		public int BookId { get; set; }

        public Book Book { get; set; }

		public string UserId { get; set; }

		public double Price { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

    }

    
}

