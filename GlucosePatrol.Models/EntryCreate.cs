using GlucosePatrol.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlucosePatrol.Models
{
    public class EntryCreate
    {
        [Required]
        //[MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        //[MaxLength(3, ErrorMessage = "There are too many characters in this field.")]
        public int BloodSugarReading { get; set; }
        public Patient Patient { get; set; }
    }
}
