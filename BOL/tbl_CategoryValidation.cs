using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL
{
    public class tbl_CategoryValidation
    {
        [Required]
        public string CategoryName { get; set; }
        [Required]
        public string CategoryDesc { get; set; }
    }

    /// <summary>
    /// Link tbl_Category Validation to tbl_Category
    /// </summary>
    [MetadataType(typeof(tbl_CategoryValidation))]
    public partial class tbl_Category
    { 
        
    }
}
