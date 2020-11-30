using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Game.WebApi.Models
{
    [Table("RegisterUser")]
    public class RegisterUser
    {
        [Key]
        public string MobileNo { get; set; }

        [Required(ErrorMessage = "Required Username")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "Username Must be Minimum 2 Charaters")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Required EmailID")]
        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Please enter Valid Email ID")]
        public string EmailId { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Required Password")]
        [MaxLength(30, ErrorMessage = "Password cannot be Greater than 30 Charaters")]
        [StringLength(31, MinimumLength = 7, ErrorMessage = "Password Must be Minimum 7 Charaters")]
        public string Password { get; set; }
        public DateTime JoiningDate { get; set; }

        public string ReferralId { get; set; }

        public string Language { get; set; }

        public string WalletPassword { get; set; }

        public string DecryptPassword { get; set; }

    }
}

