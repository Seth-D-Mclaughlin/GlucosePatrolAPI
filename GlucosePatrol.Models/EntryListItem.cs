using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlucosePatrol.Models
{
    public class EntryListItem
    {
        [Required]
        public int EntryId { get; set; }
        
        [Required]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(3, ErrorMessage = "There are too many characters in this field.")]
        public int BloodSugarReading { get; set; }
        
        [Display(Name ="Created")]
        public DateTimeOffset CreatedUtc { get; set; }
    }
}
