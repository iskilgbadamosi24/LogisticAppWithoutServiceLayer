using Shipping_System.Models;
using System.ComponentModel.DataAnnotations;

namespace Shipping_System.ViewModels
{
    public class RepresentativeCountryBranchPercentageViewModel
    {

        public string? AppUserId { get; set; }

        [MaxLength(50,
            ErrorMessage = "Name must be less than 50 characters")]
        [MinLength(8,
            ErrorMessage = "Name must be more than 8 characters")]
        public string Name { get; set; }

        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"^([0-9a-zA-Z]([\+\-_\.][0-9a-zA-Z]+)*)+@(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]*\.)+[a-zA-Z0-9]{2,3})$",
            ErrorMessage = "Email address is not valid")]

        public string Email { get; set; }

        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])[A-Za-z\d]{8,16}$",
                    ErrorMessage = "Password must be 8 to 16 characters long with </br> " +
                                    "At least one digit</br>" + "At least one lowercase letter</br>" +
                                    "At least one uppercase letter")]
        public string Password { get; set; }

        public bool IsDeleted { get; set; } = false;

        [RegularExpression(@"^(\+?\d{1,3})?[-. ]?\(?\d{3}\)?[-. ]?\d{3}[-. ]?\d{4}$",
            ErrorMessage = "The Phone number field is not valid")]
        public string Phone { get; set; }

        [MinLength(5,
            ErrorMessage = "Address must be more than 5 characters")]
        [MaxLength(50,
            ErrorMessage = "Address must be less than 50 characters")]
        public string Address { get; set; }

        [Display(Name = "Company Percentage Of Order")]
        public decimal CompanyPercentageOfOrder { get; set; }

        [Display(Name = "Country")]

        [Required(
            ErrorMessage = "Please choose country")]
        public int CountryId { get; set; }
        public List<Country>? Countries { get; set; } //for drop down list

        [Display(Name = "Branch")]
        [Required(
            ErrorMessage = "Please choose branch")]
        public int BranchId { get; set; }
        public List<Branch>? Branchs { get; set; } //for drop down list

        [Display(Name = "Discount Type")]
        public int DiscountTypeId { get; set; }
        public List<DiscountType>? DiscountTypes { get; set; } //for drop down list
    }
}
