using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlucosePatrol.Data
{
    public class Patient
    {
        [Key]
        public int PatientId { get; set; }
        [Required]
        public Guid OwnerId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public float WeightInPounds { get; set; }
        [Required]
        public int HeightInInches { get; set; }
        public string Gender { get; set; }
    }
}
