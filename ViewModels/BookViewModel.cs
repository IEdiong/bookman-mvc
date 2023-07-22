using System;
namespace Bookman.ViewModels
{
	public class BookViewModel
	{
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Author { get; set; } = null!;

        public string Description { get; set; } = null!;

        public int Year { get; set; }

        public double Price { get; set; }

        
	}
}

