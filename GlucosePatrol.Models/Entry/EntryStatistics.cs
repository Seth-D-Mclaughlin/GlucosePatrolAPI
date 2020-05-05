using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlucosePatrol.Models
{
    public class EntryStatistics
    {
        [Required]
        public int PatientId { get; set; }
        public string[,] MinMaxAvg { get; set; }
        [Required]
        public DateTime Start { get; set; }
        [Required]
        public DateTime End { get; set; }
        public List<int> BsReadings { get; set; }
    }
}
