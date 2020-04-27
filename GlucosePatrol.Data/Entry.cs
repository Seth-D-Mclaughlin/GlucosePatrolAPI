using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlucosePatrol.Data
{
    public class Entry
    {
        [Key]
        public int EntryId { get; set; } // Which reading it is
        [Required]
        public Guid OwnerId { get; set; } //Who's reading it is

        [Required]
        public int BloodSugarReading { get; set; } //The reading        **Additional adding [MaxLength] [MinLength]**
        [Required]
        public DateTimeOffset CreatedUtc { get; set; } //When the reading was created
        public DateTimeOffset? ModifiedUtc { get; set; }// When the reading was modified time
    }
}
