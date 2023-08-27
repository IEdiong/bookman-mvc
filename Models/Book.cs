using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bookman.Models
{
	public class Book
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		[Required]
		public string Name { get; set; } = string.Empty;

		[Required]
		public string Author { get; set; } = string.Empty;

		[Required]
        public string Description { get; set; } = string.Empty;

        [Required]
		public int Year { get; set; }

		[Required]
		public double Price { get; set; }

		[Required]
		public DateTime CreatedAt { get; set; }

		public DateTime UpdatedAt { get; set; }

		public string? FileName { get; set; }
	}
}

