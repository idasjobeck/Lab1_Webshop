using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebshopCore
{
    public class UserWithAddressDTO
    {
        [Required(ErrorMessage = "The first name field is a required field.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 50 characters.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "The last name field is a required field.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 50 characters.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "The email field is a required field.")]
        [RegularExpression(@"^[a-zA-Z0-9.!#$%&'*+-/=?^_`{|}~]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$", ErrorMessage = "The email entered must be in a valid format.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "The address field is a required field.")]
        public string Address1 { get; set; }
        public string? Address2 { get; set; }

        [Required(ErrorMessage = "The city field is a required field.")]
        public string City { get; set; }

        [Required(ErrorMessage = "The zip code field is a required field.")]
        public string Zip { get; set; }

        [Required(ErrorMessage = "The country field is a required field.")]
        public string Country { get; set; }
    }
}
