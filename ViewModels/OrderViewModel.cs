using System;
using System.ComponentModel.DataAnnotations;

namespace Bookman.ViewModels
{
	public class OrderViewModel
	{
        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; } = null!;

        [Required(ErrorMessage = "Phone number is required")]
        public string PhoneNumber { get; set; } = null!;

        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; } = null!;

        public int BookId { get; set; }
    }
}

