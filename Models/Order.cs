using System;
using System.ComponentModel.DataAnnotations;

namespace Bookman.Models
{
	public class Order
	{
        public Order()
        {
        }

        public Order(Book book, string userId)
        {
            Book = book;
            UserId = userId;
        }

        [Key]
		public int Id { get; set; }

		public DateTime Date { get; set; }

		public int BookId { get; set; }

		public Book Book { get; set; }

		public string UserId { get; set; }

		public double Price { get; set; }

    }

    
}

