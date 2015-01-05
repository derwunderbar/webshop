using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.Web.Mvc;

namespace WebShop.ViewModels
{
    [Serializable]
    public class CustomerViewModel
    {
        [Required]
        public string Title { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [DataType( DataType.EmailAddress )]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        [Display(Name = "House Number")]
        public string HouseNumber { get; set; }

        [Required]
        [RegularExpression(pattern: @"^\d{5}(?:[-]\d{4})?$", ErrorMessage = "Please enter a valid ZIP code.")]
        [Display(Name = "ZIP Code")]
        public string ZipCode { get; set; }
    }
}