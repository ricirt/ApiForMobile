using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiForMobile.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required(ErrorMessage= "please enter the email")]
        public string Email { get; set; }
        [Required(ErrorMessage ="please enter the password")]
        [StringLength(24,ErrorMessage ="Please colntrol password length (6-24)" ,MinimumLength =6)]
        public string Password { get; set; }
    }
}
