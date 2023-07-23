using System;
using System.ComponentModel.DataAnnotations;

namespace Bookman.ViewModels
{
	public class BookViewModel
	{
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "Author name is required")]
        public string Author { get; set; } = null!;

        [Required(ErrorMessage = "Year is required")]
        [Range(1990, 2023, ErrorMessage = "Year must be between 1990 to 2023")]
        public int Year { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [Range(500, 20000, ErrorMessage = "Price have to be between 500 to 20000")]
        public double Price { get; set; }

        [Required(ErrorMessage = "Add a description")]
        [StringLength(500, MinimumLength = 30, ErrorMessage = "Description should be between 30 to 500 characters long")]
        public string Description { get; set; } = null!;
        
	}
}

