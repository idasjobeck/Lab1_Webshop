using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebshopCore.Dtos
{
    public class ShippingDetailsDto
    {
        [Required(ErrorMessage = "The first name field is a required field.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 50 characters.")]
        public required string FirstName { get; set; }

        [Required(ErrorMessage = "The last name field is a required field.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 50 characters.")]
        public required string LastName { get; set; }

        [Required(ErrorMessage = "The address field is a required field.")]
        public required string Address1 { get; set; }
        public string? Address2 { get; set; }

        [Required(ErrorMessage = "The city field is a required field.")]
        public required string City { get; set; }

        [Required(ErrorMessage = "The zip code field is a required field.")]
        public required string Zip { get; set; }

        [Required(ErrorMessage = "The country field is a required field.")]
        public required string Country { get; set; }

        public WebshopUserDto User { get; set; }
    }
}
