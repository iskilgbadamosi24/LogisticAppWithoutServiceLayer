using Shipping_System.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shipping_System.ViewModels.TraderViewModel
{
    public class TraderAndUserViewModel
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

        [Display(Name = "Store Name")]
        public string StoreName { get; set; }

        [Display(Name = "Special Pickup Cost")]
        public int SpecialPickupCost { get; set; }

        //[Display(Name = "Trader Tax For Rejected Orders")]
        //public int TraderTaxForRejectedOrders { get; set; }

        [Display(Name = "Country")]
        [ForeignKey("Country")]
        [Required(ErrorMessage = "Please select country")]
        public int CountrId { get; set; }
        public virtual Country? Country { get; set; }


        [Display(Name = "City")]
        [ForeignKey("City")]
        [Required(ErrorMessage = "Please select city")]
        public int CityId { get; set; }
        public virtual City? City { get; set; }


        [Display(Name = "Branch")]
        [ForeignKey("Branch")]
        [Required(ErrorMessage = "Please select branch")]
        public int BranchId { get; set; }
        public virtual Branch? Branch { get; set; }



        public List<Country>? Countries { get; set; } 
        public List<Branch>? Branchs { get; set; } 
        public List<City>? Cities { get; set; } 

    }
}
