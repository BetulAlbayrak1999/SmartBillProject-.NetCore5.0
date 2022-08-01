using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBill.BusinessLogicLayer.ViewModels
{
    public class ProfileFormViewModel
    {

        public string Id { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 3)]
        [Display(Name = "FirstName")]
        public string FirstName { get; set; }


        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 3)]
        [Display(Name = "LastName")]
        public string LastName { get; set; }


        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }


        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 3)]
        [Display(Name = "User Name")]
        public string UserName { get; set; }


        [Required]
        [StringLength(11, ErrorMessage = "The TC Identity must be 11")]
        [Display(Name = "Turkish Identity")]
        public string TurkishIdentity { get; set; }
    }
}
