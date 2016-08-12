using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL
{
    public class PersonValidation
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public int? Age { get; set; }
    }

    /// <summary>
    /// Link Person Validation to Person
    /// </summary>
    [MetadataType(typeof(PersonValidation))]
    public partial class Person
    {
        public string AgeGroup { get; set; }
    }
}
