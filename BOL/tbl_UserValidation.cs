using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL
{


    public class tbl_UserValidation
    {
        /// <summary>
        /// Unique email custom validation
        /// </summary>
        public class UniqueEmailAttribute : ValidationAttribute
        {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                LinkHubDbEntities db = new LinkHubDbEntities();
                string urlValue = value.ToString();
                int count = db.tbl_User.Where(p => p.UserEmail == urlValue).ToList().Count;
                if (count != 0)
                {
                    return new ValidationResult("Email Already Exist");
                }
                return ValidationResult.Success;
            }
        }

        [Required]
        [EmailAddress]
        [UniqueEmail]
        public string UserEmail { get; set; }

        [Required]
        public string Password { get; set; }
    }

    /// <summary>
    /// Link tbl_User Validation to tbl_User
    /// </summary>
    [MetadataType(typeof(tbl_UserValidation))]
    public partial class tbl_User
    {
        [Required]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}
