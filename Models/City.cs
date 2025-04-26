﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shipping_System.Models
{
    public class City
    {
        public int Id { get; set; }

        [MaxLength(20, ErrorMessage = "Country name must be less than 20 char")]
        [MinLength(3, ErrorMessage = "Country name must be more than 5 char")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter shipping cost")]
        [Display (Name = "Shipping Cost")]
        public decimal ShippingCost { get; set; }

        [Required(ErrorMessage = "Please enter pick up cost")]
        [Display(Name = "Pickup Cost")]
        public decimal PickUpCost { get; set; }
        public bool IsDeleted { get; set; }
        [ForeignKey ("Country") ]
        public int CountrId { get; set; }
        public virtual Country? Country { get; set; }
        public List<Trader> Traders { get; set; } = new List<Trader>();

    }
}
