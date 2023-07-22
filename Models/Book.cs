using System;
using System.ComponentModel.DataAnnotations;

namespace Bookman.Models
{
	public class Book
	{
		[Key]
		public int Id { get; set; }

		public string Name { get; set; }

		public string? Author { get; set; }

		public string? Description { get; set; }

		public int Year { get; set; }

		public double Price { get; set; }

		public Book(string name)
		{
			Name = name;
		}
	}
}

