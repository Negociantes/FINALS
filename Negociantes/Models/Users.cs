using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Negociantes.Models
{
    public class Users
    {
        [Key]
        public int UserID { get; set; }

        [Required(ErrorMessage = "Required.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Required.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Required.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Required.")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Required.")]
        public string MobileNumber { get; set; }

        [Required(ErrorMessage = "Required.")]
        public string MessengerLink { get; set; }

        [Required(ErrorMessage = "Required.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Required.")]
        public string confirmPassword { get; set; }

        [Display(Name = "Type")]
        public Types Types { get; set; }
    }

    public enum Types
    {
        user = 1,
        mod = 2,
        admin = 3
    }
}
