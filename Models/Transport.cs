using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication5.Models
{
    public class Transport
    {
        public int Id { get; set; }
        [Required]
        [Range(1, 500)]
        public int Number { get; set; }
        [Required]
        [MaxLength(50)]
        public string City { get; set; }
        [Required]
        [MaxLength(50)]
        public string Start { get; set; }
        //[Required]
        [MaxLength(800)]
        public string Process { get; set; }
        [Required]
        [MaxLength(50)]
        public string Finish { get; set; }
        [Required]
        [Range(1, 500)]
        public int StationsCount { get; set; }
        [Required]
        [MaxLength(6)]
        public string Distance { get; set; }
        [Required]
        public int Type { get; set; }
    }
}
