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
        [Range(30, 700)]
        public int BloodSugarReading { get; set; }
        public int PatientId { get; set; }
    }
}
