using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlucosePatrol.Models
{
    public class EntryEdit
    {
        [Required]
        public int EntryId { get; set; }
        public int BloodSugarReading { get; set; }
    }
}
